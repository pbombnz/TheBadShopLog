using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;


public partial class ContactUs : System.Web.UI.Page
{
    protected void sendBtn_Click(object sender, EventArgs e)
    {
        // When the send button is clicked in the contact page, we need to check if the textBoxes have valid inputs before proceeding ahead

        // Declaring an empty string that will be used to hold error messages (if any)
        String errorMessage = "";

        // Now we check every textbox for the approiate validation checks

        // We need to make sure that the user has entered a first name
        if (firstNameTextBox.Text.Length == 0)
        {
            // Failed validation statement, therefore we append the error message to alert the user
            errorMessage += "ERROR: First Name field is invalid.<br />";
        }
        // We need to make sure that the user has entered a last name
        if (lastNameTestBox.Text.Length == 0)
        {
            // Failed validation statement, therefore we append the error message to alert the user
            errorMessage += "ERROR: Last Name field is invalid.<br />";
        }

        // The line below create a Match Object that checks the email (inputted by the user) to a pretty "greedy" regular expression for email addresses
        Match match = Regex.Match(emailAddressTextBox.Text, "([^\\s]*)@([^\\s]*)\\.([^\\s]*)", RegexOptions.IgnoreCase);
        // now we check if the match is wrong
        if (!match.Success)
        {
            // If the match is wrong, the email format is wrong, therefore we append the error message to alert the user
            errorMessage += "ERROR: Email is in valid and/or has incorrect format.<br /> ";
        }

        // Now to check if the message is long enough. I use 20 characters as anything smaller than that can't be a real message
        if (messageTextBox.Text.Length < 20)
        {
            // if the message textBox is not at least 20 characters, therefore we append the error message to alert the user 
            errorMessage += "ERROR: The message must be 20 or more characters.<br />";
        }

        // If all inputs are valid, then no error messages would have occured, so now we check if the error message string is empty
        if (errorMessage.Equals(""))
        {
            // The errorMessage is empty, so we can alert the user that the email has been sent
            Response.Redirect("ContactUs_Success.aspx");
        }
        else
        {
            // sent the confirmation label as red to signify that something bad has happend (invalid input/s)
            sendConfirmationLabel.ForeColor = Color.Red;
            // set the error message to the confirmation label so the user can see the error messages.
            sendConfirmationLabel.Text = errorMessage;
        }
    }
}