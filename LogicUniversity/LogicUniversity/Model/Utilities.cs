using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public struct FilNotiLstEle
    {
        //public DateTime dateTimeFilNoti;
        //public String msgFilNoti;
        //public String fromUserFilNoti;

        public String dateTimeFilNoti { get; set; }
        public String msgFilNoti { get; set; }
        public String fromUserFilNoti { get; set; }
    }

    public class MySession
    {
        // http://stackoverflow.com/questions/621549/how-to-access-session-variables-from-any-class-in-asp-net

        // private constructor
        private MySession()
        //public MySession()
        {
            //Property1 = "default value";

            if (HttpContext.Current.Session["type"] != null)
                type = HttpContext.Current.Session["type"] as string;

            if (HttpContext.Current.Session["User"] != null)
            {
                User = HttpContext.Current.Session["User"] as Object;
            }
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                System.Diagnostics.Debug.WriteLine(">> MySession.Current get");

                MySession session = (MySession)HttpContext.Current.Session["__MySession__"];

                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }

                return session;
            }
        }

        // **** add your session properties here, e.g like this:
        //public string Property1 { get; set; }
        //public DateTime MyDate { get; set; }
        //public int LoginId { get; set; }

        public string type { get; set; }

        public Object User { get; set; }
    }

    public static class Utilities
    {
        public static void getCurrLoginEmp(ref Model.Employee currEmp, ref Model.StoreEmployee currStoreEmp)
        {
            System.Diagnostics.Debug.WriteLine(">> Notification.getCurrentEmployee()");

            string strSessType = MySession.Current.type;

            if (strSessType.Equals("Employee"))
            {
                if (MySession.Current.User != null)
                {
                    currEmp = MySession.Current.User as Model.Employee;
                }
            }
            else if (strSessType.Equals("StoreEmployee"))
            {
                if (MySession.Current.User != null)
                {
                    currStoreEmp = MySession.Current.User as Model.StoreEmployee;
                }
            }
            else
            {
                // ERROR: Unknown Employee Type
            }
        }

        public static Object getCurrLoginEmp2(string empType)
        {
            Model.Employee newEmployee = null;
            Model.StoreEmployee newStoreEmployee = null;

            getCurrLoginEmp(ref newEmployee, ref newStoreEmployee);

            if (empType.Equals("Employee"))
                return newEmployee;
            else if (empType.Equals("StoreEmployee"))
                return newStoreEmployee;
            else
                return null;
        }

        public static string getCollPtName(int collPtID)
        {
            string collPtName = "";

            collPtName = Control.CollectionPointControl.getCollectionPoint(collPtID).CollectionPointName;

            return collPtName;
        }

    }

}