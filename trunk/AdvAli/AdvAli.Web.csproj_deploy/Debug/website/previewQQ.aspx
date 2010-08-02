<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="previewQQ.aspx.cs" Inherits="AdvAli.Web.website.previewQQ" %>
<%if(!IsScript)
  {%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>预览</title>
</head>
<body>
<script type="text/javascript">
<%}%>
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
add_css("div {margin:0px;}#QQ div {padding:0;}#QQ {font-family:宋体;font-size:12px;position:absolute;margin:0 auto;padding:0;border:0;}.QQ_Header {width:186px;height:75px;background-image:url(<%=WebSiteUrl%>/images/qq/qq_header.png);}.QQ_Header img#min {width:25px;height:17px;border:0px;margin:1px 0 0 0;float:right;cursor:pointer;}.QQ_Header img#close {width:42px;height:17px;border:0px;margin:1px 5px 0 0;float:right;cursor:pointer;}.QQ_Header span {display:block;clear:both;padding:10px 10px 10px 60px;line-height:20px;height:30px;overflow:hidden;color:White;}.QQ_Content {width:186px;max-height:400px;overflow-y:auto;overflow-x:hidden;background-image:url(<%=WebSiteUrl%>/images/qq/qq_line.png);padding:1px;}.QQ_Content ul {width:176px;margin:1px auto;padding:0;border:1px #D2EAF9 solid;line-height:28px;padding-bottom:50px;}.QQ_Content .mover {height:28px;line-height:28px;overflow:hidden;margin:5px 0px 0px 2px;padding-left:2px;cursor:default;vertical-align:top;}.QQ_Content .mover .m1 {float:left;width:21px;height:25px;margin-top:2px;}.QQ_Content .mover .m1 img {border:1px #E7EDF2 solid;width:20px;height:20px;}.QQ_Content .mover .m2 {height:20px;}.QQ_Content .mover .m2 .s1 {padding-left:12px;max-width:80px;overflow:hidden;display:block;height:20px;float:left;}.QQ_Content .mover .m2 .s2 {padding-left:5px;display:block;height:20px;color:Gray;}.QQ_Content .select {height:54px;overflow:hidden;margin:5px 0px 0px 2px;padding-left:2px;cursor:default;vertical-align:top;background-image:url(<%=WebSiteUrl%>/images/qq/qq_select.png);}.QQ_Content .select .m1 {float:left;width:54px;height:54px;line-height:54px;margin-top:2px;float:left;}.QQ_Content .select .m1 img {border:1px #E7EDF2 solid;width:50px;height:50px;}.QQ_Content .select .m2 {padding-left:4px;height:54px;}.QQ_Content .select .m2 .s1 {display:block;}.QQ_Content .select .m2 .s2 {display:block;color:Gray;line-height:12px;}.QQ_Bottom {width:116px;height:52px;background-image:url(<%=WebSiteUrl%>/images/qq/qq_bottom.png);padding-left:60px;padding-top:3px;font-size:12px;color:White;line-height:25px;}#QQ div.QQ_Bottom {padding-left:60px;padding-top:3px;padding-right:10px;}");
var userinfo="<%=userinfo%>",adinfo="<%=adinfo%>";
var qqmsg = "<div id=\"QQ\" style=\"left:0px;top:0px;\" onselectstart=\"return false;\"><div class=\"QQ_Header\"><img id=\"close\" alt=\"关闭\" src=\"<%=WebSiteUrl%>/images/qq/QQ_CloseUp.png\" onmouseover=\"this.src='<%=WebSiteUrl%>/images/qq/QQ_closedown.png';\" onmouseout=\"this.src='<%=WebSiteUrl%>/images/qq/QQ_closeup.png';\" /><span>{$UserInfo$}</span></div><div class=\"QQ_Content\"><ul id=\"qqlist\">{$QQList$}</ul></div><div class=\"QQ_Bottom\">{$AdInfo$}</div></div>".replace("{$UserInfo$}",userinfo).replace("{$AdInfo$}",adinfo);
var qqlist = "<%=qqlist%>";
var divs = document.createElement("div")
divs.innerHTML = qqmsg.replace("{$QQList$}",qqlist);
document.body.insertBefore(divs, document.body.childNodes[0]);
var qq = document.getElementById("QQ");
this.SetHeight();
qq.style.left = "0px";
qq.onmouseover=function(){this.style.left="0px";}
var close = document.getElementById("close");
close.onclick = function(){
qq.onmouseover='';
Hide();
}
var qqobj = document.getElementById("qqlist").getElementsByTagName("li");
SetClassMover(); 
qq.onmouseover='';
Hide();
for(var i=0;i<qqobj.length;i++)
{
    qqobj.item(i).onclick = function()
    {
        SetClassMover();
        this.className='select';
        this.onmouseover='';
        this.onmouseout='';
        this.style.backgroundImage='url(<%=WebSiteUrl%>/images/qq/qq_select.png)';
        if (this.getElementsByTagName("div")[0].getElementsByTagName("img")[0].src.toLowerCase().indexOf("_offline")==-1)
            this.getElementsByTagName("div")[0].getElementsByTagName("img")[0].src='<%=WebSiteUrl%>/images/qq/qq_big.png';
        else
            this.getElementsByTagName("div")[0].getElementsByTagName("img")[0].src='<%=WebSiteUrl%>/images/qq/qq_OffLine_big.png';
    }
}

