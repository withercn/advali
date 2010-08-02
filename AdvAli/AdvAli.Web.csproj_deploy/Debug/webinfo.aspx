<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="webinfo.aspx.cs" Inherits="AdvAli.Web.webinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="css/main.css" />
    <script type="text/javascript">var isRoot=true;</script>
    <script type="text/javascript" src="script/main.js"></script>
    <script type="text/javascript" src="script/msgbox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="start">
        <div class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div id="Div2" class="count" runat="server">网站基本信息</div>
            <ul class="logins" style="float:left;width:220px;">
                <li class="h30">网站名称：</li>
                <li class="inputs"><input id="websitename" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">网站标题：</li>
                <li class="inputs"><input id="websitetitle" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">Meta关键字：</li>
                <li class="inputs"><input id="meta_key" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">Meta描述：</li>
                <li class="inputs"><input id="meta_desc" runat="server" type="text" class="loginInput" /></li>
            </ul>
            <ul class="logins" style="float:left;width:220px;">
                <li class="h30">允许注册：</li>
                <li class="h30"><input type="radio" name="allowregister" value="1" id="reg1" runat="server" /><label for="reg1">允许</label> <input type="radio" value="0" name="allowregister" id="reg2" runat="server" /><label for="reg2">禁止</label> </li>
                <li class="h30">允许登陆：</li>
                <li class="h30"><input type="radio" name="allowlogin" value="1" id="login1" runat="server" /><label for="reg1">允许</label> <input type="radio" value="0" name="allowlogin" id="login2" runat="server" /><label for="reg2">禁止</label> </li>
                <li class="h30">允许上传单个文件的最大值：(KB)</li>
                <li class="inputs"><input id="maxupload" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">允许上传的文件类型：</li>
                <li class="inputs"><input id="allowupload" runat="server" type="text" class="loginInput" /></li>
            </ul>
            <ul class="logins" style="float:left;width:220px;">
                <li class="h30">网站地址：</li>
                <li class="inputs"><input id="websiteurl" runat="server" type="text" class="loginInput" onblur="setDomain(this.value)" /></li>
                <li class="h30">网站域名：</li>
                <li class="inputs"><input id="websitedomain" readonly="readonly" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">所有权限：</li>
                <li class="inputs"><input id="allrights" readonly="readonly" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">上传目录：</li>
                <li class="inputs"><input id="uploaddirectory" runat="server" type="text" class="loginInput" /></li>
            </ul>
            <ul class="logins" style="float:left;width:330px">
                <li class="h30">网站说明：</li>
                <li class="registerContentLiTextarea"><textarea class='registerContentTextarea' id='websitenote' runat="server"></textarea></li>
                <li class="h30"><input id="Submit1" type="submit" class="button" onserverclick="Base_Click" runat="server" value="修　　改" /> <input id="Submit2" type="submit" class="button" onserverclick="Cache_Click" runat="server" value="更新缓存" /></li>
            </ul>
            <ul class="logins" style="float:left;width:330px">
                <li class="h30">网站版权：</li>
                <li class="registerContentLiTextarea"><textarea class='registerContentTextarea' id='copyright' runat="server"></textarea></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
