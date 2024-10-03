using System;
using System.Collections.Generic;
using Equipment_Management.CustomWindowComponents;
using System.Drawing;
using Equipment_Management.GlobalVariable;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.CustomViewClass;
using System.IO;

namespace Equipment_Management.UIClass.Job
{
    public partial class EditJobForm : Form
    {
        public event EventHandler UpdateGrid;
        ObjectClass.Job editJob = new ObjectClass.Job(Global.ID);

        private PictureBox selectedEquipmentpictureBox;

        private ToolTip jobDocumentTooltip;

        string jobDocumentPath;
        string oldJobDocumentPath;
        string repairEquipmentPhotoPath;
        string oldRepairEquipmentPhotoPath;

        EquipmentStatus selectedEquipmentStatus;
        JobType selectedJobType;

        //variable for update components
        List<EquipmentStatus> equipmentStatusList;
        List<JobType> jobTypeList;
        //variable for track primarykey from combobox
        private List<int> equipmentStatusID = new List<int>();
        private List<int> jobTypeID = new List<int>();

        BindingSource equipmentListBindingSource;
        List<AllEquipmentView> equipmentSelectedList;

        public EditJobForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            equipmentStatusList = new List<EquipmentStatus>();
            jobTypeList = new List<JobType>();
            equipmentSelectedList = new List<AllEquipmentView>();
            equipmentListBindingSource = new BindingSource();

            Global.selectedEquipmentInJob = new AllEquipmentView(editJob.JEq.ID, editJob.JEq.Name, editJob.JEq.Serial
                , editJob.JEq.EStatusObj.ID, editJob.JEq.EStatusObj.EStatus, editJob.JEq.ETypeObj.ID, editJob.JEq.EPhotoPath);

            //--------------------------------------------------------------------------------------------//
            //Create hidden selected equipment picturebox
            selectedEquipmentpictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(650, 0)
            };
            this.Controls.Add(selectedEquipmentpictureBox);
            //Register drive event in photo sector
            equipmentSelecteddataGridView.CellMouseEnter += equipmentSelecteddataGridView_CellMouseEnter;
            equipmentSelecteddataGridView.CellMouseLeave += equipmentSelecteddataGridView_CellMouseLeave;
            //--------------------------------------------------------------------------------------------//
            //JobDocument Tooltip
            jobDocumentTooltip = new ToolTip();
            jobDocumentTooltip.InitialDelay = 0;
            jobDocumentTooltip.ReshowDelay = 0;
            jobDocumentTooltip.AutoPopDelay = 5000;
            repairDocLinkLabel.MouseEnter += repairDocLinkLabel_MouseEnter;
            repairDocLinkLabel.MouseLeave += repairDocLinkLabel_MouseLeave;

            UpdateSelectedEquipmentList();

