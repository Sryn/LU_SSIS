using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class InventoryList : System.Web.UI.Page
    {
        Control.InventoryListController crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new Control.InventoryListController();
            if (!IsPostBack)
            {
                List < Model.InventroyListModel > dlist= crt.getInventoryList();
                BindToGridView(dlist);
                //gvDataList.DataSource = crt.getInventoryList();
                //      gvDataList.DataBind();
                check();
            }
        }
        protected void gvDataList_RowCreated(object sender, GridViewRowEventArgs e)
        {

           if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].Style.Add("display", "none");
                e.Row.Cells[2].Style.Add("display", "none");
                e.Row.Cells[11].Style.Add("display", "none");
              
                gvDataList.HeaderRow.Cells[1].Visible = false;
                gvDataList.HeaderRow.Cells[2].Visible = false;
                gvDataList.HeaderRow.Cells[11].Visible = false;
             
            
            }


        }
        protected void gvDataList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                String reorderPoint = e.Row.Cells[9].Text;

                e.Row.CssClass = reorderPoint == "Insufficient" ? "danger1"  : "success1";


            }
        }

        public void BindToGridView(List<Model.InventroyListModel> dlist)
        {
            this.gvDataList.DataKeyNames = new string[] { "id" };
            DataTable dt = new DataTable();  // this is goin to be our data table for this story

            dt.Columns.Add(new DataColumn("BinID", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("ItemID", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Category", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("ItemDescription", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Quantity", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("UnitOfMeasure", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("ReorderLevel", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("ReorderQty", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("Remark", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("AccumulatedRequest", System.Type.GetType("System.Int32")));

            dt.Columns.Add(new DataColumn("ID", System.Type.GetType("System.String")));
            // set primary key to the table. we need this later to search the matching row
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };

            int i = 0;
            foreach (Model.InventroyListModel l in dlist)
            {
                dt.Rows.Add(new object[] {l.BinID,l.ItemID,l.Category,l.ItemDescription,
                    l.Quantity,l.UnitOfMeasure, l.ReorderLevel,
                l.ReorderQty,l.Remark,l.AccumulatedRequest,i.ToString()});
                i++;
            }

            this.gvDataList.DataSource = dt;  // set the datasource of the grid

            gvDataList.DataBind();

         

            Session["DataSource"] = dt;
        }


        protected void gvDataList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            gvDataList.PageIndex = e.NewPageIndex;
            this.gvDataList.DataSource = (DataTable)Session["DataSource"];
            this.gvDataList.DataBind();
            check();
        }

    



public void check()
        {
         
      
            for (int i = 0; i < gvDataList.Rows.Count; i++)
            {
                String status = gvDataList.Rows[i].Cells[9].Text; //get the status from gridview
           

                    if (status == "Insufficient")
                    {
                       
                        HyperLink lnk_re = (HyperLink)gvDataList.Rows[i].Cells[1].FindControl("lnk_RaisePO");//get link id from textbox in gridview
                        lnk_re.Visible = true;
                    }
            
                else
                {

                  

                    HyperLink lnk_re = (HyperLink)gvDataList.Rows[i].Cells[1].FindControl("lnk_RaisePO");//get link id from textbox in gridview
                    lnk_re.Visible = false;
                }
             
            }
        }
    }
}