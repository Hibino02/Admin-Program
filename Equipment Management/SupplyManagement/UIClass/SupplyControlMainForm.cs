using Admin_Program.SupplyManagement.UIClass.SupplierManage;
using Admin_Program.SupplyManagement.UIClass.SupplyManage;
using Admin_Program.SupplyManagement.UIClass.QuotationManage;
using Admin_Program.UIClass;
using System;
using System.Drawing;
using System.Windows.Forms;
using Admin_Program.SupplyManagement.UIClass.PRManage;

namespace Admin_Program.SupplyManagement.UIClass
{
    public partial class SupplyControlMainForm : Form
    {
        MainBackGroundFrom main;

        private AllSupplyListForm allSupplyList;
        private AllSupplierListForm allSupplierList;
        private AllQuotationListForm allQuotationList;
        private CreatePRForm createPR;

        public event EventHandler returnMain;

        public SupplyControlMainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(1450, 760);
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
        }
        //To Main Menu
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
