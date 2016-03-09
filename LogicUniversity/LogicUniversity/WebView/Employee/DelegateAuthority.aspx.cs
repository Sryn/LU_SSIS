using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class DelegateAuthority : System.Web.UI.Page
    {
        protected int intDelegateID
        {
            get { return Convert.ToInt32(ViewState["intDelegateID"]); }
            set { ViewState["intDelegateID"] = value; }
        }

        String strSessType = "";

        Model.Employee currEmp = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                getSessionData();

                fillTodaysDate();

                fillDropDownList();

                bool showDevVariables = false;
                toggleDevVariables(showDevVariables);

                showVariables(); // includes both dev and non-dev variables

                getDeptDelegates();

                checkRequestQueryString();
            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.Page_Load( 2 IsPostBack=" + IsCallback + ")");

                if (currEmp == null)
                {
                    getSessionData();                    
                }
            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.Page_Load( 3 IsPostBack=" + IsCallback + ")");

            // if this is here, when the editBtn is clicked, the values in the relevant boxes revert
            //  back to when the page is reloaded before it is sent off to the control for processing
            //checkRequestQueryString(); 
        }

        private void fillTodaysDate()
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.fillTodaysDate()");
            //throw new NotImplementedException();

            tbxTodaysDate.Text = DateTime.Today.Date.ToShortDateString();
        }

        private void checkRequestQueryString()
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.checkRequestQueryString()");
            //throw new NotImplementedException();

            int editDelegateID;
            Model.Delegate editDelegate;

            if (Request.QueryString["DelegateID"] != null)
            {
                if (int.TryParse(Request.QueryString["DelegateID"], out editDelegateID))
                {
                    editDelegate = Control.DelegateAuthorityControl.getDelegate(editDelegateID);

                    if (editDelegate != null)
                    {
                        intDelegateID = editDelegateID; // viewstate save for btnClick_EditDelegate

                        ddlDeptEmpList.SelectedIndex = getDDLIndex(editDelegate.EmployeeID);
                        tbxFromDate.Text = editDelegate.FromDate.ToShortDateString();
                        tbxToDate.Text = editDelegate.ToDate.ToShortDateString();

                        btnAddDelegate.Visible = false;

                        btnCancelEdit.Visible = true;
                        btnEditDelegate.Visible = true;
                    }
                } 
            }

            if (Request.QueryString["msg"] != null)
            {
                lblMessage.Text = Request.QueryString["msg"];
            }
        }

        private int getDDLIndex(string empID)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.getDDLIndex(empID=" + empID + ")");
            //throw new NotImplementedException();

            int index = 0;

            index = ddlDeptEmpList.Items.IndexOf(ddlDeptEmpList.Items.FindByValue(empID));

            return index;
        }

        public void btnClick_CancelEdit(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.btnClick_CancelEdit(sender=" + sender + ")");

            Server.Transfer("DelegateAuthority.aspx", false);
        }

        public void btnClick_EditDelegate(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.btnClick_EditDelegate(sender=" + sender + ")");

            bool boolResult;
            string msg, oldNewDelegatesChange;
            Model.Delegate oldDelegate;
            Model.Delegate newDelegate = new Model.Delegate();

            if (ViewState["intDelegateID"] != null)
            {
                oldDelegate = Control.DelegateAuthorityControl.getDelegate(intDelegateID);

                if (Control.DelegateAuthorityControl.parseDelegate(ddlDeptEmpList.SelectedValue, tbxFromDate.Text, tbxToDate.Text, ref newDelegate))
                {
                    oldNewDelegatesChange = Control.DelegateAuthorityControl.compareDelegates(oldDelegate, newDelegate);

                    if (!oldNewDelegatesChange.Equals("Same"))
                    {
                        // not the same so process the edit

                        //editDelegateEmpID = oldDelegate.EmployeeID;

                        boolResult = Control.DelegateAuthorityControl.editDelegate(intDelegateID, ddlDeptEmpList.SelectedValue, tbxFromDate.Text, tbxToDate.Text);

                        if (boolResult)
                        {
                            msg = "Change of Delegate details successful";
                            System.Diagnostics.Debug.WriteLine(">>> DelegateAuthority.btnClick_EditDelegate msg=" + msg);
                            System.Diagnostics.Debug.WriteLine(">>> oldNewDelegatesChange=" + oldNewDelegatesChange);
                            System.Diagnostics.Debug.WriteLine(">>> currEmp.EmployeeID=" + currEmp.EmployeeID);
                            Control.DelegateAuthorityControl.showDelegateDetails(newDelegate, "newDelegate");

                            if (oldNewDelegatesChange.Contains("EmployeeID"))
                            {
                                // there's a change in assigned delegates, so have to send both FutureCancel 
                                // (as you can't do an edit on an on-going assigned delegation) and New notices

                                msg += Control.DelegateAuthorityControl.delegateChangeNotifications(currEmp, oldDelegate, newDelegate);
                            }
                            else
                            {
                                // no change in assigned employee, so don't have to send any New nor cancel notices, just a Change details notice
                                msg += Control.DelegateAuthorityControl.delegateNotifications(currEmp, newDelegate, "Change");
                            }

                            Server.Transfer("DelegateAuthority.aspx?msg=" + msg, false);
                        } // if (boolResult)
                        else
                        {
                            msg = "ERROR: Change of Delegate details unsuccessful.  Edits reverted.";
                            System.Diagnostics.Debug.WriteLine(">>> DelegateAuthority.btnClick_EditDelegate msg=" + msg);
                            Server.Transfer("DelegateAuthority.aspx?DelegateID=" + intDelegateID + "&msg=" + msg, false);
                        }
                    } // if (!oldNewDelegatesChange.Equals("Same"))
                } // if (Control.DelegateAuthorityControl.parseDelegate(ddlDeptEmpList.SelectedValue, tbxFromDate.Text, tbxToDate.Text, ref newDelegate))
            } // if (ViewState["intDelegateID"] != null)
        } // public void btnClick_EditDelegate(Object sender, EventArgs e)

        private void getSessionData()
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.getData()");

            strSessType = Model.MySession.Current.type;

            if (strSessType.Equals("Employee"))
            {
                currEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.Employee;
            }
            else
                showPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");

        }

        private void showPopUp(String msg)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.showPopUp(msg)");

            // all three look the same
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('" + confirmMsg + "');", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ButtonClickScript", "alert('" + confirmMsg + "');", true);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + msg + "');", true);
        }

        private void toggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.toggleDevVariables(" + showDevVariables + ")");

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

            lblChosenEmp.Visible = showDevVariables;
            lblFromDate.Visible = showDevVariables;
            lblToDate.Visible = showDevVariables;

        }

        private void fillDropDownList()
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.fillDropDownList()");

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.

            Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
            ddlDeptEmpList.DataSource = crt.getListDeptEmpsForDDL(currEmp.DepartmentID);
            ddlDeptEmpList.DataTextField = "combEmpNameID";
            ddlDeptEmpList.DataValueField = "EmployeeID";
            
            // Bind the data to the control.
            ddlDeptEmpList.DataBind();

            // Set the default selected item, if desired.
            ddlDeptEmpList.SelectedIndex = 0; // set default to the current dept rep, who is at index 0;
        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.showVariables()");

            if ((lblSessType != null)) // WTF! I have to check the label I made even exists first before I use it!!!
            {
                lblSessType.Text = strSessType;
            }

            if (currEmp != null)
            {
                if (lblEmpID != null)
                    lblEmpID.Text = currEmp.EmployeeID.ToString();

                if (lblDeptID != null)
                    lblDeptID.Text = currEmp.DepartmentID.ToString();

                //showCurrDeptRep();
            }
        }

        protected void imgBtnCalFromDate_Click(object sender, ImageClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.imgBtnCalFromDate_Click( sender = " + sender.ToString()+" )");
            calFromDate.Visible = true;
        }

        protected void imgBtnCalToDate_Click(object sender, ImageClickEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.imgBtnCalToDate_Click( sender = " + sender.ToString() + " )");
            calToDate.Visible = true;
        }

        protected void calFromDate_SelectionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.calFromDate_SelectionChanged( sender = " + sender.ToString() + " )");
            tbxFromDate.Text = calFromDate.SelectedDate.ToShortDateString();
            calFromDate.Visible = false;
        }

        protected void calToDate_SelectionChanged(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.calToDate_SelectionChanged( sender = " + sender.ToString() + " )");
            tbxToDate.Text = calToDate.SelectedDate.ToShortDateString();
            calToDate.Visible = false;
        }

        public void btnClick_AddDelegate(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.btnClick_AddDelegate(ddlDeptEmpList.SelectedItem.Value=" + ddlDeptEmpList.SelectedItem.Value + ")");

            bool boolResult;

            string msg;

            lblChosenEmp.Text = ddlDeptEmpList.SelectedItem.Text;
            lblFromDate.Text = tbxFromDate.Text;
            lblToDate.Text = tbxToDate.Text;

            boolResult = Control.DelegateAuthorityControl.addDelegate(ddlDeptEmpList.SelectedValue, tbxFromDate.Text, tbxToDate.Text, DateTime.Now);

            if (boolResult)
            {
                Model.Delegate newDelegate = new Model.Delegate();

                msg = "Adding new Delegate successful";

                if (Control.DelegateAuthorityControl.parseDelegate(ddlDeptEmpList.SelectedValue, tbxFromDate.Text, tbxToDate.Text, ref newDelegate)) {
                    msg += Control.DelegateAuthorityControl.delegateNotifications(currEmp, newDelegate, "New");
                }
                else
                    msg += ". Error on sending notifications and emails.";

                Server.Transfer("DelegateAuthority.aspx?msg=" + msg, false);
            }
            else
            {
                msg = "ERROR: Adding new Delegate unsuccessful";
                //System.Diagnostics.Debug.WriteLine(">>> DelegateAuthority.btnClick_EditDelegate msg=" + msg);
                Server.Transfer("DelegateAuthority.aspx?msg=" + msg, false);
            }

        }

        private void getDeptDelegates()
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.getDeptDelegates()");

            DateTime currentDate = System.DateTime.Now.Date;

            if (currEmp != null)
            {
                //List<Model.FilNotiLstEle> lstNotification = new List<Model.FilNotiLstEle>();
                //List<Model.Delegate> lstDeptDelegates;
                List<Model.deptDelegateGVEle> lstDeptDelegateGVEle;

                if (strSessType.Equals("Employee"))
                {
                    //lstNotification = Control.NotiListControl.getFilteredNotificationList(currEmp.EmployeeID);
                    //lstDeptDelegates = Control.DelegateAuthorityControl.getDeptDelegatesList(currEmp.DepartmentID);
                    lstDeptDelegateGVEle = Control.DelegateAuthorityControl.getDeptDelegateGVEleList(currEmp.DepartmentID, currentDate);
                }
                else
                {
                    // ERROR: Unknown Employee Type
                    lstDeptDelegateGVEle = null;

                    if (lblDeptDelGVTitle != null)
                        lblDeptDelGVTitle.Text = "ERROR: Unknown or Illegal Employee Type Accessing this function ( " + strSessType + " )";
                }

                if (DeptDelegatesGridView != null)
                {
                    if (lstDeptDelegateGVEle != null)
                    {
                        if (lstDeptDelegateGVEle.Count == 0)
                        {
                            if (lblDeptDelGVTitle != null)
                                lblDeptDelGVTitle.Text = "No Assigned Delegates Found";
                        }
                        else
                        {
                            DeptDelegatesGridView.DataSource = lstDeptDelegateGVEle;
                            DeptDelegatesGridView.DataBind();
                            Cache["Data"] = lstDeptDelegateGVEle; // caching for paging
                        }
                    }
                }
            }
        }

        protected void newPageDeptDelegatesGridView(object sender, GridViewPageEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthority.newPageDeptDelegatesGridView([e.NewPageIndex=" + e.NewPageIndex + "])");

            // http://codedisplay.com/how-to-paging-gridview-in-asp-net-c-vb-net/

            DeptDelegatesGridView.PageIndex = e.NewPageIndex;
            //DeptDelegatesGridView.DataSource = Cache["Data"] as List<Model.FilNotiLstEle>;
            //DeptDelegatesGridView.DataSource = Cache["Data"] as List<Model.Delegate>;
            DeptDelegatesGridView.DataSource = Cache["Data"] as List<Model.deptDelegateGVEle>;
            DeptDelegatesGridView.DataBind();
        }

    }
}