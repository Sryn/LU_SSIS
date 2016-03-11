using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Model;
using LogicUniversity.Control;

namespace LogicUniversity.WebView.Finance
{
    
    public partial class ManageItem : System.Web.UI.Page
    {
        FinanceController crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new FinanceController();
            List<Category> catList = crt.getAllCategoryList();
            foreach(Category cat in catList)
            {
                ddlCategory.Items.Add(new ListItem(cat.CategoryName, ""+cat.CategoryID));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text.Trim().Equals(string.Empty))
            {
                lblMessage.Text = "Enter ItemID";
                return;
            }
            if (crt.checkItemID(txtItemID.Text.Trim()).Equals("Found"))
            {
                lblMessage.Text = "Enter Another Item ID";
                return;
            }
            Item item = new Item();
            item.ItemID = txtItemID.Text;
            item.Description = txtDescription.Text;
            item.Quantity = Convert.ToInt32(txtQuantity.Text);
            item.UOM = txtUOM.Text;
            item.CategoryID = Convert.ToInt32(ddlCategory.SelectedValue);
            item.ReorderLevel = Convert.ToInt32(txtReorderLevel.Text);
            item.ReorderQty = Convert.ToInt32(txtReorderQuantity.Text);
            item.BinNo = txtBinNo.Text;
            String savePath = @"~\src\img\";
            if (fuplQRCode.HasFile)
            {
                String fileName = fuplQRCode.FileName;
                savePath += fileName;
                fuplQRCode.SaveAs(savePath);
            }
            else
            {
                lblMessage.Text = "Cant Find QR code image";
                return;
            }
            item.QRCode = savePath;
            crt.insertItem(item);
        }
    }
}