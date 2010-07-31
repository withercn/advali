using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;

namespace AdvAli.Web.user
{
    public partial class rightsadd : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.BrowserRightsIntValue = 4;
            base.isNeedCheckRights = true;
            base.Page_Load(sender, e);
            adminsid.Value = HtmlAdmins.GetMaxAdminsId().ToString();
        }

        protected void RightsAdd_Click(object sender, EventArgs e)
        {
            HtmlAdmins.AdminsAdd();
        }
    }
}
