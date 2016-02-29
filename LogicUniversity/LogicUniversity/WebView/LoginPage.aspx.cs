using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView
{
    public partial class LoginPage : System.Web.UI.Page
    {
        Control.LoginControl loginCrt;
        protected void Page_Load(object sender, EventArgs e)
        {
            loginCrt = new Control.LoginControl();
            if (!IsPostBack)
            {
                Session.Clear();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("in btnLogin CLick");
            string usertype = "";
            if (txtEmployeeID.Text != "" && txtPIN.Text != "")
            { 
                usertype = loginCrt.Login(txtEmployeeID.Text, txtPIN.Text);
                switch (usertype)
                {
                    case "": break;
                    case "NotFound":
                        txtMessage.Text = "Not Found";
                        break;
                    case "StoreFound":
                        Model.StoreEmployee semp= loginCrt.getStoreEmployeeUserObject(txtEmployeeID.Text);
                        if (semp == null)
                            return;
                        Session["type"] = "StoreEmployee";
                        Session["User"] = semp;
                        Response.Redirect("~/WebView/StoreEmployee/StoreEmployeeHome.aspx");
                        break;
                    case "EmployeeFound":
                        Model.Employee emp = loginCrt.getEmployeeUserObject(txtEmployeeID.Text);
                        if (emp == null)
                            return;
                        System.Diagnostics.Debug.WriteLine("===EmployeeFound======");
                        System.Diagnostics.Debug.WriteLine(emp.Role);
                        Session["type"] = "Employee";
                        Session["User"] = emp;
                        Response.Redirect("~/WebView/Employee/EmployeeHome.aspx");
                        break;
                    case "Delegate":
                        Model.Employee delEmp = loginCrt.getEmployeeUserObject(txtEmployeeID.Text);
                        if (delEmp == null)
                            return;
                        System.Diagnostics.Debug.WriteLine("====Delegate=====");
                        System.Diagnostics.Debug.WriteLine(delEmp.Role);
                        Session["type"] = "Employee";
                        delEmp.Role = "Delegate";
                        Session["User"] = delEmp;
                        Response.Redirect("~/WebView/Employee/EmployeeHome.aspx");
                        break;
                }
            }
            else if(txtEmployeeID.Text == "")
                txtMessage.Text = "Enter Employee ID";
            else if(txtEmployeeID.Text == "")
                txtMessage.Text = "Enter PIN Number";
        }
    }
}