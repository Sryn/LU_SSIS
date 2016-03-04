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

        public static Department getDepartment(String deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getDepartment( deptID=" + deptID + ")");

            var context = new LogicUniversityEntities();

            Department rtnDept = context.Departments.Where(x => x.DepartmentID == deptID).FirstOrDefault();

            return rtnDept;
        }

        public static CollectionPoint getCollectionPoint(int collPtID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getCollectionPoint( collPtID=" + collPtID + ")");

            var context = new LogicUniversityEntities();

            CollectionPoint rtnCollPt = context.CollectionPoints.Where(x => x.CollectionPointID == collPtID).FirstOrDefault();

            return rtnCollPt;
        }

        public static List<CollectionPoint> getListCollectionPoint()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getListCollectionPoint()");

            var context = new LogicUniversityEntities();

            List<CollectionPoint> rtnCollPtList = context.CollectionPoints.ToList();

            return rtnCollPtList;
        }

        public static int changeCollectionPointForDept(string deptID, int newCollPt)
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

        public static Model.Employee getDeptRep(string deptID)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getListCollectionPoint()");

            Model.Employee deptRep = null;

            var context = new LogicUniversityEntities();

            deptRep = context.Employees.Where(x => x.DepartmentID == deptID && x.Role=="Representative").FirstOrDefault();

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
        public static string sendChangeCollectionPointNotifications(Employee currEmp, Department currDept, string newCollPtName)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.sendChangeCollectionPointNotifications(currEmp, currDept, newCollPtName=" + newCollPtName + ")");

            int successfulNotiSentCount = 0;

            string msg = "", emailSubject = "", emailBody = "", notiMsg = "", currDeptName, notiRtnMsg;

            List<Model.empIdEmail> empIdEmailToList = new List<Model.empIdEmail>(), empIdEmailCCList = new List<Model.empIdEmail>();

            List<String> justEmpEmailList = new List<String>();

            if (currDept != null)
            {
                currDeptName = currDept.DepartmentName;

                notiMsg = currDeptName + " Department has changed its collection point to " + newCollPtName;

                emailSubject = currDeptName + " Department changed its Collection Point to " + newCollPtName;

                emailBody = getEmailBody(currEmp, currDeptName, newCollPtName);

                empIdEmailToList = getAllStoreEmployeesIdEmailToList();

                empIdEmailCCList = getDeptHeadRepIdEmailList(currDept.DepartmentID);

                // don't do this as it sends to the entire CC list for every TO email sent
                // but I'm doing this temporarily until emailCtrl.SendEmail works with an email list for TO
                foreach (Model.empIdEmail empIdEmail in empIdEmailCCList)
                    empIdEmailToList.Add(empIdEmail);

                if (empIdEmailToList.Count != 0)
                {
                    // send an email one-by-one to every email listed in empIdEmailToList

                    RegexUtilities regexUtil = new RegexUtilities();
                    EmailControl emailCtrl = new EmailControl();

                    foreach (Model.empIdEmail empIdEmail in empIdEmailToList)
                    {
                        notiRtnMsg = sendNotification(empIdEmail.EmployeeID, notiMsg, currEmp.EmployeeID);

                        try{
                            successfulNotiSentCount += int.Parse(notiRtnMsg);
                        } catch(Exception e) {
                            System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                            msg += notiRtnMsg;
                        }

                        justEmpEmailList.Add(empIdEmail.Email);
                    }

                    msg += "; Notifications sent: " + successfulNotiSentCount;

                    //foreach (String empEmail in justEmpEmailList)
                    //{
                    string empEmail = currEmp.Email; // temporary until emailCtrl.SendEmail works with an email list for TO

                        if (regexUtil.IsValidEmail(empEmail))
                        {
                            // valid email, so send
                            try
                            {
                                emailCtrl.SendEmail(empEmail, emailSubject, emailBody, justEmpEmailList);

                                msg += "; Emails sent.";
                            }
                            catch (Exception e)
                            {
                                // send email error
                                System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                                msg += "\nSendEmail Exception caught for " + empEmail;
                            }
                        }
                        else
                        {
                            // invalid email found
                            msg += ", Invalid email: " + empEmail;
                        }
                    //}
                }
                else
                {
                    // ERROR: cannot get any recipient emails
                    msg += "ERROR: Cannot get any recipient emails.";
                }

            }
            else
            {
                // ERROR: no valid current department obtained
                msg += "ERROR: No valid current department information obtained.";
            }

            return msg;
        }

        public static string sendNotification(string toEmpID, string notiMsg, string fromEmpID)
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
                    rtnMsg += "\nERROR: sendNotification for empID=" + toEmpID;
                }
            }

            return rtnMsg;
        }

        public static List<Model.empIdEmail> getDeptHeadRepIdEmailList(string deptID)
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
                            Model.empIdEmail anEmpIdEmail = new Model.empIdEmail();

                            anEmpIdEmail.EmployeeID = row.EmployeeID;
                            anEmpIdEmail.Email = row.Email;

                            deptHeadRepIdEmailList.Add(anEmpIdEmail);
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

        private static List<Model.empIdEmail> getAllStoreEmployeesIdEmailToList()
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getAllStoreEmployeesIdEmailToList()");

            List<Model.empIdEmail> empIdEmailToList = new List<Model.empIdEmail>();

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    foreach (StoreEmployee row in context.StoreEmployees)
                    {
                        Model.empIdEmail anEmpIdEmail = new Model.empIdEmail();

                        anEmpIdEmail.EmployeeID = row.StoreEmployeeID;
                        anEmpIdEmail.Email = row.Email;

                        empIdEmailToList.Add(anEmpIdEmail);
                    }
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR: Exception Caught e=" + e);
                }
            }

            return empIdEmailToList;
        }

        private static string getEmailBody(Model.Employee currEmp, string currDeptName, string newCollPtName)
        {
            System.Diagnostics.Debug.WriteLine(">> CollectionPointControl.getEmailBody(currEmp, currDeptName=" + currDeptName + ", newCollPtName=" + newCollPtName + ")");

            string emailBody = "Dear Sir / Madam,\r\n";
            emailBody += "Please be informed that ";
            emailBody += currDeptName;
            emailBody += " Department has changed their collection point to ";
            emailBody += newCollPtName;
            emailBody += ".\r\n";
            emailBody += "This is a system generated email, please do not reply.\r\n\r\n";

            if (currEmp != null)
            {
                emailBody += "Change made by ";
                emailBody += Control.ChangeRepresentativeControl.getCombEmpNameID(currEmp.EmployeeID, currEmp.Name);
                emailBody += ".\r\n";
            }

            return emailBody;
        }
    }
}