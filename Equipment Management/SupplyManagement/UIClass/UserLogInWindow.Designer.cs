namespace Admin_Program.SupplyManagement.UIClass
{
    partial class UserLogInWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.logInButton = new System.Windows.Forms.Button();
            this.backToChosenFormButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userTextBox
            // 
            this.userTextBox.Location = new System.Drawing.Point(91, 32);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(156, 20);
            this.userTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(91, 72);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(156, 20);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            this.passwordTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passwordTextBox_KeyPress);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(50, 35);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(35, 13);
            this.userNameLabel.TabIndex = 2;
            this.userNameLabel.Text = "User :";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(26, 75);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(59, 13);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Password :";
            // 
            // logInButton
            // 
            this.logInButton.Location = new System.Drawing.Point(263, 32);
            this.logInButton.Name = "logInButton";
            this.logInButton.Size = new System.Drawing.Size(75, 60);
            this.logInButton.TabIndex = 4;
            this.logInButton.Text = "เข้าสู่ระบบ";
            this.logInButton.UseVisualStyleBackColor = true;
            this.logInButton.Click += new System.EventHandler(this.logInButton_Click);
            // 
            // backToChosenFormButton
            // 
            this.backToChosenFormButton.Location = new System.Drawing.Point(344, 32);
            this.backToChosenFormButton.Name = "backToChosenFormButton";
            this.backToChosenFormButton.Size = new System.Drawing.Size(75, 60);
            this.backToChosenFormButton.TabIndex = 5;
            this.backToChosenFormButton.Text = "ย้อนกลับ";
            this.backToChosenFormButton.UseVisualStyleBackColor = true;
            this.backToChosenFormButton.Click += new System.EventHandler(this.backToChosenFormButton_Click);
            // 
            // UserLogInWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 126);
            this.ControlBox = false;
            this.Controls.Add(this.backToChosenFormButton);
            this.Controls.Add(this.logInButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserLogInWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กรุณาระบุตัวตน";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button logInButton;
        private System.Windows.Forms.Button backToChosenFormButton;
    }
}