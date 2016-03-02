<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeCollectionPoint.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ChangeCollectionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblChangeCollPt" runat="server" Text="Change Collection Point"></asp:Label>
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
            <td>Department Representative</td>
            <td><asp:Label ID="lblDeptRep" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Department</td>
            <td><asp:Label ID="lblDeptName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>Current Collection Point</td>
            <td><asp:Label ID="lblCurrCollPt" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>New Collection Point</td>
            <td><asp:DropDownList ID="ddlNewCollPt" runat="server" ></asp:DropDownList></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="lblNewCollPt" runat="server" Text=""></asp:Label></td>
            <td><asp:Button ID="btnChangeCollPt" runat="server" Text="Change" OnClick="btnClick_ChangeCollPt" /></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2" style="align-content:center"><asp:Label ID="lblChangeResult" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
</asp:Content>
