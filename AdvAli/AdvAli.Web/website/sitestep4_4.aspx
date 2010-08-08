<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitestep4_4.aspx.cs" Inherits="AdvAli.Web.website.sitestep4_4" %>

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
            <div id="Div2" class="count" runat="server">加盟网站广告设计</div>
            <div></div>
            <ul class="logins">
                <li>广告图片标题：<input type="text" id="imagename" runat="server" class="loginInput" /></li>
                <li>广告图片地址：<input type="text" id="imageurl" runat="server" class="loginInput" /></li>
                <li>广告链接地址：<input type="text" id="imagelink" runat="server" class="loginInput" /></li>
                <li>　　图片宽度：<input type="text" id="width" runat="server" class="loginInput" /></li>
                <li>　　图片高度：<input type="text" id="height" runat="server" class="loginInput" /></li>
                <li>　　　　　　　 <input type="button" value="" class="preview" onclick="previewPicture()" /></li>
                <li style="clear:both;">　　　　　　　 <input onserverclick="Step3_Click" type="submit" class="button" runat="server" value="上 一 步" /> <input onserverclick="SaveStep44_Click" type="submit" class="button" runat="server" value="下 一 步" /></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
