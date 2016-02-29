<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RequisitionApproval.aspx.cs" Inherits="LogicUniversity.WebView.Employee.Requisition_Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Requisition Approval"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Department Name:"></asp:Label>
    <asp:Label ID="lblDearptmentName" runat="server"></asp:Label>
    <br />
    <asp:GridView ID="gvDataList" runat="server">
    </asp:GridView>
    <br />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;
</asp:Content>
