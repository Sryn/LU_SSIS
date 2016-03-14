<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="NotCollected.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.NotCollected" %>
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
     
          .auto-style2 {
              height: 38px;
          }
          .auto-style3 {
              height: 39px;
          }
     
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="width:90%; margin-left:100px;">
    <asp:Label ID="Label1" 
           style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;" 
        runat="server" Text="Not Collected"></asp:Label>
        <br />
        <br />
     <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
    <asp:GridView ID="gvDataList" runat="server" 
        HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke"  AllowPaging="True" PageSize="2" 
        OnRowCreated="gvDataList_RowCreated" OnPageIndexChanging="gvDataList_PageIndexChanging">
        <PagerStyle CssClass="pagination-ys"/>
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
                                    </div></div></div>
        </div>
</asp:Content>
