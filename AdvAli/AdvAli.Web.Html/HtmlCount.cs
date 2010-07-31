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
    public class HtmlCount : Page
    {
        #region 访问日志
        public static void AnalysisAdd()
        {
            Analysis ana = new Analysis();
            ana.SiteId = Util.GetPageParamsAndToInt("siteid");
            if (ana.SiteId == -100) return;
            ana.Ip = Util.ClientIp();
            string country = Consult.GetCountry(ana.Ip);
            if (string.IsNullOrEmpty(country))
            {
                string path = ((Page)HttpContext.Current.Handler).Server.MapPath("~/data/qqwry.dat");
                ana.Country = Common.QQWry.GetIpLocation(path, Util.ClientIp()).Country;
            }
            else
                ana.Country = country;
            ana.Referrer = Util.GetPageParams("referrer");
            ana.PageUrl = Util.GetPageParams("pageurl");
            ana.PageTitle = Util.GetPageParams("pagetitle");
            ana.UserId = Logic.Consult.GetWebSiteUserId(ana.SiteId);
            ana.GetSiteId = Util.GetPageParamsAndToInt("getsiteid");
            if (ana.SiteId == ana.GetSiteId) return;
            ana.Keyword = Logic.Consult.GetKeywords();
            Consult.AnalysisAdd(ana);
        }
        public static void VisitUpdate(int siteid)
        {
            Consult.VisitUpdate(siteid);
        }
        #endregion
        #region 访问量统计
        public static void VisitAdd(int siteid)
        {
            Visit v = new Visit();
            v.Dates = DateTime.Now;
            v.Consult = 0;
            v.Pv = 1;
            v.SiteId = siteid;
            if (v.SiteId == -100) return;
            Consult.VisitAdd(v);
        }
        #endregion
    }
}
