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