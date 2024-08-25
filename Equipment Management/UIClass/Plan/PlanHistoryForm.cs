using System;
using System.Collections.Generic;
using System.Drawing;
using Equipment_Management.CustomViewClass;
using System.Windows.Forms;
using Equipment_Management.GlobalVariable;

namespace Equipment_Management.UIClass.Plan
{
    public partial class PlanHistoryForm : Form
    {
        public event EventHandler UpdateGrid;
        MainBackGroundFrom main;
        private PlanHistoryProgressForm planHistoryProgressForm;

        List<AllPlanView> allPlanHistoryList;
        BindingSource allPlanHistoryListBindingSource;

        public PlanHistoryForm()
        {
            InitializeComponent();
            this.Size = new Size(1480,820);
            allPlanHistoryListBindingSource = new BindingSource();

            UpdatePlanListGridView();
        }
        private void UpdatePlanListGridView()
        {
            if (allPlanHistoryList != null)
            {
                allPlanHistoryList.Clear();
            }
            allPlanHistoryList = AllPlanView.GetAllPlanHistoryView();
            allPlanHistoryListBindingSource.DataSource = allPlanHistoryList;
            PlanHistoryDatagridview.DataSource = allPlanHistoryListBindingSource;

            FormatPlanHistoryDataGridView();
        }
        private void FormatPlanHistoryDataGridView()
        {
            if (PlanHistoryDatagridview.Columns["ID"] != null)
            {
                PlanHistoryDatagridview.Columns["ID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["EID"] != null)
            {
                PlanHistoryDatagridview.Columns["EID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["EName"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["EName"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (PlanHistoryDatagridview.Columns["ESerial"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["ESerial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
                customColumn.Width = 100;
            }
            if (PlanHistoryDatagridview.Columns["PType"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PType"];
                customColumn.HeaderText = "ประเภทแผน";
                customColumn.Width = 85;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (PlanHistoryDatagridview.Columns["PPeriod"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PPeriod"];
                customColumn.HeaderText = "รอบ";
                customColumn.Width = 70;
            }
            if (PlanHistoryDatagridview.Columns["DateTodo"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["DateTodo"];
                customColumn.HeaderText = "กำหนดการ";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (PlanHistoryDatagridview.Columns["PlanStatus"] != null)
            {
                PlanHistoryDatagridview.Columns["PlanStatus"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["PlanProcessDate"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PlanProcessDate"];
                customColumn.HeaderText = "ครั้งล่าสุด";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
            }
            if (PlanHistoryDatagridview.Columns["EPhoto"] != null)
            {
                PlanHistoryDatagridview.Columns["EPhoto"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["OPlacePhoto"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["OPlacePhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 35;
            }
            if (PlanHistoryDatagridview.Columns["OplaceDetails"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["OplaceDetails"];
                customColumn.HeaderText = "สถานที่ปฎิบัติงาน";
                customColumn.Width = 200;
            }
            if (PlanHistoryDatagridview.Columns["EStatus"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["EStatus"];
                customColumn.HeaderText = "สถานะอุปกรณ์ของแผน";
                customColumn.Width = 140;
            }
            if (PlanHistoryDatagridview.Columns["PPeriodID"] != null)
            {
                PlanHistoryDatagridview.Columns["PPeriodID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["EStatusID"] != null)
            {
                PlanHistoryDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["DaysRemainning"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["DaysRemainning"];
                customColumn.HeaderText = "เหลือวัน";
                customColumn.Width = 70;
            }
            if (PlanHistoryDatagridview.Columns["PlanStatusText"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PlanStatusText"];
                customColumn.HeaderText = "สถานะแผน";
                customColumn.Width = 80;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
        }
        //Event to pop-up plan progression
        private void PlanHistoryDatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.selectedEquipmentInPlan = null;
            DataGridViewRow selectedRow = PlanHistoryDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                AllPlanView selectedPlan = (AllPlanView)selectedRow.DataBoundItem;
                Global.selectedEquipmentInPlan = selectedPlan;
                planHistoryProgressForm = new PlanHistoryProgressForm();
                planHistoryProgressForm.Owner = main;
                planHistoryProgressForm.ShowDialog();
            }
        }

        private void PlanHistoryDatagridview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)PlanHistoryDatagridview.Rows[e.RowIndex].Cells["EStatusID"].Value;

            Global.SetRowColor(PlanHistoryDatagridview.Rows[e.RowIndex], statusID);
        }
    }
}
