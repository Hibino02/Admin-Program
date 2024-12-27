namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    partial class SupplyTypeManageForm
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
            this.removeSupplyTypeButton = new System.Windows.Forms.Button();
            this.SupplyTypeDataGridView = new System.Windows.Forms.DataGridView();
            this.detailsLabel = new System.Windows.Forms.Label();
            this.editSupplyTypeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyTypeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // removeSupplyTypeButton
            // 
            this.removeSupplyTypeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.removeSupplyTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeSupplyTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSupplyTypeButton.Location = new System.Drawing.Point(768, 88);
            this.removeSupplyTypeButton.Name = "removeSupplyTypeButton";
            this.removeSupplyTypeButton.Size = new System.Drawing.Size(104, 44);
            this.removeSupplyTypeButton.TabIndex = 8;
            this.removeSupplyTypeButton.Text = "ลบ";
            this.removeSupplyTypeButton.UseVisualStyleBackColor = false;
            this.removeSupplyTypeButton.Click += new System.EventHandler(this.removeSupplyTypeButton_Click);
            // 
            // SupplyTypeDataGridView
            // 
            this.SupplyTypeDataGridView.AllowUserToAddRows = false;
            this.SupplyTypeDataGridView.AllowUserToDeleteRows = false;
            this.SupplyTypeDataGridView.AllowUserToResizeColumns = false;
            this.SupplyTypeDataGridView.AllowUserToResizeRows = false;
            this.SupplyTypeDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.SupplyTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplyTypeDataGridView.Location = new System.Drawing.Point(17, 38);
            this.SupplyTypeDataGridView.MultiSelect = false;
            this.SupplyTypeDataGridView.Name = "SupplyTypeDataGridView";
            this.SupplyTypeDataGridView.ReadOnly = true;
            this.SupplyTypeDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.SupplyTypeDataGridView.RowHeadersVisible = false;
            this.SupplyTypeDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.SupplyTypeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplyTypeDataGridView.Size = new System.Drawing.Size(735, 562);
            this.SupplyTypeDataGridView.TabIndex = 7;
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabel.Location = new System.Drawing.Point(12, 10);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(84, 25);
            this.detailsLabel.TabIndex = 6;
            this.detailsLabel.Text = "รายการ :";
            // 
            // editSupplyTypeButton
            // 
            this.editSupplyTypeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.editSupplyTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editSupplyTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSupplyTypeButton.Location = new System.Drawing.Point(768, 38);
            this.editSupplyTypeButton.Name = "editSupplyTypeButton";
            this.editSupplyTypeButton.Size = new System.Drawing.Size(104, 44);
            this.editSupplyTypeButton.TabIndex = 9;
            this.editSupplyTypeButton.Text = "แก้ใข";
            this.editSupplyTypeButton.UseVisualStyleBackColor = false;
            this.editSupplyTypeButton.Click += new System.EventHandler(this.editSupplyTypeButton_Click);
            // 
            // SupplyTypeManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.editSupplyTypeButton);
            this.Controls.Add(this.removeSupplyTypeButton);
            this.Controls.Add(this.SupplyTypeDataGridView);
            this.Controls.Add(this.detailsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyTypeManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "จัดการซัพพลาย";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SupplyTypeManageForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.SupplyTypeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.Button removeSupplyTypeButton;
        private System.Windows.Forms.DataGridView SupplyTypeDataGridView;
        private System.Windows.Forms.Label detailsLabel;
        protected System.Windows.Forms.Button editSupplyTypeButton;
    }
}