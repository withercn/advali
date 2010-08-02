using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;
using AdvAli.Keys;
using MSXML2;
using System.Text;
using System.Net;
using Microsoft.JScript;

namespace AdvAli.Web.script
{
    public partial class SetAd : Page
    {
        protected Logic.CitySelect citySelect = AdvAli.Logic.CitySelect.IPCity;
        /// <summary>
        /// IP所属地域
        /// </summary>
        protected string ipCountry = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            //this.BindData();
            try
            {
                this.BindData();
            }
            catch (Exception ex)
            {
                Log.LogManager.WriteLog(LogFile.Error, string.Format("\r\n错误信息：{0}\r\n远程IP：{1}\r\n错误链接：{2}\r\n{3}\r\n", ex.Message, Request.UserHostAddress, HttpContext.Current.Request.Url.ToString(), ex.ToString()));
            }
        }
        /// <summary>
        /// 根据IP判断是否所属网站对话
        /// 无法识别的IP只显示所属网站对话
        /// </summary>
        protected void IpSearchLocal()
        {
            string clientIp = Common.Util.ClientIp();
            ipCountry = Common.QQWry.GetIpLocation(Server.MapPath("~/data/qqwry.dat"), clientIp).Country;
            int sPos = ipCountry.IndexOf("省");
            int cPos = ipCountry.IndexOf("市");
            int dPos = ipCountry.Length;
            if (dPos > 0)
            {
                try
                {
                    if (ipCountry.IndexOf("市") == -1)
                        ipCountry = ipCountry.Substring(sPos + 1);
                    else
                    {
                        ipCountry = ipCountry.Substring(sPos + 1, cPos - sPos);
                    }
                    ipCountry = ipCountry.Replace("市", "");
                }
                catch {}
            }
        }

