<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site2.Master" AutoEventWireup="true" CodeBehind="RequestStationery.aspx.cs" Inherits="LogicUniversity.WebView.Employee.RequestStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Request Stationery"></asp:Label>
    <asp:Label ID="lblTodayDate" runat="server"></asp:Label>
    <br />
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Text="Category:"></asp:Label>
    <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label3" runat="server" Text="Item Description:"></asp:Label>
    <asp:DropDownList ID="ddlItemDescription" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <asp:Label ID="Label4" runat="server" Text="Unit of Measure:"></asp:Label>
    <asp:TextBox ID="txtUnitOfMeasure" runat="server" Enabled="False"></asp:TextBox>
    <br />
    <asp:Label ID="Label5" runat="server" Text="Requested Quantity:"></asp:Label>
    <asp:TextBox ID="txtRequestQty" runat="server"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
    <br />
    <asp:GridView ID="gvData" runat="server">
      
       
             <Columns>
                       
                  
            
              <asp:TemplateField HeaderText="Edit" >
                        <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              NavigateUrl='<%# "~/WebView/Employee/RequestStationery.aspx?ItemID=" + Eval("ItemID")%>' Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/Employee/RequestStationery.aspx?ItemIDToDelete=" + Eval("ItemID")%>'
                                                                                    
                                Text="Delete"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
       </Columns>
         
    </asp:GridView>
    <asp:Button ID="btnClearAll" runat="server" Text="Clear All" OnClick="btnClearAll_Click" />
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;
</asp:Content>
