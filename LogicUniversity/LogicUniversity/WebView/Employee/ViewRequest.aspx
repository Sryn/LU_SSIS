<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master"   EnableEventValidation="false"
    AutoEventWireup="true" CodeBehind="ViewRequest.aspx.cs" Inherits="LogicUniversity.WebView.Employee.ViewRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        table
        {
            border: 1px solid #ccc;
        }
        table th
        {
            background-color: #F7F7F7;
            color: black;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .Pager span
        {
            color: black;
            background-color: #F7F7F7;
            font-weight: bold;
            text-align: center;
            display: inline-block;
            width: 20px;
            margin-right: 3px;
            line-height: 150%;
            border: 1px solid #ccc;
        }
        .Pager a
        {
            text-align: center;
            display: inline-block;
            width: 20px;
            border: 1px solid #ccc;
            color: black;
          
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }
        .highlight
        {
          background-color:black;
            color:black;
            font-weight:bold;
            font-size:14px;
        }
     
    </style>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div style="width:90%; margin-left:100px;">
    <table style="width: 55%;">
             <tr>
                  <td>&nbsp;</td>
                 
                 <td colspan="3">
    <asp:Label ID="Label3" runat="server" style="font-family:'Arial Rounded MT'; 
font-weight:bold; font-size:40px;"
        Text="Request List"
        ></asp:Label>
                     </td>
                 </tr>
             <tr>
                  <td>&nbsp;</td>
                
                 </tr>
    <tr>
                      <td colspan="3">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
   </td>
    </tr>
         <tr>
                 <td>&nbsp;</td>
                <td> 
    <asp:Label ID="Label2" runat="server" style="text-shadow: 10px 10px 22px #ffffcc; 
font-family:Arial; font-size:19px;"
        Text="Item Description"></asp:Label>
                    </td>
             <td>
    <asp:TextBox ID="txtItemDescription" 
         style="box-shadow: 5px 5px 6px grey; font-family:Arial; font-size:16px;" 
      height="56px" Width="220px"
        runat="server"></asp:TextBox>
                 </td>
             <td> 
    <asp:Label ID="Label1" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" 
        runat="server" Text="Status"></asp:Label>
    </td>
             <td>

             <asp:DropDownList ID="ddlStatus" runat="server"
                  style="box-shadow: 5px 5px 6px grey; font-family:Arial; 
font-size:16px;" height="56px" Width="220px">
        <asp:ListItem Value="All">All</asp:ListItem>
        <asp:ListItem Value="PendingApproval">Pending Approval</asp:ListItem>
        <asp:ListItem Value="PartiallyFulfilled">Partially Fulfilled</asp:ListItem>
        <asp:ListItem Value="ReadyForCollection">Ready for Collection</asp:ListItem>
        <asp:ListItem>Collected</asp:ListItem>
        <asp:ListItem Value="NotCollected">Not Collected</asp:ListItem>
        <asp:ListItem>Approved</asp:ListItem>
        <asp:ListItem>Denied</asp:ListItem>
    </asp:DropDownList>
                 </td>
             <td>
    <asp:Button ID="btnSearch" runat="server" cssClass="btn-custom2" style="box-shadow: 5px 5px 10px grey;"
        OnClick="btnSearch_Click" Text="Search" />
    </td>
             
             </tr>
        <tr>
            <td> <br />
    <br /></td>
        </tr>
        </table>
    <br />
    
    <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
    <asp:GridView ID="gvList" runat="server" 
         HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke"
        OnRowCreated="gvList_RowCreated" AllowPaging="True"
         OnPageIndexChanging="gvList_PageIndexChanging" PageSize="5" >
        
        <PagerStyle CssClass="pagination-ys"  />
          
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
        <HeaderStyle />
        <PagerStyle BackColor="#2461BF" ForeColor="black" HorizontalAlign="Center" />
        <RowStyle />
    </asp:GridView>
                                    </div></div></div></div>
&nbsp;
</asp:Content>
