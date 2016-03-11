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
            crt = new FinanceController();
            gvData.DataSource = crt.getAllCategoryList();
            gvData.DataBind();
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
            gvData.DataSource = crt.getAllCategoryList();
            gvData.DataBind();
            txtCategory.Text = "";
        }
    }
}