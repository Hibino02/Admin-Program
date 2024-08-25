namespace Equipment_Management.UIClass.Plan
{
    partial class CreatePlanForm
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
            this.selectEquipmentlabel = new System.Windows.Forms.Label();
            this.searchEquipmentLabel = new System.Windows.Forms.Label();
            this.equipmentListSearchTextBox = new System.Windows.Forms.TextBox();
            this.equipmentFilterListLabel = new System.Windows.Forms.Label();
            this.equipmentTypeComboBox = new System.Windows.Forms.ComboBox();
            this.EquipmentListDataGridView = new System.Windows.Forms.DataGridView();
            this.eNlabel = new System.Windows.Forms.Label();
            this.eNameLabel = new System.Windows.Forms.Label();
            this.eSlabel = new System.Windows.Forms.Label();
            this.eSerialLabel = new System.Windows.Forms.Label();
            this.eStLabel = new System.Windows.Forms.Label();
            this.eStatusLabel = new System.Windows.Forms.Label();
            this.equipmentPictureBox = new System.Windows.Forms.PictureBox();
            this.ilabel = new System.Windows.Forms.Label();
            this.InsPlacelabel = new System.Windows.Forms.Label();
            this.pTypelabel = new System.Windows.Forms.Label();
            this.periodlabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pTypecomboBox = new System.Windows.Forms.ComboBox();
            this.pPeriodcomboBox = new System.Windows.Forms.ComboBox();
            this.dateToDodateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.oPlacepictureBox = new System.Windows.Forms.PictureBox();
            this.createPlanbutton = new System.Windows.Forms.Button();
            this.createPlanPeriodbutton = new System.Windows.Forms.Button();
            this.removeSelectedbutton = new System.Windows.Forms.Button();
            this.deslabel = new System.Windows.Forms.Label();
            this.recoredPlanButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentListDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oPlacepictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // selectEquipmentlabel
            // 
            this.selectEquipmentlabel.AutoSize = true;
            this.selectEquipmentlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectEquipmentlabel.Location = new System.Drawing.Point(2, 34);
            this.selectEquipmentlabel.Name = "selectEquipmentlabel";
            this.selectEquipmentlabel.Size = new System.Drawing.Size(199, 25);
            this.selectEquipmentlabel.TabIndex = 0;
            this.selectEquipmentlabel.Text = "เลือกเครื่องมือ / อุปกรณ์";
            // 
            // searchEquipmentLabel
            // 
            this.searchEquipmentLabel.AutoSize = true;
            this.searchEquipmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchEquipmentLabel.Location = new System.Drawing.Point(649, -1);
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
            this.equipmentListSearchTextBox.Location = new System.Drawing.Point(652, 29);
            this.equipmentListSearchTextBox.Name = "equipmentListSearchTextBox";
            this.equipmentListSearchTextBox.Size = new System.Drawing.Size(441, 29);
            this.equipmentListSearchTextBox.TabIndex = 11;
            this.equipmentListSearchTextBox.TextChanged += new System.EventHandler(this.equipmentListSearchTextBox_TextChanged);
            // 
            // equipmentFilterListLabel
            // 
            this.equipmentFilterListLabel.AutoSize = true;
            this.equipmentFilterListLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentFilterListLabel.Location = new System.Drawing.Point(207, 0);
            this.equipmentFilterListLabel.Name = "equipmentFilterListLabel";
            this.equipmentFilterListLabel.Size = new System.Drawing.Size(196, 25);
            this.equipmentFilterListLabel.TabIndex = 10;
            this.equipmentFilterListLabel.Text = "ตัวกรองประเภทอุปกรณ์";
            // 
            // equipmentTypeComboBox
            // 
            this.equipmentTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentTypeComboBox.FormattingEnabled = true;
            this.equipmentTypeComboBox.Location = new System.Drawing.Point(207, 27);
            this.equipmentTypeComboBox.Name = "equipmentTypeComboBox";
            this.equipmentTypeComboBox.Size = new System.Drawing.Size(436, 32);
            this.equipmentTypeComboBox.TabIndex = 9;
            this.equipmentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.equipmentTypeComboBox_SelectedIndexChanged);
            this.equipmentTypeComboBox.TextChanged += new System.EventHandler(this.equipmentTypeComboBox_TextChanged);
            // 
            // EquipmentListDataGridView
            // 
            this.EquipmentListDataGridView.AllowUserToAddRows = false;
            this.EquipmentListDataGridView.AllowUserToDeleteRows = false;
            this.EquipmentListDataGridView.AllowUserToResizeColumns = false;
            this.EquipmentListDataGridView.AllowUserToResizeRows = false;
            this.EquipmentListDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EquipmentListDataGridView.Location = new System.Drawing.Point(5, 65);
            this.EquipmentListDataGridView.MultiSelect = false;
            this.EquipmentListDataGridView.Name = "EquipmentListDataGridView";
            this.EquipmentListDataGridView.ReadOnly = true;
            this.EquipmentListDataGridView.RowHeadersVisible = false;
            this.EquipmentListDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.EquipmentListDataGridView.Size = new System.Drawing.Size(638, 669);
            this.EquipmentListDataGridView.TabIndex = 13;
            this.EquipmentListDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentListDataGridView_CellDoubleClick);
            this.EquipmentListDataGridView.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentListDataGridView_CellMouseEnter);
            this.EquipmentListDataGridView.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.EquipmentListDataGridView_CellMouseLeave);
            // 
            // eNlabel
            // 
            this.eNlabel.AutoSize = true;
            this.eNlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eNlabel.Location = new System.Drawing.Point(669, 616);
            this.eNlabel.Name = "eNlabel";
            this.eNlabel.Size = new System.Drawing.Size(167, 25);
            this.eNlabel.TabIndex = 14;
            this.eNlabel.Text = "ชื่ออุปกรณ์ที่ถูกเลือก";
            // 
            // eNameLabel
            // 
            this.eNameLabel.AutoSize = true;
            this.eNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eNameLabel.Location = new System.Drawing.Point(842, 616);
            this.eNameLabel.Name = "eNameLabel";
            this.eNameLabel.Size = new System.Drawing.Size(19, 25);
            this.eNameLabel.TabIndex = 15;
            this.eNameLabel.Text = "-";
            // 
            // eSlabel
            // 
            this.eSlabel.AutoSize = true;
            this.eSlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eSlabel.Location = new System.Drawing.Point(669, 657);
            this.eSlabel.Name = "eSlabel";
            this.eSlabel.Size = new System.Drawing.Size(104, 25);
            this.eSlabel.TabIndex = 16;
            this.eSlabel.Text = "ชื่อทางบัญชี";
            // 
            // eSerialLabel
            // 
            this.eSerialLabel.AutoSize = true;
            this.eSerialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eSerialLabel.Location = new System.Drawing.Point(842, 657);
            this.eSerialLabel.Name = "eSerialLabel";
            this.eSerialLabel.Size = new System.Drawing.Size(19, 25);
            this.eSerialLabel.TabIndex = 17;
            this.eSerialLabel.Text = "-";
            // 
            // eStLabel
            // 
            this.eStLabel.AutoSize = true;
            this.eStLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eStLabel.Location = new System.Drawing.Point(669, 744);
            this.eStLabel.Name = "eStLabel";
            this.eStLabel.Size = new System.Drawing.Size(125, 25);
            this.eStLabel.TabIndex = 18;
            this.eStLabel.Text = "สถานะอุปกรณ์";
            // 
            // eStatusLabel
            // 
            this.eStatusLabel.AutoSize = true;
            this.eStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eStatusLabel.Location = new System.Drawing.Point(841, 744);
            this.eStatusLabel.Name = "eStatusLabel";
            this.eStatusLabel.Size = new System.Drawing.Size(19, 25);
            this.eStatusLabel.TabIndex = 19;
            this.eStatusLabel.Text = "-";
            // 
            // equipmentPictureBox
            // 
            this.equipmentPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.equipmentPictureBox.Location = new System.Drawing.Point(654, 230);
            this.equipmentPictureBox.Name = "equipmentPictureBox";
            this.equipmentPictureBox.Size = new System.Drawing.Size(390, 379);
            this.equipmentPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.equipmentPictureBox.TabIndex = 20;
            this.equipmentPictureBox.TabStop = false;
            // 
            // ilabel
            // 
            this.ilabel.AutoSize = true;
            this.ilabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ilabel.Location = new System.Drawing.Point(669, 701);
            this.ilabel.Name = "ilabel";
            this.ilabel.Size = new System.Drawing.Size(130, 25);
            this.ilabel.TabIndex = 21;
            this.ilabel.Text = "พื้นที่ปฎิบัติงาน";
            // 
            // InsPlacelabel
            // 
            this.InsPlacelabel.AutoSize = true;
            this.InsPlacelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsPlacelabel.Location = new System.Drawing.Point(841, 701);
            this.InsPlacelabel.Name = "InsPlacelabel";
            this.InsPlacelabel.Size = new System.Drawing.Size(19, 25);
            this.InsPlacelabel.TabIndex = 22;
            this.InsPlacelabel.Text = "-";
            // 
            // pTypelabel
            // 
            this.pTypelabel.AutoSize = true;
            this.pTypelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pTypelabel.Location = new System.Drawing.Point(669, 65);
            this.pTypelabel.Name = "pTypelabel";
            this.pTypelabel.Size = new System.Drawing.Size(122, 25);
            this.pTypelabel.TabIndex = 23;
            this.pTypelabel.Text = "ประเภทแผน :";
            // 
            // periodlabel
            // 
            this.periodlabel.AutoSize = true;
            this.periodlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodlabel.Location = new System.Drawing.Point(669, 106);
            this.periodlabel.Name = "periodlabel";
            this.periodlabel.Size = new System.Drawing.Size(223, 25);
            this.periodlabel.TabIndex = 24;
            this.periodlabel.Text = "ระยะเวลาของแผนต่อรอบ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(669, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 26;
            this.label1.Text = "วันที่ต้องดำเนินการ :";
            // 
            // pTypecomboBox
            // 
            this.pTypecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pTypecomboBox.FormattingEnabled = true;
            this.pTypecomboBox.Location = new System.Drawing.Point(898, 62);
            this.pTypecomboBox.Name = "pTypecomboBox";
            this.pTypecomboBox.Size = new System.Drawing.Size(278, 33);
            this.pTypecomboBox.TabIndex = 27;
            // 
            // pPeriodcomboBox
            // 
            this.pPeriodcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pPeriodcomboBox.FormattingEnabled = true;
            this.pPeriodcomboBox.Location = new System.Drawing.Point(898, 101);
            this.pPeriodcomboBox.Name = "pPeriodcomboBox";
            this.pPeriodcomboBox.Size = new System.Drawing.Size(278, 33);
            this.pPeriodcomboBox.TabIndex = 28;
            // 
            // dateToDodateTimePicker
            // 
            this.dateToDodateTimePicker.Location = new System.Drawing.Point(849, 197);
            this.dateToDodateTimePicker.Name = "dateToDodateTimePicker";
            this.dateToDodateTimePicker.Size = new System.Drawing.Size(209, 20);
            this.dateToDodateTimePicker.TabIndex = 30;
            // 
            // oPlacepictureBox
            // 
            this.oPlacepictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.oPlacepictureBox.Location = new System.Drawing.Point(1062, 230);
            this.oPlacepictureBox.Name = "oPlacepictureBox";
            this.oPlacepictureBox.Size = new System.Drawing.Size(390, 379);
            this.oPlacepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.oPlacepictureBox.TabIndex = 31;
            this.oPlacepictureBox.TabStop = false;
            // 
            // createPlanbutton
            // 
            this.createPlanbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPlanbutton.Location = new System.Drawing.Point(1182, 62);
            this.createPlanbutton.Name = "createPlanbutton";
            this.createPlanbutton.Size = new System.Drawing.Size(92, 33);
            this.createPlanbutton.TabIndex = 32;
            this.createPlanbutton.Text = "สร้าง";
            this.createPlanbutton.UseVisualStyleBackColor = true;
            this.createPlanbutton.Click += new System.EventHandler(this.createPlanbutton_Click);
            // 
            // createPlanPeriodbutton
            // 
            this.createPlanPeriodbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPlanPeriodbutton.Location = new System.Drawing.Point(1182, 102);
            this.createPlanPeriodbutton.Name = "createPlanPeriodbutton";
            this.createPlanPeriodbutton.Size = new System.Drawing.Size(92, 33);
            this.createPlanPeriodbutton.TabIndex = 33;
            this.createPlanPeriodbutton.Text = "สร้าง";
            this.createPlanPeriodbutton.UseVisualStyleBackColor = true;
            this.createPlanPeriodbutton.Click += new System.EventHandler(this.createPlanPeriodbutton_Click);
            // 
            // removeSelectedbutton
            // 
            this.removeSelectedbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeSelectedbutton.Location = new System.Drawing.Point(446, 740);
            this.removeSelectedbutton.Name = "removeSelectedbutton";
            this.removeSelectedbutton.Size = new System.Drawing.Size(197, 33);
            this.removeSelectedbutton.TabIndex = 34;
            this.removeSelectedbutton.Text = "ยกเลิกอุปกรณ์ที่เลือก";
            this.removeSelectedbutton.UseVisualStyleBackColor = true;
            this.removeSelectedbutton.Click += new System.EventHandler(this.removeSelectedbutton_Click);
            // 
            // deslabel
            // 
            this.deslabel.AutoSize = true;
            this.deslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deslabel.Location = new System.Drawing.Point(1064, 197);
            this.deslabel.Name = "deslabel";
            this.deslabel.Size = new System.Drawing.Size(361, 20);
            this.deslabel.TabIndex = 35;
            this.deslabel.Text = "*กรณีไม่มีวันที่ชัดเจน กรุณาระบุวันสุดท้ายที่ต้องทำตามแผน";
            // 
            // recoredPlanButton
            // 
            this.recoredPlanButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.recoredPlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoredPlanButton.Location = new System.Drawing.Point(1255, 740);
            this.recoredPlanButton.Name = "recoredPlanButton";
            this.recoredPlanButton.Size = new System.Drawing.Size(197, 34);
            this.recoredPlanButton.TabIndex = 60;
            this.recoredPlanButton.Text = "บันทึกแผน";
            this.recoredPlanButton.UseVisualStyleBackColor = false;
            this.recoredPlanButton.Click += new System.EventHandler(this.recoredPlanButton_Click);
            // 
            // CreatePlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.recoredPlanButton);
            this.Controls.Add(this.deslabel);
            this.Controls.Add(this.removeSelectedbutton);
            this.Controls.Add(this.createPlanPeriodbutton);
            this.Controls.Add(this.createPlanbutton);
            this.Controls.Add(this.oPlacepictureBox);
            this.Controls.Add(this.dateToDodateTimePicker);
            this.Controls.Add(this.pPeriodcomboBox);
            this.Controls.Add(this.pTypecomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.periodlabel);
            this.Controls.Add(this.pTypelabel);
            this.Controls.Add(this.InsPlacelabel);
            this.Controls.Add(this.ilabel);
            this.Controls.Add(this.equipmentPictureBox);
            this.Controls.Add(this.eStatusLabel);
            this.Controls.Add(this.eStLabel);
            this.Controls.Add(this.eSerialLabel);
            this.Controls.Add(this.eSlabel);
            this.Controls.Add(this.eNameLabel);
            this.Controls.Add(this.eNlabel);
            this.Controls.Add(this.EquipmentListDataGridView);
            this.Controls.Add(this.searchEquipmentLabel);
            this.Controls.Add(this.equipmentListSearchTextBox);
            this.Controls.Add(this.equipmentFilterListLabel);
            this.Controls.Add(this.equipmentTypeComboBox);
            this.Controls.Add(this.selectEquipmentlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreatePlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "สร้างแผนซ่อมบำรุงอุปกรณ์";
            ((System.ComponentModel.ISupportInitialize)(this.EquipmentListDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oPlacepictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectEquipmentlabel;
        private System.Windows.Forms.Label searchEquipmentLabel;
        private System.Windows.Forms.TextBox equipmentListSearchTextBox;
        private System.Windows.Forms.Label equipmentFilterListLabel;
        private System.Windows.Forms.ComboBox equipmentTypeComboBox;
        private System.Windows.Forms.DataGridView EquipmentListDataGridView;
        private System.Windows.Forms.Label eNlabel;
        private System.Windows.Forms.Label eNameLabel;
        private System.Windows.Forms.Label eSlabel;
        private System.Windows.Forms.Label eSerialLabel;
        private System.Windows.Forms.Label eStLabel;
        private System.Windows.Forms.Label eStatusLabel;
        private System.Windows.Forms.PictureBox equipmentPictureBox;
        private System.Windows.Forms.Label ilabel;
        private System.Windows.Forms.Label InsPlacelabel;
        private System.Windows.Forms.Label pTypelabel;
        private System.Windows.Forms.Label periodlabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox pTypecomboBox;
        private System.Windows.Forms.ComboBox pPeriodcomboBox;
        private System.Windows.Forms.DateTimePicker dateToDodateTimePicker;
        private System.Windows.Forms.PictureBox oPlacepictureBox;
        private System.Windows.Forms.Button createPlanbutton;
        private System.Windows.Forms.Button createPlanPeriodbutton;
        private System.Windows.Forms.Button removeSelectedbutton;
        private System.Windows.Forms.Label deslabel;
        private System.Windows.Forms.Button recoredPlanButton;
    }
}