using System;
using System.Collections.Generic;
using System.Drawing;
using Equipment_Management.ObjectClass;
using System.Windows.Forms;
using Equipment_Management.CustomViewClass;
using System.Linq;
using Equipment_Management.GlobalVariable;
using Equipment_Management.CustomWindowComponents;
using System.IO;

namespace Equipment_Management.UIClass.Plan
{
    public partial class EditPlanProcessing : Form
    {
        public event EventHandler UpdateGrid;

        Equipment replaceEquipment;
        PlanProcess editPP;

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
        string oldWorkpermitProcessPath;
        string photoContractPath;
        string oldPhotoContractPath;

        double cost;

        public EditPlanProcessing()
        {
            InitializeComponent();
            this.Size = new Size(1480, 820);

            equipmentTypeList = EquipmentType.GetEquipmentTypeList();
            editPP = new PlanProcess(Global.selectedEquipmentInProcessedPlan.ID);

            equipmentListBindingsource = new BindingSource();

            //--------------------------------------------------------------------------------------------//
            //workpermit tooltips
            workpermitTooltips = new ToolTip();
            workpermitTooltips.InitialDelay = 0;
            workpermitTooltips.ReshowDelay = 0;
            workpermitTooltips.AutoPopDelay = 5000;

            pworkpermitlinkLabel.MouseEnter += pworkpermitlinkLabel_MouseEnter;
            pworkpermitlinkLabel.MouseLeave += pworkpermitlinkLabel_MouseLeave;

            UpdateEquipmentOnPlan();
            removeSelectedbutton.Enabled = false;
            if (Global.selectedEquipmentInProcessedPlan.REID>-1)
            {
                UpdateComponents();
                eReplaceNamelabel.Text = Global.selectedEquipmentInProcessedPlan.REName;
                eReplaceSeriallabel.Text = Global.selectedEquipmentInProcessedPlan.RESerial;
                replaceEquipment = new Equipment(Global.selectedEquipmentInProcessedPlan.REID ?? 0);
                rEquipmentListDataGridView.Enabled = false;
                removeSelectedbutton.Enabled = true;
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
            eNamelabel.Text = Global.selectedEquipmentInProcessedPlan.EName;
            eSeriallabel.Text = Global.selectedEquipmentInProcessedPlan.ESerial;
            if (!string.IsNullOrEmpty(Global.selectedEquipmentInProcessedPlan.EPhotoPath))
            {
                Global.LoadImageIntoPictureBox(Global.selectedEquipmentInProcessedPlan.EPhotoPath, equipmentpictureBox);
            }
            if (!string.IsNullOrEmpty(editPP.Contract))
            {
                Global.LoadImageIntoPictureBox(editPP.Contract, contractPictureBox);
            }
            startrichTextBox.Text = Global.selectedEquipmentInProcessedPlan.StartDetails;
            startDateTimePicker.Value = Global.selectedEquipmentInProcessedPlan.ProcessDate;
            vNameTextBox.Text = Global.selectedEquipmentInProcessedPlan.VenderName;
            vDetailsrichTextBox.Text = Global.selectedEquipmentInProcessedPlan.VenderDetails;
            pricetextBox.Text = Global.selectedEquipmentInProcessedPlan.Cost.ToString("F2");

            workpermitProcessPath = editPP.WorkPermit;
            oldWorkpermitProcessPath = editPP.WorkPermit;
            oldPhotoContractPath = editPP.Contract;

            // Update link label colors based on file existence
            if (!String.IsNullOrEmpty(oldWorkpermitProcessPath))
            {
                pworkpermitlinkLabel.LinkColor = System.Drawing.Color.Purple;
            }
        }
        private void UpdateReplaceEquipmentListGridView()
        {
            equipmentList = AllEquipmentView.GetPlanProcessReplaceEquipmentEditView();
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
            if (e.RowIndex >= 0)
            {
                int selectedID = (int)rEquipmentListDataGridView.Rows[e.RowIndex].Cells["ID"].Value;
                replaceEquipment = new Equipment(selectedID);

                eReplaceNamelabel.Text = replaceEquipment.Name;
                eReplaceSeriallabel.Text = replaceEquipment.Serial;
                if(replaceEquipment.EStatusObj.ID == 1)
                {
                    EquipmentStatus reStatus = new EquipmentStatus(2);
                    replaceEquipment.EStatusObj = reStatus;
                    replaceEquipment.Change();
                }
                else
                {
                    EquipmentStatus reStatus = new EquipmentStatus(6);
                    replaceEquipment.EStatusObj = reStatus;
                    replaceEquipment.Change();
                }
                rEquipmentListDataGridView.Enabled = false;
                removeSelectedbutton.Enabled = true;
            }
        }
        private void removeSelectedbutton_Click(object sender, EventArgs e)
        {
            if (replaceEquipment.EStatusObj.ID == 2)
            {
                EquipmentStatus reStatus = new EquipmentStatus(1);
                replaceEquipment.EStatusObj = reStatus;
                if (replaceEquipment.Change())
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์เป็น : "+ replaceEquipment.EStatusObj.EStatus);
                }
                else
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว");
                }
            }
            else
            {
                EquipmentStatus reStatus = new EquipmentStatus(7);
                replaceEquipment.EStatusObj = reStatus;
                if (replaceEquipment.Change())
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์เป็น : " + replaceEquipment.EStatusObj.EStatus);
                }
                else
                {
                    ShowCustomMessageBox("เปลี่ยนสถานะอุปกรณ์ล้มเหลว");
                }
            }
            eReplaceNamelabel.Text = "-";
            eReplaceSeriallabel.Text = "-";
            rEquipmentListDataGridView.Enabled = true;
            removeSelectedbutton.Enabled = false;
            UpdateReplaceEquipmentListGridView();
        }
        //Get PDF file path & call saving method
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
                    SaveWorkPermitPlanProcessingDocument();
                }
            }
        }
        //Get Photo path and stream to picturebox
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
                    // Get the path from user
                    photoContractPath = openFileDialog.FileName;
                    using (var tempImage = Image.FromFile(photoContractPath))
                    {
                        //Strem photo to picturebox
                        contractPictureBox.Image = new Bitmap(tempImage);
                    }
                }
            }
        }
        //Save photo & documents into folder
        private void SaveWorkPermitPlanProcessingDocument()
        {
            if (!string.IsNullOrEmpty(oldWorkpermitProcessPath))
            {
                Global.DeleteFileFromFtp(oldWorkpermitProcessPath);
            }
            if (!string.IsNullOrEmpty(workpermitProcessPath))
            {
                Global.Directory = "WorkPermitOnPlanProcessDocument";
                Global.SaveFileToServer(workpermitProcessPath);
                Global.Directory = null;
                workpermitProcessPath = Global.TargetFilePath;
                oldWorkpermitProcessPath = workpermitProcessPath;
            }
        }
        private void SaveContractPhoto()
        {
            if (!string.IsNullOrEmpty(oldPhotoContractPath))
            {
                Global.DeleteFileFromFtp(oldPhotoContractPath);
            }
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
                Global.DownloadAndOpenPdf(workpermitProcessPath);
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

        private bool CheackAllAttributes()
        {
            if (string.IsNullOrEmpty(pricetextBox.Text))
            {
                cost = 0;
            }
            else if (!double.TryParse(pricetextBox.Text, out cost))
            {
                ShowCustomMessageBox("กรุณาใส่ราคาเป็นตัวเลขที่ถูกต้อง");
                return false;
            }
            else if (cost < 0)
            {
                cost = 0;
            }
            if (!string.IsNullOrEmpty(photoContractPath))
            {
                SaveContractPhoto();
                editPP.Contract = photoContractPath;
            }
            if (!string.IsNullOrEmpty(workpermitProcessPath))
            {
                editPP.WorkPermit = workpermitProcessPath;
            }
            return true;
        }

        private void pRecordbutton_Click(object sender, EventArgs e)
        {
            if (CheackAllAttributes())
            {
                //Check if replace equipment is selected & not same as old one
                if(replaceEquipment!=null&& replaceEquipment.ID != Global.selectedEquipmentInProcessedPlan.REID)
                {
                    editPP.RE = replaceEquipment;
                }
                editPP.StartDetails = startrichTextBox.Text;
                editPP.ProcessDate = startDateTimePicker.Value;
                editPP.PSup = vNameTextBox.Text;
                editPP.PSupDetails = vDetailsrichTextBox.Text;
                editPP.Cost = cost;
                if (editPP.Change())
                {
                    ShowCustomMessageBox("ปรับปรุงแผนสมบูรณ์");
                    UpdateGrid?.Invoke(this, EventArgs.Empty);
                    Close();
                }
                else
                {
                    ShowCustomMessageBox("ปรับปรุงแผนล้มเหลว");
                    Global.DeleteFileFromFtp(workpermitProcessPath);
                    Global.DeleteFileFromFtp(photoContractPath);
                }
            }
        }
        //Event to active tooltips
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
