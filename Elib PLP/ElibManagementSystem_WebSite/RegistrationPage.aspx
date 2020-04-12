<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="RegistrationPage.aspx.cs" Inherits="ElibManagementSystem_WebSite.RegistrationPage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style21 {
            height: 36px;
        }
        .auto-style22 {
        width: 189px;
    }
        .auto-style23 {
        width: 189px;
        height: 40px;
    }
    .auto-style24 {
        height: 40px;
    }
    .auto-style25 {
        width: 189px;
        height: 39px;
    }
    .auto-style26 {
        height: 39px;
    }
    .auto-style27 {
        width: 189px;
        height: 59px;
    }
    .auto-style28 {
        height: 59px;
    }
        .auto-style29 {
            width: 189px;
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table style="margin:20px 20px 20px 20px">
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style22">&nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Registration" Font-Bold="True" Font-Size="15pt" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="lblUserId" runat="server" Text="User ID :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtUserId" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valUserId" runat="server" ControlToValidate="txtUserId" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valUserIdRegex" runat="server" ControlToValidate="txtUserId" Display="Dynamic" ErrorMessage="Should be 8-15 Characters" ForeColor="Red" ValidationExpression="^[a-zA-Z0-9]{8,15}$" ValidationGroup="ValidGroup"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtFirstName" Display="Dynamic" ErrorMessage="Should Contain Only Characters" ForeColor="Red" ValidationExpression="^[a-zA-Z]{2,15}$" ValidationGroup="ValidGroup"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="lblLastName" runat="server" Text="Last Name :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLastName" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valLastName" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtLastName" Display="Dynamic" ErrorMessage="Should Contain Only Characters" ForeColor="Red" ValidationExpression="^[a-zA-Z]{2,15}" ValidationGroup="ValidGroup"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date" BackColor="#99CCFF" Height="25px" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="valDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
               
            </td>
        </tr>
        <tr>
            <td class="auto-style29">
                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
            </td>
            <td class="auto-style21">
                <asp:TextBox ID="txtAddress" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valAddress" runat="server" ControlToValidate="txtAddress" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="lblLandLineNumber" runat="server" Text="Landline Number :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtLandlineNumber" runat="server" TextMode="Phone" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valLandlineNumber" runat="server" ControlToValidate="txtLandlineNumber" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="valLandLine" runat="server" ControlToValidate="txtLandlineNumber" Display="Dynamic" ErrorMessage="Number Should be 10 digits,Should start with [1-9]" ForeColor="Red" ValidationExpression="^[1-9]{1}[0-9]{9}$" ValidationGroup="ValidGroup"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile Number :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="Phone" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valMobileNumber" runat="server" ControlToValidate="txtMobileNumber" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtMobileNumber" ErrorMessage="Number Should be 10 digits,Should start with [1-9]" ForeColor="Red" ValidationExpression="^[1-9]{1}[0-9]{9}$" ValidationGroup="ValidGroup"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">
                <asp:Label ID="lblAreaOfInterest" runat="server" Text="Area Of Interest :"></asp:Label>
            </td>
            <td>
                <asp:CheckBoxList ID="chkAreaOfInterestList" runat="server" DataSourceID="ObjectDataSource1" DataTextField="DisciplineName" DataValueField="DisciplineName" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
                <asp:CustomValidator ID="valAreaOfInterest" runat="server" ClientValidationFunction="ValidateCheckBoxList" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="ValidGroup" ></asp:CustomValidator>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="ElibManagementSystem_BusinessLogicLayer.DisciplinesBLL"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td class="auto-style25">
                <asp:Label ID="lblGender" runat="server" Text="Gender :"></asp:Label>
            </td>
            <td class="auto-style26">
                <asp:RadioButtonList ID="rdoGenderGroup" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="valGender" runat="server" ControlToValidate="rdoGenderGroup" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style27">
                <asp:Label ID="lblUserType" runat="server" Text="User Type :"></asp:Label>
            </td>
            <td class="auto-style28">
                <asp:RadioButtonList ID="rdoUserTypeGroup" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Subscriber</asp:ListItem>
                    <asp:ListItem Value="Non_Subscriber">Non-Subscriber</asp:ListItem>
                </asp:RadioButtonList>
                <asp:RequiredFieldValidator ID="valUserType" runat="server" ControlToValidate="rdoUserTypeGroup" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style23">
                <asp:Label ID="lblDateOfRegistration" runat="server" Text="Date Of Registration :"></asp:Label>
            </td>
            <td class="auto-style24">
                <asp:TextBox ID="txtDateOfRegistration" runat="server" ReadOnly="True" BackColor="#99CCFF" Height="25px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style23">
                <asp:Label ID="lblPassword" runat="server" Text="Password :"></asp:Label>
            </td>
            <td class="auto-style24">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valPassword" runat="server" ControlToValidate="txtPassword" Display="Dynamic" ErrorMessage="*" ForeColor="Red" ValidationGroup="ValidGroup"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style22">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style22">&nbsp;</td>
            <td>
                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" ValidationGroup="ValidGroup" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="82px"/>
                <ajaxToolkit:RoundedCornersExtender ID="btnRegister_RoundedCornersExtender" runat="server" BehaviorID="btnRegister_RoundedCornersExtender" TargetControlID="btnRegister">
                </ajaxToolkit:RoundedCornersExtender>
&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style22"></td>
            <td>
                <asp:Label ID="lblRegistrationMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
</asp:Content>
