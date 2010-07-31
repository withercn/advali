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
using AdvAli.Web.Html.UI;

namespace AdvAli.Web
{
    public partial class _Default : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 0;
            base.Page_Load(sender, e);
            HtmlMeta hm = new HtmlMeta();
            hm.Name = "Keywords";
            hm.Content = Config.Global.__Meta_Key;
            Header.Controls.Add(hm);
            hm = new HtmlMeta();
            hm.Name = "Description";
            hm.Content = Config.Global.__Meta_Desc;
            Header.Controls.Add(hm);
            Title = Config.Global.__Title;
        }
    }
}
