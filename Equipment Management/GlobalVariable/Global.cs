using Admin_Program.ObjectClass;
using Admin_Program.CustomViewClass;
using System.IO;
using System;
using System.Net;
using System.Drawing;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Admin_Program.GlobalVariable
{
    class Global
    {
        public static int ID { get; set; }
        public static int EStatusID { get; set; }
        public static Equipment equipmentGlobal { get; set; }
        public static AllEquipmentView selectedEquipmentInJob { get; set; }
        public static AllEquipmentForCreatedJobView AllEquipmentForCreatedJobView { get; set; }
        public static AllPlanView selectedEquipmentInPlan { get; set; }
        public static AllProcessInPlanView selectedEquipmentInProcessedPlan { get; set; }
        public static string TargetFilePath { get; set; }
        private static System.Threading.Timer deletionTimer;
        public static void SetRowColor(DataGridViewRow row , int statusid)
        {
            switch (statusid)
            {
                case 1:
                    row.DefaultCellStyle.BackColor = Color.Lime;
                        break;
                case 2:
                    row.DefaultCellStyle.BackColor = Color.Gold;
                        break;
                case 3:
                    row.DefaultCellStyle.BackColor = Color.Tomato;
                        break;
                case 4:
                    row.DefaultCellStyle.BackColor = Color.PowderBlue;
                        break;
                case 5:
                    row.DefaultCellStyle.BackColor = Color.Orange;
                        break;
                case 6:
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                        break;
                case 7:
                    row.DefaultCellStyle.BackColor = Color.YellowGreen;
                        break;
                case 8:
                    row.DefaultCellStyle.BackColor = Color.HotPink;
                        break;
                case 9:
                    row.DefaultCellStyle.BackColor = Color.IndianRed;
                        break;
                case 10:
                    row.DefaultCellStyle.BackColor = Color.LightSteelBlue;
                        break;
            }
        }
        public static void SetRowColorByDayRemainning(DataGridViewRow row, int days)
        {
            if (days <= 7)
            {
                row.DefaultCellStyle.BackColor = Color.DeepPink;
            }
            else if (days <= 180)
            {
                row.DefaultCellStyle.BackColor = Color.Gold;
            }
            else
            {
                row.DefaultCellStyle.BackColor = Color.GreenYellow;
            }
        }

        public static string user = "equipment-managementblc5"; // equipment-managementblc5
        public static string pass = "Meg@lomaniac001";
        public static string Directory { get; set; }
        private static string GetFtpServerUrl()
        {
            return $"ftp://172.16.52.40/EquipmentManagementBLC5/{Directory}/";
        }
        private static string GetFtpServerUrlforSupply()
        {
            return $"ftp://172.16.52.40/SupplyManagementBLC5/{Directory}/";
        }

        //Uploading photo & PDF into Server ------------------------------------------------------------------------------------------
        public static void SaveFileToServer(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                string ftpServerUrl = GetFtpServerUrl();
                string ftpUsername = user;
                string ftpPassword = pass;

                try
                {
                    if (!FtpDirectoryExists(ftpServerUrl, ftpUsername, ftpPassword))
                    {
                        CreateFtpDirectory(ftpServerUrl, ftpUsername, ftpPassword);
                    }
                    UploadFileToFtp(filepath, ftpServerUrl, ftpUsername, ftpPassword);
                    filepath = Path.Combine(ftpServerUrl, Path.GetFileName(filepath));
                    TargetFilePath = filepath;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Failed to upload photo: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }

        public static void SaveFileToServerSupply(string filepath)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                string ftpServerUrl = GetFtpServerUrlforSupply();
                string ftpUsername = user;
                string ftpPassword = pass;

                try
                {
                    if (!FtpDirectoryExists(ftpServerUrl, ftpUsername, ftpPassword))
                    {
                        CreateFtpDirectory(ftpServerUrl, ftpUsername, ftpPassword);
                    }
                    UploadFileToFtp(filepath, ftpServerUrl, ftpUsername, ftpPassword);
                    filepath = Path.Combine(ftpServerUrl, Path.GetFileName(filepath));
                    TargetFilePath = filepath;
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show($"Failed to upload photo: {ex.Message}", "Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
        }
        private static bool FtpDirectoryExists(string ftpServerUrl,string ftpUsername,string ftpPassword)
        {
            try
            {
                // Create an FtpWebRequest to list the contents of the directory.
                var request = (FtpWebRequest)WebRequest.Create(ftpServerUrl);
                request.Method = WebRequestMethods.Ftp.ListDirectory;
                request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

                // Get the response from the server.
                using (var response = (FtpWebResponse)request.GetResponse())
                {
                    // If we receive a response, the directory exists.
                    return true;
                }
            }
            catch (WebException ex)
            {
                // Check if the status code indicates that the directory does not exist.
                var response = (FtpWebResponse)ex.Response;
                if (response != null && response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                throw; // Re-throw any other exceptions.
            }
        }
        private static void CreateFtpDirectory(string ftpServerUrl, string ftpUsername, string ftpPassword)
        {
            // Create an FtpWebRequest to make a new directory.
            var request = (FtpWebRequest)WebRequest.Create(ftpServerUrl);
            request.Method = WebRequestMethods.Ftp.MakeDirectory;
            request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);

            // Get the response from the server.
            using (var response = (FtpWebResponse)request.GetResponse())
            {
                // Check the status code to verify the directory was created.
                if (response.StatusCode != FtpStatusCode.PathnameCreated)
                {
                    throw new Exception("Failed to create directory on FTP server.");
                }
            }
        }
        private static void UploadFileToFtp(string sourceFilePath, string ftpServerUrl, string username, string password)
        {
            FileInfo fileInfo = new FileInfo(sourceFilePath);
            string targetUri = new Uri(new Uri(ftpServerUrl), fileInfo.Name).ToString();

            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetUri);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.Credentials = new NetworkCredential(username, password);
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = false;

            byte[] fileContents;
            using (FileStream fs = fileInfo.OpenRead())
            {
                fileContents = new byte[fs.Length];
                fs.Read(fileContents, 0, fileContents.Length);
            }
            request.ContentLength = fileContents.Length;
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(fileContents, 0, fileContents.Length);
            }
            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
            }
        }
        public static void DeleteFileFromFtp(string ftpFilePath)
        {
            string ftpServerUrl = GetFtpServerUrl();
            // Construct the full URI of the file to be deleted
            string targetUri = new Uri(new Uri(ftpServerUrl), ftpFilePath).ToString();

            // Create an FtpWebRequest to delete the file
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(targetUri);
            request.Method = WebRequestMethods.Ftp.DeleteFile;
            request.Credentials = new NetworkCredential(user, pass);
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = false;

            try
            {
                // Get the response from the server
                using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine($"Delete File Complete, status {response.StatusDescription}");
                }
            }
            catch (WebException ex)
            {
                // Handle any errors that occur during the delete process
                if (ex.Response != null)
                {
                    using (FtpWebResponse ftpResponse = (FtpWebResponse)ex.Response)
                    {
                        Console.WriteLine($"Error: {ftpResponse.StatusDescription}");
                    }
                }
                else
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
        //Reading photo into Server --------------------------------------------------------------------------------------------
        public static void LoadImageIntoPictureBox(string ftpFilePath, System.Windows.Forms.PictureBox pictureBox)
        {
            try
            {
                ImageLoader imageLoader = new ImageLoader();
                byte[] imageBytes = imageLoader.GetImgByte(ftpFilePath);

                if (imageBytes != null && imageBytes.Length > 0)
                {
                    Bitmap image = ImageLoader.ByteToImage(imageBytes);

                    // Dispose of the previous image if any
                    if (pictureBox.Image != null)
                    {
                        pictureBox.Image.Dispose();
                    }

                    // Assign the new image to the PictureBox
                    pictureBox.Image = image;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Failed to download image data.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error loading image: " + ex.Message);
            }
        }
        //Opening PDF from FTP Server ------------------------------------------------------------------------------------------
        public static void DownloadAndOpenPdf(string ftpUri)
        {
            string tempFilePath = Path.GetTempFileName();
            string pdfFilePath = Path.ChangeExtension(tempFilePath, ".pdf");
            // Download the PDF file from the FTP server
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUri);
            request.Method = WebRequestMethods.Ftp.DownloadFile;
            request.Credentials = new NetworkCredential(user, pass);

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (FileStream fileStream = new FileStream(pdfFilePath, FileMode.Create))
            {
                responseStream.CopyTo(fileStream);
            }

            // Open the downloaded PDF file
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = pdfFilePath;
                process.StartInfo.UseShellExecute = true; // Important: Allows using the system default application
                process.Start();

                // Start a timer to check for file deletion
                deletionTimer = new System.Threading.Timer(DeleteFileIfUnlocked, pdfFilePath, 10000, Timeout.Infinite);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while opening the PDF: {ex.Message}");
                // Clean up the file immediately if an error occurs
                DeleteFileIfUnlocked(pdfFilePath);
            }
        }
        private static void DeleteFileIfUnlocked(object state)
        {
            string pdfFilePath = (string)state;

            try
            {
                // Attempt to open the file with write access to see if it is unlocked
                using (FileStream stream = new FileStream(pdfFilePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    stream.Close();
                }

                // If we reach here, the file is unlocked
                File.Delete(pdfFilePath);
                deletionTimer?.Dispose(); // Stop the timer
            }
            catch (IOException)
            {
                // The file is still locked; do nothing and try again later
            }
        }

    }
}
