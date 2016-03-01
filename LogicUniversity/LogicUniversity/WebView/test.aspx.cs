using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            emailCrt.SendEmail("hhz.neo@gmail.com", "Hi I am Testing", "Testing 123", cclist);
        }
    }
}