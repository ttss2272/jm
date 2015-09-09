<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true"
    CodeBehind="TransferToTally.aspx.cs" Inherits="Juris.Admin.TransferTally.TransferToTally" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
    </asp:ToolkitScriptManager>
    <asp:Panel ID="PanelTally" runat="server" GroupingText="Transfer Data To Tally">
        <table>
            <tr>
                <td>
                </td><td><asp:Label ID="lblMsg" runat="server" ForeColor="Green"></asp:Label>&nbsp;<asp:Label 
                        ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="From :"></asp:Label>
                    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="ReqFrom" runat="server" 
                        ControlToValidate="txtFrom" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                        ToolTip="Please select From Date." ValidationGroup="TToTally"></asp:RequiredFieldValidator>
                     <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtFrom" runat="server">
                    </asp:CalendarExtender>
                </td>
                <td>
                    &nbsp;<asp:Label ID="Label2" runat="server" Text="To :"></asp:Label>
                    <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtTo"  runat="server">
                    </asp:CalendarExtender>
                    <asp:RequiredFieldValidator ID="REQToDate" runat="server" 
                        ControlToValidate="txtTo" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                        ToolTip="Please Select To Date." ValidationGroup="TToTally"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td align="center">
                    <asp:RadioButtonList ID="rbtnlistInvRec" runat="server">
                        <asp:ListItem Selected="True">Invoice</asp:ListItem>
                        <asp:ListItem>Receipt</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                <asp:Button ID="btnTransfer" runat="server" Text="Transfer"  
                        onclick="btnTransfer_Click" ValidationGroup="TToTally" />
                </td>
            </tr>
        </table>
        
    </asp:Panel>
</asp:Content>
