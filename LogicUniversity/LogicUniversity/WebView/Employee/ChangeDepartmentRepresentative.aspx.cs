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
        protected String strCurrDeptRepNameID
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
                Control.CollectionPointControl crt = new Control.CollectionPointControl();
                currDeptRep = crt.getDeptRep(currEmp.DepartmentID);
                strCurrDeptRepNameID = currDeptRep.Name + " (" + currDeptRep.EmployeeID + ")"; // for the label
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

            if (lblCurrDeptRep != null && strCurrDeptRepNameID != null)
                lblCurrDeptRep.Text = strCurrDeptRepNameID;
        }

        private void fillDropDownList()
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeCollectionPoint.fillDropDownList()");

            // Specify the data source and field names for the Text 
            // and Value properties of the items (ListItem objects) 
            // in the DropDownList control.

            Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
            ddlNewDeptRep.DataSource = crt.getListDeptEmpsForDDL(currEmp.DepartmentID);
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

            if (newDeptRepID != prevDeptRepID) // to ignore when its the same current dept rep
            {
                if (strCurrDeptRepNameID != null)
                {
                    //if (currDeptRep != null)
                    //confirmMsg = Control.ChangeRepresentativeControl.changeDeptRep(currDeptRep.EmployeeID, newDeptRepID);

                    // doing this method cos I hate going back to the dB for something which I can easily store but this way might use more processing
                    //confirmMsg = Control.ChangeRepresentativeControl.changeDeptRep(strCurrDeptRepNameID.Substring(strCurrDeptRepNameID.Length - 9, 8), newDeptRepID);
                    Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
                    confirmMsg = crt.changeDeptRep(prevDeptRepID, newDeptRepID);
                }
                else
                    confirmMsg = "ERROR: Changes Unsuccessful with system error msg: " + "currDeptRep not loaded after PostBack";

                if (!confirmMsg.Substring(0, 5).Equals("ERROR"))
                {
                    getCurrDeptRep();

                    showCurrDeptRep(); // update label to show new current dept rep

                    // NEED TO DO eMail Notifications here to prev rep, new rep, dept head and store clerks

                    if (currEmp != null && prevDeptRep != null) {
                        Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
                        emailRtnMsg = crt.sendChangeDeptRepNotifications(currEmp, prevDeptRep, currDeptRep);
                        confirmMsg += emailRtnMsg;
                    }
                    else
                        confirmMsg += " but ERROR sending notification emails.";

                    //if (emailRtnMsg.Substring(0, 5).Equals("ERROR"))
                    //{
                    //    confirmMsg += emailRtnMsg;
                    //}
                    //else
                    //{
                    //    // temp
                    //    confirmMsg += emailRtnMsg;
                    //}

                    saveCurrDeprRep(); // do this in case the user immediately changes dept rep again
                }

                showPopUp(confirmMsg);
            }

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