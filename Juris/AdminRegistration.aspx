<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminRegistration.aspx.cs" Inherits="Juris.AdminRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style ="align:center">
    <table style="width: 100%;">
        <tr>
            <td align="right">
                &nbsp;
                <asp:Label ID="lblUNm" runat="server" Text="User Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUNm" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
                <asp:Label ID="lblPass" runat="server" Text="Password:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblEmail" runat="server" Text="Email ID :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="REVEmail" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                    ToolTip="Please Enter Valid Email ID." 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="RegisterAdmin"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredEmail" runat="server" 
                    ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                    ToolTip="Please Enter Email ID." ValidationGroup="RegisterAdmin"></asp:RequiredFieldValidator>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnAddAdmin" runat="server" onclick="btnAddAdmin_Click" 
                    Text="Register" ValidationGroup="RegisterAdmin" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblMsg" runat="server" Visible="False" ForeColor="Green"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>
