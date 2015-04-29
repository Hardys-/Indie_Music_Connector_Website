<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BandProfile.aspx.cs" Inherits="BandProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="css/StyleSheet.css"/>
    <title>Band Profile</title>
</head>
<body>
    <form id="form1" runat="server">
    <header>
        <div><a href="#"><img src="./images/Logo_header.jpg" /></a></div>
    </header>
    <!--    <div>
        <audio controls = "controls">
            <source src="test_music.mp3" type="audio/mpeg"/>
            Your browser does not support the audio element.
        </audio>
    </div>-->
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
    </links><br/><br/>

    <div style="background-color:#ffffff; float:left;margin-left:2%; width:98%">
        <div>
            <br/>
             &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="LikeButton" runat="server" OnClick="LikeButton_Click" Text="Likes" BackColor="White" BorderStyle="None" Font-Bold="True" Font-Names="Calibri" ForeColor="#4498D2" style="height: 21px" />
            <br/>
            <asp:Table ID="BandTable" runat="server" BorderStyle="None" BorderWidth="0px" HorizontalAlign="Center" Width="243px"> </asp:Table>
        </div>
        <br/><br/><br/><p style="font-size:18px">Grenn Day</p>
    </div>
        
    <div>
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
