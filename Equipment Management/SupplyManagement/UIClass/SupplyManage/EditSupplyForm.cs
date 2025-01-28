using Admin_Program.GlobalVariable;
using Admin_Program.SupplyManagement.ObjectClass;
using Admin_Program.UIClass;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Admin_Program.SupplyManagement.UIClass.SupplyManage
{
    public partial class EditSupplyForm : Form
    {
        MainBackGroundFrom main;
        public event EventHandler UpdateGrid;

        Supply supply;
        CreateSupplyTypeForm createSupplyType;
        SupplyTypeManageForm supplyTypeManageForm;
        //variable for track primarykey from combobox
        private List<int> supplyTypeID = new List<int>();
        //variable for update components
        List<SupplyType> supplyTypeList;
        //variable for create selected object after choseen combobox
        SupplyType selecedSupplyType;

        string oldSupplyPhoto;
        string supplyPhoto;

        public EditSupplyForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            supply = new Supply(Global.ID);

            UpdateComponents();
            ShowSelectedSupplyToForm();
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
        //Method to show current supply
        private void ShowSelectedSupplyToForm()
        {
            supplyNameTextBox.Text = supply.SupplyName;
            supplyUnitTextBox.Text = supply.SupplyUnit;
            supplyTypeComboBox.Text = supply.SupplyType.TypeName;
            decimal moqForNumeric = (decimal)supply.MOQ;
            moqnumericUpDown.Value = moqForNumeric;
            IsActiveCheckBox.Checked = supply.IsActive;
            if (!string.IsNullOrEmpty(supply.SupplyPhoto))
            {
                PhotoURLtextBox.Text = supply.SupplyPhoto;
                Global.LoadImageIntoPictureBox(supply.SupplyPhoto,supplyPictureBox);
            }
            supplyPhoto = supply.SupplyPhoto;
            oldSupplyPhoto = supply.SupplyPhoto;
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
        private void SupplyTypeCreationSuccess(object sender, EventArgs e)
        {
            UpdateComponents();
        }
        //Attach supply photo
        private void AttachPhotoButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path from user
                    supplyPhoto = openFileDialog.FileName;
                    PhotoURLtextBox.Text = openFileDialog.FileName;

                    using (var tempImage = Image.FromFile(supplyPhoto))
                    {
                        //Strem photo to picturebox
                        supplyPictureBox.Image = new Bitmap(tempImage);
                    }
                }
            }
        }
        //Save photo & documents into folder
        private void SaveSupplyPhoto()
        {
            if (!string.IsNullOrEmpty(oldSupplyPhoto))
            {
                Global.DeleteFileFromFtpSupply(oldSupplyPhoto);
            }
            if (!string.IsNullOrEmpty(supplyPhoto))
            {
                Global.Directory = "SupplyPhoto";
                Global.SaveFileToServerSupply(supplyPhoto);
                Global.Directory = null;
                supplyPhoto = Global.TargetFilePath;
            }
        }

        private bool CheckAllAttribute()
        {
            bool isComplete = true;
            int selectTypeIndex = supplyTypeComboBox.SelectedIndex;
            if(selectTypeIndex >= 0 && selectTypeIndex < supplyTypeID.Count)
            {
                int selectedTypeID = supplyTypeID[selectTypeIndex];
                selecedSupplyType = new SupplyType(selectedTypeID);
                supply.SupplyType = selecedSupplyType;
            }
            else
            {
                MessageBox.Show("กรุณาเลือกประเภทวัสดุ");
                isComplete = false;
            }
            if (string.IsNullOrEmpty(supplyNameTextBox.Text))
            {
                MessageBox.Show("กรุณาใส่ชื่อวัสดุ");
                isComplete = false;
            }
            if(supplyNameTextBox.Text.Length > 77)
            {
                MessageBox.Show("จำนวนตัวอักษรเกิน 77 ตัว");
                isComplete = false;
            }
            if (string.IsNullOrEmpty(supplyUnitTextBox.Text))
            {
                MessageBox.Show("กรุณาใส่หน่วยวัสดุ");
                isComplete = false;
            }
            if (userGroupcomboBox.SelectedIndex > 0)
            {
                string userGroup = userGroupcomboBox.SelectedItem?.ToString();
                supply.UserGroup = userGroup;
            }
            int moq = (int)moqnumericUpDown.Value;
            supply.MOQ = moq;
            supply.IsActive = IsActiveCheckBox.Checked;
            supply.SupplyName = supplyNameTextBox.Text;
            supply.SupplyUnit = supplyUnitTextBox.Text;
            if (isComplete)
            {
                if (supplyPhoto != oldSupplyPhoto)
                {
                    SaveSupplyPhoto();
                    supply.SupplyPhoto = supplyPhoto;
                }
            }
            return isComplete;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                if (supply.Change())
                {
                    MessageBox.Show("วัสดุถูกแก้ใขเรียบร้อย");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    Global.DeleteFileFromFtpSupply(supplyPhoto);
                    MessageBox.Show("ขั้นตอนการอัฟเดทข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            } 
        }
    }
}
