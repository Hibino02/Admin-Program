using System.Collections.Generic;
using System.Linq;
using Admin_Program.SupplyManagement.ObjectClass;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllSupplyListDataGridView
    {
        public int ID { get; set; }
        public string SupplyName { get; set; }
        public string SupplyUnit { get; set; }
        public int MOQ { get; set; }
        public bool IsActive { get; set; }
        public int SupplyTypeID { get; set; }
        public string SupplyTypeName { get; set; }
        public string SupplyPhoto { get; set; }

        public AllSupplyListDataGridView() { }
        public AllSupplyListDataGridView(int sid,string sname,string sunit)
        {
            ID = sid;
            SupplyName = sname;
            SupplyUnit = sunit;
        }

        public static List<AllSupplyListDataGridView> AllSupply()
        {
            List<AllSupplyListDataGridView> sViewList = new List<AllSupplyListDataGridView>();
            List<Supply> sList = Supply.GetAllSupplyList();
            foreach (Supply s in sList)
            {
                AllSupplyListDataGridView view = new AllSupplyListDataGridView
                {
                    ID = s.ID,
                    SupplyName = s.SupplyName,
                    SupplyUnit = s.SupplyUnit,
                    MOQ = s.MOQ,
                    IsActive = s.IsActive,
                    SupplyPhoto = s.SupplyPhoto,
                    SupplyTypeID = s.SupplyType.ID,
                    SupplyTypeName = s.SupplyType.TypeName
                };
                sViewList.Add(view);
            }
            return sViewList.OrderBy(s => s.SupplyName).ToList();
        }
    }
}
