<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CharityProject_rbro752._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <div class="container">
            <div class="row">
                <div class="col-sm-8">
                    <h1>Useless Is Useful</h1>
                    <h2>Sign Up Now!</h2>
                </div>
                <div class="col-sm-2">
                    <a href="http://www.un.org/sustainabledevelopment/poverty/" target="_blank">
                        <img src="../images/E_SDG_Icons-01.jpg" width="150px" />
                    </a>
                </div>
                <div class="col-sm-2">
                    <a href="http://www.un.org/sustainabledevelopment/hunger/" target="_blank">
                        <img src="../images/E_SDG_Icons-02.jpg" width="150px" />
                    </a>
                </div>
            </div>
        </div>
        <br />

    </div>

        <div class="container">
        <div class="row">
            <div class="col-sm-4">
                <form action="WebForms/SignIn.aspx">
                    <div class="form-group">
                        <input type="submit" value="Sign In" class="btn btn-default center-block" />
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
    

    <ul  class="nav nav-tabs">
        <li class="active"><a href="#aboutUs" data-toggle="tab" aria-expanded="true">About Us</a></li>
        <li class=""><a href="#inspiration" data-toggle="tab" aria-expanded="false">What Inspired Us</a></li>
        <li class=""><a href="#contact" data-toggle="tab" aria-expanded="false">Contact Us</a></li>   
    </ul>
    <div id="myTabContent" class="tab-content">       
        <div class="tab-pane fade active in" id="aboutUs">
            <p>
                Here at Useless is Useful we aim to provide a swift and easy and reliable donation service for everyone to use. 
            If you have the items, we will arange the pickup/dropoff and recycling for you to make the process as hands free as possible. 
            We take anything that is reusable or recyclable, sort through it at our depot, then we drop off the reusable items at the selected charity 
            of your choice and take your recyclable items to the local recycling centre for proper disposal.
            </p>
        </div>
        <div class="tab-pane " id="inspiration">
            <p>
                Our whole company is inspired by the 
                <a href="http://www.un.org/sustainabledevelopment/sustainable-development-goals/" target="_blank">United Nation's Sustainable Development Goals.
                </a>
                We care about our planet and the people on it. 
                Our service's goal is to help end poverty and hunger in New Zealand and eventually branch out and help all over the globe.
            </p>
        </div>
        <div class="tab-pane fade" id="contact">
            If you have an question or if you would like to work for us:
            <br />
            Please contact Ryan Brown or come visit us at our office:
            <br /><br />
            Phone: 09 123 4567 <br />
            Email: rbro752@aucklanduni.ac.nz <br />
            Address: 123 Test Avenue, Test Suburb, Auckland 1010
        </div>
    </div>
    <br />
    
</asp:Content>
