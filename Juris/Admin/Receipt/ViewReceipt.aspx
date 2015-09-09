<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="ViewReceipt.aspx.cs" Inherits="Juris.Admin.Receipt.ViewReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
    <style type="text/css">
        .style1
        {
            height: 21px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
<h2>
    <asp:Label ID="lblViewRecHeading" runat="server" Text="View Receipt"></asp:Label>
</h2><asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
</div>
<div style="width :100%">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate><asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                </asp:ToolkitScriptManager>
<table width="100%">
        <tr>
            <td class="style1">
               
                <asp:Label ID="Label1" runat="server" Text="Client Name:" ></asp:Label>
            </td>
            <td class="style1">
             
                <asp:Label ID="lblRecNo" runat="server" Text="Receipt No :" ></asp:Label>
            </td>
            <td class="style1">
             
                <asp:Label ID="Label2" runat="server" Text="From :"></asp:Label>
            </td>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="To :" ></asp:Label>
            </td>
        </tr>
        
   
        <tr>
            <td class="tdControl">
            
                <asp:TextBox ID="txtClNmRecpt" runat="server"></asp:TextBox>
            </td>
            <td class="tdControl">
               <asp:TextBox ID="txtRecNo" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RevReceipt" runat="server" 
                    ControlToValidate="txtRecNo" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                    ToolTip="Only Numbers are allowed." ValidationGroup="ViewReceipt"></asp:RegularExpressionValidator>
            </td>
            <td class="tdControl">

               <asp:TextBox ID="txtFromRecpt" runat="server" ></asp:TextBox>
                <asp:CalendarExtender ID="calExtendrFromDt" runat="server" TargetControlID="txtFromRecpt">
                </asp:CalendarExtender>
            </td>
            <td class="tdControl">
                <asp:TextBox ID="txtToRecpt" runat="server" ></asp:TextBox>
                <asp:CalendarExtender ID="CalextendrToDt" runat="server" TargetControlID="txtToRecpt">
                </asp:CalendarExtender>
            </td>
        </tr>
        <tr>
            <td class="tdControl">
                &nbsp;</td>
            <td class="tdControl">
                &nbsp;</td>
            <td class="tdControl">
                &nbsp;</td>
            <td class="tdControl">
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
            </td><td align="right"> 
                <asp:CheckBox ID="chkbxAgstBl" runat="server" AutoPostBack="True" 
                    oncheckedchanged="chkbxAgstBl_CheckedChanged" Text="Against Bill" 
                    ValidationGroup="ViewReceipt" />
            </td>
            
                    <td class="tdControl" align="right">
                        <asp:Label ID="Label6" runat="server" Text="Approve :"></asp:Label>
            </td>
                <td>
                    <asp:DropDownList ID="drpdwnlstApp" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="drpdwnlstApp_SelectedIndexChanged">
                        <asp:ListItem>--Select--</asp:ListItem>
                        <asp:ListItem Value="2">Both</asp:ListItem>
                        <asp:ListItem Value="1">Approved</asp:ListItem>
                        <asp:ListItem Value="0">Unapproved</asp:ListItem>
                    </asp:DropDownList>
            </td>
           </tr>
        </table>
        <table  >
        <tr>
        
            <td >
            <table >
            <tr>
            <td>
                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:Panel ID="PanelVwRec" runat="server" BorderColor="#666666" 
                    BorderStyle="Solid" BorderWidth="2px" Height="400px" Width="900px" ScrollBars="Vertical"><br />
                    <asp:GridView ID="GdVwRecpt" Width="900px" runat="server" onrowcommand="GdVwRecpt_RowCommand">
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                            <asp:Button ID="btnedit" Text="Edit" CommandName="Edit" CommandArgument='%Container.DataItemIndex%' runat="server"  />
                            </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                </td>
                </tr>
                </table>

            </td>
        </tr>
        </table>
        <table  align="right">
        <tr>
            <td align="right">
                <asp:Label ID="Label4" runat="server" Text="No. Of Transactions :" ></asp:Label>
            </td>
            <td colspan="2">
                <asp:Label ID="lblNoOfTrns" runat="server" Text="0"></asp:Label>
            </td>
            <td  align="right">
                <asp:Label ID="Label5" runat="server" Text="Total Amt:" ></asp:Label>
            </td>
            <td  >
                <asp:Label ID="lblTotAmt" runat="server" Text="0.00"></asp:Label>
            </td>
            </tr>
        <tr>
            <td>
                &nbsp;</td>
            </tr>
            <caption>
                &nbsp;</td>
                <tr><td></td><td></td><td></td>
                     
                    <td colspan="2" align="right">
                        <asp:Button ID="btnAdNwReceipt0" runat="server" onclick="btnAdNwReceipt_Click" 
                            Text="Add New Receipt" />
                        <asp:Button ID="btncncl" runat="server" onclick="btncncl_Click" Text="Cancel" />
                    </td>
                </tr>
            </caption>
            </table>
            </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
