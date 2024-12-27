using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplierManage
{
    public partial class EditSupplierForm : Form
    {
        public event EventHandler UpdateGrid;

        Supplier supplier;

        public EditSupplierForm()
        {
            InitializeComponent();
            this.Size = new Size(900, 230);
            supplier = new Supplier(Global.ID);

            SetSelectedSupplierToView();
        }

        private void SetSelectedSupplierToView()
        {
            supplierNametextBox.Text = supplier.Name;
            supplierAddressrichTextBox.Text = supplier.Address;
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

        private void createSupplyTypeButton_Click(object sender, EventArgs e)
        {
            if (CheckAllArrtibute())
            {
                supplier.Name = supplierNametextBox.Text;
                supplier.Address = supplierAddressrichTextBox.Text;
                if (supplier.Change())
                {
                    MessageBox.Show("แก้ใขข้อมูล เรียบร้อย");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
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
