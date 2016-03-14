<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RaiseAdjustmentVoucher.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.RaiseAdjustmentVoucher" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div style="width:90%; margin-left:140px;">
       <table style="width: 100%;">
             <tr>
                  <td>&nbsp;</td>
                 
                 <td colspan="2"> <asp:Label 
                     style="font-family:'Arial Rounded MT'; font-weight:bold; 
font-size:40px;" ID="Label7" runat="server" Text="Raise Adjustment Voucher"></asp:Label></td>
                  <td>&nbsp;                                
           
                  </td>
             </tr>
                  
                   <tr>
                  <td>&nbsp;</td>
                       </tr>
                   <tr>
                  <td>&nbsp;</td>
                       </tr>
                  <tr>
                      <td colspan="1"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
 <tr>
                 <td>&nbsp;</td>
                <td> 
    <asp:Label ID="Label2" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
         runat="server" Text="Category"></asp:Label>
                    </td>
     <td>
    <asp:DropDownList ID="ddlCategory" runat="server" 
        style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;"
        AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" 
        height="56px" Width="220px">
    </asp:DropDownList>
    </td>
      <td>&nbsp;</td>
            </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                  
            <tr>
                <td>&nbsp;</td>
                <td>  
    <asp:Label ID="Label3" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
        runat="server" Text="Item Description"></asp:Label></td>
                <td>
    <asp:DropDownList ID="ddlItemDescription" runat="server" 
        AutoPostBack="True" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged" 
        height="56px" Width="220px"
        style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;">
    </asp:DropDownList>
                    </td>
                 <td>&nbsp;</td>
            </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                  
            <tr>
                <td>&nbsp;</td>
                <td>  
   
    <asp:Label ID="Label4" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
        runat="server" Text="Unit of Measure"></asp:Label>
                    </td>
                <td>
    <asp:TextBox ID="txtUnifOfMeasure"
        style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;"
         runat="server" Enabled="False" height="56px" Width="220px"></asp:TextBox>
    </td>
               
          <td>&nbsp;</td>
            </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                  
            <tr>
                <td>&nbsp;</td>
                <td>  
    <asp:Label ID="Label5" 
        runat="server"
        style="font-family:Arial; font-size:19px;"
         Text="Quantity To Adjust"></asp:Label>
                    </td>
                <td>
    <asp:TextBox ID="txtQuantityToAdjust" runat="server"
        style="text-shadow: 5px 5px 8px grey; font-family:Arial; 
font-size:16px;" height="56px" Width="220px"></asp:TextBox>
                    </td>
                 <td><!--  Checks if textbox is blank-->
      <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtQuantityToAdjust" ForeColor="Red"></asp:RequiredFieldValidator>

    <!-- Allows only numbers-->
     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
         runat="server" ControlToValidate="txtQuantityToAdjust"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">        </asp:RegularExpressionValidator></td>
            </tr>
                  <tr>
                 <td>&nbsp;</td>
                       </tr>
                  
            <tr>
                <td colspan="2">&nbsp;</td>
                <td>  
    <asp:RadioButtonList ID="rblIncreaseOrDecrease" runat="server">
        
        <asp:ListItem Value="Increase" Selected="True">Increase</asp:ListItem>
       
                
        <asp:ListItem>Decrease</asp:ListItem>
         </asp:RadioButtonList>
                   </td>
   
     <td>&nbsp;</td>
            </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                  
            <tr>
                <td>&nbsp;</td>
                <td>  
    <asp:Label ID="Label6" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"
        runat="server" Text="Reason for Adjustment"></asp:Label>
                    </td>
                <td>
    <asp:TextBox ID="txtReason" style="text-shadow: 5px 5px 9px grey; font-family:Arial; font-size:19px;"
        runat="server" height="56px" Width="220px"></asp:TextBox>
   </td>
                 <td> <!--  Checks if textbox is blank-->
      <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtReason" ForeColor="Red"></asp:RequiredFieldValidator>

 </td>
            </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                  
            <tr>
                <td>&nbsp;</td>
                <td>  
    <asp:Button ID="btnAdd" 
        cssClass="btn-custom" style="box-shadow: 5px 5px 10px grey;" 
        runat="server" OnClick="btnAdd_Click" Text="Add" />
&nbsp;<br />
                    </td>
                </tr>
         </table>
     <br />
            
                        <div id="mainContainer" class="container" style="width:94%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
    <asp:GridView ID="gvList" runat="server"
         HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke">
        
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
                                    </div></div></div>
    <br />
    <asp:Button ID="btnConfirm" cssClass="btn-custom" style="box-shadow: 5px 5px 10px grey;"  runat="server" OnClick="btnConfirm_Click" Text="Confirm" />
</div>
</asp:Content>
