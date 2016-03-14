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

            // returns unfiltered 5-columns Model.Delegate as a list

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


        public static bool editDelegate(int intDelegateID, string empID, string strFromDate, string strToDate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.editDelegate( intDelegateID=" + intDelegateID + ", empID=" + empID + ", strFromDate=" + strFromDate + ", strToDate=" + strToDate + ")");
            //throw new NotImplementedException();

            bool boolResult = false, parseOK = false;

            Model.Delegate editDelegate;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    editDelegate = getDelegate(intDelegateID);

                    if (editDelegate != null)
                    {
                        showDelegateDetails(editDelegate, "Before change editDelegate");

                        parseOK = parseDelegate(empID, strFromDate, strToDate, ref editDelegate);

                        showDelegateDetails(editDelegate, "After  change editDelegate");

                        if (parseOK && checkDelegateValidity(editDelegate))
                        {
                            // http://stackoverflow.com/questions/15336248/entity-framework-5-updating-a-record

                            context.Delegates.Attach(editDelegate);
                            context.Entry(editDelegate).State = System.Data.EntityState.Modified;
                            context.SaveChanges();
                            boolResult = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ editDelegate: Exception Caught e=" + e);
                }
                finally
                {
                    context.Dispose();
                }
            }

            return boolResult;
        }

        /// <summary>
        /// Parses the given strings into a valid, on its own, Model.Delegate, if possible, and returns true, else false.
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="strFromDate"></param>
        /// <param name="strToDate"></param>
        /// <param name="aDelegate"></param>
        /// <returns></returns>
        public static bool parseDelegate(string empID, string strFromDate, string strToDate, ref Model.Delegate aDelegate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.parseDelegate( empID=" + empID + ", strFromDate=" + strFromDate + ", strToDate=" + strToDate + ", ref aDelegate.DelegateID=" + aDelegate.DelegateID + ")");

            bool parseOK = false;

            DateTime fromDate, toDate;

            if (Model.Utilities.checkEmployeeIDValidity(empID))
            {
                aDelegate.EmployeeID = empID;
                parseOK = true;
            }

            if (parseOK)
            {
                if (DateTime.TryParse(strFromDate, out fromDate))
                    aDelegate.FromDate = fromDate;
                else
                    parseOK = false;
            }

            if (parseOK)
            {
                if (parseOK && DateTime.TryParse(strToDate, out toDate))
                    aDelegate.ToDate = toDate;
                else
                    parseOK = false;
            }

            if (parseOK)
            {
                if (aDelegate.FromDate.CompareTo(aDelegate.ToDate) > 0) // fromDate must not be later than toDate
                    parseOK = false;
            }

            if (parseOK)
                aDelegate.Active = "Enable";

            System.Diagnostics.Debug.WriteLine(">>> DelegateAuthorityControl.parseDelegate " + parseOK);

            return parseOK;
        }

        /// <summary>
        /// Parses the given strings into a valid, on its own, Model.Delegate, if possible, <para />
        /// and checks that fromDate can only start the earliest at compDate, and returns true, else false.
        /// </summary>
        /// <param name="empID"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="compDate"></param>
        /// <param name="aDelegate"></param>
        /// <returns></returns>
        public static bool parseDelegate(string empID, string fromDate, string toDate, DateTime compDate, ref Model.Delegate aDelegate) // overload
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.parseDelegate( empID=" + empID + ", strFromDate=" + fromDate + ", strToDate=" + toDate + ", compDate=" + compDate.ToShortDateString() + " ref aDelegate.DelegateID=" + aDelegate.DelegateID + ")");

            if (parseDelegate(empID, fromDate, toDate, ref aDelegate))
            {
                if (aDelegate.FromDate.Date.CompareTo(compDate.Date) >= 0)
                {
                    // fromDate must at least start from today onwards
                    System.Diagnostics.Debug.WriteLine(">>> DelegateAuthorityControl.parseDelegate true");
                    return true;
                }
            } 
                
            return false;
        }

        /// <summary>
        /// Returns true if checkDelegate properties does not clash with other same department delegate properties in LogicUniversityEntities.Delegates <para />
        /// checkDelegate is assumed to be a valid Model.Delegate on its own <para />
        /// will ignore, i.e. does not bother to compare, with any encountered delegate that has the same DelegateID
        /// </summary>
        /// <param name="checkDelegate"></param>
        /// <returns></returns>
        private static bool checkDelegateValidity(Model.Delegate checkDelegate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.checkDelegateValidity( checkDelegate.DelegateID=" + checkDelegate.DelegateID + ")");
            //throw new NotImplementedException();

            bool validity = false;

            string deptID;

            List<Model.Delegate> newDeptDelegatesList;

            // code for checking validity of delegate record Create and Update here

            if (checkDelegate != null)
            {
                deptID = Model.Utilities.getDeptIDFromEmpID(checkDelegate.EmployeeID);

                newDeptDelegatesList = getDeptDelegatesList(deptID);

                if (newDeptDelegatesList != null)
                {
                    foreach (Model.Delegate aDelegate in newDeptDelegatesList)
                    {
                        if (checkDelegate.DelegateID == 0 || checkDelegate.DelegateID != aDelegate.DelegateID) // ignore if its the same delegate being edited
                        {
                            if (aDelegate.Active.Equals("Enable"))
                            {
                                if (((checkDelegate.FromDate.Date.CompareTo(aDelegate.FromDate.Date) < 0) && (checkDelegate.ToDate.Date.CompareTo(aDelegate.FromDate.Date) < 0))
                                    || ((checkDelegate.FromDate.Date.CompareTo(aDelegate.ToDate.Date) > 0) && (checkDelegate.ToDate.Date.CompareTo(aDelegate.ToDate.Date) > 0)))
                                    {
                                    validity = true;
                                    System.Diagnostics.Debug.WriteLine(">>> DelegateAuthorityControl.checkDelegateValidity TRUE aDelegate.DelegateID=" + aDelegate.DelegateID + " .EmployeeID=" + aDelegate.EmployeeID);
                                } else {
                                    validity = false;
                                    System.Diagnostics.Debug.WriteLine(">>> DelegateAuthorityControl.checkDelegateValidity FALSE aDelegate.DelegateID=" + aDelegate.DelegateID);
                                    showDelegateDetails(checkDelegate, "checkDelegate");
                                    showDelegateDetails(aDelegate, "aDelegate");
                                    break;
                                }                                
                            }
                        }
                    }
                }
            }

            return validity;
        }

        public static void showDelegateDetails(Model.Delegate aDelegate, string delName)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.showDelegateDetails()");

            System.Diagnostics.Debug.WriteLine(">>> " + delName 
                + ": .DelegateID=" + aDelegate.DelegateID 
                + " .EmployeeID=" + aDelegate.EmployeeID 
                + " .FromDate=" + aDelegate.FromDate.ToShortDateString() 
                + " .ToDate=" + aDelegate.ToDate.ToShortDateString() 
                + " .Active=" + aDelegate.Active);
        }

        public static bool addDelegate(string empID, string strFromDate, string strToDate, DateTime compDate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.addDelegate( empID=" + empID + ", strFromDate=" + strFromDate + ", strToDate=" + strToDate + ", compDate=" + compDate.ToShortDateString() + ")");
            //throw new NotImplementedException();

            bool boolResult = false, parseOK = false;

            Model.Delegate newDelegate = new Model.Delegate();

            parseOK = parseDelegate(empID, strFromDate, strToDate, compDate, ref newDelegate);

            showDelegateDetails(newDelegate, "newDelegate");

            if (parseOK && checkDelegateValidity(newDelegate))
            {
                using (var context = new LogicUniversityEntities())
                {
                    try
                    {
                        context.Delegates.Add(newDelegate);
                        context.SaveChanges();
                        boolResult = true;
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(">>> ERROR @ addDelegate: Exception Caught e=" + e);
                    }
                }
            }

            return boolResult;
        }

        /// <summary>
        /// Sends notifications and emails regarding new appointment, change of appointment and cancellation of appointment as Delegate <para />
        /// notiType: New, Change, CurrentCancel, FutureCancel
        /// </summary>
        /// <param name="currEmp"></param>
        /// <param name="theDelegateID"></param>
        /// <param name="notiType"></param>
        /// <returns></returns>
        public static string delegateNotifications(Employee currEmp, Model.Delegate theDelegate, String notiType)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.delegateNotifications( currEmp.EmployeeID=" + currEmp.EmployeeID + ", theDelegate.EmployeeID=" + theDelegate.EmployeeID + ", notiType=" + notiType + ")");

            string rtnMsg, emailSubject = "", emailBody = "", notiMsg = "", currDeptName, theDelegateNameEmpID;

            LoginControl loginCtrl = new LoginControl();
            Employee theDelegateEmp = null, deptHead = null;

            List<Model.empIdEmail> empIdEmailToList = new List<Model.empIdEmail>(), empIdEmailCCList = new List<Model.empIdEmail>();

            empIdEmail theDelegateIdEmail, deptHeadIdEmail;

            if(currEmp != null)
                deptHead = Model.Utilities.getDeptHeadEmpObj(currEmp.DepartmentID);

            if (theDelegate != null)
                theDelegateEmp = loginCtrl.getEmployeeUserObject(theDelegate.EmployeeID);

            System.Diagnostics.Debug.WriteLine(">> currEmp.EmployeeID=" + currEmp.EmployeeID 
                + ", theDelegate.EmployeeID=" + theDelegate.EmployeeID 
                + ", notiType=" + notiType
                + ", deptHead.EmployeeID=" + deptHead.EmployeeID
                + ", theDelegateEmp.EmployeeID=" + theDelegateEmp.EmployeeID
                + "");

            if (currEmp != null && deptHead != null && theDelegate != null && theDelegateEmp != null)
            {
                Control.CollectionPointControl crt = new Control.CollectionPointControl();
                currDeptName = crt.getDepartment(currEmp.DepartmentID).DepartmentName;

                ChangeRepresentativeControl crCtrl = new ChangeRepresentativeControl();
                theDelegateNameEmpID = crCtrl.getCombEmpNameID(theDelegateEmp.EmployeeID, theDelegateEmp.Name);

                if(notiType.Equals("New")) {
                    notiMsg = getValidDelegateNotificationMsg(currDeptName, theDelegate, "New");
                    emailSubject = "Appointment as delegated Department Head of " + currDeptName +" Department";
                    emailBody = getDelegateEmailBody(currEmp, deptHead, currDeptName, theDelegate, "New");
                }
                else if(notiType.Equals("Change")) {
                    notiMsg = getValidDelegateNotificationMsg(currDeptName, theDelegate, "Change");
                    emailSubject = "Date Change as delegated Department Head of " + currDeptName + " Department";
                    emailBody = getDelegateEmailBody(currEmp, deptHead, currDeptName, theDelegate, "Change");
                }
                else if (notiType.Equals("CurrentCancel"))
                {
                    notiMsg = getValidDelegateNotificationMsg(currDeptName, theDelegate, "Current");
                    emailSubject = "Cancellation as delegated Department Head of " + currDeptName + " Department (CURRENT)";
                    emailBody = getDelegateEmailBody(currEmp, deptHead, currDeptName, theDelegate, "Current");
                }
                else if (notiType.Equals("FutureCancel"))
                {
                    notiMsg = getValidDelegateNotificationMsg(currDeptName, theDelegate, "Future");
                    emailSubject = "Cancellation as delegated Department Head of " + currDeptName + " Department (FUTURE)";
                    emailBody = getDelegateEmailBody(currEmp, deptHead, currDeptName, theDelegate, "Future");
                }
                else
                {
                    // ERROR: Invalid notiType
                    System.Diagnostics.Debug.WriteLine(">>> DelegateAuthorityControl.delegateNotifications ERROR: Invalid notiType");
                }

                if (theDelegateEmp != null)
                {
                    theDelegateIdEmail = Model.Utilities.getEmpIdEmail(theDelegateEmp);
                    empIdEmailToList.Add(theDelegateIdEmail);
                }

                if(deptHead != null)
                {
                    deptHeadIdEmail = Model.Utilities.getEmpIdEmail(deptHead);
                    empIdEmailCCList.Add(deptHeadIdEmail);
                }

                // don't do this as it sends to the entire CC list for every TO email sent
                // but I'm doing this temporarily until emailCtrl.SendEmail works with an email list for TO
                //foreach (Model.empIdEmail empIdEmail in empIdEmailCCList)
                //    empIdEmailToList.Add(empIdEmail);

                rtnMsg = crt.sendNotiAndEmails(currEmp, emailSubject, emailBody, notiMsg, empIdEmailToList, empIdEmailCCList);

            }
            else
            {
                // ERROR: no valid current login employee obtained
                rtnMsg = "ERROR: No valid current login employee nor Delegate details information obtained.";
            }

            return rtnMsg;
        }

        public static string getValidDelegateNotificationMsg(string currDeptName, Model.Delegate theDelegate, String notiType)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getValidDelegateNotificationMsg(currDeptName=" + currDeptName + ", notiType=" + notiType + " )");

            int maxSize = Model.Utilities.GetColumnMaxLength<Notification>(x => x.Message);

            System.Diagnostics.Debug.WriteLine(">>> Model.Utilities.GetColumnMaxLength<Notification>(x => x.Message)=" + maxSize);

            string notiMsg, theDelegateNameEmpID, strFromDate, strToDate, centreString, beforeFrom, afterTo, deptCode;

            LoginControl loginCtrl = new LoginControl();
            Employee theDelegateEmp = loginCtrl.getEmployeeUserObject(theDelegate.EmployeeID);

            ChangeRepresentativeControl crCtrl = new ChangeRepresentativeControl();
            theDelegateNameEmpID = crCtrl.getCombEmpNameID(theDelegateEmp.EmployeeID, theDelegateEmp.Name);

            deptCode = Model.Utilities.getDeptIDFromEmpID(theDelegate.EmployeeID);

            strFromDate = theDelegate.FromDate.ToShortDateString();
            strToDate = theDelegate.ToDate.ToShortDateString();

            if (notiType.Equals("New")) {
                centreString = " is appointed the delegated Department Head of ";
                beforeFrom = " Department ";
                afterTo = "";
            }
            else if (notiType.Equals("Change")) {
                centreString = " delegated authority as Department Head of ";
                beforeFrom = " has been changed ";
                afterTo = "";
            }
            else
            {
                centreString = " delegated authority as Department Head of ";
                beforeFrom = " ";
                afterTo = " has been cancelled";
            }

            notiMsg = theDelegateNameEmpID + centreString
                       + currDeptName + beforeFrom + "from "
                       + strFromDate + " to "
                       + strToDate
                       + afterTo;

            /*
            New:    XX - is appointed the delegated Department Head of  - XX - Department       - from - XX - to - XX -
            Change: XX - delegated authority as Department Head of      - XX - has been changed - from - XX - to - XX -
            Current:XX - delegated authority as Department Head of      - XX -                  - from - XX - to - XX - has been cancelled
            Future: XX - delegated authority as Department Head of      - XX -                  - from - XX - to - XX - has been cancelled
             */
            if (notiMsg.Length > maxSize)
            {
                notiMsg = theDelegateNameEmpID + centreString
                       + currDeptName + beforeFrom 
                       + strFromDate + " - "
                       + strToDate
                       + afterTo;

                /*
                New:    XX - is appointed the delegated Department Head of  - XX - Department       - XX - XX -
                Change: XX - delegated authority as Department Head of      - XX - has been changed - XX - XX -
                Current:XX - delegated authority as Department Head of      - XX -                  - XX - XX - has been cancelled
                Future: XX - delegated authority as Department Head of      - XX -                  - XX - XX - has been cancelled
                 */
                if (notiMsg.Length > maxSize)
                {
                    if (beforeFrom.Contains("been"))
                        beforeFrom = " has changed ";

                    if (afterTo.Contains("been"))
                        afterTo = "has cancelled";

                    notiMsg = theDelegateNameEmpID + centreString
                           + currDeptName + beforeFrom
                           + strFromDate + " - "
                           + strToDate
                           + afterTo;

                    /*
                    New:    XX - is appointed the delegated Department Head of  - XX - Department  - XX - XX -
                    Change: XX - delegated authority as Department Head of      - XX - has changed - XX - XX -
                    Current:XX - delegated authority as Department Head of      - XX -             - XX - XX - has cancelled
                    Future: XX - delegated authority as Department Head of      - XX -             - XX - XX - has cancelled
                     */
                    if (notiMsg.Length > maxSize)
                    {
                        notiMsg = theDelegateNameEmpID + centreString
                               + currDeptName + beforeFrom
                               + afterTo;

                        /*
                        New:    XX - is appointed the delegated Department Head of  - XX - Department  -
                        Change: XX - delegated authority as Department Head of      - XX - has changed -
                        Current:XX - delegated authority as Department Head of      - XX -             - has cancelled
                        Future: XX - delegated authority as Department Head of      - XX -             - has cancelled
                         */
                        if (notiMsg.Length > maxSize)
                        {
                            notiMsg = theDelegateNameEmpID + centreString
                                   + deptCode + beforeFrom
                                   + afterTo;

                            /*
                            New:    XX - is appointed the delegated Department Head of  - X - Department  -
                            Change: XX - delegated authority as Department Head of      - X - has changed -
                            Current:XX - delegated authority as Department Head of      - X -             - has cancelled
                            Future: XX - delegated authority as Department Head of      - X -             - has cancelled
                             */

                            if (notiMsg.Length > maxSize)
                            {
                                centreString = centreString.Replace("Department ", "");

                                notiMsg = theDelegateNameEmpID + centreString
                                       + deptCode + beforeFrom
                                       + afterTo;
                                /*
                                New:    XX - is appointed the delegated Head of  - X - Department  -
                                Change: XX - delegated authority as Head of      - X - has changed -
                                Current:XX - delegated authority as Head of      - X -             - has cancelled
                                Future: XX - delegated authority as Head of      - X -             - has cancelled
                                 */
                                if (notiMsg.Length > maxSize)
                                {
                                    if (notiType.Equals("New"))
                                        centreString = " is new delegate of ";
                                    else
                                        centreString = " as delegate of ";

                                    if (notiType.Equals("Change"))
                                        afterTo = beforeFrom;

                                    notiMsg = theDelegateNameEmpID + centreString
                                           + deptCode
                                           + afterTo;

                                    /*
                                    New:    XX - is new delegate of - X - 
                                    Change: XX - as delegate of     - X - has changed
                                    Current:XX - as delegate of     - X - has cancelled
                                    Future: XX - as delegate of     - X - has cancelled
                                     */
                                    if (notiMsg.Length > maxSize)
                                    {
                                        switch (notiType)
                                        {
                                            case "New": notiMsg = "New delegate appointment"; break;
                                            case "Change": notiMsg = "Change of delegate details"; break;
                                            default: notiMsg = "Cancellation of delegate"; break;
                                        }

                                        /*
                                        New:    New delegate appointment 
                                        Change: Change of delegate details
                                        Current:Cancellation of delegate
                                        Future: Cancellation of delegate
                                         */
                                        if (notiMsg.Length > maxSize)
                                            notiMsg = notiMsg.Substring(0, maxSize - 1);
                                    }
                                }
                            }
                        }
                    }
                }

                System.Diagnostics.Debug.WriteLine(">>> Shortened notiMsg to " + notiMsg.Length);
            }

            return notiMsg;
        }


        /*
        To: Appointed Delegate
        Cc: Department Head
        Title: Appointment as delegated Department Head of XX Department

        Dear Sir/ Madam (Can this be the name of the Appointed Delegate?)
        Please be informed that you have been given the delegated authority of Department Head of XX Department during Name of Department Head’s absence from XX to XX.

        This is a system generated email, please do not reply.

        Notification: XX is appointed the delegated Department Head of XX Department from XX to XX
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        To: Appointed Delegate
        CC: Department Head
        Title: Cancellation as delegated Department Head of XX Department (FUTURE)

        Dear Sir/ Madam (Can this be the name of the Appointed Delegate?)
        Please be informed that your appointment as delegated Department Head of XX Department from XX to XX has been cancelled.  

        This is a system generated email, please do not reply.

        Notification: XX’s delegated authority as Department Head of XX from XX to XX has been cancelled.
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        To: Appointed Delegate
        CC: Department Head
        Title: Cancellation as delegated Department Head of XX Department (CURRENT)

        Dear Sir/ Madam (Can this be the name of the Appointed Delegate?)
        Please be informed that your appointment as delegated Department Head of XX Department has been cancelled.  

        This is a system generated email, please do not reply.

        Notification: XX’s delegated authority as Department Head of XX from XX to XX has been cancelled.
        */
        private static string getDelegateEmailBody(Employee currEmp, Employee deptHead, string currDeptName, Model.Delegate theDelegate, String emailType)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getNewDelegateEmailBody(currEmp, deptHead, currDeptName=" + currDeptName + ", theDelegate, emailType=" + emailType + " )");

            string delegateNameID = "", emailBody = "";

            if(theDelegate != null)
                delegateNameID = Model.Utilities.getCombEmpNameID(theDelegate.EmployeeID);

            if (delegateNameID.Equals(""))
                emailBody = "Dear Sir / Madam,\r\n";
            else
                emailBody = "Dear "+ delegateNameID +",\r\n";

            if (emailType.Equals("New"))
                emailBody += "Please be informed that you have been given the delegated authority of Department Head of ";
            else if (emailType.Equals("Change"))
                emailBody += "Please be informed of the new changed dates of your appointment as the delegated Department Head of ";
            else
                emailBody += "Please be informed that your appointment as delegated Department Head of ";
            emailBody += currDeptName;
            emailBody += " Department";
            if (emailType.Equals("New"))
            {
                emailBody += " during ";
                if (deptHead != null)
                    emailBody += deptHead.Name;
                else
                    emailBody += "it's Department Head's";
                emailBody += " absence";
            }
            if ( theDelegate != null && !emailType.Equals("Current") )  
            {
                if (emailType.Equals("Change"))
                    emailBody += " starting ";

                emailBody += " from ";
                emailBody += theDelegate.FromDate.ToShortDateString();
                emailBody += " to ";
                emailBody += theDelegate.ToDate.ToShortDateString();
            }
            if(emailType.Equals("Current") || emailType.Equals("Future"))
                emailBody += " has been cancelled";
            emailBody += ".\r\n";
            emailBody += "This is a system generated email, please do not reply.\r\n\r\n";

            if (currEmp != null)
            {
                emailBody += "Change made by ";
                Control.ChangeRepresentativeControl crt = new Control.ChangeRepresentativeControl();
                emailBody += crt.getCombEmpNameID(currEmp.EmployeeID, currEmp.Name);
                emailBody += ".\r\n";
            }

            return emailBody;
        }

        /// <summary>
        /// Checks all but the DelegateID of these two Delegate objects have the same values.<para />
        /// Returns a String "Same" if they both have the same values,<para />
        /// else a concatenation of the properties that are different
        /// </summary>
        /// <param name="oldDelegate"></param>
        /// <param name="newDelegate"></param>
        /// <returns></returns>
        public static String compareDelegates(Model.Delegate oldDelegate, Model.Delegate newDelegate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.compareDelegates( oldDelegate, newDelegate )");
            //throw new NotImplementedException();

            String rtnString = "Same";

            if (!oldDelegate.EmployeeID.Equals(newDelegate.EmployeeID))
                rtnString = "EmployeeID";

            if (oldDelegate.FromDate.Date.CompareTo(newDelegate.FromDate.Date) != 0)
                addToRtnString(ref rtnString, "FromDate");

            if (oldDelegate.ToDate.Date.CompareTo(newDelegate.ToDate.Date) != 0)
                addToRtnString(ref rtnString, "ToDate");

            if (!oldDelegate.Active.Equals(newDelegate.Active))
                addToRtnString(ref rtnString, "Active");

            return rtnString;
        }

        /// <summary>
        /// Concatenates ", " and addString to the end of rtnString if the later is not "Same", else rtnString becomes addString
        /// </summary>
        /// <param name="rtnString"></param>
        /// <param name="addString"></param>
        private static void addToRtnString(ref String rtnString, String addString)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.addToRtnString( ref rtnString=" + rtnString + ", addString=" + addString + " )");

            if (rtnString.Equals("Same"))
                rtnString = addString;
            else
            {
                rtnString += ", ";
                rtnString += addString;
            }
        }

        public static string delegateChangeNotifications(Employee currEmp, Model.Delegate oldDelegate, Model.Delegate newDelegate)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.delegateChangeNotifications( currEmp.EmpID=" + currEmp.EmployeeID + ", oldDelegate.EmpID=" + oldDelegate.EmployeeID + ", newDelegate.EmpID=" + newDelegate.EmployeeID + " )");
            //throw new NotImplementedException();

            int notificationCount = 0;

            string rtnMsg = "", firstMsg, secondMsg;

            // oldDelegate has to be informed of cancellation
            firstMsg = Control.DelegateAuthorityControl.delegateNotifications(currEmp, oldDelegate, "FutureCancel");

            notificationCount += countNotifications(firstMsg);

            // delegate changed to newDelegate
            secondMsg = Control.DelegateAuthorityControl.delegateNotifications(currEmp, newDelegate, "New"); // newly appointed to delegate

            notificationCount += countNotifications(secondMsg);

            rtnMsg = "; Notifications sent: " + notificationCount;

            checkEmailsSentOK(firstMsg, secondMsg, ref rtnMsg);

            return rtnMsg;
        }

        private static void checkEmailsSentOK(string firstMsg, string secondMsg, ref string rtnMsg)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.countNotifications( firstMsg=" + firstMsg + ", secondMsg=" + secondMsg + ", rtnMsg )");
            //throw new NotImplementedException();

            bool boolEmailsSent = false, boolSendmailException = false, boolInvalidEmails = false;

            string wrongEmails = "";
            string strEmailsSent = "; Emails sent.";
            string strSendmailException = " SendEmail Exception caught for ";
            string strInvalidEmails = ", Invalid email: ";

            if (firstMsg.Contains(strEmailsSent) || secondMsg.Contains(strEmailsSent))
            {
                boolEmailsSent = true;
            }
            else if (firstMsg.Contains(strSendmailException))
            {
                boolSendmailException = true;
                getWrongEmails(firstMsg, strSendmailException, ref wrongEmails);
            }
            else if (secondMsg.Contains(strSendmailException))
            {
                boolSendmailException = true;
                getWrongEmails(secondMsg, strSendmailException, ref wrongEmails);
            }
            else if (firstMsg.Contains(strInvalidEmails))
            {
                boolInvalidEmails = true;
                getWrongEmails(firstMsg, strInvalidEmails, ref wrongEmails);
            }
            else if (secondMsg.Contains(strInvalidEmails))
            {
                boolInvalidEmails = true;
                getWrongEmails(secondMsg, strInvalidEmails, ref wrongEmails);
            }

            if (boolEmailsSent)
            {
                rtnMsg += "; Email(s) sent";

                if (boolSendmailException || boolInvalidEmails)
                    rtnMsg += " except for these: " + wrongEmails;
            }
            else if (boolSendmailException || boolInvalidEmails)
            {
                rtnMsg += "; Errors sending these emails: " + wrongEmails;
            }

        }

        private static void getWrongEmails(string msg, string searchString, ref string wrongEmails)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.getWrongEmails( msg=" + msg + ", searchString=" + searchString + ", ref wrongEmails )");
            //throw new NotImplementedException();

            int index, length, emailIndex;

            length = searchString.Length;

            index = msg.IndexOf(searchString);

            emailIndex = index + length;

            if (wrongEmails.Length != 0)
            {
                wrongEmails = ", ";
            }

            wrongEmails += msg.Substring(emailIndex);
        }

        private static int countNotifications(string msg)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.countNotifications( msg=" + msg + " )");
            //throw new NotImplementedException();

            int count = 0, index = 0, length, nextIndex, size = 2;

            string searchString = "Notifications sent:";

            length = searchString.Length;

            nextIndex = findNextIndex(msg);

            if (msg.Contains(searchString))
            {
                index = msg.IndexOf(searchString);

                if (nextIndex != 0)
                {
                    // get valid size
                    size = nextIndex - (index + length);
                }

                if (int.TryParse(msg.Substring(index + length, size), out count))
                    return count;
            }

            return count;
        }

        private static int findNextIndex(string msg)
        {
            System.Diagnostics.Debug.WriteLine(">> DelegateAuthorityControl.findNextIndex( msg=" + msg + " )");
            //throw new NotImplementedException();

            int nextIndex = 0;

            if (msg.Contains("; Emails sent."))
            {
                nextIndex = msg.IndexOf("; Emails sent.");
            }
            else if (msg.Contains(" SendEmail Exception caught for "))
            {
                nextIndex = msg.IndexOf(" SendEmail Exception caught for ");
            }
            else if (msg.Contains(", Invalid email: "))
            {
                nextIndex = msg.IndexOf(", Invalid email: ");
            }

            return nextIndex;
        }
    }
}