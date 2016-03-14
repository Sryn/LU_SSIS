using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        Control.LoginControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new Control.LoginControl();
            if (Request.QueryString["code"] == null)
                Response.Redirect("loginPage");
            string result = crt.forgotPINCheck(Convert.ToInt32(Request.QueryString["code"]));
            if(result.Equals("noFound"))
                Response.Redirect("loginPage");

        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            string result = "";
            if (!txtConfirmPIN.Text.Equals(txtPIN.Text))
                lblMessage.Text = "Confirm PIN and PIN must same!";
            else
            {
                result = crt.changeForgotPINCheck(Convert.ToInt32(txtPIN.Text), Convert.ToInt32(Request.QueryString["code"]));
            }
            switch (result)
            {
                case "success":
                    Response.Redirect("~/WebView/LoginPage.aspx");
                    break;
                case "fail":
                    lblMessage.Text = "Fail";
                    break;
                case "invalid":
                    lblMessage.Text = "invalid";
                    break;
                case "Disable":
                    lblMessage.Text = "Disable";
                    break;
                case "notFound":
                    lblMessage.Text = "notFound";
                    break;
            }
        }
    }
}