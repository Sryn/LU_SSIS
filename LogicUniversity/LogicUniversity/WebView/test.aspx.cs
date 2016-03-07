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

        protected void Button2_Click(object sender, EventArgs e)
        {
           
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Control.EmailControl emailCrt = new Control.EmailControl();
           // emailCrt.sendEmailForRaisePO("");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Control.DisbursementController crt = new Control.DisbursementController();
            List<Model.DisbursementItemViewModel> dlist = crt.requestDisbursementList();
            Label2.Text = "";
            foreach(Model.DisbursementItemViewModel d in dlist)
            {
                Label2.Text += d.BinCode;
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            Control.DisbursementController crt = new Control.DisbursementController();
            crt.updateCollectedQtyByItemID("C001",10);
        }
    }
}