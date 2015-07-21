using System;
using System.IO;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Moderator_SetAccessLevels : System.Web.UI.Page
{
    // declares an int for the number of accounts
    static int accCount = 0;
    //declares an list that store all the loginID's
    static ArrayList loginIDList;
    //declares an list that store all the radioList for access levels
    static ArrayList radioList;
    protected void Page_Load(object sender, EventArgs e)
    {
        //when the page loads, we need to setup the UI of the site...

        //first we get all lines and store them to a string array from the loginID file
        string[] lines = System.IO.File.ReadAllLines(Path.GetFullPath(Server.MapPath("~\\files\\LoginIDFile.txt")));
        //initalise the static variables
        accCount = 0;
        loginIDList = new ArrayList();
        radioList = new ArrayList();
        // loop through every line of lines (of the file)
        foreach (string line in lines)
        {
            // creates a table row
            TableRow tr = new TableRow();
            // creates a table cell that contains the loginID;
            TableCell loginIDTableCell = new TableCell();
            loginIDTableCell.Text = line.Split(',')[0];
            // add the loginID to the loginIDList as well
            loginIDList.Add((string)line.Split(',')[0]);
            // create another cell to store the radio list
            TableCell accessLevelListTableCell = new TableCell();
            ///create radio list
            RadioButtonList accessLevelList = new RadioButtonList();
            // add radio list to radiolist arraylist
             radioList.Add(accessLevelList);
            // create the list items for the radio list of that row
            ((RadioButtonList) radioList[radioList.Count - 1]).Items.Add(new ListItem("Banned", "0"));
            ((RadioButtonList) radioList[radioList.Count - 1]).Items.Add(new ListItem("Normal", "1"));
            ((RadioButtonList) radioList[radioList.Count - 1]).Items.Add(new ListItem("Moderator", "2"));
            // select the list item that is currently loginID's access level
            ((RadioButtonList) radioList[radioList.Count - 1]).Items.FindByValue(line.Split(',')[4].ToString()).Selected = true;
            // add the radio to the approiate cell
            accessLevelListTableCell.Controls.Add((RadioButtonList) radioList[radioList.Count-1]);
            // add both table cells to table row
            tr.Controls.Add(loginIDTableCell);
            tr.Controls.Add(accessLevelListTableCell);
            // add table row to table
            mainTable.Rows.Add(tr);
            // increase the account number count by one
            accCount++;
        }

    }
    protected void saveBtn_Click(object sender, EventArgs e)
    {
        //first we get all lines and store them to a string array from the loginID file
        string[] lines = System.IO.File.ReadAllLines(Path.GetFullPath(Server.MapPath("~\\files\\LoginIDFile.txt")));
        // create new list to store new lines
        string[] newLines = new string[lines.Length];
        // loop trough all accounts
        for (int i = 0; i < accCount; i++)
        {
            // loop through every line
            for(int j = 0; j < lines.Length; j++)
            {
                // check if the loginID from the index element is the same as the one in the line
                if (lines[j].StartsWith((string)loginIDList[i]))
                {
                    // if it is, remove the current access level
                    newLines[j] = lines[j].Remove(lines[j].Length - 1);
                    // set the new access level by appending it to the new line
                    newLines[j] += ((RadioButtonList) radioList[j]).SelectedValue;
                }
            }
        }
        // save all the new lines to the file which will overwrite the old settings
        System.IO.File.WriteAllLines(Path.GetFullPath(Server.MapPath("~\\files\\LoginIDFile.txt")), newLines);
    }
}