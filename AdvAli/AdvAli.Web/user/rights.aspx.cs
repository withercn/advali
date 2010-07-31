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
    public partial class rights : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Fields = "id,adminname";
            base.FieldName = "权限编号,权限名称";
            base.FieldWidth = "120,*";
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 4;
            base.DefaultTable = "adv_admins";
            base.DelTable = "adv_admins";
            base.addurl = "../user/rightsadd.aspx";
            base.Page_Load(sender, e);
            base.DefaultDataSetBind(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }
    }
}
