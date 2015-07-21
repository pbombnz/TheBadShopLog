using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Moderator_Entry : System.Web.UI.Page
{
    // Initalise and declare the entry number to zero
    protected static int entryNumber = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        // create UserEntryFileReaderWriter object that will be used to write and read to the user entry file
        UserEntryFileReaderWriter entryReaderWriter = new UserEntryFileReaderWriter(Path.GetFullPath(Server.MapPath("~\\files\\UserEntryNew.txt")));

        // checks if the page is loading for the first time
        if (!IsPostBack)
        {
            // if the page is loading for the first time (or is a complete reload), reset the variables and buttons for this page
            // resets entryNumber
            entryNumber = 0;
            // makes the prevBtn button disabled (because we are at the start of the file)
            prevBtn.Enabled = false;
            // sets the status label that notifies the user that they are at the start
            blogStatusLabel.Text = "Start of Line";
        }
        else
        {
            // if the page is NOT loading for the first time, then we check what position we are in the file

            // checks if the the entryNumber is within range of the file (Non-Boundary)
            if (entryNumber > 0 && entryNumber < (entryReaderWriter.getEndOfLineIndexNumber() - 1))
            {
                // when the entryNumber is within range, both buttons are enabled
                nextBtn.Enabled = true;
                prevBtn.Enabled = true;
                // Since the line position is not at the boundaries (EOL or SOL) then
                // theres nothing to to alert the users hence an empty status label
                blogStatusLabel.Text = "";
            }
            else
            {
                //if the entry is a boundaryNumber, we check it which boundary it is (Max or Min)
                if (entryNumber == 0)
                {
                    // if the boundary is a minimum, then we can no longer go to the previous entry, therefore the next button is enabled
                    nextBtn.Enabled = true;
                    // We also make sure the previous button is is disabled too
                    prevBtn.Enabled = false;
                    // since we are at the start of the line, we alert the user by using a label
                    blogStatusLabel.Text = "Start of Line";
                }
                else if (entryNumber == (entryReaderWriter.getEndOfLineIndexNumber() - 1))
                {
                    // if the boundary is a maximum, then we can no longer go to next, therefore the previous button is disabled
                    prevBtn.Enabled = true;
                    // We also make sure the previous button is disabled too
                    nextBtn.Enabled = false;
                    // we also alert the user that we are at end of the file/line by using a label
                    blogStatusLabel.Text = "End of Line";
                }
                else
                {
                    // Some times the code does always play nice, so this is a hotfix by simply setting entryNumber to zero
                    entryNumber = 0;
                    // if the boundary is a minimum, then we can no longer go to the previous entry, therefore the next button is enabled
                    nextBtn.Enabled = true;
                    // We also make sure the previous button is is disabled too
                    prevBtn.Enabled = false;
                    // since we are at the start of the line, we alert the user by using a label
                    blogStatusLabel.Text = "Start of Line";
                }
            }
        }

        // Now we need to display the the actual blog information so the admin knows what blogs they are interacting with

        // Declaring a dictionary that holds all the blog information
        Dictionary<string, string> blogData = entryReaderWriter.getEntryDataAtLineNumber(entryNumber);
        // Declares a new DateTime object at a unix time of 0 seconds
        System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        // adjusts it to the time of when the blog was posted
        dtDateTime = dtDateTime.AddSeconds(int.Parse(blogData["unixTime"])).ToLocalTime();
        // declares a string that holds the date and time together
        string dateTimeString = dtDateTime.ToLongDateString() + " " + dtDateTime.ToShortTimeString();

        // set the blogLabel's text using the blog entry information so the user can see it
        blogLabel.Text = "On the " + blogData["store"] + " section, the Username/LoginID, '" + blogData["loginID"] + "' posted an experience at " + dateTimeString + ":<br />" + blogData["badExperienceParagraph"]; 

    }
    protected void nextBtn_Click(object sender, EventArgs e)
    {
        // when the nextBtn is clicked, entryNumber is increased by one
        entryNumber++;
    }
    protected void rejectBtn_Click(object sender, EventArgs e)
    {
        // if the user/moderator clicks the rjectBtn, then we reject and remove the blog entry

        // Declares an UserEntryFileReaderWriter instance that allows for modification on the UserEntryNew text file
        UserEntryFileReaderWriter entryReaderWriter = new UserEntryFileReaderWriter(Path.GetFullPath(Server.MapPath("~\\files\\UserEntryNew.txt")));
        // removes the entry at the current entryNumber
        entryReaderWriter.removeEntryDataAtLineNumber(entryNumber);
        // Redirects to a moderator's reject page that confirms that the entry is gone
        Response.Redirect("Moderator_Entry_Reject.aspx");
    }
    protected void acceptBtn_Click(object sender, EventArgs e)
    {
        // if the user/moderator clicks the acceptBtn, we enter this method that "cuts and pastes" the entry into to correct entry file

        // Declares an UserEntryFileReaderWriter instance that allows for modification on the UserEntryNew text file
        UserEntryFileReaderWriter entryReaderWriter = new UserEntryFileReaderWriter(Path.GetFullPath(Server.MapPath("~\\files\\UserEntryNew.txt")));
        // Declaring a dictionary that holds all the blog information
        Dictionary<string, string> blogData = entryReaderWriter.getEntryDataAtLineNumber(entryNumber);
        // removes the entry at the current entryNumber
        entryReaderWriter.removeEntryDataAtLineNumber(entryNumber);

        // Declares a string that will hold the full path of the approiate text file that the blog entry will save to.
        string storeFilePath = "";
        // now to determine which file the blog entry needs to save to from the blog information collected.
        // This will set the file path accordingly
        if (blogData["store"].Equals("Farmers"))
        {
            //if the store is farmers, set the file path to the farmers entry file (Absolute)
            storeFilePath = Path.GetFullPath(Server.MapPath("~\\files\\FarmersUserEntry.txt"));
        }
        else if(blogData["store"].Equals("KMart"))
        {
            // if the store is KMart, set the file path to the kmart entry file (Absolute)
            storeFilePath = Path.GetFullPath(Server.MapPath("~\\files\\KmartUserEntry.txt"));
        }
        else if (blogData["store"].Equals("DSE"))
        {
            // if the store is dick smith, set the file path to the DSE entry file (Absolute)
            storeFilePath = Path.GetFullPath(Server.MapPath("~\\files\\DSEUserEntry.txt"));
        }
        else if (blogData["store"].Equals("HarveyNorman"))
        {
            // if the store is harvey norman, set the file path to the harvey norman entry file (Absolute)
            storeFilePath = Path.GetFullPath(Server.MapPath("~\\files\\HarveyNormanUserEntry.txt"));
        }

        // Now we need to add the blog entry line to the top of the store's entry files

        // Declare a string that gets all the text from the store's file path (including new line seperators) 
        string oldUserEntryNewFile = System.IO.File.ReadAllText(storeFilePath);
        // Declares a string that places the blog entry's data into a parsable format.
        string newLine = blogData["loginID"] + "," + blogData["unixTime"] + "," + blogData["badExperienceParagraph"];
        // Overwrites the store's entry file and places the new data, line seperator and old data in the file therefore
        // the new data is at the top of the file
        System.IO.File.WriteAllText(storeFilePath, newLine + "\r\n" + oldUserEntryNewFile);
        // Redirects the umoderator to an acceptance page that confirm the entry of the
        Response.Redirect("Moderator_Entry_Accept.aspx");
    }
    protected void prevBtn_Click(object sender, EventArgs e)
    {
        // when the prevBtn is clicked, entryNumber is decreased by one
        entryNumber--;
    }
}