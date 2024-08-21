using System;
using System.Collections.Generic;
using System.Drawing;
using Equipment_Management.ObjectClass;
using System.Windows.Forms;
using Equipment_Management.CustomViewClass;
using System.Linq;
using Equipment_Management.GlobalVariable;
using Equipment_Management.UIClass.CreateWindowComponent;
using Equipment_Management.CustomWindowComponents;

namespace Equipment_Management.UIClass.Plan
{
    public partial class PlanProcessingForm : Form
    {
        public event EventHandler UpdateGrid;

        List<EquipmentType> equipmentTypeList;
        List<int> equipmentTypeID = new List<int>();
        //List for filter equipments 
        List<AllEquipmentView> equipmentList;
        List<AllEquipmentView> originalEquipmentList;
        List<AllEquipmentView> eqipmentFilteredList;
        private int currentFilterID = -1; // Holds the currently selected filter ID

        BindingSource equipmentListBindingsource;

        public PlanProcessingForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentList = AllEquipmentView.GetPlanProcessReplaceEquipmentView();

            equipmentListBindingsource = new BindingSource();

            UpdateComponents();
            UpdateEquipmentOnPlan();
            UpdateReplaceEquipmentListGridView();
        }

        private void UpdateComponents()
        {
            //Equipment type components
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            equipmentTypeComboBox.Items.Clear();
            equipmentTypeComboBox.Items.Add("--------------------------------------");
            equipmentTypeID.Add(-1);
            foreach (EquipmentType etype in equipmentTypeList)
            {
                equipmentTypeComboBox.Items.Add(etype.EType);
                equipmentTypeID.Add(etype.ID);
            }
        }
        private void UpdateEquipmentOnPlan()
        {
            eNamelabel.Text = Global.selectedEquipmentInPlan.EName;
            eSeriallabel.Text = Global.selectedEquipmentInPlan.ESerial;
            Global.LoadImageIntoPictureBox(Global.selectedEquipmentInPlan.EPhoto, equipmentpictureBox);
        }
        private void UpdateReplaceEquipmentListGridView()
        {
            originalEquipmentList = new List<AllEquipmentView>(equipmentList);
            ApplyCurrentFilter();
        }
        private void ApplyCurrentFilter()
        {
            if (currentFilterID < 0)
            {
                eqipmentFilteredList = new List<AllEquipmentView>(originalEquipmentList);
            }
            else
            {
                eqipmentFilteredList = originalEquipmentList
                    .Where(eq => eq.ETypeID == currentFilterID)
                    .ToList();
            }
            equipmentListBindingsource.DataSource = eqipmentFilteredList;
            rEquipmentListDataGridView.DataSource = equipmentListBindingsource;

            FormatEquipmentListDataGridView();
        }
        //Setting Datagridview looks
        private void FormatEquipmentListDataGridView()
        {
            if (rEquipmentListDataGridView.Columns["ID"] != null)
            {
                rEquipmentListDataGridView.Columns["ID"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["Name"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["Name"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 250;
            }
            if (rEquipmentListDataGridView.Columns["Serial"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["Serial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
                customColumn.Width = 150;
            }
            if (rEquipmentListDataGridView.Columns["EDetails"] != null)
            {
                rEquipmentListDataGridView.Columns["EDetails"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["InsDate"] != null)
            {
                rEquipmentListDataGridView.Columns["InsDate"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EType"] != null)
            {
                rEquipmentListDataGridView.Columns["EType"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EOwner"] != null)
            {
                rEquipmentListDataGridView.Columns["EOwner"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EStatus"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["EStatus"];
                customColumn.HeaderText = "สถานะปัจจุบัน";
                customColumn.Width = 130;
            }
            if (rEquipmentListDataGridView.Columns["InsDetails"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["InsDetails"];
                customColumn.HeaderText = "รายละเอียดจุดที่ติดตั้ง";
                customColumn.Width = 220;
            }
            if (rEquipmentListDataGridView.Columns["ETypeID"] != null)
            {
                rEquipmentListDataGridView.Columns["ETypeID"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EStatusID"] != null)
            {
                rEquipmentListDataGridView.Columns["EStatusID"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["InstallEPhoto"] != null)
            {
                rEquipmentListDataGridView.Columns["InstallEPhoto"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EquipmentPhoto"] != null)
            {
                rEquipmentListDataGridView.Columns["EquipmentPhoto"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["Replacement"] != null)
            {
                rEquipmentListDataGridView.Columns["Replacement"].Visible = false;
            }
        }
        //Event to filter by Equipment Type
        private void equipmentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = equipmentTypeComboBox.SelectedIndex;
            currentFilterID = selectTypeIndex >= 0 ? equipmentTypeID[selectTypeIndex] : -1;

            ApplyCurrentFilter();
        }
        private void equipmentTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            // Temporarily unsubscribe from the TextChanged event to avoid recursion
            equipmentTypeComboBox.TextChanged -= equipmentTypeComboBox_TextChanged;

            string typedText = equipmentTypeComboBox.Text;
            int currentCaretPosition = equipmentTypeComboBox.SelectionStart;

            // Filter items that start with the typed text
            var matchingItems = equipmentTypeComboBox.Items.Cast<string>()
                                         .Where(item => item.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                                         .ToList();

            // Only suggest and highlight if the user is typing and a match is found
            if (matchingItems.Any() && !string.IsNullOrEmpty(typedText))
            {
                string selectedItem = matchingItems.First();

                // Update the text and highlight the matching part only if the typed text is less than the selected item
                if (typedText.Length < selectedItem.Length && selectedItem.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                {
                    equipmentTypeComboBox.Text = selectedItem;
                    equipmentTypeComboBox.SelectionStart = currentCaretPosition;
                    equipmentTypeComboBox.SelectionLength = selectedItem.Length - typedText.Length;
                }
            }
            else
            {
                // If no match found or text is empty, keep the typed text
                equipmentTypeComboBox.Text = typedText;
                equipmentTypeComboBox.SelectionStart = currentCaretPosition;
                equipmentTypeComboBox.SelectionLength = 0;
            }

            // Re-subscribe to the TextChanged event
            equipmentTypeComboBox.TextChanged += equipmentTypeComboBox_TextChanged;
        }
        private void eSearchtextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = eSearchtextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentFilter(); // Reapply the current filter if the search box is empty
            }
            else
            {
                // Filter the already filtered list based on the search text
                var searchResults = eqipmentFilteredList
                    .Where(eq =>
                        eq.Name.ToLower().Contains(searchText) ||
                        eq.Serial.ToLower().Contains(searchText) ||
                        eq.InsDetails.ToLower().Contains(searchText))
                    .ToList();

                equipmentListBindingsource.DataSource = searchResults;
                rEquipmentListDataGridView.DataSource = equipmentListBindingsource;
            }
        }
        //Event to add and remove replacement equipment
        private void rEquipmentListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int selectedID = (int)rEquipmentListDataGridView.Rows[e.RowIndex].Cells["ID"].Value;
                Global.selectedEquipmentInJob = null;
                Global.selectedEquipmentInJob = originalEquipmentList.FirstOrDefault(eq => eq.ID == selectedID);

                eReplaceNamelabel.Text = Global.selectedEquipmentInJob.Name;
                eSeriallabel.Text = Global.selectedEquipmentInJob.Serial;
                rEquipmentListDataGridView.Enabled = false;
            }
        }
        private void removeSelectedbutton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInJob = null;
            eReplaceNamelabel.Text = "-";
            eSeriallabel.Text = "-";
            rEquipmentListDataGridView.Enabled = true;
        }
    }
}
