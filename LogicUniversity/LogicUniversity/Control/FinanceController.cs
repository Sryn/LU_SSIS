using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;
using LogicUniversity.Control;

namespace LogicUniversity.Control
{
    public class FinanceController
    {
        private Model.LogicUniversityEntities ctx;
        public FinanceController()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        public string insertNewSupplier(Supplier s)
        {
            
            ctx.Suppliers.Add(s);
            ctx.SaveChanges();
            return "";
        }
        public string checkSupplierID(string supID)
        {
            Supplier s = ctx.Suppliers.Where(x => x.SupplierID == supID).FirstOrDefault();
            if (s == null)
                return "NotFound";
            return "Found";
        }
        public List<Supplier> getSupplierList()
        {
            return ctx.Suppliers.ToList();
        }
        public List<Category> getAllCategoryList()
        {
            return ctx.Categories.ToList();
        }
        public string checkItemID(string itemID)
        {
            Item item = ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault();
            if (item == null)
                return "NotFound";
            return "Found";
        }
        public string insertItem(Item item)
        {
            Item temp = ctx.Items.Where(x => x.ItemID == item.ItemID).FirstOrDefault();
            if(temp == null)
                ctx.Items.Add(item);
            else
            {
                temp.Description = item.Description;
                temp.Quantity = item.Quantity;
                temp.UOM = item.UOM;
                temp.CategoryID = item.CategoryID;
                temp.ReorderLevel = item.ReorderLevel;
                temp.ReorderQty = item.ReorderQty;
                temp.QRCode = item.QRCode;
                temp.BinNo = item.BinNo;
            }
            ctx.SaveChanges();
            return "success";
        }
        public string insertCategory(Category cat)
        {
            Category category = ctx.Categories.Where(x => x.CategoryID == cat.CategoryID).FirstOrDefault();
            if(category==null)
            {
                ctx.Categories.Add(cat);
            }
            else
            {
                category.CategoryName = cat.CategoryName;
            }
            ctx.SaveChanges();
            return "success";
        }
    }
}