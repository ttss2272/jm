<%@ Page Title="" Language="C#" Theme="Skin1" MasterPageFile="~/admin.Master" AutoEventWireup="true"
    CodeBehind="SendMail.aspx.cs" Inherits="Juris.Admin.Mail.SendMail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <table align="center" width="100%">
    <tr>
        <th colspan="2">
       <center><h3> Send Mail</h3> </center>
        </th>
   </tr>
   <tr>
   <td colspan="2">
   <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
   </td></tr>
    <tr>
    <td align="right"> 
        <asp:Label ID="lblFrom" runat="server" Text="From : "></asp:Label>
    </td>

    <td>
        <asp:TextBox ID="txtFrom" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    </tr>

    <tr>
   <td align="right"> 
        <asp:Label ID="lblTo" runat="server" Text="To : "></asp:Label>
    </td>

    <td>
        <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ErrorMessage="*" ForeColor="Red" 
            ControlToValidate="txtTo" ValidationGroup="SendMail" ToolTip="Please Enter Recievers EMail ID"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="REVEmailTo" runat="server" 
            ControlToValidate="txtTo" ErrorMessage="*" ForeColor="Red" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ValidationGroup="SendMail" ToolTip="Please Enter Recievers EMail ID"></asp:RegularExpressionValidator>
    </td>
    </tr>

    <tr>
   <td align="right"> 
        <asp:Label ID="lblCc" runat="server" Text="Cc : "></asp:Label>
    </td>

    <td>
        <asp:TextBox ID="txtCc" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ErrorMessage="*" ForeColor="Red" ToolTip="Please Enter Valid Email" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ValidationGroup="SendMail" ControlToValidate="txtCc"></asp:RegularExpressionValidator>
    </td>
    </tr>

    <tr>
   <td align="right"> 
        <asp:Label ID="lblBcc" runat="server" Text="Bcc : "></asp:Label>
    </td>

    <td>
        <asp:TextBox ID="txtBcc" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ErrorMessage="*" ForeColor="Red" ToolTip="Please Enter Valid Mail" 
            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
            ValidationGroup="SendMail" ControlToValidate="txtBcc"></asp:RegularExpressionValidator>
    </td>
    </tr>

    <tr>
   <td align="right"> 
        <asp:Label ID="lblSubject" runat="server" Text="Subject : "></asp:Label>
    </td>

    <td>
        <asp:TextBox ID="txtSubject" runat="server" ReadOnly="True"></asp:TextBox>
    </td>
    </tr>

    <tr>
     <td align="right"> 
        <asp:Label ID="lblBody" runat="server" Text="Description : "></asp:Label>
    </td>

    <td>
        <asp:TextBox ID="txtBody" runat="server" TextMode="MultiLine" 
           ></asp:TextBox>
    </td>
    </tr>

     <tr>
     <td> 
     </td>

    <td>
        <asp:Button ID="btnSendMail" runat="server" Text="Send" 
            onclick="btnSendMail_Click" ValidationGroup="SendMail" />
        <asp:Button ID="btnCancelMail" runat="server" Text="Cancel" 
            CausesValidation="False" onclick="btnCancelMail_Click" />
    &nbsp;<asp:Label ID="lblMailStatus" runat="server" Visible="False"></asp:Label>
    &nbsp;</td>
    </tr>
</table>

</asp:Content>