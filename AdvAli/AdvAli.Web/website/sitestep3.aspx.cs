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
    public partial class sitestep3 : AdminPage
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
            if (!Page.IsPostBack)
            {
                Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetAdType(), "adtype", "id", adTypeSelect);
                adTypeSelect.Items.Insert(0, new ListItem("请选择", "0"));
            }
            adTypeSelect.SelectedIndex = 0;
            Entity.Site site = Logic.Consult.GetWebSite(id);
            adTypeSelect.Value = site.AdDisplay.ToString();
            if (Common.Util.GetAdType(site.AdDisplay) == "文字商务通" && site.Templates > 0)
                ((HtmlInputRadioButton)Page.FindControl("template" + site.Templates.ToString())).Checked = true;
            else
                ClientScript.RegisterStartupScript(this.GetType(), "s", "selectAd(" + adTypeSelect.Value + ");", true);
        }

        protected void Step2_Click(object sender, EventArgs e)
        {
            id = Common.Util.GetPageParamsAndToInt("id");
            if (id != -100)
                Response.Redirect(string.Format("sitestep2.aspx?id={0}", id.ToString()));
        }

        protected void SaveStep3_Click(object sender, EventArgs e)
        {
            HtmlWebSite.SaveStep3(id);
        }
    }
}
