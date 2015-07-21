using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

/// <summary>
/// BlogReaderWriter is a class filled with methods that is specifically used to read and write (modify) from a blog text file.
/// This class has reusable code to minimize duplication of code
///</summary>
public class BlogReaderWriter
{
    private string filePath; // Declares a string variable to store the filepath of the blog text file

    //Contructer Code
	public BlogReaderWriter(string filePath)
	{
        // Will construct the object and declaring the filePath variable in the class scope
        this.filePath = filePath;
	}

    /*
     * Writes blog entry to the approiate blog entry file (THIS SHOULD BE MOVED TO UserEntryFileReaderWriter.cs)
     */
    public void writeBlogToEntryFile(string store, string loginID, string unixTime, string experience)
    {
        // Declares a fileInfo object that allows us to get detail about the file path
        FileInfo fi = new FileInfo(this.filePath);
        // stores all text currently in the userEntryNew file into a string, currentData
        string currentData = File.ReadAllText(fi.Directory.FullName + "\\UserEntryNew.txt");
        // declares a string that contains all the data thats going to be stored into a parsable format
        // make expereince replace a comma with the HTML code of a comma to avoid confusion when parsing
        string newData = store + "," + loginID + "," + unixTime.ToString() + "," + experience.Replace(",", "&#44;");
        // now we write the new data, line seperator and old data to the file. THIS WILL OVERRIDE THE FILE but that is okay
        File.WriteAllText(fi.Directory.FullName + "\\UserEntryNew.txt", newData + "\r\n" + currentData );
    }

    /*
     * Returns an arraylist filled with all the blog entries for that specific store in a specific format. Its
     * used when displaying the blog entries (so on all Store_X.aspx pages)
     */
    public ArrayList getBlogListInformation()
    {
        // Declares a string array that stores all lines into the array
        string[] lines = System.IO.File.ReadAllLines(this.filePath);
        // checking if there are any lines in file
        if (lines.Length > 0)
        {
            //if there are lines in the file, declare a new arrayList to store blog entry strings
            ArrayList blogList = new ArrayList();

            // Display the file contents by using a foreach loop.
            for (int i = 0; i < lines.Length; i++)
            {
                // declares a String array that split the line into parsable account info
                String[] lineData = lines[i].Split(',');
                // gets the blog entry's loginID (Ie. the person who made that specific blog entry)
                string blogItemLoginID = lineData[0];

                // Delcares a FileInfo object that help get the full name of the directory
                FileInfo fi = new FileInfo(this.filePath);
                // Declares a LoginIDFileReaderWriter object that allows us to read and write to the LoginID file
                LoginIDFileReaderWriter loginIDFileReader = new LoginIDFileReaderWriter(fi.Directory.FullName + "\\LoginIDFile.txt");
                // Declares a dictionary that holds all the account information for blogItemLoginID
                Dictionary<string, string> accInfo = loginIDFileReader.getAccountInfoByLoginID(blogItemLoginID);
                // declare an int that get the unix Time from lineData
                int blogItemUnixTime = int.Parse(lineData[1]);
                // declare a string that get blogItemExperience from lineData
                string blogItemExperience = lineData[2];

                // Declare a DateTime object that is set to 0 unix seconds in universal time
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                // add the time the blog entry was posted
                dtDateTime = dtDateTime.AddSeconds(blogItemUnixTime).ToLocalTime();
                // Declare a string that contains the date and time of the blog in a readable format
                string dateTimeOfBlog = dtDateTime.ToLongDateString() + " " + dtDateTime.ToShortTimeString();
                // Add the following string into the blogList arraylist
                blogList.Add("On " + dateTimeOfBlog + ", " + accInfo["name"] + " posted their experience:<br \\>" + blogItemExperience);
            }
            // once looping is all done, we return the arraylist
            return blogList; 
        }
        else
        {
            // if there are no entries available, then we create a "dummy" array list
            ArrayList blogList = new ArrayList();
            // add a fake entry that states that no entries are available in the "dummy" array list
            blogList.Add("No Entries are available");
            // return the "dummy" array list
            return blogList;
        }        
    }
}