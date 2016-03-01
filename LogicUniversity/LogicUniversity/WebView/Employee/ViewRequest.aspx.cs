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
        List<Model.RequestListItem> resultList = new List<Model.RequestListItem>();
        protected void Page_Load(object sender, EventArgs e)
        {
            reqlistcrt = new Control.RequestListControl();
            if (!IsPostBack)
            {
                if (Request["RequisitionFormIDToDelete"] != null)
                {
                    int id = Convert.ToInt32(Request["RequisitionFormIDToDelete"].ToString());
                    delete(id);         
                }

                if (Request["RequisitionFormIDToReOder"] != null)
                {
                    int id = Convert.ToInt32(Request["RequisitionFormIDToReOder"].ToString());
                    ReOrder(id);
                }

                reqlistcrt = new Control.RequestListControl();

                
                gvList.DataSource = reqlistcrt.getRequisitionListItem("", "All", ((Model.Employee)Session["User"]).EmployeeID);
                gvList.DataBind();

                // To check the status to show edit and delete button
                check();
                AddRowSpanToGridView();

               
             
            }
        }
        public void delete(int Requisitionid)
        {
            System.Diagnostics.Debug.WriteLine("Delete Click" + Requisitionid);
            reqlistcrt.DeleteRequisition(Requisitionid);
        }

        public void ReOrder(int Requisitionid)
        {
            System.Diagnostics.Debug.WriteLine("ReOrder Click" + Requisitionid);
            
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            gvList.DataSource = reqlistcrt.getRequisitionListItem(txtItemDescription.Text, ddlStatus.SelectedValue, ((Model.Employee)Session["User"]).EmployeeID);
            gvList.DataBind();

            // To check the status to show edit and delete button
            check();
            AddRowSpanToGridView();
        }
        public void AddRowSpanToGridView()
        {
            for (int rowIndex = gvList.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow currentRow = gvList.Rows[rowIndex];
                GridViewRow previousRow = gvList.Rows[rowIndex + 1];
                
                  
                        if (currentRow.Cells[4].Text == previousRow.Cells[4].Text)
                        {
                            if (previousRow.Cells[4].RowSpan < 2)
                            {
                                currentRow.Cells[4].RowSpan = 2;
                                currentRow.Cells[3].RowSpan = 2;
                                currentRow.Cells[2].RowSpan = 2;
                                currentRow.Cells[1].RowSpan = 2;
                                currentRow.Cells[0].RowSpan = 2;
                            }
                            else
                            {
                                currentRow.Cells[4].RowSpan = previousRow.Cells[4].RowSpan + 1;
                                currentRow.Cells[3].RowSpan = previousRow.Cells[3].RowSpan + 1;
                                currentRow.Cells[2].RowSpan = previousRow.Cells[2].RowSpan + 1;
                                currentRow.Cells[1].RowSpan = previousRow.Cells[1].RowSpan + 1;
                                currentRow.Cells[0].RowSpan = previousRow.Cells[0].RowSpan + 1;
                            }

                            previousRow.Cells[4].Visible = false;
                            previousRow.Cells[3].Visible = false;
                            previousRow.Cells[2].Visible = false;
                            previousRow.Cells[1].Visible = false;
                            previousRow.Cells[0].Visible = false;
                        }
                    }
                
            
        }
       
        public void check()
        {
            String temp = null;
            // To check the status to show edit and delete button
            for (int i = 0; i < gvList.Rows.Count; i++)
            {
                String status = gvList.Rows[i].Cells[8].Text; //get the status from gridview
                String req_id = gvList.Rows[i].Cells[4].Text; //get the req_id from gridview

                if (req_id != temp)
                {
                    if (status != "PendingApproval")
                    {
                        HyperLink lnk_edit = (HyperLink)gvList.Rows[i].Cells[1].FindControl("lnk_edit");//get link id in gridview
                        lnk_edit.Visible = false;

                        HyperLink lnk_delete = (HyperLink)gvList.Rows[i].Cells[1].FindControl("lnk_delete");//get link id from textbox in gridview
                        lnk_delete.Visible = false;

                        HyperLink lnk_re = (HyperLink)gvList.Rows[i].Cells[1].FindControl("lnk_Reorder");//get link id from textbox in gridview
                        lnk_re.Visible = true;
                    }
                }
                else
                {

                    HyperLink lnk_edit = (HyperLink)gvList.Rows[i].Cells[1].FindControl("lnk_edit");//get link id in gridview
                    lnk_edit.Visible = false;

                    HyperLink lnk_delete = (HyperLink)gvList.Rows[i].Cells[1].FindControl("lnk_delete");//get link id from textbox in gridview
                    lnk_delete.Visible = false;

                    HyperLink lnk_re = (HyperLink)gvList.Rows[i].Cells[1].FindControl("lnk_Reorder");//get link id from textbox in gridview
                    lnk_re.Visible = false;
                }
                temp = req_id;
            }
        }
        protected void gvList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            
        }

     
    }
}