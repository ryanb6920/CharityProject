using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityProject_rbro752
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebForms.Globals.signedInUser == null)
            {
                lnkSignOut.Visible = false;
                lblHI.Visible = false;
                lblLoggedInUser.Visible = false;
            }
            else
            {
                lnkSignOut.Visible = true;
                lblHI.Visible = true;
                lblLoggedInUser.Visible = true;
                if (WebForms.Globals.signedInUser.UserType == "Donor")
                    lblLoggedInUser.Text = WebForms.Globals.signedInDonor.FirstName + " ";
                else if (WebForms.Globals.signedInUser.UserType == "Charity")
                    lblLoggedInUser.Text = WebForms.Globals.signedInCharity.CharityName + " ";
                else if (WebForms.Globals.signedInUser.UserType == "Admin")
                    lblLoggedInUser.Text = "Admin ";                
            }
        }

        protected void lnkSignOut_ServerClick(object sender, EventArgs e)
        {
            lblHI.InnerText = Page.AppRelativeVirtualPath;
            if (Page.AppRelativeVirtualPath == "~/Webforms/DonationManagement.aspx") { }
                Response.Redirect("SignIn.aspx");
            Response.Redirect("WebForms/SignIn.aspx");    
        }
    }
}