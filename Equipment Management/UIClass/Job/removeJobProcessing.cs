using System;
using Equipment_Management.CustomWindowComponents;
using System.Drawing;
using Equipment_Management.GlobalVariable;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using System.Collections.Generic;

namespace Equipment_Management.UIClass.Job
{
    public partial class removeJobProcessing : Form
    {
        Equipment_Management.ObjectClass.Job jobProcessingToRemove;
        public event EventHandler UpdateGrid;

        List<EquipmentStatus> equipmentInitialStatusList;
        List<int> equipmentInitialStatusID = new List<int>();
        EquipmentStatus selectedEquipmentStatus;
        Equipment eq;
        string casePhotoToDelete;
        string jobDocumentToDelete;
        string workpermitToDelete;
        string contractTpDelete;

        public removeJobProcessing()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            repairGroupBox.Enabled = false;
            jobProcessingToRemove = new ObjectClass.Job(Global.ID);
            equipmentInitialStatusList = new List<EquipmentStatus>();

            SetEquipmentStatusRollBack();
            SetJobCurrent();
        }
        private void SetEquipmentStatusRollBack()
        {
            if (jobProcessingToRemove.JEq.OnPlan == false)
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
            eNameLabel.Text = jobProcessingToRemove.JEq.Name;
            eSerialLabel.Text = jobProcessingToRemove.JEq.Serial;
            jTypeLabel.Text = jobProcessingToRemove.JType.Type;
            currentELabel.Text = jobProcessingToRemove.JEq.EStatusObj.EStatus;
            jDetailsRichTextBox.Text = jobProcessingToRemove.JDetails;
            aDateLabel.Text = jobProcessingToRemove.ADate.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(jobProcessingToRemove.CasePhoto))
            {
                Global.LoadImageIntoPictureBox(jobProcessingToRemove.CasePhoto, fixEquipmentPictureBox);
            }
            processDateTimePicker.Value = jobProcessingToRemove.StartDate.Value;
            vendorNameTextBox.Text = jobProcessingToRemove.VendName;
            vendorDetailsRichTextBox.Text = jobProcessingToRemove.VendDetails;
            fixDetailsRichTextBox.Text = jobProcessingToRemove.RepairDetails;
            costTextBox.Text = jobProcessingToRemove.Cost.ToString("F2");
            casePhotoToDelete = jobProcessingToRemove.CasePhoto;
            jobDocumentToDelete = jobProcessingToRemove.JDocument;
            workpermitToDelete = jobProcessingToRemove.WorkPermit;
            contractTpDelete = jobProcessingToRemove.Contract;

            // Update link label colors based on file existence
            if (!String.IsNullOrEmpty(workpermitToDelete))
            {
                workPermitDocLinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
            if (!String.IsNullOrEmpty(contractTpDelete))
            {
                contractLinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
        }
        private bool CheckAllAttribute()
        {
            int selectedIndexEStatus = eStatusComboBox.SelectedIndex;
            if (selectedIndexEStatus >= 0 && selectedIndexEStatus < equipmentInitialStatusID.Count)
            {
                int selectedEstatusID = equipmentInitialStatusID[selectedIndexEStatus];

                selectedEquipmentStatus = new EquipmentStatus(selectedEstatusID);
                eq = new Equipment(jobProcessingToRemove.JEq.ID);
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
        private void removeJobProcessingButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                if (jobProcessingToRemove.Remove())
                {
                    Global.DeleteFileFromFtp(casePhotoToDelete);
                    Global.DeleteFileFromFtp(jobDocumentToDelete);
                    Global.DeleteFileFromFtp(workpermitToDelete);
                    Global.DeleteFileFromFtp(contractTpDelete);
                    ShowCustomMessageBox("ลบงานแจ้งซ่อมที่กำลังดำเนินการแล้ว");
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
