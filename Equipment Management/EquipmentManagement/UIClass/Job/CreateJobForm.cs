using System;
using System.Collections.Generic;
using Admin_Program.CustomWindowComponents;
using System.Data;
using System.Drawing;
using System.Linq;
using Admin_Program.GlobalVariable;
using System.Windows.Forms;
using Admin_Program.ObjectClass;
using Admin_Program.CustomViewClass;
using System.IO;

namespace Admin_Program.UIClass.Job
{
    public partial class CreateJobForm : Form
    {
        private PictureBox pictureBox;
        private PictureBox selectedEquipmentpictureBox;

        private ToolTip toolTip1;

        public event EventHandler UpdateGrid;

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

            UpdateEquipmentList();
            UpdateSelectedEquipmentList();

            UpdateComponents();
        }

        private void UpdateComponents()
        {
            equipmentStatusList = EquipmentStatus.GetEquipmentStatusList();
            currentStatusComboBox.Items.Clear();
            equipmentStatusID.Clear();
            foreach (EquipmentStatus eqis in equipmentStatusList)
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
            jobTypeID.Clear();
            foreach (JobType job in jobTypeList)
            {
                repairTypeComboBox.Items.Add(job.Type);
                jobTypeID.Add(job.ID);
            }
            //Equipment type components
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            equipmentTypeComboBox.Items.Clear();
            equipmentTypeID.Clear();

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
                var customColumn = equipmentDisplaydataGridView.Columns["Name"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (equipmentDisplaydataGridView.Columns["Serial"] != null)
            {
                var customColumn = equipmentDisplaydataGridView.Columns["Serial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
            }
            if (equipmentDisplaydataGridView.Columns["EStatusID"] != null)
            {
                equipmentDisplaydataGridView.Columns["EStatusID"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["EStatus"] != null)
            {
                var customColumn = equipmentDisplaydataGridView.Columns["EStatus"];
                customColumn.HeaderText = "สถานะอุปกรณ์";
                customColumn.Width = 100;
            }
            if (equipmentDisplaydataGridView.Columns["ETypeID"] != null)
            {
                equipmentDisplaydataGridView.Columns["ETypeID"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["EquipmentPhoto"] != null)
            {
                var photoColumn = equipmentDisplaydataGridView.Columns["EquipmentPhoto"];
                photoColumn.HeaderText = "ภาพอุปกรณ์";
                photoColumn.Width = 80;
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
                var column = equipmentDisplaydataGridView.Columns["InsDetails"];
                column.HeaderText = "ที่ปฎิบัติงาน";
                column.Width = 150;
            }
            if (equipmentDisplaydataGridView.Columns["InstallEPhoto"] != null)
            {
                equipmentDisplaydataGridView.Columns["InstallEPhoto"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["Replacement"] != null)
            {
                equipmentDisplaydataGridView.Columns["Replacement"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["EOwnerID"] != null)
            {
                equipmentDisplaydataGridView.Columns["EOwnerID"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["IsEJob"] != null)
            {
                equipmentDisplaydataGridView.Columns["IsEJob"].Visible = false;
            }
            if (equipmentDisplaydataGridView.Columns["Zone"] != null)
            {
                equipmentDisplaydataGridView.Columns["Zone"].Visible = false;
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
            if (equipmentSelecteddataGridView.Columns["Zone"] != null)
            {
                equipmentSelecteddataGridView.Columns["Zone"].Visible = false;
            }
        }
        //Searching & filter events
        private void equipmentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = equipmentTypeComboBox.SelectedIndex;
            currentFilterID = selectTypeIndex >= 0 ? equipmentTypeID[selectTypeIndex] : -1;
            
            ApplyCurrentFilter();
        }
        private void equipmentTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            // Temporarily unsubscribe from the TextChanged event to avoid recursion
            equipmentTypeComboBox.TextChanged -= equipmentTypeComboBox_TextChanged;

            string typedText = equipmentTypeComboBox.Text;
            int currentCaretPosition = equipmentTypeComboBox.SelectionStart;

            // Filter items that start with the typed text
            var matchingItems = equipmentTypeComboBox.Items.Cast<string>()
                                         .Where(item => item.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                                         .ToList();

            // Only suggest and highlight if the user is typing and a match is found
            if (matchingItems.Any() && !string.IsNullOrEmpty(typedText))
            {
                string selectedItem = matchingItems.First();

                // Update the text and highlight the matching part only if the typed text is less than the selected item
                if (typedText.Length < selectedItem.Length && selectedItem.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                {
                    equipmentTypeComboBox.Text = selectedItem;
                    equipmentTypeComboBox.SelectionStart = currentCaretPosition;
                    equipmentTypeComboBox.SelectionLength = selectedItem.Length - typedText.Length;
                }
            }
            else
            {
                // If no match found or text is empty, keep the typed text
                equipmentTypeComboBox.Text = typedText;
                equipmentTypeComboBox.SelectionStart = currentCaretPosition;
                equipmentTypeComboBox.SelectionLength = 0;
            }

            // Re-subscribe to the TextChanged event
            equipmentTypeComboBox.TextChanged += equipmentTypeComboBox_TextChanged;
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
            if (e.RowIndex >= 0)
            {
                string columnName = equipmentDisplaydataGridView.Columns[e.ColumnIndex].Name;
                if (columnName == "EquipmentPhoto")
                {
                    equipmentDisplaydataGridView.ShowCellToolTips = false;
                    string imagePath = equipmentDisplaydataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, pictureBox);
                    pictureBox.Visible = true;
                    pictureBox.BringToFront();

                }
            }
        }
        private void equipmentDisplaydataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox.Visible = false;
            equipmentDisplaydataGridView.ShowCellToolTips = true;
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

        //Event to add displayed equipment to selected equipment datagridview
        private void equipmentDisplaydataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int selectedID = (int)equipmentDisplaydataGridView.Rows[e.RowIndex].Cells["ID"].Value;

                Global.selectedEquipmentInJob = originalEquipmentList.FirstOrDefault(eq => eq.ID == selectedID);
                // Update the selected equipment list and refresh the grid
                UpdateSelectedEquipmentList();
                FormatSelectedEquipmentListDataGridView();
                equipmentDisplaydataGridView.Enabled = false;
                pictureBox.Visible = false;
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

                    using (var tempImage = Image.FromFile(repairEquipmentPhotoPath))
                    {
                        //Strem photo to picturebox
                        equipmentRepaiePictureBox.Image = new Bitmap(tempImage);
                    }
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
                    repairDocLinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
            }
        }
        //Save photo & documents into folder
        private void SaveEquipmentPhoto()
        {
            if (!string.IsNullOrEmpty(repairEquipmentPhotoPath))
            {
                Global.Directory = "CreatedJobEquipmentPhoto";
                Global.SaveFileToServer(repairEquipmentPhotoPath);
                Global.Directory = null;
                repairEquipmentPhotoPath = Global.TargetFilePath;
            }
        }
        private void SaveCreatedJobDocument()
        {
            if (!string.IsNullOrEmpty(createdJobDocumentPath))
            {
                Global.Directory = "CreatedJobDocument";
                Global.SaveFileToServer(createdJobDocumentPath);
                Global.Directory = null;
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
            int selectedIndexJobType = repairTypeComboBox.SelectedIndex;
            if (selectedIndexJobType >= 0 && selectedIndexJobType < jobTypeID.Count)
            {
                int selectedJobTypeID = jobTypeID[selectedIndexJobType];
                selectedJobType = new JobType(selectedJobTypeID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือก ประเภทการซ่อม");
                return false;
            }
            if (JEq.EStatusObj.ID == 6 || JEq.EStatusObj.ID == 7)
            {
                if (selectedJobType.ID == 1 || selectedJobType.ID == 2 || selectedJobType.ID == 5)
                {
                    ShowCustomMessageBox("อุปกรณ์อยู่ในแผนซ่อมบำรุง กรณีที่อุปกรณ์นี้จะถูกทดแทนด้วยของใหม่\nกรุณาสิ้นสุดแผนซ่อมบำรุงก่อนทำการแจ้งซ่อม");
                    return false;
                }
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
            SaveEquipmentPhoto();
            SaveCreatedJobDocument();
            return true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                Admin_Program.ObjectClass.Job newJ = new Admin_Program.ObjectClass.Job(Global.warehouseID,jDetailsrichTextBox.Text,
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
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    Global.DeleteFileFromFtp(repairEquipmentPhotoPath);
                    Global.DeleteFileFromFtp(createdJobDocumentPath);
                    ShowCustomMessageBox("ล้มเหลวในการบันทึกข้อมูลลงใน Database");
                }
            }
        }
        //Clear Globol variable in datagridview
        private void CreateJobForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global.selectedEquipmentInJob = null;
        }

        private void equipmentDisplaydataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)equipmentDisplaydataGridView.Rows[e.RowIndex].Cells["EStatusID"].Value;

            Global.SetRowColor(equipmentDisplaydataGridView.Rows[e.RowIndex], statusID);
        }
    }
}
