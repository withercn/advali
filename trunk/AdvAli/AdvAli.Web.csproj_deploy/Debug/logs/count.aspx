<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="count.aspx.cs" Inherits="AdvAli.Web.logs.count" %>

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
            <div class="count" id="counts" runat="server">访问统计 (总计：<%=base.RecordCount%>条)</div>
            <ul class="operator">
                <li class="h30">网站：</li>
                <li class="h30"><select id="siteid" runat="server" onchange="selectSite(this.value)"></select></li>
                <li class="h30">&nbsp;&nbsp;日期：</li>
                <li class="inputf"><input type="text" id="date1" onfocus="HS_setDate(this)" class="loginInput" runat="server" /></li>
                <li class="h30">到&nbsp;</li>
                <li class="inputf"><input type="text" id="date2" onfocus="HS_setDate(this)" class="loginInput" runat="server" /></li>
                <li class="h30"><input id="Button1" class="button" value="日期查询" type="button" onclick="dateSearch();" runat="server" /></li>
                <li class="pager" runat="server"><%=pagehtml%></li>
            </ul>
            
            <table cellpadding="0" cellspacing="0" border="0" runat="server" class="data" id="data"></table>            
            
            <div class="pageX">
                <div style="float:right;" class="pager" runat="server"><%=pagehtml%></div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
