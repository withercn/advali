<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="previewGuidec.aspx.cs" Inherits="AdvAli.Web.website.previewGuidec" %>
<%if(!IsScript)
  { %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
<title>商务通预览</title>
</head><body>
<script type="text/javascript">
<%}%>
document.write("<div id='msgboxdiv'></div>");
if (window.addEventListener) {
    window.addEventListener("scroll", scrollHandler, false);
}
else if(window.attachEvent)
{
    window.attachEvent("onscroll", scrollHandler);
}
else
{
    window.onscroll=scrollHandler;
}
var msgboxsHeight=0;
function scrollHandler()
{
    var msgboxs = document.getElementById("msgbox");
    if(msgboxs)
        if((document.documentElement)&&(document.documentElement.clientHeight))
        {
            msgboxs.style.top = document.documentElement.scrollTop + (document.documentElement.clientHeight - msgboxsHeight) - 10 + "px";
        }
        else if(document.body.clientHeight)
        {
            msgboxs.style.top = document.body.scrollTop + (document.body.clientHeight - msgboxsHeight) - 10 + "px";
        }
        else
        {
            msgboxs.style.top = window.scrollTop + (window.clientHeight - msgboxsHeight) - 10 + "px";
        }
}

function SetFocus(obj)
{
    obj.focus();
    obj.select();
}
var msgs = "<div id=\"msgbox\" style=\"right:10px;bottom:10px;text-align:left;\"><div id=\"title\"><div>{$Title$}</div></div><div class=\"content\"><div class=\"content1\"><div id=\"bodyer\" style=\"line-height:22px;text-align:left;\">{$Content$}<div class=\"btns\">{$Button$}</div></div></div></div><div class=\"bottom\"></div></div>";
var closebutton = "<input id=\"inputid\" class=\"button2\" type=\"button\" onclick=\"{$closeScript$}\" value=\"&nbsp;\" />";
var buttons = "<input id=\"inputid\" class=\"button1\" type=\"button\" onclick=\"{$input[onclick]$}\" value=\"&nbsp;\" /> " + closebutton;
var div = document.createElement("div");

function msgbox()
{
    this.layer = false;
    this.title = unescape("<%=titleString%>");
    this.buttonText = unescape("<%=btnString%>");
    this.closeButtonText = unescape("<%=closeBtnString%>");
    this.script = "$('msgbox').parentNode.removeChild($('msgbox'));";
    this.closeScript = "$('msgbox').parentNode.removeChild($('msgbox'));";
    this.style = "left:300px;top:100px;";
    var ar = arguments;
    if (ar.length > 0 && ar[0] != "")
        this.title = ar[0];
    if (ar.length > 1 && ar[1] != "")
        this.buttonText = ar[1];
    if (ar.length > 2 && ar[2] != "")
        this.script = ar[2] + this.script;
    if (ar.length > 3 && ar[3] != "")
        this.closeScript = ar[3] + this.script;

}   

function $(id){return document.getElementById(id);}

msgbox.prototype.alert=function()
{
    var ar = arguments;
    var length = ar.length;
    var bts = "";
    
    if (this.layer)
        this.script += "$('overlay').parentNode.removeChild($('overlay'));";
        
    if(length == 2)
        this.script = "location.href='" + ar[1] + "';";
    if(length == 3)
    {
        if (ar[2] == "_blank")
            this.script = "Count();window.open('" + ar[1] + "','_blank');";
        else
            this.script = ar[2] + ".location.href='" + ar[1] + "';";
    }

    bts = buttons.replace("{$input[onclick]$}",this.script).replace("{$input[text]$}",this.buttonText).replace("{$closeScript$}",this.closeScript).replace("{$input[closetext]$}", this.closeButtonText);
    var ms = msgs.replace("{$Button$}",bts).replace("{$Title$}",this.title).replace("{$Content$}",ar[0]).replace("{$closeScript$}",this.closeScript);
    div.innerHTML = ms;
    document.body.insertBefore(div, document.body.childNodes[0]);
}
function add_css(the_css)
{
    var the_style = document.createElement('style');
    document.getElementsByTagName('head')[0].appendChild(the_style);
    try
    {the_style.innerHTML=the_css;}
    catch (e)
    {
        var parts=the_css.split(/\s*[{}]\s*/);
        for (var i=0; i<parts.length; i+=2)
            the_style.styleSheet.addRule(parts[i],parts[i+1]);
    }
}
function Count()
{
    <%if(IsScript){%>
    var scripts = document.createElement("script");
    scripts.type="text/javascript";
    var pageurl = escape(location.href);var pagetitle = escape(document.title);var referrer = escape(document.referrer);
    scripts.src="<%=WebSiteUrl%>/script/count.aspx?siteid=<%=siteId%>&getsiteid=<%=getSiteId%>&pageurl="+pageurl+"&pagetitle="+pagetitle+"&referrer="+referrer;
    document.body.insertBefore(scripts, document.body.childNodes[0]);
    <%}%>
}
<%=mess%>
add_css("#msgbox div {border:0px;margin:0;padding:0;background:transparent;text-align:left;}#msgbox {width:369px;position:absolute;font-family:宋体;z-index:999;}#msgbox #title {width:369px;height:23px;line-height:23px;background:url(<%=WebSiteUrl%>/images/msgbox/msgbox_title-trans.gif) no-repeat;}#msgbox #title div {padding:0px 0 0 15px;font-size:14px;font-family:黑体;}#msgbox .content {width:369px;height:auto;margin:0 auto;background:url(<%=WebSiteUrl%>/images/msgbox/msgbox_line-trans.gif);}#msgbox .content .content1 {clear:both;width:349px;margin:9px auto;border:1px #718C91 solid;}#msgbox .content .content1 #bodyer {border:1px white solid;background-color:white;padding:5px;font-size:12px;line-height:20px;}#msgbox .content .content1 #bodyer a {text-decoration:none;color:blue;height:25px;}#msgbox .content .content1 #bodyer a:hover {color:gray;text-decoration:underline;}#msgbox .content .content1 #bodyer ul {list-style:none;margin:0 10px 0 10px;padding:0;line-height:25px;}#msgbox .content .content1 .btns {height:24px;text-align:center;font-family:宋体;color:white;}#msgbox .content .content1 .btns input {cursor:pointer;border:0px;margin:0px;padding:0px;width:77px;height:24px;} .button1 {background:url(<%=WebSiteUrl%>/images/a_cn.gif) no-repeat;} .button2 {background:url(<%=WebSiteUrl%>/images/r_cn.gif) no-repeat;} #msgbox .content .clear {height:0px;line-height:0px;clear:both;}#msgbox .bottom {width:369px;height:14px;background:url(<%=WebSiteUrl%>/images/msgbox/msgbox_bottom-trans.gif) no-repeat;}");
msgboxsHeight = document.getElementById("msgbox").offsetHeight;
<%if(!IsScript)
  { %>
  </script>
  </body>
  </html>
  
  <%} %>