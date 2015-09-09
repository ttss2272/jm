<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="ViewClerk.aspx.cs" Inherits="Juris.Admin.Clerk.ViewClerk" EnableEventValidation="true"%>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 
  
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type = "text/javascript">
    var ddlText, ddlValue, ddl; //lblMesg
    function CacheItems() {
        ddlText = new Array();
        ddlValue = new Array();
        ddl = document.getElementById("<%=ddlClerk.ClientID %>");

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
<div align = "center" style ="width :100%">
        <h3>
            <asp:Label ID="lblViewClerkHeading" runat="server" Text="View Clerk" Font-Bold="True"></asp:Label>
        </h3>
     <asp:Panel ID="PanelViewClerk" runat="server" Width="937px">
        <table style="border-style: solid; border-width: thin;" class="table">
            <tr>
                <td class="style3">
                    <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td align="left" class="style2" colspan="3">
                    <asp:Label ID="lblSearchByClerkName" runat="server" Text="Search By Clerk Name :"></asp:Label>
                
                 
                    &nbsp;<asp:TextBox ID="TextBox1" runat="server" EnableViewState="False" 
                        onkeyup="FilterItems(this.value)"></asp:TextBox>
                    &nbsp;<asp:DropDownList ID="ddlClerk" runat="server" AutoPostBack="True" 
                        OnSelectedIndexChanged="ddlClerk_SelectedIndexChanged">
                    </asp:DropDownList>


                    <asp:Label ID="Label2" runat="server" Text="Approve :"></asp:Label>
                    <asp:DropDownList ID="ddlApprovVwClerk" runat="server" AutoPostBack="True" Height="23px"
                        OnSelectedIndexChanged="ddlApprovVwClerk_SelectedIndexChanged" Width="148px">
                        <asp:ListItem Value="-1">--Select--</asp:ListItem>
                        <asp:ListItem Value="2">Both</asp:ListItem>
                        <asp:ListItem Value="1">Approved</asp:ListItem>
                        <asp:ListItem Value="0">UnApproved</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td></td>
                <td></td>
            </tr><tr><td class="style3">
                <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                </td></tr>
            <tr>
                <td colspan="3" align="left">
                    <asp:Panel ID="PanelClerk" runat="server" GroupingText="View Search Clerk" Height="362px">
                        <asp:Panel ID="PanelGrid" runat="server" ScrollBars="Vertical" Height="300px" Width="100%">
                            <asp:GridView ID="GdVwViewClerk" runat="server" Width="100%" 
                                onrowcommand="GdVwViewClerk_RowCommand">
                            <Columns>
                            <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="EditClerks" CommandArgument='%Container.DataItemIndex%' UseSubmitBehavior="false"/>
                            </ItemTemplate>
                            </asp:TemplateField>
                            </Columns>
                            </asp:GridView>

                        </asp:Panel>
                    </asp:Panel>
                    
                </td>
            </tr>
            <tr>
                <td align="right" colspan="3">
                    <asp:Button ID="btnAddNewClerk" runat="server" OnClick="btnAddNewClerk_Click" 
                        Text="Add New Clerk" />
                    <asp:Button ID="btnCancl" runat="server" OnClick="btnCancl_Click" 
                        Text="Cancel" />
                </td>
                <td align="left">            
                   
                    &nbsp;</td>
                <td></td>
            </tr>
        </table>
    </asp:Panel>
 
    </div>
</asp:Content>
