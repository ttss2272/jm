<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="AddReceipt1.aspx.cs" Inherits="Juris.Admin.Receipt.AddReceipt1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 20%;
            height: 26px;
        }
        .style2
        {
            width: 30%;
            height: 26px;
        }
        </style>
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
            <asp:Panel ID="PanelAddReceipt" runat="server" Height="600px" Width="925px" 
                GroupingText="Party Details">
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
                        <td class="style1" align="right">
                            <asp:Label ID="Label3" runat="server" Text="TDS % :"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:TextBox ID="txtTDSPerc" runat="server"></asp:TextBox>
                           <%-- <asp:RegularExpressionValidator ID="REVAMT" runat="server" 
                                ControlToValidate="txtTDSPerc" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Enter Only Numbers." 
                                ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>--%>
                        </td>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label37" runat="server" Text="Date :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtRecDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                TargetControlID="txtRecDate">
                            </asp:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="tdLabel">
                       
                            <asp:Label ID="Label5" runat="server" Text="Client Name:"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:TextBox ID="txtClientName1" runat="server"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="DrplstClRec" ErrorMessage="*" ForeColor="Red" 
                                        InitialValue="-1" ToolTip="Please selest Client Name" 
                                        ValidationGroup="SaveReceipt"></asp:RequiredFieldValidator>--%>
                                    <br />
                                </ContentTemplate>
                            </asp:UpdatePanel>
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
                         <td align="right" class="tdLabel">
                          
                            <asp:Label ID="Label4" runat="server" Text="Comments :"></asp:Label>
                          
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>

                         <td class="tdLabel" align="right">
                            <asp:Label ID="Label9" runat="server" Text="Cheque/Draft No. :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtChqOrDftNo" runat="server"></asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="REVchequedrftno" runat="server" 
                                ControlToValidate="txtChqOrDftNo" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Please Enter Only Numbers." 
                                ValidationExpression="[0-9]{1,50}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>--%>
                        </td>                    
                    </tr>
                    
                    <tr>
                         <td class="tdLabel" align="right">
                            <asp:Label ID="Label14" runat="server" Text="Type Of Work 1 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:Label ID="lblClId" runat="server" Text=" "></asp:Label>
                            <asp:TextBox ID="txtTOW1" runat="server"></asp:TextBox>
                        </td>   
                        <td class="tdLabel" align="right">
                           
                            <asp:Label ID="Label7" runat="server" Text="Property Address 1 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtPropertyAddress1" runat="server" TextMode="MultiLine" 
                               ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right" >                           
                            <asp:Label ID="Label30" runat="server" Text="Amount 1 :"></asp:Label>                           
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtAmt1" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                         <td class="tdLabel" align="right">
                            <asp:Label ID="Label6" runat="server" Text="Type Of Work 2 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtTOW2" runat="server"></asp:TextBox>
                        </td>   
                        <td class="tdLabel" align="right">                           
                            <asp:Label ID="Label10" runat="server" Text="Property Address 2 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtPropertyAddress2" runat="server" TextMode="MultiLine" 
                               ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right" >                           
                            <asp:Label ID="Label12" runat="server" Text="Amount 2 :"></asp:Label>                           
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtAmt2" runat="server" AutoPostBack="True" ></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                         <td class="tdLabel" align="right">
                            <asp:Label ID="Label8" runat="server" Text="Type Of Work 3 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtTOW3" runat="server"></asp:TextBox>
                        </td>   
                        <td class="tdLabel" align="right">                           
                            <asp:Label ID="Label13" runat="server" Text="Property Address 3 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtPropertyAddress3" runat="server" TextMode="MultiLine" 
                               ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right" >                           
                            <asp:Label ID="Label15" runat="server" Text="Amount 3 :"></asp:Label>                           
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtAmt3" runat="server"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                         <td class="tdLabel" align="right">
                            <asp:Label ID="Label16" runat="server" Text="Type Of Work 4 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtTOW4" runat="server"></asp:TextBox>
                        </td>   
                        <td class="tdLabel" align="right">                           
                            <asp:Label ID="Label17" runat="server" Text="Property Address 4 :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtPropertyAddress4" runat="server" TextMode="MultiLine" 
                               ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right" >                           
                            <asp:Label ID="Label18" runat="server" Text="Amount 4 :"></asp:Label>                           
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtAmt4" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>                       
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label11" runat="server" Text="Discount :"></asp:Label>
                           </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtDisc" runat="server" AutoPostBack="True" 
                                OnTextChanged="txtDisc_TextChanged">0</asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegExpresdiscount" runat="server" 
                                ControlToValidate="txtDisc" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                                ToolTip="Enter Only Numbers." ValidationExpression="[0-9.]{1,10}" 
                                ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>--%>
                            <br />
                        </td>
                        
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label29" runat="server" Text="Bill Amount :"></asp:Label>
                        </td>
                        <td class="tdControl">
                            <asp:TextBox ID="txtBllAmt" runat="server" ReadOnly="True">0</asp:TextBox>
                           <%-- <asp:RegularExpressionValidator ID="RegExpresbillamt" runat="server" 
                                ControlToValidate="txtBllAmt" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Enter Only Numbers." 
                                ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>--%>
                            <br />
                        </td> 
                    </tr>                    
                    <tr>
                        <td class="tdLabel" align="right">
                            <asp:Label ID="Label31" runat="server" Text="TDS :"></asp:Label>
                           </td>
                        <td >                         
                            <asp:TextBox ID="txtTDSReadOnly" runat="server" ReadOnly="True">0</asp:TextBox>
                            <br />
                        </td>
                          <td class="tdLabel" align ="right">
                            <asp:Label ID="Label32" runat="server" Text="Balance Amount:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtBalamt" runat="server" AutoPostBack="True" ReadOnly="True">0.0</asp:TextBox>
                            <%--<asp:RegularExpressionValidator ID="RegExpresbalamt" runat="server" 
                                ControlToValidate="txtBalamt" Display="Dynamic" ErrorMessage="*" 
                                ForeColor="Red" ToolTip="Enter Only Numbers." 
                                ValidationExpression="[0-9.-]{1,20}" ValidationGroup="SaveReceipt"></asp:RegularExpressionValidator>--%>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel" align="right">                           
                            &nbsp;</td>
                        <td>
                           <asp:CheckBox ID="chkbxAppRecpt" runat="server" Text="Approve Receipt" 
                                 /></td>
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
            <table class="table">                
                <tr>
                    <td class="tdControl" align="right">
                    </td>
                    <td class="tdControl">
                        <asp:Button ID="btnSaveRecpt" runat="server"
                            Text="Save" ValidationGroup="SaveReceipt" />&nbsp;
                        <asp:Button ID="BtnClearRec" runat="server"  
                            Text="Clear" ValidationGroup="Save Receipt"/>&nbsp;
                        <asp:Button ID="btnCancel" runat="server"  OnClick="BtnCnclRec_Click"
                            Text="Cancel"/>
                    </td>
                    <td class="tdControl">
                        &nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
