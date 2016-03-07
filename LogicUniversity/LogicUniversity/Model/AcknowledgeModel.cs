using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Model
{
    public class AcknowledgeModel
    {
        public int disbursementId { get; set; }
        public string acknowledgeEmpId { get; set; }
        public string deptId { get; set; }
        public int quantityAccepted { get; set; }
        public string itemId { get; set; }


        public AcknowledgeModel(int disbursementId, string acknowledgeEmpId, string deptId, int quantityAccepted, string itemId)
        {
            this.disbursementId = disbursementId;
            this.acknowledgeEmpId = acknowledgeEmpId;
            this.deptId = deptId;
            this.quantityAccepted = quantityAccepted;
            this.itemId = itemId;
        }

    }

}