<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="RaisePurchaseOrder.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.RaisePurchaseOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   <div style="width:90%; margin-left:140px;">
    <asp:MultiView ID="MultiView1" runat="server" OnActiveViewChanged="MultiView1_ActiveViewChanged" ActiveViewIndex="0">
       
          <asp:View ID="View1" runat="server">
              
      
              <table style="width: 100%;">
             <tr>
                  <td>&nbsp;</td>
                 
                 <td colspan="2"> <asp:Label 
                     style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;"
                      ID="Label1" runat="server" Text="Raise New PO"></asp:Label></td>
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
                      <td colspan="3"><asp:Label ID="lblMessage" runat="server"></asp:Label></td>
                  </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
            <tr>
                 <td>&nbsp;</td>
                <td> 
                    <asp:Label ID="Label2" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" runat="server" Text="Category"></asp:Label></td>
                <td>
                    <asp:DropDownList 
                        style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;" 
                        ID="ddlCategory" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" 
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
                    <asp:Label ID="Label3" style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" runat="server" Text="Description"></asp:Label></td>
                <td>
                     <asp:DropDownList 
                         style="box-shadow: 5px 5px 9px grey; 
font-family:Arial; font-size:16px;" ID="ddlDescription" runat="server" 
                         AutoPostBack="True" 
                         OnSelectedIndexChanged="ddlDescription_SelectedIndexChanged" 
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
                <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" ID="Label4" runat="server" Text="Unit of Measure"></asp:Label></td>
                <td><asp:TextBox style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;" 
                    ID="txtUnitOfMeasure" runat="server" Enabled="False" height="56px" Width="220px"></asp:TextBox></td>
                 <td>&nbsp;</td>
                  </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" ID="Label5" runat="server" Text="Quantity to Order"></asp:Label>
                </td>
                <td>
                     <asp:TextBox style="box-shadow: 5px 5px 9px #ffffcc; font-family:Arial; font-size:16px;" 
                         ID="txtQuantityToOrder" runat="server" height="56px" Width="220px"></asp:TextBox>
                </td>
                <td>

    <!-- Allows only numbers-->
     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
         runat="server" ControlToValidate="txtQuantityToOrder"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">       

     </asp:RegularExpressionValidator>
            <!--  Checks if textbox is blank-->
    
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtQuantityToOrder" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
            </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
             <tr>
                <td>&nbsp;</td>
                 <td>
                     <asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" ID="Label6" runat="server" Text="Required Delivery Date"></asp:Label>
                 </td>
                 <td>
                     <asp:TextBox style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;" 
                         ID="txtRequiredDelivereyDate" runat="server" TextMode="Date" height="56px" Width="220px"></asp:TextBox>
                 </td>
                  <td>&nbsp;</td>
             </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
              <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"  ID="Label7" runat="server" Text="Supplier Name"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList style="box-shadow: 5px 5px 9px grey; font-family:Arial; 
font-size:16px;" ID="ddlSupplierName" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlSupplierName_SelectedIndexChanged" height="56px" Width="220px">
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
                    <asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" ID="Label8" runat="server" Text="Contact Name"></asp:Label>
                </td>
                <td>
                    <asp:TextBox style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;" 
                        ID="txtContactName" runat="server" Enabled="False" height="56px" Width="220px"></asp:TextBox>
                </td>
                   <td>&nbsp;</td>
             </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                   <tr>
                <td>&nbsp;</td>
                <td>
                     <asp:Label style="text-shadow: 5px 5px 9px #ffffcc; font-family:Arial; font-size:19px;" ID="Label9" runat="server" Text="Contact Email"></asp:Label>
                </td>
                <td>
                    <asp:TextBox style="box-shadow: 5px 5px 9px grey; font-family:Arial; 
font-size:16px;" ID="txtContactEmail" runat="server" Enabled="False" height="56px" Width="220px"></asp:TextBox>
                </td>
                        <td>&nbsp;</td>
             </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                   <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" ID="Label10" runat="server" Text="Phone"></asp:Label>
                </td>
                <td>
                    <asp:TextBox style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;" 
                        ID="txtPhone" runat="server" Enabled="False" height="56px" Width="220px"></asp:TextBox>
                </td>
                        <td>&nbsp;</td>
             </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
                   <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;" ID="Label11" runat="server" Text="Fax"></asp:Label>
                </td>
                <td>
                     <asp:TextBox style="box-shadow: 5px 5px 9px grey; 
                    font-family:Arial; font-size:16px;" ID="txtFax" runat="server" 
                         Enabled="False" height="56px" Width="220px"></asp:TextBox>
                </td>
                        <td>&nbsp;</td>
             </tr>
                  <tr>
                  <td>&nbsp;</td>
                       </tr>
             <tr>
                <td>&nbsp;</td>
                 <td>
                       <asp:Button cssClass="btn-custom" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" 
                        style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"/>
                 </td>
                 <td>&nbsp;</td>
                  <td>&nbsp;</td>
                 </tr>
        </table>
       

        </asp:View>
        </asp:MultiView>
    
            <br />
            
                        <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
             <asp:GridView ID="gvDataList" runat="server" OnRowCreated="gvDataList_RowCreated"
                 HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke">
         <Columns>                                                     
              <asp:TemplateField HeaderText="Edit" >
                <ItemTemplate>
                          <asp:HyperLink runat="server" ID="lnk_edit" 
                              onClick ="return confirm('Are you sure to Edit?');"
                              NavigateUrl='<%# "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx?ItemItemIDToEdit="+Eval("ItemID")+"&SupplierIDToEdit="+Eval("SupplierID")%>' 
                              Text="Edit"></asp:HyperLink>
                          
                          </ItemTemplate>
             </asp:TemplateField>
             <asp:TemplateField HeaderText="Delete" >
                        <ItemTemplate>
                           <asp:HyperLink runat="server" ID="lnk_delete" 
                                onClick ="return confirm('Are you sure to delete?');"
                               NavigateUrl='<%# "~/WebView/StoreEmployee/RaisePurchaseOrder.aspx?ItemItemIDToDelete="+Eval("ItemID")+"&SupplierIDToDelete="+Eval("SupplierID")%>'
                               commandName="lnk_delete"                                                       
                                Text="Delete"></asp:HyperLink>
                              </ItemTemplate>
             </asp:TemplateField>
                                        
         </Columns>
    </asp:GridView>
                                    </div></div></div>
    <br />
    
    <asp:Button ID="btnConfirm" style="box-shadow: 5px 5px 10px grey;" cssClass="btn-custom" 
         runat="server" Text="Confirm" OnClick="btnConfirm_Click" />
    <br />
    <br />
       
        <br />
        <br />
        <br />
    
    <br />
          </div>                    
</asp:Content>
