using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserProfile : System.Web.UI.Page
{
    string U = "";
    string Name = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        U = string.Format("{0}", Request.QueryString["U"]);         //get the User Id
        Name = string.Format("{0}", Request.QueryString["Name"]);


        /*Searching User Information*/
        string DBEmail = "";
        string DBName = "";
        string DBGender = "";
        string DBPic = "";
        string DBFriends = "";
        string dateString1 = "1/1/1970 00:00:00 AM";
        string dateString2 = "1/1/1970 00:00:00 AM";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser= String.Format("SELECT * FROM Users WHERE (Id) = '{0}' AND (Name) = '{1}'", U, Name); //get the password and username
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all user's information need to be displaied in this page
            {
                string s = "";
                DBEmail = reader["Email"].ToString(); //get the Email in DB
                DBName = reader["Name"].ToString();   //get the Name in DB
                DBGender = reader["Gender"].ToString();       //get the Gender in DB
                DBPic = reader["Pic"].ToString();
                dateString1 = reader["DOB"].ToString();
                DBFriends = reader["Friends"].ToString();
                dateString2 = reader["RegTime"].ToString();

            }
            conn.Close();
        } 
        if( DBPic == "" ){DBPic = "/images/UserProfile/Default.jpg";} // if user did not upload profile pic
       
        /*Searching Friends information*/
        String SQLFriend = String.Format("SELECT AlbumName, Cover, PublishedYear FROM Album WHERE (BandName) = '{0}'", DBName); //get the album published by this band
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLAlbum, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                /*Wrap up deta type */
                string AlbumDateString = reader[2].ToString();
                DateTime DBAlbumDateTime = DateTime.Parse(AlbumDateString, System.Globalization.CultureInfo.InvariantCulture);
                string DBAlbumDate = DBAlbumDateTime.Year.ToString() + "-" + DBAlbumDateTime.Month.ToString() + "-" + DBAlbumDateTime.Day.ToString();
                /*Wrap up deta type */

                DBAlbum += "<img src=\"" + reader[1].ToString() + "\" width=\"35\" height=\"35\" />&nbsp;" + reader[0].ToString() + "&nbsp;<div style=\"font-size:8px\">" + DBAlbumDate + "<br/><br/></div>";
            }
            conn.Close();
        }
        /*search ending*/

        /*display user's information*/
        TableRow  row = new TableRow();
        TableCell UserInfo = new TableCell();
        TableCell Title = new TableCell();
        TableHeaderRow header = new TableHeaderRow();

        header.ForeColor = ColorTranslator.FromHtml("#a4d5f7");
        header.Font.Bold = true;
        header.Font.Name = "Calibri";
        Title.Text = "User Profile";
        Title.HorizontalAlign = HorizontalAlign.Left;
        header.Cells.Add(Title);
        UserTable.Rows.Add(header);   // add header information

        UserInfo.BackColor = ColorTranslator.FromHtml("#4498d2");
        UserInfo.ForeColor = ColorTranslator.FromHtml("#ffffff");
        UserInfo.HorizontalAlign = HorizontalAlign.Left;
        UserInfo.Font.Name = "Calibri";
        DateTime DBDOB = DateTime.Parse(dateString1, System.Globalization.CultureInfo.InvariantCulture); //assign a date type to the string captured in database
        DateTime DBRegTime = DateTime.Parse(dateString2, System.Globalization.CultureInfo.InvariantCulture); //assign a date type to the string captured in database

        UserInfo.Text =
            "<div style=\"float:left; width: auto\"><div style=\"float:left; width: 35%; margin-left:10px;\"><br/><img src=\""
            + DBPic + "\" width=\"100\" height=\"100\" /><br/>" +
            DBName + "</a><br/></div> <div style=\"float:left; margin-left: 30px; width: 50%\"><br/>"
            + "Followers: " + DBFriends + "<br/> Email: " + DBEmail + "<br/> Gender: " + DBGender +
            "<br/> Birthday:  " + DBDOB.Date.ToString() + "<br/> Est. " + DBRegTime.Date.ToString() +
            " </div></div><br/><br/>";

        row.Cells.Add(UserInfo);
        UserTable.Rows.Add(row);
        UserTable.CellPadding = 15;                      // Content Indent
        UserTable.Style.Add("width", "95% !important"); // Inline percentage of table width
    }
}