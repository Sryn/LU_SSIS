<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="InventoryList.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.InventoryList" %>
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
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<<<<<<< HEAD
    <asp:Label ID="Label1" runat="server" 
         style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px; margin-left:40px;"  Text="Inventory List"></asp:Label>

    <br />
                        <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:2%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive">   
=======
    <asp:Label ID="Label1" runat="server" Text="Inventory List"></asp:Label>
>>>>>>> origin/master
    <asp:GridView ID="gvDataList" runat="server"
        OnRowCreated="gvDataList_RowCreated" OnRowDataBound="gvDataList_RowDataBound"
         HeaderStyle-CssClass="grid_head" 
        OnPageIndexChanging="gvDataList_PageIndexChanging"
<<<<<<< HEAD
      

         class="table table-bordered table-hover dataTable no-footer" 
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke" AllowPaging="True" PageSize="15"
      
        >
        <PagerStyle CssClass="pagination-ys" />
=======

        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke" AllowPaging="True" PageSize="15"

        >
>>>>>>> origin/master
 <Columns>
           <asp:TemplateField HeaderText="Raise PO" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_RaisePO" 
                                onClick ="return confirm('Are you sure?');"
                             NavigateUrl='<%# "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx?ItemID="+DataBinder.Eval(Container, "DataItem.ItemID")%>'
                                Text="Raise PO"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
       
          
       
         </Columns>
    </asp:GridView>
<<<<<<< HEAD
    </div>  
                            </div>  
                        
    </div>
              
=======
>>>>>>> origin/master
</asp:Content>
