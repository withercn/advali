<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="siteadd.aspx.cs" Inherits="AdvAli.Web.website.siteadd" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="../css/main.css" />
    <script type="text/javascript" src="../script/main.js"></script>
    <script type="text/javascript" src="../script/msgbox.js"></script>

</head>
<body>
    <form id="form1" enctype="multipart/form-data" runat="server">
    <div class="start">
        <div class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div class="count" runat="server">添加网站</div>
            <ul class="logins" style="float:left;width:300px;">
                <li class="h30">网站名称 / WebSite Name：</li>
                <li class="inputs"><input id="txtwebname" onchange="change(this.value);" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">网站地址 / Url：(不需要http:// 例:www.sz16.cn)</li>
                <li class="inputs"><input id="txtUrl" runat="server" type="text" class="loginInput" /></li>
                
                <li class="h30">网站介绍 / Site Introduction：</li>
                <li class="registerContentLiTextarea"><textarea class="registerContentTextarea" name="sitenote"></textarea></li>
                <li class="h30">客户即时通讯代码 / Client Code</li>
                <li class="registerContentLiTextarea" style="height:160px;"><textarea class="registerContentTextarea" style="height:150px;" name="curscript"></textarea></li>
                <li class="h30"> <span style="color:Blue;">注：</span><span style="color:Red">当流量为加盟网站自身需要的资源则系统自动调用此代码。</span></li>
            </ul>
            
            <div id="nones" style="float:left;">
                <ul id="cons" class="logins">
                    <li class="h30">网站地域 (网站所对应的地区)：<input type="button" value="请选择" name="button" class="button" onclick="openSelect(1);" /></li>
                    <li>
                        <div id="result">
                            <div class="cont" id="makeSureItem"></div>
                        </div>
                        <div class="hidden" id="selectItem">
                            <div class="tit bgc_ccc">
                                <h2 class="left">请选择城市</h2>
                                <span class="pointer right" onclick="openSelect(0);">[取消]</span>
                                <span class="pointer right" onclick="makeSure();">[确定]</span>
                            </div>
                            <div class="cls"></div>
                            <div class="cont">
                                <div id="selectSub" runat="server">
                                </div>
                            </div>
                            <div id="preview">
                                <div class="tit bgc_eee c_999">
                                    <h2>您已选择的城市</h2>
                                </div>
                                <div class="cont" id="previewItem"></div>
                            </div>
                        </div>
                        <script type="text/javascript" src="../script/SelectRangeList.js">
                        </script><input id="txtRange" runat="server" type="hidden" />
                    </li>
                    <li class="h30">广告类型 / AD Type：</li>
                    <li>
                        <select id="adTypeSelect" onchange="attack(this.value);" runat="server"></select>
                        <div id="AdType"></div>
                    </li>
                </ul>
                <ul id="guidec" class="logins" style="display:none;">
                    <li class="h30">标题：</li>
                    <li class="inputs"><input type="text" id="guidechead" name="guidechead" class="loginInput" /></li>
                    <li class="h30">商务通链接地址：</li>
                    <input type="hidden" id="guideccontent" name="guideccontent" />
                    <li class="inputs"><input type="text" id="guideclink" name="guideclink" class="loginInput" /></li>
                    <li class="h30 left">广告文字1：</li>
                    <li class="inputs left"><input type="text" id="article1" name="article1" class="loginInput" /></li>
                    <li style="clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;">&nbsp;</li>
                    <li class="h30 left">广告链接1：</li>
                    <li class="inputs left"><input type="text" id="articlelink1" name="articlelink1" class="loginInput" /></li>
                    <li style="clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;">&nbsp;</li>
                    <li class="h30"><input type="hidden" id="guidecnum" name="guidecnum" value="1" /><input type="button" class="button" id="guidecadd" value="添加数据" onclick="AddGuidec(this.parentNode)" /> <input type="button" class="button" value="载入数据" onclick="setPreview()" /> <input type="button" class="button" onclick="rjuq()" value="保存数据" /> <input type="button" class="button" value="预览效果" onclick="window.open(previewGuidec());" /></li>
                    <li><FCKeditorV2:FCKeditor ID="fckeditor" Width="380px" Height="350px" runat="server" EnableXHTML="true" EnableSourceXHTML="true" ToolbarSet="Cursor"></FCKeditorV2:FCKeditor>
                    <input type="hidden" id="fckid" value="<%=fckeditor.ClientID%>" />
                    <input type="hidden" id="websiteurl" value="<%=AdvAli.Config.Global.__WebSiteUrl%>" /></li>
                </ul>
                <ul id="qq" class="logins" style="display:none;">
                    <li class="h30">QQ头部信息：</li>
                    <li class="inputs"><input id="qqhead" name="qqhead" type="text" class="loginInput" /></li>
                    <li class="h30">QQ底部信息：</li>
                    <li class="inputs"><input id="qqbottom" name="qqbottom" type="text" class="loginInput" /></li>
                    <li class="left">QQ号码1：</li>
                    <li class="inputf left"><input id="qqnum1" name="qqnum1" type="text" class="loginInput" /></li>
                    <li class="left">QQ名称1：</li>
                    <li class="inputf left"><input id="qqs1" name="qqs1" type="text" class="loginInput" /></li>
                    <li style="clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;">&nbsp;</li>
                    <li class="left">QQ说明1：</li>
                    <li class="inputs left"><input id="qqtitle1" name="qqtitle1" type="text" class="loginInput" /></li>
                    <li style="clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;">&nbsp;</li>
                    <li class="h30"><input type="hidden" id="isqq" value="1" /><input type="hidden" id="qqn" name="qqn" value="1" /><input id="qqadd" type="button" class="button" value="添加QQ号" onclick="AddQQ(this.parentNode)" /> <input type="button" class="button" value="预览效果" onclick="window.open(previewQQ())" /></li>
                </ul>
                <ul id="pic" class="logins" style="display:none;">
                    <li class="h30">图片宽度：</li>
                    <li class="inputs"><input type="text" id="picwidth" value="250" name="picwidth" class="loginInput" /></li>
                    <li class="h30">图片高度：</li>
                    <li class="inputs"><input type="text" id="picheight" value="200" name="picheight" class="loginInput" /></li>
                    <li class="h30">图片名称：</li>
                    <li class="inputs"><input type="text" id="picname" name="picname" class="loginInput" /></li>
                    <li class="h30">图片地址：</li>
                    <li class="h30"><input type="file" id="picurl" name="picurl" class="loginInput" /></li>
                    <li class="h30">图片链接：</li>
                    <li class="inputs"><input type="text" id="piclnk" name="piclnk" class="loginInput" /></li>
                    <li class="h30"><input type="button" class="button" value="预览效果" onclick="window.open(previewPicture());" /></li>
                </ul>
            </div>
            <div style="clear:both;text-align:center;"><input id="Submit1" type="submit" class="button" runat="server" value="添　　加" onserverclick="WebSiteAdd_Click" /> <input type="button" value="返　　回" onclick="history.go(-1);" class="button" /></div>
        </div>
    </div>
    </form>
</body>
</html>
