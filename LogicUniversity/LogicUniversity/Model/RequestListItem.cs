using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class RequestListItem
    {
        private System.DateTime requestDate;
        private string requisitionForm;
        private string description;
        private string quantity;
        private string unitOfMeasure;
        private string status;

        public DateTime RequestDate
        {
            get
            {
                return requestDate;
            }

            set
            {
                requestDate = value;
            }
        }

        public string RequisitionForm
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

        public string Description
        {
            get
            {
                return description;
            }

            set
            {
                description = value;
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

        public string UnitOfMeasure
        {
            get
            {
                return unitOfMeasure;
            }

            set
            {
                unitOfMeasure = value;
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
    }
}