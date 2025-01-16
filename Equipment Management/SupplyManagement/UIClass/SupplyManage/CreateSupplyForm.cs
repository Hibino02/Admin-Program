using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    public partial class CreateSupplyForm : Form
    {
        MainBackGroundFrom main;

        CreateSupplyTypeForm createSupplyType;
        SupplyTypeManageForm supplyTypeManageForm;

        //variable for track primarykey from combobox
        private List<int> supplyTypeID = new List<int>();
        //variable for update components
        List<SupplyType> supplyTypeList;
        //variable for create selected object after choseen combobox
        SupplyType selecedSupplyType;

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
            foreach (SupplyType spt in supplyTypeList)
            {
                supplyTypeComboBox.Items.Add(spt.TypeName);
                supplyTypeID.Add(spt.ID);
            }
            userGroupcomboBox.Items.Add("--เลือกกลุ่มวัสดุ--");
            userGroupcomboBox.Items.Add("GROUP1");
            userGroupcomboBox.Items.Add("GROUP2");
            userGroupcomboBox.Items.Add("GROUP3");
        }
        //Create supply type
        private void CreateSupplyTypeButton_Click(object sender, EventArgs e)
        {
            createSupplyType = new CreateSupplyTypeForm();
            createSupplyType.Owner = main;
            createSupplyType.onSuccess += SupplyTypeCreationSuccess;
            createSupplyType.ShowDialog();
        }
        //Manage supply type
        private void manageSupplyButton_Click(object sender, EventArgs e)
        {
            supplyTypeManageForm = new SupplyTypeManageForm();
            supplyTypeManageForm.Owner = main;
            supplyTypeManageForm.updateSupplyType += SupplyTypeCreationSuccess;
            supplyTypeManageForm.ShowDialog();
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
                    PhotoURLtextBox.Text = supplyPhoto;

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
        //Checking
        private bool CheckAllAttribute()
        {
            int selectTypeIndex = supplyTypeComboBox.SelectedIndex;
            if (selectTypeIndex >= 0 && selectTypeIndex < supplyTypeID.Count)
            {
                int selectedTypeID = supplyTypeID[selectTypeIndex];
                selecedSupplyType = new SupplyType(selectedTypeID);
            }
            else
            {
                MessageBox.Show("กรุณาเลือกประเภทวัสดุ");
                return false;
            }
            if (supplyNameTextBox.TextLength > 77)
            {
                MessageBox.Show("จำนวนตัวอักษรเกิน 77 ตัว");
                return false;
            }
            if (string.IsNullOrEmpty(supplyNameTextBox.Text))
            {
                MessageBox.Show("กรุณาใส่ชื่อวัสดุ");
                return false;
            }
            if (string.IsNullOrEmpty(supplyUnitTextBox.Text))
            {
                MessageBox.Show("กรุณาใส่หน่วยวัสดุ");
                return false;
            }  
            if (userGroupcomboBox.SelectedIndex <= 0)
            {
                MessageBox.Show("กรุณาใส่กลุ่มวัสดุ");
                return false;
            }   
            SaveSupplyPhoto();
            return true;
        }
        //Create button event
        private void createButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                int moq = (int)moqnumericUpDown.Value;
                string userGroup = userGroupcomboBox.SelectedItem?.ToString();
                Supply newSp = new Supply(supplyNameTextBox.Text, supplyUnitTextBox.Text, moq, 
                    IsActiveCheckBox.Checked, selecedSupplyType,Global.warehouseID,userGroup, supplyPhoto);
                if (newSp.Create())
                {
                    MessageBox.Show("ซัพพลายถูกสร้างเรียบร้อย");
                    SupplyBalance sb = new ObjectClass.SupplyBalance(newSp, 0, DateTime.Now, Global.userName,Global.warehouseID);
                    if (sb.Create())
                    {
                        MessageBox.Show("ยอดคงเหลือของซัพพลายนี้ ถูกเพิ่มเริ่มโดยต้นที่ 0");
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("การสร้างประวัติยอดคงเหลือล้มเหลว");
                    }
                }
                else
                {
                    Global.DeleteFileFromFtpSupply(supplyPhoto);
                    MessageBox.Show("ขั้นตอนการสร้างข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
    }
}
