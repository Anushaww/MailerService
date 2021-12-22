using System;
using System.IO;
using System.Net.Mail;


namespace MailerService
{
    internal class Program
    {
        static void Main(string[] args)
        {


            SendHtmlFormattedEmail("");
        }

        private static void SendHtmlFormattedEmail(string subject)
        {
            String body = String.Empty;
            String TexthPath = @"I:\backup 18dec2021\html prog\jscript\proto5.html";
            using (StreamReader sr = new StreamReader(TexthPath, encoding: System.Text.Encoding.UTF8, detectEncodingFromByteOrderMarks: true))
            {
                body = sr.ReadToEnd();
            }
            using (MailMessage mailMessage = new MailMessage(from: "hasan.anusha@thinksys.com", to: "kumar.manoj@thinksys.com"))

            {

                mailMessage.Subject = "MailerService test";


                mailMessage.Body = body;

                mailMessage.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();

                smtp.Host = "smtp.gmail.com";

                smtp.EnableSsl = true;

                System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                NetworkCred.UserName = "hasan.anusha@thinksys.com";

                NetworkCred.Password ="thinksyshasananusha19@";

                smtp.UseDefaultCredentials = false;

                smtp.Credentials = NetworkCred;

                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(mailMessage);
            }
        }
    }
}