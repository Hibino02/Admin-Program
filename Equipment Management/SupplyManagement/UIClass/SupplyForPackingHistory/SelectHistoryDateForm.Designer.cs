namespace Admin_Program.SupplyManagement.UIClass.SupplyForPackingHistory
{
    partial class SelectHistoryDateForm
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
            this.fromdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.todateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromlabel = new System.Windows.Forms.Label();
            this.tolabel = new System.Windows.Forms.Label();
            this.createExcelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fromdateTimePicker
            // 
            this.fromdateTimePicker.Location = new System.Drawing.Point(128, 28);
            this.fromdateTimePicker.Name = "fromdateTimePicker";
            this.fromdateTimePicker.Size = new System.Drawing.Size(203, 20);
            this.fromdateTimePicker.TabIndex = 0;
            // 
            // todateTimePicker
            // 
            this.todateTimePicker.Location = new System.Drawing.Point(128, 72);
            this.todateTimePicker.Name = "todateTimePicker";
            this.todateTimePicker.Size = new System.Drawing.Size(203, 20);
            this.todateTimePicker.TabIndex = 1;
            // 
            // fromlabel
            // 
            this.fromlabel.AutoSize = true;
            this.fromlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.fromlabel.Location = new System.Drawing.Point(12, 28);
            this.fromlabel.Name = "fromlabel";
            this.fromlabel.Size = new System.Drawing.Size(80, 24);
            this.fromlabel.TabIndex = 2;
            this.fromlabel.Text = "จากวันที่ :";
            // 
            // tolabel
            // 
            this.tolabel.AutoSize = true;
            this.tolabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.tolabel.Location = new System.Drawing.Point(22, 68);
            this.tolabel.Name = "tolabel";
            this.tolabel.Size = new System.Drawing.Size(70, 24);
            this.tolabel.TabIndex = 3;
            this.tolabel.Text = "ถึงวันที่ :";
            // 
            // createExcelbutton
            // 
            this.createExcelbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.createExcelbutton.Location = new System.Drawing.Point(386, 28);
            this.createExcelbutton.Name = "createExcelbutton";
            this.createExcelbutton.Size = new System.Drawing.Size(75, 55);
            this.createExcelbutton.TabIndex = 4;
            this.createExcelbutton.Text = "สร้าง Excel";
            this.createExcelbutton.UseVisualStyleBackColor = true;
            this.createExcelbutton.Click += new System.EventHandler(this.createExcelbutton_Click);
            // 
            // SelectHistoryDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(504, 121);
            this.Controls.Add(this.createExcelbutton);
            this.Controls.Add(this.tolabel);
            this.Controls.Add(this.fromlabel);
            this.Controls.Add(this.todateTimePicker);
            this.Controls.Add(this.fromdateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectHistoryDateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เลือกช่วงเวลา";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker fromdateTimePicker;
        private System.Windows.Forms.DateTimePicker todateTimePicker;
        private System.Windows.Forms.Label fromlabel;
        private System.Windows.Forms.Label tolabel;
        private System.Windows.Forms.Button createExcelbutton;
    }
}