<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CharityProject_rbro752._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Useless Is Useful</h1>
        <h2>Sign Up Now!</h2>

        <div class="container">
            <div class="row">
                <div class="col-sm-4">
                    <form action="SignIn.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Sign In" class="btn btn-default" />
                    </div>
                </form>
                </div>
                <div class="col-sm-4">
                    <form action="DonorSignUp.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Donor Sign Up" class="btn btn-default" />
                    </div>
                </form>
                </div>
                <div class="col-sm-4">
                    <form action="CharitySignUp.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Charity Sign Up" class="btn btn-default" />
                    </div>
                </form>
                </div>
            </div>
        </div>

    </div>

    <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <form action="ListCharities.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Charity Lists" class="btn btn-default" />
                    </div>
                </form>
            </div>
            <div class="col-sm-4">
                <form action="RequestPickup.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Request a Pick Up" class="btn btn-default" />
                    </div>
                </form>
            </div>
            <div class="col-sm-4">
                <form action="CharitySignUp.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="View Donation Status" class="btn btn-default" />
                    </div>
                </form>
            </div>
        </div>
    </div>


</asp:Content>
