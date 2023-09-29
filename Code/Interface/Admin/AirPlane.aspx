<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true"
    CodeFile="AirPlane.aspx.cs" Inherits="Admin_AirPlane" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <title>هواپیما ها</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" runat="Server">
    <asp:GridView ID="DgvAirPlane" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" EnableModelValidation="True"
        ForeColor="Black" GridLines="Vertical" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ردیف" ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="نام" ReadOnly="True" SortExpression="Name" />
            <asp:BoundField DataField="Description" HeaderText="توضیحات" ReadOnly="True" SortExpression="Description" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="AirPlane.aspx?DeleteId={0}" HeaderText="حذف" 
                Text="حذف" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="AirPlane.aspx?EditeId={0}" HeaderText="ویرایش" 
                Text="ویرایش" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" CssClass="menus" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <div id="AirPlaneError" runat="server">
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
                کشور سازنده :
            </td>
            <td>
                <asp:DropDownList ID="DdlCountry" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                نوع وسيله : 
            </td>
            <td>
                <asp:DropDownList ID="Type" runat="server" DataSourceID="SqlDataSourceTypeDev" 
                    DataTextField="Name" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSourceTypeDev" runat="server" 
                    ConnectionString="<%$ ConnectionStrings:DB_AgencyConnectionString %>" 
                    SelectCommand="SELECT [id], [Name] FROM [TBDevice]"></asp:SqlDataSource>
            </td>
        </tr>
        <tr>
            <td>
                توضیحات :
            </td>
            <td>
                <asp:TextBox ID="TxtDescription" runat="server" Height="61px" TextMode="MultiLine" Width="360px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Btn_Ok" runat="server" Text="ثبت" Width="51px" 
                    onclick="Btn_Ok_Click" />
            </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>
