using System;
using System.Collections.Generic;
using Equipment_Management.CustomWindowComponents;
using System.Data;
using System.Drawing;
using System.Linq;
using Equipment_Management.GlobalVariable;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.CustomViewClass;
using System.IO;

namespace Equipment_Management.UIClass.Job
{
    public partial class CreateJobForm : Form
    {
        private PictureBox pictureBox;
        private PictureBox selectedEquipmentpictureBox;

        private ToolTip toolTip1;

        public event EventHandler updateCreatedJobDatagridView;

        //variable for update components
        List<EquipmentStatus> equipmentStatusList;
        List<JobType> jobTypeList;
        List<EquipmentType> equipmentTypeList;
        //variable for track primarykey from combobox
        private List<int> equipmentStatusID = new List<int>();
        private List<int> jobTypeID = new List<int>();
        private List<int> equipmentTypeID = new List<int>();
        //Filter algorithm variable
        private int currentFilterID = -1; // Holds the currently selected filter ID
        private List<AllEquipmentView> originalEquipmentList;
        //Saving photo & documentd variable
        string repairEquipmentPhotoPath;
        string createdJobDocumentPath;
        //variable for Created job
        EquipmentStatus selectedEquipmentStatus;
        JobType selectedJobType;
        Equipment JEq;

        BindingSource equipmentListBindingSource;
        List<AllEquipmentView> equipmentList;
        List<AllEquipmentView> equipmentFilteredList;
        List<AllEquipmentView> equipmentSelectedList;

        public CreateJobForm()
        {
            InitializeComponent();
            this.Size = new Size(1480,820);
            equipmentStatusList = new List<EquipmentStatus>();
            jobTypeList = new List<JobType>();
            equipmentTypeList = new List<EquipmentType>();
            originalEquipmentList = new List<AllEquipmentView>();
            equipmentFilteredList = new List<AllEquipmentView>();
            equipmentList = new List<AllEquipmentView>();
            equipmentSelectedList = new List<AllEquipmentView>();
            equipmentListBindingSource = new BindingSource();

            //--------------------------------------------------------------------------------------------//
            //ToolTips
            toolTip1 = new ToolTip();
            toolTip1.InitialDelay = 0;
            toolTip1.ReshowDelay = 0;
            toolTip1.AutoPopDelay = 5000;

            repairDocLinkLabel.MouseEnter += repairDocLinkLabel_MouseEnter;
            repairDocLinkLabel.MouseLeave += repairDocLinkLabel_MouseLeave_1;

            //--------------------------------------------------------------------------------------------//
            //Create hidden picturebox
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(650, 0)
            };
            this.Controls.Add(pictureBox);
            //Register drive event in photo sector
            equipmentDisplaydataGridView.CellMouseEnter += equipmentDisplaydataGridView_CellMouseEnter;
            equipmentDisplaydataGridView.CellMouseLeave += equipmentDisplaydataGridView_CellMouseLeave;
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

            //Register drive event to update equipment
            equipmentDisplaydataGridView.CellDoubleClick += equipmentDisplaydataGridView_CellDoubleClick;
            equipmentSelecteddataGridView.CellDoubleClick += equipmentSelecteddataGridView_CellDoubleClick;

            equipmentDisplaydataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            equipmentSelecteddataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            UpdateEquipmentList();
            UpdateSelectedEquipmentList();

            UpdateComponents();
        }

