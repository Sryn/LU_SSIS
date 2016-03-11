using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Threading;

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
        public string sendEmailToRepresentativeToCollect(string DeptID)
        {
            //To build email and send
            return "success";
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
            List<string> tolist = new List<string>();
            tolist.Add(email);
            try
            {
                string body = "Dear "+ name + ",\r\n";
                body += "You have requested for a reset of your PIN to Logic University Stationery Store System.\r\n";
                body += "http://localhost:8236/WebView/ForgotPassword.aspx?code="+ fpwd.Code+ "\r\n\r\n";
                body += "If you didn’t request a new PIN, please contact us immediately @ 8424-4865.\r\n\r\nThis is a system generated email, please donot reply.";
                string subject = "Reset PIN ";
                SendEmail(tolist, subject, body, new List<string>());
            }
            catch(Exception ex)
            {
                return "error";
            }
            return "success";
        }
        public string sendEmailForChangeDeliveryDate(string sEmpID)
        {
            List<Model.Employee> empList = ctx.Employees.Where(x => x.Role == "Department Head" || x.Role == "Representative").ToList();
            List<Model.StoreEmployee> sEmpList = ctx.StoreEmployees.ToList();
            Model.CollectionPoint clp = ctx.CollectionPoints.FirstOrDefault();
            List<string> toList = new List<string>();
            List<string> ccList = new List<string>();
            Model.Notification noti;

            foreach (Model.Employee emp in empList)
            {
                if(emp.Email!=null)
                    toList.Add(emp.Email);
                noti = new Model.Notification();
                noti.UserID = emp.EmployeeID;
                noti.NotificationDate = DateTime.Today;
                noti.Message = "Date for Stationery Collection has been changed To " + clp.FirstCollectionDate + " and " + clp.SecondCollectionDate + ".";
                noti.FromUser = sEmpID;
                ctx.Notifications.Add(noti);
                ctx.SaveChanges();
            }
            foreach (Model.StoreEmployee sEmp in sEmpList)
            {
                if (sEmp.Email != null)
                    ccList.Add(sEmp.Email);
                noti = new Model.Notification();
                noti.UserID = sEmp.StoreEmployeeID;
                noti.NotificationDate = DateTime.Today;
                noti.Message = "Date for Stationery Collection has been changed To " + clp.FirstCollectionDate + " and " + clp.SecondCollectionDate + ".";
                noti.FromUser = sEmpID;
                ctx.Notifications.Add(noti);
                ctx.SaveChanges();
            }

            string body = "Dear All, <br><br>";
            body += "Please be informed that the delivery date for collection has been changed To "+clp.FirstCollectionDate + " and "+clp.SecondCollectionDate+".<br><br>";
            body += "This is a system generated email, please do not reply.";

            string subject = "Change of Delivery Date for Stationery Collection";
            SendEmail(toList, subject, body, ccList);
            return "success";
        }
        //public async Task SendEmail(string to, string subject, string body,List<string> cclist)
        //{
        //    string from = "logicuniversity.edu.sg@gmail.com";
        //    string password = "logicuniversity@123";
            
        //    using (MailMessage mm = new MailMessage(from,to))
        //    {
        //        mm.Subject = subject;
        //        mm.Body = body;
        //        MailAddressCollection temp = mm.CC;
        //        foreach (string s in cclist)
        //            temp.Add(s);
        //        mm.IsBodyHtml = true;
        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.EnableSsl = true;
        //        NetworkCredential NetworkCred = new NetworkCredential(from, password);
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = NetworkCred;
        //        smtp.Port = 587;
        //        await smtp.SendMailAsync(mm);
        //        System.Diagnostics.Debug.WriteLine("Mail is sent");
        //    }
        //}
        public string sendEmailForRaisePO(Model.PurchaseOrder po)
        {
            Model.Supplier sup = (Model.Supplier)ctx.Suppliers.Where(x => x.SupplierID == po.SupplierID).FirstOrDefault();
            List<string> toEmail = new List<string>();
            toEmail.Add(sup.Email);
            string subject = "Issuance of PO# "+po.PurchaseOrderID+" to "+sup.SupplierName;
            List<string> ccList = new List<string>();
            List<Model.StoreEmployee> sEmpList = ctx.StoreEmployees.Where(x => x.StoreEmployeeID != po.StoreEmployeeID).ToList();
            if (sEmpList != null)
            {
                foreach(Model.StoreEmployee sEmp in sEmpList)
                {
                    ccList.Add(sEmp.Email);
                }
            }
            string body = "Dear Sir/ Madam, <br>";
            body += "Please be informed that Logic University Stationery Store has issued the following Purchase Order (PO# "+po.PurchaseOrderID+") for the below items with required delivery date on "+po.OrderDate+ ".<br><br><br>";
            body += "<table><tr><td>Item Description</td><td>Qty</td><td> UOM </td><td>Unit Price</td><td>Total Price </td ></tr> ";
            decimal totalPrice = 0;
            Model.SupplierItem item;
            foreach(Model.PurchaseOrderItem pitem in po.PurchaseOrderItems)
            {

                item = ctx.SupplierItems.Where(x => x.ItemID == pitem.ItemID && x.SupplierID == po.SupplierID).FirstOrDefault();
                totalPrice = item.Price.GetValueOrDefault();
                body += "<tr><td>"+item.Item.Description+"</td><td>"+pitem.Quantity+"</td><td>"+item.Item.UOM+"</td><td>"+totalPrice+"</td><td>"+totalPrice*pitem.Quantity+"</td></tr>";
            }
            body += "</table><br><br>";
            body += "For additional information, please contact "+sup.SupplierName+" @ "+sup.Email+"<br>";
            body += "This is a system generated email, please do not reply.";
            SendEmail(toEmail, subject, body, ccList);
            return "success";
        }
        //Real Email Code Begin
        public void SendEmail(List<string> toList, string subject, string body, List<string> cclist)
        {
            string to="",cc ="";
            foreach (string temp_to in toList)
                to += temp_to + ";";
            foreach (string temp_cc in cclist)
                cc += temp_cc + ";";
            int exp = SendEmail("logicuniversity.edu.sg@gmail.com", "logicuniversity@123", 465, body, to, subject, cc);
            //if(exp==0)
            //    exp = SendEmail("logicuniversity.edu.sg@gmail.com", "logicuniversity@123", 25, body, to, subject, cc);
            //if(exp==0)
            //    exp = SendEmail("logicuniversity.edu.sg@gmail.com", "logicuniversity@123", 465, body, to, subject, cc);
            if (exp == 0)
                System.Diagnostics.Debug.WriteLine("Fail to send Email");
            else
                System.Diagnostics.Debug.WriteLine("Successfully to send Email");
        }
        public int SendEmail(string from, string password, int port, string body, string to, string subject, string cc)
        {
            //string ToEmail;
            bool fSSL = true;
            try
            {
                //Creating Message object

                System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", port);
                if (fSSL)
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", from);
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);

                //Preparing the message object....

                message.From = from;
                message.To = to;
                message.Cc = cc;
                message.Subject = subject;
                message.BodyFormat = System.Web.Mail.MailFormat.Html;
                message.Body = body;
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";

                Thread email = new Thread(delegate ()
                {
                    System.Web.Mail.SmtpMail.Send(message);
                });

                email.IsBackground = true;
                email.Start();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}