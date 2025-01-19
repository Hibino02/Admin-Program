using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Drawing;

using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyArrivalManage
{
    public partial class SupplyArrivalForm : Form
    {
        //In Plan
        List<AllSupplyInPRArrivalListDataGridView> supplyInPRArrivalList;
        BindingSource supplyInPRArrivalLstBindingSource;
        //In Selected PR
        List<AllSupplyInPRListDataGridView> supplyInSelectedPRList = AllSupplyInPRListDataGridView.AllSupplyInSelectedPR(GlobalVariable.Global.PRID);
        BindingSource supplyInSelectedPRListBindingSorce;

        List<SupplyInPRArrival> supplyInPRArrival = SupplyInPRArrival.GetAllSupplyInPRByPRID(GlobalVariable.Global.PRID);
        BindingSource supplyInPRArrivalBindingSource;

        PR pr = new PR(GlobalVariable.Global.PRID);
        string invoicePDF = null;
        bool isPDFSave = false;
        List<Tuple<int, int,string,int>> pairsList;

        public SupplyArrivalForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            supplyInPRArrivalLstBindingSource = new BindingSource();
            supplyInSelectedPRListBindingSorce = new BindingSource();
            supplyInPRArrivalBindingSource = new BindingSource();

            UpdateSupplyInPlanDatagridView();
            UpdateSupplyInPRDatagridView();
        }
        //Supply In Plan
        private void UpdateSupplyInPlanDatagridView()
        {
            supplyInPRArrivalList = AllSupplyInPRArrivalListDataGridView.SupplyArrivalPlanBySupplyID(GlobalVariable.Global.PRID);
            supplyInPRArrivalLstBindingSource.DataSource = supplyInPRArrivalList;
            supplyInPRArrivalLstdataGridView.DataSource = supplyInPRArrivalLstBindingSource;
            FormatSupplyInPlanDatagridView();
        }
        private void FormatSupplyInPlanDatagridView()
        {
            var Columns = supplyInPRArrivalLstdataGridView.Columns;
            if(Columns["SupplyID"] != null)
            {
                Columns["SupplyID"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ขื่อวัสดุ";
                Columns["SupplyName"].Width = 450;
            }
            if(Columns["ReqW1"] != null)
            {
                Columns["ReqW1"].HeaderText = "สัปดาห์ที่ 1";
                Columns["ReqW1"].Width = 65;
                Columns["ReqW1"].DefaultCellStyle.BackColor = Color.Gold;
            }
            if (Columns["ReqW2"] != null)
            {
                Columns["ReqW2"].HeaderText = "สัปดาห์ที่ 2";
                Columns["ReqW2"].Width = 65;
                Columns["ReqW2"].DefaultCellStyle.BackColor = Color.Gold;
            }
            if (Columns["ReqW3"] != null)
            {
                Columns["ReqW3"].HeaderText = "สัปดาห์ที่ 3";
                Columns["ReqW3"].Width = 65;
                Columns["ReqW3"].DefaultCellStyle.BackColor = Color.Gold;
            }
            if (Columns["ReqW4"] != null)
            {
                Columns["ReqW4"].HeaderText = "สัปดาห์ที่ 4";
                Columns["ReqW4"].Width = 65;
                Columns["ReqW4"].DefaultCellStyle.BackColor = Color.Gold;
            }
            if (Columns["ArrW1"] != null)
            {
                Columns["ArrW1"].HeaderText = "ส่ง";
                Columns["ArrW1"].Width = 40;
                Columns["ArrW1"].DefaultCellStyle.BackColor = Color.Aqua;
            }
            if (Columns["ArrW2"] != null)
            {
                Columns["ArrW2"].HeaderText = "ส่ง";
                Columns["ArrW2"].Width = 40;
                Columns["ArrW2"].DefaultCellStyle.BackColor = Color.Aqua;
            }
            if (Columns["ArrW3"] != null)
            {
                Columns["ArrW3"].HeaderText = "ส่ง";
                Columns["ArrW3"].Width = 40;
                Columns["ArrW3"].DefaultCellStyle.BackColor = Color.Aqua;
            }
            if (Columns["ArrW4"] != null)
            {
                Columns["ArrW4"].HeaderText = "ส่ง";
                Columns["ArrW4"].Width = 40;
                Columns["ArrW4"].DefaultCellStyle.BackColor = Color.Aqua;
            }
            if (Columns["ArrDate1"] != null)
            {
                Columns["ArrDate1"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate1"].Width = 80;
                Columns["ArrDate1"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ArrDate2"] != null)
            {
                Columns["ArrDate2"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate2"].Width = 80;
                Columns["ArrDate2"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ArrDate3"] != null)
            {
                Columns["ArrDate3"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate3"].Width = 80;
                Columns["ArrDate3"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ArrDate4"] != null)
            {
                Columns["ArrDate4"].HeaderText = "วันที่ส่ง";
                Columns["ArrDate4"].Width = 80;
                Columns["ArrDate4"].DefaultCellStyle.Format = "MMM dd, yyy";
            }
            if (Columns["ReqAmount"] != null)
            {
                Columns["ReqAmount"].HeaderText = "แผนสุทธิ";
                Columns["ReqAmount"].Width = 60;
                Columns["ReqAmount"].DefaultCellStyle.BackColor = Color.Gold;
            }
            if (Columns["ArrAmount"] != null)
            {
                Columns["ArrAmount"].HeaderText = "ส่งสุทธิ";
                Columns["ArrAmount"].Width = 60;
                Columns["ArrAmount"].DefaultCellStyle.BackColor = Color.Aqua;
            }
            if (Columns["PRAmount"] != null)
            {
                Columns["PRAmount"].HeaderText = "ซื้อสุทธิ";
                Columns["PRAmount"].Width = 60;
                Columns["PRAmount"].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            if (Columns["RemainAmount"] != null)
            {
                Columns["RemainAmount"].HeaderText = "ขาด/เกิน";
                Columns["RemainAmount"].Width = 60;
                Columns["RemainAmount"].DefaultCellStyle.BackColor = Color.Orange;
            }
        }
        private void supplyInPRArrivalLstdataGridView_SelectionChanged(object sender, EventArgs e)
        {
            supplyInPRArrivalLstdataGridView.ClearSelection();
        }
        //Supply In Selected PR
        private void UpdateSupplyInPRDatagridView()
        {
            supplyInSelectedPRListBindingSorce.DataSource = supplyInSelectedPRList;
            supplyInSelectedPRdataGridView.DataSource = supplyInSelectedPRListBindingSorce;

            FormatSupplyInSelectedPRdataGridView();
        }
        private void FormatSupplyInSelectedPRdataGridView()
        {
            var Columns = supplyInSelectedPRdataGridView.Columns;
            if(Columns["PRID"] != null)
            {
                Columns["PRID"].Visible = false;
            }
            if(Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัสดุ";
                Columns["SupplyName"].Width = 500;
                Columns["SupplyName"].ReadOnly = true;
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
                Columns["Quantity"].HeaderText = "ยอดสั่งซื้อ";
                Columns["Quantity"].Width = 100;
                Columns["Quantity"].ReadOnly = true;

                supplyInSelectedPRdataGridView.CellFormatting += (s, e) =>
                {
                    if(e.ColumnIndex == Columns["Quantity"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInSelectedPRdataGridView.Rows[e.RowIndex].Cells["Quantity"]?.Value?.ToString();
                        string unit = supplyInSelectedPRdataGridView.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(unit))
                        {
                            e.Value = $"{quantity} {unit}";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["Balance"] != null)
            {
                Columns["Balance"].HeaderText = "ยอดปัจจุบัน";
                Columns["Balance"].Width = 100;
                Columns["Balance"].ReadOnly = true;

                supplyInSelectedPRdataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["Balance"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInSelectedPRdataGridView.Rows[e.RowIndex].Cells["Balance"]?.Value?.ToString();
                        string unit = supplyInSelectedPRdataGridView.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(unit))
                        {
                            e.Value = $"{quantity} {unit}";
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
                Columns["UpdateDate"].ReadOnly = true;
            }
            if (Columns["Amount"] != null)
            {
                Columns["Amount"].Visible = false;
            }
            if (Columns["QuotationNumber"] != null)
            {
                Columns["QuotationNumber"].HeaderText = "เลขที่ใบเสนอราคา";
                Columns["QuotationNumber"].Width = 100;
                Columns["QuotationNumber"].ReadOnly = true;
            }
            if (Columns["SupplyPhoto"] != null)
            {
                Columns["SupplyPhoto"].HeaderText = "รูป";
                Columns["SupplyPhoto"].Width = 30;
                Columns["SupplyPhoto"].ReadOnly = true;
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
            if (supplyInSelectedPRdataGridView.Columns["ArrivalQuantity"] == null)
            {
                var customInputColumn = new DataGridViewTextBoxColumn
                {
                    Name = "ArrivalQuantity",
                    HeaderText = "ยอดรับเข้า",
                    Width = 100,
                    ReadOnly = false,
                    DefaultCellStyle = { NullValue = string.Empty } // Ensure cells are initially blank
                };
                supplyInSelectedPRdataGridView.Columns.Add(customInputColumn);
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
        //Attach Invoice
        private void attachInvoicebutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    invoicePDF = openFileDialog.FileName;
                    invoicelinkLabel.LinkColor = Color.Purple;
                }
            }
        }
        private void SaveInvoicePDF()
        {
            if (!string.IsNullOrEmpty(invoicePDF))
            {
                Global.Directory = "ArrivalSupplyInvoice";
                Global.SaveFileToServerSupply(invoicePDF);
                Global.Directory = null;
                invoicePDF = Global.TargetFilePath;
            }
        }
        //Open Invoice
        private void invoicelinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(invoicePDF) && isPDFSave)
            {
                Global.DownloadAndOpenPdf(invoicePDF);
            }
            else if (!string.IsNullOrEmpty(invoicePDF))
            {
                System.Diagnostics.Process.Start(invoicePDF);
            }
        }
        //Create Arrival Supply
        private bool CheckAttributes()
        {
            pairsList = new List<Tuple<int, int, string,int>>();
            if (invoicePDF == null)
            {
                MessageBox.Show("กรุณาแนบเอกสารส่งสินค้า เพื่อเป็นหลักฐาน");
                return false;
            }
            foreach(DataGridViewRow row in supplyInSelectedPRdataGridView.Rows)
            {
                string sname = row.Cells["SupplyName"].Value.ToString();
                int sid = Convert.ToInt32(row.Cells["SupplyID"].Value);
                int prq = Convert.ToInt32(row.Cells["Quantity"].Value);
                int quantity;
                if(int.TryParse(row.Cells["ArrivalQuantity"].Value?.ToString(), out quantity))
                {
                    if (quantity == 0)
                    {
                        DialogResult result = MessageBox.Show("รายการ" + sname + " มียอดเป็น 0 ต้องการบันทึกใช่หรือไม่", "ยืนยัน",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.No)
                        {
                            return false;
                        }
                    }
                    if (quantity < 0)
                    {
                        MessageBox.Show("ยอดรายการ " + sname + "ไม่สามรถน้อยกว่า 0 ได้");
                        return false;
                    }
                    if(quantity > prq)
                    {
                        MessageBox.Show("ยอดรายการ " + sname + " ยอดรับเข้า มากกว่า ยอดสั่งซื้อ");
                        return false;
                    }
                    pairsList.Add(new Tuple<int,int,string,int>(sid,quantity, sname, prq));
                }
                else
                {
                    MessageBox.Show($"ข้อมูลในคอลัมน์ ยอดรับเข้า ของรายการ {sname} ไม่ใช่ตัวเลขที่ถูกต้อง");
                    return false;
                }
            }
            return true;
        }
        private void createbutton_Click(object sender, EventArgs e)
        {
            if (CheckAttributes())
            {
                DialogResult result = MessageBox.Show("รายการที่ถูกบันทึกจะไม่สามารถแก้ใขได้ ต้องการบันทึกใช่หรือไม่", "ยืนยัน",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    SaveInvoicePDF();
                    isPDFSave = true;
                    foreach (var pL in pairsList)
                    {
                        SupplyInPRArrival s = new SupplyInPRArrival(pr.ID, pL.Item1, pL.Item2, deliverdateTimePicker.Value.Date,
                            invoicePDF, Global.userName);
                        if (!s.Create())
                        {
                            MessageBox.Show("วัสดุรายการ " + pL.Item3 + " ล้มเหลวในการสร้าง");
                            if (SupplyInPRArrival.Remove(pr.ID))
                            {
                                MessageBox.Show("ทำการลบรายการส่งวัสดุทั้งหมดทิ้ง");
                                Global.DeleteFileFromFtpSupply(invoicePDF);
                                invoicePDF = null;
                                invoicelinkLabel.LinkColor = System.Drawing.Color.Blue;
                                return;
                            }
                        }
                    }
                    UpdateSupplyInPlanDatagridView();

                    if (!AreArrAmountsWithinPRAmounts())
                    {
                        return; // Stop further processing
                    }

                    MessageBox.Show("บันทึกรายการส่งวัสดุ สมบูรณ์");
                    ClearArrivalQuantityColumn();
                    CheckCurrentPRStatus();
                }
            }
        }
        private void ClearArrivalQuantityColumn()
        {
            // Check if the "ArrivalQuantity" column exists
            if (supplyInSelectedPRdataGridView.Columns["ArrivalQuantity"] != null)
            {
                // Get the index of the "ArrivalQuantity" column
                int columnIndex = supplyInSelectedPRdataGridView.Columns["ArrivalQuantity"].Index;

                // Iterate through the rows and clear the column values
                foreach (DataGridViewRow row in supplyInSelectedPRdataGridView.Rows)
                {
                    if (!row.IsNewRow) // Skip the new row placeholder
                    {
                        row.Cells[columnIndex].Value = null; // or string.Empty
                    }
                }
            }
        }
        //Check Amount if it's exceed;
        private bool AreArrAmountsWithinPRAmounts()
        {
            decimal prAmount;
            decimal arrAmount;
            foreach (DataGridViewRow row in supplyInPRArrivalLstdataGridView.Rows)
            {
                if (row.Cells["PRAmount"] != null && row.Cells["ArrAmount"] != null)
                {
                    // Ensure the cells have values and are not DBNull
                    if (row.Cells["PRAmount"].Value != null && row.Cells["ArrAmount"].Value != null)
                    {
                        string sname = row.Cells["SupplyName"].Value.ToString();
                        if (decimal.TryParse(row.Cells["PRAmount"].Value.ToString(), out  prAmount) &&
                            decimal.TryParse(row.Cells["ArrAmount"].Value.ToString(), out arrAmount))
                        {
                            // Check if ArrAmount exceeds PRAmount
                            if (arrAmount > prAmount)
                            {
                                MessageBox.Show("พบยอดรับเข้ารวมรายการ : "+ sname + " เกินจำนวนยอดสั่งซื้อ กรุณาตรวจสอบและแก้ไขข้อมูล",
                                        "ยอดรวมขัดแย้ง", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false; // Return false if any ArrAmount exceeds PRAmount
                            }
                        }
                        else
                        {
                            // Optional: Handle parsing errors, if needed
                            continue; // Skip the row if parsing fails
                        }
                    }
                }
            }

            return true; // Return true if no ArrAmount exceeds PRAmount
        }
        //Match PR amount and Arrival amount for PR Status
        private void CheckCurrentPRStatus()
        {
            bool allmatched = true;
            decimal prAmount;
            decimal arrAmount;
            foreach (DataGridViewRow row in supplyInPRArrivalLstdataGridView.Rows)
            {
                if (row.Cells["PRAmount"] != null && row.Cells["ArrAmount"] != null)
                {
                    // Ensure the cells have values and are not DBNull
                    if (row.Cells["PRAmount"].Value != null && row.Cells["ArrAmount"].Value != null)
                    {
                        if (decimal.TryParse(row.Cells["PRAmount"].Value.ToString(), out prAmount) &&
                            decimal.TryParse(row.Cells["ArrAmount"].Value.ToString(), out arrAmount))
                        {
                            // Check if the values are not matching
                            if (prAmount != arrAmount)
                            {
                                allmatched = false;
                                break; // Exit the loop if any row does not match
                            }
                        }
                        else
                        {
                            allmatched = false; // Treat parsing errors as mismatches
                            break;
                        }
                    }
                    else
                    {
                        allmatched = false; // Treat null values as mismatches
                        break;
                    }
                }
                else
                {
                    allmatched = false; // Treat missing columns as mismatches
                    break;
                }
            }
            if (allmatched)
            {
                PRStatus newS = new PRStatus(3);
                pr.PRStatus = newS;
                pr.Change();
            }
            else
            {
                PRStatus newS = new PRStatus(2);
                pr.PRStatus = newS;
                pr.Change();
            }
        }
        
    }
}
