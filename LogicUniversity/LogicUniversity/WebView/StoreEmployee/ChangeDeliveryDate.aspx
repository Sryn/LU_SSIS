<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="ChangeDeliveryDate.aspx.cs" Inherits="LogicUniversity.WebView.StoreEmployee.ChangeDeliveryDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br />
    <br />
    <table>
       
             <tr>
                  <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td>&nbsp;</td>
                 <td colspan="2"> <asp:Label style="font-family:'Arial Rounded MT'; font-weight:bold; 
                    font-size:40px;" ID="Label5" runat="server" Text="Change Delivery Date"></asp:Label></td>
                  <td>&nbsp;                                
           
                  </td>
             </tr>
                  
                  
                   <tr>
                  <td>&nbsp;</td>
                       </tr>
                     
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">            
                <asp:Label ID="Label1" runat="server" Text="First Delivery Date" 
                    style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"></asp:Label>
                    </td>
                <td> <asp:TextBox ID="txtFirstCollectionDate" runat="server" height="56px" Width="220px"
                    style="box-shadow: 5px 5px 9px grey; font-family:Arial; 
font-size:16px;" ReadOnly="True"></asp:TextBox></td>
                </tr>
         <tr>
                <td>&nbsp;</td>
             </tr>
        <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">   
                 <asp:Label ID="Label3" runat="server" Text="Change To" 
                     style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; 
font-size:19px;"></asp:Label>
                    </td>
            <td>
    <asp:RadioButtonList ID="rdblFirstCollectionDate" runat="server">
        <asp:ListItem>Monday</asp:ListItem>
        <asp:ListItem>Tuesday</asp:ListItem>
        <asp:ListItem>Wednesday</asp:ListItem>
    </asp:RadioButtonList>
                </td>
             </tr>
         <tr>
                <td>&nbsp;</td>
             </tr>
         <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">   
    <asp:Label ID="Label2" runat="server" Text="Second Delivery Date" 
        style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"></asp:Label>
                    </td>
             <td>
    <asp:TextBox ID="txtSecondCollectionDate" runat="server" height="56px" Width="220px"
        style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;" 
        ReadOnly="True"></asp:TextBox>
                 </td>
             </tr>
         <tr>
                <td>&nbsp;</td>
             </tr>
        <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">   
    <asp:Label ID="Label4" runat="server" Text="Change To" 
        style="text-shadow: 10px 10px 22px #ffffcc; font-family:Arial; font-size:19px;"></asp:Label>
                    </td>
            <td>
    <asp:RadioButtonList ID="rdblSecondCollectionDate" runat="server">
        <asp:ListItem>Thursday</asp:ListItem>
        <asp:ListItem>Friday</asp:ListItem>
        <asp:ListItem>Saturday</asp:ListItem>
    </asp:RadioButtonList>
                </td>
            </tr>
         <tr>
                <td>&nbsp;</td>
             </tr>
         <tr>
                <td>&nbsp;</td>
             </tr>
        <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            <td>&nbsp;</td>
                <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td class="auto-style4">  
    <asp:Button ID="btnChangeDeliveryDate" cssClass="btn-custom1" 
        style="box-shadow: 5px 5px 10px grey;" class="btn btn-lg btn-block btn-info"
        runat="server" Text="Change Delivery" OnClick="btnChangeDeliveryDate_Click" Width="161px" />
</td>
</tr>
        </table>
</asp:Content>
