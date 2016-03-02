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

        private static String getCombEmpNameID(String empID, String empName)
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

                    rtnMsg = "Changes Successful";
                }
                catch (Exception)
                {
                    context.Dispose();

                    rtnMsg = "ERROR: Changes Unsuccessful with system error msg: ";
                    rtnMsg += "Cannot change the roles of both current and new representative at the same time.";
                }
            } 

            return rtnMsg;
        }

        //public static Department getDepartment(String deptID)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getDepartment( deptID=" + deptID + ")");

        //    var context = new LogicUniversityEntities();

        //    Department rtnDept = context.Departments.Where(x => x.DepartmentID == deptID).FirstOrDefault();

        //    return rtnDept;
        //}

        //public static CollectionPoint getCollectionPoint(int collPtID)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getCollectionPoint( collPtID=" + collPtID + ")");

        //    var context = new LogicUniversityEntities();

        //    CollectionPoint rtnCollPt = context.CollectionPoints.Where(x => x.CollectionPointID == collPtID).FirstOrDefault();

        //    return rtnCollPt;
        //}

        //public static int changeCollectionPointForDept(string deptID, int newCollPt)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.changeCollectionPointForDept( deptID=" + deptID + ", newCollPt=" + newCollPt + ")");

        //    int rtnInt;

        //    var context = new LogicUniversityEntities();

        //    Department currDept = context.Departments.Single(x => x.DepartmentID == deptID);

        //    currDept.CollectionPointID = newCollPt;

        //    rtnInt = context.SaveChanges();

        //    return rtnInt;
        //}

        //public static Model.Employee getDeptRep(string deptID)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getListCollectionPoint()");

        //    Model.Employee deptRep = null;

        //    var context = new LogicUniversityEntities();

        //    deptRep = context.Employees.Where(x => x.DepartmentID == deptID && x.Role == "Representative").FirstOrDefault();

        //    return deptRep;
        //}

    }
}