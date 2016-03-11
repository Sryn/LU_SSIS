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
        String result = "";

        private bool CheckLogin(string id, string password)
        {
            LoginControl loginController = new LoginControl();
            String s = loginController.Login(id, password);
            result = s;
            if (s.Equals("NotFound"))
            {
                return false;
            }
            else
            {
                return true;
            }

        }


        //03/09/2016
        public List<DisbursementItemView> getDisbursementsForAcknowledgement(String deptID, String userID, String pinValue)
        {
            deptID = decrypt(deptID);
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {
                DisbursementController disburmentController = new DisbursementController();
                List<DisbursementItemViewModel> listOfItems = disburmentController.getDisbursementItemsForAcknowledgement(deptID);
                List<DisbursementItemView> listOfReturnItems = new List<DisbursementItemView>();

                foreach (DisbursementItemViewModel item in listOfItems)
                {
                    listOfReturnItems.Add(new DisbursementItemView(item.BinCode, item.ItemID, item.ItemDescription, item.TotalNeededQty, item.Department, item.NeedQty, item.UnitOfMeasure, item.ActualQty, item.TotalReceived, item.DisbursementItemID, item.Status, "", ""));
                }


                return listOfReturnItems;
            }
            else
            {
                return new List<DisbursementItemView>();
            }

        }


        //03/09/2016
        public List<DisbursementInfo> getDisbursementsForAcknowledgementCollection(String userID, String pinValue)
        {

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {
                DisbursementController disbursementController = new DisbursementController();
                List<Disbursement> disbursementList = disbursementController.getDisbursementsForAcknowledgementCollection();
                List<DisbursementInfo> disbursementInfoList = new List<DisbursementInfo>();


                foreach (Disbursement item in disbursementList)
                {
                    String date = String.Format("{0:dd-MMM-yyyy} {1}", item.CollectionDate, item.CollectionPoint.Time);

                    disbursementInfoList.Add(new DisbursementInfo(item.DisbursementID, date, (int)item.CollectionPointID, item.AcknowledgeEmployeeID, item.Department.DepartmentName + "&&&" + item.DepartmentID, item.status, item.Employee.Name, item.CollectionPoint.CollectionPointName));
                }

                return disbursementInfoList;
            }
            else
            {
                return new List<DisbursementInfo>();
            }
        }


        //03/09/2016
        public string acknowledgeDisbursements(List<AcknowledgeObject> listForUpdate)
        {

            if (CheckLogin(listForUpdate[0].Id, listForUpdate[0].PinValue))
            {
                Acknowledge acknowledgeController = new Acknowledge();
                List<AcknowledgeModel> acknowledgeList = new List<AcknowledgeModel>();

                foreach (AcknowledgeObject item in listForUpdate)
                {
                    acknowledgeList.Add(new AcknowledgeModel(item.DisbursementId, item.AcknowledgeEmpId, item.DeptId, item.QuantityAccepted, item.ItemId));
                }


                return acknowledgeController.acknowledgeDisbursement(acknowledgeList);
            }
            else
            {
                return "999";
            }
        }



        public string updateDisbursementListAllocation(List<DisbursementItemView> listForUpdate)
        {
            if (CheckLogin(listForUpdate[0].Id, listForUpdate[0].PinValue))
            {
                DisbursementController disbursementController = new DisbursementController();
                List<DisbursementItemViewModel> disbursementItemViewModelList = new List<DisbursementItemViewModel>();

                foreach (DisbursementItemView item in listForUpdate)
                {
                    disbursementItemViewModelList.Add(new DisbursementItemViewModel(item.BinCode, item.ItemDescription, item.TotalNeededQty, item.Department, item.NeedQty, item.UnitOfMeasure, item.ActualQty, item.ItemID, item.TotalReceived, item.DisbursementItemID, item.Status));
                }

                return disbursementController.updateAllocation(disbursementItemViewModelList);
            }
            else
            {
                return "999";
            }
        }


        public List<DisbursementItemView> disbursementListByItem(String itemid, String userID, String pinValue)
        {
            itemid = decrypt(itemid);

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {


                DisbursementController disbursementController = new DisbursementController();
                List<DisbursementItemView> listOfDisbursementItemView = new List<DisbursementItemView>();
                List<DisbursementItemViewModel> listOfDisbursement = new List<DisbursementItemViewModel>();
                listOfDisbursement = disbursementController.requestDisbursementListByItem(itemid);


                foreach (DisbursementItemViewModel item in listOfDisbursement)
                {
                    DisbursementItemView temp = new DisbursementItemView(item.BinCode, item.ItemID, item.ItemDescription, item.TotalNeededQty, item.Department, item.NeedQty, item.UnitOfMeasure, item.ActualQty, item.TotalReceived, item.DisbursementItemID, item.Status, "", "");
                    listOfDisbursementItemView.Add(temp);
                }

                return listOfDisbursementItemView;
            }

            else
            {
                return new List<DisbursementItemView>();
            }
        }




        public List<ItemObject> getItemsInCategory(string cat, String userID, String pinValue)
        {
            cat = decrypt(cat);
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {




                RequestStationeryControl requestStationeryControl = new RequestStationeryControl();
                List<Item> itemList = requestStationeryControl.getItemByCatID(cat);
                List<ItemObject> itemObjectList = new List<ItemObject>();

                foreach (Item item in itemList)
                {

                    itemObjectList.Add(new ItemObject(item.ItemID, item.Description, item.Quantity, (int)item.CategoryID, (int)item.ReorderLevel, (int)item.ReorderQty, item.QRCode, item.BinNo));

                }

                return itemObjectList;
            }
            else
            {
                return new List<ItemObject>();
            }

        }



        public List<CategoryObject> getCategory(String userID, String pinValue)
        {

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {

                RequestStationeryControl requestStationeryControl = new RequestStationeryControl();
                List<Category> categoryList = requestStationeryControl.getAllCategory();
                List<CategoryObject> categoryObjectList = new List<CategoryObject>();

                foreach (Category item in categoryList)
                {
                    categoryObjectList.Add(new CategoryObject(item.CategoryName, item.CategoryID));
                }

                return categoryObjectList;
            }
            else
            {
                return new List<CategoryObject>();
            }
        }

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

        public EmployeeObject getEmployeeRole(String userID, String pinValue)
        {

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);
            String s = CheckLogin(userID, pinValue).ToString();
            if (CheckLogin(userID, pinValue))
            {
                LoginControl loginController = new LoginControl();
                Employee newEmployee = loginController.getEmployeeUserObject(userID);
                return new EmployeeObject(newEmployee.EmployeeID, newEmployee.PIN, newEmployee.Email, newEmployee.Name, newEmployee.DepartmentID, newEmployee.Role);
            }
            else
            {
                return new EmployeeObject("", "", "", "", "", "");
            }

        }

        public StoreEmpObject getStoreRole(String userID, String pinValue)
        {

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {
                LoginControl loginController = new LoginControl();
                StoreEmployee newEmployee = loginController.getStoreEmployeeUserObject(userID);
                return new StoreEmpObject(newEmployee.StoreEmployeeID, newEmployee.PIN, newEmployee.Email, newEmployee.Name, newEmployee.Role);
            }
            else
            {
                return new StoreEmpObject("", "", "", "", "");
            }

        }


        public List<NotificationList> getNotifications(String userID, String pinValue)
        {

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {

                NotiListControl notificationListController = new NotiListControl();
                List<NotificationList> notList = new List<NotificationList>();
                List<FilNotiLstEle> notListRetrieved = notificationListController.getFilteredNotificationList(userID);

                foreach (FilNotiLstEle notItem in notListRetrieved)
                {

                    NotificationList newItem = new NotificationList(notItem.dateTimeFilNoti.ToString(), notItem.msgFilNoti.ToString(), notItem.fromUserFilNoti.ToString());
                    notList.Add(newItem);
                }
                return notList;
            }
            else
            {
                return new List<NotificationList>();
            }

        }

        public string approveRequisitions(List<requisitionApprovals> approvalList)
        {

            if (CheckLogin(approvalList[0].Id, approvalList[0].PinValue))
            {


                RequisitionApprovalControl requistionApprovalController = new RequisitionApprovalControl();
                List<RequisitionApproval> listForApproval = new List<RequisitionApproval>();


                foreach (requisitionApprovals item in approvalList)
                {
                    listForApproval.Add(new RequisitionApproval(item.RequisitionForm, item.RequisitionItemID, item.EmployeeName, item.SubmittedDate, item.ItemDescription, item.Quantity, item.Status, item.Reason));
                }


                return requistionApprovalController.ApproveRequisition(listForApproval);
            }

            else

            {
                return "999";
            }

        }



        public List<requisitionApprovals> getListOfRequisition(String userID, String pinValue)
        {

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {


                RequisitionApprovalControl requistionApprovalController = new RequisitionApprovalControl();
                LoginControl loginController = new LoginControl();
                List<requisitionApprovals> list = new List<requisitionApprovals>();

                Employee staff = new Employee();
                staff = loginController.getEmployeeUserObject(userID);


                if (staff.Role.Equals("Department Head"))
                {
                    List<LogicUniversity.Model.RequisitionApproval> pendingApprovals = requistionApprovalController.getAllRequisitionToApprove(staff.DepartmentID);

                    foreach (RequisitionApproval pendingItem in pendingApprovals)
                    {
                        requisitionApprovals item = new requisitionApprovals(pendingItem.RequisitionForm, pendingItem.RequisitionItemID, pendingItem.EmployeeName, pendingItem.SubmittedDate, pendingItem.ItemDescription, pendingItem.Quantity, pendingItem.Status, pendingItem.Reason, pendingItem.UnitOfMeasurement, "", "");
                        list.Add(item);
                    }

                    return list;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return new List<requisitionApprovals>();
            }
        }

        public List<deptEmp> getDeptEmployees(String deptID, String userID, String pinValue)
        {

            deptID = decrypt(deptID);
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
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
            else
            {
                return new List<deptEmp>();
            }

        }



        public string changeRep(changeRepModel information)
        {
            if (CheckLogin(information.Id, information.PinValue))
            {
                ChangeRepresentativeControl representativeControl = new ChangeRepresentativeControl();
                return representativeControl.changeDeptRep(information.CurrentRep, information.NewRep);
            }
            else { return "999"; }
        }


        public CollectionLocation getCollectionPoint(String deptID, String userID, String pinValue)
        {

            deptID = decrypt(deptID);

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {


                CollectionPointControl collectionPtControl = new CollectionPointControl();
                CollectionPoint temp = collectionPtControl.getCollectionPoint(Convert.ToInt32(deptID));
                return new CollectionLocation(temp.CollectionPointID, temp.CollectionPointName, temp.Time, temp.FirstCollectionDate, temp.SecondCollectionDate);
            }
            else
            {
                return new CollectionLocation(0, "", "", "", "");

            }
        }


        public List<CollectionInformation> getAllCollectionInfo(String userID, String pinValue)
        {
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
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
            else
            {
                return new List<CollectionInformation>();
            }


        }


        public List<CollectionLocation> getCollectionInfo(String userID, String pinValue)
        {
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
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
            else
            {
                return new List<CollectionLocation>();
            }

        }


        public departmentInfo getDepartmentInfo(string id, String userID, String pinValue)
        {
            id = decrypt(id);
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {


                CollectionPointControl collectionControl = new CollectionPointControl();
                Department dept = collectionControl.getDepartment(id);

                return (new departmentInfo(dept.DepartmentID, dept.DepartmentName, Convert.ToInt32(dept.CollectionPointID)));
            }

            else
            {
                return (new departmentInfo("", "", 0));
            }
        }


        public EmployeeObject getDepartmentRep(string deptId, String userID, String pinValue)
        {
            deptId = decrypt(deptId);
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {
                CollectionPointControl collectionControl = new CollectionPointControl();
                Employee emp = collectionControl.getDeptRep(deptId);

                return (new EmployeeObject(emp.EmployeeID, emp.PIN, emp.Email, emp.Name, emp.DepartmentID, emp.Role));
            }
            else
            {
                return new EmployeeObject("", "", "", "", "", "");
            }
        }

        public int changeCollection(changePoint information)
        {
            if (CheckLogin(information.Id, information.PinValue))
            {
                CollectionPointControl collectionControl = new CollectionPointControl();

                return (collectionControl.changeCollectionPointForDept(information.DeptID, information.NewCollection));
            }
            else
            {
                return 999;
            }
        }

        public itemObject getItem(string itemID, String userID, String pinValue)
        {
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {

                UpdateInventoryControl inventoryControl = new UpdateInventoryControl();

                Item itemRetrieved = inventoryControl.getQuantity(itemID);

                return new itemObject(itemRetrieved.ItemID, itemRetrieved.Description,
                                      itemRetrieved.Quantity, itemRetrieved.UOM, itemRetrieved.CategoryID,
                                      itemRetrieved.ReorderLevel, itemRetrieved.Quantity, itemRetrieved.QRCode, itemRetrieved.BinNo);
            }
            else
            {
                return new itemObject("", "", 0, "", 0, 0, 0, "", "");

            }
        }

        public List<suppliersObject> getSuppliers(string itemCode, String userID, String pinValue)
        {
            itemCode = decrypt(itemCode);

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
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
            else
            {
                return new List<suppliersObject>();
            }
        }


        public string updateInventory(updateInventoryObject information)
        {
            if (CheckLogin(information.Id, information.PinValue))
            {
                UpdateInventoryControl inventoryControl = new UpdateInventoryControl();

                return inventoryControl.updateInventory(information.ItemID, information.SupplierID, information.Quantity);
            }
            else
            {
                return "999";
            }


        }

        public List<DisbursementInfo> getAllDeptDisbursements(String userID, String pinValue)
        {



            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {

                DisbursementDetailsController disbursementByDept = new DisbursementDetailsController();
                List<Model.DisbursementInformation> disbursementByDeptList = disbursementByDept.getDeptDisbursements(userID);

                return convertToDisbursementInfo(disbursementByDeptList);
            }
            else
            {
                return new List<DisbursementInfo>();
            }

        }



        public List<DisbursementInfo> getAllDisbursements(String userID, String pinValue)
        {
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {
                DisbursementDetailsController disbursementByDept = new DisbursementDetailsController();
                List<Model.DisbursementInformation> disbursementByDeptList = disbursementByDept.getAllDisbursements();

                return convertToDisbursementInfo(disbursementByDeptList);
            }
            else
            {
                return new List<DisbursementInfo>();
            }

        }

        public List<DisbursementDetailObject> getDisbursementDetail(string disbursementID, String userID, String pinValue
)
        {
            disbursementID = decrypt(disbursementID);

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
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
            else
            {
                return new List<DisbursementDetailObject>();
            }

        }


        public string forgotPassword(forgotPin empId)
        {
            EmailControl emailControl = new EmailControl();
            System.Diagnostics.Debug.WriteLine(empId.EmployeeId);
            return emailControl.sendEmailForForgotPIN(empId.EmployeeId);
        }


        public List<DisbursementItemView> getRequestListForDisbursement(String userID, String pinValue)
        {
            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {

                DisbursementController disbursementController = new DisbursementController();
                List<DisbursementItemView> listOfDisbursementItemView = new List<DisbursementItemView>();
                List<DisbursementItemViewModel> listOfDisbursement = new List<DisbursementItemViewModel>();
                listOfDisbursement = disbursementController.requestDisbursementList();


                foreach (DisbursementItemViewModel item in listOfDisbursement)
                {
                    DisbursementItemView temp = new DisbursementItemView(item.BinCode, item.ItemID, item.ItemDescription, item.TotalNeededQty, item.Department, item.NeedQty, item.UnitOfMeasure, item.ActualQty, item.TotalReceived, item.DisbursementItemID, item.Status, "", "");
                    listOfDisbursementItemView.Add(temp);
                }

                return listOfDisbursementItemView;
            }
            else
            {
                return new List<DisbursementItemView>();
            }
        }



        public string updateRetrieval(RetrievedObject update)
        {
            DisbursementController disbursementController = new DisbursementController();
            return disbursementController.updateCollectedQtyByItemID(update.ItemID, update.Qty);
        }


        public List<DisbursementItemView> getDeptDisbursements(string dept, string disbursementID, String userID, String pinValue)
        {
            dept = decrypt(dept);
            disbursementID = decrypt(disbursementID);

            userID = decrypt(userID);
            pinValue = decrypt(pinValue);

            if (CheckLogin(userID, pinValue))
            {


                DisbursementController disbursementController = new DisbursementController();
                List<DisbursementItemView> disbursementItemList = new List<DisbursementItemView>();
                List<DisbursementItemViewModel> disbursementItemViewList = new List<DisbursementItemViewModel>();

                disbursementItemViewList = disbursementController.requestDisbursementListbyDept(dept, Convert.ToInt32(disbursementID));

                foreach (DisbursementItemViewModel item in disbursementItemViewList)
                {
                    disbursementItemList.Add(new DisbursementItemView(item.BinCode, item.ItemID, item.ItemDescription, item.TotalNeededQty, item.Department, item.NeedQty, item.UnitOfMeasure, item.ActualQty, item.TotalReceived, item.DisbursementItemID, item.Status, "", ""));
                }

                return disbursementItemList;
            }
            else
            {
                return new List<DisbursementItemView>();
            }
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

        private String decrypt(String value)
        {
            String toEncrypt = "";
            char[] readChar = value.ToCharArray();


            for (int i = 0; i < readChar.Length; i++)
            {
                int no = (int)(readChar[i]);

                if (readChar[i] >= '0' && readChar[i] <= '9')
                {
                    no = 48 + (no - 5) % 10;
                }

                else if (readChar[i].ToString().Equals((readChar[i]).ToString().ToLower()))
                {
                    no = 97 + (no + 29) % 26;
                }
                else if ((readChar[i]).ToString().Equals((readChar[i]).ToString().ToUpper()))
                {
                    no = 65 + (no + 15) % 26;
                }


                String r = Char.ToString((char)no);
                toEncrypt = r + toEncrypt;
            }
            return toEncrypt;
        }


    }
}
