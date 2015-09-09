<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true"
    CodeBehind="ViewInvoice.aspx.cs" Inherits="Juris.Admin.Invoice.ViewInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function Validate() {
            var e = document.getElementById("drplstApp");
            var strUser = e.options[e.selectedIndex].Text;
            if (strUser == "--Select--") {
                alert("Please select Approve Or Not");
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div align="center">
                <h2>
                    <asp:Label ID="lblViewInvHeading" runat="server" Text="View Invoice"></asp:Label>
                </h2>
            </div>
            <div style="width: 100%">
                <asp:Panel ID="Panel1" runat="server">
                    <table style="width: 100%;">
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td colspan="2">
                                <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
                                <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Client Name:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Invoice No:"></asp:Label>
                            </td>
                            <td>Approve :</td>
                        </tr>
                        <tr>
                            <td class="tdControl">
                                <asp:TextBox ID="txtClNm" runat="server"></asp:TextBox>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ControlToValidate="txtClNm" ErrorMessage="*" ForeColor="Red" 
                                    ToolTip="Enter Client Name."></asp:RegularExpressionValidator>
                                <br />
                            </td>
                            <td class="tdControl">
                                <asp:TextBox ID="txtInNo" runat="server" style="margin-bottom: 0px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
                                    ValidationGroup="invoice" ControlToValidate="txtInNo" runat="server" 
                                    ErrorMessage="*" ForeColor="Red" ToolTip="Please Enter Invoice No."></asp:RequiredFieldValidator>
                                <br />
                            </td>

                            <td class="tdControl">
                                <asp:DropDownList ID="drplstApp" runat="server" OnSelectedIndexChanged="drplstApp_SelectedIndexChanged"
                                    AutoPostBack="True">
                                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                                    <asp:ListItem Value="2">Both</asp:ListItem>
                                    <asp:ListItem Value="1">Approved</asp:ListItem>
                                    <asp:ListItem Value="0">UnApproved</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredDDl0" runat="server" 
                                    ControlToValidate="drplstApp" ErrorMessage="*" 
                                    ForeColor="Red" InitialValue="-1" ValidationGroup="invoice" 
                                    ToolTip="Select Approve Or Not"></asp:RequiredFieldValidator>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdControl">
                                &nbsp;</td>
                            <td class="tdControl">
                                &nbsp;</td>
                            <td class="tdControl">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label>
                                <asp:Panel ID="PanelGdvwVwInvce" runat="server" BorderColor="#666666" BorderStyle="Solid"
                                    BorderWidth="2px" Height="400px" ScrollBars="Vertical">
                                    &nbsp; &nbsp; &nbsp;
                                    <asp:GridView ID="GdVwViewInvce" runat="server" 
                                        OnRowCommand="GdVwViewInvce_RowCommand" Width="100%">
                                        <Columns>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:Button ID="btnedit" Text="Edit" CommandName="EditProject" CommandArgument='%Container.DataItemIndex%'
                                                        runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                   
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblmsg" runat="server"></asp:Label>
                            </td>
                            <td>
                                &nbsp;
                                <asp:Panel ID="PanelEmlAttFormat" runat="server" GroupingText="Email Attachment Format">
                                    <table style="width: 90%;">
                                        <tr>
                                            <td>
                                                <asp:RadioButton ID="rbtnWord0" runat="server" GroupName="GrpEmlAtt" Text="Word"
                                                    AutoPostBack="True" ValidationGroup="ms" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbtnExcel0" runat="server" GroupName="GrpEmlAtt" Text="Excel"
                                                    AutoPostBack="True" ValidationGroup="ms" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbtnPDF0" runat="server" GroupName="GrpEmlAtt" Checked="true"
                                                    Text="PDF" AutoPostBack="True" ValidationGroup="ms" />
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                             
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="Label3" runat="server" Text="Report Type :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="drplstReprtTypVwInce" runat="server">
                                    <asp:ListItem>Invoice With Annexure</asp:ListItem>
                                    <asp:ListItem>Invoice With Summary</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>
                                
                            </td>
                             
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                <asp:Button ID="btnPrvInvce" runat="server" OnClick="btnPrvInvce_Click" 
                                    Text="Preview Invoice" ValidationGroup="invoice" />
                                <asp:Button ID="btnEmlInvce" runat="server" OnClick="btnEmlInvce_Click" 
                                    Text="Email Invoice" ValidationGroup="invoice" />
                                <asp:Button ID="btnAddNwInvce" runat="server" OnClick="btnAddNwInvce_Click" 
                                    PostBackUrl="~/Admin/Invoice/AddInvoice.aspx" Text="Add New Invoice" />
                                <asp:Button ID="btncncl" runat="server" OnClick="btncncl_Click" Text="Cancel" />
                            </td>
                           
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
