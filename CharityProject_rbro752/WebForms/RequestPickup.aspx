<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestPickup.aspx.cs" Inherits="CharityProject_rbro752.WebForms.RequestPickup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="logo col-sm-2">
                <img src="../images/logo.jpg" width="150" />
            </div>
            <div class="col-sm-10">
                <h1 id="CharitySlogan">Useless is Useful - Donate Now!</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-2"></div>

            <div class="col-sm-4">

                <div class="form-group">
                    <label for="textArea">Pickup Address</label>
                    <textarea class="form-control" rows="4" id="pickupAddress"></textarea>

                </div>

                <div class="form-group">
                    <label for="inputPickupDate">Pickup Date</label>
                    <input type="date" id="inputPickupDate" class="form-control" runat="server"/>
                </div>

                <div class="form-group">
                    <label for="inputPickupTime">Pickup Time</label>
                    <input type="text" id="inputPickupTime" class="form-control" runat="server"/>
                </div>

            </div>

            <div class="col-lg-4">
                <div class="form-group">
                    <label for="donationType">Donation Category</label>
                    <select class="form-control" id="donationType" runat="server">
                        <option>Clothes</option>
                        <option>Food</option>
                        <option>Toys</option>
                        <option>Electronics</option>
                        <option>Books</option>
                        <option>Other</option>
                    </select>
                </div>

                <div class="form-group">
                    <label for="selectCharity">Select Charity</label>
                    <select class="form-control" id="selectCharity" runat="server">
                        
                    </select>
                </div>
                            
                <asp:Button ID="btnSubmitPickupRequest" Text="Submit" CssClass="btn btn-success" runat="server" OnClick="btnSubmitPickupRequest_Click" />
                
                <h4>Want to find out more about our charities?</h4>
                <a href="ListCharities.aspx" class="btn btn-default" target="_blank">Click Here!</a>
                
                
            </div>
            <div class="col-sm-2"></div>
        </div>

        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6"></div>
            <div class="col-sm-3"></div>
        </div>
    </div>

</asp:Content>
