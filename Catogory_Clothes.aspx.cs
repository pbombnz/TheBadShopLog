using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Catogory_Clothes : System.Web.UI.Page
{
    protected void farmersBtn_Click(object sender, EventArgs e)
    {
        // Redirects to the farmers store page if the farmers button is clicked
        Response.Redirect("Store_Farmers.aspx");
    }
    protected void kmartBtn_Click(object sender, EventArgs e)
    {
        // Redirects to the K-mart store page if the K-Mart button is clicked
        Response.Redirect("Store_KMart.aspx");
    }
}