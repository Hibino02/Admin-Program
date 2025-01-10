using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Admin_Program.GlobalVariable;

namespace Admin_Program.SupplyManagement.UIClass.PRManage
{
    public partial class CreatePRForm : Form
    {
        private List<int> supplierID = new List<int>();
        List<AllSupplierListDataDridView> supplierList;
        int selectedSupplierID;
        Supplier supplier;
        //Selected supplier and showing quotationlist
        List<AllQuotationListDataGridView> quotationFilteredList;
        List<AllQuotationListDataGridView> quotationOriginalList = AllQuotationListDataGridView.AllQuotationFilteredByValidDate();
        BindingSource quotationBindingSource;
        string quotationPDF;
        int quotationID;
        //Showing supply
        BindingSource supplyInQuotationBindingSource;
        List<AllSupplyInQuotationListDataGridView> supplyInQuotationViewList = AllSupplyInQuotationListDataGridView.allSupplyInQuotation();
        List<AllSupplyInQuotationListDataGridView> filteredList = new List<AllSupplyInQuotationListDataGridView>();
        //Current Quotation Selected Datagridview
        List<AllQuotationListDataGridView> currentSelectedQuotationList;
        BindingSource currentSelectedQuotationBindingSource;
        string selectedQuotationPDF;
        //Pre-SupplyInPR
        List<SupplyInQuotation> supplyInQuotation;
        List<SupplyInQuotation> preSupplyInPRList;
        List<AllSupplyInQuotationListDataGridView> preSupplyInPRView;
        BindingSource preSupplyInPRBindingSource;
        DataGridViewRow selectedRowInPreSupply;
        int quotationIDforQuery;
        int supplyIDforQuery;
        float price;
        //Selected SupplyInPR
        List<AllSupplyInPRListDataGridView> supplyInPRList;
        BindingSource supplyInPRBindingSource;
        //PictureBox
        private PictureBox leftPictureBox;
        private PictureBox rightPictureBox;
        // List of predefined colors for highlighting
        private Dictionary<string, Color> idToColorMap = new Dictionary<string, Color>();
        private readonly List<Color> highlightColors = new List<Color>
        {
            Color.LightCyan,
            Color.LightGreen,
            Color.LightBlue,
            Color.LightGoldenrodYellow,
            Color.LightGray,
            Color.LightPink
        };
        private int currentColorIndex = 0;

        public CreatePRForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            otherReasontextBox.Enabled = false;

            supplierList = new List<AllSupplierListDataDridView>();
            preSupplyInPRList = new List<SupplyInQuotation>();
            supplyInPRList = new List<AllSupplyInPRListDataGridView>();

            quotationBindingSource = new BindingSource();
            currentSelectedQuotationBindingSource = new BindingSource();
            supplyInQuotationBindingSource = new BindingSource();
            preSupplyInPRBindingSource = new BindingSource();
            supplyInPRBindingSource = new BindingSource();

            leftPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(leftPictureBox);
            supplyInQuotationdataGridView.CellMouseEnter += supplyInQuotationdataGridView_CellMouseEnter;
            supplyInQuotationdataGridView.CellMouseLeave += supplyInQuotationdataGridView_CellMouseLeave;
            preSupplyInPRdataGridView.CellMouseEnter += preSupplyInPRdataGridView_CellMouseEnter;
            preSupplyInPRdataGridView.CellMouseLeave += preSupplyInPRdataGridView_CellMouseLeave;

            rightPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(750, 0)
            };
            this.Controls.Add(rightPictureBox);
            supplyInPRdataGridView.CellMouseEnter += supplyInPRdataGridView_CellMouseEnter;
            supplyInPRdataGridView.CellMouseLeave += supplyInPRdataGridView_CellMouseLeave;

