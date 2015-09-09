<%@ Page Title="" Language="C#" Theme="Skin1" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="AddEditService.aspx.cs" Inherits="Juris.Admin.Services.AddEditService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div align = "center" style="width :100%">
        <h3>
            <asp:Label ID="lblAddEditServiceHeading" runat="server" Text="Add/Edit Service" Font-Bold="True"></asp:Label>
        </h3>
        <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
<asp:Panel ID="PanelService" runat="server">
    
    <table style="border-style: solid; border-width: thin;">
        <tr>
             
            <td colspan="2">
                <asp:Label ID="lblResult" runat="server" ForeColor="Green" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblServiceId" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" >
 
                <asp:Label ID="lblServiceNm" runat="server" Text="Service Name :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtServiceNm" runat="server" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RFVSerNm0" runat="server" 
                    ControlToValidate="txtServiceNm" Display="Dynamic" ErrorMessage="*" 
                    ForeColor="Red" ToolTip="Please give name of Service." 
                    ValidationGroup="ValidService"></asp:RequiredFieldValidator>
                <br />
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
                <asp:Label ID="lblIsDelSer" runat="server" Text="Is Deleted  ?"></asp:Label>
                <br />
                
            </td>
            <td  >
                <asp:RadioButton ID="rbNoIsDelSer" runat="server" GroupName="IsDeleted" 
                    Text="No" Checked="True" />
                <asp:RadioButton ID="rbYesIsDelSer" runat="server" GroupName="IsDeleted" 
                    Text="Yes" />
                <br />
            </td>
        </tr>
        <tr>
            <td   align="right">
                <asp:Label ID="lblApprovSer" runat="server" Text="Approve :"></asp:Label>
            </td>
            <td >
                <asp:CheckBox ID="chBxApproveServc" runat="server" AutoPostBack="True" Text="Approve Service" />
            </td>
        </tr>
        <tr>
            <td  align="right">
                &nbsp;
            </td>
            <td>
                <asp:Button ID="btnSaveService" runat="server" Text="Save" onclick="btnSaveService_Click" ValidationGroup="ValidService" />
                &nbsp;<asp:Button ID="btnClear" runat="server" Text="Clear" onclick="btnClear_Click" />
                &nbsp;<asp:Button ID="btncncl" runat="server" onclick="btncncl_Click" Text="Cancel" />
            </td>
        </tr>
    </table>
    </asp:Panel>
    </div> 
</asp:Content>
