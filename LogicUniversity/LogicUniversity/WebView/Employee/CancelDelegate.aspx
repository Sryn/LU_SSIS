<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="CancelDelegate.aspx.cs" Inherits="LogicUniversity.WebView.Employee.CancelDelegate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="nav-justified">
        <tr>
            <td>DelegateID</td>
            <td><asp:Label ID="lblDelegateID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>EmployeeID</td>
            <td><asp:Label ID="lblEmployeeID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>From Date</td>
            <td><asp:Label ID="lblFromDate" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>To Date</td>
            <td><asp:Label ID="lblToDate" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Edit</td>
            <td><asp:Label ID="lblEditBoolean" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Cancel</td>
            <td><asp:Label ID="lblCancelBoolean" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Result</td>
            <td><asp:Label ID="lblResult" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
