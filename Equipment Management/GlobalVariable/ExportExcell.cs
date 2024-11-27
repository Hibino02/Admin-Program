using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Admin_Program.GlobalVariable
{
    public class ExportExcel
    {
        private DataGridView EquipmentListDataGridView;

        public ExportExcel(DataGridView dataGridView)
        {
            EquipmentListDataGridView = dataGridView;
        }

        public void ExportToExcel()
        {
            var excelApp = new Excel.Application();
            var workbook = excelApp.Workbooks.Add();
            var worksheet = (Excel.Worksheet)workbook.Worksheets[1];

            try
            {
                // Add column headers for columns 1 to 8
                int columnCount = Math.Min(8, EquipmentListDataGridView.Columns.Count - 1);
                for (int i = 1; i <= columnCount; i++)
                {
                    worksheet.Cells[1, i] = EquipmentListDataGridView.Columns[i].HeaderText;
                }

                // Add rows for columns 1 to 8
                for (int i = 0; i < EquipmentListDataGridView.Rows.Count; i++)
                {
                    for (int j = 1; j <= columnCount; j++)
                    {
                        worksheet.Cells[i + 2, j] = EquipmentListDataGridView.Rows[i].Cells[j].Value?.ToString();
                    }
                }

                // Save the file
                using (var saveFileDialog = new SaveFileDialog
                {
                    Filter = "Excel Files (*.xlsx)|*.xlsx",
                    Title = "Save an Excel File",
                    FileName = "EquipmentList.xlsx"
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
