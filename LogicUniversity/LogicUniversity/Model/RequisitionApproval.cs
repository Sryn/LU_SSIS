using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class RequisitionApproval
    {
        private int requisitionForm;
        private int requisitionItemID;
        private string employeeName;
        private string submittedDate;
        private string itemDescription;
        private string quantity;
        private string status;
        private string reason;
        private string unitOfMeasurement;

        public RequisitionApproval(int requisitionForm, int requisitionItemID, string employeeName, string submittedDate, string itemDescription, string quantity)
        {
            this.requisitionForm = requisitionForm;
            this.requisitionItemID = requisitionItemID;
            this.employeeName = employeeName;
            this.submittedDate = submittedDate;
            this.itemDescription = itemDescription;
            this.quantity = quantity;
        }
        public RequisitionApproval(int requisitionForm, int requisitionItemID, string employeeName, string submittedDate, string itemDescription, string quantity, string status, string reason)
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

        public RequisitionApproval(int requisitionItemID, string status, string reason)
        {

            this.requisitionItemID = requisitionItemID;
            this.status = status;
            this.reason = reason;
        }

        public int RequisitionForm
        {
            get
            {
                return requisitionForm;
            }

            set
            {
                requisitionForm = value;
            }
        }

        public int RequisitionItemID
        {
            get
            {
                return requisitionItemID;
            }

            set
            {
                requisitionItemID = value;
            }
        }
        public string EmployeeName
        {
            get
            {
                return employeeName;
            }

            set
            {
                employeeName = value;
            }
        }
        public string UnitOfMeasurement
        {
            get
            {
                return unitOfMeasurement;
            }

            set
            {
                unitOfMeasurement = value;
            }
        }

        public string SubmittedDate
        {
            get
            {
                return submittedDate;
            }

            set
            {
                submittedDate = value;
            }
        }

        public string ItemDescription
        {
            get
            {
                return itemDescription;
            }

            set
            {
                itemDescription = value;
            }
        }

        public string Quantity
        {
            get
            {
                return quantity;
            }

            set
            {
                quantity = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }

        public string Reason
        {
            get
            {
                return reason;
            }

            set
            {
                reason = value;
            }
        }
    }
}