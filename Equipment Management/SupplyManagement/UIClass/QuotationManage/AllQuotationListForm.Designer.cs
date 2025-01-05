namespace Admin_Program.SupplyManagement.UIClass.QuotationManage
{
    partial class AllQuotationListForm
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
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.searchQuotationTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.RemoveButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.quotationDatagridview = new System.Windows.Forms.DataGridView();
            this.supplyInQuotationdataGridView = new System.Windows.Forms.DataGridView();
            this.supplyInQuotationlabel = new System.Windows.Forms.Label();
            this.quotationPDFlinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.quotationDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInQuotationdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(369, 13);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(337, 21);
            this.supplierComboBox.TabIndex = 27;
            this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
            // 
            // searchQuotationTextBox
            // 
            this.searchQuotationTextBox.Location = new System.Drawing.Point(105, 13);
            this.searchQuotationTextBox.Name = "searchQuotationTextBox";
            this.searchQuotationTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchQuotationTextBox.TabIndex = 26;
            this.searchQuotationTextBox.TextChanged += new System.EventHandler(this.searchQuotationTextBox_TextChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.SearchLabel.Location = new System.Drawing.Point(11, 11);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(88, 20);
            this.SearchLabel.TabIndex = 25;
            this.SearchLabel.Text = "ค้นหารายการ";
            // 
            // RemoveButton
            // 
            this.RemoveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveButton.Location = new System.Drawing.Point(1330, 156);
            this.RemoveButton.Name = "RemoveButton";
            this.RemoveButton.Size = new System.Drawing.Size(124, 52);
            this.RemoveButton.TabIndex = 24;
            this.RemoveButton.Text = "ลบ";
            this.RemoveButton.UseVisualStyleBackColor = true;
            this.RemoveButton.Click += new System.EventHandler(this.RemoveButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(1330, 98);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(124, 52);
            this.EditButton.TabIndex = 23;
            this.EditButton.Text = "แก้ใข";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(1330, 40);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(124, 52);
            this.CreateButton.TabIndex = 22;
            this.CreateButton.Text = "สร้าง";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // quotationDatagridview
            // 
            this.quotationDatagridview.AllowUserToAddRows = false;
            this.quotationDatagridview.AllowUserToDeleteRows = false;
            this.quotationDatagridview.AllowUserToResizeColumns = false;
            this.quotationDatagridview.AllowUserToResizeRows = false;
            this.quotationDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quotationDatagridview.Location = new System.Drawing.Point(14, 40);
            this.quotationDatagridview.MultiSelect = false;
            this.quotationDatagridview.Name = "quotationDatagridview";
            this.quotationDatagridview.ReadOnly = true;
            this.quotationDatagridview.RowHeadersVisible = false;
            this.quotationDatagridview.RowTemplate.Height = 24;
            this.quotationDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.quotationDatagridview.ShowCellToolTips = false;
            this.quotationDatagridview.Size = new System.Drawing.Size(800, 730);
            this.quotationDatagridview.TabIndex = 21;
            this.quotationDatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.quotationDatagridview_CellClick);
            this.quotationDatagridview.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.quotationDatagridview_DataBindingComplete);
            // 
            // supplyInQuotationdataGridView
            // 
            this.supplyInQuotationdataGridView.AllowUserToAddRows = false;
            this.supplyInQuotationdataGridView.AllowUserToDeleteRows = false;
            this.supplyInQuotationdataGridView.AllowUserToResizeColumns = false;
            this.supplyInQuotationdataGridView.AllowUserToResizeRows = false;
            this.supplyInQuotationdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyInQuotationdataGridView.Location = new System.Drawing.Point(820, 40);
            this.supplyInQuotationdataGridView.MultiSelect = false;
            this.supplyInQuotationdataGridView.Name = "supplyInQuotationdataGridView";
            this.supplyInQuotationdataGridView.ReadOnly = true;
            this.supplyInQuotationdataGridView.RowHeadersVisible = false;
            this.supplyInQuotationdataGridView.RowTemplate.Height = 24;
            this.supplyInQuotationdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInQuotationdataGridView.ShowCellToolTips = false;
            this.supplyInQuotationdataGridView.Size = new System.Drawing.Size(504, 729);
            this.supplyInQuotationdataGridView.TabIndex = 28;
            this.supplyInQuotationdataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplyInQuotationdataGridView_CellMouseEnter);
            this.supplyInQuotationdataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplyInQuotationdataGridView_CellMouseLeave);
            // 
            // supplyInQuotationlabel
            // 
            this.supplyInQuotationlabel.AutoSize = true;
            this.supplyInQuotationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyInQuotationlabel.Location = new System.Drawing.Point(816, 14);
            this.supplyInQuotationlabel.Name = "supplyInQuotationlabel";
            this.supplyInQuotationlabel.Size = new System.Drawing.Size(212, 20);
            this.supplyInQuotationlabel.TabIndex = 29;
            this.supplyInQuotationlabel.Text = "รายการวัสดุในใบเสนอราคาที่เลือก";
            // 
            // quotationPDFlinkLabel
            // 
            this.quotationPDFlinkLabel.AutoSize = true;
            this.quotationPDFlinkLabel.Location = new System.Drawing.Point(1183, 16);
            this.quotationPDFlinkLabel.Name = "quotationPDFlinkLabel";
            this.quotationPDFlinkLabel.Size = new System.Drawing.Size(141, 13);
            this.quotationPDFlinkLabel.TabIndex = 30;
            this.quotationPDFlinkLabel.TabStop = true;
            this.quotationPDFlinkLabel.Text = "ดูเอกสารใบเสนอราคาที่เลือก";
            this.quotationPDFlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.quotationPDFlinkLabel_LinkClicked);
            // 
            // AllQuotationListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.quotationPDFlinkLabel);
            this.Controls.Add(this.supplyInQuotationlabel);
            this.Controls.Add(this.supplyInQuotationdataGridView);
            this.Controls.Add(this.supplierComboBox);
            this.Controls.Add(this.searchQuotationTextBox);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.RemoveButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.quotationDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllQuotationListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "รายการใบเสนอราคาทั้งหมด";
            ((System.ComponentModel.ISupportInitialize)(this.quotationDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInQuotationdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.TextBox searchQuotationTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button RemoveButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.DataGridView quotationDatagridview;
        private System.Windows.Forms.DataGridView supplyInQuotationdataGridView;
        private System.Windows.Forms.Label supplyInQuotationlabel;
        private System.Windows.Forms.LinkLabel quotationPDFlinkLabel;
    }
}