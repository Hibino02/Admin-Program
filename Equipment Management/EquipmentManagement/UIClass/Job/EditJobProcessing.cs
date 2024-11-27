using System;
using System.Drawing;
using Admin_Program.GlobalVariable;
using System.Windows.Forms;
using System.IO;
using Admin_Program.CustomWindowComponents;

namespace Admin_Program.UIClass.Job
{
    public partial class EditJobProcessing : Form
    {
        public event EventHandler UpdateGrid;
        ObjectClass.Job editjobToProcess;

        private ToolTip workPermitTooltip;
        private ToolTip contractTooltip;

        string workPermitDocumentPath;
        string oldWorkPermitDocumentPath;
        string contractDocumentPath;
        string oldContractDocumentPath;

        double costFromtextBox;

        public EditJobProcessing()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            editjobToProcess = new ObjectClass.Job(Global.ID);

            //--------------------------------------------------------------------------------------------//
            //WorkPermit Tooltip
            workPermitTooltip = new ToolTip();
            workPermitTooltip.InitialDelay = 0;
            workPermitTooltip.ReshowDelay = 0;
            workPermitTooltip.AutoPopDelay = 5000;
            workPermitDocLinkLabel.MouseEnter += workPermitDocLinkLabel_MouseEnter;
            workPermitDocLinkLabel.MouseLeave += workPermitDocLinkLabel_MouseLeave;
            //--------------------------------------------------------------------------------------------//
            //Contract Tooltip
            contractTooltip = new ToolTip();
            contractTooltip.InitialDelay = 0;
            contractTooltip.ReshowDelay = 0;
            contractTooltip.AutoPopDelay = 5000;
            contractLinkLabel.MouseEnter += contractLinkLabel_MouseEnter;
            contractLinkLabel.MouseLeave += contractLinkLabel_MouseLeave;

            SetJobDetailsComponents();
        }
        private void SetJobDetailsComponents()
        {
            eNameLabel.Text = editjobToProcess.JEq.Name;
            eSerialLabel.Text = editjobToProcess.JEq.Serial;
            jTypeLabel.Text = editjobToProcess.JType.Type;
            currentELabel.Text = editjobToProcess.JEq.EStatusObj.EStatus;
            jDetailsRichTextBox.Text = editjobToProcess.JDetails;
            aDateLabel.Text = editjobToProcess.ADate.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(editjobToProcess.CasePhoto))
            {
                Global.LoadImageIntoPictureBox(editjobToProcess.CasePhoto, fixEquipmentPictureBox);
            }
            processDateTimePicker.Value = editjobToProcess.StartDate.Value;
            vendorNameTextBox.Text = editjobToProcess.VendName;
            vendorDetailsRichTextBox.Text = editjobToProcess.VendDetails;
            fixDetailsRichTextBox.Text  = editjobToProcess.RepairDetails;
            costTextBox.Text = editjobToProcess.Cost.ToString("F2");
            workPermitDocumentPath = editjobToProcess.WorkPermit;
            oldWorkPermitDocumentPath = editjobToProcess.WorkPermit;
            contractDocumentPath = editjobToProcess.Contract;
            oldContractDocumentPath = editjobToProcess.Contract;

            // Update link label colors based on file existence
            if (!String.IsNullOrEmpty(oldWorkPermitDocumentPath))
            {
                workPermitDocLinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
            if (!String.IsNullOrEmpty(oldContractDocumentPath))
            {
                contractLinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
        }
        //Work permit tooltips event -----------------------------------------------------------------------------
        private void workPermitDocLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(workPermitDocumentPath))
            {
                workPermitTooltip.Show($"Attached File: {Path.GetFileName(workPermitDocumentPath)}", workPermitDocLinkLabel);
            }
            else
            {
                workPermitTooltip.Show("No file attached", workPermitDocLinkLabel);
            }
        }
        private void workPermitDocLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            workPermitTooltip.Hide(workPermitDocLinkLabel);
        }
        //Contract tooltips event --------------------------------------------------------------------------------
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
        //Get PDF file path from user ----------------------------------------------------------------------------
        private void workPermitButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workPermitDocumentPath = openFileDialog.FileName;
                    workPermitDocLinkLabel.LinkColor = System.Drawing.Color.Purple;
                    SaveWorkPermitDocument();
                }
            }
        }
        private void contractButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    contractDocumentPath = openFileDialog.FileName;
                    contractLinkLabel.LinkColor = System.Drawing.Color.Purple;
                    SaveContractDocument();
                }
            }
        }
        //Save PDF file to folder --------------------------------------------------------------------------------
        private void SaveWorkPermitDocument()
        {
            if (!string.IsNullOrEmpty(oldWorkPermitDocumentPath))
            {
                Global.DeleteFileFromFtp(oldWorkPermitDocumentPath);
            }
            if (!string.IsNullOrEmpty(workPermitDocumentPath))
            {
                Global.Directory = "WorkPermitDocument";
                Global.SaveFileToServer(workPermitDocumentPath);
                Global.Directory = null;
                workPermitDocumentPath = Global.TargetFilePath;
                oldWorkPermitDocumentPath = workPermitDocumentPath;
            }
        }
        private void SaveContractDocument()
        {
            if (!string.IsNullOrEmpty(oldContractDocumentPath))
            {
                Global.DeleteFileFromFtp(oldContractDocumentPath);
            }
            if (!string.IsNullOrEmpty(contractDocumentPath))
            {
                Global.Directory = "ContractDocument";
                Global.SaveFileToServer(contractDocumentPath);
                Global.Directory = null;
                contractDocumentPath = Global.TargetFilePath;
                oldContractDocumentPath = contractDocumentPath;
            }
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

        //Check repair part
        private bool CheckRepairJob()
        {
            if (string.IsNullOrEmpty(vendorNameTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุชื่อผู้รับเหมา หรือ ผู้ซ่อม");
                return false;
            }
            if (string.IsNullOrEmpty(fixDetailsRichTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุรายละเอียดที่จะทำการซ่อม");
                return false;
            }
            if (string.IsNullOrEmpty(costTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุค่าใช้จ่าย หรือใส่ 0");
                return false;
            }
            else if (!double.TryParse(costTextBox.Text, out costFromtextBox))
            {
                ShowCustomMessageBox("กรุณาใส่ค่าใช้จ่ายเป็นตัวเลขที่ถูกต้อง");
                return false;
            }
            else if (costFromtextBox < 0)
            {
                costFromtextBox = 0;
            }
            return true;
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

        private void processButton_Click(object sender, EventArgs e)
        {
            if (CheckRepairJob())
            {
                //Update details in repair Job
                editjobToProcess.StartDate = processDateTimePicker.Value;
                editjobToProcess.VendName = vendorNameTextBox.Text;
                editjobToProcess.VendDetails = vendorDetailsRichTextBox.Text;
                editjobToProcess.RepairDetails = fixDetailsRichTextBox.Text;
                editjobToProcess.Cost = costFromtextBox;
                editjobToProcess.WorkPermit = workPermitDocumentPath;
                editjobToProcess.Contract = contractDocumentPath;
                if (editjobToProcess.Change())
                {
                    ShowCustomMessageBox("แก้ใขงานแจ้งซ่อมที่กำลังดำเนินการ เสร็จสมบูรณ์");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    ShowCustomMessageBox("การบันทึกสถานะงานแจ้งซ่อมลงในฐานข้อมูลล้มเหลว");
                    return;
                }
            }
        }
    }
}