            UpdateComponents();
        }
        private void SetRowColorById(DataGridViewRow row, string id)
        {
            if (!idToColorMap.ContainsKey(id))
            {
                // Assign a new color if the ID doesn't have an assigned color
                idToColorMap[id] = highlightColors[currentColorIndex];

                // Move to the next color (cycling through the color list)
                currentColorIndex = (currentColorIndex + 1) % highlightColors.Count;
            }

            // Apply the color to the row
            row.DefaultCellStyle.BackColor = idToColorMap[id];
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
            resetSelectionInCurrentSelectedQuotation();
            if (e.RowIndex >= 0)
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
                Global.DownloadAndOpenPdf(quotationPDF);
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
            else
            {
                //To clear linklist
                quotationPDF = null;
                quotationPDFlinkLabel.LinkColor = System.Drawing.Color.Blue;
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
        private void supplyInQuotationdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            supplyInQuotationdataGridView.ClearSelection();
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
                Columns["SupplyName"].Width = 360;
            }
            if (Columns["Price"] != null)
            {
                Columns["Price"].HeaderText = "ราคา";
                Columns["Price"].Width = 60;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].HeaderText = "หน่วย";
                Columns["SupplyUnit"].Width = 60;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].HeaderText = "รูป";
                Columns["SupplyPhoto"].Width = 24;
            }
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

                    Global.LoadImageIntoPictureBox(imagePath, leftPictureBox);
                    leftPictureBox.Visible = true;
                    leftPictureBox.BringToFront();
                }
            }
        }
        private void supplyInQuotationdataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            leftPictureBox.Visible = false;
        }
        //Event to addSelectedQuotation to PR
        private void resetSelectionInCurrentSelectedQuotation()
        {
            currentSelectedQuotationdataGridView.ClearSelection();
            selectedQuotationPDF = null;
            currentSelectedQuotationPDFlinkLabel.LinkColor = System.Drawing.Color.Blue;
        }
        private void addQuotationbutton_Click(object sender, EventArgs e)
        {
            if (quotationFilteredList != null && quotationFilteredList.Any())
            {
                DialogResult result = MessageBox.Show("ใบเสนอราคาที่ถูกเพิ่ม จะไม่สามารถยกเลิกได้ คุณแน่ใจหรือไม่?", "ยืนยันการเพิ่ม",
                     MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                {
                    suppliercomboBox.Enabled = false;
                    quotationIDforQuery = quotationID;
                    AllQuotationListDataGridView objToMove = quotationFilteredList.FirstOrDefault(q => q.ID == quotationID);

                    if (objToMove != null)
                    {
                        // Remove the object from the source list
                        quotationFilteredList.Remove(objToMove);

                        supplyInQuotationBindingSource.DataSource = null;
                        quotationBindingSource.DataSource = null;
                        quotationBindingSource.DataSource = quotationFilteredList;
                        quotationDatagridview.DataSource = quotationBindingSource;
                        FormatQuotationForSelectedSupplier();

                        // Add the object to the destination list
                        if (currentSelectedQuotationList == null)
                        {
                            currentSelectedQuotationList = new List<AllQuotationListDataGridView>();
                        }
                        currentSelectedQuotationList.Add(objToMove);

                        currentSelectedQuotationBindingSource.DataSource = null;
                        currentSelectedQuotationBindingSource.DataSource = currentSelectedQuotationList;
                        currentSelectedQuotationdataGridView.DataSource = currentSelectedQuotationBindingSource;
                        FormatCurrentSelectedQuotation();

                        resetSelectionInCurrentSelectedQuotation();
                        UpdatePreSupplyInPR();
                    }
                }         
            }
            else
            {
                MessageBox.Show("กุณาเลือก ใบเสนอราคา");
            }
        }
        private void currentSelectedQuotationdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = currentSelectedQuotationdataGridView.Rows[e.RowIndex];

                selectedQuotationPDF = selectedRow.Cells["QuotationPDF"].Value.ToString();
                // Update link label colors based on file existence
                if (!string.IsNullOrEmpty(selectedQuotationPDF))
                {
                    currentSelectedQuotationPDFlinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
                else
                {
                    currentSelectedQuotationPDFlinkLabel.LinkColor = System.Drawing.Color.Blue;
                }
            }
        }
        private void currentSelectedQuotationPDFlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(selectedQuotationPDF))
            {
                Global.DownloadAndOpenPdf(selectedQuotationPDF);
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
        private void currentSelectedQuotationdataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Assuming the ID is in the first column (index 0)
            string id = currentSelectedQuotationdataGridView.Rows[e.RowIndex].Cells["ID"].Value.ToString();

            // Set row color based on the ID
            SetRowColorById(currentSelectedQuotationdataGridView.Rows[e.RowIndex], id);
        }
        //Pre-SupplyInPR
        private void UpdatePreSupplyInPR()
        {
            supplyInQuotation = SupplyInQuotation.GetSupplyInQuotationList(quotationIDforQuery);
            preSupplyInPRList.AddRange(supplyInQuotation);
            preSupplyInPRView = AllSupplyInQuotationListDataGridView.SupplyInQuotationList(preSupplyInPRList);
            preSupplyInPRBindingSource.DataSource = null;
            preSupplyInPRBindingSource.DataSource = preSupplyInPRView;
            preSupplyInPRdataGridView.DataSource = preSupplyInPRBindingSource;

            FormatSupplyInQuotationListDataGridView();
        }
        private void FormatSupplyInQuotationListDataGridView()
        {
            var Columns = preSupplyInPRdataGridView.Columns;
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
                Columns["SupplyName"].Width = 350;
            }
            if (Columns["Price"] != null)
            {
                Columns["Price"].HeaderText = "ราคา/หน่วย";
                Columns["Price"].Width = 80;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].HeaderText = "หน่วย";
                Columns["SupplyUnit"].Width = 50;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].HeaderText = "รูป";
                Columns["SupplyPhoto"].Width = 24;
            }
        }
        private void preSupplyInPRdataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Assuming the ID is in the first column (index 0)
            string id = preSupplyInPRdataGridView.Rows[e.RowIndex].Cells["QuotationID"].Value.ToString();

            // Set row color based on the ID
            SetRowColorById(preSupplyInPRdataGridView.Rows[e.RowIndex], id);
        }
        private void preSupplyInPRdataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string columnName = preSupplyInPRdataGridView.Columns[e.ColumnIndex].Name;
                if(columnName == "SupplyPhoto")
                {
                    string imagePath = preSupplyInPRdataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath ,leftPictureBox);
                    leftPictureBox.Visible = true;
                    leftPictureBox.BringToFront();
                }
            }
        }
        private void preSupplyInPRdataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            leftPictureBox.Visible = false;
        }
        //Add-SupplyToPR
        private void preSupplyInPRdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                quotationIDforQuery = 0;
                supplyIDforQuery = 0;
                price = 0;
                selectedRowInPreSupply = preSupplyInPRdataGridView.Rows[e.RowIndex];

                quotationIDforQuery = Convert.ToInt32(selectedRowInPreSupply.Cells["QuotationID"].Value);
                supplyIDforQuery = Convert.ToInt32(selectedRowInPreSupply.Cells["SupplyID"].Value);
                price = Convert.ToSingle(selectedRowInPreSupply.Cells["Price"].Value);
                resetSelectionInCurrentSelectedQuotation();
            }
        }
        private void addToSupplyInPRbutton_Click(object sender, EventArgs e)
        {
            if(selectedRowInPreSupply != null)
            {
                if (!string.IsNullOrEmpty(quantitytextBox.Text))
                {
                    int quantity = -1;
                    if (int.TryParse(quantitytextBox.Text, out quantity) && quantity > 0)
                    {
                        float amount = 0;
                        amount = quantity * price;
                        Quotation q = new Quotation(quotationIDforQuery);
                        Supply s = new Supply(supplyIDforQuery);
                        AllSupplyInPRListDataGridView list = new AllSupplyInPRListDataGridView(
                            s.SupplyName, price, s.SupplyUnit,quantity, amount,q.QuotationNumber
                            ,s.SupplyPhoto,q.QuotationPDF,q.ID,s.ID);
                        supplyInPRList.Add(list);

                        quantitytextBox.Clear();
                        resetSelectionInCurrentSelectedQuotation();
                        UpdateSupplyInPR();
                    }
                    else
                    {
                        MessageBox.Show("จำนวนที่ระบุ ไม่ถูกต้อง");
                    }
                }
                else
                {
                    MessageBox.Show("กรุณาระบุ จำนวน");
                }  
            }
            else
            {
                MessageBox.Show("กรุณา เลือกวัสดุและระบุจำนวน");
            }
        }
        private void quantitytextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                if (selectedRowInPreSupply != null)
                {
                    if (!string.IsNullOrEmpty(quantitytextBox.Text))
                    {
                        int quantity = -1;
                        if (int.TryParse(quantitytextBox.Text, out quantity) && quantity > 0)
                        {
                            float amount = 0;
                            amount = quantity * price;
                            Quotation q = new Quotation(quotationIDforQuery);
                            Supply s = new Supply(supplyIDforQuery);
                            AllSupplyInPRListDataGridView list = new AllSupplyInPRListDataGridView(
                                s.SupplyName, price, s.SupplyUnit, quantity, amount, q.QuotationNumber
                                , s.SupplyPhoto, q.QuotationPDF, q.ID);
                            supplyInPRList.Add(list);

                            quantitytextBox.Clear();
                            resetSelectionInCurrentSelectedQuotation();
                            UpdateSupplyInPR();
                        }
                        else
                        {
                            MessageBox.Show("จำนวนที่ระบุ ไม่ถูกต้อง");
                        }
                    }
                    else
                    {
                        MessageBox.Show("กรุณาระบุ จำนวน");
                    }
                }
                else
                {
                    MessageBox.Show("กรุณา เลือกวัสดุและระบุจำนวน");
                }
            }
        }
        //SupplyInPR ADD
        private void UpdateSupplyInPR()
        {
            supplyInPRBindingSource.DataSource = null;
            supplyInPRBindingSource.DataSource = supplyInPRList;
            supplyInPRdataGridView.DataSource = supplyInPRBindingSource;

            FormatSupplyInPRListDataGridView();
        }
        private void supplyInPRdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            resetSelectionInCurrentSelectedQuotation();
        }
        private void FormatSupplyInPRListDataGridView()
        {
            var Columns = supplyInPRdataGridView.Columns;
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัดดุ";
                Columns["SupplyName"].Width = 305;
            }
            if (Columns["Price"] != null)
            {
                Columns["Price"].HeaderText = "ราคา/หน่วย";
                Columns["Price"].Width = 70;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].HeaderText = "หน่วย";
                Columns["SupplyUnit"].Width = 50;
            }
            if (Columns["Quantity"] != null)
            {
                Columns["Quantity"].HeaderText = "จำนวน";
                Columns["Quantity"].Width = 50;
            }
            if (Columns["Amount"] != null)
            {
                Columns["Amount"].HeaderText = "สุทธิ";
                Columns["Amount"].Width = 80;
            }
            if (Columns["QuotationNumber"] != null)
            {
                Columns["QuotationNumber"].HeaderText = "จากใบเสนอราคา";
                Columns["QuotationNumber"].Width = 150;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].HeaderText = "รูป";
                Columns["SupplyPhoto"].Width = 24;
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
        private void supplyInPRdataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                string columnName = supplyInPRdataGridView.Columns[e.ColumnIndex].Name;
                if(columnName == "SupplyPhoto")
                {
                    string imagePath = supplyInPRdataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, rightPictureBox);
                    rightPictureBox.Visible = true;
                    rightPictureBox.BringToFront();
                }
            }
        }
        private void supplyInPRdataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            rightPictureBox.Visible = false;
        }
        private void supplyInPRdataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            // Assuming the ID is in the first column (index 0)
            string id = supplyInPRdataGridView.Rows[e.RowIndex].Cells["QuotationID"].Value.ToString();

            // Set row color based on the ID
            SetRowColorById(supplyInPRdataGridView.Rows[e.RowIndex], id);
        }
        //SupplyInPR REMOVE
        private void removeFromSupplyInPRbutton_Click(object sender, EventArgs e)
        {
            if(supplyInPRdataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = supplyInPRdataGridView.SelectedRows[0];
                int rowIndex = selectedRow.Index;
                if (rowIndex >= 0 && rowIndex < supplyInPRList.Count)
                {
                    supplyInPRList.RemoveAt(rowIndex);
                    resetSelectionInCurrentSelectedQuotation();
                    UpdateSupplyInPR();
                }
            }
        }
        //Check PR attribute
        private bool CheckPR()
        {
            int selectSupplierIndex = suppliercomboBox.SelectedIndex;
            if (selectSupplierIndex >= 0 && selectSupplierIndex < supplierID.Count)
            {
                int selectedSupplierID = supplierID[selectSupplierIndex];
                supplier = new Supplier(selectedSupplierID);
            }
            else
            {
                MessageBox.Show("กรุณาเลือก ซัพพลายเออร์");
                return false;
            }
            if (string.IsNullOrEmpty(requestertextBox.Text))
            {
                MessageBox.Show("กรุณาระบุ ชื่อผู้ออกคำขอซื้อ");
                return false;
            }
            if (string.IsNullOrEmpty(PRTitletextBox.Text))
            {
                MessageBox.Show("กรุณาระบุ หัวข้อคำขอซื้อ");
                return false;
            }
            bool isAnyPrimaryChecked = costOfSalecheckBox.Checked || companyAssetcheckBox.Checked 
                || maintainancecheckBox.Checked || rentalLeasecheckBox.Checked;
            if (othercheckBox.Checked && string.IsNullOrEmpty(otherReasontextBox.Text))
            {
                MessageBox.Show("ใส่ข้อมูลสำหรับบัญชีเมื่อเลือก 'อื่นๆ'");
                return false;
            }
            if (!isAnyPrimaryChecked && !othercheckBox.Checked)
            {
                MessageBox.Show("กรุณาเลือก ข้อมูลสำหรับบัญชี อย่างน้อย 1 ข้อ");
                return false;
            }
            if (deliveryDateTimePicker.Value.Date <= DateTime.Now)
            {
                MessageBox.Show("วันที่ต้องการให้ส่ง ต้องมากกว่าวันที่ปัจจุบัน");
                return false;
            }
            if (string.IsNullOrEmpty(contactPersontextBox.Text))
            {
                MessageBox.Show("กรุณาระบุ ชื่อผู้ติดต่อส่งสินค้า");
                return false;
            }
            return true;
        }
        //Check SupplyInPR
        private bool SupplyInPR()
        {
            if(supplyInPRList.Count == 0)
            {
                MessageBox.Show("กรุณา เพิ่มวัสดุ อย่างน้อย 1 รายการ");
                return false;
            }
            return true;
        }
        //Create PR
        private void createPRbutton_Click(object sender, EventArgs e)
        {
            if (CheckPR() && SupplyInPR())
            {
                PRStatus prS = new PRStatus(1);
                PR newPR = new PR(Global.warehouseID, supplier, requestertextBox.Text, PRTitletextBox.Text,
                    costOfSalecheckBox.Checked, companyAssetcheckBox.Checked, maintainancecheckBox.Checked,
                    rentalLeasecheckBox.Checked, othercheckBox.Checked, otherReasontextBox.Text, addDetailsrichTextBox.Text,
                    prS, deliveryDateTimePicker.Value.Date, contactPersontextBox.Text);
                if (newPR.Create())
                {
                    foreach(AllSupplyInPRListDataGridView siprView in supplyInPRList)
                    {
                        Supply s = new Supply(siprView.SupplyID);
                        SupplyInPR sipr = new SupplyInPR(Global.PRID,s,siprView.Price,siprView.Quantity
                            ,siprView.Amount,siprView.QuotationPDF,siprView.QuotationNumber);
                        //Think for save quotation seperately and not duplicate here
                    }
                }
            }
        }
    }
}
