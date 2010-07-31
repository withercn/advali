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
    public partial class SEngine : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Fields = "id,sname,surl,skey,ie,ei";
            base.FieldName = "编号,搜索引擎,域名,查询参数,默认编码,编码参数";
            base.FieldWidth = "50,*,150,150,100,100";
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 0;
            base.DefaultTable = "adv_key_search";

            base.addurl = "../keys/SEAdd.aspx";
            base.deltable = "adv_key_search";
            base.Page_Load(sender, e);
            base.DefaultDataSetBind(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }

        protected void Engine_Click(object sender, EventArgs e)
        {

        }
    }
}
