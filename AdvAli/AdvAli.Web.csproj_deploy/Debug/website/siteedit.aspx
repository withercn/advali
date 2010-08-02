<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="siteedit.aspx.cs" Inherits="AdvAli.Web.website.siteedit" %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link rel="Stylesheet" href="../css/main.css" />
    <script type="text/javascript" src="../script/main.js"></script>
    <script type="text/javascript" src="../script/msgbox.js"></script>
</head>
<body>
    <form id="form1" enctype="multipart/form-data" runat="server">
    <div class="start">
        <div id="Div1" class="navigation" runat="server"><%=Navigations%></div>
        <div class="content">
            <div id="Div2" class="count" runat="server">修改网站</div>
            <ul class="logins" style="float:left;width:300px;">
                <li class="h30">网站名称 / WebSite Name：</li>
                <li class="inputs"><input id="txtwebname" onchange="change(this.value);" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">网站地址 / Url：(不需要http:// 例:www.sz16.cn)</li>
                <li class="inputs"><input id="txtUrl" runat="server" type="text" class="loginInput" /></li>
                <li class="h30">网站介绍 / Site Introduction：</li>
                <li class="registerContentLiTextarea"><textarea class="registerContentTextarea" name="sitenote" id="sitenote" runat="server"></textarea></li>
                <li class="h30">客户即时通讯代码 / Client Code</li>
                <li class="registerContentLiTextarea" style="height:160px;"><textarea class="registerContentTextarea" style="height:150px;" name="curscript" id="curscript" runat="server"></textarea></li>
                <li class="h30"> <span style="color:Blue;">注：</span><span style="color:Red">当流量为加盟网站自身需要的资源则系统自动调用此代码。</span></li>
            </ul>
            
            <div id="nones" style="float:left;">
                <ul class="logins" id="cons">
                    <li class="h30">网站地域 (网站所对应的地区)：<input type="button" value="请选择" name="button" class="button" onclick="openSelect(1);" /></li>
                    <li>
                        <div id="result">
                            <div class="cont" id="makeSureItem" runat="server"></div>
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
                                <div class="cont" runat="server" id="previewItem"></div>
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
                <ul id="guidec" class="logins" style="display:none;margin:0;">
                    <li class="h30">标题：</li>
                    <li class="inputs"><input type="text" id="guidechead" name="guidechead" runat="server" class="loginInput" /></li>
                    <li class="h30">商务通链接地址：</li>
                    <li class="inputs"><input type="text" id="guideclink" name="guideclink" runat="server" class="loginInput" /></li>
                    <input type="hidden" id="guideccontent" name="guideccontent" runat="server" />
                    <%=GuidecHtml%>
                    <li class="h30"><input type="hidden" id="guidecnum" runat="server" name="guidecnum" value="1" /><input type="button" class="button" id="Button1" value="添加数据" onclick="AddGuidec(this.parentNode)" /> <input type="button" class="button" id="guidecadd" value="载入数据" onclick="setPreview()" /> <input type="button" class="button" onclick="rjuq()" value="保存数据" /> <input type="button" class="button" value="预览效果" onclick="ExecuteCommand('Preview');" /></li>
                    <li><FCKeditorV2:FCKeditor ID="fckeditor" Width="380px" Height="350px" runat="server" EnableXHTML="true" EnableSourceXHTML="true" ToolbarSet="Cursor"></FCKeditorV2:FCKeditor>
                    <input type="hidden" id="fckid" value="<%=fckeditor.ClientID%>" />
                    <input type="hidden" id="websiteurl" value="<%=AdvAli.Config.Global.__WebSiteUrl%>" /></li>
                </ul>
                <ul id="qq" class="logins" style="display:none;margin:0;">
                    <li class="h30" id="t1" runat="server">QQ头部信息：</li>
                    <li class="inputs"><input id="qqhead" name="qqhead" runat="server" type="text" class="loginInput" /></li>
                    <li class="h30" id="t2" runat="server">QQ底部信息：</li>
                    <li class="inputs"><input id="qqbottom" name="qqbottom" runat="server" type="text" class="loginInput" /></li>
                    <%=QQMsnHtml%>
                    <li class="h30"><input type="hidden" id="isqq" runat="server" value="1" /><input type="hidden" id="qqn" name="qqn" runat="server" value="1" /><input id="qqadd" type="button" class="button" value="添加QQ号" onclick="AddQQ(this.parentNode)" /> <input type="button" class="button" id="qqremove" onclick="deleteQQMsn(this)" value="删除QQ" /> <input type="button" class="button" value="预览效果" onclick="window.open(previewQQ())" /></li>
                </ul>
                <ul id="pic" class="logins" style="display:none;margin:0;">
                    <li class="h30">图片宽度：</li>
                    <li class="inputs"><input type="text" runat="server" id="picwidth" value="250" name="picwidth" class="loginInput" /></li>
                    <li class="h30">图片高度：</li>
                    <li class="inputs"><input type="text" runat="server" id="picheight" value="200" name="picheight" class="loginInput" /></li>
                    <%=ImagesHtml%>
                    <li class="h30"><input type="button" class="button" value="预览效果" onclick="window.open(previewPicture());" /></li>
                </ul>
            </div>
            <div style="clear:both;text-align:center;"><input id="Submit1" type="submit" class="button" runat="server" value="修　　改" onserverclick="WebSiteEdit_Click" /> <input type="button" value="返　　回" onclick="history.go(-1);" class="button" /></div>
        </div>
    </div>
    </form>
</body>
</html>
