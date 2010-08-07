<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitestep2.aspx.cs" Inherits="AdvAli.Web.website.sitestep2" %>

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
            <div class="count" runat="server">加盟网站选择地域</div>
            <div></div>
            <ul class="logins">
                <li style="float:left;height:121px;line-height:121px;">广告选择<span class="red">地域</span>：</li>
                <li style="float:left;width:360px;" id="result"><div id="makeSureItem" runat="server" class="selectRange"></div></li>
                <li style="float:left;line-height:121px;width:50px;text-align:center;"><img src="../images/pr.gif" border="0" width="31" height="27" /></li>
                <li style="float:left;line-height:121px;width:100px;text-align:center;"><a href="javascript:void(0);" onclick="openSelect(1);" style="background:url(../images/selectrange.gif) no-repeat;margin-top:30px;width:86px;height:60px;line-height:60px;display:block;font-weight:bold;color:#005590;text-decoration:none;">请选择</a></li>
                <li style="clear:both;">　　　　　　　&nbsp;<input type="submit" style="margin-right:115px;" class="button" runat="server" value="上 一 步" onserverclick="Step1_Click" /><input type="submit" value="下 一 步" onserverclick="SaveStep2_Click" runat="server" class="button" /></li>
                <li class="box" style="line-height:24px;">当流量为加盟网站自身需要的资源，则系统自动调用此代码，即联盟系统对这部分流量资源不做任何处理直接调用加盟站点加盟前的即时通讯代码。</li>
            </ul>
            <div class="hidden" id="selectItem">
                <div class="tit bgc">
                    <h2 class="left">请选择城市</h2>
                    <span class="pointer right" onclick="openSelect(0);">[取消]</span>
                    <span class="pointer right">&nbsp;&nbsp;</span>
                    <span class="pointer right" onclick="makeSure();">[确定]</span>
                </div>
                <div class="cls"></div>
                <div class="cont">
                    <div id="selectSub" runat="server"></div>
                </div>
                <div class="tit bgc"><h2>您已选择的城市</h2></div>
                <div id="preview">
                    <div class="cont" id="previewItem" runat="server"></div>
                </div>
            </div>
            <script type="text/javascript" src="../script/SelectRangeList.js"></script>
            <input id="txtRange" runat="server" type="hidden" />
            <div style="clear:both;"></div>
        </div>
    </div>
    </form>
</body>
</html>
