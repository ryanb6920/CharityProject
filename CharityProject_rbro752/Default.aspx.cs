﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CharityProject_rbro752
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebForms.Globals.signedInUser != null)
                SignInLink.InnerText = "Sign Out";
        }
    }
}