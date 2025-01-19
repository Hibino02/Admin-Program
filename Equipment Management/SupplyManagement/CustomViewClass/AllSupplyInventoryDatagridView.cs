using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Admin_Program.SupplyManagement
{
    class AllSupplyInventoryDatagridView
    {
        public int ID { get; set; }
        public int SupplyID { get; set; }
        public string SupplyName { get; set; }
        public int Balance { get; set; }
        public int MOQ { get; set; }
        public string SupplyUnit { get; set; }
        public DateTime UpdateDate { get; set; }
        public string Updater { get; set; }
        public string SupplyPhoto { get; set; }

        public AllSupplyInventoryDatagridView() { }

        public static List<AllSupplyInventoryDatagridView> AllSupplyBalance()
        {
            List<AllSupplyInventoryDatagridView> sBalanceView = new List<AllSupplyInventoryDatagridView>();
            List<SupplyBalance> sBalance = SupplyBalance.GetAllSupplyBalanceList();

            // Group by SupplyID and select the most recent UpdateDate for each group
            var mostRecentBalances = sBalance
                .Where(sb => sb.Supply.UserGroup == GlobalVariable.Global.userGroup || GlobalVariable.Global.userGroup == "ADMIN")
                .GroupBy(sb => sb.Supply.ID)
                .Select(group => group.OrderByDescending(sb => sb.UpdateDate).First());

            foreach (SupplyBalance sb in mostRecentBalances)
            {
                if(sb.Supply.UserGroup == GlobalVariable.Global.userGroup || GlobalVariable.Global.userGroup == "ADMIN")
                {
                    AllSupplyInventoryDatagridView view = new AllSupplyInventoryDatagridView()
                    {
                        ID = sb.ID,
                        SupplyID = sb.Supply.ID,
                        SupplyName = sb.Supply.SupplyName,
                        Balance = sb.Balance,
                        MOQ = sb.Supply.MOQ,
                        SupplyUnit = sb.Supply.SupplyUnit,
                        UpdateDate = sb.UpdateDate,
                        Updater = sb.Updater,
                        SupplyPhoto = sb.Supply.SupplyPhoto
                    };
                    sBalanceView.Add(view);
                }
            }
            return sBalanceView;
        }
    }
}
