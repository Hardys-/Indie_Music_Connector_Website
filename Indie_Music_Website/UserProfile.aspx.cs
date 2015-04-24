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
        Label1.Text = "pahse10";

        U = string.Format("{0}", Request.QueryString["U"]);         //get the User Id
        Name = string.Format("{0}", Request.QueryString["Name"]);
        Label1.Text = U + " "+ Name ;

        /*Searching User Information*/
        string DBEmail = "";
        string DBName = "";
        string DBGender = "";
        string DBPic = "";
        string DBDOB = "";
        string DBFriends = "";
        string DBRegTime = "";
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
                s = reader["DOB"].ToString();
                DBDOB = s.Substring(0, s.IndexOf(" ")); // only copy the date 
                DBFriends = reader["Friends"].ToString();
                s = reader["RegTime"].ToString();
                DBRegTime = s.Substring(0, s.IndexOf(" "));// only copy the date 
            }
            conn.Close();
        } 
        if( DBPic == "" ){DBPic = "/images/UserProfile/Default.jpg";} // if user did not upload profile pic
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

        UserInfo.Text =
            "<div style=\"float:left; width: auto\"><div style=\"float:left; width: 35%; margin-left:10px;\"><br/><img src=\""
            + DBPic + "\" width=\"100\" height=\"100\" /><br/>" +
            DBName + "</a><br/></div> <div style=\"float:left; margin-left: 30px; width: 50%\"><br/>"
            + "Followers: " + DBFriends + "<br/> Email: " + DBEmail + "<br/> Gender: " + DBGender +
            "<br/> Birthday:  " + DBDOB + "<br/> Est. " + DBRegTime +
            " </div></div><br/><br/>";

        row.Cells.Add(UserInfo);
        UserTable.Rows.Add(row);
        UserTable.CellPadding = 15;                      // Content Indent
        UserTable.Style.Add("width", "95% !important"); // Inline percentage of table width
    }
}