using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Equipment_Management.ObjectClass;
using Equipment_Management.GlobalVariable;

namespace Equipment_Management.UIClass.EquipmentInstallEditWriteOffSource
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
            if (!string.IsNullOrEmpty(writeOffNTransfer.EPhotoPath) && File.Exists(writeOffNTransfer.EPhotoPath))
            {
                if (equipmentPictureBox.Image != null)
                {
                    equipmentPictureBox.Image.Dispose();
                }
                equipmentPictureBox.Image = Image.FromFile(writeOffNTransfer.EPhotoPath);
            }
            if (!string.IsNullOrEmpty(writeOffNTransfer.OPlacePhotoPath) && File.Exists(writeOffNTransfer.OPlacePhotoPath))
            {
                if (installationPlacePictureBox.Image != null)
                {
                    installationPlacePictureBox.Image.Dispose();
                }
                installationPlacePictureBox.Image = Image.FromFile(writeOffNTransfer.OPlacePhotoPath);
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
