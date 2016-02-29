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
                    result.Add(new Model.RequisitionApproval(reqItem.RequisitionID ?? default(int), reqItem.RequisitionItemID,req.Employee.Name,req.Date.ToString(),reqItem.Item.Description, reqItem.Quantity.ToString()));
                }
            }
            return result;
        }
    }
}