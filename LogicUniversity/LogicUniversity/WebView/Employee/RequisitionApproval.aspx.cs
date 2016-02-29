using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class Requisition_Approval : System.Web.UI.Page
    {
        Control.RequisitionApprovalControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new Control.RequisitionApprovalControl();
            if (!IsPostBack)
                lblDearptmentName.Text = ((Model.Employee)Session["User"]).Department.DepartmentName;
            gvDataList.DataSource = crt.getAllRequisitionToApprove(((Model.Employee)Session["User"]).DepartmentID);
            gvDataList.DataBind();

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
    }
}