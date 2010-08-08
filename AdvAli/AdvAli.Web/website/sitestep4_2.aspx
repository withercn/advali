<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitestep4_2.aspx.cs" Inherits="AdvAli.Web.website.sitestep4_2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="../css/main.css" />
    <script type="text/javascript" src="../script/main.js"></script>
    <script type="text/javascript" src="../script/msgbox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="start">
        <div id="Div1" class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div class="count" runat="server">加盟网站</div>
            <div></div>
            <ul class="logins">
                <li>QQ<span class="red">窗口标题：</span><input id="qqhead" runat="server" type="text" class="loginInput" /></li>
                <li>QQ<span class="red">窗口尾注：</span><input id="qqbottom" runat="server" type="text" class="loginInput" /></li>
            </ul>
            <ul class="logins" id="qqinfo" runat="server" style="float:left;">
                <li>　 QQ<span class="red">号码1：</span><input id="qqnum1" name="qqnum1" runat="server" type="text" class="loginInput" /></li>
                <li>　 QQ<span class="red">昵称1：</span><input id="qqs1" name="qqs1" runat="server" type="text" class="loginInput" /></li>
                <li>　 QQ<span class="red">简介1：</span><input id="qqtitle1" name="qqtitle1" runat="server" type="text" class="loginInput" /></li>
            </ul>
            <input type="hidden" runat="server" id="qqn" value="1" />
            <input type="hidden" id="isqq" runat="server" value="1" />
            <div style="float:left;height:108px;line-height:108px;">
                <a href="javascript:void(0);" onclick="addQQMSN();"><img src="../images/QQ/add.gif" width="99" height="52" border="0" alt="" /></a>
            </div>
            <ul class="logins">
                <li style="clear:both;">&nbsp;&nbsp;&nbsp;　　　　　<input onserverclick="Step3_Click" type="submit" class="button" runat="server" value="上 一 步" /> <input onserverclick="SaveStep42_Click" type="submit" class="button" runat="server" value="下 一 步" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
