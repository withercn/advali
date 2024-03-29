﻿using System;
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
    public partial class sitestep1 : AdminPage
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
            txtwebname.Value = site.SiteName;
            txtUrl.Value = site.SiteUrl;
            sitenote.Value = site.SiteNote;
            curscript.Value = site.CurScript;
        }

        protected void SaveStep1_Click(object sender, EventArgs e)
        {
            HtmlWebSite.SaveStep1(id);
        }
    }
}
