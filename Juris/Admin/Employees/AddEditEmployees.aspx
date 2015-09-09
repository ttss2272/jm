<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true"
    CodeBehind="AddEditEmployees.aspx.cs" Inherits="Juris.Admin.Employees.AddEditEmployees" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
     
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center" style="width: 100%">
        <h3>
            <asp:Label ID="lblAddEditEmpHeading" runat="server" Text="Add/Edit Employee" Font-Bold="True"></asp:Label>
        </h3>
    </div>
    <asp:Panel ID="PanelAddEmp" runat="server" GroupingText="Add/Edit Employee Details">
        <table width="100%" >
              
           
            <tr>
              <td class="style2" ></td>
                <td class="tdLabel" align="left" colspan="5" >
                    <asp:Label ID="lblResult" runat="server" Text="" Visible="False" ForeColor ="Green" ></asp:Label>
                    &nbsp;<asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td></td>
             
               
                
</tr> 
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblEmpMaxCode" runat="server" Text="" Visible="False"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="TextBox2" runat="server" ReadOnly="True" Visible="False">JMEMP</asp:TextBox>
                        <asp:Label ID="lblEmpId" runat="server" Text="" Visible="False"></asp:Label>
                    </td>
                    <td class="style1"></td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblEmpName0" runat="server" Text="Employee Name :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtEmpNm" runat="server"  
                            ></asp:TextBox>
                        <br />
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RFVEmpNm" runat="server" 
                            ControlToValidate="txtEmpNm" Display="Dynamic" 
                            ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="AddEmp" ToolTip="Employee Name should be given."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVName" runat="server" 
                            ControlToValidate="txtEmpNm" Display="Dynamic" 
                            ErrorMessage="*" ForeColor="Red" 
                            ValidationExpression="^[a-zA-Z'/\|! $(),@&#.\s]{3,50}$" ValidationGroup="AddEmp" ToolTip="Please Enter Characters Only."></asp:RegularExpressionValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblPan0" runat="server" Text="PAN No :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPanNo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="reVPanNo0" runat="server" 
                            ControlToValidate="txtPanNo" ErrorMessage="*" ForeColor="Red" 
                            ToolTip="Please enter Valid Pan no" ValidationExpression="[a-zA-Z0-9]{10}$" 
                            ValidationGroup="AddEmp"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblEmpcode" runat="server" Text="Employee Code :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtEmpCode" runat="server" ReadOnly="True"></asp:TextBox>
                        <br />
                    </td>
                    <td align="right" class="style1"></td>
                    <td align="right">
                        <asp:Label ID="lblBankName0" runat="server" Text="Bank Name :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBnkNm" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVBankName0" runat="server" 
                            ControlToValidate="txtBnkNm" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                            ToolTip="Please Enter Characters Only." 
                            ValidationExpression="^[a-zA-Z'/\|! $(),@&amp;#.\s]{3,50}$" 
                            ValidationGroup="AddEmp"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblEmpAddress" runat="server" Text="Address 1 :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtAddressL1" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <br />
                    </td>
                    <td class="style1">
                        <asp:RequiredFieldValidator ID="RFVEmpAdd1" runat="server" 
                            ControlToValidate="txtAddressL1" Display="Dynamic" 
                            ErrorMessage="*" ForeColor="Red" 
                            ValidationGroup="AddEmp" ToolTip="Address should be given."></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblBranch0" runat="server" Text="Branch :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBranch" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVbranch0" runat="server" 
                            ControlToValidate="txtBranch" Display="Dynamic" ErrorMessage="*" 
                            ForeColor="Red" ToolTip="Please Enter Character Only." 
                            ValidationExpression="^[a-zA-Z'/\|! $(),@&amp;#.\s]{3,50}$" 
                            ValidationGroup="AddEmp"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblEmpAddress0" runat="server" Text="Address 2 :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtAddressL2" runat="server" TextMode="MultiLine"></asp:TextBox>
                        <br />
                    </td>
                    <td class="style1">
                    </td>
                    <td align="right">
                        <asp:Label ID="lblMob0" runat="server" Text="Mobile :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtMobEmp" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVMobEmp0" runat="server" 
                            ControlToValidate="txtMobEmp" Display="Dynamic" ErrorMessage="*" 
                            ForeColor="Red" ToolTip="Please enter valid Mobile No." 
                            ValidationExpression="^[\s\S]{10}$" ValidationGroup="AddEmp"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblEmpAddress1" runat="server" Text="Address 3 :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtAddressL3" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td class="style1">
                    </td>
                    <td align="right">
                        <asp:Label ID="lblBnkAddress0" runat="server" Text="Bank Address :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtBnkAddress" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblEmail" runat="server" Text="Email Id :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <br />
                    </td>
                    <td class="style1">
                        <asp:RegularExpressionValidator ID="RegExpEmailId" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtEmail" 
                            Display="Dynamic" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                            ValidationGroup="AddEmp" ForeColor="Red" ToolTip="Enter Valid Email Id." ></asp:RegularExpressionValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblAccNo0" runat="server" Text="Account No :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAccNo" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegularExpression0" runat="server" 
                            ControlToValidate="txtAccNo" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                            ToolTip="Please Enter Valid Account No." 
                            ValidationExpression="^[0-9-_,.]{1,20}" ValidationGroup="AddEmp"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblTelPhn" runat="server" Text="Telephone :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtTelephn" runat="server"></asp:TextBox>
                    </td>
                    <td class="style1">
                        <asp:RegularExpressionValidator ID="REVtelephoneNo" runat="server" 
                            ControlToValidate="txtTelephn" Display="Dynamic" ErrorMessage="*" 
                            ForeColor="Red" ToolTip="Enter Valid Telephone No." 
                            ValidationExpression="[0-9-]{5,20}" 
                            ValidationGroup="AddEmp"></asp:RegularExpressionValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="lblDesig0" runat="server" Text="Designation :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesig" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVDesignation0" runat="server" 
                            ControlToValidate="txtDesig" Display="Dynamic" ErrorMessage="*" ForeColor="Red" 
                            ToolTip="Please Enter Characters Only." 
                            ValidationExpression="^[a-zA-Z'/\|! $(),@&amp;#.\s]{3,50}$" 
                            ValidationGroup="AddEmp"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        <asp:Label ID="lblIsDel0" runat="server" Text="Is Deleted ?"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:RadioButton ID="rbYes" runat="server" GroupName="IsDeleted" Text="Yes" />
                        <asp:RadioButton ID="rbNo" runat="server" Checked="True" GroupName="IsDeleted" 
                            Text="  No" />
                    </td>
                    <td class="style1">
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td class="style2">
                    </td>
                    <td align="right" class="tdLabel">
                        &nbsp;</td>
                    <td class="tdControl">
                        <asp:CheckBox ID="chkBxApprove" runat="server" Text="Approve Employee" />
                        <br />
                    </td>
                    <td class="style1">
                    </td>
                    <td></td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan="6" align="center" class="style2">
                        <asp:Button ID="btnSaveAddEmp" runat="server" OnClick="btnSaveAddEmp_Click" 
                            Text="Save" ValidationGroup="AddEmp" />
                        <asp:Button ID="btnClearAddEmp" runat="server" OnClick="btnClearAddEmp_Click" 
                            Text="Clear" />
                        <asp:Button ID="btnCancl" runat="server" OnClick="btnCancl_Click" 
                            Text="Cancel" />
                    </td>
                </tr>
                
            
        </table>
    </asp:Panel>
   
</asp:Content>
