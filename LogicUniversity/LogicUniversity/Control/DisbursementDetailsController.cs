using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LogicUniversity.Model;

namespace LogicUniversity.Control
{
    public class DisbursementDetailsController
    {
        LogicUniversityEntities ctx;
        public DisbursementDetailsController()
        {
            ctx = new LogicUniversityEntities();
        }

        public List<Model.DisbursementInformation> getDeptDisbursements(string EmpID)
        {
            LoginControl loginController = new LoginControl();

            List<Disbursement> listOfDisbursements = new List<Disbursement>();
            List<Model.DisbursementInformation> listOfDisbursementsInfo = new List<Model.DisbursementInformation>();

            Employee currentEmployee = loginController.getEmployeeUserObject(EmpID);


            listOfDisbursements = ctx.Disbursements.Where(x => x.DepartmentID == currentEmployee.DepartmentID && (x.status == "Collected" || x.status == "Ready")).ToList();

            foreach (Disbursement item in listOfDisbursements)
            {
                Model.DisbursementInformation temp = new Model.DisbursementInformation();
                temp.DisbursementID = item.DisbursementID;
                temp.CollectionDate = item.CollectionDate;
                temp.CollectionPointID = item.CollectionPointID;
                temp.AcknowledgeEmployeeID = item.AcknowledgeEmployeeID;
                temp.status = item.status;
                temp.acknowledgeEmployeeName = item.Employee.Name;
                temp.collectionPointName = item.CollectionPoint.CollectionPointName;
                temp.DepartmentID = item.DepartmentID;

                listOfDisbursementsInfo.Add(temp);
            }

            return listOfDisbursementsInfo;

        }




        public List<Model.DisbursementInformation> getAllDisbursements()
        {
            LoginControl loginController = new LoginControl();

            List<Disbursement> listOfDisbursements = new List<Disbursement>();
            List<Model.DisbursementInformation> listOfDisbursementsInfo = new List<Model.DisbursementInformation>();


            listOfDisbursements = ctx.Disbursements.ToList();

            foreach (Disbursement item in listOfDisbursements)
            {
                Model.DisbursementInformation temp = new Model.DisbursementInformation();
                temp.DisbursementID = item.DisbursementID;
                temp.CollectionDate = item.CollectionDate;
                temp.CollectionPointID = item.CollectionPointID;
                temp.AcknowledgeEmployeeID = item.AcknowledgeEmployeeID;
                temp.status = item.status;
                temp.acknowledgeEmployeeName = item.Employee.Name;
                temp.collectionPointName = item.CollectionPoint.CollectionPointName;
                temp.DepartmentID = item.DepartmentID;

                listOfDisbursementsInfo.Add(temp);
            }

            return listOfDisbursementsInfo;

        }






        public List<DisbursementDetail> getDisbursementDetails(int disbursementID)
        {
            List<DisbursementItem> disbursementItems = new List<DisbursementItem>();
            disbursementItems = ctx.DisbursementItems.Where(x => x.DisbursementID == disbursementID).ToList();
            List<DisbursementDetail> disbursementDetailsList = new List<DisbursementDetail>();
            List<RequisitionItem> requisitionItems = new List<RequisitionItem>();


            foreach (DisbursementItem item in disbursementItems)
            {
                requisitionItems = item.RequisitionItems.ToList();

                foreach (RequisitionItem individualItem in requisitionItems)
                {
                    DisbursementDetail temp = new DisbursementDetail();
                    temp.requestID = (int)individualItem.RequisitionID;
                    temp.employeeName = individualItem.Requisition.Employee.Name;
                    temp.itemDesc = individualItem.Item.Description;
                    temp.quantity = (int)individualItem.Quantity;
                    temp.UOM = individualItem.Item.UOM;
                    temp.requestDate = (System.DateTime)individualItem.Requisition.Date;
                    disbursementDetailsList.Add(temp);
                }
            }

            return disbursementDetailsList;

        }

    }

}