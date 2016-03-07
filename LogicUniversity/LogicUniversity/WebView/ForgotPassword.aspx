<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="LogicUniversity.WebView.ForgotPassword" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Forgot Password"></asp:Label>
        <br />
        <asp:Label ID="lblMessage" runat="server"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Enter PIN"></asp:Label>
        <asp:TextBox ID="txtPIN" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Enter Confirm PIN"></asp:Label>
        <asp:TextBox ID="txtConfirmPIN" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btnChange" runat="server" OnClick="btnChange_Click" Text="Change" />
    
    </div>
    </form>
</body>
</html>
