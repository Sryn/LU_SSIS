using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogicUniversity.WebView.Employee
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           /* if (Session["type"] == null)
                Response.Redirect("~/WebView/LoginPage.aspx");
            tvMenu.Nodes.Clear();
            CreateMenu(tvMenu);*/
        }
      /*  public void CreateMenu(TreeView tv)
        {
            tv.Nodes.Add(new TreeNode("Notifications", "", "", "~/WebView/Notifications.aspx", ""));
            
            
            if (Session["type"].Equals("StoreEmployee"))
            {
                Model.StoreEmployee semp = (Model.StoreEmployee)Session["User"];

                tv.Nodes.Add(new TreeNode("Request", "", "", "~/WebView/StoreEmployee/Request.aspx", ""));
                tv.Nodes.Add(new TreeNode("Inventory List", "", "", "~/WebView/StoreEmployee/InventoryList.aspx", ""));
                tv.Nodes.Add(new TreeNode("Collection Information", "", "", "~/WebView/StoreEmployee/CollectionInformation.aspx", ""));
                tv.Nodes.Add(new TreeNode("Not Collected", "", "", "~/WebView/StoreEmployee/NotCollected.aspx", ""));
                tv.Nodes.Add(new TreeNode("Disbursement List", "", "", "~/WebView/StoreEmployee/DisbursementList.aspx", ""));
                tv.Nodes.Add(new TreeNode("Raise Purchase Order", "", "", "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx", ""));
                tv.Nodes.Add(new TreeNode("Raise Adjustment Voucher", "", "", "~/WebView/StoreEmployee/RaiseAdjustmentVoucher.aspx", ""));
                tv.Nodes.Add(new TreeNode("Reports", "", "", "~/WebView/StoreEmployee/Reports.aspx", ""));
                tv.Nodes.Add(new TreeNode("Requisition Trend", "", "", "~/WebView/StoreEmployee/RequisitionTrend.aspx", ""));
                tv.Nodes.Add(new TreeNode("Stationary Order By", "", "", "~/WebView/StoreEmployee/StationaryOrderBy.aspx", ""));
                tv.Nodes.Add(new TreeNode("Stock Card", "", "", "~/WebView/StoreEmployee/StockCard.aspx", ""));

                if (semp.Role.Equals("StoreSupervisor") || semp.Role.Equals("StoreManager"))
                {
                    tv.Nodes.Add(new TreeNode("Change Delivery Date", "", "", "~/WebView/StoreEmployee/ChangeDeliveryDate.aspx", ""));
                    tv.Nodes.Add(new TreeNode("Approve Adjustment Voucher", "", "", "~/WebView/StoreEmployee/ApproveAdjustmentVoucher.aspx", ""));
                }
            }
            else if (Session["type"].Equals("Employee"))
            {
                Model.Employee emp = (Model.Employee)Session["User"];
                System.Diagnostics.Debug.WriteLine("=========");
                System.Diagnostics.Debug.WriteLine(emp.Role);
              //  tv.Nodes.Add(new TreeNode("Request Stationery", "", "", "~/WebView/Employee/RequestStationery.aspx", ""));
              //  tv.Nodes.Add(new TreeNode("View Request", "", "", "~/WebView/Employee/ViewRequest.aspx", ""));
                if (!emp.Role.Equals("Employee"))
                {
                  //  tv.Nodes.Add(new TreeNode("Change Collection Point", "", "", "~/WebView/Employee/ChangeCollectionPoint.aspx", ""));
                    tv.Nodes.Add(new TreeNode("Disbursements", "", "", "~/WebView/Employee/Disbursements.aspx", ""));
                    tv.Nodes.Add(new TreeNode("Disbursements Detail", "", "", "~/WebView/Employee/DisbursementsDetail.aspx", ""));
                    if (emp.Role.Equals("Department Head") || emp.Role.Equals("Delegate"))
                    {
                        tv.Nodes.Add(new TreeNode("Requisition Approval", "", "", "~/WebView/Employee/RequisitionApproval.aspx", ""));
                        tv.Nodes.Add(new TreeNode("Change Department Representative", "", "", "~/WebView/Employee/ChangeDepartmentRepresentative.aspx", ""));
                        if (emp.Role.Equals("HeadDepartment"))
                        {
                            tv.Nodes.Add(new TreeNode("Delegate Authority", "", "", "~/WebView/Employee/DelegateAuthority.aspx", ""));
                        }
                    }
                }
            }
            tv.Nodes.Add(new TreeNode("Change PIN", "", "", "~/WebView/ChangePIN.aspx", ""));
            tv.Nodes.Add(new TreeNode("Log Out", "", "", "~/WebView/LoginPage.aspx", ""));
        }*/
    }
}