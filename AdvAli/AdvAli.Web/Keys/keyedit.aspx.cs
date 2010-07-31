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
    public partial class keyedit : AdminPage
    {
        public int id = Common.Util.GetPageParamsAndToInt("id");

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (id <= 0)
            {
                Common.MsgBox.Alert("请选择修改的关键字");
                return;
            }
            AdvAli.Entity.Key k = AdvAli.Keys.KeyManage.GetKey(id);
            keywords.Value = k.Keywords;
            if (k.Flag)
                flag.Value = "1";
            else
                flag.Value = "0";
            //price.Value = k.Price.ToString("0.00");
            //绑定网站选择
            Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetSite(base.GetLoggedMemberId(), base.GetLoggedUserGroupId()), "sitename", "id", siteid);
            siteid.Items.Insert(0, new ListItem("请选择", "0"));
            siteid.Value = k.SiteId.ToString();
            if (k.SiteId > 0)
            {
                //绑定关键字分组
                Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetGroups(base.GetLoggedMemberId(), Common.Util.GetPageParamsAndToInt("siteid"), base.GetLoggedUserGroupId()), "groupname", "id", groupid);
            }
            groupid.Items.Insert(0, new ListItem("请选择", "0"));
            groupid.Value = k.GroupId.ToString();
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 0;
            base.Page_Load(sender, e);
        }

        protected void Keys_Click(object sender, EventArgs e)
        {
            if (id <= 0)
            {
                Common.MsgBox.Alert("请选择修改的关键字");
                return;
            }
            AdvAli.Entity.Key k = AdvAli.Keys.KeyManage.GetKey(id);
            if (keywords.Value.Trim().Length == 0 || keywords.Value.Trim().Length > 20)
            {
                Common.MsgBox.Alert("关键字长度不正确，正确长度为：1-20个汉字");
                return;
            }
            k.Keywords = keywords.Value.Trim();
            //decimal de;
            //if (!decimal.TryParse(price.Value.Trim(), out de))
            //{
            //    Common.MsgBox.Alert("价格的格式不正确,正确格式为：123.45");
            //    return;
            //}
            k.Price = decimal.Parse("0.00"); //de;
            if (Common.Util.GetPageParamsAndToInt("siteid") == -100 || Common.Util.GetPageParamsAndToInt("siteid") == 0)
            {
                Common.MsgBox.Alert("请选择关键字所属网站！");
                return;
            }
            //k.SiteId = Common.Util.GetPageParamsAndToInt("siteid");
            k.UserId = base.GetLoggedMemberId();
            k.Flag = Common.Util.ChangeStrToBool(Common.Util.GetPageParams("flag"));
            if (Common.Util.GetPageParamsAndToInt("groupid") == -100 || Common.Util.GetPageParamsAndToInt("groupid") == 0)
                k.GroupId = 0;
            else
                k.GroupId = Common.Util.GetPageParamsAndToInt("groupid");
            AdvAli.Keys.KeyManage.KeysEdit(k);
            Common.MsgBox.Alert("redirect", "关键字修改完成", "index.aspx");
        }
    }
}
