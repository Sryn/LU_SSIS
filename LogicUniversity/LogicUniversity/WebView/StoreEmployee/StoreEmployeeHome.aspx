<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="LogicUniversity.WebView.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;
    <div style="margin-left:0px">
    <br /><asp:Image ID="Image2"   runat="server" ImageUrl="~/images/cm-mockup01-o.jpg" Width="980px" Height="605px" />
     </div>
       
    <div class="ProfileImg">
    <asp:Image ID="Image1" class="img-circle" style="border-radius: 50%;" runat="server" 
        ImageUrl="~/images/profilePicture.jpg" Width="380px" height="300px"/>
     </div>

    <div class="forWelcome">
    <asp:Label ID="Label1" runat="server" Text="Welcome" font-family= "Raleway" Font-Size="40px"></asp:Label>
        </div>
    <div class="forname">
    <asp:Label ID="Label2" runat="server" Text="Shwe Yee" font-family= "Raleway" Font-Size="40px" Width="280px"></asp:Label>
        </div>
&nbsp;
</asp:Content>