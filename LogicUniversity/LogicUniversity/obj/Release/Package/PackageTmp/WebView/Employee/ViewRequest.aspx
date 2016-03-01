<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master"   EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="ViewRequest.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
      function showDialogue(itemid) {
          //alert("Are you sure want to delete this item."+itemid);
          if (confirm(' Are you sure want to delete this item. ' + itemid)) {
              return itemid;
          } else {
              return -1;
          }
        
      }
      function showDialogueReOrder(itemid) {
          if (confirm(' Are you sure want to Re_Order this item. ' + itemid)) {
              return itemid;
          } else {
              return -1;
          }
      }
        </script>
    
}
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Request List"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Item Description"></asp:Label>
    <asp:TextBox ID="txtItemDescription" runat="server"></asp:TextBox>
    Status<asp:DropDownList ID="ddlStatus" runat="server">
        <asp:ListItem Value="All">All</asp:ListItem>
        <asp:ListItem Value="PendingApproval">Pending Approval</asp:ListItem>
        <asp:ListItem Value="PartiallyFulfilled">Partially Fulfilled</asp:ListItem>
        <asp:ListItem Value="ReadyForCollection">Ready for Collection</asp:ListItem>
        <asp:ListItem>Collected</asp:ListItem>
        <asp:ListItem Value="NotCollected">Not Collected</asp:ListItem>
        <asp:ListItem>Approved</asp:ListItem>
        <asp:ListItem>Denied</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    <br />
    <asp:GridView ID="gvList" runat="server" 
        OnRowCreated="gvList_RowCreated" BackColor="White" 
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4" >
         <Columns>
                       
                  
              <asp:TemplateField HeaderText="Re_Order" >
                        <ItemTemplate>
                         <asp:HyperLink runat="server" ID="lnk_Reorder" 
                      onClick ="return confirm('Are you sure to Re_Order?');"
                                NavigateUrl='<%# "~/WebView/Employee/ViewRequest.aspx?RequisitionFormIDToReOder=" + Eval("RequisitionForm")%>'
                             commandName="lnk_reorder"
                              Text="ReOrder"></asp:HyperLink>
                          </ItemTemplate>
             </asp:TemplateField>
              <asp:TemplateField HeaderText="Edit" >
                        <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              NavigateUrl='<%# "~/WebView/Employee/RequestStationery.aspx?RequisitionFormID=" + Eval("RequisitionForm")%>' Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/Employee/ViewRequest.aspx?RequisitionFormIDToDelete=" + Eval("RequisitionForm")%>'
                               commandName="lnk_delete"                                                       
                                Text="Delete"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
       
          
       
         </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>
&nbsp;
</asp:Content>
