 
<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="Backup.aspx.cs"  Inherits="Juris.Admin.Setting.CreateBackup" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     

     
</asp:Content>
 
 
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

  <table align="left" width="50%">
    <tr>
    <td colspan="2" align="center"><h3>
    <asp:Label runat="server" ID="lblCreateBackup" Text="Create Backup"></asp:Label></h3>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="lblCBServerName" runat="server" Text="Server Name : "></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="txtCBServerName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtCBServerName" Display="Dynamic" 
            ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="CreateBackup" ToolTip="Please Enter the Server Name">
            </asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="lblCBSelectDB" runat="server" Text="Database Name : "></asp:Label>
        </td>
    <td >
        <asp:TextBox ID="txtCBDBName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtCBDBName" Display="Dynamic" 
            ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="CreateBackup" ToolTip="Please Enter Database name"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="lblCBDriveName" runat="server" Text="Drive to Store : "></asp:Label>
        </td>
    <td >
        <asp:TextBox ID="txtCBDriveName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="txtCBDriveName" Display="Dynamic" 
            ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="CreateBackup" ToolTip="Please Enter the Drive Name"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtCBDriveName" ErrorMessage="*" ForeColor="Red" 
            ToolTip="Please Enter Valid UserName" ValidationExpression="[a-zA-Z]{1}$" 
            ValidationGroup="CreateBackup"></asp:RegularExpressionValidator>
    </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="lblDBName" runat="server" Text="DB Name As : "></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="txtCBDbNameAs" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
            ControlToValidate="txtCBDbNameAs" Display="Dynamic" 
            ErrorMessage="*" 
            ForeColor="Red" ValidationGroup="CreateBackup" ToolTip="Please Enter The Database Name to Store with"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td align="right">
        &nbsp;</td>
    <td class="style1">
        &nbsp;</td>
    </tr>
    <tr>
    <td align="right">
    <asp:Button ID="btnCreate" runat="server" Text="Create" ValidationGroup="CreateBackup" onclick="btnCreate_Click" />
    </td>
    <td class="style1">
    &nbsp;<asp:Button ID="btnCreateClear" runat="server" Text="Clear" 
            onclick="btnCreateClear_Click" />
        &nbsp;<asp:Button ID="btnCreateCancel" runat="server" Text="Cancel" 
            onclick="btnCreateCancel_Click" />
        <asp:Label ID="lblCreateMsg" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
  </table>

   <table align="right" width="50%">
    <tr>
    <td colspan="2" align="center">
    <h3>
    <asp:Label runat="server" ID="lblSaveBackup" Text="Restore Backup"></asp:Label>
   </h3> </td>
    </tr>

     <tr>
    <td align="right">
        <asp:Label ID="lblSBServerName" runat="server" Text="Server Name : "></asp:Label>
         </td>
    <td>
        <asp:TextBox ID="txtSaveBkServerName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
            ControlToValidate="txtSaveBkServerName" ErrorMessage="*" 
            ForeColor="Red" ValidationGroup="Restore Back up" ToolTip="Please Enter Server Name"></asp:RequiredFieldValidator>
         </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="lblSBDBName" runat="server" Text="Database Name : "></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="txtSaveBkDBName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
            ControlToValidate="txtSaveBkDBName" ErrorMessage="*" 
            ForeColor="Red" ValidationGroup="Restore Back up" ToolTip="Please Enter Database Name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="lblSBDriveName" runat="server" Text="Drive Name From : "></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="txtSaveBkDriveName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
            ControlToValidate="txtSaveBkDriveName" ErrorMessage="*" 
            ForeColor="Red" ValidationGroup="Restore Back up" ToolTip="Please Enter Drive Name"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td align="right">
        <asp:Label ID="lblSBDBNameAs" runat="server" Text="DB Name As : "></asp:Label>
        </td>
    <td>
        <asp:TextBox ID="txtSaveBkDBNameAs" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
            ControlToValidate="txtSaveBkDBNameAs" 
            ErrorMessage="*" ForeColor="Red" 
            ValidationGroup="Restore Back up" ToolTip="Please Enter Database name to save with"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
    <td align="right">
        &nbsp;</td>
    <td>
        &nbsp;</td>
    </tr>
    <tr>
    <td align="right">
    <asp:Button ID="btnSvSave" runat="server" Text="Save" onclick="btnSvSave_Click" 
            ValidationGroup="Restore Back up" />
    </td>
    <td>
     &nbsp;<asp:Button ID="btnSvClear" runat="server" Text="Clear" 
            onclick="btnSvClear_Click" />
    &nbsp;<asp:Button ID="btnSvCancel" runat="server" Text="Cancel" 
            onclick="btnSvCancel_Click" />
        <asp:Label ID="lblSaveBk" runat="server" ForeColor="Red"></asp:Label>
    </td>
    </tr>
  
  </table>

</asp:Content>