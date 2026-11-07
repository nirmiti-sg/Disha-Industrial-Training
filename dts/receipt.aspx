<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="receipt.aspx.cs" Inherits="dts.receipt" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="receiptArea">

    <asp:Repeater ID="repreceipt" runat="server">
        <ItemTemplate>

              <style>
        body {
      font-family: Arial, sans-serif;
      font-size: 14px;
      margin: 20px;
    }
    table {
      width: 100%;
      border-collapse: collapse;
    }
    td, th {
      border: 1px solid #000;
      padding: 6px;
      text-align: left;
    }
    .no-border {
      border: none;
    }
    .center {
      text-align: center;
    }
    .right {
      text-align: right;
    }
    .bold {
      font-weight: bold;
    }
    .small {
      font-size: 12px;
    }
    .page-border{
      border: 2px solid black;
      padding: 20px;
      margin: 10px;
      height: calc(100% - 20px);
      box-sizing: border-box;
    }

  </style>


      <h2 class="center">TAX INVOICE</h2>
  <table>
    <tr>
      <td style="width:50%" class="left bold">To,</td>
      <td style="width:50%" class="left bold"> DISHA BULK CARRIERS</td>
    </tr>


<tr>
      <td style="width:50%" class="left bold"><%#Eval("billing_party")%></td>
      <td style="width:50%" class="left"> Disha Business Hub, MZ Floor, Plot No 19A, Rajiv Gandhi Transport Nagar, Kondi Near Solapur University, Solapur 413255</td>
    </tr>

<tr>
      <td style="width:50%" class="left"><%#Eval("billing_party")%></td>
      <td style="width:50%" class="left bold"> Email: accounts@dishatransport.in </td>
    </tr>

<tr>
      <td style="width:50%"></td>
      <td style="width:50%" class="left bold"><bold> CellNo - 8888 8787 88 / 84 / 73 </bold></td>
    </tr>
</table>
<table>

    <tr>
      <td style="width:30%" class="left bold">Customer GST No:<%#Eval("gst_no")%></td>
      <td style="width:25%" class="left bold">SAC CODE:</td>
      <td  style="width:10%" class="left bold">Bill No.</td>
      <td  style="width:10%">    </td>
      <td  style="width:10%" class="left bold">Bill Date</td>
    <td style="width:10%" > <%#Eval("date")%>   </td>
    </tr>

    <tr>
      <td colspan="2" rowspan="3">Dear Sir,<br>
      We are submitting our Freight Bill. Kindly Original Acknowledged Receipts.<br>
      Please Receive and give us your Acknowledgment on our Duplicate Copy.<br>
      Please send Payment by NEFT to our given bank details & Send Payment advice copy on<br>
      Mail Id: accounts@dishatransport.in , To Settle the Account well within.</td>

      <td  style="width:10%" class="left bold">Vender Code</td>
      <td  style="width:10%">    </td>
      <td  style="width:10%" class="left bold">Pan No</td>
      <td  style="width:10%">AGHPG7487N</td>
</tr>
<tr>
      <td  style="width:10%" class="left bold">PO NO</td>
      <td  style="width:10%">    </td>
      <td  style="width:10%" class="left bold">GST No</td>
      <td   style="width:10%">27AGHPG7487N1ZM</td>
</tr>

<tr>
      <td  style="width:10%" class="left bold">PartNo</td>
      <td  style="width:10%">    </td>
      <td  style="width:10%" class="left bold">MSME No</td>
      <td   style="width:10%">MH32E0017791</td>
