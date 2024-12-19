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
            if (User.IsLoginSuccess(userTextBox.Text,passwordTextBox.Text))
            {
                LoginSuccessful?.Invoke(this, EventArgs.Empty);
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
                    LoginSuccessful?.Invoke(this, EventArgs.Empty);
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
            GlobalVariable.Global.warehouseID = 0;
            this.Close();
        }
    }
}
