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
            this.removeJobProcessingbutton = new System.Windows.Forms.Button();
            this.editJobProcessingButton = new System.Windows.Forms.Button();
            this.jobAcceptationButton = new System.Windows.Forms.Button();
            this.jobProcessingDatagridview = new System.Windows.Forms.DataGridView();
            this.jobProcessingLabel = new System.Windows.Forms.Label();
            this.removeJobButton = new System.Windows.Forms.Button();
            this.jobProcessingButton = new System.Windows.Forms.Button();
            this.jobCreatedDatagridview = new System.Windows.Forms.DataGridView();
            this.jobCreatedList = new System.Windows.Forms.Label();
            this.equipmentListButton = new System.Windows.Forms.Button();
            this.createJobButton = new System.Windows.Forms.Button();
            this.installationButton = new System.Windows.Forms.Button();
            this.maintainancePlanLabel = new System.Windows.Forms.Label();
            this.maintainancePlanGroupBox = new System.Windows.Forms.GroupBox();
            this.backToMainMenuButton = new System.Windows.Forms.Button();
            this.removePlanProcessButton = new System.Windows.Forms.Button();
            this.editPlanProcessButton = new System.Windows.Forms.Button();
            this.completeOrRomovePlanProcessButton = new System.Windows.Forms.Button();
            this.planProcessingDatagridview = new System.Windows.Forms.DataGridView();
            this.planProcessingLabel = new System.Windows.Forms.Label();
            this.planProcessingButton = new System.Windows.Forms.Button();
            this.currentMaintainencePlanDatagridview = new System.Windows.Forms.DataGridView();
            this.currentMaintainencePlanList = new System.Windows.Forms.Label();
            this.planHistoryButton = new System.Windows.Forms.Button();
            this.completeOrRemovePlanButton = new System.Windows.Forms.Button();
            this.editPlanButton = new System.Windows.Forms.Button();
            this.createPlanButton = new System.Windows.Forms.Button();
            this.equipmentControlGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobProcessingDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobCreatedDatagridview)).BeginInit();
            this.maintainancePlanGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planProcessingDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentMaintainencePlanDatagridview)).BeginInit();
            this.SuspendLayout();
            // 
            // equipmentControlLabel
            // 
            this.equipmentControlLabel.AutoSize = true;
            this.equipmentControlLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentControlLabel.Location = new System.Drawing.Point(6, 11);
            this.equipmentControlLabel.Name = "equipmentControlLabel";
            this.equipmentControlLabel.Size = new System.Drawing.Size(282, 31);
            this.equipmentControlLabel.TabIndex = 0;
            this.equipmentControlLabel.Text = "อุปกรณ์ และการแจ้งซ่อม";
            // 
            // equipmentControlGroupBox
            // 
            this.equipmentControlGroupBox.Controls.Add(this.removeJobProcessingbutton);
            this.equipmentControlGroupBox.Controls.Add(this.editJobProcessingButton);
            this.equipmentControlGroupBox.Controls.Add(this.jobAcceptationButton);
            this.equipmentControlGroupBox.Controls.Add(this.jobProcessingDatagridview);
            this.equipmentControlGroupBox.Controls.Add(this.jobProcessingLabel);
            this.equipmentControlGroupBox.Controls.Add(this.removeJobButton);
            this.equipmentControlGroupBox.Controls.Add(this.jobProcessingButton);
            this.equipmentControlGroupBox.Controls.Add(this.jobCreatedDatagridview);
            this.equipmentControlGroupBox.Controls.Add(this.jobCreatedList);
            this.equipmentControlGroupBox.Controls.Add(this.equipmentListButton);
            this.equipmentControlGroupBox.Controls.Add(this.createJobButton);
            this.equipmentControlGroupBox.Controls.Add(this.installationButton);
            this.equipmentControlGroupBox.Controls.Add(this.equipmentControlLabel);
            this.equipmentControlGroupBox.Location = new System.Drawing.Point(12, 5);
            this.equipmentControlGroupBox.Name = "equipmentControlGroupBox";
            this.equipmentControlGroupBox.Size = new System.Drawing.Size(708, 769);
            this.equipmentControlGroupBox.TabIndex = 1;
            this.equipmentControlGroupBox.TabStop = false;
            // 
            // removeJobProcessingbutton
            // 
            this.removeJobProcessingbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeJobProcessingbutton.Location = new System.Drawing.Point(290, 704);
            this.removeJobProcessingbutton.Name = "removeJobProcessingbutton";
            this.removeJobProcessingbutton.Size = new System.Drawing.Size(144, 52);
            this.removeJobProcessingbutton.TabIndex = 13;
            this.removeJobProcessingbutton.Text = "ลบงานแจ้งซ่อมที่กำลังดำเนินการ";
            this.removeJobProcessingbutton.UseVisualStyleBackColor = true;
            this.removeJobProcessingbutton.Click += new System.EventHandler(this.removeJobProcessingbutton_Click);
            // 
            // editJobProcessingButton
            // 
            this.editJobProcessingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editJobProcessingButton.Location = new System.Drawing.Point(140, 704);
            this.editJobProcessingButton.Name = "editJobProcessingButton";
            this.editJobProcessingButton.Size = new System.Drawing.Size(144, 52);
            this.editJobProcessingButton.TabIndex = 12;
            this.editJobProcessingButton.Text = "แก้ใขงานแจ้งซ่อมที่กำลังดำเนินการ";
            this.editJobProcessingButton.UseVisualStyleBackColor = true;
            this.editJobProcessingButton.Click += new System.EventHandler(this.editJobProcessingButton_Click);
            // 
            // jobAcceptationButton
            // 
            this.jobAcceptationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobAcceptationButton.Location = new System.Drawing.Point(13, 704);
            this.jobAcceptationButton.Name = "jobAcceptationButton";
            this.jobAcceptationButton.Size = new System.Drawing.Size(121, 52);
            this.jobAcceptationButton.TabIndex = 11;
            this.jobAcceptationButton.Text = "ตรวจรับงาน";
            this.jobAcceptationButton.UseVisualStyleBackColor = true;
            this.jobAcceptationButton.Click += new System.EventHandler(this.jobAcceptationButton_Click);
            // 
            // jobProcessingDatagridview
            // 
            this.jobProcessingDatagridview.AllowUserToAddRows = false;
            this.jobProcessingDatagridview.AllowUserToDeleteRows = false;
            this.jobProcessingDatagridview.AllowUserToResizeColumns = false;
            this.jobProcessingDatagridview.AllowUserToResizeRows = false;
            this.jobProcessingDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobProcessingDatagridview.Location = new System.Drawing.Point(6, 492);
            this.jobProcessingDatagridview.MultiSelect = false;
            this.jobProcessingDatagridview.Name = "jobProcessingDatagridview";
            this.jobProcessingDatagridview.ReadOnly = true;
            this.jobProcessingDatagridview.RowHeadersVisible = false;
            this.jobProcessingDatagridview.RowTemplate.Height = 24;
            this.jobProcessingDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jobProcessingDatagridview.Size = new System.Drawing.Size(696, 203);
            this.jobProcessingDatagridview.TabIndex = 10;
            this.jobProcessingDatagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.jobProcessingDatagridview_CellMouseEnter);
            this.jobProcessingDatagridview.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.jobProcessingDatagridview_CellMouseLeave);
            this.jobProcessingDatagridview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.jobProcessingDatagridview_RowPrePaint);
            // 
            // jobProcessingLabel
            // 
            this.jobProcessingLabel.AutoSize = true;
            this.jobProcessingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobProcessingLabel.Location = new System.Drawing.Point(9, 465);
            this.jobProcessingLabel.Name = "jobProcessingLabel";
            this.jobProcessingLabel.Size = new System.Drawing.Size(164, 18);
            this.jobProcessingLabel.TabIndex = 9;
            this.jobProcessingLabel.Text = "รายการงานที่กำลังดำเนินการ";
            // 
            // removeJobButton
            // 
            this.removeJobButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removeJobButton.Location = new System.Drawing.Point(140, 405);
            this.removeJobButton.Name = "removeJobButton";
            this.removeJobButton.Size = new System.Drawing.Size(121, 52);
            this.removeJobButton.TabIndex = 8;
            this.removeJobButton.Text = "ลบงานแจ้งซ่อม";
            this.removeJobButton.UseVisualStyleBackColor = true;
            this.removeJobButton.Click += new System.EventHandler(this.removeJobButton_Click);
            // 
            // jobProcessingButton
            // 
            this.jobProcessingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobProcessingButton.Location = new System.Drawing.Point(13, 405);
            this.jobProcessingButton.Name = "jobProcessingButton";
            this.jobProcessingButton.Size = new System.Drawing.Size(121, 52);
            this.jobProcessingButton.TabIndex = 7;
            this.jobProcessingButton.Text = "ดำเนินการงานแจ้งซ่อม";
            this.jobProcessingButton.UseVisualStyleBackColor = true;
            this.jobProcessingButton.Click += new System.EventHandler(this.jobProcessingButton_Click);
            // 
            // jobCreatedDatagridview
            // 
            this.jobCreatedDatagridview.AllowUserToAddRows = false;
            this.jobCreatedDatagridview.AllowUserToDeleteRows = false;
            this.jobCreatedDatagridview.AllowUserToResizeColumns = false;
            this.jobCreatedDatagridview.AllowUserToResizeRows = false;
            this.jobCreatedDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.jobCreatedDatagridview.Location = new System.Drawing.Point(6, 137);
            this.jobCreatedDatagridview.MultiSelect = false;
            this.jobCreatedDatagridview.Name = "jobCreatedDatagridview";
            this.jobCreatedDatagridview.ReadOnly = true;
            this.jobCreatedDatagridview.RowHeadersVisible = false;
            this.jobCreatedDatagridview.RowTemplate.Height = 24;
            this.jobCreatedDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.jobCreatedDatagridview.Size = new System.Drawing.Size(696, 262);
            this.jobCreatedDatagridview.TabIndex = 6;
            this.jobCreatedDatagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.jobCreatedDatagridview_CellMouseEnter);
            this.jobCreatedDatagridview.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.jobCreatedDatagridview_CellMouseLeave);
            this.jobCreatedDatagridview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.jobCreatedDatagridview_RowPrePaint);
            // 
            // jobCreatedList
            // 
            this.jobCreatedList.AutoSize = true;
            this.jobCreatedList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.jobCreatedList.Location = new System.Drawing.Point(9, 110);
            this.jobCreatedList.Name = "jobCreatedList";
            this.jobCreatedList.Size = new System.Drawing.Size(179, 18);
            this.jobCreatedList.TabIndex = 5;
            this.jobCreatedList.Text = "รายการแจ้งซ่อมที่รอดำเนินการ";
            // 
            // equipmentListButton
            // 
            this.equipmentListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipmentListButton.Location = new System.Drawing.Point(186, 55);
            this.equipmentListButton.Name = "equipmentListButton";
            this.equipmentListButton.Size = new System.Drawing.Size(187, 52);
            this.equipmentListButton.TabIndex = 3;
            this.equipmentListButton.Text = "รายการอุปกรณ์ทั้งหมด";
            this.equipmentListButton.UseVisualStyleBackColor = true;
            this.equipmentListButton.Click += new System.EventHandler(this.equipmentListButton_Click);
            // 
            // createJobButton
            // 
            this.createJobButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createJobButton.Location = new System.Drawing.Point(94, 55);
            this.createJobButton.Name = "createJobButton";
            this.createJobButton.Size = new System.Drawing.Size(86, 52);
            this.createJobButton.TabIndex = 2;
            this.createJobButton.Text = "แจ้งซ่อม";
            this.createJobButton.UseVisualStyleBackColor = true;
            this.createJobButton.Click += new System.EventHandler(this.createJobButton_Click);
            // 
            // installationButton
            // 
            this.installationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installationButton.Location = new System.Drawing.Point(13, 55);
            this.installationButton.Name = "installationButton";
            this.installationButton.Size = new System.Drawing.Size(75, 52);
            this.installationButton.TabIndex = 1;
            this.installationButton.Text = "ติดตั้ง";
            this.installationButton.UseVisualStyleBackColor = true;
            this.installationButton.Click += new System.EventHandler(this.installationButton_Click);
            // 
            // maintainancePlanLabel
            // 
            this.maintainancePlanLabel.AutoSize = true;
            this.maintainancePlanLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maintainancePlanLabel.Location = new System.Drawing.Point(6, 11);
            this.maintainancePlanLabel.Name = "maintainancePlanLabel";
            this.maintainancePlanLabel.Size = new System.Drawing.Size(168, 31);
            this.maintainancePlanLabel.TabIndex = 0;
            this.maintainancePlanLabel.Text = "แผนซ่อมบำรุง";
            // 
            // maintainancePlanGroupBox
            // 
            this.maintainancePlanGroupBox.Controls.Add(this.backToMainMenuButton);
            this.maintainancePlanGroupBox.Controls.Add(this.removePlanProcessButton);
            this.maintainancePlanGroupBox.Controls.Add(this.editPlanProcessButton);
            this.maintainancePlanGroupBox.Controls.Add(this.completeOrRomovePlanProcessButton);
            this.maintainancePlanGroupBox.Controls.Add(this.planProcessingDatagridview);
            this.maintainancePlanGroupBox.Controls.Add(this.planProcessingLabel);
            this.maintainancePlanGroupBox.Controls.Add(this.planProcessingButton);
            this.maintainancePlanGroupBox.Controls.Add(this.currentMaintainencePlanDatagridview);
            this.maintainancePlanGroupBox.Controls.Add(this.currentMaintainencePlanList);
            this.maintainancePlanGroupBox.Controls.Add(this.planHistoryButton);
            this.maintainancePlanGroupBox.Controls.Add(this.completeOrRemovePlanButton);
            this.maintainancePlanGroupBox.Controls.Add(this.editPlanButton);
            this.maintainancePlanGroupBox.Controls.Add(this.createPlanButton);
            this.maintainancePlanGroupBox.Controls.Add(this.maintainancePlanLabel);
            this.maintainancePlanGroupBox.Location = new System.Drawing.Point(734, 5);
            this.maintainancePlanGroupBox.Name = "maintainancePlanGroupBox";
            this.maintainancePlanGroupBox.Size = new System.Drawing.Size(708, 769);
            this.maintainancePlanGroupBox.TabIndex = 2;
            this.maintainancePlanGroupBox.TabStop = false;
            // 
            // backToMainMenuButton
            // 
            this.backToMainMenuButton.BackColor = System.Drawing.SystemColors.Info;
            this.backToMainMenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backToMainMenuButton.Location = new System.Drawing.Point(437, 704);
            this.backToMainMenuButton.Name = "backToMainMenuButton";
            this.backToMainMenuButton.Size = new System.Drawing.Size(121, 52);
            this.backToMainMenuButton.TabIndex = 19;
            this.backToMainMenuButton.Text = "กลับสู่หน้าหลัก";
            this.backToMainMenuButton.UseVisualStyleBackColor = false;
            this.backToMainMenuButton.Click += new System.EventHandler(this.backToMainMenuButton_Click);
            // 
            // removePlanProcessButton
            // 
            this.removePlanProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.removePlanProcessButton.Location = new System.Drawing.Point(264, 704);
            this.removePlanProcessButton.Name = "removePlanProcessButton";
            this.removePlanProcessButton.Size = new System.Drawing.Size(121, 52);
            this.removePlanProcessButton.TabIndex = 18;
            this.removePlanProcessButton.Text = "ยกเลิกการซ่อมบำรุง";
            this.removePlanProcessButton.UseVisualStyleBackColor = true;
            this.removePlanProcessButton.Click += new System.EventHandler(this.removePlanProcessButton_Click);
            // 
            // editPlanProcessButton
            // 
            this.editPlanProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPlanProcessButton.Location = new System.Drawing.Point(137, 704);
            this.editPlanProcessButton.Name = "editPlanProcessButton";
            this.editPlanProcessButton.Size = new System.Drawing.Size(121, 52);
            this.editPlanProcessButton.TabIndex = 17;
            this.editPlanProcessButton.Text = "แก้ใขแผนที่กำลังดำเนินการ";
            this.editPlanProcessButton.UseVisualStyleBackColor = true;
            this.editPlanProcessButton.Click += new System.EventHandler(this.editPlanProcessButton_Click);
            // 
            // completeOrRomovePlanProcessButton
            // 
            this.completeOrRomovePlanProcessButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeOrRomovePlanProcessButton.Location = new System.Drawing.Point(10, 704);
            this.completeOrRomovePlanProcessButton.Name = "completeOrRomovePlanProcessButton";
            this.completeOrRomovePlanProcessButton.Size = new System.Drawing.Size(121, 52);
            this.completeOrRomovePlanProcessButton.TabIndex = 13;
            this.completeOrRomovePlanProcessButton.Text = "ตรวจรับการซ่อมบำรุง";
            this.completeOrRomovePlanProcessButton.UseVisualStyleBackColor = true;
            this.completeOrRomovePlanProcessButton.Click += new System.EventHandler(this.completeOrRomovePlanProcessButton_Click);
            // 
            // planProcessingDatagridview
            // 
            this.planProcessingDatagridview.AllowUserToAddRows = false;
            this.planProcessingDatagridview.AllowUserToDeleteRows = false;
            this.planProcessingDatagridview.AllowUserToResizeColumns = false;
            this.planProcessingDatagridview.AllowUserToResizeRows = false;
            this.planProcessingDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.planProcessingDatagridview.Location = new System.Drawing.Point(5, 492);
            this.planProcessingDatagridview.MultiSelect = false;
            this.planProcessingDatagridview.Name = "planProcessingDatagridview";
            this.planProcessingDatagridview.ReadOnly = true;
            this.planProcessingDatagridview.RowHeadersVisible = false;
            this.planProcessingDatagridview.RowTemplate.Height = 24;
            this.planProcessingDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.planProcessingDatagridview.Size = new System.Drawing.Size(697, 203);
            this.planProcessingDatagridview.TabIndex = 13;
            this.planProcessingDatagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.planProcessingDatagridview_CellMouseEnter);
            this.planProcessingDatagridview.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.planProcessingDatagridview_CellMouseLeave);
            this.planProcessingDatagridview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.planProcessingDatagridview_RowPrePaint);
            // 
            // planProcessingLabel
            // 
            this.planProcessingLabel.AutoSize = true;
            this.planProcessingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planProcessingLabel.Location = new System.Drawing.Point(9, 465);
            this.planProcessingLabel.Name = "planProcessingLabel";
            this.planProcessingLabel.Size = new System.Drawing.Size(191, 18);
            this.planProcessingLabel.TabIndex = 13;
            this.planProcessingLabel.Text = "อุปกรณ์ที่กำลังซ่อมบำรุงตามแผน";
            // 
            // planProcessingButton
            // 
            this.planProcessingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planProcessingButton.Location = new System.Drawing.Point(10, 405);
            this.planProcessingButton.Name = "planProcessingButton";
            this.planProcessingButton.Size = new System.Drawing.Size(121, 52);
            this.planProcessingButton.TabIndex = 13;
            this.planProcessingButton.Text = "ดำเนินการตามแผน";
            this.planProcessingButton.UseVisualStyleBackColor = true;
            this.planProcessingButton.Click += new System.EventHandler(this.planProcessingButton_Click);
            // 
            // currentMaintainencePlanDatagridview
            // 
            this.currentMaintainencePlanDatagridview.AllowUserToAddRows = false;
            this.currentMaintainencePlanDatagridview.AllowUserToDeleteRows = false;
            this.currentMaintainencePlanDatagridview.AllowUserToResizeColumns = false;
            this.currentMaintainencePlanDatagridview.AllowUserToResizeRows = false;
            this.currentMaintainencePlanDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currentMaintainencePlanDatagridview.Location = new System.Drawing.Point(5, 137);
            this.currentMaintainencePlanDatagridview.MultiSelect = false;
            this.currentMaintainencePlanDatagridview.Name = "currentMaintainencePlanDatagridview";
            this.currentMaintainencePlanDatagridview.ReadOnly = true;
            this.currentMaintainencePlanDatagridview.RowHeadersVisible = false;
            this.currentMaintainencePlanDatagridview.RowTemplate.Height = 24;
            this.currentMaintainencePlanDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.currentMaintainencePlanDatagridview.Size = new System.Drawing.Size(697, 262);
            this.currentMaintainencePlanDatagridview.TabIndex = 13;
            this.currentMaintainencePlanDatagridview.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.currentMaintainencePlanDatagridview_CellMouseEnter);
            this.currentMaintainencePlanDatagridview.CellMouseLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.currentMaintainencePlanDatagridview_CellMouseLeave);
            this.currentMaintainencePlanDatagridview.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.currentMaintainencePlanDatagridview_RowPrePaint);
            // 
            // currentMaintainencePlanList
            // 
            this.currentMaintainencePlanList.AutoSize = true;
            this.currentMaintainencePlanList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMaintainencePlanList.Location = new System.Drawing.Point(6, 110);
            this.currentMaintainencePlanList.Name = "currentMaintainencePlanList";
            this.currentMaintainencePlanList.Size = new System.Drawing.Size(171, 18);
            this.currentMaintainencePlanList.TabIndex = 13;
            this.currentMaintainencePlanList.Text = "รายการแผนซ่อมบำรุงปัจจุบัน";
            // 
            // planHistoryButton
            // 
            this.planHistoryButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.planHistoryButton.Location = new System.Drawing.Point(168, 55);
            this.planHistoryButton.Name = "planHistoryButton";
            this.planHistoryButton.Size = new System.Drawing.Size(124, 52);
            this.planHistoryButton.TabIndex = 16;
            this.planHistoryButton.Text = "ประวัติแผนทั้งหมด";
            this.planHistoryButton.UseVisualStyleBackColor = true;
            this.planHistoryButton.Click += new System.EventHandler(this.planHistoryButton_Click);
            // 
            // completeOrRemovePlanButton
            // 
            this.completeOrRemovePlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.completeOrRemovePlanButton.Location = new System.Drawing.Point(137, 405);
            this.completeOrRemovePlanButton.Name = "completeOrRemovePlanButton";
            this.completeOrRemovePlanButton.Size = new System.Drawing.Size(124, 52);
            this.completeOrRemovePlanButton.TabIndex = 15;
            this.completeOrRemovePlanButton.Text = "สิ้นสุด / ลบแผน";
            this.completeOrRemovePlanButton.UseVisualStyleBackColor = true;
            this.completeOrRemovePlanButton.Click += new System.EventHandler(this.completeOrRemovePlanButton_Click);
            // 
            // editPlanButton
            // 
            this.editPlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.editPlanButton.Location = new System.Drawing.Point(87, 55);
            this.editPlanButton.Name = "editPlanButton";
            this.editPlanButton.Size = new System.Drawing.Size(75, 52);
            this.editPlanButton.TabIndex = 14;
            this.editPlanButton.Text = "ปรับปรุงแผน";
            this.editPlanButton.UseVisualStyleBackColor = true;
            this.editPlanButton.Click += new System.EventHandler(this.editPlanButton_Click);
            // 
            // createPlanButton
            // 
            this.createPlanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createPlanButton.Location = new System.Drawing.Point(6, 55);
            this.createPlanButton.Name = "createPlanButton";
            this.createPlanButton.Size = new System.Drawing.Size(75, 52);
            this.createPlanButton.TabIndex = 13;
            this.createPlanButton.Text = "สร้างแผน";
            this.createPlanButton.UseVisualStyleBackColor = true;
            this.createPlanButton.Click += new System.EventHandler(this.createPlanButton_Click);
            // 
            // EquipmentAndMaintainenceControlForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1450, 780);
            this.ControlBox = false;
            this.Controls.Add(this.maintainancePlanGroupBox);
            this.Controls.Add(this.equipmentControlGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EquipmentAndMaintainenceControlForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.EquipmentAndMaintainenceControlForm_Load);
            this.equipmentControlGroupBox.ResumeLayout(false);
            this.equipmentControlGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.jobProcessingDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.jobCreatedDatagridview)).EndInit();
            this.maintainancePlanGroupBox.ResumeLayout(false);
            this.maintainancePlanGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planProcessingDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentMaintainencePlanDatagridview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label equipmentControlLabel;
        private System.Windows.Forms.GroupBox equipmentControlGroupBox;
        private System.Windows.Forms.Label maintainancePlanLabel;
        private System.Windows.Forms.GroupBox maintainancePlanGroupBox;
        private System.Windows.Forms.Button createJobButton;
        private System.Windows.Forms.Button installationButton;
        private System.Windows.Forms.Button equipmentListButton;
        private System.Windows.Forms.Label jobCreatedList;
        private System.Windows.Forms.DataGridView jobCreatedDatagridview;
        private System.Windows.Forms.Button jobProcessingButton;
        private System.Windows.Forms.Label jobProcessingLabel;
        private System.Windows.Forms.Button removeJobButton;
        private System.Windows.Forms.DataGridView jobProcessingDatagridview;
        private System.Windows.Forms.Button jobAcceptationButton;
        private System.Windows.Forms.Button editJobProcessingButton;
        private System.Windows.Forms.Button createPlanButton;
        private System.Windows.Forms.Label currentMaintainencePlanList;
        private System.Windows.Forms.Button planHistoryButton;
        private System.Windows.Forms.Button completeOrRemovePlanButton;
        private System.Windows.Forms.Button editPlanButton;
        private System.Windows.Forms.Button removePlanProcessButton;
        private System.Windows.Forms.Button editPlanProcessButton;
        private System.Windows.Forms.Button completeOrRomovePlanProcessButton;
        private System.Windows.Forms.DataGridView planProcessingDatagridview;
        private System.Windows.Forms.Label planProcessingLabel;
        private System.Windows.Forms.Button planProcessingButton;
        private System.Windows.Forms.DataGridView currentMaintainencePlanDatagridview;
        private System.Windows.Forms.Button backToMainMenuButton;
        private System.Windows.Forms.Button removeJobProcessingbutton;
    }
}