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
            lblMessage.Text = Request.QueryString["code"];
        }

        protected void btnChange_Click(object sender, EventArgs e)
        {
            //string enddate = DateTime.Today.AddMonths(1).AddDays(-1).ToString();
            //string startdate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString();
            //System.Diagnostics.Debug.WriteLine("enddate - " + enddate);
            //System.Diagnostics.Debug.WriteLine("startdate - " + startdate);
        }
    }
}