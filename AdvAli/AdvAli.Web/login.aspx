﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="AdvAli.Web.login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="pragma" content="no-cache">
<meta http-equiv="Cache-Control" content="no-cache, must-revalidate">
<head><title>系统登陆-红立方网站首页-医联分诊系统-红立方信息技术有限公司</title>
<link href="/css/index.css" rel="stylesheet" type="text/css" />
</head>
<body onload="$('txtUsername').focus()">
<div id="banner"></div>
<div id="nav">
<ul>
<li class="s1"><a href="/" class="lan">网站首页</a></li>
<li><a href="/rjjs/"target="_blank">软件介绍</a></li>
<li><a href="/html/czlc.htm"target="_blank">操作流程</a></li>
<li><a href="/khal/"target="_blank">成功案例</a></li>
<li><a href="/html/sqjr.htm"target="_blank">申请加入</a></li>
<li><a href="/cjwt/"target="_blank">帮助中心</a></li>
<li><a href="http://el.andad.net"target="_blank">会员入口</a></li>
<li><a href="/gsxx/gsxx_6_10.html"target="_blank">联系我们</a></li>
</ul>
</div>
<div class="content">
  <div class="left"><div class="wrap-hot"><div class="hot-l"></div><div class="hot">
<h2>公告:</h2><p><MARQUEE onmouseover=this.stop() onmouseout=this.start() scrollAmount=2 scrollDelay=4 width="100%" height=20><font style="color:#FF0000">医联分诊系统已经进入内部测试阶段,想参与测试的医院抓紧时间报名参加。</font></MARQUEE></p>
</div><div class="hot-r"></div></div>
<div class="wrap-lliucheng"><h2><a href="http://localhost/login.aspx">系统登陆</a></h2>
<span class="more"><a href="/">首页</a>—<a href="http://localhost/login.aspx">系统登陆</a></span>
<div class="secondright">
<form method="post" runat="server">
	  <span>广告主登陆</span>
	  <table width="100%" border="0" cellpadding="0" cellspacing="0" style=" border-top:1px solid #98aadc;margin-top:8px;">
        <tr>
          <td width="18%" class="lefttablebg"><b>账户信息</b></td>
          <td class="righttablebg"><label></label></td>
        </tr>
        <tr>
          <td class="lefttablebg">邮箱账户</td>
          <td class="righttablebg"><input name="txtUsername" type="text" id="txtUsername" autocomplete="off" /></td>
        </tr>
        <tr>
          <td class="lefttablebg">密码</td>
          <td class="righttablebg"><input name="txtPassword" type="password" id="txtPassword" autocomplete="off" /></td>
        </tr>
        <tr>
          <td class="lefttablebg">验证码</td>
          <td class="righttablebg"><img alt="" title="看不清楚,点击换图" style="cursor:pointer;float:left;margin-top:1px;height:20px;" onclick="this.src='http://192.168.1.85/image.aspx?id='+Math.random()*1000;" src="http://192.168.1.85/image.aspx" />&nbsp;<input name="txtCode" type="text" id="txtCode" style="width:125px;" /></td>
        </tr>
      </table>
     <table width="100%" border="0" cellpadding="0" cellspacing="0" style=" margin-top:20px;" >
        <tr style="height:20px;"><td style="width:100%;text-align:center;font-weight:bold;color:Blue;font-size:14px;font-family:宋体;" id="msg"></td></tr>
        <tr>
          <td style="width:100%; text-align:center;">
              <input type="image" name="register" id="register" src="/Images1/buttonok.gif" style="border-width:0px;" />&nbsp;&nbsp;<img src="/Images1/buttonre.gif" style="border-width:0px;cursor:pointer;" onclick="reset()" /></td>
        </tr>
      </table>
	  <p>&nbsp;</p>
	  </form>
	</div>
</div>
  </div>
  <div class="wrap-right">
   <div class="ask"><div class="pic"><a href="http://el.andad.net" target=blank><img src="/images1/ask_01.gif" border="0"  title="点击立刻申请加入医联分诊系统"/></a></div>

  <div class="pic01"><ul><li><a href="tencent://message/?uin=1085283013&Site=www.andad.net&Menu=yes" target=blank><img src="/images1/pic_02.gif" border="0" title="深圳医联网 医联服务QQ；1085283013"  /></a></li>

  <li><a href="/cjwt/"><img src="/images1/pic_03.gif" border="0" title="深圳医联网 服务策划 为你打造各种小型网站" /></a></li>

  <li><a href="/html/czlc.htm"><img src="/images1/pic_04.gif" border="0" title="深圳医联网 QQ"  /></a></li>

  </ul></div>

  </div>
