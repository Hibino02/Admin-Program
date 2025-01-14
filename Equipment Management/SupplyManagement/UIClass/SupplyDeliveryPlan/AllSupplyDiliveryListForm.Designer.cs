namespace Admin_Program.SupplyManagement.UIClass.SupplyDeliveryPlan
{
    partial class AllSupplyDiliveryListForm
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
            this.planNameSearchLabel = new System.Windows.Forms.Label();
            this.RemoveSupplyButton = new System.Windows.Forms.Button();
            this.EditSupplyButton = new System.Windows.Forms.Button();
            this.CreateSupplyButton = new System.Windows.Forms.Button();
            this.SupplierDatagridview = new System.Windows.Forms.DataGridView();
            this.planNameSearchtextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // planNameSearchLabel
            // 
            this.planNameSearchLabel.AutoSize = true;
            this.planNameSearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.planNameSearchLabel.Location = new System.Drawing.Point(11, 11);
            this.planNameSearchLabel.Name = "planNameSearchLabel";
            this.planNameSearchLabel.Size = new System.Drawing.Size(111, 20);
            this.planNameSearchLabel.TabIndex = 29;
            this.planNameSearchLabel.Text = "ค้นหาแผนจากชื่อ";
            // 
            // RemoveSupplyButton
            // 
            this.RemoveSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSupplyButton.Location = new System.Drawing.Point(1330, 156);
            this.RemoveSupplyButton.Name = "RemoveSupplyButton";
            this.RemoveSupplyButton.Size = new System.Drawing.Size(124, 52);
            this.RemoveSupplyButton.TabIndex = 28;
            this.RemoveSupplyButton.Text = "ลบ";
            this.RemoveSupplyButton.UseVisualStyleBackColor = true;
            // 
            // EditSupplyButton
            // 
            this.EditSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSupplyButton.Location = new System.Drawing.Point(1330, 98);
            this.EditSupplyButton.Name = "EditSupplyButton";
            this.EditSupplyButton.Size = new System.Drawing.Size(124, 52);
            this.EditSupplyButton.TabIndex = 27;
            this.EditSupplyButton.Text = "แก้ใข";
            this.EditSupplyButton.UseVisualStyleBackColor = true;
            // 
            // CreateSupplyButton
            // 
            this.CreateSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateSupplyButton.Location = new System.Drawing.Point(1330, 40);
            this.CreateSupplyButton.Name = "CreateSupplyButton";
            this.CreateSupplyButton.Size = new System.Drawing.Size(124, 52);
            this.CreateSupplyButton.TabIndex = 26;
            this.CreateSupplyButton.Text = "สร้าง";
            this.CreateSupplyButton.UseVisualStyleBackColor = true;
            this.CreateSupplyButton.Click += new System.EventHandler(this.CreateSupplyButton_Click);
            // 
            // SupplierDatagridview
            // 
            this.SupplierDatagridview.AllowUserToAddRows = false;
            this.SupplierDatagridview.AllowUserToDeleteRows = false;
            this.SupplierDatagridview.AllowUserToResizeColumns = false;
            this.SupplierDatagridview.AllowUserToResizeRows = false;
            this.SupplierDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierDatagridview.Location = new System.Drawing.Point(14, 40);
            this.SupplierDatagridview.MultiSelect = false;
            this.SupplierDatagridview.Name = "SupplierDatagridview";
            this.SupplierDatagridview.ReadOnly = true;
            this.SupplierDatagridview.RowHeadersVisible = false;
            this.SupplierDatagridview.RowTemplate.Height = 24;
            this.SupplierDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplierDatagridview.Size = new System.Drawing.Size(1310, 730);
            this.SupplierDatagridview.TabIndex = 25;
            // 
            // planNameSearchtextBox
            // 
            this.planNameSearchtextBox.Location = new System.Drawing.Point(128, 11);
            this.planNameSearchtextBox.Name = "planNameSearchtextBox";
            this.planNameSearchtextBox.Size = new System.Drawing.Size(384, 20);
            this.planNameSearchtextBox.TabIndex = 30;
            // 
            // AllSupplyDiliveryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.planNameSearchtextBox);
            this.Controls.Add(this.planNameSearchLabel);
            this.Controls.Add(this.RemoveSupplyButton);
            this.Controls.Add(this.EditSupplyButton);
            this.Controls.Add(this.CreateSupplyButton);
            this.Controls.Add(this.SupplierDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllSupplyDiliveryListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายการแผนวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label planNameSearchLabel;
        private System.Windows.Forms.Button RemoveSupplyButton;
        private System.Windows.Forms.Button EditSupplyButton;
        private System.Windows.Forms.Button CreateSupplyButton;
        private System.Windows.Forms.DataGridView SupplierDatagridview;
        private System.Windows.Forms.TextBox planNameSearchtextBox;
    }
}