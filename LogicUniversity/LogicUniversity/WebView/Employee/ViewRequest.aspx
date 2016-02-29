<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ViewRequest.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ViewRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Request List"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Item Description"></asp:Label>
    <asp:TextBox ID="txtItemDescription" runat="server"></asp:TextBox>
    Status<asp:DropDownList ID="ddlStatus" runat="server">
        <asp:ListItem Value="All">All</asp:ListItem>
        <asp:ListItem Value="PendingApproval">Pending Approval</asp:ListItem>
        <asp:ListItem Value="PartiallyFulfilled">Partially Fulfilled</asp:ListItem>
        <asp:ListItem Value="ReadyForCollection">Ready for Collection</asp:ListItem>
        <asp:ListItem>Collected</asp:ListItem>
        <asp:ListItem Value="NotCollected">Not Collected</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    <br />
    <asp:GridView ID="gvList" runat="server" OnRowCreated="gvList_RowCreated">
    </asp:GridView>
&nbsp;
</asp:Content>
