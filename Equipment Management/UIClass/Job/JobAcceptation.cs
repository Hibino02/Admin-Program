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

        string targetFilePath;

        string finishPhotoPath;

        private ToolTip finishJobDocumentTooltip;

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

            UpdateComponents();
        }
        private void UpdateComponents()
        {
            equipmentStatusList = EquipmentStatus.GetEquipmentStatusList();
            eStatusComboBox.Items.Clear();
            if (jobToFinish.JEq.OnPlan == true)
            {
                foreach (EquipmentStatus eqis in equipmentStatusList)
                {
                    if (eqis.ID == 7 || eqis.ID == 8)
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
            if (!string.IsNullOrEmpty(jobToFinish.CasePhoto) && File.Exists(jobToFinish.CasePhoto))
            {
                if (fixEquipmentPictureBox.Image != null)
                {
                    fixEquipmentPictureBox.Image.Dispose();
                }
                fixEquipmentPictureBox.Image = Image.FromFile(jobToFinish.CasePhoto);
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
        private void finishDocumentlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(finishDocumentPath))
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
                SavePhotoToDirectory(finishDocumentPath, @"C:\FinishJobDocument");
                finishDocumentPath = targetFilePath;
            }
        }
        private void SaveFinishPhoto()
        {
            if (!string.IsNullOrEmpty(finishPhotoPath))
            {
                SavePhotoToDirectory(finishPhotoPath, @"C:\FinishJobPhoto");
                finishPhotoPath = targetFilePath;
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
                    ShowCustomMessageBox("บันทึกการแจ้งซ่อมเสร็จสมบูรณ์");
                    return;
                }
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
