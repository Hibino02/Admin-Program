namespace Admin_Program.SupplyManagement.UIClass.SupplyHistory
{
    partial class SupplyHistoryForm
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
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.supplychart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.startdateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.enddateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.fromDatelabel = new System.Windows.Forms.Label();
            this.toDatelabel = new System.Windows.Forms.Label();
            this.chartGenbutton = new System.Windows.Forms.Button();
            this.supplycomboBox = new System.Windows.Forms.ComboBox();
            this.supplylabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.supplychart)).BeginInit();
            this.SuspendLayout();
            // 
            // supplychart
            // 
            this.supplychart.Location = new System.Drawing.Point(12, 93);
            this.supplychart.Name = "supplychart";
            series2.Name = "Series1";
            this.supplychart.Series.Add(series2);
            this.supplychart.Size = new System.Drawing.Size(727, 343);
            this.supplychart.TabIndex = 0;
            this.supplychart.Text = "chart1";
            // 
            // startdateTimePicker
            // 
            this.startdateTimePicker.Location = new System.Drawing.Point(70, 12);
            this.startdateTimePicker.Name = "startdateTimePicker";
            this.startdateTimePicker.Size = new System.Drawing.Size(217, 20);
            this.startdateTimePicker.TabIndex = 1;
            // 
            // enddateTimePicker
            // 
            this.enddateTimePicker.Location = new System.Drawing.Point(348, 11);
            this.enddateTimePicker.Name = "enddateTimePicker";
            this.enddateTimePicker.Size = new System.Drawing.Size(217, 20);
            this.enddateTimePicker.TabIndex = 2;
            // 
            // fromDatelabel
            // 
            this.fromDatelabel.AutoSize = true;
            this.fromDatelabel.Location = new System.Drawing.Point(12, 19);
            this.fromDatelabel.Name = "fromDatelabel";
            this.fromDatelabel.Size = new System.Drawing.Size(52, 13);
            this.fromDatelabel.TabIndex = 3;
            this.fromDatelabel.Text = "จากวันที่ :";
            // 
            // toDatelabel
            // 
            this.toDatelabel.AutoSize = true;
            this.toDatelabel.Location = new System.Drawing.Point(296, 18);
            this.toDatelabel.Name = "toDatelabel";
            this.toDatelabel.Size = new System.Drawing.Size(46, 13);
            this.toDatelabel.TabIndex = 4;
            this.toDatelabel.Text = "ถึงวันที่ :";
            // 
            // chartGenbutton
            // 
            this.chartGenbutton.Location = new System.Drawing.Point(656, 11);
            this.chartGenbutton.Name = "chartGenbutton";
            this.chartGenbutton.Size = new System.Drawing.Size(86, 49);
            this.chartGenbutton.TabIndex = 5;
            this.chartGenbutton.Text = "ดำเนินการ";
            this.chartGenbutton.UseVisualStyleBackColor = true;
            this.chartGenbutton.Click += new System.EventHandler(this.chartGenbutton_Click);
            // 
            // supplycomboBox
            // 
            this.supplycomboBox.FormattingEnabled = true;
            this.supplycomboBox.Location = new System.Drawing.Point(12, 66);
            this.supplycomboBox.Name = "supplycomboBox";
            this.supplycomboBox.Size = new System.Drawing.Size(727, 21);
            this.supplycomboBox.TabIndex = 6;
            this.supplycomboBox.SelectedIndexChanged += new System.EventHandler(this.supplycomboBox_SelectedIndexChanged);
            // 
            // supplylabel
            // 
            this.supplylabel.AutoSize = true;
            this.supplylabel.Location = new System.Drawing.Point(12, 47);
            this.supplylabel.Name = "supplylabel";
            this.supplylabel.Size = new System.Drawing.Size(56, 13);
            this.supplylabel.TabIndex = 7;
            this.supplylabel.Text = "เลือกวัสดุ :";
            // 
            // SupplyHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(774, 448);
            this.Controls.Add(this.supplylabel);
            this.Controls.Add(this.supplycomboBox);
            this.Controls.Add(this.chartGenbutton);
            this.Controls.Add(this.toDatelabel);
            this.Controls.Add(this.fromDatelabel);
            this.Controls.Add(this.enddateTimePicker);
            this.Controls.Add(this.startdateTimePicker);
            this.Controls.Add(this.supplychart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SupplyHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ประวัติการใช้งานและวัสดุคงคลัง";
            ((System.ComponentModel.ISupportInitialize)(this.supplychart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart supplychart;
        private System.Windows.Forms.DateTimePicker startdateTimePicker;
        private System.Windows.Forms.DateTimePicker enddateTimePicker;
        private System.Windows.Forms.Label fromDatelabel;
        private System.Windows.Forms.Label toDatelabel;
        private System.Windows.Forms.Button chartGenbutton;
        private System.Windows.Forms.ComboBox supplycomboBox;
        private System.Windows.Forms.Label supplylabel;
    }
}