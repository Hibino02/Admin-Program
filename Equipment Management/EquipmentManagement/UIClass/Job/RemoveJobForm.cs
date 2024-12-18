﻿using System;
using Admin_Program.CustomWindowComponents;
using System.Drawing;
using Admin_Program.GlobalVariable;
using System.Windows.Forms;
using Admin_Program.ObjectClass;
using System.Collections.Generic;

namespace Admin_Program.UIClass.Job
{
    public partial class RemoveJobForm : Form
    {
        Admin_Program.ObjectClass.Job jobToRemove;
        public event EventHandler UpdateGrid;

        List<EquipmentStatus> equipmentInitialStatusList;
        List<int> equipmentInitialStatusID = new List<int>();
        EquipmentStatus selectedEquipmentStatus;
        Equipment eq;
        string casePhotoToDelete;
        string jobDocumentToDelete;

        public RemoveJobForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            groupBox1.Enabled = false;
            button1.BringToFront();
            choseEquipmentLabel.BringToFront();
            eStatusComboBox.BringToFront();
            jobToRemove = new ObjectClass.Job(Global.ID);
            equipmentInitialStatusList = new List<EquipmentStatus>();
            SetJobCurrent();
            SetEquipmentStatusRollBack();
        }
        private void SetEquipmentStatusRollBack()
        {
            if(jobToRemove.JEq.OnPlan == false)
            {
                equipmentInitialStatusList = EquipmentStatus.GetEquipmentStatusList();
                eStatusComboBox.Items.Clear();
                foreach (EquipmentStatus eqis in equipmentInitialStatusList)
                {
                    if (eqis.ID == 1 || eqis.ID == 2 || eqis.ID == 3)
                    {
                        eStatusComboBox.Items.Add(eqis.EStatus);
                        equipmentInitialStatusID.Add(eqis.ID);
                    }
                }
            }
            else
            {
                equipmentInitialStatusList = EquipmentStatus.GetEquipmentStatusList();
                eStatusComboBox.Items.Clear();
                foreach (EquipmentStatus eqis in equipmentInitialStatusList)
                {
                    if (eqis.ID == 6 || eqis.ID == 7)
                    {
                        eStatusComboBox.Items.Add(eqis.EStatus);
                        equipmentInitialStatusID.Add(eqis.ID);
                    }
                }
            }
        }
        private void SetJobCurrent()
        {
            eNametextBox.Text = jobToRemove.JEq.Name;
            eSerialtextBox.Text = jobToRemove.JEq.Serial;
            currentStatusComboBox.Text = jobToRemove.JEq.EStatusObj.EStatus;
            repairTypeComboBox.Text = jobToRemove.JType.Type;
            reporterNameTextBox.Text = jobToRemove.Reporter;
            reportDateTimePicker.Value = jobToRemove.RDate.Value;
            reasdonToChoserepairRichTextBox.Text = jobToRemove.JTypeReason;
            deciderNameTextBox.Text = jobToRemove.Decider;
            decideDateTimePicker.Value = jobToRemove.DDate.Value;
            if (!string.IsNullOrEmpty(jobToRemove.CasePhoto))
            {
                Global.LoadImageIntoPictureBox(jobToRemove.CasePhoto, equipmentRepaiePictureBox);
            }
            jDetailsrichTextBox.Text = jobToRemove.JDetails;
            reasonToAppRichTextBox.Text = jobToRemove.AppReason;
            approveCheckBox.Checked = jobToRemove.Approve;
            jobDocumentToDelete = jobToRemove.JDocument;
            casePhotoToDelete = jobToRemove.CasePhoto;
        }
        private bool CheckAllAttribute()
        {
            int selectedIndexEStatus = eStatusComboBox.SelectedIndex;
            if(selectedIndexEStatus >= 0 && selectedIndexEStatus < equipmentInitialStatusID.Count)
            {
                int selectedEstatusID = equipmentInitialStatusID[selectedIndexEStatus];

                selectedEquipmentStatus = new EquipmentStatus(selectedEstatusID);
                eq = new Equipment(jobToRemove.JEq.ID);
                eq.EStatusObj = selectedEquipmentStatus;
                if (eq.Change())
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์สมบูรณ์");
                    return true;
                }
                else
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว");
                    return false;
                }
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกสถานะของอุปกรณ์");
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                if (jobToRemove.Remove())
                {
                    Global.DeleteFileFromFtp(jobDocumentToDelete);
                    Global.DeleteFileFromFtp(casePhotoToDelete);
                    ShowCustomMessageBox("ลบงานแจ้งซ่อมที่ยังไม่ได้ดำเนินการแล้ว");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    ShowCustomMessageBox("การลบผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }          
        }
        //Methodto call custom message Box
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
