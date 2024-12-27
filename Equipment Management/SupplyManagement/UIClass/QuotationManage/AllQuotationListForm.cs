using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using Admin_Program.GlobalVariable;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Admin_Program.SupplyManagement.CustomViewClass;
using Library.Forms;

namespace Admin_Program.SupplyManagement.UIClass.QuotationManage
{
    public partial class AllQuotationListForm : Form
    {
        MainBackGroundFrom main;

        private List<int> supplierID = new List<int>();
        List<Supplier> supplierList;

        BindingSource quotationBindingSource;
        List<AllQuotationListDataGridView> quotationViewList;
        //Filter algorithm variable
        private List<AllQuotationListDataGridView> originalList;
        List<AllQuotationListDataGridView> quotationFilteredList;
        private int currentFilterID = -1;
        public AllQuotationListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            quotationViewList = new List<AllQuotationListDataGridView>();
            supplierList = new List<Supplier>();

            quotationBindingSource = new BindingSource();

            UpdateComponents();
        }
        private void UpdateComponents()
        {
            supplierList = Supplier.GetAllSupplierList();
            supplierList.Sort((x, y) => x.Name.CompareTo(y.Name));
            supplierComboBox.Items.Clear();
            supplierID.Clear();

            supplierComboBox.Items.Add("------กรุณาเลือกซัพพลายเออร์------");
            supplierID.Add(-1);
            foreach (Supplier s in supplierList)
            {
                supplierComboBox.Items.Add(s.Name);
                supplierID.Add(s.ID);
            }
        }
        private void UpdateQuotationList()
        {
            quotationViewList = AllQuotationListDataGridView.AllQuotation();
            originalList = new List<AllQuotationListDataGridView>(quotationViewList);
            ApplyCurrentFilter();
        }
        private void ApplyCurrentFilter()
        {

        }
    }
}
