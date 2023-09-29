<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="City.aspx.cs" Inherits="Admin_City" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>شهر ها</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" runat="Server">
    <asp:GridView ID="DgvCity" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
        GridLines="Vertical" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ردیف" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="نام شهر" ReadOnly="True" SortExpression="Name" />
            <asp:HyperLinkField DataNavigateUrlFields="ID,CountryID" 
                DataNavigateUrlFormatString="City.aspx?CountryId={1}&amp;DeleteId={0}" 
                HeaderText="حذف" Text="حذف" />
            <asp:HyperLinkField DataNavigateUrlFields="ID,CountryID" 
                DataNavigateUrlFormatString="City.aspx?CountryId={1}&amp;EditId={0}" 
                HeaderText="ویرایش" Text="ویرایش" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
            CssClass="menus" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <div id="DivCityError" runat="server">
    </div>
    <table>
        <tr>
            <td>
                نام :
            </td>
            <td>
                <asp:HiddenField ID="HdfID" runat="server" onvaluechanged="HdfID_ValueChanged" 
                    Value="0" />
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
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
