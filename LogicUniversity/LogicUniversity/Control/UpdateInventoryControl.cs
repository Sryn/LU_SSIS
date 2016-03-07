using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class UpdateInventoryControl
    {
        LogicUniversityEntities ctx;
        public UpdateInventoryControl()
        {
            ctx = new LogicUniversityEntities();
        }


        // returns an item object
        public Item getQuantity(string itemCode)
        {
            Item itemObject = ctx.Items.Where(x => x.ItemID == itemCode).FirstOrDefault();

            return itemObject;
        }

        //returns a list of suppliers with supplier name ordered by priority
        public List<Suppliers> getSuppliers(string itemCode)
        {
            List<SupplierItem> supplierList = new List<SupplierItem>();

            List<Suppliers> suppliers = new List<Suppliers>();

            supplierList = ctx.SupplierItems.OrderBy(x => x.Priority).Where(x => x.ItemID == itemCode).ToList();

            foreach (SupplierItem item in supplierList)
            {
                String nameSupplier = getSupplierName(item.SupplierID);

                suppliers.Add(new Suppliers(item.ItemID, item.SupplierID, item.Price, item.Priority, nameSupplier));

            }

            return suppliers;

        }

        private String getSupplierName(string supplierID)
        {
            return ctx.Suppliers.Where(x => x.SupplierID == supplierID).FirstOrDefault().SupplierName;

        }

        public string updateInventory(string itemToUpdate, string supplierID, int? quantity)
        {
            System.DateTime today = DateTime.Today;


            Item findItem = ctx.Items.Where(x => x.ItemID == itemToUpdate).FirstOrDefault();
            findItem.Quantity = findItem.Quantity + (int)quantity;
            StockTransaction newTransaction = new StockTransaction();
            newTransaction.ItemID = itemToUpdate;
            newTransaction.SupplierID = supplierID;
            newTransaction.Balance = findItem.Quantity;
            newTransaction.TransactionDate = today;

            ctx.StockTransactions.Add(newTransaction);

            return (ctx.SaveChanges() > 0 ? "Success" : "Update Failed");

        }


    }
}