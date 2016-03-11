using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;
using LogicUniversity.Control;

namespace LogicUniversity.Control
{
    public class InventoryListController
    {
        LogicUniversityEntities ctx;
        public InventoryListController()
        {
            ctx = new LogicUniversityEntities();
        }
        public List<InventroyListModel> getInventoryList()
        {
            List<InventroyListModel> result = new List<InventroyListModel>();
            List<Item> itemList = ctx.Items.ToList();
            InventroyListModel ivlm;
            List<RequisitionItem> ReqItemList;
            List<DisbursementItem> DisITemList;
            foreach (Item item in itemList)
            {
                ivlm = new InventroyListModel();
                ivlm.BinID = item.BinNo;
                ivlm.ItemID = item.ItemID;
                ivlm.Category = item.Category.CategoryName;
                ivlm.ItemDescription = item.Description;
                ivlm.Quantity = item.Quantity;
                ivlm.UnitOfMeasure = item.UOM;
                ivlm.ReorderLevel = item.ReorderLevel.GetValueOrDefault();
                ivlm.ReorderQty = item.ReorderQty.GetValueOrDefault();

                ReqItemList = ctx.RequisitionItems.Where(x => x.ItemID == item.ItemID && x.Status == "Approved").ToList();
                foreach (RequisitionItem temp in ReqItemList)
                    ivlm.AccumulatedRequest += temp.Quantity.GetValueOrDefault();

                DisITemList = ctx.DisbursementItems.Where(x => x.ItemID == item.ItemID && x.Disbursement.status == "inprogress").ToList();
                foreach (DisbursementItem temp in DisITemList)
                    ivlm.AccumulatedRequest += temp.RemainingQty.GetValueOrDefault();

                if ((ivlm.Quantity - ivlm.AccumulatedRequest) < ivlm.ReorderLevel)
                    ivlm.Remark = "Insufficient";
                else if ((ivlm.Quantity - ivlm.AccumulatedRequest) >= (ivlm.ReorderLevel * 2))
                    ivlm.Remark = "Adequate";
                else
                    ivlm.Remark = "Excess";

                result.Add(ivlm);
            }
            return result;
        }
    }
}