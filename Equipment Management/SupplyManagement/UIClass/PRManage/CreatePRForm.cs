using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Admin_Program.GlobalVariable;
using System.IO;
using ClosedXML.Excel;
using System.Diagnostics;

namespace Admin_Program.SupplyManagement.UIClass.PRManage
{
    public partial class CreatePRForm : Form
    {
        private List<int> supplierID = new List<int>();
        List<AllSupplierListDataDridView> supplierList;
        int selectedSupplierID;
        Supplier supplier;
        PR newPR;
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
        //SupplyInPR List after create complete
        List<SupplyInPR> supplyInPR = new List<SupplyInPR>();
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
        //List for all plan
        private List<int> pid = new List<int>();
        List<DeliveryPlan> dpList = new List<DeliveryPlan>();
        DeliveryPlan selectPlan = null;

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
            dpList = DeliveryPlan.GetAllDeliveryPlanList();
            dpList.Sort((x, y) => x._Month.ID.CompareTo(y._Month.ID));
            planSelectcomboBox.Items.Clear();
            pid.Clear();

            planSelectcomboBox.Items.Add("--- กรุณาเลือกแผนการจัดส่ง ถ้าไม่มีกรุณาเว้นว่าง ---");
            pid.Add(-1);
            foreach(DeliveryPlan dp in dpList)
            {
                planSelectcomboBox.Items.Add(dp.PlanName);
                pid.Add(dp.ID);
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
            if (Columns["PRID"] != null)
            {
                Columns["PRID"].Visible = false;
            }
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
        private void preSupplyInPRtextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = preSupplyInPRtextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var searchResult = preSupplyInPRView.Where(psipr =>
                psipr.SupplyName.ToLower().Contains(searchText)).ToList();

                preSupplyInPRBindingSource.DataSource = searchResult;
                preSupplyInPRdataGridView.DataSource = preSupplyInPRBindingSource;
            }
            else
            {
                preSupplyInPRBindingSource.DataSource = null;
                preSupplyInPRBindingSource.DataSource = preSupplyInPRView;
                preSupplyInPRdataGridView.DataSource = preSupplyInPRBindingSource;

                FormatSupplyInQuotationListDataGridView();
            }
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
                quantitytextBox.Focus();
            }
        }
        private void addToSupplyInPRbutton_Click(object sender, EventArgs e)
        {
            if(selectedRowInPreSupply != null)
            {
                if(supplyInPRList.Count != 15)
                {
                    if (!string.IsNullOrEmpty(quantitytextBox.Text))
                    {
                        int quantity = -1;
                        if (int.TryParse(quantitytextBox.Text, out quantity) && quantity > 0)
                        {
                            // Check if SupplyID is already in the list
                            bool isDuplicate = supplyInPRList.Any(item => item.SupplyID == supplyIDforQuery);
                            if (!isDuplicate)
                            {
                                float amount = 0;
                                amount = quantity * price;
                                Quotation q = new Quotation(quotationIDforQuery);
                                Supply s = new Supply(supplyIDforQuery);
                                AllSupplyInPRListDataGridView list = new AllSupplyInPRListDataGridView(
                                    s.SupplyName, price, s.SupplyUnit, quantity, amount, q.QuotationNumber
                                    , s.SupplyPhoto, q.QuotationPDF, q.ID, s.ID);
                                supplyInPRList.Add(list);

                                quantitytextBox.Clear();
                                resetSelectionInCurrentSelectedQuotation();
                                UpdateSupplyInPR();
                            }
                            else
                            {
                                MessageBox.Show("วัสดุนี้ได้ถูกเพิ่มในใบเสนอราคาแล้ว");
                                quantitytextBox.Clear();
                            }
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
                    MessageBox.Show("สามารถเพิ่ม ซัพพลายสูงสุดได้ 15 รายการ");
                    quantitytextBox.Clear();
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
                    if(supplyInPRList.Count != 15)
                    {
                        if (!string.IsNullOrEmpty(quantitytextBox.Text))
                        {
                            int quantity = -1;
                            if (int.TryParse(quantitytextBox.Text, out quantity) && quantity > 0)
                            {
                                bool isDuplicate = supplyInPRList.Any(item => item.SupplyID == supplyIDforQuery);
                                if (!isDuplicate)
                                {
                                    float amount = 0;
                                    amount = quantity * price;
                                    Quotation q = new Quotation(quotationIDforQuery);
                                    Supply s = new Supply(supplyIDforQuery);
                                    AllSupplyInPRListDataGridView list = new AllSupplyInPRListDataGridView(
                                        s.SupplyName, price, s.SupplyUnit, quantity, amount, q.QuotationNumber
                                        , s.SupplyPhoto, q.QuotationPDF, q.ID, s.ID);
                                    supplyInPRList.Add(list);

                                    quantitytextBox.Clear();
                                    resetSelectionInCurrentSelectedQuotation();
                                    UpdateSupplyInPR();
                                }
                                else
                                {
                                    MessageBox.Show("วัสดุนี้ได้ถูกเพิ่มในใบเสนอราคาแล้ว");
                                    quantitytextBox.Clear();
                                }
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
                        MessageBox.Show("สามารถเพิ่ม ซัพพลายสูงสุดได้ 15 รายการ");
                        quantitytextBox.Clear();
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
            if (Columns["PRID"] != null)
            {
                Columns["PRID"].Visible = false;
            }
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
            if (Columns["Balance"] != null)
            {
                Columns["Balance"].Visible = false;
            }
            if (Columns["UpdateDate"] != null)
            {
                Columns["UpdateDate"].Visible = false;
            }
            if (Columns["TotalArrive"] != null)
            {
                Columns["TotalArrive"].Visible = false;
            }
            if (Columns["TotalAmount"] != null)
            {
                Columns["TotalAmount"].Visible = false;
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
            int selectPIndex = planSelectcomboBox.SelectedIndex;
            if(selectPIndex >=0 && selectPIndex < pid.Count)
            {
                int selectedPID = pid[selectPIndex];
                selectPlan = new DeliveryPlan(selectedPID);
            }
            return true;
        }
        //Check SupplyInPR
        private bool CheckSupplyInPR()
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
            if (CheckPR() && CheckSupplyInPR())
            {
                PRStatus prS = new PRStatus(1);
                newPR = new PR(Global.warehouseID, supplier, requestertextBox.Text, PRTitletextBox.Text,
                    costOfSalecheckBox.Checked, companyAssetcheckBox.Checked, maintainancecheckBox.Checked,
                    rentalLeasecheckBox.Checked, othercheckBox.Checked, otherReasontextBox.Text, addDetailsrichTextBox.Text,
                    prS, deliveryDateTimePicker.Value.Date, contactPersontextBox.Text, selectPlan);

                Dictionary<int, string> uploadedFiles = new Dictionary<int, string>();
                if (newPR.Create())
                {
                    List<int> qidList = new List<int>();

                    try
                    {
                        foreach (AllSupplyInPRListDataGridView siprView in supplyInPRList)
                        {
                            string currentSupplyInPRQuotationPDF = null;
                            //Checking if QuotationID is change for not saving duplicate
                            if (!qidList.Contains(siprView.QuotationID))
                            {
                                if (!string.IsNullOrEmpty(siprView.QuotationPDF))
                                {
                                    qidList.Add(siprView.QuotationID);
                                    Global.Directory = "SupplyInPRQuotationPDF";
                                    //Save file from FTP to local
                                    string localPath = Global.DownloadPdfToLocalPath(siprView.QuotationPDF);
                                    //Save local file to FTP
                                    Global.SaveFileToServerSupply(localPath);
                                    //Delete local file
                                    File.Delete(localPath);
                                    Global.Directory = null;
                                    //Set variable for FTP URI
                                    currentSupplyInPRQuotationPDF = Global.TargetFilePath;

                                    // Add successfully uploaded file to the list
                                    uploadedFiles[siprView.QuotationID] = currentSupplyInPRQuotationPDF;
                                }
                            }
                            else
                            {
                                currentSupplyInPRQuotationPDF = uploadedFiles[siprView.QuotationID];
                            }
                            //Create Supply In PR & Supply In Arrival
                            Supply s = new Supply(siprView.SupplyID);
                            SupplyInPR sipr = new SupplyInPR(Global.PRID, s, siprView.Price, siprView.Quantity
                                , siprView.Amount, currentSupplyInPRQuotationPDF, siprView.QuotationNumber);
                            if (!sipr.Create())
                            {
                                throw new Exception($"การสร้างซัพพลาย รายการ: {sipr.Supply.SupplyName} ล้มเหลว");
                            }
                            supplyInPR.Add(sipr);
                        }
                        MessageBox.Show("สร้างคำขอซื้อ เสร็จสมบูรณ์");
                        PRgroupBox.Enabled = false;
                        supplyInPRgroupBox.Enabled = false;
                        quotationDatagridview.Enabled = false;
                        supplyInQuotationdataGridView.Enabled = false;
                        addQuotationbutton.Enabled = false;
                        quotationPDFlinkLabel.Enabled = false;
                        createPRbutton.Enabled = false;
                        genExcellbutton.Enabled = true;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        // Rollback: Delete all uploaded files
                        foreach (KeyValuePair<int, string> entry in uploadedFiles)
                        {
                            Global.DeleteFileFromFtpSupply(entry.Value);
                        }
                        supplyInPR.Clear();
                        // Remove all supplies associated with this PR
                        SupplyInPR.Remove(Global.PRID);
                        MessageBox.Show("ทำการลบรายการ ซัพพลายทั้งหมด ในคำขอซื้อ");

                        // Remove the PR
                        newPR.Remove();
                        MessageBox.Show("ทำการลบ PR เนื่องจากการสร้าง ซัพลลายล้มเหลว");
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("สร้าง PR ล้มเหลว");
                }
            }
        }
        //Gen Excel
        private void genExcellbutton_Click(object sender, EventArgs e)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Purchase Requisition");

                // Set column widths
                worksheet.Column("A").Width = 5;
                worksheet.Column("B").Width = 15.86;
                worksheet.Column("C").Width = 13;
                worksheet.Column("D").Width = 13;
                worksheet.Column("E").Width = 16;
                worksheet.Column("F").Width = 12;
                worksheet.Column("G").Width = 12;
                worksheet.Column("H").Width = 12;
                worksheet.Column("I").Width = 19;
                // Set row and content
                //1
                worksheet.Row(1).Height = 24.75;
                var cellNEC = worksheet.Cell(1, 1);
                cellNEC.Value = "NEC";
                cellNEC.Style.Font.SetBold();
                cellNEC.Style.Font.SetFontColor(XLColor.Blue);
                cellNEC.Style.Font.SetFontName("Tahoma");
                cellNEC.Style.Font.SetFontSize(25);
                var cellNippon = worksheet.Cell(1, 3);
                cellNippon.Value = "Nippon Express NEC Logistics (Thailand) Co., Ltd.";
                cellNippon.Style.Font.SetFontName("Tahoma");
                cellNippon.Style.Font.SetFontSize(14);
                //2
                worksheet.Row(2).Height = 7.5;
                //3
                worksheet.Row(3).Height = 22.5;
                worksheet.Range("A3:I3").Merge();
                var cellPurchase = worksheet.Cell(3, 1);
                cellPurchase.Value = "PURCHASE REQUISITION";
                cellPurchase.Style.Font.SetBold();
                cellPurchase.Style.Font.SetFontName("Tahoma");
                cellPurchase.Style.Font.SetFontSize(14);
                cellPurchase.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                //4
                worksheet.Row(4).Height = 7.5;
                //5
                worksheet.Row(5).Height = 22.5;
                worksheet.Cell(5, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(5, 1).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(5, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                var row5Between = worksheet.Range("B5:H5");
                row5Between.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                row5Between.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(5, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(5, 9).Style.Border.TopBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(5, 9).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(5, 1).Value = $"Name: {newPR.Requester}";
                worksheet.Cell(5, 6).Value = "Section: Warehouse & Distribution";
                //6
                worksheet.Row(6).Height = 21;
                worksheet.Cell(6, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                var row6Between = worksheet.Range("A6:I6");
                row6Between.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(6, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(6, 1).Value = $"{newPR.PRTitle}";
                worksheet.Cell(6, 1).Style.Font.SetFontName("Calibri");
                worksheet.Cell(6, 1).Style.Font.SetFontSize(13);
                //7
                worksheet.Row(7).Height = 20.25;
                worksheet.Cell(7, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(7, 1).Value = "Info for Finance       "
                    + (newPR.IsCostOfSale ? "☑": "☐")+"Cost of Sales    "
                    +(newPR.IsCompanyAsset ? "☑" : "☐")+"Company Asset    "
                    +(newPR.IsMaintainance ? "☑" : "☐")+"Maintainance    "
                    +(newPR.IsRental ? "☑" : "☐")+"Rental/Lease    "
                    +(newPR.IsOther ? "☑" : "☐")+"Other "+(newPR.OtherReason);
                worksheet.Cell(7, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //8
                worksheet.Row(8).Height = 11.25;
                worksheet.Cell(8, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                var row8Between = worksheet.Range("A8:I8");
                row8Between.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(8, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //9
                worksheet.Row(9).Height = 18;
                var mergedSSup = worksheet.Range("A9:E9");
                mergedSSup.Merge();
                mergedSSup.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                mergedSSup.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                mergedSSup.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                mergedSSup.Style.Fill.BackgroundColor = XLColor.FromArgb(204,255,255);
                mergedSSup.Value = "Suggested Supplier";
                mergedSSup.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                var mergedDS = worksheet.Range("F9:I9");
                mergedDS.Merge();
                mergedDS.Style.Fill.BackgroundColor = XLColor.FromArgb(255,255,153);
                mergedDS.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                mergedDS.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                mergedDS.Value = "Delivery Schedule";
                mergedDS.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                //10
                worksheet.Row(10).Height = 17.25;
                worksheet.Cell(10, 1).Value = $"{newPR.Supplier.Name}";
                worksheet.Cell(10, 1).Style.Font.SetFontName("Calibri");
                worksheet.Cell(10, 1).Style.Font.SetFontSize(13);
                worksheet.Cell(10, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(10, 6).Value = $"Delivery Date : {newPR.DeliveryDate.ToString("MMM, dd yyyy")}";
                worksheet.Cell(10, 6).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(10, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //11
                worksheet.Row(11).Height = 21;
                var merged11_1 = worksheet.Range("A11:E11");
                merged11_1.Merge();
                merged11_1.Style.Font.SetFontName("Calibri");
                merged11_1.Style.Font.SetFontSize(10);
                merged11_1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                merged11_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(11, 6).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(11, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                string address = newPR.Supplier.Address;
                if (!string.IsNullOrEmpty(address))
                {
                    // Split the address by newlines (\r\n or \n)
                    string[] lines = address.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);

                    // Start row for the address lines
                    int row = 11;

                    // Iterate over the split lines and place them in Excel cells
                    foreach (string line in lines)
                    {
                        if (row <= 13)  // Assuming a limit of 3 rows in Excel
                        {
                            worksheet.Cell(row, 1).Value = line;
                            row++;
                        }
                    }

                    // If there are more than 3 lines, concatenate the remaining parts and place in the last cell
                    if (lines.Length > 3)
                    {
                        string remaining = string.Join(" ", lines.Skip(3));
                        worksheet.Cell(13, 1).Value = remaining;
                    }
                }
                worksheet.Cell(11, 6).Value = "Delivery Place : Nippon Express NEC Logistics (Thailand) Co., Ltd.";
                //12
                worksheet.Row(12).Height = 17.25;
                var merged12_1 = worksheet.Range("A12:E12");
                merged12_1.Merge();
                merged12_1.Style.Font.SetFontName("Calibri");
                merged12_1.Style.Font.SetFontSize(10);
                merged12_1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                merged12_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(12, 6).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(12, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(12, 7).Value = "Bangpakong Logistics Center";
                //13
                worksheet.Row(13).Height = 17.25;
                var merged13_1 = worksheet.Range("A13:E13");
                merged13_1.Merge();
                merged13_1.Style.Font.SetFontName("Calibri");
                merged13_1.Style.Font.SetFontSize(10);
                merged13_1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                merged13_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(13, 6).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(13, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(13, 6).Value = "Tel:  038-134374-8 Fax: 038-134379";
                //14
                worksheet.Row(14).Height = 17.25;
                worksheet.Cell(14, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(14, 6).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(14, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                var row14range = worksheet.Range("A14:I14");
                row14range.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(14, 6).Value = $"Contact Person: {newPR.ContactPerson}";
                //15
                worksheet.Row(15).Height = 7.5;
                var cell15Range = worksheet.Range("A15:I15");
                cell15Range.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //16
                worksheet.Row(16).Height = 18;
                var cell16_1 = worksheet.Cell(16, 1);
                cell16_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell16_1.Value = "No";
                cell16_1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                var cell16Range = worksheet.Range("A16:I16");
                cell16Range.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                cell16Range.Style.Fill.BackgroundColor = XLColor.FromArgb(204,255,204);
                var cell16RangeB_F = worksheet.Range("B16:F16");
                cell16RangeB_F.Merge();
                cell16RangeB_F.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell16RangeB_F.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell16RangeB_F.Value = "Description - Specification";
                cell16RangeB_F.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                var cellG16 = worksheet.Cell(16, 7);
                cellG16.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cellG16.Value = "Unit Price";
                cellG16.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                var cellH16 = worksheet.Cell(16, 8);
                cellH16.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cellH16.Value = "Quantity";
                cellH16.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                var cellI16 = worksheet.Cell(16, 9);
                cellI16.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cellI16.Value = "Total";
                cellI16.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                //17 to 31
                worksheet.Rows(17, 31).Height = 21;
                int rowIndex = 17;
                int itemNo = 1;
                float TotalAmount = 0;
                foreach (SupplyInPR sip in supplyInPR)
                {
                    worksheet.Cell(rowIndex, 1).Value = itemNo;
                    worksheet.Cell(rowIndex, 2).Value = sip.Supply.SupplyName;
                    worksheet.Cell(rowIndex, 7).Value = sip.Price;
                    worksheet.Cell(rowIndex, 8).Value = sip.Quantity;
                    worksheet.Cell(rowIndex, 9).Value = sip.Amount;
                    TotalAmount += sip.Amount;
                    itemNo++;
                    rowIndex++;
                }
                for (int row = 17; row <= 31; row++)
                {
                    var cellRange = worksheet.Range($"A{row}:I{row}");
                    cellRange.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(row,1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(row,1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(row,7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(row,7).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(row,8).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(row, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    worksheet.Cell(row,9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(row, 9).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                }
                var cellPriceFormat = worksheet.Range("G17:G31");
                cellPriceFormat.Style.NumberFormat.Format = "#,##0.00";
                var cellAmountFormat = worksheet.Range("I17:I31");
                cellAmountFormat.Style.NumberFormat.Format = "#,##0.00";
                //32
                worksheet.Row(32).Height = 30;
                var allRow32 = worksheet.Range("A32:I32");
                allRow32.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                allRow32.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                var cell32_1 = worksheet.Cell(32, 1);
                cell32_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell32_1.Value = " *** Please attach quotation and comparison sheet (if any) with this purchase requisition.";
                var cell32_8 = worksheet.Cell(32, 8);
                cell32_8.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell32_8.Value = "Total";
                cell32_8.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                var cell32_9 = worksheet.Cell(32, 9);
                cell32_9.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell32_9.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                cell32_9.Style.NumberFormat.Format = "#,##0.00";
                cell32_9.Value = TotalAmount;
                //33
                worksheet.Row(33).Height = 15;
                var cell33_1 = worksheet.Cell(33, 1);
                cell33_1.Value = "Additional Details:";
                cell33_1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                cell33_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(33, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //34
                worksheet.Row(34).Height = 17.25;
                var allRow34 = worksheet.Range("A34:I34");
                allRow34.Style.Border.BottomBorder = XLBorderStyleValues.Dotted;
                var cell34_1 = worksheet.Cell(34,1);
                cell34_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell34_1.Style.Font.SetFontSize(13);
                var cell34_9 = worksheet.Cell(34, 9);
                cell34_9.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                string addDetails = newPR.AddDetails;
                if(addDetails.Length > 120)
                {
                    worksheet.Cell(34, 1).Value = addDetails.Substring(0, 120);
                    worksheet.Cell(35, 1).Value = addDetails.Substring(120);
                }
                else
                {
                    worksheet.Cell(34, 1).Value = addDetails;
                }
                //35
                worksheet.Row(35).Height = 21;
                var allRow35 = worksheet.Range("A35:I35");
                allRow35.Style.Border.BottomBorder = XLBorderStyleValues.Dotted;
                var cell35_1 = worksheet.Cell(35, 1);
                cell35_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell35_1.Style.Font.SetFontSize(13);
                var cell35_9 = worksheet.Cell(35, 9);
                cell35_9.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //36
                worksheet.Row(36).Height = 17.25;
                var allRow36 = worksheet.Range("A36:I36");
                allRow36.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                var cell36_1 = worksheet.Cell(36, 1);
                cell36_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                var cell36_9 = worksheet.Cell(36, 9);
                cell36_9.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //37
                worksheet.Row(37).Height = 21;
                var cell37_1 = worksheet.Cell(37, 1);
                cell37_1.Value = "Approval Criteria:";
                cell37_1.Style.Font.SetBold();
                cell37_1.Style.Font.SetFontName("Calibri (Body)");
                cell37_1.Style.Font.SetFontSize(14);
                //38
                worksheet.Row(38).Height = 17.25;
                var allRow38 = worksheet.Range("A38:I38");
                allRow38.Style.Font.SetBold();
                allRow38.Style.Font.SetFontName("Calibri (Body)");
                allRow38.Style.Font.SetFontSize(10);
                allRow38.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                allRow38.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                var cell38_1_2 = worksheet.Range("A38:B38");
                cell38_1_2.Merge();
                cell38_1_2.Value = "Budget";
                cell38_1_2.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell38_1_2.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                var cell38_1_2_3 = worksheet.Range("A38:D38");
                cell38_1_2_3.Style.Fill.BackgroundColor = XLColor.FromArgb(197, 217, 241);
                cell38_1_2_3.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                cell38_1_2_3.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(38, 3).Value = "1st Approval";
                worksheet.Cell(38, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(38, 4).Value = "2nd Approval";
                worksheet.Cell(38, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                var cell38_6_7_8_9 = worksheet.Range("F38:I38");
                cell38_6_7_8_9.Merge();
                cell38_6_7_8_9.Style.Border.TopBorder = XLBorderStyleValues.Thin;
                cell38_6_7_8_9.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(38, 6).Value = "Additional Required Documents from Vendor";
                worksheet.Cell(38, 6).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(38, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //39
                worksheet.Row(39).Height = 15;
                var criteriaFontRow39 = worksheet.Range("A39:D39");
                criteriaFontRow39.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range("A39:B39").Merge();
                var cell39_1 = worksheet.Cell(39,1);
                cell39_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell39_1.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell39_1.Value = "0-3,000 baht";
                var cell39_3 = worksheet.Cell(39, 3);
                cell39_3.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell39_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell39_3.Value = "ASM";
                var cell39_4 = worksheet.Cell(39, 4);
                cell39_4.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell39_4.Value = "SMG";
                var cell39_6 = worksheet.Cell(39, 6);
                cell39_6.Value = "       [     ] คู่มือ ( Manual)";
                cell39_6.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                var cell39_9 = worksheet.Cell(39, 9);
                cell39_9.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //40
                worksheet.Row(40).Height = 15;
                worksheet.Range("A40:D40").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range("A40:B40").Merge();
                var cell40_1 = worksheet.Cell(40, 1);
                cell40_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell40_1.Value = ("3,001-10,000 baht");
                var cell40_3 = worksheet.Cell(40, 3);
                cell40_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell40_3.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell40_3.Value = "SMG";
                var cell40_4 = worksheet.Cell(40,4);
                cell40_4.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell40_4.Value = "ADM";
                var cell40_6 = worksheet.Cell(40, 6);
                cell40_6.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell40_6.Value = "       [     ] MSDS";
                worksheet.Cell(40,9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //41
                worksheet.Row(41).Height = 15;
                worksheet.Range("A41:D41").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range("A41:B41").Merge();
                var cell41_1 = worksheet.Cell(41, 1);
                cell41_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell41_1.Value = ("10,001-50,000 baht");
                var cell41_3 = worksheet.Cell(41, 3);
                cell41_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell41_3.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell41_3.Value = "SMG";
                var cell41_4 = worksheet.Cell(41, 4);
                cell41_4.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell41_4.Value = "DMG";
                var cell41_6 = worksheet.Cell(41, 6);
                cell41_6.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell41_6.Value = "       [     ] การสอบเทียบ ( Calibration Certificate)";
                worksheet.Cell(41, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //42
                worksheet.Row(42).Height = 15;
                worksheet.Range("A42:D42").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range("A42:B42").Merge();
                var cell42_1 = worksheet.Cell(42, 1);
                cell42_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell42_1.Value = ("50,001 - 100,000 baht");
                var cell42_3 = worksheet.Cell(42, 3);
                cell42_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell42_3.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell42_3.Value = "ADM / DMG";
                var cell42_4 = worksheet.Cell(42, 4);
                cell42_4.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell42_4.Value = "GM";
                var cell42_6 = worksheet.Cell(42, 6);
                cell42_6.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell42_6.Value = "       [     ] อื่นๆ ( Others) ระบุ …………………………………";
                worksheet.Cell(42, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //43
                worksheet.Row(43).Height = 15;
                worksheet.Range("A43:D43").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Range("A43:B43").Merge();
                var cell43_1 = worksheet.Cell(43, 1);
                cell43_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell43_1.Value = ("More than 100,000 baht");
                worksheet.Range("A43:D43").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                var cell43_3 = worksheet.Cell(43, 3);
                cell43_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell43_3.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell43_3.Value = "GM";
                var cell43_4 = worksheet.Cell(43, 4);
                cell43_4.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cell43_4.Value = "MD";
                worksheet.Range("F43:I43").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(43, 6).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(43, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                //44
                worksheet.Row(44).Height = 6.75;
                worksheet.Range("A44:I44").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //45
                worksheet.Row(45).Height = 21.75;
                var cellA45_B46 = worksheet.Range("A45:B46");
                cellA45_B46.Merge();
                cellA45_B46.Style.Fill.BackgroundColor = XLColor.FromArgb(255,255,0);
                cellA45_B46.Style.Font.SetBold();
                cellA45_B46.Style.Font.SetFontName("Calibri (Body)");
                cellA45_B46.Style.Font.SetFontSize(14);
                cellA45_B46.Value = "Requested by";
                cellA45_B46.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cellA45_B46.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cellA45_B46.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cellA45_B46.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                var cellG45_I46 = worksheet.Range("G45:I46");
                cellG45_I46.Merge();
                cellG45_I46.Style.Fill.BackgroundColor = XLColor.FromArgb(0,246,111);
                cellG45_I46.Style.Font.SetBold();
                cellG45_I46.Style.Font.SetFontName("Calibri (Body)");
                cellG45_I46.Style.Font.SetFontSize(14);
                cellG45_I46.Value = "HR & Administration";
                cellG45_I46.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cellG45_I46.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cellG45_I46.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cellG45_I46.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                var cellC45_F45 = worksheet.Range("C45:F45");
                cellC45_F45.Merge();
                cellC45_F45.Style.Fill.BackgroundColor = XLColor.FromArgb(141,180,226);
                cellC45_F45.Style.Font.SetBold();
                cellC45_F45.Style.Font.SetFontName("Calibri (Body)");
                cellC45_F45.Style.Font.SetFontSize(14);
                cellC45_F45.Value = "APPROVAL";
                cellC45_F45.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                cellC45_F45.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cellC45_F45.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //46
                worksheet.Row(46).Height = 21.75;
                worksheet.Range("A46:I46").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                var cellC46_D46 = worksheet.Range("C46:D46");
                cellC46_D46.Merge();
                cellC46_D46.Style.Fill.BackgroundColor = XLColor.FromArgb(197,217,241);
                cellC46_D46.Style.Font.SetFontName("Calibri (Body)");
                cellC46_D46.Value = "1st Approval";
                cellC46_D46.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                cellC46_D46.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cellC46_D46.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                var cellE46_F46 = worksheet.Range("E46:F46");
                cellE46_F46.Merge();
                cellE46_F46.Style.Fill.BackgroundColor = XLColor.FromArgb(197, 217, 241);
                cellE46_F46.Style.Font.SetFontName("Calibri (Body)");
                cellE46_F46.Value = "2nd Approval";
                cellE46_F46.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                cellE46_F46.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                //47
                worksheet.Row(47).Height = 12;
                worksheet.Cell(47, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(47, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(47, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(47, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(47, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //48
                worksheet.Row(48).Height = 15;
                worksheet.Cell(48, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(48, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(48, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(48, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(48, 7).Value = "☐ Document Checked";
                worksheet.Cell(48, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //49
                worksheet.Row(49).Height = 15;
                worksheet.Cell(49, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(49, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(49, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(49, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(49, 7).Value = "  (Quatation, Comparison Sheet, etc.)";
                worksheet.Cell(49, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //50
                worksheet.Row(50).Height = 15;
                worksheet.Cell(50, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(50, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(50, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(50, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(50, 7).Value = "☐ PR, PO checked";
                worksheet.Cell(50, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //51
                worksheet.Row(51).Height = 15;
                worksheet.Cell(51, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(51, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(51, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(51, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(51, 7).Value = "☐ Confirmation to Vendor, Copy to Requester";
                worksheet.Cell(51, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //52
                worksheet.Row(52).Height = 15;
                worksheet.Cell(52, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(52, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(52, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(52, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(52, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //53
                worksheet.Row(53).Height = 15;
                var cellA53_I53 = worksheet.Range("A53:I53");
                cellA53_I53.Style.Font.SetFontName("Calibri (Body)");
                cellA53_I53.Style.Font.SetFontSize(10);
                var cell53_1 = worksheet.Range("A53:B53");
                cell53_1.Merge();
                cell53_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell53_1.Value = " Name: ……………………………";
                var cell53_3 = worksheet.Range("C53:D53");
                cell53_3.Merge();
                cell53_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell53_3.Value = " Name: ……………………………………";
                var cell53_5 = worksheet.Range("E53:F53");
                cell53_5.Merge();
                cell53_5.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell53_5.Value = " Name: ………………………………………";
                var cell53_7 = worksheet.Range("G53:I53");
                cell53_7.Merge();
                cell53_7.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell53_7.Value = "Sign: ………………………………… Date: …………………………";
                worksheet.Cell(53, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //54
                worksheet.Row(54).Height = 20.25;
                var cellA54_I54 = worksheet.Range("A54:I54");
                cellA54_I54.Style.Font.SetFontName("Calibri (Body)");
                cellA54_I54.Style.Font.SetFontSize(10);
                var cell54_1 = worksheet.Range("A54:B54");
                cell54_1.Merge();
                cell54_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell54_1.Value = " Date: ……………………………";
                var cell54_3 = worksheet.Range("C54:D54");
                cell54_3.Merge();
                cell54_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell54_3.Value = " Date: ……………………………………";
                var cell54_5 = worksheet.Range("E54:F54");
                cell54_5.Merge();
                cell54_5.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell54_5.Value = " Date: ………………………………………";
                var cell54_7 = worksheet.Range("G54:I54");
                cell54_7.Merge();
                cell54_7.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                cell54_7.Value = "SV-SMG: …………………………… Date: …………………………";
                worksheet.Cell(54, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                //55
                worksheet.Row(55).Height = 15;
                worksheet.Cell(55, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(55, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(55, 5).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(55, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(55, 10).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                worksheet.Range("A55:I55").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                //Footer
                worksheet.PageSetup.Footer.Right.AddText("FR-Q-AM-034 Rev.02");

                // Show SaveFileDialog
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.Title = "Save Purchase Requisition";

                // Show the dialog and check if the user selected a file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Save the workbook to the selected path
                    var filePath = saveFileDialog.FileName;
                    try
                    {
                        if (IsFileInUse(filePath))
                        {
                            MessageBox.Show("ไฟล์ที่เลือกกำลังถูกเปิด หรือใช้งานอยู่ กรุณาปิดก่อนแล้วลองอีกครั้ง",
                                "ไฟล์กำลังใช้งาน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            workbook.SaveAs(filePath);
                            // Open the saved file
                            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving the file: {ex.Message}",
                                        "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //Split string function
        string GetLine(string text, int maxLength, out string remaining)
        {
            if (text.Length <= maxLength)
            {
                remaining = string.Empty;
                return text;
            }

            int lastSpaceIndex = text.LastIndexOf(' ', maxLength);
            if (lastSpaceIndex == -1) lastSpaceIndex = maxLength; // No space, split at maxLength

            remaining = text.Substring(lastSpaceIndex + 1); // Remaining after the split
            return text.Substring(0, lastSpaceIndex);       // Line up to the split
        }
        //Check opening file function
        bool IsFileInUse(string path)
        {
            if (!File.Exists(path)) return false;

            try
            {
                // Try to open the file exclusively
                using (var fileStream = File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    fileStream.Close();
                }
            }
            catch (IOException)
            {
                return true; // File is in use
            }

            return false; // File is not in use
        }
    }
}
