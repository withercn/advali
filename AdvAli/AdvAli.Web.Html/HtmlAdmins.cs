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
    public class HtmlAdmins : Page
    {
        #region 权限添加
        public static void AdminsAdd()
        {
            int id = Util.GetPageParamsAndToInt("adminsid");
            string adminname = Util.GetPageParams("adminsname");
            AdminsAdd(id, adminname);
            MsgBox.ScriptAlert("Admins", string.Format("权限添加成功!"), "../user/rights.aspx");
        }
        public static void AdminsAdd(int id, string adminname)
        {
            Consult.AdminsAdd(id, adminname);
        }
        #endregion

        #region 分配权限编号
        public static int GetMaxAdminsId()
        {
            int adminsId = Consult.GetMaxAdminsId();
            if (adminsId > 0)
                return adminsId + 1;
            else
                return 0;
        }
        #endregion
    }
}
