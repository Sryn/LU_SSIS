<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeDeliveryDate.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.ChangeDeliveryDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Next Delivery Date"></asp:Label>
    <asp:TextBox ID="txtFirstCollectionDate" runat="server"></asp:TextBox>
    <asp:Label ID="Label3" runat="server" Text="Change To"></asp:Label>
    <asp:RadioButtonList ID="rdblFirstCollectionDate" runat="server">
        <asp:ListItem>Monday</asp:ListItem>
        <asp:ListItem>Tuesday</asp:ListItem>
        <asp:ListItem>Wednesday</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    <asp:TextBox ID="txtSecondCollectionDate" runat="server"></asp:TextBox>
    <asp:Label ID="Label4" runat="server" Text="Change To"></asp:Label>
    <asp:RadioButtonList ID="rdblSecondCollectionDate" runat="server">
        <asp:ListItem>Thursday</asp:ListItem>
        <asp:ListItem>Friday</asp:ListItem>
        <asp:ListItem>Saturday</asp:ListItem>
    </asp:RadioButtonList>
    <asp:Button ID="btnChangeDeliveryDate" runat="server" Text="Change Delivery Date" OnClick="btnChangeDeliveryDate_Click" />
</asp:Content>
