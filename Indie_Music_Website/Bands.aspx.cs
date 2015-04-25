using System;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Bands : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int i = 0;  // i used for count the number of the row
        DataView dv = (DataView)DSBand.Select(DataSourceSelectArguments.Empty);
        if (dv != null)  //Exception Detect
        {

            /*-----------------------------------------------Table  Header-----------------------------------------------*/
            TableHeaderRow header = new TableHeaderRow();
            TableCell ActerName = new TableCell();
            header.ForeColor = ColorTranslator.FromHtml("#a4d5f7");
            header.Font.Bold = true;
            header.Font.Name = "Calibri";
            ActerName.Text = "Band or Singer";
            ActerName.HorizontalAlign = HorizontalAlign.Left;
            header.Cells.Add(ActerName);
            BandTable.Rows.Add(header);


            foreach (DataRow dr in dv.Table.Rows)  // add each row to table1
            {
                i++;
                TableRow row = new TableRow();
                TableCell BandInfo = new TableCell(); // we do not need to see the first item "id", so begin with item2
                row.Cells.Add(BandInfo);


                if (i % 2 == 0)           //dynamic background color even-> black & odd -> grey
                {
                    BandInfo.BackColor = ColorTranslator.FromHtml("#a4d5f7");
                    BandInfo.ForeColor = ColorTranslator.FromHtml("#ffffff");

                }
                else
                {

                    BandInfo.BackColor = ColorTranslator.FromHtml("#4498d2");
                    BandInfo.ForeColor = ColorTranslator.FromHtml("#ffffff");

                }


                BandInfo.HorizontalAlign = HorizontalAlign.Left;
                BandInfo.Font.Name = "Calibri";
                /* Output format: use <div></div> wrap information  
                 * URL linked to the band profile page and transfer the infomation of the page to that one
                   ProfilePic for the path of the pictures
                */
                string URL = string.Format("BandProfile.aspx?Id={0}&Name={1}", dr["Id"].ToString(), dr["Name"].ToString());               
                string ProfilePic = dr["Pic"].ToString();
                string dateString = dr["EstTime"].ToString();
                DateTime DBdate = DateTime.Parse(dateString,System.Globalization.CultureInfo.InvariantCulture); 

                BandInfo.Text =
                    "<div style=\"float:left; width: auto\"><div style=\"float:left; width: 20%; margin-left:10px;\"><br/><a href=\"" + URL + "\"><img src=\"" 
                    + ProfilePic + "\" width=\"100\" height=\"100\" /><br/>" +
                    dr["Name"].ToString() + "</a><br/><font style=\"font-size:10px;\">" +
                    "Est. " + DBdate.Year.ToString()  +
                    "<br/>Followers: " + dr["Followers"].ToString() + "</font></div> <div style=\"float:left;width: 75%\"><br/>" +
                    dr["Content"].ToString() + " <a href=\"" + URL + "\"> Read More>>  </a></div></div><br/><br/>";


                BandTable.Rows.Add(row);
                BandTable.CellPadding = 15;                      // Content Indent
                BandTable.Style.Add("width", "90% !important"); // Inline percentage of table width
                    
            }
        }

    }
}