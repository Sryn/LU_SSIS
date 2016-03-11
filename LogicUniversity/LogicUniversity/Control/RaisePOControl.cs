using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class RaisePOControl
    {
        Model.LogicUniversityEntities ctx;
        public RaisePOControl()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        public Item getItemByItemID(string itemID)
        {
            return ctx.Items.Where(x=>x.ItemID==itemID).FirstOrDefault();
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
        public List<SupplierItem> getSupplierByItemID(string itemID)
        {
            return ctx.SupplierItems.Where(x => x.ItemID == itemID).ToList();
        }
        public SupplierItem getSupplierItemBySupplierIDAndItemID(string sid,string itemid)
        {
            return ctx.SupplierItems.Where(x => x.SupplierID == sid && x.ItemID == itemid).FirstOrDefault();
        }
        public string confirmPOItem(List<RaisePOVoucherItem> rpoitemList,string sEmpID)
        {
            if (rpoitemList.Count <= 0)
                return "fail";
            List<PurchaseOrder> poList = new List<PurchaseOrder>();
            PurchaseOrder po_temp;
            PurchaseOrderItem poitem_temp;
            int flag = 0;
            foreach(RaisePOVoucherItem rpoitem in rpoitemList)
            {
                flag = 0;
                foreach(PurchaseOrder po in poList)
                {
                    if (po.SupplierID.Equals(rpoitem.SupplierID))
                    {
                        poitem_temp = new PurchaseOrderItem();
                        poitem_temp.ItemID = rpoitem.ItemID;
                        poitem_temp.Quantity = rpoitem.Quantity;
                        po.PurchaseOrderItems.Add(poitem_temp);
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    po_temp = new PurchaseOrder();
                    poitem_temp = new PurchaseOrderItem();

                    po_temp.SupplierID = rpoitem.SupplierID;
                    po_temp.StoreEmployeeID = sEmpID;
                    po_temp.OrderDate = DateTime.Today;
                    po_temp.RequireDeliveryDate = rpoitem.RequiredDeliveryDate;
                    poitem_temp.ItemID = rpoitem.ItemID;
                    poitem_temp.Quantity = rpoitem.Quantity;
                    po_temp.PurchaseOrderItems.Add(poitem_temp);
                    poList.Add(po_temp);
                }
            }
            foreach(PurchaseOrder po in poList)
            {
                EmailControl ecrt = new EmailControl();
                ctx.PurchaseOrders.Add(po);
                ctx.SaveChanges();

                System.Diagnostics.Debug.WriteLine("============");
                System.Diagnostics.Debug.WriteLine(po.PurchaseOrderID);
                System.Diagnostics.Debug.WriteLine(po.SupplierID);
                System.Diagnostics.Debug.WriteLine(po.StoreEmployeeID);
                System.Diagnostics.Debug.WriteLine(po.OrderDate);
                System.Diagnostics.Debug.WriteLine(po.RequireDeliveryDate);
                System.Diagnostics.Debug.WriteLine("----------------------------");
                foreach (PurchaseOrderItem poitem in po.PurchaseOrderItems)
                {
                    poitem.PurchaseOrderID = po.PurchaseOrderID;
                    ctx.PurchaseOrderItems.Add(poitem);
                    ctx.SaveChanges();
                    System.Diagnostics.Debug.WriteLine(poitem.PurchaseOrderItemID);
                    System.Diagnostics.Debug.WriteLine(poitem.ItemID);
                    System.Diagnostics.Debug.WriteLine(poitem.Quantity);
                    
                }
                
                ecrt.sendEmailForRaisePO(ctx.PurchaseOrders.Where(x=>x.PurchaseOrderID==po.PurchaseOrderID).FirstOrDefault());
                System.Diagnostics.Debug.WriteLine("----------------------------");
                System.Diagnostics.Debug.WriteLine("============");
            }
            
            return "success";
        }
    }

}