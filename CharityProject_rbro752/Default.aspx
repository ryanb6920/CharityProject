<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CharityProject_rbro752._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Useless Is Useful</h1>
        <h2>Sign Up Now!</h2>       

    </div>

    <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <form action="WebForms/SignIn.aspx">
                    <div class="form-group">
                        <input type="submit" value="Sign In" class="btn btn-default center-block"  />
                    </div>
                </form>
                </div>
                <div class="col-sm-4">
                    <form action="WebForms/DonorSignUp.aspx">
                    <div class="form-group">
                        <input type="submit" value="Donor Sign Up" class="btn btn-default center-block" />
                    </div>
                </form>
                </div>
                <div class="col-sm-4">
                    <form action="WebForms/CharitySignUp.aspx">
                    <div class="form-group">
                        <input type="submit" value="Charity Sign Up" class="btn btn-default center-block" />
                    </div>
                </form>
                </div>
            </div>
        </div>

    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <form action="WebForms/ListCharities.aspx">
                    <div class="form-group">
                        <input type="submit" value="Charity Lists" class="btn btn-default center-block" />
                    </div>
                </form>
            </div>
            <div class="col-sm-4">
                <form action="WebForms/RequestPickup.aspx">
                    <div class="form-group">
                        <input type="submit" value="Request a Pick Up" class="btn btn-default center-block" />
                    </div>
                </form>
            </div>
            <div class="col-sm-4">
                <form action="WebForms/DonationManagement.aspx">
                    <div class="form-group">
                        <input type="submit" value="View Donation Status" class="btn btn-default center-block" />
                    </div>
                </form>
            </div>
        </div>
    </div>


</asp:Content>
