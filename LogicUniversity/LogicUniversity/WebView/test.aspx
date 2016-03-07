<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="LogicUniversity.WebView.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
    
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Button" />
    
        <br />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Button" />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
    
        <br />
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Button" />
    
    </div>
    </form>
</body>
</html>
