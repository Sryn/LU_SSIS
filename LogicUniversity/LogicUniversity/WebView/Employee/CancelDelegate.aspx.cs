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

        Model.Delegate aDelegate;

        DateTime currentDate = System.DateTime.Now.Date;

        Boolean boolEdit, boolCancel;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> CancelDelegate.Page_Load( 1 IsPostBack=" + IsCallback + ")");

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

                            Server.Transfer("DelegateAuthority.aspx", true);
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

        private void processDelegate()
        {
            System.Diagnostics.Debug.WriteLine(">> CancelDelegate.processDelegate()");
            //throw new NotImplementedException();

            if (boolCancel && boolEdit)
            {
                // can delete
                lblResult.Text = "Can Delete";

                lblResult.Text = Control.DelegateAuthorityControl.deleteFutureDelegateRow(delegateID).ToString();
            }
            else if (!boolEdit)
            {
                // set Active to Disable
                lblResult.Text = "set Active to Disable";

                lblResult.Text = Control.DelegateAuthorityControl.setDelegateActiveToDisable(delegateID).ToString();
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