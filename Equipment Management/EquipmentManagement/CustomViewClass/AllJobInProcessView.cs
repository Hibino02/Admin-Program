using System;
using System.Collections.Generic;
using Admin_Program.ObjectClass;
using Admin_Program.GlobalVariable;

namespace Admin_Program.CustomViewClass
{
    class AllJobInProcessView
    {
        public int ID { get; set; }
        public string JobEquipmentName { get; set; }
        public string JobEquipmentSerial { get; set; }
        public DateTime? AppDate { get; set; }
        public DateTime? StartDate { get; set; }
        public string EquipmentStatus { get; set; }
        public string Cost { get; set; }
        public int EStatusID { get; set; }        
        public bool JobStatus { get; set; }
        public string JDetails { get; set; }
        public string VendorName { get; set; }
        public string CasePhoto { get; set; }

        public AllJobInProcessView() { }
        public AllJobInProcessView(int id,string JEName, string JESerial, DateTime? appDate, DateTime Startdate, 
            string Estatus,int Estatusid,bool jobstatus,string casephoto,string jdetails,string vendorname,string cost)
        {
            this.ID = id;
            this.JobEquipmentName = JEName;
            this.JobEquipmentSerial = JESerial;
            this.AppDate = appDate;
            this.StartDate = Startdate;
            this.EquipmentStatus = Estatus;
            this.Cost = cost;
            this.EStatusID = Estatusid;
            this.JobStatus = jobstatus;
            this.JDetails = jdetails;
            this.VendorName = vendorname;
            this.CasePhoto = casephoto;
        }

        // Method to load and transform Job objects into AllJobInProcessView objects
        public static List<AllJobInProcessView> GetCreatedJobView()
        {
            List<AllJobInProcessView> jobInProcessViews = new List<AllJobInProcessView>();
            foreach (Job j in Job.GetJobList())
            {
                if (j.JobStatus == false)
                {
                    AllJobInProcessView view = new AllJobInProcessView
                    {
                        ID = j.ID,
                        JobEquipmentName = j.JEq.Name,
                        JobEquipmentSerial = j.JEq.Serial,
                        AppDate = j.ADate,
                        EquipmentStatus = j.JEq.EStatusObj.EStatus,
                        EStatusID = j.JEq.EStatusObj.ID,
                        JDetails = j.JDetails,
                        CasePhoto = j.CasePhoto,
                    };
                    jobInProcessViews.Add(view);
                }    
            }
            return jobInProcessViews;
        }
        public static List<AllJobInProcessView> GetProcessedJobView()
        {
            List<AllJobInProcessView> jobInProcessViews = new List<AllJobInProcessView>();
            foreach (Job j in Job.GetJobList())
            {
                if(j.JobStatus == false)
                {
                    AllJobInProcessView view = new AllJobInProcessView
                    {
                        ID = j.ID,
                        JobEquipmentName = j.JEq.Name,
                        JobEquipmentSerial = j.JEq.Serial,
                        StartDate = j.StartDate,
                        Cost = j.Cost.ToString("F2"),
                        EquipmentStatus = j.JEq.EStatusObj.EStatus,
                        EStatusID = j.JEq.EStatusObj.ID,
                        JDetails = j.JDetails,
                        VendorName = j.VendName,
                        CasePhoto = j.CasePhoto,
                    };
                    jobInProcessViews.Add(view);
                }
            }
            return jobInProcessViews;
        }
    }
}
