namespace Admin_Program.SupplyManagement.UIClass.SupplyDeliveryPlan
{
    partial class CreateSupplyDeliveryPlanForm
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
            this.monthSelectopnlabel = new System.Windows.Forms.Label();
            this.monthSelectioncomboBox = new System.Windows.Forms.ComboBox();
            this.planNamelabel = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SupplierDatagridview = new System.Windows.Forms.DataGridView();
            this.addToSupplyInPRbutton = new System.Windows.Forms.Button();
            this.removeFromSupplyInPRbutton = new System.Windows.Forms.Button();
            this.supplyTypecomboBox = new System.Windows.Forms.ComboBox();
            this.supplySelectionlabel = new System.Windows.Forms.Label();
            this.supplySearchtextBox = new System.Windows.Forms.TextBox();
            this.supplyNamelabel = new System.Windows.Forms.Label();
            this.selectedSupplylabel = new System.Windows.Forms.Label();
            this.allSupplylabel = new System.Windows.Forms.Label();
            this.allSupplydataGridView = new System.Windows.Forms.DataGridView();
            this.createPRbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDatagridview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSupplydataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // monthSelectopnlabel
            // 
            this.monthSelectopnlabel.AutoSize = true;
            this.monthSelectopnlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.monthSelectopnlabel.Location = new System.Drawing.Point(12, 12);
            this.monthSelectopnlabel.Name = "monthSelectopnlabel";
            this.monthSelectopnlabel.Size = new System.Drawing.Size(107, 18);
            this.monthSelectopnlabel.TabIndex = 0;
            this.monthSelectopnlabel.Text = "แผนประจำเดือน :";
            // 
            // monthSelectioncomboBox
            // 
            this.monthSelectioncomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.monthSelectioncomboBox.FormattingEnabled = true;
            this.monthSelectioncomboBox.Location = new System.Drawing.Point(125, 9);
            this.monthSelectioncomboBox.Name = "monthSelectioncomboBox";
            this.monthSelectioncomboBox.Size = new System.Drawing.Size(123, 26);
            this.monthSelectioncomboBox.TabIndex = 1;
            // 
            // planNamelabel
            // 
            this.planNamelabel.AutoSize = true;
            this.planNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.planNamelabel.Location = new System.Drawing.Point(256, 12);
            this.planNamelabel.Name = "planNamelabel";
            this.planNamelabel.Size = new System.Drawing.Size(58, 18);
            this.planNamelabel.TabIndex = 2;
            this.planNamelabel.Text = "ชื่อแผน :";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.textBox1.Location = new System.Drawing.Point(320, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 24);
            this.textBox1.TabIndex = 3;
            // 
            // SupplierDatagridview
            // 
            this.SupplierDatagridview.AllowUserToAddRows = false;
            this.SupplierDatagridview.AllowUserToDeleteRows = false;
            this.SupplierDatagridview.AllowUserToResizeColumns = false;
            this.SupplierDatagridview.AllowUserToResizeRows = false;
            this.SupplierDatagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierDatagridview.Location = new System.Drawing.Point(12, 70);
            this.SupplierDatagridview.MultiSelect = false;
            this.SupplierDatagridview.Name = "SupplierDatagridview";
            this.SupplierDatagridview.ReadOnly = true;
            this.SupplierDatagridview.RowHeadersVisible = false;
            this.SupplierDatagridview.RowTemplate.Height = 24;
            this.SupplierDatagridview.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.SupplierDatagridview.Size = new System.Drawing.Size(671, 623);
            this.SupplierDatagridview.TabIndex = 26;
            // 
            // addToSupplyInPRbutton
            // 
            this.addToSupplyInPRbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.addToSupplyInPRbutton.Location = new System.Drawing.Point(689, 350);
            this.addToSupplyInPRbutton.Name = "addToSupplyInPRbutton";
            this.addToSupplyInPRbutton.Size = new System.Drawing.Size(75, 45);
            this.addToSupplyInPRbutton.TabIndex = 37;
            this.addToSupplyInPRbutton.Text = "◀️";
            this.addToSupplyInPRbutton.UseVisualStyleBackColor = true;
            this.addToSupplyInPRbutton.Click += new System.EventHandler(this.addToSupplyInPRbutton_Click);
            // 
            // removeFromSupplyInPRbutton
            // 
            this.removeFromSupplyInPRbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.removeFromSupplyInPRbutton.Location = new System.Drawing.Point(689, 299);
            this.removeFromSupplyInPRbutton.Name = "removeFromSupplyInPRbutton";
            this.removeFromSupplyInPRbutton.Size = new System.Drawing.Size(75, 45);
            this.removeFromSupplyInPRbutton.TabIndex = 36;
            this.removeFromSupplyInPRbutton.Text = "▶️";
            this.removeFromSupplyInPRbutton.UseVisualStyleBackColor = true;
            // 
            // supplyTypecomboBox
            // 
            this.supplyTypecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyTypecomboBox.FormattingEnabled = true;
            this.supplyTypecomboBox.Location = new System.Drawing.Point(718, 9);
            this.supplyTypecomboBox.Name = "supplyTypecomboBox";
            this.supplyTypecomboBox.Size = new System.Drawing.Size(229, 26);
            this.supplyTypecomboBox.TabIndex = 41;
            this.supplyTypecomboBox.SelectedIndexChanged += new System.EventHandler(this.supplyTypecomboBox_SelectedIndexChanged);
            // 
            // supplySelectionlabel
            // 
            this.supplySelectionlabel.AutoSize = true;
            this.supplySelectionlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplySelectionlabel.Location = new System.Drawing.Point(628, 14);
            this.supplySelectionlabel.Name = "supplySelectionlabel";
            this.supplySelectionlabel.Size = new System.Drawing.Size(84, 18);
            this.supplySelectionlabel.TabIndex = 40;
            this.supplySelectionlabel.Text = "ประเภทวัสดุ :";
            // 
            // supplySearchtextBox
            // 
            this.supplySearchtextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplySearchtextBox.Location = new System.Drawing.Point(1033, 8);
            this.supplySearchtextBox.Name = "supplySearchtextBox";
            this.supplySearchtextBox.Size = new System.Drawing.Size(274, 24);
            this.supplySearchtextBox.TabIndex = 43;
            this.supplySearchtextBox.TextChanged += new System.EventHandler(this.supplySearchtextBox_TextChanged);
            // 
            // supplyNamelabel
            // 
            this.supplyNamelabel.AutoSize = true;
            this.supplyNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.supplyNamelabel.Location = new System.Drawing.Point(978, 11);
            this.supplyNamelabel.Name = "supplyNamelabel";
            this.supplyNamelabel.Size = new System.Drawing.Size(55, 18);
            this.supplyNamelabel.TabIndex = 42;
            this.supplyNamelabel.Text = "ชื่อวัสดุ :";
            // 
            // selectedSupplylabel
            // 
            this.selectedSupplylabel.AutoSize = true;
            this.selectedSupplylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.selectedSupplylabel.Location = new System.Drawing.Point(9, 49);
            this.selectedSupplylabel.Name = "selectedSupplylabel";
            this.selectedSupplylabel.Size = new System.Drawing.Size(83, 18);
            this.selectedSupplylabel.TabIndex = 44;
            this.selectedSupplylabel.Text = "วัสดุที่ถูกเลือก";
            // 
            // allSupplylabel
            // 
            this.allSupplylabel.AutoSize = true;
            this.allSupplylabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.allSupplylabel.Location = new System.Drawing.Point(767, 49);
            this.allSupplylabel.Name = "allSupplylabel";
            this.allSupplylabel.Size = new System.Drawing.Size(72, 18);
            this.allSupplylabel.TabIndex = 45;
            this.allSupplylabel.Text = "วัสดุทั้งหมด";
            // 
            // allSupplydataGridView
            // 
            this.allSupplydataGridView.AllowUserToAddRows = false;
            this.allSupplydataGridView.AllowUserToDeleteRows = false;
            this.allSupplydataGridView.AllowUserToResizeColumns = false;
            this.allSupplydataGridView.AllowUserToResizeRows = false;
            this.allSupplydataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.allSupplydataGridView.Location = new System.Drawing.Point(770, 70);
            this.allSupplydataGridView.MultiSelect = false;
            this.allSupplydataGridView.Name = "allSupplydataGridView";
            this.allSupplydataGridView.ReadOnly = true;
            this.allSupplydataGridView.RowHeadersVisible = false;
            this.allSupplydataGridView.RowTemplate.Height = 24;
            this.allSupplydataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.allSupplydataGridView.Size = new System.Drawing.Size(671, 623);
            this.allSupplydataGridView.TabIndex = 46;
            // 
            // createPRbutton
            // 
            this.createPRbutton.BackColor = System.Drawing.SystemColors.Info;
            this.createPRbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.createPRbutton.Location = new System.Drawing.Point(1366, 699);
            this.createPRbutton.Name = "createPRbutton";
            this.createPRbutton.Size = new System.Drawing.Size(75, 70);
            this.createPRbutton.TabIndex = 77;
            this.createPRbutton.Text = "สร้าง";
            this.createPRbutton.UseVisualStyleBackColor = false;
            // 
            // CreateSupplyDeliveryPlanForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(1464, 781);
            this.Controls.Add(this.createPRbutton);
            this.Controls.Add(this.allSupplydataGridView);
            this.Controls.Add(this.allSupplylabel);
            this.Controls.Add(this.selectedSupplylabel);
            this.Controls.Add(this.supplySearchtextBox);
            this.Controls.Add(this.supplyNamelabel);
            this.Controls.Add(this.supplyTypecomboBox);
            this.Controls.Add(this.supplySelectionlabel);
            this.Controls.Add(this.addToSupplyInPRbutton);
            this.Controls.Add(this.removeFromSupplyInPRbutton);
            this.Controls.Add(this.SupplierDatagridview);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.planNamelabel);
            this.Controls.Add(this.monthSelectioncomboBox);
            this.Controls.Add(this.monthSelectopnlabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateSupplyDeliveryPlanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "สร้างแผนส่งวัสดุ";
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDatagridview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.allSupplydataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label monthSelectopnlabel;
        private System.Windows.Forms.ComboBox monthSelectioncomboBox;
        private System.Windows.Forms.Label planNamelabel;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView SupplierDatagridview;
        private System.Windows.Forms.Button addToSupplyInPRbutton;
        private System.Windows.Forms.Button removeFromSupplyInPRbutton;
        private System.Windows.Forms.ComboBox supplyTypecomboBox;
        private System.Windows.Forms.Label supplySelectionlabel;
        private System.Windows.Forms.TextBox supplySearchtextBox;
        private System.Windows.Forms.Label supplyNamelabel;
        private System.Windows.Forms.Label selectedSupplylabel;
        private System.Windows.Forms.Label allSupplylabel;
        private System.Windows.Forms.DataGridView allSupplydataGridView;
        private System.Windows.Forms.Button createPRbutton;
    }
}