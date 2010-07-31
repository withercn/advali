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
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string username = Common.Util.GetPageParams("txtusername");
            string password = Common.Util.GetPageParams("txtpassword");
            string code = Common.Util.GetPageParams("txtcode");
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(code))
            {
                Html.HtmlUser.LoginUser(username, password, code);
            }
        }
    }
}
