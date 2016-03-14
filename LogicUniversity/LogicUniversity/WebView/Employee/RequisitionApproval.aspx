
<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RequisitionApproval.aspx.cs" Inherits="LogicUniversity.WebView.Employee.Requisition_Approval" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="width:90%; margin-left:100px;">
    <asp:Label  style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;" 
        ID="Label1" runat="server" Text="Requisition Approval"></asp:Label>
    <br />
    <br />
    <br />
    <asp:Label style="font-family:Arial; font-size:16px;"
         ID="Label2" runat="server" Text="Department Name:"></asp:Label>
    <asp:Label  style="font-family:Arial; font-size:16px;" ID="lblDearptmentName" runat="server"></asp:Label>
    <br />
   

     <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-5%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 

                                     <div class="scrolling-table1">
    <asp:GridView ID="gvDataList"  runat="server" AutoGenerateColumns="False" 
                     CellPadding="4" Height="40px" Width="694px" Font-Bold="True" 
                     Font-Size="Large" ForeColor="#333333" GridLines="None"
         HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke" OnRowCreated="gvDataList_RowCreated"
                     >
                     <AlternatingRowStyle BackColor="White" />
                     <Columns>
                         <asp:BoundField DataField="RequisitionForm" HeaderText="RequisitionID"/>                     
                     
                         <asp:BoundField DataField="RequisitionItemID" HeaderText="RequisitionItemID" />
                         
                         <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" />
                          
                         <asp:BoundField DataField="SubmittedDate" HeaderText="SubmittedDate" />
                          
                         <asp:BoundField DataField="ItemDescription" HeaderText="ItemDescription" />
                     
                         <asp:BoundField DataField="Quantity" HeaderText="Quantity"  />
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

                         <asp:TemplateField HeaderText="Reason" >
                        <ItemTemplate>
                        
                          <asp:textbox id="txtReason" runat="server"></asp:textbox>
                          </ItemTemplate>
                             </asp:TemplateField>

                     </Columns>
                
                     <EditRowStyle BackColor="#2461BF" />
                   
                     <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                     <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                     <PagerStyle ForeColor="White" HorizontalAlign="Center" BackColor="#2461BF" />
                     <RowStyle BackColor="#EFF3FB" />
                     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                     <SortedAscendingCellStyle BackColor="#F5F7FB" />
                     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                     <SortedDescendingCellStyle BackColor="#E9EBEF" />
                     <SortedDescendingHeaderStyle BackColor="#4870BE" />
                 </asp:GridView>
    <br />
                                    </div></div></div></div>
    <br />
    <br />
    <asp:Button  cssClass="btn-custom" style="box-shadow: 5px 5px 10px grey;" 
        ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;
         </div>
</asp:Content>
