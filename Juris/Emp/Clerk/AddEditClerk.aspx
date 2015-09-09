<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="AddEditClerk.aspx.cs" Inherits="Juris.Emp.Clerk.AddEditClerk" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     
   
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    
<div  style = "width :100%">
    <div align="center">
        <h3>
            <asp:Label ID="lblAddClerkHeading" runat="server" Text="Add New Clerk" Font-Bold="True"></asp:Label>
        </h3>
    </div>

    <asp:Panel ID="PanelAddClerk" runat="server" GroupingText="Add/Edit Clerk Details">
        <table class="table">
            <tr>
                <td align="right">                
                    <asp:Label ID="lblPrjId0" runat="server" Visible="False"></asp:Label>
                </td>
                <td colspan="5">
                    <asp:Label ID="lblResult" runat="server" Visible="False" ForeColor ="Green" ></asp:Label><br />
                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblClerkName" runat="server" Text="Clerk Name :"></asp:Label>
                </td>
                <td class="tdControl">
                    <asp:TextBox ID="txtClerkNm" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVClrkNm1" runat="server" 
                        ControlToValidate="txtClerkNm" Display="Dynamic" ErrorMessage="*" 
                        ForeColor="Red" ToolTip="Clerk Name Should Be Given." 
                        ValidationGroup="SaveClerk"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REVName1" runat="server" 
                        ControlToValidate="txtClerkNm" Display="Dynamic" ErrorMessage="*" 
                        ForeColor="Red" ToolTip="Please Enter Character Only." 
                        ValidationExpression="^[a-zA-Z'/\|! $(),@&amp;#.\s]{3,50}$"></asp:RegularExpressionValidator>
                </td>
                <td class="style1" >
                    &nbsp;</td>
                <td align="right" class="style4">


                    <asp:Label ID="lblTelPhnClrk0" runat="server" Text="Telephone :"></asp:Label>


                    </td>

                <td class="style3">
                
                    <asp:TextBox ID="txtTelephnClrk" runat="server"></asp:TextBox>
                
                   </td>
                   <td class="style1">
                   
                       <asp:RequiredFieldValidator ID="RFVTelephone3" runat="server" 
                           ControlToValidate="txtTelephnClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Please Enter Telephone No." 
                           ValidationGroup="SaveClerk"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="REVtelephoneNo" runat="server" 
                           ControlToValidate="txtTelephnClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ValidationExpression="^[0-9'/\|! -$(),@&amp;#.\s]{7,15}$" 
                           ValidationGroup="SaveClerk" ToolTip="Enter Valid Telephone No."></asp:RegularExpressionValidator>
                
                   </td>

                <caption>
                    <br />
                </caption>
            </tr>
            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblClerkAddress1" runat="server" Text="Address 1 :"></asp:Label>
                </td>
                <td class="tdControl">
                    <asp:TextBox ID="txtClrkAdd1" runat="server" TextMode="MultiLine"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVClrkAdd3" runat="server" 
                        ControlToValidate="txtClrkAdd1" Display="Dynamic" ErrorMessage="*" 
                        ForeColor="Red" ToolTip="Address Should Be Given." ValidationGroup="SaveClerk"></asp:RequiredFieldValidator>
                </td>
                <td class="style1">
                    &nbsp;</td>

                <td align="right" class="style4">


                    <asp:Label ID="lblMobClrk0" runat="server" Text="Mobile :"></asp:Label>


                    </td>

                <td class="style3">
                
                    <asp:TextBox ID="txtMobClrk" runat="server"></asp:TextBox>
                
                   </td>
                   <td class="style1">
                   
                       <asp:RegularExpressionValidator ID="REVMobClrk2" runat="server" 
                           ControlToValidate="txtMobClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Please Enter Valid Mobile No." 
                           ValidationExpression="[0-9]{10}" ValidationGroup="SaveClerk"></asp:RegularExpressionValidator>
                       <asp:RequiredFieldValidator ID="RFVMob1" runat="server" 
                           ControlToValidate="txtMobClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Please Enter  Mobile No." ValidationGroup="SaveClerk"></asp:RequiredFieldValidator>
                   
                   </td>
            </tr>
            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblClerkAddress2" runat="server" Text="Address 2 :"></asp:Label>
                </td>
                <td class="tdControl">
                    <asp:TextBox ID="txtClrkAdd2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style1">
                </td>
            
            <td align="right" class="style4">


                    <asp:Label ID="lblPanclrk0" runat="server" Text="PAN No :"></asp:Label>


                    </td>

                <td class="style3">
                
                    <asp:TextBox ID="txtPanNoClrk" runat="server"></asp:TextBox>
                
                   </td>
                   <td class="style1">
                   
                       <asp:RequiredFieldValidator ID="RFVClrkPANno2" runat="server" 
                           ControlToValidate="txtPanNoClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Please Give PAN No." ValidationGroup="SaveClerk"></asp:RequiredFieldValidator>
                   
                   </td>
            
            </tr>


            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblClerkAddress3" runat="server" Text="Address 3 :"></asp:Label>
                </td>
                <td class="tdControl">
                    <asp:TextBox ID="txtClrkAdd3" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style1">
                </td>
                <td align="right" class="style4">


                    <asp:Label ID="lblEmailClrk0" runat="server" Text="Email Id :"></asp:Label>


                    </td>

                <td class="style3">
                
                    <asp:TextBox ID="txtEmailClrk" runat="server"></asp:TextBox>
                
                   </td>
                   <td class="style1">
                  <%-- <asp:RequiredFieldValidator ID="RequiredEmailClrk" runat="server" 
                           ControlToValidate="txtEmailClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Please Give EmailId" ValidationGroup="SaveClerk">
                           </asp:RequiredFieldValidator>--%>

                       <asp:RegularExpressionValidator ID="RegExpEmailClrk2" runat="server" 
                           ControlToValidate="txtEmailClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Please Enter Valid EmailID" 
                           ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                           ValidationGroup="SaveClerk"></asp:RegularExpressionValidator>
                   
                   </td>
            </tr>
            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblClerkAddress4" runat="server" Text="Address 4 :"></asp:Label>
                </td>
                <td class="tdControl">
                    <asp:TextBox ID="txtClrkAdd4" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td class="style1">
                </td>
                <td align="right" class="style4">


                    <asp:Label ID="lblTdsRate" runat="server" Text="TDS Rate :"></asp:Label>


                    </td>

                <td class="style3">
                
                    <asp:TextBox ID="txtTDSRateClrk" runat="server"></asp:TextBox>
                
                   </td>
                   <td class="style1">
                   
                       <asp:RequiredFieldValidator ID="RFVTds1" runat="server" 
                           ControlToValidate="txtTDSRateClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Please Give Numeric TDS Rate" 
                           ValidationGroup="SaveClerk"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
                           ControlToValidate="txtTDSRateClrk" Display="Dynamic" ErrorMessage="*" 
                           ForeColor="Red" ToolTip="Enter Numbers with 2 decimal places only" 
                           ValidationExpression="[0-9]+([\.|,][0-9]+)?" ValidationGroup="SaveClerk"></asp:RegularExpressionValidator>
                   
                   </td>
            </tr>
            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="Label1" runat="server" Text="Is Deleted ?"></asp:Label>
                </td>
                <td class="tdControl">
                    <asp:RadioButton ID="rbYes" runat="server" GroupName="IsDeleted" Text="Yes" />
                    <asp:RadioButton ID="rbNo" runat="server" Checked="True" GroupName="IsDeleted" 
                        Text="No" />
                    <br />
                </td>
                <td class="style1">
                    &nbsp;</td>
                    <td></td>
                    <td></td>
                    <td></td>
            </tr>
            
            <tr>
                <td align="right" class="tdLabel">
                    &nbsp;</td>
                <td class="tdControl">
                    <asp:CheckBox ID="chkBxApprove" runat="server" Text="Approve Clerk" />
                </td>
                <td class="style1">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td align="right">
                </td>
                <td colspan="3" align="center">
                    <asp:Button ID="btnSaveAddClerk" runat="server" OnClick="btnSaveAddClerk_Click" Text="Save"
                        ValidationGroup="SaveClerk" />
                    <asp:Button ID="btnClearAddClerk" runat="server" OnClick="btnClearAddClerk_Click"
                        Text="Clear" />
                    <asp:Button ID="btnCancl" runat="server" OnClick="btnCancl_Click" Text="Cancel" />
                </td>
                <td></td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>
    
    </div>

</asp:Content>
