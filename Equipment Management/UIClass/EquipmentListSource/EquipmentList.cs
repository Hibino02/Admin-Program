using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.CustomViewClass;
using System.Linq;
using Equipment_Management.UIClass.EquipmentInstallationSource;
using Equipment_Management.GlobalVariable;
using Equipment_Management.CustomWindowComponents;
using Equipment_Management.UIClass.EquipmentInstallEditWriteOffSource;
using Equipment_Management.UIClass.Job;

namespace Equipment_Management.UIClass.EquipmentListSource
{
    public partial class EquipmentList : Form
    {
        MainBackGroundFrom main;

        public event EventHandler UpdateGrid;

        private PictureBox pictureBox;
        //Fillter algorithm variable
        private int currentFilterID = -1; // Holds the currently selected filter ID
        private List<AllEquipmentView> originalEquipmentList;
        //variable to call other form
        EditEquipmentForm editForm;
        WriteOffAndTransferEquipmentForm writeoffAndTransferForm;
        JobHistory jobHistory;
        Equipment equipment;
        //variable for update components
        private List<int> equipmentTypeID = new List<int>();
        List<EquipmentType> equipmentTypeList;

        BindingSource equipmentListBindingSource;
        List<AllEquipmentView> equipmentList;
        List<AllEquipmentView> equipmentFilteredList;

        public EquipmentList()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            equipmentList = new List<AllEquipmentView>();
            equipmentFilteredList = new List<AllEquipmentView>();
            equipmentTypeList = new List<EquipmentType>();
            originalEquipmentList = new List<AllEquipmentView>();
            equipmentListBindingSource = new BindingSource();

            //Create hidden picturebox
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(pictureBox);
            //Register drive event
            EquipmentListDataGridView.CellMouseEnter += EquipmentListDataGridView_CellMouseEnter;
            EquipmentListDataGridView.CellMouseLeave += EquipmentListDataGridView_CellMouseLeave;

            UpdateEquipmentList();

            UpdateComponents();
        }

        private void UpdateComponents()
        {
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            equipmentTypeComboBox.Items.Clear();
            equipmentTypeID.Clear();

            equipmentTypeComboBox.Items.Add("--------------------------------------");
            equipmentTypeID.Add(-1);
            foreach (EquipmentType eqt in equipmentTypeList)
            {
                equipmentTypeComboBox.Items.Add(eqt.EType);
                equipmentTypeID.Add(eqt.ID);
            }
        }

