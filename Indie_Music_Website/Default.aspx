<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <link rel="stylesheet" href="css/StyleSheet.css"/>
    <link rel="stylesheet" href="css/responsive.css"/>
    <link rel="stylesheet" href="css/responsiveslides.css" />
    <script src="js/jquery.min.js"></script>
    <script src="js/responsiveslides.js"></script>
    <script>
        $(function () {
            $("#slider").responsiveSlides({
                auto: true,
                pager: false,
                nav: true,
                speed: 500,
                maxwidth: 962,
                namespace: "centered-btns"
            });
        });
    </script>
    <title>Indie Music: your music connector</title>
</head>
<body>
    <form id="form1" runat="server">
    <header style="background-color:#a4d5f7">
        <div style="height: auto; width:auto; margin-top:0px; float:inherit">
            <div style="float:left; width: 765px;">
                <img src="./images/Logo_header.jpg" />
            </div>
            <div style="float:right; width:auto">
                <asp:Button ID="LogStatusButton" runat="server" BackColor="#A4D5F7" BorderColor="White" BorderStyle="None" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Text="Log In" OnClick="LogInButton_Click" CssClass="pointercursor" />
                <asp:Button ID="SignUpButton" runat="server" BackColor="#A4D5F7" BorderStyle="None" Font-Bold="True" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Text="|    Sign Up" OnClick="SignUpButton_Click" CssClass="pointercursor" />
                     
                <asp:Panel ID="Panel1" runat="server" BackColor="#a4d5f7" BorderStyle="None" Visible="False">
                <div style="width:auto">
                    <div style="float:left; width:auto;" >
                    <asp:Label ID="UserNameLabel" runat="server" Text="Email:" Font-Bold="True" Font-Names="Calibri"></asp:Label>&nbsp;&nbsp;<br/> 
                    <asp:Label ID="PasswordLabel" runat="server" Text="Password:" Font-Bold="True" Font-Names="Calibri"></asp:Label>                       
                    </div>

                    <div style="float:left; width:auto; margin-right:5px">
                    <asp:TextBox ID="UserNameTextBox" runat="server" BorderStyle="None" Width="111px" ForeColor="#A4D5F7" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;<br/>
                    <asp:TextBox ID="PasswordTextBox" runat="server" BorderStyle="None" Width="111px" ForeColor="#A4D5F7"  TextMode="Password" MaxLength="50"></asp:TextBox>                      
                    </div><br/>
                    <div style="align-items:center;width:auto;float:right;cursor:pointer">
                    <asp:Button ID="LogInButton" runat="server" Text="Log In &gt;&gt;" BorderColor="White" BorderStyle="None" BackColor="#A4D5F7" Font-Bold="True" Font-Names="Calibri" Font-Size="Medium" ForeColor="White" Width="79px" OnClick="Button1_Click" CssClass="pointercursor" />  
                    <div/>
                </div>
                </asp:Panel>
              
            </div>
           
        </div>
    </header><br/><br/>

        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <links>
        <div class="menu" style>
            <ul style=" list-style:none;">
                <li class="current"><a href="Default.aspx">Home</a></li>
                <li><a href="Bands.aspx">Bands</a></li>
                <li><a href="Topiclist.aspx">Topics</a></li>
                <li><a href="Popular.aspx">The Popular...</a></li>
            </ul>
        </div>
    </links>

    <div class="slider">
        <div  class="rslides_container">
            <ul class="rslides" id="slider">
                <li><a href="#"><img src="images/slide1.png" /></a></li>
                <li><a href="#"><img src="images/slide2.png" /></a></li>
                <li><a href="#"><img src="images/slide3.png" /></a></li>
            </ul>
        </div>
    </div><br/>

    <div style="width:auto;height:auto; margin-left:30px;" >
        <div style="float:left; width:auto;margin-left:30px">
            <asp:TextBox ID="SearchBar" runat="server" BackColor="White" BorderColor="#A4D5F7" BorderStyle="Solid" BorderWidth="1px" Height="35px" Width="801px" >Search Topics, Bands, or Users you want to know</asp:TextBox>  
        </div>

        <div style="float:left; width:57px; margin-left:0">
            <asp:ImageButton ID="SearchButton" runat="server" ImageUrl="~/images/Search_button.jpg" BorderStyle="None" Height="39px" ImageAlign="Bottom" Width="50px" BackColor="#EEECEC" BorderWidth="0px" OnClick="SearchButton_Click" />
        </div> 
    </div>
    
        
    
    <div id="content">
        <div class="block01">
            <div class="heading"><a href="#"><img src="./images/Community_Logo.jpg"></a></div>
            <div class="row">
                <div class=" community "><a href="#"><h1>Black Dragon:   </h1></a></div>
                <div class="time"><h2>  - Last post: 13 mins ago</h2></div>
                <br />
                <div class="topic"><a href="123"><h3>- The Best Song I've Ever Heard</h3></a></div>
            </div>
            <div class="row">
                <div class=" community "><a href="#"><h1>Superman:   </h1></a></div>
                <div class="time"><h2>  - Last post: 27 mins ago</h2></div>
                <br />
                <div class="topic"><a href="123"><h3>- I got a HOT POSTER! Wanna see it?</h3></a></div>
            </div>
            <div class="row">
                <div class=" community "><a href="#"><h1>LetMeGuess:   </h1></a></div>
                <div class="time"><h2>  - Last post: 52 mins ago</h2></div>
                <br />
                <div class="topic"><a href="123"><h3>- Anyone wants in? Last Chance!</h3></a></div>
            </div>
        </div>

        <div class="block02">
            <div class="cover"><a href="Bands.htm"><img src="./images/cover2.jpg"></a></div>
            <div class="info">
                <br><br>
                Album: No Turning Back<br><br>
                Singer: Gui Boratto<br><br>
                Release: Aug 18, 2009<br><br>
                Length: 41:03<br><br>
                Producer: Kompakt Germany<br><br>
            </div>
        </div>

        <div class="block02">
            <div class="cover" style=" float:right"><a href="#"><img src="./images/cover1.jpg"></a></div>
            <div class="info" style="float:left">
                <br><br>
                Album: Meteor<br><br> 
                Singer: Linkin Park<br><br>
                Release: Mar 25, 2003<br><br>
                Length: 36:43<br><br>
                Producer: Warner Bros<br><br>
            </div>
        </div>
    </div>

    <footer>
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
    <div>


        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Users]"></asp:SqlDataSource>


    </div>
                
    </form>

                
</body>
</html>

