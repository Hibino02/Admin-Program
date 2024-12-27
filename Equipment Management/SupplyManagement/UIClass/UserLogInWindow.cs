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
            if (User.IsLoginSuccess(userTextBox.Text, passwordTextBox.Text))
            {
                LoginSuccessful.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("ยูสเซอร์หรือพาสเวิร์ดผิดพลาด");
            }
        }
        private void passwordTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (User.IsLoginSuccess(userTextBox.Text, passwordTextBox.Text))
                {
                    LoginSuccessful.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show("ยูสเซอร์หรือพาสเวิร์ดผิดพลาด");
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
