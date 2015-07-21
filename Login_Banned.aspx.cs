using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login_Banned : System.Web.UI.Page
{
    protected void contactBtn_Click(object sender, EventArgs e)
    {
        // when contactBtn button is clicked, redirect to the contact page.
        Response.Redirect("ContactUs.aspx");
    }
}