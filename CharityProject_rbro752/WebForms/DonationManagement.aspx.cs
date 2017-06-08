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
        static int currentDonation=1;
        static int currentDonorID = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL objBLL = new BLL();

            if (Globals.signedInUser == null)
            {
                Response.Redirect("SignIn.aspx");
            }
            if (!IsPostBack)
            {
                selectCharity.DataSource = objBLL.GetCharities();
                selectCharity.DataTextField = "CharityName";
                selectCharity.DataValueField = "Id";
                selectCharity.DataBind();


                dropDownSelect.DataSource = objBLL.GetDonations();
                dropDownSelect.DataTextField = "Id";
                dropDownSelect.DataValueField = "Id";
                dropDownSelect.DataBind();
                dropDownSelect.SelectedValue = currentDonation.ToString();
                PopulateFields(objBLL.FindDonation(currentDonation));
            }

        }

        protected void btnUpdateDonation_Click(object sender, EventArgs e)
        {
            //ClientScript.RegisterStartupScript(this.GetType(),"alertwindow", string.Format("alert('{0}'); window.location.href = 'DonationManagement.aspx';",inputDropOffDate.Value), true);
            
            BLL objBLL = new BLL();
            Donation objDonation = new Donation();
            int output = 0;
            objDonation.DonorId = currentDonorID;
            objDonation.Id = Convert.ToInt32(donationId.Value);
            objDonation.Category = categorySelect.Value;
            objDonation.PickupDate = Convert.ToDateTime(pickupDateTxt.Value);
            objDonation.PickupAddress = pickupAddress.Value;
            objDonation.Recipient = Convert.ToInt32(selectCharity.Value);
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
                Donors objDonor = objBLL.FindDonor(objDonation.DonorId);
                Charities objCharity = objBLL.FindCharity(objDonation.Recipient);
                objBLL.send(objDonation, objDonor, objCharity);
                objBLL.send(objDonation, objCharity, objDonor);                           
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Update Successful'); window.location.href = 'DonationManagement.aspx';", true);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Update Failed'); window.location.href = 'DonationManagement.aspx';", true);
            }
            PopulateFields(objBLL.FindDonation(currentDonation));            
        }

        protected void findDonation_Click(object sender, EventArgs e)
        {
            BLL objBLL = new BLL();
            PopulateFields(objBLL.FindDonation(Convert.ToInt32(dropDownSelect.SelectedItem.Value)));
        }

        void PopulateFields(Donation objDonation)
        {
            BLL objBLL = new BLL();
            noItemsTxt.Disabled = false;
            noRecItemsTxt.Disabled = false;
            inputDropOffDate.Disabled = false;
            selectStatus.Disabled = false;
            Donors objDonor = objBLL.FindDonor(objDonation.DonorId); 
            donationId.Value = objDonation.Id.ToString();
            currentDonation = objDonation.Id;
            currentDonorID = objDonation.DonorId;
            donorId.Value = objDonor.FirstName+" "+objDonor.LastName;
            categorySelect.Value = objDonation.Category;
            pickupAddress.Value = objDonation.PickupAddress;
            pickupDateTxt.Value = objDonation.PickupDate.ToString("yyyy-MM-dd");
            //recipientTxt.Value = objDonation.Recipient.ToString();
            selectCharity.Value = objDonation.Recipient.ToString();
            if(objDonation.DropOffDate != null)
            {
                inputDropOffDate.Value = objDonation.DropOffDate.Value.ToString("yyyy-MM-dd");
            }
            else
            {
                inputDropOffDate.Value = null;
                
            }            
            noItemsTxt.Value = objDonation.NoItems.ToString();
            noRecItemsTxt.Value = objDonation.NoRecycledItems.ToString();
            selectStatus.Value = objDonation.Status;

            if (Globals.signedInUser.UserType != "Admin")
            {
                categorySelect.Disabled = true;
                pickupDateTxt.Disabled = true;
                pickupAddress.Disabled = true;
                selectCharity.Disabled = true;
                inputDropOffDate.Disabled = true;
                noItemsTxt.Disabled = true;
                noRecItemsTxt.Disabled = true;
                selectStatus.Disabled = true;
                btnUpdateDonation.Visible = false;
            }
        }

        protected void dropDownSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            BLL objBLL = new BLL();
            PopulateFields(objBLL.FindDonation(Convert.ToInt32(dropDownSelect.SelectedItem.Value)));
            
        }
    }
}