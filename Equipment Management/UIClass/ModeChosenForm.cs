using System;
using System.Windows.Forms;

namespace Equipment_Management.UIClass
{
    public partial class ModeChosenForm : Form
    {
        private MainBackGroundFrom _mainBackgroundForm;
        public event EventHandler OnEquipmentControlRequested;

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

        private void CenterToParent()
        {
            if (MdiParent != null)
            {
                this.Left = (MdiParent.ClientSize.Width - this.Width) / 2;
                this.Top = (MdiParent.ClientSize.Height - this.Height) / 2;
            }
        }

        private void ModeChosenForm_Load(object sender, EventArgs e)
        {
            CenterToParent();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            if (m.Msg == WM_SYSCOMMAND && (m.WParam.ToInt32() & 0xFFF0) == SC_MOVE)
            {
                return; // Ignore move messages
            }
            base.WndProc(ref m);
        }
    }
}
