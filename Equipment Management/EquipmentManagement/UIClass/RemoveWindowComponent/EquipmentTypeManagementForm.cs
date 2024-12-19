using System;
using System.Windows.Forms;
using Admin_Program.ObjectClass;
using System.Collections.Generic;

namespace Admin_Program.EquipmentManagement.UIClass.EquipmentInstallEditWriteOffSource
{
    public partial class EquipmentTypeManagementForm : Form
    {
        public event EventHandler updateEquipmentType;

        List<EquipmentType> etypeList;

        BindingSource etypeBindingSource;
        public EquipmentTypeManagementForm()
        {
            InitializeComponent();
            etypeList = new List<EquipmentType>();
            etypeBindingSource = new BindingSource();

            UpdateEquipmentType();
        }
        private void UpdateEquipmentType()
        {
            if (etypeList != null)
            {
                etypeList.Clear();
            }
            etypeList = EquipmentType.GetEquipmentTypeList();
            etypeBindingSource.DataSource = etypeList;
            eTypeDataGridView.DataSource = etypeBindingSource;
            FormatEquipmentTypeDataGridView();
        }
        private void FormatEquipmentTypeDataGridView()
        {
            if(eTypeDataGridView.Columns["ID"] != null)
            {
                eTypeDataGridView.Columns["ID"].Visible = false;
            }
            if (eTypeDataGridView.Columns["WarehouseID"] != null)
            {
                eTypeDataGridView.Columns["WarehouseID"].Visible = false;
            }
            if (eTypeDataGridView.Columns["EType"] != null)
            {
                var customColumn = eTypeDataGridView.Columns["EType"];
                customColumn.HeaderText = "ประเภทอุปกรณ์";
                customColumn.Width = 700;
            }
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
           DataGridViewRow selectRow = eTypeDataGridView.CurrentRow;
            if (selectRow != null)
            {
                string cellValue = selectRow.Cells[1].Value?.ToString();

                DialogResult result = MessageBox.Show(
                    $"คุณต้องการลบ {cellValue} หรือไม่?",
                    "ยืนยันการลบ",
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.OK)
                {
                    int id = (int)selectRow.Cells["ID"].Value;
                    EquipmentType et = new EquipmentType(id);
                    if (et.Remove())
                    {
                        MessageBox.Show("การลบสมบูรณ์");
                        updateEquipmentType?.Invoke(this, EventArgs.Empty);
                        UpdateEquipmentType();
                    }
                    else
                    {
                        MessageBox.Show("ไม่สามารถลบได้เนื่องจากอุปกรณ์มีการใช้งานประเภทนี้");
                    }
                }
            }
        }
    }
}
