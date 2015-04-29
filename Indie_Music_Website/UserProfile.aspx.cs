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
    string I ="";

    protected void Page_Load(object sender, EventArgs e)
    {

        U = string.Format("{0}", Request.QueryString["U"]);         //get the User Id
        Name = string.Format("{0}", Request.QueryString["Name"]);
        I = string.Format("{0}", Request.QueryString["I"]);

        /*Searching User Information Initialization*/
        int DBUserId = 1;
        string DBEmail = ""; 
        string DBName = "";
        string DBGender = "F";
        string DBPic = "";
        string DBFriends = "";
        string dateString1 = "1/1/1988 00:00:00 AM";
        string dateString2 = "1/1/1988 00:00:00 AM";
        string DBFriendsList = "Followers: <Br/>"; //pic list of user's friends

        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser= String.Format("SELECT * FROM Users WHERE (Id) = '{0}' AND (Name) = '{1}'", U, Name); //get the password and username
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all user's information need to be displaied in this page
            {
                DBUserId = int.Parse(reader["Id"].ToString()); //get the user Id for later use in friend search
                DBEmail = reader["Email"].ToString();          //get the Email in DB
                DBName = reader["Name"].ToString();            //get the Name in DB
                DBGender = reader["Gender"].ToString();        //get the Gender in DB
                DBPic = reader["Pic"].ToString();
                dateString1 = reader["DOB"].ToString();
                DBFriends = reader["Friends"].ToString();
                dateString2 = reader["RegTime"].ToString();

            }
            conn.Close();
        } 
        if( DBPic == "" ){ DBPic = "/images/UserProfile/Default.jpg";} // if user did not upload profile pic

        /*Searching Friends information*/
        String SQLFriend = String.Format("SELECT Pic, Id, Name  FROM Users WHERE Id in (SELECT  User2ID FROM Friends WHERE (User1ID) = '{0}' AND (UserEmail1) = '{1}')", DBUserId, DBEmail); //get the Friend published by this band
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd2 = new SqlCommand(SQLFriend, conn))
        {
            conn.Open();
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())     //get all Album information need to be displaied in this page
            {
                string NewURL = string.Format("UserProfile.aspx?U={0}&Name={1}", reader2["Id"].ToString(), reader2["Name"].ToString());//redirect to user page
                string DBFriendAvater = reader2["Pic"].ToString();
                if (DBFriendAvater == "") { DBFriendAvater= "/images/UserProfile/Default.jpg";} // If user do not have a avater
                DBFriendsList += "<a href= \"" + NewURL + "\"><img src=\"" + DBFriendAvater + "\" width=\"35\" height=\"35\" style=\"border:1px; border-color:#a4d5f7\" /></a>";
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
            "<div style=\"float:left; width: 80%\"><div style=\"float:left; width: 150; margin-left:20px;\"><br/><br/><img src=\""
            + DBPic + "\" width=\"100\" height=\"100\" /><br/>" +
            DBName + "<br/>Followers: " + DBFriends + "<br/></div> <div style=\"float:left; margin-left: 20px; width: 50%\"><br/><br/>"
            + "Email: " + DBEmail + "<br/> Gender: " + DBGender +
            "<br/> Birthday:  " + DBDOB.Month.ToString() + "/" + DBDOB.Day.ToString() + "/" + DBDOB.Year.ToString() + "<br/> Est. " + DBRegTime.Date.ToString() +
            " </div><div style=\"float:left; margin-left: 20px; width: 40%\"><br/>" + DBFriendsList + "<div></div>";

        row.Cells.Add(UserInfo);
        UserTable.Rows.Add(row);
        UserTable.CellPadding = 15;                      // Content Indent
        UserTable.Style.Add("width", "95% !important");  // Inline percentage of table width
        //OperationPanel.Style.Add("width", "95% !important");        // Uniform width setting
        //UpdatePanel.Style.Add("width", "95% !important");           // Uniform width setting
        //PostTopicPanel.Style.Add("width", "95% !important");        // Uniform width setting


        if (I != U) { OperationPanel.Visible = false; }

        /*-------------------User operations-----------------------*/
        if ( I == U)    // leave blank for user info check
        {
            /*Initial database information*/
            EmailTextBox.Text = DBEmail;
            NameTextBox.Text = DBName;
            if (GenderDropDownList.Items.Contains(new ListItem(DBGender))) GenderDropDownList.Text = DBGender;
            if (DBDOB.Month.ToString().Length == 1) { DOBMonthDropDownList.Text = "0" + DBDOB.Month.ToString(); } else { DOBMonthDropDownList.Text = DBDOB.Month.ToString(); }
            if (DBDOB.Day.ToString().Length == 1) { DOBDayDropDownList.Text = "0" + DBDOB.Day.ToString(); } else { DOBDayDropDownList.Text = DBDOB.Day.ToString(); }
            DOBYearDropDownList.Text = DBDOB.Year.ToString();
        }

        /*--------------End of User Operations-----------------------*/
    }


    protected void RegImageButton_Click(object sender, ImageClickEventArgs e)
    {
        /*forecolor initialization*/
        EmailLabel.ForeColor = Color.Black;
        NameLabel.ForeColor = Color.Black;
        ConfirmLabel.ForeColor = Color.Black;
        PasswordLabel.ForeColor = Color.Black;
        GenderLabel.ForeColor = Color.Black;
        DOBLabel.ForeColor = Color.Black;

        if (RegChcek())// insert value if valid
        {
            DSUser.Update();
            InfoLabel.Text = "Your Information has been successfully Updated!";
        } 
    }

    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        if (UpdatePanel.Visible == false && I == U) { UpdatePanel.Visible = true; }
    }


    protected void PostButton_Click(object sender, EventArgs e)
    {
        if (PostTopicPanel.Visible == false && I == U) { PostTopicPanel.Visible = true; }
    }


    protected bool RegChcek() // check input and if email exists in Database
    {
        string DOB = DOBMonthDropDownList.Text + '/' + DOBDayDropDownList.Text + '/' + DOBYearDropDownList.Text;

        /*DOB Check*/
        DateTime dDate;
        if (DateTime.TryParse(DOB, out dDate)) { DOBSumLabel.Text = DOB; } //detect date format
        else { InfoLabel.Text = "Invalid Date of Birth information!"; DOBLabel.ForeColor = Color.Red; return false; }

        /*Name Check*/
        if (NameTextBox.Text.Length < 20 && NameTextBox.Text != "") { }
        else { InfoLabel.Text = "Invalid User Name, User name must less than 20 characters "; NameLabel.ForeColor = Color.Red; return false; }

        /*Password confirm Check*/
        if (PasswordTextBox.Text == ConfirmTextBox.Text && PasswordTextBox.Text != "" && ConfirmTextBox.Text != "") { }
        else { InfoLabel.Text = "Input Password are different! "; ConfirmLabel.ForeColor = Color.Red; PasswordLabel.ForeColor = Color.Red; return false; }

        /*Email format Check*/
        if (GenderDropDownList.Text.Contains("M") || GenderDropDownList.Text.Contains("F") || GenderDropDownList.Text.Contains("Other")) { }
        else { InfoLabel.Text = "Invalid Gender Information! "; GenderLabel.ForeColor = Color.Red; return false; }

        return true;
    }


    protected void PostTopicButton_Click(object sender, EventArgs e)
    {
        if(CommentTextBox.Text != "" && TopicTextBox.Text!="")
        {
            String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
            String SQLInsert = "INSERT INTO Topic (Owner,Likes,PostTime,LastTime,Topic,OwnerName) VALUES(@Ownerid,0, @nowtime,@nowtime, @Topic, @OwnerName)";//insert into topic table
            string nowtime = DateTime.Now.ToString("M/d/yyyy HH:mm:ss tt");
            using (SqlConnection conn = new SqlConnection(connect))
            using (SqlCommand cmd = new SqlCommand(SQLInsert, conn))
            {
                conn.Open();
                cmd.Parameters.Add("@Ownerid", int.Parse(I));
                cmd.Parameters.Add("@nowtime", nowtime);
                cmd.Parameters.Add("@Topic", TopicTextBox.Text);
                cmd.Parameters.Add("@OwnerName", Name);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            String SQLInsertComment = "INSERT INTO Comments (TopicId,OwnerId,Likes,PostTime,Content,OwnerName) VALUES(@Topicid, @OwnerId, 0, @nowtime, @Content, @OwnerName)";//insert into Comment table
            using (SqlConnection conn = new SqlConnection(connect))
            using (SqlCommand cmd = new SqlCommand(SQLInsertComment, conn))
            {
                conn.Open();

                cmd.Parameters.Add("@Topicid", GetTopicId(TopicTextBox.Text, int.Parse(I)));
                cmd.Parameters.Add("@OwnerId", int.Parse(I));
                cmd.Parameters.Add("@nowtime", nowtime);
                cmd.Parameters.Add("@Content", CommentTextBox.Text);
                cmd.Parameters.Add("@OwnerName", Name);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            string TopicURL = string.Format("Topic.aspx?Id={0}&Name={1}&Title={2}&I={3}", GetTopicId(TopicTextBox.Text, int.Parse(I)).ToString(), Name, TopicTextBox.Text,I);
            Response.Redirect(TopicURL);
        
        }
        
    }

    protected int GetTopicId(string T, int OID)// topic & OwnerId(UserId)
    {
        int ResultTopicId = 0;
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLUser = String.Format("SELECT Id FROM Topic WHERE (Topic = '{0}') AND (Owner = '{1}')", T, OID); //get the password and username
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLUser, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all user's information need to be displaied in this page
            {
                ResultTopicId = (int)reader["Id"];
            }
            conn.Close();
        } 
        return ResultTopicId;
    }
}