using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyDeliveryPlan
{
    public partial class CreateSupplyDeliveryPlanForm : Form
    {
        List<SupplyType> allSupplyTypeList;
        List<int> SupplyTypeListID = new List<int>();
        List<AllMonthListDataGridView> allMonthList;
        List<int> MonthListID = new List<int>();
        DeliveryMonth selectMonth;

        List<AllSupplyListDataGridView> allSupplyViewList;
        BindingSource allSupplyBindingSource;
        List<AllSupplyListDataGridView> selectedSupplyViewList;
        BindingSource selectedSupplyViewListBindingSource;
        //Filter algorithm
        List<AllSupplyListDataGridView> originalSupplyViewList;
        List<AllSupplyListDataGridView> supplyTypeFilteredList;
        int currentSupplyTypeFilterID = -1;
        public CreateSupplyDeliveryPlanForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 434);

            allSupplyTypeList = new List<SupplyType>();
            allMonthList = new List<AllMonthListDataGridView>();
            allSupplyViewList = new List<AllSupplyListDataGridView>();
            selectedSupplyViewList = new List<AllSupplyListDataGridView>();

            selectedSupplyViewListBindingSource = new BindingSource();
            allSupplyBindingSource = new BindingSource();

            UpdateComponent();
            UpdateSupplyList();
        }
        private void UpdateComponent()
        {
            allSupplyTypeList = SupplyType.GetAllSupplyTypeList();
            allSupplyTypeList.Sort((x, y) => x.TypeName.CompareTo(y.TypeName));
            supplyTypecomboBox.Items.Clear();
            SupplyTypeListID.Clear();
            supplyTypecomboBox.Items.Add("------กรุณาเลือกประเภทวัสดุ------");
            SupplyTypeListID.Add(-1);
            foreach (SupplyType asl in allSupplyTypeList)
            {
                supplyTypecomboBox.Items.Add(asl.TypeName);
                SupplyTypeListID.Add(asl.ID);
            }
            allMonthList = AllMonthListDataGridView.AllMonth();
            monthSelectioncomboBox.Items.Clear();
            MonthListID.Clear();
            monthSelectioncomboBox.Items.Add("-กรุณาเลือกเดือน-");
            MonthListID.Add(-1);
            foreach (AllMonthListDataGridView m in allMonthList)
            {
                monthSelectioncomboBox.Items.Add(m.MonthName);
                MonthListID.Add(m.MonthID);
            }
        }
        //All Supply DataGridView
        private void UpdateSupplyList()
        {
            allSupplyViewList = AllSupplyListDataGridView.AllSupply();
            originalSupplyViewList = new List<AllSupplyListDataGridView>(allSupplyViewList);
            ApplyCurrentSupplyFilter();
        }
        private void ApplyCurrentSupplyFilter()
        {
            int selectSupplyTypeID = supplyTypecomboBox.SelectedIndex > 0 ? SupplyTypeListID[supplyTypecomboBox.SelectedIndex] : -1;

            supplyTypeFilteredList = originalSupplyViewList
                .Where(s =>
                (selectSupplyTypeID < 0 || s.SupplyTypeID == selectSupplyTypeID)).ToList();

            allSupplyBindingSource.DataSource = supplyTypeFilteredList;
            allSupplydataGridView.DataSource = allSupplyBindingSource;

            FormatSupplyDataGridView();
        }
        private void FormatSupplyDataGridView()
        {
            if (allSupplydataGridView.Columns["ID"] != null)
            {
                allSupplydataGridView.Columns["ID"].Visible = false;
            }
            if (allSupplydataGridView.Columns["SupplyName"] != null)
            {
                var customColumn = allSupplydataGridView.Columns["SupplyName"];
                customColumn.HeaderText = "ชื่อวัสดุ";
                customColumn.Width = 500;
            }
            if (allSupplydataGridView.Columns["SupplyUnit"] != null)
            {
                var customColumn = allSupplydataGridView.Columns["SupplyUnit"];
                customColumn.HeaderText = "หน่วย";
                customColumn.Width = 55;
            }
            if (allSupplydataGridView.Columns["MOQ"] != null)
            {
                allSupplydataGridView.Columns["MOQ"].Visible = false;
            }
            if (allSupplydataGridView.Columns["IsActive"] != null)
            {
                allSupplydataGridView.Columns["IsActive"].Visible = false;
            }
            if (allSupplydataGridView.Columns["SupplyTypeID"] != null)
            {
                allSupplydataGridView.Columns["SupplyTypeID"].Visible = false;
            }
            if (allSupplydataGridView.Columns["SupplyTypeName"] != null)
            {
                allSupplydataGridView.Columns["SupplyTypeName"].Visible = false;
            }
            if (allSupplydataGridView.Columns["SupplyPhoto"] != null)
            {
                var customColumn = allSupplydataGridView.Columns["SupplyPhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 50;
            }
        }
        private void supplyTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = supplyTypecomboBox.SelectedIndex;
            currentSupplyTypeFilterID = selectTypeIndex >= 0 ? SupplyTypeListID[selectTypeIndex] : -1;

            ApplyCurrentSupplyFilter();
        }
        private void supplySearchtextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = supplySearchtextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentSupplyFilter();
            }
            else
            {
                var searchResults = supplyTypeFilteredList
                    .Where(s =>
                    s.SupplyName.ToLower().Contains(searchText) ||
                    s.SupplyTypeName.ToLower().Contains(searchText)).ToList();

                allSupplyBindingSource.DataSource = searchResults;
                allSupplydataGridView.DataSource = allSupplyBindingSource;
            }
        }
        //Add Supply to plan
        private void addToSupplyInPRbutton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = allSupplydataGridView.CurrentRow;

            if(selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกวัสดุ");
                return;
            }

            int supplyID = (int)selectedRow.Cells["ID"].Value;
            string supplyName = selectedRow.Cells["SupplyName"].Value?.ToString() ?? string.Empty;
            string supplyUnit = selectedRow.Cells["SupplyUnit"].Value?.ToString() ?? string.Empty;

            AllSupplyListDataGridView selectedSupplyToShow = new AllSupplyListDataGridView(supplyID, supplyName, supplyUnit);
            selectedSupplyViewList.Add(selectedSupplyToShow);
            UpdateSelectedSupplyList();
        }
        //Selected Supply DataGridView
        private void UpdateSelectedSupplyList()
        {
            selectedSupplyDatagridview.DataSource = null;
            selectedSupplyViewListBindingSource.DataSource = selectedSupplyViewList;
            selectedSupplyDatagridview.DataSource = selectedSupplyViewListBindingSource;

            FormatSelectedSupplyDataGridView();
        }
        private void FormatSelectedSupplyDataGridView()
        {
            if (selectedSupplyDatagridview.Columns["ID"] != null)
            {
                selectedSupplyDatagridview.Columns["ID"].Visible = false;
            }
            if (selectedSupplyDatagridview.Columns["SupplyName"] != null)
            {
                var customColumn = selectedSupplyDatagridview.Columns["SupplyName"];
                customColumn.HeaderText = "ชื่อวัสดุ";
                customColumn.Width = 500;
            }
            if (selectedSupplyDatagridview.Columns["SupplyUnit"] != null)
            {
                var customColumn = selectedSupplyDatagridview.Columns["SupplyUnit"];
                customColumn.HeaderText = "หน่วย";
                customColumn.Width = 55;
            }
            if (selectedSupplyDatagridview.Columns["MOQ"] != null)
            {
                selectedSupplyDatagridview.Columns["MOQ"].Visible = false;
            }
            if (selectedSupplyDatagridview.Columns["IsActive"] != null)
            {
                selectedSupplyDatagridview.Columns["IsActive"].Visible = false;
            }
            if (selectedSupplyDatagridview.Columns["SupplyTypeID"] != null)
            {
                selectedSupplyDatagridview.Columns["SupplyTypeID"].Visible = false;
            }
            if (selectedSupplyDatagridview.Columns["SupplyTypeName"] != null)
            {
                selectedSupplyDatagridview.Columns["SupplyTypeName"].Visible = false;
            }
            if (selectedSupplyDatagridview.Columns["SupplyPhoto"] != null)
            {
                selectedSupplyDatagridview.Columns["SupplyPhoto"].Visible = false;
            }
        }
        //Remove Supply from plan
        private void removeFromSupplyInPRbutton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = selectedSupplyDatagridview.CurrentRow;

            if(selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกวัสดุที่จะนำออกจากรายการ");
                return;
            }
            int rowIndex = selectedRow.Index;
            // Check if the index is valid in the list
            if (rowIndex >= 0 && rowIndex < selectedSupplyViewList.Count)
            {
                // Remove the item from the list at the given index
                selectedSupplyViewList.RemoveAt(rowIndex);

                // Update the DataGridView
                UpdateSelectedSupplyList();
            }
        }
        //Check attributes
        private bool CheckAll()
        {
            int selectMonthIndex = monthSelectioncomboBox.SelectedIndex;
            if(selectMonthIndex >= 0&& selectMonthIndex < MonthListID.Count)
            {
                int selectedMonthID = MonthListID[selectMonthIndex];
                selectMonth = new DeliveryMonth(selectedMonthID);
            }
            else
            {
                MessageBox.Show("กรุณาเลือก เดือน");
                return false;
            }
            if (string.IsNullOrEmpty(planNametextBox.Text))
            {
                MessageBox.Show("กรุณา ตั้งชื่อแผน");
                return false;
            }
            if(selectedSupplyViewList.Count <= 0)
            {
                MessageBox.Show("กรุณาเลือกวัสดุ อย่างน้อย 1 รายการ");
                return false;
            }
            return true;
        }
        private void createPRbutton_Click(object sender, EventArgs e)
        {
            if (CheckAll())
            {
                DeliveryPlan dp = new DeliveryPlan(GlobalVariable.Global.warehouseID, planNametextBox.Text, selectMonth);
                if (dp.Create())
                {
                    foreach (AllSupplyListDataGridView selectS in selectedSupplyViewList)
                    {
                        Supply newS = new Supply(selectS.ID);
                        SupplyInPlan sip = new SupplyInPlan(newS,0,0,0,0, dp.ID);
                        sip.Create();
                    }
                }  
                MessageBox.Show("สร้างแผนเสร็จสิ้น");
                Close();
            }
        }
    }
}
