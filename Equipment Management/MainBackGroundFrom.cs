using Admin_Program.SupplyManagement.UIClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.UIClass
{
    public partial class MainBackGroundFrom : Form
    {
        ModeChosenForm modeChosenForm;
        EquipmentAndMaintainenceControlForm equipmentForm;
        SupplyControlMainForm supplyForm;
        UserLogInWindow logInForm;
        Admin_Program.EquipmentManagement.UIClass.UserLogInWindow logInEquipmentForm;

        public MainBackGroundFrom()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
        }

        private void MainBackGroundFrom_Load(object sender, EventArgs e)
        {
            ShowModeChosenForm();
        }
        // Call ModeChosenForm as start
        private void ShowModeChosenForm()
        {
            modeChosenForm = new ModeChosenForm(this);
            modeChosenForm.MdiParent = this;
            modeChosenForm.Location = new Point(
        (this.ClientSize.Width - modeChosenForm.Size.Width) / 2,
        (this.ClientSize.Height - modeChosenForm.Size.Height) / 2);
            modeChosenForm.OnEquipmentControlRequested += LogInForEquipment;
            modeChosenForm.OnSupplyControlREquested += LogInForSupply;
            modeChosenForm.Show();
        }
        //Call MainControlForm for Equipment
        private void ShowEquipmentAndMaintainenceControlForm(object sender, EventArgs e)
        {
            equipmentForm = new EquipmentAndMaintainenceControlForm();
            equipmentForm.MdiParent = this;
            equipmentForm.Dock = DockStyle.Fill;
            equipmentForm.Show();
            equipmentForm.returnMain += backToMainMenu;
        }
        //Call MainControlForm for Supply
        private void ShowSupplyControlForm(object sender, EventArgs e)
        {
            supplyForm = new SupplyControlMainForm();
            supplyForm.MdiParent = this;
            supplyForm.Dock = DockStyle.Fill;
            supplyForm.Show();
            supplyForm.returnMain += backToMainMenu;
        }
        //Call user login for Supply
        private void LogInForSupply(object sender, EventArgs e)
        {
            logInForm = new SupplyManagement.UIClass.UserLogInWindow
            {
                MdiParent = this
            };
            // Center the child form relative to the parent
            logInForm.StartPosition = FormStartPosition.Manual; // Set to manual positioning
            logInForm.Location = new Point(
                (this.ClientSize.Width - logInForm.Width) / 2,
                (this.ClientSize.Height - logInForm.Height) / 2
            );
            logInForm.Show();
            logInForm.LoginSuccessful += ShowSupplyControlForm;
            logInForm.backToChosen += backToMainMenu;
        }
        //Call user login for Equipment
        private void LogInForEquipment(object sender, EventArgs e)
        {
            logInEquipmentForm = new EquipmentManagement.UIClass.UserLogInWindow
            {
                MdiParent = this
            };
            // Center the child form relative to the parent
            logInEquipmentForm.StartPosition = FormStartPosition.Manual;
            logInEquipmentForm.Location = new Point(
                (this.ClientSize.Width - logInEquipmentForm.Width) / 2,
                (this.ClientSize.Height - logInEquipmentForm.Height) / 2
            );
            logInEquipmentForm.Show();
            logInEquipmentForm.LoginSuccessful += ShowEquipmentAndMaintainenceControlForm;
            logInEquipmentForm.backToChosen += backToMainMenu;
        }
        private void backToMainMenu(object sender, EventArgs e)
        {
            ShowModeChosenForm();
        }

        private void MainBackGroundFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prompt the user with a MessageBox
            DialogResult result = MessageBox.Show("ต้องการออกจากโปรแกรม ใช่หรือไม่?",
                                                  "ยืนยันการออกจากโปรแกรม",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Question);

            // If the user clicks 'No', cancel the close operation
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
