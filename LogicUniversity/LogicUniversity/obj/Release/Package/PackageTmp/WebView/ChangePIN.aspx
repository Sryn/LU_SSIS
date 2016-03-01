<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangePIN.aspx.cs" Inherits="LogicUniversity.WebView.ChangePIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="Label1" runat="server" Text="Change PIN"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Old PIN"></asp:Label>
        <asp:TextBox ID="txtOldPIN" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="New PIN"></asp:Label>
        <asp:TextBox ID="txtNewPIN" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Confirm New PIN"></asp:Label>
        <asp:TextBox ID="txtConfirmNewPIN" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnUpdate" runat="server" OnClick="btnUpdate_Click" Text="Update" />
</asp:Content>
