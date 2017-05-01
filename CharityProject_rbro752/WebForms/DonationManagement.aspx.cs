using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityProject_rbro752.WebForms
{
    public partial class DonationManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Globals.signedInUser == null)
            {
                Response.Redirect("SignIn.aspx");
            }
        }

        protected void btnUpdateDonation_Click(object sender, EventArgs e)
        {

        }
    }
}