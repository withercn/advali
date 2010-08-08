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
    public partial class sitestep4_3 : AdminPage
    {
        public string WebSiteName = AdvAli.Config.Global.config.WebSiteName;
        public int id = 0;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 11;
            base.Page_Load(sender, e);
            id = Common.Util.GetPageParamsAndToInt("id");
            if (!Page.IsPostBack && id != -100)
                this.BData();
        }

        protected void BData()
        {
            Entity.Site site = Logic.Consult.GetWebSite(id);
            Entity.QQMsn qqmsn = Logic.Consult.GetQQMsn(site.AdId);
            qqhead.Value = qqmsn.Header;
            qqbottom.Value = qqmsn.Bottom;
            string[] qqnum = qqmsn.Account.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
            string[] qqs = qqmsn.Namer.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
            string[] qqtitle = qqmsn.Notes.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
            if (qqnum.Length == 0 || qqs.Length == 0 || qqtitle.Length == 0)
                return;
            isqq.Value = "0";
            string html = "";
            if (qqnum.Length == qqs.Length && qqs.Length == qqtitle.Length && qqnum.Length > 0)
            {
                for (int j = 0; j < qqnum.Length; j++)
                {
                    int i = j + 1;
                    html += string.Format("<li>　 QQ/MSN<span class=\"red\">号码{0}：</span><input name=\"qqnum{0}\" runat=\"server\" type=\"text\" value=\"{1}\" class=\"loginInput\" /></li><li>　 QQ/MSN<span class=\"red\">昵称{0}：</span><input name=\"qqs{0}\" runat=\"server\" type=\"text\" value=\"{2}\" class=\"loginInput\" /></li><li>　 QQ/MSN<span class=\"red\">分组{0}：</span><input name=\"qqtitle{0}\" runat=\"server\" type=\"text\" value=\"{3}\" class=\"loginInput\" /></li>", i.ToString(), qqnum[j], qqs[j], qqtitle[j]);
                }
                qqinfo.InnerHtml = html;
                qqn.Value = qqnum.Length.ToString();
            }
        }

        protected void SaveStep43_Click(object sender, EventArgs e)
        {
            HtmlWebSite.SaveStep42(id);
        }

        protected void Step3_Click(object sender, EventArgs e)
        {
            id = Common.Util.GetPageParamsAndToInt("id");
            if (id != -100)
                Response.Redirect(string.Format("sitestep3.aspx?id={0}", id.ToString()));
        }
    }
}
