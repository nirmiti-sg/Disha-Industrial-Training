<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="dts.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">




   <img src="logo.png" /><br />
     <div class="container shadow" style=" margin-bottom:40px; padding:30px"">

        <h2>vehicle requests</h2>
    
         <center>
         <asp:GridView runat="server" ID="gvdata" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="gvrequeast_RowCommand">
             <AlternatingRowStyle BackColor="#F7F7F7" />
             <Columns>
                 <asp:BoundField DataField="id" HeaderText="ID" />
                 <asp:BoundField DataField="vehicle_type" HeaderText="Vehicle Type" />
                 <asp:BoundField DataField="consignor" HeaderText="Consignor" />
                 <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                 <asp:BoundField DataField="billing_party" HeaderText="Billing party" />
                 <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                 <asp:BoundField DataField="weight" HeaderText="Weight" />
                 <asp:BoundField DataField="date" HeaderText="Date" />
                 <asp:BoundField DataField="time" HeaderText="Time" />


             </Columns>
                   
              <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CommandName="accept" CommandArgument=<%#Eval("id")%> runat="server" Text="Accept" CssClass="btn btn-sm btn-outline-success" />

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

              
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CommandName="dele" CommandArgument=<%#Eval("id")%> runat="server" Text="Delete" CssClass="btn btn-sm btn-outline-danger" />

                            </ItemTemplate>
                        </asp:TemplateField>


                    </Columns>
                                 <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CommandName="assigndv" CommandArgument=<%#Eval("id")%> runat="server" Text="Assign Driver" CssClass="btn btn-sm btn-outline-success" />

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>

            
             <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
             <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
             <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
             <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
             <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
             <SortedAscendingCellStyle BackColor="#F4F4FD" />
             <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
             <SortedDescendingCellStyle BackColor="#D8D8F0" />
             <SortedDescendingHeaderStyle BackColor="#3E3277" />
         </asp:GridView>
             </center>


         <div style="margin-top:50px">
         <asp:Panel ID="panelupdate" runat="server" Visible="false">


             <div>

                 <asp:TextBox runat="server" ID="txtrid" Enabled="false" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrbooking" placeholder="Enter Booking" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrdelivery" placeholder="Enter Delivery" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrgstno" placeholder="Enter GST no" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrpaytype" placeholder="Enter Pay type" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrvno" placeholder="Enter Vehicle no" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrlrtotal" placeholder="Enter Lr total" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrackstatus" placeholder="Enter ACK status" CssClass="form-control form-control-sm"></asp:TextBox><br />
                 <asp:TextBox runat="server" ID="txtrpoduplodedstatus" placeholder="Enter pod uploded status" CssClass="form-control form-control-sm"></asp:TextBox><br />

                 <asp:Button runat="server" ID="requestupdate" Text="Update" CssClass="btn btn-sm btn-outline-success" OnClick="btnupdate_Click" />



             </div>





         </asp:Panel>
   
         </div>






         </div>

      <div class="container shadow" style=" margin-bottom:40px; padding:30px"">

        <h2>Records</h2>
    
         <center>
         <asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal" OnRowCommand="GridView2_RowCommand">
             <AlternatingRowStyle BackColor="#F7F7F7" />
             <Columns>
                 <asp:BoundField DataField="id" HeaderText="ID" />
                 <asp:BoundField DataField="vehicle_type" HeaderText="Vehicle Type" />
                 <asp:BoundField DataField="consignor" HeaderText="Consignoe" />
                 <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                 <asp:BoundField DataField="billing_party" HeaderText="Billing party" />
                 <asp:BoundField DataField="quantity" HeaderText="Quantity" />
                 <asp:BoundField DataField="weight" HeaderText="Weight" />
                 <asp:BoundField DataField="date" HeaderText="Date" />
                 <asp:BoundField DataField="time" HeaderText="Time" />
                 <asp:BoundField DataField="booking" HeaderText="Booking" />
                 <asp:BoundField DataField="delivery" HeaderText="Delivery" />
                 <asp:BoundField DataField="gst_no" HeaderText="GST no." />
                 <asp:BoundField DataField="pay_type" HeaderText="Pay type" />
                 <asp:BoundField DataField="vehicle_no" HeaderText="Vehicle no." />
                 <asp:BoundField DataField="lr_total" HeaderText="LR total" />
                 <asp:BoundField DataField="ack_status" HeaderText="ACK status" />
                 <asp:BoundField DataField="pod_uploded_status" HeaderText="POD uploded status" />

                      </Columns>
                 <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button CommandName="printrec" CommandArgument=<%#Eval("id")%> runat="server" Text="Print receipt" CssClass="btn btn-sm btn-outline-success" />

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>






    
                   
           

              

            
             <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
             <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
             <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
             <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
             <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
             <SortedAscendingCellStyle BackColor="#F4F4FD" />
             <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
             <SortedDescendingCellStyle BackColor="#D8D8F0" />
             <SortedDescendingHeaderStyle BackColor="#3E3277" />
         </asp:GridView>
             </center>

          <div style="margin-top:50px">
         <asp:Panel ID="panel2" runat="server" Visible="false">


             <div>

                  <asp:TextBox runat="server" ID="txtid" Enabled="false" CssClass="form-control form-control-sm"></asp:TextBox><br />
                <asp:DropDownList runat="server" ID="ddrvehiclenumber" CssClass="form-select form-select-sm"> </asp:DropDownList> <br />
                 <asp:Button runat="server" ID="assigndv" Text="Assign Driver" CssClass="btn btn-sm btn-outline-success"  Onclick="btnassign_dv"/>



             </div>





         </asp:Panel>
   
         </div>


          </div>

</asp:Content>
