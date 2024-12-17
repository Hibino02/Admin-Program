using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass
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
            this.Close();
        }
    }
}
