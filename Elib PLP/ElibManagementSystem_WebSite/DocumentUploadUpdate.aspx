<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="DocumentUploadUpdate.aspx.cs" Inherits="ElibManagementSystem_WebSite.DocumentUploadUpdate" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
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
        .auto-style14 {
            width: 233px;
        }
      
        .auto-style18 {
            height: 26px;
        }
        
        .auto-style19 {
            width: 210px;
        }
        .auto-style20 {
            width: 339px;
        }
        
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server"   ActiveTabIndex="1" Height="430px" Width="655px" BackColor="#CCFFFF"  CssClass="Tab">
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1">

  <HeaderTemplate >Upload Document <br /></HeaderTemplate>
            <ContentTemplate>
                <table>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td><asp:Label ID="lblDocumentNameUpload" runat="server" Text="Document Name"></asp:Label>
                        </td>
                        <td><asp:TextBox ID="txtDocumentNameUpload" runat="server" BackColor="#99CCFF" Font-Size="12pt" Height="25px" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentNameUpload_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentNameUpload_RoundedCornersExtender" TargetControlID="txtDocumentNameUpload" /><asp:RequiredFieldValidator ID="valDocumentNameUpload" runat="server" ControlToValidate="txtDocumentNameUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator></td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td><asp:Label ID="lblDocumentDescriptionUpload" runat="server" Text="Document Description"></asp:Label></td><td><asp:TextBox ID="txtDocumentDescriptionUpload" runat="server" BackColor="#99CCFF" Height="25px" Font-Size="12pt" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentDescriptionUpload_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentDescriptionUpload_RoundedCornersExtender" TargetControlID="txtDocumentDescriptionUpload" /><asp:RequiredFieldValidator ID="valDocumentDescriptionUpload" runat="server" ControlToValidate="txtDocumentDescriptionUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator></td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td><asp:Label ID="lblDocumentTypeUpload" runat="server" Text="Document Type "></asp:Label></td>
                        <td><ajaxToolkit:ComboBox ID="cmbDocumentTypeUpload" runat="server" DataSourceID="ObjectDataSource1" DataTextField="DocumentTypeName" DataValueField="DocumentTypeId" MaxLength="0" style="display: inline;" BackColor="#99CCFF" Height="25px" Font-Size="12pt" width="279px"></ajaxToolkit:ComboBox><asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="ElibManagementSystem_BusinessLogicLayer.Document_Type_DetailsBLL"></asp:ObjectDataSource><asp:RequiredFieldValidator ID="valDocumentTypeUpload" runat="server" ControlToValidate="cmbDocumentTypeUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator></td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr><td><asp:Label ID="lblDisciplineNameUpload" runat="server" Text="Discipline Name"></asp:Label></td>
                        <td><ajaxToolkit:ComboBox ID="cmbDisciplineNameUpload" runat="server" DataSourceID="ObjectDataSource2" DataTextField="DisciplineName" DataValueField="DisciplineId" MaxLength="0" style="display: inline;" BackColor="#99CCFF" Height="25px" Font-Size="12pt" width="279px"></ajaxToolkit:ComboBox><asp:ObjectDataSource ID="ObjectDataSource2" runat="server" SelectMethod="GetAll" TypeName="ElibManagementSystem_BusinessLogicLayer.DisciplinesBLL"></asp:ObjectDataSource><asp:RequiredFieldValidator ID="valDisciplineNameUpload" runat="server" ControlToValidate="cmbDisciplineNameUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator></td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td><asp:Label ID="lblTitleUpload" runat="server" Text="Title"></asp:Label></td>
                        <td><asp:TextBox ID="txtTitleUpload" runat="server" BackColor="#99CCFF" Height="25px" Font-Size="12pt" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtTitleUpload_RoundedCornersExtender" runat="server" BehaviorID="txtTitleUpload_RoundedCornersExtender" TargetControlID="txtTitleUpload" /><asp:RequiredFieldValidator ID="valTitleUpload" runat="server" ControlToValidate="txtTitleUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator></td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr><td><asp:Label ID="lblAuthorUpload" runat="server" Text="Author"></asp:Label></td>
                        <td><asp:TextBox ID="txtAuthorUpload" runat="server" BackColor="#99CCFF" Height="25px" Font-Size="12pt" width="279px"></asp:TextBox>
                            <ajaxToolkit:RoundedCornersExtender ID="txtAuthorUpload_RoundedCornersExtender" runat="server" BehaviorID="txtAuthorUpload_RoundedCornersExtender" TargetControlID="txtAuthorUpload" />
                            <asp:RequiredFieldValidator ID="valAuthorUpload" runat="server" ControlToValidate="txtAuthorUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator></td>
                        <td>&nbsp;</td>

                    </tr>
                    <tr>
                        <td><asp:Label ID="lblPriceUpload" runat="server" Text="Price"></asp:Label></td>
                        <td><asp:TextBox ID="txtPriceUpload" runat="server" BackColor="#99CCFF" Height="25px" Font-Size="12pt" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtPriceUpload_RoundedCornersExtender" runat="server" BehaviorID="txtPriceUpload_RoundedCornersExtender" TargetControlID="txtPriceUpload" /><asp:RequiredFieldValidator ID="valPriceUpload" runat="server" ControlToValidate="txtPriceUpload" ErrorMessage="*" ForeColor="Red" ValidationGroup="Upload"></asp:RequiredFieldValidator></td>
                        <td>&nbsp;</td></tr>
                    <tr>
                        <td><asp:Label ID="lblDocumentPathUpload" runat="server" Text="Document Path"></asp:Label></td>
                        <td><asp:FileUpload ID="FileUpload1" runat="server" OnDataBinding="Page_Load" BackColor="#99CCFF" Height="25px" Font-Size="12pt" /><ajaxToolkit:RoundedCornersExtender ID="FileUpload1_RoundedCornersExtender" runat="server" BehaviorID="FileUpload1_RoundedCornersExtender" TargetControlID="FileUpload1" /></td>
                        <td><asp:Label ID="lblPathUpload" runat="server"></asp:Label></td>

                    </tr>
                    <tr><td>&nbsp;</td><td>&nbsp;</td><td>&nbsp;</td></tr>
                    <tr><td>&nbsp;</td><td><asp:Label ID="lblMessage" runat="server"></asp:Label></td><td>&nbsp;</td></tr>
                    <tr><td>&nbsp;</td><td><asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" ValidationGroup="Upload"  Height="40px" BackColor="#00CCFF" BorderColor="#003399" Width="82px"/><ajaxToolkit:RoundedCornersExtender ID="btnUpload_RoundedCornersExtender" runat="server" BehaviorID="btnUpload_RoundedCornersExtender" TargetControlID="btnUpload" /></td><td>&nbsp;</td></tr>

                </table></ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="Update Document">
         
             <ContentTemplate><table><tr><td class="auto-style19">&nbsp;</td><td class="auto-style20">&nbsp;</td><td>&nbsp;</td></tr><tr><td class="auto-style19"><asp:Label ID="lblDocumentId" runat="server" Text="Document ID"></asp:Label></td><td class="auto-style20"><asp:TextBox ID="txtDocumentIdUpdate" runat="server" BackColor="#99CCFF" Height="25px" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentIdUpdate_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentIdUpdate_RoundedCornersExtender" TargetControlID="txtDocumentIdUpdate" /><asp:RequiredFieldValidator ID="valDocumentIdUpdate" runat="server" ControlToValidate="txtDocumentIdUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="FindUpdate"></asp:RequiredFieldValidator></td><td><asp:Button ID="btnFindUpdate" runat="server" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="82px" Text="Find" ValidationGroup="FindUpdate" OnClick="btnFindUpdate_Click"></asp:Button><ajaxToolkit:RoundedCornersExtender ID="btnFindUpdate_RoundedCornersExtender" runat="server" BehaviorID="btnFindUpdate_RoundedCornersExtender" TargetControlID="btnFindUpdate" /></td></tr><tr>
                 <td class="auto-style19"><asp:Label ID="lblDocumentNameUpdate" runat="server" Text="Document Name"></asp:Label></td><td class="auto-style20">
                 <asp:TextBox ID="txtDocumentNameUpdate" runat="server" BackColor="#99CCFF" Height="25px" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentNameUpdate_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentNameUpdate_RoundedCornersExtender" TargetControlID="txtDocumentNameUpdate" /><asp:RequiredFieldValidator ID="valDocumentNameUpdate" runat="server" ControlToValidate="txtDocumentNameUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator></td><td>&nbsp;</td></tr><tr><td class="auto-style19"><asp:Label ID="lblDocumentDescriptionUpdate" runat="server" Text="Document Description"></asp:Label></td><td class="auto-style20"><asp:TextBox ID="txtDocumentDescriptionUpdate" runat="server" BackColor="#99CCFF" Height="25px" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentDescriptionUpdate_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentDescriptionUpdate_RoundedCornersExtender" TargetControlID="txtDocumentDescriptionUpdate" /><asp:RequiredFieldValidator ID="valDocumentDescriptionUpdate" runat="server" ControlToValidate="txtDocumentDescriptionUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator></td><td>&nbsp;</td></tr><tr>
                 <td class="auto-style19"><asp:Label ID="lblDocumentTypeUpdate" runat="server" Text="Document Type "></asp:Label></td><td class="auto-style20">
                 <ajaxToolkit:ComboBox ID="cmbDocumentTypeUpdate" runat="server" MaxLength="0" DataSourceID="ObjectDataSource3" DataTextField="DocumentTypeName" DataValueField="DocumentTypeId" style="display: inline;" BackColor="#99CCFF" Height="25px" width="279px"></ajaxToolkit:ComboBox><ajaxToolkit:RoundedCornersExtender ID="cmbDocumentTypeUpdate_RoundedCornersExtender" runat="server" BehaviorID="cmbDocumentTypeUpdate_RoundedCornersExtender" TargetControlID="cmbDocumentTypeUpdate" /><asp:RequiredFieldValidator ID="valDocumentTypeUpdate" runat="server" ControlToValidate="cmbDocumentTypeUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator><asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetAll" TypeName="ElibManagementSystem_BusinessLogicLayer.Document_Type_DetailsBLL"></asp:ObjectDataSource></td><td >&nbsp;</td></tr><tr><td class="auto-style19"><asp:Label ID="lblDisciplineNameUpdate" runat="server" Text="Discipline Name"></asp:Label></td>
                 <td class="auto-style20">
                 <ajaxToolkit:ComboBox ID="cmbDisciplineNameUpdate" runat="server" MaxLength="0" DataSourceID="ObjectDataSource4" DataTextField="DisciplineName" DataValueField="DisciplineId" style="display: inline;" BackColor="#99CCFF" Height="25px" width="279px"></ajaxToolkit:ComboBox><ajaxToolkit:RoundedCornersExtender ID="cmbDisciplineNameUpdate_RoundedCornersExtender" runat="server" BehaviorID="cmbDisciplineNameUpdate_RoundedCornersExtender" TargetControlID="cmbDisciplineNameUpdate" /><asp:RequiredFieldValidator ID="valDisciplineNameUpdate" runat="server" ControlToValidate="cmbDisciplineNameUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator><asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetAll" TypeName="ElibManagementSystem_BusinessLogicLayer.DisciplinesBLL"></asp:ObjectDataSource></td><td >&nbsp;</td></tr><tr><td class="auto-style19"><asp:Label ID="lblTitleUpdate" runat="server" Text="Title"></asp:Label></td>
                 <td class="auto-style20" >
                 <asp:TextBox ID="txtTitleUpdate" runat="server" BackColor="#99CCFF" Height="25px" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtTitleUpdate_RoundedCornersExtender" runat="server" BehaviorID="txtTitleUpdate_RoundedCornersExtender" TargetControlID="txtTitleUpdate" /><asp:RequiredFieldValidator ID="valTitleUpdate" runat="server" ControlToValidate="txtTitleUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator></td><td>&nbsp;</td></tr><tr><td class="auto-style19"><asp:Label ID="lblAuthorUpdate" runat="server" Text="Author"></asp:Label></td><td class="auto-style20"><asp:TextBox ID="txtAuthorUpdate" runat="server" BackColor="#99CCFF" Height="25px" width="279px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtAuthorUpdate_RoundedCornersExtender" runat="server" BehaviorID="txtAuthorUpdate_RoundedCornersExtender" TargetControlID="txtAuthorUpdate" /><asp:RequiredFieldValidator ID="valAuthorUpdate" runat="server" ControlToValidate="txtAuthorUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator></td><td>&nbsp;</td></tr><tr>
                 <td class="auto-style19"><asp:Label ID="lblPriceUpdate" runat="server" Text="Price"></asp:Label></td><td class="auto-style20">
                 <asp:TextBox ID="txtPriceUpdate" runat="server" BackColor="#99CCFF" Height="25px" width="279px"></asp:TextBox>
                 <ajaxToolkit:RoundedCornersExtender ID="txtPriceUpdate_RoundedCornersExtender" runat="server" BehaviorID="txtPriceUpdate_RoundedCornersExtender" TargetControlID="txtPriceUpdate" />
                 <asp:RequiredFieldValidator ID="valPriceUpdate" runat="server" ControlToValidate="txtPriceUpdate" ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator></td><td>&nbsp;</td></tr><tr><td class="auto-style19"><asp:Label ID="lblDocumentPathUpdate" runat="server" Text="Document Path"></asp:Label></td><td class="auto-style20"><asp:FileUpload ID="FileUpload2" runat="server" BackColor="#99CCFF" Height="25px" /></td><td><asp:Label ID="lblPathUpdate" runat="server"></asp:Label></td></tr><tr><td class="auto-style19">&nbsp;</td><td class="auto-style20"><asp:Label ID="lblMessageUpdate" runat="server"></asp:Label></td><td>&nbsp;</td></tr><tr><td class="auto-style19">&nbsp;</td><td class="auto-style20"><asp:Button ID="btnUpdate" runat="server" Text="Update"  ValidationGroup="Update" OnClick="btnUpdate_Click" Height="40px" BackColor="#00CCFF" BorderColor="#003399" Width="82px" /><ajaxToolkit:RoundedCornersExtender ID="btnUpdate_RoundedCornersExtender" runat="server" BehaviorID="btnUpdate_RoundedCornersExtender" TargetControlID="btnUpdate" /></td><td>&nbsp;</td></tr><tr>
                 <td class="auto-style19">&nbsp;</td><td class="auto-style20">&nbsp;</td><td>&nbsp;</td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel7" runat="server" HeaderText="TabPanel7">
            
