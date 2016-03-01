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
        [WebInvoke(UriTemplate = "/Login", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string VerifyLogin(loginDetails value);


        [OperationContract]
        [WebInvoke(UriTemplate = "/ChangePin", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string changePassword(pinDetails value);


        [OperationContract]
        [WebGet(UriTemplate = "/GetRequisitions/{id}", ResponseFormat = WebMessageFormat.Json)]
        List<RequisitionApprovals> getListOfRequisition(String id);

        [OperationContract]
        [WebInvoke(UriTemplate = "/submitRequisitionApprovals", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        string approveRequisitions(List<RequisitionApprovals> approvalList);


        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
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

    public class RequisitionApprovals
    {
        private int requisitionForm;
        private int requisitionItemID;
        private string employeeName;
        private string submittedDate;
        private string itemDescription;
        private string quantity;
        private string status;
        private string reason;

        public RequisitionApprovals(int requisitionForm, int requisitionItemID, string employeeName, string submittedDate, string itemDescription, string quantity, string status, string reason)
        {
            this.requisitionForm = requisitionForm;
            this.requisitionItemID = requisitionItemID;
            this.employeeName = employeeName;
            this.submittedDate = submittedDate;
            this.itemDescription = itemDescription;
            this.quantity = quantity;
            this.status = status;
            this.reason = reason;
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

    }

}
