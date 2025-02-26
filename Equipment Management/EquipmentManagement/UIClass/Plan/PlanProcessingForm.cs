using System;
using System.Collections.Generic;
using System.Drawing;
using Admin_Program.ObjectClass;
using System.Windows.Forms;
using Admin_Program.CustomViewClass;
using System.Linq;
using Admin_Program.GlobalVariable;
using Admin_Program.CustomWindowComponents;
using System.IO;

namespace Admin_Program.UIClass.Plan
{
    public partial class PlanProcessingForm : Form
    {
        public event EventHandler UpdateGrid;
        ObjectClass.Plan plan;

        private ToolTip workpermitTooltips;

        List<EquipmentType> equipmentTypeList;
        List<int> equipmentTypeID = new List<int>();
        //List for filter equipments 
        List<AllEquipmentView> equipmentList;
        List<AllEquipmentView> originalEquipmentList;
        List<AllEquipmentView> eqipmentFilteredList;
        private int currentFilterID = -1; // Holds the currently selected filter ID

        BindingSource equipmentListBindingsource;

        string workpermitProcessPath;
        string photoContractPath;
        //Variable for creating planprocess
        double cost;
        Equipment replaceEquipment;
        PlanProcess newPp;

        public PlanProcessingForm()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);
            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            equipmentList = AllEquipmentView.GetPlanProcessReplaceEquipmentView();
            plan = new ObjectClass.Plan(Global.selectedEquipmentInPlan.ID);

            equipmentListBindingsource = new BindingSource();

            //--------------------------------------------------------------------------------------------//
            //ToolTips
            workpermitTooltips = new ToolTip();
            workpermitTooltips.InitialDelay = 0;
            workpermitTooltips.ReshowDelay = 0;
            workpermitTooltips.AutoPopDelay = 5000;

            pworkpermitlinkLabel.MouseEnter += pworkpermitlinkLabel_MouseEnter;
            pworkpermitlinkLabel.MouseLeave += pworkpermitlinkLabel_MouseLeave;

