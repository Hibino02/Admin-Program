namespace Admin_Program.SupplyManagement.UIClass.SupplyArrivalManage
{
    partial class SupplyArrivalForm
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
            this.supplyInPRdataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // supplyInPRdataGridView
            // 
            this.supplyInPRdataGridView.AllowUserToAddRows = false;
            this.supplyInPRdataGridView.AllowUserToDeleteRows = false;
            this.supplyInPRdataGridView.AllowUserToResizeColumns = false;
            this.supplyInPRdataGridView.AllowUserToResizeRows = false;
            this.supplyInPRdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyInPRdataGridView.Location = new System.Drawing.Point(12, 27);
            this.supplyInPRdataGridView.MultiSelect = false;
            this.supplyInPRdataGridView.Name = "supplyInPRdataGridView";
            this.supplyInPRdataGridView.ReadOnly = true;
            this.supplyInPRdataGridView.RowHeadersVisible = false;
            this.supplyInPRdataGridView.RowTemplate.Height = 24;
            this.supplyInPRdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInPRdataGridView.ShowCellToolTips = false;
            this.supplyInPRdataGridView.Size = new System.Drawing.Size(459, 290);
            this.supplyInPRdataGridView.TabIndex = 29;
            // 
            // SupplyArrivalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.supplyInPRdataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyArrivalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตรวจรับวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRdataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView supplyInPRdataGridView;
    }
}