        private void UpdateComponents()
        {
            equipmentStatusList = EquipmentStatus.GetEquipmentStatusList();
            currentStatusComboBox.Items.Clear();
            foreach(EquipmentStatus eqis in equipmentStatusList)
            {
                if(eqis.ID == 4 || eqis.ID == 5)
                {
                    currentStatusComboBox.Items.Add(eqis.EStatus);
                    equipmentStatusID.Add(eqis.ID);
                }
            }
            jobTypeList = JobType.GetJobTypeList();
            jobTypeList.Sort((x, y) => x.Type.CompareTo(y.Type));
            repairTypeComboBox.Items.Clear();
            foreach(JobType job in jobTypeList)
            {
                repairTypeComboBox.Items.Add(job.Type);
                jobTypeID.Add(job.ID);
            }
            //Equipment type components
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            equipmentTypeComboBox.Items.Clear();

            equipmentTypeComboBox.Items.Add("--------------------------------------");
            equipmentTypeID.Add(-1);
            foreach (EquipmentType etype in equipmentTypeList)
            {
                equipmentTypeComboBox.Items.Add(etype.EType);
                equipmentTypeID.Add(etype.ID);
            }
        }
        //Update original
        private void UpdateEquipmentList()
        {
            equipmentList = AllEquipmentView.GetJobEquipmentView();
            originalEquipmentList = new List<AllEquipmentView>(equipmentList);
            ApplyCurrentFilter();

            FormatEquipmentListDataGridView();
        }
        //Update selected
        private void UpdateSelectedEquipmentList()
        {
            if (Global.selectedEquipmentInJob != null)
            {
                // Adding the selected equipment to the selected list
                equipmentSelectedList = new List<AllEquipmentView> { Global.selectedEquipmentInJob };

                // Binding the selected list to the DataGridView
                equipmentSelecteddataGridView.DataSource = equipmentSelectedList;
            }
        }
        private void ApplyCurrentFilter()
        {
            if (currentFilterID < 0)
            {
                equipmentFilteredList = new List<AllEquipmentView>(originalEquipmentList);
            }
            else
            {
                equipmentFilteredList = originalEquipmentList
                    .Where(eq => eq.ETypeID == currentFilterID)
                    .ToList();
            }

            equipmentListBindingSource.DataSource = equipmentFilteredList;
            equipmentDisplaydataGridView.DataSource = equipmentListBindingSource;

            FormatEquipmentListDataGridView();
        }
        //Format for original
        private void FormatEquipmentListDataGridView()
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
        //Format for selected
        private void FormatSelectedEquipmentListDataGridView()
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
        //Searching & filter events
        private void equipmentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = equipmentTypeComboBox.SelectedIndex;
            currentFilterID = selectTypeIndex >= 0 ? equipmentTypeID[selectTypeIndex] : -1;
            
