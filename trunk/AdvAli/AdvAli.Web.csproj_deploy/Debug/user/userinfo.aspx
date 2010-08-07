<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="userinfo.aspx.cs" Inherits="AdvAli.Web.user.userinfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="../css/main.css" />
    <script type="text/javascript" src="../script/main.js"></script>
    <script type="text/javascript" src="../script/msgbox.js"></script>
    <script type="text/javascript">
    <!--
    var patterns = new Object();
    function $(id){return document.getElementById(id);}
    function verify(str,pat){thePat = patterns[pat];if(thePat.test(str)){return true;}else{return false;}}
    function testemail(){patterns.email = /^[a-zA-Z0-9_-]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$/;if(!verify($("username").value,"email")){$("lbemail").innerHTML = "电子邮件格式不正确！";return false;}else{$("lbemail").innerHTML = "";return true;}}
    function testpwd(){var obj1 = $("password").value;var obj2 = $("repassword").value;if(obj1.leng!=0&&obj1.length<6||obj1.length>20){$("lbpwd1").innerHTML = "密码长度为6-20个字符";return false;}else{$("lbpwd1").innerHTML = "";return true;}if($("password").value != $("repassword").value){$("lbpwd2").innerHTML = "两次输入的密码不相同！";return false;}else{$("lbpwd2").innerHTML = "";return true;}}
    function testtel(){patterns.tel = /^\d{3,4}-\d{7,8}(-\d{3,4})?$/;if(!verify($("tel").value,"tel")){$("lbtel").innerHTML = "固定电话的格式不正确!";return false;}else{$("lbtel").innerHTML = "";$("lbmobile").innerHTML="";return true;}}
    function testmobile(){patterns.mobile =  /^0*(13|15)\d{9}$/;if(!verify($("mobile").value,"mobile")){$("lbmobile").innerHTML = "手机号码的格式不正确!";return false;}else{$("lbmobile").innerHTML = "";$("lbtel").innerHTML="";return true;}}
    function testfax(){patterns.fax = /^\d{3,4}-\d{7,8}(-\d{3,4})?$/;if(!verify($("fax").value,"fax")){$("lbfax").innerHTML = "传真号码的格式不正确!";return false;}else{$("lbfax").innerHTML = "";return true;}}
    function testsubmit(){var objs = document.getElementsByTagName("form")[0].getElementsByTagName("input");if(!setMsg($("username"),"邮箱账户",$("lbemail")))return false;if(!setMsg($("inc"),"企业名称",$("lbinc")))return false;if(!setMsg($("contact"),"联系人",$("lbcontact")))return false;if($("tel").value.length==0&&$("mobile").value.length==0){$("lbtel").innerHTML="固定电话与手机必需填写一项!";$("tel").focus();return false;}if(!setMsg($("address"),"联系地址",$("lbaddress")))return false;}
    function setMsg(obj1,msg,obj2){if(obj1.value.length==0){obj2.innerHTML = msg + "不能为空";obj1.focus();return false;}else{obj2.innerHTML="";return true;}}
    //-->
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="start">
        <div class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div class="count" runat="server">修改资料</div>
            <div></div>
            <ul class="logins">
                <li>&nbsp;&nbsp;　邮箱账户：<input style="border:0px;" class="loginInput" type="text" id="username" name="username" runat="server" onchange="return testemail()" autocomplete="off" readonly="readonly" />&nbsp;<span id="lbemail" class="red"></span><span class="gray">(请输入您常用的电子邮箱)</span></li>
                <li>&nbsp;&nbsp;　您的密码：<input class="loginInput" name="password" type="password" id="password" runat="server" onchange="return testpwd()" autocomplete="off" />&nbsp;<span id="lbpwd1" class="red"></span><span class="gray">(密码长度为6-20个字符)</span></li>
                <li>&nbsp;&nbsp;　确认密码：<input class="loginInput" name="repassword" type="password" id="repassword" runat="server" onchange="return testpwd()" autocomplete="off" />&nbsp;<span id="lbpwd2" class="red"></span><span class="gray">(请再次输入密码进行确认)</span></li>
                <li><span class="red">*</span>&nbsp;　企业名称：<input class="loginInput" name="inc" type="text" runat="server" id="inc" /><span id="lbinc" class="red"></span></li>
                <li><span class="red">*</span>&nbsp;　联 系 人：<input class="loginInput" name="contact" type="text" runat="server" id="contact" /><span id="lbcontact" class="red"></span></li>
                <li><span class="red">*</span>&nbsp;　固定电话：<input class="loginInput" name="tel" type="text" runat="server" id="tel" onchange="return testtel()" autocomplete="off" />&nbsp;<span id="lbtel" class="red"></span><span class="gray">(区号+电话+分机号，例如：010-12345678-1234)</span></li>
                <li>&nbsp;&nbsp;　手　　机：<input class="loginInput" name="mobile" type="text" runat="server" id="mobile" onchange="return testmobile()" autocomplete="off" />&nbsp;<span id="lbmobile" class="red"></span><span class="gray">(固定电话与手机，必填一项)</span></li>
                <li>&nbsp;&nbsp;　传　　真：<input class="loginInput" name="fax" type="text" runat="server" id="fax" autocomplete="off" />&nbsp;<span id="lbfax" class="red"></span><span class="gray">(选填)</span></li>
                <li>&nbsp;&nbsp;　腾讯　QQ：<input class="loginInput" name="qq" type="text" runat="server" id="qq" autocomplete="off" />&nbsp;<span id="lbmail" class="red"></span></li>
                <li>&nbsp;&nbsp; Messenger：<input class="loginInput" name="msn" type="text" runat="server" id="msn" autocomplete="off" />&nbsp;<span id="lbmsn" class="red"></span></li>
                <li><span class="red">*</span>&nbsp;　固定电话：<input class="loginInput" name="address" type="text" runat="server" id="address" /><span id="lbaddress" class="red"></span></li>
                <li>&nbsp;&nbsp;　　　　　　<span class="red" style="font-size:12px;">注意：带“*”号字段为必填内容，不带“*”号字段为选填内容。</span></li>
                <li>&nbsp;&nbsp;　　　　　　<input type="submit" runat="server" onserverclick="UserInfoEdit_Click" class="button" value="修改" />&nbsp;&nbsp;<input type="button" onclick="history.go(-1);" class="button" value="返回" /></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
