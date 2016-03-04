using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class ChangeDepartmentRepresentative : System.Web.UI.Page
    {
        protected String strCurrDeptRep
        {
            get { return ViewState["strCurrDeptRep"] as String; }
            set { ViewState["strCurrDeptRep"] = value; }
        }

        protected String prevDeptRepID
        {
            get { return ViewState["prevDeptRepID"] as String; }
            set { ViewState["prevDeptRepID"] = value; }
        }

        String strSessType = "";

        Model.Employee currEmp = null;
        Model.Employee currDeptRep = null;
        Model.Employee prevDeptRep = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // not postback, i.e. first and only call when page loads
                System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.Page_Load( 1 IsPostBack=" + IsCallback + ")");

                getSessionData();

                getCurrDeptRep();

                saveCurrDeprRep(); // for use during email notification

                fillDropDownList();

                bool showDevVariables = false;
                toggleDevVariables(showDevVariables);

                showVariables(); // includes both dev and non-dev variables
            }
            else
            {
                // is postback, i.e. loads everytime the page subsequently reloads
                System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.Page_Load( 2 IsPostBack=" + IsCallback + ")");

                if (Model.MySession.Current.type.Equals("Employee"))
                {
                    currEmp = Model.MySession.Current.User as Model.Employee; // somehow, I can't save this to a ViewState without a runtime error
                    prevDeptRep = getPrevDeptRep(prevDeptRepID);
                }
                else
                    showPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");
            }

            // runs everytime the page loads
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.Page_Load( 3 IsPostBack=" + IsCallback + ")");

        }

        private Model.Employee getPrevDeptRep(string prevDeptRepID)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.getPrevDeptRep(prevDeptRepID=" + prevDeptRepID + ")");
            //throw new NotImplementedException();

            var aLoginCtrl = new LogicUniversity.Control.LoginControl();

            Model.Employee prevDeptRep = aLoginCtrl.getEmployeeUserObject(prevDeptRepID);

            return prevDeptRep;
        }

        private void saveCurrDeprRep()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.saveCurrDeprRep()");
            //throw new NotImplementedException();

            if (currDeptRep != null)
            {
                prevDeptRepID = currDeptRep.EmployeeID;
            }

        }

        private void getCurrDeptRep()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.getCurrDeptRep()");

            if (currEmp != null)
            {
                currDeptRep = Control.CollectionPointControl.getDeptRep(currEmp.DepartmentID);
                strCurrDeptRep = currDeptRep.Name + " (" + currDeptRep.EmployeeID + ")"; // for the label
            }
        }

        private void getSessionData()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.getData()");

            strSessType = Model.MySession.Current.type;

            if (strSessType.Equals("Employee"))
            {
                currEmp = Model.Utilities.getCurrLoginEmp2(strSessType) as Model.Employee;
            }
            else
                showPopUp("ERROR: Unknown or Illegal Employee Type Accessing this function.");

        }

        private void toggleDevVariables(bool showDevVariables)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.toggleDevVariables(" + showDevVariables + ")");

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
        }

        private void showVariables()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.showVariables()");

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

                showCurrDeptRep();
            }
        }

        private void showCurrDeptRep()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.showCurrDeptRep()");

            if (lblCurrDeptRep != null && strCurrDeptRep != null)
                lblCurrDeptRep.Text = strCurrDeptRep;
        }

        private void fillDropDownList()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.fillDropDownList()");

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.

            ddlNewDeptRep.DataSource = Control.ChangeRepresentativeControl.getListDeptEmpsForDDL(currEmp.DepartmentID);
            ddlNewDeptRep.DataTextField = "combEmpNameID";
            ddlNewDeptRep.DataValueField = "EmployeeID";

            // Bind the data to the control.
            ddlNewDeptRep.DataBind();

            // Set the default selected item, if desired.
            ddlNewDeptRep.SelectedIndex = 0; // set default to the current dept rep, who is at index 0;
        }

        public void btnClick_ChangeDeptRep(Object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.btnClick_ChangeDeptRep(ddlNewDeptRep.SelectedItem.Value=" + ddlNewDeptRep.SelectedItem.Value + ")");

            String newDeptRepID = ddlNewDeptRep.SelectedItem.Value, confirmMsg = "", emailRtnMsg = "";

            //if (currDeptRep != null)
                //confirmMsg = Control.ChangeRepresentativeControl.changeDeptRep(currDeptRep.EmployeeID, newDeptRepID);

            if(strCurrDeptRep != null) // doing this method cos I hate going back to the dB for something which I can easily store but this way might use more processing
                confirmMsg = Control.ChangeRepresentativeControl.changeDeptRep(strCurrDeptRep.Substring(strCurrDeptRep.Length - 9, 8), newDeptRepID);
            else
                confirmMsg = "ERROR: Changes Unsuccessful with system error msg: " + "currDeptRep not loaded after PostBack";

            if(!confirmMsg.Substring(0, 5).Equals("ERROR"))
            {
                getCurrDeptRep();

                showCurrDeptRep(); // update label to show new current dept rep

                // NEED TO DO eMail Notifications here to prev rep, new rep, dept head and store clerks

                if (currEmp != null && prevDeptRep != null)
                    emailRtnMsg = Control.ChangeRepresentativeControl.sendChangeDeptRepNotifications(currEmp, prevDeptRep, currDeptRep);
                else
                    confirmMsg += " but ERROR sending notification emails.";

                if (emailRtnMsg.Substring(0, 5).Equals("ERROR"))
                {
                    confirmMsg += emailRtnMsg;
                }
                else
                {
                    // temp
                    confirmMsg += emailRtnMsg;
                    confirmMsg += "";
                }
            }

            showPopUp(confirmMsg);

        }

        private void showPopUp(String msg)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeDepartmentRepresentative.showPopUp()");

            // all three looks the same
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "PopupScript", "alert('" + confirmMsg + "');", true);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "ButtonClickScript", "alert('" + confirmMsg + "');", true);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "ErrorAlert", "alert('" + msg + "');", true);
        }
    }
}