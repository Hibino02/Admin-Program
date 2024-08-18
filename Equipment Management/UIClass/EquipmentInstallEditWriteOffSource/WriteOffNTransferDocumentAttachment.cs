using System;
using System.Drawing;
using Equipment_Management.CustomWindowComponents;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.GlobalVariable;
using System.IO;

namespace Equipment_Management.UIClass.EquipmentInstallEditWriteOffSource
{
    public partial class WriteOffNTransferDocumentAttachment : Form
    {
        Equipment equipmentDocAttach = Global.equipmentGlobal;
        string writeOffDocumentPath;

        EquipmentStatus estatus;

        private ToolTip toolTip1;

        public WriteOffNTransferDocumentAttachment()
        {
            InitializeComponent();
            this.Size = new Size(500, 226);

            toolTip1 = new ToolTip();
            toolTip1.InitialDelay = 0;
            toolTip1.ReshowDelay = 0;
            toolTip1.AutoPopDelay = 5000;

            documentLinkLabel.MouseHover += documentLinkLabel_MouseEnter;
            documentLinkLabel.MouseLeave += documentLinkLabel_MouseLeave;
        }
        //Attach PDF from user
        private void attachDocumentButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    writeOffDocumentPath = openFileDialog.FileName;
                }
            }
        }
        //Open Invoice
        private void documentLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(writeOffDocumentPath))
            {
                System.Diagnostics.Process.Start(writeOffDocumentPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        
        //Save documents into folder
        private void SaveWriteOffDocument()
        {
            if (!string.IsNullOrEmpty(writeOffDocumentPath))
            {
                Global.Directory = "WriteOffNTransferDocument";
                Global.SaveFileToServer(writeOffDocumentPath);
                Global.Directory = null;
                writeOffDocumentPath = Global.TargetFilePath;
            }
        }
        //Check everything
        private bool CheckAllAttributes()
        {
            if (string.IsNullOrEmpty(writeOffDocumentPath))
            {
                ShowCustomMessageBox("กรุณาแนบเอกสาร Write-Off หรือ Transfer");
                return false;
            }
            else
            {
                SaveWriteOffDocument();
            }
            return true;
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
        private void OKButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttributes())
            {
                equipmentDocAttach.WriteOffPath = writeOffDocumentPath;
                estatus = new EquipmentStatus(10);
                equipmentDocAttach.EStatusObj = estatus;
                if (equipmentDocAttach.Change())
                {
                    ShowCustomMessageBox("ทำการเปลี่ยนสถานะอุปกรณ์เป็น เลิกใช้งาน");
                    CloseFormByName("WriteOffAndTransferEquipmentForm");
                    Close();
                }
               else
                {
                    ShowCustomMessageBox("ขั้นตอนการอัพเดทข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                    Global.DeleteFileFromFtp(writeOffDocumentPath);
                }
            }
        }
        //Method to close form
        private void CloseFormByName(string formName)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == formName)
                {
                    form.Close();
                    break; // Exit the loop once the form is found and closed
                }
            }
        }
        //Event to show tooltips    
        private void documentLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(writeOffDocumentPath))
            {
                toolTip1.Show($"Attached File: {Path.GetFileName(writeOffDocumentPath)}", documentLinkLabel);
            }
            else
            {
                toolTip1.Show("No file attached", documentLinkLabel);
            }
        }
        private void documentLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Hide(documentLinkLabel);
        }
    }
}
