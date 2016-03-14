<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="Disbursements.aspx.cs" Inherits="LogicUniversity.WebView.Employee.Disbursements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<<<<<<< HEAD
     <div style="width:90%; margin-left:100px;">
    <asp:Label  style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;" 
        ID="lblTitle" runat="server" Text="Disbursements"></asp:Label>
=======
    <asp:Label ID="lblTitle" runat="server" Text="Disbursements"></asp:Label>
>>>>>>> origin/master
    <table class="auto-style1">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtRole" runat="server" Text="Role"></asp:Label></td>
            <td><asp:Label ID="lblRole" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
    <asp:Label ID="lblDisbursementTitle" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gvDisbursement" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="DisbursementID" HeaderText="Disbursement ID" />
            <asp:BoundField DataField="CollectionDate" HeaderText="Collection Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="collectionPointName" HeaderText="Collection Point" />
<%--            http://codeverge.com/asp.net.presentation-controls/gridview-hyperlink-field-based/470920 --%>
            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                    <asp:HyperLink ID="detailsHyperLink" runat="server" NavigateUrl='<%# Eval("DisbursementID", "Disbursements.aspx?DisbursementID={0}") %>'
                        Text="Details" ></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvAllDeptDisbursement" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="DisbursementID" HeaderText="Disbursement ID" />
            <asp:BoundField DataField="deptName" HeaderText="Department" />
            <asp:BoundField DataField="CollectionDate" HeaderText="Collection Date" DataFormatString="{0:d}" />
<%--            http://codeverge.com/asp.net.presentation-controls/gridview-hyperlink-field-based/470920 --%>
            <asp:TemplateField HeaderText="Details">
                <ItemTemplate>
                    <asp:HyperLink ID="detailsHyperLink" runat="server" NavigateUrl='<%# Eval("DisbursementID", "Disbursements.aspx?DisbursementID={0}") %>'
                        Text="Details" ></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvDisbursementDetails" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="employeeName" HeaderText="Employee" />
            <asp:BoundField DataField="itemDesc" HeaderText="Item Description" />
            <asp:BoundField DataField="quantity" HeaderText="Quantity" />
            <asp:BoundField DataField="UOM" HeaderText="Unit of Measure" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="gvStoreDisbursementDetails" runat="server" AutoGenerateColumns="False" >
        <Columns>
            <asp:BoundField DataField="requestID" HeaderText="Requisition ID" />
            <asp:BoundField DataField="itemDesc" HeaderText="Item Description" />
            <asp:BoundField DataField="quantityUOM" HeaderText="Quantity" />
            <asp:BoundField DataField="requestDate" HeaderText="Request Date" DataFormatString="{0:d}" />
            <asp:BoundField DataField="employeeName" HeaderText="Employee Name" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnBackToDisbursements" runat="server" Text="Back To Disbursements" Visible="false" OnClick="btnClick_BackToDisbursements" />
<<<<<<< HEAD
</div>
=======
>>>>>>> origin/master
</asp:Content>
