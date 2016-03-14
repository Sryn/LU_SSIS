using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Model;
using LogicUniversity.Control;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class NotCollected : System.Web.UI.Page
    {
        DisbursementController crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new DisbursementController();
            if (!IsPostBack)
            {
                if (Request["DisbursementID"] != null)
                {
                    int id = Convert.ToInt32(Request["DisbursementID"].ToString());
                    string result = crt.changeToNotCollected(id);                    
                }
                Retrieve();
            }
        }
        public void Retrieve()
        {
            gvDataList.DataSource = crt.getToNotCollectedList();
            gvDataList.DataBind();
            AddRowSpanToGridView();
        }
        public void AddRowSpanToGridView()
        {
            for (int rowIndex = gvDataList.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow currentRow = gvDataList.Rows[rowIndex];
                GridViewRow previousRow = gvDataList.Rows[rowIndex + 1];


                if (currentRow.Cells[6].Text == previousRow.Cells[6].Text)
                {
                    if (previousRow.Cells[6].RowSpan < 2)
                    {
                        currentRow.Cells[6].RowSpan = 2;
                        currentRow.Cells[3].RowSpan = 2;
                        currentRow.Cells[2].RowSpan = 2;
                        currentRow.Cells[1].RowSpan = 2;
                        currentRow.Cells[0].RowSpan = 2;
                    }
                    else
                    {
                        currentRow.Cells[6].RowSpan = previousRow.Cells[6].RowSpan + 1;
                        currentRow.Cells[3].RowSpan = previousRow.Cells[3].RowSpan + 1;
                        currentRow.Cells[2].RowSpan = previousRow.Cells[2].RowSpan + 1;
                        currentRow.Cells[1].RowSpan = previousRow.Cells[1].RowSpan + 1;
                        currentRow.Cells[0].RowSpan = previousRow.Cells[0].RowSpan + 1;
                    }

                    previousRow.Cells[6].Style.Add("display", "none");
                    previousRow.Cells[3].Style.Add("display", "none");
                    previousRow.Cells[2].Style.Add("display", "none");
                    previousRow.Cells[1].Style.Add("display", "none");
                    previousRow.Cells[0].Style.Add("display", "none");
                }
            }


        }

        protected void gvDataList_RowCreated(object sender, GridViewRowEventArgs e)
        {
           // e.Row.Cells[6].Style.Add("display", "none");
         //   e.Row.Cells[3].Style.Add("display", "none");
        //    e.Row.Cells[11].Style.Add("display", "none");
        }

        protected void gvDataList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDataList.PageIndex = e.NewPageIndex;
            Retrieve();
        }
    }
}