using System;
using System.Collections.Generic;
using Equipment_Management.ObjectClass;

namespace Equipment_Management.CustomViewClass
{
    class AllJobInProcessView
    {
        public int ID { get; set; }
        public string JobEquipmentName { get; set; }
        public string JobEquipmentSerial { get; set; }
        public DateTime? AppDate { get; set; }
        public string EquipmentStatus { get; set; }
        public int EStatusID { get; set; }
        public DateTime? StartDate { get; set; }

        // Default constructor
        public AllJobInProcessView() { }

        // Parameterized constructor
        public AllJobInProcessView(int id,string JEName, string JESerial, DateTime? appDate, DateTime Startdate, string Estatus,int Estatusid)
        {
            this.ID = id;
            this.JobEquipmentName = JEName;
            this.JobEquipmentSerial = JESerial;
            this.AppDate = appDate;
            this.StartDate = Startdate;
            this.EquipmentStatus = Estatus;
            this.EStatusID = Estatusid;
            
        }

        // Method to load and transform Job objects into AllJobInProcessView objects
        public static List<AllJobInProcessView> GetCreatedJobView()
        {
            List<AllJobInProcessView> jobInProcessViews = new List<AllJobInProcessView>();
            foreach (Job j in Job.GetJobList())
            {
                AllJobInProcessView view = new AllJobInProcessView
                {
                    ID = j.ID,
                    JobEquipmentName = j.JEq.Name,
                    JobEquipmentSerial = j.JEq.Serial,
                    AppDate = j.ADate,
                    EquipmentStatus = j.JEq.EStatusObj.EStatus,
                    EStatusID = j.JEq.EStatusObj.ID
                };
                jobInProcessViews.Add(view);
            }
            return jobInProcessViews;
        }
        public static List<AllJobInProcessView> GetProcessedJobView()
        {
            List<AllJobInProcessView> jobInProcessViews = new List<AllJobInProcessView>();
            foreach (Job j in Job.GetJobList())
            {
                AllJobInProcessView view = new AllJobInProcessView
                {
                    ID = j.ID,
                    JobEquipmentName = j.JEq.Name,
                    JobEquipmentSerial = j.JEq.Serial,
                    StartDate = j.StartDate,
                    EquipmentStatus = j.JEq.EStatusObj.EStatus,
                    EStatusID = j.JEq.EStatusObj.ID
                };
                jobInProcessViews.Add(view);
            }
            return jobInProcessViews;
        }
    }
}
