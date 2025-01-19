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

        AllSupplyInPRArrivalListDataGridView() { }

        public static List<AllSupplyInPRArrivalListDataGridView> SupplyArrivalPlanBySupplyID(int prid)
        {
            List<AllSupplyInPRArrivalListDataGridView> sapbysidList = new List<AllSupplyInPRArrivalListDataGridView>();
            List<SupplyInPlan> sipList = SupplyInPlan.GetAllSupplyInPlanList();
            List<SupplyInPR> siprList = SupplyInPR.GetAllSupplyInPRList(prid);

            List<SupplyInPRArrival> sipraList = SupplyInPRArrival.GetAllSupplyInPRByPRID(prid);


            foreach (SupplyInPlan sip in sipList)
            {
                // Check for matching supply in PR arrival
                var matchedPlan = siprList.Where(s => s.Supply.ID == sip.Supply.ID).ToList();

                if (matchedPlan.Any())
                {
                    var pramount = matchedPlan.First().Quantity;
                    // Create a new entry
                    var newSupply = new AllSupplyInPRArrivalListDataGridView()
                    {
                        SupplyID = sip.Supply.ID,
                        SupplyName = sip.Supply.SupplyName,
                        ReqW1 = sip.ReqW1,
                        ReqW2 = sip.ReqW2,
                        ReqW3 = sip.ReqW3,
                        ReqW4 = sip.ReqW4,
                        ReqAmount = (sip.ReqW1 + sip.ReqW2 + sip.ReqW3 + sip.ReqW4),
                        PRAmount = pramount,
                    };
                    if (sipraList != null)
                    {
                        var matchedArrival = sipraList.Where(s => s.SupplyID == newSupply.SupplyID).ToList();
                        int weekCounter = 1;
                        // Populate ArrW1 to ArrW4 and their corresponding dates
                        foreach (var s in matchedArrival)
                        {
                            if (s.ArrivalDate != null && s.Quantity > 0)
                            {
                                if (weekCounter == 1)
                                {
                                    newSupply.ArrW1 = s.Quantity;
                                    newSupply.ArrDate1 = s.ArrivalDate;
                                }
                                else if (weekCounter == 2)
                                {
                                    newSupply.ArrW2 = s.Quantity;
                                    newSupply.ArrDate2 = s.ArrivalDate;
                                }
                                else if (weekCounter == 3)
                                {
                                    newSupply.ArrW3 = s.Quantity;
                                    newSupply.ArrDate3 = s.ArrivalDate;
                                }
                                else if (weekCounter == 4)
                                {
                                    newSupply.ArrW4 = s.Quantity;
                                    newSupply.ArrDate4 = s.ArrivalDate;
                                }
                                weekCounter++;
                                if (weekCounter > 4) break;
                            }
                        }
                    }
                    newSupply.ArrAmount = newSupply.ArrW1 + newSupply.ArrW2 + newSupply.ArrW3 + newSupply.ArrW4;
                    newSupply.RemainAmount =  newSupply.ArrAmount - newSupply.PRAmount;
                    // Add to the result list
                    sapbysidList.Add(newSupply);
                }
            }
            return sapbysidList.OrderBy(s=>s.SupplyName).ToList();
        }
    }
}
