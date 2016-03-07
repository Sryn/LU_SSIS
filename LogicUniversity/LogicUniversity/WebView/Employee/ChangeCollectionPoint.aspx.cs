using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class ChangeCollectionPoint : System.Web.UI.Page
    {
        String strSessType = ""
            , strCollPtName = "";

        Model.Employee currEmp = null;
        Model.Department currDept = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                getData();

                fillDropDownList();

                bool showDevVariables = false;
                toggleDevVariables(showDevVariables);
                showVariables();

            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.Page_Load( 2 IsPostBack=" + IsCallback + ")");

                if (Model.MySession.Current.type.Equals("Employee"))
                {
                    currEmp = Model.MySession.Current.User as Model.Employee;
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    currDept = crt.getDepartment(currEmp.DepartmentID);
                } else
                    lblChangeResult.Text = "ERROR: Unknown or Illegal Employee Type Accessing this function.";
            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.Page_Load( 3 IsPostBack=" + IsCallback + ")");

        }

        private void fillDropDownList()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.fillDropDownList()");

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.
            Control.CollectionPointControl crt = new Control.CollectionPointControl();
            ddlNewCollPt.DataSource = crt.getListCollectionPoint();
            ddlNewCollPt.DataTextField = "CollectionPointName";
            ddlNewCollPt.DataValueField = "CollectionPointID";

            // Bind the data to the control.
            ddlNewCollPt.DataBind();

            // Set the default selected item, if desired.
            if(currDept != null)
                ddlNewCollPt.SelectedIndex = Convert.ToInt32(currDept.CollectionPointID) - 1000000; // set default to current collection point
        }

        private void getData()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.getData()");

            strSessType = Model.MySession.Current.type;

            if (strSessType.Equals("Employee")) {
                currEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.Employee;
                Control.CollectionPointControl crt = new Control.CollectionPointControl();
                currDept = crt.getDepartment(currEmp.DepartmentID);

                strCollPtName = Model.Utilities.getCollPtName(Convert.ToInt32(currDept.CollectionPointID));
            }
            else
                lblChangeResult.Text = "ERROR: Unknown or Illegal Employee Type Accessing this function.";

        }

        private void toggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.toggleDevVariables(" + showDevVariables + ")");

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

            if (lblNewCollPt != null)
                lblNewCollPt.Visible = showDevVariables;

        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.showVariables()");

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

                if (lblDeptRep != null)
                {
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    lblDeptRep.Text = crt.getDeptRep(currEmp.DepartmentID).Name;
                }

                if (lblDeptName != null)
                    lblDeptName.Text = currDept.DepartmentName;

                if (lblCurrCollPt != null)
                    lblCurrCollPt.Text = strCollPtName;
            }
        }

        public void btnClick_ChangeCollPt(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.btnClick_ChangeCollPt( "
                +"ddlNewCollPt.SelectedItem.Value=" + ddlNewCollPt.SelectedItem.Value 
                + ", .Text="+ddlNewCollPt.SelectedItem.Text+" )");

            int rtnInt = 0, newCollPtID = Convert.ToInt32(ddlNewCollPt.SelectedItem.Value);

            string newCollPtName = ddlNewCollPt.SelectedItem.Text;

            if (newCollPtID != currDept.CollectionPointID) // stop doing anything if its the same collection point
            {
                if (lblNewCollPt != null)
                {
                    //lblNewCollPt.Text = selectedCollPt.ToString();
                    //lblNewCollPt.Text = ddlNewCollPt.SelectedItem.Value;
<<<<<<< HEAD
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    rtnInt = crt.changeCollectionPointForDept(currEmp.DepartmentID, newCollPtID);
=======
<<<<<<< HEAD
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    rtnInt = crt.changeCollectionPointForDept(currEmp.DepartmentID, newCollPtID);
=======
                    rtnInt = Control.CollectionPointControl.changeCollectionPointForDept(currEmp.DepartmentID, newCollPtID);
>>>>>>> master
>>>>>>> origin/master
                    lblNewCollPt.Text = rtnInt.ToString();
                }

                if (lblChangeResult != null)
                {
                    if (rtnInt == 1)
                    {
                        //lblChangeResult.Text = currDept.DepartmentName + " new Collection Point at " + Model.Utilities.getCollPtName(newCollPtID) + " saved successfully.";
                        lblChangeResult.Text = currDept.DepartmentName + " new Collection Point at " + newCollPtName + " saved successfully";

                        //if (lblCurrCollPt != null)
                        lblCurrCollPt.Text = newCollPtName;
                    }
                    else if (rtnInt == 0)
                        lblChangeResult.Text = "ERROR: New Collection Point Not Saved.";
                    else if (rtnInt > 1)
                        lblChangeResult.Text = "ERROR: Multiple Collection Points were saved.";
                    else
                        lblChangeResult.Text = "ERROR: Some unknown error occured with rtnInt=" + rtnInt;
                }

                if (rtnInt == 1)
                {
                    // code for do notification
<<<<<<< HEAD
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    lblChangeResult.Text += crt.sendChangeCollectionPointNotifications(currEmp, currDept, newCollPtName);
=======
<<<<<<< HEAD
                    Control.CollectionPointControl crt = new Control.CollectionPointControl();
                    lblChangeResult.Text += crt.sendChangeCollectionPointNotifications(currEmp, currDept, newCollPtName);
=======
                    lblChangeResult.Text += Control.CollectionPointControl.sendChangeCollectionPointNotifications(currEmp, currDept, newCollPtName);
>>>>>>> master
>>>>>>> origin/master
                }
            }
        }

    }
}