namespace Admin_Program.SupplyManagement.UIClass
{
    partial class SupplyControlMainForm
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
            this.SupplyInventoryGroupBox = new System.Windows.Forms.GroupBox();
            this.supplyPlanButton = new System.Windows.Forms.Button();
            this.explainLabel2 = new System.Windows.Forms.Label();
            this.explainLabel1 = new System.Windows.Forms.Label();
            this.editSupplyButton = new System.Windows.Forms.Button();
            this.updateSupplyButton = new System.Windows.Forms.Button();
            this.supplyBalanceDatagridview = new System.Windows.Forms.DataGridView();
            this.supplyInventoryDatagridviewLabel = new System.Windows.Forms.Label();
            this.searchSupplyBalanceTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SupplyInventoryLabel = new System.Windows.Forms.Label();
            this.SupplyRequestGroupBox = new System.Windows.Forms.GroupBox();
            this.PRHistorybutton = new System.Windows.Forms.Button();
            this.excelGenbutton = new System.Windows.Forms.Button();
            this.supplyInSelectedPRdataGridView = new System.Windows.Forms.DataGridView();
            this.backToMainMenuButton = new System.Windows.Forms.Button();
            this.CompletePRButton = new System.Windows.Forms.Button();
            this.manageSupplyButton = new System.Windows.Forms.Button();
            this.removePRButton = new System.Windows.Forms.Button();
            this.manageSupplierButton = new System.Windows.Forms.Button();
            this.manageQuotationButton = new System.Windows.Forms.Button();
            this.openPRButton = new System.Windows.Forms.Button();
            this.supplyRequestLabel = new System.Windows.Forms.Label();
            this.supplyRequestDataGridView = new System.Windows.Forms.DataGridView();
            this.searchSupplyRequestTextBox = new System.Windows.Forms.TextBox();
            this.searchSupplylabel = new System.Windows.Forms.Label();
            this.requestSupplyLabel = new System.Windows.Forms.Label();
            this.transactionbutton = new System.Windows.Forms.Button();
            this.SupplyInventoryGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyBalanceDatagridview)).BeginInit();
            this.SupplyRequestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInSelectedPRdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyRequestDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SupplyInventoryGroupBox
            // 
            this.SupplyInventoryGroupBox.Controls.Add(this.transactionbutton);
            this.SupplyInventoryGroupBox.Controls.Add(this.supplyPlanButton);
            this.SupplyInventoryGroupBox.Controls.Add(this.explainLabel2);
            this.SupplyInventoryGroupBox.Controls.Add(this.explainLabel1);
            this.SupplyInventoryGroupBox.Controls.Add(this.editSupplyButton);
            this.SupplyInventoryGroupBox.Controls.Add(this.updateSupplyButton);
            this.SupplyInventoryGroupBox.Controls.Add(this.supplyBalanceDatagridview);
            this.SupplyInventoryGroupBox.Controls.Add(this.supplyInventoryDatagridviewLabel);
            this.SupplyInventoryGroupBox.Controls.Add(this.searchSupplyBalanceTextBox);
            this.SupplyInventoryGroupBox.Controls.Add(this.SearchLabel);
            this.SupplyInventoryGroupBox.Controls.Add(this.SupplyInventoryLabel);
            this.SupplyInventoryGroupBox.Location = new System.Drawing.Point(12, 5);
            this.SupplyInventoryGroupBox.Name = "SupplyInventoryGroupBox";
            this.SupplyInventoryGroupBox.Size = new System.Drawing.Size(707, 772);
            this.SupplyInventoryGroupBox.TabIndex = 0;
            this.SupplyInventoryGroupBox.TabStop = false;
            // 
            // supplyPlanButton
            // 
            this.supplyPlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyPlanButton.Location = new System.Drawing.Point(577, 659);
            this.supplyPlanButton.Name = "supplyPlanButton";
            this.supplyPlanButton.Size = new System.Drawing.Size(124, 52);
            this.supplyPlanButton.TabIndex = 12;
            this.supplyPlanButton.Text = "แผนการส่งวัสดุ";
            this.supplyPlanButton.UseVisualStyleBackColor = true;
            this.supplyPlanButton.Click += new System.EventHandler(this.supplyPlanButton_Click);
            // 
            // explainLabel2
            // 
            this.explainLabel2.AutoSize = true;
            this.explainLabel2.Location = new System.Drawing.Point(9, 742);
            this.explainLabel2.Name = "explainLabel2";
            this.explainLabel2.Size = new System.Drawing.Size(218, 13);
            this.explainLabel2.TabIndex = 11;
            this.explainLabel2.Text = "* แก้ใข หมายถึงแก้ใขรายละเอียดกรณีที่ใส่ผิด";
            // 
            // explainLabel1
            // 
            this.explainLabel1.AutoSize = true;
            this.explainLabel1.Location = new System.Drawing.Point(9, 722);
            this.explainLabel1.Name = "explainLabel1";
            this.explainLabel1.Size = new System.Drawing.Size(229, 13);
            this.explainLabel1.TabIndex = 10;
            this.explainLabel1.Text = "* อัฟเดทหมายถึง อัฟเดทยอดปัจจุบัณ ณ เวลานั้น";
            // 
            // editSupplyButton
            // 
            this.editSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editSupplyButton.Location = new System.Drawing.Point(87, 659);
            this.editSupplyButton.Name = "editSupplyButton";
            this.editSupplyButton.Size = new System.Drawing.Size(75, 52);
            this.editSupplyButton.TabIndex = 9;
            this.editSupplyButton.Text = "แก้ใข";
            this.editSupplyButton.UseVisualStyleBackColor = true;
            this.editSupplyButton.Click += new System.EventHandler(this.editSupplyButton_Click);
            // 
            // updateSupplyButton
            // 
            this.updateSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.updateSupplyButton.Location = new System.Drawing.Point(6, 659);
            this.updateSupplyButton.Name = "updateSupplyButton";
            this.updateSupplyButton.Size = new System.Drawing.Size(75, 52);
            this.updateSupplyButton.TabIndex = 8;
            this.updateSupplyButton.Text = "อัฟเดท";
            this.updateSupplyButton.UseVisualStyleBackColor = true;
            this.updateSupplyButton.Click += new System.EventHandler(this.updateSupplyButton_Click);
            // 
            // supplyBalanceDatagridview
            // 
            this.supplyBalanceDatagridview.AllowUserToAddRows = false;
            this.supplyBalanceDatagridview.AllowUserToDeleteRows = false;
            this.supplyBalanceDatagridview.AllowUserToResizeColumns = false;
            this.supplyBalanceDatagridview.AllowUserToResizeRows = false;
            this.supplyBalanceDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.supplyBalanceDatagridview.Location = new System.Drawing.Point(6, 111);
            this.supplyBalanceDatagridview.MultiSelect = false;
            this.supplyBalanceDatagridview.Name = "supplyBalanceDatagridview";
            this.supplyBalanceDatagridview.ReadOnly = true;
            this.supplyBalanceDatagridview.RowHeadersVisible = false;
            this.supplyBalanceDatagridview.RowTemplate.Height = 24;
            this.supplyBalanceDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyBalanceDatagridview.Size = new System.Drawing.Size(696, 542);
            this.supplyBalanceDatagridview.TabIndex = 7;
            // 
            // supplyInventoryDatagridviewLabel
            // 
            this.supplyInventoryDatagridviewLabel.AutoSize = true;
            this.supplyInventoryDatagridviewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyInventoryDatagridviewLabel.Location = new System.Drawing.Point(9, 90);
            this.supplyInventoryDatagridviewLabel.Name = "supplyInventoryDatagridviewLabel";
            this.supplyInventoryDatagridviewLabel.Size = new System.Drawing.Size(172, 18);
            this.supplyInventoryDatagridviewLabel.TabIndex = 6;
            this.supplyInventoryDatagridviewLabel.Text = "รายการวัสดุสิ้นเปลือง ปัจจุบัณ";
            // 
            // searchSupplyBalanceTextBox
            // 
            this.searchSupplyBalanceTextBox.Location = new System.Drawing.Point(149, 55);
            this.searchSupplyBalanceTextBox.Name = "searchSupplyBalanceTextBox";
            this.searchSupplyBalanceTextBox.Size = new System.Drawing.Size(386, 20);
            this.searchSupplyBalanceTextBox.TabIndex = 3;
            this.searchSupplyBalanceTextBox.TextChanged += new System.EventHandler(this.searchSupplyBalanceTextBox_TextChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.SearchLabel.Location = new System.Drawing.Point(6, 56);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(137, 20);
            this.SearchLabel.TabIndex = 2;
            this.SearchLabel.Text = "ค้นหารายการจากชื่อ :";
            // 
            // SupplyInventoryLabel
            // 
            this.SupplyInventoryLabel.AutoSize = true;
            this.SupplyInventoryLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SupplyInventoryLabel.Location = new System.Drawing.Point(6, 12);
            this.SupplyInventoryLabel.Name = "SupplyInventoryLabel";
            this.SupplyInventoryLabel.Size = new System.Drawing.Size(250, 31);
            this.SupplyInventoryLabel.TabIndex = 1;
            this.SupplyInventoryLabel.Text = "วัสดุสิ้นเปลือง คงเหลือ";
            // 
            // SupplyRequestGroupBox
            // 
            this.SupplyRequestGroupBox.Controls.Add(this.PRHistorybutton);
            this.SupplyRequestGroupBox.Controls.Add(this.excelGenbutton);
            this.SupplyRequestGroupBox.Controls.Add(this.supplyInSelectedPRdataGridView);
            this.SupplyRequestGroupBox.Controls.Add(this.backToMainMenuButton);
            this.SupplyRequestGroupBox.Controls.Add(this.CompletePRButton);
            this.SupplyRequestGroupBox.Controls.Add(this.manageSupplyButton);
            this.SupplyRequestGroupBox.Controls.Add(this.removePRButton);
            this.SupplyRequestGroupBox.Controls.Add(this.manageSupplierButton);
            this.SupplyRequestGroupBox.Controls.Add(this.manageQuotationButton);
            this.SupplyRequestGroupBox.Controls.Add(this.openPRButton);
            this.SupplyRequestGroupBox.Controls.Add(this.supplyRequestLabel);
            this.SupplyRequestGroupBox.Controls.Add(this.supplyRequestDataGridView);
            this.SupplyRequestGroupBox.Controls.Add(this.searchSupplyRequestTextBox);
            this.SupplyRequestGroupBox.Controls.Add(this.searchSupplylabel);
            this.SupplyRequestGroupBox.Controls.Add(this.requestSupplyLabel);
            this.SupplyRequestGroupBox.Location = new System.Drawing.Point(734, 5);
            this.SupplyRequestGroupBox.Name = "SupplyRequestGroupBox";
            this.SupplyRequestGroupBox.Size = new System.Drawing.Size(707, 772);
            this.SupplyRequestGroupBox.TabIndex = 1;
            this.SupplyRequestGroupBox.TabStop = false;
            // 
            // PRHistorybutton
            // 
            this.PRHistorybutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PRHistorybutton.Location = new System.Drawing.Point(577, 53);
            this.PRHistorybutton.Name = "PRHistorybutton";
            this.PRHistorybutton.Size = new System.Drawing.Size(124, 52);
            this.PRHistorybutton.TabIndex = 24;
            this.PRHistorybutton.Text = "ประวัติคำขอซื้อและการจัดส่ง";
            this.PRHistorybutton.UseVisualStyleBackColor = true;
            this.PRHistorybutton.Click += new System.EventHandler(this.PRHistorybutton_Click);
            // 
            // excelGenbutton
            // 
            this.excelGenbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelGenbutton.Location = new System.Drawing.Point(265, 659);
            this.excelGenbutton.Name = "excelGenbutton";
            this.excelGenbutton.Size = new System.Drawing.Size(124, 52);
            this.excelGenbutton.TabIndex = 23;
            this.excelGenbutton.Text = "Excel Gen";
            this.excelGenbutton.UseVisualStyleBackColor = true;
            this.excelGenbutton.Click += new System.EventHandler(this.excelGenbutton_Click);
            // 
            // supplyInSelectedPRdataGridView
            // 
            this.supplyInSelectedPRdataGridView.AllowUserToAddRows = false;
            this.supplyInSelectedPRdataGridView.AllowUserToDeleteRows = false;
            this.supplyInSelectedPRdataGridView.AllowUserToResizeColumns = false;
            this.supplyInSelectedPRdataGridView.AllowUserToResizeRows = false;
            this.supplyInSelectedPRdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyInSelectedPRdataGridView.Location = new System.Drawing.Point(349, 111);
            this.supplyInSelectedPRdataGridView.MultiSelect = false;
            this.supplyInSelectedPRdataGridView.Name = "supplyInSelectedPRdataGridView";
            this.supplyInSelectedPRdataGridView.ReadOnly = true;
            this.supplyInSelectedPRdataGridView.RowHeadersVisible = false;
            this.supplyInSelectedPRdataGridView.RowTemplate.Height = 24;
            this.supplyInSelectedPRdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInSelectedPRdataGridView.Size = new System.Drawing.Size(355, 542);
            this.supplyInSelectedPRdataGridView.TabIndex = 22;
            // 
            // backToMainMenuButton
            // 
            this.backToMainMenuButton.BackColor = System.Drawing.SystemColors.Info;
            this.backToMainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToMainMenuButton.Location = new System.Drawing.Point(580, 714);
            this.backToMainMenuButton.Name = "backToMainMenuButton";
            this.backToMainMenuButton.Size = new System.Drawing.Size(121, 52);
            this.backToMainMenuButton.TabIndex = 21;
            this.backToMainMenuButton.Text = "กลับสู่หน้าหลัก";
            this.backToMainMenuButton.UseVisualStyleBackColor = false;
            this.backToMainMenuButton.Click += new System.EventHandler(this.backToMainMenuButton_Click);
            // 
            // CompletePRButton
            // 
            this.CompletePRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompletePRButton.Location = new System.Drawing.Point(577, 659);
            this.CompletePRButton.Name = "CompletePRButton";
            this.CompletePRButton.Size = new System.Drawing.Size(124, 52);
            this.CompletePRButton.TabIndex = 20;
            this.CompletePRButton.Text = "ตรวจรับสินค้า";
            this.CompletePRButton.UseVisualStyleBackColor = true;
            this.CompletePRButton.Click += new System.EventHandler(this.CompletePRButton_Click);
            // 
            // manageSupplyButton
            // 
            this.manageSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageSupplyButton.Location = new System.Drawing.Point(265, 713);
            this.manageSupplyButton.Name = "manageSupplyButton";
            this.manageSupplyButton.Size = new System.Drawing.Size(124, 52);
            this.manageSupplyButton.TabIndex = 19;
            this.manageSupplyButton.Text = "จัดการรายการวัสดุ";
            this.manageSupplyButton.UseVisualStyleBackColor = true;
            this.manageSupplyButton.Click += new System.EventHandler(this.manageSupplyButton_Click);
            // 
            // removePRButton
            // 
            this.removePRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePRButton.Location = new System.Drawing.Point(135, 659);
            this.removePRButton.Name = "removePRButton";
            this.removePRButton.Size = new System.Drawing.Size(124, 52);
            this.removePRButton.TabIndex = 18;
            this.removePRButton.Text = "ลบคำขอซื้อ";
            this.removePRButton.UseVisualStyleBackColor = true;
            this.removePRButton.Click += new System.EventHandler(this.removePRButton_Click);
            // 
            // manageSupplierButton
            // 
            this.manageSupplierButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageSupplierButton.Location = new System.Drawing.Point(135, 713);
            this.manageSupplierButton.Name = "manageSupplierButton";
            this.manageSupplierButton.Size = new System.Drawing.Size(124, 52);
            this.manageSupplierButton.TabIndex = 17;
            this.manageSupplierButton.Text = "จัดการซัพพลายเออร์";
            this.manageSupplierButton.UseVisualStyleBackColor = true;
            this.manageSupplierButton.Click += new System.EventHandler(this.manageSupplierButton_Click);
            // 
            // manageQuotationButton
            // 
            this.manageQuotationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manageQuotationButton.Location = new System.Drawing.Point(5, 713);
            this.manageQuotationButton.Name = "manageQuotationButton";
            this.manageQuotationButton.Size = new System.Drawing.Size(124, 52);
            this.manageQuotationButton.TabIndex = 15;
            this.manageQuotationButton.Text = "จัดการใบเสนอราคา";
            this.manageQuotationButton.UseVisualStyleBackColor = true;
            this.manageQuotationButton.Click += new System.EventHandler(this.manageQuotationButton_Click);
            // 
            // openPRButton
            // 
            this.openPRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openPRButton.Location = new System.Drawing.Point(5, 659);
            this.openPRButton.Name = "openPRButton";
            this.openPRButton.Size = new System.Drawing.Size(124, 52);
            this.openPRButton.TabIndex = 14;
            this.openPRButton.Text = "เปิดคำขอซื้อ";
            this.openPRButton.UseVisualStyleBackColor = true;
            this.openPRButton.Click += new System.EventHandler(this.openPRButton_Click);
            // 
            // supplyRequestLabel
            // 
            this.supplyRequestLabel.AutoSize = true;
            this.supplyRequestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyRequestLabel.Location = new System.Drawing.Point(6, 90);
            this.supplyRequestLabel.Name = "supplyRequestLabel";
            this.supplyRequestLabel.Size = new System.Drawing.Size(145, 18);
            this.supplyRequestLabel.TabIndex = 13;
            this.supplyRequestLabel.Text = "รายการคำขอซื้อ ปัจจุบัณ";
            // 
            // supplyRequestDataGridView
            // 
            this.supplyRequestDataGridView.AllowUserToAddRows = false;
            this.supplyRequestDataGridView.AllowUserToDeleteRows = false;
            this.supplyRequestDataGridView.AllowUserToResizeColumns = false;
            this.supplyRequestDataGridView.AllowUserToResizeRows = false;
            this.supplyRequestDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyRequestDataGridView.Location = new System.Drawing.Point(5, 111);
            this.supplyRequestDataGridView.MultiSelect = false;
            this.supplyRequestDataGridView.Name = "supplyRequestDataGridView";
            this.supplyRequestDataGridView.ReadOnly = true;
            this.supplyRequestDataGridView.RowHeadersVisible = false;
            this.supplyRequestDataGridView.RowTemplate.Height = 24;
            this.supplyRequestDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyRequestDataGridView.Size = new System.Drawing.Size(338, 542);
            this.supplyRequestDataGridView.TabIndex = 13;
            this.supplyRequestDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.supplyRequestDataGridView_CellClick);
            this.supplyRequestDataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.supplyRequestDataGridView_DataBindingComplete);
            // 
            // searchSupplyRequestTextBox
            // 
            this.searchSupplyRequestTextBox.Location = new System.Drawing.Point(102, 61);
            this.searchSupplyRequestTextBox.Name = "searchSupplyRequestTextBox";
            this.searchSupplyRequestTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchSupplyRequestTextBox.TabIndex = 13;
            this.searchSupplyRequestTextBox.TextChanged += new System.EventHandler(this.searchSupplyRequestTextBox_TextChanged);
            // 
            // searchSupplylabel
            // 
            this.searchSupplylabel.AutoSize = true;
            this.searchSupplylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.searchSupplylabel.Location = new System.Drawing.Point(8, 59);
            this.searchSupplylabel.Name = "searchSupplylabel";
            this.searchSupplylabel.Size = new System.Drawing.Size(88, 20);
            this.searchSupplylabel.TabIndex = 13;
            this.searchSupplylabel.Text = "ค้นหารายการ";
            // 
            // requestSupplyLabel
            // 
            this.requestSupplyLabel.AutoSize = true;
            this.requestSupplyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestSupplyLabel.Location = new System.Drawing.Point(6, 12);
            this.requestSupplyLabel.Name = "requestSupplyLabel";
            this.requestSupplyLabel.Size = new System.Drawing.Size(258, 31);
            this.requestSupplyLabel.TabIndex = 13;
            this.requestSupplyLabel.Text = "คำขอซื้อ วัสดุสิ้นเปลือง";
            // 
            // transactionbutton
            // 
            this.transactionbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.transactionbutton.Location = new System.Drawing.Point(447, 659);
            this.transactionbutton.Name = "transactionbutton";
            this.transactionbutton.Size = new System.Drawing.Size(124, 52);
            this.transactionbutton.TabIndex = 13;
            this.transactionbutton.Text = "ประวัติย้อนหลัง";
            this.transactionbutton.UseVisualStyleBackColor = true;
            this.transactionbutton.Click += new System.EventHandler(this.transactionbutton_Click);
            // 
            // SupplyControlMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1450, 780);
            this.ControlBox = false;
            this.Controls.Add(this.SupplyRequestGroupBox);
            this.Controls.Add(this.SupplyInventoryGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyControlMainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.SupplyInventoryGroupBox.ResumeLayout(false);
            this.SupplyInventoryGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyBalanceDatagridview)).EndInit();
            this.SupplyRequestGroupBox.ResumeLayout(false);
            this.SupplyRequestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInSelectedPRdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyRequestDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SupplyInventoryGroupBox;
        private System.Windows.Forms.GroupBox SupplyRequestGroupBox;
        private System.Windows.Forms.Label SupplyInventoryLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox searchSupplyBalanceTextBox;
        private System.Windows.Forms.Label supplyInventoryDatagridviewLabel;
        private System.Windows.Forms.DataGridView supplyBalanceDatagridview;
        private System.Windows.Forms.Button supplyPlanButton;
        private System.Windows.Forms.Label explainLabel2;
        private System.Windows.Forms.Label explainLabel1;
        private System.Windows.Forms.Button editSupplyButton;
        private System.Windows.Forms.Button updateSupplyButton;
        private System.Windows.Forms.TextBox searchSupplyRequestTextBox;
        private System.Windows.Forms.Label searchSupplylabel;
        private System.Windows.Forms.Label requestSupplyLabel;
        private System.Windows.Forms.DataGridView supplyRequestDataGridView;
        private System.Windows.Forms.Button manageQuotationButton;
        private System.Windows.Forms.Button openPRButton;
        private System.Windows.Forms.Label supplyRequestLabel;
        private System.Windows.Forms.Button CompletePRButton;
        private System.Windows.Forms.Button manageSupplyButton;
        private System.Windows.Forms.Button removePRButton;
        private System.Windows.Forms.Button manageSupplierButton;
        private System.Windows.Forms.Button backToMainMenuButton;
        private System.Windows.Forms.DataGridView supplyInSelectedPRdataGridView;
        private System.Windows.Forms.Button excelGenbutton;
        private System.Windows.Forms.Button PRHistorybutton;
        private System.Windows.Forms.Button transactionbutton;
    }
}