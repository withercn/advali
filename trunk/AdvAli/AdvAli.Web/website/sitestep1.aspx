<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitestep1.aspx.cs" Inherits="AdvAli.Web.website.sitestep1" %>

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
            <div  class="count" runat="server">加盟网站基本资料</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;　网站名称：<input id="txtwebname" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;　网站地址：<input id="txtUrl" runat="server" type="text" class="loginInput" />&nbsp;<span class="gray">无需“http://”</span>&nbsp;&nbsp;<span class="red">例：www.sz16.cn</span></li>
                <li><span style="display:block;float:left;">&nbsp;&nbsp;　网站介绍：</span><textarea id="sitenote" runat="server" class="loginTextarea"></textarea></li>
                <li>&nbsp;&nbsp;商务通代码：&nbsp;<span class="gray">网站加盟之前使用的</span><span class="red">即时通讯代码</span></li>
                <li>&nbsp;&nbsp;　　　　　　<textarea id="curscript" runat="server" class="loginTextarea"></textarea></li>
                <li class="box" style="line-height:24px;">当流量为加盟网站自身需要的资源，则系统自动调用此代码，即联盟系统对这部分流量资源不做任何处理直接调用加盟站点加盟前的即时通讯代码。</li>
                <li style="clear:both;">&nbsp;&nbsp;&nbsp;　　　　　　<input type="submit" class="button" runat="server" value="下 一 步" onserverclick="SaveStep1_Click" /> <input type="button" value="返　　回" onclick="history.go(-1);" class="button" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
