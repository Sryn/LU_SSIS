using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;
using LogicUniversity.Model;

namespace LogicUniversity.WebView.Finance
{
    public partial class MangeCategory : System.Web.UI.Page
    {
        FinanceController crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["IDToDelete"] != null)
                {
                    String id = Request["IDToDelete"].ToString();
                 
                }

                if (Request["IDToEdit"] != null)
                {
                    String id = Request["IDToEdit"].ToString();
                    
                }
                crt = new FinanceController();
                Retrieve();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text.Trim().Equals(string.Empty))
            {
                lblMessage.Text = "Enter Category";
                return;
            }
            Category cat = new Category();
            cat.CategoryName = txtCategory.Text.Trim();
            crt.insertCategory(cat);
            Retrieve();
            txtCategory.Text = "";
        }
        public void Retrieve()
        {
            crt = new FinanceController();
            gvData.DataSource = crt.getAllCategoryList();
            gvData.DataBind();
        }
        protected void gvData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvData.PageIndex = e.NewPageIndex;
            Retrieve();
        }

        protected void gvData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[2].Style.Add("display", "none");

                gvData.HeaderRow.Cells[2].Visible = false;


            }
        }
    }
}