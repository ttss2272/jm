<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" Theme="Skin1" AutoEventWireup="true"
    CodeBehind="DocumentBoys.aspx.cs" Inherits="Juris.Emp.Document_Boys.DocumentBoys" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type = "text/javascript">
         var ddlText, ddlValue, ddl; //lblMesg
         function CacheItems() {
             ddlText = new Array();
             ddlValue = new Array();
             ddl = document.getElementById("<%=ddlDocBoy.ClientID %>");

             for (var i = 0; i < ddl.options.length; i++) {
                 ddlText[ddlText.length] = ddl.options[i].text;
                 ddlValue[ddlValue.length] = ddl.options[i].value;
             }
         }
         window.onload = CacheItems;

         function FilterItems(value) {
             ddl.options.length = 0;
             for (var i = 0; i < ddlText.length; i++) {
                 if (ddlText[i].toLowerCase().indexOf(value) != -1) {
                     AddItem(ddlText[i], ddlValue[i]);
                 }
             }
             lblMesg.innerHTML = ddl.options.length + " items found.";
             if (ddl.options.length == 0) {
                 AddItem("No items found.", "");
             }
         }

         function AddItem(text, value) {
             var opt = document.createElement("option");
             opt.text = text;
             opt.value = value;
             ddl.options.add(opt);
         }
