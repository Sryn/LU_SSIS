using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


namespace LogicUniversity
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        [WebInvoke(UriTemplate = "/ForgotPIN", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string forgotPassword(forgotPin empId);


        [OperationContract]
        [WebInvoke(UriTemplate = "/Login", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string VerifyLogin(loginDetails value);


        [OperationContract]
        [WebInvoke(UriTemplate = "/ChangePin", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string changePassword(pinDetails value);

        [OperationContract]
        [WebGet(UriTemplate = "/GetEmployeeRole/{id}", ResponseFormat = WebMessageFormat.Json)]
        EmployeeObject getEmployeeRole(String id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetStoreRole/{id}", ResponseFormat = WebMessageFormat.Json)]
        StoreEmpObject getStoreRole(String id);


        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitions/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<requisitionApprovals> getListOfRequisition(String id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/submitRequisitionApprovals", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string approveRequisitions(List<requisitionApprovals> approvalList);

        [OperationContract]
        [WebGet(UriTemplate = "/GetNotifications/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<NotificationList> getNotifications(String id);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDeptEmployees/{deptID}", ResponseFormat = WebMessageFormat.Json)]
        List<deptEmp> getDeptEmployees(String deptID);


        [OperationContract]
        [WebInvoke(UriTemplate = "/ChangeRep", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string changeRep(changeRepModel information);

        [OperationContract]
        [WebGet(UriTemplate = "/GetCollectionInfo", ResponseFormat = WebMessageFormat.Json)]
        List<CollectionLocation> getCollectionInfo();


        [OperationContract]
        [WebGet(UriTemplate = "/GetCollectionPoint/{collectionPointID}", ResponseFormat = WebMessageFormat.Json)]
        CollectionLocation getCollectionPoint(string collectionPointID);


        [OperationContract]
        [WebGet(UriTemplate = "/GetAllCollectionInfo", ResponseFormat = WebMessageFormat.Json)]
        List<CollectionInformation> getAllCollectionInfo();

        [OperationContract]
        [WebGet(UriTemplate = "/GetDisbursement/{empID}", ResponseFormat = WebMessageFormat.Json)]
        List<DisbursementInfo> getAllDeptDisbursements(String empID);


        [OperationContract]
        [WebGet(UriTemplate = "/GetAllDisbursement", ResponseFormat = WebMessageFormat.Json)]
        List<DisbursementInfo> getAllDisbursements();



        [OperationContract]
        [WebGet(UriTemplate = "/GetDepartmentInfo/{deptId}", ResponseFormat = WebMessageFormat.Json)]
        departmentInfo getDepartmentInfo(string deptId);


        [OperationContract]
        [WebGet(UriTemplate = "/GetDepartmentRep/{deptId}", ResponseFormat = WebMessageFormat.Json)]
        EmployeeObject getDepartmentRep(string deptId);

        [OperationContract]
        [WebInvoke(UriTemplate = "/ChangeCollectionPoint", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        int changeCollection(changePoint information);

        [OperationContract]
        [WebGet(UriTemplate = "/GetItem/{itemCode}", ResponseFormat = WebMessageFormat.Json)]
        itemObject getItem(string itemCode);

        [OperationContract]
        [WebGet(UriTemplate = "/GetSuppliers/{itemCode}", ResponseFormat = WebMessageFormat.Json)]
        List<suppliersObject> getSuppliers(string itemCode);

        [OperationContract]
        [WebGet(UriTemplate = "/GetDisbursementDetails/{disbursementID}", ResponseFormat = WebMessageFormat.Json)]
        List<DisbursementDetailObject> getDisbursementDetail(string disbursementID);


        [OperationContract]
        [WebInvoke(UriTemplate = "/UpdateInventory", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string updateInventory(updateInventoryObject information);

        // TODO: Add your service operations here
    }




    [DataContract]
    public class forgotPin
    {
        private string employeeId;


        public forgotPin(string employeeId)
        {
            this.employeeId = employeeId;
        }


        [DataMember]
        public string EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

    }







    [DataContract]
    public class DisbursementDetailObject
    {
        private int requestId;
        private string employee;
        private string itemDesc;
        private int quantity;
        private string requestDate;
        private string uom;


        public DisbursementDetailObject(int requestId, string employee, string itemDesc, int quantity, string requestDate, string uom)
        {
            this.requestId = requestId;
            this.employee = employee;
            this.itemDesc = itemDesc;
            this.quantity = quantity;
            this.requestDate = requestDate;
            this.uom = uom;
        }

        [DataMember]
        public string Uom
        {
            get { return uom; }
            set { uom = value; }
        }


        [DataMember]
        public int RequestId
        {
            get { return requestId; }
            set { requestId = value; }
        }

        [DataMember]
        public string Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        [DataMember]
        public string ItemDesc
        {
            get { return itemDesc; }
            set { itemDesc = value; }
        }

        [DataMember]
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string RequestDate
        {
            get { return requestDate; }
            set { requestDate = value; }
        }

    }















    [DataContract]
    public class updateInventoryObject
    {
        private string itemID;
        private string supplierID;
        private int? quantity;

        public updateInventoryObject(string itemID, string supplierID, int? quantity)
        {
            this.itemID = itemID;
            this.supplierID = supplierID;
            this.quantity = quantity;
        }

        [DataMember]
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        [DataMember]
        public string SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }

        [DataMember]
        public int? Quantity
        {
            get { return quantity; }
            set { quantity = (int?)value; }
        }

    }


    [DataContract]
    public class suppliersObject
    {
        private string itemID;
        private string supplierID;
        private decimal? price;
        private int? priority;
        private string supplierName;

        public suppliersObject(string itemID, string supplierID, decimal? price, int? priority, string supplierName)
        {
            this.itemID = itemID;
            this.supplierID = supplierID;
            this.price = price;
            this.priority = priority;
            this.supplierName = supplierName;
        }

        [DataMember]
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        [DataMember]
        public string SupplierID
        {
            get { return supplierID; }
            set { supplierID = value; }
        }

        [DataMember]
        public decimal? Price
        {
            get { return price; }
            set { price = value; }
        }

        [DataMember]
        public int? Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        [DataMember]
        public string SupplierName
        {
            get { return supplierName; }
            set { supplierName = value; }
        }

    }



    [DataContract]
    public class itemObject
    {
        private string itemID;
        private string description;
        private int? quantity;
        private string uom;
        private int? categoryID;
        private int? reorderLevel;
        private int? reorderQty;
        private string qrCode;
        private string binCode;


        public itemObject(string itemID, string description, int? quantity, string uom, int? categoryID, int? reorderLevel, int? reorderQty, string qrCode, string binCode)
        {
            this.itemID = itemID;
            this.description = description;
            this.quantity = quantity;
            this.uom = uom;
            this.categoryID = categoryID;
            this.reorderLevel = reorderLevel;
            this.reorderQty = reorderQty;
            this.qrCode = qrCode;
            this.binCode = binCode;
        }


        public itemObject()
        {

        }


        [DataMember]
        public string ItemID
        {
            get { return itemID; }
            set { itemID = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public int? Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [DataMember]
        public string Uom
        {
            get { return uom; }
            set { uom = value; }
        }

        [DataMember]
        public int? CategoryID
        {
            get { return categoryID; }
            set { categoryID = value; }
        }


        [DataMember]
        public int? ReorderLevel
        {
            get { return reorderLevel; }
            set { reorderLevel = value; }
        }

        [DataMember]
        public int? ReorderQty
        {
            get { return reorderQty; }
            set { reorderQty = value; }
        }

        [DataMember]
        public string QrCode
        {
            get { return qrCode; }
            set { qrCode = value; }
        }

        [DataMember]
        public string BinCode
        {
            get { return binCode; }
            set { binCode = value; }
        }
    }


    [DataContract]
    public class loginDetails
    {
        private string id = "";
        private string pinValue = "";


        public loginDetails(string id, string Value)
        {
            this.id = id;
            this.pinValue = Value;
        }

        [DataMember]
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string PinValue
        {
            get { return pinValue; }
            set { pinValue = value; }
        }
    }

    [DataContract]
    public class changePoint
    {
        string deptID;
        int newCollection;

        public changePoint(string deptID, int newCollection)
        {
            this.deptID = deptID;
            this.newCollection = newCollection;
        }

        [DataMember]
        public string DeptID
        {
            get { return deptID; }
            set { deptID = value; }
        }

        [DataMember]
        public int NewCollection
        {
            get { return newCollection; }
            set { newCollection = value; }
        }

    }

    [DataContract]
    public class pinDetails
    {
        string userID = "";
        string oldPin = "";
        string newPin = "";


        public pinDetails(string userID, string oldPin, string newPin)
        {
            this.userID = userID;
            this.oldPin = oldPin;
            this.newPin = newPin;
        }

        [DataMember]
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        [DataMember]
        public string OldPin
        {
            get { return oldPin; }
            set { oldPin = value; }
        }

        [DataMember]
        public string NewPin
        {
            get { return newPin; }
            set { newPin = value; }
        }

    }


    [DataContract]
    public class requisitionApprovals
    {
        private int requisitionForm;
        private int requisitionItemID;
        private string employeeName;
        private string submittedDate;
        private string itemDescription;
        private string quantity;
        private string status;
        private string reason;
        private string uom;

        public requisitionApprovals(int requisitionForm, int requisitionItemID, string employeeName, string submittedDate, string itemDescription, string quantity, string status, string reason, string uom)
        {
            this.requisitionForm = requisitionForm;
            this.requisitionItemID = requisitionItemID;
            this.employeeName = employeeName;
            this.submittedDate = submittedDate;
            this.itemDescription = itemDescription;
            this.quantity = quantity;
            this.status = status;
            this.reason = reason;
            this.uom = uom;
        }

        [DataMember]
        public int RequisitionForm
        {
            get { return requisitionForm; }
            set { requisitionForm = value; }
        }

        [DataMember]
        public int RequisitionItemID
        {
            get { return requisitionItemID; }
            set { requisitionItemID = value; }
        }

        [DataMember]
        public string EmployeeName
        {
            get { return employeeName; }
            set { employeeName = value; }
        }

        [DataMember]
        public string SubmittedDate
        {
            get { return submittedDate; }
            set { submittedDate = value; }
        }

        [DataMember]
        public string ItemDescription
        {
            get { return itemDescription; }
            set { itemDescription = value; }
        }

        [DataMember]
        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }


        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }

        [DataMember]
        public string Uom
        {
            get { return uom; }
            set { uom = value; }
        }


    }

    [DataContract]
    public class NotificationList
    {
        private string dateReceived;
        private string message;
        private string fromUser;

        public NotificationList(string dateReceived, string message, string fromUser)
        {
            this.dateReceived = dateReceived;
            this.message = message;
            this.fromUser = fromUser;
        }

        [DataMember]
        public string DateReceived
        {
            get { return dateReceived; }
            set { dateReceived = value; }
        }

        [DataMember]
        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        [DataMember]
        public string FromUser
        {
            get { return fromUser; }
            set { fromUser = value; }
        }

    }

    [DataContract]
    public class EmployeeObject
    {
        private string employeeID;
        private string pin;
        private string email;
        private string name;
        private string departmentid;
        private string role;

        public EmployeeObject(string employeeID, string pin, string email, string name, string departmentid, string role)
        {
            this.employeeID = employeeID;
            this.pin = pin;
            this.email = email;
            this.name = name;
            this.departmentid = departmentid;
            this.role = role;
        }

        [DataMember]
        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [DataMember]
        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Departmentid
        {
            get { return departmentid; }
            set { departmentid = value; }
        }

        [DataMember]
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

    }

    [DataContract]
    public class CollectionInformation
    {
        private string employeeID;
        private string pin;
        private string email;
        private string name;
        private string departmentid;
        private string role;
        private string deptName;
        private string collectionPtName;

        public CollectionInformation(string employeeID, string pin, string email, string name, string departmentid, string role, string deptName, string collectionPtName)
        {
            this.employeeID = employeeID;
            this.pin = pin;
            this.email = email;
            this.name = name;
            this.departmentid = departmentid;
            this.role = role;
            this.deptName = deptName;
            this.collectionPtName = collectionPtName;
        }

        [DataMember]
        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [DataMember]
        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Departmentid
        {
            get { return departmentid; }
            set { departmentid = value; }
        }

        [DataMember]
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

        [DataMember]
        public string DeptName
        {
            get { return deptName; }
            set { deptName = value; }
        }

        [DataMember]
        public string CollectionPtName
        {
            get { return collectionPtName; }
            set { collectionPtName = value; }
        }



    }




    [DataContract]
    public class StoreEmpObject
    {
        private string storeEmpID;
        private string pin;
        private string email;
        private string name;
        private string role;

        public StoreEmpObject(string storeEmpID, string pin, string email, string name, string role)
        {
            this.storeEmpID = storeEmpID;
            this.pin = pin;
            this.email = email;
            this.name = name;
            this.role = role;
        }

        [DataMember]
        public string StoreEmpID
        {
            get { return storeEmpID; }
            set { storeEmpID = value; }
        }

        [DataMember]
        public string Pin
        {
            get { return pin; }
            set { pin = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }


        [DataMember]
        public string Role
        {
            get { return role; }
            set { role = value; }
        }

    }





    [DataContract]
    public class deptEmp
    {
        private string employeeID;
        private string empAndDept;

        public deptEmp(string employeeID, string empAndDept)
        {
            this.employeeID = employeeID;
            this.empAndDept = empAndDept;
        }

        [DataMember]
        public string EmployeeID
        {
            get { return employeeID; }
            set { employeeID = value; }
        }

        [DataMember]
        public string EmpAndDept
        {
            get { return empAndDept; }
            set { empAndDept = value; }
        }


    }

    [DataContract]
    public class changeRepModel
    {
        private string currentRep = "";
        private string newRep = "";


        public changeRepModel(string currentRep, string newRep)
        {
            this.currentRep = currentRep;
            this.newRep = newRep;
        }

        [DataMember]
        public string CurrentRep
        {
            get { return currentRep; }
            set { currentRep = value; }
        }

        [DataMember]
        public string NewRep
        {
            get { return newRep; }
            set { newRep = value; }
        }
    }

    [DataContract]
    public class departmentInfo
    {
        private string departmentID;
        private string departmentName;
        private int? collectionPointID;


        public departmentInfo(string departmentID, string departmentName, int? collectionPointID)
        {
            this.departmentID = departmentID;
            this.departmentName = departmentName;
            this.collectionPointID = collectionPointID;

        }
        [DataMember]
        public string DepartmentID
        {
            get { return departmentID; }
            set { departmentID = value; }
        }

        [DataMember]
        public string DepartmentName
        {
            get { return departmentName; }
            set { departmentName = value; }
        }

        [DataMember]
        public int? CollectionPointID
        {
            get { return collectionPointID; }
            set { collectionPointID = value; }
        }

    }





    [DataContract]
    public class CollectionLocation
    {
        private int id;
        private string name;
        private string time;
        private string firstCollectionDate;
        private string secondCollectionDate;


        public CollectionLocation(int id, string name, string time, string firstCollectionDate, string secondCollectionDate)
        {
            this.id = id;
            this.name = name;
            this.time = time;
            this.firstCollectionDate = firstCollectionDate;
            this.secondCollectionDate = secondCollectionDate;

        }

        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Time
        {
            get { return time; }
            set { time = value; }
        }

        [DataMember]
        public string FirstCollectionDate
        {
            get { return firstCollectionDate; }
            set { firstCollectionDate = value; }
        }

        [DataMember]
        public string SecondCollectionDate
        {
            get { return secondCollectionDate; }
            set { secondCollectionDate = value; }
        }


    }


    [DataContract]
    public class DisbursementInfo
    {
        private int? disbursementId;
        private string collectionDate;
        private int? collectionPointId;
        private string acknowledgeEmployeeId;
        private string departmentId;
        private string status;
        private string acknowledgeEmployeeName;
        private string collectionPointName;

        public DisbursementInfo(int disbursementId, string collectionDate, int collectionPointId, string acknowledgeEmployeeId, string departmentId, string status, string acknowledgeEmployeeName, string collectionPointName)
        {
            this.disbursementId = disbursementId;
            this.collectionDate = collectionDate;
            this.collectionPointId = collectionPointId;
            this.acknowledgeEmployeeId = acknowledgeEmployeeId;
            this.departmentId = departmentId;
            this.status = status;
            this.acknowledgeEmployeeName = acknowledgeEmployeeName;
            this.collectionPointName = collectionPointName;
        }

        [DataMember]
        public int? DisbursementId
        {
            get { return disbursementId; }
            set { disbursementId = value; }
        }

        [DataMember]
        public string CollectionDate
        {
            get { return collectionDate; }
            set { collectionDate = value; }
        }

        [DataMember]
        public int? CollectionPointId
        {
            get { return collectionPointId; }
            set { collectionPointId = value; }
        }

        [DataMember]
        public string AcknowledgeEmployeeId
        {
            get { return acknowledgeEmployeeId; }
            set { acknowledgeEmployeeId = value; }
        }

        [DataMember]
        public string DepartmentId
        {
            get { return departmentId; }
            set { departmentId = value; }
        }

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }


        [DataMember]
        public string AcknowledgeEmployeeName
        {
            get { return acknowledgeEmployeeName; }
            set { acknowledgeEmployeeName = value; }
        }

        [DataMember]
        public string CollectionPointName
        {
            get { return collectionPointName; }
            set { collectionPointName = value; }
        }


    }

}