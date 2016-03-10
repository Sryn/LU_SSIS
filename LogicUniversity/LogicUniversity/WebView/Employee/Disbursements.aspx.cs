using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class Disbursements : System.Web.UI.Page
    {
        String strSessType = "";

        Model.Employee currEmp = null;
        Model.StoreEmployee currStoreEmp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> Disbursements.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                getSessionData();

                bool showDevVariables = false;
                toggleDevVariables(showDevVariables);

                showVariables(); // includes both dev and non-dev variables

                checkRequestQueryString();

                getDisbursementList();

            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> Disbursements.Page_Load( 2 IsPostBack=" + IsCallback + ")");

            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> Disbursements.Page_Load( 3 IsPostBack=" + IsCallback + ")");
        }

        private void getSessionData()
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.getData()");

            strSessType = Model.MySession.Current.type;

            if (strSessType.Equals("Employee"))
            {
                currEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.Employee;
            }
            else if (strSessType.Equals("StoreEmployee"))
            {
                currStoreEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.StoreEmployee;
            }
            else
            {
                showPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");
            }
        }

        private void showPopUp(String msg)
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.showPopUp(msg)");

            // all three look the same
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('" + confirmMsg + "');", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ButtonClickScript", "alert('" + confirmMsg + "');", true);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + msg + "');", true);
        }

        private void toggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.toggleDevVariables(" + showDevVariables + ")");

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

        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.showVariables()");

            if ((lblSessType != null)) // WTF! I have to check the label I made even exists first before I use it!!!
            {
                lblSessType.Text = strSessType;
            }

            if (currEmp != null)
            {
                lblTitle.Text = "Disbursements";

                if (lblEmpID != null)
                    lblEmpID.Text = currEmp.EmployeeID.ToString();

                if (lblDeptID != null)
                    lblDeptID.Text = currEmp.DepartmentID.ToString();

                if (lblRole != null)
                {
                    //lblDeptID.Text = currEmp.DepartmentID.ToString();
                    lblRole.Text = currEmp.Role;
                }
            } else if (currStoreEmp != null) {

                lblTitle.Text = "Disbursement List";

                if (lblEmpID != null)
                {
                    //lblEmpID.Text = currEmp.EmployeeID.ToString();
                    lblEmpID.Text = currStoreEmp.StoreEmployeeID.ToString();
                }

                if (lblDeptID != null)
                    lblDeptID.Text = "Stationery Store";

                if (lblRole != null)
                {
                    //lblDeptID.Text = currEmp.DepartmentID.ToString();
                    lblRole.Text = currStoreEmp.Role;
                }
            }
        }

        private void checkRequestQueryString()
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.checkRequestQueryString()");
            //throw new NotImplementedException();

            int currDisbursementID;
            //Model.Delegate editDelegate;

            if (Request.QueryString["DisbursementID"] != null)
            {
                if (int.TryParse(Request.QueryString["DisbursementID"], out currDisbursementID))
                {
                    btnBackToDisbursements.Visible = true;

                    fillGvDisbursementDetails(currDisbursementID);

                }
            }
        }

        //private void fillGvStoreDisbursementDetails(int currDisbursementID)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> Disbursements.fillGvStoreDisbursementDetails(currDisbursementID=" + currDisbursementID + ")");
        //    throw new NotImplementedException();
        //}

        private void fillGvDisbursementDetails(int currDisbursementID)
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.fillGvDisbursementDetails(currDisbursementID=" + currDisbursementID + ")");

            Control.DisbursementDetailsController ctrlDisbursementDetails = new Control.DisbursementDetailsController();
            List<Model.DisbursementDetail> lstGvDisbursementDetails = ctrlDisbursementDetails.getDisbursementDetails(currDisbursementID);
            List<Model.gvStoreDisbursementDetailsEle> lstGvStoreDisbursementDetails;

            if (lstGvDisbursementDetails != null)
            {
                if (lstGvDisbursementDetails.Count > 0)
                {
                    if (strSessType.Equals("Employee")) {
                        //fillGvDisbursementDetails(currDisbursementID);

                        lblTitle.Text = "Disbursement Details";

                        btnBackToDisbursements.Text = "Back To Disbursements";

                        gvDisbursement.Visible = false;

                        gvDisbursementDetails.DataSource = lstGvDisbursementDetails;
                        gvDisbursementDetails.DataBind();
                    }
                    else if (strSessType.Equals("StoreEmployee")) {
                        //fillGvStoreDisbursementDetails(currDisbursementID);

                        lblTitle.Text = "Disbursement List Details";

                        btnBackToDisbursements.Text = "Back To Disbursement List";

                        gvAllDeptDisbursement.Visible = false;

                        lstGvStoreDisbursementDetails = getlstGvStoreDisbursementDetails(lstGvDisbursementDetails);

                        if (lstGvStoreDisbursementDetails != null)
                        {
                            gvStoreDisbursementDetails.DataSource = lstGvStoreDisbursementDetails;
                            gvStoreDisbursementDetails.DataBind();
                        }
                        else
                        {
                            lblDisbursementTitle.Text = "No Disbursement List Details Information Available";
                        }

                    }
                    else
                        showPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");

                }
                else
                {
                    lblDisbursementTitle.Text = "No Disbursement Detail Information Available";
                }
            }

        }

        private List<Model.gvStoreDisbursementDetailsEle> getlstGvStoreDisbursementDetails(List<Model.DisbursementDetail> lstGvDisbursementDetails)
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.getlstGvStoreDisbursementDetails(lstGvDisbursementDetailsEle)");
            //throw new NotImplementedException();

            //Control.CollectionPointControl ctrlCollPt = new Control.CollectionPointControl();

            List<Model.gvStoreDisbursementDetailsEle> newLstGvStoreDisbursementDetails = null;

            if (lstGvDisbursementDetails != null)
            {
                if (lstGvDisbursementDetails.Count > 0)
                {
                    newLstGvStoreDisbursementDetails = new List<Model.gvStoreDisbursementDetailsEle>();

                    foreach (Model.DisbursementDetail alstGvDisbursementDetailsEle in lstGvDisbursementDetails)
                    {
                        Model.gvStoreDisbursementDetailsEle aGvAllDeptDisbursementEle = new Model.gvStoreDisbursementDetailsEle();

                        aGvAllDeptDisbursementEle.requestID = alstGvDisbursementDetailsEle.requestID;
                        aGvAllDeptDisbursementEle.itemDesc = alstGvDisbursementDetailsEle.itemDesc;
                        aGvAllDeptDisbursementEle.requestDate = alstGvDisbursementDetailsEle.requestDate;
                        aGvAllDeptDisbursementEle.employeeName = alstGvDisbursementDetailsEle.employeeName;

                        aGvAllDeptDisbursementEle.quantityUOM = alstGvDisbursementDetailsEle.quantity + " " + alstGvDisbursementDetailsEle.UOM;

                        newLstGvStoreDisbursementDetails.Add(aGvAllDeptDisbursementEle);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(">>> Disbursements.getlstGvStoreDisbursementDetails lstGvDisbursementDetailsEle.Count less than 1");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(">>> Disbursements.getlstGvStoreDisbursementDetails lstGvDisbursementDetailsEle is null");
            }

            return newLstGvStoreDisbursementDetails;
        }

        private void getDisbursementList()
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.getDisbursementList()");

            if (currEmp!= null || currStoreEmp != null)
            {
                List<Model.DisbursementInformation> lstDisbursementInfo = new List<Model.DisbursementInformation>();
                List<Model.gvAllDeptDisbursementEle> lstGvAllDeptDisbursement;

                if (strSessType.Equals("Employee") && currEmp != null)
                {
                    Control.DisbursementDetailsController ctrlDisbursementDetails = new Control.DisbursementDetailsController();
                    lstDisbursementInfo = ctrlDisbursementDetails.getDeptDisbursements(currEmp.EmployeeID);

                } else if (strSessType.Equals("StoreEmployee") && currStoreEmp != null) {

                    Control.DisbursementDetailsController ctrlDisbursementDetails = new Control.DisbursementDetailsController();
                    lstDisbursementInfo = ctrlDisbursementDetails.getAllDisbursements();
                }
                else
                {
                    // ERROR: Unknown Employee Type
                    lstDisbursementInfo = null;

                    if (lblDisbursementTitle != null)
                        lblDisbursementTitle.Text = "ERROR: Unknown Employee Type = " + strSessType;
                }

                if (gvDisbursement != null)
                {
                    if (lstDisbursementInfo != null)
                    {
                        if (lstDisbursementInfo.Count == 0)
                        {
                            if (lblDisbursementTitle != null)
                                lblDisbursementTitle.Text = "No Disbursement Information Available";
                        }
                        else
                        {
                            //lstGvCollInfo = combNameIDInList(lstCollInfo);

                            if (strSessType.Equals("Employee"))
                            {
                                gvDisbursement.DataSource = lstDisbursementInfo;
                                gvDisbursement.DataBind();
                            }
                            else if (strSessType.Equals("StoreEmployee"))
                            {
                                lstGvAllDeptDisbursement = getLstGvAllDeptDisbursement(lstDisbursementInfo);

                                if (lstGvAllDeptDisbursement != null)
                                {
                                    gvAllDeptDisbursement.DataSource = lstGvAllDeptDisbursement;
                                    gvAllDeptDisbursement.DataBind();
                                }
                                else
                                {
                                    lblDisbursementTitle.Text = "No Disbursement Information Available";
                                }
                            }
                        }
                    }
                }
            }
        }

        private List<Model.gvAllDeptDisbursementEle> getLstGvAllDeptDisbursement(List<Model.DisbursementInformation> lstDisbursementInfo)
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.getLstGvAllDeptDisbursement(lstDisbursementInfo)");
            //throw new NotImplementedException();

            Control.CollectionPointControl ctrlCollPt = new Control.CollectionPointControl();

            List<Model.gvAllDeptDisbursementEle> newLstGvAllDeptDisbursement = null;

            if (lstDisbursementInfo != null)
            {
                if (lstDisbursementInfo.Count > 0)
                {
                    newLstGvAllDeptDisbursement = new List<Model.gvAllDeptDisbursementEle>();

                    foreach (Model.DisbursementInformation alstDisbursementInfoEle in lstDisbursementInfo)
                    {
                        Model.gvAllDeptDisbursementEle aGvAllDeptDisbursementEle = new Model.gvAllDeptDisbursementEle();

                        aGvAllDeptDisbursementEle.DisbursementID = alstDisbursementInfoEle.DisbursementID;
                        aGvAllDeptDisbursementEle.CollectionDate = (DateTime)alstDisbursementInfoEle.CollectionDate;

                        aGvAllDeptDisbursementEle.deptName = ctrlCollPt.getDepartment(alstDisbursementInfoEle.DepartmentID).DepartmentName;

                        newLstGvAllDeptDisbursement.Add(aGvAllDeptDisbursementEle);
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine(">>> Disbursements.getLstGvAllDeptDisbursement lstDisbursementInfo.Count less than 1");
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(">>> Disbursements.getLstGvAllDeptDisbursement lstDisbursementInfo is null");
            }

            return newLstGvAllDeptDisbursement;
        }

        public void btnClick_BackToDisbursements(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> Disbursements.btnClick_BackToDisbursements(sender=" + sender + ")");

            Server.Transfer("Disbursements.aspx", false);
        }

    }
}