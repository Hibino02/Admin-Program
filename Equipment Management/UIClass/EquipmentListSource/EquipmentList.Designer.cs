namespace Equipment_Management.UIClass.EquipmentListSource
{
    partial class EquipmentList
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
            this.EquipmentListDataGridView = new System.Windows.Forms.DataGridView();
            this.jobHistoryButton = new System.Windows.Forms.Button();
            this.removeEquipmentButton = new System.Windows.Forms.Button();
            this.writeOff_TransferButton = new System.Windows.Forms.Button();
            this.editEquipmentButton = new System.Windows.Forms.Button();
            this.equipmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.equipmentFilterListLabel = new System.Windows.Forms.Label();
            this.equipmentListSearchTextBox = new System.Windows.Forms.TextBox();
            this.searchEquipmentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentListDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EquipmentListDataGridView
            // 
            this.EquipmentListDataGridView.AllowUserToAddRows = false;
            this.EquipmentListDataGridView.AllowUserToDeleteRows = false;
            this.EquipmentListDataGridView.AllowUserToResizeColumns = false;
            this.EquipmentListDataGridView.AllowUserToResizeRows = false;
            this.EquipmentListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipmentListDataGridView.Location = new System.Drawing.Point(12, 87);
            this.EquipmentListDataGridView.MultiSelect = false;
            this.EquipmentListDataGridView.Name = "EquipmentListDataGridView";
            this.EquipmentListDataGridView.ReadOnly = true;
            this.EquipmentListDataGridView.RowHeadersVisible = false;
            this.EquipmentListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EquipmentListDataGridView.Size = new System.Drawing.Size(1440, 682);
            this.EquipmentListDataGridView.TabIndex = 0;
            this.EquipmentListDataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentListDataGridView_CellMouseEnter);
            this.EquipmentListDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentListDataGridView_CellMouseLeave);
            // 
            // jobHistoryButton
            // 
            this.jobHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.jobHistoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobHistoryButton.Location = new System.Drawing.Point(1317, 14);
            this.jobHistoryButton.Name = "jobHistoryButton";
            this.jobHistoryButton.Size = new System.Drawing.Size(135, 50);
            this.jobHistoryButton.TabIndex = 1;
            this.jobHistoryButton.Text = "ประวัติแจ้งซ่อม";
            this.jobHistoryButton.UseVisualStyleBackColor = true;
            this.jobHistoryButton.Click += new System.EventHandler(this.jobHistoryButton_Click);
            // 
            // removeEquipmentButton
            // 
            this.removeEquipmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeEquipmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeEquipmentButton.Location = new System.Drawing.Point(1176, 14);
            this.removeEquipmentButton.Name = "removeEquipmentButton";
            this.removeEquipmentButton.Size = new System.Drawing.Size(135, 50);
            this.removeEquipmentButton.TabIndex = 2;
            this.removeEquipmentButton.Text = "ลบอุปกรณ์";
            this.removeEquipmentButton.UseVisualStyleBackColor = true;
            this.removeEquipmentButton.Click += new System.EventHandler(this.removeEquipmentButton_Click);
            // 
            // writeOff_TransferButton
            // 
            this.writeOff_TransferButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.writeOff_TransferButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.writeOff_TransferButton.Location = new System.Drawing.Point(1057, 14);
            this.writeOff_TransferButton.Name = "writeOff_TransferButton";
            this.writeOff_TransferButton.Size = new System.Drawing.Size(113, 50);
            this.writeOff_TransferButton.TabIndex = 3;
            this.writeOff_TransferButton.Text = "Write-Off / โอนย้าย อุปกรณ์";
            this.writeOff_TransferButton.UseVisualStyleBackColor = true;
            this.writeOff_TransferButton.Click += new System.EventHandler(this.writeOff_TransferButton_Click);
            // 
            // editEquipmentButton
            // 
            this.editEquipmentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editEquipmentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editEquipmentButton.Location = new System.Drawing.Point(916, 14);
            this.editEquipmentButton.Name = "editEquipmentButton";
            this.editEquipmentButton.Size = new System.Drawing.Size(135, 50);
            this.editEquipmentButton.TabIndex = 4;
            this.editEquipmentButton.Text = "แก้ใขรายละเอียดอุปกรณ์";
            this.editEquipmentButton.UseVisualStyleBackColor = true;
            this.editEquipmentButton.Click += new System.EventHandler(this.editEquipmentButton_Click);
            // 
            // equipmentTypeComboBox
            // 
            this.equipmentTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentTypeComboBox.FormattingEnabled = true;
            this.equipmentTypeComboBox.Location = new System.Drawing.Point(12, 33);
            this.equipmentTypeComboBox.Name = "equipmentTypeComboBox";
            this.equipmentTypeComboBox.Size = new System.Drawing.Size(436, 32);
            this.equipmentTypeComboBox.TabIndex = 5;
            this.equipmentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.equipmentTypeComboBox_SelectedIndexChanged);
            this.equipmentTypeComboBox.TextChanged += new System.EventHandler(this.equipmentTypeComboBox_TextChanged);
            // 
            // equipmentFilterListLabel
            // 
            this.equipmentFilterListLabel.AutoSize = true;
            this.equipmentFilterListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentFilterListLabel.Location = new System.Drawing.Point(12, 6);
            this.equipmentFilterListLabel.Name = "equipmentFilterListLabel";
            this.equipmentFilterListLabel.Size = new System.Drawing.Size(196, 25);
            this.equipmentFilterListLabel.TabIndex = 6;
            this.equipmentFilterListLabel.Text = "ตัวกรองประเภทอุปกรณ์";
            // 
            // equipmentListSearchTextBox
            // 
            this.equipmentListSearchTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.equipmentListSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.equipmentListSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentListSearchTextBox.Location = new System.Drawing.Point(457, 35);
            this.equipmentListSearchTextBox.Name = "equipmentListSearchTextBox";
            this.equipmentListSearchTextBox.Size = new System.Drawing.Size(441, 29);
            this.equipmentListSearchTextBox.TabIndex = 7;
            this.equipmentListSearchTextBox.TextChanged += new System.EventHandler(this.equipmentListSearchTextBox_TextChanged);
            // 
            // searchEquipmentLabel
            // 
            this.searchEquipmentLabel.AutoSize = true;
            this.searchEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchEquipmentLabel.Location = new System.Drawing.Point(454, 5);
            this.searchEquipmentLabel.Name = "searchEquipmentLabel";
            this.searchEquipmentLabel.Size = new System.Drawing.Size(223, 25);
            this.searchEquipmentLabel.TabIndex = 8;
            this.searchEquipmentLabel.Text = "พิมพ์รายละเอียดที่เกี่ยวข้อง";
            // 
            // EquipmentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 781);
            this.Controls.Add(this.searchEquipmentLabel);
            this.Controls.Add(this.equipmentListSearchTextBox);
            this.Controls.Add(this.equipmentFilterListLabel);
            this.Controls.Add(this.equipmentTypeComboBox);
            this.Controls.Add(this.editEquipmentButton);
            this.Controls.Add(this.writeOff_TransferButton);
            this.Controls.Add(this.removeEquipmentButton);
            this.Controls.Add(this.jobHistoryButton);
            this.Controls.Add(this.EquipmentListDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายการเครื่องมือ / อุปกรณ์ทั้งหมด";
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentListDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView EquipmentListDataGridView;
        private System.Windows.Forms.Button jobHistoryButton;
        private System.Windows.Forms.Button removeEquipmentButton;
        private System.Windows.Forms.Button writeOff_TransferButton;
        private System.Windows.Forms.Button editEquipmentButton;
        private System.Windows.Forms.ComboBox equipmentTypeComboBox;
        private System.Windows.Forms.Label equipmentFilterListLabel;
        private System.Windows.Forms.TextBox equipmentListSearchTextBox;
        private System.Windows.Forms.Label searchEquipmentLabel;
    }
}