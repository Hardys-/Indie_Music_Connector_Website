<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>
  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" href="css/StyleSheet.css"/>
    <title>User Profile</title>
</head>
<body>
    <form id="form2" runat="server">
    <header>
        <div><a href="#"><img src="./images/Logo_header.jpg" /></a></div>
    </header>

    <links>
        <div class="menu">
            <ul style=" list-style:none;">
                <li><a href="Default.aspx">Home</a></li>
                <li><a href="Bands.aspx">Bands</a></li>
                <li><a href="Topiclist.aspx">Topics</a></li>
                <li><a href="Popular.aspx">The Popular...</a></li>
            </ul>
        </div>
        <br/><br/>
    </links>
    <br/><br/>
    <div style="background-color:#ffffff; float:left;margin-left:2%; width:98%">

        <div>
            <asp:Table ID="UserTable" runat="server" BorderStyle="None" BorderWidth="0px" HorizontalAlign="Center" Width="243px">
            </asp:Table>
        </div>

        <br/><br/>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br/>
        <asp:SqlDataSource ID="DSUser" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>
        <br/><br/>
    </div>
        
    <footer><br/>
        <div class="box">
            <div class="box1">
                <div class="heading">Like us on</div>
                <div class="column">
                    <ul style=" list-style:none;">
                        <li><a href="http://www.facebook.com/"><img src="./images/Bottom_Fackook_Logo.jpg" style="width:45%" /></a></li>
                        <li><a href="http://www.google.com/"><img src="./images/Bottom_google_Logo.jpg" style="width:45%" /></a></li>
                        <li><a href="http://www.twitter.com/"><img src="./images/Bottom_twitter_Logo.jpg" style="width:45%" /></a></li>
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
