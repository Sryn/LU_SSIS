using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;
using LogicUniversity.Model;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class ApproveAdjustmentVoucher : System.Web.UI.Page
    {
        AdjustmentVoucherControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                crt = new AdjustmentVoucherControl();
                gvAdjVoucher.DataSource = crt.getToApproveAdjItemList(((Model.StoreEmployee)Session["User"]).StoreEmployeeID);
                gvAdjVoucher.DataBind();

                if (Request["ItemCodeToDelete="] != null)
                {
                    String id = Request["ItemCodeToDelete="].ToString();
                    _delete(id);
                }

                if (Request["ItemCodeToEdit"] != null)
                {
                    String id = Request["ItemCodeToEdit"].ToString();
                    _Edit(id);
                }
            }
        }

        public void _delete(String itemid)
        {
            System.Diagnostics.Debug.WriteLine("Delete Click" + itemid);

        }

        public void _Edit(String itemid)
        {
            System.Diagnostics.Debug.WriteLine("ReOrder Click" + itemid);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvAdjVoucher.Rows.Count; i++)
            {

              

                RadioButton rdn_Approve = (RadioButton)gvAdjVoucher.Rows[i].Cells[1].FindControl("Rdn_Approve");// to check the Radio Button from gridview
                RadioButton rdn_Reject = (RadioButton)gvAdjVoucher.Rows[i].Cells[1].FindControl("Rdn_Reject");// to check the Radio from gridview

                if (rdn_Approve.Checked == true)
                {
                    Button1.Text = "A";
                }
                // add the object 3 args constructure to list

                else if (rdn_Reject.Checked == true)
                { Button1.Text = "R";  }
               // add the object 3 args constructure to list
            }
        }
    }
}