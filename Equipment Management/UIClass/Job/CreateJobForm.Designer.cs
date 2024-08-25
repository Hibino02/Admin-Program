namespace Equipment_Management.UIClass.Job
{
    partial class CreateJobForm
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
            this.choseEquipmentLabel = new System.Windows.Forms.Label();
            this.equipmentDisplaydataGridView = new System.Windows.Forms.DataGridView();
            this.searchEquipmentLabel = new System.Windows.Forms.Label();
            this.equipmentListSearchTextBox = new System.Windows.Forms.TextBox();
            this.equipmentFilterListLabel = new System.Windows.Forms.Label();
            this.equipmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.equipmentSelecteddataGridView = new System.Windows.Forms.DataGridView();
            this.reporterNameLabel = new System.Windows.Forms.Label();
            this.reporterNameTextBox = new System.Windows.Forms.TextBox();
            this.reportDateLabel = new System.Windows.Forms.Label();
            this.reportDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.currentStatusLabel = new System.Windows.Forms.Label();
            this.currentStatusComboBox = new System.Windows.Forms.ComboBox();
            this.repairTypeLabel = new System.Windows.Forms.Label();
            this.repairTypeComboBox = new System.Windows.Forms.ComboBox();
            this.deciderNameTextBox = new System.Windows.Forms.TextBox();
            this.deciderNameLabel = new System.Windows.Forms.Label();
            this.decideDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.deciderDateLabel = new System.Windows.Forms.Label();
            this.reasonToChoseRepairLabel = new System.Windows.Forms.Label();
            this.reasdonToChoserepairRichTextBox = new System.Windows.Forms.RichTextBox();
            this.approveDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.approveDateLabel = new System.Windows.Forms.Label();
            this.approverNameTextBox = new System.Windows.Forms.TextBox();
            this.approverNameLabel = new System.Windows.Forms.Label();
            this.reasonToAppRichTextBox = new System.Windows.Forms.RichTextBox();
            this.resonToAppLabel = new System.Windows.Forms.Label();
            this.approveCheckLabel = new System.Windows.Forms.Label();
            this.approveCheckBox = new System.Windows.Forms.CheckBox();
            this.repairDocButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.equipmentRepaiePictureBox = new System.Windows.Forms.PictureBox();
            this.equipmentPhotoButton = new System.Windows.Forms.Button();
            this.repairDocLinkLabel = new System.Windows.Forms.LinkLabel();
            this.selectedEquipmentLabel = new System.Windows.Forms.Label();
            this.jDetailsLabel = new System.Windows.Forms.Label();
            this.jDetailsrichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDisplaydataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentSelecteddataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentRepaiePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // choseEquipmentLabel
            // 
            this.choseEquipmentLabel.AutoSize = true;
            this.choseEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choseEquipmentLabel.Location = new System.Drawing.Point(12, 78);
            this.choseEquipmentLabel.Name = "choseEquipmentLabel";
            this.choseEquipmentLabel.Size = new System.Drawing.Size(499, 25);
            this.choseEquipmentLabel.TabIndex = 0;
            this.choseEquipmentLabel.Text = "เลือกเครื่องมือ / อุปกรณ์ ที่ต้องการแจ้งซ่อม โดยการดับเบิ้ลคลิก";
            // 
            // equipmentDisplaydataGridView
            // 
            this.equipmentDisplaydataGridView.AllowUserToAddRows = false;
            this.equipmentDisplaydataGridView.AllowUserToDeleteRows = false;
            this.equipmentDisplaydataGridView.AllowUserToResizeColumns = false;
            this.equipmentDisplaydataGridView.AllowUserToResizeRows = false;
            this.equipmentDisplaydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipmentDisplaydataGridView.Location = new System.Drawing.Point(12, 106);
            this.equipmentDisplaydataGridView.MultiSelect = false;
            this.equipmentDisplaydataGridView.Name = "equipmentDisplaydataGridView";
            this.equipmentDisplaydataGridView.ReadOnly = true;
            this.equipmentDisplaydataGridView.RowHeadersVisible = false;
            this.equipmentDisplaydataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equipmentDisplaydataGridView.Size = new System.Drawing.Size(631, 258);
            this.equipmentDisplaydataGridView.TabIndex = 1;
            this.equipmentDisplaydataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentDisplaydataGridView_CellDoubleClick);
            this.equipmentDisplaydataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentDisplaydataGridView_CellMouseEnter);
            this.equipmentDisplaydataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentDisplaydataGridView_CellMouseLeave);
            this.equipmentDisplaydataGridView.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.equipmentDisplaydataGridView_RowPrePaint);
            // 
            // searchEquipmentLabel
            // 
            this.searchEquipmentLabel.AutoSize = true;
            this.searchEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchEquipmentLabel.Location = new System.Drawing.Point(7, 45);
            this.searchEquipmentLabel.Name = "searchEquipmentLabel";
            this.searchEquipmentLabel.Size = new System.Drawing.Size(223, 25);
            this.searchEquipmentLabel.TabIndex = 12;
            this.searchEquipmentLabel.Text = "พิมพ์รายละเอียดที่เกี่ยวข้อง";
            // 
            // equipmentListSearchTextBox
            // 
            this.equipmentListSearchTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.equipmentListSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.equipmentListSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentListSearchTextBox.Location = new System.Drawing.Point(250, 41);
            this.equipmentListSearchTextBox.Name = "equipmentListSearchTextBox";
            this.equipmentListSearchTextBox.Size = new System.Drawing.Size(393, 29);
            this.equipmentListSearchTextBox.TabIndex = 11;
            this.equipmentListSearchTextBox.TextChanged += new System.EventHandler(this.equipmentListSearchTextBox_TextChanged);
            // 
            // equipmentFilterListLabel
            // 
            this.equipmentFilterListLabel.AutoSize = true;
            this.equipmentFilterListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentFilterListLabel.Location = new System.Drawing.Point(8, 7);
            this.equipmentFilterListLabel.Name = "equipmentFilterListLabel";
            this.equipmentFilterListLabel.Size = new System.Drawing.Size(196, 25);
            this.equipmentFilterListLabel.TabIndex = 10;
            this.equipmentFilterListLabel.Text = "ตัวกรองประเภทอุปกรณ์";
            // 
            // equipmentTypeComboBox
            // 
            this.equipmentTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentTypeComboBox.FormattingEnabled = true;
            this.equipmentTypeComboBox.Location = new System.Drawing.Point(214, 3);
            this.equipmentTypeComboBox.Name = "equipmentTypeComboBox";
            this.equipmentTypeComboBox.Size = new System.Drawing.Size(429, 32);
            this.equipmentTypeComboBox.TabIndex = 9;
            this.equipmentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.equipmentTypeComboBox_SelectedIndexChanged);
            this.equipmentTypeComboBox.TextChanged += new System.EventHandler(this.equipmentTypeComboBox_TextChanged);
            // 
            // equipmentSelecteddataGridView
            // 
            this.equipmentSelecteddataGridView.AllowUserToAddRows = false;
            this.equipmentSelecteddataGridView.AllowUserToDeleteRows = false;
            this.equipmentSelecteddataGridView.AllowUserToResizeColumns = false;
            this.equipmentSelecteddataGridView.AllowUserToResizeRows = false;
            this.equipmentSelecteddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipmentSelecteddataGridView.Location = new System.Drawing.Point(12, 402);
            this.equipmentSelecteddataGridView.MultiSelect = false;
            this.equipmentSelecteddataGridView.Name = "equipmentSelecteddataGridView";
            this.equipmentSelecteddataGridView.ReadOnly = true;
            this.equipmentSelecteddataGridView.RowHeadersVisible = false;
            this.equipmentSelecteddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equipmentSelecteddataGridView.Size = new System.Drawing.Size(631, 65);
            this.equipmentSelecteddataGridView.TabIndex = 13;
            this.equipmentSelecteddataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentSelecteddataGridView_CellDoubleClick);
            this.equipmentSelecteddataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentSelecteddataGridView_CellMouseEnter);
            this.equipmentSelecteddataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentSelecteddataGridView_CellMouseLeave);
            // 
            // reporterNameLabel
            // 
            this.reporterNameLabel.AutoSize = true;
            this.reporterNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reporterNameLabel.Location = new System.Drawing.Point(8, 538);
            this.reporterNameLabel.Name = "reporterNameLabel";
            this.reporterNameLabel.Size = new System.Drawing.Size(67, 20);
            this.reporterNameLabel.TabIndex = 16;
            this.reporterNameLabel.Text = "ชื่อผู้แจ้ง :";
            // 
            // reporterNameTextBox
            // 
            this.reporterNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.reporterNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reporterNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reporterNameTextBox.Location = new System.Drawing.Point(81, 529);
            this.reporterNameTextBox.Name = "reporterNameTextBox";
            this.reporterNameTextBox.Size = new System.Drawing.Size(252, 29);
            this.reporterNameTextBox.TabIndex = 17;
            // 
            // reportDateLabel
            // 
            this.reportDateLabel.AutoSize = true;
            this.reportDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportDateLabel.Location = new System.Drawing.Point(354, 538);
            this.reportDateLabel.Name = "reportDateLabel";
            this.reportDateLabel.Size = new System.Drawing.Size(67, 20);
            this.reportDateLabel.TabIndex = 18;
            this.reportDateLabel.Text = "วันที่แจ้ง :";
            // 
            // reportDateTimePicker
            // 
            this.reportDateTimePicker.Location = new System.Drawing.Point(427, 538);
            this.reportDateTimePicker.Name = "reportDateTimePicker";
            this.reportDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.reportDateTimePicker.TabIndex = 19;
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.AutoSize = true;
            this.currentStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStatusLabel.Location = new System.Drawing.Point(4, 483);
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(122, 24);
            this.currentStatusLabel.TabIndex = 20;
            this.currentStatusLabel.Text = "สถานะปัจจุบัน :";
            // 
            // currentStatusComboBox
            // 
            this.currentStatusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStatusComboBox.FormattingEnabled = true;
            this.currentStatusComboBox.Location = new System.Drawing.Point(132, 481);
            this.currentStatusComboBox.Name = "currentStatusComboBox";
            this.currentStatusComboBox.Size = new System.Drawing.Size(180, 32);
            this.currentStatusComboBox.TabIndex = 21;
            // 
            // repairTypeLabel
            // 
            this.repairTypeLabel.AutoSize = true;
            this.repairTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairTypeLabel.Location = new System.Drawing.Point(318, 484);
            this.repairTypeLabel.Name = "repairTypeLabel";
            this.repairTypeLabel.Size = new System.Drawing.Size(134, 24);
            this.repairTypeLabel.TabIndex = 22;
            this.repairTypeLabel.Text = "ประเภทการซ่อม :";
            // 
            // repairTypeComboBox
            // 
            this.repairTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairTypeComboBox.FormattingEnabled = true;
            this.repairTypeComboBox.Location = new System.Drawing.Point(456, 480);
            this.repairTypeComboBox.Name = "repairTypeComboBox";
            this.repairTypeComboBox.Size = new System.Drawing.Size(187, 32);
            this.repairTypeComboBox.TabIndex = 23;
            // 
            // deciderNameTextBox
            // 
            this.deciderNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.deciderNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deciderNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deciderNameTextBox.Location = new System.Drawing.Point(351, 607);
            this.deciderNameTextBox.Name = "deciderNameTextBox";
            this.deciderNameTextBox.Size = new System.Drawing.Size(292, 29);
            this.deciderNameTextBox.TabIndex = 25;
            // 
            // deciderNameLabel
            // 
            this.deciderNameLabel.AutoSize = true;
            this.deciderNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deciderNameLabel.Location = new System.Drawing.Point(346, 580);
            this.deciderNameLabel.Name = "deciderNameLabel";
            this.deciderNameLabel.Size = new System.Drawing.Size(86, 20);
            this.deciderNameLabel.TabIndex = 24;
            this.deciderNameLabel.Text = "ชื่อผู้พิจารณา";
            // 
            // decideDateTimePicker
            // 
            this.decideDateTimePicker.Location = new System.Drawing.Point(351, 669);
            this.decideDateTimePicker.Name = "decideDateTimePicker";
            this.decideDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.decideDateTimePicker.TabIndex = 27;
            // 
            // deciderDateLabel
            // 
            this.deciderDateLabel.AutoSize = true;
            this.deciderDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deciderDateLabel.Location = new System.Drawing.Point(346, 642);
            this.deciderDateLabel.Name = "deciderDateLabel";
            this.deciderDateLabel.Size = new System.Drawing.Size(86, 20);
            this.deciderDateLabel.TabIndex = 26;
            this.deciderDateLabel.Text = "วันที่พิจารณา";
            // 
            // reasonToChoseRepairLabel
            // 
            this.reasonToChoseRepairLabel.AutoSize = true;
            this.reasonToChoseRepairLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonToChoseRepairLabel.Location = new System.Drawing.Point(19, 580);
            this.reasonToChoseRepairLabel.Name = "reasonToChoseRepairLabel";
            this.reasonToChoseRepairLabel.Size = new System.Drawing.Size(231, 20);
            this.reasonToChoseRepairLabel.TabIndex = 28;
            this.reasonToChoseRepairLabel.Text = "เหตุผลในการเลือก ประเภทการซ่อมนี้";
            // 
            // reasdonToChoserepairRichTextBox
            // 
            this.reasdonToChoserepairRichTextBox.Location = new System.Drawing.Point(17, 607);
            this.reasdonToChoserepairRichTextBox.Name = "reasdonToChoserepairRichTextBox";
            this.reasdonToChoserepairRichTextBox.Size = new System.Drawing.Size(316, 82);
            this.reasdonToChoserepairRichTextBox.TabIndex = 29;
            this.reasdonToChoserepairRichTextBox.Text = "";
            // 
            // approveDateTimePicker
            // 
            this.approveDateTimePicker.Location = new System.Drawing.Point(1151, 580);
            this.approveDateTimePicker.Name = "approveDateTimePicker";
            this.approveDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.approveDateTimePicker.TabIndex = 33;
            // 
            // approveDateLabel
            // 
            this.approveDateLabel.AutoSize = true;
            this.approveDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveDateLabel.Location = new System.Drawing.Point(1146, 553);
            this.approveDateLabel.Name = "approveDateLabel";
            this.approveDateLabel.Size = new System.Drawing.Size(71, 20);
            this.approveDateLabel.TabIndex = 32;
            this.approveDateLabel.Text = "วันที่อนุมัติ";
            // 
            // approverNameTextBox
            // 
            this.approverNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.approverNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.approverNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverNameTextBox.Location = new System.Drawing.Point(1150, 633);
            this.approverNameTextBox.Name = "approverNameTextBox";
            this.approverNameTextBox.Size = new System.Drawing.Size(292, 29);
            this.approverNameTextBox.TabIndex = 31;
            // 
            // approverNameLabel
            // 
            this.approverNameLabel.AutoSize = true;
            this.approverNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverNameLabel.Location = new System.Drawing.Point(1145, 606);
            this.approverNameLabel.Name = "approverNameLabel";
            this.approverNameLabel.Size = new System.Drawing.Size(71, 20);
            this.approverNameLabel.TabIndex = 30;
            this.approverNameLabel.Text = "ชื่อผู้อนุมัติ";
            // 
            // reasonToAppRichTextBox
            // 
            this.reasonToAppRichTextBox.Location = new System.Drawing.Point(925, 580);
            this.reasonToAppRichTextBox.Name = "reasonToAppRichTextBox";
            this.reasonToAppRichTextBox.Size = new System.Drawing.Size(203, 109);
            this.reasonToAppRichTextBox.TabIndex = 35;
            this.reasonToAppRichTextBox.Text = "";
            // 
            // resonToAppLabel
            // 
            this.resonToAppLabel.AutoSize = true;
            this.resonToAppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resonToAppLabel.Location = new System.Drawing.Point(921, 553);
            this.resonToAppLabel.Name = "resonToAppLabel";
            this.resonToAppLabel.Size = new System.Drawing.Size(210, 20);
            this.resonToAppLabel.TabIndex = 34;
            this.resonToAppLabel.Text = "เหตุผลในการอนุมัติ หรือ ไม่อนุมัติ";
            // 
            // approveCheckLabel
            // 
            this.approveCheckLabel.AutoSize = true;
            this.approveCheckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveCheckLabel.Location = new System.Drawing.Point(685, 711);
            this.approveCheckLabel.Name = "approveCheckLabel";
            this.approveCheckLabel.Size = new System.Drawing.Size(76, 20);
            this.approveCheckLabel.TabIndex = 36;
            this.approveCheckLabel.Text = "การอนุมัติ :";
            // 
            // approveCheckBox
            // 
            this.approveCheckBox.AutoSize = true;
            this.approveCheckBox.Checked = true;
            this.approveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.approveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveCheckBox.Location = new System.Drawing.Point(767, 711);
            this.approveCheckBox.Name = "approveCheckBox";
            this.approveCheckBox.Size = new System.Drawing.Size(218, 20);
            this.approveCheckBox.TabIndex = 37;
            this.approveCheckBox.Text = "กรณีที่ไม่อนุมัติกรุณานำเครื่องหมายติ๊กออก";
            this.approveCheckBox.UseVisualStyleBackColor = true;
            // 
            // repairDocButton
            // 
            this.repairDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairDocButton.Location = new System.Drawing.Point(925, 5);
            this.repairDocButton.Name = "repairDocButton";
            this.repairDocButton.Size = new System.Drawing.Size(158, 34);
            this.repairDocButton.TabIndex = 38;
            this.repairDocButton.Text = "แนบเอกสารแจ้งซ่อม";
            this.repairDocButton.UseVisualStyleBackColor = true;
            this.repairDocButton.Click += new System.EventHandler(this.repairDocButton_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(1356, 674);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 95);
            this.button4.TabIndex = 39;
            this.button4.Text = "บันทึกการแจ้งซ่อม";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // equipmentRepaiePictureBox
            // 
            this.equipmentRepaiePictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.equipmentRepaiePictureBox.Location = new System.Drawing.Point(689, 45);
            this.equipmentRepaiePictureBox.Name = "equipmentRepaiePictureBox";
            this.equipmentRepaiePictureBox.Size = new System.Drawing.Size(763, 497);
            this.equipmentRepaiePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.equipmentRepaiePictureBox.TabIndex = 40;
            this.equipmentRepaiePictureBox.TabStop = false;
            // 
            // equipmentPhotoButton
            // 
            this.equipmentPhotoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentPhotoButton.Location = new System.Drawing.Point(689, 5);
            this.equipmentPhotoButton.Name = "equipmentPhotoButton";
            this.equipmentPhotoButton.Size = new System.Drawing.Size(197, 34);
            this.equipmentPhotoButton.TabIndex = 41;
            this.equipmentPhotoButton.Text = "แนบภาพอุปกรณ์ที่ชำรุด";
            this.equipmentPhotoButton.UseVisualStyleBackColor = true;
            this.equipmentPhotoButton.Click += new System.EventHandler(this.equipmentPhotoButton_Click);
            // 
            // repairDocLinkLabel
            // 
            this.repairDocLinkLabel.AutoSize = true;
            this.repairDocLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairDocLinkLabel.Location = new System.Drawing.Point(1098, 9);
            this.repairDocLinkLabel.Name = "repairDocLinkLabel";
            this.repairDocLinkLabel.Size = new System.Drawing.Size(70, 20);
            this.repairDocLinkLabel.TabIndex = 42;
            this.repairDocLinkLabel.TabStop = true;
            this.repairDocLinkLabel.Text = "ดูไฟล์แนบ";
            this.repairDocLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.repairDocLinkLabel_LinkClicked);
            this.repairDocLinkLabel.MouseEnter += new System.EventHandler(this.repairDocLinkLabel_MouseEnter);
            this.repairDocLinkLabel.MouseLeave += new System.EventHandler(this.repairDocLinkLabel_MouseLeave_1);
            // 
            // selectedEquipmentLabel
            // 
            this.selectedEquipmentLabel.AutoSize = true;
            this.selectedEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedEquipmentLabel.Location = new System.Drawing.Point(12, 369);
            this.selectedEquipmentLabel.Name = "selectedEquipmentLabel";
            this.selectedEquipmentLabel.Size = new System.Drawing.Size(357, 25);
            this.selectedEquipmentLabel.TabIndex = 43;
            this.selectedEquipmentLabel.Text = "ยกเลิกเครื่องมือที่ถูกเลือก โดยการดับเบิ้ลคลิก";
            // 
            // jDetailsLabel
            // 
            this.jDetailsLabel.AutoSize = true;
            this.jDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jDetailsLabel.Location = new System.Drawing.Point(685, 553);
            this.jDetailsLabel.Name = "jDetailsLabel";
            this.jDetailsLabel.Size = new System.Drawing.Size(151, 20);
            this.jDetailsLabel.TabIndex = 44;
            this.jDetailsLabel.Text = "รายละเอียดการแจ้งซ่อม";
            // 
            // jDetailsrichTextBox
            // 
            this.jDetailsrichTextBox.Location = new System.Drawing.Point(689, 581);
            this.jDetailsrichTextBox.Name = "jDetailsrichTextBox";
            this.jDetailsrichTextBox.Size = new System.Drawing.Size(230, 109);
            this.jDetailsrichTextBox.TabIndex = 45;
            this.jDetailsrichTextBox.Text = "";
            // 
            // CreateJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.jDetailsrichTextBox);
            this.Controls.Add(this.jDetailsLabel);
            this.Controls.Add(this.selectedEquipmentLabel);
            this.Controls.Add(this.repairDocLinkLabel);
            this.Controls.Add(this.equipmentPhotoButton);
            this.Controls.Add(this.equipmentRepaiePictureBox);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.repairDocButton);
            this.Controls.Add(this.approveCheckBox);
            this.Controls.Add(this.approveCheckLabel);
            this.Controls.Add(this.reasonToAppRichTextBox);
            this.Controls.Add(this.resonToAppLabel);
            this.Controls.Add(this.approveDateTimePicker);
            this.Controls.Add(this.approveDateLabel);
            this.Controls.Add(this.approverNameTextBox);
            this.Controls.Add(this.approverNameLabel);
            this.Controls.Add(this.reasdonToChoserepairRichTextBox);
            this.Controls.Add(this.reasonToChoseRepairLabel);
            this.Controls.Add(this.decideDateTimePicker);
            this.Controls.Add(this.deciderDateLabel);
            this.Controls.Add(this.deciderNameTextBox);
            this.Controls.Add(this.deciderNameLabel);
            this.Controls.Add(this.repairTypeComboBox);
            this.Controls.Add(this.repairTypeLabel);
            this.Controls.Add(this.currentStatusComboBox);
            this.Controls.Add(this.currentStatusLabel);
            this.Controls.Add(this.reportDateTimePicker);
            this.Controls.Add(this.reportDateLabel);
            this.Controls.Add(this.reporterNameTextBox);
            this.Controls.Add(this.reporterNameLabel);
            this.Controls.Add(this.equipmentSelecteddataGridView);
            this.Controls.Add(this.searchEquipmentLabel);
            this.Controls.Add(this.equipmentListSearchTextBox);
            this.Controls.Add(this.equipmentFilterListLabel);
            this.Controls.Add(this.equipmentTypeComboBox);
            this.Controls.Add(this.equipmentDisplaydataGridView);
            this.Controls.Add(this.choseEquipmentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "แจ้งซ่อม";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreateJobForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDisplaydataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentSelecteddataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentRepaiePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label choseEquipmentLabel;
        private System.Windows.Forms.DataGridView equipmentDisplaydataGridView;
        private System.Windows.Forms.Label searchEquipmentLabel;
        private System.Windows.Forms.TextBox equipmentListSearchTextBox;
        private System.Windows.Forms.Label equipmentFilterListLabel;
        private System.Windows.Forms.ComboBox equipmentTypeComboBox;
        private System.Windows.Forms.DataGridView equipmentSelecteddataGridView;
        private System.Windows.Forms.Label reporterNameLabel;
        private System.Windows.Forms.TextBox reporterNameTextBox;
        private System.Windows.Forms.Label reportDateLabel;
        private System.Windows.Forms.DateTimePicker reportDateTimePicker;
        private System.Windows.Forms.Label currentStatusLabel;
        private System.Windows.Forms.ComboBox currentStatusComboBox;
        private System.Windows.Forms.Label repairTypeLabel;
        private System.Windows.Forms.ComboBox repairTypeComboBox;
        private System.Windows.Forms.TextBox deciderNameTextBox;
        private System.Windows.Forms.Label deciderNameLabel;
        private System.Windows.Forms.DateTimePicker decideDateTimePicker;
        private System.Windows.Forms.Label deciderDateLabel;
        private System.Windows.Forms.Label reasonToChoseRepairLabel;
        private System.Windows.Forms.RichTextBox reasdonToChoserepairRichTextBox;
        private System.Windows.Forms.DateTimePicker approveDateTimePicker;
        private System.Windows.Forms.Label approveDateLabel;
        private System.Windows.Forms.TextBox approverNameTextBox;
        private System.Windows.Forms.Label approverNameLabel;
        private System.Windows.Forms.RichTextBox reasonToAppRichTextBox;
        private System.Windows.Forms.Label resonToAppLabel;
        private System.Windows.Forms.Label approveCheckLabel;
        private System.Windows.Forms.CheckBox approveCheckBox;
        private System.Windows.Forms.Button repairDocButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox equipmentRepaiePictureBox;
        private System.Windows.Forms.Button equipmentPhotoButton;
        private System.Windows.Forms.LinkLabel repairDocLinkLabel;
        private System.Windows.Forms.Label selectedEquipmentLabel;
        private System.Windows.Forms.Label jDetailsLabel;
        private System.Windows.Forms.RichTextBox jDetailsrichTextBox;
    }
}