using System.Collections.Generic;
using Admin_Program.SupplyManagement.ObjectClass;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllSupplyInPRListDataGridView
    {
        public int PRID { get; set; }
        public string SupplyName { get; set; }
        public float Price { get; set; }
        public string SupplyUnit { get; set; }
        public int Quantity { get; set; }
        public float Amount { get; set; }
        public string QuotationNumber { get; set; }
        public string SupplyPhoto { get; set; }
        public string QuotationPDF { get; set; }
        public int QuotationID { get; set; }
        public int SupplyID { get; set; }

        public AllSupplyInPRListDataGridView() { }
        
        public AllSupplyInPRListDataGridView(string sName,float price,string sUnit,int quantity,float amount,string qNum
            ,string sPhoto,string qPDF, int qid, int sid)
        {
            this.SupplyName = sName;
            this.Price = price;
            this.SupplyUnit = sUnit;
            this.Quantity = quantity;
            this.Amount = amount;
            this.QuotationNumber = qNum;
            this.SupplyPhoto = sPhoto;
            this.QuotationPDF = qPDF;
            this.QuotationID = qid;
            this.SupplyID = sid;
        }

        public static List<AllSupplyInPRListDataGridView> SupplyInQuotationForPR(List<SupplyInQuotation> list)
        {
            List<AllSupplyInPRListDataGridView> siqForPR = new List<AllSupplyInPRListDataGridView>();
            foreach (SupplyInQuotation siq in list)
            {
                AllSupplyInPRListDataGridView view = new AllSupplyInPRListDataGridView
                {
                    SupplyName = siq.Supply.SupplyName,
                    Price = siq.Price,
                    SupplyUnit = siq.Supply.SupplyUnit
                };
                siqForPR.Add(view);
            }
            return siqForPR;
        }
        public static List<AllSupplyInPRListDataGridView> AllSupplyInActivePR()
        {
            List<AllSupplyInPRListDataGridView> allActivePR = new List<AllSupplyInPRListDataGridView>();
            List<SupplyInPR> sipr = SupplyInPR.GetAllSupplyInPRList();
            foreach(SupplyInPR s in sipr)
            {
                AllSupplyInPRListDataGridView view = new AllSupplyInPRListDataGridView
                {
                    PRID = s.PRID,
                    SupplyName = s.Supply.SupplyName,
                    Quantity = s.Quantity,
                    SupplyUnit = s.Supply.SupplyUnit
                };
                allActivePR.Add(view);
            }
            return allActivePR;
        }
    }
}
