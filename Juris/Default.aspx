<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Juris._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<%--<asp:Panel ID="PanelLogin" runat="server" GroupingText="Login Form" 
       Width="648px">
 
    <table style="width:87%; height: 171px; margin-left: 99px;">
        <tr>
            <td align="right" class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style2">
                <asp:Label ID="lblUnm" runat="server" Font-Size="Large" Text="Username :"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtUnm" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqfldvalUnm" runat="server" 
                    ControlToValidate="txtUnm" Display="Dynamic" 
                    ErrorMessage="Please Enter Username" ValidationGroup="LoginVal"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" ID="PanlLogin" class="style2">
                <asp:Label ID="lblPass" runat="server" Text="Password :" Font-Size="Large"></asp:Label>
            </td>
            <td class="style4">
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="reqfldvalPass" runat="server" 
                    ControlToValidate="txtPass" Display="Dynamic" 
                    ErrorMessage="Please Enter Password" ValidationGroup="LoginVal"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right" class="style3">
                &nbsp;</td>
            <td class="style5">
                &nbsp;</td>
            <td class="style1" width="200px">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="style2">
                &nbsp;</td>
            <td class="style4">
                <asp:Label ID="lblInUnmPass" runat="server" Font-Bold="True" 
                    Text="Incorrect Username or Password" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style2">
                &nbsp;</td>
            <td class="style4">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <br />
                <asp:Button ID="btnLogin" runat="server" Height="35px" Text="Login" 
                    Width="109px" onclick="btnLogin_Click" ValidationGroup="LoginVal" />
            </td>
            <td>
                <br />
            </td>
        </tr>
    </table>
       </asp:Panel>--%>
    <!--h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p-->
    <asp:Label ID="lblExpire" runat="server" style="text-align: center"></asp:Label>
</asp:Content>
