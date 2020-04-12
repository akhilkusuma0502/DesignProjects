<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="DisciplinePage.aspx.cs" Inherits="ElibManagementSystem_WebSite.DisciplinePage" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
     
        .Tab .ajax__tab_header
{
    color: #4682b4;
    font-family:Calibri;
    font-size: 14px;
    font-weight: bold;
    background-color: #ffffff;
    margin-left: 0px;
}
/*Body*/
.Tab .ajax__tab_body
{
    border:1px solid #b4cbdf;
    padding-top:0px;
}
/*Tab Active*/
.Tab .ajax__tab_active .ajax__tab_tab
{
    color: #ffffff;
    background:url("../../tab_active.gif") repeat-x;
    height:20px;
}
.Tab .ajax__tab_active .ajax__tab_inner
{
    color: #ffffff;
    background:url("../../tab_left_active.gif") no-repeat left;
    padding-left:10px;
}
.Tab .ajax__tab_active .ajax__tab_outer
{
    color: #ffffff;
    background:url("../../tab_right_active.gif") no-repeat right;
    padding-right:6px;
}
/*Tab Hover*/
.Tab .ajax__tab_hover .ajax__tab_tab
{
    color: #000000;
    background:url("../../tab_hover.gif") repeat-x;
    height:20px;
}
.Tab .ajax__tab_hover .ajax__tab_inner
{
    color: #000000;
    background:url("../../tab_left_hover.gif") no-repeat left;
    padding-left:10px;
}
.Tab .ajax__tab_hover .ajax__tab_outer
{
    color: #000000;
    background:url("../../tab_right_hover.gif") no-repeat right;
    padding-right:6px;
}
/*Tab Inactive*/
.Tab .ajax__tab_tab
{
    color: #666666;
    background:url("../../tab_Inactive.gif") repeat-x;
    height:20px;
}
.Tab .ajax__tab_inner
{
    color: #666666;
    background:url("../../tab_left_inactive.gif") no-repeat left;
    padding-left:10px;
}
.Tab .ajax__tab_outer
{
    color: #666666;
    background:url("../../tab_right_inactive.gif") no-repeat right;
    padding-right:6px;
    margin-right: 2px;
}
        .auto-style15 {
            width: 170px;
        }
        .auto-style16 {
            width: 156px;
        }
        .auto-style18 {
            width: 190px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="2" Height="265px" Width="489px" CssClass="Tab" >
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">
                    <HeaderTemplate>
                        Upload Discipline<br />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table  >
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style15">
                                    <asp:Label ID="lblDisciplineNameUpload" runat="server" Text="Discipline Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDisciplineNameUpload" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                                    <ajaxToolkit:RoundedCornersExtender ID="txtDisciplineNameUpload_RoundedCornersExtender" runat="server" BehaviorID="txtDisciplineNameUpload_RoundedCornersExtender" TargetControlID="txtDisciplineNameUpload" />
                                    <asp:RequiredFieldValidator ID="valDisciplineName" runat="server" ControlToValidate="txtDisciplineNameUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnUploadDiscipline" runat="server" Text="Upload" ValidationGroup="Upload" OnClick="btnUploadDiscipline_Click" Height="40px" BackColor="#00CCFF" BorderColor="#003399" Width="82px" />
                                    <ajaxToolkit:RoundedCornersExtender ID="btnUploadDiscipline_RoundedCornersExtender" runat="server" BehaviorID="btnUploadDiscipline_RoundedCornersExtender" TargetControlID="btnUploadDiscipline" />
                                    <br />
                                    <br />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style15">&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
                    <HeaderTemplate>
                        Update Discipline<br />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table  >
                            <tr>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style18">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style16"  >
                                    <asp:Label ID="lblDisciplineId" runat="server" Text="Discipline ID"></asp:Label>
                                </td>
                                <td class="auto-style18"  >
                                    <asp:TextBox ID="txtDisciplineId" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                                    <ajaxToolkit:RoundedCornersExtender ID="txtDisciplineId_RoundedCornersExtender" runat="server" BehaviorID="txtDisciplineId_RoundedCornersExtender" TargetControlID="txtDisciplineId" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDisciplineId" ErrorMessage="Discipline Id cant be empty" ForeColor="Red" ValidationGroup="UpdateFind">*</asp:RequiredFieldValidator>
                                </td>
                                <td  >
                                    <asp:Button ID="btnFind" runat="server" Text="Find" ValidationGroup="UpdateFind" OnClick="btnFind_Click" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="82px" />
                                    <ajaxToolkit:RoundedCornersExtender ID="btnFind_RoundedCornersExtender" runat="server" BehaviorID="btnFind_RoundedCornersExtender" TargetControlID="btnFind" />
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style16">
                                    <asp:Label ID="lblDisciplineNameUpdate" runat="server" Text="Discipline Name"></asp:Label>
                                </td>
                                <td class="auto-style18">
                                    <asp:TextBox ID="txtDisciplineNameUpdate" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                                    <ajaxToolkit:RoundedCornersExtender ID="txtDisciplineNameUpdate_RoundedCornersExtender" runat="server" BehaviorID="txtDisciplineNameUpdate_RoundedCornersExtender" TargetControlID="txtDisciplineNameUpdate" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDisciplineNameUpdate" ErrorMessage="Discipline Name cannott be empty " ForeColor="Red" ValidationGroup="Update1">*</asp:RequiredFieldValidator>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style18">&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style18">
                                    <asp:Button ID="btnUpdateDiscipline" runat="server" Text="Update" ValidationGroup="Update1" OnClick="btnUpdateDiscipline_Click" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="82px" />
                                    <ajaxToolkit:RoundedCornersExtender ID="btnUpdateDiscipline_RoundedCornersExtender" runat="server" BehaviorID="btnUpdateDiscipline_RoundedCornersExtender" TargetControlID="btnUpdateDiscipline" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="auto-style16">&nbsp;</td>
                                <td class="auto-style18">
                                    &nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
                    <HeaderTemplate>
                        Delete Discipline<br />
                    </HeaderTemplate>
                    <ContentTemplate>
                        <table  >
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDisciplineIdDelete" runat="server" Text="Discipline Id"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDisciplineIdDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                                    <ajaxToolkit:RoundedCornersExtender ID="txtDisciplineIdDelete_RoundedCornersExtender" runat="server" BehaviorID="txtDisciplineIdDelete_RoundedCornersExtender" TargetControlID="txtDisciplineIdDelete" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDisciplineIdDelete" ErrorMessage="*" ForeColor="Red" ValidationGroup="Delete"></asp:RequiredFieldValidator>
                                </td>
                                <td>
                                    <asp:Button ID="btnFindDelete" runat="server" Text="Find" ValidationGroup="Delete" Height="40px" BackColor="#00CCFF" BorderColor="#003399" Width="82px" OnClick="btnFindDelete_Click" />
                                    <ajaxToolkit:RoundedCornersExtender ID="btnFindDelete_RoundedCornersExtender" runat="server" BehaviorID="btnFindDelete_RoundedCornersExtender" TargetControlID="btnFindDelete" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblDisiplineNameDelete" runat="server" Text="Discipline Name"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDisciplineNameDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                                    <ajaxToolkit:RoundedCornersExtender ID="txtDisciplineNameDelete_RoundedCornersExtender" runat="server" BehaviorID="txtDisciplineNameDelete_RoundedCornersExtender" TargetControlID="txtDisciplineNameDelete" />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:Button ID="btnDelete" runat="server" Text="Delete" ValidationGroup="Delete" OnClick="btnDelete_Click" Height="40px" BackColor="#00CCFF" BorderColor="#003399" Width="82px"  />
                                    <ajaxToolkit:RoundedCornersExtender ID="btnDelete_RoundedCornersExtender" runat="server" BehaviorID="btnDelete_RoundedCornersExtender" TargetControlID="btnDelete" />
                                    <br />
                                    <br />
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>
            <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True" Font-Names="Century Gothic" Font-Size="15pt" Font-Underline="True" ForeColor="#FF3300" NavigateUrl="~/DocumentUploadUpdate.aspx">Upload Documents Here</asp:HyperLink>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
