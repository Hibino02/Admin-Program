using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplierManage
{
    public partial class CreateSupplierForm : Form
    {
        MainBackGroundFrom main;

        public CreateSupplierForm()
        {
            InitializeComponent();
            this.Size = new Size(900, 230);
        }
        private bool CheckAllArrtibute()
        {
            bool isComplete = true;
            if (string.IsNullOrEmpty(supplierNametextBox.Text))
            {
                MessageBox.Show("กรุณาใส่ ชื่อซัพพลายเออร์");
                isComplete = false;
            }
            if (string.IsNullOrEmpty(supplierAddressrichTextBox.Text))
            {
                MessageBox.Show("กรุณาใส่ ที่อยู่ซัพพลายเออร์");
                isComplete = false;
            }
            return isComplete;
        }
        //Create supplier
        private void createSupplyTypeButton_Click(object sender, EventArgs e)
        {
            if (CheckAllArrtibute())
            {
                string supplierAddress = supplierAddressrichTextBox.Text;
                Supplier sup = new Supplier(supplierNametextBox.Text, supplierAddress, Global.warehouseID);
                if (sup.Create())
                {
                    MessageBox.Show("ซัพพลายเออร์ถูกสร้างเรียบร้อย");
                    Close();
                }
                else
                {
                    MessageBox.Show("ขั้นตอนการสร้างข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
    }
}
