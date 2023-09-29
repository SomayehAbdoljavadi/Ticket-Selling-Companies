<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Country.aspx.cs" Inherits="Admin_Country" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>کشور</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" runat="Server">
    <asp:GridView ID="DgvCountry" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
        GridLines="Vertical" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ردیف" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="نام کشور" ReadOnly="True" SortExpression="Name" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Country.aspx?EditId={0}" HeaderText="ویرایش" 
                Text="ویرایش" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Country.aspx?DeleteId={0}" HeaderText="حذف" 
                Text="حذف" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="City.aspx?CountryID={0}" HeaderText="ورایش شهر" 
                Text="شهرهای کشور" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
            CssClass="menus" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <div id="DivCountryError" runat="server"></div>
    <table>
        <tr>
            <td>
                نام کشور :
            </td>
            <td>
                <asp:HiddenField ID="HdfID" runat="server" Value="0" />
                <asp:TextBox ID="txt_Name" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                پایتخت کشور :
            </td>
            <td>
                <asp:DropDownList ID="DdlCity" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="BtnOk" runat="server" Text="ثبت" onclick="BtnOk_Click" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
