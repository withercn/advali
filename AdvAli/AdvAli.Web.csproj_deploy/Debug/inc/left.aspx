<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="AdvAli.Web.inc.left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style type="text/css">
     body {margin:0 auto;padding:0 auto;background-color:#3A89C5;overflow:hidden;font-size:12px;font-family:Arial,宋体;color:White;}
     .hide {float:right;margin:0 4px 4px 0;cursor:pointer;}
     #menu .sub {background:url(../images/dir_1.gif) left no-repeat;width:127px;height:18px;margin-left:15px;font-weight:bold;padding-left:40px;}
     #menu .sub1 img {width:36px;height:18px;float:left;margin-right:4px;cursor:pointer;}
     #menu .sub1 {width:127px;height:18px;margin-left:15px;font-weight:bold;}
     #menu a {color:white;text-decoration:none;}
     #menu a:hover {color:#FFFF00}
     #menu ul {list-style:none;margin:0;padding:0;border:0;line-height:22px;}
     #menu ul li {background:url(../images/dir_3.gif) left no-repeat;width:127px;height:22px;margin-left:22px;padding-left:40px;}
     #menu ul li a {text-decoration:underline;color:white;}
     #menu ul li a:hover {color:#FFFF00;}
     .f {background:url(../images/dir.gif) left no-repeat;width:129px;height:18px;margin:0 auto;margin:15px;}
     .f span {color:#FFFF00;margin-left:25px;}
     </style>
     <script type="text/javascript" src="../script/left.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<img src="../images/hide_left-trans.gif" alt="隐藏/显示" class="hide" onclick="showhide('menu',this);" />--%>
        <div class="f"><span>客服中心</span></div>
        <div id="menu" runat="server"></div>
        
    </div>
    </form>
</body>
</html>
