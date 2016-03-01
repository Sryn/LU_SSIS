﻿using System;
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
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
            //throw new NotImplementedException();
            if (currentEmployee != null)
            {
                //List<Model.Notification> lstNotification = new List<Model.Notification>();
                //lstNotification = Control.NotificationControl.getNotificationList(currentEmployee.EmployeeID);

                List<Util.FilNotiLstEle> lstNotification = new List<Util.FilNotiLstEle>();
                lstNotification = Control.NotiListControl.getFilteredNotificationList(currentEmployee.EmployeeID);

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
                        }
                    }
                }
            }
        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.showVariables()");

            if ((lblSessType != null) && (Session["type"] != null)) // WTF! I have to check the label I made even exists first before I use it!!!
            {
                lblSessType.Text = Session["type"] as string;
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

            string strSessType = "";

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
        }

        protected void newPageNotificationGridView(object sender, GridViewPageEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.newPageNotificationGridView([e.NewPageIndex=" + e.NewPageIndex + "])");

            NotificationGridView.PageIndex = e.NewPageIndex;
            NotificationGridView.DataBind();
        }
    }
}