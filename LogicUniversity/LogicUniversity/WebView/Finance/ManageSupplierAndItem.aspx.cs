using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Finance
{
    public partial class ManageSupplierAndItem : System.Web.UI.Page
    {
        const int rankCount = 3;

        protected int supplierCount
        {
            get { return Convert.ToInt32(ViewState["supplierCount"]); }
            set { ViewState["supplierCount"] = value; }
        }
        protected int currCategoryID
        {
            get { return Convert.ToInt32(ViewState["currCategoryID"]); }
            set { ViewState["currCategoryID"] = value; }
        }

        protected String currItemID
        {
            get { return ViewState["currItemID"] as String; }
            set { ViewState["currItemID"] = value; }
        }

        protected String randomIndex
        {
            get { return ViewState["randomIndex"] as String; }
            set { ViewState["randomIndex"] = value; }
        }

        String strSessType = "";

        Model.Employee currEmp = null;
        //Model.StoreEmployee currStoreEmp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                getSessionData();

                bool showDevVariables = false;
                toggleDevVariables(showDevVariables);

                showVariables(); // includes both dev and non-dev variables

                fillCategory();

                fillRankDDLs();

                //checkRequestQueryString();

                //getDisbursementList();

            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.Page_Load( 2 IsPostBack=" + IsCallback + ")");

            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.Page_Load( 3 IsPostBack=" + IsCallback + ")");

            //checkCBXStatus();
        }

        private void checkCBXStatus()
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.checkCBXStatus()");

            for (int i = 1; i <= rankCount; i++)
            {
                CheckBox theCheckBox = getControl("cbxSupplier", i) as CheckBox;
                RangeValidator theRangeValidator = getControl("priceValidator", i) as RangeValidator;

                if (theCheckBox != null && theRangeValidator != null)
                {
                    System.Diagnostics.Debug.WriteLine(">>> checkCBXStatus cbxSupplier" + i + " found");

                    if (theCheckBox.Checked)
                    {
                        // enable validation
                        theRangeValidator.Enabled = true;
                    }
                    else
                    {
                        // disable validation
                        theRangeValidator.Enabled = false;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(">>> checkCBXStatus cbxSupplier" + i + " and/or priceValidator" + i + " not found");
                }
            }
        }

        private void getSessionData()
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.getData()");

            strSessType = Model.MySession.Current.type;

            if (strSessType.Equals("Finance"))
            {
                currEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.Employee;
            } 
            //else if (strSessType.Equals("Employee"))
            //{
            //    currEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.Employee;
            //}
            //else if (strSessType.Equals("StoreEmployee"))
            //{
            //    currStoreEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.StoreEmployee;
            //}
            else
            {
                showPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");
            }
        }

        private void showPopUp(String msg)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.showPopUp(msg)");

            // all three look the same
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('" + confirmMsg + "');", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ButtonClickScript", "alert('" + confirmMsg + "');", true);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + msg + "');", true);
        }

        private void toggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.toggleDevVariables(" + showDevVariables + ")");

            if (lblTxtSessType != null)
                lblTxtSessType.Visible = showDevVariables;

            if (lblSessType != null)
                lblSessType.Visible = showDevVariables;

            if (lblTxtEmpID != null)
                lblTxtEmpID.Visible = showDevVariables;

            if (lblEmpID != null)
                lblEmpID.Visible = showDevVariables;

            if (lblTxtDeptID != null)
                lblTxtDeptID.Visible = showDevVariables;

            if (lblDeptID != null)
                lblDeptID.Visible = showDevVariables;

            if (lblTxtRole != null)
                lblTxtRole.Visible = showDevVariables;

            if (lblRole != null)
                lblRole.Visible = showDevVariables;

            lblDevMessage.Visible = showDevVariables;
        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.showVariables()");

            if ((lblSessType != null)) // WTF! I have to check the label I made even exists first before I use it!!!
            {
                lblSessType.Text = strSessType;
            }

            if (currEmp != null)
            {
                //lblTitle.Text = "ManageSupplierAndItem";

                if (lblEmpID != null)
                    lblEmpID.Text = currEmp.EmployeeID.ToString();

                if (lblDeptID != null)
                    lblDeptID.Text = currEmp.DepartmentID.ToString();

                if (lblRole != null)
                {
                    //lblDeptID.Text = currEmp.DepartmentID.ToString();
                    lblRole.Text = currEmp.Role;
                }
            }
            //else if (currStoreEmp != null)
            //{

            //    //lblTitle.Text = "Disbursement List";

            //    if (lblEmpID != null)
            //    {
            //        //lblEmpID.Text = currEmp.EmployeeID.ToString();
            //        lblEmpID.Text = currStoreEmp.StoreEmployeeID.ToString();
            //    }

            //    if (lblDeptID != null)
            //        lblDeptID.Text = "Stationery Store";

            //    if (lblRole != null)
            //    {
            //        //lblDeptID.Text = currEmp.DepartmentID.ToString();
            //        lblRole.Text = currStoreEmp.Role;
            //    }
            //}
        }

        private void fillCategory()
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.fillCategory()");
            //throw new NotImplementedException();

            Control.RequestStationeryControl ctrlRequestStationery = new Control.RequestStationeryControl();
            List<Model.Category> lstCategory = ctrlRequestStationery.getAllCategory();

            if (lstCategory != null && lstCategory.Count > 0)
            {
                ddlCategory.Enabled = true;

                ddlCategory.DataSource = lstCategory;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();
                //ddlCategory.Items.Insert(0, "Select");
                fill_ddlItemDesc(ddlCategory.SelectedValue);
            }
            else
            {
                lblUserMessage.Text = "ERROR: Cannot load any Category data";
            }
        }

        private void fillRankDDLs()
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.fillRankDDLs()");
            //throw new NotImplementedException();

            DropDownList theRankDDL;

            List<int> lstRank = new List<int>();

            for (int i = 1; i <= rankCount; i++)
            {
                lstRank.Add(i);
            }

            for (int i = 1; i <= rankCount; i++)
            {
                theRankDDL = getControl("ddlRank", i) as DropDownList;

                if (theRankDDL != null)
                {
                    theRankDDL.DataSource = lstRank;
                    theRankDDL.DataBind();
                }
            }
        }

        protected void ddlCategorySelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.ddlCategorySelectedIndexChanged(sender="+sender+")");

            fill_ddlItemDesc(ddlCategory.SelectedValue);
        }

        private void fill_ddlItemDesc(string selectedValue)
        {
            List<Model.Item> lstItem = null;

            int selectedCategoryID;

            if (int.TryParse(selectedValue, out selectedCategoryID))
            {
                currCategoryID = selectedCategoryID;

                lblDevMessage.Text = selectedCategoryID.ToString();

                Control.RequestStationeryControl ctrlRequestStationery = new Control.RequestStationeryControl();
                lstItem = ctrlRequestStationery.getItemByCatID(selectedCategoryID.ToString());

                if (lstItem != null && lstItem.Count > 0)
                {
                    // Item List obtained
                    ddlItemDesc.Enabled = true;

                    ddlItemDesc.DataSource = lstItem;
                    ddlItemDesc.DataTextField = "Description";
                    ddlItemDesc.DataValueField = "ItemID";
                    ddlItemDesc.DataBind();
                    //ddlItemDesc.Items.Insert(0, "Select");
                    fill_SupplierDDLs(ddlItemDesc.SelectedValue);
                }
                else
                {
                    lblUserMessage.Text = "ERROR: Cannot load any selected Category Item data";
                }
            }
            else
            {
                ddlItemDesc.Enabled = false;
            }
        }

        protected void ddlItemDescSelectedIndexChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.ddlItemDescSelectedIndexChanged(sender=" + sender + ")");

            fill_SupplierDDLs(ddlItemDesc.SelectedValue);
        }

        private void fill_SupplierDDLs(String currItemID)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.ddlItemDescSelectedIndexChanged(currItemID=" + currItemID + ")");

            fill_UOM(currItemID);

            //currItemID = ddlItemDesc.SelectedValue;
            List<Model.Supplier> lstSupplier = null;

            lblDevMessage.Text = currItemID;

            Control.FinanceController ctrlFinance = new Control.FinanceController();

            try
            {
                lstSupplier = ctrlFinance.getSupplierList();

                if (lstSupplier != null && lstSupplier.Count > 0)
                {
                    // supplier List obtained

                    supplierCount = lstSupplier.Count;

                    btnSubmit.Enabled = true;

                    DropDownList currSupplierDDL, currRankDDL;
                    TextBox currPriceTBX;

                    for (int i = 1; i <= rankCount; i++)
                    {
                        currSupplierDDL = getControl("ddlSupplier", i) as DropDownList;
                        currRankDDL = getControl("ddlRank", i) as DropDownList;
                        currPriceTBX = getControl("tbxPrice", i) as TextBox;

                        if (i <= supplierCount)
                        {
                            if (currSupplierDDL != null)
                            {
                                System.Diagnostics.Debug.WriteLine(">>> ddlSupplier" + i + " found");

                                // targeted ddlSupplier found

                                currSupplierDDL.Enabled = true;

                                currSupplierDDL.DataSource = lstSupplier;
                                currSupplierDDL.DataTextField = "SupplierName";
                                currSupplierDDL.DataValueField = "SupplierID";
                                currSupplierDDL.DataBind();
                                //currDDL.Items.Insert(0, "Select");
                                if (supplierCount >= rankCount)
                                {
                                    currSupplierDDL.SelectedIndex = getRandomIndex(i, supplierCount);

                                    if (currRankDDL != null)
                                        currRankDDL.SelectedIndex = i - 1;
                                }
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine(">>> ERROR: Cannot find ddlSupplier" + i);

                                lblUserMessage.Text = "ERROR:  Supplier Fields can't be filled ";
                            }
                        }
                        else
                        {
                            toggleCbxSupplier(i, false);
                        }

                    }

                }
                else
                {
                    ddlSupplier1.Enabled = false;
                    ddlSupplier2.Enabled = false;
                    ddlSupplier3.Enabled = false;

                    btnSubmit.Enabled = false;

                    lblUserMessage.Text = "ERROR: Cannot load any Supplier data";
                }
            }
            catch (Exception e1)
            {
                System.Diagnostics.Debug.WriteLine(">>> Exception caught at ManageSupplierAndItem.ddlItemDescSelectedIndexChanged e=" + e1);
            }

        }

        private void fill_UOM(string currItemID)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.fill_UOM( currItemID=" + currItemID + " )");
            //throw new NotImplementedException();

            Model.Item currItem;

            if (lblUOM != null)
            {
                currItem = Model.Utilities.getItem(currItemID);

                if (currItem != null)
                    lblUOM.Text = currItem.UOM;
            }
        }

        private void toggleCbxSupplier(int i, bool status)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.uncheckCbxSupplier( i=" + i + " )");
            //throw new NotImplementedException();

            CheckBox theCheckBox = getControl("cbxSupplier", i) as CheckBox;

            if (theCheckBox != null)
            {
                theCheckBox.Checked = status;

                changeCbxRow(theCheckBox, i);

                theCheckBox.Enabled = status;
            }
        }

        private System.Web.UI.Control getControl(string controlPrefix, int i)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.getControl( controlPrefix=" + controlPrefix + ", i=" + i + " )");

            System.Web.UI.HtmlControls.HtmlTable tblUser = null;

            tblUser = (System.Web.UI.HtmlControls.HtmlTable)Model.Utilities.FindControlRecursive(Page, "tblUser");

            System.Web.UI.Control currControl = null;

            if (tblUser != null)
            {
                //System.Diagnostics.Debug.WriteLine(">>> tblUser found");

                currControl = tblUser.FindControl(controlPrefix + i);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(">>> ERROR: Cannot find tblUser");

                lblUserMessage.Text = "ERROR: Page Controls can't be accessed";
            }

            return currControl;
        }

        //private DropDownList getControl(string ddlPrefix, int i)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.getControl( i=" + i + ", ddlPrefix=" + ddlPrefix + " )");

        //    System.Web.UI.HtmlControls.HtmlTable tblUser = null;

        //    tblUser = (System.Web.UI.HtmlControls.HtmlTable)Model.Utilities.FindControlRecursive(Page, "tblUser");

        //    DropDownList currDDL = null;

        //    if (tblUser != null)
        //    {
        //        System.Diagnostics.Debug.WriteLine(">>> tblUser found");

        //        currDDL = tblUser.FindControl(ddlPrefix + i) as DropDownList;
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine(">>> ERROR: Cannot find tblUser");

        //        lblUserMessage.Text = "ERROR: Supplier Fields can't be filled";
        //    }

        //    return currDDL;
        //}

        //private TextBox getControl(string tbxPrefix, int i)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.getControl( i=" + i + " )");

        //    System.Web.UI.HtmlControls.HtmlTable tblUser = null;

        //    tblUser = (System.Web.UI.HtmlControls.HtmlTable)Model.Utilities.FindControlRecursive(Page, "tblUser");

        //    TextBox currTBX = null;

        //    if (tblUser != null)
        //    {
        //        System.Diagnostics.Debug.WriteLine(">>> tblUser found");

        //        currTBX = tblUser.FindControl(tbxPrefix + i) as TextBox;
        //    }
        //    else
        //    {
        //        System.Diagnostics.Debug.WriteLine(">>> ERROR: Cannot find tblUser");

        //        lblUserMessage.Text = "ERROR: Supplier Fields can't be filled";
        //    }

        //    return currTBX;
        //}

        private int getRandomIndex(int i, int supplierCount)
        {
            // random code not implemented
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.getRandomIndex( i=" + i + ", supplierCount=" + supplierCount + " )");
            //throw new NotImplementedException();

            if (i <= supplierCount)
                return i - 1;
            else
                return 0;

        }

        public void cbxCheckedChanged(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.cbxCheckedChanged( sender=" + sender + " )");

            CheckBox theCheckBox = sender as CheckBox;
            String cbxID = theCheckBox.ID;

            lblDevMessage.Text = cbxID + " changed to " + theCheckBox.Checked;

            int i;

            if (int.TryParse(cbxID.Substring(cbxID.Length - 1, 1), out i))
            {
                changeCbxRow(theCheckBox, i);
            }
        }

        private void changeCbxRow(CheckBox theCheckBox, int i)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.changeCbxRow( theCheckBox.ID="+ theCheckBox.ID +", i=" + i + " )");

            DropDownList theSupplierDDL, theRankDDL;
            TextBox thePriceTBX;

            theSupplierDDL = getControl("ddlSupplier", i) as DropDownList;
            theRankDDL = getControl("ddlRank", i) as DropDownList;
            thePriceTBX = getControl("tbxPrice", i) as TextBox;

            if (theSupplierDDL != null)
                theSupplierDDL.Enabled = theCheckBox.Checked;

            if (theRankDDL != null)
                theRankDDL.Enabled = theCheckBox.Checked;

            if (thePriceTBX != null)
                thePriceTBX.Enabled = theCheckBox.Checked;

            // validator enable/disable

            bool trueOrFalse = theCheckBox.Checked;

            switch (i)
            {
                case 1:
                    System.Diagnostics.Debug.WriteLine(">>> changeCbxRow: switch case i=" + i + " )");
                    priceValidator1.Enabled = trueOrFalse;
                    supplier12CompareValidator.Enabled = trueOrFalse;
                    supplier31CompareValidator.Enabled = trueOrFalse;
                    rank12CompareValidator.Enabled = trueOrFalse;
                    rank31CompareValidator.Enabled = trueOrFalse;
                    break;
                case 2:
                    System.Diagnostics.Debug.WriteLine(">>> changeCbxRow: switch case i=" + i + " )");
                    priceValidator2.Enabled = trueOrFalse;
                    supplier12CompareValidator.Enabled = trueOrFalse;
                    supplier23CompareValidator.Enabled = trueOrFalse;
                    rank12CompareValidator.Enabled = trueOrFalse;
                    rank23CompareValidator.Enabled = trueOrFalse;
                    break;
                case 3:
                    System.Diagnostics.Debug.WriteLine(">>> changeCbxRow: switch case i=" + i + " )");
                    priceValidator3.Enabled = trueOrFalse;
                    supplier23CompareValidator.Enabled = trueOrFalse;
                    supplier31CompareValidator.Enabled = trueOrFalse;
                    rank23CompareValidator.Enabled = trueOrFalse;
                    rank31CompareValidator.Enabled = trueOrFalse;
                    break;
                default:
                    System.Diagnostics.Debug.WriteLine(">>> changeCbxRow: illegal value in switch i=" + i + " )");
                    break;
            }
        }

        public void btnClick_Submit(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.btnClick_Submit( sender=" + sender + " )");

            lblDevMessage.Text = ddlSupplier1.SelectedValue + tbxPrice1.Text + " " + ddlSupplier2.SelectedValue + tbxPrice2.Text + " " + ddlSupplier3.SelectedValue + tbxPrice3.Text;
            lblUserMessage.Text = "";

            String currItemID = ddlItemDesc.SelectedValue;

            int checkedCBXCount = countCheckedCBX();

            Decimal price;

            Model.SupplierItem aSupplierItem;

            DropDownList aSupplierDDL, aRankDDL;
            TextBox aTBX;
            CheckBox aCBX;

            List<Model.SupplierItem> lstSupplierItem = new List<Model.SupplierItem>();

            for (int i = 1; i <= rankCount; i++)
            {
                aCBX = getControl("cbxSupplier", i) as CheckBox;

                if (aCBX != null && aCBX.Checked == true)
                {
                    aTBX = getControl("tbxPrice", i) as TextBox;

                    if (aTBX != null && Decimal.TryParse(aTBX.Text, out price))
                    {
                        if (price > 0)
                        {
                            aSupplierDDL = getControl("ddlSupplier", i) as DropDownList;
                            aRankDDL = getControl("ddlRank", i) as DropDownList;

                            if (aSupplierDDL != null && aRankDDL != null)
                            {
                                aSupplierItem = new Model.SupplierItem();

                                aSupplierItem.ItemID = currItemID;
                                aSupplierItem.SupplierID = aSupplierDDL.SelectedValue;
                                aSupplierItem.Price = price;
                                aSupplierItem.Priority = Convert.ToInt32(aRankDDL.SelectedValue);

                                lstSupplierItem.Add(aSupplierItem);
                            }
                        }
                    }
                }
            }

            if (lstSupplierItem.Count == checkedCBXCount)
            {
                // process validity of user input in lstSupplierItem
                // in here, all of the prices should be more than 0

                if (checkRankValidity(lstSupplierItem, 1))
                {
                    if(checkSupplierValidity(lstSupplierItem)) {
                        printLstSupplierItem(lstSupplierItem);

                        Control.FinanceController ctrlFinance = new Control.FinanceController();

                        if(ctrlFinance.saveNewSupplierPricesForItem(currItemID, lstSupplierItem))
                            lblUserMessage.Text = "New Supplier Prices Saved Successfully";
                        else
                            lblUserMessage.Text = "ERROR: Cannot Save New Supplier Prices";
                    }
                    else
                    {
                        lblUserMessage.Text = "ERROR: Cannot obtain valid suppliers, e.g. Suppliers should not be the same between rows";
                    }
                }
                else
                {
                    lblUserMessage.Text = "ERROR: Cannot obtain valid priorities, e.g. Priorities should not be the same between rows";
                }
            }
            else
            {
                lblUserMessage.Text = "ERROR: Cannot obtain valid input values, e.g. Prices should not be Zero (0)";
            }
        }

        private bool checkSupplierValidity(List<Model.SupplierItem> lstSupplierItem)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.checkSupplierValidity( lstSupplierItem )");

            bool rtnBool = false;
            string currSupplierID = "";
            int i, j;

            if (lstSupplierItem.Count == 1)
            {
                rtnBool = true;
            }
            else
            {
                for (i = 0; i < lstSupplierItem.Count; i++)
                {
                    currSupplierID = lstSupplierItem.ElementAt(i).SupplierID;

                    for (j = i + 1; j < lstSupplierItem.Count; j++)
                    {
                        if (currSupplierID != lstSupplierItem.ElementAt(j).SupplierID)
                            rtnBool = true;
                        else
                        {
                            rtnBool = false;
                            break;
                        }
                    }

                    if (!rtnBool)
                        break;
                }
            }

            return rtnBool;
        }

        private bool checkRankValidity(List<Model.SupplierItem> lstSupplierItem, int currRank)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.checkRankValidity( lstSupplierItem )");
            //throw new NotImplementedException();

            bool rtnBool = false;

            foreach (Model.SupplierItem aSupplierItem in lstSupplierItem)
            {
                if (!rtnBool && aSupplierItem.Priority == currRank)
                    rtnBool = true;
                else
                    rtnBool = false; // toggles back to false if more than one of the same rank
            }

            if (!rtnBool && currRank < lstSupplierItem.Count)
                rtnBool = checkRankValidity(lstSupplierItem, currRank + 1);

            return rtnBool;
        }

        private int countCheckedCBX()
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.countCheckedCBX()");
            //throw new NotImplementedException();

            int count = 0;

            if (cbxSupplier1.Checked == true) count++;
            if (cbxSupplier2.Checked == true) count++;
            if (cbxSupplier3.Checked == true) count++;

            return count;
        }

        private void printLstSupplierItem(List<Model.SupplierItem> lstSupplierItem)
        {
            System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.printLstSupplierItem( lstSupplierItem )");
            //throw new NotImplementedException();

            lblDevMessage.Text = "";

            foreach (Model.SupplierItem aSupplierITem in lstSupplierItem)
            {
                lblDevMessage.Text += "SupplierID=" + aSupplierITem.SupplierID + " Price=" + aSupplierITem.Price + " Priority=" + aSupplierITem.Priority + "<br />";
            }
        }

        //private void getPriceRanking(ref List<Model.SupplierItem> lstSupplierItem)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.getPriceRanking( lstSupplierItem )");
        //    //throw new NotImplementedException();

        //    String lowestSupplier = "";
        //    Decimal lowestPrice = 0, currLowestPrice = 0;

        //    if (lstSupplierItem.Count == rankCount)
        //    {
        //        if (getLowestPrice(lstSupplierItem, ref lowestPrice, ref lowestSupplier, currLowestPrice))
        //        {

        //        }

        //    }
        //}

        //private bool getLowestPrice(List<Model.SupplierItem> lstSupplierItem, ref decimal lowestPrice, ref string lowestSupplier, decimal currLowestPrice)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> ManageSupplierAndItem.getLowestPrice( lstSupplierItem, ref lowestPrice=" + lowestPrice + " )");
        //    //throw new NotImplementedException();

        //    bool boolResult = false;

        //    foreach (Model.SupplierItem aSupplierItem in lstSupplierItem)
        //    {
        //        if (aSupplierItem.Price != 0)
        //        {
        //            if (currLowestPrice == 0)
        //            {
        //                lowestPrice = Convert.ToDecimal(aSupplierItem.Price);
        //                lowestSupplier = aSupplierItem.SupplierID;
        //            }
        //            else if (aSupplierItem.Price < lowestPrice)
        //            {
        //                if (aSupplierItem.Price < lowestPrice)
        //                {
        //                    lowestPrice = Convert.ToDecimal(aSupplierItem.Price);
        //                    lowestSupplier = aSupplierItem.SupplierID;
        //                }
        //            }
        //        }
        //    }

        //    return boolResult;
        //}

    }
}