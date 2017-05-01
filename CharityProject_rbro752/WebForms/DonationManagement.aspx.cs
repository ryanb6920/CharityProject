using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;

/*
 To alter records on the form you must be signed in as an admin
  
                 Details:    -Email: admin@admin.com 
                             -Password: admin
 */ 

namespace CharityProject_rbro752.WebForms
{
    public partial class DonationManagement : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            BLL objBLL = new BLL();

            if (Globals.signedInUser == null)
            {
                Response.Redirect("SignIn.aspx");
            }
            else
            {
                if(Globals.signedInUser.UserType != "Admin")
                {
                    inputDropOffDate.Disabled = true;
                    noItemsTxt.Disabled = true;
                    noRecItemsTxt.Disabled = true;
                    selectStatus.Disabled = true;
                }
            }
            if (!IsPostBack)
            {                
                donationSelect.DataSource = objBLL.GetDonations();
                donationSelect.DataTextField = "Id";
                donationSelect.DataValueField = "Id";
                donationSelect.DataBind();
                PopulateFields(objBLL.FindDonation(Convert.ToInt32(donationSelect.Value)));
            }
            
        }

        protected void btnUpdateDonation_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(),"alertwindow", string.Format("alert('{0}'); window.location.href = 'DonationManagement.aspx';",inputDropOffDate.Value), true);


            BLL objBLL = new BLL();
            Donation objDonation = new Donation();
            int output = 0;
            objDonation.Id = Convert.ToInt32(donationId.Value);
            if (inputDropOffDate.Value != "")
            {
                objDonation.DropOffDate = Convert.ToDateTime(inputDropOffDate.Value);
            }
            if (noItemsTxt.Value != "")
            {
                objDonation.NoItems = Convert.ToInt32(noItemsTxt.Value);
            }
            if (noRecItemsTxt.Value != "")
            {
                objDonation.NoRecycledItems = Convert.ToInt32(noRecItemsTxt.Value);
            }
            objDonation.Status = selectStatus.Value;

            output = objBLL.DonationUpdateBLL(objDonation);
            if (output > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Update Successful'); window.location.href = 'DonationManagement.aspx';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Update Failed'); window.location.href = 'DonationManagement.aspx';", true);
            }
            PopulateFields(objBLL.FindDonation(Convert.ToInt32(donationSelect.Value)));            
        }

        protected void findDonation_Click(object sender, EventArgs e)
        {
            BLL objBLL = new BLL();
            PopulateFields(objBLL.FindDonation(Convert.ToInt32(donationSelect.Value)));
        }

        void PopulateFields(Donation objDonation)
        {
            noItemsTxt.Disabled = false;
            noRecItemsTxt.Disabled = false;
            inputDropOffDate.Disabled = false;
            selectStatus.Disabled = false;

            donationId.Value = objDonation.Id.ToString();
            donorId.Value = objDonation.DonorId.ToString();
            categoryTxt.Value = objDonation.Category;
            pickupAddress.Value = objDonation.PickupAddress;
            pickupDateTxt.Value = objDonation.PickupDate.ToShortDateString();
            recipientTxt.Value = objDonation.Recipient.ToString();
            inputDropOffDate.Value = objDonation.DropOffDate.ToString();
            noItemsTxt.Value = objDonation.NoItems.ToString();
            noRecItemsTxt.Value = objDonation.NoRecycledItems.ToString();
            selectStatus.Value = objDonation.Status;
            
            if (objDonation.NoItems > 0)
            {
                noItemsTxt.Disabled = true;
            }
                       
            if (objDonation.Status == "Completed" || objDonation.Status == "Cancelled")
            {
                noItemsTxt.Disabled = true;
                noRecItemsTxt.Disabled = true;
                inputDropOffDate.Disabled = true;
                selectStatus.Disabled = true;
            }
            else if(objDonation.Status == "Awaiting Drop Off")
            {
                noItemsTxt.Disabled = true;
                noRecItemsTxt.Disabled = true;
            }
        }
    }
}