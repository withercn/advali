using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdvAli.Web.Keys
{
    public partial class SEAdd : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 1;
            base.Page_Load(sender, e);
        }

        protected void SEA_Click(object sender, EventArgs e)
        {
            if (sname.Value.Trim().Length == 0)
            {
                Common.MsgBox.Alert("搜索引擎名称不能为空");
                return;
            }
            if (surl.Value.Trim().Length == 0)
            {
                Common.MsgBox.Alert("搜索引擎域名不能为空");
                return;
            }
            if (skey.Value.Trim().Length == 0)
            {
                Common.MsgBox.Alert("查询参数不能为空");
                return;
            }
            KeySearch ks = new KeySearch();
            ks.SName = sname.Value.Trim();
            ks.SUrl = surl.Value.Trim();
            ks.SKey = surl.Value.Trim();
            ks.Ie = ie.Value.Trim();
            ks.Ei = ei.Value.Trim();
            if (AdvAli.Keys.KeyManage.KeySearchAdd(ks))
                Common.MsgBox.Alert("redirect", "引擎添加成功!", "SEngine.aspx");
            else
                Common.MsgBox.Alert("alert", "引擎已经存在");
        }
    }
}
