using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class CancelDelegate : System.Web.UI.Page
    {
        int delegateID;

        DateTime currentDate = System.DateTime.Now.Date;

        Boolean boolEdit, boolCancel;

        String returnMsg, strSessType = "";

        Model.Employee currEmp = null;
        Model.Delegate aDelegate;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> CancelDelegate.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                getSessionData();

                if (Request.QueryString["DelegateID"] != null)
                {
                    lblDelegateID.Text = Request.QueryString["DelegateID"];

                    if (int.TryParse(Request.QueryString["DelegateID"], out delegateID))
                    {
                        aDelegate = Control.DelegateAuthorityControl.getDelegate(delegateID);

                        if (aDelegate != null)
                        {
                            lblEmployeeID.Text = aDelegate.EmployeeID;
                            lblFromDate.Text = aDelegate.FromDate.ToString("dd-MMM-yyyy");
                            lblToDate.Text = aDelegate.ToDate.ToString("dd-MMM-yyyy");

                            updateBooleans();

                            processDelegate();

                            Server.Transfer("DelegateAuthority.aspx?msg=" + returnMsg, false);
                        }
                    }

                }
            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> CancelDelegate.Page_Load( 2 IsPostBack=" + IsCallback + ")");

            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> CancelDelegate.Page_Load( 3 IsPostBack=" + IsCallback + ")");
        }

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

        private void processDelegate()
        {
            System.Diagnostics.Debug.WriteLine(">> CancelDelegate.processDelegate()");
            //throw new NotImplementedException();

            if (boolCancel && boolEdit)
            {
                // can delete
                lblResult.Text = "Can Delete";

                if (Control.DelegateAuthorityControl.deleteFutureDelegateRow(delegateID)) {
                    returnMsg = "Deletion of Delegate successful"; // success
                    returnMsg += Control.DelegateAuthorityControl.delegateNotifications(currEmp, aDelegate, "FutureCancel");
                }
                else
                    returnMsg = "ERROR: Delegate cannot be deleted"; // failure
            }
            else if (!boolEdit)
            {
                // set Active to Disable
                lblResult.Text = "set Active to Disable";

                if(Control.DelegateAuthorityControl.setDelegateActiveToDisable(delegateID)) {
                    returnMsg = "Cancellation of Delegate successful"; // success
                    returnMsg += Control.DelegateAuthorityControl.delegateNotifications(currEmp, aDelegate, "CurrentCancel");
                }
                else
                    returnMsg = "ERROR: Delegate cannot be cancelled"; // failure
            }
            else
            {
                // ERROR
                lblResult.Text = "ERROR";
            }
        }

        private void updateBooleans()
        {
            System.Diagnostics.Debug.WriteLine(">> CancelDelegate.updateBooleans()");
            //throw new NotImplementedException();

            if (aDelegate != null)
            {
                boolEdit = (aDelegate.FromDate > currentDate && aDelegate.ToDate > currentDate);
                boolCancel = (aDelegate.ToDate >= currentDate);

                lblEditBoolean.Text = boolEdit.ToString();
                lblCancelBoolean.Text = boolCancel.ToString();
            }
        }
    }
}