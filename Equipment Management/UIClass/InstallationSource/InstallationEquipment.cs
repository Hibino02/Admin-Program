using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.UIClass.CreateWindowComponent;
using System.IO;

namespace Equipment_Management.UIClass.InstallationSource
{
    public partial class InstallationEquipment : Form
    {
        MainBackGroundFrom main;
        string equipmentPhotoPath;
        string installationPlacePhotoPath;
        string acquisitionDocumentPath;

        private CreateWindow create;
        //variable for update components
        List<EquipmentType> equipmentTypeList;
        List<EquipmentOwner> equipmentOwnerList;
        List<Acquisition> equipmentAcquisitionList;
        List<EquipmentStatus> equipmentInitialStatusList;
        List<RentalBasis> rentalBasisList;
        //variable for track primarykey from combobox
        private List<int> equipmentTypeID = new List<int>();
        private List<int> equipmentOwnerID = new List<int>();
        private List<int> equipmentAcquisitionID = new List<int>();
        private List<int> equipmentInitialStatusID = new List<int>();
        private List<int> rentalBasisID = new List<int>();
        //variable for create selected object after choseen combobox
        EquipmentType selectedEquipmentType;
        EquipmentOwner selectedEquipmentOwner;
        Acquisition selectedEquipmentAcquisition;
        EquipmentStatus selectedEquipmentStatus;
        RentalBasis selectedRentalBasis;
        double priceFromTextBox;
        public InstallationEquipment()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            equipmentTypeList = new List<EquipmentType>();
            equipmentOwnerList = new List<EquipmentOwner>();
            equipmentAcquisitionList = new List<Acquisition>();
            equipmentInitialStatusList = new List<EquipmentStatus>();
            rentalBasisList = new List<RentalBasis>();
            //Close rental components as populate
            rentalBasisCombobox.Enabled = false;
            createPeriodButton.Enabled = false;

            UpdateComponents();
        }

        private void UpdateComponents()
        {
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            choseEquipmentTypeCombobox.Items.Clear();
            foreach (EquipmentType eqt in equipmentTypeList)
            {
                choseEquipmentTypeCombobox.Items.Add(eqt.EType);
                equipmentTypeID.Add(eqt.ID);
            }
            equipmentOwnerList = EquipmentOwner.GetEquipmentOwnerList();
            equipmentOwnerList.Sort((x, y) => x.Owner.CompareTo(y.Owner));
            equipmentOwnerComboBox.Items.Clear();
            foreach (EquipmentOwner eqo in equipmentOwnerList)
            {
                equipmentOwnerComboBox.Items.Add(eqo.Owner);
                equipmentOwnerID.Add(eqo.ID);
            }
            equipmentAcquisitionList = Acquisition.GetAcquisitionList();
            equipmentAcquisitionList.Sort((x, y) => x.Accquire.CompareTo(y.Accquire));
            acquisitionComboBox.Items.Clear();
            foreach (Acquisition acc in equipmentAcquisitionList)
            {
                acquisitionComboBox.Items.Add(acc.Accquire);
                equipmentAcquisitionID.Add(acc.ID);
            }
            equipmentInitialStatusList = EquipmentStatus.GetEquipmentStatusList();
            equipmentInitialStatusComboBox.Items.Clear();
            foreach (EquipmentStatus eqis in equipmentInitialStatusList)
            {
                if (eqis.ID == 1 || eqis.ID == 2 || eqis.ID == 3)
                {
                    equipmentInitialStatusComboBox.Items.Add(eqis.EStatus);
                    equipmentInitialStatusID.Add(eqis.ID);
                }
            }
            rentalBasisList = RentalBasis.GetRentalBasisList();
            rentalBasisList.Sort((x, y) => x.Basis.CompareTo(y.Basis));
            rentalBasisCombobox.Items.Clear();
            foreach (RentalBasis rent in rentalBasisList)
            {
                rentalBasisCombobox.Items.Add(rent.Basis);
                rentalBasisID.Add(rent.ID);
            }
        }

