<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customerhistory.aspx.cs" Inherits="dts.customerhistory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        .gridview {
            border-collapse: collapse;
            width: 90%;
            font-size: 12px;
        }
        .gridview td, .gridview th {
            border: 1px solid #000;
            padding: 4px;
            text-align: center;
        }
    </style>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/css/bootstrap.min.css" rel="stylesheet"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Customer History</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" style="margin-top:5%">
            <center>
                <asp:GridView runat="server" class="gridview" ID="gvcustomerhistory" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="consignor" HeaderText="Consignor" />
                        <asp:BoundField DataField="consignee" HeaderText="Consignee" />
                        <asp:BoundField DataField="billing_party" HeaderText="Billing Party" />
                        <asp:BoundField DataField="quantity" HeaderText="Qty" />
                        <asp:BoundField DataField="weight" HeaderText="Weight" />
                        <asp:BoundField DataField="date" HeaderText="Date" />
                        <asp:BoundField DataField="time" HeaderText="Time" />
                        <asp:BoundField DataField="pono" HeaderText="PO No" />
                        <asp:BoundField DataField="partno" HeaderText="Part No" />
                    </Columns>
                    <HeaderStyle BackColor="Blue" Font-Bold="True" ForeColor="White" />
                    <AlternatingRowStyle BackColor="#f2f2f2" />
                </asp:GridView>
            </center>
        </div>
    </form>
</body>
</html>
