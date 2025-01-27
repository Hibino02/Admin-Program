using System;
using System.Net;
using System.Net.Mail;

namespace Admin_Program.GlobalVariable
{
    class EmailService
    {
        public static void SendEmail(string item,int qty)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string fromEmail = "networktruckfornecpf@gmail.com";
            string fromPassword = "hqyxypwprwzijiku";
            string toEmail = "C.Nuttawut@nipponexpress-necl.co.th";

            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "มีการอัฟเดทยอดวัสดุ รายการ :" + item + " เป็นจำนวนคงเหลือ " + qty,
                    Body = "แจ้งจากโปรแกรม การจัดการวัสดุ",
                    IsBodyHtml = false
                };
                mail.To.Add(toEmail);

                SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort)
                {
                    Credentials = new NetworkCredential(fromEmail, fromPassword),
                    EnableSsl = true
                };
                smtpClient.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
            }
        }
    }
}
