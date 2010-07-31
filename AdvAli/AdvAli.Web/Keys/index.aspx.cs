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
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;

namespace AdvAli.Web.Keys
{
    public partial class index :AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Fields = "id,keywords,groupname,sitename,flag";//,price";
            base.FieldName = "编号,关键字,分组,网站,允许/拒绝访问";//,价格";
            base.FieldWidth = "50,150,100,150,100,80";
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 0;

            //绑定网站选择
            Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetSite(base.GetLoggedMemberId(), base.GetLoggedUserGroupId()), "sitename", "id", siteid);
            siteid.Items.Insert(0, new ListItem("请选择", "0"));
            //绑定关键字分组
            Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetGroups(base.GetLoggedMemberId(), Common.Util.GetPageParamsAndToInt("siteid"), base.GetLoggedUserGroupId()), "groupname", "id", group);
            group.Items.Insert(0, new ListItem("请选择", "0"));

            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid.Value = Common.Util.GetPageParams("siteid");
            if (Common.Util.GetPageParamsAndToInt("group") != -100)
                group.Value = Common.Util.GetPageParams("group");

            base.addurl = "../keys/keyadd.aspx";
            base.editurl = "../keys/keyedit.aspx";
            base.deltable = "adv_keys";
            base.Page_Load(sender, e);
            base.GetKeys(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }
    }
}
