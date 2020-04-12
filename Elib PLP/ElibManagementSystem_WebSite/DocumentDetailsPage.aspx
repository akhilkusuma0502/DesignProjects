<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="DocumentDetailsPage.aspx.cs" Inherits="ElibManagementSystem_WebSite.DocumentDetailsPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
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
        <asp:Label ID="lblDocumentDetails" runat="server" Text="Document Details" Font-Bold="True" ForeColor="#FF6666"></asp:Label>
    <br />
    <br />
    <asp:ObjectDataSource ID="odsDocumentDetails" runat="server" SelectMethod="SearchByDocumentId" TypeName="ElibManagementSystem_BusinessLogicLayer.Document_DetailsBLL">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="DocumentId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:DetailsView ID="dvDocumentDetails" runat="server" AutoGenerateRows="False" CellPadding="4" DataSourceID="odsDocumentDetails" ForeColor="#333333" GridLines="None" Height="50px" Width="125px"  >
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
        <EditRowStyle BackColor="#999999" />
        <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
        <Fields>
            <asp:TemplateField HeaderText="DocumentId" SortExpression="DocumentId">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DocumentId") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DocumentId") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDocumentId" runat="server" Text='<%# Bind("DocumentId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DocumentName" HeaderText="Name" SortExpression="DocumentName" />
            <asp:BoundField DataField="DocumentDescription" HeaderText="Description" SortExpression="DocumentDescription" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
            <asp:BoundField DataField="UploadDate" HeaderText="Uploaded On" SortExpression="UploadDate" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:TemplateField HeaderText="DocumentType" SortExpression="DocumentTypeName">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DocumentTypeName") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("DocumentTypeName") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblDocumentType" runat="server" Text='<%# Bind("DocumentTypeName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DisciplineName" HeaderText="Discipline" SortExpression="DisciplineName" />
        </Fields>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    </asp:DetailsView>
    <br />
    <br />
    <asp:Button ID="btnDownload" runat="server" Text="Download" OnClick="btnDownload_Click" Height="40px" BackColor="#00CCFF" BorderColor="#003399" Width="82px"/>
        <ajaxToolkit:RoundedCornersExtender ID="btnDownload_RoundedCornersExtender" runat="server" BehaviorID="btnDownload_RoundedCornersExtender" TargetControlID="btnDownload">
        </ajaxToolkit:RoundedCornersExtender>
    </div>
</asp:Content>
