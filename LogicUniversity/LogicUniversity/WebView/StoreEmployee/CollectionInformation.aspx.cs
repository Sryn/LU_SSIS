using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.StoreEmployee
{
    public partial class CollectionInformation : System.Web.UI.Page
    {
        //int delegateID;

        //DateTime currentDate = System.DateTime.Now.Date;

        //Boolean boolEdit, boolCancel;

        //String returnMsg;
        String strSessType = "";

        //Model.Employee currEmp = null;
        Model.StoreEmployee currStoreEmp = null;
        //Model.Delegate aDelegate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               Tt.Style.Add("display", "none");
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> CollectionInformation.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                getSessionData();

                bool showDevVariables = false;
                toggleDevVariables(showDevVariables);

                showVariables(); // includes both dev and non-dev variables

                getCollInfo();

            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> CollectionInformation.Page_Load( 2 IsPostBack=" + IsCallback + ")");

            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> CollectionInformation.Page_Load( 3 IsPostBack=" + IsCallback + ")");
        }

        private void getSessionData()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionInformation.getData()");

            strSessType = Model.MySession.Current.type;

            if (strSessType.Equals("StoreEmployee"))
            {
                currStoreEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.StoreEmployee;
            }
            else
                showPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");

        }

        private void showPopUp(String msg)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionInformation.showPopUp(msg)");

            // all three look the same
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('" + confirmMsg + "');", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ButtonClickScript", "alert('" + confirmMsg + "');", true);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + msg + "');", true);
        }

        private void toggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionInformation.toggleDevVariables(" + showDevVariables + ")");

            if (lblTxtSessType != null)
                lblTxtSessType.Visible = showDevVariables;

            if (lblSessType != null)
                lblSessType.Visible = showDevVariables;

            if (lblTxtStoreEmpID != null)
                lblTxtStoreEmpID.Visible = showDevVariables;

            if (lblStoreEmpID != null)
                lblStoreEmpID.Visible = showDevVariables;

            if (lblTxtRole != null)
                lblTxtRole.Visible = showDevVariables;

            if (lblRole != null)
                lblRole.Visible = showDevVariables;

            //lblChosenEmp.Visible = showDevVariables;
            //lblFromDate.Visible = showDevVariables;
            //lblToDate.Visible = showDevVariables;

        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionInformation.showVariables()");

            if ((lblSessType != null)) // WTF! I have to check the label I made even exists first before I use it!!!
            {
                lblSessType.Text = strSessType;
            }

            if (currStoreEmp != null)
            {
                if (lblStoreEmpID != null)
                {
                    //lblEmpID.Text = currEmp.EmployeeID.ToString();
                    lblStoreEmpID.Text = currStoreEmp.StoreEmployeeID.ToString();
                }

                if (lblRole != null)
                {
                    //lblDeptID.Text = currEmp.DepartmentID.ToString();
                    lblRole.Text = currStoreEmp.Role;
                }

                //showCurrDeptRep();
            }
        }

        private void getCollInfo()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionInformation.getCollInfo()");
            
            if (currStoreEmp != null)
            {
                List<Model.CollectionInformation> lstCollInfo;
                List<Model.gvCollEInfoEle> lstGvCollInfo;

                if (strSessType.Equals("StoreEmployee")) {
                    //lstNotification = notiControl.getFilteredNotificationList(currStoreEmp.StoreEmployeeID);

                    Control.CollectionInformationController ctrlCollInfo = new Control.CollectionInformationController();

                    lstCollInfo = ctrlCollInfo.getListCollectionInformation();
                }
                else
                {
                    // ERROR: Unknown Employee Type
                    lstCollInfo = null;

                    if (lblCollInfoTitle != null)
                        lblCollInfoTitle.Text = "ERROR: Unknown Employee Type = " + strSessType;
                }

                if (gvColllInfo != null)
                {
                    if (lstCollInfo != null)
                    {
                        if (lstCollInfo.Count == 0)
                        {
                            if (lblCollInfoTitle != null)
                                lblCollInfoTitle.Text = "No Collection Information Available";
                        }
                        else
                        {
                            lstGvCollInfo = combNameIDInList(lstCollInfo);

                            gvColllInfo.DataSource = lstGvCollInfo;
                            gvColllInfo.DataBind();
                        }
                    }
                }
            }
        }

        private List<Model.gvCollEInfoEle> combNameIDInList(List<Model.CollectionInformation> lstCollInfo)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionInformation.combNameIDInList(ref lstCollInfo.Count=" + lstCollInfo.Count + ")");
            //throw new NotImplementedException();

            String nameID;

            Model.gvCollEInfoEle aCollInfoEle;
            List<Model.gvCollEInfoEle> newLstGvCollInfo = new List<Model.gvCollEInfoEle>();

            Control.CollectionPointControl ctrlCollPt = new Control.CollectionPointControl();
            List<Model.CollectionPoint> lstCollPt = ctrlCollPt.getListCollectionPoint();

            if (lstCollInfo.Count > 0)
            {
                if (lstCollPt.Count > 0)
                {
                    foreach (Model.CollectionPoint aCollPt in lstCollPt)
                    {
                        foreach (Model.CollectionInformation aCollInfo in lstCollInfo)
                        {
                            if (aCollPt.CollectionPointName == aCollInfo.collectionPointName)
                            {
                                aCollInfoEle = new Model.gvCollEInfoEle();

                                aCollInfoEle.deptName = aCollInfo.deptName;
                                aCollInfoEle.collectionPointName = aCollInfo.collectionPointName;

                                //nameID = aCollInfo.Name + " (" + aCollInfo.EmployeeID + ")";

                                //aCollInfoEle.repNameID = nameID;

                                aCollInfoEle.repNameID = aCollInfo.Name;

                                newLstGvCollInfo.Add(aCollInfoEle);
                            }
                        }

                    }
                }
                else
                {
                    // cannot sort as can't get a valid CollectionPoint list

                    foreach (Model.CollectionInformation aCollInfo in lstCollInfo)
                    {
                        aCollInfoEle = new Model.gvCollEInfoEle();

                        aCollInfoEle.deptName = aCollInfo.deptName;
                        aCollInfoEle.collectionPointName = aCollInfo.collectionPointName;

                        nameID = aCollInfo.Name + " (" + aCollInfo.EmployeeID + ")";

                        aCollInfoEle.repNameID = nameID;

                        newLstGvCollInfo.Add(aCollInfoEle);
                    }
                }
            }

            return newLstGvCollInfo;
        }

        protected void gvColllInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvColllInfo.PageIndex = e.NewPageIndex;
            getSessionData();

            bool showDevVariables = false;
            toggleDevVariables(showDevVariables);

            showVariables(); // includes both dev and non-dev variables

            getCollInfo();
        }

    }
}