using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// LoginIDFileReaderWriter is a class filled with methods that is specifically used to read and write (modify) from a loginID text file.
/// This class has reusable code to minimize duplication of code
/// </summary>
public class LoginIDFileReaderWriter
{
    // Declares an string that will hold the loginID file path (currently set to null on init)
    private string loginIDFilePath;

    /* Constructor Code */
	public LoginIDFileReaderWriter(string filePath)
	{
        // Set the class scope variable, loginIDFilePath to the parameter filePath
        this.loginIDFilePath = filePath;
	}

    /*
     * Checks if the loginIDExist. Case Sensitive
     */
    public bool isLoginIDExist(string loginID)
    {
        // Declares a string array called lines that has all the lines of loginID file store in it
        string[] lines = System.IO.File.ReadAllLines(this.loginIDFilePath);

        // Display the file contents by using a foreach loop.
        foreach (string line in lines)
        {
            // Declares a string that gets the loginID from line by splitting and getting the first object
            string loginIDFromLine = line.Split(',')[0];
            // checks if the loginID from the line in the file matches the one recieve in parameters
            if (loginID.Equals(loginIDFromLine))
            {
                // if it does, it means its a match, therefore return true;
                return true;
            }
        }
        // If the code reaches here, it means no matches were found, therefore we return false
        return false;
    }

    /*
     * Method that creates a new account to the loginID file
     */
    public void createNewAccount(string loginID, string password, string email, string name, int accessLevel)
    {
        // Opens the loginID file in a streamWriter object (that Appends)
        System.IO.StreamWriter file = new System.IO.StreamWriter(this.loginIDFilePath, true);
        // writes line to end of file with a parsable format of the parameters
        file.WriteLine(loginID + "," + password + "," + email + "," + name + ","+accessLevel.ToString());
        // closes the stream to save to file
        file.Close();
    }

    /*
     * Returns a dictonary that gets holds all the account informationg of loginID's account
     */
    public Dictionary<string, string> getAccountInfoByLoginID(string loginID)
    {
        // Declares a string array called lines that has all the lines of loginID file store in it        
        string[] lines = System.IO.File.ReadAllLines(this.loginIDFilePath);

        // Display the file contents by using a foreach loop.
        foreach (string line in lines)
        {
            // Declares a string array that parses the information from the line
            string[] lineData = line.Split(',');

            // checks if the parameter loginID is equals to the one on the line
            if (loginID.Equals(lineData[0]))
            {
                // if it is, it means we have a matchs

                // Declaring string variables that make us understand the elements of the lineData array
                string password = lineData[1];
                string email = lineData[2];
                string name = lineData[3];
                string accessLevel = lineData[4];
                // create a new accountData dictionary to hold all the information
                Dictionary<string, string> accountData = new Dictionary<string, string>();
                // add all account data to the dictionary with a meaningful key name
                accountData.Add("password", password);
                accountData.Add("email", email);
                accountData.Add("name", name);
                accountData.Add("accessLevel", accessLevel);
                // return the dictionary
                return accountData;
            }
        }
        // if a loginID match was never found, we have to return null
        return null;
    }
}