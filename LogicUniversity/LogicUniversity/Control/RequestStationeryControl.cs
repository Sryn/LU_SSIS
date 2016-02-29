using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class RequestStationeryControl
    {
        LogicUniversityEntities ctx;
        public RequestStationeryControl()
        {
            ctx = new LogicUniversityEntities();
        }
        public List<Category> getAllCategory()
        {
            return ctx.Categories.ToList();
        }
        public List<Item> getItemByCatID(string catID)
        {
            int catid = Convert.ToInt32(catID);
            return ctx.Items.Where(x => x.CategoryID == catid).ToList();
        }
        // success = successfully saved
        // if requistionID is "", it is new
        // if not, it is edit
        public string insertNewReqisition(List<RequisitionItem> ReqItem,string empID,string requisitionID)
        {
            System.DateTime today = DateTime.Today;
            if (requisitionID.Equals(""))
            {
                Model.Requisition req = new Requisition();
                req.EmployeeID = empID;
                req.Date = today;
                ctx.Requisitions.Add(req);
                ctx.SaveChanges();

                foreach (RequisitionItem Item in ReqItem)
                {
                    Item.RequisitionID = req.RequisitionID;
                    Item.Status = "PendingApproval";
                    req.RequisitionItems.Add(Item);
                }
                ctx.SaveChanges();
            }
            return "success";
        }
    }
}