<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Admin_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <title>مدیریت</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">
    <asp:GridView ID="DgvMembers" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" EnableModelValidation="True" ForeColor="Black" 
        GridLines="Vertical" Width="600px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Username" HeaderText="نام کاربری" ReadOnly="True" 
                SortExpression="Username" />
            <asp:BoundField DataField="DisplayName" HeaderText="نام نمایشی" ReadOnly="True" 
                SortExpression="DisplayName" />
            <asp:BoundField DataField="GoogleEmail" HeaderText="پست گوگلی" ReadOnly="True" 
                SortExpression="GoogleEmail" />
            <asp:BoundField DataField="YahooEmail" HeaderText="پست یاهو" ReadOnly="True" 
                SortExpression="YahooEmail" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Default.aspx?DeleteId={0}" HeaderText="حذف" 
                Text="حذف" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Default.aspx?ResetPass={0}" 
                HeaderText="رمز عبور جدید" Text="بازنشانی رمز عبور" Visible="False" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" 
            CssClass="menus" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
</asp:Content>

