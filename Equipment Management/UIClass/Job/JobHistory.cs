using System;
using System.Collections.Generic;
using Equipment_Management.CustomViewClass;
using Equipment_Management.GlobalVariable;
using System.Drawing;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using System.Linq;

namespace Equipment_Management.UIClass.Job
{
    public partial class JobHistory : Form
    {
        public event EventHandler UpdateGrid;
        //For update Equipment panel
        Equipment JEq;
        //For update Job gridview
        List<AllJobByEquipmentView> allJobByEquipmentViewList;
        BindingSource joblistBindingSource;

        private PictureBox finishPictureBox;

        public JobHistory()
        {
            InitializeComponent();
            this.Size = new Size(1480,820);
            allJobByEquipmentViewList = AllJobByEquipmentView.GetAllJobByEquipmentView();
            JEq = new Equipment(Global.ID);
            joblistBindingSource = new BindingSource();

            //Create hidden picturebox
            finishPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(900, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(finishPictureBox);
            //Register drive event
            eJobHistoryDataGridView.CellMouseEnter += eJobHistoryDataGridView_CellMouseEnter;
            eJobHistoryDataGridView.CellMouseLeave += eJobHistoryDataGridView_CellMouseLeave;

            UpdateEquipmentDetails();
            if (allJobByEquipmentViewList.Any())
            {
                UpdateJobGridview();

                string imagePath = eJobHistoryDataGridView["CasePhoto", 0]?.Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    Global.LoadImageIntoPictureBox(imagePath, casePictureBox);
                }
            }
            else
            {
                eJobHistoryDataGridView.DataSource = null;
            }
        }
        private void UpdateEquipmentDetails()
        {
            eNameLabel.Text = JEq.Name;
            eSerialLabel.Text = JEq.Serial;
            eInstallPlacerichTextBox.Text = JEq.InstallationDetails;
            Global.LoadImageIntoPictureBox(JEq.EPhotoPath,equipmentPictureBox);
        }
        private void UpdateJobGridview()
        {
            joblistBindingSource.DataSource = allJobByEquipmentViewList;
            eJobHistoryDataGridView.DataSource = joblistBindingSource;
            FormatJobistDatagridView();
        }
        private void FormatJobistDatagridView()
        {
            if(eJobHistoryDataGridView.Columns["ID"] != null)
            {
                eJobHistoryDataGridView.Columns["ID"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["EID"] != null)
            {
                eJobHistoryDataGridView.Columns["EID"].Visible = false;
            }
            if(eJobHistoryDataGridView.Columns["JType"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["JType"];
                customColumn.HeaderText = "ประเภทการซ่อม";
                customColumn.Width = 130;
            }
            if (eJobHistoryDataGridView.Columns["SDate"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["SDate"];
                customColumn.HeaderText = "วันที่เริ่มงาน/ได้ของ";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 100;
            }
            if (eJobHistoryDataGridView.Columns["FDate"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["FDate"];
                customColumn.HeaderText = "วันที่เสร็จงาน";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 90;
            }
            if (eJobHistoryDataGridView.Columns["VendorName"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["VendorName"];
                customColumn.HeaderText = "ชื่อ Vendor / ผู้ซ่อม";
                customColumn.Width = 200;
            }
            if (eJobHistoryDataGridView.Columns["JDetails"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["JDetails"];
                customColumn.HeaderText = "รายละเอียดการแจ้งซ่อม";
                customColumn.Width = 350;
            }
            if (eJobHistoryDataGridView.Columns["Cost"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["Cost"];
                customColumn.HeaderText = "ราคา / ค่าใช้จ่าย";
                customColumn.Width = 90;
            }
            if (eJobHistoryDataGridView.Columns["CasePhoto"] != null)
            {
                eJobHistoryDataGridView.Columns["CasePhoto"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["JobStatus"] != null)
            {
                eJobHistoryDataGridView.Columns["JobStatus"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["REName"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["REName"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์ทดแทน";
                customColumn.Width = 200;
            }
            if (eJobHistoryDataGridView.Columns["RESerial"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["RESerial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
            }
            if (eJobHistoryDataGridView.Columns["FinPhoto"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["FinPhoto"];
                customColumn.HeaderText = "รูปหลังซ่อมเสร็จ";
            }
        }
        //Event to show case photo
        private void eJobHistoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string imagePath = eJobHistoryDataGridView["CasePhoto", e.RowIndex]?.Value?.ToString();
                if (!string.IsNullOrEmpty(imagePath))
                {
                    Global.LoadImageIntoPictureBox(imagePath, casePictureBox);
                }
                else
                {
                    return;
                }
            }
        }
        //Event to show hidden picturebox
        private void eJobHistoryDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = eJobHistoryDataGridView.Columns[e.ColumnIndex].Name;
                if (columnName == "FinPhoto")
                {
                    string imagePath = eJobHistoryDataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, finishPictureBox);
                    finishPictureBox.Visible = true;
                    finishPictureBox.BringToFront();

                }
            }
        }
        private void eJobHistoryDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            finishPictureBox.Visible = false;
        }
    }
}
