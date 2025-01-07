using Admin_Program.SupplyManagement.ObjectClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.PRManage
{
    public partial class CreatePRForm : Form
    {
        private List<int> supplierID = new List<int>();
        List<Supplier> supplierList;

        public CreatePRForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            otherReasontextBox.Enabled = false;

            supplierList = new List<Supplier>();
        }
        private void UpdateComponents()
        {
            supplierList = Supplier.GetAllSupplierList();
            supplierList.Sort((x, y) => x.Name.CompareTo(y.Name));
            suppliercomboBox.Items.Clear();
            supplierID.Clear();

            suppliercomboBox.Items.Add("------กรุณาเลือกซัพพลายเออร์------");
            supplierID.Add(-1);
            foreach (Supplier s in supplierList)
            {
                suppliercomboBox.Items.Add(s.Name);
                supplierID.Add(s.ID);
            }
        }
    }
}