        protected void BindData()
        {
            int hasSearch = 0;
            string key = string.Empty;
            int siteid = Common.Util.GetPageParamsAndToInt("siteid");//受访网站编号
            if (siteid == -100) return;
            AdvAli.Entity.City city = KeyManage.GetCityFormsSearchEngines(out hasSearch, out key);//获取搜索引擎来的地域名.
            //AdvAli.Entity.City city = Logic.Consult.GetCityFormsSearchEngines(out hasSearch); //获取搜索引擎来的地域名.
            string ranglist = Logic.Consult.GetWebSiteCountryId(siteid);//受访网站的地域列表
            this.IpSearchLocal();//分析IP数据
            int cityId = Logic.Consult.GetCityId(ipCountry);//客户所在的地域编号
            HtmlCount.VisitAdd(siteid); //记数器
            if (Common.Util.HasString(ranglist, cityId.ToString(), new char[] { ',' })) //判断客户所在的地域是否在受访网站选择的地域中.
            {
                citySelect = AdvAli.Logic.CitySelect.LocalDomainCity;
                Response.Clear();
                Response.Write("");
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                return;
            }
            else if (hasSearch == 2) //判断客户是否通过搜索引擎进来,并且搜索引擎是否包含地域的关键字
            {
                cityId = city.Id; //直接将地域转为搜索引擎包含的地域
                citySelect = AdvAli.Logic.CitySelect.SearchEngineCity;
            }
            else if (hasSearch == 1) //通过搜索引擎，但不包括地域关键字
            {
                //if (AdvAli.Keys.KeyManage.GetKeySite(key, cityId.ToString()))
                //    citySelect = AdvAli.Logic.CitySelect.SearchEngineKeyword;
                //else
                //    citySelect = AdvAli.Logic.CitySelect.LocalDomainCity;
                citySelect = AdvAli.Logic.CitySelect.SearchEngineKeyword;
            }
            else if (!Logic.Consult.CheckAllWebSiteCity(cityId)) //判断是否有网站选择了该地域,如果没有则转给受访网站
            {
                citySelect = AdvAli.Logic.CitySelect.LocalDomainCity;
                Response.Clear();
                Response.Write("");
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                return;
            }
            else //客户不在受访网站选择的地域,转给相关地域进行处理.
            {
                citySelect = AdvAli.Logic.CitySelect.IPCity;
            }


            int adType = 0;
            int adId = 0;
            string urls = "";
            object obj;
            if (citySelect == AdvAli.Logic.CitySelect.LocalDomainCity) //只显示受访网站的对话
            {
                AdvAli.Entity.Site site = Logic.Consult.GetWebSite(siteid);
                obj = HtmlWebSite.GetAdvert(site.AdDisplay, site.AdId);
                adType = site.AdDisplay;
                adId = site.AdId;
            }
            else if (citySelect == AdvAli.Logic.CitySelect.SearchEngineKeyword) //轮换显示搜索引擎关键词及地域所在网站的对话
            {
                siteid = Logic.Consult.GetAdKeyWebSiteId(key, cityId, out adType, out adId);
                AdvAli.Entity.Site site = Logic.Consult.GetWebSite(siteid);
                if (object.Equals(site, null)) //没有该地域没有任何对话,显示受访网站对话
                {
                    siteid = Logic.Consult.GetAdWebSiteId(cityId, out adType, out adId);
                    site = Logic.Consult.GetWebSite(siteid);
                    if (object.Equals(site, null)) //没有该地域没有任何对话,显示受访网站对话
                    {
                        site = Logic.Consult.GetWebSite(Common.Util.GetPageParamsAndToInt("siteid"));
                        siteid = site.Id;
                    }
                }
                adType = site.AdDisplay;
                adId = site.AdId;
                obj = HtmlWebSite.GetAdvert(adType, adId);
            }
            else if (cityId > 0) //根据客户地域,轮换显示不同网站对话 || 轮换显示搜索引擎包含地域所在的网站的对话
            {
                siteid = Logic.Consult.GetAdWebSiteId(cityId, out adType, out adId);
                AdvAli.Entity.Site site = Logic.Consult.GetWebSite(siteid);
                if (object.Equals(site, null)) //没有该地域没有任何对话,显示受访网站对话
                {
                    site = Logic.Consult.GetWebSite(Common.Util.GetPageParamsAndToInt("siteid"));
                    siteid = site.Id;
                }
                adType = site.AdDisplay;
                adId = site.AdId;
                obj = HtmlWebSite.GetAdvert(adType, adId);
            }
            string scripts = "";
            //adType==0或adId==0即不正常的访问,
            if (adType == 0 || adId == 0)
                return;
            if (adType == 1)
            {
                /*Guidec g = (Guidec)HtmlWebSite.GetAdvert(adType, adId);
                string baseUrl = Config.Global.__WebSiteUrl + "website/previewGuidec.aspx?";
                urls += "guidechead=" + GlobalObject.escape(g.Title);
                urls += "&guideclink=" + GlobalObject.escape(g.Link);
                urls = baseUrl + urls;*/
                urls = Config.Global.__WebSiteUrl + "website/getguidec.aspx?1=1";
            }
            if (adType == 2 || adType == 3)
            {
                QQMsn q = (QQMsn)HtmlWebSite.GetAdvert(adType, adId);
                string baseUrl = Config.Global.__WebSiteUrl + "website/previewQQ.aspx?";
                urls += "&isqq=" + (q.IsQQ ? "1" : "0");
                urls += "&qqhead=" + q.Header;
                urls += "&qqbottom=" + q.Bottom;
                string[] qqnum = q.Account.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                string[] qqs = q.Notes.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                string[] qqtitle = q.Namer.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < qqnum.Length; i++)
                {
                    urls += string.Format("&qqnum{0}={1}", i, qqnum[i]);
                    urls += string.Format("&qqs{0}={1}", i, qqs[i]);
                    urls += string.Format("&qqtitle{0}={1}", i, qqtitle[i]);
                }
                urls += "&qqn=" + qqnum.Length.ToString();
                urls = baseUrl + urls;
            }
            if (adType == 4)
            {
                string baseUrl = Config.Global.__WebSiteUrl + "website/previewPicture.aspx?";
                Images i = (Images)HtmlWebSite.GetAdvert(adType, adId);
                urls += "&width=" + i.Width.ToString() + "&height=" + i.Height.ToString();
                urls += "&picname=" + GlobalObject.escape(i.ImageName);
                urls += "&picurl=" + GlobalObject.escape(i.ImageUrl);
                urls += "&piclnk=" + GlobalObject.escape(i.ImageLink);
                urls = baseUrl + urls;
            }
            if (adType == 5) //本地资源,默认访问
            {
                scripts = Logic.Consult.GetScripts(Common.Util.GetPageParamsAndToInt("siteid"));
            }
            else
            {
                WebClient webclient = new WebClient();
                byte[] bytes = webclient.DownloadData(urls + "&isscript=1&siteid=" + Common.Util.GetPageParamsAndToInt("siteid") + "&getsiteid=" + siteid);
                webclient.Dispose();
                scripts = Encoding.UTF8.GetString(bytes);
            }
            Response.Clear();
            Response.Write("var islocal=true;" + scripts);
            HttpContext.Current.ApplicationInstance.CompleteRequest();
        }
    }
}
