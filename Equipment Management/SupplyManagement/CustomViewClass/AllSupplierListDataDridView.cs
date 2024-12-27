using System.Collections.Generic;
using System.Linq;
using Admin_Program.SupplyManagement.ObjectClass;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllSupplierListDataDridView
    {
        public int ID { get; set; }
        public string SupplierName { get; set; }
        public string SupplierAddress { get; set; }

        public AllSupplierListDataDridView() { }

        public static List<AllSupplierListDataDridView> AllSupplier()
        {
            List<AllSupplierListDataDridView> sViewList = new List<AllSupplierListDataDridView>();
            List<Supplier> sList = Supplier.GetAllSupplierList();
            foreach (Supplier s in sList)
            {
                AllSupplierListDataDridView view = new AllSupplierListDataDridView
                {
                    ID = s.ID,
                    SupplierName = s.Name,
                    SupplierAddress = s.Address
                };
                sViewList.Add(view);
            }
            return sViewList.OrderBy(s => s.SupplierName).ToList();
        }
    }
}
