<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Tour.aspx.cs" Inherits="Admin_Tour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>تور ها</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" runat="Server">
    <asp:GridView ID="DgvTour" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
        ForeColor="Black" GridLines="Vertical" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ردیف" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="نام" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Hotel" HeaderText="هتل" ReadOnly="True" SortExpression="Hotel"
                Visible="False" />
            <asp:BoundField DataField="AirPlane" HeaderText="وسیله ی نقلیه" ReadOnly="True" SortExpression="AirPlane"
                Visible="False" />
            <asp:BoundField DataField="Price" HeaderText="مبلغ" ReadOnly="True" SortExpression="Price" />
            <asp:BoundField DataField="LengthDays" HeaderText="روز ها" ReadOnly="True" SortExpression="LengthDays" />
            <asp:BoundField DataField="lengthNights" HeaderText="شب ها" ReadOnly="True" SortExpression="lengthNights" />
            <asp:BoundField DataField="City" HeaderText="شهر" ReadOnly="True" SortExpression="City"
                Visible="False" />
            <asp:BoundField DataField="Date" HeaderText="تاریخ" ReadOnly="True" SortExpression="Date" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Tour.aspx?DeleteId={0}" HeaderText="حذف" 
                Text="حذف" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Tour.aspx?EditeId={0}" HeaderText="ویرایش" 
                Text="ویرایش" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Show.aspx?Id={0}" HeaderText="نمایش" 
                Text="نمایش" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" CssClass="menus" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <div id="DivTourError" runat="server">
    </div>
    <table>
        <tr>
            <td>
                نام :
            </td>
            <td>
                <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                <asp:HiddenField ID="HdfID" runat="server" Value="0" />
            </td>
        </tr>
        <tr>
            <td>
                هتل :
            </td>
            <td>
                <asp:DropDownList ID="DdlHotel" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                وسيله ی نقلیه :
            </td>
            <td>
                <asp:DropDownList ID="DdlAirPlane" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                مبلغ :
            </td>
            <td>
                <asp:TextBox ID="TxtPrice" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                روز ها :
            </td>
            <td>
                <asp:TextBox ID="TxtLengthDays" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                شب ها :
            </td>
            <td>
                <asp:TextBox ID="TxtlengthNights" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                شهر :
            </td>
            <td>
                <asp:DropDownList ID="DdlCountry" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DdlCountry_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:DropDownList ID="DdlCity" runat="server" AutoPostBack="True" 
                    onselectedindexchanged="DdlCity_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                تاریخ :
            </td>
            <td>
                <asp:TextBox ID="TxtDate" runat="server" MaxLength="10"></asp:TextBox>
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
