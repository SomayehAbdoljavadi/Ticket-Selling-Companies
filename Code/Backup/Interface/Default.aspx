<%@ Page Title="" Language="C#" MasterPageFile="~/HomeMaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CphHeader" runat="Server">
    <title>صفحه ی اصلی</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" runat="Server">
    <div id="DivDefaultError" runat="server">
    </div>
        بلیت های صادر شده برای شما :
    <asp:GridView ID="DgvReserves" runat="server" AutoGenerateColumns="False" 
        BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" EnableModelValidation="True" ForeColor="Black" 
        GridLines="Vertical">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ردیف" ReadOnly="True" 
                SortExpression="ID" />
            <asp:BoundField DataField="Tour" HeaderText="شماره ی بلیت" ReadOnly="True" 
                SortExpression="Tour" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="default.aspx?DeleteId={0}" HeaderText="حذف" 
                Text="حذف" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
        <br />
    <div id="DivSelect" runat="server">
        <table width="100%">
            <tr>
                <td class="RightTd">
                    نام تور :
                </td>
                <td>
                    <div id="DivTourName" runat="server">
                        <asp:HiddenField ID="HdfID" runat="server" Value="0" />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    نام هتل :
                </td>
                <td>
                    <div id="DivHotel" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    نوع هواپیما :
                </td>
                <td>
                    <div id="DivAirPlane" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    هزینه ی تور :
                </td>
                <td>
                    <div id="DivPrice" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    تعداد روز های تور :
                </td>
                <td>
                    <div id="DivDays" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    تعداد شب های تور :
                </td>
                <td>
                    <div id="DivNights" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    محل تور :
                </td>
                <td>
                    <div id="DivPlace" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    تاریخ تور :
                </td>
                <td>
                    <div id="DivDate" runat="server">
                    </div>
                </td>
            </tr>
            <tr>
                <td class="RightTd">
                    <a href="Default.aspx">انصراف</a>
                </td>
                <td style="direction: ltr;">
                    <asp:Button ID="BtnSelect" runat="server" Text="انتخاب" 
                        onclick="BtnSelect_Click" />
                </td>
            </tr>
        </table>
    </div>
        <br />
        بلیت های موجود : 
    <asp:GridView ID="DgvTour1" runat="server" AutoGenerateColumns="False" BackColor="White"
        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" 
        CellPadding="3" EnableModelValidation="True"
        ForeColor="Black" GridLines="Vertical" Width="100%" DataKeyNames="id" 
        DataSourceID="SqlDataSourcedgv">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="نام" SortExpression="Name" />
            <asp:BoundField DataField="Price" HeaderText="قیمت" SortExpression="Price" />
            <asp:BoundField DataField="LengthDays" HeaderText="روز" 
                SortExpression="LengthDays" />
            <asp:BoundField DataField="lengthNights" HeaderText="شب" 
                SortExpression="lengthNights" />
            <asp:BoundField DataField="Date" HeaderText="تاریخ" SortExpression="Date" />
            <asp:BoundField DataField="Country" HeaderText="کشور" 
                SortExpression="Country" />
            <asp:BoundField DataField="City" HeaderText="شهر" SortExpression="City" />
            <asp:BoundField DataField="Dev" HeaderText="وسیله" SortExpression="Dev" />
            <asp:HyperLinkField DataNavigateUrlFields="ID" 
                DataNavigateUrlFormatString="Default.aspx?SelectedId={0}" HeaderText="انتخاب" 
                Text="انتخاب" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" CssClass="menus" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourcedgv" runat="server" 
        ConnectionString="<%$ ConnectionStrings:DB_AgencyConnectionString %>" SelectCommand="SELECT     TBTour.Name, TBTour.Price, TBTour.LengthDays, TBTour.lengthNights, TBTour.Date, TBCountry.Name AS Country, TBCity.Name AS City, 
                      TBAirPlane.Name AS Dev,TBTour.Id as id 
FROM         TBCountry RIGHT OUTER JOIN
                      TBTour LEFT OUTER JOIN
                      TBCity ON TBTour.City = TBCity.ID ON TBCountry.ID = TBCity.CountryID LEFT OUTER JOIN
                      TBAirPlane ON TBTour.AirPlane = TBAirPlane.ID
WHERE     (TBAirPlane.DevId =@Dev) OR @Dev=0">
        <SelectParameters>
            <asp:QueryStringParameter Name="dev" QueryStringField="Id" DefaultValue="0" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
