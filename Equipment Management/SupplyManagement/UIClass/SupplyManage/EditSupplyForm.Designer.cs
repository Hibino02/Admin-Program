namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    partial class EditSupplyForm
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
            this.editButton = new System.Windows.Forms.Button();
            this.supplyPictureBox = new System.Windows.Forms.PictureBox();
            this.CreateSupplyTypeButton = new System.Windows.Forms.Button();
            this.supplyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.PhotoURLtextBox = new System.Windows.Forms.TextBox();
            this.AttachPhotoButton = new System.Windows.Forms.Button();
            this.IsActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.moqnumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.moqlabel = new System.Windows.Forms.Label();
            this.supplyUnitTextBox = new System.Windows.Forms.TextBox();
            this.supplyUnitLabel = new System.Windows.Forms.Label();
            this.explainSupplyNameLabel = new System.Windows.Forms.Label();
            this.supplyNameTextBox = new System.Windows.Forms.TextBox();
            this.supplyNameLabel = new System.Windows.Forms.Label();
            this.manageSupplyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.supplyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moqnumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(1308, 724);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(145, 45);
            this.editButton.TabIndex = 47;
            this.editButton.Text = "บันทึกการแก้ใข";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // supplyPictureBox
            // 
            this.supplyPictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.supplyPictureBox.Location = new System.Drawing.Point(16, 108);
            this.supplyPictureBox.Name = "supplyPictureBox";
            this.supplyPictureBox.Size = new System.Drawing.Size(726, 661);
            this.supplyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.supplyPictureBox.TabIndex = 46;
            this.supplyPictureBox.TabStop = false;
            // 
            // CreateSupplyTypeButton
            // 
            this.CreateSupplyTypeButton.Location = new System.Drawing.Point(1308, 66);
            this.CreateSupplyTypeButton.Name = "CreateSupplyTypeButton";
            this.CreateSupplyTypeButton.Size = new System.Drawing.Size(145, 31);
            this.CreateSupplyTypeButton.TabIndex = 45;
            this.CreateSupplyTypeButton.Text = "สร้างประเภทวัสดุ";
            this.CreateSupplyTypeButton.UseVisualStyleBackColor = true;
            this.CreateSupplyTypeButton.Click += new System.EventHandler(this.CreateSupplyTypeButton_Click);
            // 
            // supplyTypeComboBox
            // 
            this.supplyTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyTypeComboBox.FormattingEnabled = true;
            this.supplyTypeComboBox.Location = new System.Drawing.Point(1058, 12);
            this.supplyTypeComboBox.Name = "supplyTypeComboBox";
            this.supplyTypeComboBox.Size = new System.Drawing.Size(395, 26);
            this.supplyTypeComboBox.TabIndex = 44;
            // 
            // PhotoURLtextBox
            // 
            this.PhotoURLtextBox.Enabled = false;
            this.PhotoURLtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PhotoURLtextBox.Location = new System.Drawing.Point(550, 67);
            this.PhotoURLtextBox.Name = "PhotoURLtextBox";
            this.PhotoURLtextBox.Size = new System.Drawing.Size(752, 26);
            this.PhotoURLtextBox.TabIndex = 43;
            // 
            // AttachPhotoButton
            // 
            this.AttachPhotoButton.Location = new System.Drawing.Point(449, 65);
            this.AttachPhotoButton.Name = "AttachPhotoButton";
            this.AttachPhotoButton.Size = new System.Drawing.Size(95, 31);
            this.AttachPhotoButton.TabIndex = 42;
            this.AttachPhotoButton.Text = "แนบรูป";
            this.AttachPhotoButton.UseVisualStyleBackColor = true;
            this.AttachPhotoButton.Click += new System.EventHandler(this.AttachPhotoButton_Click);
            // 
            // IsActiveCheckBox
            // 
            this.IsActiveCheckBox.AutoSize = true;
            this.IsActiveCheckBox.Checked = true;
            this.IsActiveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsActiveCheckBox.Location = new System.Drawing.Point(281, 73);
            this.IsActiveCheckBox.Name = "IsActiveCheckBox";
            this.IsActiveCheckBox.Size = new System.Drawing.Size(147, 17);
            this.IsActiveCheckBox.TabIndex = 41;
            this.IsActiveCheckBox.Text = "ปัจจุบัณ วัสดุนี้ยังใช้งานอยู่";
            this.IsActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // moqnumericUpDown
            // 
            this.moqnumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.moqnumericUpDown.Location = new System.Drawing.Point(189, 69);
            this.moqnumericUpDown.Name = "moqnumericUpDown";
            this.moqnumericUpDown.Size = new System.Drawing.Size(68, 24);
            this.moqnumericUpDown.TabIndex = 40;
            // 
            // moqlabel
            // 
            this.moqlabel.AutoSize = true;
            this.moqlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.moqlabel.Location = new System.Drawing.Point(12, 70);
            this.moqlabel.Name = "moqlabel";
            this.moqlabel.Size = new System.Drawing.Size(171, 20);
            this.moqlabel.TabIndex = 39;
            this.moqlabel.Text = "จำนวนเมื่อถึงกำหนดต้องสั่ง";
            // 
            // supplyUnitTextBox
            // 
            this.supplyUnitTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyUnitTextBox.Location = new System.Drawing.Point(806, 12);
            this.supplyUnitTextBox.Name = "supplyUnitTextBox";
            this.supplyUnitTextBox.Size = new System.Drawing.Size(227, 26);
            this.supplyUnitTextBox.TabIndex = 38;
            // 
            // supplyUnitLabel
            // 
            this.supplyUnitLabel.AutoSize = true;
            this.supplyUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyUnitLabel.Location = new System.Drawing.Point(758, 15);
            this.supplyUnitLabel.Name = "supplyUnitLabel";
            this.supplyUnitLabel.Size = new System.Drawing.Size(42, 20);
            this.supplyUnitLabel.TabIndex = 37;
            this.supplyUnitLabel.Text = "หน่วย";
            // 
            // explainSupplyNameLabel
            // 
            this.explainSupplyNameLabel.AutoSize = true;
            this.explainSupplyNameLabel.Location = new System.Drawing.Point(65, 41);
            this.explainSupplyNameLabel.Name = "explainSupplyNameLabel";
            this.explainSupplyNameLabel.Size = new System.Drawing.Size(143, 13);
            this.explainSupplyNameLabel.TabIndex = 36;
            this.explainSupplyNameLabel.Text = "* ชื่อวัสดุห้ามเกิน 77 ตัวอักษร";
            // 
            // supplyNameTextBox
            // 
            this.supplyNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyNameTextBox.Location = new System.Drawing.Point(68, 12);
            this.supplyNameTextBox.Name = "supplyNameTextBox";
            this.supplyNameTextBox.Size = new System.Drawing.Size(658, 26);
            this.supplyNameTextBox.TabIndex = 35;
            // 
            // supplyNameLabel
            // 
            this.supplyNameLabel.AutoSize = true;
            this.supplyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyNameLabel.Location = new System.Drawing.Point(12, 15);
            this.supplyNameLabel.Name = "supplyNameLabel";
            this.supplyNameLabel.Size = new System.Drawing.Size(50, 20);
            this.supplyNameLabel.TabIndex = 34;
            this.supplyNameLabel.Text = "ชื่อวัสดุ";
            // 
            // manageSupplyButton
            // 
            this.manageSupplyButton.Location = new System.Drawing.Point(1307, 108);
            this.manageSupplyButton.Name = "manageSupplyButton";
            this.manageSupplyButton.Size = new System.Drawing.Size(145, 31);
            this.manageSupplyButton.TabIndex = 48;
            this.manageSupplyButton.Text = "จัดการประเภทวัสดุ";
            this.manageSupplyButton.UseVisualStyleBackColor = true;
            this.manageSupplyButton.Click += new System.EventHandler(this.manageSupplyButton_Click);
            // 
            // EditSupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.manageSupplyButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.supplyPictureBox);
            this.Controls.Add(this.CreateSupplyTypeButton);
            this.Controls.Add(this.supplyTypeComboBox);
            this.Controls.Add(this.PhotoURLtextBox);
            this.Controls.Add(this.AttachPhotoButton);
            this.Controls.Add(this.IsActiveCheckBox);
            this.Controls.Add(this.moqnumericUpDown);
            this.Controls.Add(this.moqlabel);
            this.Controls.Add(this.supplyUnitTextBox);
            this.Controls.Add(this.supplyUnitLabel);
            this.Controls.Add(this.explainSupplyNameLabel);
            this.Controls.Add(this.supplyNameTextBox);
            this.Controls.Add(this.supplyNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditSupplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "แก้ใขวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.supplyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moqnumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.PictureBox supplyPictureBox;
        private System.Windows.Forms.Button CreateSupplyTypeButton;
        private System.Windows.Forms.ComboBox supplyTypeComboBox;
        private System.Windows.Forms.TextBox PhotoURLtextBox;
        private System.Windows.Forms.Button AttachPhotoButton;
        private System.Windows.Forms.CheckBox IsActiveCheckBox;
        private System.Windows.Forms.NumericUpDown moqnumericUpDown;
        private System.Windows.Forms.Label moqlabel;
        private System.Windows.Forms.TextBox supplyUnitTextBox;
        private System.Windows.Forms.Label supplyUnitLabel;
        private System.Windows.Forms.Label explainSupplyNameLabel;
        private System.Windows.Forms.TextBox supplyNameTextBox;
        private System.Windows.Forms.Label supplyNameLabel;
        private System.Windows.Forms.Button manageSupplyButton;
    }
}