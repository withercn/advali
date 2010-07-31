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
using AdvAli.Config;

namespace AdvAli.Web
{
    public partial class QQMsg : System.Web.UI.Page
    {
        public string WebSiteUrl = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            WebSiteUrl = Global.__WebSiteUrl;
        }
    }
}
