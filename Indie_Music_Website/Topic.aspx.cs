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

                    string UserURL = "<a href=\"" + string.Format("UserProfile.aspx?U={0}&Name={1}", reader["OwnerId"].ToString(), reader["OwnerName"].ToString()) + " \" target=\"_blank\">";//Open user page in new tab

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
        TableHeaderRow Header = new TableHeaderRow();
        TableCell HeaderContent = new TableCell();
        Header.ForeColor = ColorTranslator.FromHtml("#a4d5f7");
        Header.Font.Bold = true;
        Header.Font.Name = "Calibri";
        HeaderContent.Text ="--"+TopicTitle+"-- Posted by:  "+ Name;              //List of each topic
        HeaderContent.HorizontalAlign = HorizontalAlign.Left;
        Header.Cells.Add(HeaderContent);
        Table1.Rows.Add(Header);
        
        if (Id != "") { RequestbyID(Id); }    //need to add an access check
    }
}