            UpdateComponents();
            UpdateEquipmentOnPlan();
            if(plan.Eqp.EStatusObj.ID != 7)
            {
                UpdateReplaceEquipmentListGridView();
            }
        }

        private void UpdateComponents()
        {
            //Equipment type components
            equipmentTypeList.Sort((x, y) => x.EType.CompareTo(y.EType));
            equipmentTypeComboBox.Items.Clear();
            equipmentTypeComboBox.Items.Add("--------------------------------------");
            equipmentTypeID.Add(-1);
            foreach (EquipmentType etype in equipmentTypeList)
            {
                equipmentTypeComboBox.Items.Add(etype.EType);
                equipmentTypeID.Add(etype.ID);
            }
        }
        private void UpdateEquipmentOnPlan()
        {
            eNamelabel.Text = Global.selectedEquipmentInPlan.EName;
            eSeriallabel.Text = Global.selectedEquipmentInPlan.ESerial;
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInPlan.EPhoto))
            {
                Global.LoadImageIntoPictureBox(Global.selectedEquipmentInPlan.EPhoto, equipmentpictureBox);
            }
        }
        private void UpdateReplaceEquipmentListGridView()
        {
            originalEquipmentList = new List<AllEquipmentView>(equipmentList);
            ApplyCurrentFilter();
        }
        private void ApplyCurrentFilter()
        {
            if (currentFilterID < 0)
            {
                eqipmentFilteredList = new List<AllEquipmentView>(originalEquipmentList);
            }
            else
            {
                eqipmentFilteredList = originalEquipmentList
                    .Where(eq => eq.ETypeID == currentFilterID)
                    .ToList();
            }
            equipmentListBindingsource.DataSource = eqipmentFilteredList;
            rEquipmentListDataGridView.DataSource = equipmentListBindingsource;

            FormatEquipmentListDataGridView();
        }
        //Setting Datagridview looks
        private void FormatEquipmentListDataGridView()
        {
            if (rEquipmentListDataGridView.Columns["ID"] != null)
            {
                rEquipmentListDataGridView.Columns["ID"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["Name"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["Name"];
                customColumn.HeaderText = "ชื่อเรียกอุปกรณ์";
                customColumn.Width = 250;
            }
            if (rEquipmentListDataGridView.Columns["Serial"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["Serial"];
                customColumn.HeaderText = "ชื่อทางบัญชี";
                customColumn.Width = 150;
            }
            if (rEquipmentListDataGridView.Columns["EDetails"] != null)
            {
                rEquipmentListDataGridView.Columns["EDetails"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["InsDate"] != null)
            {
                rEquipmentListDataGridView.Columns["InsDate"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EType"] != null)
            {
                rEquipmentListDataGridView.Columns["EType"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EOwner"] != null)
            {
                rEquipmentListDataGridView.Columns["EOwner"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EStatus"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["EStatus"];
                customColumn.HeaderText = "สถานะปัจจุบัน";
                customColumn.Width = 130;
            }
            if (rEquipmentListDataGridView.Columns["InsDetails"] != null)
            {
                var customColumn = rEquipmentListDataGridView.Columns["InsDetails"];
                customColumn.HeaderText = "รายละเอียดจุดที่ติดตั้ง";
                customColumn.Width = 220;
            }
            if (rEquipmentListDataGridView.Columns["ETypeID"] != null)
            {
                rEquipmentListDataGridView.Columns["ETypeID"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EStatusID"] != null)
            {
                rEquipmentListDataGridView.Columns["EStatusID"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["InstallEPhoto"] != null)
            {
                rEquipmentListDataGridView.Columns["InstallEPhoto"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EquipmentPhoto"] != null)
            {
                rEquipmentListDataGridView.Columns["EquipmentPhoto"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["Replacement"] != null)
            {
                rEquipmentListDataGridView.Columns["Replacement"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["EOwnerID"] != null)
            {
                rEquipmentListDataGridView.Columns["EOwnerID"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["IsEJob"] != null)
            {
                rEquipmentListDataGridView.Columns["IsEJob"].Visible = false;
            }
            if (rEquipmentListDataGridView.Columns["Zone"] != null)
            {
                rEquipmentListDataGridView.Columns["Zone"].Visible = false;
            }
        }
        //Event to filter by Equipment Type
        private void equipmentTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectTypeIndex = equipmentTypeComboBox.SelectedIndex;
            currentFilterID = selectTypeIndex >= 0 ? equipmentTypeID[selectTypeIndex] : -1;

            ApplyCurrentFilter();
        }
        private void equipmentTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            // Temporarily unsubscribe from the TextChanged event to avoid recursion
            equipmentTypeComboBox.TextChanged -= equipmentTypeComboBox_TextChanged;

            string typedText = equipmentTypeComboBox.Text;
            int currentCaretPosition = equipmentTypeComboBox.SelectionStart;

            // Filter items that start with the typed text
            var matchingItems = equipmentTypeComboBox.Items.Cast<string>()
                                         .Where(item => item.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                                         .ToList();

            // Only suggest and highlight if the user is typing and a match is found
            if (matchingItems.Any() && !string.IsNullOrEmpty(typedText))
            {
                string selectedItem = matchingItems.First();

                // Update the text and highlight the matching part only if the typed text is less than the selected item
                if (typedText.Length < selectedItem.Length && selectedItem.StartsWith(typedText, StringComparison.OrdinalIgnoreCase))
                {
                    equipmentTypeComboBox.Text = selectedItem;
                    equipmentTypeComboBox.SelectionStart = currentCaretPosition;
                    equipmentTypeComboBox.SelectionLength = selectedItem.Length - typedText.Length;
                }
            }
            else
            {
                // If no match found or text is empty, keep the typed text
                equipmentTypeComboBox.Text = typedText;
                equipmentTypeComboBox.SelectionStart = currentCaretPosition;
                equipmentTypeComboBox.SelectionLength = 0;
            }

            // Re-subscribe to the TextChanged event
            equipmentTypeComboBox.TextChanged += equipmentTypeComboBox_TextChanged;
        }
        private void eSearchtextBox_TextChanged(object sender, EventArgs e)
        {
            string searchText = eSearchtextBox.Text.ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                ApplyCurrentFilter(); // Reapply the current filter if the search box is empty
            }
            else
            {
                // Filter the already filtered list based on the search text
                var searchResults = eqipmentFilteredList
                    .Where(eq =>
                        eq.Name.ToLower().Contains(searchText) ||
                        eq.Serial.ToLower().Contains(searchText) ||
                        eq.InsDetails.ToLower().Contains(searchText))
                    .ToList();

                equipmentListBindingsource.DataSource = searchResults;
                rEquipmentListDataGridView.DataSource = equipmentListBindingsource;
            }
        }
        //Event to add and remove replacement equipment
        private void rEquipmentListDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                int selectedID = (int)rEquipmentListDataGridView.Rows[e.RowIndex].Cells["ID"].Value;
                Global.selectedEquipmentInJob = null;
                Global.selectedEquipmentInJob = originalEquipmentList.FirstOrDefault(eq => eq.ID == selectedID);

                eReplaceNamelabel.Text = Global.selectedEquipmentInJob.Name;
                eReplaceSeriallabel.Text = Global.selectedEquipmentInJob.Serial;
                rEquipmentListDataGridView.Enabled = false;
            }
        }
        private void removeSelectedbutton_Click(object sender, EventArgs e)
        {
            Global.selectedEquipmentInJob = null;
            eReplaceNamelabel.Text = "-";
            eSeriallabel.Text = "-";
            rEquipmentListDataGridView.Enabled = true;
        }
        //Get PDF file path
        private void workPermitbutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workpermitProcessPath = openFileDialog.FileName;
                    pworkpermitlinkLabel.LinkColor = System.Drawing.Color.Purple;
                }
            }
        }
        //Get Photo file path
        private void pcontractbutton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = false;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path from user
                    photoContractPath = openFileDialog.FileName;
                    using (var tempImage = Image.FromFile(photoContractPath))
                    {
                        //Strem photo to picturebox
                        contractPictureBox.Image = new Bitmap(tempImage);
                    }
                }
            }
        }
        //Save documents into folder
        private void SavePlanProcessWorkpermit()
        {
            if (!string.IsNullOrEmpty(workpermitProcessPath))
            {
                Global.Directory = "WorkPermitOnPlanProcessDocument";
                Global.SaveFileToServer(workpermitProcessPath);
                Global.Directory = null;
                workpermitProcessPath = Global.TargetFilePath;
            }
        }
        private void SavePhotoContract()
        {
            if (!string.IsNullOrEmpty(photoContractPath))
            {
                Global.Directory = "ContractPhoto";
                Global.SaveFileToServer(photoContractPath);
                Global.Directory = null;
                photoContractPath = Global.TargetFilePath;
            }
        }
        //Open WorkPermit
        private void pworkpermitlinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(workpermitProcessPath))
            {
                System.Diagnostics.Process.Start(workpermitProcessPath);
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
        //Check All
        private bool CheckAllAttribute()
        {
            if (string.IsNullOrEmpty(vNameTextBox.Text))
            {
                ShowCustomMessageBox("กรุณาใส่ชื่อผู้รับเหมา");
                return false;
            }
            if (string.IsNullOrEmpty(pricetextBox.Text))
            {
                cost = 0;
            }
            else if(!double.TryParse(pricetextBox.Text,out cost))
            {
                ShowCustomMessageBox("กรุณาใส่ราคาเป็นตัวเลขที่ถูกต้อง");
                return false;
            }
            else if(cost < 0)
            {
                cost =0;
            }
            if(Global.selectedEquipmentInJob!=null)
            {
                replaceEquipment = new Equipment(Global.selectedEquipmentInJob.ID);
            }
            SavePlanProcessWorkpermit();
            SavePhotoContract();
            return true;
        }
        //Create process
        private void pRecordbutton_Click(object sender, EventArgs e)
        {
            if (CheckAllAttribute())
            {
                newPp = new ObjectClass.PlanProcess(Global.warehouseID,Global.selectedEquipmentInPlan.ID, startDateTimePicker.Value
                    , startrichTextBox.Text, vNameTextBox.Text, vDetailsrichTextBox.Text, cost, workpermitProcessPath
                    , photoContractPath, null, null, replaceEquipment, null);
                if (newPp.Create())
                {
                    //Update equipment status
                    Equipment eq = new Equipment(Global.selectedEquipmentInPlan.EID);
                    EquipmentStatus es = new EquipmentStatus(8);
                    eq.EStatusObj = es;
                    if (eq.Change())
                    {
                        ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ในแผนเป็น : ซ่อมบำรุง(อยู่ในแผน)");
                    }
                    else
                    {
                        ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ในแผนล้มเหลว กรุณาติดต่อผู้ดูแล");
                    }
                    if(replaceEquipment!= null)
                    {
                        if(replaceEquipment.EStatusObj.ID == 1)
                        {
                            EquipmentStatus res = new EquipmentStatus(2);
                            replaceEquipment.EStatusObj = res;
                            if (replaceEquipment.Change())
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนเป็น : กำลังปฎิบัติงาน");
                            }
                            else
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนล้มเหลว");
                            }
                        }
                        else
                        {
                            EquipmentStatus res = new EquipmentStatus(6);
                            replaceEquipment.EStatusObj = res;
                            if (replaceEquipment.Change())
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนเป็น : กำลังปฎิบัติงาน(อยู่ในแผน)");
                            }
                            else
                            {
                                ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ทดแทนล้มเหลว");
                            }
                        }
                    }
                    ShowCustomMessageBox("แผนกำลังถูกดำเนินการ");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    Global.DeleteFileFromFtp(workpermitProcessPath);
                    Global.DeleteFileFromFtp(photoContractPath);
                    ShowCustomMessageBox("ขั้นตอนการสร้างข้อมูลลงใน ฐานข้อมูลเกิดความผิดพลาด กรุณาติดต่อผู้ดูแล");
                }
            }
        }
        //Tooltips Event
        private void pworkpermitlinkLabel_MouseEnter(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(workpermitProcessPath))
            {
                workpermitTooltips.Show($"Attached File: {Path.GetFileName(workpermitProcessPath)}", pworkpermitlinkLabel);
            }
            else
            {
                workpermitTooltips.Show("No file attached", pworkpermitlinkLabel);
            }
        }
        private void pworkpermitlinkLabel_MouseLeave(object sender, EventArgs e)
        {
            workpermitTooltips.Hide(pworkpermitlinkLabel);
        }

        private void rEquipmentListDataGridView_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            int statusID = (int)rEquipmentListDataGridView.Rows[e.RowIndex].Cells["EStatusID"].Value;

            Global.SetRowColor(rEquipmentListDataGridView.Rows[e.RowIndex], statusID);
        }
    }
}
