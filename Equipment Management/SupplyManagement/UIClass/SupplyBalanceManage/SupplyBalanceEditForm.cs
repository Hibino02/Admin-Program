using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyBalanceManage
{
    public partial class SupplyBalanceEditForm : Form
    {
        SupplyBalance supplyInBalance;
        int currentBalance;
        public SupplyBalanceEditForm()
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
            currentBalancetextBox.Text = supplyInBalance.Balance.ToString();
            updateDatedateTimePicker.Value = supplyInBalance.UpdateDate == DateTime.MinValue
            ? DateTime.Today // Or any other default valid date
            : supplyInBalance.UpdateDate;
        }
        private bool CheckAttribute()
        {
            if (currentBalancetextBox.Text != supplyInBalance.Balance.ToString() ||
               updateDatedateTimePicker.Value.Date != supplyInBalance.UpdateDate.Date)
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
            }
            return true;
            
        }

        private void createbutton_Click(object sender, EventArgs e)
        {
            if (CheckAttribute())
            {
                supplyInBalance.Balance = currentBalance;
                supplyInBalance.UpdateDate = updateDatedateTimePicker.Value.Date;
                if (supplyInBalance.Change())
                {
                    MessageBox.Show("แก้ใขข้อมูลเรียบร้อย");
                    GlobalVariable.EmailService.SendEmail(supplyInBalance.Supply.SupplyName, supplyInBalance.Balance);
                    MessageBox.Show("ส่งข้อความถึง ผู้ดูแล สมบูรณ์");
                    Close();
                }
            }
        }
    }
}
