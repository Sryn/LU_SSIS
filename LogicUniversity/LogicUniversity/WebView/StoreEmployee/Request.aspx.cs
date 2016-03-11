using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class Request : System.Web.UI.Page
    {
        int count = 0;
        Control.DisbursementController crt;
        List<Model.DisbursementItemViewModel> DisbursementList;  
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new Control.DisbursementController();
            if (!IsPostBack)
            {
                DisbursementList = new List<Model.DisbursementItemViewModel>();
                DisbursementList = crt.requestDisbursementList();
                BindToGridView(DisbursementList);
            }
        }
        public void BindToGridView(List<Model.DisbursementItemViewModel> dlist)
        {

            this.gvDataList.DataSource = dlist;  // set the datasource of the grid

            gvDataList.DataBind();
            AddRowSpanToGridView();

           
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            int temp = 0;

            DisbursementList = new List<Model.DisbursementItemViewModel>();
            for (int i = 0; i < gvDataList.Rows.Count; i++)
            {

                TextBox txtQQty = (TextBox)gvDataList.Rows[i].FindControl("txtQty"); // point the current row and find control
                TextBox txttotalQTY = (TextBox)gvDataList.Rows[i].FindControl("txttotalQty"); // point the current row and find control
                String actualQty = txtQQty.Text;
                String totalReceived = txttotalQTY.Text;

                String disbursementItemID = gvDataList.Rows[i].Cells[2].Text;
                String itemID = gvDataList.Rows[i].Cells[4].Text;
                String binCode = gvDataList.Rows[i].Cells[5].Text;
                String itemDescription = gvDataList.Rows[i].Cells[6].Text;
                String totalNeededQuantity = gvDataList.Rows[i].Cells[7].Text;
                String department = gvDataList.Rows[i].Cells[8].Text;
                String needqty = gvDataList.Rows[i].Cells[9].Text;
                String unitOfMeasure = gvDataList.Rows[i].Cells[10].Text;

                if (txttotalQTY.Visible == true)
                {
                    temp = Convert.ToInt32(totalReceived);
                }
                else
                {
                    totalReceived = temp.ToString();
                }

                DisbursementList.Add(new Model.DisbursementItemViewModel(
                   binCode, itemDescription, Convert.ToInt32(totalNeededQuantity),
                   department, Convert.ToInt32(needqty), unitOfMeasure,
                   Convert.ToInt32(actualQty), itemID,
                   Convert.ToInt32(totalReceived), Convert.ToInt32(disbursementItemID),""));
                   lblMessage.Text += "A"+actualQty + "T" + totalReceived+"\t\t";

            }
            crt.confirmDisbursement(DisbursementList);
            gvDataList.DataSource = DisbursementList;
            gvDataList.DataBind();

            AddRowSpanToGridView();
            lblMessage.Text += DisbursementList.Count.ToString();
        }
        public void AddRowSpanToGridView()
        {
            for (int rowIndex = gvDataList.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow currentRow = gvDataList.Rows[rowIndex];
                GridViewRow previousRow = gvDataList.Rows[rowIndex + 1];


                if (currentRow.Cells[4].Text == previousRow.Cells[4].Text)
                {
                    if (previousRow.Cells[4].RowSpan < 2)
                    {
                        currentRow.Cells[4].RowSpan = 2;
                        currentRow.Cells[1].RowSpan = 2;
                        currentRow.Cells[5].RowSpan = 2;
                        currentRow.Cells[6].RowSpan = 2;
                        currentRow.Cells[7].RowSpan = 2;

                    }
                    else
                    {
                        currentRow.Cells[1].RowSpan = previousRow.Cells[1].RowSpan + 1;
                        currentRow.Cells[4].RowSpan = previousRow.Cells[4].RowSpan + 1;
                        currentRow.Cells[5].RowSpan = previousRow.Cells[5].RowSpan + 1;
                        currentRow.Cells[6].RowSpan = previousRow.Cells[6].RowSpan + 1;
                        currentRow.Cells[7].RowSpan = previousRow.Cells[7].RowSpan + 1;

                    }
                    previousRow.Cells[4].Visible = false;
                    previousRow.Cells[1].Visible = false;
                    previousRow.Cells[5].Visible = false;
                    previousRow.Cells[6].Visible = false;
                    previousRow.Cells[7].Visible = false;

                }
            }


        }


        protected void gvDataList_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //  if (e.Row.RowType == DataControlRowType.DataRow)
            //  {
            e.Row.Cells[2].Style.Add("display", "none");
            e.Row.Cells[3].Style.Add("display", "none");
            e.Row.Cells[11].Style.Add("display", "none");
            /*   e.Row.Cells[2].Visible = false;
               e.Row.Cells[3].Visible = false;
               e.Row.Cells[11].Visible = false;  */
            //   }

        }
        protected void txttotalQty_TextChanged(object sender, EventArgs e)
        {
           
            TextBox txttotal;
            TextBox txtquantity;
            TextBox temptotalQTY;
          
            String current_row_value = "0";
            int j = 0;
            int totalQuantity = 0;

            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            int rowIndex = row.RowIndex;   
       
            String totalqty = gvDataList.Rows[rowIndex].Cells[7].Text; //get the qty from gridview

            TextBox txtTotalQty = (TextBox)row.FindControl("txttotalQty"); // point the current row and find control
            txtquantity = (TextBox)gvDataList.Rows[rowIndex].Cells[1].FindControl("txtQty");// point the current row and find control
            totalQuantity = Convert.ToInt32(txtquantity.Text);

            current_row_value = txtTotalQty.Text;

            if (!String.IsNullOrEmpty(txtTotalQty.Text) || !(txtTotalQty.Text.Trim().Length == 0))
            {
                if (Convert.ToInt32(txtTotalQty.Text) > Convert.ToInt32(totalqty))
                {
                    Page.ClientScript.RegisterStartupScript(
                         Page.GetType(),
                        "MessageBox",
                         "<script language='javascript'>alert('" + "Please Check TotalNeeded Quantity!" + txtTotalQty.Text + "');</script>"
                        );
                    txtTotalQty.Text = "0";
                }
                if (Convert.ToInt32(txtTotalQty.Text) < Convert.ToInt32(txtquantity.Text))
                {
                    Page.ClientScript.RegisterStartupScript(
                         Page.GetType(),
                        "MessageBox",
                         "<script language='javascript'>alert('" + "Please Check Quantity!"+ "');</script>"
                        );
                    txtquantity.Text = "0";
                }
            }
            else 
            {
                Page.ClientScript.RegisterStartupScript(
                             Page.GetType(),
                            "MessageBox",
                             "<script language='javascript'>alert('" + "Can not be Blank" + txtTotalQty.Text + "');</script>"
                            );
                txtTotalQty.Text = "0";
            }
            

            if ((rowIndex + 1) <= gvDataList.Rows.Count-1) // check the next row
            {
                
                temptotalQTY = (TextBox)gvDataList.Rows[rowIndex + 1].Cells[1].FindControl("txttotalQty");
           
            }
            else
                temptotalQTY = (TextBox)gvDataList.Rows[rowIndex].Cells[1].FindControl("txttotalQty");


            if (temptotalQTY.Visible == false) // visible is false in next row
            {
                //GO DOWN 

                j = 0;
                totalQuantity = 0;

                for (int i = rowIndex; i < gvDataList.Rows.Count; i++)//go down
                {
                    ++j;
                    if ((rowIndex + j) <= gvDataList.Rows.Count - 1)
                    {
                        txttotal = (TextBox)gvDataList.Rows[rowIndex + j].Cells[1].FindControl("txttotalQty");
                        TextBox txtquantity1 = (TextBox)gvDataList.Rows[rowIndex + j].Cells[1].FindControl("txtQty");


                        if (txttotal.Visible == false)
                        {
                            txttotal.Text = current_row_value;
                            if (!String.IsNullOrEmpty(txtquantity1.Text) || !(txtquantity1.Text.Trim().Length == 0))
                            {
                                totalQuantity += Convert.ToInt32(txtquantity1.Text);
                                //  lblMessage.Text += totalQuantity.ToString();
                                if ((rowIndex + j + 1) > gvDataList.Rows.Count - 1)
                                {
                                    //   lblMessage.Text += "check";
                                    if (totalQuantity > Convert.ToInt32(current_row_value))
                                    {
                                        Page.ClientScript.RegisterStartupScript(
                                         Page.GetType(),
                                        "MessageBox",
                                         "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity! Do not allow this Quantity  " + totalQuantity.ToString() + "');</script>"
                                        );
                                        txtquantity1.Text = "0";
                                        return;
                                    }

                                }
                                else if (!String.IsNullOrEmpty(current_row_value) || !(current_row_value.Trim().Length == 0))
                                {
                                    if (totalQuantity > Convert.ToInt32(current_row_value))
                                    {
                                        Page.ClientScript.RegisterStartupScript(
                                         Page.GetType(),
                                        "MessageBox",
                                         "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity! Do not allow this Quantity  " + totalQuantity.ToString() + "');</script>"
                                        );
                                        txtquantity1.Text = "0";
                                    }

                                }

                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(
                                         Page.GetType(),
                                        "MessageBox",
                                         "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity and Add value ! Do not allow this Quantity  " + totalQuantity.ToString() + "');</script>"
                                        );
                                    txtquantity1.Text = "0";
                                }
                            }

                        }
                        else
                        {

                            return;
                        }
                    }
                }


            }
           
        }

        protected void txtQty_TextChanged(object sender, EventArgs e)
        {
            
            TextBox txttotalUP;
            TextBox txtquantity;
            TextBox temptotalQTY;
            int int_txtqty;
            int needQty;
            

            GridViewRow row = ((GridViewRow)((TextBox)sender).NamingContainer);
            //NamingContainer return the container that the control sits in
            int rowIndex = row.RowIndex;
            String qty = gvDataList.Rows[rowIndex].Cells[9].Text; //get the qty from gridview

            TextBox txtQQty = (TextBox)row.FindControl("txtQty"); // point the current row and find control
            TextBox txttotalQTY = (TextBox)row.FindControl("txttotalQty"); // point the current row and find control

            needQty = Convert.ToInt32(qty);         

            if (!String.IsNullOrEmpty(txtQQty.Text) || !(txtQQty.Text.Trim().Length == 0)) // check null
            {
                int_txtqty = Convert.ToInt32(txtQQty.Text);
                if (int_txtqty > needQty)
                {
                    Page.ClientScript.RegisterStartupScript(
                     Page.GetType(),
                    "MessageBox",
                     "<script language='javascript'>alert('" + "Please Check Need Quantity! Do not allow this Quantity" + txtQQty.Text + "');</script>"
                    );
                    txtQQty.Text = "0";
                }
            }
            else
            {
                int_txtqty = 0;
                txtQQty.Text = "0";
                Page.ClientScript.RegisterStartupScript(
                    Page.GetType(),
                   "MessageBox",
                    "<script language='javascript'>alert('" + "Do not allow blank" + "');</script>"
                   );
                txtQQty.Text = "0";
            }



            if ((rowIndex + 1) <= gvDataList.Rows.Count - 1) // check the next row
                temptotalQTY = (TextBox)gvDataList.Rows[rowIndex + 1].Cells[1].FindControl("txttotalQty");
            else
                temptotalQTY = (TextBox)gvDataList.Rows[rowIndex].Cells[1].FindControl("txttotalQty");


            if (txttotalQTY.Visible == false) // check visible is flase in current row
            {

                for (int a = rowIndex; a > -1; a--)       // go up till txttotal.Visible==true
                {
                    txttotalUP = (TextBox)gvDataList.Rows[a].Cells[1].FindControl("txttotalQty"); // go up and find control
                    txtquantity = (TextBox)gvDataList.Rows[a].Cells[1].FindControl("txtQty");   // go up and find control                                   

                    if (txttotalUP.Visible == true)  // to do break the going up loop         
                    {                       
                        GoDownDataInGridView(a,txttotalUP.Text);
                        return;
                    }
                }
            }

            else if (temptotalQTY.Visible == false) // check the visible is false in next row
            {
               // lblMessage.Text += "hereooo";


                GoDownDataInGridView(rowIndex, txttotalQTY.Text);

            }
            else //check the visible is true in current row
            {
               // lblMessage.Text += txtQQty.Text;
                if (!String.IsNullOrEmpty(txttotalQTY.Text) || !(txttotalQTY.Text.Trim().Length == 0))
                {
                    if (Convert.ToInt32(txtQQty.Text) > Convert.ToInt32(txttotalQTY.Text))
                    {
                        Page.ClientScript.RegisterStartupScript(
                         Page.GetType(),
                        "MessageBox",
                         "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity! Do not allow this Quantity " + txtQQty.Text + "');</script>"
                        );

                        txtQQty.Text = "0";
                    }

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(
                          Page.GetType(),
                         "MessageBox",
                          "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity and Add value! Do not allow this Quantity   " + txtQQty.Text + "');</script>"
                         );
                    txtQQty.Text = "0";
                }
            }
            

            
        }
        public void GoDownDataInGridView(int rowIndex, String txttotalQTY)
        { 
                int j = 0;
                int totalQuantity = 0;

              TextBox  Current_txttotal = (TextBox)gvDataList.Rows[rowIndex].Cells[1].FindControl("txttotalQty");
              TextBox  Current_txtquantity = (TextBox)gvDataList.Rows[rowIndex].Cells[1].FindControl("txtQty");



               if (!String.IsNullOrEmpty(Current_txtquantity.Text) || !(Current_txtquantity.Text.Trim().Length == 0))
                   totalQuantity = Convert.ToInt32(Current_txtquantity.Text);

                for (int i = rowIndex; i < gvDataList.Rows.Count; i++)//go down
                {
                    ++j;
                    if ((rowIndex + j) <= gvDataList.Rows.Count - 1)
                    {
                      TextBox  new_txttotal = (TextBox)gvDataList.Rows[rowIndex + j].Cells[1].FindControl("txttotalQty");
                      TextBox new_txtquantity1 = (TextBox)gvDataList.Rows[rowIndex + j].Cells[1].FindControl("txtQty");


                      if (new_txttotal.Visible == false)
                        {
                            if (!String.IsNullOrEmpty(new_txtquantity1.Text) || !(new_txtquantity1.Text.Trim().Length == 0))
                            {
                                totalQuantity += Convert.ToInt32(new_txtquantity1.Text);
                                //  lblMessage.Text += totalQuantity.ToString();
                                if ((rowIndex + j + 1) > gvDataList.Rows.Count - 1)
                                {
                                    //   lblMessage.Text += "check";
                                    if (totalQuantity > Convert.ToInt32(txttotalQTY))
                                    {
                                        Page.ClientScript.RegisterStartupScript(
                                         Page.GetType(),
                                        "MessageBox",
                                         "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity! Do not allow this Quantity  " + totalQuantity.ToString() + "');</script>"
                                        );
                                        new_txtquantity1.Text = "0";
                                        return;
                                    }

                                }
                                else if (!String.IsNullOrEmpty(txttotalQTY) || !(txttotalQTY.Trim().Length == 0))
                                {
                                    if (totalQuantity > Convert.ToInt32(txttotalQTY))
                                    {
                                        Page.ClientScript.RegisterStartupScript(
                                         Page.GetType(),
                                        "MessageBox",
                                         "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity! Do not allow this Quantity  " + totalQuantity.ToString() + "');</script>"
                                        );
                                        new_txtquantity1.Text = "0";
                                    }

                                }

                                else
                                {
                                    Page.ClientScript.RegisterStartupScript(
                                         Page.GetType(),
                                        "MessageBox",
                                         "<script language='javascript'>alert('" + "Please Check TotalReceived Quantity and Add value ! Do not allow this Quantity  " + totalQuantity.ToString() + "');</script>"
                                        );
                                    new_txtquantity1.Text = "0";
                                }
                            }

                        }
                        else
                        {

                            return;
                        }
                    }
                }
        }
       
        protected void gvDataList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {


                int reorderPoint = Convert.ToInt32(e.Row.Cells[7].Text);

                e.Row.CssClass = reorderPoint > 1 ? "success1" : "danger1";
                              
              
            }
        }
       /* protected void gvDataList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            DataTable dTable = (DataTable)Session["dataSource"];


            foreach (GridViewRow grv in this.gvDataList.Rows)
            {
                // get the matching row from the data table
                DataRow dRow = dTable.Rows.Find(this.gvDataList.DataKeys[grv.RowIndex].Value);

                // set values of updated columns : here I have only let the user to edit "Name" column
                dRow["ActualQty"] = ((TextBox)grv.FindControl("txtQty")).Text;
                dRow["TotalReceived"] = ((TextBox)grv.FindControl("txttotalQty")).Text;
            }


            gvDataList.PageIndex = e.NewPageIndex;
            this.gvDataList.DataSource = (DataTable)Session["DataSource"];
            this.gvDataList.DataBind();
            AddRowSpanToGridView();
        }*/
        protected void gvDataList_DataBound(object sender, EventArgs e)
        {

        }
    }
  }
