using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.SupplyManagement.UIClass.SupplierManage;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.QuotationManage
{
    public partial class CreateQuotationForm : Form
    {
        MainBackGroundFrom main;
        AllSupplierListForm manageSupplier;
        //Attribute for create Quotation
        Supplier supplier;
        DateTime? validDate;

        List<Supplier> supplierList;
        private List<int> supplierIDList = new List<int>();
        List<SupplyType> supplyTypeList;
        private List<int> supplyTypeIDList = new List<int>();

        //PictureBox
        private PictureBox supplyPictureBox;
        private PictureBox selectedSupplyPictureBox;

        string quotationPDF;
        //Supply
        BindingSource supplyBindingSource;
        List<AllSupplyListDataGridView> supplyViewList;
        //Selected supply
        BindingSource selectedSupplyBindingSource;
        List<AllSupplyInQuotationListDataGridView> selectedSupplyViewList;
        //Filter algorithm
        List<AllSupplyListDataGridView> originalSupplyViewList;
        List<AllSupplyListDataGridView> supplyTypeFilteredList;
        int currentSupplyTypeFilterID = -1;

        public CreateQuotationForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            supplyViewList = new List<AllSupplyListDataGridView>();
            supplyBindingSource = new BindingSource();

            selectedSupplyViewList = new List<AllSupplyInQuotationListDataGridView>();
            selectedSupplyBindingSource = new BindingSource();

            //Create hidden picturebox
            supplyPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(750, 0)
            };
            this.Controls.Add(supplyPictureBox);
            supplyDatagridview.CellMouseEnter += supplyDatagridview_CellMouseEnter;
            supplyDatagridview.CellMouseLeave += supplyDatagridview_CellMouseLeave;

            selectedSupplyPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(selectedSupplyPictureBox);
            supplyInQuotationdataGridView.CellMouseEnter += supplyInQuotationdataGridView_CellMouseEnter;
            supplyInQuotationdataGridView.CellMouseLeave += supplyInQuotationdataGridView_CellMouseLeave;

            hasValidDatecheckBox.CheckedChanged += hasValidDatecheckBox_CheckedChanged;

            UpdateComponents();
            UpdateSupplyList();
        }

        private void UpdateComponents()
        {
            supplierList = Supplier.GetAllSupplierList();
            supplierList.Sort((x, y) => x.Name.CompareTo(y.Name));
            supplierComboBox.Items.Clear();
            supplierIDList.Clear();
            foreach(Supplier s in supplierList)
            {
                supplierComboBox.Items.Add(s.Name);
                supplierIDList.Add(s.ID);
            }

            supplyTypeList = SupplyType.GetAllSupplyTypeList();
            supplyTypeList.Sort((x, y) => x.TypeName.CompareTo(y.TypeName));
            supplyTypecomboBox.Items.Clear();
            supplyTypeIDList.Clear();
            supplyTypecomboBox.Items.Add("------กรุณาเลือกประเภทวัสดุ------");
            supplyTypeIDList.Add(-1);
            foreach (SupplyType st in supplyTypeList)
            {
                supplyTypecomboBox.Items.Add(st.TypeName);
                supplyTypeIDList.Add(st.ID);
            }
        }
        //Event to update supplier address refer to supplier combobox
        private void supplierComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (supplierComboBox.SelectedIndex >= 0)
            {
                // Get the selected supplier's ID
                int selectedSupplierID = supplierIDList[supplierComboBox.SelectedIndex];

                // Find the supplier object
                Supplier selectedSupplier = supplierList.Find(s => s.ID == selectedSupplierID);

                // Display the supplier's address in the RichTextBox
                if (selectedSupplier != null)
                {
                    supplierAddressrichTextBox.Text = selectedSupplier.Address;
                }
            }
            else
            {
                // Clear the RichTextBox if no item is selected
                supplierAddressrichTextBox.Clear();
            }
        }
        //Supply mechanic in datagridview
        private void UpdateSupplyList()
        {
            supplyViewList = AllSupplyListDataGridView.AllSupply();
            originalSupplyViewList = new List<AllSupplyListDataGridView>(supplyViewList);
            ApplyCurrentSupplyFilter();
        }
        private void ApplyCurrentSupplyFilter()
        {
            int selectSupplyTypeID = supplyTypecomboBox.SelectedIndex > 0 ? supplyTypeIDList[supplyTypecomboBox.SelectedIndex] : -1;

            supplyTypeFilteredList = originalSupplyViewList
            .Where(s =>
            (selectSupplyTypeID < 0 || s.SupplyTypeID == selectSupplyTypeID))
            .ToList();

            supplyBindingSource.DataSource = supplyTypeFilteredList;
            supplyDatagridview.DataSource = supplyBindingSource;

            FormatSupplyDataGridView();
        }
        private void FormatSupplyDataGridView()
        {
            if(supplyDatagridview.Columns["ID"] != null)
            {
                supplyDatagridview.Columns["ID"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyName"] != null)
            {
                var customColumn = supplyDatagridview.Columns["SupplyName"];
                customColumn.HeaderText = "ชื่อวัสดุ";
                customColumn.Width = 500;
            }
            if (supplyDatagridview.Columns["SupplyUnit"] != null)
            {
                var customColumn = supplyDatagridview.Columns["SupplyUnit"];
                customColumn.HeaderText = "หน่วย";
                customColumn.Width = 55;
            }
            if (supplyDatagridview.Columns["MOQ"] != null)
            {
                supplyDatagridview.Columns["MOQ"].Visible = false;
            }
            if (supplyDatagridview.Columns["IsActive"] != null)
            {
                supplyDatagridview.Columns["IsActive"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyTypeID"] != null)
            {
                supplyDatagridview.Columns["SupplyTypeID"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyTypeName"] != null)
            {
                supplyDatagridview.Columns["SupplyTypeName"].Visible = false;
            }
            if (supplyDatagridview.Columns["SupplyPhoto"] != null)
            {
                var customColumn = supplyDatagridview.Columns["SupplyPhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 50;
            }
        }
        private void supplyTypecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = supplyTypecomboBox.SelectedIndex;
            currentSupplyTypeFilterID = selectTypeIndex >= 0 ? supplyTypeIDList[selectTypeIndex] : -1;

            ApplyCurrentSupplyFilter();
        }
        private void supplySearchtextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = supplySearchtextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentSupplyFilter();
            }
            else
            {
                var searchResults = supplyTypeFilteredList
                .Where(s =>
                s.SupplyName.ToLower().Contains(searchText) ||
                s.SupplyTypeName.ToLower().Contains(searchText)).ToList();

                supplyBindingSource.DataSource = searchResults;
                supplyDatagridview.DataSource = supplyBindingSource;
            }
        }
        //Selected supply mechanic
        private void UpdateSelectedSupplyList()
        {
            supplyInQuotationdataGridView.DataSource = null;
            selectedSupplyBindingSource.DataSource = selectedSupplyViewList;
            supplyInQuotationdataGridView.DataSource = selectedSupplyBindingSource;

            FormatSelectedSupplydataGridView();
        }
        private void FormatSelectedSupplydataGridView()
        {
            if (supplyInQuotationdataGridView.Columns["ID"] != null)
            {
                supplyInQuotationdataGridView.Columns["ID"].Visible = false;
            }
            if (supplyInQuotationdataGridView.Columns["QuotationID"] != null)
            {
                supplyInQuotationdataGridView.Columns["QuotationID"].Visible = false;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyID"] != null)
            {
                supplyInQuotationdataGridView.Columns["SupplyID"].Visible = false;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyName"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["SupplyName"];
                customColumn.HeaderText = "ชื่อวัสดุ";
                customColumn.Width = 500;
            }
            if (supplyInQuotationdataGridView.Columns["Price"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["Price"];
                customColumn.HeaderText = "ราคา/";
                customColumn.Width = 130;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyUnit"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["SupplyUnit"];
                customColumn.HeaderText = "หน่วย";
                customColumn.Width = 130;
            }
            if (supplyInQuotationdataGridView.Columns["SupplyPhoto"] != null)
            {
                var customColumn = supplyInQuotationdataGridView.Columns["SupplyPhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 50;
            }
        }
        //Automatically select first row
        private void supplyInQuotationdataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (supplyInQuotationdataGridView.Rows.Count > 0)
            {
                supplyInQuotationdataGridView.CurrentCell = supplyInQuotationdataGridView.Rows[0].Cells[3];
            }
        }
        //Event to add suppy to Quotation
        private void addSupplybutton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = supplyDatagridview.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวในตาราง");
                return;
            }

            float price;
            if (!float.TryParse(supplyPricetextBox.Text, out price))
            {
                MessageBox.Show("กรุณาระบุราคาให้ถูกต้อง");
                return;
            }

            int supplyID = (int)selectedRow.Cells["ID"].Value;
            string supplyName = selectedRow.Cells["SupplyName"].Value?.ToString() ?? string.Empty;
            string supplyUnit = selectedRow.Cells["SupplyUnit"].Value?.ToString() ?? string.Empty;
            string supplyPhoto = selectedRow.Cells["SupplyPhoto"].Value?.ToString() ?? string.Empty;

            AllSupplyInQuotationListDataGridView selectedSupplyToShow = new AllSupplyInQuotationListDataGridView(
                supplyID, supplyName, price, supplyUnit, supplyPhoto);
            selectedSupplyViewList.Add(selectedSupplyToShow);
            UpdateSelectedSupplyList();
            supplyPricetextBox.Clear();
        }
        private void supplyPricetextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                DataGridViewRow selectedRow = supplyDatagridview.CurrentRow;

                if (selectedRow == null)
                {
                    MessageBox.Show("กรุณาเลือกแถวในตาราง");
                    return;
                }

                float price;
                if (!float.TryParse(supplyPricetextBox.Text, out price))
                {
                    MessageBox.Show("กรุณาระบุราคาให้ถูกต้อง");
                    return;
                }

                int supplyID = (int)selectedRow.Cells["ID"].Value;
                string supplyName = selectedRow.Cells["SupplyName"].Value?.ToString() ?? string.Empty;
                string supplyUnit = selectedRow.Cells["SupplyUnit"].Value?.ToString() ?? string.Empty;
                string supplyPhoto = selectedRow.Cells["SupplyPhoto"].Value?.ToString() ?? string.Empty;

                AllSupplyInQuotationListDataGridView selectedSupplyToShow = new AllSupplyInQuotationListDataGridView(
                    supplyID, supplyName, price, supplyUnit, supplyPhoto);
                selectedSupplyViewList.Add(selectedSupplyToShow);
                UpdateSelectedSupplyList();
                supplyPricetextBox.Clear();
            }
        }
        //Event to remove supply from Quotation
        private void removeSupplybutton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = supplyInQuotationdataGridView.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("กรุณาเลือกแถวในตาราง");
                return;
            }
            int rowIndex = selectedRow.Index;
            // Check if the index is valid in the list
            if (rowIndex >= 0 && rowIndex < selectedSupplyViewList.Count)
            {
                // Remove the item from the list at the given index
                selectedSupplyViewList.RemoveAt(rowIndex);

                // Update the DataGridView
                UpdateSelectedSupplyList();
            }
        }
        //Event to close & open valid date
        private void hasValidDatecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (hasValidDatecheckBox.Checked)
            {
                validdateTimePicker.Enabled = false;
            }
            else
            {
                validdateTimePicker.Enabled = true;
            }
        }
        //Create supplier
        private void CreateSupplierButton_Click(object sender, EventArgs e)
        {
            manageSupplier = new AllSupplierListForm();
            manageSupplier.Owner = main;
            manageSupplier.ShowDialog();
            UpdateComponents();
        }
        //Event to get pdf
        private void attachQuotationButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    quotationPDF = openFileDialog.FileName;
                    quotationlinkLabel.LinkColor = System.Drawing.Color.Purple;
                    pdfURLtextBox.Text = quotationPDF;
                }
            }
        }
        //Save photo & documents into server
        private void SaveQuotationPDF()
        {
            if (!string.IsNullOrEmpty(quotationPDF))
            {
                Global.Directory = "QuotationPDF";
                Global.SaveFileToServerSupply(quotationPDF);
                Global.Directory = null;
                quotationPDF = Global.TargetFilePath;
            }
        }
        //Checking
        private bool CheckAttributeForCreateQuotation()
        {
            int selectSupplierIndex = supplierComboBox.SelectedIndex;
            if(selectSupplierIndex >= 0 && selectSupplierIndex < supplierIDList.Count)
            {
                int selectedSupplierID = supplierIDList[selectSupplierIndex];
                supplier = new Supplier(selectedSupplierID);
            }
            else
            {
                MessageBox.Show("กรุณาเลือก ซัพพลายเออร์");
                return false;
            }
            if (string.IsNullOrEmpty(quotationNumberTextBox.Text))
            {
                MessageBox.Show("กรุณาระบุ เลขที่ใบเสนอราคา");
                return false;
            }
            if(validdateTimePicker.Enabled == false)
            {
                validDate = null;
            }
            else
            {
                validDate = validdateTimePicker.Value;
            }
            if (string.IsNullOrEmpty(quotationPDF))
            {
                MessageBox.Show("กรุณาแนบไฟล์ ใบเสนอราคาอ้างอิง");
                return false;
            }
            if (!string.IsNullOrEmpty(quotationPDF))
            {
                SaveQuotationPDF();
            }
            return true;
        }
        private bool CheckAttributeForSupplyInQuotation()
        {
            if(selectedSupplyViewList.Count == 0)
            {
                MessageBox.Show("กรุณาเลือกวัสดุ อย่างน้อย 1 รายการ");
                return false;
            }
            return true;
        }
        //Create Quotation
        private void createQuotationbutton_Click(object sender, EventArgs e)
        {
            if (CheckAttributeForCreateQuotation() && CheckAttributeForSupplyInQuotation())
            {
                Quotation newQ = new Quotation(Global.warehouseID,supplier,quotationNumberTextBox.Text,issuedateTimePicker.Value
                    ,validdateTimePicker.Enabled,quotationPDF, validDate);
                if (newQ.Create())
                {
                    foreach (AllSupplyInQuotationListDataGridView siqView in selectedSupplyViewList)
                    {
                        Supply s = new Supply(siqView.SupplyID);
                        if (!s.IsActive)
                        {
                            s.IsActive = true;
                            MessageBox.Show("เปลี่ยนสถานะ วัสดุเป็นกำลังใช้งาน");
                        }
                        SupplyInQuotation siq = new SupplyInQuotation(Global.ID, s, siqView.Price);
                        if (!siq.Create())
                        {
                            MessageBox.Show("การสร้างซัพพลาย รายการ : " + siq.Supply + " ไอดี : " + siq.ID + " ล้มเหลว");
                        }
                    }
                    MessageBox.Show("สร้างใบเสนอราคา สมบูรณ์");
                    Close();
                }
                else
                {
                    MessageBox.Show("สร้างใบเสนอราคา ล้มเหลว");
                    Global.DeleteFileFromFtpSupply(quotationPDF);
                }
            }
        }
        //Open Quotation PDF
        private void quotationlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(quotationPDF))
            {
                System.Diagnostics.Process.Start(quotationPDF);
            }
            else
            {
                MessageBox.Show("ไม่มีไฟล์บันทึก");
            }
        }
        //Event to show Hidden PictureBox
        private void supplyDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string columnName = supplyDatagridview.Columns[e.ColumnIndex].Name;
                if(columnName == "SupplyPhoto")
                {
                    string imagePath = supplyDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, supplyPictureBox);
                    supplyPictureBox.Visible = true;
                    supplyPictureBox.BringToFront();
                }
            }
        }
        private void supplyDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            supplyPictureBox.Visible = false;
        }
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

                    Global.LoadImageIntoPictureBox(imagePath, selectedSupplyPictureBox);
                    selectedSupplyPictureBox.Visible = true;
                    selectedSupplyPictureBox.BringToFront();
                }
            }
        }
        private void supplyInQuotationdataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            selectedSupplyPictureBox.Visible = false;
        }
    }
}
