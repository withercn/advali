function $(id){return document.getElementById(id);}
function checkall()
{
    var startid = parseInt(document.getElementById("startid").value);
    var idlist = document.getElementById("idlist");
    idlist.value = "";
    while(document.getElementById("sel" + startid))
    {
        var obj = document.getElementById("sel" + startid);
        if(arguments[0]==2)
        {
            obj.checked = !obj.checked;
            if(obj.checked==true)
                idlist.value += obj.value + ",";
        }
        else if(document.getElementById("selall").checked || arguments[0]==1)
        {
            obj.checked = true;
            idlist.value += obj.value + ",";
            $("selall").checked = true;
        }
        else
        {
            obj.checked = false;
        }
        startid ++;
    }
}

function SetHid(value)
{
    var idlist = document.getElementById("idlist");
    if(idlist.value.indexOf(value)!=-1)
    {
        idlist.value = idlist.value.replace(value + ",", "");
    }
    else
    {
        idlist.value = idlist.value + value + ",";
    }
}

function search()
{
    var url = location.href;
    if(url.indexOf("?") != -1)
        url = url.substring(0,url.indexOf("?"));
    url += "?txtusername=" + document.getElementById("txtUsername").value + "&timesel=" + document.getElementById("timesel").value + "&time1=" + document.getElementById("timer1").value + "&time2=" + document.getElementById("timer2").value;
    location.href = url;
}
function SetCustomizeAdmins(obj)
{
    var hih = document.getElementById("hid");
    if(obj.checked && hih.value.indexOf(obj.value) == -1)
    {
        hih.value += obj.value + ",";
    }
    else if (!obj.checked && hih.value.indexOf(obj.value) != -1)
    {
        hih.value = hih.value.replace(obj.value + ",", "");
    }
}

function attack(str)
{
//    hideAll();
//    switch(str)
//    {
//        case "1":
//            document.getElementById("guidec").style.display="block";
//            break;
//        case "2":
//            document.getElementById("qq").style.display="block";
//            $("qq").innerHTML = $("qq").innerHTML.replace("Msn头部", "QQ头部").replace("Msn底部","QQ底部").replace(/Msn号/g,"QQ号").replace(/Msn名/g,"QQ名").replace(/Msn说/g,"QQ说").replace("添加Msn","添加QQ").replace("删除Msn","删除QQ");
//            $("isqq").value = "1";
//            break;
//        case "3":
//            document.getElementById("qq").style.display="block";
//            $("qq").innerHTML = $("qq").innerHTML.replace("QQ头部", "Msn头部").replace("QQ底部","Msn底部").replace(/QQ号/g,"Msn号").replace(/QQ名/g,"Msn名").replace(/QQ说/g,"Msn说").replace("添加QQ","添加Msn").replace("删除QQ","删除Msn");
//            $("isqq").value = "0";
//            break;
//        case "4":
//            document.getElementById("pic").style.display="block";
//            break;
//        default:
//            break;
//    }
}

function hideAll()
{
//    var objs = document.getElementById("nones").getElementsByTagName("ul");
//    for (var i=0;i<objs.length;i++)
//    {
//        if(objs[i] != $("cons"))
//            objs[i].style.display="none";
//    }
}

function AddQQ(obj)
{
    var tag = "QQ";
    if($("isqq").value=="0")
        tag = "Msn";
    var qqn = parseInt(document.getElementById("qqn").value);
    qqn = qqn + 1;
    if (qqn>20)
    {
        return;
    }
    document.getElementById("qqn").value = qqn;
    var qqnum1 = document.createElement("li");
    qqnum1.className = "left";
    qqnum1.innerHTML = tag + "号码" + qqn + "：";
    obj.parentNode.insertBefore(qqnum1,obj);
    var qqnum2 = document.createElement("li");
    qqnum2.className = "inputf left";
    qqnum2.innerHTML = "<input id=\"qqnum" + qqn + "\" name=\"qqnum" + qqn + "\" type=\"text\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(qqnum2,obj);
    var qqs1 = document.createElement("li");
    qqs1.className = "left";
    qqs1.innerHTML = tag + "名称" + qqn + "：";
    obj.parentNode.insertBefore(qqs1,obj);
    var qqs2 = document.createElement("li");
    qqs2.className = "inputf left";
    qqs2.innerHTML = "<input id=\"qqs" + qqn + "\" name=\"qqs" + qqn + "\" type=\"text\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(qqs2,obj);
    var cls = document.createElement("li");
    cls.style.height="0px";
    cls.style.lineHeight="0px";
    cls.style.clear="both";
    cls.style.fontSize="0px";
    cls.style.overflow="hidden";
    cls.innerText = " ";
    obj.parentNode.insertBefore(cls,obj);
    var qqtitle1 = document.createElement("li");
    qqtitle1.className = "left";
    qqtitle1.innerHTML = tag + "说明" + qqn + "：";
    obj.parentNode.insertBefore(qqtitle1,obj);
    var qqtitle2 = document.createElement("li");
    qqtitle2.className = "inputs left";
    qqtitle2.innerHTML = "<input id=\"qqtitle" + qqn + "\" name=\"qqtitle" + qqn + "\" type=\"text\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(qqtitle2,obj);
    var cls2 = document.createElement("li");
    cls2.style.height="0px";
    cls2.style.lineHeight="0px";
    cls2.style.clear="both";
    cls2.style.fontSize="0px";
    cls2.style.overflow="hidden";
    obj.parentNode.insertBefore(cls2,obj); 
}

