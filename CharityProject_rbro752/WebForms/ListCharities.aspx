<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCharities.aspx.cs" Inherits="CharityProject_rbro752.WebForms.ListCharities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Our Supported Charities</h1>
        <h2>Placeholder Charity list page</h2>
    </div>

    <asp:DataList ID="CharityDataList" runat="server" RepeatDirection="Horizontal" DataSourceID="CharityProjectDB" BorderColor="Black" CellPadding="5" GridLines="Both" HorizontalAlign="Center" RepeatColumns="4" ShowFooter="False" ShowHeader="False">
        <ItemTemplate>
            <asp:Label ID="lblCharityName" runat="server" Text='<%# Eval("CharityName") %>' Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Address: "></asp:Label>
            <asp:Label ID="lblAddress" runat="server" Text='<%# Eval("Address") %>'></asp:Label>
            <br />
            Open Hours:
            <asp:Label ID="lblOpenHours" runat="server" Text='<%# Eval("OpenHours") %>'></asp:Label>
            <br />
            <br />
            Contact Information:<br />
            Phone:
            <asp:Label ID="lblPhone" runat="server" Text='<%# Eval("PhoneNo") %>'></asp:Label>
            <br />
            Email:
            <asp:Label ID="lblEmail" runat="server" Text='<%# Eval("Email") %>'></asp:Label>
            <br />
            <br />
            Website:<br />
            URL:
            <asp:HyperLink ID="lnkWebsite" runat="server" NavigateUrl='<%# Eval("URL") %>' Text='<%# Eval("URL") %>'></asp:HyperLink>
            
        </ItemTemplate>

        <SeparatorStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Justify" VerticalAlign="Middle" />

    </asp:DataList>

    <asp:SqlDataSource ID="CharityProjectDB" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CharityName], [Email], [URL], [PhoneNo], [OpenHours], [Address] FROM [Charities]"></asp:SqlDataSource>

</asp:Content>
