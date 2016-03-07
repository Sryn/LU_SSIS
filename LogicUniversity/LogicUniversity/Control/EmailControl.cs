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
                string body = "Dear "+ name + ",\r\n";
                body += "You have requested for a reset of your PIN to Logic University Stationery Store System.\r\n";
                body += "http://localhost:8236/WebView/ForgotPassword.aspx?code="+ fpwd.Code+ "\r\n\r\n";
                body += "If you didn’t request a new PIN, please contact us immediately @ 8424-4865.\r\n\r\nThis is a system generated email, please donot reply.";
                string subject = "Reset PIN ";
                SendEmail(email, subject, body, new List<string>());
            }
            catch(Exception)
            {
                return "error";
            }
            return "success";
        }
        public void SendEmail(string to, string subject, string body,List<string> cclist)
        {
            string from = "logicuniversity.edu.sg@gmail.com";
            string password = "logicuniversity@123";
            
            using (MailMessage mm = new MailMessage(from,to))
            {
                mm.Subject = subject;
                mm.Body = body;
                MailAddressCollection temp = mm.CC;
                foreach (string s in cclist)
                    temp.Add(s);
               // mm.CC = temp;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential(from, password);
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                //smtp.Port = 587;
                smtp.Port = 25;
                smtp.Send(mm);
                System.Diagnostics.Debug.WriteLine("Mail is sent");
            }
        }

        public string sendEmailForRaisePO(Model.PurchaseOrder po)
        {
            Model.Supplier sup = (Model.Supplier)ctx.Suppliers.Where(x => x.SupplierID == po.SupplierID).FirstOrDefault();
            string toEmail = sup.Email;
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
    }
}