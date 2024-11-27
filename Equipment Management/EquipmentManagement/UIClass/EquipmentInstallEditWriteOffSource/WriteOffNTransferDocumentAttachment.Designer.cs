namespace Admin_Program.UIClass.EquipmentInstallEditWriteOffSource
{
    partial class WriteOffNTransferDocumentAttachment
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
            this.attachDocumentLabel = new System.Windows.Forms.Label();
            this.attachDocumentButton = new System.Windows.Forms.Button();
            this.documentLinkLabel = new System.Windows.Forms.LinkLabel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // attachDocumentLabel
            // 
            this.attachDocumentLabel.AutoSize = true;
            this.attachDocumentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachDocumentLabel.Location = new System.Drawing.Point(12, 19);
            this.attachDocumentLabel.Name = "attachDocumentLabel";
            this.attachDocumentLabel.Size = new System.Drawing.Size(189, 20);
            this.attachDocumentLabel.TabIndex = 0;
            this.attachDocumentLabel.Text = "เอกสาร Write-Off / โอนย้าย :";
            // 
            // attachDocumentButton
            // 
            this.attachDocumentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachDocumentButton.Location = new System.Drawing.Point(228, 7);
            this.attachDocumentButton.Name = "attachDocumentButton";
            this.attachDocumentButton.Size = new System.Drawing.Size(131, 46);
            this.attachDocumentButton.TabIndex = 1;
            this.attachDocumentButton.Text = "เลือกไฟล์";
            this.attachDocumentButton.UseVisualStyleBackColor = true;
            this.attachDocumentButton.Click += new System.EventHandler(this.attachDocumentButton_Click);
            // 
            // documentLinkLabel
            // 
            this.documentLinkLabel.AutoSize = true;
            this.documentLinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.documentLinkLabel.Location = new System.Drawing.Point(377, 19);
            this.documentLinkLabel.Name = "documentLinkLabel";
            this.documentLinkLabel.Size = new System.Drawing.Size(80, 20);
            this.documentLinkLabel.TabIndex = 2;
            this.documentLinkLabel.TabStop = true;
            this.documentLinkLabel.Text = "ดูไฟล์ที่แนบ";
            this.documentLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.documentLinkLabel_LinkClicked);
            this.documentLinkLabel.MouseEnter += new System.EventHandler(this.documentLinkLabel_MouseEnter);
            this.documentLinkLabel.MouseLeave += new System.EventHandler(this.documentLinkLabel_MouseLeave);
            // 
            // OKButton
            // 
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.Location = new System.Drawing.Point(91, 90);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(131, 46);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "บันทึก";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CancelButton.Location = new System.Drawing.Point(228, 90);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(131, 46);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "ยกเลิก";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // WriteOffNTransferDocumentAttachment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 187);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.documentLinkLabel);
            this.Controls.Add(this.attachDocumentButton);
            this.Controls.Add(this.attachDocumentLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WriteOffNTransferDocumentAttachment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "แนบเอกสาร Write-Off / โอนย้าย";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label attachDocumentLabel;
        private System.Windows.Forms.Button attachDocumentButton;
        private System.Windows.Forms.LinkLabel documentLinkLabel;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
    }
}