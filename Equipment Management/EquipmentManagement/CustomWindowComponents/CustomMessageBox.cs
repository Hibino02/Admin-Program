using System;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.CustomWindowComponents
{
    public partial class CustomMessageBox : Form
    {
        public CustomMessageBox()
        {
            InitializeComponent();
            this.Size = new Size(747, 267);
            this.Resize += CustomMessageBox_Resize;
            CenterLabel();
        }
        private void CenterLabel()
        {
            textLabel.AutoSize = true;
            textLabel.TextAlign = ContentAlignment.MiddleCenter;

            // Center the label horizontally and vertically
            textLabel.Left = (this.ClientSize.Width - textLabel.Width) / 2;
            textLabel.Top = (this.ClientSize.Height - textLabel.Height) / 2;
        }

        string messageText;
        public string MessageText
        {
            get
            {
                return messageText;
            }
            set
            {
                messageText = value;
                textLabel.Text = value;
            }
        }
        private void CustomMessageBox_Resize(object sender, EventArgs e)
        {
            CenterLabel();
        }
        

        private void OKButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CustomMessageBox_Load(object sender, EventArgs e)
        {
            this.Resize += CustomMessageBox_Resize;
        }
    }
}
