using System;
using System.Windows.Forms;

namespace Admin_Program.UIClass
{
    public partial class ModeChosenForm : Form
    {
        private MainBackGroundFrom _mainBackgroundForm;
        public event EventHandler OnEquipmentControlRequested;
        public event EventHandler OnSupplyControlREquested;

        public ModeChosenForm(MainBackGroundFrom mainBackGroundForm)
        {
            InitializeComponent();
            _mainBackgroundForm = mainBackGroundForm;
        }

        //Click event to call
        private void equipmentControlButton_Click(object sender, EventArgs e)
        {
            _mainBackgroundForm.Enabled = true;
            OnEquipmentControlRequested?.Invoke(this, EventArgs.Empty);
            this.Close();
        }
        //Click event to call
        private void supplyControlButton_Click(object sender, EventArgs e)
        {
            _mainBackgroundForm.Enabled = true;
            OnSupplyControlREquested?.Invoke(this, EventArgs.Empty);
            this.Close();
        }

        private void ModeChosenForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }  
    }
}
