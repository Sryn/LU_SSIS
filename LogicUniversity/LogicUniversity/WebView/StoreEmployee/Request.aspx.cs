using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class Request : System.Web.UI.Page
    {
        Control.DisbursementController crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new Control.DisbursementController();
            if (!IsPostBack)
            {
                gvDataList.DataSource = crt.requestDisbursementList();
                gvDataList.DataBind();
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {

        }
    }
}