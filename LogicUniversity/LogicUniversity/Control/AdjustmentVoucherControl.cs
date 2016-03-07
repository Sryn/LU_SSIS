using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class AdjustmentVoucherControl
    {
        LogicUniversityEntities ctx;
        public AdjustmentVoucherControl()
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
        public RaiseAdjustmentVoucherItem getRaiseAdjustmentVoucherItem(string itemID)
        {
            RaiseAdjustmentVoucherItem temp = new RaiseAdjustmentVoucherItem();
            Item item = ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault();
            List<SupplierItem> supItem = ctx.SupplierItems.Where(x => x.ItemID == itemID).ToList();
            temp.ItemCode = item.ItemID;
            temp.Category = item.Category.CategoryName;
            temp.Description = item.Description;
            temp.UnitOfMeasure = item.UOM;
            temp.UnitPrice = 0;
            foreach(SupplierItem spi in supItem)
            {
                temp.UnitPrice += (double)spi.Price.GetValueOrDefault();
            }
            temp.UnitPrice /= supItem.Count;
            temp.UnitPrice = Math.Round(temp.UnitPrice, 2);
            return temp;
        }
        //success = successfully added
        public string insertNewAdjustementVoucher(List<RaiseAdjustmentVoucherItem> rAdjList,string sEmpID)
        {
            AdjVoucher adjV = new AdjVoucher();
            adjV.StoreEmployeeID = sEmpID;
            ctx.AdjVouchers.Add(adjV);
            ctx.SaveChanges();
            AdjVoucherItem adjvItem;
            foreach(RaiseAdjustmentVoucherItem temp in rAdjList)
            {
                adjvItem = new AdjVoucherItem();
                adjvItem.AdjVoucherID = adjV.AdjVoucherID;
                adjvItem.ItemID = temp.ItemCode;
                adjvItem.Quantity = temp.Quantity;
                adjvItem.Reason = temp.Reason;
                adjvItem.Status = "Pending Approval";
                adjV.AdjVoucherItems.Add(adjvItem);
            }
            ctx.SaveChanges();
            return "success";
        }
        public List<RaiseAdjustmentVoucherItem> getToApproveAdjItemList(string sempID)
        {
            List<AdjVoucherItem> adjVoucherItems = ctx.AdjVoucherItems.Where(x=>x.Status== "Pending Approval").ToList();
            List<RaiseAdjustmentVoucherItem> resultForSupervisor = new List<RaiseAdjustmentVoucherItem>();
            List<RaiseAdjustmentVoucherItem> resultForManager = new List<RaiseAdjustmentVoucherItem>();
            RaiseAdjustmentVoucherItem temp;
            foreach (AdjVoucherItem adjItem in adjVoucherItems)
            {
                temp = new RaiseAdjustmentVoucherItem();
                temp.ItemCode = adjItem.ItemID;
                temp.Category = adjItem.Item.Category.CategoryName;
                temp.Description = adjItem.Item.Description;
                temp.Quantity = adjItem.Quantity.GetValueOrDefault();
                temp.UnitOfMeasure = adjItem.Item.UOM;
                List<SupplierItem> sitemList = ctx.SupplierItems.Where(x => x.ItemID == adjItem.ItemID).ToList();
                foreach(SupplierItem sitem in sitemList)
                {
                    temp.UnitPrice += (double)sitem.Price.GetValueOrDefault();
                }
                temp.UnitPrice /= sitemList.Count;
                temp.TotalPrice = temp.Quantity * temp.UnitPrice;
                temp.Reason = adjItem.Reason;
                if (temp.TotalPrice > 100)
                    resultForManager.Add(temp);
                else
                    resultForSupervisor.Add(temp);
            }
            StoreEmployee se = ctx.StoreEmployees.Where(x => x.StoreEmployeeID == sempID).FirstOrDefault();
            if (se.Role.Equals("Store Supervisor"))
                return resultForSupervisor;
            else if (se.Role.Equals("Store Manager"))
                return resultForManager;
            else
                System.Diagnostics.Debug.WriteLine("I m become null");
                return null;
        }
    }
}