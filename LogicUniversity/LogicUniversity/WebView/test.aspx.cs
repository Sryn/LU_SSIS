using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.ComponentModel;
using System.Web.Mail;

namespace LogicUniversity.WebView
{
    public partial class test : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Control.EmailControl emailCrt = new Control.EmailControl();
            List<string> cclist = new List<string>();
            cclist.Add("tanadele_sg@hotmail.com");
            cclist.Add("asa.aung1989@gmail.com");
           // emailCrt.SendEmail("hhz.neo@gmail.com", "Hi I am Testing", "Testing 123", cclist);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }
        
        protected void Button4_Click(object sender, EventArgs e)
        {

        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            //string to = "hhz.neo@gmail.com";
            //string subject = "This is Subject";
            //string body = "This is body";
            //List<string> cclist = new List<string>();
            //string from = "logicuniversity.edu.sg@gmail.com";
            //string password = "logicuniversity@123";

            //using (MailMessage mm = new MailMessage(from, to))
            //{
            //    mm.Subject = subject;
            //    mm.Body = body;
            //    MailAddressCollection temp = mm.CC;
            //    foreach (string s in cclist)
            //        temp.Add(s);
            //    // mm.CC = temp;
            //    mm.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient();
            //    Object state = mm;
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.EnableSsl = true;
            //    NetworkCredential NetworkCred = new NetworkCredential(from, password);
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = 587;

            //    smtp.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
            //    try
            //    {
            //        smtp.SendAsync(mm, state);
            //    }
            //    catch (Exception ex) {
            //        System.Diagnostics.Debug.WriteLine(ex.Message.ToString());
            //    }
            //    System.Diagnostics.Debug.WriteLine("Mail is sent");
            //}
        }
        void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            //    MailMessage mail = e.UserState as MailMessage;

            //    if (!e.Cancelled && e.Error != null)
            //    {
            //        System.Diagnostics.Debug.WriteLine("Mail is sent");
            //    }
            //}
            //protected void Button4_Click(object sender, EventArgs e)
            //{
            //    Control.DisbursementController crt = new Control.DisbursementController();
            //    List<Model.DisbursementItemViewModel> dlist = crt.requestDisbursementList();
            //    Label2.Text = "";
            //    foreach(Model.DisbursementItemViewModel d in dlist)
            //    {
            //        Label2.Text += d.BinCode;
            //    }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Control.EmailControl crt = new Control.EmailControl();
            //crt.SendEmail("hhz.neo@gmail.com", "Subject", "Body", new List<string>());
        }
        [WebMethod]                                 //Default.aspx.cs
        public static void DeleteItem()
        {
            System.Diagnostics.Debug.WriteLine("I m working");
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            //Control.DisbursementController crt = new Control.DisbursementController();
            // crt.testDate();
            int a = SendEmail();
            System.Diagnostics.Debug.WriteLine(a);
        }


        public int SendEmail()
        {
            string sToEmail;
            bool fSSL = true;
            try
            {
                //Creating Message object

                System.Web.Mail.MailMessage message = new System.Web.Mail.MailMessage();
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserver", "smtp.gmail.com");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusing", "2");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", "465");
                if (fSSL)
                    message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", "true");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", "logicuniversity.edu.sg@gmail.com");
                message.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", "logicuniversity@123");

                //Preparing the message object....

                message.From = "logicuniversity.edu.sg@gmail.com";
                message.To = "hhz.neo@gmail.com";
                message.Subject = "testing";
                message.BodyFormat = System.Web.Mail.MailFormat.Html;
                string html = @"<html><head><link href='CSS/WebCss/WebCss.css' rel='stylesheet' type='text/css' />
         </head><body >";
                html += "<h1>Welcome to Avinash Aher World</h1><br>";
                html += "</body></html>";
                message.Body = html;
                System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com";
                System.Web.Mail.SmtpMail.Send(message);




                return 1;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}