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

     protected void RequestbyID(string id)
    {
        try             
        {
            int i = 0; 
            String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";
            String sql1 = String.Format("SELECT OwnerName,Content,PostTime FROM Comments WHERE (TopicId) = '{0}'", id); //get the content of the same topic id
            using (SqlConnection conn = new SqlConnection(connect))
            using (SqlCommand cmd = new SqlCommand(sql1, conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    i++;
                    TableRow row = new TableRow();
                    TableCell item0 = new TableCell();
                    TableCell item1 = new TableCell();
                    TableCell item2 = new TableCell();
                    item0.Text = "<br/>" + reader["OwnerName"].ToString() + "<br/><br/>";
                    item1.Text ="<br/>"+reader["Content"].ToString()+"<br/><br/>";
                    item2.Text = "<br/>" + reader["PostTime"].ToString() + "<br/><br/>";
                    item2.Font.Size = 8;

                    if (i % 2 == 0)           //dynamic background color even-> black & odd -> grey
                    {
                        item2.BackColor = ColorTranslator.FromHtml("#434343");   //Transfer HEX value color 
                        item1.BackColor = ColorTranslator.FromHtml("#434343");
                        item0.BackColor = ColorTranslator.FromHtml("#434343");
                        item2.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        item1.ForeColor = ColorTranslator.FromHtml("#ffffff");
                        item0.ForeColor = ColorTranslator.FromHtml("#ffffff");
                    }
                    else 
                    {
                        item2.BackColor = ColorTranslator.FromHtml("#dcdcdc");
                        item1.BackColor = ColorTranslator.FromHtml("#dcdcdc");
                        item0.BackColor = ColorTranslator.FromHtml("#dcdcdc");
                        item2.ForeColor = ColorTranslator.FromHtml("#080808");
                        item1.ForeColor = ColorTranslator.FromHtml("#080808");
                        item0.ForeColor = ColorTranslator.FromHtml("#080808");
                    }

                    item0.Width = 120;
                    item0.HorizontalAlign = HorizontalAlign.Left;
                    item0.VerticalAlign = VerticalAlign.Top;
                    item2.Width = 100; 
                    item2.HorizontalAlign = HorizontalAlign.Center;
                    item2.VerticalAlign = VerticalAlign.Top;
                    row.Cells.Add(item0);
                    row.Cells.Add(item1);
                    row.Cells.Add(item2);                   
                    Table1.Rows.Add(row);
                    Table1.CellPadding = 6;                      // Content Indent
                    Table1.Style.Add("width", "90% !important"); // Inline percentage of table width
                    
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

    protected void Page_Load(object sender, EventArgs e)
    {
        Id = string.Format("{0}", Request.QueryString["Id"]);         //get the topic Id
        Name = string.Format("{0}",  Request.QueryString["Name"]);
        if (Id != "") { RequestbyID(Id); }    //need to add an access check
    }
}