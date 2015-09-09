<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" Theme="Skin1" AutoEventWireup="true"
    CodeBehind="ViewProjects.aspx.cs" Inherits="Juris.Emp.Project.ViewProjects" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
     <style type="text/css">
        .style1
        {
            width: 21%;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript">
        var ddlText, ddlValue, ddl, ddlText1, ddlValue1, ddl1; //lblMesg
        
        function CacheItems() {
            ddlText = new Array();
            ddlValue = new Array();
            ddl = document.getElementById("<%=ddlCliNmPrj.ClientID %>");

            for (var i = 0; i < ddl.options.length; i++) {
                ddlText[ddlText.length] = ddl.options[i].text;
                ddlValue[ddlValue.length] = ddl.options[i].value;
            }

            ddlText1 = new Array();
            ddlValue1 = new Array();
            ddl1 = document.getElementById("<%=ddlCasNmPrj.ClientID %>");

            for (var i = 0; i < ddl1.options.length; i++) {
                ddlText1[ddlText1.length] = ddl1.options[i].text;
                ddlValue1[ddlValue1.length] = ddl1.options[i].value;
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

//        function CacheCase() {
//            ddlText1 = new Array();
//            ddlValue1 = new Array();
//            ddl1 = document.getElementById("<%=ddlCasNmPrj.ClientID %>");

//            for (var i = 0; i < ddl1.options.length; i++) {
//                ddlText1[ddlText1.length] = ddl1.options[i].text;
//                ddlValue1[ddlValue1.length] = ddl1.options[i].value;
//            }
//        }
//        window.onload = CacheCase;

        function FilterCase(value) {
            ddl1.options.length = 0;
            for (var i = 0; i < ddlText1.length; i++) {
                if (ddlText1[i].toLowerCase().indexOf(value) != -1) {
                    AddCase(ddlText1[i], ddlValue1[i]);
                }
            }
            lblMesg.innerHTML = ddl1.options.length + " items found.";
            if (ddl1.options.length == 0) {
                AddCase("No items found.", "");
            }
        }

        function AddCase(text, value) {            
            var opt1 = document.createElement("option");
            opt1.text = text;
            opt1.value = value;
            ddl1.options.add(opt1);
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:Label ID="lblViewProjectDelete" runat="server" ForeColor="Red"></asp:Label>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div align="center">
                <h2>
                    <asp:Label ID="Label1" runat="server" Text="View Projects" Font-Size="Large"></asp:Label></h2>
            </div>
            <table class="table">
                <tr>
                    <td>
                        <asp:Panel ID="PanelSearchByViewProjects" runat="server" GroupingText="Search By">
                            <table>
                                <tr>
                                    <td colspan="2" align="left">
                                        <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <asp:Label ID="lblCliNm" runat="server" Text="Client Name :"></asp:Label>
                                    </td>
                                    <td class="tdLabel">
                                        <asp:Label ID="lblCaseNm" runat="server" Text="Case Name :"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        <asp:Label ID="lblStatus" runat="server" Text="Status :"></asp:Label>
                                    </td>
                                    <td class="tdLabel">
                                        <asp:Label ID="lblStatus0" runat="server" Text="Approve  :"></asp:Label>
                                    </td>
                                    <tr>
                                        <td class="tdControl">
                                            <asp:TextBox ID="TextBox1" runat="server" onkeyup="FilterItems(this.value)" EnableViewState="False"></asp:TextBox>
                                        </td>
                                        <td class="tdControl">
                                            <%--  <asp:PlaceHolder ID="LocalPlaceHolder" runat="server"></asp:PlaceHolder>--%>
                                            <asp:TextBox ID="txtCaseName" runat="server" EnableViewState="False" onkeyup="FilterCase(this.value)"></asp:TextBox>
                                        </td>
                                        <td class="style1">
                                            <asp:DropDownList ID="ddlStatus" runat="server" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem>All</asp:ListItem>
                                                <asp:ListItem>InProcess</asp:ListItem>
                                                <asp:ListItem>Completed</asp:ListItem>
                                                <asp:ListItem>On Hold</asp:ListItem>
                                                <asp:ListItem>Cancelled</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td class="tdControl">
                                            <asp:DropDownList ID="ddlApprove" runat="server" OnSelectedIndexChanged="ddlApprove_SelectedIndexChanged"
                                                AutoPostBack="True">
                                                <asp:ListItem>--Select--</asp:ListItem>
                                                <asp:ListItem Value="2">Both</asp:ListItem>
                                                <asp:ListItem Value="1">Approved</asp:ListItem>
                                                <asp:ListItem Value="0">UnApproved</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <tr>
                                            <td class="tdControl">
                                                <br />
                                                <asp:DropDownList ID="ddlCliNmPrj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCliNmPrj_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlCasNmPrj" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCasNmPrj_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td class="style1">
                                                &nbsp;
                                            </td>
                                            <td class="tdControl">
                                                <br />
                                                <asp:CheckBox ID="chkBxShwDelProjects" runat="server" AutoPostBack="True" OnCheckedChanged="chkBxShwDelProjects_CheckedChanged"
                                                    Text="Show Deleted Projects" />
                                            </td>
                                        </tr>
                                    </tr>
                                </tr>
                            </table>
                        </asp:Panel>                        
                        <asp:Panel ID="PanelViewProjects" runat="server" GroupingText="View Projects" Width="934px"
                            Height="566px">                            
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>&nbsp;
                            <asp:Label ID="lblUPDelete" runat="server" ForeColor="Red"></asp:Label>&nbsp;
                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                            <asp:Panel ID="PanelGrid" runat="server" Width="900px" Height="500px" ScrollBars="Both">
                               <asp:GridView ID="GdVwSrchProjects" runat="server"  
                                    OnRowCommand="GdVwSrchProjects_RowCommand" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Select">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkBxSelProject" runat="server" AutoPostBack="true" OnCheckedChanged="ChkBxSelProject_CheckedChanged" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemTemplate>
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" CommandName="Edit" CommandArgument='%Container.TabIndex%' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemTemplate>
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CommandName="Delete" CommandArgument='%Container.TabIndex%' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Project ID" Visible="false">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblProjectID" runat="server" Text='<%#Eval("ProjectId")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Date">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblProjectDate" runat="server" Text='<%#Eval("ProjectDate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("ClientName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Case Name">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblCaseName" runat="server" Text='<%#Eval("CaseName")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Type Of Work">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblTypeOfWork" runat="server" Text='<%#Eval("TypeOfWork")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                 <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                            <asp:DropDownList ID="ddlTotalPages" runat="server" AutoPostBack="True" Width="100px"
                                onselectedindexchanged="Page_Changed">
                            </asp:DropDownList>
                        </asp:Panel>
                        <table align="right">
                            <%--<tr>
                                <td>
                                </td>
                                <td align="right">
                                    &nbsp;
                                </td>
                            </tr>--%>
                            <tr>
                                <td>
                                    <asp:Button ID="btnDeleteSelectedProject" runat="server" Text="Delete Project(s)"
                                        OnClick="btnDeleteSelectedProject_Click" />&nbsp;
                                    <asp:Button ID="btnDocBoysHistory" runat="server" Text="Document Boy's History" OnClick="btnDocBoysHistory_Click" />
                                </td>
                                <td align="right">
                                    <asp:Button ID="btnAddNwProject" runat="server" Text="Add New Project(s)" OnClick="btnAddNwProject_Click" />&nbsp;
                                    <asp:Button ID="btnCancl" runat="server" OnClick="btnCancl_Click" Text="Cancel" />
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
      
</asp:Content>
