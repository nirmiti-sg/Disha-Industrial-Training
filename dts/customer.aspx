<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="dts.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <img src="logo.png" /><br />

    <div style="margin-top: 10px; margin-bottom: 40px; padding: 30px;" class="container shadow">
        <h2>Add new customer</h2>
        <asp:TextBox ID="txtpname" Style="margin-top: 8px; padding: 10px;" MaxLength="50" CssClass="form-control form-control-sm" runat="server" placeholder="party name"></asp:TextBox><br />
        <asp:TextBox ID="txtaddress" Style="padding: 10px;" MaxLength="100" CssClass="form-control form-control-sm" runat="server" placeholder="party address"></asp:TextBox><br />
        <asp:TextBox ID="txtconperson" Style="padding: 10px;" MaxLength="50" CssClass="form-control form-control-sm" runat="server" placeholder="contact person name"></asp:TextBox><br />
        <asp:TextBox ID="txtphoneno" MaxLength="10" Style="padding: 10px;" CssClass="form-control form-control-sm" runat="server" placeholder="phone no"></asp:TextBox><br />
        <asp:TextBox ID="txtpanno" Style="padding: 10px;" MaxLength="20" CssClass="form-control form-control-sm" runat="server" placeholder="pan no"></asp:TextBox><br />
        <asp:TextBox ID="txtgstno" Style="padding: 10px;" MaxLength="20" CssClass="form-control form-control-sm" runat="server" placeholder="gst no"></asp:TextBox><br />
        <asp:TextBox ID="txtpass" Style="padding: 10px;" CssClass="form-control form-control-sm" runat="server" placeholder="password"></asp:TextBox><br />

        <asp:Button ID="btnaddcust" Style="padding: 10px; color: #ffffff; align-content: flex-end;" CssClass="btn btn-sm" runat="server" Text="Add" BackColor="#03045E" OnClick="btnadd_Click" />



        <div style="margin-top: 30px; margin-bottom: 10px; padding: 30px;" class="container shadow">
            <h2>Existing customer </h2>
            <center>

                <asp:GridView AutoGenerateColumns="False" runat="server" ID="gvname" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" OnRowCommand="gcustomer_RowCommand">
               
                    
                    <AlternatingRowStyle BackColor="#DCDCDC" />
               
                    
                    <Columns>
                                                <asp:TemplateField>
                            <ItemTemplate>

                             
                                <asp:Button CommandName="dele" CommandArgument='<%# Eval("id") %>' runat="server" Text="Delete" CssClass="btn btn-sm btn-outline-danger" />

                            </ItemTemplate>
                        </asp:TemplateField>


                          <asp:BoundField DataField="party_name" HeaderText="Party Name" />
                          <asp:BoundField DataField="contact_person_name" HeaderText="Contact Person" />
                          <asp:BoundField DataField="phone_no" HeaderText="Phone Number" />
                          <asp:TemplateField HeaderText="Flag">
                           <ItemTemplate>
                            <%# Eval("flag").ToString() == "1" ? "Active" : "Deactive" %>
                            </ItemTemplate>
                            </asp:TemplateField>

                    </Columns>

                    <Columns>

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
