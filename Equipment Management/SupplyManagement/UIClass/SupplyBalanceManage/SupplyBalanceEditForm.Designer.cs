namespace Admin_Program.SupplyManagement.UIClass.SupplyBalanceManage
{
    partial class SupplyBalanceEditForm
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
            this.createbutton = new System.Windows.Forms.Button();
            this.updateDatedateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.updateDatelabel = new System.Windows.Forms.Label();
            this.currentBalancetextBox = new System.Windows.Forms.TextBox();
            this.currentBalancelabel = new System.Windows.Forms.Label();
            this.sUnittextBox = new System.Windows.Forms.TextBox();
            this.moqtextBox = new System.Windows.Forms.TextBox();
            this.moqlabel = new System.Windows.Forms.Label();
            this.supplyNametextBox = new System.Windows.Forms.TextBox();
            this.supplyNamelabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // createbutton
            // 
            this.createbutton.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.createbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.createbutton.Location = new System.Drawing.Point(657, 68);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(75, 56);
            this.createbutton.TabIndex = 705;
            this.createbutton.Text = "บันทึก";
            this.createbutton.UseVisualStyleBackColor = false;
            this.createbutton.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // updateDatedateTimePicker
            // 
            this.updateDatedateTimePicker.Location = new System.Drawing.Point(311, 90);
            this.updateDatedateTimePicker.Name = "updateDatedateTimePicker";
            this.updateDatedateTimePicker.Size = new System.Drawing.Size(200, 20);
            this.updateDatedateTimePicker.TabIndex = 703;
            // 
            // updateDatelabel
            // 
            this.updateDatelabel.AutoSize = true;
            this.updateDatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.updateDatelabel.Location = new System.Drawing.Point(219, 91);
            this.updateDatelabel.Name = "updateDatelabel";
            this.updateDatelabel.Size = new System.Drawing.Size(86, 20);
            this.updateDatelabel.TabIndex = 707;
            this.updateDatelabel.Text = "วันที่อัฟเดท :";
            // 
            // currentBalancetextBox
            // 
            this.currentBalancetextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.currentBalancetextBox.Location = new System.Drawing.Point(118, 88);
            this.currentBalancetextBox.Name = "currentBalancetextBox";
            this.currentBalancetextBox.Size = new System.Drawing.Size(91, 26);
            this.currentBalancetextBox.TabIndex = 702;
            // 
            // currentBalancelabel
            // 
            this.currentBalancelabel.AutoSize = true;
            this.currentBalancelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.currentBalancelabel.Location = new System.Drawing.Point(12, 91);
            this.currentBalancelabel.Name = "currentBalancelabel";
            this.currentBalancelabel.Size = new System.Drawing.Size(100, 20);
            this.currentBalancelabel.TabIndex = 706;
            this.currentBalancelabel.Text = "จำนวนปัจจุบัน :";
            // 
            // sUnittextBox
            // 
            this.sUnittextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.sUnittextBox.Location = new System.Drawing.Point(320, 50);
            this.sUnittextBox.Name = "sUnittextBox";
            this.sUnittextBox.ReadOnly = true;
            this.sUnittextBox.Size = new System.Drawing.Size(91, 26);
            this.sUnittextBox.TabIndex = 710;
            // 
            // moqtextBox
            // 
            this.moqtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.moqtextBox.Location = new System.Drawing.Point(223, 50);
            this.moqtextBox.Name = "moqtextBox";
            this.moqtextBox.ReadOnly = true;
            this.moqtextBox.Size = new System.Drawing.Size(91, 26);
            this.moqtextBox.TabIndex = 709;
            // 
            // moqlabel
            // 
            this.moqlabel.AutoSize = true;
            this.moqlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.moqlabel.Location = new System.Drawing.Point(12, 54);
            this.moqlabel.Name = "moqlabel";
            this.moqlabel.Size = new System.Drawing.Size(205, 20);
            this.moqlabel.TabIndex = 704;
            this.moqlabel.Text = "จำนวนเมื่อถึงกำหนดต้องสั่งเพิ่ม :";
            // 
            // supplyNametextBox
            // 
            this.supplyNametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyNametextBox.Location = new System.Drawing.Point(76, 12);
            this.supplyNametextBox.Name = "supplyNametextBox";
            this.supplyNametextBox.ReadOnly = true;
            this.supplyNametextBox.Size = new System.Drawing.Size(656, 26);
            this.supplyNametextBox.TabIndex = 708;
            // 
            // supplyNamelabel
            // 
            this.supplyNamelabel.AutoSize = true;
            this.supplyNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyNamelabel.Location = new System.Drawing.Point(12, 15);
            this.supplyNamelabel.Name = "supplyNamelabel";
            this.supplyNamelabel.Size = new System.Drawing.Size(58, 20);
            this.supplyNamelabel.TabIndex = 701;
            this.supplyNamelabel.Text = "ชื่อวัสดุ :";
            // 
            // SupplyBalanceEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(744, 136);
            this.Controls.Add(this.createbutton);
            this.Controls.Add(this.updateDatedateTimePicker);
            this.Controls.Add(this.updateDatelabel);
            this.Controls.Add(this.currentBalancetextBox);
            this.Controls.Add(this.currentBalancelabel);
            this.Controls.Add(this.sUnittextBox);
            this.Controls.Add(this.moqtextBox);
            this.Controls.Add(this.moqlabel);
            this.Controls.Add(this.supplyNametextBox);
            this.Controls.Add(this.supplyNamelabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyBalanceEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "แก้ใขยอดปัจจุบัน";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createbutton;
        private System.Windows.Forms.DateTimePicker updateDatedateTimePicker;
        private System.Windows.Forms.Label updateDatelabel;
        private System.Windows.Forms.TextBox currentBalancetextBox;
        private System.Windows.Forms.Label currentBalancelabel;
        private System.Windows.Forms.TextBox sUnittextBox;
        private System.Windows.Forms.TextBox moqtextBox;
        private System.Windows.Forms.Label moqlabel;
        private System.Windows.Forms.TextBox supplyNametextBox;
        private System.Windows.Forms.Label supplyNamelabel;
    }
}