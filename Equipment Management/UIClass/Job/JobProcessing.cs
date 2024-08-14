using System;
using System.Collections.Generic;
using Equipment_Management.CustomViewClass;
using System.Drawing;
using Equipment_Management.GlobalVariable;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Equipment_Management.CustomWindowComponents;
using Equipment_Management.ObjectClass;

namespace Equipment_Management.UIClass.Job
{
    public partial class JobProcessing : Form
    {
        public event EventHandler UpdateGrid;
        ObjectClass.Job jobToProcess;

        private ToolTip writeOffTooltip;
        private ToolTip workPermitTooltip;
        private ToolTip contractTooltip;

        private PictureBox originalReplacePicturebox;
        private PictureBox selectedReplacePicturebox;

        string writeOffDocumentPath;
        string workPermitDocumentPath;
        string contractDocumentPath;

        double costFromtextBox;

        Equipment JREq;

        BindingSource replaceEquipmentListBindingSource;
        List<AllEquipmentView> replaceEquipmentList;
        List<AllEquipmentView> equipmentSelectedList;

        public JobProcessing()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            jobToProcess = new ObjectClass.Job(Global.ID);
            replaceEquipmentList = new List<AllEquipmentView>();
            equipmentSelectedList = new List<AllEquipmentView>();
            replaceEquipmentListBindingSource = new BindingSource();

            //--------------------------------------------------------------------------------------------//
            //WriteOff Tooltip
            writeOffTooltip = new ToolTip();
            writeOffTooltip.InitialDelay = 0;
            writeOffTooltip.ReshowDelay = 0;
            writeOffTooltip.AutoPopDelay = 5000;
            writeOffLinkLabel1.MouseEnter += writeOffLinkLabel1_MouseEnter;
            writeOffLinkLabel1.MouseLeave += writeOffLinkLabel1_MouseLeave;
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

            //--------------------------------------------------------------------------------------------//
            //Original replace equipment hidden picturebox
            originalReplacePicturebox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(originalReplacePicturebox);
            equipmentDisplaydataGridView.CellMouseEnter += equipmentDisplaydataGridView_CellMouseEnter;
            equipmentDisplaydataGridView.CellMouseLeave += equipmentDisplaydataGridView_CellMouseLeave;
            //--------------------------------------------------------------------------------------------//
            //Selected replace equipment hidden picturebox
            selectedReplacePicturebox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(selectedReplacePicturebox);
            equipmentSelecteddataGridView.CellMouseEnter += equipmentSelecteddataGridView_CellMouseEnter;
            equipmentSelecteddataGridView.CellMouseLeave += equipmentSelecteddataGridView_CellMouseLeave;

            equipmentDisplaydataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            equipmentSelecteddataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SetJobDetailsComponents();
            CheckJobType();
            UpdateReplaceEquipmentGridView();
            UpdateSelectedReplaceEquipmentGridView();
        }
        private void SetJobDetailsComponents()
        {
            eNameLabel.Text = jobToProcess.JEq.Name;
            eSerialLabel.Text = jobToProcess.JEq.Serial;
            jTypeLabel.Text = jobToProcess.JType.Type;
            currentELabel.Text = jobToProcess.JEq.EStatusObj.EStatus;
            jDetailsRichTextBox.Text = jobToProcess.JDetails;
            aDateLabel.Text = jobToProcess.ADate.Value.ToString("yyyy-MM-dd");
            if (!string.IsNullOrEmpty(jobToProcess.CasePhoto) && File.Exists(jobToProcess.CasePhoto))
            {
                if (fixEquipmentPictureBox.Image != null)
                {
                    fixEquipmentPictureBox.Image.Dispose();
                }
                fixEquipmentPictureBox.Image = Image.FromFile(jobToProcess.CasePhoto);
            }
        }
        private void CheckJobType()
        {
            if(jobToProcess.JType.ID == 3 || jobToProcess.JType.ID == 4)
            {
                buyGroupBox.Enabled = false;
            }
            else
            {
                repairGroupBox.Enabled = false;
            }
        }
        //Buy rent transfer part ---------------------------------------------------------------------------------
        private void UpdateReplaceEquipmentGridView()
        {
            replaceEquipmentList = AllEquipmentView.GetJobProcessEquipmentView();
            replaceEquipmentListBindingSource.DataSource = replaceEquipmentList;
            equipmentDisplaydataGridView.DataSource = replaceEquipmentListBindingSource;

            FormatReplaceEquipmentListDataGridView();
        }
        private void UpdateSelectedReplaceEquipmentGridView()
        {
            if(Global.selectedEquipmentInJob != null)
            {
                // Adding the selected equipment to the selected list
                equipmentSelectedList = new List<AllEquipmentView> { Global.selectedEquipmentInJob };

                // Binding the selected list to the DataGridView
                equipmentSelecteddataGridView.DataSource = equipmentSelectedList;
            }
        }
        private void FormatReplaceEquipmentListDataGridView()
        {
            if (equipmentDisplaydataGridView.Columns["ID"] != null)
            {
                equipmentDisplaydataGridView.Columns["ID"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["Name"] != null)
            {
                equipmentDisplaydataGridView.Columns["Name"].HeaderText = "ชื่อเรียกอุปกรณ์";
            }
            if (equipmentDisplaydataGridView.Columns["Serial"] != null)
            {
                equipmentDisplaydataGridView.Columns["Serial"].HeaderText = "ชื่อทางบัญชี";
            }
            if (equipmentDisplaydataGridView.Columns["EStatusID"] != null)
            {
                equipmentDisplaydataGridView.Columns["EStatusID"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["EStatus"] != null)
            {
                equipmentDisplaydataGridView.Columns["EStatus"].HeaderText = "สถานะปัจจุบัน";
            }
            if (equipmentDisplaydataGridView.Columns["ETypeID"] != null)
            {
                equipmentDisplaydataGridView.Columns["ETypeID"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["EquipmentPhoto"] != null)
            {
                equipmentDisplaydataGridView.Columns["EquipmentPhoto"].HeaderText = "ภาพอุปกรณ์";
            }
            //No use columns
            if (equipmentDisplaydataGridView.Columns["EDetails"] != null)
            {
                equipmentDisplaydataGridView.Columns["EDetails"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["InsDate"] != null)
            {
                equipmentDisplaydataGridView.Columns["InsDate"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["EType"] != null)
            {
                equipmentDisplaydataGridView.Columns["EType"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["EOwner"] != null)
            {
                equipmentDisplaydataGridView.Columns["EOwner"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["InsDetails"] != null)
            {
                equipmentDisplaydataGridView.Columns["InsDetails"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["InstallEPhoto"] != null)
            {
                equipmentDisplaydataGridView.Columns["InstallEPhoto"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["Replacement"] != null)
            {
                equipmentDisplaydataGridView.Columns["Replacement"].Visible = false;
            }
        }
        private void FormatReplaceSelectedEquipmentListDataGridView()
        {
            if (equipmentSelecteddataGridView.Columns["ID"] != null)
            {
                equipmentSelecteddataGridView.Columns["ID"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["Name"] != null)
            {
                equipmentSelecteddataGridView.Columns["Name"].HeaderText = "ชื่อเรียกอุปกรณ์";
            }
            if (equipmentSelecteddataGridView.Columns["Serial"] != null)
            {
                equipmentSelecteddataGridView.Columns["Serial"].HeaderText = "ชื่อทางบัญชี";
            }
            if (equipmentSelecteddataGridView.Columns["EStatusID"] != null)
            {
                equipmentSelecteddataGridView.Columns["EStatusID"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["EStatus"] != null)
            {
                equipmentSelecteddataGridView.Columns["EStatus"].HeaderText = "สถานะปัจจุบัน";
            }
            if (equipmentSelecteddataGridView.Columns["ETypeID"] != null)
            {
                equipmentSelecteddataGridView.Columns["ETypeID"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["EquipmentPhoto"] != null)
            {
                equipmentSelecteddataGridView.Columns["EquipmentPhoto"].HeaderText = "ภาพอุปกรณ์";
            }
            //No use columns
            if (equipmentSelecteddataGridView.Columns["EDetails"] != null)
            {
                equipmentSelecteddataGridView.Columns["EDetails"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["InsDate"] != null)
            {
                equipmentSelecteddataGridView.Columns["InsDate"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["EType"] != null)
            {
                equipmentSelecteddataGridView.Columns["EType"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["EOwner"] != null)
            {
                equipmentSelecteddataGridView.Columns["EOwner"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["InsDetails"] != null)
            {
                equipmentSelecteddataGridView.Columns["InsDetails"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["InstallEPhoto"] != null)
            {
                equipmentSelecteddataGridView.Columns["InstallEPhoto"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["Replacement"] != null)
            {
                equipmentSelecteddataGridView.Columns["Replacement"].Visible = false;
            }
        }
        //Add replacement equipment to another grid
        private void equipmentDisplaydataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex >= 0)
                {
                    int selectedID = (int)equipmentDisplaydataGridView.Rows[e.RowIndex].Cells["ID"].Value;

                    Global.selectedEquipmentInJob = replaceEquipmentList.FirstOrDefault(eq => eq.ID == selectedID);

                    // Update the selected equipment list and refresh the grid
                    UpdateSelectedReplaceEquipmentGridView();
                    FormatReplaceSelectedEquipmentListDataGridView();
                    equipmentDisplaydataGridView.Enabled = false;
                    originalReplacePicturebox.Visible = false;
                }
            }
        }
        //Remove replacement equipment
        private void equipmentSelecteddataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            equipmentSelectedList.Clear();
            equipmentSelecteddataGridView.DataSource = null;
            Global.selectedEquipmentInJob = null;

            equipmentSelecteddataGridView.Refresh();

            equipmentDisplaydataGridView.Enabled = true;
            selectedReplacePicturebox.Visible = false;
        }
        //Write Off tooltips event -------------------------------------------------------------------------------
        private void writeOffLinkLabel1_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(writeOffDocumentPath))
            {
                writeOffTooltip.Show($"Attached File: {Path.GetFileName(writeOffDocumentPath)}", writeOffLinkLabel1);
            }
            else
            {
                writeOffTooltip.Show("No file attached", writeOffLinkLabel1);
            }
        }
        private void writeOffLinkLabel1_MouseLeave(object sender, EventArgs e)
        {
            writeOffTooltip.Hide(writeOffLinkLabel1);
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
        private void writeOffButton_Click(object sender, EventArgs e)
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
        private void SaveWriteOffDocument()
        {
            if (!string.IsNullOrEmpty(writeOffDocumentPath))
            {
                Global.SaveFileToServer(writeOffDocumentPath, "WriteOffDocument");
                writeOffDocumentPath = Global.TargetFilePath;
            }
        }
        private void SaveWorkPermitDocument()
        {
            if (!string.IsNullOrEmpty(workPermitDocumentPath))
            {
                Global.SaveFileToServer(workPermitDocumentPath, "WorkPermitDocument");
                workPermitDocumentPath = Global.TargetFilePath;
            }
        }
        private void SaveContractDocument()
        {
            if (!string.IsNullOrEmpty(contractDocumentPath))
            {
                Global.SaveFileToServer(contractDocumentPath, "ContractDocument");
                contractDocumentPath = Global.TargetFilePath;
            }
        }
        //Click to open attached PDF file ------------------------------------------------------------------------
        private void writeOffLinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(writeOffDocumentPath))
            {
                System.Diagnostics.Process.Start(writeOffDocumentPath);
            }
            else if (!string.IsNullOrEmpty(writeOffDocumentPath))
            {
                ShowCustomMessageBox("ไม่สารมารถเปิดไฟล์ดังกล่าวได้\nหรือไฟล์อาจโดนลบ");
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
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
        //Event for show picturebox ------------------------------------------------------------------------------
        private void equipmentDisplaydataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Assuming the cell contains the image path
                string imagePath = equipmentDisplaydataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    originalReplacePicturebox.Image = Image.FromFile(imagePath);
                    originalReplacePicturebox.Visible = true;

                    originalReplacePicturebox.BringToFront();
                }
            }
        }
        private void equipmentDisplaydataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            originalReplacePicturebox.Visible = false;
        }
        private void equipmentSelecteddataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Assuming the cell contains the image path
                string imagePath = equipmentSelecteddataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    selectedReplacePicturebox.Image = Image.FromFile(imagePath);
                    selectedReplacePicturebox.Visible = true;

                    selectedReplacePicturebox.BringToFront();
                }
            }
        }
        private void equipmentSelecteddataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            selectedReplacePicturebox.Visible = false;
        }

        //Check buy rent transfer part
        private bool CheckBuyRentTransferJob()
        {
            if(Global.selectedEquipmentInJob == null)
            {
                ShowCustomMessageBox("กรุณาเลือกอุปกรณ์ที่มาทดแทนของเก่า");
                return false;
            }
            else
            {
                JREq = new Equipment(Global.selectedEquipmentInJob.ID);
            }
            if (string.IsNullOrEmpty(writeOffDocumentPath))
            {
                ShowCustomMessageBox("กรุณาเแนบเอกสาร Write-Off อุปกรณ์เก่า");
                return false;
            }
            SaveWriteOffDocument();
            return true;
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
            else if(!double.TryParse(costTextBox.Text, out costFromtextBox))
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

        //Recorded this Job
        private void processButton_Click(object sender, EventArgs e)
        {
            if (!processDateTimePicker.Checked)
            {
                ShowCustomMessageBox("เลือกวันที่เริ่มงาน / ได้ของ");
                return;
            }
            else if (jobToProcess.JType.ID == 1 || jobToProcess.JType.ID == 2 || jobToProcess.JType.ID == 5)
            {
                if (CheckBuyRentTransferJob())
                {
                    EquipmentStatus newStatus = new EquipmentStatus(10);
                    //Create instance equipment for this job to change status
                    Equipment jobEquipment = new Equipment(jobToProcess.JEq.ID);
                    jobEquipment.EStatusObj = newStatus;
                    jobEquipment.WriteOffPath = writeOffDocumentPath;
                    if (!jobEquipment.Change())
                    {
                        ShowCustomMessageBox("การเปลี่ยนสถานะอุปกรณ์เก่าผิดพลาด");
                        return;
                    }
                    else
                    {
                        ShowCustomMessageBox("การเปลี่ยนสถานะอุปกรณ์เก่าสมบูรณ์");
                    }
                    //Update replace equipment & date of operation for this Job
                    jobToProcess.FinishDate = processDateTimePicker.Value;
                    jobToProcess.REq = JREq;
                    //Set job status to complete
                    jobToProcess.JobStatus = true;
                    if (jobToProcess.Change())
                    {
                        ShowCustomMessageBox("งานแจ้งซ่อมเสร็จสิ้น");
                        UpdateGrid?.Invoke(this, EventArgs.Empty);
                        Close();
                    }
                    else
                    {
                        ShowCustomMessageBox("การบันทึกข้อมูลลงฐานข้อมูลล้มเหลว");
                        return;
                    }
                }

            }
            else
            {
                if (CheckRepairJob())
                {
                    EquipmentStatus newStatus = new EquipmentStatus(9);
                    //Create instance equipment for this job to change status
                    Equipment jobEquipment = new Equipment(jobToProcess.JEq.ID);
                    jobEquipment.EStatusObj = newStatus;
                    if (!jobEquipment.Change())
                    {
                        ShowCustomMessageBox("การเปลี่ยนสถานะอุปกรณ์ซ่อมบำรุงผิดพลาด");
                        return;
                    }
                    else
                    {
                        ShowCustomMessageBox("การเปลี่ยนสถานะอุปกรณ์ซ่อมบำรุงสมบูรณ์");
                    }
                    //Update details in repair Job
                    jobToProcess.StartDate = processDateTimePicker.Value;
                    jobToProcess.VendName = vendorNameTextBox.Text;
                    jobToProcess.VendDetails = vendorDetailsRichTextBox.Text;
                    jobToProcess.RepairDetails = fixDetailsRichTextBox.Text;
                    jobToProcess.Cost = costFromtextBox;
                    jobToProcess.WorkPermit = workPermitDocumentPath;
                    jobToProcess.Contract = contractDocumentPath;
                    if (jobToProcess.Change())
                    {
                        ShowCustomMessageBox("งานแจ้งซ่อมกำลังถูกดำเนินการ กรุณาตรวจรับงานในขั้นตอนต่อไป");
                        UpdateGrid?.Invoke(this, EventArgs.Empty);
                        Close();
                    }
                    else
                    {
                        ShowCustomMessageBox("การบันทึกสถานะงานแจ้งซ่อมลงในฐานข้อมูลล้มเหลว");
                        return;
                    }
                }
                else
                {
                    return;
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
        //Clear global variable when user close window
        private void JobProcessing_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.selectedEquipmentInJob = null;
        }
    }
}
