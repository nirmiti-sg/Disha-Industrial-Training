<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="driver.aspx.cs" Inherits="dts.driver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <img src="logo.png" /><br />
    <div style="margin-top:10px; padding:30px;  " class="container shadow">
        <h2>Add new driver</h2>
        <asp:TextBox ID="txtname" style="margin-top:8px; padding:10px;" CssClass="form-control form-control-sm" runat="server" placeholder="name" ></asp:TextBox><br />
        <asp:TextBox ID="txtmono" style="padding:10px;" CssClass="form-control form-control-sm" runat="server" placeholder="mobile no" ></asp:TextBox><br />
        <asp:TextBox ID="txteid" style=" padding:10px;" CssClass="form-control form-control-sm" runat="server" placeholder="email id" ></asp:TextBox><br />
        <asp:TextBox ID="txtaddress" style="padding:10px;" CssClass="form-control form-control-sm" runat="server" placeholder="address" ></asp:TextBox><br />
        <asp:TextBox ID="txtpass" style="padding:10px;" CssClass="form-control form-control-sm" runat="server" placeholder="password" ></asp:TextBox><br />
        <asp:TextBox ID="txtvno" style="padding:10px;" CssClass="form-control form-control-sm" runat="server" placeholder="vehicle no." ></asp:TextBox><br />
        
        <asp:DropDownList runat="server" ID="drdtype" CssClass="form-select form-select-sm">


        </asp:DropDownList>
        <asp:Button ID="btnaddcust" style=" padding:10px; color:#ffffff; align-content:flex-end;" CssClass="btn btn-sm" runat="server" Text="Add" BackColor="#03045E" OnClick="btnadd_Click"   />
       
         
     <div style="margin-top:30px; margin-bottom:10px; padding:30px;  " class="container shadow">
        <h2> Existing drivers </h2>
         <center>

                <asp:GridView AutoGenerateColumns="False" runat="server" ID="gdname" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCommand="gdriver_RowCommand">
               
                    
                    <AlternatingRowStyle BackColor="#DCDCDC" />
               
                    
                    <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>

                             
                                <asp:Button CommandName="dele" CommandArgument='<%# Eval("id") %>' runat="server" Text="Delete" CssClass="btn btn-sm btn-outline-danger" />

                            </ItemTemplate>
                        </asp:TemplateField>


                          <asp:BoundField DataField="drivername" HeaderText="Driver Name" />
                          <asp:BoundField DataField="mobilenumber" HeaderText="Phone no" />
                          <asp:BoundField DataField="vehicleno" HeaderText="Vehicle Number" />
                          <asp:BoundField DataField="vehicletype" HeaderText="Vehicle type" />
                        <asp:TemplateField HeaderText="Flag">
                           <ItemTemplate>
                            <%# Eval("flag").ToString() == "1" ? "Active" : "Deactive" %>
                            </ItemTemplate>
                            </asp:TemplateField>

                        </columns> 
                        <columns>

                        <asp:TemplateField HeaderText="Activate">
                            <ItemTemplate>

                             
                                <asp:Button CommandName="act" CommandArgument='<%# Eval("id") %>' runat="server" Text="Activate" CssClass="btn btn-sm btn-outline-success" />

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

                       <Columns>

                        <asp:TemplateField>
                            <ItemTemplate>

                             
                                <asp:Button CommandName="deact" CommandArgument='<%# Eval("id") %>' runat="server" Text="Deactivate" CssClass="btn btn-sm btn-outline-danger" />

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
