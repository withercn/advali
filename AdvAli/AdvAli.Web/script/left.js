function checksubover(obj)
{
    obj.childNodes.item(1).style.display="block";
}

function checksubout(obj)
{
    obj.childNodes.item(1).style.display="none";
}

function hidesub(obj)
{
    var objs = obj.parentNode.nextSibling;
    if(objs.tagName != "UL")
        objs = obj.parentNode.nextSibling.nextSibling;
    if(objs.style.display == '' || objs.style.display == 'block')
    {
        objs.style.display = 'none';
    }
    else
    {
        objs.style.display = 'block';
    }
}

function showhide(objs,thisobj)
{
    var obj = document.getElementById(objs);
    if(obj.style.display == '' || obj.style.display == 'block')
    {
        obj.style.display = 'none';
        document.getElementById("bottom").style.display = 'none';
        thisobj.src = '../images/hide_right-trans.gif';
        top.document.getElementById("frame").cols="42,*";
    }
    else
    {
        obj.style.display = 'block';
        document.getElementById("bottom").style.display = 'block';
        thisobj.src = '../images/hide_left-trans.gif';
        top.document.getElementById("frame").cols="182,*";
    }
}

function hide(obj)
{
    var curObj = obj.parentNode.nextSibling;
    if(curObj.style.display == 'none')
    {
        curObj.style.display = 'block';
        obj.src = "../images/dir_2.gif";
    }
    else
    {
        curObj.style.display = 'none';
        obj.src = "../images/dir_1.gif";
    }
}