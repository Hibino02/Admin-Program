using Admin_Program.SupplyManagement.UIClass.SupplierManage;
using Admin_Program.SupplyManagement.UIClass.SupplyManage;
using Admin_Program.SupplyManagement.UIClass.QuotationManage;
using Admin_Program.UIClass;
using System;
using System.Drawing;
using System.Windows.Forms;
using Admin_Program.SupplyManagement.UIClass.PRManage;
using System.Collections.Generic;
using Admin_Program.SupplyManagement.CustomViewClass;
using System.Linq;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.SupplyManagement.UIClass.SupplyDeliveryPlan;
using Admin_Program.SupplyManagement.UIClass.SupplyBalanceManage;

namespace Admin_Program.SupplyManagement.UIClass
{
    public partial class SupplyControlMainForm : Form
    {
        MainBackGroundFrom main;

        private AllSupplyListForm allSupplyList;
        private AllSupplierListForm allSupplierList;
        private AllQuotationListForm allQuotationList;
        private CreatePRForm createPR;
        private AllSupplyDiliveryListForm supplyDeliveryPlan;
        private SupplyBalanceUpdateForm supplyBalanceUpdate;
        private SupplyBalanceEditForm supplyBalanceEdit;

        //PR Variables
        List<AllPRListDataGridView> allPRlistInDataGridView = new List<AllPRListDataGridView>();
        BindingSource PRBindingSource = new BindingSource();
        int prStatusID;
        int PRID;
        string quotationInSupply;
        List<AllSupplyInPRListDataGridView> allSupplyInPRList = new List<AllSupplyInPRListDataGridView>();
        List<AllSupplyInPRListDataGridView> supplyInSelectedPRList = new List<AllSupplyInPRListDataGridView>();
        BindingSource supplyInPRBindingSource = new BindingSource();

        //Balance Variables
        List<AllSupplyInventoryDatagridView> supplyBalanceAsUserGruop = new List<AllSupplyInventoryDatagridView>();
        BindingSource supplyBalanceAsUserGruopBindingSource = new BindingSource();

        public event EventHandler returnMain;

        public SupplyControlMainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(1450, 760);

            UpdatePRDatagridView();
            UpdateSupplyBalanceDatafridView();
        }
        //PR DataGrid
        private void UpdatePRDatagridView()
        {
            allSupplyInPRList = AllSupplyInPRListDataGridView.AllSupplyInActivePR();
            allPRlistInDataGridView = AllPRListDataGridView.AllPRInDataGridView();
            PRBindingSource.DataSource = allPRlistInDataGridView;
            supplyRequestDataGridView.DataSource = PRBindingSource;
            FormatPRDataDridView();
        }
        private void FormatPRDataDridView()
        {
            var Columns = supplyRequestDataGridView.Columns;
            if(Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["PRTitle"] != null)
            {
                Columns["PRTitle"].HeaderText = "หัวข้อคำสั่งซื้อ";
                Columns["PRTitle"].Width = 189;
            }
            if (Columns["DeliveryDate"] != null)
            {
                Columns["DeliveryDate"].HeaderText = "วันจัดส่ง";
                Columns["DeliveryDate"].Width = 70;
                Columns["DeliveryDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }
            if (Columns["PRStatus"] != null)
            {
                Columns["PRStatus"].HeaderText = "สถานะ";
                Columns["PRStatus"].Width = 75;
            }
            if (Columns["PRStatusID"] != null)
            {
                Columns["PRStatusID"].Visible = false;
            }
        }
        private void searchSupplyRequestTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchSupplyRequestTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                UpdatePRDatagridView();
            }
            else
            {
                var searchResults = allPRlistInDataGridView
                    .Where(pr =>
                    pr.PRTitle.ToLower().Contains(searchText) ||
                    pr.PRStatus.ToLower().Contains(searchText)).ToList();

                PRBindingSource.DataSource = searchResults;
                supplyRequestDataGridView.DataSource = PRBindingSource;
            }
        }
        private void supplyRequestDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = supplyRequestDataGridView.Rows[e.RowIndex];

