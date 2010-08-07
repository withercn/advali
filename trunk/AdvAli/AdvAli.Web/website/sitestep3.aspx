<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitestep3.aspx.cs" Inherits="AdvAli.Web.website.sitestep3" %>

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
        <div class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div class="count" runat="server">加盟网站广告设计</div>
            <div></div>
            <ul class="logins">
                <li>广告显示<span class="red">类型：</span>&nbsp;<select onchange="selectAd(this.value);" id="adTypeSelect" runat="server"></select></li>
                <!--<li>　　　　　　　商务通<span class="red">邀请窗口是否设置文字链接广告：</span>&nbsp;<input type="radio" runat="server" name="linkWord" id="linkWord1" /><label for="linkWord1">是</label>&nbsp;&nbsp;<input checked="true" type="radio" runat="server" name="linkWord" id="linkWord2" /><label for="linkWord2">否</label></li>
                <li>广告图片地址：<input type="text" id="pichref" runat="server" class="loginInput" /></li>
                <li>广告图片链接：<input type="text" id="piclnk" runat="server" class="loginInput" /></li>
                <li>广告图片宽度：</li>
                <li>广告图片高度：</li>
                <li>&nbsp;&nbsp;　　　　　　<textarea id="curscript" runat="server" class="loginTextarea"></textarea></li>
                <li class="box" style="line-height:24px;">当流量为加盟网站自身需要的资源，则系统自动调用此代码，即联盟系统对这部分流量资源不做任何处理直接调用加盟站点加盟前的即时通讯代码。</li>-->
                <li runat="server" id="showpic">
                   <div style="width:350px;height:240px;text-align:center;float:left;">
                        <label for="template1"><img src="../images/swtm.gif" width="350" height="200" alt="" /></label>
                        <input type="radio" value="1" name="templates" runat="server" id="template1" />
                   </div> 
                   <div style="width:350px;height:240px;text-align:center;float:left;">
                        <label for="template2"><img src="../images/swtf.gif" width="350" height="200" alt="" /></label>
                        <input type="radio" value="2" name="templates" runat="server" id="template2" />
                   </div> 
                </li>
                <li style="clear:both;">&nbsp;&nbsp;&nbsp;　　　　　　<input onserverclick="Step2_Click" type="submit" class="button" runat="server" value="上 一 步" /> <input onserverclick="SaveStep3_Click" type="submit" class="button" runat="server" value="下 一 步" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
