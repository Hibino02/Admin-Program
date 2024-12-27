namespace Admin_Program.SupplyManagement.UIClass.SupplierManage
{
    partial class CreateSupplierForm
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
            this.createSupplyTypeButton = new System.Windows.Forms.Button();
            this.supplierNameLabel = new System.Windows.Forms.Label();
            this.supplierNametextBox = new System.Windows.Forms.TextBox();
            this.supplierAddressLabel = new System.Windows.Forms.Label();
            this.supplierAddressrichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // createSupplyTypeButton
            // 
            this.createSupplyTypeButton.Location = new System.Drawing.Point(797, 12);
            this.createSupplyTypeButton.Name = "createSupplyTypeButton";
            this.createSupplyTypeButton.Size = new System.Drawing.Size(75, 48);
            this.createSupplyTypeButton.TabIndex = 5;
            this.createSupplyTypeButton.Text = "สร้าง";
            this.createSupplyTypeButton.UseVisualStyleBackColor = true;
            this.createSupplyTypeButton.Click += new System.EventHandler(this.createSupplyTypeButton_Click);
            // 
            // supplierNameLabel
            // 
            this.supplierNameLabel.AutoSize = true;
            this.supplierNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierNameLabel.Location = new System.Drawing.Point(12, 15);
            this.supplierNameLabel.Name = "supplierNameLabel";
            this.supplierNameLabel.Size = new System.Drawing.Size(115, 20);
            this.supplierNameLabel.TabIndex = 4;
            this.supplierNameLabel.Text = "ชื่อซัพพลายเออร์ :";
            // 
            // supplierNametextBox
            // 
            this.supplierNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierNametextBox.Location = new System.Drawing.Point(142, 12);
            this.supplierNametextBox.Name = "supplierNametextBox";
            this.supplierNametextBox.Size = new System.Drawing.Size(614, 26);
            this.supplierNametextBox.TabIndex = 3;
            // 
            // supplierAddressLabel
            // 
            this.supplierAddressLabel.AutoSize = true;
            this.supplierAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierAddressLabel.Location = new System.Drawing.Point(12, 51);
            this.supplierAddressLabel.Name = "supplierAddressLabel";
            this.supplierAddressLabel.Size = new System.Drawing.Size(124, 20);
            this.supplierAddressLabel.TabIndex = 6;
            this.supplierAddressLabel.Text = "ที่อยู่ซัพพลายเออร์ :";
            // 
            // supplierAddressrichTextBox
            // 
            this.supplierAddressrichTextBox.Location = new System.Drawing.Point(142, 53);
            this.supplierAddressrichTextBox.Name = "supplierAddressrichTextBox";
            this.supplierAddressrichTextBox.Size = new System.Drawing.Size(614, 117);
            this.supplierAddressrichTextBox.TabIndex = 7;
            this.supplierAddressrichTextBox.Text = "";
            // 
            // CreateSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 191);
            this.Controls.Add(this.supplierAddressrichTextBox);
            this.Controls.Add(this.supplierAddressLabel);
            this.Controls.Add(this.createSupplyTypeButton);
            this.Controls.Add(this.supplierNameLabel);
            this.Controls.Add(this.supplierNametextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSupplierForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createSupplyTypeButton;
        private System.Windows.Forms.Label supplierNameLabel;
        private System.Windows.Forms.TextBox supplierNametextBox;
        private System.Windows.Forms.Label supplierAddressLabel;
        private System.Windows.Forms.RichTextBox supplierAddressrichTextBox;
    }
}