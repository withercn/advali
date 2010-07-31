<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="groupsadd.aspx.cs" Inherits="AdvAli.Web.user.groupsadd" %>

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
            <div id="Div2" class="count" runat="server">添加用户组</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;用户组编号：<input id="id" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;用户组名称：<input id="groupname" runat="server" type="text" class="loginInput" /></li>
                <li style="height:auto;"><ul id="RightsList" class="RightsList" runat="server"></ul></li>
                <li style="clear:both;">&nbsp;&nbsp;<input type="submit" class="button" runat="server" value="添　　加" onserverclick="GroupsAdd_Click" /> <input type="button" value="返　　回" onclick="history.go(-1);" class="button" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
