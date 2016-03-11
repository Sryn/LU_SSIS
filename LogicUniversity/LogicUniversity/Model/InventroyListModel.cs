using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class InventroyListModel
    {
        private string binID;
        private string itemID;
        private string category;
        private string itemDescription;
        private int quantity;
        private string unitOfMeasure;
        private int reorderLevel;
        private int reorderQty;
        private string remark;
        private int accumulatedRequest;

        public string BinID
        {
            get
            {
                return binID;
            }

            set
            {
                binID = value;
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

        public int ReorderLevel
        {
            get
            {
                return reorderLevel;
            }

            set
            {
                reorderLevel = value;
            }
        }

        public int ReorderQty
        {
            get
            {
                return reorderQty;
            }

            set
            {
                reorderQty = value;
            }
        }

        public string Remark
        {
            get
            {
                return remark;
            }

            set
            {
                remark = value;
            }
        }

        public int AccumulatedRequest
        {
            get
            {
                return accumulatedRequest;
            }

            set
            {
                accumulatedRequest = value;
            }
        }
    }
}