using System;
using System.Collections.Generic;
using System.Linq;
using Admin_Program.SupplyManagement.ObjectClass;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllSupplyInPlanListDataGridView
    {
        public int ID { get; set; }
        public int PlanID { get; set; }
        public int SupplyID { get; set; }
        public string SupplyName { get; set; }
        public int Balance { get; set; }
        public string SupplyUnit { get; set; }
        public DateTime UpdateDate { get; set; }
        public int QuantityW1 { get; set; }
        public int QuantityW2 { get; set; }
        public int QuantityW3 { get; set; }
        public int QuantityW4 { get; set; }

        public AllSupplyInPlanListDataGridView() { }

        public static List<AllSupplyInPlanListDataGridView> AllSupplyInPlan()
        {
            List<AllSupplyInPlanListDataGridView> sipView = new List<AllSupplyInPlanListDataGridView>();
            List<SupplyBalance> allSib = SupplyBalance.GetAllSupplyBalanceList();
            List<SupplyInPlan> allSip = SupplyInPlan.GetAllSupplyInPlanList();

            // Group by SupplyID and select the most recent UpdateDate for each group
            var mostRecent = allSib
                .Where(sb => sb.Supply.UserGroup == GlobalVariable.Global.userGroup || GlobalVariable.Global.userGroup == "ADMIN")
                .GroupBy(sb => sb.Supply.ID)
                .Select(group => group.OrderByDescending(sb => sb.UpdateDate).First());

            foreach (SupplyBalance sib in mostRecent)
            {
                foreach(SupplyInPlan sip in allSip)
                {
                    if(sib.Supply.ID == sip.Supply.ID)
                    {
                        AllSupplyInPlanListDataGridView view = new AllSupplyInPlanListDataGridView
                        {
                            ID = sip.ID,
                            PlanID = sip.PlanID,
                            SupplyID = sip.Supply.ID,
                            SupplyName = sip.Supply.SupplyName,
                            Balance = sib.Balance,
                            SupplyUnit = sib.Supply.SupplyUnit,
                            UpdateDate = sib.UpdateDate,
                            QuantityW1 = sip.ReqW1,
                            QuantityW2 = sip.ReqW2,
                            QuantityW3 = sip.ReqW3,
                            QuantityW4 = sip.ReqW4
                        };
                        sipView.Add(view);
                    }
                }
            }
            return sipView.OrderBy(s=>s.SupplyName).ToList();
        }
    }
}