<HeaderTemplate>Delete Document</HeaderTemplate><ContentTemplate><table><tr><td  ></td><td  ></td><td  >&nbsp;</td></tr><tr><td   ><asp:Label ID="lblDocumentIdDelete" runat="server" Text="Document ID"></asp:Label></td><td><asp:TextBox ID="txtDocumentIdDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentIdDelete_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentIdDelete_RoundedCornersExtender" TargetControlID="txtDocumentIdDelete" /><asp:RequiredFieldValidator ID="valDocumentIdDelete" runat="server" ControlToValidate="txtDocumentIdDelete" ErrorMessage="*" ForeColor="Red" ValidationGroup="Delete"></asp:RequiredFieldValidator></td><td><asp:Button ID="btnFindDelete" runat="server" Text="Find" ValidationGroup="Delete" OnClick="btnFindDelete_Click" Height="32px" BackColor="#00CCFF" BorderColor="#003399" Width="82px" ></asp:Button><ajaxToolkit:RoundedCornersExtender ID="btnFindDelete_RoundedCornersExtender" runat="server" BehaviorID="btnFindDelete_RoundedCornersExtender" TargetControlID="btnFindDelete" /></td></tr><tr><td  ><asp:Label ID="lblDocumentNameDelete" runat="server" Text="Document Name"></asp:Label></td><td >
            <asp:TextBox ID="txtDocumentNameDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentNameDelete_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentNameDelete_RoundedCornersExtender" TargetControlID="txtDocumentNameDelete" /></td><td>&nbsp;</td></tr><tr><td  ><asp:Label ID="lblDocumentDescriptionDelete" runat="server" Text="Document Description"></asp:Label></td><td><asp:TextBox ID="txtDocumentDescriptionDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentDescriptionDelete_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentDescriptionDelete_RoundedCornersExtender" TargetControlID="txtDocumentDescriptionDelete" /></td><td>&nbsp;</td></tr><tr><td  ><asp:Label ID="lblDocumentTypeDelete" runat="server" Text="Document Type "></asp:Label></td><td  >
            <asp:TextBox ID="txtDocumentTypeDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDocumentTypeDelete_RoundedCornersExtender" runat="server" BehaviorID="txtDocumentTypeDelete_RoundedCornersExtender" TargetControlID="txtDocumentTypeDelete" /></td><td  >&nbsp;</td></tr><tr><td  ><asp:Label ID="lblDisciplineNameDelete" runat="server" Text="Discipline Name"></asp:Label></td><td><asp:TextBox ID="txtDisciplineNameDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtDisciplineNameDelete_RoundedCornersExtender" runat="server" BehaviorID="txtDisciplineNameDelete_RoundedCornersExtender" TargetControlID="txtDisciplineNameDelete" /></td><td>&nbsp;</td></tr><tr><td  ><asp:Label ID="lblTitleDelete" runat="server" Text="Title"></asp:Label></td><td><asp:TextBox ID="txtTitleDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtTitleDelete_RoundedCornersExtender" runat="server" BehaviorID="txtTitleDelete_RoundedCornersExtender" TargetControlID="txtTitleDelete" /></td><td>&nbsp;</td></tr><tr><td  ><asp:Label ID="lblAuthorDelete" runat="server" Text="Author"></asp:Label></td><td>
            <asp:TextBox ID="txtAuthorDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtAuthorDelete_RoundedCornersExtender" runat="server" BehaviorID="txtAuthorDelete_RoundedCornersExtender" TargetControlID="txtAuthorDelete" /></td><td>&nbsp;</td></tr><tr><td  ><asp:Label ID="lblPriceDelete" runat="server" Text="Price"></asp:Label></td><td><asp:TextBox ID="txtPriceDelete" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox><ajaxToolkit:RoundedCornersExtender ID="txtPriceDelete_RoundedCornersExtender" runat="server" BehaviorID="txtPriceDelete_RoundedCornersExtender" TargetControlID="txtPriceDelete" /></td><td>&nbsp;</td></tr><tr><td  ><asp:Label ID="lblDocumentPathDelete" runat="server" Text="Document Path"></asp:Label></td><td><asp:Label ID="lblPathDelete" runat="server"></asp:Label></td><td>&nbsp;</td></tr><tr><td  >&nbsp;</td><td><asp:Label ID="lblMessageDelete" runat="server"></asp:Label></td><td>&nbsp;</td></tr><tr><td  >&nbsp;</td><td><asp:Button ID="btnDeleteDocument" runat="server" Text="Delete" OnClick="btnDeleteDocument_Click1" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="82px"  /><ajaxToolkit:RoundedCornersExtender ID="btnDeleteDocument_RoundedCornersExtender" runat="server" BehaviorID="btnDeleteDocument_RoundedCornersExtender" TargetControlID="btnDeleteDocument" /></td><td>&nbsp;</td></tr><tr><td class="auto-style18"  ></td><td class="auto-style18"></td><td class="auto-style18"></td></tr></table></ContentTemplate></ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
        <div>

            <asp:HyperLink ID="lnkdisciplines" runat="server" ForeColor="#FF6666" NavigateUrl="~/DisciplinePage.aspx" Font-Bold="True" Font-Names="Century Gothic" Font-Size="15pt" Font-Underline="True">Modify Disciplines Here</asp:HyperLink>

        </div>
    </div>
</asp:Content>
