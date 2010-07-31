using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;
using AdvAli.Common;
using AdvAli.Config;

namespace AdvAli.Web.user
{
    public partial class useradd : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.BrowserRightsIntValue = 3;
            base.isNeedCheckRights = true;
            base.Page_Load(sender, e);
        }

        protected void UserAdd_Click(object sender, EventArgs e)
        {
            //HtmlUser.AddUser2();
            string username = Util.GetPageParams("username");
            string password = Util.GetPageParams("password");
            string inc = Util.GetPageParams("inc");
            string contact = Util.GetPageParams("contact");
            string tel = Util.GetPageParams("tel");
            string mobile = Util.GetPageParams("mobile");
            string fax = Util.GetPageParams("fax");
            string qq = Util.GetPageParams("qq");
            string msn = Util.GetPageParams("msn");
            string address = Util.GetPageParams("address");
            Html.HtmlUser.AddUser(username, password, inc, contact, tel, mobile, fax, qq, msn, address);
        }
    }
}
