namespace Admin_Program.SupplyManagement.UIClass.SupplyArrivalManage
{
    partial class SupplyArrivalForm
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
            this.supplyInPRArrivalLstdataGridView = new System.Windows.Forms.DataGridView();
            this.supplyInPlanlabel = new System.Windows.Forms.Label();
            this.supplyInSelectedPRdataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.deliverdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.deliverDatelabel = new System.Windows.Forms.Label();
            this.attachInvoicebutton = new System.Windows.Forms.Button();
            this.invoicelinkLabel = new System.Windows.Forms.LinkLabel();
            this.createbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRArrivalLstdataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInSelectedPRdataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // supplyInPRArrivalLstdataGridView
            // 
            this.supplyInPRArrivalLstdataGridView.AllowUserToAddRows = false;
            this.supplyInPRArrivalLstdataGridView.AllowUserToDeleteRows = false;
            this.supplyInPRArrivalLstdataGridView.AllowUserToResizeColumns = false;
            this.supplyInPRArrivalLstdataGridView.AllowUserToResizeRows = false;
            this.supplyInPRArrivalLstdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.supplyInPRArrivalLstdataGridView.Location = new System.Drawing.Point(12, 28);
            this.supplyInPRArrivalLstdataGridView.MultiSelect = false;
            this.supplyInPRArrivalLstdataGridView.Name = "supplyInPRArrivalLstdataGridView";
            this.supplyInPRArrivalLstdataGridView.ReadOnly = true;
            this.supplyInPRArrivalLstdataGridView.RowHeadersVisible = false;
            this.supplyInPRArrivalLstdataGridView.RowTemplate.Height = 24;
            this.supplyInPRArrivalLstdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInPRArrivalLstdataGridView.ShowCellToolTips = false;
            this.supplyInPRArrivalLstdataGridView.Size = new System.Drawing.Size(1440, 290);
            this.supplyInPRArrivalLstdataGridView.TabIndex = 29;
            this.supplyInPRArrivalLstdataGridView.SelectionChanged += new System.EventHandler(this.supplyInPRArrivalLstdataGridView_SelectionChanged);
            // 
            // supplyInPlanlabel
            // 
            this.supplyInPlanlabel.AutoSize = true;
            this.supplyInPlanlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyInPlanlabel.Location = new System.Drawing.Point(12, 5);
            this.supplyInPlanlabel.Name = "supplyInPlanlabel";
            this.supplyInPlanlabel.Size = new System.Drawing.Size(138, 20);
            this.supplyInPlanlabel.TabIndex = 30;
            this.supplyInPlanlabel.Text = "แผนประจำเดือนล่าสุด";
            // 
            // supplyInSelectedPRdataGridView
            // 
            this.supplyInSelectedPRdataGridView.AllowUserToAddRows = false;
            this.supplyInSelectedPRdataGridView.AllowUserToDeleteRows = false;
            this.supplyInSelectedPRdataGridView.AllowUserToResizeColumns = false;
            this.supplyInSelectedPRdataGridView.AllowUserToResizeRows = false;
            this.supplyInSelectedPRdataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.supplyInSelectedPRdataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.supplyInSelectedPRdataGridView.Location = new System.Drawing.Point(12, 358);
            this.supplyInSelectedPRdataGridView.MultiSelect = false;
            this.supplyInSelectedPRdataGridView.Name = "supplyInSelectedPRdataGridView";
            this.supplyInSelectedPRdataGridView.RowHeadersVisible = false;
            this.supplyInSelectedPRdataGridView.RowTemplate.Height = 24;
            this.supplyInSelectedPRdataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.supplyInSelectedPRdataGridView.ShowCellToolTips = false;
            this.supplyInSelectedPRdataGridView.Size = new System.Drawing.Size(1157, 411);
            this.supplyInSelectedPRdataGridView.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 335);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "รายการที่สั่งซื้อ";
            // 
            // deliverdateTimePicker
            // 
            this.deliverdateTimePicker.Location = new System.Drawing.Point(1175, 358);
            this.deliverdateTimePicker.Name = "deliverdateTimePicker";
            this.deliverdateTimePicker.Size = new System.Drawing.Size(199, 20);
            this.deliverdateTimePicker.TabIndex = 34;
            // 
            // deliverDatelabel
            // 
            this.deliverDatelabel.AutoSize = true;
            this.deliverDatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deliverDatelabel.Location = new System.Drawing.Point(1171, 333);
            this.deliverDatelabel.Name = "deliverDatelabel";
            this.deliverDatelabel.Size = new System.Drawing.Size(50, 20);
            this.deliverDatelabel.TabIndex = 35;
            this.deliverDatelabel.Text = "วันที่ส่ง";
            // 
            // attachInvoicebutton
            // 
            this.attachInvoicebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.attachInvoicebutton.Location = new System.Drawing.Point(1175, 420);
            this.attachInvoicebutton.Name = "attachInvoicebutton";
            this.attachInvoicebutton.Size = new System.Drawing.Size(123, 35);
            this.attachInvoicebutton.TabIndex = 36;
            this.attachInvoicebutton.Text = "แนบเอกสารส่งสินค้า";
            this.attachInvoicebutton.UseVisualStyleBackColor = true;
            this.attachInvoicebutton.Click += new System.EventHandler(this.attachInvoicebutton_Click);
            // 
            // invoicelinkLabel
            // 
            this.invoicelinkLabel.AutoSize = true;
            this.invoicelinkLabel.Location = new System.Drawing.Point(1317, 420);
            this.invoicelinkLabel.Name = "invoicelinkLabel";
            this.invoicelinkLabel.Size = new System.Drawing.Size(57, 13);
            this.invoicelinkLabel.TabIndex = 37;
            this.invoicelinkLabel.TabStop = true;
            this.invoicelinkLabel.Text = "ดูไฟล์แนบ";
            this.invoicelinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.invoicelinkLabel_LinkClicked);
            // 
            // createbutton
            // 
            this.createbutton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.createbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createbutton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.createbutton.Location = new System.Drawing.Point(1354, 713);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(98, 56);
            this.createbutton.TabIndex = 38;
            this.createbutton.Text = "บันทึกรายการส่ง";
            this.createbutton.UseVisualStyleBackColor = false;
            this.createbutton.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // SupplyArrivalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.createbutton);
            this.Controls.Add(this.invoicelinkLabel);
            this.Controls.Add(this.attachInvoicebutton);
            this.Controls.Add(this.deliverDatelabel);
            this.Controls.Add(this.deliverdateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.supplyInSelectedPRdataGridView);
            this.Controls.Add(this.supplyInPlanlabel);
            this.Controls.Add(this.supplyInPRArrivalLstdataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyArrivalForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตรวจรับวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.supplyInPRArrivalLstdataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplyInSelectedPRdataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView supplyInPRArrivalLstdataGridView;
        private System.Windows.Forms.Label supplyInPlanlabel;
        private System.Windows.Forms.DataGridView supplyInSelectedPRdataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker deliverdateTimePicker;
        private System.Windows.Forms.Label deliverDatelabel;
        private System.Windows.Forms.Button attachInvoicebutton;
        private System.Windows.Forms.LinkLabel invoicelinkLabel;
        private System.Windows.Forms.Button createbutton;
    }
}