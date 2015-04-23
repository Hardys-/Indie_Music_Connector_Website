using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
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
            TableCell c1 = new TableCell();
            TableCell c2 = new TableCell();
            TableCell c3 = new TableCell();
            header.ForeColor = Color.White;
            header.Font.Bold = true;
            header.Font.Name = "Calibri";
            c1.Text = "Post By";              //Owner of this topic, who post this topic
            c2.Text = "Topic";                // Topic tital
            c3.Text = "LastAction";           //last post time, upload when people post new comments
            header.Cells.Add(c1);
            header.Cells.Add(c2);
            header.Cells.Add(c3);
            Table1.Rows.Add(header);


            foreach (DataRow dr in dv.Table.Rows)  // add each row to table1
            {
                i++;
                TableRow row = new TableRow();
                TableCell item2 = new TableCell(); // we do not need to see the first item "id", so begin with item2
                TableCell item3 = new TableCell();
                TableCell LT = new TableCell(); //used to calculate the percentage.
                row.Cells.Add(item2);
                row.Cells.Add(item3);
                row.Cells.Add(LT);


                if (i % 2 == 0)           //dynamic background color even-> black & odd -> grey
                {
                    item2.BackColor = ColorTranslator.FromHtml("#434343");
                    LT.BackColor = ColorTranslator.FromHtml("#434343");
                    item3.BackColor = ColorTranslator.FromHtml("#434343");
                    item2.ForeColor = ColorTranslator.FromHtml("#ffffff");
                    LT.ForeColor = ColorTranslator.FromHtml("#ffffff");
                    item3.ForeColor = ColorTranslator.FromHtml("#ffffff");
                }
                else
                {
                    item2.BackColor = ColorTranslator.FromHtml("#dcdcdc");
                    LT.BackColor = ColorTranslator.FromHtml("#dcdcdc");
                    item3.BackColor = ColorTranslator.FromHtml("#dcdcdc");
                    item2.ForeColor = ColorTranslator.FromHtml("#080808");
                    LT.ForeColor = ColorTranslator.FromHtml("#080808");
                    item3.ForeColor = ColorTranslator.FromHtml("#080808");
                }
                
                //item2.BorderWidth = 2;
                item2.BorderColor = Color.White;
                item2.Width = 80;
                item2.ForeColor = Color.White;

                //item3.BorderWidth = 2;
                item3.BorderColor = Color.White;
                item3.Width =500;
                item3.HorizontalAlign = HorizontalAlign.Left;
                item3.ForeColor = Color.White;

                //LP.BorderWidth = 2;
                LT.BorderColor = Color.White;
                LT.Width = 150;
                LT.HorizontalAlign = HorizontalAlign.Right;
                LT.ForeColor = Color.White;

                string URL = string.Format("Topic.aspx?Id={0}&Name={1}", dr["Id"].ToString(), dr["OwnerName"].ToString());
                item2.Text = dr["OwnerName"].ToString();
                item3.Text = "<a href=\""+URL+"\">" + dr["Topic"].ToString() + "</a>";
                LT.Text = dr["LastTime"].ToString();

                Table1.Rows.Add(row);


            } 
        }

    }
}