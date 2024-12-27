namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    partial class AllSupplyListForm
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
            this.SupplyInventoryDatagridview = new System.Windows.Forms.DataGridView();
            this.CreateSupplyButton = new System.Windows.Forms.Button();
            this.EditSupplyButton = new System.Windows.Forms.Button();
            this.RemoveSupplyButton = new System.Windows.Forms.Button();
            this.supplyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.searchSupplyTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyInventoryDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // SupplyInventoryDatagridview
            // 
            this.SupplyInventoryDatagridview.AllowUserToAddRows = false;
            this.SupplyInventoryDatagridview.AllowUserToDeleteRows = false;
            this.SupplyInventoryDatagridview.AllowUserToResizeColumns = false;
            this.SupplyInventoryDatagridview.AllowUserToResizeRows = false;
            this.SupplyInventoryDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplyInventoryDatagridview.Location = new System.Drawing.Point(12, 39);
            this.SupplyInventoryDatagridview.MultiSelect = false;
            this.SupplyInventoryDatagridview.Name = "SupplyInventoryDatagridview";
            this.SupplyInventoryDatagridview.ReadOnly = true;
            this.SupplyInventoryDatagridview.RowHeadersVisible = false;
            this.SupplyInventoryDatagridview.RowTemplate.Height = 24;
            this.SupplyInventoryDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplyInventoryDatagridview.Size = new System.Drawing.Size(1310, 730);
            this.SupplyInventoryDatagridview.TabIndex = 8;
            this.SupplyInventoryDatagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplyInventoryDatagridview_CellMouseEnter);
            this.SupplyInventoryDatagridview.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplyInventoryDatagridview_CellMouseLeave);
            // 
            // CreateSupplyButton
            // 
            this.CreateSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateSupplyButton.Location = new System.Drawing.Point(1328, 39);
            this.CreateSupplyButton.Name = "CreateSupplyButton";
            this.CreateSupplyButton.Size = new System.Drawing.Size(124, 52);
            this.CreateSupplyButton.TabIndex = 15;
            this.CreateSupplyButton.Text = "สร้าง";
            this.CreateSupplyButton.UseVisualStyleBackColor = true;
            this.CreateSupplyButton.Click += new System.EventHandler(this.CreateSupplyButton_Click);
            // 
            // EditSupplyButton
            // 
            this.EditSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditSupplyButton.Location = new System.Drawing.Point(1328, 97);
            this.EditSupplyButton.Name = "EditSupplyButton";
            this.EditSupplyButton.Size = new System.Drawing.Size(124, 52);
            this.EditSupplyButton.TabIndex = 16;
            this.EditSupplyButton.Text = "แก้ใข";
            this.EditSupplyButton.UseVisualStyleBackColor = true;
            this.EditSupplyButton.Click += new System.EventHandler(this.EditSupplyButton_Click);
            // 
            // RemoveSupplyButton
            // 
            this.RemoveSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveSupplyButton.Location = new System.Drawing.Point(1328, 155);
            this.RemoveSupplyButton.Name = "RemoveSupplyButton";
            this.RemoveSupplyButton.Size = new System.Drawing.Size(124, 52);
            this.RemoveSupplyButton.TabIndex = 17;
            this.RemoveSupplyButton.Text = "ลบ";
            this.RemoveSupplyButton.UseVisualStyleBackColor = true;
            this.RemoveSupplyButton.Click += new System.EventHandler(this.RemoveSupplyButton_Click);
            // 
            // supplyTypeComboBox
            // 
            this.supplyTypeComboBox.FormattingEnabled = true;
            this.supplyTypeComboBox.Location = new System.Drawing.Point(367, 12);
            this.supplyTypeComboBox.Name = "supplyTypeComboBox";
            this.supplyTypeComboBox.Size = new System.Drawing.Size(337, 21);
            this.supplyTypeComboBox.TabIndex = 20;
            this.supplyTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.supplyTypeComboBox_SelectedIndexChanged);
            // 
            // searchSupplyTextBox
            // 
            this.searchSupplyTextBox.Location = new System.Drawing.Point(103, 12);
            this.searchSupplyTextBox.Name = "searchSupplyTextBox";
            this.searchSupplyTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchSupplyTextBox.TabIndex = 19;
            this.searchSupplyTextBox.TextChanged += new System.EventHandler(this.searchSupplyTextBox_TextChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.SearchLabel.Location = new System.Drawing.Point(9, 10);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(88, 20);
            this.SearchLabel.TabIndex = 18;
            this.SearchLabel.Text = "ค้นหารายการ";
            // 
            // AllSupplyListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.supplyTypeComboBox);
            this.Controls.Add(this.searchSupplyTextBox);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.RemoveSupplyButton);
            this.Controls.Add(this.EditSupplyButton);
            this.Controls.Add(this.CreateSupplyButton);
            this.Controls.Add(this.SupplyInventoryDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllSupplyListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายการวัสดุทั้งหมด";
            ((System.ComponentModel.ISupportInitialize)(this.SupplyInventoryDatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SupplyInventoryDatagridview;
        private System.Windows.Forms.Button CreateSupplyButton;
        private System.Windows.Forms.Button EditSupplyButton;
        private System.Windows.Forms.Button RemoveSupplyButton;
        private System.Windows.Forms.ComboBox supplyTypeComboBox;
        private System.Windows.Forms.TextBox searchSupplyTextBox;
        private System.Windows.Forms.Label SearchLabel;
    }
}