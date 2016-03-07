using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class DelegateAuthorityControl
    {
        LogicUniversityEntities ctx;
        public DelegateAuthorityControl()
        {
            ctx = new LogicUniversityEntities();
        }

        public static Model.Delegate getDelegate(int delegateID)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getDelegate( delegateID=" + delegateID + ")");

            Model.Delegate aDelegate = null;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    aDelegate = context.Delegates.Where(x => x.DelegateID == delegateID).FirstOrDefault();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ getDelegate: Exception Caught e=" + e);
                }
            }

            return aDelegate;
        }

        public static List<Model.Delegate> getDeptDelegatesList(string deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getDeptDelegatesList( deptID=" + deptID + ")");

            // returns unfiltered 4-columns Model.Delegate as a list

            Employee anEmp;
            List<Model.Delegate> allDeptDelegatesList = null;
            List<Model.Delegate> newDeptDelegatesList = new List<Model.Delegate>();

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    allDeptDelegatesList = context.Delegates.OrderByDescending(x => x.FromDate).ThenByDescending(x => x.ToDate).ToList();

                    if (allDeptDelegatesList.Count != 0)
                    {
                        foreach (Model.Delegate aDelegate in allDeptDelegatesList)
                        {
                            anEmp = getEmpFromDelEmpID(aDelegate);

                            if (anEmp != null && anEmp.DepartmentID == deptID)
                            {
                                newDeptDelegatesList.Add(aDelegate);
                            }

                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(">>> No History of any delegates from any dept assigned");
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ getDeptDelegatesList: Exception Caught e=" + e);
                }
            }


            return newDeptDelegatesList;
        }

        private static Employee getEmpFromDelEmpID(Model.Delegate aDelegate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getEmpFromDelEmpID( aDelegate.EmployeeID = " + aDelegate.EmployeeID + ")");
            //throw new NotImplementedException();

            Employee anEmp = null;

            var loginCtrl = new LoginControl();

            try
            {
                anEmp = loginCtrl.getEmployeeUserObject(aDelegate.EmployeeID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(">>> ERROR @ getEmpFromDelEmpID: Exception Caught e=" + e);
            }

            return anEmp;
        }

        public static List<Model.deptDelegateGVEle> getDeptDelegateGVEleList(string deptID, DateTime compDate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getDeptDelegateGVEleList( deptID=" + deptID + ")");

            Model.deptDelegateGVEle aDeptDelegateGVEle;

            List<Model.deptDelegateGVEle> newDeptDelegateGVEleList = null;

            List<Model.Delegate> newDeptDelegatesList = getDeptDelegatesList(deptID);

            if (newDeptDelegatesList.Count != 0)
            {
                // do something
                newDeptDelegateGVEleList = new List<deptDelegateGVEle>();

                foreach (Model.Delegate aDelegate in newDeptDelegatesList)
                {
                    if (aDelegate.Active.Equals("Enable"))
                    {
                        aDeptDelegateGVEle = new deptDelegateGVEle();

                        aDeptDelegateGVEle.DelegateID = aDelegate.DelegateID;
                        aDeptDelegateGVEle.empNameID = Model.Utilities.getCombEmpNameID(aDelegate.EmployeeID);
                        aDeptDelegateGVEle.fromDate = aDelegate.FromDate.ToShortDateString();
                        aDeptDelegateGVEle.toDate = aDelegate.ToDate.ToShortDateString();
                        aDeptDelegateGVEle.Active = aDelegate.Active;
                        aDeptDelegateGVEle.edit = getEditString(aDelegate, compDate);
                        aDeptDelegateGVEle.cancel = getCancelString(aDelegate, compDate);

                        newDeptDelegateGVEleList.Add(aDeptDelegateGVEle);
                    }
                }

            }
            else
            {
                System.Diagnostics.Debug.WriteLine(">>> No History of any delegates for deptID=" + deptID);
            }

            return newDeptDelegateGVEleList;
        }

        private static string getCancelString(Model.Delegate aDelegate, DateTime compDate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getCancelString( aDelegate.EmployeeID=" + aDelegate.EmployeeID + ", compDate="+compDate.ToString()+")");
            //throw new NotImplementedException();

            string cancelString = "";

            if (aDelegate.ToDate >= compDate)
            {
                cancelString = "Cancel";
            }

            return cancelString;
        }

        private static string getEditString(Model.Delegate aDelegate, DateTime compDate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getEditString( aDelegate.EmployeeID=" + aDelegate.EmployeeID + ", compDate=" + compDate.ToString() + ")");
            //throw new NotImplementedException();

            string editString = "";

            if (aDelegate.FromDate > compDate && aDelegate.ToDate > compDate)
            {
                editString = "Edit";
            }

            return editString;
        }

        public static Boolean setDelegateActiveToDisable(int delegateID)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.setDelegateActiveToDisable( delegateID=" + delegateID + ")");

            Boolean boolResult = false;

            Model.Delegate aDelegate = null;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    aDelegate = context.Delegates.Where(x => x.DelegateID == delegateID).FirstOrDefault();

                    if (aDelegate != null)
                    {
                        aDelegate.Active = "Disable";

                        context.SaveChanges();

                        boolResult = true;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ getDelegate: Exception Caught e=" + e);
                }
                finally
                {
                    context.Dispose();
                }
            }

            return boolResult;

        }

        public static Boolean deleteFutureDelegateRow(int delegateID)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.deleteFutureDelegateRow( delegateID=" + delegateID + ")");

            DateTime currentDate = System.DateTime.Now.Date;

            Boolean boolResult = false;

            Model.Delegate aDelegate = null;

            using (var context = new LogicUniversityEntities())
            {
                try {
                    aDelegate = context.Delegates.Where(x => x.DelegateID == delegateID).SingleOrDefault();

                    if (aDelegate != null && aDelegate.FromDate > currentDate)
                    {
                        context.Delegates.Remove(aDelegate);

                        context.SaveChanges();

                        boolResult = true;
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ getDelegate: Exception Caught e=" + e);
                }
                finally
                {
                    context.Dispose();
                }
            }

            return boolResult;
        }

    }
}