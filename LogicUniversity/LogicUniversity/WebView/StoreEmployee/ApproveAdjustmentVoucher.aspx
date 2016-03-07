<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ApproveAdjustmentVoucher.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.ApproveAdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Approve Adjustement Voucher"></asp:Label>
    <br />
    <asp:GridView ID="gvAdjVoucher" runat="server">
          <Columns>                                                     
              <asp:TemplateField HeaderText="Edit" >
                        <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              onClick ="return confirm('Are you sure to Edit?');"
                              NavigateUrl='<%# "~/WebView/StoreEmployee/ApproveAdjustmentVoucher.aspx?ItemCodeToEdit=" + Eval("ItemCode")%>' 
                              Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/StoreEmployee/ApproveAdjustmentVoucher.aspx?ItemCodeToDelete=" + Eval("ItemCode")%>'
                               commandName="lnk_delete"                                                       
                                Text="Delete"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>                       
         </Columns>
    </asp:GridView>
&nbsp;
</asp:Content>
