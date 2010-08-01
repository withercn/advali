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
    public partial class sitestep4_1 : AdminPage
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

        private void BData()
        {
            Entity.Site site = Logic.Consult.GetWebSite(id);
            Guidec guidec = Logic.Consult.GetGuidec(site.AdId);
            title.Value = guidec.Title;
            link.Value = guidec.Link;
            context.Value = guidec.Context;
            if (guidec.WordLnk == 1)
            {
                wordLnk1.Checked = true;
                ClientScript.RegisterStartupScript(this.GetType(), "ScriptBlock", "setAdShow('block');", true);
            }
            else
            {
                wordLnk2.Checked = true;
                ClientScript.RegisterStartupScript(this.GetType(), "ScriptBlock", "setAdShow('none');", true);
            }
            adText1.Value = guidec.AdText1;
            adLink1.Value = guidec.AdLink2;
            adText2.Value = guidec.AdText2;
            adLink2.Value = guidec.AdLink2;
            ClientScript.RegisterStartupScript(this.GetType(), "StartScript", "reviewSwt();", true);
            int template = Common.Util.GetPageParamsAndToInt("t");
            if (template == 1)
            {
                tel1li.Visible = false;
                tel2li.Visible = false;
                swtf.Visible = false;
                prompt.Value = guidec.Prompt;
            }
            if (template == 2)
            {
                promptli.Visible = false;
                swtm.Visible = false;
                tel1.Value = guidec.Tel1;
                tel2.Value = guidec.Tel2;
            }
        }

        protected void Step2_Click(object sender, EventArgs e)
        {
            id = Common.Util.GetPageParamsAndToInt("id");
            int t = Common.Util.GetPageParamsAndToInt("t");
            if (id != -100)
                Response.Redirect(string.Format("sitestep3.aspx?id={0}&t={1}", id.ToString(), t.ToString()), true);
        }

        protected void SaveStep41_Click(object sender, EventArgs e)
        {
            HtmlWebSite.SaveStep41(id);
        }
    }
}
