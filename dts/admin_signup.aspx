<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_signup.aspx.cs" Inherits="dts.admin_signup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-LN+7fdVzj6u52u30Kp6M/trliBMCMKTyK833zpbD+pXdCLuTusPj697FH4R/5mcr" crossorigin="anonymous">
    <title>Disha signup form</title>
</head>
<body>
    <form id="form1" runat="server">
    <img src="logo.png"  height="100px"/>
        <div>
           
<div style="margin-top:5%; margin-left:25%; border: solid 2px #f1f1f1; margin-right:25%; padding:20px; border-radius:10px ">
        <asp:TextBox CssClass="form-control form-control-sm" ID="txtusername" placeholder="Enter Name" runat="server"></asp:TextBox><br />
        <asp:TextBox placeholder="Enter phone no." CssClass="form-control form-control-sm" ID="txtphoneno" runat="server"></asp:TextBox><br />
        <asp:TextBox placeholder="Enter email id" CssClass="form-control form-control-sm" ID="txtmail" runat="server"></asp:TextBox><br />
        <asp:TextBox placeholder="Enter address" CssClass="form-control form-control-sm" ID="txtadd" runat="server"></asp:TextBox><br />
        <asp:TextBox TextMode="Password" placeholder="Enter password" CssClass="form-control form-control-sm" ID="txtpass" runat="server"></asp:TextBox><br />


        <div style="text-align:center">
<asp:Button CssClass="btn btn-sm btn-success" ID="btnadd" runat="server" Text="Sign up" OnClick="btnadd_Click" />
<asp:Button CssClass="btn btn-sm"  Style="background-color:#800000; color:white" ID="btnclear" runat="server"  Text="Clear" OnClick="btnclear_Click" />
  

    </div>
   

       
     <div style="margin-top:30px; margin-bottom:10px; padding:30px;  " class="container shadow">
        <h2> Admin list </h2>
         <center>

                <asp:GridView AutoGenerateColumns="False" runat="server" ID="ganame" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" >
               
                    
                    <AlternatingRowStyle BackColor="#DCDCDC" />
               
                    
                    <Columns>

                          <asp:BoundField DataField="name" HeaderText="Admin Name" />
                          <asp:BoundField DataField="phone_no" HeaderText="Contact no." />
                     

                 

                    </Columns>


                    
                     <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                    <SortedDescendingHeaderStyle BackColor="#000065" />

                </asp:GridView>

            </center>
    </div>
     </form>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.7/dist/js/bootstrap.bundle.min.js" integrity="sha384-ndDqU0Gzau9qJ1lfW4pNLlhNTkCfHzAVBReH9diLvGRem5+R9g2FzA8ZGN954O5Q" crossorigin="anonymous"></script>
</body>
</html>
