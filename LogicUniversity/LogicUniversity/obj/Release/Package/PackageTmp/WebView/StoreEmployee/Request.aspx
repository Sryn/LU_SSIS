<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="Request.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Request"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="gvDataList" runat="server">
    </asp:GridView>
    <br />
    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
&nbsp;
</asp:Content>