        private void UpdateEquipmentList()
        {
            equipmentList = AllEquipmentView.GetAllEquipmentView();
            originalEquipmentList = new List<AllEquipmentView>(equipmentList);
            ApplyCurrentFilter();
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
            EquipmentListDataGridView.DataSource = equipmentListBindingSource;

            FormatEquipmentListDataGridView();
        }
        //Setting Datagridview looks
        private void FormatEquipmentListDataGridView()
        {
            if (EquipmentListDataGridView.Columns["ID"] != null)
            {
                EquipmentListDataGridView.Columns["ID"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["Name"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["Name"];
                photoColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                photoColumn.Width = 200;
            }
            if (EquipmentListDataGridView.Columns["Serial"] != null)
            {
                EquipmentListDataGridView.Columns["Serial"].HeaderText = "ชื่อทางบัญชี";
            }
            if (EquipmentListDataGridView.Columns["EDetails"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["EDetails"];
                photoColumn.HeaderText = "รายละเอียดอุปกรณ์";
                photoColumn.Width = 170;
            }
            if (EquipmentListDataGridView.Columns["InsDate"] != null)
            {
                EquipmentListDataGridView.Columns["InsDate"].HeaderText = "วันที่เริ่มใช้งาน";
                EquipmentListDataGridView.Columns["InsDate"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (EquipmentListDataGridView.Columns["EType"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["EType"];
                photoColumn.HeaderText = "ประเภทอุปกรณ์";
                photoColumn.Width = 250;
            }
            if (EquipmentListDataGridView.Columns["EOwner"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["EOwner"];
                photoColumn.HeaderText = "เจ้าของอุปกรณ์";
                photoColumn.Width = 70;
            }
            if (EquipmentListDataGridView.Columns["EStatus"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["EStatus"];
                photoColumn.HeaderText = "สถานะปัจจุบัน";
                photoColumn.Width = 100;
            }
            if (EquipmentListDataGridView.Columns["InsDetails"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["InsDetails"];
                photoColumn.HeaderText = "รายละเอียดจุดที่ติดตั้ง";
                photoColumn.Width = 250;
            }
            if (EquipmentListDataGridView.Columns["ETypeID"] != null)
            {
                EquipmentListDataGridView.Columns["ETypeID"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["EStatusID"] != null)
            {
                EquipmentListDataGridView.Columns["EStatusID"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["InstallEPhoto"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["InstallEPhoto"];
                photoColumn.HeaderText = "ไฟล์ภาพจุดติดตั้งอุปกรณ์";
                photoColumn.Width = 100;
            }
            if (EquipmentListDataGridView.Columns["EquipmentPhoto"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["EquipmentPhoto"];
                photoColumn.HeaderText = "ไฟล์ภาพอุปกรณ์";
                photoColumn.Width = 100;
            }
            if (EquipmentListDataGridView.Columns["Replacement"] != null)
            {
                EquipmentListDataGridView.Columns["Replacement"].Visible = false;
            }
        }

        //Event to highlight text match
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
                        eq.EDetails.ToLower().Contains(searchText) ||
                        eq.InsDetails.ToLower().Contains(searchText) ||
                        eq.EType.ToLower().Contains(searchText) ||
                        eq.EOwner.ToLower().Contains(searchText) ||
                        eq.EStatus.ToLower().Contains(searchText))
                    .ToList();

                equipmentListBindingSource.DataSource = searchResults;
                EquipmentListDataGridView.DataSource = equipmentListBindingSource;
            }
        }

        //Click edit equipment
        private void editEquipmentButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = EquipmentListDataGridView.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                editForm = new EditEquipmentForm();
                editForm.Owner = main;
                editForm.UpdateGrid += OnUpdate;
                editForm.ShowDialog();
            }        
        }
        //Click remove equipment
        private void removeEquipmentButton_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("คุณต้องการลบอุปกรณ์นี้หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                DataGridViewRow selectedRow = EquipmentListDataGridView.CurrentRow;
                if (selectedRow != null)
                {
                    int eid = (int)selectedRow.Cells["ID"].Value;
                    equipment = new Equipment(eid);
                    string ePhoto = equipment.EPhotoPath;
                    string oPlacePhoto = equipment.OPlacePhotoPath;
                    string eDoc = equipment.EDocumentPath;
                    if (equipment.Remove())
                    {
                        Global.DeleteFileFromFtp(ePhoto);
                        Global.DeleteFileFromFtp(oPlacePhoto);
                        Global.DeleteFileFromFtp(eDoc);
                        ShowCustomMessageBox("ลบอุปกรณ์เสร็จสมบูรณ์");
                        UpdateEquipmentList();
                    }
                    else
                    {
                        ShowCustomMessageBox("อุปกรณ์นี้ไม่สามารถลบได้ เนื่องจากมีประวัติการดำเนินการเกิดขึ้นแล้ว " + "\n" + " กรุณาใช้คำสั่ง Write-Off เพื่อสิ้นสุดการใช้งาน");
                    }
                }
                else
                {
                    ShowCustomMessageBox("กรุณาเลือกรายการที่ต้องการดำเนินการ");
                }
                
            }
            
        }

        //Method to call UpdateGridview
        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateEquipmentList();
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

        private bool CheckEquipmentStatusBeforeWriteOffNTransfer()
        {
            bool isComplete = true;
            switch (Global.EStatusID)
            {
                case 4:
                case 5:
                case 9:
                    ShowCustomMessageBox("อุปกรณ์อยู่ในงานแจ้งซ่อมจึงไม่สามารถ Write-Off หรือ โอนย้ายได้\nกรุณาทำการยกเลิกแจ้งซ่อม");
                    isComplete = false;
                    break;
                case 6:
                case 7:
                case 8:
                    ShowCustomMessageBox("อุปกรณ์อยู่ในแผนซ่อมบำรุงจึงไม่สามารถ Write-Off หรือ โอนย้ายได้\nกรุณาสิ้นสุดแผน");
                    isComplete = false;
                    break;
                case 10:
                    ShowCustomMessageBox("อุปกรณ์นี้สิ้นสุดการใช้งานแล้ว");
                    isComplete = false;
                    break;
            }
            return isComplete;
        }
        private void writeOff_TransferButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = EquipmentListDataGridView.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                Global.EStatusID = -1;
                Global.EStatusID = (int)selectedRow.Cells["EStatusID"].Value;

                if (CheckEquipmentStatusBeforeWriteOffNTransfer())
                {
                    writeoffAndTransferForm = new WriteOffAndTransferEquipmentForm();
                    writeoffAndTransferForm.Owner = main;
                    writeoffAndTransferForm.UpdateGrid += OnUpdate;
                    writeoffAndTransferForm.ShowDialog();
                }
            }       
        }
        private void jobHistoryButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = EquipmentListDataGridView.CurrentRow;
            if(selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                jobHistory = new JobHistory();
                jobHistory.Owner = main;
                jobHistory.UpdateGrid += OnUpdate;
                jobHistory.ShowDialog();
            }
        }
        //Event to show equipment photo
        private void EquipmentListDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = EquipmentListDataGridView.Columns[e.ColumnIndex].Name;
                if (columnName == "InstallEPhoto" || columnName == "EquipmentPhoto")
                {
                    string imagePath = EquipmentListDataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
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
        private void EquipmentListDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox.Visible = false;
        }
    }
}
