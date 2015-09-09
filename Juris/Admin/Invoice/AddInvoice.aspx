<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true"
    Theme="Skin1" CodeBehind="AddInvoice.aspx.cs" Inherits="Juris.Admin.Invoice.AddInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .Background
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .Popup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 400px;
            height: 350px;
        }
        .lbl
        {
            font-size: 16px;
            font-style: italic;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center">
        <h2>
            <asp:Label ID="lblAddInv" runat="server" Text="Add Invoice"></asp:Label>
        </h2>
    </div>
    <div style="width: 100%">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="Panel1" runat="server">
                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                        <ContentTemplate>
                            <table>
                                <tr>
                                    <td class="tdLabel" align="center" colspan="3">
                                        <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>
                                        &nbsp;<asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel" align="right">
                                        <asp:Label ID="Label1" runat="server" Text="Client Name :"></asp:Label>
                                    </td>
                                    <td class="tdControl">
                                        <asp:DropDownList ID="drpdwnClientNm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpdwnClientNm_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="ReqValSelClient" runat="server" ControlToValidate="drpdwnClientNm"
                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" InitialValue="-1" SetFocusOnError="True"
                                            ToolTip="Please Select Proper Client" ValidationGroup="InvVal"></asp:RequiredFieldValidator>
                                        <br />
                                    </td>
                                    <td class="tdLabel">
                                        <asp:Label ID="Label2" runat="server" Text="Bill No :"></asp:Label>
                                        <asp:TextBox ID="txtBillNo" runat="server" ReadOnly="True">AUTO GENERATED</asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel" align="right">
                                        <asp:Label ID="Label8" runat="server" Text="Address :"></asp:Label>
                                    </td>
                                    <td class="tdControl">
                                        <asp:TextBox ID="txtAddInvce" runat="server" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td class="tdLabel">
                                        <asp:Label ID="Label16" runat="server" Text="Date :"></asp:Label>
                                        <asp:TextBox ID="txtDtInvce" runat="server"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDtInvce">
                                        </asp:CalendarExtender>
                                        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                                        </asp:ToolkitScriptManager>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel" align="right">
                                        <asp:Label ID="Label3" runat="server" Text="PAN No :"></asp:Label>
                                    </td>
                                    <td class="tdControl">
                                        <asp:TextBox ID="txtPanNo" runat="server" ReadOnly="True"></asp:TextBox>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td class="tdControl" align="left">
                                        <asp:CheckBox ID="chkbxSelAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkbxSelAll_CheckedChanged"
                                            Text="Clear All" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnSelPrjct" runat="server" OnClick="btnSelPrjct_Click" Text="Select Project"
                                            ValidationGroup="InvVal" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <table>
                        <tr>
                            <td colspan="3" align="left" style="width: 100%">
                                <%--td--%>
                                <asp:Label ID="lblSelProjectMessage" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Panel ID="PanelGdvwAddInvce" runat="server" BorderColor="Gray" BorderStyle="Solid"
                                    BorderWidth="1px" HorizontalAlign="Left" Height="200px" ScrollBars="Vertical"
                                    Width="900px">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GdVwAddInvce" runat="server" AutoGenerateColumns="false" Width="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Select">
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkSel" runat="server" AutoPostBack="true" OnCheckedChanged="OnCheckboxCheck" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%-- <asp:TemplateField HeaderText="ProjectId">
                                                            <ItemTemplate>
                                                                <%#Eval("ProjectId")%></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Date">
                                                            <ItemTemplate>
                                                                <%#Eval("ProjectDate")%></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Case Name">
                                                            <ItemTemplate>
                                                                <%#Eval("CaseName")%></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="TypeOfWork">
                                                            <ItemTemplate>
                                                                <%#Eval("TypeOfWork")%></ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Price">
                                                            <ItemTemplate>
                                                                <%#Eval("Price")%></ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    <asp:BoundField DataField="ProjectId" HeaderText="ProjectId" />
                                                    <asp:BoundField DataField="ProjectDate" HeaderText="ProjectDate" />
                                                    <asp:BoundField DataField="CaseName" HeaderText="CaseName" />
                                                    <asp:BoundField DataField="TypeOfWork" HeaderText="TypeOfWork" />
                                                    <asp:BoundField DataField="Price" HeaderText="Price" />
                                                </Columns>
                                            </asp:GridView>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CustomValidator ID="CustounValGridCheckbox" runat="server" ClientValidationFunction="Validate()"
                                    ForeColor="Red" ErrorMessage="*" ToolTip="Please Select Atleast One Project"></asp:CustomValidator>
                            </td>
                        </tr>
                    </table>
                    <table class="table">
                        <tr>
                            <td class="tdLabel" align="right">
                                <asp:Label ID="Label5" runat="server" Text="Remark :"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:TextBox ID="txtRemrk" runat="server" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td class="tdControl" align="right">
                                <asp:Label ID="Label15" runat="server" Text="Amount :"></asp:Label>
                            </td>
                            <td class="tdControl">
                                <asp:TextBox ID="txtAmtAddInvce" runat="server" ReadOnly="True">0</asp:TextBox>
                                <asp:RegularExpressionValidator ID="REVAMT" runat="server" ControlToValidate="txtAmtAddInvce"
                                    Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Enter Only Numbers."
                                    ValidationExpression="[0-9.]{1,10}" ValidationGroup="InvVal"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLabel" align="right">
                                <asp:Label ID="Label14" runat="server" Text="Status :"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:DropDownList ID="DrpDwnlstStatus" runat="server">
                                    <asp:ListItem Selected="True">In Process</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="tdControl" align="right">
                                <%--<asp:Label ID="lblOtherchrge" runat="server" Text="Other Charge:"></asp:Label>--%>
                            </td>
                            <td class="tdLabel">
                                <%--<asp:TextBox ID="txtOtherChrge" runat="server" ReadOnly="True" 
                                    >0</asp:TextBox>--%>
                                <%--<asp:RegularExpressionValidator ID="REVOtherCharges" runat="server" 
                                    ControlToValidate="txtOtherChrge" Display="Dynamic" ErrorMessage="*" 
                                    ForeColor="Red" ToolTip="Enter Only Numbers." 
                                    ValidationExpression="[0-9.]{1,10}" ValidationGroup="InvVal"></asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style1">
                                <asp:CheckBox ID="chkbxAppInv" runat="server" Text="Approve Invoice" />
                            </td>
                            <td class="tdControl" align="right">
                                <%--<asp:Label ID="lblTotamt" runat="server" Text="Total Amount:"></asp:Label>--%>
                            </td>
                            <td class="tdLabel">
                                <%--<asp:TextBox ID="txtTotAmt" runat="server" ReadOnly="True" 
                                   >0</asp:TextBox>
                                <asp:RegularExpressionValidator ID="REVTotalAmt" runat="server" 
                                    ControlToValidate="txtTotAmt" Display="Dynamic" ErrorMessage="*" 
                                    ForeColor="Red" ToolTip="Enter Only Numbers." 
                                    ValidationExpression="[0-9-.]{1,10}" ValidationGroup="InvVal"></asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td class="style1">
                                <asp:CheckBox ID="chkbxisDel" runat="server" Text="Is Deleted" />
                            </td>
                            <td class="tdLabel" align="right">
                                <asp:Label ID="Label20" runat="server" Text="Invoice Formate :"></asp:Label>
                            </td>
                            <td>
                                <asp:RadioButton ID="rbInvoice1" Checked="true" runat="server" GroupName="Invoice" Text="Invoice Formate 1" />
                                <asp:RadioButton ID="rbInvoice2" runat="server" GroupName="Invoice" Text="Invoice Formate 2" />
                            </td>
                        </tr>
                        <tr>
                            <td class="tdLabel" align="right">
                                <asp:Label ID="Label11" runat="server" Text="Report Type :"></asp:Label>
                            </td>
                            <td class="style1">
                                <asp:DropDownList ID="drplstRprtTyp" runat="server">
                                    <asp:ListItem>Invoice With Annexure</asp:ListItem>
                                    <asp:ListItem>Invoice With Summary</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="tdControl">
                                &nbsp;
                            </td>
                            <td class="tdControl">
                                <asp:HiddenField ID="HiddenFieldInvoiceId" runat="server" />
                            </td>
                            <tr>
                                <td colspan="4" align="center">
                                    <asp:Button ID="btnSvPrvInv" runat="server" Text="Save &amp; Preview" ValidationGroup="InvVal"
                                        OnClick="btnSvPrvInv_Click" Width="110px" />
                                    &nbsp;<asp:Button ID="btnSaveInvce" runat="server" OnClick="btnSaveInvce_Click" Text="Save"
                                        ValidationGroup="InvVal" Width="60px" />
                                    &nbsp;<asp:Button ID="btnCncl" runat="server" OnClick="btnCncl_Click" OnClientClick="Validate()"
                                        Text="Cancel" Width="60px" />
                                    <%--&nbsp;<asp:Button ID="btnShowInvoice" runat="server" onclick="btnShowInvoice_Click" 
                                   Text="Show Invoice" Visible="False" Width="100px" OnClientClick="SetTarget();" />
                                   <script type="text/javascript">
                                       function fixform() {
                                           document.getElementById("aspnetForm").target = '';
                                       }
                                       function SetTarget() {
                                           document.forms[0].target = "_blank";
                                       }
                                   </script>
                                   
                               &nbsp;<asp:Button ID="btnShowAnnexure" runat="server" 
                                   onclick="btnShowAnnexure_Click" Text="Show Annexure" Visible="False" 
                                   Width="100px" />--%>
                                </td>
                            </tr>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="Panl1"
        TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background">
    </asp:ModalPopupExtender>
    <asp:Panel ID="Panl1" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 350px; height: 300px;" id="irm1" src="Invoice.aspx" runat="server">
        </iframe>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Close" />
    </asp:Panel>
    <asp:ModalPopupExtender ID="ModalPopupExtender2" runat="server" PopupControlID="Panl2"
        TargetControlID="Button1" CancelControlID="Button2" BackgroundCssClass="Background">
    </asp:ModalPopupExtender>
    <asp:Panel ID="Panel2" runat="server" CssClass="Popup" align="center" Style="display: none">
        <iframe style="width: 350px; height: 300px;" id="Iframe1" src="Annexure.aspx" runat="server">
        </iframe>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Close" />
    </asp:Panel>
</asp:Content>
