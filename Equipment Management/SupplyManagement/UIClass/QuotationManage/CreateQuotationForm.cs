using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.QuotationManage
{
    public partial class CreateQuotationForm : Form
    {
        MainBackGroundFrom main;

        List<Supplier> supplierList;
        private List<int> supplierIDList = new List<int>();
        List<SupplyType> supplyTypeList;
        private List<int> supplyTypeIDList = new List<int>();
        //Supply
        BindingSource supplyBindingSource;
        List<AllSupplyListDataGridView> supplyViewList;
        //Selected supply
        BindingSource selectedSupplyBindingSource;
        List<AllSupplyInQuotationListDataGridView> selectedSupplyViewList;
        //Filter algorithm
        List<AllSupplyListDataGridView> originalSupplyViewList;
        List<AllSupplyListDataGridView> supplyTypeFilteredList;
        int currentSupplyTypeFilterID = -1;

        public CreateQuotationForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            supplyViewList = new List<AllSupplyListDataGridView>();
            supplyBindingSource = new BindingSource();

            selectedSupplyViewList = new List<AllSupplyInQuotationListDataGridView>();

            UpdateComponents();
            UpdateSupplyList();
        }

        private void UpdateComponents()
        {
            supplierList = Supplier.GetAllSupplierList();
            supplierList.Sort((x, y) => x.Name.CompareTo(y.Name));
            supplierComboBox.Items.Clear();
            supplierIDList.Clear();
            foreach(Supplier s in supplierList)
            {
                supplierComboBox.Items.Add(s.Name);
                supplierIDList.Add(s.ID);
            }

            supplyTypeList = SupplyType.GetAllSupplyTypeList();
            supplyTypeList.Sort((x, y) => x.TypeName.CompareTo(y.TypeName));
            supplyTypecomboBox.Items.Clear();
            supplyTypeIDList.Clear();
            supplyTypecomboBox.Items.Add("------กรุณาเลือกประเภทวัสดุ------");
            supplyTypeIDList.Add(-1);
            foreach (SupplyType st in supplyTypeList)
            {
                supplyTypecomboBox.Items.Add(st.TypeName);
                supplyTypeIDList.Add(st.ID);
            }
        }
        //Event to update supplier address refer to supplier combobox
        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supplierComboBox.SelectedIndex >= 0)
            {
                // Get the selected supplier's ID
                int selectedSupplierID = supplierIDList[supplierComboBox.SelectedIndex];

                // Find the supplier object
                Supplier selectedSupplier = supplierList.Find(s => s.ID == selectedSupplierID);

                // Display the supplier's address in the RichTextBox
                if (selectedSupplier != null)
                {
                    supplierAddressrichTextBox.Text = selectedSupplier.Address;
                }
            }
            else
            {
                // Clear the RichTextBox if no item is selected
                supplierAddressrichTextBox.Clear();
            }
        }
        //Supply mechanic in datagridview
        private void UpdateSupplyList()
        {
            supplyViewList = AllSupplyListDataGridView.AllSupply();
            originalSupplyViewList = new List<AllSupplyListDataGridView>(supplyViewList);
            ApplyCurrentSupplyFilter();
        }
        private void ApplyCurrentSupplyFilter()
        {
            int selectSupplyTypeID = supplyTypecomboBox.SelectedIndex > 0 ? supplyTypeIDList[supplyTypecomboBox.SelectedIndex] : -1;

            supplyTypeFilteredList = originalSupplyViewList
            .Where(s =>
            (selectSupplyTypeID < 0 || s.SupplyTypeID == selectSupplyTypeID))
            .ToList();

            supplyBindingSource.DataSource = supplyTypeFilteredList;
            supplyDatagridview.DataSource = supplyBindingSource;

            FormatSupplyDataGridView();
        }
        private void FormatSupplyDataGridView()
        {
            if(supplyDatagridview.Columns["ID"] != null)
            {
                supplyDatagridview.Columns["ID"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyName"] != null)
            {
                var customColumn = supplyDatagridview.Columns["SupplyName"];
                customColumn.HeaderText = "ชื่อวัสดุ";
                customColumn.Width = 500;
            }
            if (supplyDatagridview.Columns["SupplyUnit"] != null)
            {
                var customColumn = supplyDatagridview.Columns["SupplyUnit"];
                customColumn.HeaderText = "หน่วย";
                customColumn.Width = 55;
            }
            if (supplyDatagridview.Columns["MOQ"] != null)
            {
                supplyDatagridview.Columns["MOQ"].Visible = false;
            }
            if (supplyDatagridview.Columns["IsActive"] != null)
            {
                supplyDatagridview.Columns["IsActive"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyTypeID"] != null)
            {
                supplyDatagridview.Columns["SupplyTypeID"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyTypeName"] != null)
            {
                supplyDatagridview.Columns["SupplyTypeName"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyPhoto"] != null)
            {
                var customColumn = supplyDatagridview.Columns["SupplyPhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 50;
            }
        }
        private void supplyTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = supplyTypecomboBox.SelectedIndex;
            currentSupplyTypeFilterID = selectTypeIndex >= 0 ? supplyTypeIDList[selectTypeIndex] : -1;

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

                supplyBindingSource.DataSource = searchResults;
                supplyDatagridview.DataSource = supplyBindingSource;
            }
        }
        //Selected supply mechanic
        private void UpdateSelectedSupplyList()
        {
            selectedSupplyBindingSource.DataSource = selectedSupplyViewList;
            supplyInQuotationdataGridView.DataSource = selectedSupplyBindingSource;

            FormatSelectedSupplydataGridView();
        }
        private void FormatSelectedSupplydataGridView()
        {
            if (supplyInQuotationdataGridView.Columns["ID"] != null)
            {
                supplyInQuotationdataGridView.Columns["ID"].Visible = false;
            }
            if (supplyInQuotationdataGridView.Columns["QuotationID"] != null)
            {
                supplyInQuotationdataGridView.Columns["QuotationID"].Visible = false;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyID"] != null)
            {
                supplyInQuotationdataGridView.Columns["SupplyID"].Visible = false;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyName"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["SupplyName"];
                customColumn.HeaderText = "ชื่อวัสดุ";
                customColumn.Width = 500;
            }
            if (supplyInQuotationdataGridView.Columns["Price"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["Price"];
                customColumn.HeaderText = "ราคา/";
                customColumn.Width = 130;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyUnit"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["SupplyUnit"];
                customColumn.HeaderText = "หน่วย";
                customColumn.Width = 130;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyPhoto"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["SupplyPhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 50;
            }
        }
        //Event to add suppy to Quotation
        private void addSupplybutton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = supplyDatagridview.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวในตาราง");
                return;
            }

            float price;
            if (!float.TryParse(supplyPricetextBox.Text, out price))
            {
                MessageBox.Show("กรุณาระบุราคาให้ถูกต้อง");
                return;
            }

            int supplyID = (int)selectedRow.Cells["ID"].Value;
            string supplyName = selectedRow.Cells["SupplyName"].Value?.ToString() ?? string.Empty;
            string supplyUnit = selectedRow.Cells["SupplyUnit"].Value?.ToString() ?? string.Empty;
            string supplyPhoto = selectedRow.Cells["SupplyPhoto"].Value?.ToString() ?? string.Empty;

            AllSupplyInQuotationListDataGridView selectedSupplyToShow = new AllSupplyInQuotationListDataGridView(
                supplyID, supplyName, price, supplyUnit, supplyPhoto);
            selectedSupplyViewList.Add(selectedSupplyToShow);
            UpdateSelectedSupplyList();
        }
    }
}
