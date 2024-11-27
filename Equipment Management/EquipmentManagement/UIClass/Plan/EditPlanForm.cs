using System;
using System.Collections.Generic;
using System.Drawing;
using Admin_Program.ObjectClass;
using System.Windows.Forms;
using Admin_Program.CustomViewClass;
using Admin_Program.GlobalVariable;
using Admin_Program.UIClass.CreateWindowComponent;
using Admin_Program.CustomWindowComponents;

namespace Admin_Program.UIClass.Plan
{
    public partial class EditPlanForm : Form
    {
        public event EventHandler UpdateGrid;

        CreateWindow create;
        MainBackGroundFrom main;

        List<PlanPeriod> planPeriodList;

        AllEquipmentView equipmentToEdit;
        PlanPeriod planPeriodToCreatePlan;
        ObjectClass.Plan ePlan;

        List<int> planPeriodID = new List<int>();

        public EditPlanForm()
        {
            InitializeComponent();
            this.Size = new Size(837, 820);
            ePlan = new ObjectClass.Plan(Global.selectedEquipmentInPlan.ID);

            UpdateComponents();
            UpdateEquipmentOnPlan();
        }

        private void UpdateComponents()
        {
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
        private void UpdateEquipmentOnPlan()
        {
            pTypecomboBox.Text = Global.selectedEquipmentInPlan.PType;
            pPeriodcomboBox.Text = Global.selectedEquipmentInPlan.PPeriod;
            dateToDodateTimePicker.Value = Global.selectedEquipmentInPlan.DateTodo;
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInPlan.EPhoto))
            {
                Global.LoadImageIntoPictureBox(Global.selectedEquipmentInPlan.EPhoto, equipmentPictureBox);
            }
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInPlan.OPlacePhoto))
            {
                Global.LoadImageIntoPictureBox(Global.selectedEquipmentInPlan.OPlacePhoto, oPlacepictureBox);
            }
            eNameLabel.Text = Global.selectedEquipmentInPlan.EName;
            eSerialLabel.Text = Global.selectedEquipmentInPlan.ESerial;
            InsPlacelabel.Text = Global.selectedEquipmentInPlan.OplaceDetails;
            eStatusLabel.Text = Global.selectedEquipmentInPlan.EStatus;
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

        private bool CheckAllAttribute()
        {
            int selectPeriodIndex = pPeriodcomboBox.SelectedIndex;
            int selectedPeriodID = planPeriodID[selectPeriodIndex];
            if (selectedPeriodID != ePlan.PPeriod.ID)
            {
                string selectedPeriodText = pPeriodcomboBox.SelectedItem?.ToString();
                planPeriodToCreatePlan = new PlanPeriod(selectedPeriodID);
                ePlan.PPeriod = planPeriodToCreatePlan;
            }
            return true;
        }

        private void recoredPlanButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                ePlan.DateToDo = dateToDodateTimePicker.Value;
                if (ePlan.Change())
                {
                    ShowCustomMessageBox("ปรับปรุงแผนเสร็จสมบูรณ์");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Global.selectedEquipmentInPlan = null;
                    Close();
                }
                else
                {
                    ShowCustomMessageBox("ปรับปรุงแผนล้มเหลว ไม่สามารถบันทึก");
                }
            }
        }
    }


}
