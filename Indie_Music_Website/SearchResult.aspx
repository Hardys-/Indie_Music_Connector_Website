<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchResult.aspx.cs" Inherits="SearchResult" %>
  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
    <link rel="stylesheet" href="css/StyleSheet.css"/>
    <title>SearchResult</title>
</head>
<body>
    <form id="form2" runat="server">
    <header>
        <div><a href="#"><img src="./images/Logo_header.jpg" /></a></div>
    </header>

    <links>
        <div class="menu">
            <ul style=" list-style:none;">
                <li><a href="Default.aspx" style="color:#ff4040">Back to Homepage</a></li>
            </ul>
        </div>
        <br/><br/>
    </links>
    <br/><br/>
    <div style="background-color:#ffffff; float:left;margin-left:2%; width:98%">
        <div style="margin-left:28px"><br/>

            
            <asp:TextBox ID="SearchTextBox" runat="server" BorderColor="#A4D5F7" BorderStyle="Solid" Height="23px" style="margin-bottom: 0px" Width="530px"></asp:TextBox>
            <asp:Button ID="SearchButton" runat="server" BackColor="#A4D5F7" BorderColor="#A4D5F7" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" ForeColor="White" Height="29px" Text="Re-Search" OnClick="SearchButton_Click" />
        </div>
        
        <div>
        
            
            <asp:Table ID="SearchTable" runat="server" HorizontalAlign="Center" Width="295px">
            </asp:Table>
        
        
        </div>
        <br/><br/>
        <br/><br/><br/>
    </div><br/>
        
    <div style="margin-bottom:20px"><footer><br/>
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

    </footer></div>
    </form>
</body>
</html>
