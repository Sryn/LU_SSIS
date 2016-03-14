using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class DisbursementItemViewModel
    {
        private string binCode;
        private string itemID;
        private string itemDescription;
        private int totalNeededQty;
        private string department;
        private int needQty;
        private string unitOfMeasure;
        private int actualQty;
        private int totalReceived;
        private int disbursementItemID;
        private string status;

        public int DisbursementItemID
        {
            get { return disbursementItemID; }
            set { disbursementItemID = value; }
        }

        public DisbursementItemViewModel()
        {

        }


        public DisbursementItemViewModel(string binCode, string itemDescription, int totalNeededQty, string department, int needQty, string unitOfMeasure, int actualQty, string itemID, int totalReceived, int disbursementItemID, string status)
        {
            this.binCode = binCode;
            this.itemDescription = itemDescription;
            this.totalNeededQty = totalNeededQty;
            this.department = department;
            this.needQty = needQty;
            this.unitOfMeasure = unitOfMeasure;
            this.actualQty = actualQty;
            this.itemID = itemID;
            this.totalReceived = totalReceived;
            this.disbursementItemID = disbursementItemID;
            this.status = status;
        }

        public int TotalReceived
        {
            get
            {
                return totalReceived;
            }

            set
            {
                totalReceived = value;
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
        public string BinCode
        {
            get
            {
                return binCode;
            }

            set
            {
                binCode = value;
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

        public int TotalNeededQty
        {
            get
            {
                return totalNeededQty;
            }

            set
            {
                totalNeededQty = value;
            }
        }

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

        public int NeedQty
        {
            get
            {
                return needQty;
            }

            set
            {
                needQty = value;
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

        public int ActualQty
        {
            get
            {
                return actualQty;
            }

            set
            {
                actualQty = value;
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