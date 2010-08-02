<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="keyadd.aspx.cs" Inherits="AdvAli.Web.Keys.keyadd" %>

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
        <div  class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div class="count" runat="server">添加关键词</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;关 键 词：<input id="keywords" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;允许访问： <select id="flag" runat="server"><option value="0">拒绝</option><option value="1" selected="selected">允许</option></select>&nbsp;<span class="gray"><font color="blue">允许：</font>接收来自该关键词的对话 <font color="red">拒绝：</font>不接收来自该关键词的对话</span></li>
                <li>&nbsp;&nbsp;网　　站： <select id="siteid" runat="server" onchange="selectGroup()"></select></li>
                <li>&nbsp;&nbsp;分　　组： <select id="groupid" runat="server" onchange="selectGroup()"></select></li>
                <li>&nbsp;&nbsp;　　　　　<input type="submit" class="button" runat="server" value="添　　加" onserverclick="Keys_Click" /> <input type="button" value="返　　回" onclick="history.go(-1);" class="button" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
