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
    public partial class CreatePlanForm : Form
    {
        public event EventHandler UpdateGrid;

        List<EquipmentType> equipmentTypeList;
        List<PlanType> planTypeList;
        List<PlanPeriod> planPeriodList;
        List<AllEquipmentView> equipmentList;
        List<ObjectClass.Plan> allPlanToCheck = ObjectClass.Plan.GetPlanList();
        ObjectClass.Plan oldPlan;

        Equipment equipmentToCreatePlan;
        PlanType planTypeToCreatePlan;
        PlanPeriod planPeriodToCreatePlan;

        private PictureBox pictureBox;

        private CreateWindow create;
        MainBackGroundFrom main;

        //List for filter equipments
        List<AllEquipmentView> originalEquipmentList;
        List<AllEquipmentView> eqipmentFilteredList;
        private int currentFilterID = -1; // Holds the currently selected filter ID

        BindingSource equipmentListBindingsource;

        List<int> equipmentTypeID = new List<int>();
        List<int> planTypeID = new List<int>();
        List<int> planPeriodID = new List<int>();

        public CreatePlanForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            
            equipmentList = AllEquipmentView.GetAllEquipmentForPlanView();

            equipmentListBindingsource = new BindingSource();

            //--------------------------------------------------------------------------------------------//
            //Create hidden picturebox
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(800, 620),
                Location = new Point(650, 0)
            };
            this.Controls.Add(pictureBox);
            //Register drive event in photo sector
            EquipmentListDataGridView.CellMouseEnter += EquipmentListDataGridView_CellMouseEnter;
            EquipmentListDataGridView.CellMouseLeave += EquipmentListDataGridView_CellMouseLeave;

            UpdateComponents();
            UpdateEquipmentListGridView();
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
            planTypeList = PlanType.GetPlanTypeList();
            planTypeList.Sort((x, y) => x.PType.CompareTo(y.PType));
            pTypecomboBox.Items.Clear();
            planTypeID.Clear();
            foreach (PlanType pty in planTypeList)
            {
                pTypecomboBox.Items.Add(pty.PType);
                planTypeID.Add(pty.ID);
            }
            planPeriodList = PlanPeriod.GetPlanPeriodList();
            planPeriodList.Sort((x, y) => x.PPeriod.CompareTo(y.PPeriod));
            pPeriodcomboBox.Items.Clear();
            planPeriodID.Clear();
            foreach (PlanPeriod ppe in planPeriodList)
            {
                pPeriodcomboBox.Items.Add(ppe.PPeriod);
                planPeriodID.Add(ppe.ID);
            }
        }
        private void UpdateEquipmentListGridView()
        {
            originalEquipmentList = new List<AllEquipmentView>(equipmentList);
            ApplyCurrentFilter();
        }
        private void ApplyCurrentFilter()
        {
            if(currentFilterID < 0)
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
            EquipmentListDataGridView.DataSource = equipmentListBindingsource;

            FormatEquipmentListDataGridView();
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
                var searchResults = eqipmentFilteredList
                    .Where(eq =>
                        eq.Name.ToLower().Contains(searchText) ||
                        eq.Serial.ToLower().Contains(searchText) ||
                        eq.EDetails.ToLower().Contains(searchText) ||
                        eq.EStatus.ToLower().Contains(searchText))
                    .ToList();

                equipmentListBindingsource.DataSource = searchResults;
                EquipmentListDataGridView.DataSource = equipmentListBindingsource;
            }
        }
        //Setting Datagridview looks
        private void FormatEquipmentListDataGridView()
        {
            if(EquipmentListDataGridView.Columns["ID"] != null)
            {
                EquipmentListDataGridView.Columns["ID"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["Name"] != null)
            {
                var customColumn = EquipmentListDataGridView.Columns["Name"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (EquipmentListDataGridView.Columns["Serial"] != null)
            {
                EquipmentListDataGridView.Columns["Serial"].HeaderText = "ชื่อทางบัญชี";
            }
            if (EquipmentListDataGridView.Columns["EDetails"] != null)
            {
                var customColumn = EquipmentListDataGridView.Columns["EDetails"];
                customColumn.HeaderText = "รายละเอียดอุปกรณ์";
                customColumn.Width = 150;
            }
            if (EquipmentListDataGridView.Columns["InsDate"] != null)
            {
                EquipmentListDataGridView.Columns["InsDate"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["EType"] != null)
            {
                EquipmentListDataGridView.Columns["EType"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["EOwner"] != null)
            {
                EquipmentListDataGridView.Columns["EOwner"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["EStatus"] != null)
            {
                var customColumn = EquipmentListDataGridView.Columns["EStatus"];
                customColumn.HeaderText = "สถานะปัจจุบัน";
                customColumn.Width = 90;
            }
            if (EquipmentListDataGridView.Columns["InsDetails"] != null)
            {
                EquipmentListDataGridView.Columns["InsDetails"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["ETypeID"] != null)
            {
                EquipmentListDataGridView.Columns["ETypeID"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["EStatusID"] != null)
            {
                EquipmentListDataGridView.Columns["EStatusID"].Visible = false;
            }
            if (EquipmentListDataGridView.Columns["InstallEPhoto"] != null)
            {
                var customColumn = EquipmentListDataGridView.Columns["InstallEPhoto"];
                customColumn.HeaderText = "ภาพ";
                customColumn.Width = 50;
            }
            if (EquipmentListDataGridView.Columns["EquipmentPhoto"] != null)
            {
                var photoColumn = EquipmentListDataGridView.Columns["EquipmentPhoto"];
                photoColumn.HeaderText = "ภาพ";
                photoColumn.Width = 50;
            }
            if (EquipmentListDataGridView.Columns["Replacement"] != null)
            {
                EquipmentListDataGridView.Columns["Replacement"].Visible = false;
            }
        }
        //Event to add selected Equipment 
        private void EquipmentListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int selectedID = (int)EquipmentListDataGridView.Rows[e.RowIndex].Cells["ID"].Value;

                Global.selectedEquipmentInJob = originalEquipmentList.FirstOrDefault(eq => eq.ID == selectedID);

                if (!string.IsNullOrEmpty(Global.selectedEquipmentInJob.EquipmentPhoto))
                {
                    Global.LoadImageIntoPictureBox(Global.selectedEquipmentInJob.EquipmentPhoto, equipmentPictureBox);
                }
                if (!string.IsNullOrEmpty(Global.selectedEquipmentInJob.InstallEPhoto))
                {
                    Global.LoadImageIntoPictureBox(Global.selectedEquipmentInJob.InstallEPhoto, oPlacepictureBox);
                }
                eNameLabel.Text = Global.selectedEquipmentInJob.Name;
                eSerialLabel.Text = Global.selectedEquipmentInJob.Serial;
                InsPlacelabel.Text = Global.selectedEquipmentInJob.InsDetails;
                eStatusLabel.Text = Global.selectedEquipmentInJob.EStatus;
                EquipmentListDataGridView.Enabled = false;
                pictureBox.Visible = false;
            }
        }
        //Event to remove selected Equipment 
        private void removeSelectedbutton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInJob = null;
            equipmentPictureBox.Image = null;
            oPlacepictureBox.Image = null;
            eNameLabel.Text = "-";
            eSerialLabel.Text = "-";
            InsPlacelabel.Text = "-";
            eStatusLabel.Text = "-";
            EquipmentListDataGridView.Enabled = true;
        }
        // Event to show & hide picturebox
        private void EquipmentListDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = EquipmentListDataGridView.Columns[e.ColumnIndex].Name;
                if (columnName == "EquipmentPhoto"|| columnName == "InstallEPhoto")
                {
                    EquipmentListDataGridView.ShowCellToolTips = false;
                    string imagePath = EquipmentListDataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, pictureBox);
                    pictureBox.Visible = true;
                    pictureBox.BringToFront();

                }
            }
        }
        private void EquipmentListDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            pictureBox.Visible = false;
            EquipmentListDataGridView.ShowCellToolTips = true;
        }
        //Create new plan
        private void createPlanbutton_Click(object sender, EventArgs e)
        {
            bool isCreating = true;
            while (isCreating)
            {
                create = new CreateWindow();
                create.Owner = main;
                if(create.ShowDialog() == DialogResult.OK)
                {
                    string receiveType = create.DetailsText;
                    PlanType newPt = new PlanType(receiveType);
                    if (newPt.Create())
                    {
                        ShowCustomMessageBox("ประเภทแผนใหม่ : " + receiveType);
                        UpdateComponents();
                        isCreating = false;
                    }
                    else
                    {
                        ShowCustomMessageBox("ประเภทแผนนี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
                    }
                    create.DetailsText = string.Empty;
                }
                else
                {
                    isCreating = false;
                }
            }
        }
        //Crate new plan period
        private void createPlanPeriodbutton_Click(object sender, EventArgs e)
        {
            bool isCreating = true;
            while (isCreating)
            {
                create = new CreateWindow();
                create.Owner = main;
                if (create.ShowDialog() == DialogResult.OK)
                {
                    string receiveType = create.DetailsText;
                    PlanPeriod newPpr = new PlanPeriod(receiveType);
                    if (newPpr.Create())
                    {
                        ShowCustomMessageBox("รอบของแผนใหม่ : " + receiveType);
                        UpdateComponents();
                        isCreating = false;
                    }
                    else
                    {
                        ShowCustomMessageBox("รอบของแผนนี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
                    }
                    create.DetailsText = string.Empty;
                }
                else
                {
                    isCreating = false;
                }
            }
        }
        //Call custom message box
        private void ShowCustomMessageBox(string message)
        {
            using (var messageBox = new CustomMessageBox())
            {
                messageBox.MessageText = message;
                var result = messageBox.ShowDialog();
            }
        }
        //Method to check Equipment already has plan
        private bool CheckEquipmentHasPlan(int eid)
        {
            foreach(ObjectClass.Plan p in allPlanToCheck)
            {
                if(p.Eqp.ID == eid)
                {
                    oldPlan = p;
                    return true;
                }
            }
            return false;
        }
        private bool CheckAllAttribute()
        {
            if(Global.selectedEquipmentInJob == null)
            {
                ShowCustomMessageBox("กรุณาเลือกอุปกรณ์ที่ต้องการสร้างแผนซ่อมบำรุง");
                return false;
            }
            else
            {
                equipmentToCreatePlan = new ObjectClass.Equipment(Global.selectedEquipmentInJob.ID);
            }
            int selectTypeIndex = pTypecomboBox.SelectedIndex;
            if (selectTypeIndex>=0&& selectTypeIndex < planTypeID.Count)
            {
                int selectedTypeID = planTypeID[selectTypeIndex];
                planTypeToCreatePlan = new PlanType(selectedTypeID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกประเภทแผน");
                return false;
            }
            int selectPeriodIndex = pPeriodcomboBox.SelectedIndex;
            if (selectPeriodIndex >= 0 && selectPeriodIndex < planPeriodID.Count)
            {
                int selectedPeriodID = planPeriodID[selectPeriodIndex];
                planPeriodToCreatePlan = new PlanPeriod(selectedPeriodID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกระยะเวลาของแผนต่อรอบ");
                return false;
            }
            return true;
        }

        private void recoredPlanButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                //In case of old plan
                if (CheckEquipmentHasPlan(equipmentToCreatePlan.ID))
                {
                    oldPlan.PlanStatus = true;
                    oldPlan.TimesToDo = 0;
                    oldPlan.PType = planTypeToCreatePlan;
                    oldPlan.PPeriod = planPeriodToCreatePlan;
                    oldPlan.DateToDo = dateToDodateTimePicker.Value;
                    if (oldPlan.Change())
                    {
                        if (equipmentToCreatePlan.EStatusObj.ID == 1)
                        {
                            EquipmentStatus newEs = new EquipmentStatus(7);
                            equipmentToCreatePlan.EStatusObj = newEs;
                            equipmentToCreatePlan.OnPlan = true;
                            if (equipmentToCreatePlan.Change())
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์จาก : พร้อมใช้งาน" + Environment.NewLine + "เป็น : พร้อมใช้งาน(อยู่ในแผน)");
                                Close();
                            }
                            else
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว");
                            }
                        }
                        else
                        {
                            EquipmentStatus newEs = new EquipmentStatus(6);
                            equipmentToCreatePlan.EStatusObj = newEs;
                            equipmentToCreatePlan.OnPlan = true;
                            if (equipmentToCreatePlan.Change())
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์จาก : กำลังปฏิบัติงาน"+Environment.NewLine+"เป็น : กำลังปฏิบัติงาน(อยู่ในแผน)");
                                Close();
                            }
                            else
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว");
                            }
                        }

                    }
                    else
                    {
                        ShowCustomMessageBox("ขั้นตอนการสร้างแผนลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                    }
                }
                else
                {
                    //In case of new plan
                    ObjectClass.Plan newP = new ObjectClass.Plan(equipmentToCreatePlan, planTypeToCreatePlan, planPeriodToCreatePlan
                    , 0, true, dateToDodateTimePicker.Value);
                    if (newP.Create())
                    {
                        if (equipmentToCreatePlan.EStatusObj.ID == 1)
                        {
                            EquipmentStatus newEs = new EquipmentStatus(7);
                            equipmentToCreatePlan.EStatusObj = newEs;
                            equipmentToCreatePlan.OnPlan = true;
                            if (equipmentToCreatePlan.Change())
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์จาก : พร้อมใช้งาน" + Environment.NewLine + "เป็น : พร้อมใช้งาน(อยู่ในแผน)");
                                Close();
                            }
                            else
                            {
                                newP.Remove();
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว แผนที่สร้างถูกยกเลิก");
                            }
                        }
                        else
                        {
                            EquipmentStatus newEs = new EquipmentStatus(6);
                            equipmentToCreatePlan.EStatusObj = newEs;
                            equipmentToCreatePlan.OnPlan = true;
                            if (equipmentToCreatePlan.Change())
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์จาก : กำลังปฏิบัติงาน" + Environment.NewLine + "เป็น : กำลังปฏิบัติงาน(อยู่ในแผน)");
                                Close();
                            }
                            else
                            {
                                newP.Remove();
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว แผนที่สร้างถูกยกเลิก");
                            }
                        }
                    }
                    else
                    {
                        ShowCustomMessageBox("ขั้นตอนการสร้างแผนลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                    }
                }
            }
            UpdateGrid?.Invoke(this, EventArgs.Empty);
        }

        private void EquipmentListDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)EquipmentListDataGridView.Rows[e.RowIndex].Cells["EStatusID"].Value;

            Global.SetRowColor(EquipmentListDataGridView.Rows[e.RowIndex], statusID);
        }
    }
}
