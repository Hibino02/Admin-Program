using System;
using System.Drawing;
using System.IO;
using Equipment_Management.GlobalVariable;
using System.Windows.Forms;
using Equipment_Management.CustomWindowComponents;
using Equipment_Management.ObjectClass;
using System.Collections.Generic;

namespace Equipment_Management.UIClass.Job
{
    public partial class JobAcceptation : Form
    {
        public event EventHandler UpdateGrid;
        ObjectClass.Job jobToFinish;
        EquipmentStatus selectedEquipmentStatus;
        List<EquipmentStatus> equipmentStatusList;
        List<int> equipmentStatusID = new List<int>();

        string workPermitDocumentPath;
        string contractDocumentPath;
        string finishDocumentPath;

        string finishPhotoPath;

        private ToolTip finishJobDocumentTooltip;
        private ToolTip workpermitTooltip;
        private ToolTip contractTooltip;

        public JobAcceptation()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            jobToFinish = new ObjectClass.Job(Global.ID);
            equipmentStatusList = new List<EquipmentStatus>();
            SetJobDetailsComponents();

            //--------------------------------------------------------------------------------------------//
            //Finish Job Document Tooltip
            finishJobDocumentTooltip = new ToolTip();
            finishJobDocumentTooltip.InitialDelay = 0;
            finishJobDocumentTooltip.ReshowDelay = 0;
            finishJobDocumentTooltip.AutoPopDelay = 5000;
            finishDocumentlinkLabel.MouseEnter += finishDocumentlinkLabel_MouseEnter;
            finishDocumentlinkLabel.MouseLeave += finishDocumentlinkLabel_MouseLeave;
            // --------------------------------------------------------------------------------------------//
            //Workpermit Document Tooltip
            workpermitTooltip = new ToolTip();
            workpermitTooltip.InitialDelay = 0;
            workpermitTooltip.ReshowDelay = 0;
            workpermitTooltip.AutoPopDelay = 5000;
            workPermitDocLinkLabel.MouseEnter += workPermitDocLinkLabel_MouseEnter;
            workPermitDocLinkLabel.MouseLeave += workPermitDocLinkLabel_MouseLeave;
            // --------------------------------------------------------------------------------------------//
            //Contract Document Tooltip
            contractTooltip = new ToolTip();
            contractTooltip.InitialDelay = 0;
            contractTooltip.ReshowDelay = 0;
            contractTooltip.AutoPopDelay = 5000;
            contractLinkLabel.MouseEnter += contractLinkLabel_MouseEnter;
            contractLinkLabel.MouseLeave += contractLinkLabel_MouseLeave;

