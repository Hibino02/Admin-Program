using System;
using System.Collections.Generic;
using System.Drawing;
using Equipment_Management.ObjectClass;
using System.Windows.Forms;
using Equipment_Management.GlobalVariable;
using Equipment_Management.CustomWindowComponents;
using System.IO;

namespace Equipment_Management.UIClass.Plan
{
    public partial class CompletePlanProcessing : Form
    {
        public event EventHandler UpdateGrid;

        List<EquipmentStatus> equipmentStatusList;
        List<int> equipmentStatusID = new List<int>();
        EquipmentStatus selectedEquipmentStatus;

        private ToolTip finDocTooltips;

        string finDocProcessedPath;

        public CompletePlanProcessing()
        {
            InitializeComponent();
            this.Size = new Size(1169, 820);
            equipmentStatusList = EquipmentStatus.GetEquipmentStatusList();

            //--------------------------------------------------------------------------------------------//
            //ToolTips
            finDocTooltips = new ToolTip();
            finDocTooltips.InitialDelay = 0;
            finDocTooltips.ReshowDelay = 0;
            finDocTooltips.AutoPopDelay = 5000;

            finDoclinkLabel.MouseEnter += finDoclinkLabel_MouseEnter;
            finDoclinkLabel.MouseLeave += finDoclinkLabel_MouseLeave;

            UpdateProcessingDetails();
            UpdateEquipmentStatusComponents();
        }
        private void UpdateProcessingDetails()
        {
            eNamelabel.Text = Global.selectedEquipmentInProcessedPlan.EName;
            eSeriallabel.Text = Global.selectedEquipmentInProcessedPlan.ESerial;
            Global.LoadImageIntoPictureBox(Global.selectedEquipmentInProcessedPlan.EPhotoPath, equipmentpictureBox);
            startrichTextBox.Text = Global.selectedEquipmentInProcessedPlan.StartDetails;
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInProcessedPlan.REName))
            {
                eReplaceNamelabel.Text = Global.selectedEquipmentInProcessedPlan.REName;
            }
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInProcessedPlan.RESerial))
            {
                eReplaceSeriallabel.Text = Global.selectedEquipmentInProcessedPlan.RESerial;
            }
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInProcessedPlan.ContractPhoto))
            {
                Global.LoadImageIntoPictureBox(Global.selectedEquipmentInProcessedPlan.ContractPhoto, contractPictureBox);
            }
            startDatelabel.Text = Global.selectedEquipmentInProcessedPlan.ProcessDate.ToString("dd MMM yy");
            vNameTextBox.Text = Global.selectedEquipmentInProcessedPlan.VenderName;
            vDetailsrichTextBox.Text = Global.selectedEquipmentInProcessedPlan.VenderDetails;
            pricetextBox.Text = Global.selectedEquipmentInProcessedPlan.Cost.ToString("F2");
        }
        private void UpdateEquipmentStatusComponents()
        {
            equipmentStatusList.Sort((x, y) => x.EStatus.CompareTo(y.EStatus));
            equipmentStatusComboBox.Items.Clear();
            foreach(EquipmentStatus estatus in equipmentStatusList)
            {
                if(estatus.ID == 6 || estatus.ID == 7)
                {
                    equipmentStatusComboBox.Items.Add(estatus.EStatus);
                    equipmentStatusID.Add(estatus.ID);
                }
            }
        }
        //Get PDF path from user
        private void finDoctbutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    finDocProcessedPath = openFileDialog.FileName;
                }
            }
        }
        //Save documents into folder
        private void SaveFinishDocument()
        {
            if (!string.IsNullOrEmpty(finDocProcessedPath))
            {
                Global.Directory = "FinishPlanProcessDocument";
                Global.SaveFileToServer(finDocProcessedPath);
                Global.Directory = null;
                finDocProcessedPath = Global.TargetFilePath;
            }
        }
        //Open document
        private void finDoclinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(finDocProcessedPath))
            {
                System.Diagnostics.Process.Start(finDocProcessedPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        //Call custom message box
        private void ShowCustomMessageBox(string message)
        {
            using (var messageBox = new CustomMessageBox())
            {
                messageBox.MessageText = message;
                var result = messageBox.ShowDialog();
            }
        }
        //Check All
        private bool CheckAllAttribute()
        {
            int selectIndexStatus = equipmentStatusComboBox.SelectedIndex;
            if (selectIndexStatus >= 0)
            {
                int selectedStatusID = equipmentStatusID[selectIndexStatus];
                selectedEquipmentStatus = new EquipmentStatus(selectedStatusID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกสถานะอุปกรณ์หลังเสร็จ");
                return false;
            }
            SaveFinishDocument();
            return true;
        }

        private void finRecordbutton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                //Prepare object for update
                PlanProcess newPP = new PlanProcess(Global.selectedEquipmentInProcessedPlan.ID);
                ObjectClass.Plan newP = new ObjectClass.Plan(Global.selectedEquipmentInProcessedPlan.PID);
                Equipment equipmentOnPlan = new Equipment(Global.selectedEquipmentInProcessedPlan.EID);
                //Check if there is replace equipment selected
                Equipment replaceEquipment = null;
                if (Global.selectedEquipmentInProcessedPlan.REID > -1)
                {
                    replaceEquipment = new Equipment(Global.selectedEquipmentInProcessedPlan.REID??-1);
                }
                //Update variable before change
                newPP.FinishDate = finishDateTimePicker.Value;
                newPP.FinishDetails = finRichTextBox.Text;
                newPP.FinishDoc = finDocProcessedPath;
                newP.DateToDo = nextOPTdateTimePicker.Value;
                equipmentOnPlan.EStatusObj = selectedEquipmentStatus;
                if (replaceEquipment != null)
                {
                    if(equipmentOnPlan.EStatusObj.ID != 7)
                    {
                        if (replaceEquipment.ID == 6)
                        {
                            EquipmentStatus esta = new EquipmentStatus(7);
                            replaceEquipment.EStatusObj = esta;
                        }
                        else
                        {
                            EquipmentStatus esta = new EquipmentStatus(1);
                            replaceEquipment.EStatusObj = esta;
                        }
                    }
                }
                //Begin changes
                if (newPP.Change())
                {
                    ShowCustomMessageBox("ดำเนินการตามแผนเสร็จสมบูรณ์");
                    if (newP.Change())
                    {
                        ShowCustomMessageBox("กำหนดรอบถัดไปของแผน คือ : " + newP.DateToDo?.ToString("MMM dd, yyy"));
                        if (equipmentOnPlan.Change())
                        {
                            ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ของแผนนี้เป็น "+ equipmentOnPlan.EStatusObj.EStatus);
                            if (replaceEquipment != null)
                            {
                                if (replaceEquipment.Change())
                                {
                                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนเป็น " + replaceEquipment.EStatusObj.EStatus);
                                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                                    Close();
                                    return;
                                }
                                else
                                {
                                    ShowCustomMessageBox("Replace Equipment Update Fails");
                                }
                            }
                            ShowCustomMessageBox("ไม่มีอุปกรณ์ทดแทน ในการซ่อมบำรุงครั้งนี้");
                            UpdateGrid?.Invoke(this, EventArgs.Empty);
                            Close();
                        }
                        else
                        {
                            ShowCustomMessageBox("Equipment On Plan Update Fails");
                        }
                    }
                    else
                    {
                        ShowCustomMessageBox("Plan Update Fails");
                    }
                }
                else
                {
                    ShowCustomMessageBox("Plan Processing Update Fails");
                    Global.DeleteFileFromFtp(finDocProcessedPath);
                }
            }
        }
        //Event for Tooltips
        private void finDoclinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(finDocProcessedPath))
            {
                finDocTooltips.Show($"Attached File: {Path.GetFileName(finDocProcessedPath)}", finDoclinkLabel);
            }
            else
            {
                finDocTooltips.Show("No file attached", finDoclinkLabel);
            }
        }
        private void finDoclinkLabel_MouseLeave(object sender, EventArgs e)
        {
            finDocTooltips.Hide(finDoclinkLabel);
        }
    }
}
