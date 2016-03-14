using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class NotCollectedModel
    {
        private string department;
        private string collectionDate;
        private string collectionPoint;
        private string itemDescription;
        private string quantity;
        private int disbursementID;

        public string Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }

        public string CollectionDate
        {
            get
            {
                return collectionDate;
            }

            set
            {
                collectionDate = value;
            }
        }

        public string CollectionPoint
        {
            get
            {
                return collectionPoint;
            }

            set
            {
                collectionPoint = value;
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

        public int DisbursementID
        {
            get
            {
                return disbursementID;
            }

            set
            {
                disbursementID = value;
            }
        }
    }
}