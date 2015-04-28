using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BandProfile : System.Web.UI.Page
{
    string Id = "";
    string Name = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = string.Format("{0}", Request.QueryString["Id"]);         //get the Band Id
        Name = string.Format("{0}", Request.QueryString["Name"]);   //get the Band Name
        Button1.Text = Id + "  " + Name;
       
        /*Searching Band Information*/
        string DBName = "";
        string DBPic = "";
        string DBMembers = "";
        string DBFollowers = "";
        string DBContent = "";
        string dateString = "1/1/1970 00:00:00 AM";
        string DBAlbum = "";
        string DBVideoLink = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLBand = String.Format("SELECT * FROM Band WHERE (Id) = '{0}' AND (Name) = '{1}'", Id, Name); //get the password and username
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLBand, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Band's information need to be displaied in this page
            {   
                DBName = reader["Name"].ToString();   //get the Name in DB
                DBPic = reader["Pic"].ToString();
                DBMembers = reader["Members"].ToString();
                DBFollowers = reader["Followers"].ToString();
                dateString = reader["EstTime"].ToString();
                DBContent = reader["Content"].ToString();
                DBVideoLink = reader["VideoLink"].ToString();
            }
            conn.Close();
        }
        if (DBPic == "") { DBPic = "/images/UserProfile/Default.jpg"; } // if Band did not have avatar
       
        /*Searching Album information*/
        String SQLAlbum = String.Format("SELECT AlbumName, Cover, PublishedYear FROM Album WHERE (BandName) = '{0}'", DBName); //get the album published by this band
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
        TableRow row = new TableRow();
        TableCell BandInfo = new TableCell();
        TableCell Title = new TableCell();
        TableHeaderRow header = new TableHeaderRow();

        header.ForeColor = ColorTranslator.FromHtml("#a4d5f7");
        header.Font.Bold = true;
        header.Font.Name = "Calibri";
        header.Font.Size = 18;
        Title.Text = "Band Profile:";
        Title.HorizontalAlign = HorizontalAlign.Left;
        header.Cells.Add(Title);
        BandTable.Rows.Add(header);   // add header information

        BandInfo.BackColor = ColorTranslator.FromHtml("#4498d2"); //backgroud color
        BandInfo.ForeColor = ColorTranslator.FromHtml("#ffffff"); //front font color
        BandInfo.HorizontalAlign = HorizontalAlign.Left;
        BandInfo.Font.Name = "Calibri";

        DateTime DBEstTime= DateTime.Parse(dateString, System.Globalization.CultureInfo.InvariantCulture); //assign a date type to the string captured in database

        /*Block for displaying*/
        BandInfo.Text =
            "<div style=\"float:left; width: auto\"><div style=\"float:left; width: 200; margin-left:10px;\"><br/><img src=\""
            + DBPic + "\" width=\"150\" height=\"150\" /><br/><p style=\"font-size:20px\">"
            + DBName + "</p><br/>Followers: " + DBFollowers + "<br/>Members: " + DBMembers + "<br/>EST. TIME: " + DBEstTime.Year.ToString()
            + "</div> <div style=\"float:left; margin-left: 35px; width: 20%\"><br/>"
            + DBAlbum + " </div><div style=\"float:left; margin-left: 15px; width: 45%\"><br/> " + DBContent +"</div></div><br/>" +
            "<div style=\"float:left; padding-left: 250px; width: 65%\"><iframe width=\"640\" height=\"390\" src=\"" + DBVideoLink + "?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe></div>";

        row.Cells.Add(BandInfo);
        BandTable.Rows.Add(row);
        BandTable.CellPadding = 15;                      // Content Indent
        BandTable.Style.Add("width", "95% !important"); // Inline percentage of table width

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Text = "123456";
    }
}