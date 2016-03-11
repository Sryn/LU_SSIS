﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LogicUniversity.Control;
using LogicUniversity.Model;

namespace LogicUniversity.WebView.Finance
{
    public partial class ManageSupplier : System.Web.UI.Page
    {
        FinanceController crt;
        protected void Page_Load(object sender, EventArgs e)
        {
            crt = new FinanceController();
            gvDataList.DataSource = crt.getSupplierList();
            gvDataList.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Supplier sp = new Supplier();

            string result = crt.checkSupplierID(txtSupplierID.Text);
            if (txtSupplierID.Text.Trim().Equals(string.Empty))
            {
                lblMessage.Text = "Enter Supplier ID";
                return;
            }
            if (crt.checkSupplierID(txtSupplierID.Text.Trim()).Equals("Found"))
            {
                lblMessage.Text = "User Another Supplier ID";
                return;
            }
            sp.SupplierID = txtSupplierID.Text;
            if (txtSupplierName.Text.Trim().Equals(string.Empty))
            {
                lblMessage.Text = "Enter Supplier Name";
                return;
            }
            sp.SupplierName = txtSupplierName.Text; 
            sp.ContactName = txtContactName.Text;
            sp.PhNo = txtPhoneNo.Text;
            sp.FaxNo = txtFaxNo.Text;
            sp.Address = txtAddress.Text;
            sp.Email = txtEmail.Text;
            sp.GSTRegistration = txtGSTRegistration.Text;
            crt.insertNewSupplier(sp);
            gvDataList.DataSource = crt.getSupplierList();
            gvDataList.DataBind();
        }

        protected void btnClearAll_Click(object sender, EventArgs e)
        {
            txtSupplierID.Text = string.Empty;
            txtSupplierName.Text = string.Empty;
            txtContactName.Text = string.Empty;
            txtPhoneNo.Text = string.Empty;
            txtFaxNo.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtGSTRegistration.Text = string.Empty;
        }
    }
}