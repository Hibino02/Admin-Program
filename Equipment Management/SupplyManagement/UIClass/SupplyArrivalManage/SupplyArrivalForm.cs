using Admin_Program.SupplyManagement.CustomViewClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyArrivalManage
{
    public partial class SupplyArrivalForm : Form
    {
        List<AllSupplyInPRArrivalListDataGridView> supplyInPRArrivalLst = AllSupplyInPRArrivalListDataGridView.SupplyArrivalPlanBySupplyID(GlobalVariable.Global.PRID);
        BindingSource supplyInPRArrivalLstBindingSource;
        public SupplyArrivalForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            supplyInPRArrivalLstBindingSource = new BindingSource();

            UpdateSupplyInPlanDatagridView();
        }
        private void UpdateSupplyInPlanDatagridView()
        {
            supplyInPRArrivalLstBindingSource.DataSource = supplyInPRArrivalLst;
            supplyInPRArrivalLstdataGridView.DataSource = supplyInPRArrivalLstBindingSource;
            FormatSupplyInPlanDatagridView();
        }
        private void FormatSupplyInPlanDatagridView()
        {
            var Columns = supplyInPRArrivalLstdataGridView.Columns;
            if(Columns["SupplyID"] != null)
            {
                Columns["SupplyID"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ขื่อวัสดุ";
                Columns["SupplyName"].Width = 500;
            }
            if(Columns["ReqW1"] != null)
            {
                Columns["ReqW1"].HeaderText = "สัปดาห์ที่ 1";
                Columns["ReqW1"].Width = 65;
            }
            if (Columns["ReqW2"] != null)
            {
                Columns["ReqW2"].HeaderText = "สัปดาห์ที่ 2";
                Columns["ReqW2"].Width = 65;
            }
            if (Columns["ReqW3"] != null)
            {
                Columns["ReqW3"].HeaderText = "สัปดาห์ที่ 3";
                Columns["ReqW3"].Width = 65;
            }
            if (Columns["ReqW4"] != null)
            {
                Columns["ReqW4"].HeaderText = "สัปดาห์ที่ 4";
                Columns["ReqW4"].Width = 65;
            }
            if (Columns["ArrW1"] != null)
            {
                Columns["ArrW1"].HeaderText = "ส่งจริง";
                Columns["ArrW1"].Width = 40;
            }
            if (Columns["ArrW2"] != null)
            {
                Columns["ArrW2"].HeaderText = "ส่งจริง";
                Columns["ArrW2"].Width = 40;
            }
            if (Columns["ArrW3"] != null)
            {
                Columns["ArrW3"].HeaderText = "ส่งจริง";
                Columns["ArrW3"].Width = 40;
            }
            if (Columns["ArrW4"] != null)
            {
                Columns["ArrW4"].HeaderText = "ส่งจริง";
                Columns["ArrW4"].Width = 40;
            }
            if (Columns["ArrDate1"] != null)
            {
                Columns["ArrDate1"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate1"].Width = 80;
                Columns["ArrDate1"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ArrDate2"] != null)
            {
                Columns["ArrDate2"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate2"].Width = 80;
                Columns["ArrDate2"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ArrDate3"] != null)
            {
                Columns["ArrDate3"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate3"].Width = 80;
                Columns["ArrDate3"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ArrDate4"] != null)
            {
                Columns["ArrDate4"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate4"].Width = 80;
                Columns["ArrDate4"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ReqAmount"] != null)
            {
                Columns["ReqAmount"].HeaderText = "เรียกสุทธิ";
                Columns["ReqAmount"].Width = 60;
            }
            if (Columns["ArrAmount"] != null)
            {
                Columns["ArrAmount"].HeaderText = "ส่งสุทธิ";
                Columns["ArrAmount"].Width = 60;
            }
        }

        private void supplyInPRArrivalLstdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            supplyInPRArrivalLstdataGridView.ClearSelection();
        }
    }
}
