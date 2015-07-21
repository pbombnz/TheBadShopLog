using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

public partial class Store_DSE : System.Web.UI.Page
{
	// Declares a static int that is used to define how many blog entries to show
    private static int numberOfBlogsToShow = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
		// when the page loads, we check if it isnt a postback (which is first time load)
        if (!IsPostBack)
        {
			//Just reset numberOfBlogsToShow to zero just incase
            numberOfBlogsToShow = 0;
			// show the next five blog entries
            getNextFiveBlogsFromList();
        }
    }
    protected void newBlogTextBox_TextChanged(object sender, EventArgs e)
    {
		// When the new blog text box has changed, we need to update the characters left label which is what the function below calculates
        this.changeCharacterLeftLabel();
    }
    protected void sendBlogBtn_Click(object sender, EventArgs e)
    {
		// When the new blog text box has changed, we need to update the characters left label which is what the function below calculates
        this.changeCharacterLeftLabel();
		// Declares an int that calcualuates how many characters are left
        int charsLeft = newBlogTextBox.MaxLength - newBlogTextBox.Text.Length;
		// checks if charsLeft is within the character limit
        if (charsLeft >= 0)
        {
			 // if it is, we write the blog to the user entry file
			 
			// Declares a BlogReaderWriter object that allows to save to the user entry file
            BlogReaderWriter blogWriter = new BlogReaderWriter(Path.GetFullPath(Server.MapPath("~\\files\\DSEUserEntry.txt")));
			// Declares a int32 variable that gets and stores the current unix time
            Int32 unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
			// Writes the new blog entry information to the new user entry file
            blogWriter.writeBlogToEntryFile("DSE", (String)Session["loginID"], unixTimestamp.ToString(), newBlogTextBox.Text);
			// redirects the users to a success page to confirm that there blog entry is awaiting moderation
            Response.Redirect("Post_Success.aspx");
        }
    }

    private void changeCharacterLeftLabel()
    {
		 // sets the charLeftLabel's text colour to black as a precautionary measure
        charLeftLabel.ForeColor = Color.Black;
		// declares an int that calculates the characters left from the text box and text box's character limit
        int charsLeft = newBlogTextBox.MaxLength - newBlogTextBox.Text.Length;
		// Sets the charLeftLabel to the int above (with other string components)
        charLeftLabel.Text = "Characters Left: " + charsLeft.ToString();
		// checks if the characters left value is above or equal to zero
        if (charsLeft >= 0)
        {
			// if the above is true, then the blog entry experience string is a valid, therefore
			// we change the text colour to green to signify that the input is an acceptable length
            charLeftLabel.ForeColor = Color.ForestGreen;
        }
        else
        {
			// if the above is false, then the blog entry experience string is a invalid, therefore
			// we change the text colour to red to signify that the input is an unacceptable length
            charLeftLabel.ForeColor = Color.Red;
        }
    }
    protected void showNextFiveBlogsBtn_Click(object sender, EventArgs e)
    {
		// if the showNextFiveBlogsBtn button is clicked, the users wants to view more blog entries
		// therefore we execute the method below which will load the next 5 entries
        this.getNextFiveBlogsFromList();
    }

    private void getNextFiveBlogsFromList()
    {
		//create a BlogReaderWriter object that is used to read the store's entry file
        BlogReaderWriter blogReader = new BlogReaderWriter(Path.GetFullPath(Server.MapPath("~\\files\\DSEUserEntry.txt")));
		//create a an arraylist object that holds the the blog entries is a formatted string
        ArrayList blogListData = blogReader.getBlogListInformation();
		// clears the blogListTable 
        blogListTable.Rows.Clear();
		// add 5 to numberOfBlogsToShow (so it will show the next 5 blogs)
        numberOfBlogsToShow += 5;
		// check if the above actually goes over the length of the blog entries
        if (numberOfBlogsToShow > blogListData.Count)
        {
			// if it does, set it to the maximum possible number (which will be the number of elements in the arraylist)
            numberOfBlogsToShow = blogListData.Count;
        }
		// Declares a temporary int counter that is used for the loop (that initalised with numberOfBlogsToShow)
		// This declares how many blogs will be shown
        int numberOfBlogsToShowCounter = numberOfBlogsToShow;
		// loop until numberOfBlogsToShowCounter is zero
        while (numberOfBlogsToShowCounter > 0)
        {
			// create a new table row
            TableRow tr = new TableRow();
			// create a new table cell
            TableCell tc = new TableCell();
			// set the cell's text to the arraylist's first element
            tc.Text = (String)blogListData[0];
			// remove the arraylist's first element as its no longer needed
            blogListData.RemoveAt(0);
			// Add the cell to the table row
            tr.Cells.Add(tc);
			// add the table row to the table
            blogListTable.Rows.Add(tr);
			// decrease the counter by one
            numberOfBlogsToShowCounter--;
        }
    }
    protected void addBlogBtn_Click(object sender, EventArgs e)
    {
		// checks if the user is logged in
		
		// checks if the "isLoggedIn" session key exists
        if (Session["isLoggedIn"] != null)
        {
			// checks if the user is logged in
            if ((bool)Session["isLoggedIn"])
            {
				// if the user is, then set the add blog section of the site to be visible so they add a blog entry
                addBlogSection.Visible = true;
            }
            else
            {
				// if they are not logged in, redirect them to the login screen so they can post blog entries
                Response.Redirect("Login.aspx");
            }
        }
        else
        {
			// if the key doesn't exist, they are not logged in, redirect them to the login screen so they can post blog entries
            Response.Redirect("Login.aspx");
        }
    }
}