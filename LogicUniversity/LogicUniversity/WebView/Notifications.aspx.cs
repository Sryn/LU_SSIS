using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView
{
    public partial class Notification : System.Web.UI.Page
    {
        Model.Employee currentEmployee = null;
        Model.StoreEmployee currentStoreEmployee = null;

        String strSessType = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not call back, i.e. first and only call when page loads
                getCurrentEmployee();

                bool showDevVariables = false;
                toggleDevVariables(showDevVariables);
                if(showDevVariables)
                    showVariables();

                getRelevantNotifications();
            }
            else
            {
                // is call back, i.e. loads everytime the page reloads
            }
        }

        private void toggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.toggleDevVariables(" + showDevVariables + ")");
            //throw new NotImplementedException();

            if(lblTxtDeptID != null)
                lblTxtDeptID.Visible = showDevVariables;

            if(lblTxtEmpID != null)
                lblTxtEmpID.Visible = showDevVariables;

            if(lblTxtSessType != null)
                lblTxtSessType.Visible = showDevVariables;

            if(lblDeptID != null)
                lblDeptID.Visible = showDevVariables;

            if(lblEmpID != null)
                lblEmpID.Visible = showDevVariables;

            if(lblSessType != null)
                lblSessType.Visible = showDevVariables;
        }

        private void getRelevantNotifications()
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.getRelevantNotifications()");

            if (currentEmployee != null || currentStoreEmployee != null)
            {
                List<Model.FilNotiLstEle> lstNotification = new List<Model.FilNotiLstEle>();

                if(strSessType.Equals("Employee"))
                    lstNotification = Control.NotiListControl.getFilteredNotificationList(currentEmployee.EmployeeID);
                else if(strSessType.Equals("StoreEmployee"))
                    lstNotification = Control.NotiListControl.getFilteredNotificationList(currentStoreEmployee.StoreEmployeeID);
                else
                {
                    // ERROR: Unknown Employee Type
                    lstNotification = null;

                    if (lblNotiTitle != null)
                        lblNotiTitle.Text = "ERROR: Unknown Employee Type = " + strSessType;
                }

                if (NotificationGridView != null)
                {
                    if (lstNotification != null)
                    {
                        if (lstNotification.Count == 0)
                        {
                            if(lblNotiTitle != null)
                                lblNotiTitle.Text = "No Notifications";
                        }
                        else
                        {
                            NotificationGridView.DataSource = lstNotification;
                            NotificationGridView.DataBind();
                            Cache["Data"] = lstNotification; // caching for paging
                        }
                    }
                }
            }
        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.showVariables()");

            if ((lblSessType != null)) // WTF! I have to check the label I made even exists first before I use it!!!
            {
                lblSessType.Text = strSessType;
            }

            if (currentEmployee != null)
            {
                if (lblDeptID != null)
                    lblDeptID.Text = currentEmployee.DepartmentID.ToString();

                if (lblEmpID != null)
                    lblEmpID.Text = currentEmployee.EmployeeID.ToString();
            }
        }

        private void getCurrentEmployee()
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.getCurrentEmployee()");

            //string strSessType = "";

            if (Session["type"] != null)
            {
                strSessType = Session["type"] as string;
            }

            if (strSessType.Equals("Employee"))
            {
                if (Session["User"] != null)
                {
                    currentEmployee = Session["User"] as Model.Employee;
                }
            }
            else if (strSessType.Equals("StoreEmployee"))
            {
                if (Session["User"] != null)
                {
                    currentStoreEmployee = Session["User"] as Model.StoreEmployee;
                }
            }
            else
            {
                // ERROR: Unknown Employee Type
            }
        }

        protected void newPageNotificationGridView(object sender, GridViewPageEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.newPageNotificationGridView([e.NewPageIndex=" + e.NewPageIndex + "])");

            // http://codedisplay.com/how-to-paging-gridview-in-asp-net-c-vb-net/

            NotificationGridView.PageIndex = e.NewPageIndex;
            NotificationGridView.DataSource = Cache["Data"] as List<Model.FilNotiLstEle>;
            NotificationGridView.DataBind();
        }
    }
}