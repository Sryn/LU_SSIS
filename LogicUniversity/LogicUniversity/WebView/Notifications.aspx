<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="LogicUniversity.WebView.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblNotiTitle" runat="server" Text="Notifications"></asp:Label>
    <table class="auto-style1">
        <tr>
            <td><asp:Label ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
    </table>
    <asp:GridView ID="NotificationGridView" runat="server" AutoGenerateColumns="False" AllowPaging="true" OnPageIndexChanging="newPageNotificationGridView" PagerSettings-Mode="NumericFirstLast">
        <Columns>
            <asp:BoundField DataField="dateTimeFilNoti" HeaderText="Date" />
            <asp:BoundField DataField="msgFilNoti" HeaderText="Message" />
            <asp:BoundField DataField="fromUserFilNoti" HeaderText="From" />
        </Columns>
    </asp:GridView>
</asp:Content>
