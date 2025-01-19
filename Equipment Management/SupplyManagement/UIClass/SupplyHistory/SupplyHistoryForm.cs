using Admin_Program.SupplyManagement.CustomViewClass;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Admin_Program.SupplyManagement.UIClass.SupplyHistory
{
    public partial class SupplyHistoryForm : Form
    {
        List<AllSupplyListDataGridView> allsupply;
        List<int> allSupplyID = new List<int>();
        int selectedSupplyID;

        List<SupplyBalance> allSupplyInventory = SupplyBalance.GetAllSupplyBalanceList();
        List<SupplyInPRArrival> allSupplyInPRArrival;

        public SupplyHistoryForm()
        {
            InitializeComponent();

            UpdateSupplyCombobox();
        }
        private void UpdateSupplyCombobox()
        {
            allsupply = AllSupplyListDataGridView.AllSupply();
            allsupply.Sort((x, y) => x.SupplyTypeName.CompareTo(y.SupplyTypeName));
            supplycomboBox.Items.Clear();
            allSupplyID.Clear();

            supplycomboBox.Items.Add("--------------- กรรุณาเลือกวัสดุ ---------------");
            allSupplyID.Add(-1);
            foreach (AllSupplyListDataGridView asL in allsupply)
            {
                supplycomboBox.Items.Add(asL.SupplyName);
                allSupplyID.Add(asL.ID);
            }
        }
        private void supplycomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectSupplyIndex = supplycomboBox.SelectedIndex;
            if (selectSupplyIndex >= 0)
            {
                selectedSupplyID = allSupplyID[selectSupplyIndex];
            }
            else
            {
                selectedSupplyID = -1;
            }
        }
        //Balance line
        private void CreateBalanceSeries(int id, DateTime start,DateTime end)
        {
            // Ensure the chart area exists
            if (supplychart.ChartAreas.Count == 0)
            {
                supplychart.ChartAreas.Add(new ChartArea("Default"));
            }

            // Add the legend if it doesn't exist
            if (supplychart.Legends.Count == 0)
            {
                supplychart.Legends.Add(new Legend("Default"));
            }

            // Configure the chart area for date formatting
            var chartArea = supplychart.ChartAreas["Default"];
            chartArea.AxisX.LabelStyle.Format = "MMM dd, yyyy"; // Date format
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days; // Optional, adjusts intervals
            chartArea.AxisX.Interval = 7; // Adjust as needed for spacing

            chartArea.AxisX.Minimum = start.ToOADate(); // Set start date as the minimum
            chartArea.AxisX.Maximum = end.ToOADate();   // Optional, ensures it ends at the right date

            Series balanceSeries = new Series("ยอดคงเหลือ")
            {
                ChartType = SeriesChartType.StepLine,
                Color = Color.DarkBlue,
                BorderWidth = 3
            };

            var matchingBalance = allSupplyInventory.Where(s => s.Supply.ID == id && s.UpdateDate.Date
            >= start.Date && s.UpdateDate.Date <= end.Date).ToList();

            if (matchingBalance.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลในช่วงเวลาที่เลือก");
                return;
            }

            foreach (var balance in matchingBalance)
            {
                balanceSeries.Points.AddXY(balance.UpdateDate, balance.Balance);

                var lastPointIndex = balanceSeries.Points.Count - 1;
                var lastPoint = balanceSeries.Points[lastPointIndex];

                lastPoint.Label = balance.Balance.ToString("0"); // Display balance value as label
                lastPoint.LabelForeColor = Color.Black; // Label color
                lastPoint.LabelBackColor = Color.White; // Transparent background
            }

            supplychart.Series.Add(balanceSeries);
        }
        //Arrival box
        private void CreateArrivalSeries(int id,DateTime start,DateTime end)
        {
            allSupplyInPRArrival =SupplyInPRArrival.GetAllSupplyInPRBySupplyID(selectedSupplyID);
            // Ensure the chart area exists
            if (supplychart.ChartAreas.Count == 0)
            {
                supplychart.ChartAreas.Add(new ChartArea("Default"));
            }

            // Add the legend if it doesn't exist
            if (supplychart.Legends.Count == 0)
            {
                supplychart.Legends.Add(new Legend("Default"));
            }

            Series arrivalSeries = new Series("ยอดรับเข้า")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Orange,
                BorderWidth = 1
            };

            // Make columns thinner
            arrivalSeries["PixelPointWidth"] = "15";

            var matchingArrival = allSupplyInPRArrival.Where(a => a.SupplyID == id && a.ArrivalDate.Value.Date
            >= start.Date && a.ArrivalDate.Value.Date <= end.Date).ToList();

            if (matchingArrival.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลในช่วงเวลาที่เลือก");
                return;
            }

            foreach (var arrival in matchingArrival)
            {
                arrivalSeries.Points.AddXY(arrival.ArrivalDate.Value.Date, arrival.Quantity);

                // Add label for each point
                var lastPointIndex = arrivalSeries.Points.Count - 1;
                var lastPoint = arrivalSeries.Points[lastPointIndex];

                lastPoint.Label = arrival.Quantity.ToString("0"); // Display quantity value as label
                lastPoint.LabelForeColor = Color.Black; // Label color
                lastPoint.LabelBackColor = Color.Transparent; // Transparent background
            }

            supplychart.Series.Add(arrivalSeries);
        }
        //Usage Previous balance - next balance not Arrival
        private void CreateUsageSeries(int id, DateTime start, DateTime end)
        {
            // Ensure the chart area exists
            if (supplychart.ChartAreas.Count == 0)
            {
                supplychart.ChartAreas.Add(new ChartArea("Default"));
            }

            // Add the legend if it doesn't exist
            if (supplychart.Legends.Count == 0)
            {
                supplychart.Legends.Add(new Legend("Default"));
            }

            Series usageSeries = new Series("ยอดใช้")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.Red,
                BorderWidth = 2
            };

            // Make columns thinner
            usageSeries["PixelPointWidth"] = "15";

            // Get balances for the selected supply
            var matchingBalance = allSupplyInventory.Where(s => s.Supply.ID == id && s.UpdateDate.Date
            >= start.Date && s.UpdateDate.Date <= end.Date).ToList();

            // Get arrivals for the selected supply in the same date range
            var matchingArrival = allSupplyInPRArrival.Where(a => a.SupplyID == id && a.ArrivalDate.Value.Date
            >= start.Date && a.ArrivalDate.Value.Date <= end.Date).ToList();

            if (matchingBalance.Count == 0)
            {
                MessageBox.Show("ไม่มีข้อมูลในช่วงเวลาที่เลือก");
                return;
            }

            // Calculate usage for each period
            for (int i = 1; i < matchingBalance.Count; i++) // Start from the second entry for comparison
            {
                var prevBalance = matchingBalance[i - 1];
                var currentBalance = matchingBalance[i];

                // Find any arrivals between the two balances
                var arrivalsInBetween = matchingArrival.Where(a => a.ArrivalDate.Value.Date > prevBalance.UpdateDate.Date
                                                                  && a.ArrivalDate.Value.Date <= currentBalance.UpdateDate.Date)
                                                        .Sum(a => a.Quantity);  // Sum of arrivals between the two balances

                // Calculate the usage excluding the arrivals
                double usage = (prevBalance.Balance - currentBalance.Balance) - arrivalsInBetween;

                // Only add to the usage series if the usage is positive (i.e., actual usage occurred)
                if (usage > 0)
                {
                    usageSeries.Points.AddXY(currentBalance.UpdateDate, usage);

                    // Add the label on top of the column
                    var lastPointIndex = usageSeries.Points.Count - 1;
                    var lastPoint = usageSeries.Points[lastPointIndex];

                    lastPoint.Label = usage.ToString("0"); // Adding label with no decimals
                    lastPoint.LabelForeColor = Color.Black; // Set label color
                    lastPoint.LabelBackColor = Color.Transparent; // Set label background color
                }
            }
            supplychart.Series.Add(usageSeries);
        }

        private void chartGenbutton_Click(object sender, EventArgs e)
        {
            if (selectedSupplyID > 0)
            {
                if(startdateTimePicker.Value.Date < enddateTimePicker.Value.Date)
                {
                    supplychart.Series.Clear();

                    CreateArrivalSeries(selectedSupplyID, startdateTimePicker.Value.Date, enddateTimePicker.Value.Date);
                    CreateUsageSeries(selectedSupplyID, startdateTimePicker.Value.Date, enddateTimePicker.Value.Date);
                    CreateBalanceSeries(selectedSupplyID,startdateTimePicker.Value.Date,enddateTimePicker.Value.Date);
                }
                else
                {
                    MessageBox.Show("วันที่เริ่ม ไม่สามารถน้อยกว่า วันที่สิ้นสุดได้");
                }
            }
            else
            {
                MessageBox.Show("กรุณาเลือกวัสดุ");
            }
        }
    }
}
