namespace Equipment_Management.UIClass
{
    partial class EquipmentAndMaintainenceControlForm
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
            this.equipmentControlLabel = new System.Windows.Forms.Label();
            this.equipmentControlGroupBox = new System.Windows.Forms.GroupBox();
            this.maintainancePlanLabel = new System.Windows.Forms.Label();
            this.maintainancePlanGroupBox = new System.Windows.Forms.GroupBox();
            this.equipmentControlGroupBox.SuspendLayout();
            this.maintainancePlanGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // equipmentControlLabel
            // 
            this.equipmentControlLabel.AutoSize = true;
            this.equipmentControlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentControlLabel.Location = new System.Drawing.Point(6, 16);
            this.equipmentControlLabel.Name = "equipmentControlLabel";
            this.equipmentControlLabel.Size = new System.Drawing.Size(406, 31);
            this.equipmentControlLabel.TabIndex = 0;
            this.equipmentControlLabel.Text = "แผงควบคุมอุปกรณ์ และการแจ้งซ่อม";
            // 
            // equipmentControlGroupBox
            // 
            this.equipmentControlGroupBox.Controls.Add(this.equipmentControlLabel);
            this.equipmentControlGroupBox.Location = new System.Drawing.Point(3, -1);
            this.equipmentControlGroupBox.Name = "equipmentControlGroupBox";
            this.equipmentControlGroupBox.Size = new System.Drawing.Size(607, 775);
            this.equipmentControlGroupBox.TabIndex = 1;
            this.equipmentControlGroupBox.TabStop = false;
            // 
            // maintainancePlanLabel
            // 
            this.maintainancePlanLabel.AutoSize = true;
            this.maintainancePlanLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintainancePlanLabel.Location = new System.Drawing.Point(6, 16);
            this.maintainancePlanLabel.Name = "maintainancePlanLabel";
            this.maintainancePlanLabel.Size = new System.Drawing.Size(292, 31);
            this.maintainancePlanLabel.TabIndex = 0;
            this.maintainancePlanLabel.Text = "แผงควบคุมแผนซ่อมบำรุง";
            // 
            // maintainancePlanGroupBox
            // 
            this.maintainancePlanGroupBox.Controls.Add(this.maintainancePlanLabel);
            this.maintainancePlanGroupBox.Location = new System.Drawing.Point(616, -2);
            this.maintainancePlanGroupBox.Name = "maintainancePlanGroupBox";
            this.maintainancePlanGroupBox.Size = new System.Drawing.Size(607, 775);
            this.maintainancePlanGroupBox.TabIndex = 2;
            this.maintainancePlanGroupBox.TabStop = false;
            // 
            // EquipmentAndMaintainenceControlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1226, 776);
            this.ControlBox = false;
            this.Controls.Add(this.maintainancePlanGroupBox);
            this.Controls.Add(this.equipmentControlGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentAndMaintainenceControlForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.EquipmentAndMaintainenceControlForm_Load);
            this.equipmentControlGroupBox.ResumeLayout(false);
            this.equipmentControlGroupBox.PerformLayout();
            this.maintainancePlanGroupBox.ResumeLayout(false);
            this.maintainancePlanGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label equipmentControlLabel;
        private System.Windows.Forms.GroupBox equipmentControlGroupBox;
        private System.Windows.Forms.Label maintainancePlanLabel;
        private System.Windows.Forms.GroupBox maintainancePlanGroupBox;
    }
}