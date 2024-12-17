using Admin_Program.SupplyManagement.UIClass.SupplyManage;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass
{
    public partial class SupplyControlMainForm : Form
    {
        MainBackGroundFrom main;

        private AllSupplyListForm allSupplyList;

        public event EventHandler returnMain;

        public SupplyControlMainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(1450, 780);
        }

        //Supply Manage
        private void manageSupplyButton_Click(object sender, EventArgs e)
        {
            allSupplyList = new AllSupplyListForm();
            allSupplyList.Owner = main;
            allSupplyList.ShowDialog();
        }
        //To Main Menu
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }

    }
}
