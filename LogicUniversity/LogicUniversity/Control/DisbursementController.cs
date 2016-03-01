using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Control
{
    public class DisbursementController
    {
        private Model.LogicUniversityEntities ctx;
        public DisbursementController()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        public List<Model.DisbursementItemViewModel> requestDisbursementList()
        {
            List<Model.Disbursement> disburList = ctx.Disbursements.Where(x => x.status == "Active" && x.CollectionDate > DateTime.Today).ToList();
            List<Model.RequisitionItem> requList = ctx.RequisitionItems.Where(x => x.Status == "Approved").ToList();
            List<Model.DisbursementItem> oldDisburItemList = ctx.DisbursementItems.Where(x => x.RemainingQty != 0 && x.Disbursement.CollectionDate <= DateTime.Today).ToList();
            int flag = 0;
            Model.Disbursement temp;


            if (disburList == null)
            {
                disburList = new List<Model.Disbursement>();
            }
            foreach(Model.DisbursementItem disItem in oldDisburItemList)
            {
                foreach(Model.Disbursement dis in disburList)
                {
                    foreach(Model.DisbursementItem disItem2 in dis.DisbursementItems)
                    {
                        if (disItem2.Disbursement.DisbursementID.Equals(disItem.Disbursement.DepartmentID))
                        {
                            disItem2.Quantity += disItem.Quantity;
                            flag = 1;
                            break;
                        }
                    }
                }
                if (flag == 0)
                {
                    temp = new Model.Disbursement();
                    temp.CollectionDate = DateTime.Today; // have to change later to real collection Date
                    temp.CollectionPointID = disItem.Disbursement.Department.CollectionPointID;
                    //temp.AcknowledgeEmployeeID = disItem.Disbursement.Department.

                }
            }
            return null;
        }
    }
}