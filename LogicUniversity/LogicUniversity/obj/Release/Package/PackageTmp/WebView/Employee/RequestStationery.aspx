<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RequestStationery.aspx.cs" Inherits="LogicUniversity.WebView.Employee.RequestStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Request Stationery"></asp:Label>
    <asp:Label ID="lblTodayDate" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Category:"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Item Description:"></asp:Label>
    <asp:DropDownList ID="ddlItemDescription" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Unit of Measure:"></asp:Label>
    <asp:TextBox ID="txtUnitOfMeasure" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Requested Quantity:"></asp:Label>
    <asp:TextBox ID="txtRequestQty" runat="server"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
    <br />
    <asp:GridView ID="gvData" runat="server">
    </asp:GridView>
    <asp:Button ID="btnClearAll" runat="server" Text="Clear All" OnClick="btnClearAll_Click" />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;
</asp:Content>
