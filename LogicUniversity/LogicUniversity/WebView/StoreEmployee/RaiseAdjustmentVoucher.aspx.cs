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
    public partial class RaiseAdjustmentVoucher : System.Web.UI.Page
    {
        AdjustmentVoucherControl crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new AdjustmentVoucherControl();
            List<Category> catlist = crt.getAllCategory();
            if (catlist == null)
                return;
            if (!IsPostBack)
            {
                foreach (Model.Category cat in catlist)
                {
                    ddlCategory.Items.Add(new ListItem(cat.CategoryName, "" + cat.CategoryID));
                }
                List<Item> itemList = crt.getItemByCatID("" + catlist[0].CategoryID);
                if (itemList == null)
                    return;
                foreach (Model.Item item in itemList)
                {
                    ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
                }
                txtUnifOfMeasure.Text = itemList[0].UOM;

                if (Request["ItemCodeToDelete"] != null)
                {
                    String id =Request["ItemCodeToDelete"].ToString();
                    _delete(id);
                }

                if (Request["ItemCodeToEdit"] != null)
                {
                    String id =Request["ItemCodeToEdit"].ToString();
                    _Edit(id);
                }

                gridViewDataBind();
            }
           
        }
        public void _delete(String itemid)
        {
            System.Diagnostics.Debug.WriteLine("Delete Click" + itemid);

            List<RaiseAdjustmentVoucherItem> POItemList;
            if (Session["AdjItem"] == null)
                POItemList = new List<RaiseAdjustmentVoucherItem>();
            else
                POItemList = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];
            foreach (RaiseAdjustmentVoucherItem rpov in POItemList)
            {
                if (rpov.ItemCode.Equals(itemid))
                {
                    POItemList.Remove(rpov);
                    gridViewDataBind();
                    return;
                }
            }
        }

        public void _Edit(String itemid)
        {
            System.Diagnostics.Debug.WriteLine("ReOrder Click" + itemid);

            List<RaiseAdjustmentVoucherItem> POItemList;
            if (Session["AdjItem"] == null)
                POItemList = new List<RaiseAdjustmentVoucherItem>();
            else
                POItemList = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];
            foreach (RaiseAdjustmentVoucherItem rpov in POItemList)
            {
                if (rpov.ItemCode.Equals(itemid))
                {
                    POItemList.Remove(rpov);
                    if (rpov.Quantity > 0)
                    {
                        txtQuantityToAdjust.Text = rpov.Quantity.ToString();
                        rblIncreaseOrDecrease.SelectedIndex = 0;
                    }
                    else
                    {
                        txtQuantityToAdjust.Text = (rpov.Quantity*-1).ToString();
                        rblIncreaseOrDecrease.SelectedIndex = 1;
                    }
                    txtReason.Text = rpov.Reason;
                    gridViewDataBind();
                    return;
                }
            }
        }
        private void gridViewDataBind()
        {
            if (Session["AdjItem"] != null)
            {
                gvList.DataSource = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];
                gvList.DataBind();
            }
            else
            {
                gvList.DataSource = null;
                gvList.DataBind();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ddlItemDescription.SelectedValue == null)
                return;

            List<RaiseAdjustmentVoucherItem> AdjItemList;
            if (Session["AdjItem"] == null)
                AdjItemList = new List<RaiseAdjustmentVoucherItem>();
            else
                AdjItemList = (List<RaiseAdjustmentVoucherItem>)Session["AdjItem"];

            foreach (RaiseAdjustmentVoucherItem ait in AdjItemList)
            {
                if (ait.ItemCode.Equals(ddlItemDescription.SelectedValue))
                {
                    if (rblIncreaseOrDecrease.SelectedValue.Equals("Decrease"))
                        ait.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text) * -1;
                    else
                        ait.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text);

                    ait.TotalPrice = ait.Quantity * ait.UnitPrice;
                    gridViewDataBind();
                    return;
                }
            }
            RaiseAdjustmentVoucherItem temp = crt.getRaiseAdjustmentVoucherItem(ddlItemDescription.SelectedValue);
            temp.Reason = txtReason.Text;
            if(rblIncreaseOrDecrease.SelectedValue.Equals("Decrease"))
                temp.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text)*-1;
            else
                temp.Quantity = Convert.ToInt32(txtQuantityToAdjust.Text);
            temp.TotalPrice = temp.Quantity * temp.UnitPrice;

            AdjItemList.Add(temp);
            Session["AdjItem"] = AdjItemList;
            gridViewDataBind();
            txtQuantityToAdjust.Text = "";
            txtReason.Text = "";
        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlItemDescription.Items.Clear();
            List<Model.Item> itemList = crt.getItemByCatID(ddlCategory.SelectedValue);
            if (itemList == null || itemList.Count == 0)
            {
                txtUnifOfMeasure.Text = "";
                return;
            }
            foreach (Model.Item item in itemList)
            {
                ddlItemDescription.Items.Add(new ListItem(item.Description, "" + item.ItemID));
            }
            txtUnifOfMeasure.Text = itemList[ddlItemDescription.SelectedIndex].UOM;
        }

        protected void ddlItemDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.Item> itemlist = crt.getItemByCatID(ddlCategory.SelectedValue);
            txtUnifOfMeasure.Text = itemlist[ddlItemDescription.SelectedIndex].UOM;
        }
        
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (Session["AdjItem"] == null)
            {
                lblMessage.Text = "Fill the item first";
            }
            else
            {
                lblMessage.Text = crt.insertNewAdjustementVoucher((List<RaiseAdjustmentVoucherItem>)Session["AdjItem"], ((Model.StoreEmployee)Session["User"]).StoreEmployeeID);
                Session["AdjItem"] = null;
                gridViewDataBind();
                txtQuantityToAdjust.Text = "";
                txtReason.Text = "";
            }
        }
    }
}