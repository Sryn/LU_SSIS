<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" 
    CodeBehind="Request.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="LogicUniversity.WebView.StoreEmployee.Request" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="margingAlignTop">
    <asp:Label ID="Label1" runat="server" Text="Request"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
        </div>
     <div class="scrolling-table">
    <asp:GridView ID="gvDataList"  HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke"
        runat="server" OnRowCreated="gvDataList_RowCreated" 
        style="margin-right: 0px"  OnRowDataBound="gvDataList_RowDataBound" OnDataBound="gvDataList_DataBound" 
        >
        <Columns>
        <asp:TemplateField HeaderText="ActualQty" >
                        <ItemTemplate>
                           <asp:TextBox ID="txtQty" runat="server" Width="30px" OnTextChanged="txtQty_TextChanged"
                               Text='<%# Eval("ActualQty") %>'
                                AutoPostBack="true">
                                
                               </asp:TextBox>
                          </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="TotalReceived" >
                        <ItemTemplate>
                           <asp:TextBox ID="txttotalQty" runat="server" Width="30px" 
                               Text='<%# Eval("TotalReceived") %>'
                               OnTextChanged="txttotalQty_TextChanged"
                             AutoPostBack="true">
                                
                               </asp:TextBox>
                          </ItemTemplate>
             </asp:TemplateField>
            </Columns>
        <HeaderStyle />
        <RowStyle />
    </asp:GridView>
    <br />
         </div>
     <br /> <br />
      <div class="margingAlign">
    <asp:Button ID="btnConfirm" runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
          </div>
&nbsp;
</asp:Content>
