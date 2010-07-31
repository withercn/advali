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
    public partial class previewGuidec : Page
    {
        public bool IsScript = false;
        public string WebSiteUrl = "";
        public string mess = "";
        public string titleString = "系统提示";
        public string btnString = "确定";
        public string closeBtnString = GlobalObject.escape("暂不对话");
        public string siteId = "0";
        public string getSiteId = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            getSiteId = Common.Util.GetPageParams("getsiteid");
            siteId = Common.Util.GetPageParams("siteId");
            titleString = GlobalObject.escape(titleString);
            btnString = GlobalObject.escape(btnString);
            this.BindData();
        }

        protected void BindData()
        {
            IsScript = Common.Util.GetPageParamsAndToInt("isscript") == 1 ? true : false;
            int gnum = Common.Util.GetPageParamsAndToInt("gnum");
            if (gnum == -100) return;
            WebSiteUrl = Config.Global.__WebSiteUrl;
            string guidecHeader = Common.Util.GetPageParams("guidechead");
            string guidecLink = Common.Util.GetPageParams("guideclink");
            string guidecContent = Common.Util.GetPageParams("guideccontent").Replace("\"", "\\\"");
            string html = "";
            if (string.IsNullOrEmpty(Common.Util.GetPageParams("article0")))
            {
                html = string.Format("\" + unescape(\"{0}\") + \"<br /><br /><ul>", guidecContent);
            }
            else
            {
                html = string.Format("\" + unescape(\"{0}\") + \"<br /><span style='color:red;'>\" + unescape('" + GlobalObject.escape("就医热点：") + "') + \"</span><ul>", guidecContent);
                for (int i = 0; i < gnum; i++)
                {
                    if (!string.IsNullOrEmpty(Common.Util.GetPageParams("article" + i.ToString())))
                    {
                        html += string.Format("<li style='width:160px;overflow:hidden;float:left;'><a href='{1}' target='_blank'>\" + unescape('{0}') + \"</a></li>", GlobalObject.escape("˙") + Common.Util.GetPageParams("article" + i.ToString()), Common.Util.GetPageParams("articlelink" + i.ToString()));
                    }
                }
            }
            html += "<li style='clear:both;height:0px;line-height:0px;'></li></ul>";
            mess = string.Format("var msg = new msgbox(\"{3}\",{4});msg.alert(\"{0}\",\"{1}\",\"{2}\")", html, guidecLink, "_blank", "<span='font-family:\" + unescape(\"" + GlobalObject.escape("宋体") + "\") + \";'>\" + unescape(\"" + guidecHeader + "\") + \"</span>", "unescape(\"" + GlobalObject.escape("接受对话") + "\")");
        }
    }
}
