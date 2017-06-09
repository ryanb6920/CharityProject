<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CharityProject_rbro752._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <img src="../images/carousel-pic-hunger.jpg" alt="hunger">
                <div class="carousel-caption">
                    <h2>Hunger</h2>
                    
                </div>
            </div>

            <div class="item">
                <img src="../images/carousel-pic-poverty.jpg" alt="poverty">
                <div class="carousel-caption">
                    <h2>Poverty</h2>
                    
                </div>
            </div>

            <div class="item">
                <img src="../images/carousel-pic-unitednations.jpg" alt="United Nations">
                <div class="carousel-caption">
                    <h2>United Nations</h2>
                    <p>Plan to stop this by 2030</p>
                </div>
            </div>
        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="glyphicon glyphicon-chevron-left"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="glyphicon glyphicon-chevron-right"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>




    <h1 style="font-size: 100px;">Sign Up Now!</h1>
    <br />
    <br />
    <div class="btn-group btn-group-justified">
        <a class="btn btn-default btn-home-page-link" id="SignInLink" runat="server" href="WebForms/SignIn.aspx">Sign In</a>
        <a class="btn btn-default btn-home-page-link" href="WebForms/DonorSignUp.aspx">Donor Sign Up</a>
        <a class="btn btn-default btn-home-page-link" href="WebForms/CharitySignUp.aspx">Charity Sign Up</a>
    </div>
    <br />
    <div class="container">
        <div class="row">
            <div class="col-sm-8">
                <ul class="nav nav-tabs">
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
            <br />
                        <br />
                        Phone: 09 123 4567
                            <br />
                        Email: rbro752@aucklanduni.ac.nz
                            <br />
                        Address: 123 Test Avenue, Test Suburb, Auckland 1010
                    </div>
                </div>


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







    <br />

</asp:Content>
