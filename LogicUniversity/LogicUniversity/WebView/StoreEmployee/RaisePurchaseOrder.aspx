<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RaisePurchaseOrder.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.RaisePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Raise New PO"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Description"></asp:Label>
    <asp:DropDownList ID="ddlDescription" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDescription_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Unit of Measure"></asp:Label>
    <asp:TextBox ID="txtUnitOfMeasure" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Quantity to Order"></asp:Label>
    <asp:TextBox ID="txtQuantityToOrder" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Required Delivery Date"></asp:Label>
    <asp:TextBox ID="txtRequiredDelivereyDate" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <asp:Label ID="Label7" runat="server" Text="Supplier Name"></asp:Label>
    <asp:DropDownList ID="ddlSupplierName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlSupplierName_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label8" runat="server" Text="Contact Name"></asp:Label>
    <asp:TextBox ID="txtContactName" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label9" runat="server" Text="Contact Email"></asp:Label>
    <asp:TextBox ID="txtContactEmail" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label10" runat="server" Text="Phone"></asp:Label>
    <asp:TextBox ID="txtPhone" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label11" runat="server" Text="Fax"></asp:Label>
    <asp:TextBox ID="txtFax" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
&nbsp;<br />
    <asp:GridView ID="gvDataList" runat="server">
         <Columns>                                                     
              <asp:TemplateField HeaderText="Edit" >
                <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              onClick ="return confirm('Are you sure to Edit?');"
                              NavigateUrl='<%# "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx?ItemItemIDToEdit="+Eval("ItemID")+"&SupplierIDToEdit="+Eval("SupplierID")%>' 
                              Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx?ItemItemIDToDelete="+Eval("ItemID")+"&SupplierIDToDelete="+Eval("SupplierID")%>'
                               commandName="lnk_delete"                                                       
                                Text="Delete"></asp:HyperLink>
                              </ItemTemplate>
             </asp:TemplateField>
                                        
         </Columns>
    </asp:GridView>
    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
    <br />
                          </ItemTemplate>
             </asp:TemplateField>         
</asp:Content>
