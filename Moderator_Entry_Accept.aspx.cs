using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Moderator_Entry_Accept : System.Web.UI.Page
{
    void Page_LoadComplete(object sender, EventArgs e)
    { 
        // when the page has completely loaded, it will add meta data that redirects to the Moderator's entry page after 5 seconds
        Response.AddHeader("REFRESH", "5;URL=Moderator_Entry.aspx");
    }
}