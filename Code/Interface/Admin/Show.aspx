<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/AdminMasterPage.master" AutoEventWireup="true" CodeFile="Show.aspx.cs" Inherits="Admin_Show" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CphMain" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="Username" DataSourceID="SqlDataSource1" 
    EnableModelValidation="True">
    <Columns>
        <asp:BoundField DataField="Username" HeaderText="Username" ReadOnly="True" 
            SortExpression="Username" />
        <asp:BoundField DataField="GoogleEmail" HeaderText="GoogleEmail" 
            SortExpression="GoogleEmail" />
        <asp:BoundField DataField="DisplayName" HeaderText="DisplayName" 
            SortExpression="DisplayName" />
    </Columns>
</asp:GridView>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
    ConnectionString="<%$ ConnectionStrings:DB_AgencyConnectionString %>" 
    SelectCommand="SELECT     TBMembers.Username, TBMembers.GoogleEmail, TBMembers.DisplayName
FROM         TBTicket INNER JOIN
                      TBMembers ON TBTicket.ID = TBMembers.ID WHERE ([Tour] = @Tour)">
    <SelectParameters>
        <asp:QueryStringParameter Name="Tour" QueryStringField="id" />
    </SelectParameters>
</asp:SqlDataSource>
</asp:Content>

