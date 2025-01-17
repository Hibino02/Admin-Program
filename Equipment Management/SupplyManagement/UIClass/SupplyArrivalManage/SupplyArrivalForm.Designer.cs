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
            this.supplyInPRArrivalLstdataGridView = new System.Windows.Forms.DataGridView();
            this.supplyInPlanlabel = new System.Windows.Forms.Label();
            this.supplyInPRArrivaldataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRArrivalLstdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRArrivaldataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // supplyInPRArrivalLstdataGridView
            // 
            this.supplyInPRArrivalLstdataGridView.AllowUserToAddRows = false;
            this.supplyInPRArrivalLstdataGridView.AllowUserToDeleteRows = false;
            this.supplyInPRArrivalLstdataGridView.AllowUserToResizeColumns = false;
            this.supplyInPRArrivalLstdataGridView.AllowUserToResizeRows = false;
            this.supplyInPRArrivalLstdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.supplyInPRArrivalLstdataGridView.Location = new System.Drawing.Point(12, 28);
            this.supplyInPRArrivalLstdataGridView.MultiSelect = false;
            this.supplyInPRArrivalLstdataGridView.Name = "supplyInPRArrivalLstdataGridView";
            this.supplyInPRArrivalLstdataGridView.ReadOnly = true;
            this.supplyInPRArrivalLstdataGridView.RowHeadersVisible = false;
            this.supplyInPRArrivalLstdataGridView.RowTemplate.Height = 24;
            this.supplyInPRArrivalLstdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInPRArrivalLstdataGridView.ShowCellToolTips = false;
            this.supplyInPRArrivalLstdataGridView.Size = new System.Drawing.Size(1440, 290);
            this.supplyInPRArrivalLstdataGridView.TabIndex = 29;
            this.supplyInPRArrivalLstdataGridView.SelectionChanged += new System.EventHandler(this.supplyInPRArrivalLstdataGridView_SelectionChanged);
            // 
            // supplyInPlanlabel
            // 
            this.supplyInPlanlabel.AutoSize = true;
            this.supplyInPlanlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyInPlanlabel.Location = new System.Drawing.Point(12, 5);
            this.supplyInPlanlabel.Name = "supplyInPlanlabel";
            this.supplyInPlanlabel.Size = new System.Drawing.Size(138, 20);
            this.supplyInPlanlabel.TabIndex = 30;
            this.supplyInPlanlabel.Text = "แผนประจำเดือนล่าสุด";
            // 
            // supplyInPRArrivaldataGridView
            // 
            this.supplyInPRArrivaldataGridView.AllowUserToAddRows = false;
            this.supplyInPRArrivaldataGridView.AllowUserToDeleteRows = false;
            this.supplyInPRArrivaldataGridView.AllowUserToResizeColumns = false;
            this.supplyInPRArrivaldataGridView.AllowUserToResizeRows = false;
            this.supplyInPRArrivaldataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.supplyInPRArrivaldataGridView.Location = new System.Drawing.Point(12, 358);
            this.supplyInPRArrivaldataGridView.MultiSelect = false;
            this.supplyInPRArrivaldataGridView.Name = "supplyInPRArrivaldataGridView";
            this.supplyInPRArrivaldataGridView.ReadOnly = true;
            this.supplyInPRArrivaldataGridView.RowHeadersVisible = false;
            this.supplyInPRArrivaldataGridView.RowTemplate.Height = 24;
            this.supplyInPRArrivaldataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInPRArrivaldataGridView.ShowCellToolTips = false;
            this.supplyInPRArrivaldataGridView.Size = new System.Drawing.Size(938, 290);
            this.supplyInPRArrivaldataGridView.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "รายการที่สั่งซื้อ";
            // 
            // SupplyArrivalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplyInPRArrivaldataGridView);
            this.Controls.Add(this.supplyInPlanlabel);
            this.Controls.Add(this.supplyInPRArrivalLstdataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyArrivalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตรวจรับวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRArrivalLstdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRArrivaldataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView supplyInPRArrivalLstdataGridView;
        private System.Windows.Forms.Label supplyInPlanlabel;
        private System.Windows.Forms.DataGridView supplyInPRArrivaldataGridView;
        private System.Windows.Forms.Label label1;
    }
}