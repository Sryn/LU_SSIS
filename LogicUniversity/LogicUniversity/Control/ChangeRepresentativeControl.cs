using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class ChangeRepresentativeControl
    {
        LogicUniversityEntities ctx;
        public ChangeRepresentativeControl()
        {
            ctx = new LogicUniversityEntities();
        }

        public static List<Employee> getListDeptEmployees(string deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeRepresentativeControl.getListDeptEmployees(deptID=" + deptID + ")");

            var context = new LogicUniversityEntities();

            List<Employee> rtnDeptEmpsList = context.Employees.Where(x => x.DepartmentID == deptID).ToList();

            return rtnDeptEmpsList;
        }

        public static List<Model.deptEmpDDL_Ele> getListDeptEmpsForDDL(string deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeRepresentativeControl.getListDeptEmpsForDDL(deptID=" + deptID + ")");

            // returns a 2-column EmployeeID, combEmpNameID(Name (EmployeeID)) as a list, excluding the dept head

            String anEmployeeID, anEmployeeName, combEmpNameID;

            Model.deptEmpDDL_Ele aDeptEmpDDL_Ele;

            List<Employee> newListDeptEmployees = getListDeptEmployees(deptID);

            List<Model.deptEmpDDL_Ele> newListDeptEmpsForDDL = new List<Model.deptEmpDDL_Ele>();

            foreach (Employee anEmployee in newListDeptEmployees)
            {
                if (!anEmployee.Role.Equals("Department Head")) // don't add the dept head to the list
                {
                    aDeptEmpDDL_Ele = new Model.deptEmpDDL_Ele();

                    anEmployeeID = anEmployee.EmployeeID;
                    anEmployeeName = anEmployee.Name;

                    combEmpNameID = getCombEmpNameID(anEmployeeID, anEmployeeName);

                    aDeptEmpDDL_Ele.EmployeeID = anEmployeeID;
                    aDeptEmpDDL_Ele.combEmpNameID = combEmpNameID;

                    if (anEmployee.Role.Equals("Representative"))
                        newListDeptEmpsForDDL.Insert(0, aDeptEmpDDL_Ele); // adds the current rep to the start of the list
                    else
                        newListDeptEmpsForDDL.Add(aDeptEmpDDL_Ele);
                }
            }

            return newListDeptEmpsForDDL;
        }

        public static String getCombEmpNameID(String empID, String empName)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeRepresentativeControl.getCombEmpNameID(empID=" + empID + ", empName=" + empName + ")");

            String combEmpNameID;

            combEmpNameID = empName + " (" + empID + ")";

            return combEmpNameID;
        }

        public static string changeDeptRep(string currDeptRepID, string newDeptRepID)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeRepresentativeControl.changeDeptRep(currDeptRepID=" + currDeptRepID + ", newDeptRepID=" + newDeptRepID + ")");
            //throw new NotImplementedException();

            //newDeptRepID = "12345678"; // error test

            string rtnMsg = "";

            Model.Employee currDeptRep, newDeptRep;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    currDeptRep = context.Employees.Where(x => x.EmployeeID == currDeptRepID).FirstOrDefault();

                    newDeptRep = context.Employees.Where(x => x.EmployeeID == newDeptRepID).FirstOrDefault();

                    currDeptRep.Role = "Employee";

                    newDeptRep.Role = "Representative";

                    context.SaveChanges();

                    rtnMsg = "Changes Successful ";
                }
                catch (Exception)
                {
                    context.Dispose();

                    rtnMsg = "ERROR: Changes Unsuccessful with system error msg: ";
                    rtnMsg += "Cannot successfully change the roles of both current and new representative at the same time.";
                }
            } 

            return rtnMsg;
        }

        /*
            To: Store Clerk, Store Supervisor, Store Manager
            Cc: Department Representative (Old), Department Representative (New), Department Head 
            Title: XX Department changed its Department Representative to XX

            Please be informed that XX Department has changed their Department Representative to XX (New Department Representative)

            This is a system generated email, please do not reply.
          
            Notification: XX Department has changed its Department Representative to XX.
         */
        public static string sendChangeDeptRepNotifications(Employee currEmp, Employee prevDeptRep, Employee newDeptRep)
        {
            System.Diagnostics.Debug.WriteLine(">> ChangeRepresentativeControl.sendChangeDeptRepNotifications( currEmp, prevDeptRep, newDeptRep)");

            string rtnMsg, emailSubject = "", emailBody = "", notiMsg = "", currDeptName, newDeptRepNameEmpID;

            List<Model.empIdEmail> empIdEmailToList = new List<Model.empIdEmail>(), empIdEmailCCList = new List<Model.empIdEmail>();

            empIdEmail prevDeptRepIdEmail;

            if (currEmp != null)
            {
                currDeptName = Control.CollectionPointControl.getDepartment(currEmp.DepartmentID).DepartmentName;

                newDeptRepNameEmpID = getCombEmpNameID(newDeptRep.EmployeeID, newDeptRep.Name);

                notiMsg = Control.CollectionPointControl.getValidNotificationMsg(currDeptName, newDeptRepNameEmpID, " Department has changed its ", "Department Representative");

                emailSubject = currDeptName + " Department changed its Department Representative to " + newDeptRepNameEmpID;

                emailBody = Control.CollectionPointControl.getEmailBody(currEmp, currDeptName, newDeptRepNameEmpID, "Department Representative");

                empIdEmailToList = Control.CollectionPointControl.getAllStoreEmployeesIdEmailToList();

                empIdEmailCCList = Control.CollectionPointControl.getDeptHeadRepIdEmailList(currEmp.DepartmentID);

                if (prevDeptRep != null)
                {
                    prevDeptRepIdEmail = Model.Utilities.getEmpIdEmail(prevDeptRep);
                    empIdEmailCCList.Add(prevDeptRepIdEmail);
                }

                // don't do this as it sends to the entire CC list for every TO email sent
                // but I'm doing this temporarily until emailCtrl.SendEmail works with an email list for TO
                foreach (Model.empIdEmail empIdEmail in empIdEmailCCList)
                    empIdEmailToList.Add(empIdEmail);

                rtnMsg = Control.CollectionPointControl.sendNotiAndEmails(currEmp, emailSubject, emailBody, notiMsg, empIdEmailToList);

            }
            else
            {
                // ERROR: no valid current login employee obtained
                rtnMsg = "ERROR: No valid current login employee information obtained.";
            }

            return rtnMsg;
        }

    }
}