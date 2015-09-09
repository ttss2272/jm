<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Juris.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div style="width :100%" align="center">  
<asp:Panel ID="PanelLogin" runat="server" GroupingText="Login Form">
    <table style="width:70%;">
        <tr>
            <td align="left" >
                </td>
            <td align="left" class ="tdLabel ">
                <asp:Label ID="lblInUnmPass" runat="server" Font-Bold="True" 
                    Text="Incorrect Username or Password" Visible="False"></asp:Label>
                <asp:Label ID="lblExpire" runat="server" Font-Bold="True" Text="" 
                    Visible="true"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" class="tdLabel">
                <asp:Label ID="lblUnm" runat="server" Font-Size="Large" Text="Username :"></asp:Label>
            </td>
            <td  align ="left" class="tdControl " >
                <asp:TextBox ID="txtUnm" runat="server"></asp:TextBox>
            </td>
            <td align ="left" class="tdControl " >
                <asp:RequiredFieldValidator ID="reqfldvalUnm" runat="server" 
                    ControlToValidate="txtUnm" Display="Dynamic" 
                    ErrorMessage="*" ValidationGroup="LoginVal" ForeColor="Red" 
                    ToolTip="Please Enter Username"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr >
            <td align="right"  class ="tdLabel ">
                <asp:Label ID="lblPass" runat="server" Text="Password :" Font-Size="Large"></asp:Label>
            </td>
            <td align ="left" class="tdControl " >
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td align ="left" class="tdControl ">
                <asp:RequiredFieldValidator ID="reqfldvalPass" runat="server" 
                    ControlToValidate="txtPass" Display="Dynamic" 
                    ErrorMessage="*" ValidationGroup="LoginVal" ForeColor="Red" 
                    ToolTip="Please Enter Password"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="left" >
                &nbsp;</td>
            <td align="left"  class="tdControl ">
                <asp:Button ID="btnLogin" runat="server" Height="34px" 
                    onclick="btnLogin_Click1" Text="Login" Width="101px" />
            </td>
            <td>
                </td>
        </tr>
    </table>
       </asp:Panel>
       </div>  
</asp:Content>
