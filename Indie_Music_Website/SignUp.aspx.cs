using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

public partial class SignUp : System.Web.UI.Page
{
    string Id = "";
    protected bool RegChcek() // check input and if email exists in Database
    {
        string DOB = DOBMonthDropDownList.Text + '/' + DOBDayDropDownList.Text + '/' + DOBYearDropDownList.Text;
        RegTimeLabel.Text = DateTime.Now.ToString("M/d/yyyy"); DOBSumLabel.Text = DOB;

        /*DOB Check*/
        DateTime dDate;
        if (DateTime.TryParse(DOB, out dDate)) { DOBSumLabel.Text = DOB; } //detect date format
        else { InfoLabel.Text = "Invalid Date of Birth information!"; DOBLabel.ForeColor = Color.Red; return false; }
        
        /*Name Check*/
        if (NameTextBox.Text.Length < 20 && NameTextBox.Text != "") { }
        else { InfoLabel.Text = "Invalid User Name, User name must less than 20 characters "; NameLabel.ForeColor = Color.Red; return false; }
        
        /*Password confirm Check*/
        if (PasswordTextBox.Text == ConfirmTextBox.Text && PasswordTextBox.Text != "" && ConfirmTextBox.Text !="" ) { }
        else { InfoLabel.Text = "Input Password are different! "; ConfirmLabel.ForeColor = Color.Red; PasswordLabel.ForeColor = Color.Red; return false; }
       
        /*Email format Check*/
        if (EmailTextBox.Text.Contains("@") && (EmailTextBox.Text.Contains(".edu") || EmailTextBox.Text.Contains(".com"))) { }
        else if (EmailTextBox.Text.Contains("@") && (EmailTextBox.Text.Contains(".net") || EmailTextBox.Text.Contains(".gov"))) { }
        else if (EmailTextBox.Text.Contains("@") && EmailTextBox.Text.Contains(".") ) { }
        else { InfoLabel.Text = "Invalid Email address! "; EmailLabel.ForeColor = Color.Red; return false; }
        
        /*Email format Check*/
        if (GenderDropDownList.Text.Contains("M") || GenderDropDownList.Text.Contains("F") || GenderDropDownList.Text.Contains("Other")) { }
        else { InfoLabel.Text = "Invalid Gender Information! ";GenderLabel.ForeColor = Color.Red;  return false; }
       
        /*Exist Email  Check*/
        if (sqlqueryid(EmailTextBox.Text) == ""){}  //No Id found: Email not exist
        else{ InfoLabel.Text = "This Email Address already existed in system, please change another one! ";EmailLabel.ForeColor = Color.Red;  return false;}
        return true;
    }

    protected string sqlqueryid(string Email)
    {
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
        String sql1 = String.Format("SELECT Id FROM Users WHERE (Email) = '{0}'", Email); //get the Id
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(sql1, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Id = reader["Id"].ToString();
            }
            conn.Close();          
        }
        return Id;
    
    }

    protected void Page_Load(object sender, EventArgs e)
    {

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
            SqlDataSource1.Insert();
            Id = sqlqueryid(EmailTextBox.Text); //get the Id
            string URL = string.Format("Default.aspx?U={0}&Name={1}", Id, NameTextBox.Text);
            EmailLabel.Visible = false;
            NameLabel.Visible = false;
            ConfirmLabel.Visible = false;
            PasswordLabel.Visible = false;
            GenderLabel.Visible = false;
            DOBLabel.Visible = false;
            EmailTextBox.Visible = false;
            NameTextBox.Visible = false;
            ConfirmTextBox.Visible = false;
            PasswordTextBox.Visible = false;
            GenderDropDownList.Visible = false;
            DOBDayDropDownList.Visible = false;
            DOBMonthDropDownList.Visible = false;
            DOBYearDropDownList.Visible = false;
            RegImageButton.Visible = false;        
            Response.Redirect(URL);
        } 
            
           
    }
}