<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RaiseAdjustmentVoucher.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.RaiseAdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Raise Adjustment Voucher"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Category"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Item Description"></asp:Label>
    <asp:DropDownList ID="ddlItemDescription" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Unit of Measure"></asp:Label>
    <asp:TextBox ID="txtUnifOfMeasure" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Quantity To Adjust"></asp:Label>
    <asp:TextBox ID="txtQuantityToAdjust" runat="server"></asp:TextBox>
    <br />
    <asp:RadioButtonList ID="rblIncreaseOrDecrease" runat="server">
        <asp:ListItem Value="Increase" Selected="True">Increase</asp:ListItem>
        <asp:ListItem>Decrease</asp:ListItem>
    </asp:RadioButtonList>
    <br />
    <asp:Label ID="Label6" runat="server" Text="Reason for Adjustment"></asp:Label>
    <asp:TextBox ID="txtReason" runat="server"></asp:TextBox>
    <br />
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
&nbsp;<br />
    <asp:GridView ID="gvList" runat="server">
        <Columns>                                                     
              <asp:TemplateField HeaderText="Edit" >
                        <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              onClick ="return confirm('Are you sure to Edit?');"
                              NavigateUrl='<%# "~/WebView/StoreEmployee/RaiseAdjustmentVoucher.aspx?ItemCodeToEdit=" + Eval("ItemCode")%>' 
                              Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/StoreEmployee/RaiseAdjustmentVoucher.aspx?ItemCodeToDelete=" + Eval("ItemCode")%>'
                               commandName="lnk_delete"                                                       
                                Text="Delete"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>                       
         </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
</asp:Content>
