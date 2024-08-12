using Equipment_Management.ObjectClass;
using Equipment_Management.CustomViewClass;

namespace Equipment_Management.GlobalVariable
{
    class Global
    {
        public static int ID { get; set; }
        public static int EStatusID { get; set; }
        public static Equipment equipmentGlobal { get; set; }
        public static AllEquipmentView selectedEquipmentInJob { get; set; }
    }
}
