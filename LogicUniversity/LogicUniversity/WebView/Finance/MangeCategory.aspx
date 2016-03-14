<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="MangeCategory.aspx.cs" Inherits="LogicUniversity.WebView.Finance.MangeCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<<<<<<< HEAD
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
    <table style="width:50%; ">
        <tr>
            <td colspan="2"><asp:Label 
                ID="Label1" 
                style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;"
                runat="server" Text="Manage Category"></asp:Label></td>
        </tr>
          <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
        </tr>
          <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label  style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label4" runat="server" Text="Category"></asp:Label></td>
            <td><asp:TextBox ID="txtCategory" runat="server" style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;" Height="42px" Width="199px"
                ></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>

            
        </tr>
          <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td>&nbsp;</td>

            <td colspan="2"> 
                <asp:Button cssClass="btn-custom"    
                    style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                    ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="99px" /></td>
       
             </tr>
         
         <tr>
                  <td>&nbsp;</td>
                       </tr>
    </table>
    
     <br />
            
                        <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
    <asp:GridView ID="gvData" runat="server"
        HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke"
        AllowPaging="True" PageSize="5" 
        OnPageIndexChanging="gvData_PageIndexChanging" 
        OnRowCreated="gvData_RowCreated"
        >
        <PagerStyle CssClass="pagination-ys" />
         <Columns>                                                     
              <asp:TemplateField HeaderText="Edit" >
                <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              onClick ="return confirm('Are you sure to Edit?');"
                              NavigateUrl='<%# "~/WebView/Finance/MangeCategory.aspx?IDToEdit="+Eval("CategoryID")%>' 
                              Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/Finance/MangeCategory.aspx?IDToDelete="+Eval("CategoryID")%>'
                               commandName="lnk_delete"                                                       
                                Text="Delete"></asp:HyperLink>
                              </ItemTemplate>
             </asp:TemplateField>
                                        
         </Columns>
    </asp:GridView>
                                    </div>
                </div>
                            </div>
=======
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="Label1" runat="server" Text="Manage Category"></asp:Label></td>
        </tr>
        <tr>
            <td colspan="2"><asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Category"></asp:Label></td>
            <td><asp:TextBox ID="txtCategory" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td colspan="2"> <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /></td>
        </tr>
    </table>
    <asp:GridView ID="gvData" runat="server"></asp:GridView>
>>>>>>> origin/master
</asp:Content>
