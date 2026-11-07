<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="assigndriver.aspx.cs" Inherits="dts.assigndriver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




    <div class="container" style="margin-top:5%">

        <h2>Assign Driver</h2>
        <br />


        <asp:DropDownList runat="server" CssClass="form-select form-select-sm" ID="drddriver"></asp:DropDownList>

        <br />
        <asp:Button CssClass="btn btn-success btn-sm" ID="btnassigndriver" runat="server" Text="Assign Driver" OnClick="btnassigndriver_Click" />
     
        
           
    </div>
     <div style="margin-top:30px; margin-bottom:10px; padding:30px;  " class="container shadow">
        <h2> Assigned drivers </h2>
         <center>

                <asp:GridView AutoGenerateColumns="False" runat="server" ID="gassigndv" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" >
               
                    
                    <AlternatingRowStyle BackColor="#DCDCDC" />
               
                    
                    <Columns>

                          <asp:BoundField DataField="requestid" HeaderText="Request Id" />
                        <asp:BoundField DataField="drivername" HeaderText="Driver Name" />
                          <asp:BoundField DataField="vehicletype" HeaderText="Vehicle Type" />
                          <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle Number" />
                          <asp:BoundField DataField="date" HeaderText="Assign Date" />
                        
                       
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
</asp:Content>
