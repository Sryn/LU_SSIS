<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Finance/FinanceMasterPage.Master" AutoEventWireup="true" CodeBehind="ManageItem.aspx.cs" Inherits="LogicUniversity.WebView.Finance.ManageItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 43px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td colspan="2"><asp:Label ID="Label1" runat="server" 
                style="font-family:'Arial Rounded MT'; font-weight:bold; font-size:40px;"
                Text="Manage Item"></asp:Label></td>
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
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label3" runat="server" Text="ItemID"></asp:Label></td>
            <td class="auto-style2"><asp:TextBox ID="txtItemID" 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"  runat="server" Height="45px" Width="266px"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidatorAccount" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtItemID" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label4" runat="server" Text="Description"></asp:Label></td>
            <td class="auto-style2"><asp:TextBox style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                ID="txtDescription" runat="server"
                Height="45px" Width="266px"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtDescription" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label5" runat="server" Text="Quantity"></asp:Label></td>

            <td class="auto-style2"><asp:TextBox 
                ID="txtQuantity" style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                Height="45px" Width="266px" runat="server"></asp:TextBox></td>
            <td>
                 
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtQuantity" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
         runat="server" ControlToValidate="txtQuantity"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"/>  
                    </td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label6" runat="server" Text="Unit Of Measure"></asp:Label></td>
            <td class="auto-style2"><asp:TextBox ID="txtUOM" style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                Height="45px" Width="266px" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtUOM" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label7" runat="server" Text="Category"></asp:Label></td>
            <td class="auto-style2"><asp:DropDownList style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                Height="45px" Width="266px"
                ID="ddlCategory" runat="server"></asp:DropDownList></td>
           
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label8" runat="server" Text="Reoder Level"></asp:Label></td>
            <td class="auto-style2"><asp:TextBox ID="txtReorderLevel" 
                style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                Height="45px" Width="266px" runat="server"></asp:TextBox></td>
            <td>
                
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtReorderLevel" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
         runat="server" ControlToValidate="txtReorderLevel"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"/> 
                    </td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label9" runat="server" Text="Reorder Quantity"></asp:Label></td>
            <td class="auto-style2"><asp:TextBox 
                ID="txtReorderQuantity" style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                Height="45px" Width="266px" runat="server"></asp:TextBox></td>
            <td>
                 
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtReorderQuantity" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" 
         runat="server" ControlToValidate="txtReorderQuantity"
    ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"/> 
                    </td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label10" runat="server" Text="QR Code"></asp:Label></td>
            <td class="auto-style2"><asp:FileUpload ID="fuplQRCode" Height="35px" Width="266px" runat="server" /></td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Label style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
                        font-size:19px;" 
                ID="Label11" runat="server" Text="Bin No"></asp:Label></td>
            <td class="auto-style2">
                <asp:TextBox style="box-shadow: 5px 5px 7px grey;
                        font-family:Arial; font-size:16px;"
                    ID="txtBinNo" Height="45px" Width="266px" runat="server"></asp:TextBox></td>
            <td>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
          ErrorMessage="*Required"
      ControlToValidate="txtBinNo" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
        </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
                  <td>&nbsp;</td>
                       </tr>
        <tr>
            <td><asp:Button cssClass="btn-custom"    
                    style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                 ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
           &nbsp; &nbsp; &nbsp; &nbsp;
            &nbsp; &nbsp; &nbsp; &nbsp;</td>
            <td><asp:Button cssClass="btn-custom"    
                    style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
                ID="btnClearAll" runat="server" Text="Clear All" /></td>
        </tr>
    </table>
</asp:Content>
