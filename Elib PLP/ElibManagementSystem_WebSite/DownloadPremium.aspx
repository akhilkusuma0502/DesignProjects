<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadPremium.aspx.cs" Inherits="ElibManagementSystem_WebSite.DownloadPremium" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">
        body{
            display:grid;
        }
        form{
            margin:auto;
        }
        .auto-style1 {
            height: 26px;
        }
    </style>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <table class="auto-style1">
        <tr>
            <td colspan="10">
                <asp:Label ID="lblPaymentSummary" runat="server" Text="Payment Summary"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="6">
                <asp:Label ID="lblMessage" runat="server" Text="Please review the following details for this transaction."></asp:Label>
            </td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="10">
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="8">
                <asp:Label ID="lblVerfiy" runat="server" Text="Verify Payment"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td colspan="8" class="auto-style1"></td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2" colspan="8">
                <asp:Label ID="lblMembershipFee" runat="server" Text="Document Fee  :   "></asp:Label>
            &nbsp;<asp:Label ID="lblPrice" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="6">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="6">
                <asp:Label ID="lblPayment" runat="server" Text="Payment Mode"></asp:Label>
            </td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="6">
                <asp:RadioButtonList ID="rdoPaymentModeGroup" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Visa Debit</asp:ListItem>
                    <asp:ListItem>American Express</asp:ListItem>
                    <asp:ListItem>Paypal</asp:ListItem>
                    <asp:ListItem>Discover</asp:ListItem>
                </asp:RadioButtonList>
            </td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2" colspan="6"></td>
            <td class="auto-style2" colspan="2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="6">&nbsp;</td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="5">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            </td>
            <td>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            </td>
            <td colspan="2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblCreditCard" runat="server" Text="CreditCard :"></asp:Label>
            </td>
            <td class="auto-style2" colspan="2">
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2" colspan="4">
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2" colspan="2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2" colspan="6">
                <asp:Label ID="lblCreditCardNumber" runat="server" Text="Credit Card Number"></asp:Label>
            </td>
            <td class="auto-style2" colspan="2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2" colspan="6">
                <asp:TextBox ID="txtCreditCardNumber" runat="server" Width="283px"></asp:TextBox>
            </td>
            <td class="auto-style2" colspan="2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style2" colspan="3">
                <asp:Label ID="lblExpiration" runat="server" Text="Expiration Month/Year"></asp:Label>
            </td>
            <td class="auto-style2" colspan="3">
                <asp:Label ID="lblCVV" runat="server" Text="CVV"></asp:Label>
            </td>
            <td class="auto-style2" colspan="2"></td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style2" colspan="3">
                <asp:DropDownList ID="ddlMonthExpiration" runat="server">
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblSlash" runat="server" Text="/"></asp:Label>
                <asp:DropDownList ID="ddlYearExpiration" runat="server" CssClass="auto-style3">
                    <asp:ListItem>2018</asp:ListItem>
                    <asp:ListItem>2019</asp:ListItem>
                    <asp:ListItem>2020</asp:ListItem>
                    <asp:ListItem>2021</asp:ListItem>
                    <asp:ListItem>2022</asp:ListItem>
                    <asp:ListItem>2023</asp:ListItem>
                    <asp:ListItem>2024</asp:ListItem>
                    <asp:ListItem>2025</asp:ListItem>
                    <asp:ListItem>2026</asp:ListItem>
                    <asp:ListItem>2027</asp:ListItem>
                    <asp:ListItem>2028</asp:ListItem>
                    <asp:ListItem>2029</asp:ListItem>
                    <asp:ListItem>2030</asp:ListItem>
                    <asp:ListItem>2031</asp:ListItem>
                    <asp:ListItem>2032</asp:ListItem>
                    <asp:ListItem>2033</asp:ListItem>
                    <asp:ListItem>2034</asp:ListItem>
                    <asp:ListItem>2035</asp:ListItem>
                    <asp:ListItem>2036</asp:ListItem>
                    <asp:ListItem>2037</asp:ListItem>
                    <asp:ListItem>2038</asp:ListItem>
                    <asp:ListItem>2039</asp:ListItem>
                    <asp:ListItem>2040</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style2" colspan="3">
                <asp:TextBox ID="txtCVV" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style2" colspan="6">&nbsp;</td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style2" colspan="6">
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style2" colspan="6">
                <asp:Label ID="lblPaymentErrorMessage" runat="server"></asp:Label>
            </td>
            <td class="auto-style2" colspan="2">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
