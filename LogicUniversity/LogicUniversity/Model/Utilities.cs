﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity.Validation;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;
using System.Data.Metadata.Edm;

namespace LogicUniversity.Model
{
    public struct FilNotiLstEle
    {
        public String dateTimeFilNoti { get; set; }
        public String msgFilNoti { get; set; }
        public String fromUserFilNoti { get; set; }
    }

    public struct deptEmpDDL_Ele
    {
        public String EmployeeID { get; set; }

        public String combEmpNameID { get; set; }
    }

    // used in CollectionPointControl for having an email and 
    // empID list of both ModelEmployees and Model.StoreEmployees
    public struct empIdEmail 
    {
        public String EmployeeID { get; set; }

        public String Email { get; set; }
    }

    public partial class LogicUniversityEntities
    {
        // https://blogs.infosupport.com/improving-dbentityvalidationexception/

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }
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

        public static empIdEmail getEmpIdEmail(Employee anEmployee)
        {
            System.Diagnostics.Debug.WriteLine(">> Utilities.getEmpIdEmail(anEmployee)");
            //throw new NotImplementedException();

            empIdEmail anEmpIdEmail = new empIdEmail();

            if (anEmployee != null)
            {
                anEmpIdEmail.EmployeeID = anEmployee.EmployeeID;
                anEmpIdEmail.Email = anEmployee.Email;
            }

            return anEmpIdEmail;
        }

        public static empIdEmail getStoreEmpIdEmail(StoreEmployee aStoreEmployee)
        {
            System.Diagnostics.Debug.WriteLine(">> Utilities.getStoreEmpIdEmail(aStoreEmployee)");
            //throw new NotImplementedException();

            empIdEmail anEmpIdEmail = new empIdEmail();

            if (aStoreEmployee != null)
            {
                anEmpIdEmail.EmployeeID = aStoreEmployee.StoreEmployeeID;
                anEmpIdEmail.Email = aStoreEmployee.Email;
            }

            return anEmpIdEmail;
        }

        // Usage example:
        // int colMaxLength = Model.Utilities.GetColumnMaxLength<Notification>(x => x.Message);
        // https://noobsysadmin.wordpress.com/2013/07/30/get-max-column-length-entity-framework-5/
        /// <summary>
        /// Gets the Maximum Length of a column table in Entity Framework 5
        /// Original from SO:
        /// http://stackoverflow.com/questions/12378186/entity-framework-5-maxlength/12964634#12964634
        /// You need to add a reference to System.Linq.Expressions
        /// Also these:
        /// using System.Data.Entity.Infrastructure;
        /// using System.Data.Metadata.Edm;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="column"></param>
        /// <returns></returns>
        public static int GetColumnMaxLength<T>(Expression<Func<T, string>> column)
        {
            int result = 0;
            //var modelContext = new Models.MyContext();///<=Your model context
            var modelContext = new LogicUniversityEntities();///<=Your model context
            var objectContext = ((IObjectContextAdapter)modelContext).ObjectContext;
            using (objectContext)
            {
                var entType = typeof(T);
                var columnName = ((MemberExpression)column.Body).Member.Name;

                var test = objectContext.MetadataWorkspace.GetItems(DataSpace.CSpace);

                if (test == null)
                    return 0;

                var q = test
                    .Where(m => m.BuiltInTypeKind == BuiltInTypeKind.EntityType)
                    .SelectMany(meta => ((EntityType)meta).Properties
                    .Where(p => p.Name == columnName && p.TypeUsage.EdmType.Name == "String"));

                var queryResult = q.Where(p =>
                {
                    var match = p.DeclaringType.Name == entType.Name;
                    if (!match)
                        match = entType.Name == p.DeclaringType.Name;

                    return match;

                })
                    .Select(sel => sel.TypeUsage.Facets["MaxLength"].Value)
                    .ToList();

                if (queryResult.Any())
                    result = Convert.ToInt32(queryResult.First());

                return result;
            }
        }

    }

}