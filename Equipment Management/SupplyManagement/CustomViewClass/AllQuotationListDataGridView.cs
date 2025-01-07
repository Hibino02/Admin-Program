using System.Collections.Generic;
using System.Linq;
using Admin_Program.SupplyManagement.ObjectClass;
using System;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllQuotationListDataGridView
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        public string QuotationNumber { get; set; }
        public string SupplierName { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime? ValidDate { get; set; }
        public string QuotationPDF { get; set; }

        public string ValidDateDisplay => ValidDate.HasValue
            ? ValidDate.Value.ToString("MMM dd, yyyy")
            : "จนกว่าจะแจ้งให้ทราบ";

        public AllQuotationListDataGridView() { }

        public static List<AllQuotationListDataGridView> AllQuotation()
        {
            List<AllQuotationListDataGridView> qViewList = new List<AllQuotationListDataGridView>();
            List<Quotation> qList = Quotation.GetAllQuotationList();
            foreach(Quotation q in qList)
            {
                AllQuotationListDataGridView view = new AllQuotationListDataGridView
                {
                    ID = q.ID,
                    SupplierID = q.Supplier.ID,
                    SupplierName = q.Supplier.Name,
                    QuotationNumber = q.QuotationNumber,
                    IssueDate = q.IssueDate,
                    ValidDate = q.ValidDate,
                    QuotationPDF = q.QuotationPDF
                };
                qViewList.Add(view);
            }
            return qViewList.OrderBy(q => q.IssueDate).ToList();
        }
        public static List<AllQuotationListDataGridView> AllQuotationFilteredByValidDate()
        {
            List<AllQuotationListDataGridView> qViewList = new List<AllQuotationListDataGridView>();
            List<Quotation> qList = Quotation.GetAllQuotationList();
            foreach (Quotation q in qList)
            {
                if(q.ValidDate == null || q.ValidDate >= DateTime.Now.Date)
                {
                    AllQuotationListDataGridView view = new AllQuotationListDataGridView
                    {
                        ID = q.ID,
                        SupplierID = q.Supplier.ID,
                        SupplierName = q.Supplier.Name,
                        QuotationNumber = q.QuotationNumber,
                        IssueDate = q.IssueDate,
                        ValidDate = q.ValidDate,
                        QuotationPDF = q.QuotationPDF
                    };
                    qViewList.Add(view);
                }   
            }
            return qViewList.OrderBy(q => q.IssueDate).ToList();
        }
    }
}
