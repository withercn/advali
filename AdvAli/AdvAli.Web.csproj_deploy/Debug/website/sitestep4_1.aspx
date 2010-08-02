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
                <li>　商务通<span class="red">邀请窗口标题：</span><input onblur="reviewSwt();" id="title" name="title" runat="server" type="text" class="loginInput" /></li>
                <li>　　　商务通<span class="red">链接地址：</span><input onblur="reviewSwt();" id="link" name="link" runat="server" type="text" class="loginInput" /></li>
                <li id="promptli" runat="server">　　　商务通<span class="red">温馨提示：</span><input onblur="reviewSwt();" type="text" id="prompt" runat="server" class="loginInput" /></li>
                <li id="tel1li" runat="server">　　　　<span class="red">网络咨询热线：</span><input onblur="reviewSwt();" type="text" id="tel1" runat="server" class="loginInput" /></li>
                <li id="tel2li" runat="server">　　　　　<span class="red">24小时热线：</span><input onblur="reviewSwt();" type="text" id="tel2" runat="server" class="loginInput" /></li>
                <li><span style="display:block;float:left;">商务通<span class="red">邀请窗口邀请语：</span></span><textarea onblur="reviewSwt();" id="context" name="context" runat="server" class="loginTextarea"></textarea></li>
                <li>　　　　　　　　　　　商务通<span class="red">邀请窗口是否设置文字链接广告：</span><input onclick="setAdShow('block');" type="radio" runat="server" id="wordLnk1" name="wordLnk" value="1" /><label for="wordLnk1">是</label>&nbsp;<input onclick="setAdShow('none');" type="radio" runat="server" id="wordLnk2" name="wordLnk" value="2" /><label for="wordLnk2">否</label></li>
                <li id="ad1">　　　　　　广告语一：<input onblur="reviewSwt();" type="text" id="adText1" runat="server" class="loginInput" /></li>
                <li id="ad2">　　　　　广告链接一：<input onblur="reviewSwt();" type="text" id="adLink1" runat="server" class="loginInput" /></li>
                <li id="ad3">　　　　　　广告语二：<input onblur="reviewSwt();" type="text" id="adText2" runat="server" class="loginInput" /></li>
                <li id="ad4">　　　　　广告链接二：<input onblur="reviewSwt();" type="text" id="adLink2" runat="server" class="loginInput" /></li>
                <li>　　　　　　　　　　　 <input type="submit" value="上一步" runat="server" onserverclick="Step2_Click" class="button" /> <input type="submit" class="button" runat="server" value="下 一 步" onserverclick="SaveStep41_Click" /></li>
            </ul>
            <div id="swtm" runat="server"><div class="msgbox_title">您好,这里是<span id="msgbox_titles"></span></div><div class="msgbox_close" onclick="$('swtm').parentNode.removeChild($('swtm'));"></div><div class="msgbox_context"><p id="msgbox_text"></p><ul id="msgbox_hot"></ul><div class="msgbox_button"><a id="actions" href="#" target="_blank"><img src="../images/msgbox/btn1.gif" width="88" height="24" border="0" alt="" /></a><a href="javascript:void(0);" onclick="$('swtm').parentNode.removeChild($('swtm'));"><img src="../images/msgbox/btn2.gif" width="88" height="24" border="0" alt="" /></a></div></div><div id="msgbox_prompt"></div></div>
            <div id="swtf" runat="server"><div class="msgbox_title">您好,这里是<span id="msgbox_titles"></span></div><div class="msgbox_close" onclick="$('swtf').parentNode.removeChild($('swtf'));"></div><div class="msgbox_context"><div id="msgbox_text"></div><ul id="msgbox_tel"><li id="msgbox_tel1"></li><li id="msgbox_tel2"></li></ul><div class="msgbox_button"><a id="actions" href="#" target="_blank"><img src="../images/msgbox/btn1.gif" width="88" height="24" border="0" alt="" /></a><a href="javascript:void(0);" onclick="$('swtf').parentNode.removeChild($('swtf'));"><img src="../images/msgbox/btn2.gif" width="88" height="24" border="0" alt="" /></a></div></div><ul id="msgbox_hot"></ul></div>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
