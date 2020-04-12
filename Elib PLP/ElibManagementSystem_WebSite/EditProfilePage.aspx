<%@ Page Title="" Language="C#" MasterPageFile="~/ElibA.Master" AutoEventWireup="true" CodeBehind="EditProfilePage.aspx.cs" Inherits="ElibManagementSystem_WebSite.EditProfilePage" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  

    
   
   
    <script type="text/javascript">
    function ValidateCheckBoxList(sender, args) {
        var checkBoxList = document.getElementById("<%=chkAreaOfInterestList.ClientID %>");
        var checkboxes = checkBoxList.getElementsByTagName("input");
        var isValid = false;
        for (var i = 0; i < checkboxes.length; i++) {
            if (checkboxes[i].checked) {
                isValid = true;
                break;
            }
        }
        args.IsValid = isValid;
    }

    </script>

    <style type="text/css">
        .auto-style15 {
            height: 26px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>

  
     <table  style="margin:20px 20px 20px 20px">
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Profile" Font-Bold="True" Font-Size="15pt" ForeColor="#FF6666"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style15">
                </td>
            <td class="auto-style15">
                </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtFirstName" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <ajaxToolkit:RoundedCornersExtender ID="txtFirstName_RoundedCornersExtender" runat="server" BehaviorID="txtFirstName_RoundedCornersExtender" TargetControlID="txtFirstName">
                </ajaxToolkit:RoundedCornersExtender>
            </td>
        </tr>
        <tr>
            <td  >
                <asp:Label ID="lblLastName" runat="server" Text="Last Name :"></asp:Label>
            </td>
            <td  >
                <asp:TextBox ID="txtLastName" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <ajaxToolkit:RoundedCornersExtender ID="txtLastName_RoundedCornersExtender" runat="server" BehaviorID="txtLastName_RoundedCornersExtender" TargetControlID="txtLastName">
                </ajaxToolkit:RoundedCornersExtender>
            </td>
        </tr>
        <tr>
            <td  >
                <asp:Label ID="lblDateOfBirth" runat="server" Text="Date Of Birth :"></asp:Label>
            </td>
            <td  >
                <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date" BackColor="#99CCFF" Height="25px" ></asp:TextBox>
               
                <ajaxToolkit:RoundedCornersExtender ID="txtDateOfBirth_RoundedCornersExtender" runat="server" BehaviorID="txtDateOfBirth_RoundedCornersExtender" TargetControlID="txtDateOfBirth">
                </ajaxToolkit:RoundedCornersExtender>
               
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAddress" runat="server" Text="Address :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtAddress" runat="server" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <ajaxToolkit:RoundedCornersExtender ID="txtAddress_RoundedCornersExtender" runat="server" BehaviorID="txtAddress_RoundedCornersExtender" TargetControlID="txtAddress">
                </ajaxToolkit:RoundedCornersExtender>
            </td>
        </tr>
        <tr>
            <td  >
                <asp:Label ID="lblLandLineNumber" runat="server" Text="Landline Number :"></asp:Label>
            </td>
            <td  >
                <asp:TextBox ID="txtLandlineNumber" runat="server" TextMode="Phone" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <ajaxToolkit:RoundedCornersExtender ID="txtLandlineNumber_RoundedCornersExtender" runat="server" BehaviorID="txtLandlineNumber_RoundedCornersExtender" TargetControlID="txtLandlineNumber">
                </ajaxToolkit:RoundedCornersExtender>
            </td>
        </tr>
        <tr>
            <td  >
                <asp:Label ID="lblMobileNumber" runat="server" Text="Mobile Number :"></asp:Label>
            </td>
            <td  >
                <asp:TextBox ID="txtMobileNumber" runat="server" TextMode="Phone" BackColor="#99CCFF" Height="25px"></asp:TextBox>
                <ajaxToolkit:RoundedCornersExtender ID="txtMobileNumber_RoundedCornersExtender" runat="server" BehaviorID="txtMobileNumber_RoundedCornersExtender" TargetControlID="txtMobileNumber">
                </ajaxToolkit:RoundedCornersExtender>
            </td>
        </tr>
        <tr>
            <td  >
                <asp:Label ID="lblAreaOfInterest" runat="server" Text="Area Of Interest :"></asp:Label>
            </td>
            <td  >
                <asp:CheckBoxList ID="chkAreaOfInterestList" runat="server" DataSourceID="ObjectDataSource1" DataTextField="DisciplineName" DataValueField="DisciplineName" RepeatDirection="Horizontal">
                </asp:CheckBoxList>
                <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetAll" TypeName="ElibManagementSystem_BusinessLogicLayer.DisciplinesBLL"></asp:ObjectDataSource>
            </td>
        </tr>
        <tr>
            <td  >
                <asp:Label ID="lblGender" runat="server" Text="Gender :"></asp:Label>
            </td>
            <td  >
                <asp:RadioButtonList ID="rdoGenderGroup" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblUserType" runat="server" Text="User Type :"></asp:Label>
            </td>
            <td>
                <asp:RadioButtonList ID="rdoUserTypeGroup" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem>Subscriber</asp:ListItem>
                    <asp:ListItem Value="Non_Subscriber">Non-Subscriber</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td  >
                &nbsp;</td>
            <td  >
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btnUpdate" runat="server" Text="Update Details" OnClick="btnUpdate_Click" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="123px"/>
                <ajaxToolkit:RoundedCornersExtender ID="btnUpdate_RoundedCornersExtender" runat="server" BehaviorID="btnUpdate_RoundedCornersExtender" TargetControlID="btnUpdate">
                </ajaxToolkit:RoundedCornersExtender>
&nbsp;<asp:Button ID="btnEditDetails" runat="server" OnClick="btnEditDetails_Click" Text="Edit Details" Height="40px"  BackColor="#00CCFF" BorderColor="#003399" Width="123px"/>
                <ajaxToolkit:RoundedCornersExtender ID="btnEditDetails_RoundedCornersExtender" runat="server" BehaviorID="btnEditDetails_RoundedCornersExtender" TargetControlID="btnEditDetails">
                </ajaxToolkit:RoundedCornersExtender>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Label ID="lblUpdateMessage" runat="server"></asp:Label>
                <br />
                <br />
          
                <br />
               
            </td>
        </tr>
    </table>

    </div>
</asp:Content>
