<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="LogicUniversity.WebView.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
 
	
	<title>Sign In</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
      
	<!-- Google Fonts -->
	<link href='https://fonts.googleapis.com/css?family=Roboto+Slab:400,100,300,700|Lato:400,100,300,700,900' rel='stylesheet' type='text/css'/>

	<link rel="stylesheet" href="~/css/animate.css" type="text/css"/>
	<!-- Custom Stylesheet -->
	<link rel="stylesheet" href="~/css/style.css" type="text/css"/>

	<script src="https://ajax.googleapis.com/ajax/libs/jquery/2.1.4/jquery.min.js"></script>

</head>

<body>
    <form id="form2" runat="server">
	<div class="container">
		<div class="top">		    
		</div>
        <div class="img">
         <asp:Image ID="Image1" runat="server" Height="290px" ImageUrl="~/images/unilogo.png" Width="250px" />
           </div>

		<div class="login-box animated fadeInUp">
            
			<div class="box-header">
               
				<h2>Logic University</h2>
			</div>
			<label for="username">
<<<<<<< HEAD
		    <asp:Label ID="txtMessage" ForeColor="Red" Font-Size="Large" runat="server"></asp:Label>	<br />	   
            <asp:Label ID="lblMessage" ForeColor="Red" Font-Size="Large" runat="server"></asp:Label>
            <br />
            EmployeeID</label>
			<br/>
			<asp:TextBox ID="txtEmployeeID" runat="server"></asp:TextBox>
			<br/>
			<label for="password">PIN</label>
			<br/>
			<asp:TextBox ID="txtPIN" runat="server" TextMode="Password"></asp:TextBox>
=======
            <asp:Label ID="lblMessage" runat="server"></asp:Label>
            <br />
            EmployeeID</label>
			<br/>
			<asp:TextBox ID="txtEmployeeID" runat="server" Text="finance"></asp:TextBox>
			<br/>
			<label for="password">PIN</label>
			<br/>
			<asp:TextBox ID="txtPIN" runat="server"  Text="123456"></asp:TextBox>
>>>>>>> origin/master
			<br/>
			<asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Log In" />
			<br/>
			 <asp:LinkButton ID="lkBtnForgotPassword" runat="server" OnClick="lkBtnForgotPassword_Click">Forgot Password?</asp:LinkButton>
		
             </div>
	</div>
        </form>
</body>

<script>
	$(document).ready(function () {
    	$('#logo').addClass('animated fadeInDown');
    	$("input:text:visible:first").focus();
	});
	$('#username').focus(function() {
		$('label[for="username"]').addClass('selected');
	});
	$('#username').blur(function() {
		$('label[for="username"]').removeClass('selected');
	});
	$('#password').focus(function() {
		$('label[for="password"]').addClass('selected');
	});
	$('#password').blur(function() {
		$('label[for="password"]').removeClass('selected');
	});
</script>

</html>