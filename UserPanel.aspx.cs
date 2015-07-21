using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class UserPanel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // When this page loads, we display the user's account information (and if appliable, access to moderator only features)s

        // Sets the title label as the same name as the loginID to signify that is is their user panel 
        contentTitle.Text = (string) Session["LoginID"];

        // Declares a LoginIDFileReaderWriter instance which allows reading and writing of the loginID file
        LoginIDFileReaderWriter loginIDFileReader = new LoginIDFileReaderWriter(Path.GetFullPath(Server.MapPath("~\\files\\LoginIDFile.txt")));
        // Declares a dictionary object that hold all account information of the loginID
        Dictionary<string,string> accInfo = loginIDFileReader.getAccountInfoByLoginID((string) Session["LoginID"]);

        // Set the labels' text to the corosponding account information thats related to that label
        loginIDLabel.Text = (string) Session["LoginID"];
        emailLabel.Text = (string) accInfo["email"];
        nameLabel.Text = (string)accInfo["name"];

        // checks the size of the account's password
        if(((string) accInfo["password"]).Length == 0)
        {
            // if the size is zero, then we set the label saying that there is no password
            passwordLabel.Text = "(No Password Specified)";
        }
        else 
        {
            // if the size is bigger than zero, than the password is not an empty string therefore we show it by
            // seeting the string accordingly
            passwordLabel.Text = (string) accInfo["password"];
        }

        // Instead of just showing the accessLevel number, we are gonna show what the number actually means 
        // instead, so we use a switch statement
        switch ((int) int.Parse(accInfo["accessLevel"]))
        {
            case 1:
                //if the accessLevel is 1, then we can see the access level label's text to normal user
                accessLevelLabel.Text = "Normal User";
                // because the users is not a moderator, they will not be able to see the moderator only section
                moderatorSection.Visible = false;
                //break out of swtich/case statement
                break;
            case 2:
                //if the accessLevel is 2, then we can see the access level label's text to moderator
                accessLevelLabel.Text = "Moderator";
                // because the users is a moderator, they will be able to see the moderator only section
                moderatorSection.Visible = true;
                //break out of swtich/case statement
                break;
        }  
    }
    protected void moderateEntryBtn_Click(object sender, EventArgs e)
    {
        // when the moderator entry button is clicked, we redirect to the moderator entry page
        Response.Redirect("Moderator_Entry.aspx");
    }
    protected void setMembersAccessLevelBtn_Click(object sender, EventArgs e)
    {
        // when the moderator set members access level button is clicked, we redirect to the moderator set members access page
        Response.Redirect("Moderator_SetAccessLevels.aspx");
    }
}