using System;
using System.Collections.Generic;
using System.Linq;
using Admin_Program.ObjectClass;

namespace Admin_Program.CustomViewClass
{
    class AllPlanView
    {
        public int ID { get; set; }
        public int EID { get; set; }
        public string EName { get; set; }
        public string ESerial { get; set; }
        public string PType { get; set; }
        public string PPeriod { get; set; }
        public DateTime? PlanProcessDate { get; set; }
        public DateTime DateTodo { get; set; }
        public int DaysRemainning { get; set; }
        public bool PlanStatus { get; set; }     
        public string EPhoto { get; set; }
        public string OplaceDetails { get; set; }
        public string EStatus { get; set; }
        public int PPeriodID { get; set; }
        public int EStatusID { get; set; }
        //Custom property
        public string PlanStatusText
        {
            get
            {
                return PlanStatus ? "ดำเนินการ" : "สิ้นสุด";
            }
        }
        public string OPlacePhoto { get; set; }
        public int ETypeID { get; set; }

        public AllPlanView(){}

        public static List<AllPlanView> GetCreatedPlanView()
        {
            List<AllPlanView> list = new List<AllPlanView>();
            List<PlanProcess> pplist = PlanProcess.GetPlanProcessList();
            foreach (Plan p  in Plan.GetPlanList())
            {
                if (p.PlanStatus)
                {
                    if(p.Eqp.EStatusObj.ID == 6 || p.Eqp.EStatusObj.ID == 7)
                    {
                        DateTime? latestFinishDate = null;

                        if (pplist != null)
                        {
                            foreach (PlanProcess pp in pplist)
                            {
                                if(pp.PlanID == p.ID)
                                {
                                    if (!latestFinishDate.HasValue || (pp.FinishDate.HasValue && pp.FinishDate.Value >
                                        latestFinishDate.Value))
                                    {
                                        latestFinishDate = pp.FinishDate;
                                    }
                                }
                            }
                        }
                        TimeSpan? countdown = p.DateToDo.Value - DateTime.Now;
                        int daysRemainning = countdown.HasValue ? countdown.Value.Days : 0;
                        AllPlanView view = new AllPlanView
                        {
                            ID = p.ID,
                            EID = p.Eqp.ID,
                            EName = p.Eqp.Name,
                            ESerial = p.Eqp.Serial,
                            PType = p.PType.PType,
                            PPeriod = p.PPeriod.PPeriod,
                            DateTodo = p.DateToDo.Value,
                            PlanStatus = p.PlanStatus,
                            EPhoto = p.Eqp.EPhotoPath,
                            OPlacePhoto = p.Eqp.OPlacePhotoPath,
                            OplaceDetails = p.Eqp.InstallationDetails,
                            EStatus = p.Eqp.EStatusObj.EStatus,
                            PPeriodID = p.PPeriod.ID,
                            PlanProcessDate = latestFinishDate,
                            DaysRemainning = daysRemainning,
                            EStatusID = p.Eqp.EStatusObj.ID
                        };
                        list.Add(view);
                    }
                }
            }
            return list.OrderBy(p => p.DateTodo).ToList();
        }
        public static List<AllPlanView> GetAllPlanHistoryView()
        {
            List<AllPlanView> list = new List<AllPlanView>();
            List<PlanProcess> pplist = PlanProcess.GetPlanProcessList();
            foreach (Plan p in Plan.GetPlanList())
            {
                DateTime? latestFinishDate = null;

                if (pplist != null)
                {
                    foreach (PlanProcess pp in pplist)
                    {
                        if (pp.PlanID == p.ID)
                        {
                            if (!latestFinishDate.HasValue || (pp.FinishDate.HasValue && pp.FinishDate.Value >
                                latestFinishDate.Value))
                            {
                                latestFinishDate = pp.FinishDate;
                            }
                        }
                    }
                }
                TimeSpan? countdown = p.DateToDo.Value - DateTime.Now;
                int daysRemainning = countdown.HasValue ? countdown.Value.Days : 0;
                AllPlanView view = new AllPlanView
                {
                    ID = p.ID,
                    EID = p.Eqp.ID,
                    EName = p.Eqp.Name,
                    ESerial = p.Eqp.Serial,
                    PType = p.PType.PType,
                    PPeriod = p.PPeriod.PPeriod,
                    DateTodo = p.DateToDo.Value,
                    PlanStatus = p.PlanStatus,
                    EPhoto = p.Eqp.EPhotoPath,
                    OPlacePhoto = p.Eqp.OPlacePhotoPath,
                    OplaceDetails = p.Eqp.InstallationDetails,
                    EStatus = p.Eqp.EStatusObj.EStatus,
                    PPeriodID = p.PPeriod.ID,
                    PlanProcessDate = latestFinishDate,
                    DaysRemainning = daysRemainning,
                    EStatusID = p.Eqp.EStatusObj.ID,
                    ETypeID = p.Eqp.ETypeObj.ID
                };
                list.Add(view);
            }
            return list.OrderBy(p => p.DateTodo).ToList();
        }
    }
}
