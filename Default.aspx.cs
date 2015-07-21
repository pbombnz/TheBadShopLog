using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void catogoryClothesBtn_Click(object sender, EventArgs e)
    {
        // Redirects to the clothing catogory page when the catogoryClothesBtn button is clicked
        Response.Redirect("Catogory_Clothes.aspx");
    }
    protected void catogoryTechBtn_Click(object sender, EventArgs e)
    {
        // Redirects to the tech catogory page when the catogoryTechBtn button is clicked
        Response.Redirect("Catogory_Tech.aspx");
    }
}