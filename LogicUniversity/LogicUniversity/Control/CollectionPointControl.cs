using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class CollectionPointControl
    {
        LogicUniversityEntities ctx;
        public CollectionPointControl()
        {
            ctx = new LogicUniversityEntities();
        }

        public Department getDepartment(String deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getDepartment( deptID=" + deptID + ")");

            var context = new LogicUniversityEntities();

            Department rtnDept = context.Departments.Where(x => x.DepartmentID == deptID).FirstOrDefault();

            return rtnDept;
        }

        public CollectionPoint getCollectionPoint(int collPtID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getCollectionPoint( collPtID=" + collPtID + ")");

            var context = new LogicUniversityEntities();

            CollectionPoint rtnCollPt = context.CollectionPoints.Where(x => x.CollectionPointID == collPtID).FirstOrDefault();

            return rtnCollPt;
        }

        public List<CollectionPoint> getListCollectionPoint()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getListCollectionPoint()");

            var context = new LogicUniversityEntities();

            List<CollectionPoint> rtnCollPtList = context.CollectionPoints.ToList();

            return rtnCollPtList;
        }

        public int changeCollectionPointForDept(string deptID, int newCollPt)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.changeCollectionPointForDept( deptID=" + deptID + ", newCollPt=" + newCollPt + ")");

            //deptID = "ABCD"; // ERROR test - passed
            //newCollPt = 2; // ERROR test - passed

            int rtnInt = 0;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    Department currDept = context.Departments.Single(x => x.DepartmentID == deptID);

                    currDept.CollectionPointID = newCollPt;

                    rtnInt = context.SaveChanges();
                }
                catch (Exception)
                {
                    context.Dispose();

                    rtnInt = -1;
                }
            }

            return rtnInt;
        }

        public Model.Employee getDeptRep(string deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getListCollectionPoint()");

            Model.Employee deptRep = null;

            var context = new LogicUniversityEntities();

            deptRep = context.Employees.Where(x => x.DepartmentID == deptID && x.Role == "Representative").FirstOrDefault();

            return deptRep;
        }

        /*
            To: Store Clerk, Store Supervisor, Store Manager
            Cc: Department Representative, Department Head
            Title: XX Department changed its Collection Point to XX

            Dear Sir/ Madam,
            Please be informed that XX Department has changed their collection point to XX.
            This is a system generated email, please do not reply.

            Notification: XX Department has changed its collection point to XX.         

            public void SendEmail(string to, string subject, string body, List<string> cclist)
         */
        public string sendChangeCollectionPointNotifications(Employee currEmp, Department currDept, string newCollPtName)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendChangeCollectionPointNotifications(currEmp, currDept, newCollPtName=" + newCollPtName + ")");

            string msg, emailSubject = "", emailBody = "", notiMsg = "", currDeptName;

            List<Model.empIdEmail> empIdEmailToList = new List<Model.empIdEmail>(), empIdEmailCCList = new List<Model.empIdEmail>();

            if (currDept != null)
            {
                currDeptName = currDept.DepartmentName;

                //notiMsg = currDeptName + " Department has changed its collection point to " + newCollPtName;
                notiMsg = getValidNotificationMsg(currDeptName, newCollPtName, " Department has changed its ", "Collection Point");

                emailSubject = currDeptName + " Department changed its Collection Point to " + newCollPtName;

                emailBody = getEmailBody(currEmp, currDeptName, newCollPtName, "Collection Point");

                empIdEmailToList = getAllStoreEmployeesIdEmailToList();

                empIdEmailCCList = getDeptHeadRepIdEmailList(currDept.DepartmentID);

                // don't do this as it sends to the entire CC list for every TO email sent
                // but I'm doing this temporarily until emailCtrl.SendEmail works with an email list for TO
                //foreach (Model.empIdEmail empIdEmail in empIdEmailCCList)
                //    empIdEmailToList.Add(empIdEmail);

                msg = sendNotiAndEmails(currEmp, emailSubject, emailBody, notiMsg, empIdEmailToList, empIdEmailCCList);

            }
            else
            {
                // ERROR: no valid current department obtained
                msg = "ERROR: No valid current department information obtained.";
            }

            return msg;
        }

        public string getValidNotificationMsg(string currDeptName, string newThing, string middleText, string changedThing)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendNotiAndEmails(currDeptName=" + currDeptName + ", newThing=" + newThing + ", middleText, changedThing=" + changedThing + " )");

            int maxSize = Model.Utilities.GetColumnMaxLength<Notification>(x => x.Message);

            System.Diagnostics.Debug.WriteLine(">>> Model.Utilities.GetColumnMaxLength<Notification>(x => x.Message)=" + maxSize);

            string notiMsg = currDeptName + middleText + changedThing + " to " + newThing;

            if (notiMsg.Length > maxSize)
            {
                notiMsg = currDeptName + " changed " + changedThing + " to " + newThing;

                if (notiMsg.Length > maxSize)
                {
                    notiMsg = changedThing + " changed";

                    if (notiMsg.Length > maxSize)
                        notiMsg = notiMsg.Substring(0, maxSize - 1);
                }

                System.Diagnostics.Debug.WriteLine(">>> Shortened notiMsg to " + notiMsg.Length);
            }

            return notiMsg;
        }

        public string sendNotiAndEmails(Employee currEmp, string emailSubject, string emailBody, string notiMsg, List<Model.empIdEmail> empIdEmailToList, List<Model.empIdEmail> empIdEmailCcList)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendNotiAndEmails(currEmp, emailSubject, emailBody, notiMsg, empIdEmailToList)");

            string msg = "";

            List<String> justEmpEmailToList = new List<String>();
            List<String> justEmpEmailCcList = new List<String>();

            List<Model.empIdEmail> empIdEmailNotiList = getAllNotiRecipientsList(empIdEmailToList, empIdEmailCcList);

            if (empIdEmailNotiList.Count != 0)
            {
                msg = sendNotifications(currEmp, notiMsg, empIdEmailNotiList);

                justEmpEmailToList = getJustEmpEmailList(empIdEmailToList, ref msg);
                justEmpEmailCcList = getJustEmpEmailList(empIdEmailCcList, ref msg);

                //msg += "; Notifications sent: " + successfulNotiSentCount;

                //foreach (String empEmail in justEmpEmailList)
                //{
                //string empEmail = currEmp.Email; // temporary until emailCtrl.SendEmail works with an email list for TO

                //if (regexUtil.IsValidEmail(empEmail))
                //{
                    // valid email, so send
                if (justEmpEmailToList.Count > 0)
                {
                    EmailControl emailCtrl = new EmailControl();

                    try
                    {
                        //List<string> toList = new List<string>();
                        //toList.Add(empEmail);
                        //emailCtrl.SendEmail(toList, emailSubject, emailBody, justEmpEmailList);
                        emailCtrl.SendEmail(justEmpEmailToList, emailSubject, emailBody, justEmpEmailCcList);

                        msg += "; Emails sent.";
                    }
                    catch (Exception e)
                    {
                        // send email error
                        System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                        msg += "; Error sending email(s)";
                    }
                }
                else
                {
                    msg += "; No valid email address found to send notifications to";
                }
                //}
                //else
                //{
                //    // invalid email found
                //    msg += ", Invalid email: " + empEmail;
                //}
                //}
            }
            else
            {
                // ERROR: cannot get any recipient emails
                msg += "ERROR: Cannot get any recipient email addresses.";
            }

            return msg;
        }

        /// <summary>
        /// Returns a List&lt;string&gt; of just the REGEX validified email of each empIdEmail in empIdEmailList<para />
        /// message is added to to mention success/errors of email REGEX verifications
        /// </summary>
        /// <param name="empIdEmailList"></param>
        /// <returns></returns>
        private List<string> getJustEmpEmailList(List<empIdEmail> empIdEmailList, ref string message)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getJustEmpEmailToList( empIdEmailToList)");

            RegexUtilities regexUtil = new RegexUtilities();

            List<String> justEmpEmailList = new List<String>();

            if(empIdEmailList != null && empIdEmailList.Count > 0) {
                foreach (empIdEmail anEmpIdEmail in empIdEmailList)
                {
                    if (regexUtil.IsValidEmail(anEmpIdEmail.Email))
                    {
                        // add valid email to list
                        justEmpEmailList.Add(anEmpIdEmail.Email);
                    }
                    else
                    {
                        // invalid email found
                        message += ", Invalid email: " + anEmpIdEmail.Email;
                    }
                }
            }

            return justEmpEmailList;
        }

        /// <summary>
        /// Sends a notification with notiMsg as the message to each recipient in the empIdEmailNotiList, with the sender set as currEmp<para />
        /// Returns a string message saying number of notifications sent
        /// </summary>
        /// <param name="currEmp"></param>
        /// <param name="notiMsg"></param>
        /// <param name="empIdEmailNotiList"></param>
        /// <returns></returns>
        private string sendNotifications(Employee currEmp, string notiMsg, List<Model.empIdEmail> empIdEmailNotiList)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendNotifications( currEmp, notiMsg, empIdEmailNotiList)");

            string notiRtnMsg = "", parseMsg;
            int successfulNotiSentCount = 0;

            foreach (Model.empIdEmail empIdEmail in empIdEmailNotiList)
            {
                parseMsg = sendNotification(empIdEmail.EmployeeID, notiMsg, currEmp.EmployeeID);

                try
                {
                    successfulNotiSentCount += int.Parse(parseMsg);
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                    notiRtnMsg += parseMsg;
                }

            }

            notiRtnMsg += "; Notifications sent: " + successfulNotiSentCount;

            return notiRtnMsg;
        }

        /// <summary>
        /// Returns a List<Model.empIdEmail> of the combined contents of empIdEmailToList and empIdEmailCcList
        /// </summary>
        /// <param name="empIdEmailToList"></param>
        /// <param name="empIdEmailCcList"></param>
        /// <returns></returns>
        private List<empIdEmail> getAllNotiRecipientsList(List<empIdEmail> empIdEmailToList, List<empIdEmail> empIdEmailCcList)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getAllNotiRecipientsList(empIdEmailToList, empIdEmailCcList)");

            List<Model.empIdEmail> empIdEmailNotiList = new List<empIdEmail>();

            if (empIdEmailToList != null && empIdEmailToList.Count != 0)
            {
                foreach (Model.empIdEmail anEmpIdEmail in empIdEmailToList)
                    empIdEmailNotiList.Add(anEmpIdEmail);
            }

            if (empIdEmailCcList != null && empIdEmailCcList.Count != 0)
            {
                foreach (Model.empIdEmail anEmpIdEmail in empIdEmailCcList)
                    empIdEmailNotiList.Add(anEmpIdEmail);
            }

            return empIdEmailNotiList;
        }

        public string sendNotification(string toEmpID, string notiMsg, string fromEmpID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendNotification(empID=" + toEmpID + ", notiMsg, fromEmpID=" + fromEmpID + ")");
            //throw new NotImplementedException();

            string rtnMsg = "";

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    Notification aNotification = new Notification();

                    aNotification.UserID = toEmpID;
                    aNotification.Message = notiMsg;
                    aNotification.FromUser = fromEmpID;
                    aNotification.NotificationDate = System.DateTime.Now;

                    context.Notifications.Add(aNotification);

                    rtnMsg += context.SaveChanges();
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                    rtnMsg += "; ERROR: sendNotification for empID=" + toEmpID;
                }
            }

            return rtnMsg;
        }

        public List<Model.empIdEmail> getDeptHeadRepIdEmailList(string deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getDeptHeadRepIdEmailList(deptID=" + deptID + ")");

            List<Model.empIdEmail> deptHeadRepIdEmailList = new List<Model.empIdEmail>();

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    foreach (Employee row in context.Employees.Where(x => x.DepartmentID == deptID).ToList())
                    {
                        if (row.Role.Equals("Department Head") || row.Role.Equals("Representative"))
                        {
                            ////Model.empIdEmail anEmpIdEmail = new Model.empIdEmail();

                            ////anEmpIdEmail.EmployeeID = row.EmployeeID;
                            ////anEmpIdEmail.Email = row.Email;

                            //Model.empIdEmail anEmpIdEmail = Model.Utilities.getEmpIdEmail(row);

                            //deptHeadRepIdEmailList.Add(anEmpIdEmail);

                            deptHeadRepIdEmailList.Add(Model.Utilities.getEmpIdEmail(row));
                        }
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                }
            }

            return deptHeadRepIdEmailList;
        }

        public List<Model.empIdEmail> getAllStoreEmployeesIdEmailToList()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getAllStoreEmployeesIdEmailToList()");

            List<Model.empIdEmail> empIdEmailToList = new List<Model.empIdEmail>();

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    foreach (StoreEmployee row in context.StoreEmployees)
                    {
                        //Model.empIdEmail anEmpIdEmail = new Model.empIdEmail();

                        //anEmpIdEmail.EmployeeID = row.StoreEmployeeID;
                        //anEmpIdEmail.Email = row.Email;

                        //empIdEmailToList.Add(anEmpIdEmail);

                        empIdEmailToList.Add(Model.Utilities.getStoreEmpIdEmail(row));
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                }
            }

            return empIdEmailToList;
        }

        public string getEmailBody(Model.Employee currEmp, string currDeptName, string newCollPtName, string changeThing)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getEmailBody(currEmp, currDeptName=" + currDeptName + ", newCollPtName=" + newCollPtName + ")");

            string emailBody = "Dear Sir / Madam,\r\n";
            emailBody += "Please be informed that ";
            emailBody += currDeptName;
            emailBody += " Department has changed their ";
            emailBody += changeThing;
            emailBody += " to ";
            emailBody += newCollPtName;
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
    }
}