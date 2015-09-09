<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="InvoiceDetails.aspx.cs" Inherits="Juris.NewFolder1.InvoiceDetails" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type = "text/javascript">
     function PrintPanel() {
         var panel = document.getElementById("<%=pnlContents.ClientID %>");
         var printWindow = window.open('', '', 'height=400,width=800');
         printWindow.document.write('<html><head><title>DIV Contents</title>');
         printWindow.document.write('</head><body >');
         printWindow.document.write(panel.innerHTML);
         printWindow.document.write('</body></html>');
         printWindow.document.close();
         setTimeout(function () {
             printWindow.print();
         }, 500);
         return false;
     }
    </script>
    <style type="text/css">
        #divEmployees
        {
            font-family:Arial, Verdana, Sans-Serif;
            padding:10px;
            font-size:14px;

        }
        .td
        {
            height:30px;
            width:250px;
            font-size:14px;
            
        }
        .tr
        {
            height:30px;
            width:250px;
            margin-left:1px;
             font-size:14px;
        }
        #divEmployees .detail
        {
            border-bottom:dashed 1px #0066CC;
            margin-bottom:10px;
            padding:10px;
             font-size:14px;
        }
        #MainContent_lblto
        {
            padding-left:100px;
            height:30px;
            width:25px;
             font-size:14px;
            
        }
          #MainContent_lbdate
        {
            padding-left:500px;
            height:30px;
            width:25px;
             font-size:14px;
            
        }
           #MainContent_lblmanager
        {
            padding-left:120px;
            height:30px;
            width:25px;
             font-size:14px;
            
        }
            #MainContent_lbinvoice
        {
            padding-left:500px;
            height:30px;
            width:25px;
             font-size:14px;
        }
             #MainContent_lbClientname
        {
            padding-left:130px;
            height:30px;
            width:25px;
             font-size:14px;
        }
              #MainContent_lblsub
        {
            padding-left:400px;
            height:30px;
            width:25px;
             font-size:14px;
        }
               #MainContent_lbldate2
        {
            padding-left:420px;
            height:30px;
            width:25px;
             font-size:14px;
        }
        
                #MainContent_lblpan
        {
            
            height:30px;
            width:25px;
            
        }
                 #MainContent_lblpanno
        {
           
            height:30px;
            width:25px;
            font-size:14px;
        }
        
                  #MainContent_lblTotalAmount
        {
           
            height:30px;
            width:25px;
             font-size:14px;
        }
                    #MainContent_lblTotal
        {
           
            height:30px;
            width:25px;
             font-size:14px;
        }
        table
        {
        width:100%;
        border-collapse:collapse;
        background:#eee;
        border-spacing: 20px 15px;
        border:0px;
border-collapse:collapse;
border-spacing:0px;

            
            
        }
        td,th
        {
        padding:6px;
        border:1px solid #ccc;
        text-align:left;
         border-spacing: 50px 15px; 
          padding-right: 30px;  
         }
    
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
   
 <asp:Button ID="btnPrint" runat="server" Text="Print" OnClientClick = "return PrintPanel();" />    
   <asp:Panel ID="pnlContents" runat="server" >
    <table class="table" cellpadding="5" cellspacing="5">
        <tr>
            <td>
               <b> <asp:Label ID="lblto" runat="server" Text="To,"></asp:Label></b></td>
            <td>
              <b>  <asp:Label ID="lbdate" runat="server" Text="Date:"></asp:Label></b>
               <b> <asp:Label ID="lblDate" runat="server" Text="Label"></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td >
              <b>  <asp:Label ID="lblmanager" runat="server" Text="Manager,"></asp:Label> </b></td>
            <td>
           <b><asp:Label ID="lbinvoice" runat="server" Text="Invoice:"></asp:Label></b>
           <b> <asp:Label ID="lblInvoiceNo" runat="server" Text="Label"></asp:Label></b>
            </td>
        </tr>
        <tr>
            <td>
                <b> <asp:Label ID="lbClientname" runat="server" Text="Client Name :"></asp:Label></b><br />
               <b> <asp:Label ID="lblClientName" runat="server" Text="Label"></asp:Label></b>
            </td>
            <td>
             <b>  <asp:Label ID="lblsub" runat="server" Text="Invoice For: "></asp:Label></b>
             <b></b><asp:Label ID="lbldate2"
        runat="server" Text="Label"></asp:Label></b>
            </td>
        </tr>
    </table>
 
       
          <table class="table" cellpadding="10" cellspacing="10">
           
                 <asp:Repeater ID="Repeater1" runat="server">
            <HeaderTemplate>
               <tr>
                  <td>
                   <b>Type of work</b></td>
                  <td>
                     <b>Quantity</b></td>
                  <td>
                     <b> Amount</b></td>
                  <td>
                      <b>Total Amount</b></td>
              </tr>
            </HeaderTemplate>
             <ItemTemplate>
             <tr>
               <td>
                    <%# Eval("TypeOfWork")%> </td>
                  <td>
                    <%# Eval("Qty")%> </td>
                  <td>
                      <%# Eval("Amount")%></td>
                  <td>
                      <%# Eval("TotalAmount")%></td>
                       </tr>
              </ItemTemplate>
              </asp:Repeater>
             

          </table>
      
         <table class="table">
           <tr>
               <td>
                   <asp:Label ID="lblpan" runat="server" Text="Pan No:"></asp:Label>
                   <asp:Label ID="lblpanno" runat="server" Text="Label"></asp:Label>
                   </td>
               <td>
         <asp:Label ID="lblTotal" runat="server" Text="Total Amount:"></asp:Label>
</td>
               <td>
                  <asp:Label ID="lblTotalAmount" runat="server" Text="Label"></asp:Label></td>
           </tr>
       </table>
       <table class="table">
           <tr>
               <td class="style3">
                  <b> <asp:Label ID="Label3" runat="server" Text="Pay  Rupees of"></b></asp:Label>
                  <b> <asp:Label ID="lblrupees" runat="server" Text="Label"></asp:Label></b>
               </td>
               <td>
                   
               </td>
           </tr>
       </table>
   <b> <asp:Label ID="Label1" runat="server" Text="Thank You"></asp:Label></b><br />
  <b>  <asp:Label ID="Label2" runat="server" Text="For JURIS METRICS"></asp:Label></b>
    </asp:Panel>

</asp:Content>
