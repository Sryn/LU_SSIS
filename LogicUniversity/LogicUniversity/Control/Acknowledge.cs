using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class Acknowledge
    {
        LogicUniversityEntities ctx;
        public Acknowledge()
        {
            ctx = new LogicUniversityEntities();
        }


        public string acknowledgeDisbursement(List<AcknowledgeModel> acknowledgeObject)
        {

            Disbursement disbursement = ctx.Disbursements.Where(x => x.DisbursementID == acknowledgeObject[0].disbursementId).FirstOrDefault();
            disbursement.CollectionDate = DateTime.Today;
            disbursement.AcknowledgeEmployeeID = acknowledgeObject[0].acknowledgeEmpId;
            disbursement.status = "Collected";


            foreach (AcknowledgeModel item in acknowledgeObject)
            {
                List<DisbursementItem> disbursementItemList = ctx.DisbursementItems.Where(x => x.DisbursementID == item.disbursementId).ToList();

                foreach (DisbursementItem eachItem in disbursementItemList)
                {
                    DisbursementItem disbursementItem = ctx.DisbursementItems.Where(x => x.DisbursementItemID == eachItem.DisbursementItemID).FirstOrDefault();

                    if (eachItem.Quantity == disbursementItem.Quantity)
                    {
                        disbursementItem.RemainingQty = 0;
                    }
                    else
                    {
                        disbursementItem.RemainingQty = disbursementItem.Quantity - eachItem.Quantity;
                        disbursementItem.Quantity = eachItem.Quantity;
                        eachItem.Item.Quantity = (int)eachItem.Item.Quantity + (int)disbursementItem.Quantity - (int)eachItem.Quantity;
                    }

                    List<RequisitionItem> requisitionItemList = eachItem.RequisitionItems.ToList();

                    foreach (RequisitionItem anotherEachItem in requisitionItemList)
                    {
                        if (eachItem.Quantity == disbursementItem.Quantity)
                        {
                            anotherEachItem.Status = "Collected";
                        }
                        else
                        {
                            anotherEachItem.Status = "Partial Fulfilled";
                        }


                    }

                    StockTransaction stockTransaction = new StockTransaction();
                    stockTransaction.DepartmentID = eachItem.Disbursement.DepartmentID;
                    stockTransaction.ItemID = eachItem.ItemID;
                    stockTransaction.Balance = eachItem.Item.Quantity - eachItem.Quantity;
                    stockTransaction.TransactionDate = DateTime.Today;
                    ctx.StockTransactions.Add(stockTransaction);


                }

            }

            try
            {
                ctx.SaveChanges();
                return "Success";
            }
            catch (Exception)
            {
                return "Error";
            }

        }
    }
}