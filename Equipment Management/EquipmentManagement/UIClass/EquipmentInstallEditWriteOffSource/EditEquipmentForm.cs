﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Admin_Program.ObjectClass;
using Admin_Program.UIClass.CreateWindowComponent;
using Admin_Program.GlobalVariable;
using System.IO;
using Admin_Program.CustomWindowComponents;
using Admin_Program.EquipmentManagement.UIClass.EquipmentInstallEditWriteOffSource;
using Admin_Program.EquipmentManagement.ObjectClass;

namespace Admin_Program.UIClass.EquipmentInstallationSource
{
    public partial class EditEquipmentForm : Form
    {
        Equipment edit;
        MainBackGroundFrom main;
        public event EventHandler UpdateGrid;

        private ToolTip accToolTip;
        private ToolTip writeoffToolTip;

        string equipmentPhotoPath;
        string oldEquipmentPhotoPath;
        string installationPlacePhotoPath;
        string oldInstallationPlacePhotoPath;
        string acquisitionDocumentPath;
        string oldAcquisitionDocumentPath;
        string writeoffTransferDocumentPath;

        private CreateWindow create;
        private EquipmentTypeManagementForm eqManage;
        //variable for update components
        List<EquipmentType> equipmentTypeList;
        List<EquipmentOwner> equipmentOwnerList;
        List<Acquisition> equipmentAcquisitionList;
        List<EquipmentStatus> equipmentInitialStatusList;
        List<RentalBasis> rentalBasisList;
        List<Zone> zoneList;
        //variable for track primarykey from combobox
        private List<int> equipmentTypeID = new List<int>();
        private List<int> equipmentOwnerID = new List<int>();
        private List<int> equipmentAcquisitionID = new List<int>();
        private List<int> equipmentInitialStatusID = new List<int>();
        private List<int> rentalBasisID = new List<int>();
        private List<string> zPhotoList = new List<string>();
        private List<int> zoneIDList = new List<int>();
        //variable for create selected object after choseen combobox
        EquipmentType selectedEquipmentType;
        EquipmentOwner selectedEquipmentOwner;
        EquipmentStatus selectedEquipmentStatus;
        RentalBasis selectedRentalBasis;
        Zone selectedZone;
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
            zoneList = new List<Zone>();
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

            //--------------------------------------------------------------------------------------------//
            //AccToolTip
            accToolTip = new ToolTip();
            accToolTip.InitialDelay = 0;
            accToolTip.ReshowDelay = 0;
            accToolTip.AutoPopDelay = 5000;

            invoiceLinkLabel.MouseEnter += invoiceLinkLabel_MouseEnter;
            invoiceLinkLabel.MouseLeave += invoiceLinkLabel_MouseLeave;

            //--------------------------------------------------------------------------------------------//
            //WriteOffToolTip
            writeoffToolTip = new ToolTip();
            writeoffToolTip.InitialDelay = 0;
            writeoffToolTip.ReshowDelay = 0;
            writeoffToolTip.AutoPopDelay = 5000;

            writeOfflinkLabel.MouseEnter += writeOfflinkLabel_MouseEnter;
            writeOfflinkLabel.MouseLeave += writeOfflinkLabel_MouseLeave;

