using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register_Success : System.Web.UI.Page
{
    void Page_LoadComplete(object sender, EventArgs e)
    {
        // when the page is completely loaded, we add a meta header that redirects to the login page after 5 seconds
        Response.AddHeader("REFRESH", "5;URL=Login.aspx");
    }
}