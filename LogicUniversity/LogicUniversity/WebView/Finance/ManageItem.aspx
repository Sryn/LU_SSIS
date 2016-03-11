<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageItem.aspx.cs" Inherits="LogicUniversity.WebView.Finance.ManageItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Manage Item"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="ItemID"></asp:Label></td>
            <td><asp:TextBox ID="txtItemID" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Description"></asp:Label></td>
            <td><asp:TextBox ID="txtDescription" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="Quantity"></asp:Label></td>
            <td><asp:TextBox ID="txtQuantity" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="Unit Of Measure"></asp:Label></td>
            <td><asp:TextBox ID="txtUOM" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label7" runat="server" Text="Category"></asp:Label></td>
            <td><asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label8" runat="server" Text="Reoder Level"></asp:Label></td>
            <td><asp:TextBox ID="txtReorderLevel" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label9" runat="server" Text="Reorder Quantity"></asp:Label></td>
            <td><asp:TextBox ID="txtReorderQuantity" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label10" runat="server" Text="QR Code"></asp:Label></td>
            <td><asp:FileUpload ID="fuplQRCode" runat="server" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label11" runat="server" Text="Bin No"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtBinNo" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
            <td><asp:Button ID="btnClearAll" runat="server" Text="Clear All" /></td>
        </tr>
    </table>
</asp:Content>
