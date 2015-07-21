using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// UserEntryFileReaderWriter is a class filled with methods that is specifically used to read and write (modify) from a user entry text file.
/// This class has reusable code to minimize duplication of code
/// </summary>
public class UserEntryFileReaderWriter
{
    // Declares a string to hold the file path of the user entry file
    private string filePath;

    /* Constructor Code */
	public UserEntryFileReaderWriter(string filePath)
	{
        // Gets the parameter filePath and sets its to the class scoped filePath variable
        this.filePath = filePath;
	}

    /*
     * Returns the number of lines
     */
    public int getEndOfLineIndexNumber()
    {
        //Returns the number of lines by getting the lenth of the string array
        return System.IO.File.ReadAllLines(this.filePath).Length;
    }

    /*
     * Returns a dictionary object that holds the blog entry at that line number
     */
    public Dictionary<string,string> getEntryDataAtLineNumber(int lineNumber)
    {
        // making sure that the param, lineNumber, is within range
        if (lineNumber > -1 && lineNumber < this.getEndOfLineIndexNumber())
        {
            //Declares a string array that holds the all the lines of the user entry file
            string[] lines = System.IO.File.ReadAllLines(this.filePath);
            // declares a string array that holds all the data from the line 
            string[] lineData = lines[lineNumber].Split(',');
            // Decalre strings that give the elements in the array a meaningful defininition
            string store = lineData[0];
            string loginID = lineData[1];
            string unixTime = lineData[2];
            string badExperienceParagraph = lineData[3];
            // declares are dictionary object that will be returned later
            Dictionary<string, string> entryData = new Dictionary<string, string>();
            // adds all entry blog data to the entryData dictionary with a relavant key name
            entryData.Add("store", store);
            entryData.Add("loginID", loginID);
            entryData.Add("unixTime", unixTime);
            entryData.Add("badExperienceParagraph", badExperienceParagraph);
            // return the dictionary
            return entryData;
        }
        else
        {
            // if the param is out of range, return null
            return null;
        }
    }

    /*
     * Removes the entry blog form user entry file at the specific line
     */
    public void removeEntryDataAtLineNumber(int lineNumber)
    {
        //Declares a string array that holds all the lines of the user entry file
        string[] lines = System.IO.File.ReadAllLines(this.filePath);
        //Declares a string array that holds all the NEW lines of the user entry file (meaning one less than the orginal if we are removing)
        string[] newLines = new string[lines.Length-1];
        // Declare an int that is used to help store items in newLines without overwriting (or ArrayOutOfBoundsException appearing)
        int newLinesCounter = 0;
        // loop through all the items of lines
        for (int i = 0; i < lines.Length; i++)
        {
            // checks if i is equal to line number
            if (i == lineNumber)
            {
                // if it is, then we just skip this line as we dont want to include it
                continue;
            }
            else
            {
                // store the current line into the newLines array at index, newLinesCounter
                newLines[newLinesCounter] = lines[i];
                // increase newLinesCounter by one
                newLinesCounter++;
            }
        }
        // Write the newLines string array to the file which overwrite the file with the new data
        System.IO.File.WriteAllLines(this.filePath, newLines);
    }

}