using System.Collections.Generic;
using System.Linq;
using Admin_Program.SupplyManagement.ObjectClass;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllSupplyInQuotationListDataGridView
    {
        public int ID { get; set; }
        public int QuotationID { get; set; }
        public int SupplyID { get; set; }
        public string SupplyName { get; set; }
        public float Price { get; set; }
        public string SupplyUnit { get; set; }
        public string SupplyPhoto { get; set; }

        public AllSupplyInQuotationListDataGridView() { }
        //Contructor for add Supply to Quotation and show in DataGridView
        public AllSupplyInQuotationListDataGridView(int supplyID, string supplyName, float price, string supplyUnit, string supplyPhoto)
        {
            SupplyID = supplyID;
            SupplyName = supplyName;
            Price = price;
            SupplyUnit = supplyUnit;
            SupplyPhoto = supplyPhoto;
        }
        public static List<AllSupplyInQuotationListDataGridView> allSupplyInQuotation()
        {
            List<AllSupplyInQuotationListDataGridView> siqViewList = new List<AllSupplyInQuotationListDataGridView>();
            List<SupplyInQuotation> siqList = SupplyInQuotation.GetAllSupplyInQuotationList();
            foreach (SupplyInQuotation siq in siqList)
            {
                AllSupplyInQuotationListDataGridView view = new AllSupplyInQuotationListDataGridView
                {
                    ID = siq.ID,
                    QuotationID = siq.QuotationID,
                    SupplyID = siq.Supply.ID,
                    SupplyName = siq.Supply.SupplyName,
                    Price = siq.Price,
                    SupplyUnit = siq.Supply.SupplyUnit,
                    SupplyPhoto = siq.Supply.SupplyPhoto
                };
                siqViewList.Add(view);
            }
            return siqViewList.OrderBy(siq => siq.ID).ToList();
        }
        public static List<AllSupplyInQuotationListDataGridView> SupplyInQuotationList(List<SupplyInQuotation> list)
        {
            List<AllSupplyInQuotationListDataGridView> siqViewList = new List<AllSupplyInQuotationListDataGridView>();
            foreach (SupplyInQuotation siq in list)
            {
                AllSupplyInQuotationListDataGridView view = new AllSupplyInQuotationListDataGridView
                {
                    ID = siq.ID,
                    QuotationID = siq.QuotationID,
                    SupplyID = siq.Supply.ID,
                    SupplyName = siq.Supply.SupplyName,
                    Price = siq.Price,
                    SupplyUnit = siq.Supply.SupplyUnit,
                    SupplyPhoto = siq.Supply.SupplyPhoto
                };
                siqViewList.Add(view);
            }
            return siqViewList;
        }
    }
}
