using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using AdvAli.Entity;
using AdvAli.Common;
using AdvAli.Logic;
using System.Web;
using System.Web.UI;

namespace AdvAli.Web.Html
{
    public class HtmlGroups : Page
    {
        #region 添加用户组
        public static void GroupsAdd()
        {
            int id = Util.GetPageParamsAndToInt("id");
            string groupname = Util.GetPageParams("groupname");
            string admins = Util.GetPageParams("hid");
            if (admins.Length > 0)
            {
                admins = admins.Substring(0, admins.Length - 1);
            }
            Group g = new Group();
            g.Id = id;
            g.GroupName = groupname;
            g.Caption = admins;
            GroupsAdd(g);
        }
        public static void GroupsAdd(Group g)
        {
            if (Consult.GroupsAdd(g) != -1)
            {
                MsgBox.ScriptAlert("Groups", string.Format("用户组添加成功!"), "../user/groups.aspx");
            }
            else
            {
                MsgBox.ScriptAlert("Groups", string.Format("用户组添加失败,组编号或编名称有重复!"), "../user/groups.aspx");
            }
        }
        #endregion

        #region 自动分析组编号
        public static int GetMaxGroupId()
        {
            int groupId = Consult.GetMaxGroupsId();
            if (groupId > 0)
                return groupId + 1;
            else
                return 0;
        }
        #endregion

        #region 修改用户组
        public static void GroupsEdit()
        {
            int id = Util.GetPageParamsAndToInt("id");
            if (id == -100)
            {
                MsgBox.ScriptAlert("Groups", "请选择一个用户组修改", "../user/groups.aspx");
                return;
            }
            string groupname = Util.GetPageParams("groupname");
            string caption = Util.GetPageParams("hid");
            if (caption.Length > 0)
                caption = caption.Substring(0, caption.Length - 1);
            Group g = new Group();
            g.Id = id;
            g.GroupName = groupname;
            g.Caption = caption;
            GroupsEdit(g);
        }
        public static void GroupsEdit(Group g)
        {
            Logic.Consult.EditGroups(g);
            MsgBox.ScriptAlert("Groups", string.Format("用户组 {0} 修改成功!", g.GroupName), "../user/groups.aspx");
        }
        #endregion
    }
}
