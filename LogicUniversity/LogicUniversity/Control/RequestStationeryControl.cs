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
        public string getUOMByItemID(string itemID)
        {
            return ((Item)ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault()).UOM;
        }
        public string getCategoryIDbyItemID(string itemID)
        {
            return ((Item)ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault()).CategoryID.GetValueOrDefault().ToString();
        }
        public List<RequisitionItem> getRequisitionItemByReqID(int reqID)
        {
            List<Model.RequisitionItem> reqItemList = ctx.RequisitionItems.Where(x => x.RequisitionID == reqID).ToList();
            List<Model.RequisitionItem> toReturn = new List<RequisitionItem>();
            Model.RequisitionItem temp;
            for (int i=0;i<reqItemList.Count;i++)
            {
                temp = new RequisitionItem();

                temp.ItemID = reqItemList[i].ItemID;
                temp.Quantity = reqItemList[i].Quantity;

                ctx.RequisitionItems.Remove(reqItemList[i]);

                toReturn.Add(temp);
            }
            Model.Requisition req = ctx.Requisitions.Where(x => x.RequisitionID == reqID).FirstOrDefault();
            ctx.Requisitions.Remove(req);
            ctx.SaveChanges();
            return toReturn;
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
        //EmpNotFound = Employee Id not found in Employee Table
        public string insertNewReqisition(List<RequisitionItem> ReqItem, string empID, string requisitionID)
        {
            System.DateTime today = DateTime.Today;
            if (requisitionID.Equals(""))
            {
                Model.Requisition req = new Requisition();
                req.EmployeeID = empID;
                req.Date = today;
                ctx.Requisitions.Add(req);
                ctx.SaveChanges();
                Employee emp = ctx.Employees.Where(x => x.EmployeeID == empID).FirstOrDefault();
                if (emp == null)
                    return "EmpNotFound";
                foreach (RequisitionItem Item in ReqItem)
                {
                    Item.RequisitionID = req.RequisitionID;
                    if (emp.Role == "Department Head")
                    {
                        Item.Status = "Approved";
                        Item.Reson = "";
                    }
                    else
                        Item.Status = "PendingApproval";
                    req.RequisitionItems.Add(Item);
                }
                ctx.SaveChanges();
                if (emp.Role != "Department Head")
                {
                    EmailControl emailCrt = new EmailControl();
                    emailCrt.sendforReqStationaryApproval(empID);
                    Notification noti = new Notification();
                    noti.Message = emp.Name+"’s Stationary Requisition is pending your approval.";
                    noti.FromUser = emp.EmployeeID;
                    noti.NotificationDate = DateTime.Today;
                    noti.UserID = ((Employee)ctx.Employees.Where(x => x.Role == "Department Head" && x.DepartmentID == emp.DepartmentID).FirstOrDefault()).EmployeeID;
                    ctx.Notifications.Add(noti);
                    ctx.SaveChanges();
                }
            }
            return "success";
        }
    }
}