using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class RaisePOVoucherItem
    {
        private string category;
        private string description;
        private int quantity;
        private string unitOfMeasure;
        private decimal unitOfPrice;
        private decimal totalPrice;
        private string supplierID;
        private string itemID;
        private DateTime requiredDeliveryDate;

        public string Category
        {
            get
            {
                return category;
            }

            set
            {
                category = value;
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

        public int Quantity
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

        public decimal UnitOfPrice
        {
            get
            {
                return unitOfPrice;
            }

            set
            {
                unitOfPrice = value;
            }
        }

        public decimal TotalPrice
        {
            get
            {
                return totalPrice;
            }

            set
            {
                totalPrice = value;
            }
        }

        public string SupplierID
        {
            get
            {
                return supplierID;
            }

            set
            {
                supplierID = value;
            }
        }

        public string ItemID
        {
            get
            {
                return itemID;
            }

            set
            {
                itemID = value;
            }
        }

        public DateTime RequiredDeliveryDate
        {
            get
            {
                return requiredDeliveryDate;
            }

            set
            {
                requiredDeliveryDate = value;
            }
        }
    }
}