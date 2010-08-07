<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AdvAli.Web.user.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="../css/main.css" />
    <script type="text/javascript" src="../script/main.js"></script>
    <script type="text/javascript" src="../script/msgbox.js"></script>
    <script type="text/javascript" src="../script/HScalender.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="start">
        <div class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div class="count" runat="server">用户列表 (总计：<%=base.RecordCount%>人)</div>
            <ul class="operator">
                <li class="inputf">用户名：<input type="text" class="loginInput" id="txtUsername" runat="server" />&nbsp;<select id="timesel" runat="server"><option value="0">请选择</option><option value="1">注册时间</option><option value="2">登陆时间</option></select><input class="loginInput" onfocus="HS_setDate(this)" type="text" id="timer1" runat="server" />&nbsp;至&nbsp;<input class="loginInput" onfocus="HS_setDate(this)" type="text" id="timer2" runat="server" />&nbsp;<input id="Button1" class="button" value="查　　询" type="button" onclick="search();" runat="server" /></li>
                <li class="pager" runat="server"><%=pagehtml%></li>
            </ul>

            <table cellpadding="0" cellspacing="0" border="0" runat="server" class="data" id="data"></table>
            
            <div class="pageD">
                <span>选择：</span><span class="link" onclick="checkall(1)">全选</span>&nbsp;-&nbsp;<span class="link" onclick="checkall(2)">反选</span>
            </div>
            <div class="pageX">
                <div style="float:left;"><input class="button" value="添加用户" type="submit" runat="server" onserverclick="Add_Click" /> <input type="submit" class="button" value="编辑用户" runat="server" onserverclick="Edit_Click" /> <input type="submit" class="button" value="删除用户" runat="server" onserverclick="Del_Click" /> <input id="Rights" type="submit" class="button" value="设置权限" runat="server" onserverclick="Rights_Click" /></div>
                <div id="Div1" style="float:right;" class="pager" runat="server"><%=pagehtml%></div>
            </div>
            
        </div>
    </div>
    </form>
</body>
</html>
