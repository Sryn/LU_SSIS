using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Model;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class ChangeDeliveryDate : System.Web.UI.Page
    {
        Control.ChangeDeliveryController crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new Control.ChangeDeliveryController();
            CollectionPoint cp = crt.getCollectionPoint();
            txtFirstCollectionDate.Text = cp.FirstCollectionDate;
            txtSecondCollectionDate.Text = cp.SecondCollectionDate;
            if (!IsPostBack) { 
                rdblFirstCollectionDate.SelectedValue = cp.FirstCollectionDate;
                rdblSecondCollectionDate.SelectedValue = cp.SecondCollectionDate;
            }
        }
        protected void btnChangeDeliveryDate_Click(object sender, EventArgs e)
        {
            crt.saveCollectionDate(rdblFirstCollectionDate.SelectedValue, rdblSecondCollectionDate.SelectedValue,((Model.StoreEmployee)Session["User"]).StoreEmployeeID);
            CollectionPoint cp = crt.getCollectionPoint();
            txtFirstCollectionDate.Text = cp.FirstCollectionDate;
            txtSecondCollectionDate.Text = cp.SecondCollectionDate;
        }
    }
}