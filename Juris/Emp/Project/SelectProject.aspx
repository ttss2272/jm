<%@ Page Title="" Language="C#" MasterPageFile="~/employee.Master" AutoEventWireup="true" Theme ="Skin1" 
    CodeBehind="SelectProject.aspx.cs" Inherits="Juris.Emp.Project.SelectProject" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 100%"  align="center" >
                <asp:Label ID="Label3" runat="server" Text="Select Projects" Font-Bold="True" Font-Size="Large"></asp:Label><br />
                <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                
            </div>
            <asp:Panel ID="PanelserchProject" runat="server" GroupingText="Search By">
                <table style="width: 100%;">
                    <tr>
                        
                        <td class="tdControl ">
                        <asp:Label ID="Label1" runat="server" Text="From Date : "></asp:Label>
                            <asp:TextBox ID="txtFromDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFromDate">
                            </asp:CalendarExtender>
                        </td>
                       
                        </td>
                        <td class="tdControl ">
                         <asp:Label ID="Label2" runat="server" Text="To Date : "></asp:Label>
                            <asp:TextBox ID="txtToDate" runat="server"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtToDate">
                            </asp:CalendarExtender>
                        </td>
                        <td >
                            <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
                            <asp:CheckBox ID="chkSelAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelAll_CheckedChanged"
                                Text="Select All" />
                            &nbsp;<asp:Button ID="btnSelectRecords" runat="server" Text="Select Records" Width="111px"
                                OnClick="btnSelectRecords_Click" />
                            &nbsp;<asp:Button ID="btnCncl" runat="server" OnClick="btnCancelClick" Text="Cancel" />
                            &nbsp;
                        </td>
                    </tr>
                  
                </table>
            </asp:Panel>
            <asp:Panel ID="PanelSearch" runat="server" ScrollBars="Vertical" Width="100%" Height="300px">
            <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                <asp:GridView ID="GdVwSelPrjct" runat="server" 
                    OnRowCommand="RowCommand" 
                    Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemTemplate>
                                <asp:Button ID="btnselect" Text="Edit" runat="server" CommandName="Edit" CommandArgument='%Container.DataItemIndex%' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
