<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="true" CodeBehind="rightsedit.aspx.cs" Inherits="AdvAli.Web.user.rightsedit" %>

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
        <div id="Div1" class="navigation" runat="server"><%=Navigations%>修改用户权限</div>
        <div class="content">
            <div id="Div2" class="count" runat="server">修改用户权限</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;　电子邮件：<input style="border:0px;" readonly="readonly" id="txtUsername" runat="server" type="text" class="loginInput" /></li>
                <li>&nbsp;&nbsp;　用 户 组：<asp:DropDownList id="group" runat="server" OnSelectedIndexChanged="Groups_Change" AutoPostBack="true"></asp:DropDownList></li>
                <li style="height:auto;">&nbsp;&nbsp;　用户权限：<ul id="RightsList" class="RightsList" runat="server"></ul></li>
                <li style="clear:both;">&nbsp;&nbsp;　　　　　　<input type="submit" class="button" runat="server" value="修　　改" onserverclick="RightsEdit_Click" /> <input type="reset" class="button" /></li>
            </ul>
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
