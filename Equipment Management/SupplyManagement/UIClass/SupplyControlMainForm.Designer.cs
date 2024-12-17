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
            this.SupplyRequestGroupBox = new System.Windows.Forms.GroupBox();
            this.SupplyInventoryLabel = new System.Windows.Forms.Label();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.searchSupplyInventoryTextBox = new System.Windows.Forms.TextBox();
            this.supplyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.supplyInventoryDatagridviewLabel = new System.Windows.Forms.Label();
            this.SupplyInventoryDatagridview = new System.Windows.Forms.DataGridView();
            this.updateSupplyButton = new System.Windows.Forms.Button();
            this.editSupplyButton = new System.Windows.Forms.Button();
            this.explainLabel1 = new System.Windows.Forms.Label();
            this.explainLabel2 = new System.Windows.Forms.Label();
            this.supplyPlanButton = new System.Windows.Forms.Button();
            this.requestSupplyLabel = new System.Windows.Forms.Label();
            this.searchSupplylabel = new System.Windows.Forms.Label();
            this.searchSupplyRequestTextBox = new System.Windows.Forms.TextBox();
            this.supplyRequestDataGridView = new System.Windows.Forms.DataGridView();
            this.supplyRequestLabel = new System.Windows.Forms.Label();
            this.openPRButton = new System.Windows.Forms.Button();
            this.manageQuotationButton = new System.Windows.Forms.Button();
            this.editPRButton = new System.Windows.Forms.Button();
            this.manageSupplierButton = new System.Windows.Forms.Button();
            this.removePRButton = new System.Windows.Forms.Button();
            this.manageSupplyButton = new System.Windows.Forms.Button();
            this.CompletePRButton = new System.Windows.Forms.Button();
            this.backToMainMenuButton = new System.Windows.Forms.Button();
            this.SupplyInventoryGroupBox.SuspendLayout();
            this.SupplyRequestGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyInventoryDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyRequestDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // SupplyInventoryGroupBox
            // 
            this.SupplyInventoryGroupBox.Controls.Add(this.supplyPlanButton);
            this.SupplyInventoryGroupBox.Controls.Add(this.explainLabel2);
            this.SupplyInventoryGroupBox.Controls.Add(this.explainLabel1);
            this.SupplyInventoryGroupBox.Controls.Add(this.editSupplyButton);
            this.SupplyInventoryGroupBox.Controls.Add(this.updateSupplyButton);
            this.SupplyInventoryGroupBox.Controls.Add(this.SupplyInventoryDatagridview);
            this.SupplyInventoryGroupBox.Controls.Add(this.supplyInventoryDatagridviewLabel);
            this.SupplyInventoryGroupBox.Controls.Add(this.supplyTypeComboBox);
            this.SupplyInventoryGroupBox.Controls.Add(this.searchSupplyInventoryTextBox);
            this.SupplyInventoryGroupBox.Controls.Add(this.SearchLabel);
            this.SupplyInventoryGroupBox.Controls.Add(this.SupplyInventoryLabel);
            this.SupplyInventoryGroupBox.Location = new System.Drawing.Point(12, 5);
            this.SupplyInventoryGroupBox.Name = "SupplyInventoryGroupBox";
            this.SupplyInventoryGroupBox.Size = new System.Drawing.Size(707, 772);
            this.SupplyInventoryGroupBox.TabIndex = 0;
            this.SupplyInventoryGroupBox.TabStop = false;
            // 
            // SupplyRequestGroupBox
            // 
            this.SupplyRequestGroupBox.Controls.Add(this.backToMainMenuButton);
            this.SupplyRequestGroupBox.Controls.Add(this.CompletePRButton);
            this.SupplyRequestGroupBox.Controls.Add(this.manageSupplyButton);
            this.SupplyRequestGroupBox.Controls.Add(this.removePRButton);
            this.SupplyRequestGroupBox.Controls.Add(this.manageSupplierButton);
            this.SupplyRequestGroupBox.Controls.Add(this.editPRButton);
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
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.SearchLabel.Location = new System.Drawing.Point(6, 56);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(88, 20);
            this.SearchLabel.TabIndex = 2;
            this.SearchLabel.Text = "ค้นหารายการ";
            // 
            // searchSupplyInventoryTextBox
            // 
            this.searchSupplyInventoryTextBox.Location = new System.Drawing.Point(100, 58);
            this.searchSupplyInventoryTextBox.Name = "searchSupplyInventoryTextBox";
            this.searchSupplyInventoryTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchSupplyInventoryTextBox.TabIndex = 3;
            // 
            // supplyTypeComboBox
            // 
            this.supplyTypeComboBox.FormattingEnabled = true;
            this.supplyTypeComboBox.Location = new System.Drawing.Point(364, 58);
            this.supplyTypeComboBox.Name = "supplyTypeComboBox";
            this.supplyTypeComboBox.Size = new System.Drawing.Size(337, 21);
            this.supplyTypeComboBox.TabIndex = 4;
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
            // SupplyInventoryDatagridview
            // 
            this.SupplyInventoryDatagridview.AllowUserToAddRows = false;
            this.SupplyInventoryDatagridview.AllowUserToDeleteRows = false;
            this.SupplyInventoryDatagridview.AllowUserToResizeColumns = false;
            this.SupplyInventoryDatagridview.AllowUserToResizeRows = false;
            this.SupplyInventoryDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplyInventoryDatagridview.Location = new System.Drawing.Point(6, 111);
            this.SupplyInventoryDatagridview.MultiSelect = false;
            this.SupplyInventoryDatagridview.Name = "SupplyInventoryDatagridview";
            this.SupplyInventoryDatagridview.ReadOnly = true;
            this.SupplyInventoryDatagridview.RowHeadersVisible = false;
            this.SupplyInventoryDatagridview.RowTemplate.Height = 24;
            this.SupplyInventoryDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplyInventoryDatagridview.Size = new System.Drawing.Size(696, 542);
            this.SupplyInventoryDatagridview.TabIndex = 7;
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
            // explainLabel2
            // 
            this.explainLabel2.AutoSize = true;
            this.explainLabel2.Location = new System.Drawing.Point(9, 742);
            this.explainLabel2.Name = "explainLabel2";
            this.explainLabel2.Size = new System.Drawing.Size(218, 13);
            this.explainLabel2.TabIndex = 11;
            this.explainLabel2.Text = "* แก้ใข หมายถึงแก้ใขรายละเอียดกรณีที่ใส่ผิด";
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
            // searchSupplyRequestTextBox
            // 
            this.searchSupplyRequestTextBox.Location = new System.Drawing.Point(102, 61);
            this.searchSupplyRequestTextBox.Name = "searchSupplyRequestTextBox";
            this.searchSupplyRequestTextBox.Size = new System.Drawing.Size(258, 20);
            this.searchSupplyRequestTextBox.TabIndex = 13;
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
            this.supplyRequestDataGridView.Size = new System.Drawing.Size(696, 542);
            this.supplyRequestDataGridView.TabIndex = 13;
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
            // openPRButton
            // 
            this.openPRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openPRButton.Location = new System.Drawing.Point(5, 659);
            this.openPRButton.Name = "openPRButton";
            this.openPRButton.Size = new System.Drawing.Size(124, 52);
            this.openPRButton.TabIndex = 14;
            this.openPRButton.Text = "เปิดคำขอซื้อ";
            this.openPRButton.UseVisualStyleBackColor = true;
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
            // 
            // editPRButton
            // 
            this.editPRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPRButton.Location = new System.Drawing.Point(135, 659);
            this.editPRButton.Name = "editPRButton";
            this.editPRButton.Size = new System.Drawing.Size(124, 52);
            this.editPRButton.TabIndex = 16;
            this.editPRButton.Text = "แก้ใขคำขอซื้อ";
            this.editPRButton.UseVisualStyleBackColor = true;
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
            // 
            // removePRButton
            // 
            this.removePRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePRButton.Location = new System.Drawing.Point(265, 659);
            this.removePRButton.Name = "removePRButton";
            this.removePRButton.Size = new System.Drawing.Size(124, 52);
            this.removePRButton.TabIndex = 18;
            this.removePRButton.Text = "ลบคำขอซื้อ";
            this.removePRButton.UseVisualStyleBackColor = true;
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
            // CompletePRButton
            // 
            this.CompletePRButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CompletePRButton.Location = new System.Drawing.Point(577, 659);
            this.CompletePRButton.Name = "CompletePRButton";
            this.CompletePRButton.Size = new System.Drawing.Size(124, 52);
            this.CompletePRButton.TabIndex = 20;
            this.CompletePRButton.Text = "ตรวจรับสินค้า";
            this.CompletePRButton.UseVisualStyleBackColor = true;
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
            // SupplyControlMainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1450, 780);
            this.ControlBox = false;
            this.Controls.Add(this.SupplyRequestGroupBox);
            this.Controls.Add(this.SupplyInventoryGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "SupplyControlMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.SupplyInventoryGroupBox.ResumeLayout(false);
            this.SupplyInventoryGroupBox.PerformLayout();
            this.SupplyRequestGroupBox.ResumeLayout(false);
            this.SupplyRequestGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplyInventoryDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyRequestDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox SupplyInventoryGroupBox;
        private System.Windows.Forms.GroupBox SupplyRequestGroupBox;
        private System.Windows.Forms.Label SupplyInventoryLabel;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.ComboBox supplyTypeComboBox;
        private System.Windows.Forms.TextBox searchSupplyInventoryTextBox;
        private System.Windows.Forms.Label supplyInventoryDatagridviewLabel;
        private System.Windows.Forms.DataGridView SupplyInventoryDatagridview;
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
        private System.Windows.Forms.Button editPRButton;
        private System.Windows.Forms.Button backToMainMenuButton;
    }
}