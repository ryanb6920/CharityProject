<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CharityProject_rbro752._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Useless Is Useful</h1>
        <h2>Sign Up Now!</h2>

        <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <a runat="server" class="btn btn-default" href="Webforms/DonorSignUp.aspx">
                        <h2>Sign In</h2>
                    </a>
                </div>
                <div class="col-sm-4">
                    <a runat="server" class="btn btn-default" href="Webforms/DonorSignUp.aspx">
                        <h2>Donor Sign Up</h2>
                    </a>
                </div>
                <div class="col-sm-4">
                    <a runat="server" class="btn btn-default" href="Webforms/CharitySignUp.aspx">
                        <h2>Charity Sign Up</h2>
                    </a>
                </div>
            </div>
        </div>

    </div>

    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <a runat="server" class="btn btn-default" href="Webforms/RequestPickup.aspx">
                    <h2>Request a Pickup</h2>
                </a>
            </div>
            <div class="col-sm-4">
                <a runat="server" class="btn btn-default" href="Webforms/ListCharities.aspx">
                    <h2>View our Charities</h2>
                </a>
            </div>
            <div class="col-sm-4">
                <a runat="server" class="btn btn-default" href="Webforms/DonationManagement.aspx">
                    <h2>Manage Your Donation</h2>
                </a>
            </div>
        </div>
    </div>


</asp:Content>
