using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace LogicUniversity.Control
{
    public class EmailControl
    {
        public void SendEmail(string to, string subject, string body,List<string> cclist)
        {
            string from = "logicuniversity.edu.sg@gmail.com";
            string password = "logicuniversity@123";
            using (MailMessage mm = new MailMessage(from, to))
            {
                mm.Subject = subject;
                mm.Body = body;
                MailAddressCollection temp = mm.CC;
                foreach (string s in cclist)
                    temp.Add(s);
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
    }
}