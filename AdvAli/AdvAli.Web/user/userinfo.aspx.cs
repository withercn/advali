using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;

namespace AdvAli.Web.user
{
    public partial class userinfo : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.BrowserRightsIntValue = 6;
            base.isNeedCheckRights = true;
            base.Page_Load(sender, e);
            //txtUsername.Value = base.user.Username;
            //txtEntname.Value = base.user.EntName;
            //txtAddress.Value = base.user.Address;
            //txtTel.Value = base.user.Tel;
            //txtEntnote.Value = base.user.EntNote;
            
        }

        protected override void BindData()
        {
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

        protected void UserInfoEdit_Click(object sender, EventArgs e)
        {
            int userid = 0;
            int.TryParse(HtmlUser.clsdes.Decrypt(Common.AdvAliCookie.GetCookieMemberId()), out userid);
            if (userid > 0)
            {
                User user = Logic.Consult.GetUser(userid);
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
            else
            {
                AdvAli.Common.MsgBox.ScriptAlert("Msg", "<p>对不起,您没有权限访问该模块!</p>", "../login.aspx", "top");
            }
        }
    }
}
