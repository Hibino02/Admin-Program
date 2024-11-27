using System;
using System.Collections.Generic;
using Admin_Program.CustomViewClass;
using Admin_Program.GlobalVariable;
using System.Drawing;
using System.Windows.Forms;
using Admin_Program.ObjectClass;
using Admin_Program.CustomWindowComponents;
using System.IO;

namespace Admin_Program.UIClass.Job
{
    public partial class JobHistory : Form
    {
        public event EventHandler UpdateGrid;
        //For update Equipment panel
        Equipment JEq;
        //For update Job gridview
        List<AllJobByEquipmentView> allJobByEquipmentViewList;
        BindingSource joblistBindingSource;

        string jobDocument;
        string workpermit;
        string contract;
        string findocument;

        string casePhoto;
        string finPhoto;

        DateTime startDate;
        DateTime finishDate;

        private ToolTip jDocumentTooltips;
        private ToolTip workpermitTooltips;
        private ToolTip contractTooltips;
        private ToolTip findocumentTooltips;

        private PictureBox newEPicturebox;

        public bool isJlist = true;

        public JobHistory()
        {
            InitializeComponent();
            this.Size = new Size(1480,820);
            allJobByEquipmentViewList = AllJobByEquipmentView.GetAllJobByEquipmentView();

            if (CheckJoblist())
            {
                this.Close();
                return;
            }

            JEq = new Equipment(Global.ID);
            joblistBindingSource = new BindingSource();

            //--------------------------------------------------------------------------------------------//
            //jDocument tooltips
            jDocumentTooltips = new ToolTip();
            jDocumentTooltips.InitialDelay = 0;
            jDocumentTooltips.ReshowDelay = 0;
            jDocumentTooltips.AutoPopDelay = 5000;

            jobDoclinkLabel.MouseEnter += jobDoclinkLabel_MouseEnter;
            jobDoclinkLabel.MouseLeave += jobDoclinkLabel_MouseLeave;

            //--------------------------------------------------------------------------------------------//
            //workpermit tooltips
            workpermitTooltips = new ToolTip();
            workpermitTooltips.InitialDelay = 0;
            workpermitTooltips.ReshowDelay = 0;
            workpermitTooltips.AutoPopDelay = 5000;

            workpermitlinkLabel.MouseEnter += workpermitlinkLabel_MouseEnter;
            workpermitlinkLabel.MouseLeave += workpermitlinkLabel_MouseLeave;

            //--------------------------------------------------------------------------------------------//
            //contract tooltips
            contractTooltips = new ToolTip();
            contractTooltips.InitialDelay = 0;
            contractTooltips.ReshowDelay = 0;
            contractTooltips.AutoPopDelay = 5000;

            contractlinkLabel.MouseEnter += contractlinkLabel_MouseEnter;
            contractlinkLabel.MouseLeave += contractlinkLabel_MouseLeave;

            //--------------------------------------------------------------------------------------------//
            //workpermit tooltips
            findocumentTooltips = new ToolTip();
            findocumentTooltips.InitialDelay = 0;
            findocumentTooltips.ReshowDelay = 0;
            findocumentTooltips.AutoPopDelay = 5000;

            finDoclinkLabel.MouseEnter += finDoclinkLabel_MouseEnter;
            finDoclinkLabel.MouseLeave += finDoclinkLabel_MouseLeave;

            //Create hidden picturebox for Job
            newEPicturebox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(700, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(newEPicturebox);
            //Register drive event
            eJobHistoryDataGridView.CellMouseEnter += eJobHistoryDataGridView_CellMouseEnter;
            eJobHistoryDataGridView.CellMouseLeave += eJobHistoryDataGridView_CellMouseLeave;

            UpdateEquipmentDetails();
            UpdateJobGridview();
        }
        public bool CheckJoblist()
        {
            if (allJobByEquipmentViewList.Count == 0)
            {
                ShowCustomMessageBox("อุปกรณ์นี้ ไม่เคยมีประวัติการแจ้งซ่อม");
                isJlist = false;
                return true;
            }
            return false;
        }
        private void UpdateEquipmentDetails()
        {
            //Static components setting here
            eNameLabel.Text = JEq.Name;
            eSerialLabel.Text = JEq.Serial;
            eInstallPlacerichTextBox.Text = JEq.InstallationDetails;
            if (!string.IsNullOrEmpty(JEq.EPhotoPath))
            {
                Global.LoadImageIntoPictureBox(JEq.EPhotoPath, equipmentPictureBox);
            }
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
                eJobHistoryDataGridView.Columns["JType"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["SDate"] != null)
            {
                eJobHistoryDataGridView.Columns["SDate"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["FDate"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["FDate"];
                customColumn.HeaderText = "วันที่เสร็จงาน";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 120;
            }
            if (eJobHistoryDataGridView.Columns["VendorName"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["VendorName"];
                customColumn.HeaderText = "ชื่อ Vendor / ผู้ซ่อม";
                customColumn.Width = 200;
            }
            if (eJobHistoryDataGridView.Columns["JDetails"] != null)
            {
                eJobHistoryDataGridView.Columns["JDetails"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["Cost"] != null)
            {
                eJobHistoryDataGridView.Columns["Cost"].Visible = false;
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
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์ทดแทน (กรณีที่ซื้อใหม่)";
                customColumn.Width = 250;
            }
            if (eJobHistoryDataGridView.Columns["RESerial"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["RESerial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
                customColumn.Width = 100;
            }
            if (eJobHistoryDataGridView.Columns["FinPhoto"] != null)
            {
                eJobHistoryDataGridView.Columns["FinPhoto"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["REPhoto"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["REPhoto"];
                customColumn.HeaderText = "รูปของใหม่";
                customColumn.Width = 100;
            }
            if (eJobHistoryDataGridView.Columns["JobDocument"] != null)
            {
                eJobHistoryDataGridView.Columns["JobDocument"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["WorkPermit"] != null)
            {
                eJobHistoryDataGridView.Columns["WorkPermit"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["Contract"] != null)
            {
                eJobHistoryDataGridView.Columns["Contract"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["FinDocument"] != null)
            {
                eJobHistoryDataGridView.Columns["FinDocument"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["RepairDetails"] != null)
            {
                eJobHistoryDataGridView.Columns["RepairDetails"].Visible = false;
            }
            if (eJobHistoryDataGridView.Columns["VendorDetails"] != null)
            {
                var customColumn = eJobHistoryDataGridView.Columns["VendorDetails"];
                customColumn.HeaderText = "รายละเอียดผู้รับเหมา";
                customColumn.Width = 250;
            }
        }
        //Showing contents to components
        private void eJobHistoryDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = eJobHistoryDataGridView.Rows[e.RowIndex];

                jobDocument = selectedRow.Cells["JobDocument"].Value?.ToString();
                workpermit = selectedRow.Cells["WorkPermit"].Value?.ToString();
                contract = selectedRow.Cells["Contract"].Value?.ToString();
                findocument = selectedRow.Cells["FinDocument"].Value?.ToString();

                // Update link label colors based on file existence
                if (!String.IsNullOrEmpty(jobDocument))
                {
                    jobDoclinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
                else
                {
                    jobDoclinkLabel.LinkColor = System.Drawing.Color.Blue;
                }
                if (!String.IsNullOrEmpty(workpermit))
                {
                    workpermitlinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
                else
                {
                    workpermitlinkLabel.LinkColor = System.Drawing.Color.Blue;
                }
                if (!String.IsNullOrEmpty(contract))
                {
                    contractlinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
                else
                {
                    contractlinkLabel.LinkColor = System.Drawing.Color.Blue;
                }
                if (!String.IsNullOrEmpty(findocument))
                {
                    finDoclinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
                else
                {
                    finDoclinkLabel.LinkColor = System.Drawing.Color.Blue;
                }

                jTypelabel.Text = selectedRow.Cells["JType"].Value?.ToString();
                string sDate = selectedRow.Cells["SDate"].Value?.ToString();
                if(DateTime.TryParse(sDate, out startDate))
                {
                    startDatelabel.Text = startDate.ToString("MMM dd, yyy");
                }
                else
                {
                    startDatelabel.Text = "-";
                }
                jDetailrichTextBox.Text = selectedRow.Cells["JDetails"].Value?.ToString();
                casePhoto = selectedRow.Cells["CasePhoto"].Value?.ToString();
                if (!string.IsNullOrEmpty(casePhoto))
                {
                    Global.LoadImageIntoPictureBox(casePhoto, casePictureBox);
                }
                else
                {
                    casePictureBox.Image = null;
                }
                costlabel.Text = selectedRow.Cells["Cost"].Value?.ToString();
                string fDate = selectedRow.Cells["FDate"].Value?.ToString();
                if(DateTime.TryParse(fDate, out finishDate))
                {
                    finDatelabel.Text = finishDate.ToString("MMM dd, yyy");
                }
                else
                {
                    finDatelabel.Text = "-";
                }
                repairDetailrichTextBox.Text = selectedRow.Cells["RepairDetails"].Value?.ToString();
                finPhoto = selectedRow.Cells["FinPhoto"].Value?.ToString();
                if (!string.IsNullOrEmpty(finPhoto))
                {
                    Global.LoadImageIntoPictureBox(finPhoto,finPictureBox);
                }
                else
                {
                    finPictureBox.Image = null;
                }
            }
        }
        //Automatic selected first row
        private void eJobHistoryDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (eJobHistoryDataGridView.Rows.Count > 0)
            {
                eJobHistoryDataGridView.CurrentCell = eJobHistoryDataGridView.Rows[0].Cells[4];
                eJobHistoryDataGridView_CellClick(this,new DataGridViewCellEventArgs(0,0));
            }
        }
        //Opening Documents Event
        private void jobDoclinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(jobDocument))
            {
                Global.DownloadAndOpenPdf(jobDocument);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        private void workpermitlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(workpermit))
            {
                Global.DownloadAndOpenPdf(workpermit);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        private void contractlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(contract))
            {
                Global.DownloadAndOpenPdf(contract);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        private void finDoclinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(findocument))
            {
                Global.DownloadAndOpenPdf(findocument);
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

        private void jobDoclinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(jobDocument))
            {
                jDocumentTooltips.Show($"Attached File: {Path.GetFileName(jobDocument)}", jobDoclinkLabel);
            }
            else
            {
                jDocumentTooltips.Show("No file attached", jobDoclinkLabel);
            }
        }
        private void jobDoclinkLabel_MouseLeave(object sender, EventArgs e)
        {
            jDocumentTooltips.Hide(jobDoclinkLabel);
        }
        private void workpermitlinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(workpermit))
            {
                workpermitTooltips.Show($"Attached File: {Path.GetFileName(workpermit)}", workpermitlinkLabel);
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
        private void contractlinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(contract))
            {
                contractTooltips.Show($"Attached File: {Path.GetFileName(contract)}", contractlinkLabel);
            }
            else
            {
                contractTooltips.Show("No file attached", contractlinkLabel);
            }
        }
        private void contractlinkLabel_MouseLeave(object sender, EventArgs e)
        {
            contractTooltips.Hide(contractlinkLabel);
        }
        private void finDoclinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(findocument))
            {
                findocumentTooltips.Show($"Attached File: {Path.GetFileName(findocument)}", finDoclinkLabel);
            }
            else
            {
                findocumentTooltips.Show("No file attached", finDoclinkLabel);
            }
        }
        private void finDoclinkLabel_MouseLeave(object sender, EventArgs e)
        {
            findocumentTooltips.Hide(finDoclinkLabel);
        }

        //Event to drive picturebox
        private void eJobHistoryDataGridView_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = eJobHistoryDataGridView.Columns[e.ColumnIndex].Name;
                if (columnName == "REPhoto")
                {
                    eJobHistoryDataGridView.ShowCellToolTips = false;

                    string imagePath = eJobHistoryDataGridView[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, newEPicturebox);
                    newEPicturebox.Visible = true;
                    newEPicturebox.BringToFront();
                }
            }
        }
        private void eJobHistoryDataGridView_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            newEPicturebox.Visible = false;
            eJobHistoryDataGridView.ShowCellToolTips = true;
        }
    }
}
