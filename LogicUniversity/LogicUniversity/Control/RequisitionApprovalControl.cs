using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Control
{

    public class RequisitionApprovalControl
    {
        Model.LogicUniversityEntities ctx;
        public RequisitionApprovalControl()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        public List<Model.RequisitionApproval> getAllRequisitionToApprove(string DeptID)
        {
            List<Model.Requisition> temp = ctx.Requisitions.Where(x => x.Employee.DepartmentID == DeptID).ToList();
            List<Model.RequisitionApproval> result = new List<Model.RequisitionApproval>();
            foreach(Model.Requisition req in temp)
            {
                foreach(Model.RequisitionItem reqItem in req.RequisitionItems)
                {
                    if(reqItem.Status.Equals("PendingApproval"))
                        result.Add(new Model.RequisitionApproval(reqItem.RequisitionID ?? default(int), reqItem.RequisitionItemID,req.Employee.Name,req.Date.ToString(),reqItem.Item.Description, reqItem.Quantity.ToString()));
                }
            }
            return result;
        }
        // in RequisitionApproval Object, status should be only both "Approved" and "Reject"
        //success => successfully updated
        public string ApproveRequisition(List<Model.RequisitionApproval> reqlist)
        {
            Model.RequisitionItem requisition;
            List<Model.RequisitionItem> requisitionItemList = new List<Model.RequisitionItem>();
            foreach (Model.RequisitionApproval req in reqlist)
            {
                requisition = ctx.RequisitionItems.Where(x => x.RequisitionItemID == req.RequisitionItemID).FirstOrDefault();
                if (req.Status.Equals("Approve"))
                {
                    requisition.Status = "Approved";
                }else if (req.Status.Equals("Reject"))
                {
                    requisition.Status = "Denied";
                }
                requisition.Reson = req.Reason;
                ctx.SaveChanges();
                requisitionItemList.Add(requisition);
            }
            Control.EmailControl emailCrt = new Control.EmailControl();
            string result = emailCrt.sendForAdjReviewed(requisitionItemList);
            return "success";
        }        
    }
}