﻿namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    partial class CreateSupplyForm
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
            this.searchSupplyTextBox = new System.Windows.Forms.TextBox();
            this.supplyNameLabel = new System.Windows.Forms.Label();
            this.explainSupplyNameLabel = new System.Windows.Forms.Label();
            this.supplyUnitLabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.moqlabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.IsActiveCheckBox = new System.Windows.Forms.CheckBox();
            this.AttachPhotoButton = new System.Windows.Forms.Button();
            this.PhotoURLtextBox = new System.Windows.Forms.TextBox();
            this.supplyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.CreateSupplyTypeButton = new System.Windows.Forms.Button();
            this.supplyPictureBox = new System.Windows.Forms.PictureBox();
            this.createButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // searchSupplyTextBox
            // 
            this.searchSupplyTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.searchSupplyTextBox.Location = new System.Drawing.Point(67, 12);
            this.searchSupplyTextBox.Name = "searchSupplyTextBox";
            this.searchSupplyTextBox.Size = new System.Drawing.Size(658, 26);
            this.searchSupplyTextBox.TabIndex = 21;
            // 
            // supplyNameLabel
            // 
            this.supplyNameLabel.AutoSize = true;
            this.supplyNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyNameLabel.Location = new System.Drawing.Point(11, 15);
            this.supplyNameLabel.Name = "supplyNameLabel";
            this.supplyNameLabel.Size = new System.Drawing.Size(50, 20);
            this.supplyNameLabel.TabIndex = 20;
            this.supplyNameLabel.Text = "ชื่อวัสดุ";
            // 
            // explainSupplyNameLabel
            // 
            this.explainSupplyNameLabel.AutoSize = true;
            this.explainSupplyNameLabel.Location = new System.Drawing.Point(64, 41);
            this.explainSupplyNameLabel.Name = "explainSupplyNameLabel";
            this.explainSupplyNameLabel.Size = new System.Drawing.Size(143, 13);
            this.explainSupplyNameLabel.TabIndex = 22;
            this.explainSupplyNameLabel.Text = "* ชื่อวัสดุห้ามเกิน 77 ตัวอักศร";
            // 
            // supplyUnitLabel
            // 
            this.supplyUnitLabel.AutoSize = true;
            this.supplyUnitLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyUnitLabel.Location = new System.Drawing.Point(757, 15);
            this.supplyUnitLabel.Name = "supplyUnitLabel";
            this.supplyUnitLabel.Size = new System.Drawing.Size(42, 20);
            this.supplyUnitLabel.TabIndex = 23;
            this.supplyUnitLabel.Text = "หน่วย";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.Location = new System.Drawing.Point(805, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(227, 26);
            this.textBox1.TabIndex = 24;
            // 
            // moqlabel
            // 
            this.moqlabel.AutoSize = true;
            this.moqlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.moqlabel.Location = new System.Drawing.Point(11, 70);
            this.moqlabel.Name = "moqlabel";
            this.moqlabel.Size = new System.Drawing.Size(171, 20);
            this.moqlabel.TabIndex = 25;
            this.moqlabel.Text = "จำนวนเมื่อถึงกำหนดต้องสั่ง";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.numericUpDown1.Location = new System.Drawing.Point(188, 69);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(68, 24);
            this.numericUpDown1.TabIndex = 26;
            // 
            // IsActiveCheckBox
            // 
            this.IsActiveCheckBox.AutoSize = true;
            this.IsActiveCheckBox.Location = new System.Drawing.Point(280, 73);
            this.IsActiveCheckBox.Name = "IsActiveCheckBox";
            this.IsActiveCheckBox.Size = new System.Drawing.Size(147, 17);
            this.IsActiveCheckBox.TabIndex = 27;
            this.IsActiveCheckBox.Text = "ปัจจุบัณ วัสดุนี้ยังใช้งานอยู่";
            this.IsActiveCheckBox.UseVisualStyleBackColor = true;
            // 
            // AttachPhotoButton
            // 
            this.AttachPhotoButton.Location = new System.Drawing.Point(448, 65);
            this.AttachPhotoButton.Name = "AttachPhotoButton";
            this.AttachPhotoButton.Size = new System.Drawing.Size(95, 31);
            this.AttachPhotoButton.TabIndex = 28;
            this.AttachPhotoButton.Text = "แนบรูป";
            this.AttachPhotoButton.UseVisualStyleBackColor = true;
            this.AttachPhotoButton.Click += new System.EventHandler(this.AttachPhotoButton_Click);
            // 
            // PhotoURLtextBox
            // 
            this.PhotoURLtextBox.Enabled = false;
            this.PhotoURLtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.PhotoURLtextBox.Location = new System.Drawing.Point(549, 67);
            this.PhotoURLtextBox.Name = "PhotoURLtextBox";
            this.PhotoURLtextBox.Size = new System.Drawing.Size(483, 26);
            this.PhotoURLtextBox.TabIndex = 29;
            // 
            // supplyTypeComboBox
            // 
            this.supplyTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyTypeComboBox.FormattingEnabled = true;
            this.supplyTypeComboBox.Location = new System.Drawing.Point(1057, 12);
            this.supplyTypeComboBox.Name = "supplyTypeComboBox";
            this.supplyTypeComboBox.Size = new System.Drawing.Size(395, 26);
            this.supplyTypeComboBox.TabIndex = 30;
            // 
            // CreateSupplyTypeButton
            // 
            this.CreateSupplyTypeButton.Location = new System.Drawing.Point(1307, 62);
            this.CreateSupplyTypeButton.Name = "CreateSupplyTypeButton";
            this.CreateSupplyTypeButton.Size = new System.Drawing.Size(145, 31);
            this.CreateSupplyTypeButton.TabIndex = 31;
            this.CreateSupplyTypeButton.Text = "สร้างประเภทวัสดุ";
            this.CreateSupplyTypeButton.UseVisualStyleBackColor = true;
            this.CreateSupplyTypeButton.Click += new System.EventHandler(this.CreateSupplyTypeButton_Click);
            // 
            // supplyPictureBox
            // 
            this.supplyPictureBox.Location = new System.Drawing.Point(15, 108);
            this.supplyPictureBox.Name = "supplyPictureBox";
            this.supplyPictureBox.Size = new System.Drawing.Size(675, 549);
            this.supplyPictureBox.TabIndex = 32;
            this.supplyPictureBox.TabStop = false;
            // 
            // createButton
            // 
            this.createButton.Location = new System.Drawing.Point(1307, 610);
            this.createButton.Name = "createButton";
            this.createButton.Size = new System.Drawing.Size(145, 45);
            this.createButton.TabIndex = 33;
            this.createButton.Text = "สร้าง";
            this.createButton.UseVisualStyleBackColor = true;
            // 
            // CreateSupplyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 667);
            this.Controls.Add(this.createButton);
            this.Controls.Add(this.supplyPictureBox);
            this.Controls.Add(this.CreateSupplyTypeButton);
            this.Controls.Add(this.supplyTypeComboBox);
            this.Controls.Add(this.PhotoURLtextBox);
            this.Controls.Add(this.AttachPhotoButton);
            this.Controls.Add(this.IsActiveCheckBox);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.moqlabel);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.supplyUnitLabel);
            this.Controls.Add(this.explainSupplyNameLabel);
            this.Controls.Add(this.searchSupplyTextBox);
            this.Controls.Add(this.supplyNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSupplyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "สร้างวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox searchSupplyTextBox;
        private System.Windows.Forms.Label supplyNameLabel;
        private System.Windows.Forms.Label explainSupplyNameLabel;
        private System.Windows.Forms.Label supplyUnitLabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label moqlabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox IsActiveCheckBox;
        private System.Windows.Forms.Button AttachPhotoButton;
        private System.Windows.Forms.TextBox PhotoURLtextBox;
        private System.Windows.Forms.ComboBox supplyTypeComboBox;
        private System.Windows.Forms.Button CreateSupplyTypeButton;
        private System.Windows.Forms.PictureBox supplyPictureBox;
        private System.Windows.Forms.Button createButton;
    }
}