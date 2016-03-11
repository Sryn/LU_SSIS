<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="NotCollected.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.NotCollected" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Not Collected"></asp:Label>
    <asp:GridView ID="gvDataList" runat="server" OnRowCreated="gvDataList_RowCreated">

          <Columns>
       <asp:TemplateField HeaderText="Not Collected" >
                        <ItemTemplate>
                         <asp:HyperLink runat="server" ID="lnk_Not" 
                      onClick ="return confirm('Are you sure?');"
                                NavigateUrl='<%# "~/WebView/StoreEmployee/NotCollected.aspx?DisbursementID=" + Eval("DisbursementID")%>'
                          
                              Text="Not Collected"></asp:HyperLink>
                          </ItemTemplate>
             </asp:TemplateField>
            </Columns>

    </asp:GridView>

</asp:Content>
