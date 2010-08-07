<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="password.aspx.cs" Inherits="AdvAli.Web.user.password" %>

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
            <div class="count" runat="server">修改密码</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;　您的邮箱：<input style="border:0px;" id="txtUsername" type="text" runat="server" readonly="readonly" class="loginInput" /></li>
                <li><span class="red">*</span>&nbsp;您的旧密码：<input id="txtOldPassword" type="password" runat="server" class="loginInput" /> <span class="gray">(6-20)个字符</span></li>
                <li><span class="red">*</span>&nbsp;输入新密码：<input id="txtPassword" type="password" runat="server" class="loginInput" /> <span class="gray">(6-20)个字符</span></li>
                <li><span class="red">*</span>&nbsp;新密码确认：<input id="txtPassword2" type="password" runat="server" class="loginInput" /> <span class="gray">(6-20)个字符</span></li>
                <li>&nbsp;&nbsp;　　　　　　<span class="red" style="font-size:12px;">注意：带“*”号字段为必填内容，不带“*”号字段为选填内容。</span></li>
                <li>&nbsp;&nbsp;　　　　　　<input type="submit" class="button" value="修　　改" onserverclick="Password_Click" /> <input type="button" class="button" value="返　　回" onclick="history.go(-1);" /></li>
            </ul>
            <div style="clear:both;height:0px;line-height:0px;">&nbsp;</div>
        </div>
    </div>
    </form>
</body>
</html>
