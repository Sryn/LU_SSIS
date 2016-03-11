using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class DisbursementDetail
    {
        public int requestID { get; set; }
        public string employeeName { get; set; }

        public string itemDesc { get; set; }

        public int quantity { get; set; }

        public DateTime requestDate { get; set; }

        public string UOM { get; set; }

        public DisbursementDetail()
        { }

    }

}