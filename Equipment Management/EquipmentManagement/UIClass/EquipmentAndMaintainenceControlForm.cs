using System;
using System.Collections.Generic;
using System.Drawing;
using Admin_Program.CustomWindowComponents;
using System.Windows.Forms;
using Admin_Program.ObjectClass;
using Admin_Program.CustomViewClass;
using Admin_Program.UIClass.InstallationSource;
using Admin_Program.UIClass.EquipmentListSource;
using Admin_Program.UIClass.Job;
using Admin_Program.GlobalVariable;
using Admin_Program.UIClass.Plan;
using System.Linq;
using Admin_Program.EquipmentManagement.UIClass.Zone;

namespace Admin_Program.UIClass
{
    public partial class EquipmentAndMaintainenceControlForm : Form
    {
        MainBackGroundFrom main;
        //variable for calling other windows
        private InstallationEquipment installRquipment;
        private EquipmentList equipmentList;
        private CreateJobForm jobCreate;
        private RemoveJobForm jobRemove;
        private EditJobForm jobEdit;
        private JobProcessing jobProcessing;
        private JobAcceptation jobAcceptation;
        private EditJobProcessing editJobProcessing;
        private removeJobProcessing removejobprocessing;
        private CreatePlanForm createPlan;
        private EditPlanForm editPlan;
        private PlanProcessingForm planProcessing;
        private CompletePlanProcessing completePlanProcessing;
        private EditPlanProcessing editPlanProcessing;
        private RemovePlanProcessingForm removePlanProcessingForm;
        private PlanHistoryForm planHistoryForm;
        private ZoneManageForm zoneManageForm;

        private PictureBox casePicturebox;
        private PictureBox planPicturebox;

        BindingSource jobCreatedBindingSource;
        BindingSource jobProcessedBindingSource;
        BindingSource planCreatedBindingSource;
        BindingSource planProccessedBindingSource;

        List<AllJobInProcessView> alljobInProcessViewList;
        List<AllJobInProcessView> jobfilteredList;

        List<AllPlanView> planCreatedViewList;
        List<AllProcessInPlanView> planProceessedViewList;

        public event EventHandler returnMain;

        public EquipmentAndMaintainenceControlForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(1450, 760);

            //Create hidden picturebox for Job
            casePicturebox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(700, 620),
                Location = new Point(750, 0)
            };
            this.Controls.Add(casePicturebox);
            //Register drive event
            jobCreatedDatagridview.CellMouseEnter += jobCreatedDatagridview_CellMouseEnter;
            jobCreatedDatagridview.CellMouseLeave += jobCreatedDatagridview_CellMouseLeave;
            jobProcessingDatagridview.CellMouseEnter += jobProcessingDatagridview_CellMouseEnter;
            jobProcessingDatagridview.CellMouseLeave += jobProcessingDatagridview_CellMouseLeave;

