<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="DelegateAuthority.aspx.cs" Inherits="LogicUniversity.WebView.Employee.DelegateAuthority" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblTitle" runat="server" Text="Delegate Authority"></asp:Label>
    <table class="auto-style1">
        <tr>
            <td><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtEmpID" runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" runat="server" Text="Label"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtDeptID" runat="server" Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" runat="server" Text="Label"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td>Delegate To</td>
            <td><asp:DropDownList ID="ddlDeptEmpList" runat="server" ></asp:DropDownList></td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>From Date</td>
            <td>
                <asp:TextBox ID="tbxFromDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgBtnCalFromDate" runat="server" Height="22px" ImageUrl="~/Images/calendar.png" OnClick="imgBtnCalFromDate_Click" />
            </td>
            <td><asp:Calendar ID="calFromDate" runat="server" Visible="False" OnSelectionChanged="calFromDate_SelectionChanged"></asp:Calendar></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>To Date</td>
            <td>
                <asp:TextBox ID="tbxToDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgBtnCalToDate" runat="server" Height="22px" ImageUrl="~/Images/calendar.png" OnClick="imgBtnCalToDate_Click" />
            </td>
            <td><asp:Calendar ID="calToDate" runat="server" Visible="False" OnSelectionChanged="calToDate_SelectionChanged"></asp:Calendar></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblChosenEmp" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblFromDate" runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblToDate" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td><asp:Button ID="btnAddDelegate" runat="server" Text="Add" OnClick="btnClick_AddDelegate" /></td>
        </tr>
    </table>
    <hr />
    <asp:Label ID="lblDeptDelGVTitle" runat="server" Text="Delegates History"></asp:Label>
    <asp:GridView ID="DeptDelegatesGridView" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="newPageDeptDelegatesGridView" PagerSettings-Mode="NumericFirstLast">
        <Columns>
            <asp:BoundField DataField="empNameID" HeaderText="Name" />
            <asp:BoundField DataField="fromDate" HeaderText="From Date" />
            <asp:BoundField DataField="toDate" HeaderText="To Date" />
<%--            <asp:BoundField DataField="edit" HeaderText="" />--%>
<%--            http://codeverge.com/asp.net.presentation-controls/gridview-hyperlink-field-based/470920--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="editHyperLink" runat="server" NavigateUrl='<%# Eval("DelegateID", "editDelegate.aspx?DelegateID={0}") %>'
                        Text="Edit" Visible='<%# (Eval("edit") == "" ? false : true) %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:BoundField DataField="cancel" HeaderText="" />--%>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl='<%# Eval("DelegateID", "CancelDelegate.aspx?DelegateID={0}") %>'
                        Text="Cancel" Visible='<%# (Eval("cancel") == "" ? false : true) %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
