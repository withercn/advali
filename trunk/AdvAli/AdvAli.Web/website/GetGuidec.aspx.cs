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

        protected void Page_Load(object sender, EventArgs e)
        {
            WebSiteUrl = Config.Global.__WebSiteUrl;
            getSiteId = Common.Util.GetPageParams("getsiteid");
            siteId = Common.Util.GetPageParams("siteId");
        }
    }
}
