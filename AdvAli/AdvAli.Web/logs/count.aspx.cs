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

namespace AdvAli.Web.logs
{
    public partial class count : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 13;
            base.FieldName = "编号,网站,日期,访问量,咨询量";
            base.FieldWidth = "50,*,120,100,100";

            Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetSite(base.GetLoggedMemberId(), base.GetLoggedUserGroupId()), "sitename", "id", siteid);
            siteid.Items.Insert(0, new ListItem("请选择", "0"));
            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid.Value = Common.Util.GetPageParams("siteid");
            if (Common.Util.GetPageParams("date1") != string.Empty)
                date1.Value = Common.Util.GetPageParams("date1");
            if (Common.Util.GetPageParams("date2") != string.Empty)
                date2.Value = Common.Util.GetPageParams("date2");
            base.deltable = "adv_visit";
            base.Page_Load(sender, e);
            base.GetVisits(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }
    }
}
