namespace Admin_Program.SupplyManagement.UIClass.QuotationManage
{
    partial class CreateQuotationForm
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
            this.supplierNameLabel = new System.Windows.Forms.Label();
            this.supplierComboBox = new System.Windows.Forms.ComboBox();
            this.CreateSupplierButton = new System.Windows.Forms.Button();
            this.supplierAddressLabel = new System.Windows.Forms.Label();
            this.supplierAddressrichTextBox = new System.Windows.Forms.RichTextBox();
            this.quotationNumberlabel = new System.Windows.Forms.Label();
            this.quotationNumberTextBox = new System.Windows.Forms.TextBox();
            this.issueDatelabel = new System.Windows.Forms.Label();
            this.validDatelabel = new System.Windows.Forms.Label();
            this.issuedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.validdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.hasValidDatecheckBox = new System.Windows.Forms.CheckBox();
            this.attachQuotationButton = new System.Windows.Forms.Button();
            this.pdfURLtextBox = new System.Windows.Forms.TextBox();
            this.quotationlinkLabel = new System.Windows.Forms.LinkLabel();
            this.supplyListlabel = new System.Windows.Forms.Label();
            this.supplyDatagridview = new System.Windows.Forms.DataGridView();
            this.supplySearchtextBox = new System.Windows.Forms.TextBox();
            this.supplyTypelabel = new System.Windows.Forms.Label();
            this.supplyTypecomboBox = new System.Windows.Forms.ComboBox();
            this.supplyPricelabel = new System.Windows.Forms.Label();
            this.supplyPricetextBox = new System.Windows.Forms.TextBox();
            this.addSupplybutton = new System.Windows.Forms.Button();
            this.supplyInQuotationlabel = new System.Windows.Forms.Label();
            this.supplyInQuotationdataGridView = new System.Windows.Forms.DataGridView();
            this.removeSupplybutton = new System.Windows.Forms.Button();
            this.createQuotationbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.supplyDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInQuotationdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // supplierNameLabel
            // 
            this.supplierNameLabel.AutoSize = true;
            this.supplierNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierNameLabel.Location = new System.Drawing.Point(12, 6);
            this.supplierNameLabel.Name = "supplierNameLabel";
            this.supplierNameLabel.Size = new System.Drawing.Size(115, 20);
            this.supplierNameLabel.TabIndex = 21;
            this.supplierNameLabel.Text = "ชื่อซัพพลายเออร์ :";
            // 
            // supplierComboBox
            // 
            this.supplierComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierComboBox.FormattingEnabled = true;
            this.supplierComboBox.Location = new System.Drawing.Point(133, 4);
            this.supplierComboBox.Name = "supplierComboBox";
            this.supplierComboBox.Size = new System.Drawing.Size(486, 26);
            this.supplierComboBox.TabIndex = 31;
            this.supplierComboBox.SelectedIndexChanged += new System.EventHandler(this.supplierComboBox_SelectedIndexChanged);
            // 
            // CreateSupplierButton
            // 
            this.CreateSupplierButton.Location = new System.Drawing.Point(625, 2);
            this.CreateSupplierButton.Name = "CreateSupplierButton";
            this.CreateSupplierButton.Size = new System.Drawing.Size(138, 31);
            this.CreateSupplierButton.TabIndex = 32;
            this.CreateSupplierButton.Text = "จัดการซัพพลายเออร์";
            this.CreateSupplierButton.UseVisualStyleBackColor = true;
            this.CreateSupplierButton.Click += new System.EventHandler(this.CreateSupplierButton_Click);
            // 
            // supplierAddressLabel
            // 
            this.supplierAddressLabel.AutoSize = true;
            this.supplierAddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierAddressLabel.Location = new System.Drawing.Point(3, 41);
            this.supplierAddressLabel.Name = "supplierAddressLabel";
            this.supplierAddressLabel.Size = new System.Drawing.Size(124, 20);
            this.supplierAddressLabel.TabIndex = 33;
            this.supplierAddressLabel.Text = "ที่อยู่ซัพพลายเออร์ :";
            // 
            // supplierAddressrichTextBox
            // 
            this.supplierAddressrichTextBox.Location = new System.Drawing.Point(133, 43);
            this.supplierAddressrichTextBox.Name = "supplierAddressrichTextBox";
            this.supplierAddressrichTextBox.ReadOnly = true;
            this.supplierAddressrichTextBox.Size = new System.Drawing.Size(486, 96);
            this.supplierAddressrichTextBox.TabIndex = 34;
            this.supplierAddressrichTextBox.Text = "";
            // 
            // quotationNumberlabel
            // 
            this.quotationNumberlabel.AutoSize = true;
            this.quotationNumberlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.quotationNumberlabel.Location = new System.Drawing.Point(0, 151);
            this.quotationNumberlabel.Name = "quotationNumberlabel";
            this.quotationNumberlabel.Size = new System.Drawing.Size(127, 20);
            this.quotationNumberlabel.TabIndex = 35;
            this.quotationNumberlabel.Text = "เลขที่ใบเสนอราคา :";
            // 
            // quotationNumberTextBox
            // 
            this.quotationNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.quotationNumberTextBox.Location = new System.Drawing.Point(133, 148);
            this.quotationNumberTextBox.Name = "quotationNumberTextBox";
            this.quotationNumberTextBox.Size = new System.Drawing.Size(153, 26);
            this.quotationNumberTextBox.TabIndex = 36;
            // 
            // issueDatelabel
            // 
            this.issueDatelabel.AutoSize = true;
            this.issueDatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.issueDatelabel.Location = new System.Drawing.Point(300, 154);
            this.issueDatelabel.Name = "issueDatelabel";
            this.issueDatelabel.Size = new System.Drawing.Size(113, 20);
            this.issueDatelabel.TabIndex = 37;
            this.issueDatelabel.Text = "วันที่ออกเอกสาร :";
            // 
            // validDatelabel
            // 
            this.validDatelabel.AutoSize = true;
            this.validDatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.validDatelabel.Location = new System.Drawing.Point(336, 190);
            this.validDatelabel.Name = "validDatelabel";
            this.validDatelabel.Size = new System.Drawing.Size(77, 20);
            this.validDatelabel.TabIndex = 38;
            this.validDatelabel.Text = "วันที่สิ้นสุด :";
            // 
            // issuedateTimePicker
            // 
            this.issuedateTimePicker.Location = new System.Drawing.Point(419, 154);
            this.issuedateTimePicker.Name = "issuedateTimePicker";
            this.issuedateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.issuedateTimePicker.TabIndex = 39;
            // 
            // validdateTimePicker
            // 
            this.validdateTimePicker.Location = new System.Drawing.Point(419, 190);
            this.validdateTimePicker.Name = "validdateTimePicker";
            this.validdateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.validdateTimePicker.TabIndex = 40;
            // 
            // hasValidDatecheckBox
            // 
            this.hasValidDatecheckBox.AutoSize = true;
            this.hasValidDatecheckBox.Location = new System.Drawing.Point(204, 193);
            this.hasValidDatecheckBox.Name = "hasValidDatecheckBox";
            this.hasValidDatecheckBox.Size = new System.Drawing.Size(126, 17);
            this.hasValidDatecheckBox.TabIndex = 41;
            this.hasValidDatecheckBox.Text = "จนกว่าจะแจ้งให้ทราบ";
            this.hasValidDatecheckBox.UseVisualStyleBackColor = true;
            this.hasValidDatecheckBox.CheckedChanged += new System.EventHandler(this.hasValidDatecheckBox_CheckedChanged);
            // 
            // attachQuotationButton
            // 
            this.attachQuotationButton.Location = new System.Drawing.Point(7, 223);
            this.attachQuotationButton.Name = "attachQuotationButton";
            this.attachQuotationButton.Size = new System.Drawing.Size(145, 31);
            this.attachQuotationButton.TabIndex = 42;
            this.attachQuotationButton.Text = "แนบใบเสนอราคา";
            this.attachQuotationButton.UseVisualStyleBackColor = true;
            this.attachQuotationButton.Click += new System.EventHandler(this.attachQuotationButton_Click);
            // 
            // pdfURLtextBox
            // 
            this.pdfURLtextBox.Enabled = false;
            this.pdfURLtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.pdfURLtextBox.Location = new System.Drawing.Point(162, 228);
            this.pdfURLtextBox.Name = "pdfURLtextBox";
            this.pdfURLtextBox.ReadOnly = true;
            this.pdfURLtextBox.Size = new System.Drawing.Size(394, 26);
            this.pdfURLtextBox.TabIndex = 43;
            // 
            // quotationlinkLabel
            // 
            this.quotationlinkLabel.AutoSize = true;
            this.quotationlinkLabel.Location = new System.Drawing.Point(562, 232);
            this.quotationlinkLabel.Name = "quotationlinkLabel";
            this.quotationlinkLabel.Size = new System.Drawing.Size(57, 13);
            this.quotationlinkLabel.TabIndex = 44;
            this.quotationlinkLabel.TabStop = true;
            this.quotationlinkLabel.Text = "ดูไฟล์แนบ";
            this.quotationlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.quotationlinkLabel_LinkClicked);
            // 
            // supplyListlabel
            // 
            this.supplyListlabel.AutoSize = true;
            this.supplyListlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyListlabel.Location = new System.Drawing.Point(8, 266);
            this.supplyListlabel.Name = "supplyListlabel";
            this.supplyListlabel.Size = new System.Drawing.Size(86, 20);
            this.supplyListlabel.TabIndex = 45;
            this.supplyListlabel.Text = "รายการวัสดุ :";
            // 
            // supplyDatagridview
            // 
            this.supplyDatagridview.AllowUserToAddRows = false;
            this.supplyDatagridview.AllowUserToDeleteRows = false;
            this.supplyDatagridview.AllowUserToResizeColumns = false;
            this.supplyDatagridview.AllowUserToResizeRows = false;
            this.supplyDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyDatagridview.Location = new System.Drawing.Point(12, 295);
            this.supplyDatagridview.MultiSelect = false;
            this.supplyDatagridview.Name = "supplyDatagridview";
            this.supplyDatagridview.ReadOnly = true;
            this.supplyDatagridview.RowHeadersVisible = false;
            this.supplyDatagridview.RowTemplate.Height = 24;
            this.supplyDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyDatagridview.ShowCellToolTips = false;
            this.supplyDatagridview.Size = new System.Drawing.Size(607, 437);
            this.supplyDatagridview.TabIndex = 46;
            // 
            // supplySearchtextBox
            // 
            this.supplySearchtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplySearchtextBox.Location = new System.Drawing.Point(96, 263);
            this.supplySearchtextBox.Name = "supplySearchtextBox";
            this.supplySearchtextBox.Size = new System.Drawing.Size(190, 26);
            this.supplySearchtextBox.TabIndex = 47;
            this.supplySearchtextBox.TextChanged += new System.EventHandler(this.supplySearchtextBox_TextChanged);
            // 
            // supplyTypelabel
            // 
            this.supplyTypelabel.AutoSize = true;
            this.supplyTypelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyTypelabel.Location = new System.Drawing.Point(292, 266);
            this.supplyTypelabel.Name = "supplyTypelabel";
            this.supplyTypelabel.Size = new System.Drawing.Size(65, 20);
            this.supplyTypelabel.TabIndex = 48;
            this.supplyTypelabel.Text = "ประเภท :";
            // 
            // supplyTypecomboBox
            // 
            this.supplyTypecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyTypecomboBox.FormattingEnabled = true;
            this.supplyTypecomboBox.Location = new System.Drawing.Point(363, 264);
            this.supplyTypecomboBox.Name = "supplyTypecomboBox";
            this.supplyTypecomboBox.Size = new System.Drawing.Size(256, 26);
            this.supplyTypecomboBox.TabIndex = 49;
            this.supplyTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.supplyTypecomboBox_SelectedIndexChanged);
            // 
            // supplyPricelabel
            // 
            this.supplyPricelabel.AutoSize = true;
            this.supplyPricelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyPricelabel.Location = new System.Drawing.Point(215, 744);
            this.supplyPricelabel.Name = "supplyPricelabel";
            this.supplyPricelabel.Size = new System.Drawing.Size(97, 20);
            this.supplyPricelabel.TabIndex = 50;
            this.supplyPricelabel.Text = "ราคาต่อหน่วย :";
            // 
            // supplyPricetextBox
            // 
            this.supplyPricetextBox.BackColor = System.Drawing.SystemColors.Info;
            this.supplyPricetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyPricetextBox.Location = new System.Drawing.Point(318, 741);
            this.supplyPricetextBox.Name = "supplyPricetextBox";
            this.supplyPricetextBox.Size = new System.Drawing.Size(178, 26);
            this.supplyPricetextBox.TabIndex = 51;
            this.supplyPricetextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.supplyPricetextBox_KeyPress);
            // 
            // addSupplybutton
            // 
            this.addSupplybutton.Location = new System.Drawing.Point(502, 738);
            this.addSupplybutton.Name = "addSupplybutton";
            this.addSupplybutton.Size = new System.Drawing.Size(117, 31);
            this.addSupplybutton.TabIndex = 52;
            this.addSupplybutton.Text = "เพิ่ม";
            this.addSupplybutton.UseVisualStyleBackColor = true;
            this.addSupplybutton.Click += new System.EventHandler(this.addSupplybutton_Click);
            // 
            // supplyInQuotationlabel
            // 
            this.supplyInQuotationlabel.AutoSize = true;
            this.supplyInQuotationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyInQuotationlabel.Location = new System.Drawing.Point(632, 272);
            this.supplyInQuotationlabel.Name = "supplyInQuotationlabel";
            this.supplyInQuotationlabel.Size = new System.Drawing.Size(110, 20);
            this.supplyInQuotationlabel.TabIndex = 53;
            this.supplyInQuotationlabel.Text = "สรุปรายการวัสดุ :";
            // 
            // supplyInQuotationdataGridView
            // 
            this.supplyInQuotationdataGridView.AllowUserToAddRows = false;
            this.supplyInQuotationdataGridView.AllowUserToDeleteRows = false;
            this.supplyInQuotationdataGridView.AllowUserToResizeColumns = false;
            this.supplyInQuotationdataGridView.AllowUserToResizeRows = false;
            this.supplyInQuotationdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyInQuotationdataGridView.Location = new System.Drawing.Point(636, 295);
            this.supplyInQuotationdataGridView.MultiSelect = false;
            this.supplyInQuotationdataGridView.Name = "supplyInQuotationdataGridView";
            this.supplyInQuotationdataGridView.ReadOnly = true;
            this.supplyInQuotationdataGridView.RowHeadersVisible = false;
            this.supplyInQuotationdataGridView.RowTemplate.Height = 24;
            this.supplyInQuotationdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInQuotationdataGridView.ShowCellToolTips = false;
            this.supplyInQuotationdataGridView.Size = new System.Drawing.Size(816, 437);
            this.supplyInQuotationdataGridView.TabIndex = 54;
            this.supplyInQuotationdataGridView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.supplyInQuotationdataGridView_DataBindingComplete);
            // 
            // removeSupplybutton
            // 
            this.removeSupplybutton.Location = new System.Drawing.Point(1335, 738);
            this.removeSupplybutton.Name = "removeSupplybutton";
            this.removeSupplybutton.Size = new System.Drawing.Size(117, 31);
            this.removeSupplybutton.TabIndex = 55;
            this.removeSupplybutton.Text = "ลบ";
            this.removeSupplybutton.UseVisualStyleBackColor = true;
            this.removeSupplybutton.Click += new System.EventHandler(this.removeSupplybutton_Click);
            // 
            // createQuotationbutton
            // 
            this.createQuotationbutton.BackColor = System.Drawing.SystemColors.Info;
            this.createQuotationbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createQuotationbutton.Location = new System.Drawing.Point(1314, 214);
            this.createQuotationbutton.Name = "createQuotationbutton";
            this.createQuotationbutton.Size = new System.Drawing.Size(138, 72);
            this.createQuotationbutton.TabIndex = 56;
            this.createQuotationbutton.Text = "สร้าง";
            this.createQuotationbutton.UseVisualStyleBackColor = false;
            this.createQuotationbutton.Click += new System.EventHandler(this.createQuotationbutton_Click);
            // 
            // CreateQuotationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.createQuotationbutton);
            this.Controls.Add(this.removeSupplybutton);
            this.Controls.Add(this.supplyInQuotationdataGridView);
            this.Controls.Add(this.supplyInQuotationlabel);
            this.Controls.Add(this.addSupplybutton);
            this.Controls.Add(this.supplyPricetextBox);
            this.Controls.Add(this.supplyPricelabel);
            this.Controls.Add(this.supplyTypecomboBox);
            this.Controls.Add(this.supplyTypelabel);
            this.Controls.Add(this.supplySearchtextBox);
            this.Controls.Add(this.supplyDatagridview);
            this.Controls.Add(this.supplyListlabel);
            this.Controls.Add(this.quotationlinkLabel);
            this.Controls.Add(this.pdfURLtextBox);
            this.Controls.Add(this.attachQuotationButton);
            this.Controls.Add(this.hasValidDatecheckBox);
            this.Controls.Add(this.validdateTimePicker);
            this.Controls.Add(this.issuedateTimePicker);
            this.Controls.Add(this.validDatelabel);
            this.Controls.Add(this.issueDatelabel);
            this.Controls.Add(this.quotationNumberTextBox);
            this.Controls.Add(this.quotationNumberlabel);
            this.Controls.Add(this.supplierAddressrichTextBox);
            this.Controls.Add(this.supplierAddressLabel);
            this.Controls.Add(this.CreateSupplierButton);
            this.Controls.Add(this.supplierComboBox);
            this.Controls.Add(this.supplierNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateQuotationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "สร้างใบเสนอราคา";
            ((System.ComponentModel.ISupportInitialize)(this.supplyDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInQuotationdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label supplierNameLabel;
        private System.Windows.Forms.ComboBox supplierComboBox;
        private System.Windows.Forms.Button CreateSupplierButton;
        private System.Windows.Forms.Label supplierAddressLabel;
        private System.Windows.Forms.RichTextBox supplierAddressrichTextBox;
        private System.Windows.Forms.Label quotationNumberlabel;
        private System.Windows.Forms.TextBox quotationNumberTextBox;
        private System.Windows.Forms.Label issueDatelabel;
        private System.Windows.Forms.Label validDatelabel;
        private System.Windows.Forms.DateTimePicker issuedateTimePicker;
        private System.Windows.Forms.DateTimePicker validdateTimePicker;
        private System.Windows.Forms.CheckBox hasValidDatecheckBox;
        private System.Windows.Forms.Button attachQuotationButton;
        private System.Windows.Forms.TextBox pdfURLtextBox;
        private System.Windows.Forms.LinkLabel quotationlinkLabel;
        private System.Windows.Forms.Label supplyListlabel;
        private System.Windows.Forms.DataGridView supplyDatagridview;
        private System.Windows.Forms.TextBox supplySearchtextBox;
        private System.Windows.Forms.Label supplyTypelabel;
        private System.Windows.Forms.ComboBox supplyTypecomboBox;
        private System.Windows.Forms.Label supplyPricelabel;
        private System.Windows.Forms.TextBox supplyPricetextBox;
        private System.Windows.Forms.Button addSupplybutton;
        private System.Windows.Forms.Label supplyInQuotationlabel;
        private System.Windows.Forms.DataGridView supplyInQuotationdataGridView;
        private System.Windows.Forms.Button removeSupplybutton;
        private System.Windows.Forms.Button createQuotationbutton;
    }
}