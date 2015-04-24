using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Input;
using System.Web.UI;
using System.Drawing;
using System.Data.SqlClient;  
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    string U ="" ; //U for tracking the user who Logged in

    protected void TryLogin(string Email, string pw) // user id(email) and user password
    {
        try
        {
            string DBName = "";
            string DBPW = "";
            string UserId = ""; //only in SQL search to check if user id existed
            String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
            String SQLNamePW = String.Format("SELECT Id,Name,PW FROM Users WHERE (Email) = '{0}'", Email); //get the password and username
            using (SqlConnection conn = new SqlConnection(connect))
            using (SqlCommand cmd = new SqlCommand(SQLNamePW, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DBName = reader["Name"].ToString();   //get the Name in DB
                    DBPW = reader["PW"].ToString();       //get the pasword in DB
                    UserId = reader["Id"].ToString();
                }
                conn.Close();
            }
            if (DBPW == pw)    // correct infomation
            {
                U = UserId;   //U != "" means that user has logged in
                LogStatusButton.Text = DBName;     //display user name
                LogStatusButton.ForeColor = ColorTranslator.FromHtml("#fd5b5b");
                SignUpButton.Text = "|  Log Out";
                Panel1.Visible = false;
                UserIdLabel.Text = U ;
            }
            else 
            {
                UserNameTextBox.Text = "Email or Password may incorrect";
                PasswordTextBox.Text = "Password may incorrect";
            }

        }
        catch (Exception m)// For exceptions 
        {
            if (m.Source != null)
                Console.WriteLine("Exception source: {0}", m.Source);  // output exception source in console 
            throw;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //page redirection check for UserID
        if(U == "") { U = string.Format("{0}", Request.QueryString["U"]);}
        string Name = string.Format("{0}", Request.QueryString["Name"]);
        if(U !="" && Name != "") // information found
        {
                LogStatusButton.Text = Name;     //display user name
                LogStatusButton.ForeColor = ColorTranslator.FromHtml("#fd5b5b");
                SignUpButton.Text = "|  Log Out";
                Panel1.Visible = false;    
        }
    }


    protected void SearchButton_Click(object sender, ImageClickEventArgs e)
    {
        
        string URL = string.Format("SearchResult.aspx?Input={0}&U={1}", SearchBar.Text, U);
        Response.Redirect(URL);
    }


    protected void LogStatusButton_Click(object sender, EventArgs e)
    {
        //check if logged in 
        
        if (U == "" && LogStatusButton.Text == "Log In") { Panel1.Visible = true;} // not login
        else if (UserIdLabel.Text != ""  &&  LogStatusButton.Text != "Log In") //already login
        {
            string UserURL = string.Format("UserProfile.aspx?U={0}&Name={1}", UserIdLabel.Text, LogStatusButton.Text);//redirect to user page
            Response.Redirect(UserURL);
        }
    }


    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        if (U == "" && LogStatusButton.Text == "Log In") { Response.Redirect("SignUp.aspx"); }
        else 
        {
            U = "";   //U != "" Logged out
            LogStatusButton.Text = "Log In";     //display user name
            LogStatusButton.ForeColor = ColorTranslator.FromHtml("#ffffff");
            SignUpButton.Text = "|  Sign Up";
            Panel1.Visible = false;
            Response.Redirect("Default.aspx");

        }
    }


    protected void LogInButton_Click(object sender, EventArgs e)
    {
        string user = UserNameTextBox.Text;
        string pw =  PasswordTextBox.Text;
        if( U == "" && user != "" && pw != "" ) { TryLogin(user,pw);} //Only can login when user not did that
    }
}