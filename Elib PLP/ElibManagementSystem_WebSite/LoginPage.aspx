<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="ElibManagementSystem_WebSite.LoginPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style13 {
            width: 164px;
        }
        .auto-style14 {
            width: 86%;
            height: 26px;
            margin: auto;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <table style="margin-left:80px;margin-right:80px;margin-top:25px;margin-bottom:25px;">
                <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblLogin" runat="server" Text="Login" Font-Bold="True" Font-Size="15pt" ForeColor="#FF6666"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="UserId :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserID" runat="server" BackColor="#99CCFF" Height="30px"></asp:TextBox>
                <ajaxToolkit:RoundedCornersExtender ID="txtUserID_RoundedCornersExtender" runat="server" BehaviorID="txtUserID_RoundedCornersExtender" TargetControlID="txtUserID" />
                <asp:RequiredFieldValidator ID="valReqUserID" runat="server" ErrorMessage="*" ControlToValidate="txtUserID" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtUserID" Display="Dynamic" ErrorMessage="Enter Only Characters And Numbers" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{8,15}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" BackColor="#99CCFF" Height="30px"></asp:TextBox>
                <ajaxToolkit:RoundedCornersExtender ID="txtPassword_RoundedCornersExtender" runat="server" BehaviorID="txtPassword_RoundedCornersExtender" TargetControlID="txtPassword" />
                <asp:RequiredFieldValidator ID="valReqPassword" runat="server" ErrorMessage="*" ControlToValidate="txtPassword" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="Enter Only Characters And Numbers" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{8,15}$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                </td>
        </tr>
        <tr>
            <td >&nbsp;</td>
            <td>
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="103px" BorderStyle="None"/>
                <ajaxToolkit:RoundedCornersExtender ID="btnLogin_RoundedCornersExtender" runat="server" BehaviorID="btnLogin_RoundedCornersExtender" TargetControlID="btnLogin" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblLoginMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
