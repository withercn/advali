function beginDrag(elementToDrag, event) {
var deltaX = event.clientX - parseInt(elementToDrag.style.left);
var deltaY = event.clientY - parseInt(elementToDrag.style.top);
//elementToDrag.style.cursor = "move";
if (document.addEventListener) {//2 级 DOM事件模型
document.addEventListener("mousemove", moveHandler, true);
document.addEventListener("mouseup", upHandler, true);
}
else if (document.attachEvent) {//IE5+事件模型
document.attachEvent("onmousemove", moveHandler);
document.attachEvent("onmouseup", upHandler);
}
else {//IE4事件模型
var oldmovehandler = document.onmousemove;
var olduphandler = document.onmouseup;
document.onmousemove = moveHandler;
document.onmouseup = upHandler;
}
//禁止起泡
if (event.stopPropagation)//DOM2
event.stopPropagation();
else event.cancelBubble = true;//IE
if (event.preventDefault)
event.preventDefault();
else event.cancelBubble = true;
function moveHandler(e) {
if (!e)
e = window.event;
elementToDrag.style.left = (e.clientX - deltaX) + "px";
elementToDrag.style.top = (e.clientY - deltaY) + "px";
if (e.stopPropagation)
e.stopPropagation();
else e.cancelBubble = true;
}
function upHandler(e) {
if (!e)
e = window.event;
elementToDrag.style.cursor = "default";
if (document.removeEventListener) { //DOM2
document.removeEventListener('mouseup', upHandler, true);
document.removeEventListener('mousemove', moveHandler, true);
}
else if (document.detachEvent) { //IE5+
document.detachEvent("onmousemove", moveHandler);
document.detachEvent("onmouseup", upHandler);
}
else {//IE4
document.onmouseup = olduphandler;
document.onmousemove = oldmovehandler;
}
if (e.stopPropagation)
e.stopPropagation();
else e.cancelBubble = true;
}
}

var start = 1;
var objid = "inputid";

function SetHideValue(id,value)
{
    $(id).value = value;
    document.forms[0].submit();
}

if(document.all)
{
    window.attachEvent('onload', loadWindows);
}
else
{
    window.addEventListener('load',loadWindows,false);
}

function loadWindows()
{
    if(top.window.document.forms.length>0)
    {
        top.window.document.forms[0].appendChild(div);
        if (start == 1)
        {
            $('txtUsername').focus();
        }
        else if (start == 0)
        {
            if ($(objid))
                $(objid).focus();
        }
    }
    else
    {
        document.body.appendChild(div);
    }
}

function SetFocus(obj)
{
    obj.focus();
    obj.select();
}
var path = "../";
if(typeof(isRoot) != 'undefined')
    path = "";
if(typeof(paths) != 'undefined')
    path = paths;
document.writeln("<link href=\"" + path + "css/msgbox.css\" rel=\"Stylesheet\" />");
var msgs = "<div id=\"msgbox\" style=\"{$style$}\"><div id=\"title\" onmousedown=\"beginDrag(this.parentNode, event);\"><img src=\"" + path + "images/msgbox/close_up.gif\" onclick=\"{$closeScript$}\" onmouseover=\"this.src='" + path + "images/msgbox/close_down.gif'\" onmouseout=\"this.src='" + path + "images/msgbox/close_up.gif'\" alt=\"关闭\" /><div>{$Title$}</div></div><div class=\"content\"><div class=\"content1\"><div id=\"bodyer\">{$Content$}<div class=\"btns\">{$Button$}</div></div></div></div><div class=\"bottom\"></div></div>";
var buttons = "<input id=\"inputid\" onmouseover=\"this.style.backgroundImage='url(" + path + "images/msgbox/btn_down-trans.gif)'\" onmouseout=\"this.style.backgroundImage='url(" + path + "images/msgbox/btn_up-trans.gif)'\" type=\"button\" onclick=\"{$input[onclick]$}\" value=\"{$input[text]$}\" />";
var div = document.createElement("div");

function msgbox()
{
    this.layer = false;
    this.title = "系统提示";
    this.buttonText = "确定";
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

msgbox.prototype.overlayer=function()
{
    var divs = document.createElement("div");
    divs.innerHTML = "<div id=\"overlay\" style=\"z-index:1;filter:alpha(opacity=70);left:0px;top:0px;width:100%;height:100%;background-color:black;position:absolute;moz-opacity:0.7;opacity:.70;\"></div>"
    document.body.appendChild(divs);
    this.layer = true;
}

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
            this.script = "window.open('" + ar[1] + "','_blank');";
        else
            this.script = ar[2] + ".location.href='" + ar[1] + "';";
    }
    if(length == 4)
        if(ar[3]==true)
        {
            var left = document.documentElement.offsetWidth - 378 + "px";
            var top = document.documentElement.clientHeight - 248 + "px";
            this.style = "left:" + left + ";top:" + top + ";";
        }
    bts = buttons.replace("{$input[onclick]$}",this.script).replace("{$input[text]$}",this.buttonText);
    msgs = msgs.replace("{$style$}", this.style);
    var ms = msgs.replace("{$Button$}",bts).replace("{$Title$}",this.title).replace("{$Content$}",ar[0]).replace("{$closeScript$}",this.closeScript);
    div.innerHTML = ms;
}