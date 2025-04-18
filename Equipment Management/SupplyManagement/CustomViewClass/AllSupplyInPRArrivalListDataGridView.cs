using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllSupplyInPRArrivalListDataGridView
    {
        public int SupplyID { get; set; }
        public string SupplyName { get; set; }
        public int ReqW1 { get; set; }
        public int ArrW1 { get; set; }
        public DateTime? ArrDate1 { get; set; }
        public int ReqW2 { get; set; }
        public int ArrW2 { get; set; }
        public DateTime? ArrDate2 { get; set; }
        public int ReqW3 { get; set; }
        public int ArrW3 { get; set; }
        public DateTime? ArrDate3 { get; set; }
        public int ReqW4 { get; set; }
        public int ArrW4 { get; set; }
        public DateTime? ArrDate4 { get; set; }
        public int ReqAmount { get; set; }
        public int ArrAmount { get; set; }
        public int PRAmount { get; set; }
        public int RemainAmount { get; set; }
        public DateTime? DateW1 { get; set; }
        public DateTime? DateW2 { get; set; }
        public DateTime? DateW3 { get; set; }
        public DateTime? DateW4 { get; set; }

        AllSupplyInPRArrivalListDataGridView() { }

        public static List<AllSupplyInPRArrivalListDataGridView> SupplyInPlanByPR(PR pr)
        {
            List<AllSupplyInPRArrivalListDataGridView> sipraView = new List<AllSupplyInPRArrivalListDataGridView>();
            if (pr.Plan == null)
            {
                return sipraView;
            }
            else
            {
                List<SupplyInPR> sipr = SupplyInPR.GetAllSupplyInPRList(pr.ID);
                List<SupplyInPlan> sip = SupplyInPlan.GetAllSupplyInPlanByPlanID(pr.Plan.ID);
                List<SupplyInPRArrival> sipra = SupplyInPRArrival.GetAllSupplyInPRByPRID(pr.ID);
                sipraView = sipr.Select(siPR =>
                {
                    var matchingPlan = sip.FirstOrDefault(siP => siP.Supply.ID == siPR.Supply.ID);
                    var matchingArrivals = sipra.Where(siPRA => siPRA.SupplyID == siPR.Supply.ID).ToList();

                    var view = new AllSupplyInPRArrivalListDataGridView
                    {
                        SupplyID = siPR.Supply.ID,
                        SupplyName = siPR.Supply.SupplyName,
                        ReqW1 = matchingPlan?.ReqW1 ?? 0,
                        ReqW2 = matchingPlan?.ReqW2 ?? 0,
                        ReqW3 = matchingPlan?.ReqW3 ?? 0,
                        ReqW4 = matchingPlan?.ReqW4 ?? 0,
                        DateW1 = matchingPlan.DateW1,
                        DateW2 = matchingPlan.DateW2,
                        DateW3 = matchingPlan.DateW3,
                        DateW4 = matchingPlan.DateW4,
                    };
                    //Request in plan amount
                    int totalRequestAmount = (matchingPlan?.ReqW1 ?? 0) +
                                         (matchingPlan?.ReqW2 ?? 0) +
                                         (matchingPlan?.ReqW3 ?? 0) +
                                         (matchingPlan?.ReqW4 ?? 0);
                    view.ReqAmount = totalRequestAmount;
                    //Arrival amount
                    int totalArrivalAmount = matchingArrivals.Sum(arrival => arrival.Quantity);
                    view.ArrAmount = totalArrivalAmount;
                    //Request in PR amount
                    int totalSiprAmount = sipr.Where(s => s.Supply.ID == siPR.Supply.ID).Sum(s => s.Quantity);
                    view.PRAmount = totalSiprAmount;
                    //Remain amount
                    view.RemainAmount = totalSiprAmount - totalArrivalAmount;
                    // Dynamically map arrivals to the right weeks
                    int weekCounter = 1;
                    foreach (var arrival in matchingArrivals)
                    {
                        // Assign each arrival to the next available week (ArrW1, ArrW2, etc.)
                        var arrPropertyName = $"ArrW{weekCounter}";
                        var arrDatePropertyName = $"ArrDate{weekCounter}";

                        view.GetType().GetProperty(arrPropertyName)?.SetValue(view, arrival.Quantity);
                        view.GetType().GetProperty(arrDatePropertyName)?.SetValue(view, arrival.ArrivalDate);

                        weekCounter++;  // Increment to the next week (ArrW2, ArrW3, etc.)
                    }
                    return view;
                }).ToList();

                return sipraView;
            }
        }
    }
}
