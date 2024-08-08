namespace Equipment_Management.UIClass.CreateWindowComponent
{
    partial class CreateWindow
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
            this.createDetailsTextBox = new System.Windows.Forms.TextBox();
            this.createButton = new System.Windows.Forms.Button();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createDetailsTextBox
            // 
            this.createDetailsTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.createDetailsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.createDetailsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createDetailsTextBox.Location = new System.Drawing.Point(145, 31);
            this.createDetailsTextBox.Name = "createDetailsTextBox";
            this.createDetailsTextBox.Size = new System.Drawing.Size(527, 26);
            this.createDetailsTextBox.TabIndex = 0;
            // 
            // createButton
            // 
            this.createButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.createButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createButton.Location = new System.Drawing.Point(568, 72);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(104, 44);
            this.createButton.TabIndex = 1;
            this.createButton.Text = "สร้าง";
            this.createButton.UseVisualStyleBackColor = false;
            this.createButton.Click += new System.EventHandler(this.createButton_Click);
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabel.Location = new System.Drawing.Point(12, 31);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(113, 25);
            this.detailsLabel.TabIndex = 2;
            this.detailsLabel.Text = "รายละเอียด :";
            // 
            // CreateWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 128);
            this.Controls.Add(this.detailsLabel);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.createDetailsTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.TextBox createDetailsTextBox;
        protected System.Windows.Forms.Button createButton;
        private System.Windows.Forms.Label detailsLabel;
    }
}