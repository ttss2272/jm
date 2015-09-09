<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="TypeOfWork.aspx.cs" Inherits="Juris.Admin.Type_of_work.TypeOfWork" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type = "text/javascript">
    var ddlText, ddlValue, ddl; //lblMesg
    function CacheItems() {
        ddlText = new Array();
        ddlValue = new Array();
        ddl = document.getElementById("<%=ddlTypWrk.ClientID %>");

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
<div align = "center" style =" width: 100%;">
   
           <h2> <asp:Label ID="lblAddEdittypeOfWork" runat="server" Text="Add/Edit Type Of Work"></asp:Label></h2>
       
        </div>
        <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
<asp:Panel ID="PanelAddEditTypWrk" runat="server" GroupingText="Add/Edit Type Of Work">
    <table>
     <tr>
         <td colspan="3" >
             <asp:Label ID="lblResult" runat="server" ForeColor="Green" Visible="False"></asp:Label>
             </td>
    </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblTypWrkId" runat="server" Visible="False"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tdLabel" align="right">
                <asp:Label ID="lblTypeOfWorkClient" runat="server" Text="Type Of Work :"></asp:Label>
            </td>
            <td class="tdControl">
              
                <asp:TextBox ID="txtTypeOfWork" runat="server"></asp:TextBox>
            </td>
            <td>
             
                <asp:RequiredFieldValidator ID="RFVTypWrk0" runat="server" 
                    ControlToValidate="txtTypeOfWork" Display="Dynamic" 
                    ErrorMessage="*" ValidationGroup="ValidTypWrk" 
                    ForeColor="Red" ToolTip="Please give Type Of Work."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tdControl" align="right">
                <asp:Label ID="lblIsDelTypWrk0" runat="server" Text="Is Deleted  ?"></asp:Label>
               </td>
            <td">
               </td>
            <td class="tdControl">
               <asp:RadioButton ID="rbYesIsDeltypWrk" runat="server" GroupName="IsDeleted" 
                    Text="Yes" />
             
                <asp:RadioButton ID="rbNoIsDeltypWrk" runat="server" GroupName="IsDeleted" checked="true" Text="No" />
             
            </td>
        </tr>
        <tr>
            <td >
                </td>
            <td class="" >
                <asp:CheckBox ID="ChkBxApprovTypOfWrk" runat="server" 
                    Text="Approve Type Of Work" /><br />
                </td>
            <td>
               
            </td>
        </tr>
        <tr>
            <td >
                </td>
            <td colspan="2">
          
                <asp:Button ID="btnSaveTypWrk0" runat="server" onclick="btnSaveTypWrk_Click" 
                    Text="Save" ValidationGroup="ValidTypWrk" />&nbsp;
                <asp:Button ID="btnClearTypWrk" runat="server" onclick="btnClearTypWrk_Click" 
                    Text="Clear" /> 
                &nbsp;<asp:Button ID="btnCancl0" runat="server" onclick="btnCancl_Click" 
                    Text="Cancel" />
                </td>
        </tr>
    </table>
    </asp:Panel>
    <asp:Panel ID="PanelSearchByTypWrk" runat="server" GroupingText="Search By">
     <table class="table"><tr>
            <td class="tdLabel">
                <asp:Label ID="lblTypWrkSearch" runat="server" 
                    Text="Type Of Work  :"></asp:Label>
            </td>
            <td class="tdLabel">
                &nbsp;</td>
            <td>
                <asp:Label ID="lblApprvTypWrk" runat="server" Text="Approve :"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
               <asp:TextBox ID="TextBox1" runat="server" 
                    onkeyup = "FilterItems(this.value)" EnableViewState="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypWrk" runat="server" AutoPostBack="True" 
                            onselectedindexchanged="ddlTypWrk_SelectedIndexChanged">
                        </asp:DropDownList>
            </td>
           <td>
               <asp:DropDownList ID="ddlApprvtypWrk" runat="server" AutoPostBack="True" onselectedindexchanged="ddlApprvtypWrk_SelectedIndexChanged"  
                   >
                  
                   <asp:ListItem Value="-1">--Select--</asp:ListItem>
                   <asp:ListItem Value="2">Both</asp:ListItem>
                   <asp:ListItem Value="1">Approve</asp:ListItem>
                   <asp:ListItem Value="0">UnApprove</asp:ListItem>
                  
               </asp:DropDownList>
               </td>
           
            <td>
                <asp:CheckBox ID="ChkbxShowDeletedTypWrk" runat="server" 
                    Text="Show Deleted Type Of Work" AutoPostBack="True" 
                    oncheckedchanged="ChkbxShowDeletedTypWrk_CheckedChanged" />
            </td>
        </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelViewTypWrkClient" runat="server" GroupingText="View Type Of Work(s)">
        <asp:Panel ID="Panelgridview" runat="server" Height="300px" ScrollBars="Auto" 
            Width="100%">
            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
        <asp:GridView ID="GdVwViewTypWrk" runat="server" Width="100%" 
                onrowcommand="GdVwViewTypWrk_RowCommand">
        <Columns>
             <asp:templatefield HeaderText="Edit">
                 <ItemTemplate>
                     <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName = "EditTypWrk" CommandArgument = '%Container.DataItemIndex%'  />
                 </ItemTemplate>
            </asp:templatefield>
        </Columns>
        </asp:GridView>
        </asp:Panel>
    </asp:Panel>
   </asp:Content>
