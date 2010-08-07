<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetScript.aspx.cs" Inherits="AdvAli.Web.website.GetScript" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
            <div class="count" runat="server"><div style="float:left;">获取代码</div><div style="float:right;"><input type="checkbox" onclick="textautorow(this)" id="autorow" /><label for="autorow">自动换行</label></div></div>
            <textarea style="width:100%;height:370px;margin-top:10px;overflow:auto;" id="code" runat="server" onfocus="this.select();">
<script type="text/javascript">var siteid=<%=siteid.ToString()%>;var pageurl = escape(location.href);var pagetitle = escape(document.title);var referrer = escape(document.referrer);document.write('<scr' + "ipt language=\"javascript\" src=\"<%=AdvAli.Config.Global.config.WebSiteUrl%>/script/setad.aspx?siteid=" + siteid + "&pageurl=" + pageurl + "&pagetitle=" + pagetitle + "&referrer=" + referrer + "\"></scr" + 'ipt>');</script>
<script type="text/javascript">
if(typeof(islocal)=="undefined"){<%=Scripts.Replace("var ", "window.")%>}
</script></textarea>
            <div style="height:40px;line-height:40px;text-align:right;"><span style="color:Red;font-size:16px;">请将该段代码放入代码页&lt;body&gt;与&lt;/body&gt;之间。</span>  <input type="button" class="button" value="复制代码" onclick="copyCode('code');" /></div>
        </div>
    </div>
    </form>
</body>
</html>
