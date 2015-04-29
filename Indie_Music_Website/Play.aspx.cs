using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Play : System.Web.UI.Page
{
    string AlbumId = "";
    //string AlbumName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AlbumId = string.Format("{0}", Request.QueryString["AlbumId"]);         //get the Band Id
        //AlbumName = string.Format("{0}", Request.QueryString["AlbumName"]);   //get the Band Name

        
        TableRow row = new TableRow();
        TableCell MusicInfo = new TableCell();
       
        String connect = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Database.mdf;Integrated Security=True";//connect to our database
        String SQLBand = String.Format("SELECT * FROM Songs WHERE (Album) = '{0}'", AlbumId); //get the password and username
        using (SqlConnection conn = new SqlConnection(connect))
        using (SqlCommand cmd = new SqlCommand(SQLBand, conn))
        {
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())     //get all Band's information need to be displaied in this page
            {
                string SongURL = reader["Path"].ToString(); if (SongURL == "") { ;} //default music------------------------
                string player = reader["Name"].ToString() + "&nbsp;&nbsp;<audio controls = \"controls\"><source src=\"" + SongURL + "\" type=\"audio/mpeg\"/>Your browser does not support the audio element.</audio>";
                MusicInfo.Text += player + "<br/>";
            }
            conn.Close();
        }
        
        row.Cells.Add(MusicInfo);
        Table1.Rows.Add(row);   


    }
}