<div class="right">
<div class="rightbox">
<h2 title="客户案例"><a href="/khal/">最新加盟</a></h2>
<span><a href="/khal/">更多>></a></span>
<div id="demo"> 
<div id="ofdimg" style="widows:200;height:300">
 
<a href="/khal/khal_5_25.html" target="_blank"><img src="/UploadFiles/2009-04/admin/2009040215034229271.gif" width="200" height="51"  border="0"/></a>
 
<a href="/khal/khal_5_24.html" target="_blank"><img src="/UploadFiles/2009-04/admin/2009040215025190403.gif" width="200" height="51"  border="0"/></a>
 
<a href="/khal/khal_5_23.html" target="_blank"><img src="/UploadFiles/2009-04/admin/2009040215020594090.jpg" width="200" height="51"  border="0"/></a>
 
<a href="/khal/khal_5_22.html" target="_blank"><img src="/UploadFiles/2009-04/admin/2009040215011346050.gif" width="200" height="51"  border="0"/></a>
 
<a href="/khal/khal_5_21.html" target="_blank"><img src="/UploadFiles/2009-04/admin/2009040214593618947.gif" width="200" height="51"  border="0"/></a>
 
<a href="/khal/khal_5_20.html" target="_blank"><img src="/UploadFiles/2009-04/admin/2009040214581913563.gif" width="200" height="51"  border="0"/></a>
 
<a href="/khal/khal_5_19.html" target="_blank"><img src="/UploadFiles/2009-04/admin/2009040214571796780.gif" width="200" height="51"  border="0"/></a>
</div>
		<div id="demo2"></div> 
</div>
<script type="text/javascript"> 
var speed=20; //数字越大速度越慢 
var tab=document.getElementById("demo"); 
var tab1=document.getElementById("ofdimg"); 
var tab2=document.getElementById("demo2"); 
tab2.innerHTML=tab1.innerHTML;          //克隆demo1为demo2 
function Marquee(){ 
if(tab2.offsetTop-tab.scrollTop<=0)//当滚动至demo1与demo2交界时 
tab.scrollTop-=tab1.offsetHeight //demo跳到最顶端 
else{ 
tab.scrollTop++ 
} 
} 
var MyMar=setInterval(Marquee,speed); 
tab.onmouseover=function() {clearInterval(MyMar)};//鼠标移上时清除定时器达到滚动停止的目的 
tab.onmouseout=function() {MyMar=setInterval(Marquee,speed)};//鼠标移开时重设定时器 
</script>


</div>
<div class="rightbox">
<h2 title="友情链接"><a href="/FriendLink/FriendLinkReg.asp">友情链接</a></h2>
<span><a href="/FriendLink/FriendLinkReg.asp">更多>></a></span>
<ul>
 <table width="100%" cellspacing="2"> 
<tr>
<td width="50%" nowrap="nowrap"><a id="link29" href="/plus/link/To?29" target="_blank" title="网站名称:深圳医疗网&#13;&#10;网站描述:">深圳医疗网</a></td><td width="50%" nowrap="nowrap"><a id="link4" href="/plus/link/To?4" target="_blank" title="网站名称:健康百事通&#13;&#10;网站描述:">健康百事通</a></td></tr>
</table>
</ul></div></div></div></div>
<div id="wrap-footer"><div id="footer-l"></div><div id="footer">Copyright &copy; 2003-2009 www.andad.net All Rights Reserved 版权所有：红立方信息技术有限公司 粤ICP备10055779号<br /><script src="http://s11.cnzz.com/stat.php?id=2069264&web_id=2069264&show=pic" language="JavaScript"></script>

地址：深圳市福田区振中路87号华胜大厦6楼 咨询QQ：1160966298  1085283013/邮箱：andad100@126.com 
<br />
<img src="/images/love.gif">
</div><div id="footer-r"></div></div>
</body>
</html>
<SCRIPT LANGUAGE="JavaScript" src=http://float2006.tq.cn/floatcard?adminid=8903647&sort=0&version=vip></SCRIPT>
<script src="/ks_inc/ajax.js" type="text/javascript"></script>
