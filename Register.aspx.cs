using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Text.RegularExpressions;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // if the "isLoggedIn" session key exist, check if the users is logged in
        if (Session["isLoggedIn"] != null)
        {
            //check if the users is logged in
            if ((bool)Session["isLoggedIn"])
            {
                // when the users is logged in, they have no need to be on this page, therefore they get redirected to the home page
                Response.Redirect("Default.aspx");
            }
        }
    }

    protected void openTCBtn_Click(object sender, EventArgs e)
    {
        // when the button openTCBtn is clicked, it opens the page in a new window/tab (NOTE: NO NATIVE WAY TO DO THIS IN C#)
        Response.Write("<script>window.open('Register_TermsAndConditions.aspx','_blank')</script>");
    }
    protected void submitBtn_Click(object sender, EventArgs e)
    {
        // when the user clicks the submit button, it means they are ready to become a member, but before we 
        // do that we check for valid inputs

        // Declares a boolean that is true that is used to determine if all inputs are valid
        bool isAllValidInput = true;

        // Resets all labels on page
        this.resetLabelText();

        // checks if the full name text box is invalid (not enough characters)
        if (fullNameTextBox.Text.Length == 0)
        {
            // if it is, we set the confirmation label's color to red to signify an error
            fullNameConfirmationLabel.ForeColor = Color.Red;
            // show the user an error message through the label
            fullNameConfirmationLabel.Text = "ERROR: Full Name field is invalid.";
            // set the isAllValidInput to false
            isAllValidInput = false;
        }

        // Declares a Match instance that checks if the email address (from user's input) matches with a pretty "greedy" regular expression
        Match match = Regex.Match(emailAddressTextBox.Text, "([^\\s]*)@([^\\s]*)\\.([^\\s]*)", RegexOptions.IgnoreCase);
        // now we check if the match is wrong
        if (!match.Success)
        {
            // if it is, we set the confirmation label's color to red to signify an error
            emailAddressConfirmationLabel.ForeColor = Color.Red;
            // show the user an error message through the label
            emailAddressConfirmationLabel.Text = "ERROR: Email is in valid and/or has incorrect format.";
            // set the isAllValidInput to false
            isAllValidInput = false;
        }

        // checks if the loginID text box is invalid (not enough characters)
        if (loginIDTextBox.Text.Length == 0)
        {
            // if it is, we set the confirmation label's color to red to signify an error
            loginIDConfirmationLabel.ForeColor = Color.Red;
            // show the user an error message through the label
            loginIDConfirmationLabel.Text = "ERROR: LoginID is invalid.";
            // set the isAllValidInput to false
            isAllValidInput = false;
        }
        else
        {
            // the loginID is enough characters, but now we need to check if the users name is already taken or not

            // Declares a streamReader file object that allows us to read the loginID file line by line
            System.IO.StreamReader file = new System.IO.StreamReader(Path.GetFullPath(Server.MapPath("~\\files\\LoginIDFile.txt")));
            // Declares a string that is set to null (by default) and is used to hold temp lines of the file
            String line;
            // Read the file and display it line by line by using a loop until the file is at the end.
            while (file.Peek() > -1)
            {
                // stores the line read from file into the line variable
                line = file.ReadLine();
                // parse the line to get the loginID of that line
                String loginID = line.Split(',')[0];

                // checks if the loginID already exist (Case insensitive)
                if (loginID.ToLower().Equals(loginIDTextBox.Text.ToLower()))
                {
                    // if it is, we set the confirmation label's color to red to signify an error
                    loginIDConfirmationLabel.ForeColor = Color.Red;
                    // show the user an error message through the label
                    loginIDConfirmationLabel.Text = "ERROR: LoginID already exist. Please choose another one.";
                    // set the isAllValidInput to false
                    isAllValidInput = false;
                    // because we found a match, we no longer need to continue looking through the file, therefore we break out of the loop
                    break;
                }
            }
            // close the buffer file as we no longer need it
            file.Close();
        }

        // checks if the password text box is zero characters (though this is not invalid, it is prefered to have a password, so a warning occurs)
        if (passwordTextBox.Text.Length == 0)
        {
            // if it is, we set the confirmation label's color to orange to signify a warning message
            passwordConfirmationLabel.ForeColor = Color.Orange;
            // show the user an warning message through the label
            passwordConfirmationLabel.Text = "WARNING: Although having no password is allowed, it is recommended to have a password.";
        }

        // if the accept radio button is not checked
        if (!acceptTCBtn.Checked)
        {
            // when the accept radio button is not checked, is automatically an invalid input as you must accept the T&C's to register
    
            // if it is, we set the confirmation label's color to red to signify an error
            TCConfirmationLabel.ForeColor = Color.Red;
            // show the user an error message through the label
            TCConfirmationLabel.Text = "ERROR: You cannot register if you have not accepted our terms and conditions.";
            // set the isAllValidInput to false
            isAllValidInput = false;
        }

        // if the boolean isAllValidInput was never changed (ie its true)
        if (isAllValidInput)
        {
            // when the above is true,  it means that all inputs are valid, therefore we now write the accoun informaton to the file

            // Declares a streamWriter file that has the will append the current loginID file
            System.IO.StreamWriter file = new System.IO.StreamWriter(Path.GetFullPath(Server.MapPath("~\\files\\LoginIDFile.txt")), true);
            // Declares a string that constructs the data into an accepted format with the correct parameters
            String lineConstructor = loginIDTextBox.Text + "," + passwordTextBox.Text + "," + emailAddressTextBox.Text + "," + fullNameTextBox.Text + ",1";
            // writes the new string created above into the buffered file in a new line
            file.WriteLine(lineConstructor);
            // close the buffered file
            file.Close();
            // Alert the user that registration was sucessful by redirecting the user to a sucess page
            Response.Redirect("Register_Success.aspx");
        }
    }

    private void resetLabelText()
    {
        // this method defaults all the labels to empty string
        fullNameConfirmationLabel.Text = "";
        emailAddressConfirmationLabel.Text = "";
        loginIDConfirmationLabel.Text = "";
        passwordConfirmationLabel.Text = "";
        TCConfirmationLabel.Text = "";
    }
}