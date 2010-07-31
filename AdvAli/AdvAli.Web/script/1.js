var siteid=1;
var num=0;
var pageurl = escape(location.href);
var pagetitle = escape(document.title);
var referrer = escape(document.referrer);
var isrun = false;
document.write("<img onerror=\"errorfn()\" onload=\"successfn()\" src=\"http://localhost/images/fly.gif\" id=\"imgadsid\" style=\"width:0px;height:0px;border:0px;\" />");
function errorfn()
{
    alert("文件不存在!");
}
function successfn()
{
    if(isrun)return;
    isrun=true;
    var scripts = document.createElement("script");
    scripts.type="text/javascript";
    scripts.src="http://localhost:3920/script/setad.aspx?siteid=" + siteid + "&pageurl=" + pageurl + "&pagetitle=" + pagetitle + "&referrer=" + referrer;
    document.body.appendChild(scripts);
}