function previewQQ()
{
    var qqn = parseInt(document.getElementById("qqn").value);
    var url = "../website/previewQQ.aspx";
    url = url + "?qqn=" + qqn + "&isqq=" + $("isqq").value
    url = url + "&qqhead="+escape($("qqhead").value);
    url = url + "&qqbottom=" + escape($("qqbottom").value);
    for(var i=0;i<qqn;i++)
    {
        url = url + "&qqnum" + i + "=" + escape($("qqnum" + (i+1)).value);
        url = url + "&qqs" + i + "=" + escape($("qqs" + (i+1)).value);
        url = url + "&qqtitle" + i + "=" + escape($("qqtitle" + (i+1)).value);
    }
    return url;
}

function AddGuidec(obj)
{
    var gnum = parseInt($("guidecnum").value);
    gnum = gnum + 1;
    $("guidecnum").value = gnum;
    if(gnum > 5)
    {
        $("guidecnum").value=5;
        return;
    }
    var articleT = document.createElement("li");
    articleT.className = "h30 left";
    articleT.innerText = "广告文字" + gnum + "：";
    obj.parentNode.insertBefore(articleT,obj);
    var articleL = document.createElement("li");
    articleL.className = "inputs";
    articleL.innerHTML = "<input type=\"text\" id=\"article" + gnum + "\" name=\"article" + gnum + "\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(articleL,obj);
    var nuls = document.createElement("li");
    nuls.style.height="0px";
    nuls.style.lineHeight="0px";
    nuls.style.clear="both";
    nuls.style.fontSize="0px";
    nuls.style.overflow="hidden";
    obj.parentNode.insertBefore(nuls,obj);
    var linkT = document.createElement("li");
    linkT.className = "h30 left";
    linkT.innerText = "文字链接" + gnum + "：";
    obj.parentNode.insertBefore(linkT,obj);
    var linkL = document.createElement("li");
    linkL.className = "inputs";
    linkL.innerHTML = "<input type=\"text\" id=\"articlelink" + gnum + "\" name=\"articlelink" + gnum + "\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(linkL,obj);
    nuls = document.createElement("li");
    nuls.style.height="0px";
    nuls.style.lineHeight="0px";
    nuls.style.clear="both";
    nuls.style.fontSize="0px";
    nuls.style.overflow="hidden";
    obj.parentNode.insertBefore(nuls,obj);
}

function previewGuidec()
{
    var gnum = parseInt($("guidecnum").value);
    var url = "../website/previewGuidec.aspx";
    url = url + "?gnum=" + gnum + "&guidechead=" + escape($("guidechead").value) + "&guideclink=" + escape($("guideclink").value);
    for(var i=0;i<gnum;i++)
    {
        url = url + "&article" + i + "=" + escape($("article" + (i+1)).value);
        url = url + "&articlelink" + i + "=" + escape($("articlelink" + (i+1)).value);
    }
    url = url + "&guideccontent=" + escape($("guideccontent").value);
    return url;
}

