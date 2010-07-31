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

namespace AdvAli.Web.user
{
    public partial class groups : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Fields = "id,groupname";
            base.FieldName = "编号,用户组";
            base.FieldWidth = "120,*";
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 10;
            base.DefaultTable = "adv_group";
            base.DelTable = "adv_group";
            base.EditUrl = "../user/groupsedit.aspx";
            base.addurl = "../user/groupsadd.aspx";
            base.Page_Load(sender, e);
            base.DefaultDataSetBind(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }
    }
}
