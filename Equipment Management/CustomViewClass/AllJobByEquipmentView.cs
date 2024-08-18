using System;
using System.Collections.Generic;
using Equipment_Management.GlobalVariable;

namespace Equipment_Management.CustomViewClass
{
    class AllJobByEquipmentView
    {
        public int ID { get; set; }
        public int EID { get; set; }
        public string JType { get; set; }
        public DateTime? SDate { get; set; }
        public DateTime? FDate { get; set; }
        public string VendorName { get; set; }
        public string JDetails { get; set; }
        public string Cost { get; set; }
        public string CasePhoto { get; set; }
        public bool JobStatus { get; set; }
        public string REName { get; set; }
        public string RESerial { get; set; }
        public string FinPhoto { get; set; }

        public AllJobByEquipmentView() { }
        public AllJobByEquipmentView(int id,int eid,string jtype,DateTime? sdate,DateTime? fdate,string vendorname,
            string rename, string reserial,string cost,string casephoto,string finphoto,bool jobstatus,string jdetails)
        {
            this.ID = id;
            this.EID = eid;
            this.JType = jtype;
            this.SDate = sdate;
            this.FDate = fdate;
            this.VendorName = vendorname;
            this.JDetails = jdetails;
            this.Cost = cost;
            this.CasePhoto = casephoto;
            this.JobStatus = jobstatus;
            this.REName = rename;
            this.RESerial = reserial;
            this.FinPhoto = finphoto;
        }

        public static List<AllJobByEquipmentView> GetAllJobByEquipmentView()
        {
            List<AllJobByEquipmentView> allJobByEquipmentView = new List<AllJobByEquipmentView>();
            foreach(ObjectClass.Job j in ObjectClass.Job.GetJobList())
            {
                if(j.JEq.ID == Global.ID && j.JobStatus == true)
                {
                    AllJobByEquipmentView view = new AllJobByEquipmentView
                    {
                        ID = j.ID,
                        EID = j.JEq.ID,
                        JType = j.JType.Type,
                        SDate = j.StartDate,
                        FDate = j.FinishDate,
                        VendorName = j.VendName,
                        REName = j.REq?.Name,
                        RESerial = j.REq?.Serial,
                        Cost = j.Cost.ToString("F2"),
                        CasePhoto = j.CasePhoto,
                        FinPhoto = j.FinishPhoto,
                        JDetails = j.JDetails
                    };
                    allJobByEquipmentView.Add(view);
                }
            }
            return allJobByEquipmentView;
        }
    }
}
