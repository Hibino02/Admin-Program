using Equipment_Management.ObjectClass;
using Equipment_Management.CustomViewClass;
using System.IO;
using System.Windows.Forms;
using System;
using System.Net;
using System.Drawing;
using System.Diagnostics;

namespace Equipment_Management.GlobalVariable
{
    class Global
    {
        public static int ID { get; set; }
        public static int EStatusID { get; set; }
        public static Equipment equipmentGlobal { get; set; }
        public static AllEquipmentView selectedEquipmentInJob { get; set; }
        public static string TargetFilePath { get; set; }

        public static string user = "TEST"; // equipment-managementblc5
        public static string pass = "Meg@lomaniac001";
        //Uploading photo into Server ------------------------------------------------------------------------------------------
        public static void SaveFileToServer(string filepath, string directory)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                string ftpServerUrl = $"ftp://192.168.1.116/TESTSERVER/{directory}/"; // change ip for local use
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
                    MessageBox.Show($"Failed to upload photo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        //Reading photo into Server --------------------------------------------------------------------------------------------
        public static void LoadImageIntoPictureBox(string ftpFilePath, PictureBox pictureBox)
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
                    MessageBox.Show("Failed to download image data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
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

                // The process might not be available for waiting if the user is prompted to select a program
                if (!process.HasExited)
                {
                    process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while opening the PDF: {ex.Message}");
            }
            finally
            {
                // Delete the file after the process has exited or failed to start
                if (File.Exists(pdfFilePath))
                {
                    File.Delete(pdfFilePath);
                    Console.WriteLine("File deleted.");
                }
            }
        }

    }
}
