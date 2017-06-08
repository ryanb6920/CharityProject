<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="CharityProject_rbro752.WebForms.SignIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign In</title>
    
    <link href="../Content/Cosmo.css" rel="stylesheet" />
    <link href="../Content/Custom.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row">

            <!-- Logo Goes Here -->            
            <div class="logo col-sm-2">
                <a href="../Default.aspx">
                    <img src="../images/logo.jpg" width="150px" />
                </a>
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
                    <h2>Sign In</h2>
                    <!-- Email Input -->
                    <div class="form-group">
                        <label for="email">Email:</label>
                        <input type="email" id="emailSignIn" placeholder="Enter Email" class="form-control" required="required" runat="server"/>
                    </div>
                    <!-- Password Input -->
                    <div class="form-group">
                        <label for="password">Password:</label>
                        <input type="password" id="passwordSignIn" placeholder="Enter Password" class="form-control" required="required" runat="server"/>
                    </div>
                    <div class="form-group">
                        <asp:Button ID="btnSignIn" Text="Submit" CssClass="btn btn-success" runat="server" OnClick="btnSignIn_Click"/>
                    </div>
                </form>
            </div>

            <!-- Right  Form -->
            <div class="col-sm-5">
                <h2>Not a Member?</h2>
                <h4>Sign up now!</h4>

                <!-- Donor Sign up Link -->
                <!--<a href="DonorSignUp.aspx">Sign up as a Donor!</a><br />-->
                <form action="DonorSignUp.aspx" target="_blank">
                    <div class="form-group">
                        <input type="submit" value="Donor Sign Up" class="btn"/>
                    </div>
                </form>
                <!-- Charity Sign up Link -->
                <!--<a href="CharitySignUp.aspx">Sign up as a Charity!</a>-->
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
