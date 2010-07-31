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
    public partial class GetScript : AdminPage
    {
        public int siteid;
        public string Scripts = "";
        public string weburl = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            weburl = AdvAli.Config.Global.config.WebSiteUrl;
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 7;
            base.Page_Load(sender, e);
        }

        protected override void BindData()
        {
            siteid = Common.Util.GetPageParamsAndToInt("siteid");
            this.Scripts = HtmlWebSite.GetScripts(siteid);
            this.Scripts = Common.Util.RemoveScript(this.Scripts);
            base.BindData();
        }
    }
}
