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

namespace Admin_Program.SupplyManagement.UIClass.SupplyDeliveryPlan
{
    public partial class AllSupplyDiliveryListForm : Form
    {
        CreateSupplyDeliveryPlanForm createSupply;
        MainBackGroundFrom main;
        public AllSupplyDiliveryListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480,820);

            UpdateComponents();
        }
        private void UpdateComponents()
        {

        }

        private void CreateSupplyButton_Click(object sender, EventArgs e)
        {
            createSupply = new CreateSupplyDeliveryPlanForm();
            createSupply.Owner = main;
            createSupply.ShowDialog();
        }
    }
}
