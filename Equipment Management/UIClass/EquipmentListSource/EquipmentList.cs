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

namespace Equipment_Management.UIClass.EquipmentListSource
{
    public partial class EquipmentList : Form
    {
        MainBackGroundFrom main;

        private PictureBox pictureBox;
        //Fillter algorithm variable
        private int currentFilterID = -1; // Holds the currently selected filter ID
        private List<AllEquipmentView> originalEquipmentList;
        //variable to call other form
        EditEquipmentForm editForm;
        WriteOffAndTransferEquipmentForm writeoffAndTransferForm;
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

            EquipmentListDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            UpdateEquipmentList();

            UpdateComponents();
        }

        private void UpdateComponents()
        {
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            equipmentTypeComboBox.Items.Clear();

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

            FormatEquipmentListDataGridView();
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
            if(EquipmentListDataGridView.Columns["ID"] != null)
            {
                EquipmentListDataGridView.Columns["ID"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["Name"] != null)
            {
                EquipmentListDataGridView.Columns["Name"].HeaderText = "ชื่อเรียกอุปกรณ์";
            }
            if (EquipmentListDataGridView.Columns["Serial"] != null)
            {
                EquipmentListDataGridView.Columns["Serial"].HeaderText = "ชื่อทางบัญชี";
            }
            if (EquipmentListDataGridView.Columns["EDetails"] != null)
            {
                EquipmentListDataGridView.Columns["EDetails"].HeaderText = "รายละเอียดอุปกรณ์";
            }
            if (EquipmentListDataGridView.Columns["InsDate"] != null)
            {
                EquipmentListDataGridView.Columns["InsDate"].HeaderText = "วันที่เริ่มใช้งาน";
                EquipmentListDataGridView.Columns["InsDate"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (EquipmentListDataGridView.Columns["EType"] != null)
            {
                EquipmentListDataGridView.Columns["EType"].HeaderText = "ประเภทอุปกรณ์";
            }
            if (EquipmentListDataGridView.Columns["EOwner"] != null)
            {
                EquipmentListDataGridView.Columns["EOwner"].HeaderText = "เจ้าของอุปกรณ์";
            }
            if (EquipmentListDataGridView.Columns["EStatus"] != null)
            {
                EquipmentListDataGridView.Columns["EStatus"].HeaderText = "สถานะปัจจุบัน";
            }
            if (EquipmentListDataGridView.Columns["InsDetails"] != null)
            {
                EquipmentListDataGridView.Columns["InsDetails"].HeaderText = "รายละเอียดจุดที่ติดตั้ง";
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
                EquipmentListDataGridView.Columns["InstallEPhoto"].HeaderText = "ไฟล์ภาพจุดที่ติดตั้ง";
            }
            if (EquipmentListDataGridView.Columns["EquipmentPhoto"] != null)
            {
                EquipmentListDataGridView.Columns["EquipmentPhoto"].HeaderText = "ไฟล์ภาพอุปกรณ์";
            }
            if (EquipmentListDataGridView.Columns["Replacement"] != null)
            {
                EquipmentListDataGridView.Columns["Replacement"].Visible = false;
            }
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
            Global.ID = (int)selectedRow.Cells["ID"].Value;

            editForm = new EditEquipmentForm();
            editForm.Owner = main;
            editForm.UpdateGrid += OnUpdate;
            editForm.ShowDialog();
        }
        //Click remove equipment
        private void removeEquipmentButton_Click(object sender, EventArgs e)
        {
            
            DialogResult result = MessageBox.Show("คุณต้องการลบอุปกรณ์นี้หรือไม่?", "ยืนยันการลบ", MessageBoxButtons.OKCancel);
            if(result == DialogResult.OK)
            {
                DataGridViewRow selectedRow = EquipmentListDataGridView.CurrentRow;
                int eid = (int)selectedRow.Cells["ID"].Value;
                equipment = new Equipment(eid);
                if (equipment.Remove())
                {
                    ShowCustomMessageBox("ลบอุปกรณ์เสร็จสมบูรณ์");
                    UpdateEquipmentList();
                }
                else
                {
                    ShowCustomMessageBox("อุปกรณ์นี้ไม่สามารถลบได้ เนื่องจากมีประวัติการดำเนินการเกิดขึ้นแล้ว " + "\n" + " กรุณาใช้คำสั่ง Write-Off เพื่อสิ้นสุดการใช้งาน");
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
        //Event to show equipment photo
        private void EquipmentListDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Assuming the cell contains the image path
                string imagePath = EquipmentListDataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();

                if (!string.IsNullOrEmpty(imagePath) && System.IO.File.Exists(imagePath))
                {
                    pictureBox.Image = Image.FromFile(imagePath);
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
