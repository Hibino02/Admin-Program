using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.UIClass.CreateWindowComponent;
using System.IO;
using Equipment_Management.CustomWindowComponents;
using Equipment_Management.GlobalVariable;
using System.Linq;

namespace Equipment_Management.UIClass.InstallationSource
{
    public partial class InstallationEquipment : Form
    {
        MainBackGroundFrom main;
        string equipmentPhotoPath;
        string installationPlacePhotoPath;
        string acquisitionDocumentPath;

        private ToolTip invoiceTooltip;

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

            //--------------------------------------------------------------------------------------------//
            //invoice Tooltip
            invoiceTooltip = new ToolTip();
            invoiceTooltip.InitialDelay = 0;
            invoiceTooltip.ReshowDelay = 0;
            invoiceTooltip.AutoPopDelay = 5000;

            invoiceLinkLabel.MouseEnter += invoiceLinkLabel_MouseEnter;
            invoiceLinkLabel.MouseLeave += invoiceLinkLabel_MouseLeave;

            UpdateComponents();
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
            rentalBasisList = RentalBasis.GetRentalBasisList();
            rentalBasisList.Sort((x, y) => x.Basis.CompareTo(y.Basis));
            rentalBasisCombobox.Items.Clear();
            rentalBasisID.Clear();
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
        
        //Save photo & documents into folder
        private void SaveEquipmentPhoto()
        {
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
            if (!string.IsNullOrEmpty(acquisitionDocumentPath))
            {
                Global.Directory = "AcquisitionDocument";
                Global.SaveFileToServer(acquisitionDocumentPath);
                Global.Directory = null;
                acquisitionDocumentPath = Global.TargetFilePath;
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
                priceFromTextBox = 0;
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
                    Global.DeleteFileFromFtp(equipmentPhotoPath);
                    Global.DeleteFileFromFtp(installationPlacePhotoPath);
                    Global.DeleteFileFromFtp(acquisitionDocumentPath);
                    ShowCustomMessageBox("ขั้นตอนการสร้างข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
        //Open Invoice
        private void invoiceLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(acquisitionDocumentPath))
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
        //Event to drive tooltips invoice link label
        private void invoiceLinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(acquisitionDocumentPath))
            {
                invoiceTooltip.Show($"Attached File: {Path.GetFileName(acquisitionDocumentPath)}", invoiceLinkLabel);
            }
            else
            {
                invoiceTooltip.Show("No file attached", invoiceLinkLabel);
            }
        }
        private void invoiceLinkLabel_MouseLeave(object sender, EventArgs e)
        {
            invoiceTooltip.Hide(invoiceLinkLabel);
        }

        private void choseEquipmentTypeCombobox_TextChanged(object sender, EventArgs e)
        {
            // Temporarily unsubscribe from the TextChanged event to avoid recursion
            choseEquipmentTypeCombobox.TextChanged -= choseEquipmentTypeCombobox_TextChanged;

            string typedText = choseEquipmentTypeCombobox.Text;
            int currentCaretPosition = choseEquipmentTypeCombobox.SelectionStart;

            // Filter items that start with the typed text
            var matchingItems = choseEquipmentTypeCombobox.Items.Cast<string>()
                                         .Where(item => item.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                                         .ToList();

            // Only suggest and highlight if the user is typing and a match is found
            if (matchingItems.Any() && !string.IsNullOrEmpty(typedText))
            {
                string selectedItem = matchingItems.First();

                // Update the text and highlight the matching part only if the typed text is less than the selected item
                if (typedText.Length < selectedItem.Length && selectedItem.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                {
                    choseEquipmentTypeCombobox.Text = selectedItem;
                    choseEquipmentTypeCombobox.SelectionStart = currentCaretPosition;
                    choseEquipmentTypeCombobox.SelectionLength = selectedItem.Length - typedText.Length;
                }
            }
            else
            {
                // If no match found or text is empty, keep the typed text
                choseEquipmentTypeCombobox.Text = typedText;
                choseEquipmentTypeCombobox.SelectionStart = currentCaretPosition;
                choseEquipmentTypeCombobox.SelectionLength = 0;
            }

            // Re-subscribe to the TextChanged event
            choseEquipmentTypeCombobox.TextChanged += choseEquipmentTypeCombobox_TextChanged;
        }
    }
}
