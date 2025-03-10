﻿namespace Admin_Program.SupplyManagement.UIClass.SupplyDeliveryPlan
{
    partial class AllSupplyDiliveryListForm
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
            this.planNameSearchLabel = new System.Windows.Forms.Label();
            this.removeButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.CreateSupplyButton = new System.Windows.Forms.Button();
            this.planDatagridview = new System.Windows.Forms.DataGridView();
            this.planNameSearchtextBox = new System.Windows.Forms.TextBox();
            this.selectPlanSupplydataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.excelbutton = new System.Windows.Forms.Button();
            this.finbutton = new System.Windows.Forms.Button();
            this.clearPlanbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.planDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectPlanSupplydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // planNameSearchLabel
            // 
            this.planNameSearchLabel.AutoSize = true;
            this.planNameSearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.planNameSearchLabel.Location = new System.Drawing.Point(11, 11);
            this.planNameSearchLabel.Name = "planNameSearchLabel";
            this.planNameSearchLabel.Size = new System.Drawing.Size(111, 20);
            this.planNameSearchLabel.TabIndex = 29;
            this.planNameSearchLabel.Text = "ค้นหาแผนจากชื่อ";
            // 
            // removeButton
            // 
            this.removeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeButton.Location = new System.Drawing.Point(742, 4);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(124, 31);
            this.removeButton.TabIndex = 28;
            this.removeButton.Text = "ลบแผน";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackColor = System.Drawing.SystemColors.Info;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editButton.Location = new System.Drawing.Point(1328, 3);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(124, 31);
            this.editButton.TabIndex = 27;
            this.editButton.Text = "ปรับปรุง";
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // CreateSupplyButton
            // 
            this.CreateSupplyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateSupplyButton.Location = new System.Drawing.Point(612, 4);
            this.CreateSupplyButton.Name = "CreateSupplyButton";
            this.CreateSupplyButton.Size = new System.Drawing.Size(124, 31);
            this.CreateSupplyButton.TabIndex = 26;
            this.CreateSupplyButton.Text = "สร้างแผน";
            this.CreateSupplyButton.UseVisualStyleBackColor = true;
            this.CreateSupplyButton.Click += new System.EventHandler(this.CreateSupplyButton_Click);
            // 
            // planDatagridview
            // 
            this.planDatagridview.AllowUserToAddRows = false;
            this.planDatagridview.AllowUserToDeleteRows = false;
            this.planDatagridview.AllowUserToResizeColumns = false;
            this.planDatagridview.AllowUserToResizeRows = false;
            this.planDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.planDatagridview.Location = new System.Drawing.Point(14, 40);
            this.planDatagridview.MultiSelect = false;
            this.planDatagridview.Name = "planDatagridview";
            this.planDatagridview.ReadOnly = true;
            this.planDatagridview.RowHeadersVisible = false;
            this.planDatagridview.RowTemplate.Height = 24;
            this.planDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.planDatagridview.Size = new System.Drawing.Size(326, 543);
            this.planDatagridview.TabIndex = 25;
            this.planDatagridview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.planDatagridview_CellClick);
            this.planDatagridview.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.planDatagridview_DataBindingComplete);
            // 
            // planNameSearchtextBox
            // 
            this.planNameSearchtextBox.Location = new System.Drawing.Point(128, 11);
            this.planNameSearchtextBox.Name = "planNameSearchtextBox";
            this.planNameSearchtextBox.Size = new System.Drawing.Size(278, 20);
            this.planNameSearchtextBox.TabIndex = 30;
            // 
            // selectPlanSupplydataGridView
            // 
            this.selectPlanSupplydataGridView.AllowUserToAddRows = false;
            this.selectPlanSupplydataGridView.AllowUserToDeleteRows = false;
            this.selectPlanSupplydataGridView.AllowUserToResizeColumns = false;
            this.selectPlanSupplydataGridView.AllowUserToResizeRows = false;
            this.selectPlanSupplydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.selectPlanSupplydataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.selectPlanSupplydataGridView.Location = new System.Drawing.Point(346, 40);
            this.selectPlanSupplydataGridView.MultiSelect = false;
            this.selectPlanSupplydataGridView.Name = "selectPlanSupplydataGridView";
            this.selectPlanSupplydataGridView.RowHeadersVisible = false;
            this.selectPlanSupplydataGridView.RowTemplate.Height = 24;
            this.selectPlanSupplydataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.selectPlanSupplydataGridView.Size = new System.Drawing.Size(1106, 543);
            this.selectPlanSupplydataGridView.TabIndex = 31;
            this.selectPlanSupplydataGridView.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.selectPlanSupplydataGridView_CellFormatting);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(412, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 20);
            this.label1.TabIndex = 32;
            this.label1.Text = "รายการวัสดุและปริมาณคงเหลือ";
            // 
            // excelbutton
            // 
            this.excelbutton.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.excelbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.excelbutton.Location = new System.Drawing.Point(1198, 3);
            this.excelbutton.Name = "excelbutton";
            this.excelbutton.Size = new System.Drawing.Size(124, 31);
            this.excelbutton.TabIndex = 33;
            this.excelbutton.Text = "Export";
            this.excelbutton.UseVisualStyleBackColor = false;
            this.excelbutton.Click += new System.EventHandler(this.excelbutton_Click);
            // 
            // finbutton
            // 
            this.finbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finbutton.Location = new System.Drawing.Point(872, 4);
            this.finbutton.Name = "finbutton";
            this.finbutton.Size = new System.Drawing.Size(124, 31);
            this.finbutton.TabIndex = 34;
            this.finbutton.Text = "สิ้นสุดแผน";
            this.finbutton.UseVisualStyleBackColor = true;
            this.finbutton.Click += new System.EventHandler(this.finbutton_Click);
            // 
            // clearPlanbutton
            // 
            this.clearPlanbutton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.clearPlanbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clearPlanbutton.Location = new System.Drawing.Point(1068, 3);
            this.clearPlanbutton.Name = "clearPlanbutton";
            this.clearPlanbutton.Size = new System.Drawing.Size(124, 31);
            this.clearPlanbutton.TabIndex = 35;
            this.clearPlanbutton.Text = "ล้างแผนที่เลือก";
            this.clearPlanbutton.UseVisualStyleBackColor = false;
            this.clearPlanbutton.Click += new System.EventHandler(this.clearPlanbutton_Click);
            // 
            // AllSupplyDiliveryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 595);
            this.Controls.Add(this.clearPlanbutton);
            this.Controls.Add(this.finbutton);
            this.Controls.Add(this.excelbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectPlanSupplydataGridView);
            this.Controls.Add(this.planNameSearchtextBox);
            this.Controls.Add(this.planNameSearchLabel);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.CreateSupplyButton);
            this.Controls.Add(this.planDatagridview);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AllSupplyDiliveryListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "รายการแผนวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.planDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.selectPlanSupplydataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label planNameSearchLabel;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button CreateSupplyButton;
        private System.Windows.Forms.DataGridView planDatagridview;
        private System.Windows.Forms.TextBox planNameSearchtextBox;
        private System.Windows.Forms.DataGridView selectPlanSupplydataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button excelbutton;
        private System.Windows.Forms.Button finbutton;
        private System.Windows.Forms.Button clearPlanbutton;
    }
}