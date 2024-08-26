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
            this.PlanHistoryDatagridview.Location = new System.Drawing.Point(12, 12);
            this.PlanHistoryDatagridview.MultiSelect = false;
            this.PlanHistoryDatagridview.Name = "PlanHistoryDatagridview";
            this.PlanHistoryDatagridview.ReadOnly = true;
            this.PlanHistoryDatagridview.RowHeadersVisible = false;
            this.PlanHistoryDatagridview.RowTemplate.Height = 24;
            this.PlanHistoryDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PlanHistoryDatagridview.Size = new System.Drawing.Size(1440, 757);
            this.PlanHistoryDatagridview.TabIndex = 14;
            this.PlanHistoryDatagridview.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PlanHistoryDatagridview_CellDoubleClick);
            this.PlanHistoryDatagridview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.PlanHistoryDatagridview_RowPrePaint);
            // 
            // PlanHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.PlanHistoryDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlanHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ประวัติแผนทั้งหมด";
            ((System.ComponentModel.ISupportInitialize)(this.PlanHistoryDatagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView PlanHistoryDatagridview;
    }
}