function SetClassMover()
{
    var objs = document.getElementById("qqlist").getElementsByTagName("li");
    for(var i=0;i<objs.length;i++)
    {
        objs.item(i).className='mover';
        if(objs.item(i).getElementsByTagName("div")[0].getElementsByTagName("img")[0].src.toLowerCase().indexOf("_offline")==-1)
            objs.item(i).getElementsByTagName("div")[0].getElementsByTagName("img")[0].src='<%=WebSiteUrl%>/images/qq/qq.png';
        else
            objs.item(i).getElementsByTagName("div")[0].getElementsByTagName("img")[0].src='<%=WebSiteUrl%>/images/qq/qq_OffLine.png';
        objs.item(i).style.background='';
        objs.item(i).onmouseover=function(){this.style.backgroundImage='url(<%=WebSiteUrl%>/images/qq/qq_mover.png)';}
        objs.item(i).onmouseout=function(){this.style.backgroundImage='';}
        objs.item(i).ondblclick=function(){Count();location.href='<%=LinkUrl%>' + this.getElementsByTagName("div")[0].getElementsByTagName("img")[0].alt;}
    }
}
if (window.addEventListener) {
    window.addEventListener("scroll", SetHeight, false);
}
else if(window.attachEvent)
{
    window.attachEvent("onscroll", SetHeight);    
}
else
{
    window.onscroll=SetHeight;
}

function SetHeight()
{
    var bases = (document.documentElement.clientHeight - qq.offsetHeight) / 2;
    qq.style.top = (document.documentElement.scrollTop + bases) + "px";
}

function Hide()
{
    var qqleft = parseInt(qq.style.left);
    qqleft--;
    qq.style.left = qqleft + "px";
    if(qqleft>(10 - qq.offsetWidth))
    {
        window.setTimeout(Hide,1);
    }
    else
    {
        qq.onmouseover=function(){this.style.left="0px";}
    }
}
function Count()
{
    <%if(IsScript){%>
    var scripts = document.createElement("script");
    scripts.type="text/javascript";
    var pageurl = escape(location.href);var pagetitle = escape(document.title);var referrer = escape(document.referrer);
    scripts.src="<%=AdvAli.Config.Global.config.WebSiteUrl%>/script/count.aspx?siteid=<%=siteId%>&getsiteid=<%=getSiteId%>&pageurl="+pageurl+"&pagetitle="+pagetitle+"&referrer="+referrer;
    document.body.insertBefore(scripts, document.body.childNodes[0]);
    <%}%>
}
<%if(!IsScript)
  {%>
</script>
</body>
</html>
<%}%>