using System.Collections.Generic;
using Admin_Program.ObjectClass;

namespace Admin_Program.CustomViewClass
{
    class AllEquipmentForCreatedJobView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Serial { get; set; }
        public string EStatus { get; set; }
        public string EPhoto { get; set; }

        public AllEquipmentForCreatedJobView() { }
        public AllEquipmentForCreatedJobView(int id,string name,string serial,string ephoto,string estatus)
        {
            this.ID = id;
            this.Name = name;
            this.Serial = serial;
            this.EPhoto = ephoto;
            this.EStatus = estatus;
        }

        public static List<AllEquipmentForCreatedJobView> GetAllEquipmentForCreatedJobView()
        {
            List<AllEquipmentForCreatedJobView> list = new List<AllEquipmentForCreatedJobView>();
            foreach (Equipment e in Equipment.GetEquipmentList())
            {
                if (e.Replacement)
                {
                    if(e.EStatusObj.ID == 1 || e.EStatusObj.ID == 2 || e.EStatusObj.ID == 6
                   || e.EStatusObj.ID == 7)
                    {
                        AllEquipmentForCreatedJobView view = new AllEquipmentForCreatedJobView
                        {
                            ID = e.ID,
                            Name = e.Name,
                            Serial = e.Serial,
                            EStatus = e.EStatusObj.EStatus,
                            EPhoto = e.EPhotoPath
                        };
                        list.Add(view);
                    }
                }
            }
            return list;
        }
    }
}
