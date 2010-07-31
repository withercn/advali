using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using AdvAli.Entity;
using AdvAli.Common;
using AdvAli.Logic;
using System.Web;
using System.Web.UI;

namespace AdvAli.Web.Html
{
    public class HtmlWebSite : Page
    {
        #region 获取广告范围
        public static string GetAdRang(string ranglist)
        {
            return Consult.GetAdRang(ranglist);
        }
        public static void WebSiteAdd()
        {
            string website = Common.Util.GetPageParams("txtwebname");
            if (string.IsNullOrEmpty(website))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请输入网站名称</p>");
                return;
            }
            string websiteurl = Common.Util.GetPageParams("txturl");
            if (string.IsNullOrEmpty(websiteurl))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请输入网站地址</p>");
                return;
            }
            websiteurl = websiteurl.ToLower().Replace("http://", "").Replace("/", "");
            if (Consult.ExistsWebSite(websiteurl))
            {
                MsgBox.Alert("WebSiteAdd", "<p>网站地址已经存在</p>");
                return;
            }
            string rangelist = Common.Util.GetPageParams("txtrange");
            if (string.IsNullOrEmpty(rangelist))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请选择网站地域</p>");
                return;
            }
            if (rangelist.Length > 0)
            {
                rangelist = rangelist.Substring(0, rangelist.Length - 1);
                string[] str = rangelist.Split(new char[] { ',' });
                rangelist = "";
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = "$" + str[i] + "$";
                    rangelist += str[i] + ",";
                }
                if (rangelist.Length > 0) rangelist = rangelist.Substring(0, rangelist.Length - 1);
            }
            int adtype = Common.Util.GetPageParamsAndToInt("adtypeselect");
            if (adtype == 0 || adtype == -100)
            {
                MsgBox.Alert("WebSiteAdd", "<p>请选择网站地域</p>");
                return;
            }
            string websitenote = Common.Util.GetPageParams("sitenote");
            string curscript = Common.Util.GetPageParams("curscript");
            if (curscript.Length <= 0)
            {
                MsgBox.Alert("WebSiteAdd", "<p>客户即时通讯代码不能为空!</p>");
                return;
            }
            if (curscript.Trim().Length > 2000)
            {
                MsgBox.Alert("WebSiteAdd", "<p>客户即时通讯代码,请限制在2000个字节内.</p>");
                return;
            }
            string guideccontent = Common.Util.GetPageParams("guideccontent");
            if (guideccontent.Length > 2000)
            {
                MsgBox.Alert("WebSiteAdd", "<p>叙述文字长度,请限制在2000个字节内.</p>");
                return;
            }
            int adid = GetAdvertId(adtype);
            if (adid == 0) return;
            Site site = new Site();
            site.SiteName = website;
            site.SiteUrl = websiteurl;
            site.SiteNote = websitenote;
            site.RangeList = rangelist;
            site.AdDisplay = adtype;
            site.AdId = adid;
            site.SiteDomain = Util.GetDomain("http://" + websiteurl);
            site.UserId = HtmlUser.GetLoggedMemberId();
            site.CurScript = curscript;
            Consult.WebSiteAdd(site);
            MsgBox.Alert("WebSiteAdd", "<p>网站添加成功!</p>", "../website/index.aspx");
        }
        public static int GetAdvertId(int adtype)
        {
            switch (adtype)
            {
                case 1: return HtmlWebSite.GuidecAdd();
                case 2: return HtmlWebSite.QQMsnAdd(true);
                case 3: return HtmlWebSite.QQMsnAdd(false);
                case 4: return HtmlWebSite.ImageAdd();
                default: return 0;
            }
        }
        public static int GuidecAdd()
        {
            int guidecnum = Common.Util.GetPageParamsAndToInt("guidecnum");
            if (guidecnum == -100) return 0;
            string title = Common.Util.GetPageParams("guidechead");
            string link = Common.Util.GetPageParams("guideclink");
            string article = "", articlelink = "";
            string guideccontent = Common.Util.GetPageParams("guideccontent");
            for (int i = 1; i <= guidecnum; i++)
            {
                if (Common.Util.GetPageParams("article" + i.ToString()) == "")
                    article += " |||";
                else
                    article += Common.Util.GetPageParams("article" + i.ToString()) + "|||";
                if (Common.Util.GetPageParams("articlelink" + i.ToString()) == "")
                    articlelink += " |||";
                else
                    articlelink += Common.Util.GetPageParams("articlelink" + i.ToString()) + "|||";
            }
            if (article.Length > 0)
                article = article.Substring(0, article.Length - 3);
            if (articlelink.Length > 0)
                articlelink = articlelink.Substring(0, articlelink.Length - 3);
            Guidec guidec = new Guidec();
            guidec.Title = title;
            guidec.Link = link;
            return Consult.GuidecAdd(guidec);
        }
        public static int QQMsnAdd(bool flag)
        {
            int qqn = Common.Util.GetPageParamsAndToInt("qqn");
            if (qqn == -100) return 0;
            string header = Common.Util.GetPageParams("qqhead");
            string bottom = Common.Util.GetPageParams("qqbottom");
            string account = "", namer = "", notes = "";
            for (int i = 1; i <= qqn; i++)
            {
                account += Common.Util.GetPageParams("qqnum" + i.ToString()) + "|||";
                namer += Common.Util.GetPageParams("qqs" + i.ToString()) + "|||";
                notes += Common.Util.GetPageParams("qqtitle" + i.ToString()) + "|||";
            }
            if (account.Length > 0)
                account = account.Substring(0, account.Length - 3);
            if (namer.Length > 0)
                namer = namer.Substring(0, namer.Length - 3);
            if (notes.Length > 0)
                notes = notes.Substring(0, notes.Length - 3);
            QQMsn qqmsn = new QQMsn();
            qqmsn.Header = header;
            qqmsn.Bottom = bottom;
            qqmsn.IsQQ = flag;
            qqmsn.Account = account;
            qqmsn.Namer = namer;
            qqmsn.Notes = notes;
            return Consult.QQMsnAdd(qqmsn);
        }
        public static int ImageAdd()
        {
            int width = Common.Util.GetPageParamsAndToInt("picwidth");
            int height = Common.Util.GetPageParamsAndToInt("picheight");
            string imagename = Common.Util.GetPageParams("picname");
            string imageurl = "";
            string imagelink = Common.Util.GetPageParams("piclnk");
            HttpFileCollection hfc = HttpContext.Current.Request.Files;
            HttpPostedFile postedFile = hfc["picurl"];
            if (postedFile != null)
            {
                string extFileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("."));
                string[] extName = AdvAli.Config.Global.config.AllowUpload.Split(new char[] { '|' });
                bool hasType = false;
                for (int j = 0; j < extName.Length; j++)
                {
                    if (extName[j].ToLower() == extFileName.Substring(1).ToLower()) hasType = true;
                }
                if (!hasType)
                {
                    MsgBox.Alert("Login", string.Format("<p>上传的文件类型出错,只允许 {0} !</p>", AdvAli.Config.Global.config.AllowUpload));
                    return 0;
                }
                int fileLength = int.Parse((postedFile.ContentLength / 1024).ToString());
                if (fileLength > AdvAli.Config.Global.config.MaxUpload)
                {
                    MsgBox.Alert("Login", string.Format("<p>上传的文件长度出错,只最大只允许 {0} Kbyte!</p>", AdvAli.Config.Global.config.MaxUpload));
                    return 0;
                }
                imageurl = Util.FileUpDb("picurl");
                if (string.IsNullOrEmpty(imageurl))
                {
                    MsgBox.JumpAlert("Login", string.Format("<p>上传的文件类型出错!</p>"));
                    return 0;
                }
            }
            else
            {
                MsgBox.Alert("Login", "<p>请选择文件!</p>");
                return 0;
            }
            Images image = new Images();
            image.Width = width;
            image.Height = height;
            image.ImageName = imagename;
            image.ImageUrl = imageurl;
            image.ImageLink = imagelink;
            return Consult.ImagesAdd(image);
        }
        public static object GetAdvert(int adType, int adId)
        {
            switch (adType)
            {
                case 1: return GetGuidec(adId);
                case 2: return GetQQMsn(adId);
                case 3: return GetQQMsn(adId);
                case 4: return GetImages(adId);
                default: return null;
            }
        }
        public static Guidec GetGuidec(int adId)
        {
            return Consult.GetGuidec(adId);
        }
        public static QQMsn GetQQMsn(int adId)
        {
            return Consult.GetQQMsn(adId);
        }
        public static Images GetImages(int adId)
        {
            return Consult.GetImages(adId);
        }
        public static void WebSiteEdit(int id)
        {
            string website = Common.Util.GetPageParams("txtwebname");
            if (string.IsNullOrEmpty(website))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请输入网站名称</p>");
                return;
            }
            string websiteurl = Common.Util.GetPageParams("txturl");
            if (string.IsNullOrEmpty(websiteurl))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请输入网站地址</p>");
                return;
            }
            websiteurl = websiteurl.ToLower().Replace("http://", "").Replace("/", "");
            string rangelist = Common.Util.GetPageParams("txtrange");
            if (string.IsNullOrEmpty(rangelist))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请选择网站地域</p>");
                return;
            }
            if (rangelist.Length > 0)
                if (rangelist.Substring(rangelist.Length - 1, 1) == ",")
                {
                    rangelist = rangelist.Substring(0, rangelist.Length - 1);
                }
            string[] str = rangelist.Split(new char[] { ',' });
            rangelist = "";
            for (int i = 0; i < str.Length; i++)
            {
                str[i] = "$" + str[i] + "$";
                rangelist += str[i] + ",";
            }
            if (rangelist.Length > 0) rangelist = rangelist.Substring(0, rangelist.Length - 1);
            int adtype = Common.Util.GetPageParamsAndToInt("adtypeselect");
            if (adtype == 0 || adtype == -100)
            {
                MsgBox.Alert("WebSiteAdd", "<p>请选择网站地域</p>");
                return;
            }
            string websitenote = Common.Util.GetPageParams("sitenote");
            Site site = Consult.GetWebSite(id);
            if (adtype == site.AdDisplay)
            {
                EditAdvertId(adtype, site.AdId);
            }
            else
            {
                Consult.RemoveAdvert(site.AdDisplay, site.AdId);
                site.AdId = GetAdvertId(adtype);
            }
            string curscript = Common.Util.GetPageParams("curscript");
            if (curscript.Length <= 0)
            {
                MsgBox.Alert("WebSiteAdd", "<p>客户即时通讯代码不能为空!</p>");
                return;
            }
            if (curscript.Length > 2000)
            {
                MsgBox.Alert("WebSiteAdd", "<p>客户即时通讯代码,请限制在2000个字节内.</p>");
                return;
            }
            site.SiteName = website;
            site.SiteUrl = websiteurl;
            site.SiteNote = websitenote;
            site.RangeList = rangelist;
            site.AdDisplay = adtype;
            site.SiteDomain = Util.GetDomain("http://" + websiteurl);
            site.CurScript = curscript;
            Consult.WebSiteEdit(site);
            MsgBox.Alert("WebSiteEdit", "<p>网站修改成功!</p>", "../website/index.aspx");
        }
        public static void EditAdvertId(int adtype,int id)
        {
            switch (adtype)
            {
                case 1:
                    HtmlWebSite.GuidecEdit(id);
                    break;
                case 2:
                    HtmlWebSite.QQMsnEdit(id, true);
                    break;
                case 3:
                    HtmlWebSite.QQMsnEdit(id, false);
                    break;
                case 4:
                    HtmlWebSite.ImageEdit(id);
                    break;
            }
        }
        public static void GuidecEdit(int id)
        {
            int guidecnum = Common.Util.GetPageParamsAndToInt("guidecnum");
            if (guidecnum == -100)
            {
                MsgBox.Alert("WebSiteAdd", "<p>商务通错误</p>");
                return;
            }
            string title = Common.Util.GetPageParams("guidechead");
            string link = Common.Util.GetPageParams("guideclink");
            string article = "", articlelink = "";
            for (int i = 1; i <= guidecnum; i++)
            {
                if (Common.Util.GetPageParams("article" + i.ToString()) == "")
                    article += " |||";
                else
                    article += Common.Util.GetPageParams("article" + i.ToString()) + "|||";
                if (Common.Util.GetPageParams("articlelink" + i.ToString()) == "")
                    articlelink += " |||";
                else
                    articlelink += Common.Util.GetPageParams("articlelink" + i.ToString()) + "|||";
            }
            if (article.Length > 0)
                article = article.Substring(0, article.Length - 3);
            if (articlelink.Length > 0)
                articlelink = articlelink.Substring(0, articlelink.Length - 3);
            string guideccontent = Common.Util.GetPageParams("guideccontent");
            Guidec guidec = new Guidec();
            guidec.Id = id;
            guidec.Title = title;
            guidec.Link = link;

            Consult.GuidecEdit(guidec);
        }
        public static void QQMsnEdit(int id, bool flag)
        {
            int qqn = Common.Util.GetPageParamsAndToInt("qqn");
            if (qqn == -100)
            {
                MsgBox.Alert("WebSiteAdd", "<p>QQ/Msn错误</p>");
                return;
            }
            string header = Common.Util.GetPageParams("qqhead");
            string bottom = Common.Util.GetPageParams("qqbottom");
            string account = "", namer = "", notes = "";
            for (int i = 1; i <= qqn; i++)
            {
                account += Common.Util.GetPageParams("qqnum" + i.ToString()) + "|||";
                namer += Common.Util.GetPageParams("qqs" + i.ToString()) + "|||";
                notes += Common.Util.GetPageParams("qqtitle" + i.ToString()) + "|||";
            }
            if (account.Length > 0)
                account = account.Substring(0, account.Length - 3);
            if (namer.Length > 0)
                namer = namer.Substring(0, namer.Length - 3);
            if (notes.Length > 0)
                notes = notes.Substring(0, notes.Length - 3);
            QQMsn qqmsn = new QQMsn();
            qqmsn.Header = header;
            qqmsn.Bottom = bottom;
            qqmsn.IsQQ = flag;
            qqmsn.Account = account;
            qqmsn.Namer = namer;
            qqmsn.Notes = notes;
            Consult.QQMsnEdit(qqmsn);
        }
        public static void ImageEdit(int id)
        {
            int width = Common.Util.GetPageParamsAndToInt("picwidth");
            int height = Common.Util.GetPageParamsAndToInt("picheight");
            string imagename = Common.Util.GetPageParams("picname");
            string imageurl = Common.Util.GetPageParams("pice");
            string imagelink = Common.Util.GetPageParams("piclnk");
            HttpFileCollection hfc = HttpContext.Current.Request.Files;
            HttpPostedFile postedFile = hfc["picurl"];
            if (postedFile != null)
            {
                if (postedFile.ContentLength > 0)
                {
                    string extFileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("."));
                    string[] extName = AdvAli.Config.Global.config.AllowUpload.Split(new char[] { '|' });
                    bool hasType = false;
                    for (int j = 0; j < extName.Length; j++)
                    {
                        if (extName[j].ToLower() == extFileName.Substring(1).ToLower()) hasType = true;
                    }
                    if (!hasType)
                    {
                        MsgBox.Alert("Login", string.Format("<p>上传的文件类型出错,只允许 {0} !</p>", AdvAli.Config.Global.config.AllowUpload));
                        return;
                    }
                    int fileLength = int.Parse((postedFile.ContentLength / 1024).ToString());
                    if (fileLength > AdvAli.Config.Global.config.MaxUpload)
                    {
                        MsgBox.Alert("Login", string.Format("<p>上传的文件长度出错,只最大只允许 {0} Kbyte!</p>", AdvAli.Config.Global.config.MaxUpload));
                        return;
                    }
                    imageurl = Util.FileUpDb("picurl");
                }
            }
            Images image = new Images();
            image.Id = id;
            image.Width = width;
            image.Height = height;
            image.ImageName = imagename;
            image.ImageUrl = imageurl;
            image.ImageLink = imagelink;
            Consult.ImageEdit(image);
        }
        public static string GetScripts(int siteid)
        {
            return Consult.GetScripts(siteid);
        }
        public static void SaveStep1(int siteid)
        {
            string website = Common.Util.GetPageParams("txtwebname");
            if (string.IsNullOrEmpty(website))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请输入网站名称</p>");
                return;
            }
            string websiteurl = Common.Util.GetPageParams("txturl");
            if (string.IsNullOrEmpty(websiteurl))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请输入网站地址</p>");
                return;
            }
            websiteurl = websiteurl.ToLower().Replace("http://", "").Replace("/", "");
            if (Consult.ExistsWebSite(websiteurl))
            {
                MsgBox.Alert("WebSiteAdd", "<p>网站地址已经存在</p>");
                return;
            }
            string websitenote = Common.Util.GetPageParams("sitenote");
            string curscript = Common.Util.GetPageParams("curscript");
            if (curscript.Length <= 0)
            {
                MsgBox.Alert("WebSiteAdd", "<p>客户即时通讯代码不能为空!</p>");
                return;
            }
            if (curscript.Trim().Length > 2000)
            {
                MsgBox.Alert("WebSiteAdd", "<p>客户即时通讯代码,请限制在2000个字节内.</p>");
                return;
            }
            Site site;
            if (siteid > 0)
                site = Logic.Consult.GetWebSite(siteid);
            else
                site = new Site();
            site.SiteName = website;
            site.SiteUrl = websiteurl;
            site.SiteNote = websitenote;
            site.SiteDomain = Util.GetDomain("http://" + websiteurl);
            site.UserId = HtmlUser.GetLoggedMemberId();
            site.CurScript = curscript;
            int id = Logic.Consult.SaveStep1(siteid, site);
            if (id > 0)
            {
                HttpContext.Current.Response.Redirect(string.Format("../website/sitestep2.aspx?id={0}", id), true);
                return;
            }
            else
            {
                MsgBox.Alert("Save1", "<p>数据保存失败！请检查之后重新保存。</p>");
                return;
            }
        }
        public static void SaveStep2(int siteid)
        {
            string rangelist = Common.Util.GetPageParams("txtrange");
            if (string.IsNullOrEmpty(rangelist))
            {
                MsgBox.Alert("WebSiteAdd", "<p>请选择网站地域</p>");
                return;
            }
            if (rangelist.Length > 0)
            {
                rangelist = rangelist.Substring(0, rangelist.Length - 1);
                string[] str = rangelist.Split(new char[] { ',' });
                rangelist = "";
                for (int i = 0; i < str.Length; i++)
                {
                    str[i] = "$" + str[i] + "$";
                    rangelist += str[i] + ",";
                }
                if (rangelist.Length > 0) rangelist = rangelist.Substring(0, rangelist.Length - 1);
            }
            Site site = Logic.Consult.GetWebSite(siteid);
            site.RangeList = rangelist;
            Logic.Consult.SaveStep2(siteid, site);
            HttpContext.Current.Response.Redirect(string.Format("../website/sitestep3.aspx?id={0}", siteid), true);
        }
        public static void SaveStep3(int siteid)
        {
            int adtype = Common.Util.GetPageParamsAndToInt("adTypeSelect");
            if (adtype == 0 || adtype == -100)
            {
                MsgBox.Alert("WebSiteAdd", "<p>请选择广告显示类型!</p>");
                return;
            }
            int templates = Common.Util.GetPageParamsAndToInt("templates");
            Site site = Logic.Consult.GetWebSite(siteid);
            site.AdDisplay = adtype;
            site.Templates = templates;
            Logic.Consult.SaveStep3(siteid, site);
            HttpContext.Current.Response.Redirect(string.Format("../website/sitestep4_{1}.aspx?id={0}&t={2}", siteid, adtype, templates), true);
        }
        public static void SaveStep41(int siteid)
        {
            Site site = Logic.Consult.GetWebSite(siteid);
            string title = Common.Util.GetPageParams("title");
            string link = Common.Util.GetPageParams("link");
            string context = Common.Util.GetPageParams("context");
            int wordlnk = Common.Util.GetPageParamsAndToInt("wordlnk");
            string adtext1 = Common.Util.GetPageParams("adtext1");
            string adtext2 = Common.Util.GetPageParams("adtext2");
            string adlink1 = Common.Util.GetPageParams("adlink1");
            string adlink2 = Common.Util.GetPageParams("adlink2");
            Guidec guidec;
            if (site.AdId > 0)
                guidec = Logic.Consult.GetGuidec(site.AdId);
            else
                guidec = new Guidec();
            guidec.Title = title;
            guidec.Link = link;
            guidec.Context = context;
            guidec.WordLnk = wordlnk;
            guidec.AdText1 = adtext1;
            guidec.AdLink1 = adlink1;
            guidec.AdText2 = adtext2;
            guidec.AdLink2 = adlink2;
            int results = Logic.Consult.SaveStep41(siteid, site, guidec);
            if (results > 0)
                MsgBox.Alert("Alert", "<p>网站加盟成功!</p>", "../website/GetScript.aspx?siteid=" + siteid.ToString());
            else
                MsgBox.Alert("网站加盟失败!");
        }
        #endregion
    }
}
