using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;
using AdvAli.Config;
using AdvAli.Common;

namespace AdvAli.Web
{
    public partial class webinfo : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.BrowserRightsIntValue = 1;
            base.isNeedCheckRights = true;
            base.Page_Load(sender, e);
        }

        protected override void BindData()
        {
            websitename.Value = Global.config.WebSiteName;
            websitetitle.Value = Global.config.WebSiteTitle;
            meta_key.Value = Global.config.Meta_Key;
            meta_desc.Value = Global.config.Meta_Desc;
            websiteurl.Value = Global.config.WebSiteUrl;
            websitedomain.Value = Global.config.WebSiteDomain;
            allrights.Value = Global.config.AllRights;
            uploaddirectory.Value = Global.config.UploadDirectory;
            if (Global.config.AllowRegister)
                reg1.Checked = true;
            else
                reg2.Checked = true;
            if (Global.config.AllowLogin)
                login1.Checked = true;
            else
                login2.Checked = true;
            maxupload.Value = Global.config.MaxUpload.ToString();
            allowupload.Value = Global.config.AllowUpload;
            websitenote.Value = Global.config.WebSiteNote;
            copyright.Value = Global.config.CopyRight;
            base.BindData();
        }

        protected void Base_Click(object sender, EventArgs e)
        {
            Global.config.WebSiteName = Common.Util.GetPageParams("websitename");
            Global.config.WebSiteTitle = Common.Util.GetPageParams("websitetitle");
            Global.config.Meta_Key = Common.Util.GetPageParams("meta_key");
            Global.config.Meta_Desc = Common.Util.GetPageParams("meta_desc");
            Global.config.WebSiteUrl = Common.Util.GetPageParams("websiteurl");
            Global.config.WebSiteDomain = Common.Util.GetPageParams("websitedomain");
            Global.config.AllRights = Common.Util.GetPageParams("allrights");
            Global.config.UploadDirectory = Common.Util.GetPageParams("uploaddirectory");
            Global.config.AllowRegister = Common.Util.ChangeStrToBool(Common.Util.GetPageParams("allowregister"));
            Global.config.AllowLogin = Common.Util.ChangeStrToBool(Common.Util.GetPageParams("allowlogin"));
            Global.config.MaxUpload = long.Parse(Common.Util.GetPageParams("maxupload"));
            Global.config.AllowUpload = Common.Util.GetPageParams("allowupload");
            Global.config.WebSiteNote = Common.Util.GetPageParams("websitenote");
            Global.config.CopyRight = Common.Util.GetPageParams("copyright");
            Logic.Consult.UpdateConfig(Global.config);
            MsgBox.JumpAlert("Cache", string.Format("<p>网站基本信息更新成功</p>"));
        }

        protected void Cache_Click(object sender, EventArgs e)
        {
            Global.config = Global.provider.GetConfig();
            Global.__WebSiteName = Global.config.WebSiteName;
            Global.__WebSiteUrl = Global.config.WebSiteUrl;
            Global.__UploadDirectory = Global.config.UploadDirectory;
            Global.__Domain = Global.config.WebSiteDomain;
            MsgBox.JumpAlert("Cache", string.Format("<p>缓存更新完毕</p>"));
        }
    }
}
