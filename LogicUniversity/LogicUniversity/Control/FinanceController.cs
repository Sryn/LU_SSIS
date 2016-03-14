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
            if (temp == null)
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
            if (category == null)
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

        /// <summary>
        /// Overwrites/Saves SupplierID, Price and Priority for itemID in table SupplierItem with new data in newLstSupplierItem<para />
        /// Will delete current data first if exists in table SupplierItem<para />
        /// newLstSupplierItem is assumed to be not null and have valid data
        /// </summary>
        /// <param name="itemID"></param>
        /// <param name="lstSupplierItem"></param>
        /// <returns></returns>
        public bool saveNewSupplierPricesForItem(string itemID, List<SupplierItem> newLstSupplierItem)
        {
            System.Diagnostics.Debug.WriteLine(">> FinanceController.saveNewSupplierPricesForItem( itemID=" + itemID + ", lstSupplierItem )");

            bool rtnBool = true;

            List<Model.SupplierItem> currLstSupplierItem;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    currLstSupplierItem = context.SupplierItems.Where(x => x.ItemID == itemID).ToList();

                    if (currLstSupplierItem != null)
                    {
                        // delete current SupplierItems first
                        foreach (Model.SupplierItem oldSupplierItem in currLstSupplierItem)
                        {
                            context.SupplierItems.Remove(oldSupplierItem);
                            System.Diagnostics.Debug.WriteLine(">>> oldSupplierItem.ItemId" + oldSupplierItem.ItemID + " .SupplierID=" + oldSupplierItem.SupplierID + " deleted");

                            if (!rtnBool)
                                break;
                        }
                    }

                    if (rtnBool)
                    {
                        // just save each SupplierItem in newLstSupplierItem into table SupplierItem
                        foreach (Model.SupplierItem newSupplierItem in newLstSupplierItem)
                        {
                            context.SupplierItems.Add(newSupplierItem);
                            System.Diagnostics.Debug.WriteLine(">>> newSupplierItem.ItemId" + newSupplierItem.ItemID + " .SupplierID=" + newSupplierItem.SupplierID + " added");
                        }

                        context.SaveChanges();
                        rtnBool = true;
                    }

                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ saveNewSupplierPricesForItem: Exception Caught e=" + e);
                }
                finally
                {
                    context.Dispose();
                }
            }

            return rtnBool;
        }

        /// <summary>
        /// Can't use this as it can't force a rollback on the calling method if an error occurs
        /// </summary>
        /// <param name="currLstSupplierItem"></param>
        /// <param name="newLstSupplierItem"></param>
        /// <returns></returns>
        private bool replaceCurrLstWithNewLst(List<SupplierItem> currLstSupplierItem, List<SupplierItem> newLstSupplierItem)
        {
            System.Diagnostics.Debug.WriteLine(">> FinanceController.replaceCurrLstWithNewLst( currLstSupplierItem, newLstSupplierItem )");

            bool rtnBool = true;

            if (currLstSupplierItem != null)
            {
                // delete current SupplierItems first
                foreach (Model.SupplierItem oldSupplierItem in currLstSupplierItem)
                {
                    rtnBool = deleteSupplierItem(oldSupplierItem);

                    if (!rtnBool)
                        break;
                }
            }

            if (rtnBool)
            {
                // just save each SupplierItem in newLstSupplierItem into table SupplierItem
                foreach (Model.SupplierItem newSupplierItem in newLstSupplierItem)
                {
                    if (saveNewSupplierItem(newSupplierItem))
                        rtnBool = true;

                    if (!rtnBool)
                        break;
                }
            }

            return rtnBool;
        }

        /// <summary>
        /// Can't use this as well as it can't force a rollback on the calling method if an error occurs
        /// </summary>
        /// <param name="supplierItem"></param>
        /// <returns></returns>
        private bool deleteSupplierItem(SupplierItem supplierItem)
        {
            System.Diagnostics.Debug.WriteLine(">> FinanceController.deleteSupplierItem( supplierItem )");

            bool rtnBool = false;
            SupplierItem oldSupplierItem;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    oldSupplierItem = context.SupplierItems.Where(x => x.ItemID == supplierItem.ItemID && x.SupplierID == supplierItem.SupplierID).Single();

                    context.SupplierItems.Remove(oldSupplierItem);
                    //context.Entry(supplierItem).State = System.Data.EntityState.Deleted;
                    context.SaveChanges();
                    rtnBool = true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ deleteSupplierItem: Exception Caught e=" + e);
                }
                finally
                {
                    context.Dispose();
                }
            }

            return rtnBool;
        }

        /// <summary>
        /// Can't use this as well as it can't force a rollback on the calling method if an error occurs
        /// </summary>
        /// <param name="newSupplierItem"></param>
        /// <returns></returns>
        private bool saveNewSupplierItem(SupplierItem newSupplierItem)
        {
            System.Diagnostics.Debug.WriteLine(">> FinanceController.saveNewSupplierItem( newSupplierItem )");

            bool rtnBool = false;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    context.SupplierItems.Add(newSupplierItem);
                    context.SaveChanges();
                    rtnBool = true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ saveNewSupplierItem: Exception Caught e=" + e);
                }
                finally
                {
                    context.Dispose();
                }
            }

            return rtnBool;
        }

        /// <summary>
        /// Don't use this method!!!<para />
        /// A first chance exception of type 'System.InvalidOperationException' occurred in System.Data.Entity.dll<para />
        /// System.InvalidOperationException: The property 'SupplierID' is part of the object's key information and cannot be modified. 
        /// </summary>
        /// <param name="supplierItem"></param>
        /// <param name="newSupplierItem"></param>
        /// <returns></returns>
        private bool replaceCurrSupplierItemWithNewSupplierItem(SupplierItem supplierItem, SupplierItem newSupplierItem)
        {
            System.Diagnostics.Debug.WriteLine(">> FinanceController.replaceCurrSupplierItemWithNewSupplierItem( supplierItem, newSupplierItem )");

            bool rtnBool = false;
            Model.SupplierItem currSupplierItem;

            using (var context = new LogicUniversityEntities())
            {
                try
                {
                    currSupplierItem = context.SupplierItems.Where(x => x.ItemID == supplierItem.ItemID && x.SupplierID == supplierItem.SupplierID).Single();

                    currSupplierItem.SupplierID = newSupplierItem.SupplierID;
                    currSupplierItem.Price = newSupplierItem.Price;
                    currSupplierItem.Priority = newSupplierItem.Priority;

                    context.Entry(currSupplierItem).State = System.Data.EntityState.Modified;
                    context.SaveChanges();
                    rtnBool = true;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(">>> ERROR @ replaceCurrSupplierItemWithNewSupplierItem: Exception Caught e=" + e);
                }
                finally
                {
                    context.Dispose();
                }
            }

            return rtnBool;
        }
    }
}