using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogicLayer;
using BusinessObjects;

namespace CharityProject_rbro752.WebForms
{
    public partial class DonorSignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            if(passwordSignUp.Value == passwordConfirmSignUp.Value)
            {
                int output;

                BLL objBLL = new BLL();
                Donors objDonor = new Donors();
                objDonor.FirstName = firstNameTxt.Value;
                objDonor.LastName = lastNameTxt.Value;
                objDonor.Email = emailSignUp.Value;
                objDonor.Password = passwordSignUp.Value;

                output = objBLL.DonorSignUpBLL(objDonor);

                if(output > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Succesfully Registered as Donor'); window.location.href = 'DonorSignUp.aspx';", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Registration Failed'); window.location.href = 'DonorSignUp.aspx';", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", "alert('Passwords must match!'); window.location.href = 'DonorSignUp.aspx';", true);
            }
            
        }
    }
}