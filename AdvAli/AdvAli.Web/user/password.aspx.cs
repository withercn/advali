using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;

namespace AdvAli.Web.user
{
    public partial class password : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.BrowserRightsIntValue = 5;
            base.isNeedCheckRights = true;
            base.Page_Load(sender, e);
            txtUsername.Value = base.user.Username;
        }

        protected void Password_Click(object sender, EventArgs e)
        {
            int userid = 0;
            int.TryParse(HtmlUser.clsdes.Decrypt(Common.AdvAliCookie.GetCookieMemberId()), out userid);
            if (userid > 0)
            {
                if (txtPassword.Value.Trim() == txtPassword2.Value.Trim())
                {
                    HtmlUser.EditPassword(userid, txtOldPassword.Value.Trim(), txtPassword.Value.Trim());
                }
                else
                {
                    Common.MsgBox.Alert("Password", string.Format("<p>两次输入的密码不相同,请仔细检查!</p>"));
                }
            }
            else
            {
                AdvAli.Common.MsgBox.ScriptAlert("Msg", "<p>对不起,您没有权限访问该模块!</p>", "../login.aspx", "top");
            }
            
        }
    }
}
