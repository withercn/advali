<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SEAdd.aspx.cs" Inherits="AdvAli.Web.Keys.SEAdd" %>

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
            <div class="count" runat="server">添加搜索引擎</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;搜索引擎名：<input id="sname" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;域　　　名：<input id="surl" runat="server" type="text" class="loginInput" />&nbsp;<span class="gray">例：(www.baidu.com、www.baidu.cn) 都是使用 <font color=red>baidu</font></span></li>
                <li>&nbsp;&nbsp;　查询参数：<input id="skey" runat="server" type="text" class="loginInput" />&nbsp;<span class="gray">多个不同的查询参数用 “|”连接</span></li>
                <li>&nbsp;&nbsp;　默认编码：<input id="ie" runat="server" type="text" value="GB2312" class="loginInput" /></li>
                <li>&nbsp;&nbsp;　编码参数：<input id="ei" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;　　　　　　<input type="submit" class="button" runat="server" value="添　　加" onserverclick="SEA_Click" /> <input type="button" value="返　　回" onclick="history.go(-1);" class="button" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
