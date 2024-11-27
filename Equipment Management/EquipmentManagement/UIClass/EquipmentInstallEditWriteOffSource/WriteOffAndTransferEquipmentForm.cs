using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Admin_Program.ObjectClass;
using Admin_Program.GlobalVariable;

namespace Admin_Program.UIClass.EquipmentInstallEditWriteOffSource
{
    public partial class WriteOffAndTransferEquipmentForm : Form
    {
        Equipment writeOffNTransfer;
        WriteOffNTransferDocumentAttachment docAttach;
        MainBackGroundFrom main;

        public event EventHandler UpdateGrid;

        public WriteOffAndTransferEquipmentForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            WriteOffGroupBox.Enabled = false;
            writeOffNTransfer = new Equipment(Global.ID);
            SetEquipmentCurrentStatus();
        }
        private void SetEquipmentCurrentStatus()
        {
            choseEquipmentTypeCombobox.Text = writeOffNTransfer.ETypeObj.EType;
            equipmentNameTextBox.Text = writeOffNTransfer.Name;
            equipmentSerialTextBox.Text = writeOffNTransfer.Serial;
            equipmentOwnerComboBox.Text = writeOffNTransfer.EOwnerObj.Owner;
            acquisitionComboBox.Text = writeOffNTransfer.AcquisitionObj.Accquire;
            equipmentInitialStatusComboBox.Text = writeOffNTransfer.EStatusObj.EStatus;
            replacementCheckBox.Checked = writeOffNTransfer.Replacement;
            priceTextBox.Text = writeOffNTransfer.Price.ToString();
            rentalBasisCombobox.Text = writeOffNTransfer.ERentalBasis?.Basis ?? string.Empty;
            installationDateTimePicker.Value = writeOffNTransfer.InsDate;
            if (!string.IsNullOrEmpty(writeOffNTransfer.EPhotoPath))
            {
                Global.LoadImageIntoPictureBox(writeOffNTransfer.EPhotoPath, equipmentPictureBox);
            }
            if (!string.IsNullOrEmpty(writeOffNTransfer.OPlacePhotoPath))
            {
                Global.LoadImageIntoPictureBox(writeOffNTransfer.OPlacePhotoPath, installationPlacePictureBox);
            }
            sellDetailsRichTextBox.Text = writeOffNTransfer.SellDetails;
            equipmentDetailRichTextBox.Text = writeOffNTransfer.EDetails;
            InstallationDetailsRichTextBox.Text = writeOffNTransfer.InstallationDetails;
        }
        private void attachWriteOffNTransferButton_Click(object sender, EventArgs e)
        {
            Global.equipmentGlobal = writeOffNTransfer;
            docAttach = new WriteOffNTransferDocumentAttachment();
            docAttach.Owner = main;
            docAttach.ShowDialog();
        }

        private void WriteOffAndTransferEquipmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdateGrid?.Invoke(this, EventArgs.Empty);
        }
    }
}
