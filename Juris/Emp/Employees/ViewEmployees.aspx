<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" Theme="Skin1" AutoEventWireup="true" CodeBehind="ViewEmployees.aspx.cs" Inherits="Juris.Emp.Employees.ViewEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type = "text/javascript">
     var ddlText, ddlValue, ddl; //lblMesg
     function CacheItems() {
         ddlText = new Array();
         ddlValue = new Array();
         ddl = document.getElementById("<%=ddlEmpNameVwEmp.ClientID %>");

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
        // lblMesg.innerHTML = ddl.options.length + " items found.";
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
<div align = "center" style ="width:100%">
        <h3>
            <asp:Label ID="lblViewEmpHeading" runat="server" Text="View Employee" Font-Bold="True"></asp:Label>
        </h3>
    <asp:Panel ID="PanelViewEmployee" runat="server">
    <table class="table">
    <tr><td>
             <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
   </td></tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="Label1" runat="server" Text="Search By :"></asp:Label>
            </td>
            <td >
            </td>
            <td >
                </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Label ID="lblEmployeeCode" runat="server" 
                    Text="Employee Code :"></asp:Label>
            </td>
            <td class="tdLabel">
                <asp:Label ID="lblEmployeeName0" runat="server" Text="Employee Name :"></asp:Label>
            </td>
            <td>
            </td>
            <td class="tdLabel">
                <asp:Label ID="Label2" runat="server" Text="Approve : "></asp:Label>
            </td>
            
        </tr>
        <tr>
            <td class="tdControl">
                <asp:TextBox ID="txtEmpCodeVwEmp" runat="server" AutoPostBack="True" 
                     ReadOnly="True" ></asp:TextBox>
            </td>
            <td class="tdControl">
                <asp:TextBox ID="txtBind" runat="server"  
                    onkeyup = "FilterItems(this.value)" EnableViewState="False"></asp:TextBox>
                </td>
            <td class="tdControl">
                <asp:DropDownList ID="ddlEmpNameVwEmp" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlEmpNameVwEmp_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td class="tdControl">
                <asp:DropDownList ID="ddlApproveEmp" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="ddlApproveEmp_SelectedIndexChanged" >
                    <asp:ListItem Value="-1">--Select--</asp:ListItem>
                    <asp:ListItem Value="2">Both</asp:ListItem>
                    <asp:ListItem Value="1">Approved</asp:ListItem>
                    <asp:ListItem Value="0">UnApproved</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
              </td>
            <td >
                </td>
            <td >
                &nbsp;</td>
            <td align="right">
            <br />
            </td>
            <td>
                </td>
             </tr>
            <tr>
                <td colspan="5" align="right">
                    <asp:CheckBox ID="ChkbxShowDeletedEmp" runat="server" AutoPostBack="True" 
                        oncheckedchanged="ChkbxShowDeletedEmp_CheckedChanged" 
                        Text="Show Deleted Employees" />
                </td>
                <td>
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
                <td align="right">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
        </tr>
            </table>

        <table>
        <tr>
            <td>
                <asp:Panel ID="PanelEmployee" runat="server" Font-Bold="False" 
                    GroupingText="View All Employees" Height="400px" Width="869px">
                    <asp:Panel ID="Panel1" runat="server" Height="220px" ScrollBars="Vertical" 
                        Width="100%">
                        <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:GridView ID="GdVwViewEmp" runat="server" Width="100%" AllowPaging="False" 
                            onrowcommand="GdVwViewEmp_RowCommand">
                <Columns>
                  <asp:templatefield HeaderText="Edit">
                  <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName = "EditEmp" CommandArgument = '%Container.DataItemIndex%'  />
                  </ItemTemplate>
                  </asp:templatefield>
                </Columns>
                </asp:GridView>
                </asp:Panel>
                </asp:Panel>
            </td>
        </tr>
        
        <tr>
            <td align="right" >
                 <asp:Button ID="btnCreateNewEmp0" runat="server" 
                     onclick="btnCreateNewEmp_Click" Text="Create New Employee" />
                 <asp:Button ID="btnCancl" runat="server" onclick="btnCancl_Click" 
                     Text="Cancel" />
                 </td>
            <td >
            </td>
        </tr>
        </table>
    </asp:Panel>
    </div> 
</asp:Content>
