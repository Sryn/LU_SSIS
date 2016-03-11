<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="MangeCategory.aspx.cs" Inherits="LogicUniversity.WebView.Finance.MangeCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Manage Category"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Category"></asp:Label></td>
            <td><asp:TextBox ID="txtCategory" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
    <asp:GridView ID="gvData" runat="server"></asp:GridView>
</asp:Content>
