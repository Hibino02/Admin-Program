namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    partial class EditSupplyTypeForm
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
            this.editSupplyTypeButton = new System.Windows.Forms.Button();
            this.supplyTypeLabel = new System.Windows.Forms.Label();
            this.supplyTypeNametextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // editSupplyTypeButton
            // 
            this.editSupplyTypeButton.Location = new System.Drawing.Point(412, 16);
            this.editSupplyTypeButton.Name = "editSupplyTypeButton";
            this.editSupplyTypeButton.Size = new System.Drawing.Size(75, 48);
            this.editSupplyTypeButton.TabIndex = 5;
            this.editSupplyTypeButton.Text = "แก้ใข";
            this.editSupplyTypeButton.UseVisualStyleBackColor = true;
            this.editSupplyTypeButton.Click += new System.EventHandler(this.editSupplyTypeButton_Click);
            // 
            // supplyTypeLabel
            // 
            this.supplyTypeLabel.AutoSize = true;
            this.supplyTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyTypeLabel.Location = new System.Drawing.Point(17, 32);
            this.supplyTypeLabel.Name = "supplyTypeLabel";
            this.supplyTypeLabel.Size = new System.Drawing.Size(81, 20);
            this.supplyTypeLabel.TabIndex = 4;
            this.supplyTypeLabel.Text = "ประเภทวัสดุ";
            // 
            // supplyTypeNametextBox
            // 
            this.supplyTypeNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyTypeNametextBox.Location = new System.Drawing.Point(104, 26);
            this.supplyTypeNametextBox.Name = "supplyTypeNametextBox";
            this.supplyTypeNametextBox.Size = new System.Drawing.Size(268, 26);
            this.supplyTypeNametextBox.TabIndex = 3;
            // 
            // EditSupplyTypeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(504, 81);
            this.Controls.Add(this.editSupplyTypeButton);
            this.Controls.Add(this.supplyTypeLabel);
            this.Controls.Add(this.supplyTypeNametextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSupplyTypeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editSupplyTypeButton;
        private System.Windows.Forms.Label supplyTypeLabel;
        private System.Windows.Forms.TextBox supplyTypeNametextBox;
    }
}