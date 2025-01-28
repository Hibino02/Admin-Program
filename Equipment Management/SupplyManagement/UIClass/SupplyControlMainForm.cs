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
using ClosedXML.Excel;
using System.IO;
using System.Diagnostics;
using Admin_Program.SupplyManagement.UIClass.SupplyArrivalManage;
using Admin_Program.SupplyManagement.UIClass.PRandArrivalHistory;
using Admin_Program.SupplyManagement.UIClass.SupplyHistory;
using Admin_Program.SupplyManagement.BusinessClass;
using System.Text.RegularExpressions;

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
        private SupplyArrivalForm supplyInPRArrival;
        private PRandArrivalHistoryForm prandArrivalHsitoryForm;
        private SupplyHistoryForm supplyHistoryForm;

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
        List<int> balanceID = new List<int>();

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
            supplyInSelectedPRdataGridView.DataSource = null;
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
                Columns["PRTitle"].Width = 179;
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
                Columns["PRStatus"].Width = 85;
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
            if (Columns["Balance"] != null)
            {
                Columns["Balance"].Visible = false;
            }
            if (Columns["UpdateDate"] != null)
            {
                Columns["UpdateDate"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
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
            if (Columns["TotalArrive"] != null)
            {
                Columns["TotalArrive"].Visible = false;
            }
            if (Columns["TotalAmount"] != null)
            {
                Columns["TotalAmount"].Visible = false;
            }
        }

        //Supply Balance
        private void UpdateSupplyBalanceDatafridView()
        {
            supplyBalanceAsUserGruop = AllSupplyInventoryDatagridView.AllSupplyBalance();
            supplyBalanceAsUserGruopBindingSource.DataSource = supplyBalanceAsUserGruop;
            supplyBalanceDatagridview.DataSource = supplyBalanceAsUserGruopBindingSource;

            supplyBalanceDatagridview.DataBindingComplete += (sender, e) =>
            {
                CheckBalanceAndBufferStock(supplyBalanceAsUserGruop);
                HighlightInven(balanceID);
                FormatSupplyBalancedataGridView();
            };
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
                Columns["SupplyName"].Width = 418;
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
            if (Columns["MOQ"] != null)
            {
                Columns["MOQ"].HeaderText = "จุดสั่งซื้อ";
                Columns["MOQ"].Width = 50;

                supplyBalanceDatagridview.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["MOQ"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyBalanceDatagridview.Rows[e.RowIndex].Cells["MOQ"]?.Value?.ToString();
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
                Columns["UpdateDate"].Width = 70;
                Columns["UpdateDate"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["Updater"] != null)
            {
                Columns["Updater"].HeaderText = "ผู้บันทึก";
                Columns["Updater"].Width = 75;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].Visible = false;
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
        //Check Balance and Buffer stock
        private void CheckBalanceAndBufferStock(List<AllSupplyInventoryDatagridView> list)
        {
            balanceID.Clear();
            foreach(AllSupplyInventoryDatagridView inven in list)
            {
                if(inven.Balance <= inven.MOQ)
                {
                    balanceID.Add(inven.ID);
                }
            }
        }
        //Highlight if Balance and MOQ is matched
        private void HighlightInven(List<int> id)
        {
            foreach (DataGridViewRow row in supplyBalanceDatagridview.Rows)
            {
                int ID = Convert.ToInt32(row.Cells["ID"].Value);
                if (balanceID.Contains(ID))
                {
                    // Set the background color of the entire row to orange
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
                else
                {
                    // Reset the background color to default if not matched
                    row.DefaultCellStyle.BackColor = Color.White;
                }
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
        //Generate inventory chart
        private void transactionbutton_Click(object sender, EventArgs e)
        {
            supplyHistoryForm = new SupplyHistoryForm();
            supplyHistoryForm.Owner = main;
            supplyHistoryForm.ShowDialog();
        }
        //Supply Manage
        private void manageSupplyButton_Click(object sender, EventArgs e)
        {
            allSupplyList = new AllSupplyListForm();
            allSupplyList.Owner = main;
            allSupplyList.ShowDialog();
            UpdateSupplyBalanceDatafridView();
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
            if (supplyRequestDataGridView.SelectedRows.Count > 0)
            {
                if (prStatusID > 1)
                {
                    MessageBox.Show("คำขอซื้อนี้ กำลังดำเนินการ จึงไม่สามารถลบได้");
                }
                else
                {
                    DialogResult result = MessageBox.Show("ต้องการลบคำขอซื้อใช่หรือไม่ ?", "ยืนยัน",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        List<SupplyInPR> sipr = SupplyInPR.GetAllSupplyInPRList(PRID);
                        foreach (SupplyInPR s in sipr)
                        {
                            if (s.QuotationPDF != quotationInSupply)
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
                        if (SupplyInPR.Remove(PRID) && SupplyInPRArrival.Remove(PRID))
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
            }          
        }
        //Gen Excel
        private void excelGenbutton_Click(object sender, EventArgs e)
        {
            if(supplyRequestDataGridView.SelectedRows.Count > 0)
            {
                PR newPR = new PR(PRID);
                List<SupplyInPR> supplyInPR = SupplyInPR.GetAllSupplyInPRList(PRID);
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
                        + (newPR.IsCostOfSale ? "☑" : "☐") + "Cost of Sales    "
                        + (newPR.IsCompanyAsset ? "☑" : "☐") + "Company Asset    "
                        + (newPR.IsMaintainance ? "☑" : "☐") + "Maintainance    "
                        + (newPR.IsRental ? "☑" : "☐") + "Rental/Lease    "
                        + (newPR.IsOther ? "☑" : "☐") + "Other " + (newPR.OtherReason);
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
                    mergedSSup.Style.Fill.BackgroundColor = XLColor.FromArgb(204, 255, 255);
                    mergedSSup.Value = "Suggested Supplier";
                    mergedSSup.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    var mergedDS = worksheet.Range("F9:I9");
                    mergedDS.Merge();
                    mergedDS.Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 153);
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
                    merged11_1.Style.Font.SetFontSize(13);
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
                    merged12_1.Style.Font.SetFontSize(13);
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
                    merged13_1.Style.Font.SetFontSize(13);
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
                    cell16Range.Style.Fill.BackgroundColor = XLColor.FromArgb(204, 255, 204);
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
                        worksheet.Cell(row, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(row, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(row, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(row, 7).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(row, 7).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(row, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(row, 8).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell(row, 8).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        worksheet.Cell(row, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
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
                    var cell34_1 = worksheet.Cell(34, 1);
                    cell34_1.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    cell34_1.Style.Font.SetFontSize(13);
                    var cell34_9 = worksheet.Cell(34, 9);
                    cell34_9.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    string addDetails = newPR.AddDetails;
                    if (addDetails.Length > 120)
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
                    var cell39_1 = worksheet.Cell(39, 1);
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
                    var cell40_4 = worksheet.Cell(40, 4);
                    cell40_4.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    cell40_4.Value = "ADM";
                    var cell40_6 = worksheet.Cell(40, 6);
                    cell40_6.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    cell40_6.Value = "       [     ] MSDS";
                    worksheet.Cell(40, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
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
                    cell42_1.Value = ("More than 50,000 baht");
                    var cell42_3 = worksheet.Cell(42, 3);
                    cell42_3.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    cell42_3.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    cell42_3.Value = "DMG";
                    var cell42_4 = worksheet.Cell(42, 4);
                    cell42_4.Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    cell42_4.Value = "MD";
                    var cell42_6 = worksheet.Cell(42, 6);
                    cell42_6.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    cell42_6.Value = "       [     ] อื่นๆ ( Others) ระบุ …………………………………";
                    worksheet.Cell(42, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    //43
                    worksheet.Row(43).Height = 15;
                    worksheet.Range("A43:D43").Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(43, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(43, 3).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(43, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell(43, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
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
                    cellA45_B46.Style.Fill.BackgroundColor = XLColor.FromArgb(255, 255, 0);
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
                    cellG45_I46.Style.Fill.BackgroundColor = XLColor.FromArgb(0, 246, 111);
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
                    cellC45_F45.Style.Fill.BackgroundColor = XLColor.FromArgb(141, 180, 226);
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
                    cellC46_D46.Style.Fill.BackgroundColor = XLColor.FromArgb(197, 217, 241);
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
        }
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
        //Supply Dilivery Plan
        private void supplyPlanButton_Click(object sender, EventArgs e)
        {
            supplyDeliveryPlan = new AllSupplyDiliveryListForm();
            supplyDeliveryPlan.Owner = main;
            supplyDeliveryPlan.ShowDialog();
        }
        //Supply Arrival
        private void CompletePRButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = supplyRequestDataGridView.CurrentRow;
            if(selectedRow != null)
            {
                GlobalVariable.Global.PRID = -1;
                GlobalVariable.Global.PRID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                supplyInPRArrival = new SupplyArrivalForm();
                supplyInPRArrival.Owner = main;
                supplyInPRArrival.ShowDialog();

                UpdatePRDatagridView();
                UpdateSupplyBalanceDatafridView();
            }
            else
            {
                MessageBox.Show("กรุณาเลือกรายการ คำขอซื้อ");
            }
        }
        //PR and Supply Arrival History
        private void PRHistorybutton_Click(object sender, EventArgs e)
        {
            prandArrivalHsitoryForm = new PRandArrivalHistoryForm();
            prandArrivalHsitoryForm.Owner = main;
            prandArrivalHsitoryForm.ShowDialog();
            UpdatePRDatagridView();
        }
        //packing material file upload
        private void fileUploadbutton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Excel Files (*.xls;*.xlsx)|*.xls;*.xlsx|All Files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string pattern = @"\((\d+)\)$";
                    // Get selected file names
                    string[] selectedFiles = openFileDialog.FileNames
                        .OrderByDescending(f =>
                        {
                            // Extract the number inside parentheses using regex
                            var match = Regex.Match(Path.GetFileName(f), pattern);
                            return match.Success ? int.Parse(match.Groups[1].Value) : 0; // If no number, return 0
                        })
                        .ToArray();

                    if (SFPManage.SFPCheckAndCreate(selectedFiles))
                    {
                        UpdateSupplyBalanceDatafridView();
                        MessageBox.Show("อัฟโหลดสมบูรณ์");
                    }
                }
            }
        }
        //To Main Menu
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}