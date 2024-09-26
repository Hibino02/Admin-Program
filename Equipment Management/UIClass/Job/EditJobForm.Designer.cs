namespace Equipment_Management.UIClass.Job
{
    partial class EditJobForm
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
            this.jDetailsrichTextBox = new System.Windows.Forms.RichTextBox();
            this.jDetailsLabel = new System.Windows.Forms.Label();
            this.selectedEquipmentLabel = new System.Windows.Forms.Label();
            this.repairDocLinkLabel = new System.Windows.Forms.LinkLabel();
            this.equipmentPhotoButton = new System.Windows.Forms.Button();
            this.equipmentRepaiePictureBox = new System.Windows.Forms.PictureBox();
            this.editJobCompleteButton = new System.Windows.Forms.Button();
            this.repairDocButton = new System.Windows.Forms.Button();
            this.approveCheckBox = new System.Windows.Forms.CheckBox();
            this.approveCheckLabel = new System.Windows.Forms.Label();
            this.reasonToAppRichTextBox = new System.Windows.Forms.RichTextBox();
            this.resonToAppLabel = new System.Windows.Forms.Label();
            this.approveDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.approveDateLabel = new System.Windows.Forms.Label();
            this.approverNameTextBox = new System.Windows.Forms.TextBox();
            this.approverNameLabel = new System.Windows.Forms.Label();
            this.reasdonToChoserepairRichTextBox = new System.Windows.Forms.RichTextBox();
            this.reasonToChoseRepairLabel = new System.Windows.Forms.Label();
            this.decideDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.deciderDateLabel = new System.Windows.Forms.Label();
            this.deciderNameTextBox = new System.Windows.Forms.TextBox();
            this.deciderNameLabel = new System.Windows.Forms.Label();
            this.repairTypeComboBox = new System.Windows.Forms.ComboBox();
            this.repairTypeLabel = new System.Windows.Forms.Label();
            this.currentStatusComboBox = new System.Windows.Forms.ComboBox();
            this.currentStatusLabel = new System.Windows.Forms.Label();
            this.reportDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.reportDateLabel = new System.Windows.Forms.Label();
            this.reporterNameTextBox = new System.Windows.Forms.TextBox();
            this.reporterNameLabel = new System.Windows.Forms.Label();
            this.equipmentSelecteddataGridView = new System.Windows.Forms.DataGridView();
            this.searchEquipmentLabel = new System.Windows.Forms.Label();
            this.equipmentListSearchTextBox = new System.Windows.Forms.TextBox();
            this.equipmentFilterListLabel = new System.Windows.Forms.Label();
            this.equipmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.equipmentDisplaydataGridView = new System.Windows.Forms.DataGridView();
            this.choseEquipmentLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentRepaiePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentSelecteddataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDisplaydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // jDetailsrichTextBox
            // 
            this.jDetailsrichTextBox.Location = new System.Drawing.Point(693, 585);
            this.jDetailsrichTextBox.Name = "jDetailsrichTextBox";
            this.jDetailsrichTextBox.Size = new System.Drawing.Size(230, 109);
            this.jDetailsrichTextBox.TabIndex = 82;
            this.jDetailsrichTextBox.Text = "";
            // 
            // jDetailsLabel
            // 
            this.jDetailsLabel.AutoSize = true;
            this.jDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jDetailsLabel.Location = new System.Drawing.Point(689, 557);
            this.jDetailsLabel.Name = "jDetailsLabel";
            this.jDetailsLabel.Size = new System.Drawing.Size(151, 20);
            this.jDetailsLabel.TabIndex = 81;
            this.jDetailsLabel.Text = "รายละเอียดการแจ้งซ่อม";
            // 
            // selectedEquipmentLabel
            // 
            this.selectedEquipmentLabel.AutoSize = true;
            this.selectedEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedEquipmentLabel.Location = new System.Drawing.Point(16, 373);
            this.selectedEquipmentLabel.Name = "selectedEquipmentLabel";
            this.selectedEquipmentLabel.Size = new System.Drawing.Size(480, 25);
            this.selectedEquipmentLabel.TabIndex = 80;
            this.selectedEquipmentLabel.Text = "กรณีที่ ต้องการเปลี่ยนอุปกรณ์แจ้งซ่อม กรุณาลบงานแจ้งซ่อม";
            // 
            // repairDocLinkLabel
            // 
            this.repairDocLinkLabel.AutoSize = true;
            this.repairDocLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairDocLinkLabel.Location = new System.Drawing.Point(1102, 13);
            this.repairDocLinkLabel.Name = "repairDocLinkLabel";
            this.repairDocLinkLabel.Size = new System.Drawing.Size(70, 20);
            this.repairDocLinkLabel.TabIndex = 79;
            this.repairDocLinkLabel.TabStop = true;
            this.repairDocLinkLabel.Text = "ดูไฟล์แนบ";
            this.repairDocLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.repairDocLinkLabel_LinkClicked);
            this.repairDocLinkLabel.MouseEnter += new System.EventHandler(this.repairDocLinkLabel_MouseEnter);
            this.repairDocLinkLabel.MouseLeave += new System.EventHandler(this.repairDocLinkLabel_MouseLeave);
            // 
            // equipmentPhotoButton
            // 
            this.equipmentPhotoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentPhotoButton.Location = new System.Drawing.Point(693, 9);
            this.equipmentPhotoButton.Name = "equipmentPhotoButton";
            this.equipmentPhotoButton.Size = new System.Drawing.Size(197, 34);
            this.equipmentPhotoButton.TabIndex = 78;
            this.equipmentPhotoButton.Text = "แนบภาพอุปกรณ์ที่ชำรุด";
            this.equipmentPhotoButton.UseVisualStyleBackColor = true;
            this.equipmentPhotoButton.Click += new System.EventHandler(this.equipmentPhotoButton_Click);
            // 
            // equipmentRepaiePictureBox
            // 
            this.equipmentRepaiePictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.equipmentRepaiePictureBox.Location = new System.Drawing.Point(693, 49);
            this.equipmentRepaiePictureBox.Name = "equipmentRepaiePictureBox";
            this.equipmentRepaiePictureBox.Size = new System.Drawing.Size(763, 497);
            this.equipmentRepaiePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.equipmentRepaiePictureBox.TabIndex = 77;
            this.equipmentRepaiePictureBox.TabStop = false;
            // 
            // editJobCompleteButton
            // 
            this.editJobCompleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editJobCompleteButton.Location = new System.Drawing.Point(1342, 678);
            this.editJobCompleteButton.Name = "editJobCompleteButton";
            this.editJobCompleteButton.Size = new System.Drawing.Size(114, 95);
            this.editJobCompleteButton.TabIndex = 76;
            this.editJobCompleteButton.Text = "บันทึกการแก้ใข";
            this.editJobCompleteButton.UseVisualStyleBackColor = true;
            this.editJobCompleteButton.Click += new System.EventHandler(this.editJobCompleteButton_Click);
            // 
            // repairDocButton
            // 
            this.repairDocButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairDocButton.Location = new System.Drawing.Point(929, 9);
            this.repairDocButton.Name = "repairDocButton";
            this.repairDocButton.Size = new System.Drawing.Size(158, 34);
            this.repairDocButton.TabIndex = 75;
            this.repairDocButton.Text = "แนบเอกสารแจ้งซ่อม";
            this.repairDocButton.UseVisualStyleBackColor = true;
            this.repairDocButton.Click += new System.EventHandler(this.repairDocButton_Click);
            // 
            // approveCheckBox
            // 
            this.approveCheckBox.AutoSize = true;
            this.approveCheckBox.Checked = true;
            this.approveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.approveCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveCheckBox.Location = new System.Drawing.Point(771, 715);
            this.approveCheckBox.Name = "approveCheckBox";
            this.approveCheckBox.Size = new System.Drawing.Size(218, 20);
            this.approveCheckBox.TabIndex = 74;
            this.approveCheckBox.Text = "กรณีที่ไม่อนุมัติกรุณานำเครื่องหมายติ๊กออก";
            this.approveCheckBox.UseVisualStyleBackColor = true;
            // 
            // approveCheckLabel
            // 
            this.approveCheckLabel.AutoSize = true;
            this.approveCheckLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveCheckLabel.Location = new System.Drawing.Point(689, 715);
            this.approveCheckLabel.Name = "approveCheckLabel";
            this.approveCheckLabel.Size = new System.Drawing.Size(76, 20);
            this.approveCheckLabel.TabIndex = 73;
            this.approveCheckLabel.Text = "การอนุมัติ :";
            // 
            // reasonToAppRichTextBox
            // 
            this.reasonToAppRichTextBox.Location = new System.Drawing.Point(929, 584);
            this.reasonToAppRichTextBox.Name = "reasonToAppRichTextBox";
            this.reasonToAppRichTextBox.Size = new System.Drawing.Size(203, 109);
            this.reasonToAppRichTextBox.TabIndex = 72;
            this.reasonToAppRichTextBox.Text = "";
            // 
            // resonToAppLabel
            // 
            this.resonToAppLabel.AutoSize = true;
            this.resonToAppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resonToAppLabel.Location = new System.Drawing.Point(925, 557);
            this.resonToAppLabel.Name = "resonToAppLabel";
            this.resonToAppLabel.Size = new System.Drawing.Size(210, 20);
            this.resonToAppLabel.TabIndex = 71;
            this.resonToAppLabel.Text = "เหตุผลในการอนุมัติ หรือ ไม่อนุมัติ";
            // 
            // approveDateTimePicker
            // 
            this.approveDateTimePicker.Location = new System.Drawing.Point(1155, 584);
            this.approveDateTimePicker.Name = "approveDateTimePicker";
            this.approveDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.approveDateTimePicker.TabIndex = 70;
            // 
            // approveDateLabel
            // 
            this.approveDateLabel.AutoSize = true;
            this.approveDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approveDateLabel.Location = new System.Drawing.Point(1150, 557);
            this.approveDateLabel.Name = "approveDateLabel";
            this.approveDateLabel.Size = new System.Drawing.Size(71, 20);
            this.approveDateLabel.TabIndex = 69;
            this.approveDateLabel.Text = "วันที่อนุมัติ";
            // 
            // approverNameTextBox
            // 
            this.approverNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.approverNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.approverNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverNameTextBox.Location = new System.Drawing.Point(1154, 637);
            this.approverNameTextBox.Name = "approverNameTextBox";
            this.approverNameTextBox.Size = new System.Drawing.Size(292, 29);
            this.approverNameTextBox.TabIndex = 68;
            // 
            // approverNameLabel
            // 
            this.approverNameLabel.AutoSize = true;
            this.approverNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.approverNameLabel.Location = new System.Drawing.Point(1149, 610);
            this.approverNameLabel.Name = "approverNameLabel";
            this.approverNameLabel.Size = new System.Drawing.Size(71, 20);
            this.approverNameLabel.TabIndex = 67;
            this.approverNameLabel.Text = "ชื่อผู้อนุมัติ";
            // 
            // reasdonToChoserepairRichTextBox
            // 
            this.reasdonToChoserepairRichTextBox.Location = new System.Drawing.Point(21, 611);
            this.reasdonToChoserepairRichTextBox.Name = "reasdonToChoserepairRichTextBox";
            this.reasdonToChoserepairRichTextBox.Size = new System.Drawing.Size(316, 82);
            this.reasdonToChoserepairRichTextBox.TabIndex = 66;
            this.reasdonToChoserepairRichTextBox.Text = "";
            // 
            // reasonToChoseRepairLabel
            // 
            this.reasonToChoseRepairLabel.AutoSize = true;
            this.reasonToChoseRepairLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reasonToChoseRepairLabel.Location = new System.Drawing.Point(23, 584);
            this.reasonToChoseRepairLabel.Name = "reasonToChoseRepairLabel";
            this.reasonToChoseRepairLabel.Size = new System.Drawing.Size(231, 20);
            this.reasonToChoseRepairLabel.TabIndex = 65;
            this.reasonToChoseRepairLabel.Text = "เหตุผลในการเลือก ประเภทการซ่อมนี้";
            // 
            // decideDateTimePicker
            // 
            this.decideDateTimePicker.Location = new System.Drawing.Point(355, 673);
            this.decideDateTimePicker.Name = "decideDateTimePicker";
            this.decideDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.decideDateTimePicker.TabIndex = 64;
            // 
            // deciderDateLabel
            // 
            this.deciderDateLabel.AutoSize = true;
            this.deciderDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deciderDateLabel.Location = new System.Drawing.Point(350, 646);
            this.deciderDateLabel.Name = "deciderDateLabel";
            this.deciderDateLabel.Size = new System.Drawing.Size(86, 20);
            this.deciderDateLabel.TabIndex = 63;
            this.deciderDateLabel.Text = "วันที่พิจารณา";
            // 
            // deciderNameTextBox
            // 
            this.deciderNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.deciderNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deciderNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deciderNameTextBox.Location = new System.Drawing.Point(355, 611);
            this.deciderNameTextBox.Name = "deciderNameTextBox";
            this.deciderNameTextBox.Size = new System.Drawing.Size(292, 29);
            this.deciderNameTextBox.TabIndex = 62;
            // 
            // deciderNameLabel
            // 
            this.deciderNameLabel.AutoSize = true;
            this.deciderNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deciderNameLabel.Location = new System.Drawing.Point(350, 584);
            this.deciderNameLabel.Name = "deciderNameLabel";
            this.deciderNameLabel.Size = new System.Drawing.Size(86, 20);
            this.deciderNameLabel.TabIndex = 61;
            this.deciderNameLabel.Text = "ชื่อผู้พิจารณา";
            // 
            // repairTypeComboBox
            // 
            this.repairTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairTypeComboBox.FormattingEnabled = true;
            this.repairTypeComboBox.Location = new System.Drawing.Point(460, 484);
            this.repairTypeComboBox.Name = "repairTypeComboBox";
            this.repairTypeComboBox.Size = new System.Drawing.Size(187, 32);
            this.repairTypeComboBox.TabIndex = 60;
            // 
            // repairTypeLabel
            // 
            this.repairTypeLabel.AutoSize = true;
            this.repairTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.repairTypeLabel.Location = new System.Drawing.Point(322, 488);
            this.repairTypeLabel.Name = "repairTypeLabel";
            this.repairTypeLabel.Size = new System.Drawing.Size(134, 24);
            this.repairTypeLabel.TabIndex = 59;
            this.repairTypeLabel.Text = "ประเภทการซ่อม :";
            // 
            // currentStatusComboBox
            // 
            this.currentStatusComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStatusComboBox.FormattingEnabled = true;
            this.currentStatusComboBox.Location = new System.Drawing.Point(136, 485);
            this.currentStatusComboBox.Name = "currentStatusComboBox";
            this.currentStatusComboBox.Size = new System.Drawing.Size(180, 32);
            this.currentStatusComboBox.TabIndex = 58;
            // 
            // currentStatusLabel
            // 
            this.currentStatusLabel.AutoSize = true;
            this.currentStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStatusLabel.Location = new System.Drawing.Point(8, 487);
            this.currentStatusLabel.Name = "currentStatusLabel";
            this.currentStatusLabel.Size = new System.Drawing.Size(122, 24);
            this.currentStatusLabel.TabIndex = 57;
            this.currentStatusLabel.Text = "สถานะปัจจุบัน :";
            // 
            // reportDateTimePicker
            // 
            this.reportDateTimePicker.Location = new System.Drawing.Point(431, 542);
            this.reportDateTimePicker.Name = "reportDateTimePicker";
            this.reportDateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.reportDateTimePicker.TabIndex = 56;
            // 
            // reportDateLabel
            // 
            this.reportDateLabel.AutoSize = true;
            this.reportDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reportDateLabel.Location = new System.Drawing.Point(358, 542);
            this.reportDateLabel.Name = "reportDateLabel";
            this.reportDateLabel.Size = new System.Drawing.Size(67, 20);
            this.reportDateLabel.TabIndex = 55;
            this.reportDateLabel.Text = "วันที่แจ้ง :";
            // 
            // reporterNameTextBox
            // 
            this.reporterNameTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.reporterNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.reporterNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reporterNameTextBox.Location = new System.Drawing.Point(85, 533);
            this.reporterNameTextBox.Name = "reporterNameTextBox";
            this.reporterNameTextBox.Size = new System.Drawing.Size(252, 29);
            this.reporterNameTextBox.TabIndex = 54;
            // 
            // reporterNameLabel
            // 
            this.reporterNameLabel.AutoSize = true;
            this.reporterNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.reporterNameLabel.Location = new System.Drawing.Point(12, 542);
            this.reporterNameLabel.Name = "reporterNameLabel";
            this.reporterNameLabel.Size = new System.Drawing.Size(67, 20);
            this.reporterNameLabel.TabIndex = 53;
            this.reporterNameLabel.Text = "ชื่อผู้แจ้ง :";
            // 
            // equipmentSelecteddataGridView
            // 
            this.equipmentSelecteddataGridView.AllowUserToAddRows = false;
            this.equipmentSelecteddataGridView.AllowUserToDeleteRows = false;
            this.equipmentSelecteddataGridView.AllowUserToResizeColumns = false;
            this.equipmentSelecteddataGridView.AllowUserToResizeRows = false;
            this.equipmentSelecteddataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipmentSelecteddataGridView.Location = new System.Drawing.Point(16, 406);
            this.equipmentSelecteddataGridView.MultiSelect = false;
            this.equipmentSelecteddataGridView.Name = "equipmentSelecteddataGridView";
            this.equipmentSelecteddataGridView.ReadOnly = true;
            this.equipmentSelecteddataGridView.RowHeadersVisible = false;
            this.equipmentSelecteddataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equipmentSelecteddataGridView.Size = new System.Drawing.Size(631, 65);
            this.equipmentSelecteddataGridView.TabIndex = 52;
            this.equipmentSelecteddataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentSelecteddataGridView_CellMouseEnter);
            this.equipmentSelecteddataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.equipmentSelecteddataGridView_CellMouseLeave);
            // 
            // searchEquipmentLabel
            // 
            this.searchEquipmentLabel.AutoSize = true;
            this.searchEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchEquipmentLabel.Location = new System.Drawing.Point(11, 49);
            this.searchEquipmentLabel.Name = "searchEquipmentLabel";
            this.searchEquipmentLabel.Size = new System.Drawing.Size(223, 25);
            this.searchEquipmentLabel.TabIndex = 51;
            this.searchEquipmentLabel.Text = "พิมพ์รายละเอียดที่เกี่ยวข้อง";
            // 
            // equipmentListSearchTextBox
            // 
            this.equipmentListSearchTextBox.BackColor = System.Drawing.SystemColors.Info;
            this.equipmentListSearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.equipmentListSearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentListSearchTextBox.Location = new System.Drawing.Point(254, 45);
            this.equipmentListSearchTextBox.Name = "equipmentListSearchTextBox";
            this.equipmentListSearchTextBox.Size = new System.Drawing.Size(393, 29);
            this.equipmentListSearchTextBox.TabIndex = 50;
            // 
            // equipmentFilterListLabel
            // 
            this.equipmentFilterListLabel.AutoSize = true;
            this.equipmentFilterListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentFilterListLabel.Location = new System.Drawing.Point(12, 11);
            this.equipmentFilterListLabel.Name = "equipmentFilterListLabel";
            this.equipmentFilterListLabel.Size = new System.Drawing.Size(196, 25);
            this.equipmentFilterListLabel.TabIndex = 49;
            this.equipmentFilterListLabel.Text = "ตัวกรองประเภทอุปกรณ์";
            // 
            // equipmentTypeComboBox
            // 
            this.equipmentTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentTypeComboBox.FormattingEnabled = true;
            this.equipmentTypeComboBox.Location = new System.Drawing.Point(218, 7);
            this.equipmentTypeComboBox.Name = "equipmentTypeComboBox";
            this.equipmentTypeComboBox.Size = new System.Drawing.Size(429, 32);
            this.equipmentTypeComboBox.TabIndex = 48;
            // 
            // equipmentDisplaydataGridView
            // 
            this.equipmentDisplaydataGridView.AllowUserToAddRows = false;
            this.equipmentDisplaydataGridView.AllowUserToDeleteRows = false;
            this.equipmentDisplaydataGridView.AllowUserToResizeColumns = false;
            this.equipmentDisplaydataGridView.AllowUserToResizeRows = false;
            this.equipmentDisplaydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.equipmentDisplaydataGridView.Location = new System.Drawing.Point(16, 110);
            this.equipmentDisplaydataGridView.MultiSelect = false;
            this.equipmentDisplaydataGridView.Name = "equipmentDisplaydataGridView";
            this.equipmentDisplaydataGridView.ReadOnly = true;
            this.equipmentDisplaydataGridView.RowHeadersVisible = false;
            this.equipmentDisplaydataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.equipmentDisplaydataGridView.Size = new System.Drawing.Size(631, 258);
            this.equipmentDisplaydataGridView.TabIndex = 47;
            // 
            // choseEquipmentLabel
            // 
            this.choseEquipmentLabel.AutoSize = true;
            this.choseEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choseEquipmentLabel.Location = new System.Drawing.Point(16, 82);
            this.choseEquipmentLabel.Name = "choseEquipmentLabel";
            this.choseEquipmentLabel.Size = new System.Drawing.Size(499, 25);
            this.choseEquipmentLabel.TabIndex = 46;
            this.choseEquipmentLabel.Text = "เลือกเครื่องมือ / อุปกรณ์ ที่ต้องการแจ้งซ่อม โดยการดับเบิ้ลคลิก";
            // 
            // EditJobForm
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
            this.Controls.Add(this.editJobCompleteButton);
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
            this.Name = "EditJobForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "แก้ใขการแจ้งซ่อม";
            ((System.ComponentModel.ISupportInitialize)(this.equipmentRepaiePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentSelecteddataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentDisplaydataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox jDetailsrichTextBox;
        private System.Windows.Forms.Label jDetailsLabel;
        private System.Windows.Forms.Label selectedEquipmentLabel;
        private System.Windows.Forms.LinkLabel repairDocLinkLabel;
        private System.Windows.Forms.Button equipmentPhotoButton;
        private System.Windows.Forms.PictureBox equipmentRepaiePictureBox;
        private System.Windows.Forms.Button editJobCompleteButton;
        private System.Windows.Forms.Button repairDocButton;
        private System.Windows.Forms.CheckBox approveCheckBox;
        private System.Windows.Forms.Label approveCheckLabel;
        private System.Windows.Forms.RichTextBox reasonToAppRichTextBox;
        private System.Windows.Forms.Label resonToAppLabel;
        private System.Windows.Forms.DateTimePicker approveDateTimePicker;
        private System.Windows.Forms.Label approveDateLabel;
        private System.Windows.Forms.TextBox approverNameTextBox;
        private System.Windows.Forms.Label approverNameLabel;
        private System.Windows.Forms.RichTextBox reasdonToChoserepairRichTextBox;
        private System.Windows.Forms.Label reasonToChoseRepairLabel;
        private System.Windows.Forms.DateTimePicker decideDateTimePicker;
        private System.Windows.Forms.Label deciderDateLabel;
        private System.Windows.Forms.TextBox deciderNameTextBox;
        private System.Windows.Forms.Label deciderNameLabel;
        private System.Windows.Forms.ComboBox repairTypeComboBox;
        private System.Windows.Forms.Label repairTypeLabel;
        private System.Windows.Forms.ComboBox currentStatusComboBox;
        private System.Windows.Forms.Label currentStatusLabel;
        private System.Windows.Forms.DateTimePicker reportDateTimePicker;
        private System.Windows.Forms.Label reportDateLabel;
        private System.Windows.Forms.TextBox reporterNameTextBox;
        private System.Windows.Forms.Label reporterNameLabel;
        private System.Windows.Forms.DataGridView equipmentSelecteddataGridView;
        private System.Windows.Forms.Label searchEquipmentLabel;
        private System.Windows.Forms.TextBox equipmentListSearchTextBox;
        private System.Windows.Forms.Label equipmentFilterListLabel;
        private System.Windows.Forms.ComboBox equipmentTypeComboBox;
        private System.Windows.Forms.DataGridView equipmentDisplaydataGridView;
        private System.Windows.Forms.Label choseEquipmentLabel;
    }
}