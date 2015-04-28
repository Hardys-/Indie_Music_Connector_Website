using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    string Input = "";
    string U = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Input = string.Format("{0}", Request.QueryString["Input"]);         //get the topic Id
        U = string.Format("{0}", Request.QueryString["U"]);

        /*Table info initialization*/
        TableHeaderRow header = new TableHeaderRow();
        TableCell Title = new TableCell();
        TableCell Content = new TableCell();
        TableRow row = new TableRow();
        header.ForeColor = ColorTranslator.FromHtml("#a4d5f7");
        header.Font.Bold = true;
        header.Font.Name = "Calibri";
        Title.Text = "Search Results for \"" + Input + "\" :";
        Title.HorizontalAlign = HorizontalAlign.Left;

        Content.BackColor = ColorTranslator.FromHtml("#ece9e9");
        /*Block for different search result*/
        if(Input != "")  // not a empty value
        {
            int Inlen = Input.Length;
            if (Input.Contains("user ") && Input.IndexOf("user ") + 5 != Inlen) { Content.Text = "<br/>Found Users: <br/><br/>" + SearchUser(Input.Substring(Input.IndexOf("user ") + 5, Inlen - Input.IndexOf("user ") - 5)); }
            else if (Input.Contains("topic ") && Input.IndexOf("topic ") + 6 != Inlen) { Content.Text = "<br/>Found Topics: <br/><br/>" + SearchTopic(Input.Substring(Input.IndexOf("topic ") + 6, Inlen - Input.IndexOf("topic ") - 6)); }
            else if (Input.Contains("comment ") && Input.IndexOf("comment ") + 8 != Inlen) { Content.Text = "<br/>Found Comments: <br/><br/>" + SearchComment(Input.Substring(Input.IndexOf("comment ") + 8, Inlen - Input.IndexOf("comment ") - 8)); }
            else if (Input.Contains("band ") && Input.IndexOf("band ") + 5 != Inlen) { Content.Text = "<br/>Found Bands: <br/><br/>" + SearchBand(Input.Substring(Input.IndexOf("band ") + 5, Inlen - Input.IndexOf("band ") - 5)); }
            else if (Input.Contains("song ") && Input.IndexOf("song ") + 5 != Inlen) { Content.Text = "<br/>Found Songs: <br/><br/>" + SearchSong(Input.Substring(Input.IndexOf("song ") + 5, Inlen - Input.IndexOf("song ") - 5)); }
            else if (Input.Contains("album ") && Input.IndexOf("album ") + 6 != Inlen) { Content.Text = "<br/>Found Albums: <br/><br/>" + SearchAlbum(Input.Substring(Input.IndexOf("album ") + 6, Inlen - Input.IndexOf("album ") - 6)); }
            else
            {
                Content.Text = "<br/>Found Users: <br/><br/>" + SearchUser(Input) //Comprehensive results
                                + "<br/>Found Topics: <br/><br/>" + SearchTopic(Input)
                                + "<br/>Found Comments: <br/><br/>" + SearchComment(Input)
                                + "<br/>Found Bands: <br/><br/>" + SearchBand(Input)
                                + "<br/>Found Songs: <br/><br/>" + SearchSong(Input)
                                + "<br/>Found Albums: <br/><br/>" + SearchAlbum(Input);
            }        
        }
        /*Add Result to table*/
        header.Cells.Add(Title);
        row.Cells.Add(Content);
        SearchTable.Rows.Add(header);
        SearchTable.Rows.Add(row);
        SearchTable.CellPadding = 15;                      // Content Indent
        SearchTable.Style.Add("width", "90% !important"); // Inline percentage of table width
    }


    protected void SearchButton_Click(object sender, EventArgs e)
    {
        string URL = string.Format("SearchResult.aspx?Input={0}&U={1}", SearchTextBox.Text, U);
        Response.Redirect(URL);
    }

    protected bool SQLInjectionCheck(string InputString) //check if contain keyword like "SELECT", "Union", "OR 1=1 "
    {
        return true; 
    }


    protected string GetPicById(int UserID)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT Pic FROM Users WHERE Id = '{0}'", UserID); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                SQLResult = reader["Pic"].ToString();
                if (SQLResult == "") { SQLResult = "/images/UserProfile/Default.jpg"; }//default
            }
            conn.Close();
        }

        return SQLResult;
    }

    protected string GetTopicNameById(int TopicID)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT Topic FROM Topic WHERE Id = '{0}'", TopicID); //get the Topic of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())    
            {
                SQLResult = reader["Topic"].ToString();             
            }
            conn.Close();
        }
        return SQLResult;
    }


    protected string GetTopicOwnerNameById(int TopicID)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT OwnerName FROM Topic WHERE Id = '{0}'", TopicID); //get the Topic of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SQLResult = reader["OwnerName"].ToString();
            }
            conn.Close();
        }
        return SQLResult;
    }


    protected string GetBandURLByBandName(string BandName)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT Id, Name, Pic FROM Band WHERE Name = '{0}'", BandName); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                string Picpath = reader["Pic"].ToString();
                if (Picpath == "") { Picpath = "/images/UserProfile/Default.jpg"; }
                string UserURL = "<a href=\"" + string.Format("BandProfile.aspx?Id={0}&Name={1}", reader["Id"].ToString(), reader["Name"].ToString()) + " \" target=\"_blank\" style=\"color:#626262\">";//Open user page in new tab
                SQLResult = UserURL + "<img src = \"" + Picpath + "\" width=\"22\" height=\"22\" /> &nbsp;"
                         + reader["Name"].ToString() + "</a>";
            }
            conn.Close();
        }

        return SQLResult;
    }


    protected string GetAlbumPicNameByAlbumID(int AlbumID)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT AlbumName, Cover FROM Album WHERE Id = '{0}'", AlbumID); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                string Picpath = reader["Cover"].ToString();
                if (Picpath == "") { Picpath = "/images/UserProfile/Default.jpg"; }
                SQLResult =  "<img src = \"" + Picpath + "\" width=\"15\" height=\"15\" /> &nbsp;"
                         + reader["AlbumName"].ToString() + "</a>";
            }
            conn.Close();
        }

        return SQLResult;
    }


    protected string GetBandNameByAlbumId(int AlbumID)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT BandName FROM Album WHERE Id = '{0}'", AlbumID); //get the Topic of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SQLResult = reader["BandName"].ToString();
            }
            conn.Close();
        }
        return SQLResult;
    }


    protected string SearchRecolor(string InputString, string s)//InputString for inputstring, s for searched result
    {
        string ResultString = "";
        int len = s.Length;

        if (InputString.Contains(s)) //if contain
        {
            int lndex = InputString.IndexOf(s);
            if (lndex == 0) //start with s
            {
                ResultString =  "<mark style=\"color:red;\">" + s + "</mark>" + InputString.Substring(lndex + len, InputString.Length - 1 - lndex - len + 1);
            }
            else if (lndex + len - 1 == InputString.Length)// end with s
            {
                ResultString = InputString.Substring(0, lndex) + "<mark style=\"color:red;\">" + s + "</mark>";
            }
            else  // s in the middle
            {  ResultString = InputString.Substring(0, lndex) + "<mark style=\"color:red;\">" + s + "</mark>" + InputString.Substring(lndex + len, InputString.Length - 1 - lndex - len + 1); }
 
        }
        else 
        {
            ResultString = InputString;//if not contain
        
        }
        
        return ResultString;
    }


    /*-------------User---------Seach if the user contain searched info: email, name */
    protected string SearchUser(string InputString)
    {
        string SQLResult ="";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser = String.Format("SELECT Email, Name, Pic,Id FROM Users WHERE (Email LIKE '%{0}%') OR (Name LIKE '%{1}%')", InputString, InputString); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                if (reader["Name"].ToString() != "" || reader["Email"].ToString() != "")
                {
                    string Picpath = reader["Pic"].ToString();
                    if (Picpath == "") { Picpath = "/images/UserProfile/Default.jpg"; }
                    string UserURL = "<a href=\"" + string.Format("UserProfile.aspx?U={0}&Name={1}", reader["Id"].ToString(), reader["Name"].ToString()) + " \" target=\"_blank\" style=\"color:#626262\">";//Open user page in new tab
                    SQLResult += UserURL + "<img src = \"" + Picpath + "\" width=\"15\" height=\"15\" /> &nbsp;"
                             + SearchRecolor(reader["Name"].ToString(), InputString) + "&nbsp;" + SearchRecolor(reader["Email"].ToString(), InputString) + "</a><br/><br/>";
                }
                else{SQLResult = "Nothing found of Users that contain \""+InputString+"\" !";}               
            }
            conn.Close();
        }

        return SQLResult;
    }

    /*-------------Topic---------Seach if the Topic contain searched info: Topic, Ownername */
    protected string SearchTopic(string InputString)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser = String.Format("SELECT Id, Topic, Owner, OwnerName FROM Topic WHERE  (Topic LIKE '%{0}%') OR (OwnerName LIKE '%{1}%')", InputString, InputString); 
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                if (reader["Topic"].ToString() != "" || reader["OwnerName"].ToString() != "")
                {
                    string Picpath = GetPicById(int.Parse(reader["Owner"].ToString()));
                    string UserURL = "<a href=\"" + string.Format("Topic.aspx?Id={0}&Name={1}&Title={2}", reader["Id"].ToString(), reader["OwnerName"].ToString(), reader["Topic"].ToString()) + " \" target=\"_blank\" style=\"color:#626262\">";//Open Topic page in new tab
                    SQLResult += UserURL + "<img src = \"" + Picpath + "\" width=\"15\" height=\"15\" /> &nbsp;"
                             + SearchRecolor(reader["OwnerName"].ToString(), InputString) + "<br/>&nbsp;" + SearchRecolor(reader["Topic"].ToString(), InputString) + "</a><br/><br/>";
                }
                else { SQLResult = "Nothing found of Topics that contain \"" + InputString + "\" !"; }
            }
            conn.Close();
        }

        return SQLResult;
    }

    /*-------------Comments---------Seach if the Topic contain searched info: Topic, Ownername */
    protected string SearchComment(string InputString)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser = String.Format("SELECT Id, TopicId,  OwnerName, Content, OwnerId FROM Comments WHERE  (Content LIKE '%{0}%') OR (OwnerName LIKE '%{1}%')", InputString, InputString);
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all information need to be displaied in this page
            {
                if (reader["Content"].ToString() != "" || reader["OwnerName"].ToString() != "")
                {
                    string Picpath = GetPicById(int.Parse(reader["OwnerId"].ToString()));
                    string UserURL = "<a href=\"" + string.Format("Topic.aspx?Id={0}&Name={1}&Title={2}", reader["TopicId"].ToString(), GetTopicOwnerNameById(int.Parse(reader["TopicId"].ToString())), GetTopicNameById(int.Parse(reader["TopicId"].ToString()))) + " \" target=\"_blank\" style=\"color:#626262\">";//Open Topic page in new tab
                    SQLResult += UserURL + "<img src = \"" + Picpath + "\" width=\"15\" height=\"15\" /> &nbsp;"
                             + SearchRecolor(reader["OwnerName"].ToString(), InputString) + "<br/>&nbsp;" + SearchRecolor(reader["Content"].ToString(), InputString) + "</a><br/><br/>";
                }
                else { SQLResult = "Nothing found of Comment that contain \"" + InputString + "\" !"; }
            }
            conn.Close();
        }

        return SQLResult;
    }


    /*-------------Band---------Seach if the Band contain searched info: Content, name */
    protected string SearchBand(string InputString)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser = String.Format("SELECT Content, Name, Pic, Id FROM Band WHERE (Content LIKE '%{0}%') OR (Name LIKE '%{1}%')", InputString, InputString); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                if (reader["Name"].ToString() != "" || reader["Content"].ToString() != "")
                {
                    string Picpath = reader["Pic"].ToString();
                    if (Picpath == "") { Picpath = "/images/UserProfile/Default.jpg"; }
                    string UserURL = "<a href=\"" + string.Format("BandProfile.aspx?Id={0}&Name={1}", reader["Id"].ToString(), reader["Name"].ToString()) +" \" target=\"_blank\" style=\"color:#626262\">";//Open user page in new tab
                    SQLResult += UserURL + "<img src = \"" + Picpath + "\" width=\"15\" height=\"15\" /> &nbsp;"
                             + SearchRecolor(reader["Name"].ToString(), InputString) + "<br/>" + SearchRecolor(reader["Content"].ToString(), InputString) + "</a><br/><br/>";
                }
                else { SQLResult = "Nothing found of Bands that contain \"" + InputString + "\" !"; }
            }
            conn.Close();
        }

        return SQLResult;
    }


    /*-------------Song---------Seach if the Band contain searched info: Name */
    protected string SearchSong(string InputString)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser = String.Format("SELECT Album, Name, Id FROM Songs WHERE (Name LIKE '%{0}%')",  InputString); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                if (reader["Name"].ToString() != "")
                {
                    
                    SQLResult += GetBandURLByBandName(GetBandNameByAlbumId(int.Parse(reader["Album"].ToString())))
                                 + "<br/>Album: " + GetAlbumPicNameByAlbumID(int.Parse(reader["Album"].ToString())) + ": &nbsp;&nbsp;"
                                 + SearchRecolor(reader["Name"].ToString(), InputString)  + "</a><br/><br/>";
                }
                else { SQLResult = "Nothing found of Songs that contain \"" + InputString + "\" !"; }
            }
            conn.Close();
        }

        return SQLResult;
    }

    /*-------------Album---------Seach if the Band contain searched info: AlbumName*/
    protected string SearchAlbum(string InputString)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser = String.Format("SELECT Id, Cover, AlbumName, BandName FROM Album WHERE (AlbumName LIKE '%{0}%')", InputString); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                if (reader["AlbumName"].ToString() != "" )
                {
                    string Picpath = reader["Cover"].ToString();
                    if (Picpath == "") { Picpath = "/images/UserProfile/Default.jpg"; }
                    string UserURL = GetBandURLByBandName(reader["BandName"].ToString());
                    SQLResult += UserURL + "<br/><img src = \"" + Picpath + "\" width=\"15\" height=\"15\" /> &nbsp;"
                             + SearchRecolor(reader["AlbumName"].ToString(), InputString) +"<br/><br/>";
                }
                else { SQLResult = "Nothing found of Bands that contain \"" + InputString + "\" !"; }
            }
            conn.Close();
        }

        return SQLResult;
    }

}