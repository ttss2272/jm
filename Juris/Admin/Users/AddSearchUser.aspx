<%@ Page Title="" Language="C#" Theme="Skin1" MasterPageFile="~/admin.Master" AutoEventWireup="true"
    CodeBehind="AddSearchUser.aspx.cs" Inherits="Juris.Admin.User.AddSearchUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     
    <script type="text/javascript">
        function validate() {
            x = document.myForm
            input = x.txtPass.value
            if (input.length < 8) {
                alert("The field must contain more than 8 characters!")
                return false
            } else {
                return true
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div align="center" style=" width: 100%;">
<h2>
    <asp:Label ID="lblHeading" runat="server" Text="Add User"></asp:Label>
    </h2>
    </div>
<div style ="width :100%">
    <asp:Panel ID="PanelSubmitUsr" runat="server" GroupingText="Add/Edit User Details">
        <table class="table">
        <tr><td>
            <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
            </td><td>
        <asp:Label ID="lblMsg" runat="server" ForeColor="Green" ></asp:Label>
        </td>
         </tr>   <tr>
                <td class="tdLabel" align="right">
                    <asp:Label ID="Label1" runat="server" Text="UserName:"></asp:Label>
                </td>
                <td class="tdControl">
                  <asp:TextBox ID="txtUNm" runat="server"></asp:TextBox>
                </td>
                <td class="tdValidation">
                    <asp:RequiredFieldValidator ID="ReqfldvalUnm" runat="server" ControlToValidate="txtUNm"
                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="UserVal"
                        ForeColor="#FF3300" ToolTip="Enter User Name"></asp:RequiredFieldValidator>
               </td>
                <td>
 
                </td>
            </tr>
            <tr>
                <td class="tdLabel"align="right">
                   <asp:Label ID="Label2" runat="server" Text="PassWord:"></asp:Label></td>
                <td class="tdControl">
                    <asp:TextBox ID="txtPass" runat="server" TextMode="Password" ></asp:TextBox>
                </td>
                <td class="tdValidation">
                  <asp:RequiredFieldValidator ID="Reqfldvalapass" runat="server" ControlToValidate="txtPass"
                        Display="Dynamic" ErrorMessage="*" SetFocusOnError="True" ValidationGroup="UserVal"
                        ForeColor="#FF3300" ToolTip="Enter Password"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPass"
                        Display="Dynamic" ErrorMessage="*"
                                             ForeColor="#FF3300" ValidationExpression="^[\s\S]{8,15}$" ValidationGroup="UserVal" ToolTip="Mimimum 8 and maximum 15 characters are allowed"></asp:RegularExpressionValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="right" class="tdLabel">
                    <asp:Label ID="lblMailID" runat="server" Text="Email ID :"></asp:Label>
                </td>
                <td class="tdControl">
                    <asp:TextBox ID="txtUMailID" runat="server"></asp:TextBox>
                </td>
                <td class="tdValidation">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUMailID" ErrorMessage="*" ForeColor="Red" 
                        ValidationGroup="UserVal" ToolTip="Enter Mail ID"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtUMailID" ErrorMessage="*" 
                        ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="UserVal" ToolTip="Enter Valid Mail ID"></asp:RegularExpressionValidator>
                </td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="tdLabel"align="right">
                     <asp:Label ID="Label3" runat="server" Text="Type:"></asp:Label></td>
                <td class="tdControl">
                    <asp:DropDownList ID="drpDwnlstType" runat="server">
                        <asp:ListItem>admin</asp:ListItem>
                        <asp:ListItem>employee</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td> 
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td class="tdLabel">
                    
                </td>
                <td class="tdControl">
                     <asp:CheckBox ID="ChkbxIsDelUsr" runat="server" Text="Is Deleted ?" />
                 </td>
                 </tr>
                 <tr><td></td>
                <td colspan="2">
                    <asp:Button ID="btnSubmitUsr4" runat="server" OnClick="btnSubmitUsr_Click" Text="Submit" ValidationGroup="UserVal"/>
                    &nbsp;<asp:Button ID="btnCancl" runat="server" onclick="btnCancl_Click" Text="Cancel" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelSerchUsr" runat="server" GroupingText="Search User Details">
        <table>
            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Username :"></asp:Label>
                </td>
                <td align="left" >
                    <asp:Label ID="Label6" runat="server" Text="Type :"></asp:Label>
                     
                </td>
                
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="txtUNmSrch" runat="server" ></asp:TextBox>
                </td>
                <td align="left">
                    &nbsp;<asp:DropDownList ID="drpdwnlstTypSrch" runat="server" AutoPostBack="True"  
                        OnSelectedIndexChanged="drpdwnlstTypSrch_SelectedIndexChanged">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem>Both</asp:ListItem>
                        <asp:ListItem>admin</asp:ListItem>
                        <asp:ListItem>employee</asp:ListItem>
                    </asp:DropDownList>
                  
                     </td>
                     <tr>
                     <td></td>
                     <td>
                         <asp:CheckBox ID="chkbxSrchIsDel" runat="server" AutoPostBack="True" 
                             OnCheckedChanged="chkbxSrchIsDel_CheckedChanged" Text="Is Deleted ?" />
                         </td>
                     </tr>
 
            </tr>
        </table>
        <table>
            <tr>
                <td align ="left" >
                    <asp:Panel ID="Panel1" BorderColor="Black " BorderStyle="Solid" BorderWidth="1px"
                        Width="100%" Height="230px" ScrollBars="Vertical" runat="server">
                        <asp:GridView ID="grdvwSerchUser" runat="server" 
                            OnRowCommand="grdvwSerchUser_RowCommand" Width ="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" Text="Edit" CommandName="UpdateThis" CommandArgument='%Container.DataItemIndex' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
    </div>
</asp:Content>
