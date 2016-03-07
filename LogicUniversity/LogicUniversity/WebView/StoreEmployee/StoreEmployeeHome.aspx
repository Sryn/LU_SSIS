<%@ Page Title="" Language="C#" MasterPageFile="~/WebView/Site1.Master" AutoEventWireup="true" CodeBehind="Notifications.aspx.cs" Inherits="LogicUniversity.WebView.Notification" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    &nbsp;
    <br /><asp:Image ID="Image2"  runat="server" ImageUrl="~/images/cm-mockup01-o.jpg" Width="980px" Height="605px" />
     <div class="all">
     </div>

    <div class="ProfileImg">
    <asp:Image ID="Image1" class="img-circle" style="border-radius: 50%;" runat="server" ImageUrl="~/images/profilePicture.jpg" Width="190px" height="160px"/>
     </div>

    <div class="forWelcome">
    <asp:Label ID="Label1" runat="server" Text="Welcome" font-family= "Raleway" Font-Size="XX-Large"></asp:Label>
        </div>
    <div class="forname">
    <asp:Label ID="Label2" runat="server" Text="Shwe Yee" font-family= "Raleway" Font-Size="XX-Large" Width="146px"></asp:Label>
        </div>
&nbsp;
</asp:Content>