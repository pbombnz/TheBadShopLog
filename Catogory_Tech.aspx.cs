using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Catogory_Tech : System.Web.UI.Page
{
    protected void dseBtn_Click(object sender, EventArgs e)
    {
        // Redirects to the dick smith electronics page when the dseBtn is clicked
        Response.Redirect("Store_DSE.aspx");
    }
    protected void harveyNormanBtn_Click(object sender, EventArgs e)
    {
        // Redirects to the harvey norman page when the harveyNormanBtn is clicked
        Response.Redirect("Store_HarveyNorman.aspx");
    }
}