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

namespace Admin_Program.SupplyManagement.UIClass
{
    public partial class SupplyControlMainForm : Form
    {
        MainBackGroundFrom main;

        private AllSupplyListForm allSupplyList;
        private AllSupplierListForm allSupplierList;
        private AllQuotationListForm allQuotationList;
        private CreatePRForm createPR;

        List<AllPRListDataGridView> allPRlistInDataGridView = new List<AllPRListDataGridView>();
        BindingSource PRBindingSource = new BindingSource();
        List<AllSupplyInPRListDataGridView> allSupplyInPRList = new List<AllSupplyInPRListDataGridView>();
        List<AllSupplyInPRListDataGridView> supplyInSelectedPRList = new List<AllSupplyInPRListDataGridView>();
        BindingSource supplyInPRBindingSource = new BindingSource();

        public event EventHandler returnMain;

        public SupplyControlMainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(1450, 760);

            allSupplyInPRList = AllSupplyInPRListDataGridView.AllSupplyInActivePR();

            UpdatePRDatagridView();
        }
        //PR DataGrid
        private void UpdatePRDatagridView()
        {
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

                int PRID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                UpdateSupplyInPRList(PRID);
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
                Columns["SupplyName"].Width = 300;
            }
            if (Columns["Quantity"] != null)
            {
                Columns["Quantity"].HeaderText = "จำนวน";
                Columns["Quantity"].Width = 50;
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
        //To Main Menu
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
