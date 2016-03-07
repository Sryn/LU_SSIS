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
                    aDeptDelegateGVEle = new deptDelegateGVEle();

                    aDeptDelegateGVEle.DelegateID = aDelegate.DelegateID;
                    aDeptDelegateGVEle.empNameID = Model.Utilities.getCombEmpNameID(aDelegate.EmployeeID);
                    aDeptDelegateGVEle.fromDate = aDelegate.FromDate.ToShortDateString();
                    aDeptDelegateGVEle.toDate = aDelegate.ToDate.ToShortDateString();
                    aDeptDelegateGVEle.edit = getEditString(aDelegate, compDate);
                    aDeptDelegateGVEle.cancel = getCancelString(aDelegate, compDate);

                    newDeptDelegateGVEleList.Add(aDeptDelegateGVEle);
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

        //internal static List<Model.FilNotiLstEle> getFilteredNotificationList(string empID)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> NotificationControl.getFilteredNotificationList( empID=" + empID + ")");

        //    // returns filtered 3-columns NotificationDate, Message, FromUser(UserName - UserRole) as a list

        //    DateTime aDateTime;
        //    String aMsg, fromUser, combNameRole;

        //    Model.FilNotiLstEle aFilNotiLstEle;

        //    //LoginControl loginCrt = new LoginControl();

        //    List<Notification> newNotificationList = getNotificationList(empID);

        //    List<Model.FilNotiLstEle> newFilteredNotificationList = new List<Model.FilNotiLstEle>();

        //    foreach (Notification aNotification in newNotificationList)
        //    {
        //        //FilNotiLstEle aFilNotiLstEle = new FilNotiLstEle();
        //        aFilNotiLstEle = new Model.FilNotiLstEle();

        //        aDateTime = (DateTime)aNotification.NotificationDate;
        //        aMsg = aNotification.Message;
        //        fromUser = aNotification.FromUser;

        //        combNameRole = getCombNameRole(fromUser);

        //        aFilNotiLstEle.dateTimeFilNoti = aDateTime.Date.ToString("dd-MMM-yyyy");
        //        aFilNotiLstEle.msgFilNoti = aMsg;
        //        aFilNotiLstEle.fromUserFilNoti = combNameRole;

        //        newFilteredNotificationList.Add(aFilNotiLstEle);
        //    }

        //    //return newNotificationList;

        //    return newFilteredNotificationList;
        //}

        //private static String getCombNameRole(String fromUserID)
        //{
        //    System.Diagnostics.Debug.WriteLine(">> NotificationControl.getCombNameRole( fromUserID=" + fromUserID + ")");

        //    LoginControl loginCrt = new LoginControl();

        //    Employee anEmp;
        //    StoreEmployee aStoreEmp;

        //    String fromUserName = "", fromUserRole = "", combNameRole;

        //    if (fromUserID.Substring(0, 3).Equals("STR"))
        //    {
        //        // fromUser is StoreEmployee
        //        aStoreEmp = loginCrt.getStoreEmployeeUserObject(fromUserID);

        //        fromUserName = aStoreEmp.Name;
        //        fromUserRole = aStoreEmp.Role;

        //    }
        //    else if (fromUserID.Substring(0, 3).Equals("Emp"))
        //    {
        //        // fromUser is Employee
        //        anEmp = loginCrt.getEmployeeUserObject(fromUserID);

        //        fromUserName = anEmp.Name;
        //        fromUserRole = anEmp.Role;
        //    }
        //    else
        //    {
        //        // fromUser is neither StoreEmployee nor Employee, therefore, an ERROR
        //        fromUserName = "Unknown FromUserName";
        //        fromUserRole = "Unknown FromUserRole";
        //    }

        //    combNameRole = fromUserName + " - " + fromUserRole;

        //    return combNameRole;
        //}
    }
}