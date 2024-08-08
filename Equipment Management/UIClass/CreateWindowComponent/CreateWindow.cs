using System;
using System.Windows.Forms;

namespace Equipment_Management.UIClass.CreateWindowComponent
{
    public partial class CreateWindow : Form
    {
        public string DetailsText { get; set; }
        public CreateWindow()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            DetailsText = createDetailsTextBox.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
