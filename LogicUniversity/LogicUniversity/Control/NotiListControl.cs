using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class NotiListControl
    {
        LogicUniversityEntities ctx;
        public NotiListControl()
        {
            ctx = new LogicUniversityEntities();
        }
        // StoreFound = Store Employee Found;
        // EmployeeFound = Employee Found
        // NotFound = Not Found User;
        // Delegate = Employee is delegate;
        //public String Login(string UserID, string PIN)
        //{
        //    string UserType = UserID.Substring(0, 1);
        //    if (UserType.Equals("S"))
        //    {
        //        System.Diagnostics.Debug.WriteLine("StoreClerk Login");
        //        StoreEmployee semp = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == UserID && x.PIN == PIN).FirstOrDefault();
        //        if (semp == null)
        //        {
        //            System.Diagnostics.Debug.WriteLine("StoreClerk Not Found");
        //            return "NotFound";
        //        }
        //        return "StoreFound";
        //    }
        //    else if (UserType.Equals("E"))
        //    {
        //        System.Diagnostics.Debug.WriteLine("Employee Login");
        //        Employee emp = ctx.Employees.Where(x => x.EmployeeID == UserID && x.PIN == PIN).FirstOrDefault();
        //        if (emp == null)
        //        {
        //            System.Diagnostics.Debug.WriteLine("Employee Not Found");
        //            return "NotFound";
        //        }
        //        if (emp.Role != "Department Head")
        //        {
        //            Model.Delegate del = ctx.Delegates.Where(x => x.EmployeeID == emp.EmployeeID && x.ToDate >= DateTime.Today && x.FromDate <= DateTime.Today).FirstOrDefault();
        //            if (del == null)
        //            {
        //                return "EmployeeFound";
        //            }
        //            else
        //            {
        //                System.Diagnostics.Debug.WriteLine("Delegate");
        //                return "Delegate";
        //            }
        //        }
        //        else
        //        {
        //            return "EmployeeFound";
        //        }
        //    }
        //    return "NotFound";
        //}
        //public Employee getEmployeeUserObject(string empid)
        //{
        //    return ctx.Employees.Where(x => x.EmployeeID == empid).FirstOrDefault();
        //}
        //public StoreEmployee getStoreEmployeeUserObject(String sid)
        //{
        //    return ctx.StoreEmployees.Where(x => x.StoreEmployeeID == sid).FirstOrDefault();
        //}

        // success = successfully changed
        // notfound = user not found
        // error = type is not equal both StoreEmployee and Employee
        //public String ChangePIN(Object user,string type,string oldPIN,string newPIN)
        //{
        //    string result = "error";
        //    if (type.Equals("StoreEmployee"))
        //    {
        //        StoreEmployee semp = (StoreEmployee)user;
        //        StoreEmployee sEmp = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == semp.StoreEmployeeID && x.PIN == oldPIN).FirstOrDefault();
        //        if (sEmp == null)
        //            return "notfound";
        //        sEmp.PIN = newPIN;
        //        ctx.SaveChanges();
        //        return "success";
        //    }
        //    if (type.Equals("Employee"))
        //    {
        //        Employee semp = (Employee)user;
        //        Employee Emp = ctx.Employees.Where(x => x.EmployeeID == semp.EmployeeID && x.PIN == oldPIN).FirstOrDefault();
        //        if (Emp == null)
        //            return "notfound";
        //        Emp.PIN = newPIN;
        //        ctx.SaveChanges();
        //        return "success";
        //    }
        //    return result;
        //}

        public List<Notification> getNotificationList(string empID)
        {
            System.Diagnostics.Debug.WriteLine(">> NotificationControl.getNotificationList( empID=" + empID + ")");

            // returns unfiltered 5-columns Model.Notification as a list

            //throw new NotImplementedException();
            List<Notification> newNotificationList = null;

            var context = new LogicUniversityEntities();

            newNotificationList = context.Notifications.Where(x => x.UserID == empID).OrderByDescending(x => x.NotificationDate).ToList();

            return newNotificationList;
        }

        public List<Model.FilNotiLstEle> getFilteredNotificationList(string empID)
        {
            System.Diagnostics.Debug.WriteLine(">> NotificationControl.getFilteredNotificationList( empID=" + empID + ")");

            // returns filtered 3-columns NotificationDate, Message, FromUser(UserName - UserRole) as a list

            DateTime aDateTime;
            String aMsg, fromUser, combNameRole;

            Model.FilNotiLstEle aFilNotiLstEle;

            //LoginControl loginCrt = new LoginControl();

            List<Notification> newNotificationList = getNotificationList(empID);

            List<Model.FilNotiLstEle> newFilteredNotificationList = new List<Model.FilNotiLstEle>();

            foreach (Notification aNotification in newNotificationList)
            {
                //FilNotiLstEle aFilNotiLstEle = new FilNotiLstEle();
                aFilNotiLstEle = new Model.FilNotiLstEle();

                aDateTime = (DateTime)aNotification.NotificationDate;
                aMsg = aNotification.Message;
                fromUser = aNotification.FromUser;

                combNameRole = getCombNameRole(fromUser);

                aFilNotiLstEle.dateTimeFilNoti = aDateTime.Date.ToString("dd-MMM-yyyy");
                aFilNotiLstEle.msgFilNoti = aMsg;
                aFilNotiLstEle.fromUserFilNoti = combNameRole;

                newFilteredNotificationList.Add(aFilNotiLstEle);
            }

            //return newNotificationList;

            return newFilteredNotificationList;
        }

        public String getCombNameRole(String fromUserID)
        {
            System.Diagnostics.Debug.WriteLine(">> NotificationControl.getCombNameRole( fromUserID=" + fromUserID + ")");

            LoginControl loginCrt = new LoginControl();

            Employee anEmp;
            StoreEmployee aStoreEmp;

            String fromUserName = "", fromUserRole = "", combNameRole;

            if (fromUserID.Substring(0, 3).Equals("STR"))
            {
                // fromUser is StoreEmployee
                aStoreEmp = loginCrt.getStoreEmployeeUserObject(fromUserID);

                fromUserName = aStoreEmp.Name;
                fromUserRole = aStoreEmp.Role;

            }
            else if (fromUserID.Substring(0, 3).Equals("Emp"))
            {
                // fromUser is Employee
                anEmp = loginCrt.getEmployeeUserObject(fromUserID);

                fromUserName = anEmp.Name;
                fromUserRole = anEmp.Role;
            }
            else
            {
                // fromUser is neither StoreEmployee nor Employee, therefore, an ERROR
                fromUserName = "Unknown FromUserName";
                fromUserRole = "Unknown FromUserRole";
            }

            combNameRole = fromUserName + " - " + fromUserRole;

            return combNameRole;
        }
    }
}