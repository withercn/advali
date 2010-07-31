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
    public partial class index : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.Fields = "id,username,inc,contact,groupname,regdate,logdate";
            base.FieldName = "编号,账号,企业名称,联系人,分组类型,注册时间,登陆时间";
            base.FieldWidth = "50,*,120,80,80,120,120";
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 2;
            base.addurl = "../user/useradd.aspx";
            base.editurl = "../user/useredit.aspx";
            base.RightsUrl = "../user/rightsedit.aspx";
            base.deltable = "adv_user";
            base.Page_Load(sender, e);
            base.TableBindData(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }
    }
}
