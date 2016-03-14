using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class RequestStationery : System.Web.UI.Page
    {
        Control.RequestStationeryControl reqCrt;
        protected void Page_Load(object sender, EventArgs e)
        {
            btnClearAll.Visible = false;
            btnSubmit.Visible = false;
          
            reqCrt = new Control.RequestStationeryControl();
            List<Model.Category> catlist = reqCrt.getAllCategory();
            if (catlist == null)
                return;
            if (!IsPostBack)
            {
<<<<<<< HEAD
                txtRequestQty.Text = "0";
=======
                if (Request["ItemIDToDelete"] != null)
                {
                    int id = Convert.ToInt32(Request["ItemIDToDelete"].ToString());
                   //delete
                }

                if (Request["ItemID"] != null)
                {
                    int id = Convert.ToInt32(Request["ItemID"].ToString());
                   //edit
                }
>>>>>>> origin/master

                foreach (Model.Category cat in catlist)
                {
                    ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
                }
                List<Model.Item> itemList = reqCrt.getItemByCatID("" + catlist[0].CategoryID);
                if (itemList == null)
                    return;
                foreach (Model.Item item in itemList)
                {
                    ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                }
                txtUnitOfMeasure.Text = itemList[0].UOM;
                lblTodayDate.Text = DateTime.Today.Date.ToShortDateString();
                if (Request["ItemIDToDelete"] != null)
                {
                    string id = Request["ItemIDToDelete"];
                    if (Session["ReqItem"] != null)
                    {
                        List<Model.RequisitionItem> temp_List = (List<Model.RequisitionItem>)Session["ReqItem"];
                        foreach(Model.RequisitionItem temp in temp_List)
                        {
                            if (temp.ItemID.Equals(id))
                            {
                                temp_List.Remove(temp);
                                break;
                            }
                        }
                    }
                }
                if (Request["ItemID"] != null)
                {
                    string id = Request["ItemID"];
                    if (Session["ReqItem"] != null)
                    {
                        List<Model.RequisitionItem> temp_List = (List<Model.RequisitionItem>)Session["ReqItem"];
                        foreach (Model.RequisitionItem temp in temp_List)
                        {
                            if (temp.ItemID.Equals(id))
                            {
                                temp_List.Remove(temp);
                                ddlCategory.SelectedValue = reqCrt.getCategoryIDbyItemID(temp.ItemID);
                                ddlItemDescription.SelectedValue = temp.ItemID;
                                txtUnitOfMeasure.Text = reqCrt.getUOMByItemID(temp.ItemID);
                                txtRequestQty.Text = temp.Quantity.GetValueOrDefault().ToString();
                                break;
                            }
                        }
                    }
                }
                if (Request["RequisitionFormID"] != null)
                {
                    int id = Convert.ToInt32(Request["RequisitionFormID"].ToString());
                    List<Model.RequisitionItem> temp_List = reqCrt.getRequisitionItemByReqID(id);
                    Model.RequisitionItem temp = temp_List[0];
                    temp_List.Remove(temp);
                    foreach(Model.RequisitionItem req in temp_List)
                    {
                        req.Reson = "";
                        req.Status = "";
                    }
                    Session["ReqItem"] = temp_List;
                    ddlCategory.SelectedValue = reqCrt.getCategoryIDbyItemID(temp.ItemID);
                    ddlItemDescription.SelectedValue = temp.ItemID;
                    txtUnitOfMeasure.Text = reqCrt.getUOMByItemID(temp.ItemID);
                    txtRequestQty.Text = temp.Quantity.GetValueOrDefault().ToString();
                }
            }
            gridViewDataBind();
        }

        private void gridViewDataBind()
        {
            if (Session["ReqItem"] != null)
            {
                gvData.DataSource = (List<Model.RequisitionItem>)Session["ReqItem"];
                gvData.DataBind();
                btnClearAll.Visible = true;
                btnSubmit.Visible = true;
            }
        }

        protected void ddlItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.Item> itemlist = reqCrt.getItemByCatID(ddlCategory.SelectedValue);
            txtUnitOfMeasure.Text = itemlist[ddlItemDescription.SelectedIndex].UOM;
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlItemDescription.Items.Clear();
            List<Model.Item> itemList = reqCrt.getItemByCatID(ddlCategory.SelectedValue);
            if (itemList == null || itemList.Count==0) {
                txtUnitOfMeasure.Text = "";
                return;
            }
            foreach (Model.Item item in itemList)
            {
                ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
            }
            txtUnitOfMeasure.Text = itemList[ddlItemDescription.SelectedIndex].UOM;
        }
       
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnSubmit.Visible = true;
            btnClearAll.Visible = true;
            if (ddlItemDescription.SelectedValue == null)
                return;

            List<Model.RequisitionItem> ReqItem;
            if (Session["ReqItem"] == null)
                ReqItem = new List<Model.RequisitionItem>();
            else
                ReqItem = (List<Model.RequisitionItem>)Session["ReqItem"];

            foreach(Model.RequisitionItem rit in ReqItem)
            {
                if (rit.ItemID.Equals(ddlItemDescription.SelectedValue))
                {
                    rit.Quantity = Convert.ToInt32(txtRequestQty.Text);
                    gridViewDataBind();
                    return;
                }
            }
            Model.RequisitionItem temp = new Model.RequisitionItem();
            temp.ItemID = ddlItemDescription.SelectedValue;
            temp.Quantity = Convert.ToInt32(txtRequestQty.Text);
            ReqItem.Add(temp);
            Session["ReqItem"] = ReqItem;
            gridViewDataBind();
            txtRequestQty.Text = "0";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Session["ReqItem"] == null)
            {
                lblMessage.Text = "Add Data First";
                return;
            }
            else
            {
                reqCrt.insertNewReqisition((List<Model.RequisitionItem>)Session["ReqItem"],((Model.Employee)Session["User"]).EmployeeID,"");
                lblMessage.Text = "Successfully Added";
                Session["ReqItem"] = null;
                gvData.DataSource = null;
                gvData.DataBind();
                txtRequestQty.Text = "0";
                btnClearAll.Visible = false;
                btnSubmit.Visible = false;
            }
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            Session["ReqItem"] = null;
            gvData.DataSource = null;
            gvData.DataBind();
            txtRequestQty.Text = "0";
            btnClearAll.Visible = false;
            btnSubmit.Visible = false;
        }

        protected void gvData_RowCreated(object sender, GridViewRowEventArgs e)
        {
            e.Row.Cells[2].Style.Add("display", "none");
            e.Row.Cells[3].Style.Add("display", "none");
            //e.Row.Cells[4].Style.Add("display", "none");
        }
    }
}