using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;
using System.Data.SqlClient;

namespace CharityProject_rbro752.WebForms
{
    public partial class RequestPickup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Globals.signedInUser == null || Globals.signedInUser.UserType != "Donor")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('You must be signed in as a Donor to access this page'); window.location.href = 'SignIn.aspx';", true);
                Response.Redirect("SignIn.aspx");
            }
            if (!IsPostBack)
            {
                BLL objBLL = new BLL();
                selectCharity.DataSource = objBLL.GetCharities();
                selectCharity.DataTextField = "CharityName";
                selectCharity.DataValueField = "Id";
                selectCharity.DataBind();
            }
        }

        protected void btnSubmitPickupRequest_Click(object sender, EventArgs e)
        {
            int output;
            BLL objBLL = new BLL();
            Donation objDonation = new Donation();
            objDonation.DonorId = Globals.signedInDonor.Id;
            objDonation.Category = donationType.Value;
            objDonation.PickupAddress = pickupAddress.Value;
            objDonation.PickupDate = Convert.ToDateTime(inputPickupDate.Value);
            objDonation.Recipient = Convert.ToInt32(selectCharity.Value);
            objDonation.Status = "Awaiting Pickup";

            output = objBLL.RequestPickupBLL(objDonation);

            if (output > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Pickup Request Submitted'); window.location.href = 'RequestPickup.aspx';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Pickup Request Failed'); window.location.href = 'RequestPickup.aspx';", true);
            }
        }
    }
}