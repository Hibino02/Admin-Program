using System;
using System.Collections.Generic;
using System.Linq;
using Equipment_Management.ObjectClass;

namespace Equipment_Management.CustomViewClass
{
    class AllPlanView
    {
        public int ID { get; set; }
        public int EID { get; set; }
        public string EName { get; set; }
        public string ESerial { get; set; }
        public string PType { get; set; }
        public int TimesDid { get; set; }
        public int TimesTodo { get; set; }
        public string PPeriod { get; set; }
        public DateTime? PlanProcessDate { get; set; }
        public DateTime DateTodo { get; set; }
        public bool PlanStatus { get; set; }     
        public string EPhoto { get; set; }
        public string OPlacePhoto { get; set; }
        public string OplaceDetails { get; set; }
        public string EStatus { get; set; }
        public int PPeriodID { get; set; }

        public AllPlanView(){}
        public AllPlanView(int id,int eid,string ename,string eserial,string ptype,string pperiod,
            int timestodo,DateTime datetodo,bool planstatus,string ephoto,string oplacephoto, 
            DateTime? planprocessdate,int timesdid,string oplacedetails,string estatus,int pperiodid)
        {
            this.ID = id;
            this.EID = eid;
            this.EName = ename;
            this.ESerial = eserial;
            this.PType = ptype;
            this.TimesDid = timesdid;
            this.TimesTodo = timestodo;
            this.PPeriod = pperiod;
            this.PlanProcessDate = planprocessdate;
            this.DateTodo = datetodo;
            this.PlanStatus = planstatus;
            this.EPhoto = ephoto;
            this.OPlacePhoto = oplacephoto;
            this.OplaceDetails = oplacedetails;
            this.EStatus = estatus;
            this.PPeriodID = pperiodid;
        }

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
                        int processCount = 0;//process counter

                        if (pplist != null)
                        {
                            foreach (PlanProcess pp in pplist)
                            {
                                if(pp.PlanID == p.ID)
                                {
                                    processCount++;

                                    if (!latestFinishDate.HasValue || (pp.FinishDate.HasValue && pp.FinishDate.Value >
                                        latestFinishDate.Value))
                                    {
                                        latestFinishDate = pp.FinishDate;
                                    }
                                }
                            }
                        }
                        AllPlanView view = new AllPlanView
                        {
                            ID = p.ID,
                            EID = p.Eqp.ID,
                            EName = p.Eqp.Name,
                            ESerial = p.Eqp.Serial,
                            PType = p.PType.PType,
                            PPeriod = p.PPeriod.PPeriod,
                            TimesDid = processCount,
                            TimesTodo = p.TimesToDo,
                            DateTodo = p.DateToDo.Value,
                            PlanStatus = p.PlanStatus,
                            EPhoto = p.Eqp.EPhotoPath,
                            OPlacePhoto = p.Eqp.OPlacePhotoPath,
                            OplaceDetails = p.Eqp.InstallationDetails,
                            EStatus = p.Eqp.EStatusObj.EStatus,
                            PPeriodID = p.PPeriod.ID,
                            PlanProcessDate = latestFinishDate
                        };
                        list.Add(view);
                    }
                }
            }
            return list.OrderBy(p => p.DateTodo).ToList();
        }
    }
}