            UpdateComponents();
            LoadSelectedJob();
        }

        //LoadSelectedJob
        private void LoadSelectedJob()
        {
            //Disable not use components
            equipmentDisplaydataGridView.Enabled = false;
            equipmentTypeComboBox.Enabled = false;
            equipmentListSearchTextBox.Enabled = false;
            equipmentFilterListLabel.Enabled = false;
            searchEquipmentLabel.Enabled = false;
            choseEquipmentLabel.Enabled = false;
            //Update content in components
            currentStatusComboBox.Text = editJob.JEq.EStatusObj.EStatus;
            repairTypeComboBox.Text = editJob.JType.Type;
            reporterNameTextBox.Text = editJob.Reporter;
            reportDateTimePicker.Value = editJob.RDate.Value;
            reasdonToChoserepairRichTextBox.Text = editJob.JTypeReason;
            deciderNameTextBox.Text = editJob.Decider;
            decideDateTimePicker.Value = editJob.DDate.Value;
            if (!string.IsNullOrEmpty(editJob.CasePhoto))
            {
                Global.LoadImageIntoPictureBox(editJob.CasePhoto, equipmentRepaiePictureBox);
            }
            oldJobDocumentPath = editJob.JDocument;
            oldRepairEquipmentPhotoPath = editJob.CasePhoto;
            jDetailsrichTextBox.Text = editJob.JDetails;
            approveCheckBox.Checked = editJob.Approve;
            reasonToAppRichTextBox.Text = editJob.AppReason;
            approveDateTimePicker.Value = editJob.ADate.Value;
            approverNameTextBox.Text = editJob.Approver;

            // Update link label colors based on file existence
            if (!String.IsNullOrEmpty(oldJobDocumentPath))
            {
                repairDocLinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
        }

        private void UpdateComponents()
        {
            equipmentStatusList = EquipmentStatus.GetEquipmentStatusList();
            currentStatusComboBox.Items.Clear();
            equipmentStatusID.Clear();
            foreach (EquipmentStatus eqis in equipmentStatusList)
            {
                if (eqis.ID == 4 || eqis.ID == 5)
                {
                    currentStatusComboBox.Items.Add(eqis.EStatus);
                    equipmentStatusID.Add(eqis.ID);
                }
            }
            jobTypeList = JobType.GetJobTypeList();
            jobTypeList.Sort((x, y) => x.Type.CompareTo(y.Type));
            repairTypeComboBox.Items.Clear();
            jobTypeID.Clear();
            foreach (JobType job in jobTypeList)
            {
                if(editJob.JType.ID == 4 || editJob.JType.ID == 3)
                {
                    if(job.ID == 4 || job.ID == 3)
                    {
                        repairTypeComboBox.Items.Add(job.Type);
                        jobTypeID.Add(job.ID);
                    }
                }
                else
                {
                    if(job.ID == 1||job.ID == 2||job.ID == 5)
                    {
                        repairTypeComboBox.Items.Add(job.Type);
                        jobTypeID.Add(job.ID);
                    }
                }
            }
        }
        
        //Update selected equipment
        private void UpdateSelectedEquipmentList()
        {
            if (Global.selectedEquipmentInJob != null)
            {
                // Adding the selected equipment to the selected list
                equipmentSelectedList = new List<AllEquipmentView> { Global.selectedEquipmentInJob };

                // Binding the selected list to the DataGridView
                equipmentSelecteddataGridView.DataSource = equipmentSelectedList;
                FormatSelectedEquipmentListDataGridView();
            }
        }
        //Format for selected
        private void FormatSelectedEquipmentListDataGridView()
        {
            if (equipmentSelecteddataGridView.Columns["ID"] != null)
            {
                equipmentSelecteddataGridView.Columns["ID"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["Name"] != null)
            {
                var customColumn = equipmentSelecteddataGridView.Columns["Name"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (equipmentSelecteddataGridView.Columns["Serial"] != null)
            {
                var customColumn = equipmentSelecteddataGridView.Columns["Serial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
            }
            if (equipmentSelecteddataGridView.Columns["EStatusID"] != null)
            {
                equipmentSelecteddataGridView.Columns["EStatusID"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["EStatus"] != null)
            {
                var customColumn = equipmentSelecteddataGridView.Columns["EStatus"];
                customColumn.HeaderText = "สถานะอุปกรณ์";
                customColumn.Width = 100;
            }
            if (equipmentSelecteddataGridView.Columns["ETypeID"] != null)
            {
                equipmentSelecteddataGridView.Columns["ETypeID"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["EquipmentPhoto"] != null)
            {
                var photoColumn = equipmentSelecteddataGridView.Columns["EquipmentPhoto"];
                photoColumn.HeaderText = "ภาพ";
                photoColumn.Width = 80;
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
                var column = equipmentSelecteddataGridView.Columns["InsDetails"];
                column.HeaderText = "ที่ปฎิบัติงาน";
                column.Width = 150;
            }
            if (equipmentSelecteddataGridView.Columns["InstallEPhoto"] != null)
            {
                equipmentSelecteddataGridView.Columns["InstallEPhoto"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["Replacement"] != null)
            {
                equipmentSelecteddataGridView.Columns["Replacement"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["EOwnerID"] != null)
            {
                equipmentSelecteddataGridView.Columns["EOwnerID"].Visible = false;
            }
            if (equipmentSelecteddataGridView.Columns["IsEJob"] != null)
            {
                equipmentSelecteddataGridView.Columns["IsEJob"].Visible = false;
            }
        }
      
        //Event to appear pcturebox in selected Equipment
        private void equipmentSelecteddataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = equipmentSelecteddataGridView.Columns[e.ColumnIndex].Name;
                if (columnName == "EquipmentPhoto")
                {
                    equipmentSelecteddataGridView.ShowCellToolTips = false;
                    string imagePath = equipmentSelecteddataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, selectedEquipmentpictureBox);
                    selectedEquipmentpictureBox.Visible = true;
                    selectedEquipmentpictureBox.BringToFront();

                }
            }
        }
        private void equipmentSelecteddataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            selectedEquipmentpictureBox.Visible = false;
            equipmentSelecteddataGridView.ShowCellToolTips = true;
        }
        //Event to show JobDocument Tooltip
        private void repairDocLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(jobDocumentPath))
            {
                jobDocumentTooltip.Show($"Attached File: {Path.GetFileName(jobDocumentPath)}", repairDocLinkLabel);
            }
            else if (!string.IsNullOrEmpty(oldJobDocumentPath))
            {
                jobDocumentTooltip.Show($"Attached File: {Path.GetFileName(oldJobDocumentPath)}", repairDocLinkLabel);
            }
            else
            {
                jobDocumentTooltip.Show("No file attached", repairDocLinkLabel);
            }
        }
        private void repairDocLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            jobDocumentTooltip.Hide(repairDocLinkLabel);
        }
        //Get PDF file path from user ----------------------------------------------------------------------------
        private void repairDocButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    jobDocumentPath = openFileDialog.FileName;
                    repairDocLinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
            }
        }
        //Save PDF file to folder --------------------------------------------------------------------------------
        private void SaveJobDocument()
        {
            if (!string.IsNullOrEmpty(jobDocumentPath))
            {
                Global.DeleteFileFromFtp(oldJobDocumentPath);
                Global.Directory = "CreatedJobDocument";
                Global.SaveFileToServer(jobDocumentPath);
                Global.Directory = null;
                jobDocumentPath = Global.TargetFilePath;
                editJob.JDocument = jobDocumentPath;
            }
        }
        //Get file path from user and stream to PictureBox
        private void equipmentPhotoButton_Click(object sender, EventArgs e)
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
                    repairEquipmentPhotoPath = openFileDialog.FileName;

                    using (var tempImage = Image.FromFile(repairEquipmentPhotoPath))
                    {
                        //Strem photo to picturebox
                        equipmentRepaiePictureBox.Image = new Bitmap(tempImage);
                    }
                }
            }
        }
        //Save photo into folder
        private void SaveEquipmentPhoto()
        {
            if (!string.IsNullOrEmpty(repairEquipmentPhotoPath))
            {
                Global.DeleteFileFromFtp(oldRepairEquipmentPhotoPath);
                Global.Directory = "CreatedJobEquipmentPhoto";
                Global.SaveFileToServer(repairEquipmentPhotoPath);
                Global.Directory = null;
                repairEquipmentPhotoPath = Global.TargetFilePath;
                editJob.CasePhoto = repairEquipmentPhotoPath;
            }
        }
        //Open job document
        private void repairDocLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(jobDocumentPath))
            {
                System.Diagnostics.Process.Start(jobDocumentPath);
            }
            else if (!string.IsNullOrEmpty(oldJobDocumentPath))
            {
                Global.DownloadAndOpenPdf(oldJobDocumentPath);
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

        private bool CheckAllAttribute()
        {
            if (currentStatusComboBox.SelectedIndex > 0)
            {
                int selectedIndexEStatus = currentStatusComboBox.SelectedIndex;
                if (selectedIndexEStatus >= 0 && selectedIndexEStatus < equipmentStatusID.Count)
                {
                    int selectedEstatusID = equipmentStatusID[selectedIndexEStatus];
                    selectedEquipmentStatus = new EquipmentStatus(selectedEstatusID);
                    editJob.JEq.EStatusObj = selectedEquipmentStatus;
                }
            }
            if (repairTypeComboBox.SelectedIndex > 0)
            {
                int selectedIndexJobType = repairTypeComboBox.SelectedIndex;
                if (selectedIndexJobType >= 0 && selectedIndexJobType < jobTypeID.Count)
                {
                    int selectedJobTypeID = jobTypeID[selectedIndexJobType];
                    selectedJobType = new JobType(selectedJobTypeID);
                    editJob.JType = selectedJobType;
                }
            }
            if (string.IsNullOrEmpty(jDetailsrichTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุรายละเอียดการแจ้งซ่อม");
                return false;
            }
            if (string.IsNullOrEmpty(reporterNameTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุชื่อผู้แจ้ง");
                return false;
            }
            SaveEquipmentPhoto();
            SaveJobDocument();
            editJob.Reporter = reporterNameTextBox.Text;
            editJob.RDate = reportDateTimePicker.Value;
            editJob.JTypeReason = reasdonToChoserepairRichTextBox.Text;
            editJob.Decider = deciderNameTextBox.Text;
            editJob.DDate = decideDateTimePicker.Value;
            editJob.JDetails = jDetailsrichTextBox.Text;
            editJob.AppReason = reasonToAppRichTextBox.Text;
            editJob.ADate = approveDateTimePicker.Value;
            editJob.Approver = approverNameTextBox.Text;
            return true;
        }

        private void editJobCompleteButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                if (editJob.Change())
                {
                    ShowCustomMessageBox("การแจ้งซ่อมถูกแก้ใขเรียบร้อย");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    Global.DeleteFileFromFtp(jobDocumentPath);
                    Global.DeleteFileFromFtp(repairEquipmentPhotoPath);
                    ShowCustomMessageBox("ขั้นตอนการอัฟเดทข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
    }
}
