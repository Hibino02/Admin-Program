using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Admin_Program.GlobalVariable;

namespace Admin_Program.EquipmentManagement.UIClass.Zone
{
    public partial class ZoneManageForm : Form
    {
        List<ObjectClass.Zone> zList = new List<ObjectClass.Zone>();
        List<int> zid = new List<int>();
        List<string> zPhotoList = new List<string>();
        string zonePhoto;
        public ZoneManageForm()
        {
            InitializeComponent();
            this.Size = new Size(837,343);

            UpdateComponent();
        }

        private void UpdateComponent()
        {
            zList = ObjectClass.Zone.GetAllZone();
            zoneListcomboBox.Items.Clear();
            zPhotoList.Clear();
            zid.Clear();
            foreach (ObjectClass.Zone z in zList)
            {
                zoneListcomboBox.Items.Add(z.Name);
                zPhotoList.Add(z.Photo);
                zid.Add(z.ID);
            }
        }
        //Add photo for new Zone
        private void addachPhotobutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    zonePhoto = openFileDialog.FileName;

                    using (var tempImage = Image.FromFile(zonePhoto))
                    {
                        createZpictureBox.Image = new Bitmap(tempImage);
                    }
                }
            }
        }
        //Save photo
        private void SaveZonePhoto()
        {
            if (!string.IsNullOrEmpty(zonePhoto))
            {
                Global.Directory = "ZonePhoto";
                Global.SaveFileToServer(zonePhoto);
                Global.Directory = null;
                zonePhoto = Global.TargetFilePath;
            }
        }
        //Add Zone to database
        private void addZbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(zNametextBox.Text))
            {
                MessageBox.Show("กรุณาระบุชื่อ โซน");
            }
            if (string.IsNullOrEmpty(zonePhoto))
            {
                MessageBox.Show("กรุณาใส่รูปโซน");
            }
            else
            {
                SaveZonePhoto();
                ObjectClass.Zone z = new ObjectClass.Zone(zNametextBox.Text, zonePhoto, GlobalVariable.Global.warehouseID);
                if (z.Create())
                {
                    MessageBox.Show("สร้างโซน เสร็จสิ้น");
                    UpdateComponent();
                    zNametextBox.Clear();
                    createZpictureBox.Image = null;
                }
                else
                {
                    MessageBox.Show("การสร้าง โซนล้อเหลว");
                    Global.DeleteFileFromFtp(zonePhoto);
                }
            }
        }
        //Selecting zone
        private void zoneListcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (zoneListcomboBox.Items.Count == 0)
            {
                selectedZpictureBox.Image = null;
            }
            else
            {
                int selectItemIndex = zoneListcomboBox.SelectedIndex;
                if(selectItemIndex >= 0 && selectItemIndex < zPhotoList.Count)
                {
                    string selectItemPhoto = zPhotoList[selectItemIndex];
                    if (!string.IsNullOrEmpty(selectItemPhoto))
                    {
                        GlobalVariable.Global.LoadImageIntoPictureBox(selectItemPhoto, selectedZpictureBox);
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
        //Remove zone
        private void removeZbutton_Click(object sender, EventArgs e)
        {
            if(zoneListcomboBox.SelectedIndex < 0)
            {
                MessageBox.Show("กรุณาเลือกรายการที่ต้องการลบ");
                return;
            }
            else
            {
                int selectItemIndex = zoneListcomboBox.SelectedIndex;
                if(selectItemIndex > 0 && selectItemIndex < zid.Count)
                {
                    int selectId = zid[selectItemIndex];
                    ObjectClass.Zone z = new ObjectClass.Zone(selectId);
                    if (z.Remove())
                    {
                        MessageBox.Show("ลบโซนเรียบร้อย");
                        UpdateComponent();
                    }
                    else
                    {
                        MessageBox.Show("โซนนี้ถูกเลือกใช้อยู่");
                    }
                }
            }
        }
    }
}
