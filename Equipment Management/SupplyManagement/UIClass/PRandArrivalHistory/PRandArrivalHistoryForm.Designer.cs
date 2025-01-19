namespace Admin_Program.SupplyManagement.UIClass.PRandArrivalHistory
{
    partial class PRandArrivalHistoryForm
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
            this.PRListDatagridview = new System.Windows.Forms.DataGridView();
            this.supplyInPRdataGridView = new System.Windows.Forms.DataGridView();
            this.arrivalHistorydataGridView = new System.Windows.Forms.DataGridView();
            this.PRListlabel = new System.Windows.Forms.Label();
            this.supplyInPRlabel = new System.Windows.Forms.Label();
            this.arrivalHistorylabel = new System.Windows.Forms.Label();
            this.arrivalDatecomboBox = new System.Windows.Forms.ComboBox();
            this.datelabel = new System.Windows.Forms.Label();
            this.invoicelinkLabel = new System.Windows.Forms.LinkLabel();
            this.quotationlinkLabel = new System.Windows.Forms.LinkLabel();
            this.arrivalHistoryEditbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PRListDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalHistorydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // PRListDatagridview
            // 
            this.PRListDatagridview.AllowUserToAddRows = false;
            this.PRListDatagridview.AllowUserToDeleteRows = false;
            this.PRListDatagridview.AllowUserToResizeColumns = false;
            this.PRListDatagridview.AllowUserToResizeRows = false;
            this.PRListDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.PRListDatagridview.Location = new System.Drawing.Point(6, 27);
            this.PRListDatagridview.MultiSelect = false;
            this.PRListDatagridview.Name = "PRListDatagridview";
            this.PRListDatagridview.ReadOnly = true;
            this.PRListDatagridview.RowHeadersVisible = false;
            this.PRListDatagridview.RowTemplate.Height = 24;
            this.PRListDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.PRListDatagridview.Size = new System.Drawing.Size(374, 749);
            this.PRListDatagridview.TabIndex = 8;
            this.PRListDatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PRListDatagridview_CellClick);
            this.PRListDatagridview.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.PRListDatagridview_DataBindingComplete);
            // 
            // supplyInPRdataGridView
            // 
            this.supplyInPRdataGridView.AllowUserToAddRows = false;
            this.supplyInPRdataGridView.AllowUserToDeleteRows = false;
            this.supplyInPRdataGridView.AllowUserToResizeColumns = false;
            this.supplyInPRdataGridView.AllowUserToResizeRows = false;
            this.supplyInPRdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.supplyInPRdataGridView.Location = new System.Drawing.Point(390, 417);
            this.supplyInPRdataGridView.MultiSelect = false;
            this.supplyInPRdataGridView.Name = "supplyInPRdataGridView";
            this.supplyInPRdataGridView.ReadOnly = true;
            this.supplyInPRdataGridView.RowHeadersVisible = false;
            this.supplyInPRdataGridView.RowTemplate.Height = 24;
            this.supplyInPRdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInPRdataGridView.Size = new System.Drawing.Size(1062, 359);
            this.supplyInPRdataGridView.TabIndex = 9;
            this.supplyInPRdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplyInPRdataGridView_CellClick);
            this.supplyInPRdataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.supplyInPRdataGridView_DataBindingComplete);
            // 
            // arrivalHistorydataGridView
            // 
            this.arrivalHistorydataGridView.AllowUserToAddRows = false;
            this.arrivalHistorydataGridView.AllowUserToDeleteRows = false;
            this.arrivalHistorydataGridView.AllowUserToResizeColumns = false;
            this.arrivalHistorydataGridView.AllowUserToResizeRows = false;
            this.arrivalHistorydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.arrivalHistorydataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.arrivalHistorydataGridView.Location = new System.Drawing.Point(390, 27);
            this.arrivalHistorydataGridView.MultiSelect = false;
            this.arrivalHistorydataGridView.Name = "arrivalHistorydataGridView";
            this.arrivalHistorydataGridView.RowHeadersVisible = false;
            this.arrivalHistorydataGridView.RowTemplate.Height = 24;
            this.arrivalHistorydataGridView.Size = new System.Drawing.Size(939, 366);
            this.arrivalHistorydataGridView.TabIndex = 10;
            this.arrivalHistorydataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.arrivalHistorydataGridView_CellClick);
            this.arrivalHistorydataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.arrivalHistorydataGridView_DataBindingComplete);
            // 
            // PRListlabel
            // 
            this.PRListlabel.AutoSize = true;
            this.PRListlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRListlabel.Location = new System.Drawing.Point(2, 4);
            this.PRListlabel.Name = "PRListlabel";
            this.PRListlabel.Size = new System.Drawing.Size(104, 20);
            this.PRListlabel.TabIndex = 11;
            this.PRListlabel.Text = "รายการคำขอซื้อ";
            // 
            // supplyInPRlabel
            // 
            this.supplyInPRlabel.AutoSize = true;
            this.supplyInPRlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyInPRlabel.Location = new System.Drawing.Point(386, 396);
            this.supplyInPRlabel.Name = "supplyInPRlabel";
            this.supplyInPRlabel.Size = new System.Drawing.Size(185, 20);
            this.supplyInPRlabel.TabIndex = 12;
            this.supplyInPRlabel.Text = "รายการวัสดุในคำขอซื้อที่เลือก";
            // 
            // arrivalHistorylabel
            // 
            this.arrivalHistorylabel.AutoSize = true;
            this.arrivalHistorylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalHistorylabel.Location = new System.Drawing.Point(386, 2);
            this.arrivalHistorylabel.Name = "arrivalHistorylabel";
            this.arrivalHistorylabel.Size = new System.Drawing.Size(109, 20);
            this.arrivalHistorylabel.TabIndex = 13;
            this.arrivalHistorylabel.Text = "ประวัติรายการรับ";
            // 
            // arrivalDatecomboBox
            // 
            this.arrivalDatecomboBox.FormattingEnabled = true;
            this.arrivalDatecomboBox.Location = new System.Drawing.Point(811, 4);
            this.arrivalDatecomboBox.Name = "arrivalDatecomboBox";
            this.arrivalDatecomboBox.Size = new System.Drawing.Size(186, 21);
            this.arrivalDatecomboBox.TabIndex = 14;
            this.arrivalDatecomboBox.SelectedIndexChanged += new System.EventHandler(this.arrivalDatecomboBox_SelectedIndexChanged);
            // 
            // datelabel
            // 
            this.datelabel.AutoSize = true;
            this.datelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datelabel.Location = new System.Drawing.Point(747, 4);
            this.datelabel.Name = "datelabel";
            this.datelabel.Size = new System.Drawing.Size(58, 20);
            this.datelabel.TabIndex = 15;
            this.datelabel.Text = "วันที่ส่ง :";
            // 
            // invoicelinkLabel
            // 
            this.invoicelinkLabel.AutoSize = true;
            this.invoicelinkLabel.Location = new System.Drawing.Point(1243, 9);
            this.invoicelinkLabel.Name = "invoicelinkLabel";
            this.invoicelinkLabel.Size = new System.Drawing.Size(86, 13);
            this.invoicelinkLabel.TabIndex = 16;
            this.invoicelinkLabel.TabStop = true;
            this.invoicelinkLabel.Text = "ดูเอกสารส่งสินค้า";
            this.invoicelinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.invoicelinkLabel_LinkClicked);
            // 
            // quotationlinkLabel
            // 
            this.quotationlinkLabel.AutoSize = true;
            this.quotationlinkLabel.Location = new System.Drawing.Point(1342, 403);
            this.quotationlinkLabel.Name = "quotationlinkLabel";
            this.quotationlinkLabel.Size = new System.Drawing.Size(110, 13);
            this.quotationlinkLabel.TabIndex = 17;
            this.quotationlinkLabel.TabStop = true;
            this.quotationlinkLabel.Text = "ดูเอกสารใบเสนอราคา";
            this.quotationlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.quotationlinkLabel_LinkClicked);
            // 
            // arrivalHistoryEditbutton
            // 
            this.arrivalHistoryEditbutton.Location = new System.Drawing.Point(1345, 27);
            this.arrivalHistoryEditbutton.Name = "arrivalHistoryEditbutton";
            this.arrivalHistoryEditbutton.Size = new System.Drawing.Size(107, 41);
            this.arrivalHistoryEditbutton.TabIndex = 18;
            this.arrivalHistoryEditbutton.Text = "แก้ใขยอดส่ง";
            this.arrivalHistoryEditbutton.UseVisualStyleBackColor = true;
            this.arrivalHistoryEditbutton.Click += new System.EventHandler(this.arrivalHistoryEditbutton_Click);
            // 
            // PRandArrivalHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.arrivalHistoryEditbutton);
            this.Controls.Add(this.quotationlinkLabel);
            this.Controls.Add(this.invoicelinkLabel);
            this.Controls.Add(this.datelabel);
            this.Controls.Add(this.arrivalDatecomboBox);
            this.Controls.Add(this.arrivalHistorylabel);
            this.Controls.Add(this.supplyInPRlabel);
            this.Controls.Add(this.PRListlabel);
            this.Controls.Add(this.arrivalHistorydataGridView);
            this.Controls.Add(this.supplyInPRdataGridView);
            this.Controls.Add(this.PRListDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PRandArrivalHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ประวัติคำสั่งซื้อ";
            ((System.ComponentModel.ISupportInitialize)(this.PRListDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.arrivalHistorydataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PRListDatagridview;
        private System.Windows.Forms.DataGridView supplyInPRdataGridView;
        private System.Windows.Forms.DataGridView arrivalHistorydataGridView;
        private System.Windows.Forms.Label PRListlabel;
        private System.Windows.Forms.Label supplyInPRlabel;
        private System.Windows.Forms.Label arrivalHistorylabel;
        private System.Windows.Forms.ComboBox arrivalDatecomboBox;
        private System.Windows.Forms.Label datelabel;
        private System.Windows.Forms.LinkLabel invoicelinkLabel;
        private System.Windows.Forms.LinkLabel quotationlinkLabel;
        private System.Windows.Forms.Button arrivalHistoryEditbutton;
    }
}