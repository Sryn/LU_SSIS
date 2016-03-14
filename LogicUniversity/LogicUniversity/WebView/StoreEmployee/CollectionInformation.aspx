<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="CollectionInformation.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.CollectionInformation" %>
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
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .Pager span
        {
            color: #333;
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
            color: #fff;
            color: #333;
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }
        .highlight
        {
            background-color: #FFFFAF;
        }
     
          .auto-style2 {
              height: 38px;
          }
          .auto-style3 {
              height: 39px;
          }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:90%; margin-left:100px;">
    <asp:Label ID="lblTitle" runat="server" 
        style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;" 
        Text="Collection Information"></asp:Label>
    <table ID="Tt" style="width:57%;" runat="server">
        <tr>
            <td class="auto-style2"><asp:Label ID="lblTxtSessType" runat="server" Text="Session[type]"></asp:Label></td>
            <td class="auto-style2"><asp:Label ID="lblSessType" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="lblTxtStoreEmpID" runat="server" Text="StoreEmployeeID"></asp:Label></td>
            <td><asp:Label ID="lblStoreEmpID" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td class="auto-style3"><asp:Label ID="lblTxtRole" runat="server" Text="Role"></asp:Label></td>
            <td class="auto-style3"><asp:Label ID="lblRole" runat="server" Text="Label"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblCollInfoTitle" runat="server" Text=""></asp:Label>
    <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
    <asp:GridView 
        HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke"  AllowPaging="True" PageSize="2" 
        ID="gvColllInfo" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvColllInfo_PageIndexChanging">
       <PagerStyle CssClass="pagination-ys"/>
         <Columns>
            <asp:BoundField DataField="deptName" HeaderText="Department" />
            <asp:BoundField DataField="collectionPointName" HeaderText="Collection Point" />
            <asp:BoundField DataField="repNameID" HeaderText="Representative List" />
        </Columns>
    </asp:GridView>
                                    </div>
                </div>
        </div>
        </div>
</asp:Content>
