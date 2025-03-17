using System;
using System.Net;
using System.Net.Mail;

namespace Admin_Program.GlobalVariable
{
    class EmailService
    {
        public static void SendEmail(string item,int qty)
        {
            string smtpServer = "mail.nipponexpress-necl.co.th";
            int smtpPort = 5000;
            string fromEmail = "C.Nuttawut@nipponexpress-necl.co.th";
            string fromPassword = "CNut4727";
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
        public static void SendEmailForPlan(string pname, string m)
        {
            string smtpServer = "mail.nipponexpress-necl.co.th";
            int smtpPort = 5000;
            string fromEmail = "C.Nuttawut@nipponexpress-necl.co.th";
            string fromPassword = "CNut4727";
            string toEmail = "C.Nuttawut@nipponexpress-necl.co.th";

            try
            {
                MailMessage mail = new MailMessage
                {
                    From = new MailAddress(fromEmail),
                    Subject = "มีการอัฟเดทแผนจัดส่งวัสดุ ชื่อแผน :" + pname + " ประจำเดือน " + m + " ผู้อัฟเดท : "+ Global.userName,
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