        private void createTypeButton_Click(object sender, EventArgs e)
        {
            bool isCreating = true;
            while (isCreating)
            {
                create = new CreateWindow();
                create.Owner = main;
                if (create.ShowDialog() == DialogResult.OK)
                {
                    string receiveType = create.DetailsText;
                    EquipmentType newEqt = new EquipmentType(receiveType);
                    if (newEqt.Create())
                    {
                        MessageBox.Show("ประเภทอุปกรณ์ใหม่ : " + receiveType);
                        UpdateComponents();
                        isCreating = false;
                    }
                    else
                    {
                        MessageBox.Show("ประเภทอุปกรณ์นี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
                    }
                    create.DetailsText = string.Empty;
                }
                else
                {
                    isCreating = false;
                }
            }        
        }
        private void createOwnerButton_Click(object sender, EventArgs e)
        {
            bool isCreating = true;
            while (isCreating)
            {
                create = new CreateWindow();
                create.Owner = main;
                if (create.ShowDialog() == DialogResult.OK)
                {
                    string receiveOwner = create.DetailsText;
                    EquipmentOwner newEqo = new EquipmentOwner(receiveOwner);
                    if (newEqo.Create())
                    {
                        MessageBox.Show("ชื่อเจ้าของอุปกรณ์ใหม่ : " + receiveOwner);
                        UpdateComponents();
                        isCreating = false;
                    }
                    else
                    {
                        MessageBox.Show("ชื่อเจ้าของอุปกรณ์นี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
                    }
                    create.DetailsText = string.Empty;
                }
                else
                {
                    isCreating = false;
                }
            }
        }
        private void createPeriodButton_Click(object sender, EventArgs e)
        {
            bool isCreating = true;
            while (isCreating)
            {
                create = new CreateWindow();
                create.Owner = main;
                if (create.ShowDialog() == DialogResult.OK)
                {
                    string receiveRental = create.DetailsText;
                    RentalBasis newRent = new RentalBasis(receiveRental);
                    if (newRent.Create())
                    {
                        MessageBox.Show("ประเภทการเช่าใหม่ : " + newRent);
                        UpdateComponents();
                        isCreating = false;
                    }
                    else
                    {
                        MessageBox.Show("ประเภทการเช่านี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
                    }
                    create.DetailsText = string.Empty;
                }
                else
                {
                    isCreating = false;
                }
            }
        }
        //Check if acquisition is not rent
        private void acquisitionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(acquisitionComboBox.SelectedIndex == 0)
            {
                rentalBasisCombobox.Enabled = true;
                createPeriodButton.Enabled = true;
            }
            else
            {
                rentalBasisCombobox.Enabled = false;
                createPeriodButton.Enabled = false;
            }
        }
        //Get file path from user and stream to PictureBox
        private void equipmentPhotoButton_Click(object sender, EventArgs e)
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
                    equipmentPhotoPath = openFileDialog.FileName;
                    //Strem photo to picturebox
                    equipmentPictureBox.Image = Image.FromFile(equipmentPhotoPath);          
                }
            }
        }
        private void installationPlacePhotoButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the path from user
                    installationPlacePhotoPath = openFileDialog.FileName;
                    //Strem photo to picturebox
                    installationPlacePictureBox.Image = Image.FromFile(installationPlacePhotoPath);
                }
            }
        }
        //Get PDF file path from user
        private void invoiceAttachmentButton_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    acquisitionDocumentPath = openFileDialog.FileName;
                }
            }
        }
        //Saving photo to target directory
        private void SavePhotoToDirectory(string sourceFilePath, string targetDirectory)
        {
            // Check if the directory exists
            if (!Directory.Exists(targetDirectory))
            {
                // Create the directory if it doesn't exist
                Directory.CreateDirectory(targetDirectory);
            }

            // Define the target file path
            string targetFilePath = Path.Combine(targetDirectory, Path.GetFileName(sourceFilePath));

            // Copy the file to the target directory
            File.Copy(sourceFilePath, targetFilePath, true); // 'true' allows overwriting if the file already exists

            MessageBox.Show($"File saved to: {targetFilePath}");
        }
        private void SaveEquipmentPhoto()
        {
            if (!string.IsNullOrEmpty(equipmentPhotoPath))
            {
                SavePhotoToDirectory(equipmentPhotoPath, @"D:\EquipmentPhoto");
            }
        }
        private void SaveInstallationPlacePhoto()
        {
            if (!string.IsNullOrEmpty(installationPlacePhotoPath))
            {
                SavePhotoToDirectory(installationPlacePhotoPath, @"D:\InstallationPlacePhoto");
            }
        }

        private bool CheckAllAttribute()
        {
            bool isComplete = true;
            int selectTypeIndex = choseEquipmentTypeCombobox.SelectedIndex;
            if(selectTypeIndex >= 0 && selectTypeIndex < equipmentTypeID.Count)
            {
                int selectedTypeID = equipmentTypeID[selectTypeIndex];
                selectedEquipmentType = new EquipmentType(selectedTypeID);
            }
            else
            {
                MessageBox.Show(this, "กรุณาเลือกประเภท ของอุปกรณ์");
                isComplete = false;
            }
            if (string.IsNullOrEmpty(equipmentNameTextBox.Text))
            {
                MessageBox.Show(this, "ต้องระบุชื่อเรียก ของอุปกรณ์");
                isComplete = false;
            }
            int selectOwnerIndex = equipmentOwnerComboBox.SelectedIndex;
            if(selectOwnerIndex >= 0 && selectOwnerIndex < equipmentOwnerID.Count)
            {
                int selectedOwnerID = equipmentOwnerID[selectOwnerIndex];
                selectedEquipmentOwner = new EquipmentOwner(selectedOwnerID);
            }
            else
            {
                MessageBox.Show(this, "กรุณาเลือกเจ้าของ อุปกรณ์ชิ้นนี้");
                isComplete = false;
            }
            int selectAcquisitionIndex = acquisitionComboBox.SelectedIndex;
            if(selectAcquisitionIndex >= 0 && selectAcquisitionIndex < equipmentAcquisitionID.Count)
            {
                int selecedAcquisitionID = equipmentAcquisitionID[selectAcquisitionIndex];
                selectedEquipmentAcquisition = new Acquisition(selecedAcquisitionID);
            }
            else
            {
                MessageBox.Show(this, "กรูณาเลือกการได้มา ของอุปกรณ์");
                isComplete = false;
            }
            int selectInitialStatus = equipmentInitialStatusComboBox.SelectedIndex;
            if(selectInitialStatus >= 0 && selectInitialStatus < equipmentInitialStatusID.Count)
            {
                int selectedInitialStatusID = equipmentInitialStatusID[selectInitialStatus];
                selectedEquipmentStatus = new EquipmentStatus(selectedInitialStatusID);
            }
            else
            {
                MessageBox.Show(this, "กรุณาเลือกสถานะเริ่มต้น ของอุปกรณ์");
                isComplete = false;
            }
            if (string.IsNullOrEmpty(priceTextBox.Text))
            {
                MessageBox.Show(this, "ต้องใส่ราคาอย่างน้อย 1");
                isComplete = false;
            }
            else if (!double.TryParse(priceTextBox.Text, out priceFromTextBox))
            {
                MessageBox.Show(this, "กรุณาใส่ราคาเป็นตัวเลขที่ถูกต้อง");
                isComplete = false;
            }
            if (rentalBasisCombobox.Enabled)
            {
                int selectRentalBasis = rentalBasisCombobox.SelectedIndex;
                if(selectRentalBasis >= 0 && selectRentalBasis < rentalBasisID.Count)
                {
                    int selectedRentalBasisID = rentalBasisID[selectRentalBasis];
                    selectedRentalBasis = new RentalBasis(selectedRentalBasisID);
                }
                else
                {
                    MessageBox.Show(this, "กรุณาเลือก รอบในการเช่า");
                    isComplete = false;
                }
            }
            if (string.IsNullOrEmpty(sellDetailsRichTextBox.Text))
            {
                MessageBox.Show(this, "กรุณาระบุรายละเอียดผู้ขาย ให้เช่า หรือหน่วยงานที่ย้ายมา");
                isComplete = false;
            }
            return isComplete;
        }

        private void createEquipmentButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                Equipment newEq = new Equipment(equipmentNameTextBox.Text, installationDateTimePicker.Value, selectedEquipmentType,
                selectedEquipmentOwner, selectedEquipmentAcquisition, selectedEquipmentStatus, selectedRentalBasis,
                equipmentSerialTextBox.Text, equipmentPhotoPath, installationPlacePhotoPath, InstallationPlaceRichTextBox.Text,
                replacementCheckBox.Checked, sellDetailsRichTextBox.Text, priceFromTextBox, acquisitionDocumentPath, null);
                if (newEq.Create())
                {
                    MessageBox.Show(this, "อุปกรณ์ใหม่ถูกเพิ่มในระบบเรียบร้อย");
                }
                else
                {
                    MessageBox.Show(this, "ขั้นตอนการสร้างข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
    }
}
