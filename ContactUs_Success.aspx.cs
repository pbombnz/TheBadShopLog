using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

public partial class ContactUs_Success : System.Web.UI.Page
{
    void Page_LoadComplete(object sender, EventArgs e)
    {
        // When the page has loaded completely, we add a meta header that will redirect to the home page in 5 seconds
        Response.AddHeader("REFRESH", "5;URL=Default.aspx");
    }
}