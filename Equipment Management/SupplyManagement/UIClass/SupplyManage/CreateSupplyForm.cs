using Admin_Program.GlobalVariable;
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
    public partial class CreateSupplyForm : Form
    {
        MainBackGroundFrom main;

        CreateSupplyTypeForm createSupplyType;

        private List<int> supplyTypeID = new List<int>();
        List<SupplyType> supplyTypeList;

        string supplyPhoto;

        public CreateSupplyForm()
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
        //Create supply type
        private void CreateSupplyTypeButton_Click(object sender, EventArgs e)
        {
            createSupplyType = new CreateSupplyTypeForm();
            createSupplyType.Owner = main;
            createSupplyType.onSuccess += SupplyTypeCreationSuccess;
            createSupplyType.ShowDialog();
        }
        //Get photo from user click
        private void AttachPhotoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    supplyPhoto = openFileDialog.FileName;

                    using (var tempImage = Image.FromFile(supplyPhoto))
                    {
                        supplyPictureBox.Image = new Bitmap(tempImage);
                    }
                }
            }
        }
        //Save photo into folder
        private void SaveSupplyPhoto()
        {
            if (!string.IsNullOrEmpty(supplyPhoto))
            {
                Global.Directory = "SupplyPhoto";
                Global.SaveFileToServerSupply(supplyPhoto);
                Global.Directory = null;
                supplyPhoto = Global.TargetFilePath;
            }
        }
        //Event handler to call method
        private void SupplyTypeCreationSuccess(object sender, EventArgs e)
        {
            UpdateComponents();
        }
    }
}
