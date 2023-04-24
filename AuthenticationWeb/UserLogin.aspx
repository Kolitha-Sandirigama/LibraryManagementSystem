<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="LibrarySystemWeb.UserLogin" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   
<title>Login</title>
<link href="Styles/Login.css" rel="stylesheet" type="text/css" />
    
 

    
<img src="Images/Library_Login.png" />
    
</head>

<body class="wrapper" style="background-color:#ffffff">
    <form id="form1" runat="server">

  

    <div>
<table class="cs">

<tr>
<td>User Name</td>
<td>:</td>
<td>
<asp:TextBox ID="txtUserName"  runat="server" Width="120px"></asp:TextBox></td> 
<td> * </td>

</tr>
<tr>
<td>Password  </td>
<td>:</td>
<td>
<asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="120px" ></asp:TextBox> 
</td>
<td>*</td>
</tr>
<tr>
<td colspan="4">
<asp:Label ID="lblMessage" runat="server"></asp:Label>
</td>

</tr>
<tr>
<td colspan="2" style="font-weight: 700"></td>
<td align="right">
    <asp:Button ID="btnSubmit" runat="server" 
                        Text="Login" onclick="btnSubmit_Click" /></td>

</tr>
</table>

</div>
</form>

</body>
 



</html>