            ApplyCurrentFilter();
        }
        private void equipmentListSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = equipmentListSearchTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentFilter(); // Reapply the current filter if the search box is empty
            }
            else
            {
                // Filter the already filtered list based on the search text
                var searchResults = equipmentFilteredList
                    .Where(eq =>
                        eq.Name.ToLower().Contains(searchText) ||
                        eq.Serial.ToLower().Contains(searchText) ||
                        eq.EStatus.ToLower().Contains(searchText))
                    .ToList();

                equipmentListBindingSource.DataSource = searchResults;
                equipmentDisplaydataGridView.DataSource = equipmentListBindingSource;
            }
        }
        //Event to appear pcturebox
        private void equipmentDisplaydataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Assuming the cell contains the image path
                string imagePath = equipmentDisplaydataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);
                    pictureBox.Visible = true;

                    pictureBox.BringToFront();
                }
            }
        }
        private void equipmentDisplaydataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox.Visible = false;
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

        //Event to appear pcturebox in selected Equipment
        private void equipmentSelecteddataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Assuming the cell contains the image path
                string imagePath = equipmentSelecteddataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    selectedEquipmentpictureBox.Image = Image.FromFile(imagePath);
                    selectedEquipmentpictureBox.Visible = true;

                    selectedEquipmentpictureBox.BringToFront();
                }
            }
        }
        private void equipmentSelecteddataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            selectedEquipmentpictureBox.Visible = false;
        }

        //Event to add displayed equipment to selected equipment datagridview
        private void equipmentDisplaydataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.RowIndex >= 0)
                {
                    int selectedID = (int)equipmentDisplaydataGridView.Rows[e.RowIndex].Cells["ID"].Value;

                    Global.selectedEquipmentInJob = originalEquipmentList.FirstOrDefault(eq => eq.ID == selectedID);

                    // Update the selected equipment list and refresh the grid
                    UpdateSelectedEquipmentList();
                    FormatSelectedEquipmentListDataGridView();
                    equipmentDisplaydataGridView.Enabled = false;
                }
            }
        }
        //Event to remove selected equipment in datagridview
        private void equipmentSelecteddataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            equipmentSelectedList.Clear();
            equipmentSelecteddataGridView.DataSource = null;
            Global.selectedEquipmentInJob = null;

            equipmentSelecteddataGridView.Refresh();

            equipmentDisplaydataGridView.Enabled = true;
            selectedEquipmentpictureBox.Visible = false;
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
                    //Strem photo to picturebox
                    equipmentRepaiePictureBox.Image = Image.FromFile(repairEquipmentPhotoPath);
                }
            }
        }
        //Get PDF file path from user
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
                    createdJobDocumentPath = openFileDialog.FileName;
                }
            }
        }
        //Save photo & documents into folder
        private void SaveEquipmentPhoto()
        {
            if (!string.IsNullOrEmpty(repairEquipmentPhotoPath))
            {
                Global.SaveFileToServer(repairEquipmentPhotoPath, Global.Directory + @"EquipmentManagementBLC5\CreatedJobEquipmentPhoto");
                repairEquipmentPhotoPath = Global.TargetFilePath;
            }
        }
        private void SaveCreatedJobDocument()
        {
            if (!string.IsNullOrEmpty(createdJobDocumentPath))
            {
                Global.SaveFileToServer(createdJobDocumentPath, Global.Directory + @"EquipmentManagementBLC5\CreatedJobDocument");
                createdJobDocumentPath = Global.TargetFilePath;
            }
        }
        //Click to open attached PDF file
        private void repairDocLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(createdJobDocumentPath))
            {
                System.Diagnostics.Process.Start(createdJobDocumentPath);
            }
            else if (!string.IsNullOrEmpty(createdJobDocumentPath))
            {
                ShowCustomMessageBox("ไม่สารมารถเปิดไฟล์ดังกล่าวได้\nหรือไฟล์อาจโดนลบ");
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        //Event to show tooltips
        private void repairDocLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(createdJobDocumentPath))
            {
                toolTip1.Show($"Attached File: {Path.GetFileName(createdJobDocumentPath)}", repairDocLinkLabel);
            }
            else
            {
                toolTip1.Show("No file attached", repairDocLinkLabel);
            }
        }
        private void repairDocLinkLabel_MouseLeave_1(object sender, EventArgs e)
        {
            toolTip1.Hide(repairDocLinkLabel);
        }

        private bool CheckAllAttribute()
        {
            if (Global.selectedEquipmentInJob == null)
            {
                ShowCustomMessageBox("กรุณาเลือกอุปกรณ์ที่ต้องการแจ้งซ่อม");
                return false;
            }
            else
            {
                JEq = new Equipment(Global.selectedEquipmentInJob.ID);
            }
            int selectedIndexEStatus = currentStatusComboBox.SelectedIndex;
            if (selectedIndexEStatus >= 0 && selectedIndexEStatus < equipmentStatusID.Count)
            {
                int selectedEstatusID = equipmentStatusID[selectedIndexEStatus];
                selectedEquipmentStatus = new EquipmentStatus(selectedEstatusID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกสถานะปัจจุบัน ของอุปกรณ์");
                return false;
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
            if (!reportDateTimePicker.Checked)
            {
                ShowCustomMessageBox("กรุณาระบุวันที่แจ้ง");
                return false;
            }
            int selectedIndexJobType = repairTypeComboBox.SelectedIndex;
            if(selectedIndexJobType >= 0 && selectedIndexJobType < jobTypeID.Count)
            {
                int selectedJobTypeID = jobTypeID[selectedIndexJobType];
                selectedJobType = new JobType(selectedJobTypeID);

                SaveEquipmentPhoto();
                SaveCreatedJobDocument();
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือก ประเภทการซ่อม");
                return false;
            }
            if(JEq.EStatusObj.ID == 6 || JEq.EStatusObj.ID == 7)
            {
                if(selectedJobType.ID == 1 || selectedJobType.ID == 2 || selectedJobType.ID == 5)
                {
                    ShowCustomMessageBox("อุปกรณ์อยู่ในแผนซ่อมบำรุง กรณีที่อุปกรณ์นี้จะถูกทดแทนด้วยของใหม่\nกรุณาสิ้นสุดแผนซ่อมบำรุงก่อนทำการแจ้งซ่อม");
                    return false;
                }
            }
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                Equipment_Management.ObjectClass.Job newJ = new Equipment_Management.ObjectClass.Job(jDetailsrichTextBox.Text,
                    repairEquipmentPhotoPath, reporterNameTextBox.Text, reportDateTimePicker.Value, decideDateTimePicker.Value,
                    approveDateTimePicker.Value, null, null, reasdonToChoserepairRichTextBox.Text, deciderNameTextBox.Text, approveCheckBox.Checked,
                    reasonToAppRichTextBox.Text, approverNameTextBox.Text, createdJobDocumentPath, null, null, null, null, 0, null, null, null, null, false,
                    selectedJobType, JEq, null);
                if (newJ.Create())
                {
                    JEq.EStatusObj = selectedEquipmentStatus;
                    if (!JEq.Change())
                    {
                        ShowCustomMessageBox("ล้มเหลวในการเปลี่ยนสถานะของอุปกรณ์");
                        return;
                    }
                    ShowCustomMessageBox("บันทึกการแจ้งซ่อมเสร็จสมบูรณ์");
                    Global.selectedEquipmentInJob = null;
                    updateCreatedJobDatagridView?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    ShowCustomMessageBox("ล้มเหลวในการบันทึกข้อมูลลงใน Database");
                }
            }
        }
        //Clear Globol variable in datagridview
        private void CreateJobForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.selectedEquipmentInJob = null;
        }
    }
}