function AddPicture(obj)
{
    var picnum = parseInt($("picnum").value);
    picnum = picnum + 1;
    $("picnum").value = picnum;
    if(picnum>5)
    {
        return;
    }
    var picNameT = document.createElement("li");
    picNameT.className = "h30";
    picNameT.innerText = "图片名称" + picnum + "：";
    obj.parentNode.insertBefore(picNameT,obj);
    var picNameL = document.createElement("li");
    picNameL.className = "inputs";
    picNameL.innerHTML = "<input type=\"text\" id=\"pic" + picnum + "\" name=\"pic" + picnum + "\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(picNameL,obj);
    var picUrlT = document.createElement("li");
    picUrlT.className = "h30";
    picUrlT.innerText = "图片地址" + picnum + "：";
    obj.parentNode.insertBefore(picUrlT,obj);
    var picUrlL = document.createElement("li");
    picUrlL.className = "h30";
    picUrlL.innerHTML = "<input type=\"file\" id=\"picurl" + picnum + "\" name=\"picurl" + picnum + "\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(picUrlL,obj);
    var picLnkT = document.createElement("li");
    picLnkT.className = "h30";
    picLnkT.innerText = "图片链接" + picnum + "：";
    obj.parentNode.insertBefore(picLnkT,obj);
    var picLnkL = document.createElement("li");
    picLnkL.className = "inputs";
    picLnkL.innerHTML = "<input type=\"text\" id=\"piclnk" + picnum + "\" name=\"piclnk" + picnum + "\" class=\"loginInput\" />";
    obj.parentNode.insertBefore(picLnkL,obj);
}

function previewPicture()
{
    var url = "../website/previewPicture.aspx?width=" + $("picwidth").value + "&height=" + $("picheight").value;
    url += "&picname=" + escape($("picname").value);
    if(!$("picurl").value.length==0)
    {
        url += "&picurl=" + escape(getFullPath($("picurl")));
    }
    else if($("pichref")!=null)
    {
        url += "&picurl=" + escape($("pichref").href);
    }
    else
    {
        url += "&picurl=";
    }
    url += "&piclnk=" + escape($("piclnk").value);
    return url;
}

function deleteGuidec(obj)
{
    var gnum = parseInt($("guidecnum").value);
    if(gnum <= 1)return;
    for(var i=0;i<6;i++)
        removePrevious(obj.parentNode);
    if(gnum>0)
        $("guidecnum").value = gnum -1;
}

function deleteQQMsn(obj)
{
    var qqnum = parseInt($("qqn").value);
    if(qqnum<=1)return;
    for(var i=0;i<8;i++)
        removePrevious(obj.parentNode);
    if(qqnum>0)
        $("qqn").value = qqnum - 1;
}

function deleteImages(obj)
{
    var picnum = parseInt($("picnum").value);
    if(picnum<=1)return;
    for(var i=0;i<6;i++)
        removePrevious(obj.parentNode);
    if(picnum>0)
        $("picnum").value=picnum-1;
}

function removePrevious(obj)
{
    var p1 = obj.previousSibling;
    if(p1.tagName.toLowerCase() != "li")
        p1 = obj.previousSibling;
    p1.parentNode.removeChild(p1);
}

function removeNext(obj)
{
    var p1 = obj.nextSibling;
    if(p1.tagName.toLowerCase() != "li")
        p1 = obj.nextSibling;;
    p1.parentNode.removeChild(p1);
}

function copyCode(obj)
{
    var s = document.getElementById(obj).value;
    window.clipboardData.setData('text',s);
    alert("已复制到剪切板");
}

