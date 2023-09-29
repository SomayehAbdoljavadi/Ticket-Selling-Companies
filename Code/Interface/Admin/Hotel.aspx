<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="Hotel.aspx.cs" Inherits="Admin_Hotel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>هتل</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" runat="Server">
    <asp:GridView ID="DgvHotel" runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" BackColor="White" BorderColor="#999999" 
        BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" 
        GridLines="Vertical" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ردیف" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="نام هتل" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Address" HeaderText="آدرس" ReadOnly="True" SortExpression="Address" />
            <asp:BoundField DataField="Tell" HeaderText="تلفن" ReadOnly="True" SortExpression="Tell" />
            <asp:BoundField DataField="Description" HeaderText="توضیحات" ReadOnly="True" SortExpression="Description" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Hotel.aspx?DeleteId={0}" HeaderText="حذف" 
                Text="حذف" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Hotel.aspx?EditId={0}" HeaderText="ویرایش" 
                Text="ویرایش" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" CssClass="menus" Font-Bold="True" 
            ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <div id="DivHotelError" runat="server">
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
                ستاره :
            </td>
            <td>
                <asp:DropDownList ID="DdlStars" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                آدرس :
            </td>
            <td>
                <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
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
                <asp:DropDownList ID="DdlCity" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                تلفن :
            </td>
            <td>
                <asp:TextBox ID="TxtTell" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                توضيحات :
            </td>
            <td>
                <asp:TextBox ID="TxtDescription" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Btn_Ok" runat="server" onclick="Btn_Ok_Click" Text="ثبت" 
                    Width="51px" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
