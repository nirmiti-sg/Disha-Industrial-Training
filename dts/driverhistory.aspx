
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="driverhistory.aspx.cs" Inherits="dts.driverhistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">



    <style>

        .gridview {
    border-collapse: collapse; /* Ensures single border lines */
    width: 80%;
    font-size:11px;
}

/* Apply border to each row and column cell */
.gridview td, 
.gridview th {
    border: 1px solid #000;  /* black border */
    padding: 2px;
    text-align: center;
}


    </style>

     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-sRIl4kxILFvY47J16cr9ZwB07vP4J8+LH7qKQnuqkuIAvNWLzeN8tE5YBujZqJLB" crossorigin="anonymous">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">


    <div class="container" style="margin-top:5%">
        <center>
            <asp:GridView runat="server" class="gridview" ID="gvdriverhistory" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnRowCommand="gvdriverhistory_RowCommand" OnRowDataBound="gvdriverhistory_RowDataBound">

                <AlternatingRowStyle BackColor="#CCCCCC" />

                <Columns>
                    <asp:BoundField DataField="consignor" HeaderText="Consigner" />
                    <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                    <asp:BoundField DataField="billing_party" HeaderText="" />
                    <asp:BoundField DataField="quantity" HeaderText="Qty" />
                    <asp:BoundField DataField="weight" HeaderText="Weight" />
                    <asp:BoundField DataField="date" HeaderText="Date" />
                    <asp:BoundField DataField="time" HeaderText="Time" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                </Columns>
                <Columns>
                    <asp:TemplateField HeaderText="Accept">
                        <ItemTemplate>
                            <asp:Button runat="server" ID="btnAccept" Text="Accept" CommandName="acc" CommandArgument=<%#Eval("assignid")%> />
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

                                <Columns>
                    <asp:TemplateField HeaderText="Completed">
                        <ItemTemplate>
                            <asp:Button ID="btnCompleted" runat="server" Text="Completed"  CommandName="comp" CommandArgument=<%#Eval("assignid")%>/>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>



                <FooterStyle BackColor="#CCCCCC" />
                <HeaderStyle BackColor="black" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#808080" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#383838" />
            </asp:GridView>
            </center>
    </div>


    </form>
     <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.bundle.min.js" integrity="sha384-FKyoEForCGlyvwx9Hj09JcYn3nv7wiPVlz7YYwJrWVcXK/BmnVDxM+D2scQbITxI" crossorigin="anonymous"></script>

</body>
</html>