            acquisitionComboBox.Enabled = false;
            UpdateComponents();
            SetEquipmentCurrentStatus();
        }
        private void UpdateComponents()
        {
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            choseEquipmentTypeCombobox.Items.Clear();
            equipmentTypeID.Clear();
            foreach (EquipmentType eqt in equipmentTypeList)
            {
                choseEquipmentTypeCombobox.Items.Add(eqt.EType);
                equipmentTypeID.Add(eqt.ID);
            }
            equipmentOwnerList = EquipmentOwner.GetEquipmentOwnerList();
            equipmentOwnerList.Sort((x, y) => x.Owner.CompareTo(y.Owner));
            equipmentOwnerComboBox.Items.Clear();
            equipmentOwnerID.Clear();
            foreach (EquipmentOwner eqo in equipmentOwnerList)
            {
                equipmentOwnerComboBox.Items.Add(eqo.Owner);
                equipmentOwnerID.Add(eqo.ID);
            }
            equipmentAcquisitionList = Acquisition.GetAcquisitionList();
            equipmentAcquisitionList.Sort((x, y) => x.Accquire.CompareTo(y.Accquire));
            acquisitionComboBox.Items.Clear();
            equipmentAcquisitionID.Clear();
            foreach (Acquisition acc in equipmentAcquisitionList)
            {
                acquisitionComboBox.Items.Add(acc.Accquire);
                equipmentAcquisitionID.Add(acc.ID);
            }
            if(edit.EStatusObj.ID == 1 || edit.EStatusObj.ID == 2 || edit.EStatusObj.ID == 3)
            {
                equipmentInitialStatusList = EquipmentStatus.GetEquipmentStatusList();
                equipmentInitialStatusComboBox.Items.Clear();
                equipmentInitialStatusID.Clear();
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
                equipmentInitialStatusID.Clear();
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
            rentalBasisID.Clear();
            foreach (RentalBasis rent in rentalBasisList)
            {
                rentalBasisCombobox.Items.Add(rent.Basis);
                rentalBasisID.Add(rent.ID);
            }
            zoneList = Zone.GetAllZone();
            if(zoneList != null)
            {
                zoneList.Sort((x, y) => x.Name.CompareTo(y.Name));
                zonecomboBox.Items.Clear();
                zPhotoList.Clear();
                zoneIDList.Clear();
                foreach (Zone z in zoneList)
                {
                    zonecomboBox.Items.Add(z.Name);
                    zPhotoList.Add(z.Photo);
                    zoneIDList.Add(z.ID);
                }
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
            if(edit.ERentalBasis != null && edit.ERentalBasis.ID > -1)
            {
                rentalBasisCombobox.Text = edit.ERentalBasis.Basis;
            }
            installationDateTimePicker.Value = edit.InsDate;
            if(!string.IsNullOrEmpty(edit.EPhotoPath))
            {
                Global.LoadImageIntoPictureBox(edit.EPhotoPath, equipmentPictureBox);
            }
            if (!string.IsNullOrEmpty(edit.OPlacePhotoPath))
            {
                Global.LoadImageIntoPictureBox(edit.OPlacePhotoPath, installationPlacePictureBox);
            }
            zonecomboBox.SelectedItem = edit.Zone?.Name;
            int zIndex = edit.Zone != null ? zonecomboBox.Items.IndexOf(edit.Zone.Name) : -1;
            if (zIndex != -1)
            {
                string matchP = zPhotoList[zIndex];
                Global.LoadImageIntoPictureBox(matchP, selectedZpictureBox);
            }
            sellDetailsRichTextBox.Text = edit.SellDetails;
            equipmentDetailRichTextBox.Text = edit.EDetails;
            InstallationDetailsRichTextBox.Text = edit.InstallationDetails;
            if(edit.EStatusObj.ID != 1 && edit.EStatusObj.ID != 2 && edit.EStatusObj.ID != 6 &&
                edit.EStatusObj.ID != 7 && edit.EStatusObj.ID != 3)
            {
                replacementCheckBox.Enabled = false;
            }
            acquisitionDocumentPath = edit.EDocumentPath;
            oldAcquisitionDocumentPath = edit.EDocumentPath;

            equipmentPhotoPath = edit.EPhotoPath;
            oldEquipmentPhotoPath = edit.EPhotoPath;

            installationPlacePhotoPath = edit.OPlacePhotoPath;
            oldInstallationPlacePhotoPath = edit.OPlacePhotoPath;

            writeoffTransferDocumentPath = edit.WriteOffPath;

            // Update link label colors based on file existence
            if (!String.IsNullOrEmpty(oldAcquisitionDocumentPath))
            {
                invoiceLinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
            if (!String.IsNullOrEmpty(writeoffTransferDocumentPath))
            {
                writeOfflinkLabel.LinkColor = System.Drawing.Color.Purple;
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
                    EquipmentType newEqt = new EquipmentType(receiveType,Global.warehouseID);
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
                    EquipmentOwner newEqo = new EquipmentOwner(receiveOwner,Global.warehouseID);
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

                    using (var tempImage = Image.FromFile(equipmentPhotoPath))
                    {
                        //Strem photo to picturebox
                        equipmentPictureBox.Image = new Bitmap(tempImage);
                    }
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

                    using (var tempImage = Image.FromFile(installationPlacePhotoPath))
                    {
                        //Strem photo to picturebox
                        installationPlacePictureBox.Image = new Bitmap(tempImage);
                    }
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
                    invoiceLinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
            }
        }
       
        //Save photo & documents into folder
        private void SaveEquipmentPhoto()
        {
            if (!string.IsNullOrEmpty(oldEquipmentPhotoPath))
            {
                Global.DeleteFileFromFtp(oldEquipmentPhotoPath);
            }
            if (!string.IsNullOrEmpty(equipmentPhotoPath))
            {
                Global.Directory = "EquipmentPhoto";
                Global.SaveFileToServer(equipmentPhotoPath);
                Global.Directory = null;
                equipmentPhotoPath = Global.TargetFilePath;
            }
        }
        private void SaveInstallationPlacePhoto()
        {
            if(!string.IsNullOrEmpty(oldInstallationPlacePhotoPath))
            {
                Global.DeleteFileFromFtp(oldInstallationPlacePhotoPath);
            }
            if (!string.IsNullOrEmpty(installationPlacePhotoPath))
            {
                Global.Directory = "InstallationPlacePhoto";
                Global.SaveFileToServer(installationPlacePhotoPath);
                Global.Directory = null;
                installationPlacePhotoPath = Global.TargetFilePath;
            }
        }
        private void SaveAcquisitionDocument()
        {
            if (!string.IsNullOrEmpty(oldAcquisitionDocumentPath))
            {
                Global.DeleteFileFromFtp(oldAcquisitionDocumentPath);
            }
            if (!string.IsNullOrEmpty(acquisitionDocumentPath))
            {
                Global.Directory = "AcquisitionDocument";
                Global.SaveFileToServer(acquisitionDocumentPath);
                Global.Directory = null;
                acquisitionDocumentPath = Global.TargetFilePath;
                oldAcquisitionDocumentPath = acquisitionDocumentPath;
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
            int selectZoneIndex = zonecomboBox.SelectedIndex;
            if (selectZoneIndex >= 0)
            {
                int selectedZoneID = zoneIDList[selectZoneIndex];
                selectedZone = new Zone(selectedZoneID);
                edit.Zone = selectedZone;
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
            edit.InsDate = installationDateTimePicker.Value;
            if (isComplete)
            {
                if (equipmentPhotoPath != oldEquipmentPhotoPath)
                {
                    SaveEquipmentPhoto();
                    edit.EPhotoPath = equipmentPhotoPath;
                }
                if (installationPlacePhotoPath != oldInstallationPlacePhotoPath)
                {
                    SaveInstallationPlacePhoto();
                    edit.OPlacePhotoPath = installationPlacePhotoPath;
                }
                if (acquisitionDocumentPath != oldAcquisitionDocumentPath)
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
                    Global.DeleteFileFromFtp(equipmentPhotoPath);
                    Global.DeleteFileFromFtp(installationPlacePhotoPath);
                    Global.DeleteFileFromFtp(acquisitionDocumentPath);
                    ShowCustomMessageBox("ขั้นตอนการอัฟเดทข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
        //Open invoice
        private void invoiceLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(acquisitionDocumentPath != oldAcquisitionDocumentPath)
            {
                if (!string.IsNullOrEmpty(acquisitionDocumentPath))
                {
                    System.Diagnostics.Process.Start(acquisitionDocumentPath);
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(oldAcquisitionDocumentPath))
                {
                    Global.DownloadAndOpenPdf(oldAcquisitionDocumentPath);
                }
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
        //Event to drive tooltip accDocument
        private void invoiceLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(acquisitionDocumentPath))
            {
                accToolTip.Show($"Attached File: {Path.GetFileName(acquisitionDocumentPath)}", invoiceLinkLabel);
            }
            else
            {
                accToolTip.Show("No file attached", invoiceLinkLabel);
            }
        }
        private void invoiceLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            accToolTip.Hide(invoiceLinkLabel);
        }
        //Open Write Off
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(writeoffTransferDocumentPath))
            {
                Global.DownloadAndOpenPdf(writeoffTransferDocumentPath);
            }
            else
            {
                ShowCustomMessageBox("ไม่เคยมีการบันทึกไฟล์");
            }
        }
        //Event to drive writeoff tooltip
        private void writeOfflinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(writeoffTransferDocumentPath))
            {
                writeoffToolTip.Show($"Attached File: {Path.GetFileName(writeoffTransferDocumentPath)}", writeOfflinkLabel);
            }
            else
            {
                writeoffToolTip.Show("No file attached", writeOfflinkLabel);
            }
        }
        private void writeOfflinkLabel_MouseLeave(object sender, EventArgs e)
        {
            writeoffToolTip.Hide(writeOfflinkLabel);
        }
        //Call Equipment type manage window
        private void manageTypeButton_Click(object sender, EventArgs e)
        {
            eqManage = new EquipmentTypeManagementForm();
            eqManage.Owner = main;
            eqManage.updateEquipmentType += RefreshComponent;
            eqManage.ShowDialog();
        }
        //Refresh components after delete
        private void RefreshComponent(object sender, EventArgs e)
        {
            UpdateComponents();
        }
        //Zone selection
        private void zonecomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zonecomboBox.Items.Count == 0)
            {
                selectedZpictureBox.Image = null;
            }
            else
            {
                int selectItemIndex = zonecomboBox.SelectedIndex;
                if (selectItemIndex >= 0 && selectItemIndex < zPhotoList.Count)
                {
                    string selectItemPhoto = zPhotoList[selectItemIndex];
                    if (!string.IsNullOrEmpty(selectItemPhoto))
                    {
                        Global.LoadImageIntoPictureBox(selectItemPhoto, selectedZpictureBox);
                    }
                    else
                    {
                        selectedZpictureBox.Image = null;
                    }
                }
                else
                {
                    selectedZpictureBox.Image = null;
                }
            }
        }
    }
}
