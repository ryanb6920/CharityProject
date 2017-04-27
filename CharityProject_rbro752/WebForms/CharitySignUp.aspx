<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CharitySignUp.aspx.cs" Inherits="CharityProject_rbro752.WebForms.CharitySignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up - Charity</title>
    <link href="../Content/Cosmo.css" rel="stylesheet" />
    <link href="../Content/Custom.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row">

            <!-- Logo Goes Here -->            
            <div class="logo col-sm-2">
                <img src="../images/logo.jpg" width="150px" />
            </div>

            <!-- Title/Slogan -->
            <div class="col-sm-10">
                <h1 id="CharitySlogan">Useless is Useful - Donate Now!</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-1"></div>
            <!-- Left Form -->
            <div class="col-sm-5">
                <form id="SignIn" runat="server">
                    <h2>Sign Up - Donor</h2>
                    <!-- Charity Name Input -->
                    <div class="form-group">
                        <label for="charityNameTxt">Charity Name:</label>
                        <input type="text" id="charityNameTxt" placeholder="Charity Name" class="form-control" required="required" runat="server"/>
                    </div>

                    <!-- Email Input -->
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="email" id="emailSignIn" placeholder="Enter Charity Email" class="form-control" required="required" runat="server"/>                   
                    </div>

                    <!-- Website URL Input-->
                    <div class="form-group">
                        <label for="websiteURL">Website URL (Optional):</label>
                        <input type="text" id="websiteURL" placeholder="Enter Website URL" class="form-control" runat="server"/>                   
                    </div>
                   
                    <!-- Contact Number Input -->
                    <div class="form-group">
                        <label for="contact">Contact Number:</label>
                        <input type="text" id="charityContactNumber" placeholder="Contact Number" class="form-control" required="required" runat="server"/>
                    </div>

                    <!-- Opening Hours Input-->
                    <div class="form-group">
                        <label for="openHours">Opening Hours:</label>
                        <input type="text" id="openHours" placeholder="Opening Hours" class="form-control" required="required" runat="server"/>
                    </div>

                    <!-- Address Input-->
                    <div class="form-group">
                        <label for="address">Address:</label>
                        <input type="text" id="address" placeholder="Address" class="form-control" required="required" runat="server"/>
                    </div>

                    <!-- Password Input -->
                    <div class="form-group">
                        <label for="password">Password:</label>
                        <input type="password" id="passwordSignUp" placeholder="Enter Password" class="form-control" required="required" runat="server"/>
                    </div>
                    <div class="form-group">
                        <label for="password">Confirm Password:</label>
                        <input type="password" id="passwordConfirmSignUp" placeholder="Confirm Password" class="form-control" required="required" runat="server"/>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSignUp" Text="Submit" CssClass="btn btn-success" runat="server" OnClick="btnSignUp_Click">
                    </div>
                </form>
            </div>

            <!-- Right  Form -->
            <div class="col-sm-5">
                <h2>Already signed up?</h2>
                <h4>Sign in now!</h4>

                <!-- Donor Sign up Link -->
                <!--<a href="DonorSignUp.aspx">Sign up as a Donor!</a><br />-->
                <form action="SignIn.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Sign In" class="btn"/>
                    </div>
                </form>
                <!-- Charity Sign up Link -->
                <!--<a href="CharitySignUp.aspx">Sign up as a Charity!</a>-->
                
                <h2>Want to register as a Donor?</h2>
                <form action="DonorSignUp.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Donor Sign Up" class="btn" />
                    </div>
                </form>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>
</body>
</html>
