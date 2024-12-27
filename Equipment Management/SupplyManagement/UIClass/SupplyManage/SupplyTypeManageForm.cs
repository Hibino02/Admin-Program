using System;
using System.Windows.Forms;
using Admin_Program.SupplyManagement.ObjectClass;
using System.Collections.Generic;
using Admin_Program.GlobalVariable;
using Admin_Program.UIClass;

namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    public partial class SupplyTypeManageForm : Form
    {
        public event EventHandler updateSupplyType;

        MainBackGroundFrom main;

        EditSupplyTypeForm editSupplyType;

        List<SupplyType> supplyTypeList;
        BindingSource supplyTypeBindingSource;

        public SupplyTypeManageForm()
        {
            InitializeComponent();

            supplyTypeList = new List<SupplyType>();
            supplyTypeBindingSource = new BindingSource();

            UpdateSupplyType();
        }
        private void UpdateSupplyType()
        {
            if (supplyTypeList != null)
            {
                supplyTypeList.Clear();
            }
            supplyTypeList = SupplyType.GetAllSupplyTypeList();
            supplyTypeBindingSource.DataSource = supplyTypeList;
            SupplyTypeDataGridView.DataSource = supplyTypeBindingSource;
            FormatSupplyTypeDataGridView();
        }
        private void FormatSupplyTypeDataGridView()
        {
            if (SupplyTypeDataGridView.Columns["ID"] != null)
            {
                SupplyTypeDataGridView.Columns["ID"].Visible = false;
            }
            if (SupplyTypeDataGridView.Columns["TypeName"] != null)
            {
                var customColumn = SupplyTypeDataGridView.Columns["TypeName"];
                customColumn.HeaderText = "ประเภทวัสดุ";
                customColumn.Width = 700;
            }
            if (SupplyTypeDataGridView.Columns["WarehouseID"] != null)
            {
                SupplyTypeDataGridView.Columns["WarehouseID"].Visible = false;
            }
        }
        //Edit type event
        private void editSupplyTypeButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = SupplyTypeDataGridView.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                editSupplyType = new EditSupplyTypeForm();
                editSupplyType.Owner = main;
                editSupplyType.onSuccess += OnUpdate;
                editSupplyType.ShowDialog();
            }
        }
        //Remove type event
        private void removeSupplyTypeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = SupplyTypeDataGridView.CurrentRow;
            if(selectedRow != null)
            {
                int id = (int)selectedRow.Cells["ID"].Value;
                SupplyType spt = new SupplyType(id);
                if (spt.Remove())
                {
                    MessageBox.Show("ลบเสร็จสิ้น");
                    UpdateSupplyType();
                }
                else
                {
                    MessageBox.Show("ไม่สามารถลบได้ เนื่องจากถูกใช้งาน");
                }
            }
        }
        private void OnUpdate(object sender, EventArgs e)
        {
            UpdateSupplyType();
        }
        //Event to update combobox
        private void SupplyTypeManageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            updateSupplyType?.Invoke(this, EventArgs.Empty);
        }


    }
}
