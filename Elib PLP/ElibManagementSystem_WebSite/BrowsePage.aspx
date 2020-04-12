<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="BrowsePage.aspx.cs" Inherits="ElibManagementSystem_WebSite.BrowsePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .margin
        {
            margin-left:25px;
            margin-right:25px;
            margin-top:25px;
            margin-bottom:25px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="margin">
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td>
                        <asp:GridView ID="gvDisciplinesList" runat="server" AutoGenerateColumns="False" DataKeyNames="DisciplineId" DataSourceID="GetAllDisciplines" OnSelectedIndexChanged="gvDisciplinesList_SelectedIndexChanged" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal">
                            <AlternatingRowStyle BackColor="#F7F7F7" />
                            <Columns>
                                <asp:BoundField DataField="DisciplineId" HeaderText="DisciplineId" SortExpression="DisciplineId" />
                                <asp:BoundField DataField="DisciplineName" HeaderText="DisciplineName" SortExpression="DisciplineName" />
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                            <SortedAscendingCellStyle BackColor="#F4F4FD" />
                            <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                            <SortedDescendingCellStyle BackColor="#D8D8F0" />
                            <SortedDescendingHeaderStyle BackColor="#3E3277" />
                        </asp:GridView>
                        <asp:ObjectDataSource ID="GetAllDisciplines" runat="server" SelectMethod="GetAll" TypeName="ElibManagementSystem_BusinessLogicLayer.DisciplinesBLL"></asp:ObjectDataSource>
                        </td>
                    <td>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:GridView ID="gvDocumentDetailsList" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                            <Columns>
                                <asp:BoundField DataField="DocumentId" HeaderText="Document Id" />
                                <asp:BoundField DataField="DocumentName" HeaderText="Document Name" />
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="Author" HeaderText="Author" />
                                <asp:BoundField DataField="Price" HeaderText="Price" />
                                <asp:TemplateField ShowHeader="False" HeaderText="Documents Details">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="lnkViewDetails" runat="server"  NavigateUrl='<%# Eval("DocumentId","~/DocumentDetailsPage.aspx?DocumentId={0}") %>' ForeColor="#CC0000" >View Details</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="White" ForeColor="#000066" />
                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                            <RowStyle ForeColor="#000066" />
                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                        </asp:GridView>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                            <ProgressTemplate>
                                <asp:Label ID="lblOutputMessage" runat="server"></asp:Label>
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                    </td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>


    </asp:UpdatePanel>
    </div>
</asp:Content>
