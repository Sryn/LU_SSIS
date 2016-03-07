using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class DisbursementController
    {
        private Model.LogicUniversityEntities ctx;
        public DisbursementController()
        {
            ctx = new Model.LogicUniversityEntities();
        }
        public List<Model.DisbursementItemViewModel> requestDisbursementList()
        {
            List<Model.Disbursement> disburList = ctx.Disbursements.Where(x => x.status == "inProgress" && x.CollectionDate >= DateTime.Today).ToList();
            List<Model.RequisitionItem> requList = ctx.RequisitionItems.Where(x => x.Status == "Approved").ToList();
            List<Model.DisbursementItem> oldDisburItemList = ctx.DisbursementItems.Where(x => x.RemainingQty != 0 && x.Disbursement.CollectionDate <= DateTime.Today).ToList();

            setDisbursementItemIntoDisbursement(disburList, oldDisburItemList);
            setRequisitionItemIntoDisbursement(disburList, requList);

            List<Model.DisbursementItemViewModel> result = new List<DisbursementItemViewModel>();
            Model.DisbursementItemViewModel temp;
            List<Model.DisbursementItem> disItemList = ctx.DisbursementItems.Where(x => x.Disbursement.status == "inProgress" && x.Disbursement.CollectionDate >= DateTime.Today).OrderBy(x => x.ItemID).ToList();
            disburList = ctx.Disbursements.Where(x => x.status == "inProgress" && x.CollectionDate >= DateTime.Today).ToList();
            Dictionary<string, int> totalRec = new Dictionary<string, int>();
            Dictionary<string, int> totalNeedQty = new Dictionary<string, int>();
            int temp_totalneedqty = 0;

            foreach(Model.DisbursementItem disItem in disItemList)
                {
                    temp = new DisbursementItemViewModel();
                    if (disItem.Item == null)
                        disItem.Item = ctx.Items.Where(x => x.ItemID == disItem.ItemID).FirstOrDefault();
                    temp.BinCode = disItem.Item.BinNo;
                    temp.ItemID = disItem.ItemID;
                    temp.ItemDescription = disItem.Item.Description;
                    temp.TotalNeededQty = disItem.Quantity.GetValueOrDefault();

                    if (!totalNeedQty.TryGetValue(temp.ItemID,out temp_totalneedqty))
                        totalNeedQty.Add(temp.ItemID, disItem.Quantity.GetValueOrDefault());
                    else
                        totalNeedQty[temp.ItemID] = totalNeedQty[temp.ItemID] + disItem.Quantity.GetValueOrDefault();

                    temp.Department = disItem.Disbursement.Department.DepartmentName;
                    temp.NeedQty = disItem.Quantity.GetValueOrDefault();
                    temp.UnitOfMeasure = disItem.Item.UOM;
                    temp.ActualQty = disItem.Quantity.GetValueOrDefault() - disItem.RemainingQty.GetValueOrDefault();

                    if (!totalRec.TryGetValue(temp.ItemID, out temp_totalneedqty))
                        totalRec.Add(temp.ItemID, temp.ActualQty);
                    else
                        totalRec[temp.ItemID] = totalRec[temp.ItemID] + temp.ActualQty;

                    temp.DisbursementItemID = disItem.DisbursementItemID;
                    result.Add(temp);
                }
            foreach(DisbursementItemViewModel divm in result)
            {
                divm.TotalNeededQty = totalNeedQty[divm.ItemID];
                divm.TotalReceived = totalRec[divm.ItemID];
            }
            return result;
        }
        private void setRequisitionItemIntoDisbursement(List<Disbursement> disburList, List<RequisitionItem> requList)
        {
            if (requList == null)
                return;
            if (disburList == null)
                disburList = new List<Disbursement>();
            int flag = 0;
            DisbursementItem temp_disbItem;
            Disbursement temp_disb;

            foreach (RequisitionItem reqItem in requList)
            {
                flag = 0;
                foreach (Disbursement dis in disburList)
                {
                    if (dis.DepartmentID.Equals(reqItem.Requisition.Employee.DepartmentID))
                    { 
                        foreach (DisbursementItem disItem in dis.DisbursementItems)
                        {
                            if (reqItem.ItemID.Equals(disItem.ItemID))
                            {
                                disItem.Quantity += reqItem.Quantity;
                                disItem.RemainingQty += reqItem.Quantity;
                                disItem.RequisitionItems.Add(reqItem);
                                reqItem.Status = "inProgress";
                                ctx.SaveChanges();
                                flag = 1;
                            }
                        }
                        if (flag == 0)
                        {
                            temp_disbItem = new DisbursementItem();
                            temp_disbItem.ItemID = reqItem.ItemID;
                            temp_disbItem.Quantity = reqItem.Quantity;
                            temp_disbItem.RemainingQty = reqItem.Quantity;
                            temp_disbItem.RequestDate = reqItem.Requisition.Date;
                            temp_disbItem.RequisitionItems.Add(reqItem);
                            temp_disbItem.DisbursementID = dis.DisbursementID;
                            dis.DisbursementItems.Add(temp_disbItem);
                            reqItem.Status = "inProgress";
                            ctx.SaveChanges();
                            flag = 2;
                        }
                    }
                }
                if (flag == 0)
                {
                    temp_disb = new Disbursement();
                    temp_disb.CollectionDate = DateTime.Today.AddDays(2); //to change later
                    temp_disb.CollectionPointID = reqItem.Requisition.Employee.Department.CollectionPointID;
                    temp_disb.AcknowledgeEmployeeID = ((Employee)ctx.Employees.Where(x => x.DepartmentID == reqItem.Requisition.Employee.DepartmentID && x.Role == "Representative").FirstOrDefault()).EmployeeID;
                    temp_disb.DepartmentID = reqItem.Requisition.Employee.DepartmentID;
                    temp_disb.status = "inProgress";
                    ctx.Disbursements.Add(temp_disb);
                    ctx.SaveChanges();

                    temp_disbItem = new DisbursementItem();
                    temp_disbItem.ItemID = reqItem.ItemID;
                    temp_disbItem.Quantity = reqItem.Quantity;
                    temp_disbItem.RemainingQty = reqItem.Quantity;
                    temp_disbItem.RequestDate = reqItem.Requisition.Date;
                    temp_disbItem.DisbursementID = temp_disb.DisbursementID;
                    temp_disbItem.RequisitionItems.Add(reqItem);
                    temp_disb.DisbursementItems.Add(temp_disbItem);
                    disburList.Add(temp_disb);
                    reqItem.Status = "inProgress";
                    ctx.SaveChanges();
                }
            }
        }
        public void setDisbursementItemIntoDisbursement(List<Disbursement> disList, List<Model.DisbursementItem> olddisItemList)
        {
            int flag = 0;
            DisbursementItem temp_disburItem;
            Disbursement temp_disbur;
            Employee temp_Emp;

            if (disList == null)
            {
                disList = new List<Disbursement>();
            }
            if (olddisItemList == null)
                return;

            foreach (DisbursementItem disItem in olddisItemList)
            {
                flag = 0;
                foreach (Disbursement dis in disList)
                {
                    if (dis.DepartmentID.Equals(disItem.Disbursement.DepartmentID)) { 
                        foreach (DisbursementItem disItem1 in dis.DisbursementItems)
                        {
                            if (disItem.ItemID.Equals(disItem1.ItemID))
                            {
                                disItem1.Quantity += disItem.RemainingQty;
                                disItem1.RemainingQty += disItem.RemainingQty;
                                disItem.RemainingQty = 0;
                                ctx.SaveChanges();
                                flag = 1;
                            }
                        }
                        if (flag == 0)
                        {
                            temp_disburItem = new DisbursementItem();
                            temp_disburItem.ItemID = disItem.ItemID;
                            temp_disburItem.Quantity = disItem.RemainingQty;
                            temp_disburItem.RequestDate = disItem.RequestDate;
                            temp_disburItem.RemainingQty = disItem.RemainingQty;
                            disItem.RemainingQty = 0;
                            dis.DisbursementItems.Add(temp_disburItem);
                            ctx.SaveChanges();
                            flag = 2;
                        }
                }
                }
                if (flag == 0)
                {
                    temp_disbur = new Disbursement();
                    temp_disbur.CollectionDate = DateTime.Today;
                    temp_disbur.CollectionPointID = disItem.Disbursement.Department.CollectionPointID;
                    temp_Emp = ctx.Employees.Where(x => x.DepartmentID == disItem.Disbursement.DepartmentID && x.Role == "Representative").FirstOrDefault();
                    temp_disbur.AcknowledgeEmployeeID = temp_Emp.EmployeeID;
                    temp_disbur.DepartmentID = disItem.Disbursement.DepartmentID;
                    temp_disbur.status = "inProgress";

                    temp_disburItem = new DisbursementItem();
                    temp_disburItem.ItemID = disItem.ItemID;
                    temp_disburItem.Quantity = disItem.RemainingQty;
                    temp_disburItem.RequestDate = disItem.RequestDate;
                    temp_disburItem.RemainingQty = disItem.RemainingQty;
                    disItem.RemainingQty = 0;
                    temp_disbur.DisbursementItems.Add(temp_disburItem);
                    ctx.Disbursements.Add(temp_disbur);
                    ctx.SaveChanges();

                }
            }
        }

        //for Mobile Only and item is only for add
        //QtyIsInvalid = qty is less than or equal to zero
        //ItemNotFound = item is not in disburitem list
        //success = successfully updated
        //overflow = qty is more than it needed
        //ItemNotFound = item is not in the database
        //QtyIsNotEnough = item in the inventory is less then given qty
        public string updateCollectedQtyByItemID(string itemID,int qty)
        {
            if (qty <= 0)
                return "QtyIsInvalid";
            Model.Item item = ctx.Items.Where(x => x.ItemID == itemID).FirstOrDefault();
            if (item == null)
                return "ItemNotFound";
            if (item.Quantity < qty)
                return "QtyIsNotEnough";
            List<Model.DisbursementItem> disburList = ctx.DisbursementItems.Where(x => x.Disbursement.status == "inProgress" && x.Disbursement.CollectionDate >= DateTime.Today && x.ItemID==itemID).ToList();
            if (disburList.Count <= 0)
                return "ItemNotFound";
            foreach(DisbursementItem disItem in disburList)
            {
                int totalRemaining = disItem.RemainingQty.GetValueOrDefault();
                if (disItem.RemainingQty <= qty)
                {
                    qty -= disItem.RemainingQty.GetValueOrDefault();
                    disItem.RemainingQty = 0;
                    ctx.SaveChanges();
                }
                else
                {
                    disItem.RemainingQty -= qty;
                    qty = 0;
                    ctx.SaveChanges();
                }
            }
            if (qty > 0)
                return "overflow";
            return "success";
        }
    }
}