using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.UIClass.CreateWindowComponent;
using Equipment_Management.GlobalVariable;
using System.IO;
using Equipment_Management.CustomWindowComponents;

namespace Equipment_Management.UIClass.EquipmentInstallationSource
{
    public partial class EditEquipmentForm : Form
    {
        Equipment edit;
        MainBackGroundFrom main;
        public event EventHandler UpdateGrid;

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
        EquipmentStatus selectedEquipmentStatus;
        RentalBasis selectedRentalBasis;
        double priceFromTextBox;

        public EditEquipmentForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            equipmentTypeList = new List<EquipmentType>();
            equipmentOwnerList = new List<EquipmentOwner>();
            equipmentAcquisitionList = new List<Acquisition>();
            equipmentInitialStatusList = new List<EquipmentStatus>();
            rentalBasisList = new List<RentalBasis>();
            edit = new Equipment(Global.ID);
            //Close rental basis if it's not rent
            if(edit.AcquisitionObj.ID != 1)
            {
                rentalBasisCombobox.Enabled = false;
                createPeriodButton.Enabled = false;
            }
            if(edit.EStatusObj.ID != 1 && edit.EStatusObj.ID != 2 && edit.EStatusObj.ID != 3
                && edit.EStatusObj.ID != 6 && edit.EStatusObj.ID != 7)
            {
                equipmentInitialStatusComboBox.Enabled = false;
            }
            //Close Acquisition combobox to cant edit
            acquisitionComboBox.Enabled = false;
            UpdateComponents();
            SetEquipmentCurrentStatus();
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
            if(edit.EStatusObj.ID == 1 || edit.EStatusObj.ID == 2 || edit.EStatusObj.ID == 3)
            {
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
            }
            else if(edit.EStatusObj.ID == 6 || edit.EStatusObj.ID == 7)
            {
                equipmentInitialStatusList = EquipmentStatus.GetEquipmentStatusList();
                equipmentInitialStatusComboBox.Items.Clear();
                foreach (EquipmentStatus eqis in equipmentInitialStatusList)
                {
                    if (eqis.ID == 6 || eqis.ID == 7)
                    {
                        equipmentInitialStatusComboBox.Items.Add(eqis.EStatus);
                        equipmentInitialStatusID.Add(eqis.ID);
                    }
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
        private void SetEquipmentCurrentStatus()
        {
            choseEquipmentTypeCombobox.Text = edit.ETypeObj.EType;
            equipmentNameTextBox.Text = edit.Name;
            equipmentSerialTextBox.Text = edit.Serial;
            equipmentOwnerComboBox.Text = edit.EOwnerObj.Owner;
            acquisitionComboBox.Text = edit.AcquisitionObj.Accquire;
            equipmentInitialStatusComboBox.Text = edit.EStatusObj.EStatus;
            replacementCheckBox.Checked = edit.Replacement;
            priceTextBox.Text = edit.Price.ToString();
            rentalBasisCombobox.Text = edit.ERentalBasis?.Basis??string.Empty;
            installationDateTimePicker.Value = edit.InsDate;
            if(!string.IsNullOrEmpty(edit.EPhotoPath) && File.Exists(edit.EPhotoPath))
            {
                if (equipmentPictureBox.Image != null)
                {
                    equipmentPictureBox.Image.Dispose();
                }
                equipmentPictureBox.Image = Image.FromFile(edit.EPhotoPath);
            }
            if (!string.IsNullOrEmpty(edit.OPlacePhotoPath) && File.Exists(edit.OPlacePhotoPath))
            {
                if (installationPlacePictureBox.Image != null)
                {
                    installationPlacePictureBox.Image.Dispose();
                }
                installationPlacePictureBox.Image = Image.FromFile(edit.OPlacePhotoPath);
            }
            sellDetailsRichTextBox.Text = edit.SellDetails;
            equipmentDetailRichTextBox.Text = edit.EDetails;
            InstallationDetailsRichTextBox.Text = edit.InstallationDetails;
            if(edit.EStatusObj.ID != 1 && edit.EStatusObj.ID != 2 && edit.EStatusObj.ID != 6 &&
                edit.EStatusObj.ID != 7 && edit.EStatusObj.ID != 3)
            {
                replacementCheckBox.Enabled = false;
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
                        ShowCustomMessageBox("ประเภทการเช่าใหม่ : " + newRent);
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
            if (acquisitionComboBox.SelectedIndex == 0)
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
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
            bool isComplete = true;
            int selectTypeIndex = choseEquipmentTypeCombobox.SelectedIndex;
            if (selectTypeIndex >= 0 && selectTypeIndex < equipmentTypeID.Count)
            {
                int selectedTypeID = equipmentTypeID[selectTypeIndex];
                selectedEquipmentType = new EquipmentType(selectedTypeID);
                edit.ETypeObj = selectedEquipmentType;
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกประเภท ของอุปกรณ์");
                isComplete = false;
            }
            if (string.IsNullOrEmpty(equipmentNameTextBox.Text))
            {
                ShowCustomMessageBox("ต้องระบุชื่อเรียก ของอุปกรณ์");
                isComplete = false;
            }
            int selectOwnerIndex = equipmentOwnerComboBox.SelectedIndex;
            if (selectOwnerIndex >= 0 && selectOwnerIndex < equipmentOwnerID.Count)
            {
                int selectedOwnerID = equipmentOwnerID[selectOwnerIndex];
                selectedEquipmentOwner = new EquipmentOwner(selectedOwnerID);
                edit.EOwnerObj = selectedEquipmentOwner;
            }
            else
            {
                ShowCustomMessageBox("กรุณาเลือกเจ้าของ อุปกรณ์ชิ้นนี้");
                isComplete = false;
            }
            int selectInitialStatus = equipmentInitialStatusComboBox.SelectedIndex;
            if (selectInitialStatus >= 0 && selectInitialStatus < equipmentInitialStatusID.Count)
            {
                int selectedInitialStatusID = equipmentInitialStatusID[selectInitialStatus];
                selectedEquipmentStatus = new EquipmentStatus(selectedInitialStatusID);
                edit.EStatusObj = selectedEquipmentStatus;
            }
            if (string.IsNullOrEmpty(priceTextBox.Text))
            {
                ShowCustomMessageBox("ต้องใส่ราคาอย่างน้อย 0");
                isComplete = false;
            }
            else if (!double.TryParse(priceTextBox.Text, out priceFromTextBox))
            {
                ShowCustomMessageBox("กรุณาใส่ราคาเป็นตัวเลขที่ถูกต้อง");
                isComplete = false;
            }
            else
            {
                edit.Price = priceFromTextBox;
            }
            if (rentalBasisCombobox.Enabled)
            {
                int selectRentalBasis = rentalBasisCombobox.SelectedIndex;
                if (selectRentalBasis >= 0 && selectRentalBasis < rentalBasisID.Count)
                {
                    int selectedRentalBasisID = rentalBasisID[selectRentalBasis];
                    selectedRentalBasis = new RentalBasis(selectedRentalBasisID);
                    edit.ERentalBasis = selectedRentalBasis;
                }
                else
                {
                    edit.ERentalBasis = null;
                }
            }
            if (string.IsNullOrEmpty(sellDetailsRichTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาระบุรายละเอียดผู้ขาย ให้เช่า หรือหน่วยงานที่ย้ายมา");
                isComplete = false;
            }
            if (replacementCheckBox.Checked && selectedEquipmentStatus.ID == 3)
            {
                ShowCustomMessageBox("อุปกรณ์ที่มีสถานะชำรุด จะไม่สามารถนำไปทดแทนได้\nกรุณาเลือกประเภทอุปกรณ์ที่ถูกต้อง");
                return false;
            }
            edit.Name = equipmentNameTextBox.Text;
            edit.Serial = equipmentSerialTextBox.Text;
            edit.SellDetails = sellDetailsRichTextBox.Text;
            edit.EDetails = equipmentDetailRichTextBox.Text;
            edit.InstallationDetails = InstallationDetailsRichTextBox.Text;
            edit.Replacement = replacementCheckBox.Checked;
            if (isComplete)
            {
                if (!string.IsNullOrEmpty(equipmentPhotoPath))
                {
                    SaveEquipmentPhoto();
                    edit.EPhotoPath = equipmentPhotoPath;
                }
                if (!string.IsNullOrEmpty(installationPlacePhotoPath))
                {
                    SaveInstallationPlacePhoto();
                    edit.OPlacePhotoPath = installationPlacePhotoPath;
                }
                if (!string.IsNullOrEmpty(acquisitionDocumentPath))
                {
                    SaveAcquisitionDocument();
                    edit.EDocumentPath = acquisitionDocumentPath;
                }         
            }
            return isComplete;
        }
        
        private void editEquipmentButton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                if (edit.Change())
                {
                    ShowCustomMessageBox("อุปกรณ์ถูกแก้ใขเรียบร้อย");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    ShowCustomMessageBox("ขั้นตอนการอัฟเดทข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
        //Open invoice
        private void invoiceLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (File.Exists(edit.EDocumentPath))
            {
                System.Diagnostics.Process.Start(edit.EDocumentPath);
            }
            else if (!string.IsNullOrEmpty(acquisitionDocumentPath))
            {
                ShowCustomMessageBox("ไม่สารมารถเปิดไฟล์ดังกล่าวได้\nหรือไฟล์อาจโดนลบ");
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
    }
}
