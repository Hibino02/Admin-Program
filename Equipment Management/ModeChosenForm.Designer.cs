﻿namespace Admin_Program.UIClass
{
    partial class ModeChosenForm
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
            this.equipmentControlButton = new System.Windows.Forms.Button();
            this.supplyControlButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // equipmentControlButton
            // 
            this.equipmentControlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentControlButton.Location = new System.Drawing.Point(10, 33);
            this.equipmentControlButton.Name = "equipmentControlButton";
            this.equipmentControlButton.Size = new System.Drawing.Size(378, 537);
            this.equipmentControlButton.TabIndex = 0;
            this.equipmentControlButton.Text = "โปรแกรมจัดการอุปกรณ์,แจ้งซ่อม และแผนซ่อมบำรุง";
            this.equipmentControlButton.UseVisualStyleBackColor = true;
            this.equipmentControlButton.Click += new System.EventHandler(this.equipmentControlButton_Click);
            // 
            // supplyControlButton
            // 
            this.supplyControlButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.supplyControlButton.Location = new System.Drawing.Point(425, 33);
            this.supplyControlButton.Name = "supplyControlButton";
            this.supplyControlButton.Size = new System.Drawing.Size(378, 537);
            this.supplyControlButton.TabIndex = 1;
            this.supplyControlButton.Text = "โปรแกรมจัดการวัสดุสิ้นเปลือง";
            this.supplyControlButton.UseVisualStyleBackColor = true;
            this.supplyControlButton.Click += new System.EventHandler(this.supplyControlButton_Click);
            // 
            // ModeChosenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(829, 618);
            this.ControlBox = false;
            this.Controls.Add(this.supplyControlButton);
            this.Controls.Add(this.equipmentControlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModeChosenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ModeChosenForm";
            this.Load += new System.EventHandler(this.ModeChosenForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button equipmentControlButton;
        private System.Windows.Forms.Button supplyControlButton;
    }
}