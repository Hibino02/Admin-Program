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

namespace Admin_Program.SupplyManagement.UIClass.SupplierManage
{
    public partial class AllSupplierListForm : Form
    {
        MainBackGroundFrom main;

        private CreateSupplierForm createSupplier;
        private EditSupplierForm editSupplier;

        BindingSource supplierBindingSource;
        List<AllSupplierListDataDridView> supplierViewList;

        public AllSupplierListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            supplierBindingSource = new BindingSource();
            supplierViewList = new List<AllSupplierListDataDridView>();

            UpdateSupplierList();
        }

        private void UpdateSupplierList()
        {
            supplierViewList = AllSupplierListDataDridView.AllSupplier();
            supplierBindingSource.DataSource = supplierViewList;
            SupplierDatagridview.DataSource = supplierBindingSource;

            FormatDataGridView();
        }
        private void FormatDataGridView()
        {
            if(SupplierDatagridview.Columns["ID"] != null)
            {
                SupplierDatagridview.Columns["ID"].Visible = false;
            }
            if (SupplierDatagridview.Columns["SupplierName"] != null)
            {
                var customColumn = SupplierDatagridview.Columns["SupplierName"];
                customColumn.HeaderText = "ชื่อซัพพลายเออร์";
                customColumn.Width = 500;
            }
            if (SupplierDatagridview.Columns["SupplierAddress"] != null)
            {
                var customColumn = SupplierDatagridview.Columns["SupplierAddress"];
                customColumn.HeaderText = "ที่อยู่ซัพพลายเออร์";
                customColumn.Width = 800;
            }
        }
        //Event to search
        private void searchSupplierTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchSupplierTextBox.Text.ToLower();

            if (!string.IsNullOrEmpty(searchText))
            {
                var searchResult = supplierViewList
                    .Where(s =>
                    s.SupplierName.ToLower().Contains(searchText)).ToList();

                supplierBindingSource.DataSource = searchResult;
                SupplierDatagridview.DataSource = supplierBindingSource;
            }
            else
            {
                UpdateSupplierList();
            }
        }
        //Create supplier
        private void CreateSupplyButton_Click(object sender, EventArgs e)
        {
            createSupplier = new CreateSupplierForm();
            createSupplier.Owner = main;
            createSupplier.ShowDialog();
            UpdateSupplierList();
        }
        //Edit supplier
        private void EditSupplyButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = SupplierDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                editSupplier = new EditSupplierForm();
                editSupplier.Owner = main;
                editSupplier.UpdateGrid += OnUpdate;
                editSupplier.ShowDialog();
            }
        }
        //Remove supplier
        private void RemoveSupplyButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = SupplierDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                DialogResult result = MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบรายการนี้?", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = (int)selectedRow.Cells["ID"].Value;
                    Supplier supplier = new Supplier(id);
                    if (supplier.Remove())
                    {
                        MessageBox.Show("ลบซัพพลายเออร์เสร็จสิ้น");
                        UpdateSupplierList();
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถลบได้ เนื่องจากกำลังถูกใช้งาน");
                    }
                }
            }
        }
        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateSupplierList();
        }


    }
}
