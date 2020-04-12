<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="SearchResultsPage.aspx.cs" Inherits="ElibManagementSystem_WebSite.SearchResultsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:50px;margin-top:20px;margin-right:50px;margin-bottom:20px;">
          <p>
        <asp:Label ID="lblSearchResults" runat="server" Text="Search Results"></asp:Label>
        &nbsp;</p>
    <p>
        &nbsp;

    </p>
    <p>
        <asp:ObjectDataSource ID="odsSearchResults" runat="server" SelectMethod="SearchByDocumentName" TypeName="ElibManagementSystem_BusinessLogicLayer.Document_DetailsBLL">
            <SelectParameters>
                <asp:QueryStringParameter Name="name" QueryStringField="Search" Type="String" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </p>
    <p>
        <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="False" DataSourceID="odsSearchResults" CellPadding="3" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:TemplateField HeaderText="DocumentId" SortExpression="DocumentId">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("DocumentId") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="lblDetails" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Black" Text='<%# Bind("DocumentId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DocumentName" HeaderText="Name" SortExpression="DocumentName" />
                <asp:BoundField DataField="DocumentDescription" HeaderText="Description" SortExpression="DocumentDescription" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Author" HeaderText="Author" SortExpression="Author" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:TemplateField ShowHeader="False" HeaderText="Document Details">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnkDocumentDetails" runat="server" NavigateUrl='<%# Eval("DocumentId","~/DocumentDetailsPage.aspx?DocumentId={0}") %>' ForeColor="Red" >View Details</asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        &nbsp;&nbsp;</p>
    </div>
</asp:Content>
