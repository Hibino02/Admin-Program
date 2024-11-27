using System;
using System.Collections.Generic;
using System.Drawing;
using Admin_Program.GlobalVariable;
using Admin_Program.CustomViewClass;
using System.Windows.Forms;
using System.IO;
using Admin_Program.CustomWindowComponents;

namespace Admin_Program.UIClass.Plan
{
    public partial class PlanHistoryProgressForm : Form
    {
        List<AllProcessInPlanView> processInplan;
        BindingSource processInplanBindingSource;
        //Variable for click datagrid event
        DateTime processParsedDate;
        DateTime finParsedDate;
        string workpermitPath;
        string finDocPath;
        string contractPhotopath;

        private ToolTip workpermitTooltips;
        private ToolTip finDocTooltips;

        private PictureBox replaceEquipmentPictureBox;

        public PlanHistoryProgressForm()
        {
            InitializeComponent();
            this.Size = new Size(1015, 820);
            processInplanBindingSource = new BindingSource();

            planProcessDatagridview.DataBindingComplete += planProcessDatagridview_DataBindingComplete;

            //--------------------------------------------------------------------------------------------//
            //workpermit tooltips
            workpermitTooltips = new ToolTip();
            workpermitTooltips.InitialDelay = 0;
            workpermitTooltips.ReshowDelay = 0;
            workpermitTooltips.AutoPopDelay = 5000;

            workpermitlinkLabel.MouseEnter += workpermitlinkLabel_MouseEnter;
            workpermitlinkLabel.MouseLeave += workpermitlinkLabel_MouseLeave;

            //--------------------------------------------------------------------------------------------//
            //finDoc tooltips
            finDocTooltips = new ToolTip();
            finDocTooltips.InitialDelay = 0;
            finDocTooltips.ReshowDelay = 0;
            finDocTooltips.AutoPopDelay = 5000;

            finDoclinkLabel.MouseEnter += finDoclinkLabel_MouseEnter;
            finDoclinkLabel.MouseLeave += finDoclinkLabel_MouseLeave;

            //--------------------------------------------------------------------------------------------//
            //Create hidden picturebox for Plan
            replaceEquipmentPictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(700, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(replaceEquipmentPictureBox);
            //Register event for picturebox
            planProcessDatagridview.CellMouseEnter += planProcessDatagridview_CellMouseEnter;
            planProcessDatagridview.CellMouseLeave += planProcessDatagridview_CellMouseLeave;

            UpdatePlanComponents();
            UpdatePlanProcessDataGridView();
        }
        private void UpdatePlanComponents()
        {
            eNamelabel.Text = Global.selectedEquipmentInPlan.EName;
            eSeriallabel.Text = Global.selectedEquipmentInPlan.ESerial;
            eStatuslabel.Text = Global.selectedEquipmentInPlan.EStatus;
            pTypelabel.Text = Global.selectedEquipmentInPlan.PType;
            pPeriodlabel.Text = Global.selectedEquipmentInPlan.PPeriod;
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInPlan.EPhoto))
            {
                Global.LoadImageIntoPictureBox(Global.selectedEquipmentInPlan.EPhoto, epictureBox);
            }
            // Update link label colors based on file existence
            if (!String.IsNullOrEmpty(workpermitPath))
            {
                workpermitlinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
            else
            {
                workpermitlinkLabel.LinkColor = System.Drawing.Color.Blue;
            }
            if (!String.IsNullOrEmpty(finDocPath))
            {
                finDoclinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
            else
            {
                finDoclinkLabel.LinkColor = System.Drawing.Color.Blue;
            }
        }
        private void UpdatePlanProcessDataGridView()
        {
            processInplan = AllProcessInPlanView.GetAllProcessInlan(Global.selectedEquipmentInPlan.ID);
            processInplanBindingSource.DataSource = processInplan;
            planProcessDatagridview.DataSource = processInplanBindingSource;

            FormaiingProcessDataGridView();
        }
        private void FormaiingProcessDataGridView()
        {
            if(planProcessDatagridview.Columns["ID"] != null)
            {
                planProcessDatagridview.Columns["ID"].Visible = false;
            }
            if (planProcessDatagridview.Columns["PID"] != null)
            {
                planProcessDatagridview.Columns["PID"].Visible = false;
            }
            if (planProcessDatagridview.Columns["EID"] != null)
            {
                planProcessDatagridview.Columns["EID"].Visible = false;
            }
            if (planProcessDatagridview.Columns["EName"] != null)
            {
                planProcessDatagridview.Columns["EName"].Visible = false;
            }
            if (planProcessDatagridview.Columns["ESerial"] != null)
            {
                planProcessDatagridview.Columns["ESerial"].Visible = false;
            }
            if (planProcessDatagridview.Columns["PType"] != null)
            {
                planProcessDatagridview.Columns["PType"].Visible = false;
            }
            if (planProcessDatagridview.Columns["ProcessDate"] != null)
            {
                var column = planProcessDatagridview.Columns["ProcessDate"];
                column.HeaderText = "วันที่เริ่ม";
                column.DefaultCellStyle.Format = "MMM dd, yyy";
                column.Width = 80;
            }
            if (planProcessDatagridview.Columns["REID"] != null)
            {
                planProcessDatagridview.Columns["REID"].Visible = false;
            }
            if (planProcessDatagridview.Columns["RESerial"] != null)
            {
                var column = planProcessDatagridview.Columns["RESerial"];
                column.HeaderText = "ชื่อทางบัญชี";
                column.Width = 150;
                column.DisplayIndex = 19;
            }
            if (planProcessDatagridview.Columns["ContractPhoto"] != null)
            {
                planProcessDatagridview.Columns["ContractPhoto"].Visible = false;
            }
            if (planProcessDatagridview.Columns["EPhotoPath"] != null)
            {
                planProcessDatagridview.Columns["EPhotoPath"].Visible = false;
            }
            if (planProcessDatagridview.Columns["VenderName"] != null)
            {
                planProcessDatagridview.Columns["VenderName"].Visible = false;
            }
            if (planProcessDatagridview.Columns["StartDetails"] != null)
            {
                var column = planProcessDatagridview.Columns["StartDetails"];
                column.HeaderText = "รายละเอียดตอนเริ่มงาน";
                column.Width = 200;
            }
            if (planProcessDatagridview.Columns["VenderDetails"] != null)
            {
                var column = planProcessDatagridview.Columns["VenderDetails"];
                column.HeaderText = "รายละเอียดผู้รับเหมา";
                column.Width = 200;
            }
            if (planProcessDatagridview.Columns["Cost"] != null)
            {
                var column = planProcessDatagridview.Columns["Cost"];
                column.HeaderText = "ราคา";
                column.Width = 100;
            }
            if (planProcessDatagridview.Columns["WorkPermit"] != null)
            {
                planProcessDatagridview.Columns["WorkPermit"].Visible = false;
            }
            if (planProcessDatagridview.Columns["FinishDate"] != null)
            {
                var column = planProcessDatagridview.Columns["FinishDate"];
                column.HeaderText = "วันที่เสร็จ";
                column.DefaultCellStyle.Format = "MMM dd, yyy";
                column.Width = 80;
            }
            if (planProcessDatagridview.Columns["FinishDetails"] != null)
            {
                var column = planProcessDatagridview.Columns["FinishDetails"];
                column.HeaderText = "รายละเอียดหลังเสร็จงาน";
                column.Width = 200;
            }
            if (planProcessDatagridview.Columns["FinishDocuments"] != null)
            {
                planProcessDatagridview.Columns["FinishDocuments"].Visible = false;
            }
            if (planProcessDatagridview.Columns["REName"] != null)
            {
                var column = planProcessDatagridview.Columns["REName"];
                column.HeaderText = "ชื่ออุปกรณ์ทดแทน";
                column.Width = 200;
                column.DisplayIndex = 18;
            }
            if (planProcessDatagridview.Columns["EStatusID"] != null)
            {
                planProcessDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (planProcessDatagridview.Columns["REPhotoPath"] != null)
            {
                var column = planProcessDatagridview.Columns["REPhotoPath"];
                column.HeaderText = "รูป";
                column.Width = 50;
                column.DisplayIndex = 20;
            }
        }
        //Showing contents to components
        private void planProcessDatagridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = planProcessDatagridview.Rows[e.RowIndex];

                vNamelabel.Text = selectedRow.Cells["VenderName"].Value?.ToString();
                costlabel.Text = selectedRow.Cells["Cost"].Value?.ToString();
                string pDate = selectedRow.Cells["ProcessDate"].Value?.ToString();
                if(DateTime.TryParse(pDate,out processParsedDate))
                {
                    processDatelabel.Text = processParsedDate.ToString("MMM dd, yyy");
                }
                else
                {
                    processDatelabel.Text = "-";
                }
                string fDate = selectedRow.Cells["FinishDate"].Value?.ToString();
                if (DateTime.TryParse(fDate, out finParsedDate))
                {
                    finDatelabel.Text = finParsedDate.ToString("MMM dd, yyy");
                }
                else
                {
                    finDatelabel.Text = "-";
                }
                workpermitPath = selectedRow.Cells["WorkPermit"].Value?.ToString();
                finDocPath = selectedRow.Cells["FinishDocuments"].Value?.ToString();
                contractPhotopath = selectedRow.Cells["ContractPhoto"].Value?.ToString();
                if (!string.IsNullOrEmpty(contractPhotopath))
                {
                    Global.LoadImageIntoPictureBox(contractPhotopath, contractPhotopictureBox);
                }
                else
                {
                    contractPhotopictureBox.Image = null;
                }
                // Update link label colors based on file existence
                if (!String.IsNullOrEmpty(workpermitPath))
                {
                    workpermitlinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
                if (!String.IsNullOrEmpty(finDocPath))
                {
                    finDoclinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
            }
        }
        //Automatic selected first row
        private void planProcessDatagridview_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Ensure there are rows to select
            if (planProcessDatagridview.Rows.Count > 0)
            {
                // Select the first row and cell
                planProcessDatagridview.CurrentCell = planProcessDatagridview.Rows[0].Cells[6];
                // Optionally, trigger the CellClick event
                planProcessDatagridview_CellClick(this, new DataGridViewCellEventArgs(0, 0));
            }
        }
        //Workpermit tooltips Event
        private void workpermitlinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(workpermitPath))
            {
                workpermitTooltips.Show($"Attached File: {Path.GetFileName(workpermitPath)}", workpermitlinkLabel);
            }
            else
            {
                workpermitTooltips.Show("No file attached", workpermitlinkLabel);
            }
        }
        private void workpermitlinkLabel_MouseLeave(object sender, EventArgs e)
        {
            workpermitTooltips.Hide(workpermitlinkLabel);
        }
        //FinDoc tooltips Event
        private void finDoclinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(finDocPath))
            {
                finDocTooltips.Show($"Attached File: {Path.GetFileName(finDocPath)}", finDoclinkLabel);
            }
            else
            {
                finDocTooltips.Show("No file attached", finDoclinkLabel);
            }
        }
        private void finDoclinkLabel_MouseLeave(object sender, EventArgs e)
        {
            finDocTooltips.Hide(finDoclinkLabel);
        }
        //Open workpermit
        private void workpermitlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(workpermitPath))
            {
                Global.DownloadAndOpenPdf(workpermitPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        //Open FinDoc
        private void finDoclinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(finDocPath))
            {
                Global.DownloadAndOpenPdf(finDocPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        //Call custom message box
        private void ShowCustomMessageBox(string message)
        {
            using (var messageBox = new CustomMessageBox())
            {
                messageBox.MessageText = message;
                var result = messageBox.ShowDialog();
            }
        }
        //Event to show hidden picture box
        private void planProcessDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = planProcessDatagridview.Columns[e.ColumnIndex].Name;
                if (columnName == "REPhotoPath")
                {
                    planProcessDatagridview.ShowCellToolTips = false;

                    string imagePath = planProcessDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, replaceEquipmentPictureBox);
                    replaceEquipmentPictureBox.Visible = true;
                    replaceEquipmentPictureBox.BringToFront();
                }
            }
        }
        private void planProcessDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            replaceEquipmentPictureBox.Visible = false;
            planProcessDatagridview.ShowCellToolTips = true;
        }
    }
}
