using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Equipment_Management.CustomViewClass;
using Equipment_Management.UIClass.InstallationSource;
using Equipment_Management.UIClass.EquipmentListSource;
using Equipment_Management.UIClass.Job;
using Equipment_Management.GlobalVariable;

namespace Equipment_Management.UIClass
{
    public partial class EquipmentAndMaintainenceControlForm : Form
    {
        MainBackGroundFrom main;
        //variable for calling other windows
        private InstallationEquipment installRquipment;
        private EquipmentList equipmentList;
        private CreateJobForm jobCreate;
        private RemoveJobForm jobRemove;
        private JobProcessing jobProcessing;
        private JobAcceptation jobAcceptation;
        private EditJobProcessing editJobProcessing;

        BindingSource jobCreatedBindingSource;
        BindingSource jobProcessedBindingSource;

        List<AllJobInProcessView> alljobInProcessViewList;
        List<AllJobInProcessView> jobfilteredList;

        public event EventHandler returnMain;

        public EquipmentAndMaintainenceControlForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Size = new Size(1450, 760);

            alljobInProcessViewList = new List<AllJobInProcessView>();
            jobfilteredList = new List<AllJobInProcessView>();
            //Job Created DataGridView section
            jobCreatedBindingSource = new BindingSource();
            jobCreatedDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateCreatedJobView();
            //Job Processing DataGridView section
            jobProcessedBindingSource = new BindingSource();
            jobProcessingDatagridview.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            UpdateProcessedJobView();
        }

        private void EquipmentAndMaintainenceControlForm_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
        //Job Created Methods section
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
            if (jobCreatedDatagridview.Columns["JobEquipmentName"] != null)
            {
                jobCreatedDatagridview.Columns["JobEquipmentName"].HeaderText = "ชื่ออุปกรณ์";
            }
            if (jobCreatedDatagridview.Columns["JobEquipmentSerial"] != null)
            {
                jobCreatedDatagridview.Columns["JobEquipmentSerial"].HeaderText = "Serial No.";
            }
            if (jobCreatedDatagridview.Columns["AppDate"] != null)
            {
                jobCreatedDatagridview.Columns["AppDate"].HeaderText = "วันที่อนุมัติแจ้งซ่อม";
                jobCreatedDatagridview.Columns["AppDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }
            if (jobCreatedDatagridview.Columns["EquipmentStatus"] != null)
            {
                jobCreatedDatagridview.Columns["EquipmentStatus"].HeaderText = "สถานะปัจจุบัน";
            }
            if (jobCreatedDatagridview.Columns["ID"] != null)
            {
                jobCreatedDatagridview.Columns["ID"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["EStatusID"] != null)
            {
                jobCreatedDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (jobCreatedDatagridview.Columns["StartDate"] != null)
            {
                jobCreatedDatagridview.Columns["StartDate"].Visible = false;
            }
        }
        //Job Processed Methods section
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
            if (jobProcessingDatagridview.Columns["JobEquipmentName"] != null)
            {
                jobProcessingDatagridview.Columns["JobEquipmentName"].HeaderText = "ชื่ออุปกรณ์";
            }
            if (jobProcessingDatagridview.Columns["JobEquipmentSerial"] != null)
            {
                jobProcessingDatagridview.Columns["JobEquipmentSerial"].HeaderText = "Serial No.";
            }
            if (jobProcessingDatagridview.Columns["StartDate"] != null)
            {
                jobProcessingDatagridview.Columns["StartDate"].HeaderText = "วันที่เริ่มงาน";
                jobProcessingDatagridview.Columns["StartDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
                jobProcessingDatagridview.Columns["StartDate"].DisplayIndex = 2;
            }
            if (jobProcessingDatagridview.Columns["EquipmentStatus"] != null)
            {
                jobProcessingDatagridview.Columns["EquipmentStatus"].HeaderText = "สถานะปัจจุบัน";
                jobProcessingDatagridview.Columns["EquipmentStatus"].DisplayIndex = 3;
            }
            if (jobProcessingDatagridview.Columns["ID"] != null)
            {
                jobProcessingDatagridview.Columns["ID"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["EStatusID"] != null)
            {
                jobProcessingDatagridview.Columns["EStatusID"].Visible = false;
            }
            if (jobProcessingDatagridview.Columns["AppDate"] != null)
            {
                jobProcessingDatagridview.Columns["AppDate"].Visible = false;
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
            equipmentList.ShowDialog();
        }
        //Create Job
        private void createJobButton_Click(object sender, EventArgs e)
        {
            jobCreate = new CreateJobForm();
            jobCreate.Owner = main;
            jobCreate.updateCreatedJobDatagridView += OnUpdateCreatedJob;
            jobCreate.ShowDialog();
        }
        //Remove Job
        private void removeJobButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobCreatedDatagridview.CurrentRow;
            Global.ID = (int)selectedRow.Cells["ID"].Value;
            jobRemove = new RemoveJobForm();
            jobRemove.Owner = main;
            jobRemove.UpdateGrid += OnUpdateCreatedJob;
            jobRemove.ShowDialog();
        }
        //Job processing
        private void jobProcessingButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobCreatedDatagridview.CurrentRow;
            Global.ID = (int)selectedRow.Cells["ID"].Value;
            jobProcessing = new JobProcessing();
            jobProcessing.Owner = main;
            jobProcessing.UpdateGrid += OnUpdateCreatedJob;
            jobProcessing.UpdateGrid += OnUpdateProcessJob;
            jobProcessing.ShowDialog();
        }
        //Job acceptation
        private void jobAcceptationButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobProcessingDatagridview.CurrentRow;
            Global.ID = (int)selectedRow.Cells["ID"].Value;
            jobAcceptation = new JobAcceptation();
            jobAcceptation.Owner = main;
            jobAcceptation.UpdateGrid += OnUpdateProcessJob;
            jobAcceptation.ShowDialog();
        }
        //Edit Job processing
        private void editJobProcessingButton_Click(object sender, EventArgs e)
        {
            Global.ID = -1;
            DataGridViewRow selectedRow = jobProcessingDatagridview.CurrentRow;
            Global.ID = (int)selectedRow.Cells["ID"].Value;
            editJobProcessing = new EditJobProcessing();
            editJobProcessing.Owner = main;
            editJobProcessing.UpdateGrid += OnUpdateProcessJob;
            editJobProcessing.ShowDialog();
        }
        //To Main Menu
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
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
    }
}
