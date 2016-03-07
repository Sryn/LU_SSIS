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

        public EmployeeObject getEmployeeRole(String id)
        {
            LoginControl loginController = new LoginControl();
            Employee newEmployee = loginController.getEmployeeUserObject(id);
            return new EmployeeObject(newEmployee.EmployeeID, newEmployee.PIN, newEmployee.Email, newEmployee.Name, newEmployee.DepartmentID, newEmployee.Role);
        }

        public StoreEmpObject getStoreRole(String id)
        {
            LoginControl loginController = new LoginControl();
            StoreEmployee newEmployee = loginController.getStoreEmployeeUserObject(id);
            return new StoreEmpObject(newEmployee.StoreEmployeeID, newEmployee.PIN, newEmployee.Email, newEmployee.Name, newEmployee.Role);
        }


        public List<NotificationList> getNotifications(String id)
        {
            NotiListControl notificationListController = new NotiListControl();
            List<NotificationList> notList = new List<NotificationList>();
            List<FilNotiLstEle> notListRetrieved = notificationListController.getFilteredNotificationList(id);

            foreach (FilNotiLstEle notItem in notListRetrieved)
            {

                NotificationList newItem = new NotificationList(notItem.dateTimeFilNoti.ToString(), notItem.msgFilNoti.ToString(), notItem.fromUserFilNoti.ToString());
                notList.Add(newItem);
            }
            return notList;
        }

        public string approveRequisitions(List<requisitionApprovals> approvalList)
        {
            RequisitionApprovalControl requistionApprovalController = new RequisitionApprovalControl();
            List<RequisitionApproval> listForApproval = new List<RequisitionApproval>();


            foreach (requisitionApprovals item in approvalList)
            {
                listForApproval.Add(new RequisitionApproval(item.RequisitionForm, item.RequisitionItemID, item.EmployeeName, item.SubmittedDate, item.ItemDescription, item.Quantity, item.Status, item.Reason));
            }


            return requistionApprovalController.ApproveRequisition(listForApproval);

            //return requistionApprovalController.ApproveRequisition(listForApproval);
        }



        public List<requisitionApprovals> getListOfRequisition(string EmpId)
        {
            RequisitionApprovalControl requistionApprovalController = new RequisitionApprovalControl();
            LoginControl loginController = new LoginControl();
            List<requisitionApprovals> list = new List<requisitionApprovals>();

            Employee staff = new Employee();
            staff = loginController.getEmployeeUserObject(EmpId);


            if (staff.Role.Equals("Department Head"))
            {
                List<LogicUniversity.Model.RequisitionApproval> pendingApprovals = requistionApprovalController.getAllRequisitionToApprove(staff.DepartmentID);

                foreach (RequisitionApproval pendingItem in pendingApprovals)
                {
                    requisitionApprovals item = new requisitionApprovals(pendingItem.RequisitionForm, pendingItem.RequisitionItemID, pendingItem.EmployeeName, pendingItem.SubmittedDate, pendingItem.ItemDescription, pendingItem.Quantity, pendingItem.Status, pendingItem.Reason, pendingItem.UnitOfMeasurement);
                    list.Add(item);
                }

                return list;
            }
            else
            {
                return null;
            }
        }

        public List<deptEmp> getDeptEmployees(String deptID)
        {
            ChangeRepresentativeControl representativeControl = new ChangeRepresentativeControl();
            List<deptEmp> empdeptList = new List<deptEmp>();
            List<deptEmpDDL_Ele> retrievedList = representativeControl.getListDeptEmpsForDDL(deptID);

            foreach (deptEmpDDL_Ele item in retrievedList)
            {
                deptEmp newItem = new deptEmp(item.EmployeeID, item.combEmpNameID);
                empdeptList.Add(newItem);
            }

            return empdeptList;

        }



        public string changeRep(changeRepModel information)
        {
            ChangeRepresentativeControl representativeControl = new ChangeRepresentativeControl();
            return representativeControl.changeDeptRep(information.CurrentRep, information.NewRep);
        }


        public CollectionLocation getCollectionPoint(String deptID)
        {
            CollectionPointControl collectionPtControl = new CollectionPointControl();
            CollectionPoint temp = collectionPtControl.getCollectionPoint(Convert.ToInt32(deptID));
            return new CollectionLocation(temp.CollectionPointID, temp.CollectionPointName, temp.Time, temp.FirstCollectionDate, temp.SecondCollectionDate);
        }


        public List<CollectionInformation> getAllCollectionInfo()
        {
            CollectionInformationController collectioninfoController = new CollectionInformationController();
            List<CollectionInformation> collectionInfoList = new List<CollectionInformation>();

            List<Model.CollectionInformation> collectionList = new List<Model.CollectionInformation>();


            collectionList = collectioninfoController.getListCollectionInformation();

            foreach (Model.CollectionInformation item in collectionList)
            {
                collectionInfoList.Add(new CollectionInformation(item.EmployeeID, item.PIN, item.Email, item.Name, item.DepartmentID, item.Role, item.deptName, item.collectionPointName));
            }

            return collectionInfoList;


        }


        public List<CollectionLocation> getCollectionInfo()
        {
            CollectionPointControl collectionControl = new CollectionPointControl();
            List<CollectionPoint> listCollectionPoint = new List<CollectionPoint>();
            List<CollectionLocation> listCollectionLocation = new List<CollectionLocation>();

            listCollectionPoint = collectionControl.getListCollectionPoint();


            foreach (CollectionPoint item in listCollectionPoint)
            {
                listCollectionLocation.Add(new CollectionLocation(item.CollectionPointID, item.CollectionPointName, item.Time, item.FirstCollectionDate, item.SecondCollectionDate));
            }

            return listCollectionLocation;

        }


        public departmentInfo getDepartmentInfo(string id)
        {
            CollectionPointControl collectionControl = new CollectionPointControl();
            Department dept = collectionControl.getDepartment(id);

            return (new departmentInfo(dept.DepartmentID, dept.DepartmentName, Convert.ToInt32(dept.CollectionPointID)));
        }


        public EmployeeObject getDepartmentRep(string deptId)
        {
            CollectionPointControl collectionControl = new CollectionPointControl();
            Employee emp = collectionControl.getDeptRep(deptId);

            return (new EmployeeObject(emp.EmployeeID, emp.PIN, emp.Email, emp.Name, emp.DepartmentID, emp.Role));
        }

        public int changeCollection(changePoint information)
        {
            CollectionPointControl collectionControl = new CollectionPointControl();

            return (collectionControl.changeCollectionPointForDept(information.DeptID, information.NewCollection));
        }

        public itemObject getItem(string itemID)
        {
            UpdateInventoryControl inventoryControl = new UpdateInventoryControl();

            Item itemRetrieved = inventoryControl.getQuantity(itemID);

            return new itemObject(itemRetrieved.ItemID, itemRetrieved.Description,
                                  itemRetrieved.Quantity, itemRetrieved.UOM, itemRetrieved.CategoryID,
                                  itemRetrieved.ReorderLevel, itemRetrieved.Quantity, itemRetrieved.QRCode, itemRetrieved.BinNo);

        }

        public List<suppliersObject> getSuppliers(string itemCode)
        {
            UpdateInventoryControl inventoryControl = new UpdateInventoryControl();

            List<Suppliers> listSuppliers = inventoryControl.getSuppliers(itemCode);
            List<suppliersObject> listSuppliersObject = new List<suppliersObject>();

            foreach (Suppliers item in listSuppliers)
            {
                listSuppliersObject.Add(new suppliersObject(item.ItemID, item.SupplierID, item.Price, item.Priority, item.SupplierName));
            }

            return listSuppliersObject;
        }


        public string updateInventory(updateInventoryObject information)
        {
            UpdateInventoryControl inventoryControl = new UpdateInventoryControl();

            return inventoryControl.updateInventory(information.ItemID, information.SupplierID, information.Quantity);


        }

        public List<DisbursementInfo> getAllDeptDisbursements(String empId)
        {
            DisbursementDetailsController disbursementByDept = new DisbursementDetailsController();
            List<Model.DisbursementInformation> disbursementByDeptList = disbursementByDept.getDeptDisbursements(empId);

            return convertToDisbursementInfo(disbursementByDeptList);

        }



        public List<DisbursementInfo> getAllDisbursements()
        {
            DisbursementDetailsController disbursementByDept = new DisbursementDetailsController();
            List<Model.DisbursementInformation> disbursementByDeptList = disbursementByDept.getAllDisbursements();

            return convertToDisbursementInfo(disbursementByDeptList);

        }

        public List<DisbursementDetailObject> getDisbursementDetail(string disbursementID)
        {
            DisbursementDetailsController disbursementByDeptControl = new DisbursementDetailsController();
            List<Model.DisbursementDetail> disbursementList = disbursementByDeptControl.getDisbursementDetails(Convert.ToInt32(disbursementID));
            List<DisbursementDetailObject> itemList = new List<DisbursementDetailObject>();

            foreach (Model.DisbursementDetail item in disbursementList)
            {

                String date = String.Format("{0:dd-MMM-yyyy}", item.requestDate);

                DisbursementDetailObject temp = new DisbursementDetailObject(item.requestID, item.employeeName, item.itemDesc, item.quantity, date, item.UOM);
                itemList.Add(temp);
            }

            return itemList;

        }


        public string forgotPassword(forgotPin empId)
        {
            EmailControl emailControl = new EmailControl();
            System.Diagnostics.Debug.WriteLine(empId.EmployeeId);
            return emailControl.sendEmailForForgotPIN(empId.EmployeeId);
        }


        private List<DisbursementInfo> convertToDisbursementInfo(List<Model.DisbursementInformation> list)
        {
            List<DisbursementInfo> disbursementInfoByDeptList = new List<DisbursementInfo>();

            foreach (Model.DisbursementInformation item in list)
            {

                String date = String.Format("{0:dd-MMM-yyyy}", item.CollectionDate);

                DisbursementInfo temp = new DisbursementInfo((int)item.DisbursementID, date, (int)item.CollectionPointID, item.AcknowledgeEmployeeID, item.DepartmentID, item.status, item.acknowledgeEmployeeName, item.collectionPointName);
                disbursementInfoByDeptList.Add(temp);
            }

            return disbursementInfoByDeptList;
        }


    }
}
