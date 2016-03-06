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
        private Model.LogicUniversityEntities ctx;
        public EmailControl()
        {
            ctx = new Model.LogicUniversityEntities();
        }

        //success = successfully send email
        //error = error in send email
        //fail = fail
        //notfound = userID not found
        public string sendEmailForForgotPIN(string userID)
        {
            string UserType = userID.Substring(0, 1);
            string email = "";
            string name = "";
            if (UserType.Equals("S"))
            {
                Model.StoreEmployee sEmp = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == userID).FirstOrDefault();
                if (sEmp == null)
                    return "notfound";
                email = sEmp.Email;
                name = sEmp.Name;
            }
            else if (UserType.Equals("E"))
            {
                Model.Employee emp = ctx.Employees.Where(x => x.EmployeeID == userID).FirstOrDefault();
                if (emp == null)
                    return "notfound";
                email = emp.Email;
                name = emp.Name;
            }
            Model.ForgotPassword pwd = new Model.ForgotPassword();
            pwd.UserID = userID;
            pwd.Status = "Active";
            Model.ForgotPassword fpwd = ctx.ForgotPasswords.Add(pwd);
            ctx.SaveChanges();
            try
            {
                string body = "Dear " + name + ",\r\n";
                body += "You have requested for a reset of your PIN to Logic University Stationery Store System.\r\n";
                body += "http://localhost:8236/WebView/ForgotPassword.aspx?code=" + fpwd.Code + "\r\n\r\n";
                body += "If you didn’t request a new PIN, please contact us immediately @ 8424-4865.\r\n\r\nThis is a system generated email, please donot reply.";
                string subject = "Reset PIN ";
                SendEmail(email, subject, body, new List<string>());
            }
            catch (Exception ex)
            {
                return "error";
            }
            return "success";
        }
        public void SendEmail(string to, string subject, string body, List<string> cclist)
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
                smtp.Port = 587; // works on my own machine
                //smtp.Port = 25; // works from ISS machine
                smtp.Send(mm);
                System.Diagnostics.Debug.WriteLine("Mail is sent");
            }
        }
    }
}