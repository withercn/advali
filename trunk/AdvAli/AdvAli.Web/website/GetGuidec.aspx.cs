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
using Microsoft.JScript;

namespace AdvAli.Web.website
{
    public partial class GetGuidec : System.Web.UI.Page
    {
        public string WebSiteUrl = "";
        public string siteId = "0";
        public string getSiteId = "0";
        public string template = "swtm";
        public string titles = "";
        public string link = "";
        public string text = "";
        public string tel1 = "";
        public string tel2 = "";
        public string prompt = "";
        public string text1 = "";
        public string link1 = "";
        public string text2 = "";
        public string link2 = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            WebSiteUrl = Config.Global.__WebSiteUrl;
            getSiteId = Common.Util.GetPageParams("getsiteid");
            siteId = Common.Util.GetPageParams("siteId");
            Entity.Site site = Logic.Consult.GetWebSite(int.Parse(siteId));
            Guidec guidec = Logic.Consult.GetGuidec(site.AdId);
            titles = GlobalObject.escape(guidec.Title);
            link = guidec.Link;
            text = GlobalObject.escape(guidec.Context);
            tel1 = guidec.Tel1;
            tel2 = guidec.Tel2;
            prompt = GlobalObject.escape(guidec.Prompt);
            text1 = GlobalObject.escape(guidec.AdText1);
            link1 = guidec.AdLink1;
            text2 = GlobalObject.escape(guidec.AdText2);
            link2 = guidec.AdLink2;
            if (site.Templates == 2)
                template = "swtf";
        }
    }
}
