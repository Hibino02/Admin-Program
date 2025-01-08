using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.PRManage
{
    public partial class CreatePRForm : Form
    {
        private List<int> supplierID = new List<int>();
        List<AllSupplierListDataDridView> supplierList;
        int selectedSupplierID;
        //Variable for selected supplier and showing quotationlist
        List<AllQuotationListDataGridView> quotationFilteredList;
        List<AllQuotationListDataGridView> quotationOriginalList = AllQuotationListDataGridView.AllQuotationFilteredByValidDate();
        BindingSource quotationBindingSource;
        string quotationPDF;
        int quotationID;
        //Variable for showing supply
        BindingSource supplyInQuotationBindingSource;
        List<AllSupplyInQuotationListDataGridView> supplyInQuotationViewList = AllSupplyInQuotationListDataGridView.allSupplyInQuotation();
        List<AllSupplyInQuotationListDataGridView> filteredList = new List<AllSupplyInQuotationListDataGridView>();
        //Variable for Current Quotation Selected Datagridview
        List<AllQuotationListDataGridView> currentSelectedQuotationList;
        BindingSource currentSelectedQuotationBindingSource;

        public CreatePRForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            otherReasontextBox.Enabled = false;

            supplierList = new List<AllSupplierListDataDridView>();
            quotationBindingSource = new BindingSource();
            currentSelectedQuotationBindingSource = new BindingSource();
            supplyInQuotationBindingSource = new BindingSource();

            UpdateComponents();
        }
        private void UpdateComponents()
        {
            supplierList = AllSupplierListDataDridView.AllSupplierFilteredByValidQuotation();
            supplierList.Sort((x, y) => x.SupplierName.CompareTo(y.SupplierName));
            suppliercomboBox.Items.Clear();
            supplierID.Clear();

            suppliercomboBox.Items.Add("------กรุณาเลือกซัพพลายเออร์------");
            supplierID.Add(-1);
            foreach (AllSupplierListDataDridView s in supplierList)
            {
                suppliercomboBox.Items.Add(s.SupplierName);
                supplierID.Add(s.ID);
            }
        }
        //Event to change other reason textbox
        private void othercheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (otherReasontextBox.Enabled)
            {
                otherReasontextBox.Enabled = false;
                otherReasontextBox.Clear();
            }
            else
            {
                otherReasontextBox.Enabled = true;
            }
        }
        //Event to update supplier's address and Quotation refer to combobox
        private void suppliercomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            quotationPDF = null;
            quotationPDFlinkLabel.LinkColor = System.Drawing.Color.Blue;
            supplyInQuotationBindingSource.DataSource = null;
            supplyInQuotationdataGridView.DataSource = supplyInQuotationBindingSource;
            if (suppliercomboBox.SelectedIndex > 0)
            {
                selectedSupplierID = supplierID[suppliercomboBox.SelectedIndex];

                AllSupplierListDataDridView selectedSupplier = supplierList.Find(s => s.ID == selectedSupplierID);

                if (selectedSupplier != null)
                {
                    supplierAddressrichTextBox.Text = selectedSupplier.SupplierAddress;
                    quotationFilteredList = quotationOriginalList
                        .Where(q =>
                        (q.SupplierID == selectedSupplierID)).ToList();
                    quotationBindingSource.DataSource = quotationFilteredList;
                    quotationDatagridview.DataSource = quotationBindingSource;
                    FormatQuotationForSelectedSupplier();
                }
            }
            else
            {
                supplierAddressrichTextBox.Clear();
                quotationBindingSource.DataSource = null;
                quotationDatagridview.DataSource = quotationBindingSource;
            }
        }
        private void FormatQuotationForSelectedSupplier()
        {
            var Columns = quotationDatagridview.Columns;
            if (Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["SupplierID"] != null)
            {
                Columns["SupplierID"].Visible = false;
            }
            if (Columns["QuotationNumber"] != null)
            {
                Columns["QuotationNumber"].HeaderText = "เลขที่ใบเสนอราคา";
                Columns["QuotationNumber"].Width = 168;
            }
            if (Columns["SupplierName"] != null)
            {
                Columns["SupplierName"].Visible = false;
            }
            if (Columns["IssueDate"] != null)
            {
                Columns["IssueDate"].HeaderText = "วันที่ออก";
                Columns["IssueDate"].Width = 82;
                Columns["IssueDate"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ValidDate"] != null)
            {
                Columns["ValidDate"].Visible = false;
            }
            if (Columns["ValidDateDisplay"] != null)
            {
                Columns["ValidDateDisplay"].HeaderText = "หมดอายุ";
                Columns["ValidDateDisplay"].Width = 115;
            }
            if (Columns["QuotationPDF"] != null)
            {
                Columns["QuotationPDF"].Visible = false;
            }
        }
        //Event to showing supply refer to clicking Quotation
        private void quotationDatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = quotationDatagridview.Rows[e.RowIndex];

                quotationID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                quotationPDF = selectedRow.Cells["QuotationPDF"].Value.ToString();
                UpdateSupplyInQuotationList(quotationID);
                // Update link label colors based on file existence
                if (!string.IsNullOrEmpty(quotationPDF))
                {
                    quotationPDFlinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
                else
                {
                    quotationPDFlinkLabel.LinkColor = System.Drawing.Color.Blue;
                }
            }
        }
        private void quotationPDFlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(quotationPDF))
            {
                GlobalVariable.Global.DownloadAndOpenPdf(quotationPDF);
            }
        }
        private void quotationDatagridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ensure there are rows to select
            if (quotationDatagridview.Rows.Count > 0)
            {
                quotationDatagridview.CurrentCell = quotationDatagridview.Rows[0].Cells[2];
                quotationDatagridview_CellClick(this, new DataGridViewCellEventArgs(0, 0));
            }
        }
        private void UpdateSupplyInQuotationList(int qid)
        {
            // Filter or fetch data for the selected quotation ID
            filteredList = supplyInQuotationViewList
                .Where(s => s.QuotationID == qid) // Filter by QuotationID
                .ToList();

            // Bind the filtered data to the second DataGridView
            supplyInQuotationBindingSource.DataSource = filteredList;
            supplyInQuotationdataGridView.DataSource = supplyInQuotationBindingSource;

            FormatSupplyInQuotationDataGridView();
        }
        private void FormatSupplyInQuotationDataGridView()
        {
            var Columns = supplyInQuotationdataGridView.Columns;
            if (Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["QuotationID"] != null)
            {
                Columns["QuotationID"].Visible = false;
            }
            if (Columns["SupplyID"] != null)
            {
                Columns["SupplyID"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัดดุ";
                Columns["SupplyName"].Width = 280;
            }
            if (Columns["Price"] != null)
            {
                Columns["Price"].HeaderText = "ราคา";
                Columns["Price"].Width = 100;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].HeaderText = "หน่วย";
                Columns["SupplyUnit"].Width = 100;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].HeaderText = "รูป";
                Columns["SupplyPhoto"].Width = 24;
            }
        }
        //Event to addSelectedQuotation to PR
        private void addQuotationbutton_Click(object sender, EventArgs e)
        {
            if (quotationFilteredList != null)
            {
                suppliercomboBox.Enabled = false;
                AllQuotationListDataGridView objToMove = quotationFilteredList.FirstOrDefault(q => q.ID == quotationID);

                if (objToMove != null)
                {
                    // Remove the object from the source list
                    quotationFilteredList.Remove(objToMove);

                    // Add the object to the destination list
                    currentSelectedQuotationList.Add(objToMove);
                    currentSelectedQuotationBindingSource.DataSource = currentSelectedQuotationList;
                    currentSelectedQuotationdataGridView.DataSource = currentSelectedQuotationBindingSource;
                    FormatCurrentSelectedQuotation();
                }
            }      
        }
        private void FormatCurrentSelectedQuotation()
        {
            var Columns = currentSelectedQuotationdataGridView.Columns;
            if (Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["SupplierID"] != null)
            {
                Columns["SupplierID"].Visible = false;
            }
            if (Columns["QuotationNumber"] != null)
            {
                Columns["QuotationNumber"].HeaderText = "เลขที่ใบเสนอราคา";
                Columns["QuotationNumber"].Width = 168;
            }
            if (Columns["SupplierName"] != null)
            {
                Columns["SupplierName"].Visible = false;
            }
            if (Columns["IssueDate"] != null)
            {
                Columns["IssueDate"].HeaderText = "วันที่ออก";
                Columns["IssueDate"].Width = 82;
                Columns["IssueDate"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ValidDate"] != null)
            {
                Columns["ValidDate"].Visible = false;
            }
            if (Columns["ValidDateDisplay"] != null)
            {
                Columns["ValidDateDisplay"].HeaderText = "หมดอายุ";
                Columns["ValidDateDisplay"].Width = 115;
            }
            if (Columns["QuotationPDF"] != null)
            {
                Columns["QuotationPDF"].Visible = false;
            }
        }
    }
}
