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
            int actualQty = 0;

            foreach (AcknowledgeModel item in acknowledgeObject)
            {
                List<DisbursementItem> disbursementItemList = ctx.DisbursementItems.Where(x => x.DisbursementID == item.disbursementId).ToList();

                foreach (DisbursementItem eachItem in disbursementItemList)
                {
                    actualQty = eachItem.Quantity.GetValueOrDefault() - eachItem.RemainingQty.GetValueOrDefault();
                    //DisbursementItem disbursementItem = ctx.DisbursementItems.Where(x => x.DisbursementItemID == eachItem.DisbursementItemID).FirstOrDefault();

                    if (item.quantityAccepted == actualQty)
                    {
                        eachItem.Status = "Collected";
                        List<RequisitionItem> ReqItemList = ctx.RequisitionItems.Where(x => x.DisbursementItems.Any(y => y.DisbursementID == eachItem.DisbursementID)).ToList();
                        foreach (RequisitionItem reqItem in ReqItemList)
                        {
                            if (reqItem.Status.Equals("inProgress"))
                            {
                                reqItem.Status = "Collected";
                            }
                        }
                    }
                    else if (item.quantityAccepted < actualQty)
                    {
                        eachItem.Item.Quantity += actualQty-item.quantityAccepted;
                        eachItem.RemainingQty += actualQty - item.quantityAccepted;
                        List<RequisitionItem> ReqItemList = ctx.RequisitionItems.Where(x => x.DisbursementItems.Any(y => y.DisbursementID == eachItem.DisbursementID)).ToList();
                        foreach(RequisitionItem reqItem in ReqItemList)
                        {
                            reqItem.Status = "Partial Fulfilled";
                        }
                    }

                    StockTransaction stockTransaction = new StockTransaction();
                    stockTransaction.DepartmentID = eachItem.Disbursement.DepartmentID;
                    stockTransaction.ItemID = eachItem.ItemID;
                    stockTransaction.Balance = eachItem.Item.Quantity;
                    stockTransaction.TransactionDate = DateTime.Today;
                    ctx.StockTransactions.Add(stockTransaction);
                }
            }
            try
            {
                ctx.SaveChanges();
                return "Success";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message);
                return "Error";
            }
        }
    }
}