<%@ Page Title="" Language="C#" Theme="Skin1" MasterPageFile="~/employee.Master" AutoEventWireup="true" CodeBehind="ViewService.aspx.cs" Inherits="Juris.Emp.Services.ViewService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<script type = "text/javascript">
    var ddlText, ddlValue, ddl; //lblMesg
    function CacheItems() {
        ddlText = new Array();
        ddlValue = new Array();
        ddl = document.getElementById("<%=ddlSearchByServiceNameSer.ClientID %>");

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
            <asp:Label ID="lblViewserviceHeading" runat="server" Text="View Services" Font-Bold="True"></asp:Label>
        </h3>
</div>
    <asp:Panel ID="PanelViewService" runat="server">
    <table style="border-style: solid; border-width: thin; width: 100%;">
        <tr>
            <td>
                <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td >
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblSearchByServiceName" runat="server" 
                    Text="Search By Service Name :"></asp:Label>
            </td>
            <td >
                &nbsp;
                <asp:TextBox ID="TextBox1" runat="server" onkeyup ="FilterItems(this.value)"></asp:TextBox>
                &nbsp;<asp:DropDownList ID="ddlSearchByServiceNameSer" runat="server" AutoPostBack="True"  onselectedindexchanged="ddlSearchByServiceNameSer_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td><asp:Label ID="Label1" runat="server" Text="Approve :"></asp:Label>
                &nbsp;<asp:DropDownList ID="ddlApproveSer" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlApproveSer_SelectedIndexChanged">
                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                    <asp:ListItem Value="2">Both</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                    <asp:ListItem Value="0">UnApproved</asp:ListItem>
                </asp:DropDownList>
&nbsp;
            </td>
        </tr>
        <tr>
            <td   colspan="3" align="left">
                <asp:Panel ID="PanelService" runat="server" GroupingText="View Services" Height="490px">
                <asp:Panel ID="PanelGrid" runat="server" Height="400px" ScrollBars="Vertical" Width="100%">
                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:GridView ID="GdVwViewService" runat="server" Width="100%" onrowcommand="GdVwViewService_RowCommand">
                <Columns>
                  <asp:templatefield HeaderText="Edit">
                  <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName = "Edit" CommandArgument = '%Container.DataItemIndex%'  />
                    </ItemTemplate>
                  </asp:templatefield>
                  </Columns>
                </asp:GridView>
                </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        <tr><td align="right" colspan="3">
                <asp:Button ID="btnAddNewService" runat="server" Text="Add New Service" onclick="btnAddNewService_Click" />
                &nbsp;<asp:Button ID="btnCncl" runat="server" onclick="btnCncl_Click" Text="Cancel"/>
            </td>
        </tr>
        </table>
    </asp:Panel>
</asp:Content>
