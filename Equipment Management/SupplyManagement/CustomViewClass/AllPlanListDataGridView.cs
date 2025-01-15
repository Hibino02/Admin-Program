using System.Collections.Generic;
using System.Linq;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllPlanListDataGridView
    {
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public int MonthID { get; set; }
        public string MonthName { get; set; }

        public AllPlanListDataGridView() { }

        public static List<AllPlanListDataGridView> AllPlan()
        {
            List<AllPlanListDataGridView> pView = new List<AllPlanListDataGridView>();
            List<ObjectClass.DeliveryPlan> allPlan = ObjectClass.DeliveryPlan.GetAllDeliveryPlanList();
            foreach(ObjectClass.DeliveryPlan p in allPlan)
            {
                AllPlanListDataGridView view = new AllPlanListDataGridView
                {
                    PlanID = p.ID,
                    PlanName = p.PlanName,
                    MonthID = p._Month.ID,
                    MonthName = p._Month._Month
                };
                pView.Add(view);
            }
            return pView.OrderBy(p=>p.MonthID).ToList();
        }
    }
}
