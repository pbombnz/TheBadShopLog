using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // when the page loads, we check if the user is logged in...

        // Firstly we check if a session state for the logged in state exists
        // if its null, its assumed that we are not logged in.
        if (Session["isLoggedIn"] != null)
        {
            // if the sessio state exists for the logged in stat exist, we now check the if the users is actually logged in
            if ((bool) Session["isLoggedIn"])
            {
                // Since the users has already logged in, they dont need to login again so we redirect them to the home page
                Response.Redirect("Default.aspx");
            }
        }
    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        // This method is activated when te login button is clicked. It allows the user to login (if they have correct inputs)

        // Create a streamReader object to read the loginIDFile
        System.IO.StreamReader file = new System.IO.StreamReader(Path.GetFullPath(Server.MapPath("~\\files\\LoginIDFile.txt")));
        // Declare an empty string called line to hold account information
        String line;
        // Loop until we are at the end of the file
        while (file.Peek() > -1)
        {
            // Read the next next line and store it into line
            line = file.ReadLine();
            // Declare variables that have values that are parsed from line
            String loginID = line.Split(',')[0];
            String password = line.Split(',')[1];
            String accessLevel = line.Split(',')[4];

            // checks if the loginID from line, is the same as the user's input (Which means its a valid LoginID)
            if (loginID.Equals(loginIDTextBox.Text))
            {
                // check if the user's input for password matches the password for the loginID
                if (password.Length == 0 || password.Equals(passwordTextBox.Text))
                {
                    // we now have valid inputs (that link to a valid account), now we check if the users is banned
                    if (int.Parse(accessLevel) == 0)
                    {
                        // if the user is banned, show them a page that alerts the user that they cant login
                        Response.Redirect("Login_Banned.aspx");
                    }
                    else
                    {
                        // if the users is NOT banned, they have valid inputs and have a valid account and are NOT banned
                        // therefore we create session state for the logged in state and set it to true
                        Session["isLoggedIn"] = true;
                        // we also create a session key with the loginID, so that we can found out who is actually logged in
                        Session["LoginID"] = loginID;
                        // redirects to the home page
                        Response.Redirect("Default.aspx");
                    }
                }
                else
                {
                    // if the user's password input is invalid, we alert the user
                    // with an error message by setting the loginConfirmationLabel as so.
                    loginConfirmationLabel.Text = "ERROR: Username or password is incorrect or does not exist";
                }
                return;
            }
        }
        // if the user's input are invalids (and/or the account does not exist), we alert the user
        // with an error message by setting the loginConfirmationLabel as so.
        loginConfirmationLabel.Text = "ERROR: Username or password is incorrect or does not exist";
    }
    protected void registerBtn_Click(object sender, EventArgs e)
    {
        // if the users clicks the registerBtn button, we redirect them to the registration page
        Response.Redirect("Register.aspx");
    }
}