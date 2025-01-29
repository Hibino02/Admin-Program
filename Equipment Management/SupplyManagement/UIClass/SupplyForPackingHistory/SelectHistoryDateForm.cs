using Admin_Program.SupplyManagement.ObjectClass;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyForPackingHistory
{
    public partial class SelectHistoryDateForm : Form
    {
        List<SupplyForPacking> sfpList = SupplyForPacking.GetAllSupplyForPacking();
        public SelectHistoryDateForm()
        {
            InitializeComponent();
            this.Size = new Size(520, 160);
        }

        private void createExcelbutton_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromdateTimePicker.Value.Date;
            DateTime toDate = todateTimePicker.Value.Date;

            if (fromDate > toDate)
            {
                MessageBox.Show("วันที่เริ่มต้น ไม่สามารถเกิน วันที่สิ้นสุดได้");
                return;
            }
            var filteredData = sfpList.Where(sfp => sfp.PackDate.Date >= fromDate && sfp.PackDate.Date <= toDate).ToList();
            if(filteredData.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลในช่วงวันที่ที่เลือก");
                return;
            }
            // Create Excel
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Packing Data");

                // Add headers
                worksheet.Cell(1, 1).Value = "ID";
                worksheet.Cell(1, 2).Value = "UploadDate";
                worksheet.Cell(1, 3).Value = "Invoice";
                worksheet.Cell(1, 4).Value = "Details";

                // Insert data
                int row = 2;
                foreach (var item in filteredData)
                {
                    worksheet.Cell(row, 1).Value = item.ID;
                    worksheet.Cell(row, 2).Value = item.PackDate.Date.ToString("dd-MM-yyyy");
                    worksheet.Cell(row, 3).Value = item.InvNum;
                    // Split Details by "KGS." and insert each part in a new row
                    string[] detailsParts = item.Details.Split(new string[] { "KGS." }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < detailsParts.Length; i++)
                    {
                        worksheet.Cell(row, 4).Value = detailsParts[i].Trim() + (i < detailsParts.Length - 1 ? " KGS." : "");

                        if (i < detailsParts.Length - 1)
                            row++; // Move to next row for the next part
                    }

                    row++; // Move to next row for the next entry
                }

                // Auto adjust column width
                worksheet.Columns().AdjustToContents();
                worksheet.Style.Alignment.Vertical = XLAlignmentVerticalValues.Top;

                // Save the file
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "SupplyData.xlsx");
                workbook.SaveAs(filePath);

                MessageBox.Show("Excel file saved successfully: " + filePath);
                System.Diagnostics.Process.Start(filePath); // Open the file
            }
        }
    }
}
