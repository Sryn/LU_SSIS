<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="CollectionInformation.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.CollectionInformation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Collection Information"></asp:Label>
    <table class="auto-style1">
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtStoreEmpID" runat="server" Text="StoreEmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblStoreEmpID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtRole" runat="server" Text="Role"></asp:Label></td>
            <td><asp:Label ID="lblRole" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblCollInfoTitle" runat="server" Text=""></asp:Label>
    <asp:GridView ID="gvColllInfo" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="deptName" HeaderText="Department" />
            <asp:BoundField DataField="collectionPointName" HeaderText="Collection Point" />
            <asp:BoundField DataField="repNameID" HeaderText="Representative List" />
        </Columns>
    </asp:GridView>
</asp:Content>
