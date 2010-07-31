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
    public class HtmlMenu : Page
    {
        private static StringBuilder builder;

        #region 添加菜单项
        public static void AddMenu()
        {
            string menuname = HttpContext.Current.Request["txtMenuName"];
            string url = HttpContext.Current.Request["txtUrl"];
            string parent = HttpContext.Current.Request["txtParent"];
            int parentid = 0;
            int.TryParse(parent, out parentid);
            AddMenu(menuname, url, parentid);
        }
        public static void AddMenu(string menuname, string url, int parent)
        {
            Menu menu = new Menu();
            menu.MenuName = menuname;
            menu.Url = url;
            menu.Parent = parent;
            Consult.AddMenu(menu);
        }
        #endregion

        #region 删除菜单项
        public static bool DeleteMenu()
        {
            string menuid = HttpContext.Current.Request["txtMenuId"];
            int id = 0;
            int.TryParse(menuid, out id);
            return DeleteMenu(id);
        }
        public static bool DeleteMenu(int menuid)
        {
            return Consult.DeleteMenu(menuid);
        }
        #endregion

        #region 修改菜单项
        public static bool EditMenu(Menu menu)
        {
            return Consult.EditMenu(menu);
        }
        #endregion

        #region 读取菜单项
        public static string GetMenus()
        {
            builder = new StringBuilder();
            Menus mainmenus = Consult.GetMenus(0);
            foreach (Menu menu in mainmenus)
            {
                User user = Consult.GetUser(HtmlUser.GetLoggedMemberId());
                if (Util.JudgeRights(menu.Rights, user.Admins) || menu.Sub>0)
                {
                    Menus submenus = Consult.GetMenus(menu.Id);
                    if (submenus.Count > 0)
                    {
                        if (menu.Sub == 1 && user.GroupId == 1)
                            builder.Append(string.Format("<div class=\"sub\"><a href=\"javascript:void(0);\">{1}</a></div>\r\n", menu.Url, menu.MenuName));
                        //else if (menu.Url == "http://www.andad.net/cjwt/")
                        //    builder.Append(string.Format("<div class=\"sub\"><a href=\"{0}\" target=\"_blank\">{1}</a></div>\r\n", menu.Url, menu.MenuName));
                        else
                            builder.Append(string.Format("<div class=\"sub1\"><img src=\"../images/dir_2.gif\" onclick=\"hide(this)\" /><a href=\"{0}\" target=\"mainFrame\">{1}</a></div>\r\n", menu.Url, menu.MenuName));
                        builder.Append("    <ul style=\"display:block;\">\r\n");
                        foreach (Menu submenu in submenus)
                        {
                            if (Util.JudgeRights(submenu.Rights, user.Admins))
                            {
                                builder.Append(string.Format("        <li><a href=\"{0}\" target=\"mainFrame\" title=\"{1}\">{1}</a></li>\r\n", submenu.Url, submenu.MenuName));
                            }
                        }
                        builder.Append("    </ul>\r\n");
                    }
                    else
                    {
                        if (menu.Url.ToLower().IndexOf("logout.aspx") != -1)
                        {
                            builder.Append(string.Format("<div class=\"sub\"><a href=\"{0}\" target=\"_top\">{1}</a></div>\r\n", menu.Url, menu.MenuName)); 
                        }
                        else
                        {
                            builder.Append(string.Format("<div class=\"sub\"><a href=\"{0}\" target=\"mainFrame\">{1}</a></div>\r\n", menu.Url, menu.MenuName));
                        }
                    }
                }
            }
            return builder.ToString();
        }
        #endregion
    }
}
