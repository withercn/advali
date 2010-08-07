<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AdvAli.Web.Keys.index" %>

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
            <div class="count" runat="server">关键字 (总计：<%=base.RecordCount%>条)</div>
            <ul class="operator">
                <li class="h30">网站：</li>
                <li class="h30"><select id="siteid" runat="server" onchange="selectKey()"></select></li>
                <li class="h30">&nbsp;&nbsp;分组：</li>
                <li class="h30"><select id="group" runat="server" onchange="selectKey()"></select></li>
                <li class="pager" runat="server"><%=pagehtml%></li>
            </ul>
            
            <table cellpadding="0" cellspacing="0" border="0" runat="server" class="data" id="data"></table>
            
            <div class="pageD">
                <span>选择：</span><span class="link" onclick="checkall(1)">全选</span>&nbsp;-&nbsp;<span class="link" onclick="checkall(2)">反选</span>
            </div>
            <div class="pageX">
                <div style="float:left;"><input class="button" value="添加关键字" type="submit" runat="server" onserverclick="Add_Click" /> <input type="submit" class="button" value="编辑关键字" runat="server" onserverclick="Edit_Click" /> <input type="submit" class="button" value="删除关键字" runat="server" onserverclick="Del_Click" /></div>
                <div style="float:right;" class="pager" runat="server"><%=pagehtml%></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
