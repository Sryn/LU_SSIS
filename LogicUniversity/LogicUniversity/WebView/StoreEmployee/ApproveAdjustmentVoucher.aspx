<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ApproveAdjustmentVoucher.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.ApproveAdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Approve Adjustement Voucher"></asp:Label>
    <br />
    <asp:GridView ID="gvAdjVoucher" runat="server">
          <Columns>                                                     
               <asp:TemplateField HeaderText="Approve" >
                        <ItemTemplate>
                          <asp:RadioButton ID="Rdn_Approve" GroupName ="Approve" runat="server" Checked="true"/>
                          
                          </ItemTemplate>
                             </asp:TemplateField>
                           <asp:TemplateField HeaderText="Reject">
                            <ItemTemplate>
                         
                          <asp:RadioButton ID="Rdn_Reject" GroupName ="Approve" runat="server"/>
                          </ItemTemplate>
                       </asp:TemplateField>
         </Columns>
    </asp:GridView>
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
</asp:Content>
