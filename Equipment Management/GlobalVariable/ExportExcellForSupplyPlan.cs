using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Admin_Program.GlobalVariable
{
    class ExportExcellForSupplyPlan
    {
        private DataGridView DataGridView;

        public ExportExcellForSupplyPlan(DataGridView dataGridView)
        {
            DataGridView = dataGridView;
        }

        public void ExportToExcel()
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            try
            {
                for (int i = 3; i <= 13; i++)  // Columns 3 to 13 in the DataGridView
                {
                    worksheet.Cells[1, i - 2] = DataGridView.Columns[i].HeaderText;  // Adjust header placement
                }

                int rowCount = 0; // Track the number of actual data rows
                for (int i = 0; i < DataGridView.Rows.Count; i++)
                {
                    bool writeRow = false;  // Flag to determine if the row should be written

                    // Check only columns 9 to 12
                    for (int j = 9; j <= 12; j++)
                    {
                        var cellValue = DataGridView.Rows[i].Cells[j].Value?.ToString();
                        if (!string.IsNullOrEmpty(cellValue) && cellValue != "0")
                        {
                            writeRow = true;  // If any column from 9 to 12 is non-zero, set flag to true
                            break;  // No need to check further columns
                        }
                    }

                    // If any value in columns 9 to 12 is non-zero, write the entire row
                    if (writeRow)
                    {
                        for (int j = 3; j <= 13; j++)  // Write all columns
                        {
                            var cellValue = DataGridView.Rows[i].Cells[j].Value?.ToString();
                            worksheet.Cells[rowCount + 2, j - 2] = cellValue;
                        }
                        rowCount++; // Increment row count
                    }
                }
                worksheet.Columns.AutoFit();

                // Apply borders to all filled cells (including headers)
                Excel.Range usedRange = worksheet.Range[
                    worksheet.Cells[1, 1], // Start from header row, column 1
                    worksheet.Cells[rowCount + 1, 11] // Last filled row and column
                ];
                usedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                usedRange.Borders.Weight = Excel.XlBorderWeight.xlThin;

                // Save the file
                using (var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save an Excel File",
                    FileName = "List.xlsx"
                })
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting to Excel: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Cleanup
                workbook.Close(false);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }
        }
    }
}
