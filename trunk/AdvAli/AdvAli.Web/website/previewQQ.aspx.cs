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

namespace AdvAli.Web.website
{
    public partial class previewQQ : Page
    {
        public string userinfo = "";
        public string adinfo = "";
        public string qqlist = "";
        public string WebSiteUrl = "";
        public bool IsScript = false;
        public bool IsQQ = true;
        public string LinkUrl = "";
        public string siteId = "0";
        public string getSiteId = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void BindData()
        {
            getSiteId = Common.Util.GetPageParams("getsiteid");
            siteId = Common.Util.GetPageParams("siteId");
            IsScript = Common.Util.GetPageParamsAndToInt("IsScript") == 1 ? true : false;
            IsQQ = Common.Util.GetPageParamsAndToInt("IsQQ") == 1 ? true : false;
            if (IsQQ)
                LinkUrl = "tencent://message/?uin=";
            else
                LinkUrl = "msnim:chat?contact=";
            WebSiteUrl = Config.Global.__WebSiteUrl;
            int qqn = Common.Util.GetPageParamsAndToInt("qqn");
            if (qqn == -100) return;
            long qqNumber = 0;
            userinfo = Common.Util.GetPageParams("qqhead").Replace("\"", "\\\"");
            adinfo = Common.Util.GetPageParams("qqbottom").Replace("\"", "\\\"");
            for (int i = 0; i < qqn; i++)
            {
                string qqnum = Common.Util.GetPageParams("qqnum" + i.ToString());
                string qqs = Common.Util.GetPageParams("qqs" + i.ToString());
                string qqtitle = Common.Util.GetPageParams("qqtitle" + i.ToString());
                if (qqnum.Trim().Length > 0 || qqs.Trim().Length > 0 || qqtitle.Trim().Length > 0)
                {
                    int qqState = -1;
                    long.TryParse(qqnum, out qqNumber);
                    if (IsQQ)
                        qqState = Common.Util.GetQQState(qqNumber);
                    else
                        qqState = Common.Util.GetMsnState(qqnum);
                    string qqImg = WebSiteUrl + "/images/QQ/QQ";
                    if (qqState != 1)
                        qqImg += "_Offline";
                    qqImg += ".png";
                    qqlist += "<li class=\"mover\"><div class=\"m1\"><img alt=\"{$QQnum$}\" src=\"" + qqImg + "\" /></div><div class=\"m2\"><span class=\"s1\">{$QQS$}</span><span class=\"s2\">{$QQT$}</span></div></li>";
                }
                qqlist = qqlist.Replace("{$QQnum$}", qqnum).Replace("{$QQS$}", qqs).Replace("{$QQT$}", qqtitle);
            }
            qqlist = qqlist.Replace("\"", "\\\"");
        }

        
    }
}
