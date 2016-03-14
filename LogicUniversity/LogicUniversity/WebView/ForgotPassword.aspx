<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="LogicUniversity.WebView.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" 
            style="font-family:'Arial Rounded MT'; font-weight:bold; 
font-size:40px;"
            runat="server" Text="Forgot Password"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" 
            style="text-shadow: 5px 5px 9px #ffffcc; font-family:Arial; font-size:19px;"
            Text="Enter PIN"></asp:Label>
        <asp:TextBox ID="txtPIN" 
            height="56px" Width="220px"  
           style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;"
            runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" 
            style="text-shadow: 5px 5px 9px #ffffcc; font-family:Arial; font-size:19px;"
            runat="server" Text="Enter Confirm PIN"></asp:Label>
        <asp:TextBox 
            height="56px" Width="220px"  
           style="box-shadow: 5px 5px 9px grey; font-family:Arial; font-size:16px;"
            ID="txtConfirmPIN" runat="server"></asp:TextBox>
        <br />
        <asp:Button 
            cssClass="btn-custom" style="box-shadow: 5px 5px 10px grey;" 
            class="btn btn-lg btn-block btn-info"
            ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change" />
    
    </div>
    </form>
</body>
</html>
