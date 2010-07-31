var qqmsg = "<div id=\"QQ\" style=\"left:0px;top:0px;\" onselectstart=\"return false;\"><div class=\"QQ_Header\"><img id=\"close\" alt=\"关闭\" src=\"/images/qq/QQ_CloseUp.png\" onmouseover=\"this.src='/images/qq/QQ_closedown.png';\" onmouseout=\"this.src='/images/qq/QQ_closeup.png';\" /><img id=\"min\" alt=\"最小化\" src=\"/images/qq/qq_minup.png\" onmouseover=\"this.src='/images/qq/qq_mindown.png';\" onmouseout=\"this.src='/images/qq/qq_minup.png';\" /><span>{$UserInfo$}</span></div><div class=\"QQ_Content\"><ul id=\"qqlist\">{$QQList$}</ul></div><div class=\"QQ_Bottom\">{$AdInfo$}</div></div>";
var qqlist = "<li class=\"mover\"><div class=\"m1\"><img alt=\"971240\" src=\"/images/QQ/QQ.png\" /></div><div class=\"m2\"><span class=\"s1\">这是一个这是一个</span><span class=\"s2\">这是一段说明文字</span></div></li>";

var qq = document.getElementById("QQ");
this.SetHeight();
qq.style.left = (10 - qq.offsetWidth) + "px";
qq.onmouseover=function(){this.style.left="0px";}
var min = document.getElementById("min");
var close = document.getElementById("close");
min.onclick = function(){
qq.onmouseover='';
Hide();
}
close.onclick = function(){qq.parentNode.removeChild(qq);}
var qqobj = document.getElementById("qqlist").getElementsByTagName("li");
SetClassMover(); 
for(var i=0;i<qqobj.length;i++)
{
    qqobj.item(i).onclick = function()
    {
        SetClassMover();
        this.className='select';
        this.onmouseover='';
        this.onmouseout='';
        this.style.backgroundImage='url(/images/qq/qq_select.png)';
        this.getElementsByTagName("div")[0].getElementsByTagName("img")[0].src='/images/qq/qq_big.png';
    }
}

function SetClassMover()
{
    var objs = document.getElementById("qqlist").getElementsByTagName("li");
    for(var i=0;i<objs.length;i++)
    {
        objs.item(i).className='mover';
        objs.item(i).getElementsByTagName("div")[0].getElementsByTagName("img")[0].src='/images/qq/qq.png';
        objs.item(i).style.background='';
        objs.item(i).onmouseover=function(){this.style.backgroundImage='url(/images/qq/qq_mover.png)';}
        objs.item(i).onmouseout=function(){this.style.backgroundImage='';}
        objs.item(i).ondblclick=function(){location.href='tencent://message/?uin=' + this.getElementsByTagName("div")[0].getElementsByTagName("img")[0].alt;}
    }
}
window.onresize=window.onscroll;

window.onscroll=function()
{
    this.SetHeight();
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