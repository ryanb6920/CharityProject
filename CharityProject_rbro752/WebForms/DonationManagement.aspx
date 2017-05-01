<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DonationManagement.aspx.cs" Inherits="CharityProject_rbro752.WebForms.DonationManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-sm-2">
                <img src="../images/logo.jpg" width="150" />
            </div>
            <div class="col-sm-10">
                <h1>Manage Donations</h1>
            </div>

        </div>
        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-4">
                <label for="donationSelect">Donation:</label>
                <select class="form-control" id="donationSelect" runat="server">
                </select>
            </div>
            <div class="col-sm-4">
            </div>
            <div class="col-sm-2"></div>
        </div>

        <div class="row">
            <div class="col-sm-2"></div>
            <div class="col-sm-4">
                <form id="managementFormLeft">
                    <div class="form-group">
                        <label for="donationId">Donation Id:</label>
                        <input class="form-control" id="donationId" placeholder="Id Here" disabled="" type="text">
                    </div>

                    <div class="form-group">
                        <label for="donorId">Donor Id:</label>
                        <input class="form-control" id="donorId" placeholder="Id Here" disabled="" type="text">
                    </div>

                    <div class="form-group">
                        <label for="categoryTxt">Donation Category:</label>
                        <input class="form-control" id="categoryTxt" placeholder="Category" disabled="" type="text">
                    </div>

                    <div class="form-group">
                        <label for="pickupDateTxt">Pickup Date:</label>
                        <input class="form-control" id="pickupDateTxt" placeholder="Category" disabled="" type="text">
                    </div>

                    <div class="form-group">
                        <label for="recipientTxt">Recipient:</label>
                        <input class="form-control" id="recipientTxt" placeholder="Category" disabled="" type="text">
                    </div>
                </form>
            </div>
            <div class="col-sm-4">
                <form id="managementFormRight">
                    <div class="form-group">
                        <label for="inputDropOffDate">Drop Off Date</label>
                        <input type="date" id="inputDropOffDate" class="form-control" runat="server" />
                    </div>

                    <div class="form-group">
                        <label for="noItemsTxt">Number of Items</label>
                        <input class="form-control" id="noItemsTxt" placeholder="Total Items" type="text" runat="server">
                    </div>

                    <div class="form-group">
                        <label for="noRecItemsTxt">Number of Recycled Items</label>
                        <input class="form-control" id="noRecItemsTxt" placeholder="Recycled Items" type="text" runat="server">
                    </div>

                    <div class="form-group">
                        <label for="selectStatus">Status:</label>
                        <select class="form-control" id="selectStatus" runat="server">
                            <option>Awaiting Pickup</option>
                            <option>At Depot</option>
                            <option>Awaiting Pickup Drop Off</option>
                            <option>Completed</option>
                        </select>
                    </div>

                    <asp:Button ID="btnUpdateDonation" Text="Update" CssClass="btn btn-success" runat="server" OnClick="btnUpdateDonation_Click" />


                </form>
            </div>
            <div class="col-sm-2"></div>
        </div>

    </div>

</asp:Content>
