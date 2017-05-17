<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ListCharities.aspx.cs" Inherits="CharityProject_rbro752.WebForms.ListCharities" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Our Supported Charities</h1>
        <h2>Placeholder Charity list page</h2>
    </div>
    
    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal">
        <ItemTemplate>
            <asp:Label ID="lblCharityName" runat="server" Text="CharityName" Font-Size="Large"></asp:Label>
            <br />
            <asp:Label ID="Label1" runat="server" Text="Address: "></asp:Label>
            <asp:Label ID="lblAddress" runat="server" Text="Label"></asp:Label>
            <br />
            Open Hours:
            <asp:Label ID="lblOpenHours" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Contact Information:<br /> Phone:
            <asp:Label ID="lblPhone" runat="server" Text="Label"></asp:Label>
            <br />
            Email:
            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            Website:<br /> URL:
            <asp:HyperLink ID="lnkWebsite" runat="server">HyperLink</asp:HyperLink>
        </ItemTemplate>
         
    </asp:DataList>
    
</asp:Content>
