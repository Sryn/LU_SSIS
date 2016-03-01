using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using LogicUniversity.Model;
using LogicUniversity.Control;

namespace LogicUniversity
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string VerifyLogin(loginDetails value)
        {
            LoginControl checkLogin = new LoginControl();
            return checkLogin.Login(value.Id, value.PinValue);
        }

        public string changePassword(pinDetails value)
        {
            LoginControl loginController = new LoginControl();

            Object staffObject = new Object();
            string staffType = "";

            if (value.UserID.Substring(0, 1).Equals("E"))
            {
                staffObject = loginController.getEmployeeUserObject(value.UserID);
                staffType = "Employee";
            }
            else
            {
                staffObject = loginController.getStoreEmployeeUserObject(value.UserID);
                staffType = "StoreEmployee";
            }

            return loginController.ChangePIN(staffObject, staffType, value.OldPin, value.NewPin);

        }


        public string approveRequisitions(List<RequisitionApprovals> approvalList)
        {
            RequisitionApprovalControl requistionApprovalController = new RequisitionApprovalControl();
            List<RequisitionApproval> listForApproval = new List<RequisitionApproval>();

            foreach (RequisitionApprovals item in approvalList)
            {
                RequisitionApproval newItem = new RequisitionApproval(item.RequisitionForm, item.RequisitionItemID, item.EmployeeName, item.SubmittedDate, item.ItemDescription, item.Quantity, item.Status, item.Reason);
                listForApproval.Add(newItem);
            }

            return requistionApprovalController.ApproveRequisition(listForApproval);
        }



        public List<RequisitionApprovals> getListOfRequisition(string EmpId)
        {
            RequisitionApprovalControl requistionApprovalController = new RequisitionApprovalControl();
            LoginControl loginController = new LoginControl();
            List<RequisitionApprovals> list = new List<RequisitionApprovals>();

            Employee staff = new Employee();
            staff = loginController.getEmployeeUserObject(EmpId);


            if (staff.Role.Equals("Department Head"))
            {
                List<LogicUniversity.Model.RequisitionApproval> pendingApprovals = requistionApprovalController.getAllRequisitionToApprove(staff.DepartmentID);

                foreach (RequisitionApproval pendingItem in pendingApprovals)
                {
                    RequisitionApprovals item = new RequisitionApprovals(pendingItem.RequisitionForm, pendingItem.RequisitionItemID, pendingItem.EmployeeName, pendingItem.SubmittedDate, pendingItem.ItemDescription, pendingItem.Quantity, pendingItem.Status, pendingItem.Reason);
                    list.Add(item);
                }

                return list;
            }
            else
            {
                return null;
            }
        }

    }
}
