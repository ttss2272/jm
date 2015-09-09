<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" Theme="Skin1" AutoEventWireup="true"
    CodeBehind="ViewClient.aspx.cs" Inherits="Juris.Admin.Client.ViewClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            height: 30px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div align = "center" style ="width :100%">
        <h3>
            <asp:Label ID="lblViewClientHeading" runat="server" Text="View Client" Font-Bold="True"></asp:Label>
        </h3>
        </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="border-style: solid; border-width: thin; width: 100%;">
                  <tr>
                    <td class="style1">
                        <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                     
                </tr>
                  <tr>
                      <td class="style1">
                          <asp:Label ID="lblSearchByClientName" runat="server" 
                              Text="Search By Client Name :"></asp:Label>
                          &nbsp;
                          <asp:TextBox ID="txtSearchCl" runat="server"></asp:TextBox>
                          &nbsp;&nbsp;
                          <asp:DropDownList ID="drpdwnlstApp" runat="server" AutoPostBack="True" 
                              Height="28px" OnSelectedIndexChanged="drpdwnlstApp_SelectedIndexChanged" 
                              Width="133px">
                              <asp:ListItem Value="2">Both</asp:ListItem>
                              <asp:ListItem Value="1">Approve</asp:ListItem>
                              <asp:ListItem Value="0">Unapprove</asp:ListItem>
                          </asp:DropDownList>
                      </td>
                  </tr>
                  <tr><td>
                      <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                      </td></tr>
                <tr>
                    <td class="tdControl" align="left">
                        <asp:Panel ID="PanelClient" runat="server" GroupingText="View Clients" Height="441px"
                            Width="100%" BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" ScrollBars="Vertical">
                            <asp:GridView ID="GdVwViewClient" runat="server" Width="100%" OnRowCommand="GdVwViewClient_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:Button ID="btnselect" Text="Edit" runat="server" CommandName="Edit" CommandArgument='%Container.DataItemIndex%' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr><tr><td></td></tr>
                <tr>
                    <td align="right">
                        <asp:Button ID="btnAddNewClient" runat="server" Text="Add New Client" OnClick="btnAddNewClient_Click" /> 
                        &nbsp;<asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
