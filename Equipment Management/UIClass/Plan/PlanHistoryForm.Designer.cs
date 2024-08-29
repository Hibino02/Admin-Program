namespace Equipment_Management.UIClass.Plan
{
    partial class PlanHistoryForm
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
            this.PlanHistoryDatagridview = new System.Windows.Forms.DataGridView();
            this.searchEquipmentLabel = new System.Windows.Forms.Label();
            this.equipmentListSearchTextBox = new System.Windows.Forms.TextBox();
            this.equipmentFilterListLabel = new System.Windows.Forms.Label();
            this.equipmentTypeComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.PlanHistoryDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // PlanHistoryDatagridview
            // 
            this.PlanHistoryDatagridview.AllowUserToAddRows = false;
            this.PlanHistoryDatagridview.AllowUserToDeleteRows = false;
            this.PlanHistoryDatagridview.AllowUserToResizeColumns = false;
            this.PlanHistoryDatagridview.AllowUserToResizeRows = false;
            this.PlanHistoryDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PlanHistoryDatagridview.Location = new System.Drawing.Point(12, 74);
            this.PlanHistoryDatagridview.MultiSelect = false;
            this.PlanHistoryDatagridview.Name = "PlanHistoryDatagridview";
            this.PlanHistoryDatagridview.ReadOnly = true;
            this.PlanHistoryDatagridview.RowHeadersVisible = false;
            this.PlanHistoryDatagridview.RowTemplate.Height = 24;
            this.PlanHistoryDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PlanHistoryDatagridview.Size = new System.Drawing.Size(1440, 695);
            this.PlanHistoryDatagridview.TabIndex = 14;
            this.PlanHistoryDatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlanHistoryDatagridview_CellDoubleClick);
            this.PlanHistoryDatagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlanHistoryDatagridview_CellMouseEnter);
            this.PlanHistoryDatagridview.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlanHistoryDatagridview_CellMouseLeave);
            this.PlanHistoryDatagridview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.PlanHistoryDatagridview_RowPrePaint);
            // 
            // searchEquipmentLabel
            // 
            this.searchEquipmentLabel.AutoSize = true;
            this.searchEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchEquipmentLabel.Location = new System.Drawing.Point(526, 9);
            this.searchEquipmentLabel.Name = "searchEquipmentLabel";
            this.searchEquipmentLabel.Size = new System.Drawing.Size(223, 25);
            this.searchEquipmentLabel.TabIndex = 18;
            this.searchEquipmentLabel.Text = "พิมพ์รายละเอียดที่เกี่ยวข้อง";
            // 
            // equipmentListSearchTextBox
            // 
            this.equipmentListSearchTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.equipmentListSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.equipmentListSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentListSearchTextBox.Location = new System.Drawing.Point(524, 38);
            this.equipmentListSearchTextBox.Name = "equipmentListSearchTextBox";
            this.equipmentListSearchTextBox.Size = new System.Drawing.Size(277, 29);
            this.equipmentListSearchTextBox.TabIndex = 17;
            // 
            // equipmentFilterListLabel
            // 
            this.equipmentFilterListLabel.AutoSize = true;
            this.equipmentFilterListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentFilterListLabel.Location = new System.Drawing.Point(12, 9);
            this.equipmentFilterListLabel.Name = "equipmentFilterListLabel";
            this.equipmentFilterListLabel.Size = new System.Drawing.Size(196, 25);
            this.equipmentFilterListLabel.TabIndex = 16;
            this.equipmentFilterListLabel.Text = "ตัวกรองประเภทอุปกรณ์";
            // 
            // equipmentTypeComboBox
            // 
            this.equipmentTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentTypeComboBox.FormattingEnabled = true;
            this.equipmentTypeComboBox.Location = new System.Drawing.Point(12, 36);
            this.equipmentTypeComboBox.Name = "equipmentTypeComboBox";
            this.equipmentTypeComboBox.Size = new System.Drawing.Size(497, 32);
            this.equipmentTypeComboBox.TabIndex = 15;
            this.equipmentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.equipmentTypeComboBox_SelectedIndexChanged);
            // 
            // PlanHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.searchEquipmentLabel);
            this.Controls.Add(this.equipmentListSearchTextBox);
            this.Controls.Add(this.equipmentFilterListLabel);
            this.Controls.Add(this.equipmentTypeComboBox);
            this.Controls.Add(this.PlanHistoryDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ประวัติแผนทั้งหมด";
            ((System.ComponentModel.ISupportInitialize)(this.PlanHistoryDatagridview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PlanHistoryDatagridview;
        private System.Windows.Forms.Label searchEquipmentLabel;
        private System.Windows.Forms.TextBox equipmentListSearchTextBox;
        private System.Windows.Forms.Label equipmentFilterListLabel;
        private System.Windows.Forms.ComboBox equipmentTypeComboBox;
    }
}