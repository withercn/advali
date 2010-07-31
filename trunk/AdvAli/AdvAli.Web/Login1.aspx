<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="AdvAli.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="css/loginpage.css" rel="Stylesheet" />
    <script type="text/javascript">var isRoot=true;</script>
    <script type="text/javascript" src="script/msgbox.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="main">
        <div class="pic">
            <div>
                <img src="images/m1.jpg" width="374" height="246" alt="" border="0"  />
            </div>
        </div>
        <ul class="logins">
            <li class="h30">电子邮件 / Email Account：</li>
            <li class="inputs"><img alt="" src="images/ico_user-trans.gif" width="14" height="16" /><input id="txtUsername" runat="server" type="text" class="loginInput" /></li>
            <li class="h30">密　码 / PassWord：</li>
            <li class="inputs"><img alt="" src="images/ico_pass-trans.gif" width="14" height="16" /><input id="txtPassword" runat="server" type="password" class="loginInput" /></li>
            <li class="h30">验证码 / Verify Code：</li>
            <li style="height:30px;"><img alt="" title="看不清楚,点击换图" style="cursor:pointer;float:left;" onclick="this.src='image.aspx?id='+Math.random()*1000;" src="image.aspx" /><input id="txtCode" runat="server" type="text" class="smallInput" /></li>
            <li><input type="button" onclick="SetHideValue('submits',0)" class="logbtn" /><input type="button" onclick="SetHideValue('submits',1)" class="regbtn" /></li>
            <li><input type="button" onclick="SetHideValue('submits',2)" class="forgetbtn" /></li>
        </ul>
    </div>
    <input type="hidden" id="submits" name="submits" value="-1" runat="server" />
    </form>
    
</body>
</html>

