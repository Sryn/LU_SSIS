<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LogicUniversity.WebView.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="txtMessage" runat="server"></asp:Label>
        <br />
    
        EmployeeID<asp:TextBox ID="txtEmployeeID" runat="server" Text="STR00003"></asp:TextBox>
        <br />
        PIN<asp:TextBox ID="txtPIN" runat="server" Text="000000"></asp:TextBox>
        <br />
        <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log In" />
        <br />
        <asp:LinkButton ID="lkBtnForgotPassword" runat="server">Forgot Password?</asp:LinkButton>
    
    </div>
    </form>
</body>
</html>
