<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Bands.aspx.cs" Inherits="Bands" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/StyleSheet.css"/>
    <title>Band List</title>
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <div><a href="#"><img src="./images/Logo_header.jpg"/></a></div>
    </header>

    <links>
        <div class="menu" >
            <ul style=" list-style:none;">
                <li><a href="Default.aspx" >Home</a></li>
                <li class="current"><a href="Bands.aspx">Bands</a></li>
                <li><a href="Topiclist.aspx">Topics</a></li>
                <li><a href="Popular.aspx">The Popular...</a></li>
            </ul>
        </div>
        <br/><br/>
    </links>
    <br/><br/>
    <div style=" background-color:grey;">
        <div style=" background-color:white;float:left;margin-left:2%; width:95%">
            <asp:Label ID="Label1" runat="server" ForeColor="Red" Text="Label1234567" Visible="False"></asp:Label> 
            <asp:Table ID="BandTable" runat="server" Height="25px" BorderStyle="None" BorderWidth="0px" Width="29px" HorizontalAlign="Center">
             </asp:Table>
             <asp:SqlDataSource ID="DSBand" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Band]"></asp:SqlDataSource>
     
             
     
             <br />
        </div>
    </div>


 <footer>
        <div class="box" style="padding:20px;">
            <div class="box1">
                <div class="heading">Like us on</div>
                <div class="column">
                    <ul style=" list-style:none;">
                        <li><a href="http://www.facebook.com/"><img src="./images/Bottom_Fackook_Logo.jpg" style="width:120px; height:30px" /></a></li>
                        <li><a href="http://www.google.com/"><img src="./images/Bottom_google_Logo.jpg" style="width:120px; height:30px" /></a></li>
                        <li><a href="http://www.twitter.com/"><img src="./images/Bottom_twitter_Logo.jpg" style="width:120px; height:30px" /></a></li>
                    </ul>
                </div>
            </div>

            <div class="box1">
                <div class="heading">Company</div>
                <div class="column">
                    <ul style=" list-style:none;">
                        <li>people</li>
                        <li>About Us</li>
                        <li><a href="Contact.htm">Contact</a></li>
                    </ul>
                </div>
            </div>

            <div class="box1">
                <div class="heading">Information</div>
                <div class="column">
                    <ul style=" list-style:none;">
                        <li>Privacy</li>
                        <li>Terms</li>
                        <li>Help</li>
                    </ul>
                </div>
            </div>
        </div>
        <div class="copyright ">© 2015 Indie Music. All Rights Reserved</div>
        
    </footer>
    </form>
</body>
</html>
