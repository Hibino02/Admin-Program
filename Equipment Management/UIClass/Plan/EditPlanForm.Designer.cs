namespace Equipment_Management.UIClass.Plan
{
    partial class EditPlanForm
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
            this.deslabel = new System.Windows.Forms.Label();
            this.createPlanPeriodbutton = new System.Windows.Forms.Button();
            this.oPlacepictureBox = new System.Windows.Forms.PictureBox();
            this.dateToDodateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.timeToDonumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.pPeriodcomboBox = new System.Windows.Forms.ComboBox();
            this.pTypecomboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.timeslabel = new System.Windows.Forms.Label();
            this.periodlabel = new System.Windows.Forms.Label();
            this.pTypelabel = new System.Windows.Forms.Label();
            this.InsPlacelabel = new System.Windows.Forms.Label();
            this.ilabel = new System.Windows.Forms.Label();
            this.equipmentPictureBox = new System.Windows.Forms.PictureBox();
            this.eStatusLabel = new System.Windows.Forms.Label();
            this.eStLabel = new System.Windows.Forms.Label();
            this.eSerialLabel = new System.Windows.Forms.Label();
            this.eSlabel = new System.Windows.Forms.Label();
            this.eNameLabel = new System.Windows.Forms.Label();
            this.eNlabel = new System.Windows.Forms.Label();
            this.recoredPlanButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.oPlacepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeToDonumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // deslabel
            // 
            this.deslabel.AutoSize = true;
            this.deslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deslabel.Location = new System.Drawing.Point(422, 145);
            this.deslabel.Name = "deslabel";
            this.deslabel.Size = new System.Drawing.Size(361, 20);
            this.deslabel.TabIndex = 56;
            this.deslabel.Text = "*กรณีไม่มีวันที่ชัดเจน กรุณาระบุวันสุดท้ายที่ต้องทำตามแผน";
            // 
            // createPlanPeriodbutton
            // 
            this.createPlanPeriodbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPlanPeriodbutton.Location = new System.Drawing.Point(540, 50);
            this.createPlanPeriodbutton.Name = "createPlanPeriodbutton";
            this.createPlanPeriodbutton.Size = new System.Drawing.Size(92, 33);
            this.createPlanPeriodbutton.TabIndex = 55;
            this.createPlanPeriodbutton.Text = "สร้าง";
            this.createPlanPeriodbutton.UseVisualStyleBackColor = true;
            this.createPlanPeriodbutton.Click += new System.EventHandler(this.createPlanPeriodbutton_Click);
            // 
            // oPlacepictureBox
            // 
            this.oPlacepictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.oPlacepictureBox.Location = new System.Drawing.Point(420, 178);
            this.oPlacepictureBox.Name = "oPlacepictureBox";
            this.oPlacepictureBox.Size = new System.Drawing.Size(390, 379);
            this.oPlacepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.oPlacepictureBox.TabIndex = 53;
            this.oPlacepictureBox.TabStop = false;
            // 
            // dateToDodateTimePicker
            // 
            this.dateToDodateTimePicker.Location = new System.Drawing.Point(207, 145);
            this.dateToDodateTimePicker.Name = "dateToDodateTimePicker";
            this.dateToDodateTimePicker.Size = new System.Drawing.Size(209, 20);
            this.dateToDodateTimePicker.TabIndex = 52;
            // 
            // timeToDonumericUpDown
            // 
            this.timeToDonumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeToDonumericUpDown.Location = new System.Drawing.Point(347, 94);
            this.timeToDonumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.timeToDonumericUpDown.Name = "timeToDonumericUpDown";
            this.timeToDonumericUpDown.Size = new System.Drawing.Size(55, 31);
            this.timeToDonumericUpDown.TabIndex = 51;
            this.timeToDonumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pPeriodcomboBox
            // 
            this.pPeriodcomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pPeriodcomboBox.FormattingEnabled = true;
            this.pPeriodcomboBox.Location = new System.Drawing.Point(256, 49);
            this.pPeriodcomboBox.Name = "pPeriodcomboBox";
            this.pPeriodcomboBox.Size = new System.Drawing.Size(278, 33);
            this.pPeriodcomboBox.TabIndex = 50;
            // 
            // pTypecomboBox
            // 
            this.pTypecomboBox.Enabled = false;
            this.pTypecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pTypecomboBox.FormattingEnabled = true;
            this.pTypecomboBox.Location = new System.Drawing.Point(256, 10);
            this.pTypecomboBox.Name = "pTypecomboBox";
            this.pTypecomboBox.Size = new System.Drawing.Size(278, 33);
            this.pTypecomboBox.TabIndex = 49;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 48;
            this.label1.Text = "วันที่ต้องดำเนินการ :";
            // 
            // timeslabel
            // 
            this.timeslabel.AutoSize = true;
            this.timeslabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeslabel.Location = new System.Drawing.Point(27, 98);
            this.timeslabel.Name = "timeslabel";
            this.timeslabel.Size = new System.Drawing.Size(294, 25);
            this.timeslabel.TabIndex = 47;
            this.timeslabel.Text = "จำนวนครั้งในการซ่อมบำรุงต่อรอบ :";
            // 
            // periodlabel
            // 
            this.periodlabel.AutoSize = true;
            this.periodlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.periodlabel.Location = new System.Drawing.Point(27, 54);
            this.periodlabel.Name = "periodlabel";
            this.periodlabel.Size = new System.Drawing.Size(223, 25);
            this.periodlabel.TabIndex = 46;
            this.periodlabel.Text = "ระยะเวลาของแผนต่อรอบ :";
            // 
            // pTypelabel
            // 
            this.pTypelabel.AutoSize = true;
            this.pTypelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pTypelabel.Location = new System.Drawing.Point(27, 13);
            this.pTypelabel.Name = "pTypelabel";
            this.pTypelabel.Size = new System.Drawing.Size(122, 25);
            this.pTypelabel.TabIndex = 45;
            this.pTypelabel.Text = "ประเภทแผน :";
            // 
            // InsPlacelabel
            // 
            this.InsPlacelabel.AutoSize = true;
            this.InsPlacelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsPlacelabel.Location = new System.Drawing.Point(199, 649);
            this.InsPlacelabel.Name = "InsPlacelabel";
            this.InsPlacelabel.Size = new System.Drawing.Size(19, 25);
            this.InsPlacelabel.TabIndex = 44;
            this.InsPlacelabel.Text = "-";
            // 
            // ilabel
            // 
            this.ilabel.AutoSize = true;
            this.ilabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ilabel.Location = new System.Drawing.Point(27, 649);
            this.ilabel.Name = "ilabel";
            this.ilabel.Size = new System.Drawing.Size(130, 25);
            this.ilabel.TabIndex = 43;
            this.ilabel.Text = "พื้นที่ปฎิบัติงาน";
            // 
            // equipmentPictureBox
            // 
            this.equipmentPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.equipmentPictureBox.Location = new System.Drawing.Point(12, 178);
            this.equipmentPictureBox.Name = "equipmentPictureBox";
            this.equipmentPictureBox.Size = new System.Drawing.Size(390, 379);
            this.equipmentPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.equipmentPictureBox.TabIndex = 42;
            this.equipmentPictureBox.TabStop = false;
            // 
            // eStatusLabel
            // 
            this.eStatusLabel.AutoSize = true;
            this.eStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eStatusLabel.Location = new System.Drawing.Point(199, 692);
            this.eStatusLabel.Name = "eStatusLabel";
            this.eStatusLabel.Size = new System.Drawing.Size(19, 25);
            this.eStatusLabel.TabIndex = 41;
            this.eStatusLabel.Text = "-";
            // 
            // eStLabel
            // 
            this.eStLabel.AutoSize = true;
            this.eStLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eStLabel.Location = new System.Drawing.Point(27, 692);
            this.eStLabel.Name = "eStLabel";
            this.eStLabel.Size = new System.Drawing.Size(125, 25);
            this.eStLabel.TabIndex = 40;
            this.eStLabel.Text = "สถานะอุปกรณ์";
            // 
            // eSerialLabel
            // 
            this.eSerialLabel.AutoSize = true;
            this.eSerialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eSerialLabel.Location = new System.Drawing.Point(200, 605);
            this.eSerialLabel.Name = "eSerialLabel";
            this.eSerialLabel.Size = new System.Drawing.Size(19, 25);
            this.eSerialLabel.TabIndex = 39;
            this.eSerialLabel.Text = "-";
            // 
            // eSlabel
            // 
            this.eSlabel.AutoSize = true;
            this.eSlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eSlabel.Location = new System.Drawing.Point(27, 605);
            this.eSlabel.Name = "eSlabel";
            this.eSlabel.Size = new System.Drawing.Size(104, 25);
            this.eSlabel.TabIndex = 38;
            this.eSlabel.Text = "ชื่อทางบัญชี";
            // 
            // eNameLabel
            // 
            this.eNameLabel.AutoSize = true;
            this.eNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eNameLabel.Location = new System.Drawing.Point(200, 564);
            this.eNameLabel.Name = "eNameLabel";
            this.eNameLabel.Size = new System.Drawing.Size(19, 25);
            this.eNameLabel.TabIndex = 37;
            this.eNameLabel.Text = "-";
            // 
            // eNlabel
            // 
            this.eNlabel.AutoSize = true;
            this.eNlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eNlabel.Location = new System.Drawing.Point(27, 564);
            this.eNlabel.Name = "eNlabel";
            this.eNlabel.Size = new System.Drawing.Size(167, 25);
            this.eNlabel.TabIndex = 36;
            this.eNlabel.Text = "ชื่ออุปกรณ์ที่ถูกเลือก";
            // 
            // recoredPlanButton
            // 
            this.recoredPlanButton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.recoredPlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recoredPlanButton.Location = new System.Drawing.Point(613, 735);
            this.recoredPlanButton.Name = "recoredPlanButton";
            this.recoredPlanButton.Size = new System.Drawing.Size(197, 34);
            this.recoredPlanButton.TabIndex = 61;
            this.recoredPlanButton.Text = "ปรับปรุงแผน";
            this.recoredPlanButton.UseVisualStyleBackColor = false;
            this.recoredPlanButton.Click += new System.EventHandler(this.recoredPlanButton_Click);
            // 
            // EditPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 781);
            this.Controls.Add(this.recoredPlanButton);
            this.Controls.Add(this.deslabel);
            this.Controls.Add(this.createPlanPeriodbutton);
            this.Controls.Add(this.oPlacepictureBox);
            this.Controls.Add(this.dateToDodateTimePicker);
            this.Controls.Add(this.timeToDonumericUpDown);
            this.Controls.Add(this.pPeriodcomboBox);
            this.Controls.Add(this.pTypecomboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.timeslabel);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ปรับปรุงแผนซ่อมบำรุง";
            ((System.ComponentModel.ISupportInitialize)(this.oPlacepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeToDonumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label deslabel;
        private System.Windows.Forms.Button createPlanPeriodbutton;
        private System.Windows.Forms.PictureBox oPlacepictureBox;
        private System.Windows.Forms.DateTimePicker dateToDodateTimePicker;
        private System.Windows.Forms.NumericUpDown timeToDonumericUpDown;
        private System.Windows.Forms.ComboBox pPeriodcomboBox;
        private System.Windows.Forms.ComboBox pTypecomboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label timeslabel;
        private System.Windows.Forms.Label periodlabel;
        private System.Windows.Forms.Label pTypelabel;
        private System.Windows.Forms.Label InsPlacelabel;
        private System.Windows.Forms.Label ilabel;
        private System.Windows.Forms.PictureBox equipmentPictureBox;
        private System.Windows.Forms.Label eStatusLabel;
        private System.Windows.Forms.Label eStLabel;
        private System.Windows.Forms.Label eSerialLabel;
        private System.Windows.Forms.Label eSlabel;
        private System.Windows.Forms.Label eNameLabel;
        private System.Windows.Forms.Label eNlabel;
        private System.Windows.Forms.Button recoredPlanButton;
    }
}