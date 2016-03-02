<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeDepartmentRepresentative.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ChangeDepartmentRepresentative" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Change Department Representative"></asp:Label>
    <table class="auto-style1">
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td>Current Representative</td>
            <td><asp:Label ID="lblCurrDeptRep" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>New Representative</td>
            <td><asp:DropDownList ID="ddlNewDeptRep" runat="server" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblNewDeptRep" runat="server" Text=""></asp:Label></td>
            <td><asp:Button ID="btnChangeDeptRep" runat="server" Text="Change" OnClick="btnClick_ChangeDeptRep" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblNote" runat="server" Text="Note - Upon confirmation, an email notification will be sent to the current rep., new rep., dept. head and store clerks."></asp:Label></td>
        </tr>
    </table>
</asp:Content>
