<%@ Page Title="" Language="C#" Theme="Skin1" MasterPageFile="~/employee.Master" AutoEventWireup="true"
    CodeBehind="AddEditWork.aspx.cs" Inherits="Juris.Emp.Project.AddEditWork" %>
    <asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
                <asp:Label ID="lbltesting" runat="server" ForeColor="Red">
                </asp:Label>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:Label ID="lblCatchError" runat="server" ForeColor="Red"> </asp:Label>
        <%--</table>--%>
            <asp:Label ID="lblDelMsg" runat="server" ForeColor="Red"></asp:Label>
        <%--<asp:UpdatePanel ID="UpdatePanel2" width="100%" runat="server">
                                                            <ContentTemplate>--%>
                <asp:Label ID="lblMessageFile" runat="server" > </asp:Label>
        <%--          </asp:CalendarExtender>--%>
    </div>
    <table style="width: 100%;">
        <tr>
            <td class="tdControl">
                <table width="100%">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td align="center">
                                        <h2>
                                            <asp:Label ID="Label9" runat="server" Text="Add Project" Visible="true"></asp:Label></h2>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Timer ID="Timer1" runat="server" OnTick="Timer1_Tick" Interval="20000" 
                                            Enabled="False">
                                        </asp:Timer>
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
                                            </Triggers>
                                            <ContentTemplate>
                                                <table class="table">
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblResult" runat="server" ForeColor="Green" Visible="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblFileuploadValue" runat="server" Text="0" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="left" class="tdLabel">
                                                            <%--<asp:Label ID="lblDelMsg" runat="server"></asp:Label>--%>
                                                            <asp:Label ID="lblCliId1" runat="server" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblTypWrkID" runat="server" Visible="False"></asp:Label>
                                                            <asp:Label ID="lblMaxPrjId" runat="server" Visible="False"></asp:Label>
                                                        </td>
                                                        <td align="right" class="tdLabel">
                                                        </td>
                                                        <td class="tdControl">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="lblDate" runat="server" Text="Date :   "></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
                                                            <asp:CalendarExtender ID="CEDate" runat="server" TargetControlID="txtDate" ClearTime="True" DaysModeTitleFormat="dd/MM/yyyy"
                                                                Format="dd/MM/yyyy"  TodaysDateFormat="dd/MM/yyyy">
                                                            </asp:CalendarExtender>
                                                            <asp:Label ID="lblProjectId" runat="server" Visible="False"></asp:Label>
                                                            <%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc" %> --%>
                                                        </td>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="lblLoanNo" runat="server" Text="Loan No."></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:TextBox ID="txtLoanAcNoAddWrk" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="REVMobClrk2" runat="server" ControlToValidate="txtLoanAcNoAddWrk"
                                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Enter Only Numbers."
                                                                ValidationExpression="[0-9]{1,10}" ValidationGroup="SaveProject"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="lblClientNmAddWork" runat="server" Text="Client Name :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:DropDownList ID="ddlCliNm" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCliNm_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCliNm"
                                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" InitialValue="-1" SetFocusOnError="True"
                                                                ValidationGroup="SaveProject" ToolTip="Please Select Client"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="Label12" runat="server" Text="Branch :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:TextBox ID="txtBranchAddWrk" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:RegularExpressionValidator ID="REVName2" runat="server" ControlToValidate="txtBranchAddWrk"
                                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Please Enter Character Only."
                                                                ValidationExpression="^[a-zA-Z'/\|! $(),@&amp;#.\s]{3,50}$" ValidationGroup="SaveProject"></asp:RegularExpressionValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="lblTypWrkAddWrk" runat="server" Text="Type Of Work :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:DropDownList ID="ddlTypWrk" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTypWrk_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlTypWrk"
                                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" InitialValue="-1" SetFocusOnError="True"
                                                                ValidationGroup="SaveProject" ToolTip="Please Select Type Of Work"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="tdLabel" align="right" >
                                                            <%--<asp:Label ID="Label13" runat="server" Text="Loan Amount :"></asp:Label>--%>
                                                        </td>
                                                        <td class="tdControl">
                                                            <%--<asp:TextBox ID="txtLoanAmtAddWrk" runat="server">0</asp:TextBox>--%>
                                                        </td>
                                                        <td>
                                                            <%--<asp:RegularExpressionValidator ID="REVMobClrk4" runat="server" ControlToValidate="txtLoanAmtAddWrk"
                                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Enter Only Numbers."
                                                                ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveProject"></asp:RegularExpressionValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="lblCsNmAddWrk" runat="server" Text="Case Name :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:TextBox ID="txtCasNm" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Display="Dynamic"
                                                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SaveProject"
                                                                ControlToValidate="txtCasNm" ToolTip="Please Enter Case Name"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="tdControl" align="right">
                                                            <asp:Label ID="Label14" runat="server" Text="Enter property details, if any"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:TextBox ID="txtPropertyDetails" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="lblRefNo" runat="server" Text="Ref No :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:TextBox ID="txtRefNo" runat="server"></asp:TextBox>
                                                        </td>
                                                        <td class="tdLabel" align="right">
                                                            <%--<asp:Label ID="lblEmail" runat="server" Text="Email ID :"></asp:Label>--%>
                                                        </td>
                                                        <td class="tdControl">
                                                            <%--<asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>--%>
                                                        </td>
                                                        <td class="tdValidation">
                                                            <%--<asp:RegularExpressionValidator ID="RegExpValEmil0" runat="server" ControlToValidate="txtEmail"
                                                                ErrorMessage="*" ForeColor="Red" ToolTip="Enter Valid Email Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                ValidationGroup="SaveProject"></asp:RegularExpressionValidator>
                                                            &nbsp;--%>
                                                        </td>
                                                    </tr>
                                                    <%--<tr>
                                                        <td align="right">
                                                            &nbsp;
                                                        </td>
                                                        <td class="tdControl">
                                                            &nbsp;
                                                        </td>
                                                        <td align="right" class="tdLabel">
                                                            <asp:Label ID="Label15" runat="server" Text="Document :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <-<asp:TextBox ID="txtFileName" runat="server" Visible="False"></asp:TextBox>->
                                                            <asp:DropDownList ID="dpdwnlstFileNames" runat="server" Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>--%>
                                                </table>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                       <%-- <table class="table">
                                            <tr>
                                                <td>                                                    
                                                </td>
                                                <td>
                                                </td>
                                                <td class="tdControl" align="right">
                                                    &nbsp;
                                                    </td>
                                                <td class="tdControl">
                                                    <asp:FileUpload ID="FileUpload1" Multiple="true" runat="server" />
                                                    <br />
                                                </td>
                                            </tr>
                                        </table>
                                        <table class="table">
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                </td>
                                                <td align="right">
                                                    <asp:CheckBox ID="cbpdf" runat="server" Text="Save as PDF" 
                                                        oncheckedchanged="cbpdf_CheckedChanged" />
                                                    <asp:Button ID="btnSaveWordFile" runat="server" Text="Save File" Enabled="False"
                                                        OnClick="btnSaveWordFile_Click" />
                                                    <asp:Button ID="UploadButton" runat="server" OnClick="UploadButton_Click" Text="Attach" />
                                                    <asp:Button ID="btnOpenAddWrk" runat="server" Enabled="False" OnClick="btnOpenAddWrk_Click"
                                                        Text="Open" />
                                                    <asp:Button ID="btnEmailAddWrk" runat="server" Enabled="False" OnClick="btnEmailAddWrk_Click"
                                                        Text="Email" style="height: 26px" />
                                                    <asp:Button ID="btnDelAddWrk" runat="server" Enabled="False" OnClick="btnDelAddWrk_Click"
                                                        Text="Delete" /><br />
                                                </td>
                                            </tr>
                                        </table>--%>
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td align="center" class="tdControl">
                                        <asp:CheckBox ID="chkBxDsReqExtWrk" runat="server" Text="Does It Require External Work ?" />
                                        <asp:CheckBox ID="chkBxDsReqSrch" runat="server" Text="Does It Require Search ?" />
                                        <asp:CheckBox ID="chkBxAplySerTx" runat="server" Text="Apply Service Tax" />
                                    </td>
                                </tr>
                            </table>
                            <center>
                                <div>
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <table class="table">
                                                <tr>
                                                    <td class="tdControl" align="center">
                                                        <asp:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" 
                                                            Width="682px">
                                                            <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                                                                <HeaderTemplate>
                                                                    Name Of Papers</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <table class="table">
                                                                        <tr>
                                                                            <td>
                                                                                Select all necessary documents required for this work from below list.
                                                                                <br />
                                                                                <asp:Label ID="lblnameofpapermessage" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:Panel ID="PanelPapers" runat="server" ScrollBars="Vertical" Height="217px">
                                                                                    <asp:GridView ID="GVPapers" runat="server" Width="650px" 
                                                                                        OnSelectedIndexChanged="GVPapers_SelectedIndexChanged" 
                                                                                        AutoGenerateColumns="False">
                                                                                        <AlternatingRowStyle Height="20px" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Select">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="ChkBxSelDoc" runat="server" AutoPostBack="true" /></ItemTemplate>                                                                                            
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Document ID" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDocumentId" runat="server" Text='<%#Eval("DocumentID")%>'></asp:Label>
                                                                                                </ItemTemplate>                                                                                            
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Document">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDocumentName" runat="server" Text='<%#Eval("Document")%>'></asp:Label>
                                                                                                </ItemTemplate>                                                                                            
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle Height="20px" />
                                                                                    </asp:GridView>
                                                                                </asp:Panel>
                                                                                <asp:GridView ID="GridView1" runat="server">
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:TabPanel>
                                                            <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel1">
                                                                <HeaderTemplate>
                                                                    Services</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="lblServices" runat="server" ForeColor="Red"></asp:Label>
                                                                                <br />
                                                                                Select Services required for this work from below list.
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Panel ID="PanelServices" runat="server" ScrollBars="Vertical" Height="227px">
                                                                                    <asp:GridView ID="GVServices" runat="server" Width="650px" 
                                                                                        AutoGenerateColumns="False">
                                                                                        <AlternatingRowStyle Height="20px" />
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Select">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="ChkBxSelService" runat="server" AutoPostBack="true" OnCheckedChanged="ChkBxSelService_CheckedChanged" /></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Service ID" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblServiceID" runat="server" Text='<%#Eval("ServiceID")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Service Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblServiceName" runat="server" Text='<%#Eval("ServiceName")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>

                                                                                            <asp:TemplateField HeaderText="Service Price" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblServicePrice" Visible="false" runat="server" Text='<%#Eval("Price")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle Height="20px" />
                                                                                    </asp:GridView>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:TabPanel>
                                                            <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel1">
                                                                <HeaderTemplate>
                                                                    Employees</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <table style="width: 660px">
                                                                        <tr>
                                                                            <td>
                                                                                Select the Employees who will perform this work from below list.&nbsp;
                                                                                <br />
                                                                                <asp:Label ID="lblemployeemessage" runat="server" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label16" runat="server" Text="Search Start Date :"></asp:Label>&nbsp;<asp:TextBox
                                                                                    ID="txtStrDtEmp" runat="server" Width="10%"></asp:TextBox><asp:CalendarExtender ID="CalendarExtender9"
                                                                                        runat="server" TargetControlID="txtStrDtEmp" Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Label ID="Label17" runat="server" Text="Search Finished Date :"></asp:Label>&nbsp;<asp:TextBox
                                                                                    ID="txtEndDtEmp" runat="server" Width="100px"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="CalendarExtender10" runat="server" TargetControlID="txtEndDtEmp" Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Panel ID="PanelEmp" runat="server" ScrollBars="Vertical" Height="217px">
                                                                                    <asp:GridView ID="GVEmployees" runat="server" Width="650px" 
                                                                                        AutoGenerateColumns="False">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Select">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="ChkBxSelEmp" runat="server" AutoPostBack="true" /></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Employee ID" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblEmployeeID" runat="server" Text='<%#Eval("EmployeeID")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Employee Code">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblEmployeeCode" runat="server" Text='<%#Eval("EmployeeCode")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Employee Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblEmployeeName" runat="server" Text='<%#Eval("EmployeeName")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle Height="20px" />
                                                                                        <AlternatingRowStyle Height="20px" />
                                                                                    </asp:GridView>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:TabPanel>
                                                            <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="TabPanel1">
                                                                <HeaderTemplate>
                                                                    Search Clerk</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <table style="width: 660px">
                                                                        <tr>
                                                                            <td>
                                                                                Select the Search Clerk from below list.
                                                                                <br />
                                                                                <asp:Label runat="server" ID="lblsearchclarkmessage" Visible="False" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Label ID="Label18" runat="server" Text="Search Start Date :"></asp:Label><asp:TextBox
                                                                                    ID="txtStrStarDtClerk" runat="server" Width="100px"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="CalendarExtender11" runat="server" TargetControlID="txtStrStarDtClerk" Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Label ID="Label19" runat="server" Text="Search Finished Date :"></asp:Label>&nbsp;<asp:TextBox
                                                                                    ID="txtStrEndDtClerk" runat="server" Width="100px"></asp:TextBox><asp:CalendarExtender
                                                                                        ID="CalendarExtender12" runat="server" TargetControlID="txtStrEndDtClerk" Enabled="True">
                                                                                    </asp:CalendarExtender>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Panel ID="PanelClerk" runat="server" ScrollBars="Vertical" Height="217px">
                                                                                    <asp:GridView ID="GVClerk" runat="server" Width="650px" 
                                                                                        AutoGenerateColumns="False">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Select">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="ChkBxSelClerk" runat="server" AutoPostBack="true" /></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Clerk ID" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblClerkID" runat="server" Text='<%#Eval("ClerkID")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Clerk Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblClerkName" runat="server" Text='<%#Eval("ClerkName")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle Height="20px" />
                                                                                        <AlternatingRowStyle Height="20px" />
                                                                                    </asp:GridView>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:TabPanel>
                                                            <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="TabPanel1">
                                                                <HeaderTemplate>
                                                                    Document Boy</HeaderTemplate>
                                                                <ContentTemplate>
                                                                    <table>
                                                                        <tr>
                                                                            <td>
                                                                                Select the Document Boy from below list.
                                                                                <br />
                                                                                <asp:Label ID="lbldocboymessage" runat="server" Visible="False" ForeColor="Red"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <asp:Panel ID="PanelDocBoy" runat="server" ScrollBars="Vertical" Height="217px">
                                                                                    <asp:GridView ID="GVDocBoy" runat="server" Width="650px" 
                                                                                        AutoGenerateColumns="False">
                                                                                        <Columns>
                                                                                            <asp:TemplateField HeaderText="Select">
                                                                                                <ItemTemplate>
                                                                                                    <asp:CheckBox ID="ChkBxSelDocBoy" runat="server" AutoPostBack="true" /></ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Document Boy ID" Visible="False">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDocumentBoyID" runat="server" Text='<%#Eval("DocumentBoyID")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                            <asp:TemplateField HeaderText="Document Boy Name">
                                                                                                <ItemTemplate>
                                                                                                    <asp:Label ID="lblDocumentBoyName" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                                                </ItemTemplate>
                                                                                            </asp:TemplateField>
                                                                                        </Columns>
                                                                                        <RowStyle Height="20px" />
                                                                                        <AlternatingRowStyle Height="20px" />
                                                                                    </asp:GridView>
                                                                                </asp:Panel>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ContentTemplate>
                                                            </asp:TabPanel>
                                                        </asp:TabContainer>
                                                        <%--<asp:UpdatePanel ID="UpdatePanel2" width="100%" runat="server">
                                                            <ContentTemplate>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                            <table class="table">
                                                <tr>
                                                    <td align="right" class="tdLabel">
                                                        <asp:Label ID="Label2" runat="server" Text="Soft Copy Sent :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <asp:CheckBox ID="ChkBxSCS" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxSCS_CheckedChanged" />
                                                        <asp:TextBox ID="txtSoftCopySent" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtSoftCopySent">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                    <td align="right" class="tdLabel">
                                                        <asp:Label ID="Label5" runat="server" Text="Pending Doc Rcd :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <asp:CheckBox ID="ChkBxPDR" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxPDR_CheckedChanged" />
                                                        <asp:TextBox ID="txtPendingDocRcd" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPendingDocRcd">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="style39">
                                                        <asp:Label ID="Label3" runat="server" Text="Search Initiated :"></asp:Label>
                                                    </td>
                                                    <td class="style37">
                                                        <asp:CheckBox ID="ChkBxSI" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxSI_CheckedChanged" />
                                                        <asp:TextBox ID="txtSearchInitiated" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtSearchInitiated">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                   <%-- <td align="right" class="tdLabel">
                                                        <asp:Label ID="Label6" runat="server" Text="Pending Docs Rcsp :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <asp:CheckBox ID="ChkBxPDRcsp" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxPDRcsp_CheckedChanged" />
                                                        <asp:TextBox ID="txtPendingDocRcsp" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtPendingDocRcsp">
                                                        </asp:CalendarExtender>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td align="right" class="tdLabel">
                                                        <asp:Label ID="Label4" runat="server" Text="Search Received :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <asp:CheckBox ID="ChkBxSR" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxSR_CheckedChanged" />
                                                        <asp:TextBox ID="txtSearchReceived" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender7" runat="server" TargetControlID="txtSearchReceived">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                    <td align="right" class="tdLabel">
                                                        <asp:Label ID="Label7" runat="server" Text="Receipt Search :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <asp:CheckBox ID="ChkBxRS" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxRS_CheckedChanged" />
                                                        <asp:TextBox ID="txtReceiptSearch" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender8" runat="server" TargetControlID="txtReceiptSearch">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdLabel" align="right">
                                                        <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
                                                        <asp:Label ID="lblRemarks1" runat="server" Text="Remarks :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                    <td class="tdLabel" align="right">
                                                        <asp:Label ID="Label8" runat="server" Text="Hard Copy Sent :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <asp:CheckBox ID="ChkBxHCS" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxHCS_CheckedChanged" />
                                                        <asp:TextBox ID="txtHardCopySent" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtHardCopySent">
                                                        </asp:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td class="tdLabel" align="right">
                                                        <asp:Label ID="Label27" Visible="false" runat="server" Text="Price :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <%--          </asp:CalendarExtender>--%>
                                                        <asp:TextBox ID="txtPrice" Visible="false" runat="server" AutoPostBack="True" OnTextChanged="txtPrice_TextChanged"
                                                            ReadOnly="True">0</asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="REVAMT" runat="server" ControlToValidate="txtPrice"
                                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Enter Only Numbers."
                                                            ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveProject"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                  <%--  <td class="tdLabel" align="right">
                                                        <asp:Label ID="Label26" runat="server" Text="Final Report Sent :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="ChkBxFRS" runat="server" AutoPostBack="True" OnCheckedChanged="ChkBxFRS_CheckedChanged" />
                                                        <asp:TextBox ID="txtFinalReportSent" runat="server" Enabled="False"></asp:TextBox>
                                                        <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtFinalReportSent">
                                                        </asp:CalendarExtender>
                                                    </td>--%>
                                                </tr>
                                                <tr>
                                                    <td class="tdLabel" align="right">
                                                        <asp:Label ID="Label29" Visible="false" runat="server" Text="Service Tax :"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtServiceTax" Visible="false" runat="server" AutoPostBack="True" Enabled="False">0</asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="REVServiceTax" runat="server" ControlToValidate="txtServiceTax"
                                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Enter Only Numbers."
                                                            ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveProject"></asp:RegularExpressionValidator>--%>
                                                    </td>
                                                    <td class="tdLabel" align="right">
                                                        <asp:Label ID="Label22" Visible="false" runat="server" Text="Other Charges :"></asp:Label>
                                                    </td>
                                                    <td class="tdControl">
                                                        <asp:TextBox ID="txtOtherCharge" Visible="false" runat="server" AutoPostBack="true" OnTextChanged="txtOtherCharge_TextChanged">0</asp:TextBox>
                                                        <%--<asp:RegularExpressionValidator ID="REVAMTotaamt" runat="server" ControlToValidate="txtOtherCharge"
                                                            Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Enter Only Numbers."
                                                            ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveProject"></asp:RegularExpressionValidator>--%>
                                                        <asp:Label ID="lblOtherChrgeMsg" runat="server" ForeColor="Red"></asp:Label>
                                                    </td>
                                                    <tr>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="Label30" runat="server" Text="Status :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:DropDownList ID="ddlStatus" runat="server">
                                                                <asp:ListItem Value="InProcess">InProcess</asp:ListItem>
                                                                <asp:ListItem Value="Completed">Completed</asp:ListItem>
                                                                <asp:ListItem Value="OnHold">OnHold</asp:ListItem>
                                                                <asp:ListItem Value="Cancelled">Cancelled</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:TextBox ID="txtStatus" runat="server" Visible="False"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlStatus"
                                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" InitialValue="-1" SetFocusOnError="True"
                                                                ToolTip="Please Select Status" ValidationGroup="SaveProject"></asp:RequiredFieldValidator>
                                                        </td>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="Label24" Visible="false" runat="server" Text="Total Amount :"></asp:Label>
                                                        </td>
                                                        <td class="tdControl">
                                                            <asp:TextBox ID="txtTotAmt" Visible="false" runat="server" Enabled="False">0</asp:TextBox>
                                                            <%--<asp:RegularExpressionValidator ID="REVTotalamt" runat="server" ControlToValidate="txtTotAmt"
                                                                Display="Dynamic" ErrorMessage="*" ForeColor="Red" ToolTip="Enter Only Numbers."
                                                                ValidationExpression="[0-9.]{1,10}" ValidationGroup="SaveProject"></asp:RegularExpressionValidator>--%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tdLabel" align="right">
                                                            &nbsp;
                                                        </td>
                                                        <td>
                                                        <asp:CheckBox ID="ChkBxApprovProject" runat="server" Visible="false" Text="Approve Project" />
                                                        </td>
                                                        <td class="tdLabel" align="right">
                                                            <asp:Label ID="Label20" runat="server" Text="Is Deleted :"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:RadioButton ID="rbYesIsDel" runat="server" GroupName="IsDeleted" Text="Yes" />
                                                            <asp:RadioButton ID="rbNoIsDel" runat="server" GroupName="IsDeleted" Checked="true"
                                                                Text="No" />
                                                            
                                                        </td>
                                                    </tr>
                                                </tr>
                                            </table>
                                            <%--</ContentTemplate>
                                                        </asp:UpdatePanel>--%>
                                            <%--   </td>
                                                </tr>--%>
                                            <table>
                                                <tr>
                                                    <td class="tdControl" align="center">
                                                        <asp:Button ID="Button1" runat="server" OnClick="btnResetAmt_Click" Text="Reset Amount" />&nbsp;
                                                        <asp:Button ID="Button2" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="SaveProject" />&nbsp;
                                                        <asp:Button ID="Button3" runat="server" OnClick="btnCancel_Click" Text="Cancel" CausesValidation="False" />
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- <tr>
                                                    <td class="tdControl" align="center">
                                                        <asp:Button ID="btnResetAmt" runat="server" OnClick="btnResetAmt_Click" Text="Reset Amount" />&nbsp;
                                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" ValidationGroup="SaveProject" />&nbsp;
                                                        <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="Cancel" />
                                                    </td>
                                                </tr>--%>
                                            <%--</table>--%>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </center>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
