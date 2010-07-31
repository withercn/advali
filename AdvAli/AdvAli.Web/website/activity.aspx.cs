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
    public partial class activity : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 14;
            base.Page_Load(sender, e);
            int siteid = Common.Util.GetPageParamsAndToInt("siteid");
            if (siteid == -100)
                return;
            else
                Logic.Consult.Activity(siteid);
            Response.Redirect(Request.UrlReferrer.ToString());
        }
    }
}
