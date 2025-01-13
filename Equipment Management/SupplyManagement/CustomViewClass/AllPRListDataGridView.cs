using System.Collections.Generic;
using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Linq;

namespace Admin_Program.SupplyManagement.CustomViewClass
{
    class AllPRListDataGridView
    {
        public int ID { get; set; }
        public string PRTitle { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string PRStatus { get; set; }
        public int PRStatusID { get; set; }

        public AllPRListDataGridView() { }

        public static List<AllPRListDataGridView> AllPRInDataGridView()
        {
            List<AllPRListDataGridView> prinGridList = new List<AllPRListDataGridView>();
            List<PR> prList = PR.GetAllPRList();
            foreach(PR pr in prList)
            {
                if(pr.PRStatus.ID < 3)
                {
                    AllPRListDataGridView view = new AllPRListDataGridView
                    {
                        ID = pr.ID,
                        PRTitle = pr.PRTitle,
                        DeliveryDate = pr.DeliveryDate.Date,
                        PRStatus = pr.PRStatus.Status,
                        PRStatusID = pr.PRStatus.ID
                    };
                    prinGridList.Add(view);
                }
            }
            return prinGridList.OrderBy(pr=>pr.ID).ToList();
        }
    }
}
