<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DonorSignUp.aspx.cs" Inherits="CharityProject_rbro752.WebForms.DonorSignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up - Donor</title>
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
                    <!-- Full Name Input -->
                    <div class="form-group">
                        <label for="fullName">Full Name:</label>
                        <input type="text" id="fullNameTxt" placeholder="Full Name" class="form-control" required="required" runat="server"/>
                    </div>
                    <!-- Email Input -->
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="email" id="emailSignIn" placeholder="Enter Email" class="form-control" required="required" runat="server"/>                   
                    </div>
                    <!-- Password Input -->
                    <div class="form-group">
                        <label for="password">Password:</label>
                        <input type="password" id="passwordSignUp" placeholder="Enter Password" class="form-control" required="required" runat="server"/>
                    </div>
                    <div class="form-group">
                        <label for="password">Password:</label>
                        <input type="password" id="passwordConfirmSignUp" placeholder="Confirm Password" class="form-control" required="required" runat="server"/>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSignUp" Text="Submit" CssClass="btn btn-success" runat="server" OnClick="btnSignUp_Click"/>
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
                
                <h2>Want to register your Charity?</h2>
                <form action="CharitySignUp.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Charity Sign Up" class="btn" />
                    </div>
                </form>
            </div>
            <div class="col-sm-1"></div>
        </div>
    </div>
</body>
</html>
