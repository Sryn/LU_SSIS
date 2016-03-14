<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="DelegateAuthority.aspx.cs" Inherits="LogicUniversity.WebView.Employee.DelegateAuthority" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: black;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .Pager span
        {
            color: black;
            background-color: #F7F7F7;
            font-weight: bold;
            text-align: center;
            display: inline-block;
            width: 20px;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #ccc;
        }
        .Pager a
        {
            text-align: center;
            display: inline-block;
            width: 20px;
            border: 1px solid #ccc;
            color: black;
          
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }
        .highlight
        {
          background-color:black;
            color:black;
            font-weight:bold;
            font-size:14px;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="width:90%; margin-left:100px;">
    <asp:Label ID="lblTitle"  style="font-family:'Arial Rounded MT'; 
font-weight:bold; font-size:40px;"
        runat="server" 
        Text="Delegate Authority"></asp:Label>
    <table class="auto-style1" style="width:50%;">
        <tr>
            <td><asp:Label ID="lblTxtSessType" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                runat="server" Text="Session[type]"></asp:Label></td>
            <td><asp:Label ID="lblSessType" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                runat="server" Text="Label"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtEmpID" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                runat="server" Text="EmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblEmpID" runat="server" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                Text="Label"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtDeptID" runat="server" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                Text="DepartmentID"></asp:Label></td>
            <td><asp:Label ID="lblDeptID" runat="server" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                 Text="Label"></asp:Label></td>
            <td></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label1" runat="server" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                Text="DelegateTo"></asp:Label></td>
            <td><asp:DropDownList ID="ddlDeptEmpList" runat="server" style="box-shadow: 5px 5px 8px grey; font-family:Arial; 
font-size:16px;" height="56px" Width="220px"></asp:DropDownList></td>
            <%-- http://www.dotnetspider.com/forum/203479-Date-validation-ASP-NET.aspx --%>
            <%-- http://stackoverflow.com/questions/133051/what-is-the-difference-between-visibilityhidden-and-displaynone --%>
            <td><asp:TextBox ID="tbxTodaysDate" runat="server" style="display:none"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label2" runat="server" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                Text="FromDate"></asp:Label></td>
            <td>
                <asp:TextBox ID="tbxFromDate" runat="server" 
                    style="box-shadow: 5px 5px 8px grey; font-family:Arial; font-size:16px;"
                    ></asp:TextBox>
                <asp:ImageButton ID="imgBtnCalFromDate" runat="server" Height="22px" ImageUrl="~/Images/calendar.png" OnClick="imgBtnCalFromDate_Click" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCalFromDate" runat="server" ErrorMessage="Please enter a From Date" ControlToValidate="tbxFromDate" 
                    ForeColor="Red" Display="Dynamic" ToolTip="Please enter a From Date" ValidationGroup="frmDelegateAuth">*
                </asp:RequiredFieldValidator>
                <asp:CompareValidator id="cvTodaysDate" runat="server" 
                     ControlToCompare="tbxTodaysDate" cultureinvariantvalues="true" 
                     display="Dynamic" enableclientscript="true"  
                     ControlToValidate="tbxFromDate" ForeColor="Red" 
                     ErrorMessage="From Date must not be earlier than today"
                     type="Date" setfocusonerror="true" Operator="GreaterThanEqual" 
                     text="From Date must not be earlier than today"
                     ValidationGroup="frmDelegateAuth" >*
                </asp:CompareValidator>
                <asp:Calendar ID="calFromDate" runat="server" Visible="False" OnSelectionChanged="calFromDate_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                Text="ToDate"></asp:Label></td>
            <td>
                <asp:TextBox style="box-shadow: 5px 5px 8px grey; font-family:Arial; font-size:16px;" ID="tbxToDate" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgBtnCalToDate" runat="server" Height="22px" ImageUrl="~/Images/calendar.png" OnClick="imgBtnCalToDate_Click" />
            </td>
            <td>
                <asp:RequiredFieldValidator ID="rfvCalToDate" runat="server" ErrorMessage="Please enter a To Date" ControlToValidate="tbxToDate"
                     ForeColor="Red" Display="Dynamic" ToolTip="Please enter a To Date" ValidationGroup="frmDelegateAuth">*
                </asp:RequiredFieldValidator>
<%--                http://stackoverflow.com/questions/9372901/asp-net-compare-validator-to-validate-date --%>
                <asp:CompareValidator id="cvtxtStartDate" runat="server" 
                     ControlToCompare="tbxFromDate" cultureinvariantvalues="true" 
                     display="Dynamic" enableclientscript="true"  
                     ControlToValidate="tbxToDate" ForeColor="Red" 
                     ErrorMessage="To Date must not be earlier than From Date"
                     type="Date" setfocusonerror="true" Operator="GreaterThanEqual" 
                     text="To Date must not be earlier than From Date"
                     ValidationGroup="frmDelegateAuth" >*
                </asp:CompareValidator>
                <asp:Calendar ID="calToDate" runat="server" Visible="False" OnSelectionChanged="calToDate_SelectionChanged"></asp:Calendar>
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="lblChosenEmp" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblFromDate" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                runat="server" Text=""></asp:Label></td>
            <td><asp:Label ID="lblToDate" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
                runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>

            <asp:Button ID="btnAddDelegate" cssClass="btn-custom2" 
                    style="box-shadow: 5px 5px 10px grey;" runat="server" 
                    Text="Add" OnClick="btnClick_AddDelegate" 
                    ValidationGroup="frmDelegateAuth" />
                
                <asp:Button ID="btnCancelEdit" cssClass="btn-custom2" 
                style="box-shadow: 5px 5px 10px grey;" runat="server" Text="Cancel" 
                Visible="false" OnClick="btnClick_CancelEdit" />
                <asp:Button ID="btnEditDelegate" cssClass="btn-custom2" 
                    style="box-shadow: 5px 5px 10px grey;"  runat="server" 
                    Text="Change" Visible="false" OnClick="btnClick_EditDelegate" />

                
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" style="align-content:center"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
    <hr />
    <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True" ForeColor="Red" ValidationGroup="frmDelegateAuth" />
    <asp:Label ID="lblDeptDelGVTitle" style="font-family:'Arial Rounded MT'; 
font-weight:bold; font-size:40px;"
        runat="server" Text="Delegates History"></asp:Label>
    
     <asp:GridView ID="DeptDelegatesGridView" HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke"
         runat="server" AutoGenerateColumns="false" 
         AllowPaging="true" OnPageIndexChanging="newPageDeptDelegatesGridView" PagerSettings-Mode="NumericFirstLast">
          <PagerStyle CssClass="pagination-ys"  />
          <Columns>
            <asp:BoundField DataField="empNameID" HeaderText="Name" />
            <asp:BoundField DataField="fromDate" HeaderText="From Date" />
            <asp:BoundField DataField="toDate" HeaderText="To Date" />
<%--            <asp:BoundField DataField="edit" HeaderText="" />--%>
<%--            http://codeverge.com/asp.net.presentation-controls/gridview-hyperlink-field-based/470920 --%>
            <asp:TemplateField HeaderText="Edit">
                <ItemTemplate>
                    <asp:HyperLink ID="editHyperLink" runat="server" NavigateUrl='<%# Eval("DelegateID", "DelegateAuthority.aspx?DelegateID={0}") %>'
                        Text="Edit" Visible='<%# (Eval("edit") == "" ? false : true) %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
<%--            <asp:BoundField DataField="cancel" HeaderText="" />--%>
            <asp:TemplateField HeaderText="Cancel">
                <ItemTemplate>
                    <asp:HyperLink ID="cancelHyperLink" runat="server" NavigateUrl='<%# Eval("DelegateID", "CancelDelegate.aspx?DelegateID={0}") %>'
                        Text="Cancel" Visible='<%# (Eval("cancel") == "" ? false : true) %>'></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
                                    </div></div></div></div>
</asp:Content>
