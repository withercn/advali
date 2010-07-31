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
    public partial class keyadd : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 0;
            base.Page_Load(sender, e);
        }

        protected override void BindData()
        {
            //绑定网站选择
            Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetSite(base.GetLoggedMemberId(), base.GetLoggedUserGroupId()), "sitename", "id", siteid);
            siteid.Items.Insert(0, new ListItem("请选择", "0"));
            //绑定关键字分组
            if (Common.Util.GetPageParamsAndToInt("siteid") > 0)
            {
                Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetGroups(base.GetLoggedMemberId(), Common.Util.GetPageParamsAndToInt("siteid"), base.GetLoggedUserGroupId()), "groupname", "id", groupid);
            }
            groupid.Items.Insert(0, new ListItem("请选择", "0"));

            keywords.Value = Common.Util.GetPageParams("keywords");
            //price.Value = Common.Util.GetPageParams("price");
            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid.Value = Common.Util.GetPageParams("siteid");
            if (Common.Util.GetPageParamsAndToInt("groupid") != -100)
                groupid.Value = Common.Util.GetPageParams("groupid");

            base.BindData();
        }

        protected void Keys_Click(object sender, EventArgs e)
        {
            Key k = new Key();
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
            k.SiteId = Common.Util.GetPageParamsAndToInt("siteid");
            k.Flag = Common.Util.ChangeStrToBool(Common.Util.GetPageParams("flag"));
            k.UserId = base.GetLoggedMemberId();
            if (Common.Util.GetPageParamsAndToInt("groupid") == -100 || Common.Util.GetPageParamsAndToInt("groupid") == 0)
                k.GroupId = 0;
            else
                k.GroupId = Common.Util.GetPageParamsAndToInt("groupid");
            if (AdvAli.Keys.KeyManage.KeysAdd(k))
                Common.MsgBox.Alert("redirect", "关键字添加成功!", "index.aspx");
            else
                Common.MsgBox.Alert("alert", "关键字已经存在");
        }
    }
}
