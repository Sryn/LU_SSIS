using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;
using LogicUniversity.Model;
using System.Data;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class ApproveAdjustmentVoucher : System.Web.UI.Page
    {
        AdjustmentVoucherControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                BindToGridView();
                AddRowSpanToGridView();

                if (Request["ItemCodeToDelete"] != null)
                {
                    String id = Request["ItemCodeToDelete"].ToString();
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

        protected void gvAdjVoucher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAdjVoucher.PageIndex = e.NewPageIndex;
            this.gvAdjVoucher.DataSource = (DataTable)Session["DataSource"];
            this.gvAdjVoucher.DataBind();
            AddRowSpanToGridView();
        }
         
        public void BindToGridView()
        {
            crt = new AdjustmentVoucherControl();
            List<RaiseAdjustmentVoucherItem> l = new List<RaiseAdjustmentVoucherItem>();
            l = crt.getToApproveAdjItemList(((Model.StoreEmployee)Session["User"]).StoreEmployeeID);

            this.gvAdjVoucher.DataKeyNames = new string[] { "id" };
            DataTable dt = new DataTable();  // this is goin to be our data table for this story

            dt.Columns.Add(new DataColumn("ItemCode", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Category", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Description", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("Quantity", System.Type.GetType("System.Int32")));
            dt.Columns.Add(new DataColumn("UnitOfMeasure", System.Type.GetType("System.String")));
            dt.Columns.Add(new DataColumn("UnitPrice", System.Type.GetType("System.Double")));
            dt.Columns.Add(new DataColumn("TotalPrice", System.Type.GetType("System.Double")));
            dt.Columns.Add(new DataColumn("Reason", System.Type.GetType("System.String")));
            

            dt.Columns.Add(new DataColumn("ID", System.Type.GetType("System.String")));
            // set primary key to the table. we need this later to search the matching row
            dt.PrimaryKey = new DataColumn[] { dt.Columns["ID"] };

            int i = 0;

            
            foreach (Model.RaiseAdjustmentVoucherItem  r in l)
            {
                dt.Rows.Add(new object[] {r.ItemCode,r.Category,r.Description,r.Quantity,r.UnitOfMeasure,
                r.UnitPrice,r.TotalPrice,r.Reason,i.ToString()});
                i++;
            }

            this.gvAdjVoucher.DataSource = dt;  // set the datasource of the grid

            gvAdjVoucher.DataBind();

            AddRowSpanToGridView();

            Session["DataSource"] = dt;
        }
        protected void gvAdjVoucher_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {              
                e.Row.Cells[2].Style.Add("display", "none");
                gvAdjVoucher.HeaderRow.Cells[2].Visible = false;

                e.Row.Cells[10].Style.Add("display", "none");
                gvAdjVoucher.HeaderRow.Cells[10].Visible = false;    

            }
        }

        public void AddRowSpanToGridView()
        {
            for (int rowIndex = gvAdjVoucher.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow currentRow = gvAdjVoucher.Rows[rowIndex];
                GridViewRow previousRow = gvAdjVoucher.Rows[rowIndex + 1];


                if (currentRow.Cells[3].Text == previousRow.Cells[3].Text || currentRow.Cells[6].Text == previousRow.Cells[6].Text)
                {
                    if (previousRow.Cells[3].RowSpan < 2)
                    {
                        currentRow.Cells[3].RowSpan = 2;
                        currentRow.Cells[6].RowSpan = 2;

                    }
                    else
                    {
                        currentRow.Cells[0].RowSpan = previousRow.Cells[0].RowSpan + 1;
                        currentRow.Cells[1].RowSpan = previousRow.Cells[1].RowSpan + 1;
                        currentRow.Cells[2].RowSpan = previousRow.Cells[2].RowSpan + 1;
                        currentRow.Cells[3].RowSpan = previousRow.Cells[3].RowSpan + 1;
                        currentRow.Cells[4].RowSpan = previousRow.Cells[4].RowSpan + 1;

                        currentRow.Cells[5].RowSpan = previousRow.Cells[5].RowSpan + 1;
                        currentRow.Cells[6].RowSpan = previousRow.Cells[6].RowSpan + 1;
                        currentRow.Cells[7].RowSpan = previousRow.Cells[7].RowSpan + 1;
                        currentRow.Cells[8].RowSpan = previousRow.Cells[8].RowSpan + 1;
                        currentRow.Cells[9].RowSpan = previousRow.Cells[9].RowSpan + 1;

                    }
                    
                    previousRow.Cells[3].Visible = false;
                    previousRow.Cells[6].Visible = false;

                }
               /* if (currentRow.Cells[6].Text == previousRow.Cells[6].Text)
                {
                    if (previousRow.Cells[6].RowSpan < 2)
                    {
                        currentRow.Cells[6].RowSpan = 2;


                    }
                    else
                    {
                        currentRow.Cells[0].RowSpan = previousRow.Cells[0].RowSpan + 1;
                        currentRow.Cells[1].RowSpan = previousRow.Cells[1].RowSpan + 1;
                        currentRow.Cells[2].RowSpan = previousRow.Cells[2].RowSpan + 1;
                        currentRow.Cells[3].RowSpan = previousRow.Cells[3].RowSpan + 1;
                        currentRow.Cells[4].RowSpan = previousRow.Cells[4].RowSpan + 1;

                        currentRow.Cells[5].RowSpan = previousRow.Cells[5].RowSpan + 1;
                        currentRow.Cells[6].RowSpan = previousRow.Cells[6].RowSpan + 1;
                        currentRow.Cells[7].RowSpan = previousRow.Cells[7].RowSpan + 1;
                        currentRow.Cells[8].RowSpan = previousRow.Cells[8].RowSpan + 1;
                        currentRow.Cells[9].RowSpan = previousRow.Cells[9].RowSpan + 1;

                    }

                    previousRow.Cells[5].Visible = false;

                }*/
            }


        }
    }
}