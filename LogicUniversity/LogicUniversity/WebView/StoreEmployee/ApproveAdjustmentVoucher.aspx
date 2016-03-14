<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ApproveAdjustmentVoucher.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.ApproveAdjustmentVoucher" %>
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
            color: #333;
            font-weight: bold;
        }
        table th, table td
        {
            padding: 5px;
            border-color: #ccc;
        }
        .Pager span
        {
            color: #333;
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
            color: #fff;
            color: #333;
            margin-right: 3px;
            line-height: 150%;
            text-decoration: none;
        }
        .highlight
        {
            background-color: #FFFFAF;
        }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:90%; margin-left:120px;">
    <asp:Label ID="Label1"  style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;" 
        runat="server" Text="Approve Adjustement Voucher"></asp:Label>
    <br />
        <br />
    <div id="mainContainer" class="container" style="width:94%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive">   
    <asp:GridView ID="gvAdjVoucher" HeaderStyle-CssClass="grid_head" 
         class="table table-striped table-bordered table-hover dataTable no-footer" 
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke" AllowPaging="True" PageSize="4"
        runat="server" OnPageIndexChanging="gvAdjVoucher_PageIndexChanging" OnRowCreated="gvAdjVoucher_RowCreated">
        <PagerStyle CssClass="pagination-ys" />
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
<<<<<<< HEAD
                                    </div>
                </div>
        </div>
&nbsp;</div>
=======
&nbsp;
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
>>>>>>> origin/master
</asp:Content>
