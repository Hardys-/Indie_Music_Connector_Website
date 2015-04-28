<%@ Page Language="C#" AutoEventWireup="true" CodeFile="_MusicPlayer.aspx.cs" Inherits="MusicPlayer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <audio controls = "controls">
            <source src="test_music.mp3" type="audio/mpeg"/>
            Your browser does not support the audio element.
        </audio>
    </div>
    </form>
</body>
</html>
