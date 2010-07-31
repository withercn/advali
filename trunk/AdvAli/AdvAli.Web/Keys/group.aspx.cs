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
    public partial class group : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Fields = "id,groupname,sitename";
            base.FieldName = "编号,分组名称,网站";
            base.FieldWidth = "50,200,*";
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 0;

            //绑定网站选择
            Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetSite(base.GetLoggedMemberId(), base.GetLoggedUserGroupId()), "sitename", "id", siteid);
            siteid.Items.Insert(0, new ListItem("请选择", "0"));


            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid.Value = Common.Util.GetPageParams("siteid");

            base.addurl = "../keys/groupadd.aspx";
            base.deltable = "adv_keys_group";
            base.Page_Load(sender, e);
            base.GetKeysGroup(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }
    }
}
