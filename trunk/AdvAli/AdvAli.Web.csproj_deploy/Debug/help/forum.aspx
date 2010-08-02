<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="forum.aspx.cs" Inherits="AdvAli.Web.help.forum" %>

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
            <div class="count" id="counts" runat="server">反馈意见 (总计：<%=base.RecordCount%>条)</div>
            <ul class="operator">
                <li class="inputf"><input type="checkbox" id="isre" onclick="selectForum()" runat="server" /><label for="isre">已回复</label></li>
                <li class="inputf"><input type="checkbox" id="remove" onclick="selectForum()" runat="server" /><label for="remove">已删除</label></li>
                <li class="pager" runat="server"><%=pagehtml%></li>
            </ul>
            
            <table cellpadding="0" cellspacing="0" border="0" runat="server" class="data" id="data"></table>            
            
            <div class="pageD">
                <span>选择：</span><span class="link" onclick="checkall(1)">全选</span>&nbsp;-&nbsp;<span class="link" onclick="checkall(2)">反选</span>
            </div>
            <div class="pageX">
                <div style="float:left;"><input type="submit" class="button" value="删除日志" runat="server" onserverclick="Del_Click" /> <input type="submit" class="button" value="恢复删除" runat="server" onserverclick="Recover_Click" /></div>
                <div style="float:right;" class="pager" runat="server"><%=pagehtml%></div>
            </div>
        </div>
        <ul id="posts" runat="server">
            <li>标题：<input type="text" id="title" runat="server" /></li>
            <li>意见：<textarea id="context" runat="server"></textarea></li>
            <input type="submit" onserverclick="Post_Click" class="button" runat="server" value="反馈" />
        </ul>
        <div id="reposts">
            <input type="hidden" id="postid" runat="server" />
            <textarea id="re" runat="server"></textarea>
            <input type="submit" onserverclick="Replay_Click" class="button" runat="server" value="回复" />
        </div>
    </div>
    </form>
</body>
</html>
