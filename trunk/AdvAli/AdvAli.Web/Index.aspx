<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AdvAli.Web._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <link href="css/main.css" rel="Stylesheet" />
</head>
<frameset id="frameset" runat="server" name="main" framespacing="0" border="false" rows="79,*" frameborder="0" scrolling="yes">
        <frame name="topFrame" frameborder="0" scrolling="No" noresize="noresize" id="topFrame" src="inc/top.htm" />
        <frameset cols="182,*" framespacing="0" frameborder="0" border="false" id="frame">
            <frame name="leftFrame" noresize="noresize" id="leftFrame"  src="inc/left.aspx" />
            <frame name="mainFrame" id="mainFrame" src="website/index.aspx" />
        </frameset>
        <frame name="bottomFrame" frameborder="0" scrolling="no" noresize="noresize" id="bottomFrame" src="inc/bottom.htm" />
    </frameset>
<body>
</body>
</html>
