<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitestep4_1.aspx.cs" Inherits="AdvAli.Web.website.sitestep4_1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="../css/main.css" />
    <link rel="Stylesheet" href="../css/msgbox" />
    <script type="text/javascript" src="../script/main.js"></script>
    <script type="text/javascript" src="../script/msgbox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="start">
        <div class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div class="count" runat="server">加盟网站</div>
            <div></div>
            <ul class="logins">
                <li>　商务通<span class="red">邀请窗口标题：</span><input id="title" name="title" runat="server" type="text" class="loginInput" /></li>
                <li>　　　商务通<span class="red">链接地址：</span><input id="link" name="link" runat="server" type="text" class="loginInput" /></li>
                <li><span style="display:block;float:left;">商务通<span class="red">邀请窗口邀请语：</span></span><textarea id="contenxt" name="contenxt" runat="server" class="loginTextarea"></textarea></li>
                <li>　　　　　　　　　　　商务通<span class="red">邀请窗口是否设置文字链接广告：</span><input type="radio" runat="server" id="wordLnk1" name="wordLnk" value="1" /><label for="wordLnk1">是</label>&nbsp;<input type="radio" runat="server" id="wordLnk2" name="wordLnk" value="2" /><label for="wordLnk2">否</label></li>
                <li>　　　　　　广告语一：<input type="text" id="adText1" runat="server" class="loginInput" /></li>
                <li>　　　　　广告链接一：<input type="text" id="adLink1" runat="server" class="loginInput" /></li>
                <li>　　　　　　广告语二：<input type="text" id="adText2" runat="server" class="loginInput" /></li>
                <li>　　　　　广告链接二：<input type="text" id="adLink2" runat="server" class="loginInput" /></li>
                <li>　　　　　　预览效果：</li>
                <li>　　　　　　　　　　　 <input type="submit" value="上一步" runat="server" onserverclick="Step2_Click" class="button" /> <input type="submit" class="button" runat="server" value="下 一 步" onserverclick="SaveStep41_Click" /></li>
            </ul>
            <div style="clear:both;"></div>
            <div id="msgbox">
                <div class="msgbox_title">您好,这里是<span id="msgbox_titles"></span></div>
                <div class="msgbox_context">
                    <p class="msgbox_text">如您有健康问题，请点击“接受”在线医生将即时为您提供免费健康咨询服务。</p>
                    <ul class="msgbox_hot">
                        <li>·<a href="#" target="_blank">广告语一</a></li>
                        <li>·<a href="#" target="_blank">广告语一</a></li>
                    </ul>
                    <div class="msgbox_button">
                        <a href="#" target="_blank"><img src="../images/msgbox/btn1.gif" width="88" height="24" border="0" alt="" /></a>
                        <a href="#" target="_blank"><img src="../images/msgbox/btn2.gif" width="88" height="24" border="0" alt="" /></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
