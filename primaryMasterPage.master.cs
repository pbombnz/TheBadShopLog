using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // when the page loads, we check if isLoggedIn a key in the session states
        if (Session["isLoggedIn"] != null)
        {
            // if it is, it MIGHT mean that we are logged in, so we check this
            if ((bool)Session["isLoggedIn"])
            {
                // if the session is logged in, we changed the registered button's text to displays a string that signifies the user's panel 
                registerBtn.Text = (String)Session["loginID"] + "'s Panel";
                // since we are logged in , we cant login twice, therefore we convert the login button to a logout button
                loginLogoutBtn.Text = "Logout";
            }
        }
    }
    protected void homeBtn_Click(object sender, EventArgs e)
    {
        // when the home button is clicked, the server redirects the user to the home page
        Response.Redirect("Default.aspx");
    }
    protected void aboutBtn_Click(object sender, EventArgs e)
    {
        // When the about button is clicked, the server redirects the user to the about page
        Response.Redirect("About.aspx");
    }
    protected void contactBtn_Click(object sender, EventArgs e)
    {
        // when the contact button is clicked, the server redirects the user to the contact page
        Response.Redirect("ContactUs.aspx");
    }
    protected void registerBtn_Click(object sender, EventArgs e)
    {
        // if the register button's text is "Register", it means that the user has not logged in
        if (registerBtn.Text.Equals("Register"))
        {
            // if the above is true, we redirect to the registration page
            Response.Redirect("Register.aspx");
        }
        else
        {
            // if the above is not true, it means that the user is logged in (meaning it would be
            // pointless for the user to re-register) so the button redirects to the user's panel
            Response.Redirect("UserPanel.aspx");
        }
    }
    protected void loginLogoutBtn_Click(object sender, EventArgs e)
    {
        // checks if the loginLogoutBtn button's text is login
        if (loginLogoutBtn.Text.Equals("Login"))
        {
            // if the above is true, it means the users has not logged on therefore redirect the user to the login page
            Response.Redirect("Login.aspx");
        }
        else
        {
            // if the above is not true, it means the users is already logged in and therefore wants to logout
            // Set the 'isLoggedIn' key to false, to signify that we are no longer logged in
            Session["isLoggedIn"] = false;
            // Set the loginID to null (as its good practice)
            Session["loginID"] = null;
            // Set the text of the buttons that get changed to their orginal text
            registerBtn.Text = "Register";
            loginLogoutBtn.Text = "Login";
            //redirects user to the home page
            Response.Redirect("Default.aspx");
        }
    }
}
