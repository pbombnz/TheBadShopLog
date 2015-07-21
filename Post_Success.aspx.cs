using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Post_Success : System.Web.UI.Page
{
    void Page_LoadComplete(object sender, EventArgs e)
    {
        // when the page has completely loaded, it will add meta data that redirects to the home page after 10 seconds
        Response.AddHeader("REFRESH", "10;URL=Default.aspx");
    }
}