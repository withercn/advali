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
    public partial class previewPicture : Page
    {
        public bool IsScript = false;
        public string WebSiteUrl = "";
        public string html = "";
        public int width = 280;
        public int height = 280;
        public string sTitle = "";
        public string piclnk = "";
        public string siteId = "0";
        public string getSiteId = "0";
        public string btn1 = GlobalObject.escape("接受对话");
        public string btn2 = GlobalObject.escape("暂不对话");

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BindData();
        }

        protected void BindData()
        {
            getSiteId = Common.Util.GetPageParams("getsiteid");
            siteId = Common.Util.GetPageParams("siteId");
            IsScript = Common.Util.GetPageParamsAndToInt("isscript") == 1 ? true : false;
            int w = Common.Util.GetPageParamsAndToInt("width");
            int h = Common.Util.GetPageParamsAndToInt("height");
            if (w != -100) width = w;
            if (h != -100) height = h;
            WebSiteUrl = Config.Global.__WebSiteUrl;
            string picname = Common.Util.GetPageParams("picname");
            string picurl = Common.Util.GetPageParams("picurl");
            piclnk = Common.Util.GetPageParams("piclnk");
            sTitle = picname;
            html = string.Format("<a id=\\\"imgLnk\\\" class=\\\"faint\\\" title=\\\"\"+unescape(\"{2}\")+\"\\\" href=\\\"{0}\\\" target=\\\"_blank\\\">{1}</a>", piclnk, picurl.Replace("\\", "\\\\\\\\"), picname);
        }
    }
}
