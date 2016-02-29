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