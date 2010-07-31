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

namespace AdvAli.Web.help
{
    public partial class forum : AdminPage
    {
        public string pagehtml = "";

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 0;
            base.FieldName = "标题,意见人";
            base.FieldWidth = "*,200";
            if (base.GetLoggedUserGroupId() >= 8)
                posts.Visible = false;

            if (Common.Util.GetPageParamsAndToInt("isre") != -100)
                isre.Checked = Common.Util.ChangeStrToBool(Common.Util.GetPageParams("isre"));
            else
                isre.Checked = false;
            if (Common.Util.GetPageParamsAndToInt("remove") != -100)
                remove.Checked = Common.Util.ChangeStrToBool(Common.Util.GetPageParams("remove"));
            else
                remove.Checked = false;

            base.deltable = "adv_forum";
            base.Page_Load(sender, e);
            base.GetForum(data);
            Pager pager = HtmlPager.GetPager(RecordCount);
            pagehtml += string.Format("<a href=\"{0}\">首页</a><a href=\"{1}\">上页</a><a href=\"{2}\">下页</a><a href=\"{3}\">末页</a><select onchange=\"changePage(this.value);\">{4}</select>", pager.FristPage, pager.PrevPage, pager.NextPage, pager.LastPage, pager.ListPage);
        }

        protected void Replay_Click(object sender, EventArgs e)
        {
            string id = postid.Value;
            string re_str = re.Value;
            Logic.Consult.Repost(int.Parse(id), re_str);
            Common.MsgBox.JumpAlert("jump", "回复成功!");
        }

        protected void Post_Click(object sender, EventArgs e)
        {
            string post_Title = title.Value;
            string post_Context = context.Value;
            Logic.Consult.Posts(post_Title, post_Context, base.GetLoggedMemberId());
            Common.MsgBox.JumpAlert("jump", "意见反馈成功!");
        }

        protected override void Del_Click(object sender, EventArgs e)
        {
            string idlist = GetIdList();
            if (!string.IsNullOrEmpty(idlist))
            {
                Logic.Consult.DeletePost(idlist);
                Common.MsgBox.JumpAlert("jump", "删除意见反馈成功!");
            }
            else
                Common.MsgBox.JumpAlert("jump", "删除意见反馈失败!");

        }

        protected void Recover_Click(object sender, EventArgs e)
        {
            string idlist = GetIdList();
            if (!string.IsNullOrEmpty(idlist))
            {
                Logic.Consult.RecoverPost(idlist);
                Common.MsgBox.JumpAlert("jump", "恢复已经删除数据成功!");
            }
            else
                Common.MsgBox.JumpAlert("jump", "恢复已经删除数据失败!");
        }
    }
}
