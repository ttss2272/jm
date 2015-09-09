<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true"
    CodeBehind="AddEditDocBoyHistory.aspx.cs" Inherits="Juris.Admin.Project.AddEditDocBoyHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
        <table class="table">
        <tr><td>
            
            </td>
            </tr>
            <tr>
                <td>
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                        <asp:Label ID="lblresult" runat="server" Visible="False" ForeColor ="Green" ></asp:Label>
                            &nbsp;<asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                            <br />
                            <asp:Label ID="lblresult1" runat="server" ForeColor="Green" Visible="False"></asp:Label>
                            &nbsp;<asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Panel ID="PanelAddDocBoyHostory" runat="server" GroupingText="Add/Edit Document Boy's History"
                                Width="479px">
                                <table>
                                <tr>
                                <td >
                                       <asp:Label ID="lblPrjId" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="lblId" runat="server" Visible="False"></asp:Label>
                                            <asp:Label ID="lblCode" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td></td>
                                </tr>
                                    <tr>
                                   
                                        <td  class="tdLabel" align="right">
                                     
                                            <asp:Label ID="Label1" runat="server" Text="Date :"></asp:Label>
                                            <br />
                                           
                                        </td>
                                         <td class="tdControl">
                                             <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                             <asp:CalendarExtender ID="txtDate0_CalendarExtender" runat="server" 
                                                 TargetControlID="txtDate">
                                             </asp:CalendarExtender>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" align="right">
                                            <asp:Label ID="Label2" runat="server" Text="Select Document Boy :"></asp:Label>
                                            
                                        </td>
                                        <td class="tdControl">
                                            <asp:DropDownList ID="ddlSelDocBoy" runat="server" AutoPostBack="True" 
                                                OnSelectedIndexChanged="ddlSelDocBoy_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldDdl" runat="server" 
                                                ControlToValidate="ddlSelDocBoy" ErrorMessage="*" InitialValue="-1" ForeColor="Red"
                                                ToolTip="Please Select Document Boy" ValidationGroup="SaveDocBoy"></asp:RequiredFieldValidator>
                                    </tr>
                                    <tr>
                                        <td colspan="2" >
                                            <br />
                                            <asp:UpdatePanel ID="UpdatePanel2"  runat="server">
                                                <ContentTemplate>
                                                    <asp:Panel ID="PanelGrid" runat="server" GroupingText="Select Pending Documents "
                                                        Height="250px" Width="350" ScrollBars="Vertical">
                                                        <asp:GridView ID="GVSelPendingDoc" Width="300px" runat="server">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Select">
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="ChkBxSelDoc" runat="server" AutoPostBack="true" /></ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </asp:Panel>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td class="tdLabel" align="right">
                                            <asp:Label ID="Label3" runat="server" Text="Remarks :"></asp:Label>
                                            <br />
                                        </td>
                                        <td class="tdControl">
                                        
                                            <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="tdControl">
                                            
                                        </td>
                                        <td>
                                        <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="SaveDocBoy" OnClick="btnSave_Click" />
                                            <asp:Button ID="btnClear" runat="server" Text="Clear"  
                                                onclick="btnClear_Click" />
                                            <asp:Button ID="btnCncl" runat="server" onclick="btnCncl_Click" Text="Cancel" />
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td  valign="top">
                    <asp:Panel ID="PanelViewDocBoyHistory" runat="server" GroupingText="View Document Boy's History"
                        Height="258px" Width="320px">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="PanelGVViewDocBoy" runat="server" ScrollBars="Vertical">
                                    <asp:GridView ID="GVViewDocBoy" runat="server" 
                                    Height="171px" Width="279px" 
                                        onrowcommand="GVViewDocBoy_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemTemplate>
                                                    <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditDocBoyHistory" CommandArgument='%Container.DataItemIndex' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>
