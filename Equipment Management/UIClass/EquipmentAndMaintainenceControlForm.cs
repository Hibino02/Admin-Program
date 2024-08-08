using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Equipment_Management.CustomViewClass;
using Equipment_Management.UIClass.InstallationSource;

namespace Equipment_Management.UIClass
{
    public partial class EquipmentAndMaintainenceControlForm : Form
    {
        MainBackGroundFrom main;

        private InstallationEquipment installRquipment;

        BindingSource jobCreatedBindingSource;
        BindingSource jobProcessedBindingSource;

        List<AllJobInProcessView> alljobInProcessViewList;
        List<AllJobInProcessView> jobfilteredList;

        public event EventHandler returnMain;
        public event EventHandler installationEquipment;

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
                jobProcessingDatagridview.Columns["StartDate"].DisplayIndex = 3;
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

        private void installationButton_Click(object sender, EventArgs e)
        {
            installRquipment = new InstallationEquipment();
            installRquipment.Owner = main;
            installRquipment.ShowDialog();
        }
        private void backToMainMenuButton_Click(object sender, EventArgs e)
        {
            returnMain?.Invoke(this, EventArgs.Empty);
            Close();
        }
    }
}