function change(str)
{
    document.getElementById("guidechead").value = str + "在线咨询平台：";
    document.getElementById("guideccontent").value = "　　　　朋友，如您有健康问题，请点击<span style=color:red>“接受对话”</span>，在线医生将即时为您提供<span style='color:red'>免费健康</span>咨询服务。"
}
function setDomain(str)
{
    var s = str.toLowerCase();
    s = s.substring(s.indexOf("http://")+7);
    s = s.substring(0,s.indexOf("/"));
    document.getElementById("websitedomain").value = s;
}
function getFullPath(obj) 
{ 
    if(obj) 
    { 
        //ie 
        if (window.navigator.userAgent.indexOf("MSIE")>=1) 
        { 
            obj.select(); 
            return document.selection.createRange().text; 
        } 
        //firefox 
        else if(window.navigator.userAgent.indexOf("Firefox")>=1) 
        { 
            if(obj.files) 
            { 
                return obj.files.item(0).getAsDataURL(); 
            } 
            return obj.value; 
        } 
    return obj.value; 
    } 
}
function textautorow(checkd)
{
    if(checkd.checked)
    {
        $("code").style.overflowX="scroll";
        $("code").wrap="off";
    }
    else
    {
        $("code").style.overflowX="hidden";
        $("code").style.overflow="auto";
        $("code").wrap="soft";
    }
}
function setPreview()
{
    var css = "<style type=\"text/css\">#msgbox div {border:0px;margin:0;padding:0;background:transparent;}#msgbox {width:369px;position:absolute;font-family:宋体;z-index:999;}#msgbox #title {width:369px;height:23px;line-height:23px;background:url(" + $("websiteurl").value + "/images/msgbox/msgbox_title-trans.gif) no-repeat;}#msgbox #title div {padding:0px 0 0 15px;font-size:14px;font-family:黑体;}#msgbox .content {width:369px;height:auto;margin:0 auto;text-align:center;background:url(" + $("websiteurl").value + "/images/msgbox/msgbox_line-trans.gif);}#msgbox .content .content1 {text-align:left;clear:both;width:349px;}#msgbox .content .content1 #bodyer {border:1px #718C91 solid;padding:5px;width:349px;height:100%;background-color:white;font-size:12px;line-height:20px;}#msgbox .content .content1 #bodyer a {text-decoration:none;color:blue;height:25px;line-height:25px;}#msgbox .content .content1 #bodyer a:hover {color:gray;text-decoration:underline;}#msgbox .content .content1 #bodyer ul {list-style:none;margin:0 10px 0 10px;padding:0;line-height:25px;}#msgbox .content .content1 .btns {clear:both;height:24px;text-align:center;font-family:宋体;color:white;}#msgbox .content .content1 .btns input {cursor:pointer;border:0px;margin:0px;padding:0px;width:77px;height:24px;} .button1 {background:url(" + $("websiteurl").value + "/images/a_cn.gif) no-repeat;} .button2 {background:url(" + $("websiteurl").value + "/images/r_cn.gif) no-repeat;} #msgbox .content .clear {height:0px;line-height:0px;clear:both;}#msgbox .bottom {width:369px;height:14px;background:url(" + $("websiteurl").value + "/images/msgbox/msgbox_bottom-trans.gif) no-repeat;}</style>";
    var bodyer = "<div id=msgbox><div id=title><div><span style='font-family:宋体;' id=previewtitle>{$title$}</span></div></div><div class=content><div class=content1><div id=bodyer><span id=previewinfo>{$guideccontent$}</span><br /><span style='color:red;'>就医热点：</span><ul id=previewlist>{$list$}</ul><div class=btns><input id=inputid class=button1 onclick=\"window.open({$link$}','_blank');\" type=button> <input  id=inputid class=button2 onclick=\"$('msgbox').parentNode.removeChild($('msgbox'));\" type=button></div></div></div></div><div class=\"bottom\"></div></div>";
    var title = $("guidechead").value;
    var link = $("guideclink").value;
    var info = $("guideccontent").value;
    var article = new String();
    var guidecnum = parseInt($("guidecnum").value);
    for(var i=1;i<=guidecnum;i++)
    {
        article += "<li style='width:160px;overflow:hidden;float:left;'><a href='" + $("articlelink" + i).value + "' target='_blank' _fcksaveurl=\"" + $("articlelink" + i).value + "\" _fckxhtmljob=\"1\">˙" + $("article" + i).value + "</a></li>";
    }
    bodyer = css + bodyer.replace("{$title$}", title).replace("{$link$}", link).replace("{$guideccontent$}", info).replace("{$list$}", article);
    var oEditor = FCKeditorAPI.GetInstance($("fckid").value);
    oEditor.SetHTML(bodyer);
}

function rjuq()
{
    var oEditor = FCKeditorAPI.GetInstance($("fckid").value);
    var xml = oEditor.EditorDocument.body.innerHTML;
    if(xml.toLowerCase()=="<p></p>")return;
    xml = xml.substring(xml.toLowerCase().indexOf("</style>")+9);
    if(document.getElementById("divs")!=null)
        $("divs").parentNode.removeChild($("divs"));
    var divs = document.createElement("div");
    divs.id = "divs";
    divs.style.display="none";
    divs.innerHTML = xml;
    document.body.appendChild(divs);
    var title = $("previewtitle").innerHTML;
    var info = $("previewinfo").innerHTML;
    var link = $("guideclink").value;
    var list = $("previewlist").innerHTML.toLowerCase();
    $("guidechead").value = title;
    $("guideclink").value = link;
    $("guideccontent").value = info;
    var i = 0;
    var titlen = list.toLowerCase().split("href=");
    while(list.indexOf("href=\"")!=-1)
    {
        list = list.substring(list.indexOf("href=\"")+6);
        $("articlelink" + (i+1)).value = list.substring(0,list.indexOf("\" "));
        list = list.substring(list.indexOf(">")+1);
        $("article" + (i+1)).value = list.substring(1,list.indexOf("</a>"));
        i++;
    }
}

function ExecuteCommand(commandName)
{
    var oEditor = FCKeditorAPI.GetInstance($("fckid").value);
    var con = oEditor.GetXHTML(true);
    con = oEditor.GetXHTML(true);

    oEditor.Commands.GetCommand( commandName ).Execute() ;
}

