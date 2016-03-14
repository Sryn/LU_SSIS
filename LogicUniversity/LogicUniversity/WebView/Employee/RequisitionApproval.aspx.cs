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
        List<Model.RequisitionApproval> ApproveList;
        protected void Page_Load(object sender, EventArgs e)
        {
            ApproveList = new List<Model.RequisitionApproval>();
            crt = new Control.RequisitionApprovalControl();
            if (!IsPostBack)
            {
                lblDearptmentName.Text = ((Model.Employee)Session["User"]).Department.DepartmentName;
                gvDataList.DataSource = crt.getAllRequisitionToApprove(((Model.Employee)Session["User"]).DepartmentID);
                gvDataList.DataBind();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
           
            for (int i = 0; i < gvDataList.Rows.Count; i++)
            {

                    string requisitionItemID = gvDataList.Rows[i].Cells[1].Text; //get the requisition item id from gridview
                    string reason = ((TextBox)gvDataList.Rows[i].Cells[8].FindControl("txtReason")).Text;

                    RadioButton rdn_Approve = (RadioButton)gvDataList.Rows[i].Cells[6].FindControl("Rdn_Approve");// to check the Radio Button from gridview
                    RadioButton rdn_Reject = (RadioButton)gvDataList.Rows[i].Cells[6].FindControl("Rdn_Reject");// to check the Radio from gridview

                    if (rdn_Approve.Checked == true)
                        ApproveList.Add(new Model.RequisitionApproval(Convert.ToInt32(requisitionItemID),"Approve",reason)); // add the object 3 args constructure to list

                    else if (rdn_Reject.Checked==true)
                        ApproveList.Add(new Model.RequisitionApproval(Convert.ToInt32(requisitionItemID), "Reject", reason)); // add the object 3 args constructure to list
            }
            string result = crt.ApproveRequisition(ApproveList);
            gvDataList.DataSource = crt.getAllRequisitionToApprove(((Model.Employee)Session["User"]).DepartmentID);
            gvDataList.DataBind();
        }

        protected void gvDataList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[1].Style.Add("display", "none");
         //   gvAdjVoucher.HeaderRow.Cells[2].Visible = false;

            e.Row.Cells[0].Style.Add("display", "none");
          //  gvAdjVoucher.HeaderRow.Cells[10].Visible = false;
        }
    }
}