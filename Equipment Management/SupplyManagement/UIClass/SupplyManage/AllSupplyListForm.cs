using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using Admin_Program.GlobalVariable;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Admin_Program.SupplyManagement.CustomViewClass;
using Library.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    public partial class AllSupplyListForm : Form
    {
        MainBackGroundFrom main;

        private CreateSupplyForm createSupply;
        private EditSupplyForm editSupply;

        //Picture box
        private PictureBox supplyPictureBox;

        private List<int> supplyTypeID = new List<int>();
        List<SupplyType> supplyTypeList;

        BindingSource supplyBindingSource;
        List<AllSupplyListDataGridView> supplyViewList;
        //Filter algorithm variable
        private List<AllSupplyListDataGridView> originalList;
        List<AllSupplyListDataGridView> supplyTypeFilteredList;
        private int currentFilterID = -1; // Holds the currently selected filter ID

        public AllSupplyListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            supplyViewList = new List<AllSupplyListDataGridView>();
            supplyBindingSource = new BindingSource();

            //Create hidden picturebox
            supplyPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(supplyPictureBox);
            //Register Event
            SupplyInventoryDatagridview.CellMouseEnter += SupplyInventoryDatagridview_CellMouseEnter;
            SupplyInventoryDatagridview.CellMouseLeave += SupplyInventoryDatagridview_CellMouseLeave;

            UpdateSupplyList();
            UpdateComponents();
        }

        private void UpdateComponents()
        {
            supplyTypeList = SupplyType.GetAllSupplyTypeList();
            supplyTypeList.Sort((x, y) => x.TypeName.CompareTo(y.TypeName));
            supplyTypeComboBox.Items.Clear();
            supplyTypeID.Clear();

            supplyTypeComboBox.Items.Add("------กรุณาเลือกประเภทวัสดุ------");
            supplyTypeID.Add(-1);
            foreach (SupplyType spt in supplyTypeList)
            {
                supplyTypeComboBox.Items.Add(spt.TypeName);
                supplyTypeID.Add(spt.ID);
            }
        }
        private void UpdateSupplyList()
        {
            supplyViewList = AllSupplyListDataGridView.AllSupply();
            originalList = new List<AllSupplyListDataGridView>(supplyViewList);
            ApplyCurrentFilter();
        }
        //Method for apply combobox to gridview
        private void ApplyCurrentFilter()
        {
            int selectSupplyTypeID = supplyTypeComboBox.SelectedIndex > 0 ? supplyTypeID[supplyTypeComboBox.SelectedIndex] : -1;

            supplyTypeFilteredList = originalList
            .Where(s =>
            (selectSupplyTypeID < 0 || s.SupplyTypeID == selectSupplyTypeID))
            .ToList();

            SortableBindingList<AllSupplyListDataGridView> sortableList = new SortableBindingList<AllSupplyListDataGridView>(supplyTypeFilteredList);
            supplyBindingSource.DataSource = sortableList;
            SupplyInventoryDatagridview.DataSource = supplyBindingSource;

            FormatDataGridView();
        }
        private void FormatDataGridView()
        {
            var Columns = SupplyInventoryDatagridview.Columns;
            if(Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัสดุ";
                Columns["SupplyName"].Width = 500;
                Columns["SupplyName"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].HeaderText = "หน่วย";
                Columns["SupplyUnit"].Width = 50;
                Columns["SupplyUnit"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (Columns["MOQ"] != null)
            {
                Columns["MOQ"].HeaderText = "จุดต่ำสุดที่ต้องสั่งซื้อ";
                Columns["MOQ"].Width = 130;
                Columns["MOQ"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (Columns["IsActive"] != null)
            {
                Columns["IsActive"].Visible = false;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].HeaderText = "รูปวัสดุ";
                Columns["SupplyPhoto"].Width = 50;
                Columns["SupplyPhoto"].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            if (Columns["SupplyTypeID"] != null)
            {
                Columns["SupplyTypeID"].Visible = false;
            }
            if (Columns["SupplyTypeName"] != null)
            {
                Columns["SupplyTypeName"].HeaderText = "ประเภทวัสดุ";
                Columns["SupplyTypeName"].Width = 400;
            }
        }
        private void supplyTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = supplyTypeComboBox.SelectedIndex;
            currentFilterID = selectTypeIndex >= 0 ? supplyTypeID[selectTypeIndex] : -1;

            ApplyCurrentFilter();
        }
        //Create Supply
        private void CreateSupplyButton_Click(object sender, EventArgs e)
        {
            createSupply = new CreateSupplyForm();
            createSupply.Owner = main;
            createSupply.ShowDialog();
            UpdateSupplyList();
            UpdateComponents();
        }
        //Edit Supply
        private void EditSupplyButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = SupplyInventoryDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                editSupply = new EditSupplyForm();
                editSupply.Owner = main;
                editSupply.UpdateGrid += OnUpdate;
                UpdateComponents();
                editSupply.ShowDialog();
            }          
        }
        //Remove supply
        private void RemoveSupplyButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = SupplyInventoryDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                DialogResult result = MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบรายการนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = (int)selectedRow.Cells["ID"].Value;
                    Supply supply = new Supply(id);
                    if (supply.Remove())
                    {
                        Global.DeleteFileFromFtpSupply(supply.SupplyPhoto);
                        MessageBox.Show("ลบวัสดุเสร็จสิ้น");
                        UpdateSupplyList();
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถลบได้ เนื่องจากกำลังถูกใช้งาน");
                    }
                }
            }
        }
        //Method for update gridview
        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateSupplyList();
        }
        //Event to apply textchange in searchTextBox
        private void searchSupplyTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchSupplyTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentFilter();
            }
            else
            {
                var searchResults = supplyTypeFilteredList
                .Where(s =>
                    s.SupplyName.ToLower().Contains(searchText) ||
                    s.SupplyUnit.ToLower().Contains(searchText)).ToList();

                supplyBindingSource.DataSource = searchResults;
                SupplyInventoryDatagridview.DataSource = supplyBindingSource;
            }
        }
        //Event to show and hide PictureBox
        private void SupplyInventoryDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string columnName = SupplyInventoryDatagridview.Columns[e.ColumnIndex].Name;
                if(columnName == "SupplyPhoto")
                {
                    string imagePath = SupplyInventoryDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }
                    Global.LoadImageIntoPictureBox(imagePath, supplyPictureBox);
                    supplyPictureBox.Visible = true;
                    supplyPictureBox.BringToFront();
                }
            }
        }
        private void SupplyInventoryDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            supplyPictureBox.Visible = false;
        }
    }
}
