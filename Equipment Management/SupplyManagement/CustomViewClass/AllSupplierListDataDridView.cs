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
        public static List<AllSupplierListDataDridView> AllSupplierFilteredByValidQuotation()
        {
            List<AllSupplierListDataDridView> sViewList = new List<AllSupplierListDataDridView>();
            List<AllQuotationListDataGridView> qFilteredByValid = AllQuotationListDataGridView.AllQuotationFilteredByValidDate();
            List<Supplier> sList = Supplier.GetAllSupplierList();

            HashSet<int> addedSupplierIDs = new HashSet<int>();
            foreach (Supplier s in sList)
            {
                // Check if the supplier is already in the addedSupplierIDs set
                if (!addedSupplierIDs.Contains(s.ID))
                {
                    // Check if the supplier exists in the filtered quotation list
                    if (qFilteredByValid.Any(q => q.SupplierID == s.ID))
                    {
                        AllSupplierListDataDridView view = new AllSupplierListDataDridView
                        {
                            ID = s.ID,
                            SupplierName = s.Name,
                            SupplierAddress = s.Address
                        };
                        sViewList.Add(view);

                        // Add the supplier ID to the set to skip duplicates
                        addedSupplierIDs.Add(s.ID);
                    }
                }
            }
            return sViewList.OrderBy(s => s.SupplierName).ToList();
        }
    }
}
