using System;
using System.Collections.Generic;
using System.Drawing;
using Admin_Program.CustomViewClass;
using System.Windows.Forms;
using Admin_Program.GlobalVariable;
using Admin_Program.ObjectClass;
using System.Linq;

namespace Admin_Program.UIClass.Plan
{
    public partial class PlanHistoryForm : Form
    {
        public event EventHandler UpdateGrid;

        private PictureBox oPlacePictureBox;

        MainBackGroundFrom main;
        private PlanHistoryProgressForm planHistoryProgressForm;

        List<AllPlanView> allPlanHistoryList;

        //Variables for sorted only equipment type available
        List<EquipmentType> etypeList;
        List<EquipmentType> filteredEtypeList;
        List<int> filteredEquipmentTypeID = new List<int>();
        private int currentFilterID = -1;
        //Variable for filtered combobox algorithm
        List<AllPlanView> originalAllPlanHistoryList;
        List<AllPlanView> filteredAllPlanHistoryList;

        BindingSource allPlanHistoryListBindingSource;

        public PlanHistoryForm()
        {
            InitializeComponent();
            this.Size = new Size(1480,820);
            allPlanHistoryListBindingSource = new BindingSource();
            etypeList = EquipmentType.GetEquipmentTypeList();

            //Create hidden picturebox
            oPlacePictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(oPlacePictureBox);
            //Register drive event
            PlanHistoryDatagridview.CellMouseEnter += PlanHistoryDatagridview_CellMouseEnter;
            PlanHistoryDatagridview.CellMouseLeave += PlanHistoryDatagridview_CellMouseLeave;

            UpdatePlanListGridView();
            FilterTypeByPlan();
            UpdateComponents();
        }
        private void FilterTypeByPlan()
        {
            filteredEtypeList = etypeList.Where(allEtype => allPlanHistoryList.Any(plan => plan.ETypeID == allEtype.ID))
                .ToList();
        }
        private void UpdateComponents()
        {
            if(filteredEtypeList.Count != 0)
            {
                filteredEtypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
                equipmentTypeComboBox.Items.Clear();
                filteredEquipmentTypeID.Clear();

                equipmentTypeComboBox.Items.Add("---------------------------------------------------");
                filteredEquipmentTypeID.Add(-1);
                foreach (EquipmentType eqt in filteredEtypeList)
                {
                    equipmentTypeComboBox.Items.Add(eqt.EType);
                    filteredEquipmentTypeID.Add(eqt.ID);
                }
            }
            else
            {
                equipmentTypeComboBox.Items.Clear();
                equipmentTypeComboBox.Items.Add("ไม่มีอุปกรณ์ใดอยู่ในแผน");
            }
        }
        private void UpdatePlanListGridView()
        {
            if (allPlanHistoryList != null)
            {
                allPlanHistoryList.Clear();
            }
            allPlanHistoryList = AllPlanView.GetAllPlanHistoryView();
            originalAllPlanHistoryList = new List<AllPlanView>(allPlanHistoryList);
            ApplyCurrentFilter();
        }
        private void ApplyCurrentFilter()
        {
            int selectedEquipmentTypeID = equipmentTypeComboBox.SelectedIndex > 0 ? filteredEquipmentTypeID[equipmentTypeComboBox.SelectedIndex] : -1;

            filteredAllPlanHistoryList = originalAllPlanHistoryList.Where(eT => (selectedEquipmentTypeID <0 || eT.ETypeID == selectedEquipmentTypeID)).ToList();

            allPlanHistoryListBindingSource.DataSource = filteredAllPlanHistoryList;
            PlanHistoryDatagridview.DataSource = allPlanHistoryListBindingSource;

            FormatPlanHistoryDataGridView();
        }
        private void FormatPlanHistoryDataGridView()
        {
            if (PlanHistoryDatagridview.Columns["ID"] != null)
            {
                PlanHistoryDatagridview.Columns["ID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["EID"] != null)
            {
                PlanHistoryDatagridview.Columns["EID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["EName"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["EName"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (PlanHistoryDatagridview.Columns["ESerial"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["ESerial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
                customColumn.Width = 100;
            }
            if (PlanHistoryDatagridview.Columns["PType"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PType"];
                customColumn.HeaderText = "ประเภทแผน";
                customColumn.Width = 85;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (PlanHistoryDatagridview.Columns["PPeriod"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PPeriod"];
                customColumn.HeaderText = "รอบ";
                customColumn.Width = 70;
            }
            if (PlanHistoryDatagridview.Columns["DateTodo"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["DateTodo"];
                customColumn.HeaderText = "กำหนดการ";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (PlanHistoryDatagridview.Columns["PlanStatus"] != null)
            {
                PlanHistoryDatagridview.Columns["PlanStatus"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["PlanProcessDate"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PlanProcessDate"];
                customColumn.HeaderText = "ครั้งล่าสุด";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
            }
            if (PlanHistoryDatagridview.Columns["EPhoto"] != null)
            {
                PlanHistoryDatagridview.Columns["EPhoto"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["OPlacePhoto"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["OPlacePhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 35;
            }
            if (PlanHistoryDatagridview.Columns["OplaceDetails"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["OplaceDetails"];
                customColumn.HeaderText = "สถานที่ปฎิบัติงาน";
                customColumn.Width = 200;
            }
            if (PlanHistoryDatagridview.Columns["EStatus"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["EStatus"];
                customColumn.HeaderText = "สถานะอุปกรณ์ของแผน";
                customColumn.Width = 140;
            }
            if (PlanHistoryDatagridview.Columns["PPeriodID"] != null)
            {
                PlanHistoryDatagridview.Columns["PPeriodID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["EStatusID"] != null)
            {
                PlanHistoryDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (PlanHistoryDatagridview.Columns["DaysRemainning"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["DaysRemainning"];
                customColumn.HeaderText = "เหลือวัน";
                customColumn.Width = 70;
            }
            if (PlanHistoryDatagridview.Columns["PlanStatusText"] != null)
            {
                var customColumn = PlanHistoryDatagridview.Columns["PlanStatusText"];
                customColumn.HeaderText = "สถานะแผน";
                customColumn.Width = 80;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (PlanHistoryDatagridview.Columns["ETypeID"] != null)
            {
                PlanHistoryDatagridview.Columns["ETypeID"].Visible = false;
            }
        }
        //Event to change Datagridview by selecting ComboBox
        private void equipmentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = equipmentTypeComboBox.SelectedIndex;
            currentFilterID = selectTypeIndex >= 0 ? filteredEquipmentTypeID[selectTypeIndex] : -1;

            ApplyCurrentFilter();
        }
        //Event to pop-up plan progression
        private void PlanHistoryDatagridview_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Global.selectedEquipmentInPlan = null;
            DataGridViewRow selectedRow = PlanHistoryDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                AllPlanView selectedPlan = (AllPlanView)selectedRow.DataBoundItem;
                Global.selectedEquipmentInPlan = selectedPlan;
                planHistoryProgressForm = new PlanHistoryProgressForm();
                planHistoryProgressForm.Owner = main;
                planHistoryProgressForm.ShowDialog();
            }
        }
        //Painting row
        private void PlanHistoryDatagridview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            bool statusID = (bool)PlanHistoryDatagridview.Rows[e.RowIndex].Cells["PlanStatus"].Value;

            if (statusID)
            {
                PlanHistoryDatagridview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.GreenYellow;
            }
            else
            {
                PlanHistoryDatagridview.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
        }
        //Event to drive picturebox
        private void PlanHistoryDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = PlanHistoryDatagridview.Columns[e.ColumnIndex].Name;
                if (columnName == "OPlacePhoto")
                {
                    PlanHistoryDatagridview.ShowCellToolTips = false;
                    string imagePath = PlanHistoryDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, oPlacePictureBox);
                    oPlacePictureBox.Visible = true;
                    oPlacePictureBox.BringToFront();

                }
            }
        }
        private void PlanHistoryDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            PlanHistoryDatagridview.ShowCellToolTips = true;
            oPlacePictureBox.Visible = false;
        }
        //Searching text alrorithm
        private void equipmentListSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = equipmentListSearchTextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentFilter(); // Reapply the current filter if the search box is empty
            }
            else
            {
                // Filter the already filtered list based on the search text
                var searchResults = filteredAllPlanHistoryList
                    .Where(eq =>
                        eq.EName.ToLower().Contains(searchText) ||
                        eq.ESerial.ToLower().Contains(searchText) ||
                        eq.PType.ToLower().Contains(searchText) ||
                        eq.PPeriod.ToLower().Contains(searchText) ||
                        eq.OplaceDetails.ToLower().Contains(searchText) ||
                        eq.DaysRemainning.ToString().Contains(searchText) ||
                        eq.EStatus.ToLower().Contains(searchText))
                    .ToList();

                allPlanHistoryListBindingSource.DataSource = searchResults;
                PlanHistoryDatagridview.DataSource = allPlanHistoryListBindingSource;
            }
        }
    }
}