            //Create hidden picturebox for Plan
            planPicturebox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Visible = false,
                BackColor = Color.Transparent,
                Size = new Size(700, 620),
                Location = new Point(10, 10)
            };
            this.Controls.Add(planPicturebox);
            //Register drive event
            currentMaintainencePlanDatagridview.CellMouseEnter += currentMaintainencePlanDatagridview_CellMouseEnter;
            currentMaintainencePlanDatagridview.CellMouseLeave += currentMaintainencePlanDatagridview_CellMouseLeave;

            alljobInProcessViewList = new List<AllJobInProcessView>();
            jobfilteredList = new List<AllJobInProcessView>();
            planCreatedViewList = new List<AllPlanView>();
            planProceessedViewList = new List<AllProcessInPlanView>();
            //Job Created DataGridView section
            jobCreatedBindingSource = new BindingSource();
            UpdateCreatedJobView();
            //Job Processing DataGridView section
            jobProcessedBindingSource = new BindingSource();
            UpdateProcessedJobView();
            //Plan Created DataGridView section
            planCreatedBindingSource = new BindingSource();
            UpdateCreatedPlanView();
            //Plan Processed DataGridView section
            planProccessedBindingSource = new BindingSource();
            UpdateProcessedPlanView();
        }
        //Job Event to drive Hidden Job picture box
        private void jobCreatedDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = jobCreatedDatagridview.Columns[e.ColumnIndex].Name;
                if (columnName == "CasePhoto")
                {
                    jobCreatedDatagridview.ShowCellToolTips = false;

                    string imagePath = jobCreatedDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, casePicturebox);
                    casePicturebox.Visible = true;
                    casePicturebox.BringToFront();
                }
            }
        }
        private void jobCreatedDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            casePicturebox.Visible = false;
            jobCreatedDatagridview.ShowCellToolTips = true;
        }
        private void jobProcessingDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = jobProcessingDatagridview.Columns[e.ColumnIndex].Name;
                if (columnName == "CasePhoto")
                {
                    jobProcessingDatagridview.ShowCellToolTips = false;

                    string imagePath = jobProcessingDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, casePicturebox);
                    casePicturebox.Visible = true;
                    casePicturebox.BringToFront();
                }
            }
        }
        private void jobProcessingDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            casePicturebox.Visible = false;
            jobProcessingDatagridview.ShowCellToolTips = true;
        }
        //Plan Event to drive Hidden Job picture box
        private void currentMaintainencePlanDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = currentMaintainencePlanDatagridview.Columns[e.ColumnIndex].Name;
                if (columnName == "OPlacePhoto")
                {
                    currentMaintainencePlanDatagridview.ShowCellToolTips = false;

                    string imagePath = currentMaintainencePlanDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, planPicturebox);
                    planPicturebox.Visible = true;
                    planPicturebox.BringToFront();
                }
            }
        }
        private void currentMaintainencePlanDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            planPicturebox.Visible = false;
            currentMaintainencePlanDatagridview.ShowCellToolTips = true;
        }
        private void planProcessingDatagridview_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string columnName = planProcessingDatagridview.Columns[e.ColumnIndex].Name;
                if (columnName == "ContractPhoto")
                {
                    planProcessingDatagridview.ShowCellToolTips = false;

                    string imagePath = planProcessingDatagridview[e.ColumnIndex, e.RowIndex]?.Value?.ToString();
                    if (string.IsNullOrEmpty(imagePath))
                    {
                        return;
                    }

                    Global.LoadImageIntoPictureBox(imagePath, planPicturebox);
                    planPicturebox.Visible = true;
                    planPicturebox.BringToFront();
                }
            }
        }
        private void planProcessingDatagridview_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            planPicturebox.Visible = false;
            planProcessingDatagridview.ShowCellToolTips = true;
        }

        private void EquipmentAndMaintainenceControlForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
        //Update gridview Job Created
        private void UpdateCreatedJobView()
        {
            if(alljobInProcessViewList != null)
            {
                alljobInProcessViewList.Clear();
            }
            alljobInProcessViewList = AllJobInProcessView.GetCreatedJobView();
            List<int> filterEStatusIds = new List<int> { 4, 5 };
            // Apply the filter to the list
            jobfilteredList = FilterJobListByEStatusId(alljobInProcessViewList, filterEStatusIds);
            // Set the filtered list as the data source
            jobCreatedBindingSource.DataSource = jobfilteredList;

            jobCreatedDatagridview.DataSource = jobCreatedBindingSource;
            FormatJobCreatedDataGridView();
        }
        private void FormatJobCreatedDataGridView()
        {
            if (jobCreatedDatagridview.Columns["ID"] != null)
            {
                jobCreatedDatagridview.Columns["ID"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["JobEquipmentName"] != null)
            {
                var customColumn = jobCreatedDatagridview.Columns["JobEquipmentName"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (jobCreatedDatagridview.Columns["JobEquipmentSerial"] != null)
            {
                var customColumn = jobCreatedDatagridview.Columns["JobEquipmentSerial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
            }
            if (jobCreatedDatagridview.Columns["AppDate"] != null)
            {
                var customColumn = jobCreatedDatagridview.Columns["AppDate"];
                customColumn.HeaderText = "วันที่อนุมัติ";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (jobCreatedDatagridview.Columns["StartDate"] != null)
            {
                jobCreatedDatagridview.Columns["StartDate"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["EquipmentStatus"] != null)
            {
                var customColumn = jobCreatedDatagridview.Columns["EquipmentStatus"];
                customColumn.HeaderText = "สถานะอุปกรณ์";
                customColumn.Width = 100;
            }
            if (jobCreatedDatagridview.Columns["Cost"] != null)
            {
                jobCreatedDatagridview.Columns["Cost"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["EStatusID"] != null)
            {
                jobCreatedDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["JobStatus"] != null)
            {
                jobCreatedDatagridview.Columns["JobStatus"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["JDetails"] != null)
            {
                var customColumn = jobCreatedDatagridview.Columns["JDetails"];
                customColumn.HeaderText = "รายละเอียดการแจ้งซ่อม";
                customColumn.Width = 150;
            }
            if (jobCreatedDatagridview.Columns["VendorName"] != null)
            {
                jobCreatedDatagridview.Columns["VendorName"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["CasePhoto"] != null)
            {
                var customColumn = jobCreatedDatagridview.Columns["CasePhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 60;
            }
        }
        //Update gridview Job Processed
        private void UpdateProcessedJobView()
        {
            if (alljobInProcessViewList != null)
            {
                alljobInProcessViewList.Clear();
            }
            alljobInProcessViewList = AllJobInProcessView.GetProcessedJobView();
            List<int> filterEStatusIds = new List<int> {9};
            jobfilteredList = FilterJobListByEStatusId(alljobInProcessViewList, filterEStatusIds);
            jobProcessedBindingSource.DataSource = jobfilteredList;

            jobProcessingDatagridview.DataSource = jobProcessedBindingSource;
            FormatJobProceesedDataGridView();
        }
        private void FormatJobProceesedDataGridView()
        {
            if (jobProcessingDatagridview.Columns["ID"] != null)
            {
                jobProcessingDatagridview.Columns["ID"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["JobEquipmentName"] != null)
            {
                var customColumn = jobProcessingDatagridview.Columns["JobEquipmentName"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (jobProcessingDatagridview.Columns["JobEquipmentSerial"] != null)
            {
                var customColumn = jobProcessingDatagridview.Columns["JobEquipmentSerial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
            }
            if (jobProcessingDatagridview.Columns["AppDate"] != null)
            {
                jobProcessingDatagridview.Columns["AppDate"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["StartDate"] != null)
            {
                var customColumn = jobProcessingDatagridview.Columns["StartDate"];
                customColumn.HeaderText = "วันที่เริ่มงาน";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (jobProcessingDatagridview.Columns["EquipmentStatus"] != null)
            {
                jobProcessingDatagridview.Columns["EquipmentStatus"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["Cost"] != null)
            {
                var customColumn = jobProcessingDatagridview.Columns["Cost"];
                customColumn.HeaderText = "ค่าใช้จ่าย";
                customColumn.Width = 70;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (jobProcessingDatagridview.Columns["EStatusID"] != null)
            {
                jobProcessingDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["JobStatus"] != null)
            {
                jobProcessingDatagridview.Columns["JobStatus"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["JDetails"] != null)
            {
                jobProcessingDatagridview.Columns["JDetails"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["VendorName"] != null)
            {
                var customColumn = jobProcessingDatagridview.Columns["VendorName"];
                customColumn.HeaderText = "ชื่อผู้รับเหมา / ผู้ซ่อม";
                customColumn.Width = 180;
            }
            if (jobProcessingDatagridview.Columns["CasePhoto"] != null)
            {
                var customColumn = jobProcessingDatagridview.Columns["CasePhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 60;
            }
        }
        //Update gridview Plan Created
        private void UpdateCreatedPlanView()
        {
            if(planCreatedViewList != null)
            {
                planCreatedViewList.Clear();
            }
            planCreatedViewList = AllPlanView.GetCreatedPlanView();
            planCreatedBindingSource.DataSource = planCreatedViewList;
            currentMaintainencePlanDatagridview.DataSource = planCreatedBindingSource;

            FormatPlanCreatedDataGridView();
        }
        private void FormatPlanCreatedDataGridView()
        {
            if (currentMaintainencePlanDatagridview.Columns["ID"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["ID"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["EID"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["EID"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["EName"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["EName"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (currentMaintainencePlanDatagridview.Columns["ESerial"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["ESerial"];
                customColumn.HeaderText = "ชื่อบัญชี";
                customColumn.Width = 70;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (currentMaintainencePlanDatagridview.Columns["PType"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["PType"];
                customColumn.HeaderText = "ประเภทแผน";
                customColumn.Width = 85;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (currentMaintainencePlanDatagridview.Columns["PPeriod"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["PPeriod"];
                customColumn.HeaderText = "รอบ";
                customColumn.Width = 70;
            }
            if (currentMaintainencePlanDatagridview.Columns["DateTodo"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["DateTodo"];
                customColumn.HeaderText = "กำหนดการ";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (currentMaintainencePlanDatagridview.Columns["PlanStatus"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["PlanStatus"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["PlanProcessDate"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["PlanProcessDate"];
                customColumn.HeaderText = "ครั้งล่าสุด";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
            }
            if (currentMaintainencePlanDatagridview.Columns["EPhoto"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["EPhoto"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["OPlacePhoto"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["OPlacePhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 35;
            }
            if (currentMaintainencePlanDatagridview.Columns["OplaceDetails"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["OplaceDetails"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["EStatus"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["EStatus"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["PPeriodID"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["PPeriodID"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["EStatusID"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["DaysRemainning"] != null)
            {
                var customColumn = currentMaintainencePlanDatagridview.Columns["DaysRemainning"];
                customColumn.HeaderText = "เหลือวัน";
                customColumn.Width = 70;
            }
            if (currentMaintainencePlanDatagridview.Columns["PlanStatusText"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["PlanStatusText"].Visible = false;
            }
            if (currentMaintainencePlanDatagridview.Columns["ETypeID"] != null)
            {
                currentMaintainencePlanDatagridview.Columns["ETypeID"].Visible = false;
            }
        }
        //Update gridview Plan Proceesed
        private void UpdateProcessedPlanView()
        {
            if(planProceessedViewList != null)
            {
                planProceessedViewList.Clear();
            }
            planProceessedViewList = AllProcessInPlanView.GetProcessInPlanView();
            planProccessedBindingSource.DataSource = planProceessedViewList;
            planProcessingDatagridview.DataSource = planProccessedBindingSource;

            FormatProcessInPlanDataGridView();
        }
        private void FormatProcessInPlanDataGridView()
        {
            if(planProcessingDatagridview.Columns["ID"] != null)
            {
                planProcessingDatagridview.Columns["ID"].Visible = false; 
            }
            if(planProcessingDatagridview.Columns["PID"] != null)
            {
                planProcessingDatagridview.Columns["PID"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["EID"] != null)
            {
                planProcessingDatagridview.Columns["EID"].Visible = false;
            }
            if(planProcessingDatagridview.Columns["EName"] != null)
            {
                var customColumn = planProcessingDatagridview.Columns["EName"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 200;
            }
            if (planProcessingDatagridview.Columns["ESerial"] != null)
            {
                var customColumn = planProcessingDatagridview.Columns["ESerial"];
                customColumn.HeaderText = "ชื่อบัญชี";
            }
            if (planProcessingDatagridview.Columns["PType"] != null)
            {
                var customColumn = planProcessingDatagridview.Columns["PType"];
                customColumn.HeaderText = "ประเภทแผน";
                customColumn.Width = 85;
                customColumn.HeaderCell.Style.Font = new Font("Arial", 10, FontStyle.Regular);
            }
            if (planProcessingDatagridview.Columns["ProcessDate"] != null)
            {
                var customColumn = planProcessingDatagridview.Columns["ProcessDate"];
                customColumn.HeaderText = "วันที่เริ่ม";
                customColumn.DefaultCellStyle.Format = "MMM dd, yyy";
                customColumn.Width = 80;
            }
            if (planProcessingDatagridview.Columns["REID"] != null)
            {
                planProcessingDatagridview.Columns["REID"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["ProcessDate"] != null)
            {
                var customColumn = planProcessingDatagridview.Columns["REName"];
                customColumn.HeaderText = "อุปกรณ์ทดแทน";
                customColumn.Width = 200;
            }
            if (planProcessingDatagridview.Columns["RESerial"] != null)
            {
                planProcessingDatagridview.Columns["RESerial"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["ContractPhoto"] != null)
            {
                var customColumn = planProcessingDatagridview.Columns["ContractPhoto"];
                customColumn.HeaderText = "รูป";
                customColumn.Width = 28;
            }
            if (planProcessingDatagridview.Columns["EPhotoPath"] != null)
            {
                planProcessingDatagridview.Columns["EPhotoPath"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["StartDetails"] != null)
            {
                planProcessingDatagridview.Columns["StartDetails"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["VenderName"] != null)
            {
                planProcessingDatagridview.Columns["VenderName"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["VenderDetails"] != null)
            {
                planProcessingDatagridview.Columns["VenderDetails"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["Cost"] != null)
            {
                planProcessingDatagridview.Columns["Cost"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["WorkPermit"] != null)
            {
                planProcessingDatagridview.Columns["WorkPermit"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["FinishDate"] != null)
            {
                planProcessingDatagridview.Columns["FinishDate"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["FinishDetails"] != null)
            {
                planProcessingDatagridview.Columns["FinishDetails"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["FinishDocuments"] != null)
            {
                planProcessingDatagridview.Columns["FinishDocuments"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["EStatusID"] != null)
            {
                planProcessingDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (planProcessingDatagridview.Columns["REPhotoPath"] != null)
            {
                planProcessingDatagridview.Columns["REPhotoPath"].Visible = false;
            }
        }
        //Method to filter Equipment status ID
        private List<AllJobInProcessView> FilterJobListByEStatusId(List<AllJobInProcessView> jobList, List<int> eStatusIds)
        {
            List<AllJobInProcessView> filteredList = new List<AllJobInProcessView>();
            foreach (AllJobInProcessView job in jobList)
            {
                if (eStatusIds.Contains(job.EStatusID))
                {
                    filteredList.Add(job);
                }
            }
            return filteredList;
        }
        //Install
        private void installationButton_Click(object sender, EventArgs e)
        {
            installRquipment = new InstallationEquipment();
            installRquipment.Owner = main;
            installRquipment.ShowDialog();
        }
        //Equipment List
        private void equipmentListButton_Click(object sender, EventArgs e)
        {
            equipmentList = new EquipmentList();
            equipmentList.Owner = main;
            equipmentList.UpdateGrid += OnUpdateCreatedPlan;
            equipmentList.ShowDialog();

            UpdateCreatedJobView();
            UpdateProcessedJobView();
            UpdateCreatedPlanView();
            UpdateProcessedPlanView();
        }
        //Create Job
        private void createJobButton_Click(object sender, EventArgs e)
        {
            jobCreate = new CreateJobForm();
            jobCreate.Owner = main;
            jobCreate.UpdateGrid += OnUpdateCreatedJob;
            jobCreate.UpdateGrid += OnUpdateCreatedPlan;
            jobCreate.ShowDialog();
        }
        //Remove Job
        private void removeJobButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobCreatedDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                jobRemove = new RemoveJobForm();
                jobRemove.Owner = main;
                jobRemove.UpdateGrid += OnUpdateCreatedJob;
                jobRemove.UpdateGrid += OnUpdateCreatedPlan;
                jobRemove.ShowDialog();
            }    
        }
        //Edit Job
        private void editJobButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobCreatedDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                jobEdit = new EditJobForm();
                jobEdit.Owner = main;
                jobEdit.UpdateGrid += OnUpdateCreatedJob;
                jobEdit.ShowDialog();
                //Clear list for selected Job
                Global.selectedEquipmentInJob = null;
            }
        }
        //Job processing
        private void jobProcessingButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobCreatedDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                jobProcessing = new JobProcessing();
                jobProcessing.Owner = main;
                jobProcessing.UpdateGrid += OnUpdateCreatedJob;
                jobProcessing.UpdateGrid += OnUpdateProcessJob;
                jobProcessing.ShowDialog();
            }          
        }
        //Job acceptation
        private void jobAcceptationButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobProcessingDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                jobAcceptation = new JobAcceptation();
                jobAcceptation.Owner = main;
                jobAcceptation.UpdateGrid += OnUpdateProcessJob;
                jobAcceptation.UpdateGrid += OnUpdateCreatedPlan;
                jobAcceptation.ShowDialog();
            }    
        }
        //Edit Job processing
        private void editJobProcessingButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobProcessingDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                editJobProcessing = new EditJobProcessing();
                editJobProcessing.Owner = main;
                editJobProcessing.UpdateGrid += OnUpdateProcessJob;
                editJobProcessing.ShowDialog();
            }
        }
        //Remove Job processing
        private void removeJobProcessingbutton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobProcessingDatagridview.CurrentRow;
            if (selectedRow!=null)
            {
                Global.ID = (int)selectedRow.Cells["ID"].Value;
                removejobprocessing = new removeJobProcessing();
                removejobprocessing.Owner = main;
                removejobprocessing.UpdateGrid += OnUpdateProcessJob;
                removejobprocessing.UpdateGrid += OnUpdateCreatedPlan;
                removejobprocessing.ShowDialog();
            }
        }
        //Create Equipment Plan
        private void createPlanButton_Click(object sender, EventArgs e)
        {
            createPlan = new CreatePlanForm();
            createPlan.Owner = main;
            createPlan.UpdateGrid += OnUpdateCreatedPlan;
            createPlan.ShowDialog();
        }
        //Edit Equipment Plan
        private void editPlanButton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInPlan = null;
            DataGridViewRow selectedRow = currentMaintainencePlanDatagridview.CurrentRow;
            
            if (selectedRow != null)
            {
                AllPlanView selectedPlan = (AllPlanView)selectedRow.DataBoundItem;
                Global.selectedEquipmentInPlan = selectedPlan;
                editPlan = new EditPlanForm();
                editPlan.Owner = main;
                editPlan.UpdateGrid += OnUpdateCreatedPlan;
                editPlan.ShowDialog();
            }
        }
        //Plan Processing
        private void planProcessingButton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInPlan = null;
            Global.selectedEquipmentInJob = null;
            DataGridViewRow selectedRow = currentMaintainencePlanDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                AllPlanView selectedPlan = (AllPlanView)selectedRow.DataBoundItem;
                Global.selectedEquipmentInPlan = selectedPlan;
                planProcessing = new PlanProcessingForm();
                planProcessing.Owner = main;
                planProcessing.UpdateGrid += OnUpdateCreatedPlan;
                planProcessing.UpdateGrid += OnUpdateProcessedPlan;
                planProcessing.ShowDialog();
            }
        }
        //Edit Plan Processing
        private void editPlanProcessButton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInProcessedPlan = null;
            Global.selectedEquipmentInJob = null;
            DataGridViewRow selectedRow = planProcessingDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                AllProcessInPlanView selectedPlan = (AllProcessInPlanView)selectedRow.DataBoundItem;
                Global.selectedEquipmentInProcessedPlan = selectedPlan;
                editPlanProcessing = new EditPlanProcessing();
                editPlanProcessing.Owner = main;
                editPlanProcessing.UpdateGrid += OnUpdateProcessedPlan;
                editPlanProcessing.ShowDialog();
            }
        }
        //Complete & Remove plan
        private void completeOrRemovePlanButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = currentMaintainencePlanDatagridview.CurrentRow;
            if (selectedRow != null)
            {
                DialogResult result = MessageBox.Show("ต้องการลบแผน หรือไม่", "ยืนยันการลบแผน", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    int pid = (int)selectedRow.Cells["ID"].Value;
                    int eid = (int)selectedRow.Cells["EID"].Value;
                    ObjectClass.Plan plan = new ObjectClass.Plan(pid);
                    if (plan.Remove())
                    {
                        Equipment eq = new Equipment(eid);
                        if(eq.EStatusObj.ID == 6)
                        {
                            EquipmentStatus newEs = new EquipmentStatus(2);
                            eq.EStatusObj = newEs;
                            eq.OnPlan = false;
                            if (eq.Change())
                            {
                                ShowCustomMessageBox("ลบแผนเสร็จสิ้น เปลี่ยนสถานะอุปกรณ์เป็น" + Environment.NewLine + "กำลังปฎิบัติงาน");
                            }
                            else
                            {

                                ShowCustomMessageBox("ลบแผนเสร็จสิ้น แต่ล้มเหลวในการเปลี่ยนสถานะอุปกรณ์");
                            }
                        }
                        else
                        {
                            EquipmentStatus newEs = new EquipmentStatus(1);
                            eq.EStatusObj = newEs;
                            eq.OnPlan = false;
                            if (eq.Change())
                            {
                                ShowCustomMessageBox("ลบแผนเสร็จสิ้น เปลี่ยนสถานะอุปกรณ์เป็น" + Environment.NewLine + "พร้อมใช้งาน");
                            }
                            else
                            {
                                ShowCustomMessageBox("ลบแผนเสร็จสิ้น แต่ล้มเหลวในการเปลี่ยนสถานะอุปกรณ์");
                            }
                        }
                    }
                    else
                    {
                        DialogResult result1 = MessageBox.Show("แผนนี้มีการดำเนินการไปแล้วจึงไม่สามารถลบได้ ต้องการสิ้นสุดแผนหรือไม่", "ยืนยันการสิ้นสุดแผน", 
                            MessageBoxButtons.OKCancel);
                        if(result1 == DialogResult.OK)
                        {
                            plan.PlanStatus = false;
                            Equipment eq = new Equipment(eid);
                            if (eq.EStatusObj.ID == 6)
                            {
                                EquipmentStatus newEs = new EquipmentStatus(2);
                                eq.EStatusObj = newEs;
                                eq.OnPlan = false;
                                if (eq.Change())
                                {
                                    ShowCustomMessageBox("ลบแผนเสร็จสิ้น เปลี่ยนสถานะอุปกรณ์เป็น" + Environment.NewLine + "กำลังปฎิบัติงาน");
                                }
                                else
                                {
                                    ShowCustomMessageBox("ลบแผนเสร็จสิ้น แต่ล้มเหลวในการเปลี่ยนสถานะอุปกรณ์");
                                }
                            }
                            else
                            {
                                EquipmentStatus newEs = new EquipmentStatus(1);
                                eq.EStatusObj = newEs;
                                eq.OnPlan = false;
                                if (eq.Change())
                                {
                                    ShowCustomMessageBox("ลบแผนเสร็จสิ้น เปลี่ยนสถานะอุปกรณ์เป็น" + Environment.NewLine + "พร้อมใช้งาน");
                                }
                                else
                                {
                                    ShowCustomMessageBox("ลบแผนเสร็จสิ้น แต่ล้มเหลวในการเปลี่ยนสถานะอุปกรณ์");
                                }
                            }
                        }
                    }
                }
                UpdateCreatedPlanView();
            }
            
        }
        //Complete Plan Processing
        private void completeOrRomovePlanProcessButton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInProcessedPlan = null;
            DataGridViewRow selectedRow = planProcessingDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                AllProcessInPlanView selectedPlan = (AllProcessInPlanView)selectedRow.DataBoundItem;
                Global.selectedEquipmentInProcessedPlan = selectedPlan;
                completePlanProcessing = new CompletePlanProcessing();
                completePlanProcessing.Owner = main;
                completePlanProcessing.UpdateGrid += OnUpdateCreatedPlan;
                completePlanProcessing.UpdateGrid += OnUpdateProcessedPlan;
                completePlanProcessing.ShowDialog();
            }
        }
        //Remove plan processing
        private void removePlanProcessButton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInProcessedPlan = null;
            DataGridViewRow selectedRow = planProcessingDatagridview.CurrentRow;
            if(selectedRow != null)
            {
                AllProcessInPlanView selectedPlan = (AllProcessInPlanView)selectedRow.DataBoundItem;
                Global.selectedEquipmentInProcessedPlan = selectedPlan;
                removePlanProcessingForm = new RemovePlanProcessingForm();
                removePlanProcessingForm.Owner = main;
                removePlanProcessingForm.UpdateGrid += OnUpdateCreatedPlan;
                removePlanProcessingForm.UpdateGrid += OnUpdateProcessedPlan;
                removePlanProcessingForm.ShowDialog();
            }
        }
        //Plan History
        private void planHistoryButton_Click(object sender, EventArgs e)
        {
            planHistoryForm = new Plan.PlanHistoryForm();
            planHistoryForm.Owner = main;
            planHistoryForm.ShowDialog();
        }
        //Zone Manage
        private void zMbutton_Click(object sender, EventArgs e)
        {
            zoneManageForm = new ZoneManageForm();
            zoneManageForm.Owner = main;
            zoneManageForm.ShowDialog();
        }
        //To Main Menu
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Global.warehouseID = 0;
            Close();
        }

        private void OnUpdateCreatedJob(object sender, EventArgs e)
        {
            UpdateCreatedJobView();
        }
        private void OnUpdateProcessJob(object sender, EventArgs e)
        {
            UpdateProcessedJobView();
        }
        private void OnUpdateCreatedPlan(object sender, EventArgs e)
        {
            UpdateCreatedPlanView();
        }
        private void OnUpdateProcessedPlan(object sender, EventArgs e)
        {
            UpdateProcessedPlanView();
        }

        //Methodto call custom message Box
        private void ShowCustomMessageBox(string message)
        {
            using (var messageBox = new CustomMessageBox())
            {
                messageBox.MessageText = message;
                var result = messageBox.ShowDialog();
            }
        }
        //Event highlighting row
        private void jobCreatedDatagridview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)jobCreatedDatagridview.Rows[e.RowIndex].Cells["EStatusID"].Value;

            Global.SetRowColor(jobCreatedDatagridview.Rows[e.RowIndex], statusID);
        }
        private void jobProcessingDatagridview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)jobProcessingDatagridview.Rows[e.RowIndex].Cells["EStatusID"].Value;

            Global.SetRowColor(jobProcessingDatagridview.Rows[e.RowIndex], statusID);
        }
        private void currentMaintainencePlanDatagridview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)currentMaintainencePlanDatagridview.Rows[e.RowIndex].Cells["DaysRemainning"].Value;

            Global.SetRowColorByDayRemainning(currentMaintainencePlanDatagridview.Rows[e.RowIndex], statusID);
        }
        private void planProcessingDatagridview_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)planProcessingDatagridview.Rows[e.RowIndex].Cells["EStatusID"].Value;

            Global.SetRowColor(planProcessingDatagridview.Rows[e.RowIndex], statusID);
        }
        //Searching plan
        private void equipmentListSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = PlanSearchTextBox.Text.ToLower();
            if (!string.IsNullOrEmpty(searchText))
            {
                var searchResults = planCreatedViewList
                    .Where(pl =>
                        pl.EName.ToLower().Contains(searchText) ||
                        pl.ESerial.ToLower().Contains(searchText)
                    ).ToList();

                planCreatedBindingSource.DataSource = searchResults;
                currentMaintainencePlanDatagridview.DataSource = planCreatedBindingSource;
            }
            else
            {
                UpdateCreatedPlanView();
            }
        }
    }
}
