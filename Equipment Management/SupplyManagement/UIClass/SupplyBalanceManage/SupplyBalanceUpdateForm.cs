using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyBalanceManage
{
    public partial class SupplyBalanceUpdateForm : Form
    {
        SupplyBalance supplyInBalance;
        int currentBalance;
        public SupplyBalanceUpdateForm()
        {
            InitializeComponent();
            this.Size = new Size(760, 175);
            supplyInBalance = new SupplyBalance(GlobalVariable.Global.ID);

            UpdateCurrentSelected();
        }
        private void UpdateCurrentSelected()
        {
            supplyNametextBox.Text = supplyInBalance.Supply.SupplyName;
            moqtextBox.Text = supplyInBalance.Supply.MOQ.ToString();
            sUnittextBox.Text = supplyInBalance.Supply.SupplyUnit;
        }
        //Check
        private bool CheckAttribute()
        {
            if (string.IsNullOrEmpty(currentBalancetextBox.Text))
            {
                MessageBox.Show("กรุณาระบุจำนวนคงเหลือปัจจุบัน");
                return false;
            }
            if (int.TryParse(currentBalancetextBox.Text, out currentBalance))
            {
                if (currentBalance < 0)
                {
                    MessageBox.Show("ค่าที่ระบุไม่สามารถน้อยกว่า 0 ได้");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("กรุณากรอกตัวเลขที่ถูกต้อง");
                return false;
            }
            return true;
        }
        private void createbutton_Click(object sender, EventArgs e)
        {
            if (CheckAttribute())
            {
                DialogResult result = MessageBox.Show("ต้องการบันทึกยอดคงเหลือปัจจุบัน ?","ยืนยัน",
                    MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Supply s = new Supply(supplyInBalance.Supply.ID);
                    SupplyBalance sb = new SupplyBalance(s,currentBalance, updateDatedateTimePicker.Value.Date,GlobalVariable.Global.userName,GlobalVariable.Global.warehouseID);
                    if (sb.Create())
                    {
                        MessageBox.Show("อัฟเดทยอดปัจจุบันเรียบร้อย");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("อัฟเดทยอดปัจจุบันล้มเหลว");
                    }
                }
            }
        }
    }
}
