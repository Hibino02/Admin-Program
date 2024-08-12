using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.UIClass.CreateWindowComponent;
using System.IO;
using Equipment_Management.CustomWindowComponents;

namespace Equipment_Management.UIClass.InstallationSource
{
    public partial class InstallationEquipment : Form
    {
        MainBackGroundFrom main;
        string equipmentPhotoPath;
        string installationPlacePhotoPath;
        string acquisitionDocumentPath;

        string targetFilePath;

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
                        ShowCustomMessageBox("ประเภทอุปกรณ์ใหม่ : " + receiveType);
                        UpdateComponents();
                        isCreating = false;
                    }
                    else
                    {
                        ShowCustomMessageBox("ประเภทอุปกรณ์นี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
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
                        ShowCustomMessageBox("ชื่อเจ้าของอุปกรณ์ใหม่ : " + receiveOwner);
                        UpdateComponents();
                        isCreating = false;
                    }
                    else
                    {
                        ShowCustomMessageBox("ชื่อเจ้าของอุปกรณ์นี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
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
                        ShowCustomMessageBox("ประเภทการเช่านี้ ถูกใช้แล้วจึงไม่สามาถบันทึก");
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
            try
            {
                // Check if the directory exists
                if (!Directory.Exists(targetDirectory))
                {
                    // Create the directory if it doesn't exist
                    Directory.CreateDirectory(targetDirectory);
                }

                // Define the target file path
                targetFilePath = Path.Combine(targetDirectory, Path.GetFileName(sourceFilePath));

                // Check if the file is locked by another process
                if (IsFileLocked(new FileInfo(sourceFilePath)))
                {
                    ShowCustomMessageBox("ไฟล์นี้กำลังถูกเปิด จึงไม่สามารถก๊อปปี้ได้");
                    return;
                }

                // Copy the file to the target directory
                File.Copy(sourceFilePath, targetFilePath, true); // 'true' allows overwriting if the file already exists

                ShowCustomMessageBox($"File saved to: {targetFilePath}");
            }
            catch (IOException ex)
            {
                ShowCustomMessageBox($"An error occurred: {ex.Message}");
            }
        }
        //Save photo & documents into folder
        private void SaveEquipmentPhoto()
        {
            if (!string.IsNullOrEmpty(equipmentPhotoPath))
            {
                SavePhotoToDirectory(equipmentPhotoPath, @"C:\EquipmentPhoto");
                equipmentPhotoPath = targetFilePath;
            }
        }
        private void SaveInstallationPlacePhoto()
        {
            if (!string.IsNullOrEmpty(installationPlacePhotoPath))
            {
                SavePhotoToDirectory(installationPlacePhotoPath, @"C:\InstallationPlacePhoto");
                installationPlacePhotoPath = targetFilePath;
            }
        }
        private void SaveAcquisitionDocument()
        {
            if (!string.IsNullOrEmpty(acquisitionDocumentPath))
            {
                SavePhotoToDirectory(acquisitionDocumentPath, @"C:\AcquisitionDocument");
                acquisitionDocumentPath = targetFilePath;
            }
        }

        private bool CheckAllAttribute()
        {
            int selectTypeIndex = choseEquipmentTypeCombobox.SelectedIndex;
            if(selectTypeIndex >= 0 && selectTypeIndex < equipmentTypeID.Count)
            {
                int selectedTypeID = equipmentTypeID[selectTypeIndex];
                selectedEquipmentType = new EquipmentType(selectedTypeID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกประเภท ของอุปกรณ์");
                return false;
            }
            if (string.IsNullOrEmpty(equipmentNameTextBox.Text))
            {
                ShowCustomMessageBox("ต้องระบุชื่อเรียก ของอุปกรณ์");
                return false;
            }
            int selectOwnerIndex = equipmentOwnerComboBox.SelectedIndex;
            if(selectOwnerIndex >= 0 && selectOwnerIndex < equipmentOwnerID.Count)
            {
                int selectedOwnerID = equipmentOwnerID[selectOwnerIndex];
                selectedEquipmentOwner = new EquipmentOwner(selectedOwnerID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกเจ้าของ อุปกรณ์ชิ้นนี้");
                return false;
            }
            int selectAcquisitionIndex = acquisitionComboBox.SelectedIndex;
            if(selectAcquisitionIndex >= 0 && selectAcquisitionIndex < equipmentAcquisitionID.Count)
            {
                int selecedAcquisitionID = equipmentAcquisitionID[selectAcquisitionIndex];
                selectedEquipmentAcquisition = new Acquisition(selecedAcquisitionID);
            }
            else
            {
                ShowCustomMessageBox("กรูณาเลือกการได้มา ของอุปกรณ์");
                return false;
            }
            int selectInitialStatus = equipmentInitialStatusComboBox.SelectedIndex;
            if(selectInitialStatus >= 0 && selectInitialStatus < equipmentInitialStatusID.Count)
            {
                int selectedInitialStatusID = equipmentInitialStatusID[selectInitialStatus];
                selectedEquipmentStatus = new EquipmentStatus(selectedInitialStatusID);
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกสถานะเริ่มต้น ของอุปกรณ์");
                return false;
            }
            if (string.IsNullOrEmpty(priceTextBox.Text))
            {
                ShowCustomMessageBox("ต้องใส่ราคาอย่างน้อย 0");
                return false;
            }
            else if (!double.TryParse(priceTextBox.Text, out priceFromTextBox))
            {
                ShowCustomMessageBox("กรุณาใส่ราคาเป็นตัวเลขที่ถูกต้อง");
                return false;
            }
            else if (priceFromTextBox < 0)
            {
                priceFromTextBox = 0;
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
                    ShowCustomMessageBox("กรุณาเลือก รอบในการเช่า");
                    return false;
                }
            }
            if (replacementCheckBox.Checked && selectedEquipmentStatus.ID == 3)
            {
                ShowCustomMessageBox("อุปกรณ์ที่มีสถานะชำรุด จะไม่สามารถนำไปทดแทนได้\nกรุณาเลือกประเภทอุปกรณ์ที่ถูกต้อง");
                return false;
            }
            if (string.IsNullOrEmpty(sellDetailsRichTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุรายละเอียดผู้ขาย ให้เช่า หรือหน่วยงานที่ย้ายมา");
                return false;
            }
            else
            {
                SaveEquipmentPhoto();
                SaveInstallationPlacePhoto();
                SaveAcquisitionDocument();
            }
            return true;
        }

        private void createEquipmentButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                Equipment newEq = new Equipment(equipmentNameTextBox.Text,false, installationDateTimePicker.Value, selectedEquipmentType,
                selectedEquipmentOwner, selectedEquipmentAcquisition, selectedEquipmentStatus, selectedRentalBasis,
                equipmentSerialTextBox.Text, equipmentPhotoPath, installationPlacePhotoPath, equipmentDetailRichTextBox.Text,
                replacementCheckBox.Checked, sellDetailsRichTextBox.Text, priceFromTextBox, acquisitionDocumentPath, null,InstallationDetailsRichTextBox.Text);
                if (newEq.Create())
                {
                    ShowCustomMessageBox("อุปกรณ์ใหม่ถูกเพิ่มในระบบเรียบร้อย");
                    Close();
                }
                else
                {
                    ShowCustomMessageBox("ขั้นตอนการสร้างข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
        //Open Invoice
        private void invoiceLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(acquisitionDocumentPath))
            {
                System.Diagnostics.Process.Start(acquisitionDocumentPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        //Call custom message box
        private void ShowCustomMessageBox(string message)
        {
            using (var messageBox = new CustomMessageBox())
            {
                messageBox.MessageText = message;
                var result = messageBox.ShowDialog();
            }
        }
        //Method to check file is being open
        private bool IsFileLocked(FileInfo file)
        {
            FileStream stream = null;
            try
            {
                stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            }
            catch (IOException)
            {
                // The file is locked by another process
                return true;
            }
            finally
            {
                stream?.Close();
            }

            // The file is not locked
            return false;
        }
    }
}
