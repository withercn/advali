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
    public partial class groupadd : AdminPage
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

            groupname.Value = Common.Util.GetPageParams("groupname");
            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid.Value = Common.Util.GetPageParams("siteid");

            base.BindData();
        }

        protected void KeysGroup_Click(object sender, EventArgs e)
        {
            AdvAli.Entity.KeyGroup kg = new KeyGroup();
            if (groupname.Value.Trim().Length == 0)
            {
                Common.MsgBox.Alert("分组名字不能为空!");
                return;
            }
            if (Common.Util.GetPageParamsAndToInt("siteid") == -100 || Common.Util.GetPageParamsAndToInt("siteid") == 0)
            {
                Common.MsgBox.Alert("请选择分组所属网站！");
                return;
            }
            kg.GroupName = groupname.Value.Trim();
            kg.SiteId = Common.Util.GetPageParamsAndToInt("siteid");
            kg.UserId = base.GetLoggedMemberId();
            if (AdvAli.Keys.KeyManage.KeysGroupAdd(kg))
                Common.MsgBox.Alert("redirect", "关键字分组,添加成功!", "group.aspx");
            else
                Common.MsgBox.Alert("alert", "分组名称已经存在!");
        }
    }
}
