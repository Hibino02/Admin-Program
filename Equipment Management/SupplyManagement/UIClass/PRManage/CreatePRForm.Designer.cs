namespace Admin_Program.SupplyManagement.UIClass.PRManage
{
    partial class CreatePRForm
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
            this.supplyInPRgroupBox = new System.Windows.Forms.GroupBox();
            this.quantitytextBox = new System.Windows.Forms.TextBox();
            this.supplyQuantitylabel = new System.Windows.Forms.Label();
            this.supplyInPRdataGridView = new System.Windows.Forms.DataGridView();
            this.addToSupplyInPRbutton = new System.Windows.Forms.Button();
            this.removeFromSupplyInPRbutton = new System.Windows.Forms.Button();
            this.preSupplyInPRdataGridView = new System.Windows.Forms.DataGridView();
            this.PRgroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.currentSelectedQuotationdataGridView = new System.Windows.Forms.DataGridView();
            this.selectedSupplyInQuotationlabel = new System.Windows.Forms.Label();
            this.quotationPDFlinkLabel = new System.Windows.Forms.LinkLabel();
            this.addQuotationbutton = new System.Windows.Forms.Button();
            this.supplyInQuotationlabel = new System.Windows.Forms.Label();
            this.supplyInQuotationdataGridView = new System.Windows.Forms.DataGridView();
            this.quotationDatagridview = new System.Windows.Forms.DataGridView();
            this.quotation1label = new System.Windows.Forms.Label();
            this.supplierAddresslabel = new System.Windows.Forms.Label();
            this.supplierAddressrichTextBox = new System.Windows.Forms.RichTextBox();
            this.suppliercomboBox = new System.Windows.Forms.ComboBox();
            this.contactPersontextBox = new System.Windows.Forms.TextBox();
            this.contactPersonlabel = new System.Windows.Forms.Label();
            this.deliveryDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.deliveryDatelabel = new System.Windows.Forms.Label();
            this.supplierlabel = new System.Windows.Forms.Label();
            this.otherReasontextBox = new System.Windows.Forms.TextBox();
            this.othercheckBox = new System.Windows.Forms.CheckBox();
            this.rentalLeasecheckBox = new System.Windows.Forms.CheckBox();
            this.maintainancecheckBox = new System.Windows.Forms.CheckBox();
            this.complayAssetcheckBox = new System.Windows.Forms.CheckBox();
            this.costOfSalecheckBox = new System.Windows.Forms.CheckBox();
            this.forAccountlabel = new System.Windows.Forms.Label();
            this.PRTitletextBox = new System.Windows.Forms.TextBox();
            this.PRtitlelabel = new System.Windows.Forms.Label();
            this.requestertextBox = new System.Windows.Forms.TextBox();
            this.prCreatorNamelabel = new System.Windows.Forms.Label();
            this.supplyInPRgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.preSupplyInPRdataGridView)).BeginInit();
            this.PRgroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentSelectedQuotationdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInQuotationdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // supplyInPRgroupBox
            // 
            this.supplyInPRgroupBox.Controls.Add(this.quantitytextBox);
            this.supplyInPRgroupBox.Controls.Add(this.supplyQuantitylabel);
            this.supplyInPRgroupBox.Controls.Add(this.supplyInPRdataGridView);
            this.supplyInPRgroupBox.Controls.Add(this.addToSupplyInPRbutton);
            this.supplyInPRgroupBox.Controls.Add(this.removeFromSupplyInPRbutton);
            this.supplyInPRgroupBox.Controls.Add(this.preSupplyInPRdataGridView);
            this.supplyInPRgroupBox.Location = new System.Drawing.Point(-1, 407);
            this.supplyInPRgroupBox.Name = "supplyInPRgroupBox";
            this.supplyInPRgroupBox.Size = new System.Drawing.Size(1359, 374);
            this.supplyInPRgroupBox.TabIndex = 32;
            this.supplyInPRgroupBox.TabStop = false;
            // 
            // quantitytextBox
            // 
            this.quantitytextBox.BackColor = System.Drawing.SystemColors.Info;
            this.quantitytextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.quantitytextBox.Location = new System.Drawing.Point(902, 333);
            this.quantitytextBox.Name = "quantitytextBox";
            this.quantitytextBox.Size = new System.Drawing.Size(136, 22);
            this.quantitytextBox.TabIndex = 35;
            this.quantitytextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.quantitytextBox_KeyPress);
            // 
            // supplyQuantitylabel
            // 
            this.supplyQuantitylabel.AutoSize = true;
            this.supplyQuantitylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyQuantitylabel.Location = new System.Drawing.Point(825, 328);
            this.supplyQuantitylabel.Name = "supplyQuantitylabel";
            this.supplyQuantitylabel.Size = new System.Drawing.Size(71, 24);
            this.supplyQuantitylabel.TabIndex = 34;
            this.supplyQuantitylabel.Text = "จำนวน :";
            // 
            // supplyInPRdataGridView
            // 
            this.supplyInPRdataGridView.AllowUserToAddRows = false;
            this.supplyInPRdataGridView.AllowUserToDeleteRows = false;
            this.supplyInPRdataGridView.AllowUserToResizeColumns = false;
            this.supplyInPRdataGridView.AllowUserToResizeRows = false;
            this.supplyInPRdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyInPRdataGridView.Location = new System.Drawing.Point(6, 18);
            this.supplyInPRdataGridView.MultiSelect = false;
            this.supplyInPRdataGridView.Name = "supplyInPRdataGridView";
            this.supplyInPRdataGridView.ReadOnly = true;
            this.supplyInPRdataGridView.RowHeadersVisible = false;
            this.supplyInPRdataGridView.RowTemplate.Height = 24;
            this.supplyInPRdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInPRdataGridView.ShowCellToolTips = false;
            this.supplyInPRdataGridView.Size = new System.Drawing.Size(736, 338);
            this.supplyInPRdataGridView.TabIndex = 28;
            this.supplyInPRdataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.supplyInPRdataGridView_RowPrePaint);
            // 
            // addToSupplyInPRbutton
            // 
            this.addToSupplyInPRbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.addToSupplyInPRbutton.Location = new System.Drawing.Point(748, 175);
            this.addToSupplyInPRbutton.Name = "addToSupplyInPRbutton";
            this.addToSupplyInPRbutton.Size = new System.Drawing.Size(75, 45);
            this.addToSupplyInPRbutton.TabIndex = 27;
            this.addToSupplyInPRbutton.Text = "◀️";
            this.addToSupplyInPRbutton.UseVisualStyleBackColor = true;
            this.addToSupplyInPRbutton.Click += new System.EventHandler(this.addToSupplyInPRbutton_Click);
            // 
            // removeFromSupplyInPRbutton
            // 
            this.removeFromSupplyInPRbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.removeFromSupplyInPRbutton.Location = new System.Drawing.Point(748, 124);
            this.removeFromSupplyInPRbutton.Name = "removeFromSupplyInPRbutton";
            this.removeFromSupplyInPRbutton.Size = new System.Drawing.Size(75, 45);
            this.removeFromSupplyInPRbutton.TabIndex = 26;
            this.removeFromSupplyInPRbutton.Text = "▶️";
            this.removeFromSupplyInPRbutton.UseVisualStyleBackColor = true;
            // 
            // preSupplyInPRdataGridView
            // 
            this.preSupplyInPRdataGridView.AllowUserToAddRows = false;
            this.preSupplyInPRdataGridView.AllowUserToDeleteRows = false;
            this.preSupplyInPRdataGridView.AllowUserToResizeColumns = false;
            this.preSupplyInPRdataGridView.AllowUserToResizeRows = false;
            this.preSupplyInPRdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.preSupplyInPRdataGridView.Location = new System.Drawing.Point(829, 18);
            this.preSupplyInPRdataGridView.MultiSelect = false;
            this.preSupplyInPRdataGridView.Name = "preSupplyInPRdataGridView";
            this.preSupplyInPRdataGridView.ReadOnly = true;
            this.preSupplyInPRdataGridView.RowHeadersVisible = false;
            this.preSupplyInPRdataGridView.RowTemplate.Height = 24;
            this.preSupplyInPRdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.preSupplyInPRdataGridView.ShowCellToolTips = false;
            this.preSupplyInPRdataGridView.Size = new System.Drawing.Size(511, 307);
            this.preSupplyInPRdataGridView.TabIndex = 24;
            this.preSupplyInPRdataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.preSupplyInPRdataGridView_CellClick);
            this.preSupplyInPRdataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.preSupplyInPRdataGridView_RowPrePaint);
            // 
            // PRgroupBox
            // 
            this.PRgroupBox.Controls.Add(this.label1);
            this.PRgroupBox.Controls.Add(this.currentSelectedQuotationdataGridView);
            this.PRgroupBox.Controls.Add(this.selectedSupplyInQuotationlabel);
            this.PRgroupBox.Controls.Add(this.quotationPDFlinkLabel);
            this.PRgroupBox.Controls.Add(this.addQuotationbutton);
            this.PRgroupBox.Controls.Add(this.supplyInQuotationlabel);
            this.PRgroupBox.Controls.Add(this.supplyInQuotationdataGridView);
            this.PRgroupBox.Controls.Add(this.quotationDatagridview);
            this.PRgroupBox.Controls.Add(this.quotation1label);
            this.PRgroupBox.Controls.Add(this.supplierAddresslabel);
            this.PRgroupBox.Controls.Add(this.supplierAddressrichTextBox);
            this.PRgroupBox.Controls.Add(this.suppliercomboBox);
            this.PRgroupBox.Controls.Add(this.contactPersontextBox);
            this.PRgroupBox.Controls.Add(this.contactPersonlabel);
            this.PRgroupBox.Controls.Add(this.deliveryDateTimePicker);
            this.PRgroupBox.Controls.Add(this.deliveryDatelabel);
            this.PRgroupBox.Controls.Add(this.supplierlabel);
            this.PRgroupBox.Controls.Add(this.otherReasontextBox);
            this.PRgroupBox.Controls.Add(this.othercheckBox);
            this.PRgroupBox.Controls.Add(this.rentalLeasecheckBox);
            this.PRgroupBox.Controls.Add(this.maintainancecheckBox);
            this.PRgroupBox.Controls.Add(this.complayAssetcheckBox);
            this.PRgroupBox.Controls.Add(this.costOfSalecheckBox);
            this.PRgroupBox.Controls.Add(this.forAccountlabel);
            this.PRgroupBox.Controls.Add(this.PRTitletextBox);
            this.PRgroupBox.Controls.Add(this.PRtitlelabel);
            this.PRgroupBox.Controls.Add(this.requestertextBox);
            this.PRgroupBox.Controls.Add(this.prCreatorNamelabel);
            this.PRgroupBox.Location = new System.Drawing.Point(-1, 0);
            this.PRgroupBox.Name = "PRgroupBox";
            this.PRgroupBox.Size = new System.Drawing.Size(1468, 419);
            this.PRgroupBox.TabIndex = 33;
            this.PRgroupBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(571, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 24);
            this.label1.TabIndex = 64;
            this.label1.Text = "ใบเสนอราคาที่ถูกเลือกปัจจุบัน :";
            // 
            // currentSelectedQuotationdataGridView
            // 
            this.currentSelectedQuotationdataGridView.AllowUserToAddRows = false;
            this.currentSelectedQuotationdataGridView.AllowUserToDeleteRows = false;
            this.currentSelectedQuotationdataGridView.AllowUserToResizeColumns = false;
            this.currentSelectedQuotationdataGridView.AllowUserToResizeRows = false;
            this.currentSelectedQuotationdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentSelectedQuotationdataGridView.Location = new System.Drawing.Point(575, 226);
            this.currentSelectedQuotationdataGridView.MultiSelect = false;
            this.currentSelectedQuotationdataGridView.Name = "currentSelectedQuotationdataGridView";
            this.currentSelectedQuotationdataGridView.ReadOnly = true;
            this.currentSelectedQuotationdataGridView.RowHeadersVisible = false;
            this.currentSelectedQuotationdataGridView.RowTemplate.Height = 24;
            this.currentSelectedQuotationdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.currentSelectedQuotationdataGridView.ShowCellToolTips = false;
            this.currentSelectedQuotationdataGridView.Size = new System.Drawing.Size(368, 154);
            this.currentSelectedQuotationdataGridView.TabIndex = 63;
            this.currentSelectedQuotationdataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.currentSelectedQuotationdataGridView_RowPrePaint);
            this.currentSelectedQuotationdataGridView.SelectionChanged += new System.EventHandler(this.currentSelectedQuotationdataGridView_SelectionChanged);
            // 
            // selectedSupplyInQuotationlabel
            // 
            this.selectedSupplyInQuotationlabel.AutoSize = true;
            this.selectedSupplyInQuotationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.selectedSupplyInQuotationlabel.Location = new System.Drawing.Point(1104, 385);
            this.selectedSupplyInQuotationlabel.Name = "selectedSupplyInQuotationlabel";
            this.selectedSupplyInQuotationlabel.Size = new System.Drawing.Size(262, 24);
            this.selectedSupplyInQuotationlabel.TabIndex = 62;
            this.selectedSupplyInQuotationlabel.Text = "รายการวัสดุจากใบเสนอราคาที่เลือก :";
            // 
            // quotationPDFlinkLabel
            // 
            this.quotationPDFlinkLabel.AutoSize = true;
            this.quotationPDFlinkLabel.Location = new System.Drawing.Point(829, 16);
            this.quotationPDFlinkLabel.Name = "quotationPDFlinkLabel";
            this.quotationPDFlinkLabel.Size = new System.Drawing.Size(110, 13);
            this.quotationPDFlinkLabel.TabIndex = 61;
            this.quotationPDFlinkLabel.TabStop = true;
            this.quotationPDFlinkLabel.Text = "ดูเอกสารใบเสนอราคา";
            this.quotationPDFlinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.quotationPDFlinkLabel_LinkClicked);
            // 
            // addQuotationbutton
            // 
            this.addQuotationbutton.Location = new System.Drawing.Point(868, 197);
            this.addQuotationbutton.Name = "addQuotationbutton";
            this.addQuotationbutton.Size = new System.Drawing.Size(75, 23);
            this.addQuotationbutton.TabIndex = 60;
            this.addQuotationbutton.Text = "เพิ่ม";
            this.addQuotationbutton.UseVisualStyleBackColor = true;
            this.addQuotationbutton.Click += new System.EventHandler(this.addQuotationbutton_Click);
            // 
            // supplyInQuotationlabel
            // 
            this.supplyInQuotationlabel.AutoSize = true;
            this.supplyInQuotationlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyInQuotationlabel.Location = new System.Drawing.Point(945, 8);
            this.supplyInQuotationlabel.Name = "supplyInQuotationlabel";
            this.supplyInQuotationlabel.Size = new System.Drawing.Size(211, 24);
            this.supplyInQuotationlabel.TabIndex = 59;
            this.supplyInQuotationlabel.Text = "รายการวัสดุในใบเสนอราคา :";
            // 
            // supplyInQuotationdataGridView
            // 
            this.supplyInQuotationdataGridView.AllowUserToAddRows = false;
            this.supplyInQuotationdataGridView.AllowUserToDeleteRows = false;
            this.supplyInQuotationdataGridView.AllowUserToResizeColumns = false;
            this.supplyInQuotationdataGridView.AllowUserToResizeRows = false;
            this.supplyInQuotationdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.supplyInQuotationdataGridView.Location = new System.Drawing.Point(949, 35);
            this.supplyInQuotationdataGridView.MultiSelect = false;
            this.supplyInQuotationdataGridView.Name = "supplyInQuotationdataGridView";
            this.supplyInQuotationdataGridView.ReadOnly = true;
            this.supplyInQuotationdataGridView.RowHeadersVisible = false;
            this.supplyInQuotationdataGridView.RowTemplate.Height = 24;
            this.supplyInQuotationdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInQuotationdataGridView.ShowCellToolTips = false;
            this.supplyInQuotationdataGridView.Size = new System.Drawing.Size(511, 345);
            this.supplyInQuotationdataGridView.TabIndex = 58;
            this.supplyInQuotationdataGridView.SelectionChanged += new System.EventHandler(this.supplyInQuotationdataGridView_SelectionChanged);
            // 
            // quotationDatagridview
            // 
            this.quotationDatagridview.AllowUserToAddRows = false;
            this.quotationDatagridview.AllowUserToDeleteRows = false;
            this.quotationDatagridview.AllowUserToResizeColumns = false;
            this.quotationDatagridview.AllowUserToResizeRows = false;
            this.quotationDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.quotationDatagridview.Location = new System.Drawing.Point(575, 35);
            this.quotationDatagridview.MultiSelect = false;
            this.quotationDatagridview.Name = "quotationDatagridview";
            this.quotationDatagridview.ReadOnly = true;
            this.quotationDatagridview.RowHeadersVisible = false;
            this.quotationDatagridview.RowTemplate.Height = 24;
            this.quotationDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.quotationDatagridview.ShowCellToolTips = false;
            this.quotationDatagridview.Size = new System.Drawing.Size(368, 159);
            this.quotationDatagridview.TabIndex = 57;
            this.quotationDatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.quotationDatagridview_CellClick);
            this.quotationDatagridview.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.quotationDatagridview_DataBindingComplete);
            // 
            // quotation1label
            // 
            this.quotation1label.AutoSize = true;
            this.quotation1label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.quotation1label.Location = new System.Drawing.Point(563, 8);
            this.quotation1label.Name = "quotation1label";
            this.quotation1label.Size = new System.Drawing.Size(110, 24);
            this.quotation1label.TabIndex = 56;
            this.quotation1label.Text = "ใบเสนอราคา :";
            // 
            // supplierAddresslabel
            // 
            this.supplierAddresslabel.AutoSize = true;
            this.supplierAddresslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierAddresslabel.Location = new System.Drawing.Point(20, 298);
            this.supplierAddresslabel.Name = "supplierAddresslabel";
            this.supplierAddresslabel.Size = new System.Drawing.Size(145, 24);
            this.supplierAddresslabel.TabIndex = 55;
            this.supplierAddresslabel.Text = "ที่อยู่ซัพพลายเออร์ :";
            // 
            // supplierAddressrichTextBox
            // 
            this.supplierAddressrichTextBox.Enabled = false;
            this.supplierAddressrichTextBox.Location = new System.Drawing.Point(20, 325);
            this.supplierAddressrichTextBox.Name = "supplierAddressrichTextBox";
            this.supplierAddressrichTextBox.Size = new System.Drawing.Size(533, 78);
            this.supplierAddressrichTextBox.TabIndex = 54;
            this.supplierAddressrichTextBox.Text = "";
            // 
            // suppliercomboBox
            // 
            this.suppliercomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.suppliercomboBox.FormattingEnabled = true;
            this.suppliercomboBox.Location = new System.Drawing.Point(136, 243);
            this.suppliercomboBox.Name = "suppliercomboBox";
            this.suppliercomboBox.Size = new System.Drawing.Size(417, 32);
            this.suppliercomboBox.TabIndex = 53;
            this.suppliercomboBox.SelectedIndexChanged += new System.EventHandler(this.suppliercomboBox_SelectedIndexChanged);
            // 
            // contactPersontextBox
            // 
            this.contactPersontextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.contactPersontextBox.Location = new System.Drawing.Point(164, 192);
            this.contactPersontextBox.Name = "contactPersontextBox";
            this.contactPersontextBox.Size = new System.Drawing.Size(389, 29);
            this.contactPersontextBox.TabIndex = 52;
            // 
            // contactPersonlabel
            // 
            this.contactPersonlabel.AutoSize = true;
            this.contactPersonlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.contactPersonlabel.Location = new System.Drawing.Point(8, 197);
            this.contactPersonlabel.Name = "contactPersonlabel";
            this.contactPersonlabel.Size = new System.Drawing.Size(150, 24);
            this.contactPersonlabel.TabIndex = 51;
            this.contactPersonlabel.Text = "ชื่อผู้ติดต่อส่งสินค้า :";
            // 
            // deliveryDateTimePicker
            // 
            this.deliveryDateTimePicker.Location = new System.Drawing.Point(164, 159);
            this.deliveryDateTimePicker.Name = "deliveryDateTimePicker";
            this.deliveryDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.deliveryDateTimePicker.TabIndex = 50;
            // 
            // deliveryDatelabel
            // 
            this.deliveryDatelabel.AutoSize = true;
            this.deliveryDatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.deliveryDatelabel.Location = new System.Drawing.Point(16, 155);
            this.deliveryDatelabel.Name = "deliveryDatelabel";
            this.deliveryDatelabel.Size = new System.Drawing.Size(142, 24);
            this.deliveryDatelabel.TabIndex = 49;
            this.deliveryDatelabel.Text = "วันที่ต้องการให้ส่ง :";
            // 
            // supplierlabel
            // 
            this.supplierlabel.AutoSize = true;
            this.supplierlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplierlabel.Location = new System.Drawing.Point(16, 246);
            this.supplierlabel.Name = "supplierlabel";
            this.supplierlabel.Size = new System.Drawing.Size(114, 24);
            this.supplierlabel.TabIndex = 48;
            this.supplierlabel.Text = "ซัพพลายเออร์ :";
            // 
            // otherReasontextBox
            // 
            this.otherReasontextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.otherReasontextBox.Location = new System.Drawing.Point(164, 111);
            this.otherReasontextBox.Name = "otherReasontextBox";
            this.otherReasontextBox.Size = new System.Drawing.Size(389, 29);
            this.otherReasontextBox.TabIndex = 47;
            // 
            // othercheckBox
            // 
            this.othercheckBox.AutoSize = true;
            this.othercheckBox.Location = new System.Drawing.Point(101, 121);
            this.othercheckBox.Name = "othercheckBox";
            this.othercheckBox.Size = new System.Drawing.Size(52, 17);
            this.othercheckBox.TabIndex = 46;
            this.othercheckBox.Text = "Other";
            this.othercheckBox.UseVisualStyleBackColor = true;
            this.othercheckBox.CheckedChanged += new System.EventHandler(this.othercheckBox_CheckedChanged);
            // 
            // rentalLeasecheckBox
            // 
            this.rentalLeasecheckBox.AutoSize = true;
            this.rentalLeasecheckBox.Location = new System.Drawing.Point(456, 88);
            this.rentalLeasecheckBox.Name = "rentalLeasecheckBox";
            this.rentalLeasecheckBox.Size = new System.Drawing.Size(97, 17);
            this.rentalLeasecheckBox.TabIndex = 45;
            this.rentalLeasecheckBox.Text = "Rental / Lease";
            this.rentalLeasecheckBox.UseVisualStyleBackColor = true;
            // 
            // maintainancecheckBox
            // 
            this.maintainancecheckBox.AutoSize = true;
            this.maintainancecheckBox.Location = new System.Drawing.Point(360, 88);
            this.maintainancecheckBox.Name = "maintainancecheckBox";
            this.maintainancecheckBox.Size = new System.Drawing.Size(90, 17);
            this.maintainancecheckBox.TabIndex = 44;
            this.maintainancecheckBox.Text = "Maintainance";
            this.maintainancecheckBox.UseVisualStyleBackColor = true;
            // 
            // complayAssetcheckBox
            // 
            this.complayAssetcheckBox.AutoSize = true;
            this.complayAssetcheckBox.Location = new System.Drawing.Point(255, 88);
            this.complayAssetcheckBox.Name = "complayAssetcheckBox";
            this.complayAssetcheckBox.Size = new System.Drawing.Size(99, 17);
            this.complayAssetcheckBox.TabIndex = 43;
            this.complayAssetcheckBox.Text = "Company Asset";
            this.complayAssetcheckBox.UseVisualStyleBackColor = true;
            // 
            // costOfSalecheckBox
            // 
            this.costOfSalecheckBox.AutoSize = true;
            this.costOfSalecheckBox.Location = new System.Drawing.Point(164, 88);
            this.costOfSalecheckBox.Name = "costOfSalecheckBox";
            this.costOfSalecheckBox.Size = new System.Drawing.Size(85, 17);
            this.costOfSalecheckBox.TabIndex = 42;
            this.costOfSalecheckBox.Text = "Cost Of Sale";
            this.costOfSalecheckBox.UseVisualStyleBackColor = true;
            // 
            // forAccountlabel
            // 
            this.forAccountlabel.AutoSize = true;
            this.forAccountlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.forAccountlabel.Location = new System.Drawing.Point(20, 81);
            this.forAccountlabel.Name = "forAccountlabel";
            this.forAccountlabel.Size = new System.Drawing.Size(133, 24);
            this.forAccountlabel.TabIndex = 41;
            this.forAccountlabel.Text = "ข้อมูลสำหรับบัญชี";
            // 
            // PRTitletextBox
            // 
            this.PRTitletextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PRTitletextBox.Location = new System.Drawing.Point(164, 46);
            this.PRTitletextBox.Name = "PRTitletextBox";
            this.PRTitletextBox.Size = new System.Drawing.Size(389, 29);
            this.PRTitletextBox.TabIndex = 40;
            // 
            // PRtitlelabel
            // 
            this.PRtitlelabel.AutoSize = true;
            this.PRtitlelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PRtitlelabel.Location = new System.Drawing.Point(35, 46);
            this.PRtitlelabel.Name = "PRtitlelabel";
            this.PRtitlelabel.Size = new System.Drawing.Size(123, 24);
            this.PRtitlelabel.TabIndex = 39;
            this.PRtitlelabel.Text = "หัวข้อ คำขอซื้อ :";
            // 
            // requestertextBox
            // 
            this.requestertextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.requestertextBox.Location = new System.Drawing.Point(164, 8);
            this.requestertextBox.Name = "requestertextBox";
            this.requestertextBox.Size = new System.Drawing.Size(389, 29);
            this.requestertextBox.TabIndex = 38;
            // 
            // prCreatorNamelabel
            // 
            this.prCreatorNamelabel.AutoSize = true;
            this.prCreatorNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.prCreatorNamelabel.Location = new System.Drawing.Point(20, 11);
            this.prCreatorNamelabel.Name = "prCreatorNamelabel";
            this.prCreatorNamelabel.Size = new System.Drawing.Size(138, 24);
            this.prCreatorNamelabel.TabIndex = 37;
            this.prCreatorNamelabel.Text = "ชื่อผู้ออกคำขอซื้อ :";
            // 
            // CreatePRForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.PRgroupBox);
            this.Controls.Add(this.supplyInPRgroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePRForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "สร้างใบขอซื้อ";
            this.supplyInPRgroupBox.ResumeLayout(false);
            this.supplyInPRgroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.preSupplyInPRdataGridView)).EndInit();
            this.PRgroupBox.ResumeLayout(false);
            this.PRgroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.currentSelectedQuotationdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInQuotationdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quotationDatagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox supplyInPRgroupBox;
        private System.Windows.Forms.DataGridView supplyInPRdataGridView;
        private System.Windows.Forms.Button addToSupplyInPRbutton;
        private System.Windows.Forms.Button removeFromSupplyInPRbutton;
        private System.Windows.Forms.DataGridView preSupplyInPRdataGridView;
        private System.Windows.Forms.TextBox quantitytextBox;
        private System.Windows.Forms.Label supplyQuantitylabel;
        private System.Windows.Forms.GroupBox PRgroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView currentSelectedQuotationdataGridView;
        private System.Windows.Forms.Label selectedSupplyInQuotationlabel;
        private System.Windows.Forms.LinkLabel quotationPDFlinkLabel;
        private System.Windows.Forms.Button addQuotationbutton;
        private System.Windows.Forms.Label supplyInQuotationlabel;
        private System.Windows.Forms.DataGridView supplyInQuotationdataGridView;
        private System.Windows.Forms.DataGridView quotationDatagridview;
        private System.Windows.Forms.Label quotation1label;
        private System.Windows.Forms.Label supplierAddresslabel;
        private System.Windows.Forms.RichTextBox supplierAddressrichTextBox;
        private System.Windows.Forms.ComboBox suppliercomboBox;
        private System.Windows.Forms.TextBox contactPersontextBox;
        private System.Windows.Forms.Label contactPersonlabel;
        private System.Windows.Forms.DateTimePicker deliveryDateTimePicker;
        private System.Windows.Forms.Label deliveryDatelabel;
        private System.Windows.Forms.Label supplierlabel;
        private System.Windows.Forms.TextBox otherReasontextBox;
        private System.Windows.Forms.CheckBox othercheckBox;
        private System.Windows.Forms.CheckBox rentalLeasecheckBox;
        private System.Windows.Forms.CheckBox maintainancecheckBox;
        private System.Windows.Forms.CheckBox complayAssetcheckBox;
        private System.Windows.Forms.CheckBox costOfSalecheckBox;
        private System.Windows.Forms.Label forAccountlabel;
        private System.Windows.Forms.TextBox PRTitletextBox;
        private System.Windows.Forms.Label PRtitlelabel;
        private System.Windows.Forms.TextBox requestertextBox;
        private System.Windows.Forms.Label prCreatorNamelabel;
    }
}