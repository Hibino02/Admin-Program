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
        CreateQuotationForm createQuotation;
        EditQuotationForm editQuotation;

        private string quotationPDF;

        private PictureBox supplyInQuotationPictureBox;

        private List<int> supplierID = new List<int>();
        List<Supplier> supplierList;

        BindingSource quotationBindingSource;
        List<AllQuotationListDataGridView> quotationViewList;

        BindingSource supplyInQuotationBindingSource;
        List<AllSupplyInQuotationListDataGridView> supplyInQuotationViewList = new List<AllSupplyInQuotationListDataGridView>();

        List<AllSupplyInQuotationListDataGridView> filteredList = new List<AllSupplyInQuotationListDataGridView>();
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
            //Get all SupplyInQuotation
            supplyInQuotationViewList = AllSupplyInQuotationListDataGridView.allSupplyInQuotation();

            quotationBindingSource = new BindingSource();
            supplyInQuotationBindingSource = new BindingSource();

            //Create hidden picturebox
            supplyInQuotationPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(supplyInQuotationPictureBox);
            supplyInQuotationdataGridView.CellMouseEnter += supplyInQuotationdataGridView_CellMouseEnter;
            supplyInQuotationdataGridView.CellMouseLeave += supplyInQuotationdataGridView_CellMouseLeave;

            UpdateComponents();
            UpdateQuotationList();
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
        private void UpdateQuotationList()
        {
            quotationViewList = AllQuotationListDataGridView.AllQuotation();
            originalList = new List<AllQuotationListDataGridView>(quotationViewList);
            ApplyCurrentFilter();
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
        private void ApplyCurrentFilter()
        {
            int selectSupplierID = supplierComboBox.SelectedIndex > 0 ? supplierID[supplierComboBox.SelectedIndex] : -1;

            quotationFilteredList = originalList
            .Where(q =>
            (selectSupplierID < 0 || q.SupplierID == selectSupplierID)).ToList();

            SortableBindingList<AllQuotationListDataGridView> sortableList = new SortableBindingList<AllQuotationListDataGridView>(quotationFilteredList);
            quotationBindingSource.DataSource = sortableList;
            quotationDatagridview.DataSource = quotationBindingSource;

            FormatDataDirdView();
        }
        private void FormatDataDirdView()
        {
            var Columns = quotationDatagridview.Columns;
            if(Columns["ID"] != null)
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
                Columns["QuotationNumber"].Width = 200;
                Columns["QuotationNumber"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (Columns["SupplierName"] != null)
            {
                Columns["SupplierName"].HeaderText = "ชื่อซัพพลายเออร์";
                Columns["SupplierName"].Width = 300;
                Columns["SupplierName"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (Columns["IssueDate"] != null)
            {
                Columns["IssueDate"].HeaderText = "วันที่ออกเอกสาร";
                Columns["IssueDate"].Width = 150;
                Columns["IssueDate"].DefaultCellStyle.Format = "MMM dd, yyy";
                Columns["IssueDate"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (Columns["ValidDate"] != null)
            {
                Columns["ValidDate"].Visible = false;
            }
            if (Columns["ValidDateDisplay"] != null)
            {
                Columns["ValidDateDisplay"].HeaderText = "วันที่หมดอายุ";
                Columns["ValidDateDisplay"].Width = 150;
                Columns["ValidDateDisplay"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            if (Columns["QuotationPDF"] != null)
            {
                Columns["QuotationPDF"].Visible = false;
            }
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
        //Event to filter supplier
        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectIndex = supplierComboBox.SelectedIndex;
            currentFilterID = selectIndex >= 0 ? supplierID[selectIndex] : -1;

            ApplyCurrentFilter();
        }
        //Event to search quotation with text
        private void searchQuotationTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = searchQuotationTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentFilter();
            }
            else
            {
                var searchResult = quotationFilteredList.Where(q =>
                q.QuotationNumber.ToLower().Contains(searchText) ||
                q.SupplierName.ToLower().Contains(searchText)).ToList();

                quotationBindingSource.DataSource = searchResult;
                quotationDatagridview.DataSource = quotationBindingSource;
            }
        }
        //Automatically select first row
        private void quotationDatagridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ensure there are rows to select
            if (quotationDatagridview.Rows.Count > 0)
            {
                quotationDatagridview.CurrentCell = quotationDatagridview.Rows[0].Cells[2];
                quotationDatagridview_CellClick(this, new DataGridViewCellEventArgs(0,0));
            }
        }
        //Showing quotation contents on clicking cell event
        private void quotationDatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = quotationDatagridview.Rows[e.RowIndex];

                int quotationID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
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
        //Open Quotation PDF
        private void quotationPDFlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(quotationPDF))
            {
                Global.DownloadAndOpenPdf(quotationPDF);
            }
            else
            {
                MessageBox.Show("ไม่มีไฟล์บันทึก");
            }
        }
        //Event to show supply picturebox
        private void supplyInQuotationdataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string columnName = supplyInQuotationdataGridView.Columns[e.ColumnIndex].Name;
                if(columnName == "SupplyPhoto")
                {
                    string imagePath = supplyInQuotationdataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, supplyInQuotationPictureBox);
                    supplyInQuotationPictureBox.Visible = true;
                    supplyInQuotationPictureBox.BringToFront();
                }
            }
        }
        private void supplyInQuotationdataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            supplyInQuotationPictureBox.Visible = false;
        }
        //Create quotation
        private void CreateButton_Click(object sender, EventArgs e)
        {
            createQuotation = new CreateQuotationForm();
            createQuotation.Owner = main;
            createQuotation.ShowDialog();
            UpdateQuotationList();
            supplyInQuotationViewList = AllSupplyInQuotationListDataGridView.allSupplyInQuotation();
        }
        //Edit quotation
        private void EditButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = quotationDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                editQuotation = new EditQuotationForm();
                editQuotation.Owner = main;
                editQuotation.ShowDialog();
                UpdateQuotationList();
                supplyInQuotationViewList = AllSupplyInQuotationListDataGridView.allSupplyInQuotation();
            }
        }
        //Remove quotation and supply
        private void RemoveButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = quotationDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                DialogResult result = MessageBox.Show("คุณแน่ใจหรือไม่ว่าต้องการลบรายการนี้", "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    int id = (int)selectedRow.Cells["ID"].Value;
                    Quotation q = new Quotation(id);
                    if (SupplyInQuotation.Remove(id))
                    {
                        MessageBox.Show("ลบรายการวัสดุทั้งหมด ในใบเสนอราคา");
                        if (!string.IsNullOrEmpty(q.QuotationPDF))
                        {
                            Global.DeleteFileFromFtpSupply(q.QuotationPDF);
                        }
                        q.Remove();
                        MessageBox.Show("ลบใบเสนอราคา สมบูรณ์");
                        UpdateQuotationList();
                        supplyInQuotationViewList = AllSupplyInQuotationListDataGridView.allSupplyInQuotation();
                    }          
                }
            }
        }
    }
}
