using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicUniversity.Control
{
    public class RequestListControl
    {
        Model.LogicUniversityEntities ctx;
        public RequestListControl()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        //success = successfully deleted
        public string DeleteRequisition(int requisitionID)
        {
            Model.Requisition req = ctx.Requisitions.Where(x => x.RequisitionID == requisitionID).FirstOrDefault();
            List<Model.RequisitionItem> toRemove = new List<Model.RequisitionItem>();
            foreach(Model.RequisitionItem reqitem in req.RequisitionItems)
            {
                toRemove.Add(reqitem);
            }
            foreach(Model.RequisitionItem reqitem in toRemove)
            {
                ctx.RequisitionItems.Remove(reqitem);
            }
            ctx.Requisitions.Remove(req);
            ctx.SaveChanges();
            return "success";
        }
        public string ReorderRequisition(int requisitionID)
        {
            Model.Requisition req = ctx.Requisitions.Where(x => x.RequisitionID == requisitionID).FirstOrDefault();
            Model.Requisition toAdd = new Model.Requisition();
            toAdd = req;
            foreach(Model.RequisitionItem reqitem in req.RequisitionItems)
            {
                toAdd.RequisitionItems.Add(reqitem);
            }
            ctx.Requisitions.Add(toAdd);
            ctx.SaveChanges();
            return "success";
        }
        public List<Model.RequisitionItem> getRequistionList(string Description,string status,string empID)
        {
            if (status.Equals("All"))
                if (Description.Equals(""))
                    return ctx.RequisitionItems.Where(x => x.Requisition.EmployeeID == empID).ToList();
                else
                    return ctx.RequisitionItems.Where(x => x.Item.Description == Description && x.Requisition.EmployeeID == empID).ToList();
            else
                if (Description.Equals(""))
                    return ctx.RequisitionItems.Where(x => x.Status == status && x.Requisition.EmployeeID == empID).ToList();
                else
                return ctx.RequisitionItems.Where(x => x.Status == status && x.Item.Description == Description && x.Requisition.EmployeeID == empID).ToList();
        }
        public List<Model.RequestListItem> getRequisitionListItem(string Description, string status, string empID)
        {
            List<Model.RequisitionItem> reqItemList = getRequistionList(Description, status, empID);
            List<Model.RequestListItem> resultList = new List<Model.RequestListItem>();
            Model.RequestListItem result;
            foreach (Model.RequisitionItem req in reqItemList)
            {
                result = new Model.RequestListItem();
                result.RequestDate = (System.DateTime)req.Requisition.Date;
                result.RequisitionForm = ""+req.RequisitionID;
                result.Description = req.Item.Description;
                result.Quantity = ""+req.Quantity;
                result.UnitOfMeasure = req.Item.UOM;
                result.Status = req.Status;
                resultList.Add(result);
            }
            return resultList;
        }
    }
}