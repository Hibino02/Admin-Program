using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        List<AllSupplyInPlanListDataGridView> allSupplyList = AllSupplyInPlanListDataGridView.AllSupplyInPlan();
        List<AllSupplyInPlanListDataGridView> selectPlanSupplyList = new List<AllSupplyInPlanListDataGridView>();
        BindingSource selectPlanSupplyBindingSource;
        public AllSupplyDiliveryListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480,434);

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
                Columns["PlanName"].Width = 305;
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
                Columns["SupplyName"].Width = 542;
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
            if(selectPlanSupplydataGridView.Rows.Count > 0)
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
            } 
        }
    }
}
