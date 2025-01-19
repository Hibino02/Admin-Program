using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.PRandArrivalHistory
{
    public partial class PRandArrivalHistoryForm : Form
    {
        List<AllPRListDataGridView> allPRList;
        BindingSource allPRBindingSource;

        List<AllSupplyInPRListDataGridView> allSupplyInPRList;
        BindingSource allSupplyInPRListBindingSource;

        List<SupplyArrivalHistory> allSupplyArrivalList;
        BindingSource allSupplyArrivalListBindingSource;

        List<Tuple<int, int>> supplyCollection = new List<Tuple<int, int>>();

        string quotationPDF;
        string invoicePDF;
        int PRID;
        List<int> sID = new List<int>();

        public PRandArrivalHistoryForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            UpdatePRDataGridView();
        }
        //PR List
        private void UpdatePRDataGridView()
        {
            allPRBindingSource = new BindingSource();
            allPRList = AllPRListDataGridView.AllPR();
            allPRBindingSource.DataSource = allPRList;
            PRListDatagridview.DataSource = allPRBindingSource;

            FormatPRList();
        }
        private void FormatPRList()
        {
            var Columns = PRListDatagridview.Columns;
            if (Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["PRTitle"] != null)
            {
                Columns["PRTitle"].HeaderText = "หัวข้อคำสั่งซื้อ";
                Columns["PRTitle"].Width = 180;
            }
            if (Columns["DeliveryDate"] != null)
            {
                Columns["DeliveryDate"].HeaderText = "วันที่ส่ง";
                Columns["DeliveryDate"].DefaultCellStyle.Format = "MMM dd, yyy";
                Columns["DeliveryDate"].Width = 80;
            }
            if (Columns["PRStatus"] != null)
            {
                Columns["PRStatus"].HeaderText = "สถานะ";
                Columns["PRStatus"].Width = 110;
            }
            if (Columns["PRStatusID"] != null)
            {
                Columns["PRStatusID"].Visible = false;
            }
        }
        private void PRListDatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = PRListDatagridview.Rows[e.RowIndex];

                PRID = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                UpdateSupplyInPRList(PRID);
                UpdateSupplyArrivalHistoryList(PRID);
            }
        }
        private void PRListDatagridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(PRListDatagridview.Rows.Count > 0)
            {
                PRListDatagridview.CurrentCell = PRListDatagridview.Rows[0].Cells[1];
                PRListDatagridview_CellClick(this,new DataGridViewCellEventArgs(0,0));
            }
        }
        //Supply In PR List
        private void UpdateSupplyInPRList(int prid)
        {
            allSupplyInPRList = AllSupplyInPRListDataGridView.AllSupplyInSelectedPRHistory(prid);
            allSupplyInPRListBindingSource = new BindingSource();
            allSupplyInPRListBindingSource.DataSource = allSupplyInPRList;
            supplyInPRdataGridView.DataSource = allSupplyInPRListBindingSource;

            CheckTotalAmount(allSupplyInPRList);
            FormatsupplyInPRList();
        }
        private void FormatsupplyInPRList()
        {
            var Columns = supplyInPRdataGridView.Columns;
            if (Columns["PRID"] != null)
            {
                Columns["PRID"].Visible = false;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัสดุ";
                Columns["SupplyName"].Width = 500;
            }
            if (Columns["Price"] != null)
            {
                Columns["Price"].HeaderText = "ราคา/หน่วย";
                Columns["Price"].Width = 80;

                supplyInPRdataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["Price"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInPRdataGridView.Rows[e.RowIndex].Cells["Price"]?.Value?.ToString();
                        if (!string.IsNullOrEmpty(quantity))
                        {
                            e.Value = $"{quantity} บาท";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["Quantity"] != null)
            {
                Columns["Quantity"].HeaderText = "จำนวนซื้อ";
                Columns["Quantity"].Width = 80;

                supplyInPRdataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["Quantity"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInPRdataGridView.Rows[e.RowIndex].Cells["Quantity"]?.Value?.ToString();
                        string supplyUnit = supplyInPRdataGridView.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(supplyUnit))
                        {
                            e.Value = $"{quantity} {supplyUnit}";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["Balance"] != null)
            {
                Columns["Balance"].Visible = false;
            }
            if (Columns["UpdateDate"] != null)
            {
                Columns["UpdateDate"].Visible = false;
            }
            if (Columns["Amount"] != null)
            {
                Columns["Amount"].HeaderText = "ราคาสุทธิ";
                Columns["Amount"].Width = 100;

                supplyInPRdataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["Amount"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInPRdataGridView.Rows[e.RowIndex].Cells["Amount"]?.Value?.ToString();
                        if (!string.IsNullOrEmpty(quantity))
                        {
                            e.Value = $"{quantity} บาท";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["QuotationNumber"] != null)
            {
                Columns["QuotationNumber"].HeaderText = "เลขที่ใบเสนอราคา";
                Columns["QuotationNumber"].Width = 120;
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
                Columns["TotalArrive"].HeaderText = "ส่งสุทธิ";
                Columns["TotalArrive"].Width = 85;

                supplyInPRdataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["TotalArrive"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInPRdataGridView.Rows[e.RowIndex].Cells["TotalArrive"]?.Value?.ToString();
                        string unit = supplyInPRdataGridView.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(unit))
                        {
                            e.Value = $"{quantity} {unit}";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
            if (Columns["TotalAmount"] != null)
            {
                Columns["TotalAmount"].HeaderText = "ขาด/เกิน สุทธิ";
                Columns["TotalAmount"].Width = 90;

                supplyInPRdataGridView.CellFormatting += (s, e) =>
                {
                    if (e.ColumnIndex == Columns["TotalAmount"].Index && e.RowIndex >= 0)
                    {
                        string quantity = supplyInPRdataGridView.Rows[e.RowIndex].Cells["TotalAmount"]?.Value?.ToString();
                        string unit = supplyInPRdataGridView.Rows[e.RowIndex].Cells["SupplyUnit"]?.Value.ToString();
                        if (!string.IsNullOrEmpty(quantity) && !string.IsNullOrEmpty(unit))
                        {
                            e.Value = $"{quantity} {unit}";
                            e.FormattingApplied = true;
                        }
                    }
                };
            }
        }
        private void supplyInPRdataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = supplyInPRdataGridView.Rows[e.RowIndex];
                quotationPDF = selectedRow.Cells["QuotationPDF"].Value.ToString();
                quotationlinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
        }
        private void supplyInPRdataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (supplyInPRdataGridView.Rows.Count > 0)
            {
                supplyInPRdataGridView.CurrentCell = supplyInPRdataGridView.Rows[0].Cells[1];
                supplyInPRdataGridView_CellClick(this, new DataGridViewCellEventArgs(0, 0));
            }
        }
        private void quotationlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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
        //Check Amount mismatch in Supply In PR
        private void CheckTotalAmount(List<AllSupplyInPRListDataGridView> asipr)
        {
            sID.Clear();
            foreach (AllSupplyInPRListDataGridView s in asipr)
            {
                if (s.TotalAmount != 0)
                {
                    sID.Add(s.SupplyID);
                }
            }
        }
        //Highlight supply that mismatched after Query SupplyHistory
        private void HighlightRowsBasedOnSupplyID(List<int> sID)
        {
            foreach (DataGridViewRow row in supplyInPRdataGridView.Rows)
            {
                int supplyID = Convert.ToInt32(row.Cells["SupplyID"].Value);
                if (sID.Contains(supplyID))
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
            foreach(DataGridViewRow row in arrivalHistorydataGridView.Rows)
            {
                int supplyID = Convert.ToInt32(row.Cells["SupplyID"].Value);
                if(sID.Contains(supplyID))
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
        //Supply Arrival History
        private void UpdateSupplyArrivalHistoryList(int prid)
        {
            allSupplyArrivalList = SupplyArrivalHistory.allSupplyArrivalHistoryByPRID(prid);
            allSupplyArrivalListBindingSource = new BindingSource();
            allSupplyArrivalListBindingSource.DataSource = allSupplyArrivalList;
            arrivalHistorydataGridView.DataSource = allSupplyArrivalListBindingSource;
            FormatArrivalHistory();
            ExtractDateFromList(allSupplyArrivalList);
            HighlightRowsBasedOnSupplyID(sID);
        }
        private void FormatArrivalHistory()
        {
            var Columns = arrivalHistorydataGridView.Columns;
            if(Columns["ID"] != null)
            {
                Columns["ID"].Visible = false;
            }
            if (Columns["PRID"] != null)
            {
                Columns["PRID"].Visible = false;
            }
            if (Columns["SupplyName"] != null)
            {
                Columns["SupplyName"].HeaderText = "ชื่อวัสดุ";
                Columns["SupplyName"].Width = 500;
                Columns["SupplyName"].ReadOnly = true;
            }
            if (Columns["Quantity"] != null)
            {
                Columns["Quantity"].HeaderText = "จำนวนที่ส่ง";
                Columns["Quantity"].Width = 100;
                Columns["Quantity"].ReadOnly = false;
            }
            if (Columns["SupplyUnit"] != null)
            {
                Columns["SupplyUnit"].HeaderText = "หน่วย";
                Columns["SupplyUnit"].Width = 50;
                Columns["SupplyUnit"].ReadOnly = true;
            }
            if (Columns["ArrivalDate"] != null)
            {
                Columns["ArrivalDate"].HeaderText = "วันที่ส่ง";
                Columns["ArrivalDate"].Width = 70;
                Columns["ArrivalDate"].DefaultCellStyle.Format = "MMM dd, yyy";
                Columns["ArrivalDate"].ReadOnly = true;
            }
            if (Columns["InvoicePDF"] != null)
            {
                Columns["InvoicePDF"].Visible = false;
            }
            if (Columns["Recever"] != null)
            {
                Columns["Recever"].HeaderText = "ผู้รับ";
                Columns["Recever"].Width = 100;
                Columns["Recever"].ReadOnly = true;
            }
            if (Columns["SupplyID"] != null)
            {
                Columns["SupplyID"].Visible = false;
            }
        }
        private void arrivalHistorydataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = arrivalHistorydataGridView.Rows[e.RowIndex];
                invoicePDF = selectedRow.Cells["InvoicePDF"].Value.ToString();
                invoicelinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
        }
        private void arrivalHistorydataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if(arrivalHistorydataGridView.Rows.Count > 0)
            {
                arrivalHistorydataGridView.CurrentCell = arrivalHistorydataGridView.Rows[0].Cells[2];
                arrivalHistorydataGridView_CellClick(this, new DataGridViewCellEventArgs(0,0));
            }
        }
        private void invoicelinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(invoicePDF))
            {
                Global.DownloadAndOpenPdf(invoicePDF);
            }
            else
            {
                MessageBox.Show("ไม่มีไฟล์บันทึก");
            }
        }
        //Supply Arrival History Date filter
        private void ExtractDateFromList(List<SupplyArrivalHistory> allSupplyArrivalList)
        {
            HashSet<string> uniqueDates = new HashSet<string>();
            arrivalDatecomboBox.Items.Clear();
            arrivalDatecomboBox.Items.Add("--- ดูทั้งหมด ---");
            foreach (SupplyArrivalHistory sah in allSupplyArrivalList)
            {
                if (sah.ArrivalDate.HasValue)
                {
                    string date = sah.ArrivalDate.Value.Date.ToString("MMM dd, yyy");
                    // Add the date to the HashSet (it will ensure uniqueness)
                    if (uniqueDates.Add(date))
                    {
                        // Only add the date to the ComboBox if it is unique
                        arrivalDatecomboBox.Items.Add(date);
                    }
                }
            }
        }
        private void arrivalDatecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDate = arrivalDatecomboBox.SelectedItem?.ToString();
            if (selectedDate == "--- ดูทั้งหมด ---")
            {
                UpdateSupplyArrivalHistoryList(PRID);
            }
            else
            {
                var searchResults = allSupplyArrivalList.Where(
                    s => s.ArrivalDate.HasValue && s.ArrivalDate.Value.Date.ToString("MMM dd, yyy") == selectedDate)
                    .ToList();

                allSupplyArrivalListBindingSource.DataSource = searchResults;
                arrivalHistorydataGridView.DataSource = allSupplyArrivalListBindingSource;
                HighlightRowsBasedOnSupplyID(sID);
            }
        }
        //Edit arrival history Event
        private void arrivalHistoryEditbutton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("ยืนยันการแก้ใข ?", "ยืนยัน",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                if (arrivalHistorydataGridView.Rows.Count > 0)
                {
                    foreach (DataGridViewRow row in arrivalHistorydataGridView.Rows)
                    {
                        int sipraid = Convert.ToInt32(row.Cells["ID"].Value ?? 0);
                        int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);

                        SupplyInPRArrival.Change(sipraid, quantity);
                    }
                    UpdateSupplyInPRList(PRID);
                    UpdateSupplyArrivalHistoryList(PRID);
                    if (sID.Count == 0)
                    {
                        if (PR.Change(PRID, 3))
                        {
                            MessageBox.Show("เปลี่ยนสถานะคำขอซื้อเป็น เสร็จสิ้น");
                        }
                        else
                        {
                            MessageBox.Show("เปลี่ยนสถานะ PR ล้มเหลว");
                        }
                    }
                    else
                    {
                        if (PR.Change(PRID, 2))
                        {
                            MessageBox.Show("เปลี่ยนสถานะคำขอซื้อเป็น รับสินค้าแล้วบางส่วน");
                        }
                        else
                        {
                            MessageBox.Show("เปลี่ยนสถานะ PR ล้มเหลว");
                        }
                    }
                    //Manually update PR List for update status
                    allPRBindingSource = new BindingSource();
                    allPRList = AllPRListDataGridView.AllPR();
                    allPRBindingSource.DataSource = allPRList;
                    PRListDatagridview.DataSource = allPRBindingSource;
                    FormatPRList();
                    MessageBox.Show("แก้ใขยอดส่งเรียบร้อย");                   
                }
            }
        }
    }
}
