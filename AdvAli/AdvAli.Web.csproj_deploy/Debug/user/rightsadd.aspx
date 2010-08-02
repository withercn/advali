<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="rightsadd.aspx.cs" Inherits="AdvAli.Web.user.rightsadd" %>

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
            <div id="Div2" class="count" runat="server">添加新用户</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;　权限编号：<input id="adminsid" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;　权限名称：<input id="adminsname" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;　　　　　　<span class="red" style="font-size:12px;">注意：带“*”号字段为必填内容，不带“*”号字段为选填内容。</span></li>
                <li>&nbsp;&nbsp;　　　　　　<input type="submit" class="button" runat="server" value="添　　加" onserverclick="RightsAdd_Click" /> <input type="button" value="返　　回" onclick="history.go(-1);" class="button" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
