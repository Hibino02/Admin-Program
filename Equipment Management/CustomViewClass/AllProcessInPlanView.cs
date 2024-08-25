using System;
using System.Collections.Generic;
using System.Linq;
using Equipment_Management.ObjectClass;

namespace Equipment_Management.CustomViewClass
{
    class AllProcessInPlanView
    {
        public int ID { get; set; }
        public int PID { get; set; }
        public int EID { get; set; }
        public string EName { get; set; }
        public string ESerial { get; set; }
        public string PType { get; set; }
        public DateTime ProcessDate { get; set; }
        public int? REID { get; set; }
        public string REName { get; set; }
        public string RESerial { get; set; }
        public string ContractPhoto { get; set; }
        public string EPhotoPath { get; set; }
        public string VenderName { get; set; }
        public string StartDetails { get; set; }
        public string VenderDetails { get; set; }
        public double Cost { get; set; }
        public string WorkPermit { get; set; }
        public DateTime? FinishDate { get; set; }
        public string FinishDetails { get; set; }
        public string FinishDocuments { get; set; }
        public int EStatusID { get; set; }

        public AllProcessInPlanView() { }

        public static List<AllProcessInPlanView> GetProcessInPlanView()
        {
            List<AllProcessInPlanView> list = new List<AllProcessInPlanView>();
            List<PlanProcess> pplist = PlanProcess.GetPlanProcessList();
            foreach (Plan p in Plan.GetPlanList())
            {
                if (p.PlanStatus && p.Eqp.EStatusObj.ID == 8)
                {
                    PlanProcess latestProcess = pplist.Where(pp => pp.PlanID == p.ID)
                        .OrderByDescending(pp => pp.ID).FirstOrDefault();
                    if (latestProcess != null)
                    {
                        AllProcessInPlanView processView = new AllProcessInPlanView
                        {
                            ID = latestProcess.ID,
                            PID = p.ID,
                            EID = p.Eqp.ID,
                            EName=p.Eqp.Name,
                            ESerial=p.Eqp.Serial,
                            PType=p.PType.PType,
                            ProcessDate=latestProcess.ProcessDate,
                            REID=latestProcess.RE?.ID,
                            REName=latestProcess.RE?.Name,
                            RESerial=latestProcess.RE?.Serial,
                            ContractPhoto=latestProcess.Contract,
                            EPhotoPath=p.Eqp.EPhotoPath,
                            StartDetails=latestProcess.StartDetails,
                            VenderName=latestProcess.PSup,
                            VenderDetails=latestProcess.PSupDetails,
                            Cost=latestProcess.Cost,
                            WorkPermit=latestProcess.WorkPermit,
                            EStatusID = p.Eqp.EStatusObj.ID
                        };
                        list.Add(processView);
                    }
                }
            }
            return list;
        }
        public static List<AllProcessInPlanView> GetAllProcessInlan(int planid)
        {
            List<AllProcessInPlanView> list = new List<AllProcessInPlanView>();
            List<PlanProcess> pplist = PlanProcess.GetPlanProcessList();
            foreach(PlanProcess pp in pplist)
            {
                if(pp.PlanID == planid)
                {
                    AllProcessInPlanView processView = new AllProcessInPlanView
                    {
                        ID = pp.ID,
                        ProcessDate = pp.ProcessDate,
                        REName = pp.RE?.Name,
                        RESerial = pp.RE?.Serial,
                        ContractPhoto = pp.Contract,
                        StartDetails = pp.StartDetails,
                        VenderName = pp.PSup,
                        VenderDetails = pp.PSupDetails,
                        Cost = pp.Cost,
                        WorkPermit = pp.WorkPermit,
                        FinishDate = pp.FinishDate,
                        FinishDetails = pp.FinishDetails,
                        FinishDocuments = pp.FinishDoc
                    };
                    list.Add(processView);
                }
            }
            return list.OrderByDescending(p => p.ProcessDate).ToList();
        }
    }
}
