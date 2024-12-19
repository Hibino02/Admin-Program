namespace Admin_Program.EquipmentManagement.UIClass.EquipmentInstallEditWriteOffSource
{
    partial class EquipmentTypeManagementForm
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
            this.detailsLabel = new System.Windows.Forms.Label();
            this.eTypeDataGridView = new System.Windows.Forms.DataGridView();
            this.removeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.eTypeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // detailsLabel
            // 
            this.detailsLabel.AutoSize = true;
            this.detailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.detailsLabel.Location = new System.Drawing.Point(12, 9);
            this.detailsLabel.Name = "detailsLabel";
            this.detailsLabel.Size = new System.Drawing.Size(84, 25);
            this.detailsLabel.TabIndex = 3;
            this.detailsLabel.Text = "รายการ :";
            // 
            // eTypeDataGridView
            // 
            this.eTypeDataGridView.AllowUserToAddRows = false;
            this.eTypeDataGridView.AllowUserToDeleteRows = false;
            this.eTypeDataGridView.AllowUserToResizeColumns = false;
            this.eTypeDataGridView.AllowUserToResizeRows = false;
            this.eTypeDataGridView.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.eTypeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.eTypeDataGridView.Location = new System.Drawing.Point(17, 37);
            this.eTypeDataGridView.MultiSelect = false;
            this.eTypeDataGridView.Name = "eTypeDataGridView";
            this.eTypeDataGridView.ReadOnly = true;
            this.eTypeDataGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.eTypeDataGridView.RowHeadersVisible = false;
            this.eTypeDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.eTypeDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.eTypeDataGridView.Size = new System.Drawing.Size(735, 562);
            this.eTypeDataGridView.TabIndex = 4;
            // 
            // removeButton
            // 
            this.removeButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.removeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(768, 37);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(104, 44);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "ลบ";
            this.removeButton.UseVisualStyleBackColor = false;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // EquipmentTypeManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.eTypeDataGridView);
            this.Controls.Add(this.detailsLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentTypeManagementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            ((System.ComponentModel.ISupportInitialize)(this.eTypeDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label detailsLabel;
        private System.Windows.Forms.DataGridView eTypeDataGridView;
        protected System.Windows.Forms.Button removeButton;
    }
}