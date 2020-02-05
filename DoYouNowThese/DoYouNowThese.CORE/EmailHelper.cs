using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace DoYouNowThese.CORE
{
   public static class EmailHelper
    {
        public static void Mail(string sendMailAdress, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("doyounowthese@gmail.com");
            MailAddress to = new MailAddress(sendMailAdress);
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body = body;

            NetworkCredential info = new NetworkCredential("doyounowthese@gmail.com", "ibanez756q7");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);

        }
    }
}
