using System;
using Equipment_Management.ObjectClass;
using System.Drawing;
using Equipment_Management.GlobalVariable;
using System.Windows.Forms;
using System.Collections.Generic;
using Equipment_Management.CustomWindowComponents;

namespace Equipment_Management.UIClass.Plan
{
    public partial class RemovePlanProcessingForm : Form
    {
        public event EventHandler UpdateGrid;

        List<EquipmentStatus> equipmentStatusList;
        List<int> equipmentStatusID = new List<int>();
        EquipmentStatus selectedEquipmentStatus;
        Equipment equipmentOnPlan;
        Equipment replaceEquipment;

        public RemovePlanProcessingForm()
        {
            InitializeComponent();
            this.Size = new Size(748, 820);
            equipmentStatusList = EquipmentStatus.GetEquipmentStatusList();
            equipmentOnPlan = new Equipment(Global.selectedEquipmentInProcessedPlan.EID);
            if (Global.selectedEquipmentInProcessedPlan.REID > -1)
            {
                replaceEquipment = new Equipment(Global.selectedEquipmentInProcessedPlan.REID ?? 0);
            }

            UpdateProcessingDetails();
            UpdateEquipmentStatusComponents();
        }
        private void UpdateProcessingDetails()
        {
            eNamelabel.Text = Global.selectedEquipmentInProcessedPlan.EName;
            eSeriallabel.Text = Global.selectedEquipmentInProcessedPlan.ESerial;
            eCurrentStatuslabel.Text = equipmentOnPlan.EStatusObj.EStatus;
            if (replaceEquipment != null)
            {
                reCurrentStatuslabel.Text = replaceEquipment.EStatusObj.EStatus;
                reNamelabel.Text = Global.selectedEquipmentInProcessedPlan.REName;
                reSeriallabel.Text = Global.selectedEquipmentInProcessedPlan.RESerial;
            }
            DateToDodateTimePicker.Value = Global.selectedEquipmentInProcessedPlan.ProcessDate;
            Global.LoadImageIntoPictureBox(Global.selectedEquipmentInProcessedPlan.EPhotoPath,EquipmentpictureBox);
        }
        private void UpdateEquipmentStatusComponents()
        {
            equipmentStatusList.Sort((x, y) => x.EStatus.CompareTo(y.EStatus));
            equipmentStatusComboBox.Items.Clear();
            foreach (EquipmentStatus estatus in equipmentStatusList)
            {
                if (estatus.ID == 6 || estatus.ID == 7)
                {
                    equipmentStatusComboBox.Items.Add(estatus.EStatus);
                    equipmentStatusID.Add(estatus.ID);
                }
            }
        }
        
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
            return true;
        }
        private void pRecordbutton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                PlanProcess removePP = new PlanProcess(Global.selectedEquipmentInProcessedPlan.ID);
                if (removePP.Remove())
                {
                    ShowCustomMessageBox("ยกเลิกการดำเนินการ");
                    Global.DeleteFileFromFtp(Global.selectedEquipmentInProcessedPlan.WorkPermit);
                    Global.DeleteFileFromFtp(Global.selectedEquipmentInProcessedPlan.ContractPhoto);
                    ObjectClass.Plan plan = new ObjectClass.Plan(Global.selectedEquipmentInProcessedPlan.PID);
                    plan.DateToDo = DateToDodateTimePicker.Value;
                    plan.Change();
                    //Set status back
                    if(selectedEquipmentStatus.ID == 6)
                    {
                        //Setting if equipment back to operate
                        equipmentOnPlan.EStatusObj = selectedEquipmentStatus;
                        if (equipmentOnPlan.Change())
                        {
                            ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ในแผนเป็น : "+ equipmentOnPlan.EStatusObj.EStatus);
                            //Check if there is replace equipment
                            if (Global.selectedEquipmentInProcessedPlan.REID > -1)
                            {
                                if (replaceEquipment.EStatusObj.ID == 2)
                                {
                                    EquipmentStatus esta = new EquipmentStatus(1);
                                    replaceEquipment.EStatusObj = esta;
                                    if (replaceEquipment.Change())
                                    {
                                        ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนเป็น : " + replaceEquipment.EStatusObj.EStatus);
                                        UpdateGrid?.Invoke(this, EventArgs.Empty);
                                        Close();
                                        return;
                                    }
                                    else
                                    {
                                        ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนล้มเหลว");
                                        return;
                                    }
                                }
                                else
                                {
                                    EquipmentStatus esta = new EquipmentStatus(7);
                                    replaceEquipment.EStatusObj = esta;
                                    if (replaceEquipment.Change())
                                    {
                                        ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนเป็น : " + replaceEquipment.EStatusObj.EStatus);
                                        UpdateGrid?.Invoke(this, EventArgs.Empty);
                                        Close();
                                        return;
                                    }
                                    else
                                    {
                                        ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนล้มเหลว");
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                UpdateGrid?.Invoke(this, EventArgs.Empty);
                                Close();
                            }
                        }
                    }
                    else
                    {
                        //Setting if equipment back to not operate
                        equipmentOnPlan.EStatusObj = selectedEquipmentStatus;
                        if (equipmentOnPlan.Change())
                        {
                            ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ในแผนเป็น : " + equipmentOnPlan.EStatusObj.EStatus);
                            UpdateGrid?.Invoke(this, EventArgs.Empty);
                            Close();
                        }
                    }
                }
                else
                {
                    ShowCustomMessageBox("ยกเลิกการดำเนินการล้มเหลว");
                }
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
    }
}
