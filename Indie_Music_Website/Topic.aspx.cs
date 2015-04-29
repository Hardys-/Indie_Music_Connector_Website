using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topic : System.Web.UI.Page
{
    string Id = "";
    string Name = "";
    string TopicTitle = "";
    string I = "1";
    int OwnerId =0;

     protected void RequestbyID(string id)
    {
        try             
        {
            int i = 0; 
            String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
            String sql1 = String.Format("SELECT OwnerId, OwnerName,Content,PostTime FROM Comments WHERE (TopicId) = '{0}'", id); //get the content of the same topic id
            using (SqlConnection conn = new SqlConnection(connect))
            using (SqlCommand cmd = new SqlCommand(sql1, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                    TableRow row = new TableRow();
                    TableCell Content = new TableCell();

                    
                    string UserURL = "<a href=\"" + string.Format("UserProfile.aspx?U={0}&Name={1}", reader["OwnerId"].ToString(), reader["OwnerName"].ToString()) + " \" target=\"_blank\" style=\"color:#000000\">";//Open user page in new tab
                    OwnerId = int.Parse(reader["OwnerId"].ToString());
                    Content.Text = UserURL + "<img src=\"" + GetPicById(int.Parse(reader["OwnerId"].ToString())) + "\" width=\"15\" height=\"15\"/> &nbsp;"
                                    + reader["OwnerName"].ToString() + "</a><br/><br/>"                 //Post owner Info
                                    + reader["Content"].ToString() + "</a><br/><br/>"              // Topic comments
                                    + "<div style=\"font-size:10px\"> Posted at: " + reader["PostTime"].ToString() + "</div><br/>";  // Post time
     
                    if (i % 2 == 0)           //dynamic background color even-> black & odd -> grey
                    {
                        Content.BackColor = ColorTranslator.FromHtml("#ffffff");   //Transfer HEX value color 
                        Content.ForeColor = ColorTranslator.FromHtml("#000000");
                    }
                    else 
                    {
                        Content.BackColor = ColorTranslator.FromHtml("#ece9e9");
                        Content.ForeColor = ColorTranslator.FromHtml("#000000");
                    }

                    Content.HorizontalAlign = HorizontalAlign.Left;
                    Content.Font.Name = "Calibri";

                    row.Cells.Add(Content);                   
                    Table1.Rows.Add(row);
                    Table1.CellPadding = 15;                      // Content Indent
                    Table1.Style.Add("width", "95% !important");  // Inline percentage of table width
                    
                }
                conn.Close();
                
            }

            /*String sql2 = "SELECT MAX(Votes) FROM Candidates"; //get the max value of all votes
            using (SqlConnection conn = new SqlConnection(connect))
            using (SqlCommand cmd = new SqlCommand(sql2, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    max = int.Parse(reader[0].ToString());
                }

                conn.Close();
            }*/
        }
        catch (Exception m)// For exceptions 
        {
           if (m.Source != null)
               Console.WriteLine("Exception source: {0}", m.Source);  // output exception source in console 
           throw;
        }
    }

    protected string GetPicById(int UserID) 
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT Pic FROM Users WHERE Id = '{0}'",UserID); //get the Picture of the user
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                SQLResult = reader["Pic"].ToString();
               
            }
            conn.Close();
        }

        return SQLResult;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = string.Format("{0}", Request.QueryString["Id"]);         //get the topic Id
        Name = string.Format("{0}",  Request.QueryString["Name"]);    // get the user Name
        
        TopicTitle = string.Format("{0}", Request.QueryString["Title"]);  //get the Topic Title
        I = string.Format("{0}", Request.QueryString["I"]);
        if (I != "") { Panel1.Visible = true; } else { Panel1.Visible = false; }
        TableHeaderRow Header = new TableHeaderRow();
        TableCell HeaderContent = new TableCell();
        Header.ForeColor = ColorTranslator.FromHtml("#a4d5f7");
        Header.Font.Bold = true;
        Header.Font.Name = "Calibri";
        HeaderContent.Text ="--"+TopicTitle+"-- Posted by:  "+ Name;              //List of each topic
        HeaderContent.HorizontalAlign = HorizontalAlign.Left;
        Header.Cells.Add(HeaderContent);
        Table1.Rows.Add(Header);
        DisplayLikes();
        if (Id != "") { RequestbyID(Id); }    //need to add an access check
    }


    protected void PostCommentButton_Click(object sender, EventArgs e)
    {
        string nowtime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLInsertComment = "INSERT INTO Comments (TopicId,OwnerId,Likes,PostTime,Content,OwnerName) VALUES(@Topicid, @OwnerId, 0, @nowtime, @Content, @OwnerName)";//insert into Comment table
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLInsertComment, conn))
        {
            conn.Open();

            cmd.Parameters.Add("@Topicid", int.Parse(Id));
            cmd.Parameters.Add("@OwnerId", OwnerId);
            cmd.Parameters.Add("@nowtime", nowtime);
            cmd.Parameters.Add("@Content", PostTextBox.Text);
            cmd.Parameters.Add("@OwnerName", GetNameById(int.Parse(I)));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        PostTextBox.Text = "";
        string TopicURL = string.Format("Topic.aspx?Id={0}&Name={1}&Title={2}&I={3}", Id, Name, TopicTitle, int.Parse(I));
        Response.Redirect(TopicURL);

    }

    protected string GetNameById(int UserID)
    {
        string SQLResult = "";
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLFriend = String.Format("SELECT Name FROM Users WHERE Id = {0}", UserID); 
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Album information need to be displaied in this page
            {
                SQLResult = reader["Name"].ToString();
                
            }
            conn.Close();
        }

        return SQLResult;
    }

    protected void LikeButton_Click(object sender, EventArgs e)
    {
        string nowtime = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss tt");
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLInsertComment = String.Format("UPDATE Topic SET Likes = Likes + 1 WHERE Id = '{0}'", Id);//add likes
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLInsertComment, conn))
        {
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }


    protected void DisplayLikes()
    {
        
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        String sql1 = String.Format("SELECT Likes FROM Topic WHERE (Id) = '{0}'", Id); //get the content of the same topic id
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(sql1, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LikeButton.Text = reader["Likes"].ToString() + "  Likes";           
            }
            conn.Close();
        }



    }
}