</tr>
   
  </table>

  <table>
    <tr style="background-color:#dddddd;">
      <th>SR.NO</th>
      <th>LR No</th>
      <th>LRDate</th>
      <th>VehicleNo</th>
      <th>Destination</th>
      <th>Consignor</th>
      <th>Consignee</th>
      <th>Description</th>
      <th>INVNo</th>
      <th>ChargeWt</th>
      <th>LoadType</th>
      <th>Freight</th>
    </tr>
    <tr>
      <td>1</td>
      <td><%#Eval("id")%></td>
      <td><%#Eval("date")%></td>
      <td><%#Eval("vehicle_no")%></td>
      <td><%#Eval("consignee") %></td>
      <td><%#Eval("consignor")%>    </td>
      <td><%#Eval("consignee")%>  </td>
      <td></td>
      <td></td>
      <td><%#Eval("weight")%></td>
      <td><%#Eval("vehicle_type")%></tb>
      <td><%#Eval("lr_total")%></td>
    </tr>
    <tr>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></td>
      <td></tb>
      <td></td>
    </tr>
  </table>
 
      <p stype="text-transform:cappitalize;"><strong>GST Payable By:-</strong>DISHA BULK CARRIERS</p>
 <table>
    <tr>
      <td><strong>Remarks:Customer is not liabile to pay GST under Reverse Charge since M/s. DISHA BULK CARRIERS
being GTA supplier has opted to pay GST under Forward Charge.</strong></td>
      <td><strong>SGST(0%)</strong></td>
      <td class="right"><strong>0</strong></td>
    </tr>
    <tr>
      <td><strong>Bank Details:</strong> DISHA BULK CARRIERS BANK OF MAHARASHTRA <strong>BRANCH:</strong> TWIN SOLAPUR</strong></td>
      <td><strong>CGST(0%)</strong></td>
      <td class="right"><strong>0</strong></td>
    </tr>
    <tr>
      <td> <strong>C/A A/C No: </strong>20152301506   <strong>IFSC Code:</strong>MAHB0001128</td>
      <td><strong>IGST(12%)</strong></td>
      <td class="right"><strong>0</strong></td>
    </tr>
    <tr> 
      <td><strong>Rupees in words: <%# NumberToWords(Convert.ToInt32(Eval("lr_total"))) %> only</strong></td>
      <td><strong>Grand Total:</strong></td>
      <td class="right"><strong><%#Eval("lr_total")%></strong></td></strong>
    </tr>
    <tr>
      <td><strong>Remark:--</strong></td>
      <td></td>
      <td class="right"><strong>For DISHA TRANSPORT</strong></td>
    </tr>
 <tr>
      <td><strong>Registered Office Address: Surabhi Plot No.20, Omkar Housing Society, Mangalvedha, Near Airport, Hotgi Road, Solapur 413224</strong></td>
      <td></td>
      <td class="right"></td>
    </tr>
     </table>




            <div class="row">

                <div class="col col-sm-10">


          <p><strong>
        Note: - 'I/We hereby declare that though our aggregate turnover in any preceding financial year from 2017-18 onwards is more than<br />
               the aggregate turnover notified under sub-rule (4) of rule 48, we are not required to prepare an invoice in terms of the <br />provisions of the said sub-rule'.
      </strong></p>
          <p><strong>
        Note - All Payments to be drawn by NEFT/RTGS/ A/C Payee Cheques in favour of DURGA TRANSPORT Only.
      </strong></p>
                </div>

                <div class="col col-sm-2" >
                    <img src="disha_seal.png" style="margin-top:-70px !important" height="200px" alt="" />

                </div>


                </div>

                
                
                <br>
<br/>
<br/><br/>
<br/>
<br/>
<br/>
<br/>
<br/>

            
            </ItemTemplate>

        </asp:Repeater>

         </div>

        <asp:Button ID="btnPrint" runat="server" Text="Print Receipt" CssClass="btn btn-primary"
    OnClientClick="printReceipt(); return false;" />


    
         <script type="text/javascript">
        function printReceipt() {
            var printContents = document.getElementById('receiptArea').innerHTML;
            var win = window.open('', '', 'height=600,width=800');
            win.document.write('<html><head><title>Receipt</title></head><body>');
            win.document.write(printContents);
            win.document.write('</body></html>');
            win.document.close();
            win.print();
        }
    </script>

       





</asp:Content>
