<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="ViewDocument.aspx.cs" Inherits="Juris.Admin.Documents.ViewDocument" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type = "text/javascript">
    var ddlText, ddlValue, ddl; //lblMesg
    function CacheItems() {
        ddlText = new Array();
        ddlValue = new Array();
        ddl = document.getElementById("<%=ddlDocumentDoc.ClientID %>");

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
        <h2>
            <asp:Label ID="lblAddEditDocHeading" runat="server" Text="Add/Edit Document" Font-Bold="True"></asp:Label>
        </h2>
    <asp:Panel ID="PanelAddEditDocPaper" runat="server" GroupingText="Add/Edit Documents or Paper">
    <table>
     <tr>
        <td class="tdLabel" align="right">
            &nbsp;</td>
        <td>
            <asp:Label ID="lblResult" runat="server" ForeColor="Green" Visible="False"></asp:Label>
            &nbsp;<asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
        </td>
    </tr>
        <tr>
            <td class="tdLabel" align="right">
                <asp:Label ID="lblDocPaper" runat="server" Text="Documents or Papers  :"></asp:Label>
            </td>
            <td class="tdControl">
                <asp:TextBox ID="txtDocPaper" runat="server"></asp:TextBox>
             </td>
             <td class="tdValidation">
                <asp:RequiredFieldValidator ID="RFVDocNm" runat="server" 
                    ControlToValidate="txtDocPaper" Display="Dynamic" 
                    ErrorMessage="*" ForeColor="Red" 
                    ValidationGroup="ValidDoc" Width="200px" ToolTip="Please give name of Document."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLabel" align="right">
                <asp:Label ID="lblIsDelDoc" runat="server" Text="Is Deleted  ?"></asp:Label><br /><br />
                <asp:Label ID="lblDocId" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
            <td >
               
               <asp:RadioButton ID="rbYesIsDelDoc" runat="server" GroupName="IsDeleted" 
                    Text="Yes" />
            
                <asp:RadioButton ID="rbNoIsDelDoc" runat="server" GroupName="IsDeleted" checked=true
                    Text="No" />
               <br />
                <asp:CheckBox ID="ChkBxApprovDoc" runat="server" Font-Bold="True" 
                    Text="Approve Documents" />
               
            </td>
            <td></td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                <asp:Button ID="btnSaveDocPaper" runat="server" Text="Save"  
                    onclick="btnSaveDocPaper_Click" ValidationGroup="ValidDoc" />
               <asp:Button ID="btnClearDocPaper" runat="server" Text="Clear" 
                     onclick="btnClearDocPaper_Click" />
              
                <asp:Button ID="btnCancl" runat="server" onclick="btnCancl_Click" 
                    Text="Cancel" />
            </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="PanelSearchByDocPaper" runat="server" GroupingText="Search By">
     <table class="table"><tr>
            <td class="tdLabel">
                <asp:Label ID="lblDocPaperNm" runat="server" Text="Documents / Papers Name"></asp:Label>
            </td>
            <td >
               </td>
            <td class="tdLabel">
                
                <asp:Label ID="Label1" runat="server" Text="Approve :"></asp:Label>
                
             </td>
             <td>
             </td>
        </tr>
        <tr>
            <td >
                <asp:TextBox ID="txtBound" runat="server" EnableViewState="False" 
                    onkeyup = "FilterItems(this.value)"></asp:TextBox>
            </td>
            <td >
                <asp:DropDownList ID="ddlDocumentDoc" runat="server" AutoPostBack="True" 
                     onselectedindexchanged="ddlDocumentDoc_SelectedIndexChanged">
                </asp:DropDownList>
                </td>
            <td class="tdControl" >
                <asp:DropDownList ID="ddlApprovDoc" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="ddlApprovDoc_SelectedIndexChanged">
                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                    <asp:ListItem Value="2">Both</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                    <asp:ListItem Value="0">UnApproved</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tdControl">
                <asp:CheckBox ID="ChkbxShowDeletedDocPaper1" runat="server" 
                    Text="Show Deleted Documents / Papers" 
                    oncheckedchanged="ChkbxShowDeletedDocPaper1_CheckedChanged" 
                    AutoPostBack="True" />
            </td>
        </tr>
        </table>
    </asp:Panel>
        </div>
    <asp:Panel ID="PanelViewDocPaper" runat="server" 
        GroupingText="View Document(s) or Paper(s)">
        <asp:Panel ID="PanelGrid" runat="server" Height="400px" ScrollBars="Vertical" 
            Width="100%">
            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GdVwDocPaper" runat="server" 
            CellSpacing="1" onrowcommand="GdVwDocPaper_RowCommand" Width ="100%">
            <Columns>
                  <asp:templatefield HeaderText="Edit">
                  <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName = "EditDocument" CommandArgument = '%Container.DataItemIndex%'  />
                    </ItemTemplate>
                  </asp:templatefield>
                  </Columns>
        </asp:GridView>
        </asp:Panel>

    </asp:Panel>

</asp:Content>
