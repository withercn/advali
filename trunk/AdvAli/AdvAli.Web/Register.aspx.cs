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
using AdvAli.Common;
using AdvAli.Config;

namespace AdvAli.Web
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Global.config.AllowRegister)
            {
                MsgBox.AlertScript("Login", "<p>系统目前不允许注册新用户!</p>", "history.go(-1);");
                return;
            }
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