function selectSite(siteid)
{
    var par = location.search.replace("?","");
    var url = location.href;
    if(par == "")
        location.href = location.href + "?siteid=" + siteid;
    else if(par.indexOf("siteid")==-1)
    {
        url = url + "&siteid=" + siteid;
        location.href = url;
    }
    else
    {
        var param = par.toLowerCase().split("&");
        for(var i=0;i<param.length;i++)
        {
            var sParams = param[i].split("=");
            if(sParams[0]=="siteid")
                url = url.toLowerCase().replace("siteid="+sParams[1],"siteid="+siteid);
            if(sParams[0]=="page")
                url = url.toLowerCase().replace("&page="+sParams[1],"");
        }
        location.href = url;
    }
}

function selectKey()
{
    var siteid = $("siteid").value;
    var group = $("group").value;
    location.href = "index.aspx?siteid=" + siteid + "&group=" + group;
}

function selectKeyGroup()
{
    var siteid = $("siteid").value;
    location.href = "group.aspx?siteid=" + siteid;
}

function selectForum()
{
    location.href = "forum.aspx?isre=" + ($("isre").checked ? "1" : "0") + "&remove=" + ($("remove").checked ? "1" : "0");
}

function dateSearch()
{
    var date1 = document.getElementById("date1").value;
    var date2 = document.getElementById("date2").value;
    var siteid = document.getElementById("siteid").value;
    location.href = "?siteid="+siteid+"&date1="+date1+"&date2="+date2;
}

function changePage(pageNo)
{
    var par = location.search.toLowerCase().replace("?","");
    var url = location.href;
    if (par == "")
        location.href = location.href + "?Page=" + pageNo;
    else if(par.indexOf("page=") == -1)
    {
        location.href = url + "&Page=" + pageNo;
    }
    else
    {
        var param = par.toLowerCase().split("&");
        for(var i=0;i<param.length;i++)
        {
            var sParams = param[i].split("=");
            if(sParams[0]=="page")
                location.href = url.toLowerCase().replace("page="+sParams[1],"Page="+pageNo);
        }
    }
}

function showContext(obj)
{
    var startid = parseInt(document.getElementById("startid").value);
    while(document.getElementById("c" + startid))
    {
        if($(obj)==$("c"+startid))
        {
            if($(obj).style.display == 'none')
                $(obj).style.display = 'block';
            else
                $(obj).style.display = 'none';
        }
        else
            $("c"+startid).style.display = 'none';
        startid ++;
    }
    
}

function repost(s)
{
    $("reposts").style.display = "block";
    $("postid").value = s;
}

function selectGroup() 
{
    var hrefs = "keyadd.aspx?siteid=" + $("siteid").value + "&groupid=" + $("groupid").value;
    if ($("keywords").value.length > 0)
        hrefs += "&keywords=" + $("keywords").value;
    location.href = hrefs;
}
function editGroup() {
    var hrefs = $("urls").value + "&siteid=" + $("siteid").value + "&groupid=" + $("groupid").value;
    if ($("keywords").value.length > 0)
        hrefs += "&keywords=" + $("keywords").value;
    location.href = hrefs;
}
function selectAd(values) {
    if (values == 1)
        $("showpic").style.display = "block";
    else
        $("showpic").style.display = "none";
}
function reviewSwt() {
    var template = parseInt(location.href.substring(location.href.length - 1));
    $("msgbox_titles").innerHTML = $("title").value;
    $("actions").href = $("link").value;
    $("msgbox_text").innerHTML = $("context").value;
    if (template == 1) {
        $("msgbox_prompt").innerHTML = $("prompt").value;
    }
    else {
        $("msgbox_tel1").innerHTML = $("tel1").value;
        $("msgbox_tel2").innerHTML = $("tel2").value;
    }
    if ($("adText1").value.length > 0)
        $("msgbox_hot").innerHTML = "<li>·<a href=\"" + $("adLink1").value + "\" target=\"_blank\">" + $("adText1").value + "</a></li>";
    else
        $("msgbox_hot").innerHTML = "<li>&nbsp;</li>";
    if ($("adText2").value.length > 0)
        $("msgbox_hot").innerHTML += "<li>·<a href=\"" + $("adLink2").value + "\" target=\"_blank\">" + $("adText2").value + "</a></li>";
    else
        $("msgbox_hot").innerHTML += "<li>&nbsp;</li>";
}
function setAdShow(value) {
    $("ad1").style.display = value;
    $("ad2").style.display = value;
    $("ad3").style.display = value;
    $("ad4").style.display = value;
}