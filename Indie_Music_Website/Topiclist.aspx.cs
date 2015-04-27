using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Topiclist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;  // i used for count the number of the row
        DataView dv = (DataView)DSTopic.Select(DataSourceSelectArguments.Empty);
        if (dv != null)  //Exception Detect
        {
           
            /*-----------------------------------------------Table  Header-----------------------------------------------*/
            TableHeaderRow header = new TableHeaderRow();
            TableCell TopicContent = new TableCell();;
            header.ForeColor = ColorTranslator.FromHtml("#a4d5f7");
            header.Font.Bold = true;
            header.Font.Name = "Calibri";
            TopicContent.Text = "Topics:";              //List of each topic
            TopicContent.HorizontalAlign = HorizontalAlign.Left;
            header.Cells.Add(TopicContent);
            Table1.Rows.Add(header);


            foreach (DataRow dr in dv.Table.Rows)      // add each row to table1
            {
                i++;
                TableRow row = new TableRow();
                TableCell Content = new TableCell(); // Topic Info for each topic
                


                if (i % 2 == 0)           //dynamic background color even-> black & odd -> grey
                {
                    Content.BackColor = ColorTranslator.FromHtml("#a4d5f7");
                    Content.ForeColor = ColorTranslator.FromHtml("#ffffff");
                }
                else
                {
                    Content.BackColor = ColorTranslator.FromHtml("#4498d2");
                    Content.ForeColor = ColorTranslator.FromHtml("#ffffff");
                }
                

                Content.HorizontalAlign = HorizontalAlign.Left;
                Content.Font.Name = "Calibri";

                string TopicURL = string.Format("Topic.aspx?Id={0}&Name={1}&Title={2}", dr["Id"].ToString(), dr["OwnerName"].ToString(), dr["Topic"].ToString());
                string UserURL = string.Format("UserProfile.aspx?U={0}&Name={1}", dr["Owner"].ToString(), dr["OwnerName"].ToString());//redirect to user page

                Content.Text = "<a href=\"" + UserURL + "\" style=\"color:#ffffff\" >"
                    + "<img src=\"" + GetPicById(int.Parse(dr["Owner"].ToString())) + "\" width=\"15\" height=\"15\"  style=\"border:1px; border-color:#a4d5f7\"/> &nbsp;" + dr["OwnerName"].ToString() + "</a>"  //Poster
                    + "&nbsp;&nbsp;<div style=\"font-size:10px\">" + dr["LastTime"].ToString() + "</div><br/>"  // Post time
                    + "<a href=\"" + TopicURL + "\">" + dr["Topic"].ToString() + "</a><br/>";             // Topic
                                    

                
                row.Cells.Add(Content);
                Table1.Rows.Add(row);
                Table1.CellPadding = 15;                      // Content Indent
                Table1.Style.Add("width", "95% !important");  // Inline percentage of table width

            } 
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

}