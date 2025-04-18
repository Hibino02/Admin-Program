using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyDeliveryPlan
{
    public partial class AllSupplyDiliveryListForm : Form
    {
        CreateSupplyDeliveryPlanForm createSupply;
        MainBackGroundFrom main;

        List<AllPlanListDataGridView> planList;
        BindingSource planListBindingSource;
        int planID;
        string planName;
        string monthName;
        DataGridViewRow selectedRow;

        object w1;
        object w2;
        object w3;
        object w4;

        List<AllSupplyInPlanListDataGridView> allSupplyList = new List<AllSupplyInPlanListDataGridView>();
        List<AllSupplyInPlanListDataGridView> selectPlanSupplyList = new List<AllSupplyInPlanListDataGridView>();
        BindingSource selectPlanSupplyBindingSource;
        public AllSupplyDiliveryListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480,657);

            planList = new List<AllPlanListDataGridView>();
            planListBindingSource = new BindingSource();
            selectPlanSupplyBindingSource = new BindingSource();

            UpdatePlanGridView();
        }

        //Update Plan
        private void UpdatePlanGridView()
        {
            allSupplyList = AllSupplyInPlanListDataGridView.AllSupplyInPlan();
            planList = AllPlanListDataGridView.AllPlan();
            planListBindingSource.DataSource = planList;
            planDatagridview.DataSource = planListBindingSource;

            FormatPlanDataGridView();
        }
        private void FormatPlanDataGridView()
        {
            var Columns = planDatagridview.Columns;
            if(Columns["PlanID"] != null)
            {
                Columns["PlanID"].Visible = false;
            }
            if (Columns["PlanName"] != null)
            {
                Columns["PlanName"].HeaderText = "ชื่อแผน";
                Columns["PlanName"].Width = 238;
            }
            if (Columns["MonthID"] != null)
            {
                Columns["MonthID"].Visible = false;
            }
            if (Columns["MonthName"] != null)
            {
                Columns["MonthName"].HeaderText = "เดือน";
                Columns["MonthName"].Width = 80;
            }
        }
        private void planDatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedRow = planDatagridview.Rows[e.RowIndex];

                planID = Convert.ToInt32(selectedRow.Cells["PlanID"].Value);
                planName = selectedRow.Cells["PlanName"].Value.ToString();
                monthName = selectedRow.Cells["MonthName"].Value.ToString();
                UpdateSupplyInPlanFridView(planID);
            }
        }
        //Setting dateTimePicker dynamically **call form FormatSupplyInPlanDataGridView()
        private void SetDateTimePickerValue(DateTimePicker picker, object value)
        {
            if (value != null)
            {
                DateTime date;
                if (DateTime.TryParse(value.ToString(), out date))
                {
                    picker.Value = date;
                    picker.Checked = true;
                    return;
                }
            }
            picker.Checked = false;
        }
        private void planDatagridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(planDatagridview.Rows.Count > 0)
            {
                planDatagridview.CurrentCell = planDatagridview.Rows[0].Cells[1];
                planDatagridview_CellClick(this, new DataGridViewCellEventArgs(0, 0));
            }
        }
        //Update SupplyInPlan
        private void UpdateSupplyInPlanFridView(int id)
        {
            selectPlanSupplyList = allSupplyList
                .Where(s => s.PlanID == id).ToList();

            selectPlanSupplyBindingSource.DataSource = selectPlanSupplyList;
            selectPlanSupplydataGridView.DataSource = selectPlanSupplyBindingSource;

            FormatSupplyInPlanDataGridView();
        }
        private void FormatSupplyInPlanDataGridView()
        {
            var Columns = selectPlanSupplydataGridView.Columns;
            if (Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["PlanID"] != null)
            {
                Columns["PlanID"].Visible = false;
            }
            if (Columns["SupplyID"] != null)
            {
                Columns["SupplyID"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัสดุ";
                Columns["SupplyName"].Width = 470;
                Columns["SupplyName"].ReadOnly = true;
            }
            if (Columns["Balance"] != null)
            {
                Columns["Balance"].HeaderText = "คงหลือ/หน่วย";
                Columns["Balance"].Width = 80;
                Columns["Balance"].ReadOnly = true;
                selectPlanSupplydataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["Balance"].Index && e.RowIndex >= 0)
                    {
                        string balance = selectPlanSupplydataGridView.Rows[e.RowIndex].Cells["Balance"]?.Value?.ToString();
                        string unit = selectPlanSupplydataGridView.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if (!string.IsNullOrEmpty(balance) && !string.IsNullOrEmpty(unit))
                        {
                            e.Value = $"{balance} {unit}";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["Remain"] != null)
            {
                Columns["Remain"].HeaderText = "ค้างส่ง";
                Columns["Remain"].Width = 40;
                Columns["Remain"].ReadOnly = true;
            }
            if (Columns["IncRemain"] != null)
            {
                Columns["IncRemain"].HeaderText = "รวม";
                Columns["IncRemain"].Width = 40;
                Columns["IncRemain"].ReadOnly = true;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].Visible = false;
            }
            if (Columns["UpdateDate"] != null)
            {
                Columns["UpdateDate"].HeaderText = "วันที่อัฟเดท";
                Columns["UpdateDate"].Width = 93;
                Columns["UpdateDate"].DefaultCellStyle.Format = "MMM dd, yyy";
                Columns["UpdateDate"].ReadOnly = true;
            }
            if (Columns["QuantityW1"] != null)
            {
                string header = "สัปดาห์ที่ 1";
                if (selectPlanSupplydataGridView.Rows.Count > 0)
                {
                    w1 = selectPlanSupplydataGridView.Rows[0].Cells["DateW1"].Value;
                    SetDateTimePickerValue(dateTimePickerW1, w1);
                    DateTime date;
                    if (w1 != null && DateTime.TryParse(w1.ToString(), out date))
                    {
                        header = date.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("th-TH"));
                    }
                }
                Columns["QuantityW1"].HeaderText = header;
                Columns["QuantityW1"].Width = 80;
                Columns["QuantityW1"].ReadOnly = false;
            }
            if (Columns["QuantityW2"] != null)
            {
                string header = "สัปดาห์ที่ 2";
                if (selectPlanSupplydataGridView.Rows.Count > 0)
                {
                    w2 = selectPlanSupplydataGridView.Rows[0].Cells["DateW2"].Value;
                    SetDateTimePickerValue(dateTimePickerW2, w2);
                    DateTime date;
                    if (w2 != null && DateTime.TryParse(w2.ToString(), out date))
                    {
                        header = date.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("th-TH"));
                    }
                }
                Columns["QuantityW2"].HeaderText = header;
                Columns["QuantityW2"].Width = 80;
                Columns["QuantityW2"].ReadOnly = false;
            }
            if (Columns["QuantityW3"] != null)
            {
                string header = "สัปดาห์ที่ 3";
                if (selectPlanSupplydataGridView.Rows.Count > 0)
                {
                    w3 = selectPlanSupplydataGridView.Rows[0].Cells["DateW3"].Value;
                    SetDateTimePickerValue(dateTimePickerW3, w3);
                    DateTime date;
                    if (w3 != null && DateTime.TryParse(w3.ToString(), out date))
                    {
                        header = date.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("th-TH"));
                    }
                }
                Columns["QuantityW3"].HeaderText = header;
                Columns["QuantityW3"].Width = 80;
                Columns["QuantityW3"].ReadOnly = false;
            }
            if (Columns["QuantityW4"] != null)
            {
                string header = "สัปดาห์ที่ 4";
                if (selectPlanSupplydataGridView.Rows.Count > 0)
                {
                    w4 = selectPlanSupplydataGridView.Rows[0].Cells["DateW4"].Value;
                    SetDateTimePickerValue(dateTimePickerW4, w4);
                    DateTime date;
                    if (w4 != null && DateTime.TryParse(w4.ToString(), out date))
                    {
                        header = date.ToString("dd MMM yyyy", new System.Globalization.CultureInfo("th-TH"));
                    }
                }
                Columns["QuantityW4"].HeaderText = header;
                Columns["QuantityW4"].Width = 80;
                Columns["QuantityW4"].ReadOnly = false;
            }
            if (Columns["Total"] != null)
            {
                Columns["Total"].HeaderText = "รวม";
                Columns["Total"].Width = 40;
                Columns["Total"].ReadOnly = true;
            }
            if (Columns["DateW1"] != null)
            {
                Columns["DateW1"].Visible = false;
            }
            if (Columns["DateW2"] != null)
            {
                Columns["DateW2"].Visible = false;
            }
            if (Columns["DateW3"] != null)
            {
                Columns["DateW3"].Visible = false;
            }
            if (Columns["DateW4"] != null)
            {
                Columns["DateW4"].Visible = false;
            }
            selectPlanSupplydataGridView.CellFormatting += selectPlanSupplydataGridView_CellFormatting;
        }
        //Create Plan
        private void CreateSupplyButton_Click(object sender, EventArgs e)
        {
            createSupply = new CreateSupplyDeliveryPlanForm();
            createSupply.Owner = main;
            createSupply.ShowDialog();
            UpdatePlanGridView();
        }
        //Update Plan
        private void editButton_Click(object sender, EventArgs e)
        {
            if (selectPlanSupplydataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in selectPlanSupplydataGridView.Rows)
                {
                    int sipid = Convert.ToInt32(row.Cells["ID"].Value ?? 0);
                    int qw1 = Convert.ToInt32(row.Cells["QuantityW1"].Value ?? 0);
                    int qw2 = Convert.ToInt32(row.Cells["QuantityW2"].Value ?? 0);
                    int qw3 = Convert.ToInt32(row.Cells["QuantityW3"].Value ?? 0);
                    int qw4 = Convert.ToInt32(row.Cells["QuantityW4"].Value ?? 0);

                    DateTime? dateW1 = dateTimePickerW1.Checked ? (DateTime?)dateTimePickerW1.Value.Date : null;
                    DateTime? dateW2 = dateTimePickerW2.Checked ? (DateTime?)dateTimePickerW2.Value.Date : null;
                    DateTime? dateW3 = dateTimePickerW3.Checked ? (DateTime?)dateTimePickerW3.Value.Date : null;
                    DateTime? dateW4 = dateTimePickerW4.Checked ? (DateTime?)dateTimePickerW4.Value.Date : null;

                    SupplyInPlan sip = new SupplyInPlan(sipid);
                    sip.ReqW1 = qw1;
                    sip.ReqW2 = qw2;
                    sip.ReqW3 = qw3;
                    sip.ReqW4 = qw4;
                    sip.DateW1 = dateW1;
                    sip.DateW2 = dateW2;
                    sip.DateW3 = dateW3;
                    sip.DateW4 = dateW4;
                    sip.Change();
                }
                GlobalVariable.EmailService.SendEmailForPlan(planName, monthName);
                MessageBox.Show("อัฟเดทแผนเรียบร้อย");
                UpdatePlanGridView();
            }
        }
        //Remove Plan
        private void removeButton_Click(object sender, EventArgs e)
        {
            if(selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกแผน");
                return;
            }
            DialogResult result = MessageBox.Show(
            "คุณแน่ใจหรือไม่ว่าต้องการลบแผนนี้?",
            "ยืนยันการลบ",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
                if (SupplyInPlan.Remove(planID))
                {
                    MessageBox.Show("ลบรายการวัสดุในแผนเรียบร้อย");
                    if (DeliveryPlan.Remove(planID))
                    {
                        MessageBox.Show("ลบแผนเรียบร้อย");
                        UpdatePlanGridView();
                        selectPlanSupplyBindingSource.DataSource = null;
                    }
                }
                else
                {
                    MessageBox.Show("แผนนี้ไม่สามารถลบได้ เนื่องจากถูกอ้างอิงใน PR กรุณาสิ้นสุดแผน");
                }
            }
        }
        //Finish Plan
        private void finbutton_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกแผน");
                return;
            }
            DialogResult result = MessageBox.Show(
            "คุณแน่ใจหรือไม่ว่าต้องการสิ้นสุดแผนนี้?",
            "ยืนยันการสิ้นสุด",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                DeliveryPlan selPlan = new DeliveryPlan(planID);
                selPlan.PlanStatus = false;
                if (selPlan.Change())
                {
                    MessageBox.Show("สิ้นสุดแผนเรียบร้อย");
                    UpdatePlanGridView();
                    selectPlanSupplyBindingSource.DataSource = null;
                }
            }
        }
        //Clear selected plan
        private void clearPlanbutton_Click(object sender, EventArgs e)
        {
            if (selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกแผน");
                return;
            }
            DialogResult result = MessageBox.Show(
            "คุณแน่ใจหรือไม่ว่าต้องการ ล้างข้อมูล แผนนี้?",
            "ยืนยันการล้างข้อมูล",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (selectPlanSupplydataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in selectPlanSupplydataGridView.Rows)
                    {
                        int sipid = Convert.ToInt32(row.Cells["ID"].Value ?? 0);

                        SupplyInPlan sip = new SupplyInPlan(sipid);
                        sip.ReqW1 = 0;
                        sip.ReqW2 = 0;
                        sip.ReqW3 = 0;
                        sip.ReqW4 = 0;
                        sip.DateW1 = null;
                        sip.DateW2 = null;
                        sip.DateW3 = null;
                        sip.DateW4 = null;
                        sip.Change();
                    }
                    GlobalVariable.EmailService.SendEmailForPlan(planName, monthName);
                    MessageBox.Show("ล้างแผนเรียบร้อย");
                    UpdatePlanGridView();
                }
            }
        }
        //Highlight Water proof
        private void selectPlanSupplydataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow row in selectPlanSupplydataGridView.Rows)
            {
                if (row.Cells["SupplyName"].Value != null) // Ensure the cell is not null
                {
                    string cellValue = row.Cells["SupplyName"].Value.ToString();

                    if (cellValue.IndexOf("Water", StringComparison.OrdinalIgnoreCase) >=0 ||
                        cellValue.IndexOf("Poof", StringComparison.OrdinalIgnoreCase)>=0)
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow; // Highlight row
                        row.DefaultCellStyle.ForeColor = Color.Black;  // Change text color if needed
                    }
                    else
                    {
                        row.DefaultCellStyle.BackColor = Color.White; // Reset color if conditions not met
                        row.DefaultCellStyle.ForeColor = Color.Black;
                    }
                }
            }
        }
        //Export Excel
        private void excelbutton_Click(object sender, EventArgs e)
        {
            var export = new ExportExcellForSupplyPlan(selectPlanSupplydataGridView);
            export.ExportToExcel();
        }
    }
}
