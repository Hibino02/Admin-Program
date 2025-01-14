using System.Collections.Generic;
using System.Linq;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllMonthListDataGridView
    {
        public int MonthID { get; set; }
        public string MonthName { get; set; }

        public AllMonthListDataGridView() { }

        public static List<AllMonthListDataGridView> AllMonth()
        {
            List<AllMonthListDataGridView> mView = new List<AllMonthListDataGridView>();
            List<ObjectClass.DeliveryMonth> allMonthList = ObjectClass.DeliveryMonth.getAllDeliveryMonthList();
            foreach(ObjectClass.DeliveryMonth monthView in allMonthList)
            {
                AllMonthListDataGridView view = new AllMonthListDataGridView
                {
                    MonthID = monthView.ID,
                    MonthName = monthView._Month
                };
                mView.Add(view);
            }
            return mView.OrderBy(dm => dm.MonthID).ToList();
        }
    }
}
