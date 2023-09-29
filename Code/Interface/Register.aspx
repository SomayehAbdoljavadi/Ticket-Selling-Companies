<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.master" AutoEventWireup="true"
    CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphHeader" runat="Server">
    <title>ثبت نام</title>
    <style type="text/css">
        .style1
        {
            width: 82px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" runat="Server">
    <table width="100%">
        <tr>
            <td class="style1">
                <asp:Label ID="Label1" runat="server" Text="نام کاربری : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label2" runat="server" Text="رمز عبور : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label8" runat="server" Text="تکرار رمز عبور : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label3" runat="server" Text="نام نمایشی : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtDisplayName" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label4" runat="server" Text="پست گوگلی : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtGoogleEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label5" runat="server" Text="پست یاهو : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtYahooEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label6" runat="server" Text="پست MSN : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtMSNEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Label ID="Label7" runat="server" Text="پست دیگر : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TxtOtherEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="BtnRegister" runat="server" Text="ثبت نام" 
                    onclick="BtnRegister_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div id="DivRegisterResPonds" runat="server">
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
