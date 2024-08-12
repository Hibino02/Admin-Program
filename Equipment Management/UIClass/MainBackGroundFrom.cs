using System;
using System.Drawing;
using System.Windows.Forms;

namespace Equipment_Management.UIClass
{
    public partial class MainBackGroundFrom : Form
    {
        ModeChosenForm modeChosenForm;
        EquipmentAndMaintainenceControlForm equipmentForm;

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
        (this.ClientSize.Height - modeChosenForm.Size.Height) / 2
    );
            modeChosenForm.OnEquipmentControlRequested += ShowEquipmentAndMaintainenceControlForm;
            modeChosenForm.Show();
        }
        private void ShowEquipmentAndMaintainenceControlForm(object sender, EventArgs e)
        {
            equipmentForm = new EquipmentAndMaintainenceControlForm();
            equipmentForm.MdiParent = this;
            equipmentForm.Dock = DockStyle.Fill;
            equipmentForm.Show();
            equipmentForm.returnMain += backToMainMenu;
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
