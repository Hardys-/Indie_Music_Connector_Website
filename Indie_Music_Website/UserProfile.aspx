<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserProfile.aspx.cs" Inherits="UserProfile" %>
  
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head  runat="server">
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
        <br/>

        <div style="margin-left:26px;margin-right:26px"> <!--Panel Width setting-->
        <asp:Panel ID="OperationPanel" runat="server" BackColor="#A4D5F7" BorderColor="White" BorderStyle="Solid" HorizontalAlign="Center">
            <br />
            <div style="font-family:Calibri;font-size:16px; font-weight: bold; color:#ffffff; margin-bottom: 0px;">You can either:</div>
            <br />
            <asp:Button ID="UpdateButton" runat="server" BackColor="#A4D5F7" BorderColor="White" BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Update Profile" OnClick="UpdateButton_Click" />&nbsp;&nbsp;
            <asp:Button ID="UploadAvaterButton" runat="server" BackColor="#A4D5F7" BorderColor="White" BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Upload Avater" />
            &nbsp;&nbsp;
            <asp:Button ID="PostButton" runat="server" BackColor="#A4D5F7" BorderColor="White" BorderStyle="Solid" Font-Bold="True" ForeColor="White" Text="Start a Topic" OnClick="PostButton_Click" />&nbsp;&nbsp;
            <br />
            <br />
            <br />
        </asp:Panel>
        </div>

        <div style="margin-left:26px;margin-right:26px"> <!--Panel Width setting-->
        <asp:Panel ID="UpdatePanel" runat="server" BackColor="#4498D2" BorderColor="White" BorderStyle="Solid" Visible="False"><br/><br/>&nbsp;&nbsp;&nbsp;
            <asp:Label ID="InfoLabel" runat="server" Text=" " Font-Bold="True" Font-Names="Calibri" ForeColor="#FF5050"></asp:Label>
        <div style="width:auto; margin-left:200px; margin-right:auto">
            <div style="float:left; width:auto; margin-left:5px;">
                <br />
                <br />
                <asp:Label ID="EmailLabel" runat="server" Text="Email:" Font-Size="Large" ForeColor="White"></asp:Label><br/><br/>
                <asp:Label ID="NameLabel" runat="server" Text="Name:" Font-Size="Large" ForeColor="White"></asp:Label><br/><br/>
                <asp:Label ID="PasswordLabel" runat="server" Text="Password:" Font-Size="Large" ForeColor="White"></asp:Label><br/><br/>
                <asp:Label ID="ConfirmLabel" runat="server" Text="Confirm Password:" Font-Size="Large" ForeColor="White"></asp:Label><br/><br/>
                <asp:Label ID="GenderLabel" runat="server" Text="Gender:" Font-Size="Large" ForeColor="White"></asp:Label><br/><br/>
                <asp:Label ID="DOBLabel" runat="server" Text="Date of Birth:" Font-Size="Large" ForeColor="White"></asp:Label><br/><br/>
            </div>
            <div style="float:left; width:auto;margin-left:5px;">
                <br />
                <br />
                <asp:TextBox ID="EmailTextBox" runat="server" Height="17px" MaxLength="50" BorderStyle="None" Enabled="False"></asp:TextBox><br/><br/>
                <asp:TextBox ID="NameTextBox" runat="server" Height="17px" MaxLength="50" BorderStyle="None"></asp:TextBox><br/><br />
                <asp:TextBox ID="PasswordTextBox" runat="server" Height="17px" MaxLength="50" TextMode="Password" BorderStyle="None"></asp:TextBox><br/><br/>
                <asp:TextBox ID="ConfirmTextBox" runat="server" Height="17px" MaxLength="50" TextMode="Password" BorderStyle="None"></asp:TextBox><br/><br/>
                <asp:DropDownList ID="GenderDropDownList" runat="server" Height="20px">
                    <asp:ListItem Value="M">Male</asp:ListItem>
                    <asp:ListItem Value="F">Female</asp:ListItem>
                    <asp:ListItem Value="Other">Other</asp:ListItem>
                </asp:DropDownList><br/><br/>
                <asp:DropDownList ID="DOBMonthDropDownList" runat="server" Height="20px">
                    <asp:ListItem Selected="True">Month</asp:ListItem>
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem></asp:ListItem>
                </asp:DropDownList>
                <asp:DropDownList ID="DOBDayDropDownList" runat="server" Height="20px">
                    <asp:ListItem>Day</asp:ListItem>
                    <asp:ListItem>01</asp:ListItem>
                    <asp:ListItem>02</asp:ListItem>
                    <asp:ListItem>03</asp:ListItem>
                    <asp:ListItem>04</asp:ListItem>
                    <asp:ListItem>05</asp:ListItem>
                    <asp:ListItem>06</asp:ListItem>
                    <asp:ListItem>07</asp:ListItem>
                    <asp:ListItem>08</asp:ListItem>
                    <asp:ListItem>09</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                    <asp:ListItem>11</asp:ListItem>
                    <asp:ListItem>12</asp:ListItem>
                    <asp:ListItem>13</asp:ListItem>
                    <asp:ListItem>14</asp:ListItem>
                    <asp:ListItem>15</asp:ListItem>
                    <asp:ListItem>16</asp:ListItem>
                    <asp:ListItem>17</asp:ListItem>
                    <asp:ListItem>18</asp:ListItem>
                    <asp:ListItem>19</asp:ListItem>
                    <asp:ListItem>20</asp:ListItem>
                    <asp:ListItem>21</asp:ListItem>
                    <asp:ListItem>22</asp:ListItem>
                    <asp:ListItem>23</asp:ListItem>
                    <asp:ListItem>24</asp:ListItem>
                    <asp:ListItem>25</asp:ListItem>
                    <asp:ListItem>26</asp:ListItem>
                    <asp:ListItem>27</asp:ListItem>
                    <asp:ListItem>28</asp:ListItem>
                    <asp:ListItem>29</asp:ListItem>
                    <asp:ListItem>30</asp:ListItem>
                    <asp:ListItem>31</asp:ListItem>
                 </asp:DropDownList>
             <asp:DropDownList ID="DOBYearDropDownList" runat="server" Height="20px" Width="65px">
                <asp:ListItem>Year</asp:ListItem>
                <asp:ListItem>2015</asp:ListItem>
                <asp:ListItem>2014</asp:ListItem>
                <asp:ListItem>2013</asp:ListItem>
                <asp:ListItem>2012</asp:ListItem>
                <asp:ListItem>2011</asp:ListItem>
                <asp:ListItem>2010</asp:ListItem>
                <asp:ListItem>2009</asp:ListItem>
                <asp:ListItem>2008</asp:ListItem>
                <asp:ListItem>2007</asp:ListItem>
                <asp:ListItem>2006</asp:ListItem>
                <asp:ListItem>2005</asp:ListItem>
                <asp:ListItem>2004</asp:ListItem>
                <asp:ListItem>2003</asp:ListItem>
                <asp:ListItem>2002</asp:ListItem>
                <asp:ListItem>2001</asp:ListItem>
                <asp:ListItem>2000</asp:ListItem>
                <asp:ListItem>1999</asp:ListItem>
                <asp:ListItem>1998</asp:ListItem>
                <asp:ListItem>1997</asp:ListItem>
                <asp:ListItem>1996</asp:ListItem>
                <asp:ListItem>1995</asp:ListItem>
                <asp:ListItem>1994</asp:ListItem>
                <asp:ListItem>1993</asp:ListItem>
                <asp:ListItem>1992</asp:ListItem>
                <asp:ListItem>1991</asp:ListItem>
                <asp:ListItem>1990</asp:ListItem>
                <asp:ListItem>1989</asp:ListItem>
                <asp:ListItem>1988</asp:ListItem>
                <asp:ListItem>1987</asp:ListItem>
                <asp:ListItem>1986</asp:ListItem>
                <asp:ListItem>1985</asp:ListItem>
                <asp:ListItem></asp:ListItem>
            </asp:DropDownList><br/><br/>
                
                <asp:ImageButton ID="RegImageButton" runat="server" Height="26px" ImageUrl="./images/Lets_Go_Button.jpg" Width="173px" OnClick="RegImageButton_Click" />
                <br/><br/><br/>
            </div>
            <br />
            </div>
        
            <br/>
            <br />
            <br/>
            <asp:Label ID="DOBSumLabel" runat="server" Visible="False"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br/>
            <!------------------------block of register components ----------->
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
        
        </asp:Panel>
        </div>

        <div style="margin-left:26px;margin-right:26px"> <!--Panel Width setting-->
        <asp:Panel ID="PostTopicPanel" runat="server" BackColor="#A4D5F7" BorderColor="White" BorderStyle="Solid" Visible="False">
            <div style="margin-left:30px;">
            <br />&nbsp;&nbsp;
            <asp:Label ID="TopicLabel" runat="server" Font-Bold="True" Font-Names="Calibri" ForeColor="White" Text="Topic:"></asp:Label>&nbsp;
            <asp:TextBox ID="TopicTextBox" runat="server" BorderColor="White" BorderStyle="Solid" Height="16px" Width="455px">Your Topic</asp:TextBox>
            <br />
            <br />&nbsp;&nbsp;
            <asp:TextBox ID="CommentTextBox" runat="server" BorderColor="White" BorderStyle="Solid" Height="70px" Width="504px" TextMode="MultiLine">Your first comment to this Topic</asp:TextBox>
            <br />
            <br />&nbsp;&nbsp;
            <asp:Button ID="PostTopicButton" runat="server" BackColor="#A4D5F7" BorderColor="White" BorderStyle="Solid" Font-Bold="True" Font-Names="Calibri" ForeColor="White" Text="Post" Width="124px" />
            </div>
            <br />
            <br />
        
        </asp:Panel>
        </div>

        <asp:SqlDataSource ID="DSUser" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM User" UpdateCommand="UPDATE Users SET  Name = @Name, PW = @PW, Gender= @Gender, DOB = @DOB  WHERE Email = @Email">
            <SelectParameters>
                <asp:Parameter Name="UserId" />
                <asp:Parameter Name="UserName" />
            </SelectParameters>
            <UpdateParameters>
                <asp:ControlParameter ControlID="EmailTextBox" Name="Email" PropertyName="Text" />
                <asp:ControlParameter ControlID="NameTextBox" Name="Name" PropertyName="Text" />
                <asp:ControlParameter ControlID="PasswordTextBox" Name="PW" PropertyName="Text" />
                <asp:ControlParameter ControlID="GenderDropDownList" Name="Gender" PropertyName="SelectedValue" />
                <asp:ControlParameter ControlID="DOBSumLabel" Name="DOB" PropertyName="Text" />
            </UpdateParameters>
        </asp:SqlDataSource>

        <br/><br/>
    </div>
        
    <footer><br/>
        <div class="box">
            <div class="box1">
                <div class="heading">Like us on          <div class="column">
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
