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
            ClientScript.RegisterStartupScript(this.GetType(), "alertwindow", string.Format("alert('{0}'); window.location.href = 'RequestPickup.aspx';",selectCharity.Value), true);
        }
    }
}