</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div align="center" style ="width :100%">
        <h2>
            <asp:Label ID="lblAddEditDocBoyHeading" runat="server" Text="Add/Edit Document Boy">
                </asp:Label>
        </h2>
        <asp:Panel ID="PanelAddEditDocumentBoy" runat="server" GroupingText="Add/Edit Document Boy">
        <table class="table">
            <tr>
               
                <td class="tdLabel"align="center" colspan ="3">
                    <asp:Label ID="lblResult" runat="server" Visible="False" ForeColor ="Green" ></asp:Label>
                    &nbsp;<asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                    
                </td>
           
            </tr>
            <tr>
                    
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblCode" runat="server" Text="Code :"></asp:Label>
                </td>
                <td align="left" class="tdControl">
                    <asp:TextBox ID="txtCodeDocBoy" runat="server" ReadOnly="True"></asp:TextBox>
                    <asp:Label ID="lblDocMaxCode" runat="server" Text="" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" ReadOnly="True" Visible="False">JMDOCB</asp:TextBox>
                    <asp:Label ID="lblDocBoyId" runat="server" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                     
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblNameDocBoy" runat="server" Text="Name :"></asp:Label>
                </td>
                <td class="tdControl" align="left">
                    <asp:TextBox ID="txtNameDocBoy" runat="server" ></asp:TextBox>
                    </td>
                    <td class="tdValidation" align="left">
                    <asp:RequiredFieldValidator ID="RFVDocBoyNm" runat="server" ControlToValidate="txtNameDocBoy"
                        Display="Dynamic" ErrorMessage="*" ValidationGroup="Validation"
                        ForeColor="Red" ToolTip="Please give name."></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                            ErrorMessage="*" ControlToValidate="txtNameDocBoy" Display="Dynamic" ForeColor="red" ValidationGroup="Validation" 
                        validationexpression="^[a-zA-Z\s]+$" ToolTip="Please Enter Characters Only."></asp:RegularExpressionValidator>
                       
                </td>
            </tr>
            <tr>
                     
                <td class="tdLabel" align="right">
                    <asp:Label ID="lblMobDocBoy" runat="server" Text="Mobile :"></asp:Label>
                </td>
                <td class="tdControl" align="left">
                    <asp:TextBox ID="txtMobileDocBoy" runat="server"></asp:TextBox>
                    </td>
                    <td class="tdValidation" align="left">
                    <asp:RegularExpressionValidator ID="REVMobDocBoy" runat="server" ControlToValidate="txtMobileDocBoy"
                        Display="Dynamic" ErrorMessage="*" ValidationExpression="[0-9]{10}"
                        ValidationGroup="Validation" ForeColor="Red" 
                            ToolTip="Please enter valid Mobile No." SetFocusOnError="True"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblEmail" runat="server" Text="E-Mail :"></asp:Label>
                </td>
                <td align="left" class="tdControl">
                    <asp:TextBox ID="txtMailIDDocBoy" runat="server"></asp:TextBox>
                </td>
                <td align="left" class="tdValidation">
                    <asp:RequiredFieldValidator ID="RequiredEmailDocBoy" runat="server" 
                        ControlToValidate="txtMailIDDocBoy" Display="Dynamic" 
                        ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="Validation" ToolTip="Please Enter Email ID"> 
                        </asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtMailIDDocBoy" Display="Dynamic" 
                        ErrorMessage="*" ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="Validation" ToolTip="Please Enter Valid Maid ID"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                    
                <td class="tdLabel" align="right">
                    <asp:Label ID="lblIsDelDocBoy" runat="server" Text="Is Deleted  ?"></asp:Label>
                </td>
                <td class="tdControl" align="left">
                <asp:RadioButton ID="rbYesIsDelDocBoy" runat="server" GroupName="IsDeleted" Text="Yes" />
                <asp:RadioButton ID="rbNoIsDelDocBoy" runat="server" GroupName="IsDeleted" Text="No" Checked="True" /><br />
                    <asp:CheckBox ID="ChkBxApprovDocBoy" runat="server" Text="Approve Document Boy" />
                       
                        
                         
                </td>
            </tr>
                 
            <tr>
                <td></td> 
                     
                <td class="tdControl">
                    <asp:Button ID="btnSaveDocBoy" runat="server" Text="Save" OnClick="btnSaveDocBoy_Click" ValidationGroup="Validation" />
                        &nbsp;<asp:Button ID="btnClearDocBoy" runat="server" Text="Clear" OnClick="btnClearDocBoy_Click" />
                    &nbsp;<asp:Button ID="btnCncl" runat="server" onclick="btnCncl_Click" Text="Cancel"/>
                </td>
            </tr>
        </table>
        </asp:Panel>

        <asp:Panel ID="PanelSearchByTypWrk" runat="server" GroupingText="Search By">
            <table class="table">
                <tr>
                    <td>
                        <asp:Label ID="lblCode1" runat="server" Text="Code:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblDocBoy" runat="server" Text="Document Boy:"></asp:Label>
                    </td>
                    <td>
                        <asp:Label ID="lblApprvTypWrk1" runat="server" Text="Approve:"></asp:Label>
                    </td>
                    <td >
 
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCode1" runat="server" ReadOnly="True"></asp:TextBox>
                    </td>
                    <td>
                     <asp:TextBox ID="TextBox2" runat="server" onkeyup="FilterItems(this.value)" EnableViewState="False"></asp:TextBox>
                     <asp:DropDownList ID="ddlDocBoy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlDocBoy_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlApprovDocBoy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlApprovDocBoy_SelectedIndexChanged">
                            <asp:ListItem Value="-1">--Select--</asp:ListItem>
                            <asp:ListItem Value="2">Both</asp:ListItem>
                            <asp:ListItem Value="1">Approved</asp:ListItem>
                            <asp:ListItem Value="0">UnApproved</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        
                    </td>
                </tr><tr><td></td><td></td><td><asp:CheckBox ID="ChkbxShowDeletedDocBoy" runat="server" AutoPostBack="True" Text="Show Deleted Doc Boy" OnCheckedChanged="ChkbxShowDeletedDocBoy_CheckedChanged" />
                </td></tr>
                 
            </table>
        </asp:Panel>
    </div>
    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <asp:Panel ID="PanelViewDocBoy" runat="server" GroupingText="View Document Boys"
                Height="342px" Width="916px">
                <asp:Panel ID="PanelGrid" runat="server" ScrollBars="Vertical" Width="100%" Height="250px">
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:GridView ID="GdVwViewDocumentBoy" runat="server" 
                        OnRowCommand="GdVwViewDocumentBoy_RowCommand" Width ="100%" 
                        >
                        <Columns>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemTemplate>
                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Editdocboy" CommandArgument='%Container.DataItemIndex%' />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </asp:Panel>
        <%--</ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>
