using System.Drawing;
using System.IO;
using System.Net;
using Equipment_Management.GlobalVariable;

public class ImageLoader
{
    private string ftpUsername = Global.user; // Replace with your FTP username
    private string ftpPassword = Global.pass; // Replace with your FTP password

    // Method to download image data from FTP server
    public byte[] GetImgByte(string ftpFilePath)
    {
        using (WebClient ftpClient = new WebClient())
        {
            ftpClient.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
            byte[] imageBytes = ftpClient.DownloadData(ftpFilePath);
            return imageBytes;
        }
    }

    // Method to convert byte array to Bitmap image
    public static Bitmap ByteToImage(byte[] blob)
    {
        using (MemoryStream mStream = new MemoryStream(blob))
        {
            Bitmap bm = new Bitmap(mStream);
            return bm;
        }
    }
}