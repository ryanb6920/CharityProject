<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RequestPickup.aspx.cs" Inherits="CharityProject_rbro752.WebForms.RequestPickup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-12">
                <h1>Request Pickup</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-sm-1"></div>
            <div class="col-sm-5">
                <form id="requestPickup">
                    <div class="form-group">
                        <label for="textArea">Pickup Address</label>
                        <textarea class="form-control" cols="5" id="pickupAddress" required="required" runat="server"></textarea>
                    </div>
                    <div class="form-group">
                        <label for="inputPickupDate">Pickup Date</label>
                        <input type="date" id="inputPickupDate" class="form-control" required="required" runat="server" />
                    </div>
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
                        <select class="form-control" id="selectCharity" required="required" runat="server">
                        </select>
                    </div>
                    <asp:Button ID="btnSubmitPickupRequest" Text="Submit" CssClass="btn btn-success" runat="server" OnClick="btnSubmitPickupRequest_Click" />
                </form>
            </div>
            <div class="col-sm-5">
                <h4>Want to find out more about our charities?</h4>
                <a href="ListCharities.aspx" class="btn btn-default" target="_blank">Click Here!</a>
            </div>
            <div class="col-sm-1"></div>
        </div>

    </div>

</asp:Content>
