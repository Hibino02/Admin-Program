using System;
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
        }

        // Call ModeChosenForm as start
        private void ShowModeChosenForm()
        {
            modeChosenForm = new ModeChosenForm(this);
            modeChosenForm.MdiParent = this;
            modeChosenForm.OnEquipmentControlRequested += ShowEquipmentAndMaintainenceControlForm;
            modeChosenForm.Show();
        }

        private void MainBackGroundFrom_Load(object sender, EventArgs e)
        {
            ShowModeChosenForm();
        }

        private void ShowEquipmentAndMaintainenceControlForm(object sender, EventArgs e)
        {
            equipmentForm = new EquipmentAndMaintainenceControlForm();
            equipmentForm.MdiParent = this;
            equipmentForm.Show();
        }
    }
}
