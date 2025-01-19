using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class SupplyArrivalHistory
    {
        public int ID { get; set; }
        public int PRID { get; set; }
        public string SupplyName { get; set; }
        public int Quantity { get; set; }
        public string SupplyUnit { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public string InvoicePDF { get; set; }
        public string Recever { get; set; }
        public int SupplyID { get; set; }

        static List<Supply> allSupply = Supply.GetAllSupplyList();

        public SupplyArrivalHistory() { }

        public static List<SupplyArrivalHistory> allSupplyArrivalHistoryByPRID(int prid)
        {
            List<SupplyArrivalHistory> allsHistory = new List<SupplyArrivalHistory>();
            List<SupplyInPRArrival> siprAList = SupplyInPRArrival.GetAllSupplyInPRByPRID(prid);

            foreach (SupplyInPRArrival sipr in siprAList)
            {
                var matchSupply = allSupply.Where(s => s.ID == sipr.SupplyID).ToList();

                if (matchSupply.Any())
                {
                    var supply = matchSupply.First();
                    var view = new SupplyArrivalHistory()
                    {
                        ID = sipr.ID,
                        PRID = sipr.PRID,
                        SupplyName = supply.SupplyName,
                        Quantity = sipr.Quantity,
                        SupplyUnit = supply.SupplyUnit,
                        ArrivalDate = sipr.ArrivalDate,
                        InvoicePDF = sipr.InvoicePDF,
                        Recever = sipr.Recever,
                        SupplyID = sipr.SupplyID
                    };
                    allsHistory.Add(view);
                }
            }
            return allsHistory.OrderByDescending(h=>h.ArrivalDate).ToList();
        }
    }
}
