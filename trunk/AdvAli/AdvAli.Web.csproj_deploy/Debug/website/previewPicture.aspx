<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="previewPicture.aspx.cs" Inherits="AdvAli.Web.website.previewPicture" %>

<%if(!IsScript) 
  {%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>图片预览</title>
</head>
<body>
<script type="text/javascript">
<%} %>
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
add_css(".picframe {position:absolute;right:10px;bottom:10px;width:<%=width+20%>px;height:<%=height+62%>px;}.r1 {height:30px;line-height:30px;}.r1 .d1 {width:5px;background:url(<%=WebSiteUrl%>/images/picture/t-l.gif) no-repeat;width:5px;}.r1 .d2 {background:url(<%=WebSiteUrl%>/images/picture/t-c.gif);} .r1 .d2 .v1 {float:left;font-family:黑体;font-size:14px;padding-left:5px;}.r1 .d2 .v2 {float:right;margin-top:1px;} .r1 .d2 .v2 img {cursor:pointer;width:44px;height:17px;}.r1 .d3 {background:url(<%=WebSiteUrl%>/images/picture/t-r.gif) no-repeat;width:5px;}.r2 {background-color:white;}.r2 .d1 {background:url(<%=WebSiteUrl%>/images/picture/c-l.gif);width:5px;}.r2 .d2 {padding:5px;}.r2 .d2 .v2 {text-align:center;margin-top:5px;}.r2 .d2 .v2 input {cursor:pointer;border:0px;margin:0px;padding:0px;width:77px;height:24px;color:black;}.button1 {background:url(<%=WebSiteUrl%>/images/a_cn.gif) no-repeat;} .button2 {background:url(<%=WebSiteUrl%>/images/r_cn.gif) no-repeat;}.r2 .d3 {background:url(<%=WebSiteUrl%>/images/picture/c-r.gif);width:5px;}.r3 {height:6px;line-height:6px;}.r3 .d1 {width:5px;background:url(<%=WebSiteUrl%>/images/picture/b-l.gif) no-repeat;width:5px;}.r3 .d2 {background:url(<%=WebSiteUrl%>/images/picture/b-c.gif);}.r3 .d3 {background:url(<%=WebSiteUrl%>/images/picture/b-r.gif) no-repeat;width:5px;} .faint {filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);display:block;}");
var divs = document.createElement("div");
divs.className = "picframe";
divs.id = "picframe";
divs.innerHTML = "<table id=\"tb0\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\"><tr class=\"r1\"><td class=\"d1\"></td><td class=\"d2\"><div class=\"v1\">" + unescape("<%=sTitle%>") + "</div></td><td class=\"d3\"></td></tr><tr class=\"r2\"><td class=\"d1\"></td><td class=\"d2\"><div><%=html%></div><div class=\"v2\"><input onclick=\"Count();window.open('<%=piclnk%>','_blank');\" value=\"&nbsp;\" type=\"button\" class=\"button1\" /> <input onclick=\"document.getElementById('tb0').parentNode.removeChild(document.getElementById('tb0'));\" value=\"&nbsp;\" type=\"button\" class=\"button2\" /></div></td><td class=\"d3\">&nbsp;</td></tr><tr class=\"r3\"><td class=\"d1\"></td><td class=\"d2\"></td><td class=\"d3\"></td></tr></table>";
document.body.insertBefore(divs, document.body.childNodes[0]);
scrollHandler();
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
function scrollHandler()
{
    var picframe = document.getElementById("picframe");
    if(picframe)
    picframe.style.top = document.documentElement.scrollTop + (document.documentElement.clientHeight-picframe.offsetHeight) + "px";
}
var imgLnk = document.getElementById("imgLnk");
    var url = imgLnk.innerHTML;
    imgLnk.style.width = "<%=width%>px";
    imgLnk.style.height = "<%=height%>px";
    imgLnk.innerHTML="";
    if(url.toLowerCase().substring(0,4) == "http")
    {
        var imgs = document.createElement("img");
        imgs.src = url;
        imgs.width = <%=width%>;
        imgs.height = <%=height%>;
        imgs.border=0;
        imgLnk.appendChild(imgs);
    }
    else
    {
        imgLnk.filters.item("DXImageTransform.Microsoft.AlphaImageLoader").src = url;
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
<%if(!IsScript){ %>
</script>
</body>
</html>
<%} %>