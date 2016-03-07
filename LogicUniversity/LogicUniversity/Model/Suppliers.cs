using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class Suppliers
    {
        private string itemID;
        private string supplierID;
        private decimal? price;
        private int? priority;
        private string supplierName;


        public Suppliers(string itemID, string supplierID, decimal? price, int? priority, string supplierName)
        {
            this.itemID = itemID;
            this.supplierID = supplierID;
            this.price = price;
            this.priority = priority;
            this.supplierName = supplierName;
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

        public decimal? Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int? Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return supplierName;
            }

            set
            {
                supplierName = value;
            }
        }
    }
}