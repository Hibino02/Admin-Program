using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    public partial class EditSupplyTypeForm : Form
    {
        public event EventHandler onSuccess;

        SupplyType supplyType;
        public EditSupplyTypeForm()
        {
            InitializeComponent();
            this.Size = new Size(520,120);
            supplyType = new SupplyType(GlobalVariable.Global.ID);
            supplyTypeNametextBox.Text = supplyType.TypeName;
        }
        //Edit action
        private void editSupplyTypeButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(supplyType.TypeName))
            {
                supplyType.TypeName = supplyTypeNametextBox.Text;
                if (supplyType.Change())
                {
                    MessageBox.Show("แก้ใขเสร็จสิ้น");
                    onSuccess?.Invoke(this,EventArgs.Empty);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("แก้ใขล้มเหลว");
                }
            }
        }
    }
}
