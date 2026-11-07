<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_login.aspx.cs" Inherits="dts.admin_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">


    <title>Disha Transport System</title>
</head>
<body>
    <form id="form1" runat="server">
        <img src="logo.png"  height="100px"/>
    <div style="margin-top:10%; margin-left:25%; border: solid 2px #f1f1f1; margin-right:25%; padding:20px; border-radius:10px ">
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtusername" placeholder="Enter User Name" runat="server"></asp:TextBox><br />
        <asp:TextBox TextMode="Password" placeholder="Enter Password" CssClass="form-control form-control-sm" ID="txtpass" runat="server"></asp:TextBox><br />
       
        <div style="text-align:center">
         <asp:Button  CssClass="btn btn-sm btn-success" PostBackUrl="home.aspx" ID="btnlogin" href="admin.Master" runat="server" Text="Login" />
        <asp:Button CssClass="btn btn-sm" Style="background-color:#800000; color:white" ID="btnclear" runat="server" Text="Clear" /><br />
  
            <a href="admin_signup.aspx" style="margin_top=10px">Sign up</a>
    </div>
        </div>
    </form>




<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js" integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous"></script>

</body>
</html>
