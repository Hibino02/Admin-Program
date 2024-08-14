namespace Equipment_Management.UIClass.Job
{
    partial class JobHistory
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
            this.enLabel = new System.Windows.Forms.Label();
            this.esLabel = new System.Windows.Forms.Label();
            this.eNameLabel = new System.Windows.Forms.Label();
            this.eplabel = new System.Windows.Forms.Label();
            this.ePlaceLabel = new System.Windows.Forms.Label();
            this.eSerialLabel = new System.Windows.Forms.Label();
            this.equipmentPictureBox = new System.Windows.Forms.PictureBox();
            this.historyListlabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.equipmentPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // enLabel
            // 
            this.enLabel.AutoSize = true;
            this.enLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enLabel.Location = new System.Drawing.Point(33, 9);
            this.enLabel.Name = "enLabel";
            this.enLabel.Size = new System.Drawing.Size(76, 25);
            this.enLabel.TabIndex = 0;
            this.enLabel.Text = "ชื่อเรียก :";
            // 
            // esLabel
            // 
            this.esLabel.AutoSize = true;
            this.esLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.esLabel.Location = new System.Drawing.Point(3, 45);
            this.esLabel.Name = "esLabel";
            this.esLabel.Size = new System.Drawing.Size(106, 25);
            this.esLabel.TabIndex = 1;
            this.esLabel.Text = "ชื่อทางบัญชี :";
            // 
            // eNameLabel
            // 
            this.eNameLabel.AutoSize = true;
            this.eNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eNameLabel.Location = new System.Drawing.Point(113, 9);
            this.eNameLabel.Name = "eNameLabel";
            this.eNameLabel.Size = new System.Drawing.Size(53, 25);
            this.eNameLabel.TabIndex = 2;
            this.eNameLabel.Text = "label";
            // 
            // eplabel
            // 
            this.eplabel.AutoSize = true;
            this.eplabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eplabel.Location = new System.Drawing.Point(3, 84);
            this.eplabel.Name = "eplabel";
            this.eplabel.Size = new System.Drawing.Size(174, 25);
            this.eplabel.TabIndex = 4;
            this.eplabel.Text = "รายละเอียดจุดที่ติดตั้ง :";
            // 
            // ePlaceLabel
            // 
            this.ePlaceLabel.AutoSize = true;
            this.ePlaceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ePlaceLabel.Location = new System.Drawing.Point(174, 84);
            this.ePlaceLabel.Name = "ePlaceLabel";
            this.ePlaceLabel.Size = new System.Drawing.Size(53, 25);
            this.ePlaceLabel.TabIndex = 5;
            this.ePlaceLabel.Text = "label";
            // 
            // eSerialLabel
            // 
            this.eSerialLabel.AutoSize = true;
            this.eSerialLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eSerialLabel.Location = new System.Drawing.Point(113, 45);
            this.eSerialLabel.Name = "eSerialLabel";
            this.eSerialLabel.Size = new System.Drawing.Size(53, 25);
            this.eSerialLabel.TabIndex = 6;
            this.eSerialLabel.Text = "label";
            // 
            // equipmentPictureBox
            // 
            this.equipmentPictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.equipmentPictureBox.Location = new System.Drawing.Point(7, 127);
            this.equipmentPictureBox.Name = "equipmentPictureBox";
            this.equipmentPictureBox.Size = new System.Drawing.Size(637, 638);
            this.equipmentPictureBox.TabIndex = 7;
            this.equipmentPictureBox.TabStop = false;
            // 
            // historyListlabel
            // 
            this.historyListlabel.AutoSize = true;
            this.historyListlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyListlabel.Location = new System.Drawing.Point(645, 13);
            this.historyListlabel.Name = "historyListlabel";
            this.historyListlabel.Size = new System.Drawing.Size(180, 25);
            this.historyListlabel.TabIndex = 8;
            this.historyListlabel.Text = "รายการประวัติแจ้งซ่อม :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(650, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(800, 719);
            this.dataGridView1.TabIndex = 9;
            // 
            // JobHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1462, 773);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.historyListlabel);
            this.Controls.Add(this.equipmentPictureBox);
            this.Controls.Add(this.eSerialLabel);
            this.Controls.Add(this.ePlaceLabel);
            this.Controls.Add(this.eplabel);
            this.Controls.Add(this.eNameLabel);
            this.Controls.Add(this.esLabel);
            this.Controls.Add(this.enLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "JobHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ประวัติงานแจ้งซ่อมรายอุปกรณ์";
            ((System.ComponentModel.ISupportInitialize)(this.equipmentPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label enLabel;
        private System.Windows.Forms.Label esLabel;
        private System.Windows.Forms.Label eNameLabel;
        private System.Windows.Forms.Label eplabel;
        private System.Windows.Forms.Label ePlaceLabel;
        private System.Windows.Forms.Label eSerialLabel;
        private System.Windows.Forms.PictureBox equipmentPictureBox;
        private System.Windows.Forms.Label historyListlabel;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}