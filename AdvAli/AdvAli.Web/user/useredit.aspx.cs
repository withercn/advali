using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdvAli.Web.user
{
    public partial class useredit :AdvAli.Web.Html.UI.AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 8;
            base.Page_Load(sender, e);
        }

        protected override void BindData()
        {
            int id = AdvAli.Common.Util.GetPageParamsAndToInt("id");
            AdvAli.Entity.User user = AdvAli.Logic.Consult.GetUser(id);
            txtUserid.Value = id.ToString();
            username.Value = user.Username;
            inc.Value = user.Inc;
            contact.Value = user.Contact;
            tel.Value = user.TelPhone;
            mobile.Value = user.Mobile;
            fax.Value = user.Fax;
            qq.Value = user.QQ;
            msn.Value = user.Msn;
            address.Value = user.Address;
            base.BindData();
        }

        protected void UserEdit_Click(object sender, EventArgs e)
        {
            int id = AdvAli.Common.Util.GetPageParamsAndToInt("id");
            User user = Logic.Consult.GetUser(id);
            user.Username = Common.Util.GetPageParams("username");
            if (Common.Util.GetPageParams("password").Length >= 6 && Common.Util.GetPageParams("password").Length <= 20 && Common.Util.GetPageParams("password") == Common.Util.GetPageParams("repassword"))
            {
                user.Password = Common.Util.Md532(Common.Util.GetPageParams("password"));
            }
            user.Inc = Common.Util.GetPageParams("inc");
            user.Contact = Common.Util.GetPageParams("contact");
            user.TelPhone = Common.Util.GetPageParams("tel");
            user.Mobile = Common.Util.GetPageParams("mobile");
            user.Fax = Common.Util.GetPageParams("fax");
            user.QQ = Common.Util.GetPageParams("qq");
            user.Msn = Common.Util.GetPageParams("msn");
            user.Address = Common.Util.GetPageParams("address");
            HtmlUser.EditUser(user);
        }
    }
}
