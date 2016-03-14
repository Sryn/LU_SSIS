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
            //if(txtEmployeeID.Text.Equals("finance") && txtPIN.Text.Equals("123456"))
            //{
            //    Model.Employee emp = loginCrt.getEmployeeUserObject(txtEmployeeID.Text);
            //    if (emp == null)
            //        return;
            //    System.Diagnostics.Debug.WriteLine("===FinanceFound======");
            //    System.Diagnostics.Debug.WriteLine(emp.Role);
            //    Session["User"] = emp;
            //    Session["type"] = "Finance";
            //    Response.Redirect("~/WebView/Finance/FinanceHomePage.aspx");
            //}
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
                        Model.StoreEmployee semp = loginCrt.getStoreEmployeeUserObject(txtEmployeeID.Text);
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
                    case "FinanceEmployeeFound":
                        Model.Employee femp = loginCrt.getEmployeeUserObject(txtEmployeeID.Text);
                        if (femp == null)
                            return;
                        System.Diagnostics.Debug.WriteLine("===FinanceEmpFound======");
                        System.Diagnostics.Debug.WriteLine(femp.Role);
                        Session["User"] = femp;
                        Session["type"] = "Finance";
                        Response.Redirect("~/WebView/Finance/FinanceHomePage.aspx");
                        break;
                }
            }
            else if (txtEmployeeID.Text == "")
                txtMessage.Text = "Enter Employee ID";
            else if (txtEmployeeID.Text == "")
                txtMessage.Text = "Enter PIN Number";
        }

        protected void lkBtnForgotPassword_Click(object sender, EventArgs e)
        {
            string result = loginCrt.checkUserID(txtEmployeeID.Text);
            string resultToReturn="";
            txtMessage.Visible = false;
            lblMessage.Visible = true;
            if (result.Equals("Found"))
                resultToReturn = loginCrt.makeForgotPassword(txtEmployeeID.Text);
            else
                lblMessage.Text = "InputValid UserID";
            switch (resultToReturn)
            {
                case "success":
                    lblMessage.Text = "Successfully Send You Email";
                    break;
                case "error":
                    lblMessage.Text = "Error in send Email";
                    break;
                case "fail":
                    lblMessage.Text = "Fail";
                    break;
                case "notfound":
                    lblMessage.Text = "Not Found";
                    break;
            }
        }
        //success = successfully send email
        //error = error in send email
        //fail = fail
        //notfound = userID not found
    }
}