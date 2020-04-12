<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="ElibManagementSystem_WebSite.HomePage" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    <style type="text/css">
        .auto-style8 {
            margin-top: 0px;
        }
        #TextBox1
        {
            color:darkseagreen;
            background-color:#b3bff5;
        }
        #btnSearch
        {
            color:blueviolet;
            background-color:coral;
        }
        .auto-style9 {
            width: 556px;
        }
    </style>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-left:15px; margin-top:15px;">
<div style="font-size:30px; font-weight:bold;font-family:Arial, Helvetica, sans-serif; color:black;">
        <asp:Label ID="lblSearch" runat="server" Text="Start Searching Document"></asp:Label>
    </div>
    <br />
    <div class="auto-style9">
        <asp:TextBox ID="txtSearch" runat="server" Height="35px" Width="430px" BackColor="#999966"></asp:TextBox>
        <ajaxToolkit:RoundedCornersExtender ID="txtSearch_RoundedCornersExtender" runat="server" BehaviorID="TextBox1_RoundedCornersExtender" TargetControlID="txtSearch" />
    &nbsp;<asp:Button ID="btnSearch" runat="server" Text="Search" Height="35px" BackColor="#33CCFF" ForeColor="#003366" Width="77px" OnClick="btnSearch_Click"/>
        <ajaxToolkit:RoundedCornersExtender ID="btnSearch_RoundedCornersExtender" runat="server" BehaviorID="btnSearch_RoundedCornersExtender" TargetControlID="btnSearch" />
        <br />
        <br />
        
    </div>
        </div>
    <div style="margin-left:15px; margin-top:15px;">
        <div style="font-size:30px; font-weight:bold;font-family:Arial, Helvetica, sans-serif; color:black;">
        <asp:Label runat="server" Text="Browse Documents">
            <asp:LinkButton ID="lnkHere" runat="server"  ForeColor="#FF6666" Height="26px" Width="43px" Font-Underline="True" PostBackUrl="~/BrowsePage.aspx">Here</asp:LinkButton>
        </asp:Label>
        </div>
        </div>
        <br />
        <div style="margin-left:15px;font-size:30px; font-weight:bold;font-family:Arial, Helvetica, sans-serif; color:black;">
        <asp:label runat="server" ID="lblGuestUser" Text="Guest User ?"> 
            <asp:LinkButton ID="lnkRegisterHere" runat="server" ForeColor="#FF6666" Height="26px" Width="202px" Font-Underline="True" PostBackUrl="~/RegistrationPage.aspx">Register Here</asp:LinkButton>
            </asp:label>
        </div>
        <br />

        
</asp:Content>
