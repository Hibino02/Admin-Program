using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    public partial class AllSupplyListForm : Form
    {
        MainBackGroundFrom main;

        private CreateSupplyForm createSupply;

        private List<int> supplyTypeID = new List<int>();
        List<SupplyType> supplyTypeList;

        public AllSupplyListForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            UpdateComponents();
        }

        private void UpdateComponents()
        {
            supplyTypeList = SupplyType.GetAllSupplyTypeList();
            supplyTypeList.Sort((x, y) => x.TypeName.CompareTo(y.TypeName));
            supplyTypeComboBox.Items.Clear();
            supplyTypeID.Clear();

            supplyTypeComboBox.Items.Add("------กรุณาเลือกประเภทวัสดุ------");
            supplyTypeID.Add(-1);
            supplyTypeComboBox.SelectedIndex = 0;
            foreach (SupplyType spt in supplyTypeList)
            {
                supplyTypeComboBox.Items.Add(spt.TypeName);
                supplyTypeID.Add(spt.ID);
            }
        }
        //Create Supply
        private void CreateSupplyButton_Click(object sender, EventArgs e)
        {
            createSupply = new CreateSupplyForm();
            createSupply.Owner = main;
            createSupply.ShowDialog();
        }
    }
}
