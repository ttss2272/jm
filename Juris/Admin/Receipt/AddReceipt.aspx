<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" Theme="Skin1"
    CodeBehind="AddReceipt.aspx.cs" Inherits="Juris.Admin.Receipt.AddReceipt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div align="center" style="width: 100%;">
    <h2>
        <asp:Label ID="lblAddRecHeading" runat="server" Text="Add Receipt"></asp:Label>
    </h2>
    <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:Panel ID="PanelAddReceipt" runat="server" Height="500px" Width="925px" GroupingText="Party Details">
                <br />
                
                <table class="table">
                    <tr>
                    <td class="tdLabel" align="center" colspan="3">
                        <asp:Label ID="lblResult" runat="server" Visible="False" ForeColor ="Green" ></asp:Label></td></tr>
                    <tr>
                        <td class="tdLabel" align="right">
                            
                            <asp:Label ID="Label1" runat="server" Text="Receipt No :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtRecNo" runat="server"  ReadOnly="True"></asp:TextBox>
                        </td>
                        <td class="tdLabel" align="right">
                            
                            <asp:Label ID="Label2" runat="server" Text="Payment Type :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:DropDownList ID="DRpDwnLstPmntTyp" runat="server" AutoPostBack="True" 
                                 OnSelectedIndexChanged="DRpDwnLstPmntTyp_SelectedIndexChanged" 
                               >
                                <asp:ListItem>Cheque</asp:ListItem>
                                <asp:ListItem>Cash</asp:ListItem>
                                <asp:ListItem>Credit Card</asp:ListItem>
                                <asp:ListItem>RTGS</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label3" runat="server" Text="TDS % :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtTDSPerc" runat="server" >2.1</asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVAMT" runat="server" 
                                ControlToValidate="txtTDSPerc" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Enter Only Numbers." 
                                ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                        </td>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label15" runat="server" Text="Group Id :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtGrpId" runat="server" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegExpresgroupId" runat="server" 
                                ControlToValidate="txtGrpId" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                                ToolTip="Enter Only Numbers." ValidationExpression="[0-9]{0,10}" 
                                ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="tdLabel">
                       
                            <asp:Label ID="Label5" runat="server" Text="Client Name:"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="DrplstClRec" runat="server" AutoPostBack="True"
                                        OnSelectedIndexChanged="DrplstClRec_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="DrplstClRec" ErrorMessage="*" ForeColor="Red" 
                                        InitialValue="-1" ToolTip="Please selest Client Name" 
                                        ValidationGroup="SaveReceipt"></asp:RequiredFieldValidator>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                        <td  class="tdLabel" align="right">
                            <asp:Label ID="Label16" runat="server" Text="Subgroup Name :"></asp:Label>
                    
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtSubGrpNm" runat="server"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label14" runat="server" Text="Client Id :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:Label ID="lblClId" runat="server" Text=" "></asp:Label>
                            <asp:TextBox ID="txtClId" runat="server" ReadOnly="True"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegExpresclientId" runat="server" 
                                ControlToValidate="txtClId" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                                ToolTip="Enter Only Numbers." ValidationExpression="[0-9.]{1,10}" 
                                ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                        </td>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label37" runat="server" Text="Date:"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtRecDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtRecDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                           
                            <asp:Label ID="Label7" runat="server" Text="Bank Name :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtBnkNm" runat="server" ></asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVBankName" runat="server" 
                                ControlToValidate="txtBnkNm" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                                ToolTip="Please Enter Character Only." 
                                ValidationExpression="^[a-zA-Z'/\|! $(),@&amp;#.\s]{3,50}$" 
                                ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                        <td align="right">
                         
                            <asp:Label ID="Label28" runat="server" Text="Cheque/Draft Date :"></asp:Label>
                         
                        </td>
                        <td>
                            
                            <asp:TextBox ID="txtChqOrDftDt" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" 
                                TargetControlID="txtChqOrDftDt">
                            </asp:CalendarExtender>
                            
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label9" runat="server" Text="Cheque/Draft No. :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtChqOrDftNo" runat="server"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="REVchequedrftno" runat="server" 
                                ControlToValidate="txtChqOrDftNo" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Please Enter Only Numbers." 
                                ValidationExpression="[0-9]{1,50}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                        </td>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label29" runat="server" Text="Bill Amount :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtBllAmt" runat="server" ReadOnly="True">0</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegExpresbillamt" runat="server" 
                                ControlToValidate="txtBllAmt" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Enter Only Numbers." 
                                ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="tdLabel">
                          
                            <asp:Label ID="Label34" runat="server" Text="Comments :"></asp:Label>
                          
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtCoommnts" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td class="tdLabel" align="right" >
                           
                            <asp:Label ID="Label30" runat="server" Text="Amount :"></asp:Label>
                           
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtAmt" runat="server" AutoPostBack="True" 
                                OnTextChanged="txtAmt_TextChanged">0</asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" 
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="SaveReceipt" 
                                ToolTip="Enter Proper Amt"></asp:CustomValidator>
                            <asp:Label ID="lblAmtMsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                            &nbsp;</td>
                        <td class="tdControl">
                            <asp:CheckBox ID="chkbxTDSCertRecvd" runat="server" 
                                Text="TDS Certificate Received" 
                                />
                        </td>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label11" runat="server" Text="Discount :"></asp:Label>
                           </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtDisc" runat="server" AutoPostBack="True" 
                                OnTextChanged="txtDisc_TextChanged">0</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegExpresdiscount" runat="server" 
                                ControlToValidate="txtDisc" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                                ToolTip="Enter Only Numbers." ValidationExpression="[0-9.]{1,10}" 
                                ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                           
                            &nbsp;</td>
                        <td>
                           
                            <asp:CheckBox ID="chkAgainstBills" runat="server" AutoPostBack="True" 
                                OnCheckedChanged="chkAgainstBills_CheckedChanged" Text="Against Bills" />
                           
                        </td>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label31" runat="server" Text="TDS :"></asp:Label>
                           </td>
                        <td >
                         
                            <asp:TextBox ID="txtTDSReadOnly" runat="server" ReadOnly="True">0</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegExpresTDS" runat="server" 
                                ControlToValidate="txtTDSPerc" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Enter Only Numbers." 
                                ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                            <br />
                         
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                            &nbsp;</td>
                        <td class="tdControl">
                            <asp:CheckBox ID="chkbxAppRecpt" runat="server" Text="Approve Receipt" 
                                 />
                        </td>
                        <td class="tdLabel" align ="right">
                            <asp:Label ID="Label32" runat="server" Text="Balance Amount:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBalamt" runat="server" AutoPostBack="True" ReadOnly="True">0.0</asp:TextBox>
                            <asp:RegularExpressionValidator ID="RegExpresbalamt" runat="server" 
                                ControlToValidate="txtBalamt" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Enter Only Numbers." 
                                ValidationExpression="[0-9.-]{1,20}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">
                            &nbsp;</td>
                        <td class="tdControl">
                            &nbsp;</td>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label38" runat="server" Text="Is Deleted ?"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:RadioButtonList ID="rbtnlstIsDel" runat="server">
                                <asp:ListItem>Yes</asp:ListItem>
                                <asp:ListItem Selected="True">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="Panel2" runat="server" GroupingText="List Of Pending Bills" Height="225px"
                Width="100%">
                <table>
                    <tr>
                        <td  colspan="6">
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" BorderWidth="2px" BorderStyle="Solid "
                                Width="100%" Height="166px" Visible="false">
                                <asp:GridView ID="GrdVwInvoice" runat="server" Visible="False" AutoGenerateColumns="False"
                                    OnRowDataBound="GrdVwInvoice_RowDataBound" Width="100%">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chksel" runat="server" AutoPostBack="true" OnCheckedChanged="onCheck" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="InvoiceId." Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceId" runat="server" Text='<%#Eval("InvoiceId") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Invoice No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInvoiceNo" runat="server" Text='<%#Eval("InvoiceNo") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblamt" runat="server" Text='<%#Eval("Amount") %>'></asp:Label></ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Adjust Amount">
                                            <ItemTemplate>
                                                <asp:Label ID="lbladjamt" runat="server" Text=""></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TDS">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltds" runat="server" Text=""></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                </table>
            </asp:Panel>
            <table class="table">
                <tr>
                    <td >
                        </td>
                </tr>
                <tr>
                    <td class="tdLabel" align="right">
                        <asp:Label ID="Label18" runat="server"  Text="No Of (Bills):"></asp:Label>
                    </td>
                    <td class="style1">
                        <asp:Label ID="lblValNoOfBill" runat="server" Text="0"></asp:Label>
                    </td>
                    <td class="tdControl" align="right">
                        <asp:Label ID="Label20" runat="server" Text="All Bills Amount:"></asp:Label>
                    </td>
                    <td style="width:20px">
                        <asp:Label ID="lblValAllBillsAmount" runat="server" Text="0"></asp:Label>
                    </td>
                    <td class="tdLabel" align="right">
                        <asp:Label ID="Label19" runat="server" Text="TDS Amount :"></asp:Label>
                    </td>
                    <td class="tdLabel">
                        <asp:Label ID="lblValTDSAmount" runat="server" Text="0"></asp:Label>
                    </td>
                    <td class="tdControl" align="right">
                        <asp:Button ID="btnSaveRecpt" runat="server"
                            Text="Save" ValidationGroup="SaveReceipt" onclick="btnSaveRecpt_Click" />
                    </td>
                    <td class="tdControl">
                        <asp:Button ID="BtnClearRec" runat="server"  OnClick="BtnClearRec_Click"
                            Text="Clear" ValidationGroup="Save Receipt"  />
                    </td>
                    <td class="tdControl">
                    <asp:Button ID="btnCancel" runat="server"  OnClick="BtnCnclRec_Click"
                            Text="Cancel"  /></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
