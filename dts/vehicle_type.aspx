<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="vehicle_type.aspx.cs" Inherits="dts.vehicle_type" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

  <img src="logo.png" /><br />

    <div class="container shadow" style=" margin-bottom:40px; padding:30px"">

        <h2>Add Vehicle Types</h2>
    <asp:TextBox runat="server" ID="txttype" CssClass="form-control form-control-sm" placeholder="Enter Vehicle type"></asp:TextBox>


    <div style="text-align:right; margin-top:20px">

        <asp:Button ID="btnadd" runat="server" Text="Add" CssClass="btn btn-sm btn-outline-success" OnClick="btnadd_Click" /><br />
    </div>


        <div style="margin-top:20px; margin-bottom:10px; padding:30px;  " class="container shadow">
        <h2> Existing vehicle types </h2>
            <center>

                <asp:GridView AutoGenerateColumns="False" runat="server" ID="gvtype" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCommand="gvtype_RowCommand">
                   
                    <AlternatingRowStyle BackColor="#DCDCDC" />
                   
                    <Columns>

                        <asp:BoundField DataField="vtype" HeaderText="Vehicle Type" />


<asp:TemplateField><ItemTemplate>
                                <asp:Button CommandName="dele" CommandArgument=<%#Eval("vid")%> runat="server" Text="Delete" CssClass="btn btn-sm btn-outline-danger" />

                            
</ItemTemplate>
</asp:TemplateField>


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





        </div>

</asp:Content>
