<%@ Page ValidateRequest="false" Title="" Theme="Skin1" Language="C#" MasterPageFile="~/admin.Master"
    AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="Juris.Admin.Client.AddClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
   
    <style type="text/css">
        .style1
        {
            width: 174px;
        }
    </style>
   
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function validateForm() {
            var x = document.forms["addclient"]["txtEmailId1"].value;
            var atpos = x.indexOf("@");
            var dotpos = x.lastIndexOf(".");
            if (atpos < 1 || dotpos < atpos + 2 || dotpos + 2 >= x.length) {
                alert("Not a valid e-mail address");
                return false;
            }
        }
    </script>
    <div style="width: 100%">
        <div align="center">
            <h2>
                <asp:Label ID="Label28" runat="server" Text="Add Client"></asp:Label>
            </h2>
        </div>
        <asp:Label ID="lblResult" runat="server" Visible="False" ForeColor="Green"></asp:Label>
            <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
    </div>
    <div style="width: 100%;">
        <%----------------------------------------Left div------------------------------------%>
        <div style="width: 55%;">
            <table class="table">
            <tr><td>
            
            </td></tr>
                <tr>
                    <td align="right" class="style1">
                    </td>
                    <td class="tdLabel">
                        <asp:Label ID="lblPrefixmsg" runat="server" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="left" class="style1">
                        <asp:Label ID="Label1" runat="server" Text="Client Code :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtClientCode" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label2" runat="server" Text="Prefix :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtPrefix" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RequiredFieldValidator ID="reqfldvalPrefix" runat="server" ControlToValidate="txtPrefix"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Prefix cannot be empty"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label3" runat="server" Text="Client Name :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtClientNm" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtClientNm"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="ClientVal" SetFocusOnError="True"
                            ForeColor="Red" ToolTip="Enter Client Name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVClientName" runat="server" ControlToValidate="txtClientNm"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="^[a-zA-Z'/\|!$(),@&#.\s]{3,50}$"
                            ToolTip="Please Enter Characters Only." ValidationGroup="ClientVal"></asp:RegularExpressionValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label4" runat="server" Text="Address 1:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtadd1" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtadd1"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Enter Address"></asp:RequiredFieldValidator>
                    </td>
                    <td class="tdValidation">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label5" runat="server" Text="Address 2:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtadd2" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lbladd3" runat="server" Text="Address 3:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtadd3" runat="server" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label8" runat="server" Text="City :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtCityClient" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RequiredFieldValidator ID="ReqFldvalCity" runat="server" ControlToValidate="txtCityClient"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Enter City Name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVCity" runat="server" ControlToValidate="txtCityClient"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="[a-zA-Z]{3,50}$"
                            ToolTip="Enter Character Only" ValidationGroup="ClientVal"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label9" runat="server" Text="Branch :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtClientBranch" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RequiredFieldValidator ID="ReqFldvalBranch" runat="server" ControlToValidate="txtCityClient"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True"
                            ValidationGroup="ClientVal" ToolTip="Enter Branch Name"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVBranch" runat="server" ControlToValidate="txtClientBranch"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="^[a-zA-Z'/\|!$(),@&#.\s]{3,50}$"
                            ToolTip="Please Enter Characters Only." ValidationGroup="ClientVal"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label10" runat="server" Text="Pincode :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtPin" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RequiredFieldValidator ID="ReqFldvalPin" runat="server" ControlToValidate="txtPin"
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="ClientVal" ForeColor="#FF3300"
                            ToolTip="Enter Pin Code"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVpincode" runat="server" ControlToValidate="txtPin"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="[0-9]{6}"
                            ToolTip="Enter 6 Digit PinCode No." ValidationGroup="ClientVal"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label11" runat="server" Text="PAN No :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtPANClient" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RequiredFieldValidator ID="ReqFldvalPANNo" runat="server" ControlToValidate="txtPANClient"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Enter PAN No"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label12" runat="server" BorderStyle="None" Text="Telephone :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtTelClient" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RequiredFieldValidator ID="ReqFldvalTel" runat="server" ControlToValidate="txtTelClient"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Enter Telephone No"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="REVtelephoneNo" runat="server" ControlToValidate="txtTelClient"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="^[0-9]{7,15}$"
                            ToolTip="Enter Valid Telephone No." ValidationGroup="ClientVal"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label13" runat="server" Text="Mobile :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtMobClient" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RegularExpressionValidator ID="RegExpValMobNo" runat="server" ControlToValidate="txtMobClient"
                            ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationExpression="[0-9]{10}"
                            ValidationGroup="ClientVal" ToolTip="Enter Valid Mobile No"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label14" runat="server" Text="Contact Person 1:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtContactPer1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVConctactpar1" runat="server" ControlToValidate="txtContactPer1"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ClientVal" ValidationExpression="^[a-zA-Z'/\|!$(),@&#.\s]{3,50}$"
                            ToolTip="Please Enter Characters Only."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label15" runat="server" Text="Contact No:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtContact1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RegExpcontactper1" runat="server" ControlToValidate="txtContact1"
                            ErrorMessage="*" ForeColor="#FF3300" SetFocusOnError="True" ValidationExpression="[0-9]{10}"
                            ValidationGroup="ClientVal" ToolTip="Enter Valid Mobile No"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label16" runat="server" Text="Email ID 1:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtEmailId1" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <%--<asp:RequiredFieldValidator ID="RequiredEmailId1" runat="server" ControlToValidate="txtEmailId1"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Enter Telephone No"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegExpValEmil1" runat="server" ControlToValidate="txtEmailId1"
                            ErrorMessage="*" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ForeColor="#FF3300" ValidationGroup="ClientVal" ToolTip="Enter Valid Email Id">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label17" runat="server" Text="Contact Person 2:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtContactPer2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="REVContactper2" runat="server" ControlToValidate="txtContactPer2"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="^[a-zA-Z'/\|!$(),@&#.\s]{3,50}$"
                            ToolTip="Please Enter Characters Only."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label18" runat="server" Text="Contact No:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtContact2" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RExpContact2" runat="server" ControlToValidate="txtContact2"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}"
                            ValidationGroup="ClientVal" ToolTip="Enter Valid Mobile No"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label19" runat="server" Text="Email ID 2:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtEmailId2" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <%--<asp:RequiredFieldValidator ID="RequiredEmailId2" runat="server" ControlToValidate="txtEmailId2"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Enter  Email Id"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegExpValEmil2" runat="server" ControlToValidate="txtEmailId2"
                            ErrorMessage="*" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ForeColor="#FF3300" ValidationGroup="ClientVal" ToolTip="Enter Valid Email Id">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label20" runat="server" Text="Contact Person 3:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtContactPer3" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <asp:RegularExpressionValidator ID="REVContactper3" runat="server" ControlToValidate="txtContactPer3"
                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationExpression="^[a-zA-Z'/\|!$(),@&#.\s]{3,50}$"
                            ToolTip="Please Enter Characters Only."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label21" runat="server" Text="Contact No:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtContact3" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RegularExpressionValidator ID="RExpContact5" runat="server" ControlToValidate="txtContact3"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{10}"
                            ValidationGroup="ClientVal" ToolTip="Enter Valid Mobile No"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label22" runat="server" Text="Email ID 3:"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtEmailId3" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation">
                        <%--<asp:RequiredFieldValidator ID="RequiredEmailId3" runat="server" ControlToValidate="txtEmailId3"
                            Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="ClientVal"
                            ForeColor="#FF3300" ToolTip="Enter Email Id"></asp:RequiredFieldValidator>--%>
                        <asp:RegularExpressionValidator ID="RegExpValEmil3" runat="server" ControlToValidate="txtEmailId3"
                            ErrorMessage="*" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                            ForeColor="#FF3300" ValidationGroup="ClientVal" ToolTip="Enter Valid Email Id"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="Label23" runat="server" Text="Is Deleted ?"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:RadioButton ID="rbtnYesIsDel" runat="server" Text="Yes" GroupName="GrpIsDel" />
                        <asp:RadioButton ID="rbtnNoIsDel" runat="server" GroupName="GrpIsDel" Text="No" Checked="True" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <asp:Label ID="lblSerTax1" runat="server" Text="Service Tax :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtSerTaxClient" runat="server">0</asp:TextBox><br />
                        <asp:CheckBox ID="chkbxAppCl" runat="server" Text="Approve Client" />
                    </td>
                </tr>
            </table>
            <table align="center">
                <tr>
                    <td>
                        <asp:Button ID="btnSaveClient" runat="server" OnClick="btnSaveClient_Click" Text="Save"
                            ValidationGroup="ClientVal" />
                        <asp:Button ID="btnClearFlds" runat="server" OnClick="btnClearFlds_Click" Text="Clear" />
                        <asp:Button ID="btnCncl" runat="server" OnClick="btnCncl_Click" Text="Cancel" 
                            CausesValidation="False" />
                    </td>
                </tr>
            </table>
        </div>
        <%----------------------------------------Right div------------------------------------%>
        <div style="width: 42%; position: absolute; right: 100px; top: 180px">
            <table>
                <tr>
                    <td colspan="2" class="tdLabel">
                        <asp:Label ID="lblser" runat="server" ForeColor="Green"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="tdLabel">
                        <asp:Label ID="lblServiceHeading" runat="server" Text="Add Services For Client" Font-Size="Large"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">
                        <asp:Label ID="Label27" runat="server"></asp:Label>
                    </td>
                    <td class="tdLabel">
                        <asp:Label ID="lblSerId" runat="server" Visible="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">
                        <asp:Label ID="Label7" runat="server" Text="Service Name:"></asp:Label>
                    </td>
                    <td align="left" class="tdControl">
                        <asp:DropDownList ID="drpDwnlstSerNm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                            <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">
                        <asp:Label ID="Label26" runat="server" Text="Price :"></asp:Label>
                    </td>
                    <td class="tdControl">
                        <asp:TextBox ID="txtSerPrice" runat="server" Text="0"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegExpprice" runat="server" ControlToValidate="txtSerPrice"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationExpression="[0-9]{1,10}"
                            ValidationGroup="ser" ToolTip="Enter Only Numbers."></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td class="tdControl">
                        <asp:Button ID="btnAddSer" runat="server" Text="Add Service" OnClick="btnAddSer_Click"
                            ValidationGroup="ser" />
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;
                    </td>
                    <td class="tdControl">
                        &nbsp;
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" Width="75%" ScrollBars="Vertical" BorderWidth="1px"
                Height="200px">
                <asp:GridView ID="GdVwService" runat="server" AutoGenerateColumns="False" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSel" AutoPostBack="true" OnCheckedChanged="onCheck" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%-- <asp:TemplateField HeaderText ="ServiceId">
               
                            <ItemTemplate >
                            <%#Eval("ServiceId")%></ItemTemplate> 
                    </asp:TemplateField> 
                     <asp:TemplateField HeaderText ="Price">
                     <ItemTemplate ><%#Eval("Price")%></ItemTemplate>
                     
                     </asp:TemplateField> --%>
                        <asp:BoundField DataField="ServiceId" HeaderText="ServiceId" />
                        <asp:BoundField DataField="Price" HeaderText="Price" InsertVisible="False" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            <table class="table">
                <tr>
                    <td class="tdLabel">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td class="tdControl">
                        <asp:Label ID="Label24" runat="server" Text="Email Id For Invoice :"></asp:Label>
                        <asp:TextBox ID="txtEmlIdInvce" runat="server" Text="" Style="margin-left: 60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="tdLabel">
                        <asp:Label ID="Label25" runat="server" Text="Multiple Email Id's (Should Be Separated By Comma):"></asp:Label>
                    </td>
                    <tr >
                        <td class="tdControl">
                            <asp:TextBox ID="txtMulEmailId" runat="server" Text="" TextMode="MultiLine" Style="margin-left: 180px"></asp:TextBox>
                        </td>
                    </tr>
            </table>
        </div>
    </div>
</asp:Content>
