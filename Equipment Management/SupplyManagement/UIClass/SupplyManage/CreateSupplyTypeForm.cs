using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    public partial class CreateSupplyTypeForm : Form
    {
        public event EventHandler onSuccess;
        public CreateSupplyTypeForm()
        {
            InitializeComponent();
            this.Size = new Size(520,120);
        }
        //Create action
        private void createSupplyTypeButton_Click(object sender, EventArgs e)
        {
            SupplyType st = new SupplyType(supplyTypeNametextBox.Text,GlobalVariable.Global.warehouseID);
            if (st.Create())
            {
                MessageBox.Show("สร้างประเภทซัพพลายใหม่แล้ว");
                onSuccess?.Invoke(this,EventArgs.Empty);
                this.Close();
            }
            else
            {
                MessageBox.Show("สร้างประเภทล้มเหลว");
            }
        }
    }
}
