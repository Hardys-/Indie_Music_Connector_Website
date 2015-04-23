using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SearchResult : System.Web.UI.Page
{
    string Input = "";
    string U = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Input = string.Format("{0}", Request.QueryString["Input"]);         //get the topic Id
        U = string.Format("{0}", Request.QueryString["U"]);
        Label1.Text = "Search Result for \"" + Input + "\" :";

    }
}