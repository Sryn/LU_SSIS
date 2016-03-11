<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="InventoryList.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.InventoryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Inventory List"></asp:Label>
    <asp:GridView ID="gvDataList" runat="server"
        OnRowCreated="gvDataList_RowCreated" OnRowDataBound="gvDataList_RowDataBound"
         HeaderStyle-CssClass="grid_head" 
        OnPageIndexChanging="gvDataList_PageIndexChanging"

        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke" AllowPaging="True" PageSize="15"

        >
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
</asp:Content>