                PRID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                prStatusID = Convert.ToInt32(selectedRow.Cells["PRStatusID"].Value);
                UpdateSupplyInPRList(PRID);
            }
        }
        private void supplyRequestDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(supplyRequestDataGridView.Rows.Count > 0)
            {
                supplyRequestDataGridView.CurrentCell = supplyRequestDataGridView.Rows[0].Cells[1];
                supplyRequestDataGridView_CellClick(this,new DataGridViewCellEventArgs(0,0));
            }
        }
        //Supply In PR DataGrid
        private void UpdateSupplyInPRList(int id)
        {
            supplyInSelectedPRList = allSupplyInPRList
                .Where(s => s.PRID == id).ToList();

            supplyInPRBindingSource.DataSource = supplyInSelectedPRList;
            supplyInSelectedPRdataGridView.DataSource = supplyInPRBindingSource;

            FormatSelectedSupplyInPRDataGridView();
        }
        private void FormatSelectedSupplyInPRDataGridView()
        {
            var Columns = supplyInSelectedPRdataGridView.Columns;
            if(Columns["PRID"] != null)
            {
                Columns["PRID"].Visible = false;
            }
            if(Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัสดุ";
                Columns["SupplyName"].Width = 270;
            }
            if (Columns["Price"] != null)
            {
                Columns["Price"].Visible = false;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].Visible = false;
            }
            if (Columns["Quantity"] != null)
            {
                Columns["Quantity"].HeaderText = "จำนวน";
                Columns["Quantity"].Width = 80;

                supplyInSelectedPRdataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["Quantity"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInSelectedPRdataGridView.Rows[e.RowIndex].Cells["Quantity"]?.Value?.ToString();
                        string supplyUnit = supplyInSelectedPRdataGridView.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if(!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(supplyUnit))
                        {
                            e.Value = $"{quantity} {supplyUnit}";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["Amount"] != null)
            {
                Columns["Amount"].Visible = false;
            }
            if (Columns["QuotationNumber"] != null)
            {
                Columns["QuotationNumber"].Visible = false;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].Visible = false;
            }
            if (Columns["QuotationPDF"] != null)
            {
                Columns["QuotationPDF"].Visible = false;
            }
            if (Columns["QuotationID"] != null)
            {
                Columns["QuotationID"].Visible = false;
            }
            if (Columns["SupplyID"] != null)
            {
                Columns["SupplyID"].Visible = false;
            }
        }

        //Supply Balance
        private void UpdateSupplyBalanceDatafridView()
        {
            supplyBalanceAsUserGruop = AllSupplyInventoryDatagridView.AllSupplyBalance();
            supplyBalanceAsUserGruopBindingSource.DataSource = supplyBalanceAsUserGruop;
            supplyBalanceDatagridview.DataSource = supplyBalanceAsUserGruopBindingSource;
            FormatSupplyBalancedataGridView();
        }
        private void FormatSupplyBalancedataGridView()
        {
            var Columns = supplyBalanceDatagridview.Columns;
            if (Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["SupplyID"] != null)
            {
                Columns["SupplyID"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัสดุ";
                Columns["SupplyName"].Width = 395;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].Visible = false;
            }
            if (Columns["Balance"] != null)
            {
                Columns["Balance"].HeaderText = "จำนวนปัจจุบัน";
                Columns["Balance"].Width = 80;

                supplyBalanceDatagridview.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["Balance"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyBalanceDatagridview.Rows[e.RowIndex].Cells["Balance"]?.Value?.ToString();
                        string supplyUnit = supplyBalanceDatagridview.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(supplyUnit))
                        {
                            e.Value = $"{quantity} {supplyUnit}";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["UpdateDate"] != null)
            {
                Columns["UpdateDate"].HeaderText = "วันที่อัฟเดท";
                Columns["UpdateDate"].Width = 93;
                Columns["UpdateDate"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["Updater"] != null)
            {
                Columns["Updater"].HeaderText = "ผู้บันทึก";
                Columns["Updater"].Width = 80;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].HeaderText = "รูป";
                Columns["SupplyPhoto"].Width = 40;
            }
        }
        private void searchSupplyBalanceTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchSupplyBalanceTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                UpdateSupplyBalanceDatafridView();
            }
            else
            {
                var searchResult = supplyBalanceAsUserGruop
                    .Where(sb =>
                    sb.SupplyName.ToLower().Contains(searchText)).ToList();

                supplyBalanceAsUserGruopBindingSource.DataSource = searchResult;
                supplyBalanceDatagridview.DataSource = supplyBalanceAsUserGruopBindingSource;
            }
        }

        //Supply Balance Update
        private void updateSupplyButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = supplyBalanceDatagridview.CurrentRow;

            if(selectedRow != null)
            {
                GlobalVariable.Global.ID = -1;
                GlobalVariable.Global.ID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                supplyBalanceUpdate = new SupplyBalanceUpdateForm();
                supplyBalanceUpdate.Owner = main;
                supplyBalanceUpdate.ShowDialog();
                UpdateSupplyBalanceDatafridView();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการวัสดุ");
            }
        }
        //Supply Balance Edit
        private void editSupplyButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = supplyBalanceDatagridview.CurrentRow;

            if(selectedRow != null)
            {
                GlobalVariable.Global.ID = -1;
                GlobalVariable.Global.ID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                supplyBalanceEdit = new SupplyBalanceEditForm();
                supplyBalanceEdit.Owner = main;
                supplyBalanceEdit.ShowDialog();
                UpdateSupplyBalanceDatafridView();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการวัสดุ");
            }
        }
        //Supply Manage
        private void manageSupplyButton_Click(object sender, EventArgs e)
        {
            allSupplyList = new AllSupplyListForm();
            allSupplyList.Owner = main;
            allSupplyList.ShowDialog();
        }
        //Supplier Manage
        private void manageSupplierButton_Click(object sender, EventArgs e)
        {
            allSupplierList = new AllSupplierListForm();
            allSupplierList.Owner = main;
            allSupplierList.ShowDialog();
        }
        //Quotation Manage
        private void manageQuotationButton_Click(object sender, EventArgs e)
        {
            allQuotationList = new AllQuotationListForm();
            allQuotationList.Owner = main;
            allQuotationList.ShowDialog();
        }
        //Create PR
        private void openPRButton_Click(object sender, EventArgs e)
        {
            createPR = new CreatePRForm();
            createPR.Owner = main;
            createPR.ShowDialog();
            UpdatePRDatagridView();
        }
        //Remove PR
        private void removePRButton_Click(object sender, EventArgs e)
        {
            if (prStatusID > 1)
            {
                MessageBox.Show("คำขอซื้อนี้ กำลังดำเนินการ จึงไม่สามารถลบได้");
            }
            else
            {
                List<SupplyInPR> sipr = SupplyInPR.GetAllSupplyInPRList(PRID);
                foreach (SupplyInPR s in sipr)
                {
                    if(s.QuotationPDF != quotationInSupply)
                    {
                        quotationInSupply = s.QuotationPDF;
                        if (!string.IsNullOrEmpty(s.QuotationPDF))
                        {
                            GlobalVariable.Global.DeleteFileFromFtpSupply(s.QuotationPDF);
                        }
                        else
                        {
                            MessageBox.Show("การลบไฟล์อ้างอิง ใบเสนอราคา ของวัสดุเกิดข้อผิดพลาด");
                        }
                    }
                }
                if (SupplyInPR.Remove(PRID))
                {
                    MessageBox.Show("ลบวัสดุของ PR สมบูรณ์");
                    PR pr = new PR(PRID);
                    if (pr.Remove())
                    {
                        MessageBox.Show("ลบ PR สมบูรณ์");
                        supplyInSelectedPRdataGridView.DataSource = null;
                        UpdatePRDatagridView();
                    }
                }
            }
        }
        //Supply Dilivery Plan
        private void supplyPlanButton_Click(object sender, EventArgs e)
        {
            supplyDeliveryPlan = new AllSupplyDiliveryListForm();
            supplyDeliveryPlan.Owner = main;
            supplyDeliveryPlan.ShowDialog();
        }
        //To Main Menu
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}