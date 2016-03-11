<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageSupplier.aspx.cs" Inherits="LogicUniversity.WebView.Finance.ManageSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Manage Supplier"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="SupplierID"></asp:Label></td>
            <td><asp:TextBox ID="txtSupplierID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Supplier Name"></asp:Label></td>
            <td><asp:TextBox ID="txtSupplierName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="Contact Name"></asp:Label></td>
            <td><asp:TextBox ID="txtContactName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="Phone No"></asp:Label></td>
            <td><asp:TextBox ID="txtPhoneNo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label7" runat="server" Text="Fax No"></asp:Label></td>
            <td><asp:TextBox ID="txtFaxNo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label8" runat="server" Text="Address"></asp:Label></td>
            <td><asp:TextBox ID="txtAddress" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Email"></asp:Label></td>
            <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label9" runat="server" Text="GSTRegistration"></asp:Label></td>
            <td><asp:TextBox ID="txtGSTRegistration" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            <td><asp:Button ID="btnClearAll" runat="server" Text="Clear All" OnClick="btnClearAll_Click" /></td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gvDataList" runat="server">
    </asp:GridView>
</asp:Content>
