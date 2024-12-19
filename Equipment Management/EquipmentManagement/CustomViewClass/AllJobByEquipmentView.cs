using System;
using System.Collections.Generic;
using Admin_Program.GlobalVariable;

namespace Admin_Program.CustomViewClass
{
    class AllJobByEquipmentView
    {
        public int ID { get; set; }
        public int EID { get; set; }
        public string JType { get; set; }
        public DateTime? SDate { get; set; }
        public DateTime? FDate { get; set; }
        public string VendorName { get; set; }
        public string VendorDetails { get; set; }
        public string JDetails { get; set; }
        public string Cost { get; set; }
        public string CasePhoto { get; set; }
        public bool JobStatus { get; set; }
        public string REName { get; set; }
        public string RESerial { get; set; }
        public string REPhoto { get; set; }
        public string FinPhoto { get; set; }
        public string JobDocument { get; set; }
        public string WorkPermit { get; set; }
        public string Contract { get; set; }
        public string FinDocument { get; set; }
        public string RepairDetails { get; set; }
        

        public AllJobByEquipmentView() { }

        public static List<AllJobByEquipmentView> GetAllJobByEquipmentView()
        {
            List<AllJobByEquipmentView> allJobByEquipmentView = new List<AllJobByEquipmentView>();
            foreach(ObjectClass.Job j in ObjectClass.Job.GetJobList())
            {
                if (j.JEq.ID == Global.ID && j.JobStatus == true)
                {
                    AllJobByEquipmentView view = new AllJobByEquipmentView
                    {
                        ID = j.ID,
                        EID = j.JEq.ID,
                        JType = j.JType.Type,
                        SDate = j.StartDate,
                        FDate = j.FinishDate,
                        VendorName = j.VendName,
                        VendorDetails = j.VendDetails,
                        REName = j.REq?.Name,
                        RESerial = j.REq?.Serial,
                        Cost = j.Cost.ToString("F2"),
                        CasePhoto = j.CasePhoto,
                        FinPhoto = j.FinishPhoto,
                        REPhoto = j.REq?.EPhotoPath,
                        JDetails = j.JDetails,
                        JobDocument = j.JDocument,
                        WorkPermit = j.WorkPermit,
                        Contract = j.Contract,
                        FinDocument = j.FinishDocument,
                        RepairDetails = j.RepairDetails
                    };
                    allJobByEquipmentView.Add(view);
                }
            }
            return allJobByEquipmentView;
        }
    }
}
