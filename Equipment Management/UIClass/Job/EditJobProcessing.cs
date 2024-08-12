using System;
using System.Drawing;
using Equipment_Management.GlobalVariable;
using System.Windows.Forms;
using System.IO;
using Equipment_Management.CustomWindowComponents;

namespace Equipment_Management.UIClass.Job
{
    public partial class EditJobProcessing : Form
    {
        public event EventHandler UpdateGrid;
        ObjectClass.Job editjobToProcess;

        private ToolTip workPermitTooltip;
        private ToolTip contractTooltip;

        string workPermitDocumentPath;
        string contractDocumentPath;

        string targetFilePath;

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
            if (!string.IsNullOrEmpty(editjobToProcess.CasePhoto) && File.Exists(editjobToProcess.CasePhoto))
            {
                if (fixEquipmentPictureBox.Image != null)
                {
                    fixEquipmentPictureBox.Image.Dispose();
                }
                fixEquipmentPictureBox.Image = Image.FromFile(editjobToProcess.CasePhoto);
            }
            processDateTimePicker.Value = editjobToProcess.StartDate.Value;
            vendorNameTextBox.Text = editjobToProcess.VendName;
            vendorDetailsRichTextBox.Text = editjobToProcess.VendDetails;
            fixDetailsRichTextBox.Text  = editjobToProcess.RepairDetails;
            costTextBox.Text = editjobToProcess.Cost.ToString("F2");
            workPermitDocumentPath = editjobToProcess.WorkPermit;
            contractDocumentPath = editjobToProcess.Contract;
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
                }
            }
        }
        //Save PDF file to folder --------------------------------------------------------------------------------
        private void SaveWorkPermitDocument()
        {
            if (!string.IsNullOrEmpty(workPermitDocumentPath))
            {
                SavePhotoToDirectory(workPermitDocumentPath, @"C:\WorkPermitDocument");
                workPermitDocumentPath = targetFilePath;
            }
        }
        private void SaveContractDocument()
        {
            if (!string.IsNullOrEmpty(contractDocumentPath))
            {
                SavePhotoToDirectory(contractDocumentPath, @"C:\ContractDocument");
                contractDocumentPath = targetFilePath;
            }
        }
        
        //Click to open attached PDF file ------------------------------------------------------------------------
        private void workPermitDocLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(workPermitDocumentPath))
            {
                System.Diagnostics.Process.Start(workPermitDocumentPath);
            }
            else if (!string.IsNullOrEmpty(workPermitDocumentPath))
            {
                ShowCustomMessageBox("ไม่สารมารถเปิดไฟล์ดังกล่าวได้\nหรือไฟล์อาจโดนลบ");
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        private void contractLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(contractDocumentPath))
            {
                System.Diagnostics.Process.Start(contractDocumentPath);
            }
            else if (!string.IsNullOrEmpty(contractDocumentPath))
            {
                ShowCustomMessageBox("ไม่สารมารถเปิดไฟล์ดังกล่าวได้\nหรือไฟล์อาจโดนลบ");
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
            SaveWorkPermitDocument();
            SaveContractDocument();
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

        //Saving file to folder Method
        private void SavePhotoToDirectory(string sourceFilePath, string targetDirectory)
        {
            try
            {
                // Check if the directory exists
                if (!Directory.Exists(targetDirectory))
                {
                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(targetDirectory);
                }

                // Define the target file path
                targetFilePath = Path.Combine(targetDirectory, Path.GetFileName(sourceFilePath));

                // Check if the file is locked by another process
                if (IsFileLocked(new FileInfo(sourceFilePath)))
                {
                    ShowCustomMessageBox("ไฟล์นี้กำลังถูกเปิด จึงไม่สามารถก๊อปปี้ได้");
                    return;
                }

                // Copy the file to the target directory
                File.Copy(sourceFilePath, targetFilePath, true); // 'true' allows overwriting if the file already exists

                ShowCustomMessageBox($"File saved to: {targetFilePath}");
            }
            catch (IOException ex)
            {
                ShowCustomMessageBox($"An error occurred: {ex.Message}");
            }
        }
        //Method to check file is being open
        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                // The file is locked by another process
                return true;
            }
            finally
            {
                stream?.Close();
            }

            // The file is not locked
            return false;
        }
    }
}