            UpdateComponents();
        }
        private void UpdateComponents()
        {
            equipmentStatusList = EquipmentStatus.GetEquipmentStatusList();
            eStatusComboBox.Items.Clear();
            equipmentStatusID.Clear();
            if (jobToFinish.JEq.OnPlan == true)
            {
                foreach (EquipmentStatus eqis in equipmentStatusList)
                {
                    if (eqis.ID == 6 || eqis.ID == 7)
                    {
                        eStatusComboBox.Items.Add(eqis.EStatus);
                        equipmentStatusID.Add(eqis.ID);
                    }
                }
            }
            else
            {
                foreach (EquipmentStatus eqis in equipmentStatusList)
                {
                    if (eqis.ID == 1 || eqis.ID == 2)
                    {
                        eStatusComboBox.Items.Add(eqis.EStatus);
                        equipmentStatusID.Add(eqis.ID);
                    }
                }
            }
        }
        private void SetJobDetailsComponents()
        {
            eNameLabel.Text = jobToFinish.JEq.Name;
            eSerialLabel.Text = jobToFinish.JEq.Serial;
            jTypeLabel.Text = jobToFinish.JType.Type;
            currentELabel.Text = jobToFinish.JEq.EStatusObj.EStatus;
            jDetailsRichTextBox.Text = jobToFinish.JDetails;
            aDateLabel.Text = jobToFinish.ADate.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(jobToFinish.CasePhoto))
            {
                Global.LoadImageIntoPictureBox(jobToFinish.CasePhoto, fixEquipmentPictureBox);
            }
            startDateLabel.Text = jobToFinish.StartDate?.ToString("yyyy-MM-dd")??"ไม่ได้ระบุ";
            vendorNameTextBox.Text = jobToFinish.VendName;
            vendorDetailsRichTextBox.Text = jobToFinish.VendDetails;
            fixDetailsRichTextBox.Text = jobToFinish.RepairDetails;
            costTextBox.Text = jobToFinish.Cost.ToString();
            workPermitDocumentPath = jobToFinish.WorkPermit;
            contractDocumentPath = jobToFinish.Contract;
        }
        //Click to open attached PDF file ------------------------------------------------------------------------
        private void workPermitDocLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(workPermitDocumentPath))
            {
                Global.DownloadAndOpenPdf(workPermitDocumentPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        private void contractLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(contractDocumentPath))
            {
                Global.DownloadAndOpenPdf(contractDocumentPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        private void finishDocumentlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(finishDocumentPath))
            {
                System.Diagnostics.Process.Start(finishDocumentPath);
            }
            else if (!string.IsNullOrEmpty(finishDocumentPath))
            {
                ShowCustomMessageBox("ไม่สารมารถเปิดไฟล์ดังกล่าวได้\nหรือไฟล์อาจโดนลบ");
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        //Get PDF file path from user ----------------------------------------------------------------------------
        private void finishDocumentbutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    finishDocumentPath = openFileDialog.FileName;
                }
            }
        }
        //Save PDF & Photo file to folder ------------------------------------------------------------------------
        private void SaveFinishDocument()
        {
            if (!string.IsNullOrEmpty(finishDocumentPath))
            {
                Global.Directory = "FinishJobDocument";
                Global.SaveFileToServer(finishDocumentPath);
                Global.Directory = null;
                finishDocumentPath = Global.TargetFilePath;
            }
        }
        private void SaveFinishPhoto()
        {
            if (!string.IsNullOrEmpty(finishPhotoPath))
            {
                Global.Directory = "FinishJobPhoto";
                Global.SaveFileToServer(finishPhotoPath);
                Global.Directory = null;
                finishPhotoPath = Global.TargetFilePath;
            }
        }
        //Get pictures path from user and streamto picturebox ----------------------------------------------------
        private void finishPhotobutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path from user
                    finishPhotoPath = openFileDialog.FileName;
                    //Strem photo to picturebox
                    finishPictureBox.Image = Image.FromFile(finishPhotoPath);
                }
            }
        }
        //Event to call Tooltips ---------------------------------------------------------------------------------
        private void finishDocumentlinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(finishDocumentPath))
            {
                finishJobDocumentTooltip.Show($"Attached File: {Path.GetFileName(finishDocumentPath)}", finishDocumentlinkLabel);
            }
            else
            {
                finishJobDocumentTooltip.Show("No file attached", finishDocumentlinkLabel);
            }
        }
        private void finishDocumentlinkLabel_MouseLeave(object sender, EventArgs e)
        {
            finishJobDocumentTooltip.Hide(finishDocumentlinkLabel);
        }
        private void workPermitDocLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(workPermitDocumentPath))
            {
                workpermitTooltip.Show($"Attached File: {Path.GetFileName(workPermitDocumentPath)}", workPermitDocLinkLabel);
            }
            else
            {
                workpermitTooltip.Show("No file attached", workPermitDocLinkLabel);
            }
        }
        private void workPermitDocLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            workpermitTooltip.Hide(workPermitDocLinkLabel);
        }
        private void contractLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(contractDocumentPath))
            {
                contractTooltip.Show($"Attached File: {Path.GetFileName(contractDocumentPath)}", contractLinkLabel);
            }
            else
            {
                contractTooltip.Show("No file attached", contractLinkLabel);
            }
        }
        private void contractLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            contractTooltip.Hide(contractLinkLabel);
        }
        //Method to call custom message Box
        private void ShowCustomMessageBox(string message)
        {
            using (var messageBox = new CustomMessageBox())
            {
                messageBox.MessageText = message;
                var result = messageBox.ShowDialog();
            }
        }

        private bool CheckAllAttribute()
        {
            if (string.IsNullOrEmpty(acceptorNametextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุชื่อผู้ตรวจรับงาน");
                return false;
            }
            int selectedIndexEStatus = eStatusComboBox.SelectedIndex;
            if (selectedIndexEStatus >= 0 && selectedIndexEStatus < equipmentStatusID.Count)
            {
                int selectedEstatusID = equipmentStatusID[selectedIndexEStatus];
                selectedEquipmentStatus = new EquipmentStatus(selectedEstatusID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกสถานะอุปกรณ์หลังจากซ่อม");
                return false;
            }
            SaveFinishPhoto();
            SaveFinishDocument();
            return true;
        }

        private void finishRepairJobbutton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                Equipment finishEquipment = new Equipment(jobToFinish.JEq.ID);
                finishEquipment.EStatusObj = selectedEquipmentStatus;
                if (finishEquipment.Change())
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์สมบูรณ์");
                }
                else
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว");
                    return;
                }
                jobToFinish.FinishDate = finishDateTimePicker.Value;
                jobToFinish.FinishPhoto = finishPhotoPath;
                jobToFinish.FinishDocument = finishDocumentPath;
                jobToFinish.Acceptor = acceptorNamelabel.Text;
                jobToFinish.JobStatus = true;
                if (jobToFinish.Change())
                {
                    ShowCustomMessageBox("บันทึกการแจ้งซ่อมเสร็จสมบูรณ์");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    Global.DeleteFileFromFtp(finishDocumentPath);
                    Global.DeleteFileFromFtp(finishPhotoPath);
                    ShowCustomMessageBox("บันทึกการแจ้งซ่อมเสร็จสมบูรณ์");
                    return;
                }
            }
        }

        
    }
}
