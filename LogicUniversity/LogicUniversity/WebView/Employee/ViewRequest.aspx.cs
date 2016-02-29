using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class ViewRequest : System.Web.UI.Page
    {
        Control.RequestListControl reqlistcrt;
        protected void Page_Load(object sender, EventArgs e)
        {
            reqlistcrt = new Control.RequestListControl();
            gvList.DataSource = reqlistcrt.getRequisitionListItem("", "All", ((Model.Employee)Session["User"]).EmployeeID);
            gvList.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvList.DataSource = reqlistcrt.getRequisitionListItem(txtItemDescription.Text, ddlStatus.SelectedValue, ((Model.Employee)Session["User"]).EmployeeID);
            gvList.DataBind();
        }

        protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("==");
        }
    }
}