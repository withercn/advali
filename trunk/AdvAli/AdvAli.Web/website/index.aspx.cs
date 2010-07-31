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

namespace AdvAli.Web.website
{
    public partial class index : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.DefaultTable = "adv_site";
            base.FieldName = "编号,网站,广告类型,广告范围,状态";
            base.FieldWidth = "50,150,100,*,100";
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 7;
            base.addurl = "../website/sitestep1.aspx";
            base.editurl = "../website/sitestep1.aspx";
            base.deltable = "adv_site";
            base.Page_Load(sender, e);
            base.GetWebSite(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }

        protected override void Del_Click(object sender, EventArgs e)
        {
            string idlist = base.GetIdList();
            if (string.IsNullOrEmpty(idlist))
            {
                Common.MsgBox.JumpAlert("Msg", "<p>请选择需要删除的数据!</p>");
                return;
            }
            string[] id = idlist.Split(new char[] { ',' });
            for (int i = 0; i < id.Length; i++)
            {
                int pid = 0;
                int.TryParse(id[i], out pid);
                if (pid != 0)
                {
                    AdvAli.Entity.Site site = Logic.Consult.GetWebSite(pid);
                    if (site.AdDisplay > 0 && site.AdId > 0)
                        Logic.Consult.RemoveAdvert(site.AdDisplay, site.AdId);
                }
            }
            base.Del_Click(sender, e);
        }
    }
}
