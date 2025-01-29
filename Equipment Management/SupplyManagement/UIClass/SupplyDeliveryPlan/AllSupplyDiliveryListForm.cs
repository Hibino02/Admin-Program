﻿using Admin_Program.SupplyManagement.CustomViewClass;
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

        List<AllMonthListDataGridView> monthList;
        List<int> mID = new List<int>();
        List<AllPlanListDataGridView> planList;
        BindingSource planListBindingSource;
        int planID;
        string planName;
        int monthID;
        string monthName;
        string mFMail = null;

        List<AllSupplyInPlanListDataGridView> allSupplyList = new List<AllSupplyInPlanListDataGridView>();
        List<AllSupplyInPlanListDataGridView> selectPlanSupplyList = new List<AllSupplyInPlanListDataGridView>();
        BindingSource selectPlanSupplyBindingSource;
        public AllSupplyDiliveryListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480,634);

            monthList = new List<AllMonthListDataGridView>();
            planList = new List<AllPlanListDataGridView>();
            planListBindingSource = new BindingSource();
            selectPlanSupplyBindingSource = new BindingSource();

            UpdateComponent();
            UpdatePlanGridView();
        }
        private void UpdateComponent()
        {
            monthList = AllMonthListDataGridView.AllMonth();
            selectMonthcomboBox.Items.Clear();
            mID.Clear();
            selectMonthcomboBox.Items.Add("---เลือกเดือน---");
            mID.Add(-1);
            foreach (AllMonthListDataGridView m in monthList)
            {
                selectMonthcomboBox.Items.Add(m.MonthName);
                mID.Add(m.MonthID);
            }
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
                DataGridViewRow selectedRow = planDatagridview.Rows[e.RowIndex];

                planID = Convert.ToInt32(selectedRow.Cells["PlanID"].Value);
                planName = selectedRow.Cells["PlanName"].Value.ToString();
                monthID = Convert.ToInt32(selectedRow.Cells["MonthID"].Value);
                monthName = selectedRow.Cells["MonthName"].Value.ToString();
                UpdateSupplyInPlanFridView(planID);
            }
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
                Columns["SupplyName"].Width = 588;
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
                Columns["QuantityW1"].HeaderText = "สัปดาห์ที่ 1";
                Columns["QuantityW1"].Width = 80;
                Columns["QuantityW1"].ReadOnly = false;
            }
            if (Columns["QuantityW2"] != null)
            {
                Columns["QuantityW2"].HeaderText = "สัปดาห์ที่ 2";
                Columns["QuantityW2"].Width = 80;
                Columns["QuantityW2"].ReadOnly = false;
            }
            if (Columns["QuantityW3"] != null)
            {
                Columns["QuantityW3"].HeaderText = "สัปดาห์ที่ 3";
                Columns["QuantityW3"].Width = 80;
                Columns["QuantityW3"].ReadOnly = false;
            }
            if (Columns["QuantityW4"] != null)
            {
                Columns["QuantityW4"].HeaderText = "สัปดาห์ที่ 4";
                Columns["QuantityW4"].Width = 80;
                Columns["QuantityW4"].ReadOnly = false;
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
        private void CheckSelectMonth()
        {
            int selectMonthIndex = selectMonthcomboBox.SelectedIndex;
            if(selectMonthIndex > 0)
            {
                int selectedMonthID = mID[selectMonthIndex];
                if (selectedMonthID != monthID)
                {
                    DeliveryMonth newM = new DeliveryMonth(selectedMonthID);
                    DeliveryMonth m = new DeliveryMonth(monthID, monthName);
                    DeliveryPlan dp = new DeliveryPlan(planID, GlobalVariable.Global.warehouseID, planName, m);
                    dp._Month = newM;
                    dp.Change();
                    MessageBox.Show("เดือนของแผนที่เลือกถูกแก้ใข");
                    mFMail = dp._Month._Month;
                }
            }
        }
        //Update Plan
        private void editButton_Click(object sender, EventArgs e)
        {
            CheckSelectMonth();
            if (selectPlanSupplydataGridView.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in selectPlanSupplydataGridView.Rows)
                {
                    int sipid = Convert.ToInt32(row.Cells["ID"].Value ?? 0);
                    int qw1 = Convert.ToInt32(row.Cells["QuantityW1"].Value ?? 0);
                    int qw2 = Convert.ToInt32(row.Cells["QuantityW2"].Value ?? 0);
                    int qw3 = Convert.ToInt32(row.Cells["QuantityW3"].Value ?? 0);
                    int qw4 = Convert.ToInt32(row.Cells["QuantityW4"].Value ?? 0);

                    SupplyInPlan sip = new SupplyInPlan(sipid);
                    sip.ReqW1 = qw1;
                    sip.ReqW2 = qw2;
                    sip.ReqW3 = qw3;
                    sip.ReqW4 = qw4;
                    sip.Change();
                }
                if(mFMail == null)
                {
                    GlobalVariable.EmailService.SendEmailForPlan(planName, monthName);
                }
                else
                {
                    GlobalVariable.EmailService.SendEmailForPlan(planName, mFMail);
                }
                MessageBox.Show("อัฟเดทแผนเรียบร้อย");
                UpdatePlanGridView();
            }
        }
        //Remove Plan
        private void removeButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = planDatagridview.CurrentRow;

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
                int planID = (int)selectedRow.Cells["PlanID"].Value;
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
    }
}
