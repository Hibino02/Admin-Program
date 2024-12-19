using System;
using System.Windows.Forms;
using Admin_Program.EquipmentManagement.ObjectClass;

namespace Admin_Program.EquipmentManagement.UIClass
{
    public partial class UserLogInWindow : Form
    {
        User user;

        public event EventHandler LoginSuccessful;
        public event EventHandler backToChosen;
        public UserLogInWindow()
        {
            InitializeComponent();
            user = new ObjectClass.User();
        }
        private void logInButton_Click(object sender, EventArgs e)
        {
            if (User.IsUserAvailable(userTextBox.Text))
            {
                if (User.IsPasswordCorrect(passwordTextBox.Text))
                {
                    LoginSuccessful?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("รหัสผ่านผิดพลาด");
                }
            }
            else
            {
                MessageBox.Show("ไม่มี User นี้ในระบบ");
            }
        }
        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (User.IsUserAvailable(userTextBox.Text))
                {
                    if (User.IsPasswordCorrect(passwordTextBox.Text))
                    {
                        LoginSuccessful?.Invoke(this, EventArgs.Empty);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("รหัสผ่านผิดพลาด");
                    }
                }
                else
                {
                    MessageBox.Show("ไม่มี User นี้ในระบบ");
                }
            }
        }

        private void backToChosenFormButton_Click(object sender, EventArgs e)
        {
            backToChosen?.Invoke(this, EventArgs.Empty);
            GlobalVariable.Global.warehouseID = 0;
            this.Close();
        }
    }
}
