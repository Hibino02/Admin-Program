namespace Admin_Program.EquipmentManagement.UIClass.Zone
{
    partial class ZoneManageForm
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
            this.createZpictureBox = new System.Windows.Forms.PictureBox();
            this.zNametextBox = new System.Windows.Forms.TextBox();
            this.addZbutton = new System.Windows.Forms.Button();
            this.zNamelabel = new System.Windows.Forms.Label();
            this.selectedZpictureBox = new System.Windows.Forms.PictureBox();
            this.removeZbutton = new System.Windows.Forms.Button();
            this.zoneListcomboBox = new System.Windows.Forms.ComboBox();
            this.addachPhotobutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.createZpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedZpictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // createZpictureBox
            // 
            this.createZpictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.createZpictureBox.Location = new System.Drawing.Point(12, 55);
            this.createZpictureBox.Name = "createZpictureBox";
            this.createZpictureBox.Size = new System.Drawing.Size(395, 213);
            this.createZpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.createZpictureBox.TabIndex = 82;
            this.createZpictureBox.TabStop = false;
            // 
            // zNametextBox
            // 
            this.zNametextBox.Location = new System.Drawing.Point(12, 29);
            this.zNametextBox.Name = "zNametextBox";
            this.zNametextBox.Size = new System.Drawing.Size(395, 20);
            this.zNametextBox.TabIndex = 83;
            // 
            // addZbutton
            // 
            this.addZbutton.Location = new System.Drawing.Point(332, 274);
            this.addZbutton.Name = "addZbutton";
            this.addZbutton.Size = new System.Drawing.Size(75, 23);
            this.addZbutton.TabIndex = 84;
            this.addZbutton.Text = "เพิ่มโซน";
            this.addZbutton.UseVisualStyleBackColor = true;
            this.addZbutton.Click += new System.EventHandler(this.addZbutton_Click);
            // 
            // zNamelabel
            // 
            this.zNamelabel.AutoSize = true;
            this.zNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.zNamelabel.Location = new System.Drawing.Point(12, 6);
            this.zNamelabel.Name = "zNamelabel";
            this.zNamelabel.Size = new System.Drawing.Size(190, 20);
            this.zNamelabel.TabIndex = 85;
            this.zNamelabel.Text = "ระบุรหัสโซนสำหรับเรียงลำดับ :";
            // 
            // selectedZpictureBox
            // 
            this.selectedZpictureBox.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.selectedZpictureBox.Location = new System.Drawing.Point(413, 55);
            this.selectedZpictureBox.Name = "selectedZpictureBox";
            this.selectedZpictureBox.Size = new System.Drawing.Size(395, 213);
            this.selectedZpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.selectedZpictureBox.TabIndex = 87;
            this.selectedZpictureBox.TabStop = false;
            // 
            // removeZbutton
            // 
            this.removeZbutton.Location = new System.Drawing.Point(733, 274);
            this.removeZbutton.Name = "removeZbutton";
            this.removeZbutton.Size = new System.Drawing.Size(75, 23);
            this.removeZbutton.TabIndex = 88;
            this.removeZbutton.Text = "ลบโซน";
            this.removeZbutton.UseVisualStyleBackColor = true;
            this.removeZbutton.Click += new System.EventHandler(this.removeZbutton_Click);
            // 
            // zoneListcomboBox
            // 
            this.zoneListcomboBox.FormattingEnabled = true;
            this.zoneListcomboBox.Location = new System.Drawing.Point(413, 29);
            this.zoneListcomboBox.Name = "zoneListcomboBox";
            this.zoneListcomboBox.Size = new System.Drawing.Size(395, 21);
            this.zoneListcomboBox.TabIndex = 89;
            this.zoneListcomboBox.SelectedIndexChanged += new System.EventHandler(this.zoneListcomboBox_SelectedIndexChanged);
            // 
            // addachPhotobutton
            // 
            this.addachPhotobutton.Location = new System.Drawing.Point(12, 274);
            this.addachPhotobutton.Name = "addachPhotobutton";
            this.addachPhotobutton.Size = new System.Drawing.Size(75, 23);
            this.addachPhotobutton.TabIndex = 90;
            this.addachPhotobutton.Text = "แนบรูป";
            this.addachPhotobutton.UseVisualStyleBackColor = true;
            this.addachPhotobutton.Click += new System.EventHandler(this.addachPhotobutton_Click);
            // 
            // ZoneManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(821, 304);
            this.Controls.Add(this.addachPhotobutton);
            this.Controls.Add(this.zoneListcomboBox);
            this.Controls.Add(this.removeZbutton);
            this.Controls.Add(this.selectedZpictureBox);
            this.Controls.Add(this.zNamelabel);
            this.Controls.Add(this.addZbutton);
            this.Controls.Add(this.zNametextBox);
            this.Controls.Add(this.createZpictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZoneManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "จัดการโซน";
            ((System.ComponentModel.ISupportInitialize)(this.createZpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectedZpictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.PictureBox createZpictureBox;
        private System.Windows.Forms.TextBox zNametextBox;
        private System.Windows.Forms.Button addZbutton;
        private System.Windows.Forms.Label zNamelabel;
        protected System.Windows.Forms.PictureBox selectedZpictureBox;
        private System.Windows.Forms.Button removeZbutton;
        private System.Windows.Forms.ComboBox zoneListcomboBox;
        private System.Windows.Forms.Button addachPhotobutton;
    }
}