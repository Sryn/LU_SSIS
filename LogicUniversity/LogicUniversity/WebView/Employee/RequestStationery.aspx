<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site2.Master" AutoEventWireup="true" CodeBehind="RequestStationery.aspx.cs" Inherits="LogicUniversity.WebView.Employee.RequestStationery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <table style="width: 100%; margin-left:80px;">
             <tr>
                  <td>&nbsp;</td>
                 
                 <td colspan="3">
    <asp:Label ID="Label1" runat="server" style="font-family:'Arial Rounded MT'; 
font-weight:bold; font-size:40px;"  
        Text="Request Stationery"
        ></asp:Label>
                     </td>
                 </tr>
             <tr>
                  <td>&nbsp;</td>
                
                 </tr>
                  <tr>
                        <td>&nbsp;</td>
                      <td>
    <asp:Label ID="lblTodayDate" runat="server" ></asp:Label>
   </td>
                      </tr>
             
                  <tr>
                       <td>&nbsp;</td>
                      <td colspan="1">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
   </td>
                      </tr>
           <tr>
                 <td>&nbsp;</td>
                <td> 
    <asp:Label ID="Label2" runat="server" Text="Category:"
        style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"></asp:Label>
   </td>
               <td>
                     <asp:DropDownList ID="ddlCategory" style="box-shadow: 5px 5px 6px grey; font-family:Arial; font-size:16px;"
        runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" 
                         height="56px" Width="220px">
    </asp:DropDownList>
                   </td>
   </tr>
          <tr>
                  <td>&nbsp;</td>
                
                 </tr>
           <tr>
                 <td>&nbsp;</td>
                <td> 
    <asp:Label ID="Label3" runat="server" Text="Item Description:"
        style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"></asp:Label>
    </td>
               <td>
                    <asp:DropDownList ID="ddlItemDescription" 
                        style="box-shadow: 5px 5px 6px grey; font-family:Arial; font-size:16px;"
        runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlItemDescription_SelectedIndexChanged" 
                       height="56px" Width="220px">
    </asp:DropDownList>
    </td>
               </tr>
          <tr>
                  <td>&nbsp;</td>
                
                 </tr>
          <tr>
                 <td>&nbsp;</td>
                <td> 
    <asp:Label ID="Label4" runat="server" Text="Unit of Measure:"
        style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"></asp:Label>
    </td>
              <td>
                    <asp:TextBox ID="txtUnitOfMeasure" runat="server" Enabled="False"
        style="box-shadow: 5px 5px 6px grey; font-family:Arial; font-size:16px;" 
                       height="56px" Width="220px"></asp:TextBox>
    </td>
              </tr>
          <tr>
                  <td>&nbsp;</td>
                
                 </tr>
          <tr>
                 <td>&nbsp;</td>
                <td> 
    <asp:Label ID="Label5" runat="server" Text="Requested Quantity:"
        style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"></asp:Label>
   </td>
              <td>
                     <asp:TextBox ID="txtRequestQty" runat="server" 
                         style="box-shadow: 5px 5px 6px grey; font-family:Arial; 
font-size:16px;" height="56px" Width="220px"
        ></asp:TextBox>
                  </td>
              <td>
    <!-- Allows only numbers-->
     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
         runat="server" ControlToValidate="txtRequestQty"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$">       

     </asp:RegularExpressionValidator>
            <!--  Checks if textbox is blank-->
    
              <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtRequestQty" ForeColor="Red"></asp:RequiredFieldValidator>
                  </td>
              </tr>
          <tr>
                  <td>&nbsp;</td>
                
                 </tr>
         <tr>
                 <td>&nbsp;</td>
                <td> 
    <asp:Button ID="btnAdd" cssClass="btn-custom2" style="box-shadow: 5px 5px 10px grey;"
        runat="server" OnClick="btnAdd_Click" Text="Add" />
    </td></tr>
          </table>

    <br />
    <br />
<<<<<<< HEAD
    <div id="mainContainer" class="container" style="width:98%; position:relative; margin-left:-1%;" >  
            <div class="shadowBox">                           
                                <div class="table-responsive"> 
    <asp:GridView ID="gvData" runat="server"
         HeaderStyle-CssClass="grid_head" 
        CssClass="table table-hover table-bordered"
        RowStyle-CssClass="grid_row" HorizontalAlign="Center"
        HeaderStyle-BackColor="WhiteSmoke" OnRowCreated="gvData_RowCreated">
=======
    <asp:Label ID="Label5" runat="server" Text="Requested Quantity:"></asp:Label>
    <asp:TextBox ID="txtRequestQty" runat="server"></asp:TextBox>
    <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" />
    <br />
    <asp:GridView ID="gvData" runat="server">
>>>>>>> origin/master
      
       
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
                                    </div>
                </div>
        </div>
    <br />
    <br />

    <asp:Button ID="btnClearAll" runat="server" cssClass="btn-custom2" style="box-shadow: 5px 5px 10px grey;"
        Text="Clear All" OnClick="btnClearAll_Click" />
    <asp:Button ID="btnSubmit" runat="server"  cssClass="btn-custom2" style="box-shadow: 5px 5px 10px grey;"
        OnClick="btnSubmit_Click" Text="Submit" />
&nbsp;
</asp:Content>
