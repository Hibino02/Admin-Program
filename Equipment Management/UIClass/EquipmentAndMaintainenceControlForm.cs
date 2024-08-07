using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Equipment_Management.UIClass
{
    public partial class EquipmentAndMaintainenceControlForm : Form
    {
        MainBackGroundFrom main;

        public event EventHandler returnMain;

        public EquipmentAndMaintainenceControlForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(1450, 760);
        }

        private void EquipmentAndMaintainenceControlForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
