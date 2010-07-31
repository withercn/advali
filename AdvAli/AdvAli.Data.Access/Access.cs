/*using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using AdvAli.Entity;
using AdvAli.Common;

namespace AdvAli.Data
{
    public class Access : IDataProvider
    {
        private StringBuilder builder = new StringBuilder();
        private string catidString = string.Empty;

        public Entity.Config GetConfig()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_config");
            Entity.Config config = new Config();
            using (DataSet ds = AccessHelper.RunSqlGetDataSet(this.builder.ToString()))
            {
                if (Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    config.WebSiteName = reader["websitename"].ToString();
                    config.WebSiteTitle = reader["websitetitle"].ToString();
                    config.WebSiteUrl = reader["websiteurl"].ToString();
                    config.WebSiteDomain = reader["websitedomain"].ToString();
                    config.WebSiteNote = reader["websitenote"].ToString();
                    config.AllRights = reader["allrights"].ToString();
                    config.UploadDirectory = reader["uploaddirectory"].ToString();
                    config.AllowRegister = Util.ChangeStrToBool(reader["allowregister"].ToString());
                    config.AllowLogin = Util.ChangeStrToBool(reader["allowlogin"].ToString());
                    config.MaxUpload = long.Parse(reader["maxupload"].ToString());
                    config.AllowUpload = reader["allowupload"].ToString();
                    config.CopyRight = reader["copyright"].ToString();
                    config.Meta_Key = reader["meta_key"].ToString();
                    config.Meta_Desc = reader["meta_desc"].ToString();
                }
            }
            return config;
        }
        public void UpdateConfig(Entity.Config config)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_config set websitename=@websitename,websitetitle=@websitetitle,websiteurl=@websiteurl,websitedomain=@websitedomain,websitenote=@websitenote,allrights=@allrights,uploaddirectory=@uploaddirectory,allowregister=@allowregister,allowlogin=@allowlogin,maxupload=@maxupload,allowupload=@allowupload,copyright=@copyright,meta_key=@meta_key,meta_desc=@meta_desc");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@websitename", OleDbType.VarChar, 200, config.WebSiteName),
                AccessHelper.MakeInParam("@websitetitle", OleDbType.VarChar, 200, config.WebSiteTitle),
                AccessHelper.MakeInParam("@websiteurl", OleDbType.VarChar, 200, config.WebSiteUrl),
                AccessHelper.MakeInParam("@websitedomain", OleDbType.VarChar, 200, config.WebSiteDomain),
                AccessHelper.MakeInParam("@websitenote", OleDbType.VarChar, 8000, config.WebSiteNote),
                AccessHelper.MakeInParam("@allrights", OleDbType.VarChar, 2000, config.AllRights),
                AccessHelper.MakeInParam("@uploaddirectory", OleDbType.VarChar, 500, config.UploadDirectory),
                AccessHelper.MakeInParam("@allowregister", OleDbType.Boolean, 1, config.AllowRegister),
                AccessHelper.MakeInParam("@allowlogin", OleDbType.Boolean, 1, config.AllowLogin),
                AccessHelper.MakeInParam("@maxupload", OleDbType.BigInt, 8, config.MaxUpload),
                AccessHelper.MakeInParam("@allowupload", OleDbType.VarChar, 200, config.AllowUpload),
                AccessHelper.MakeInParam("@copyright", OleDbType.VarChar, 500, config.CopyRight),
                AccessHelper.MakeInParam("@meta_key", OleDbType.VarChar, 200, config.Meta_Key),
                AccessHelper.MakeInParam("@meta_desc", OleDbType.VarChar, 2000, config.Meta_Desc)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        #region 用户
        public int AddUser(User u)
        {
            if (!CheckUser(u.Username))
                return -1;
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_user (username,password,entname,entnote,regdate,logdate,regip,logip,groupid,address,tel,admins values (@username,@password,@entname,@entnote,@regdate,@logdate,@regip,@logip,@groupid,@address,@tel,@admins)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                 AccessHelper.MakeInParam("@username", OleDbType.VarChar,50,u.Username),
                 AccessHelper.MakeInParam("@password", OleDbType.Char,32,u.Password),
                 AccessHelper.MakeInParam("@entname",OleDbType.VarChar,100,u.EntName),
                 AccessHelper.MakeInParam("@entnote",OleDbType.VarChar,400,u.EntNote),
                 AccessHelper.MakeInParam("@regdate",OleDbType.Date,4,u.RegDate),
                 AccessHelper.MakeInParam("@logdate",OleDbType.Date,4,u.LogDate),
                 AccessHelper.MakeInParam("@regip",OleDbType.VarChar,15,u.RegIp),
                 AccessHelper.MakeInParam("@logip",OleDbType.VarChar,15,u.LogIp),
                 AccessHelper.MakeInParam("@groupid",OleDbType.Integer,4,u.GroupId),
                 AccessHelper.MakeInParam("@address", OleDbType.VarChar, 200, u.Address),
                 AccessHelper.MakeInParam("@tel", OleDbType.VarChar, 50, u.Tel),
                 AccessHelper.MakeInParam("@admins", OleDbType.VarChar, 200, u.Adminstrator)
             };
            return AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public bool CheckUser(string username)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_user where username=@username");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@username",OleDbType.VarChar,50,username)
            };
            int objValue = AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (objValue > 0)
                return false;
            else
                return true;
        }
        public DataSet GetDefaultEmailConfig()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_emailconfig where isopen=-1");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public int LoginUser(string username, string password)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_user where username=@username and password=@password");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@username", OleDbType.VarChar, 50, username),
                AccessHelper.MakeInParam("@password", OleDbType.Char, 32, Util.Md532(password))
            };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
            {
                return 0;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }
        public void LoginUserUpdateState(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set logdate=now(),logip=@logip where id=@userid");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid),
                AccessHelper.MakeInParam("@logip", OleDbType.VarChar, 15, Util.ClientIp())
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public bool DeleteUser(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("delete adv_user where id=@userid");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid)
            };
            if (AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams) > 0)
                return true;
            else
                return false;
        }
        public DataSet GetUser(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_user where id=@userid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public int EditUser(User u)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set password=@password,entname=@entname,entnote=@entnote,groupid=@groupid,address=@address,tel=@tel where id=@userid");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@password", OleDbType.Char, 32, u.Password),
                AccessHelper.MakeInParam("@entname", OleDbType.VarChar, 200, u.EntName),
                AccessHelper.MakeInParam("@entnote", OleDbType.VarChar, 800, u.EntNote),
                AccessHelper.MakeInParam("@groupid", OleDbType.Integer, 4, u.GroupId),
                AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, u.Id),
                AccessHelper.MakeInParam("@address", OleDbType.VarChar, 200, u.Address),
                AccessHelper.MakeInParam("@tel", OleDbType.VarChar, 50, u.Tel)
            };
            return AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public DataSet GetAdmins(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select admins from adv_user where id=@userid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return null;
            else
            {
                this.builder = new StringBuilder();
                this.builder.Append(string.Format("select * from adv_admins where id in ({0})", obj.ToString()));
                return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
            }
        }
        public DataSet GetAdmins()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_admins where len(adminname)>0");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetGroups()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_group");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetGroupAdmins(string admins)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id,adminname from adv_admins where id in (" + admins + ")");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public string ForgetPassword(string email)
        {
            this.builder = new StringBuilder();
            string pass = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
            builder.Append("update adv_user set password=@password where username=@email");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@password", OleDbType.Char, 32, Util.Md532(pass)),
                AccessHelper.MakeInParam("@email", OleDbType.VarChar, 50, email)
            };
            int results = AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return pass;
            else
                return null;
        }
        public void AddMenu(AdvAli.Entity.Menu menu)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_menu (menu,url,parent) values (@menu,@url,@parent)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@menu", OleDbType.VarChar, 100, menu.MenuName),
                AccessHelper.MakeInParam("@url", OleDbType.VarChar, 200, menu.Url),
                AccessHelper.MakeInParam("@parent", OleDbType.Integer, 4, menu.Parent)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public bool DeleteMenu(int menuid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("delete adv_menu where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, menuid) };
            object obj = AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            int results = AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return true;
            else
                return false;
        }
        public bool EditMenu(AdvAli.Entity.Menu menu)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_menu set menu=@menu,url=@url,parent=@parent where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@menu", OleDbType.VarChar, 100, menu.MenuName),
                AccessHelper.MakeInParam("@url", OleDbType.VarChar, 200, menu.Url),
                AccessHelper.MakeInParam("@parent", OleDbType.Integer ,4, menu.Parent),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, menu.Id)
            };
            int results = AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return true;
            else
                return false;
        }
        public DataSet GetMenus(int parent)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_menu where parent=@parent");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@parent", OleDbType.Integer, 4, parent)
            };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetUser()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_user order by id desc");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetUser(int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from adv_user");
            int i = int.Parse(AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString()).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            i = 0;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from adv_user where id not in (select top " + min + " id from adv_user order by id desc) order by id desc");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetUser(string username, int timersel, DateTime timer1, DateTime timer2, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            StringBuilder sb = new StringBuilder();
            this.builder.Append("select count(id) from adv_user where 1=1");
            if (!string.IsNullOrEmpty(username))
            {
                sb.Append(string.Format(" and username like '%{0}%'", username));
            }
            if (timersel > 0)
            {
                if (timersel == 1)
                {
                    sb.Append(" and regdate");
                }
                else
                {
                    sb.Append(" and logdate");
                }
                sb.Append(string.Format(" between '{0}' and '{1}'", timer1.ToString(), timer2.ToString()));
            }
            this.builder.Append(sb.ToString());
            int i = int.Parse(AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString()).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " a.*,b.groupname from adv_user a,adv_group b where a.id not in (select top " + min + " id from adv_user where 1=1 " + sb.ToString() + " order by id desc) " + sb.ToString() + "  and a.groupid=b.id order by a.id desc");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetTable(string tablename, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from " + tablename);
            int i = int.Parse(AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString()).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from " + tablename + " where id not in (select top " + min + " id from " + tablename + " order by id desc) order by id desc");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetTable(int userid, string tablename, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from " + tablename + " where userid=@userid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid) };
            int i = int.Parse(AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from " + tablename + " where userid=@userid and id not in (select top " + min + " id from " + tablename + " where userid=@userid order by id desc) order by id desc");
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetTable(int userid, string tablename, string fields, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from " + tablename);
            if (userid == 0)
                this.builder.Append(" where userid=@userid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid) };
            int i = int.Parse(AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " " + fields + " from " + tablename + " where 1=1");
            if (userid == 0)
                this.builder.Append(" and userid=@userid");
            this.builder.Append(" and id not in (select top " + min + " id from " + tablename + " where 1=1");
            if (userid == 0)
                this.builder.Append(" and userid=@userid");
            this.builder.Append(" order by id desc) order by id desc");
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetLogs(int userid, int siteid, string date1, string date2, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from adv_analysis where 1=1");
            if (userid > 0 && siteid == 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and getsiteid=@siteid");
            if (date1 != string.Empty || date2 != string.Empty)
                this.builder.Append(string.Format(" and (logdate between '{0} 00:00' and '{1} 23:59')", date1, date2));
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid), AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, siteid) };
            int i = int.Parse(AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from adv_analysis where 1=1");
            if (userid > 0 && siteid == 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and getsiteid=@siteid");
            if (date1 != string.Empty || date2 != string.Empty)
                this.builder.Append(string.Format(" and (logdate between '{0} 00:00' and '{1} 23:59')", date1, date2));
            this.builder.Append(" and id not in (select top " + min + " id from adv_analysis where 1=1");
            if (userid > 0 && siteid == 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and getsiteid=@siteid");
            if (date1 != string.Empty || date2 != string.Empty)
                this.builder.Append(string.Format(" and (logdate between '{0} 00:00' and '{1} 23:59')", date1, date2));
            this.builder.Append(" order by id desc) order by id desc");
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public string GetCurrentUrlName(string url)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select menu from adv_menu where url=@url");
            OleDbParameter[] sParasm = new OleDbParameter[] { AccessHelper.MakeInParam("@url", OleDbType.VarChar, 200, url.ToLower()) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParasm);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return "";
            else
                return obj.ToString();
        }
        public bool DeleteData(int id, string table)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("delete {0} where id=@id", Util.RemoveHTMLTag(table)));
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, id) };
            int results = AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results == 1)
                return true;
            else
                return false;
        }
        public bool DeleteBatch(string idlist, string table)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("delete {0} where id in ({1})", Util.RemoveHTMLTag(table), Util.RemoveHTMLTag(idlist)));
            int results = AccessHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
            if (results > 0)
                return true;
            else
                return false;
        }
        public string GetGroupAdmins(int groupid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select caption from adv_group where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, groupid) };
            return AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString();
        }
        public bool EditUserPassword(int userid, string oldpassword, string newpassword)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update from adv_user set password=@newpassword where id=@id and password=@oldpassword");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@newpassword", OleDbType.Char, 32, newpassword),
                AccessHelper.MakeInParam("@oldpassword", OleDbType.Char, 32, oldpassword),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, userid)
            };
            int results = AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return true;
            else
                return false;
        }
        public void EditUserRights(int userid, int groupid, string userrights)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set groupid=@groupid,admins=@admins where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@groupid", OleDbType.Integer, 4, groupid),
                AccessHelper.MakeInParam("@admins", OleDbType.VarChar, 1000, userrights),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, userid)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void AdminsAdd(int id, string adminname)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_admins (id,adminname) values (@id,@adminname)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, id),
                AccessHelper.MakeInParam("@adminname", OleDbType.VarChar, 100, adminname)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public int GetMaxAdminsId()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_admins order by id desc");
            object obj = AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return -100;
            else
                return int.Parse(obj.ToString());
        }
        public int GetMaxGroupsId()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_group where id<999 order by id desc");
            object obj = AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return -100;
            else
                return int.Parse(obj.ToString());
        }
        public int GroupsAdd(Group g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_group where id=@id or groupname=@groupname");
            OleDbParameter[] fParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, g.Id),
                AccessHelper.MakeInParam("@groupname", OleDbType.VarChar, 50, g.GroupName)
            };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), fParams);
            if (!object.Equals(obj, null) && !object.Equals(obj, System.DBNull.Value))
                return -1;
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_group (id,groupname,caption) values (@id,@groupname,@caption)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, g.Id),
                AccessHelper.MakeInParam("@groupname", OleDbType.VarChar, 50, g.GroupName),
                AccessHelper.MakeInParam("@caption", OleDbType.VarChar, 1000, g.Caption)
            };
            return AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public DataSet GetGroups(int id)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_group where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, id) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public void EditGroups(Group g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_group set groupname=@groupname,caption=@caption where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@groupname", OleDbType.VarChar, 40, g.GroupName),
                AccessHelper.MakeInParam("@caption", OleDbType.VarChar, 1000, g.Caption),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, g.Id)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set admins=@caption where groupid=@id");
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("UPDATE adv_menu SET sub = 1 WHERE (id IN (SELECT parent FROM adv_menu WHERE id IN (" + g.Caption + ") AND sub = 0 and parent not in (" + g.Caption + ")))");
            AccessHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
            this.builder = new StringBuilder();
            this.builder.Append("UPDATE adv_menu SET sub = 0 WHERE (id not (SELECT parent FROM adv_menu WHERE id IN (" + g.Caption + ") AND sub = 1))");
            AccessHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
        }
        #endregion
        #region 网站
        public string GetAdRang(string ranglist)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select cityname from adv_city where cityid in ({0})", ranglist));
            string rangelist = "";
            using (DataSet ds = AccessHelper.RunSqlGetDataSet(this.builder.ToString()))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        rangelist += reader["cityname"].ToString() + ",";
                    }
                }
            }
            if (rangelist.Length > 0)
                rangelist = rangelist.Substring(0, rangelist.Length - 1);
            return rangelist;
        }
        public DataSet GetCity(int proId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_city where proId=@proId");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@proId", OleDbType.Integer, 4, proId) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetProvince()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_province");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetAdType()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_adtype order by id");
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public int GuidecAdd(Guidec g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_guidec (title,link,article,articlelink) values (@title,@link,@article,@articlelink)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@title", OleDbType.VarChar, 200, g.Title),
                AccessHelper.MakeInParam("@link", OleDbType.VarChar, 200, g.Link),
                AccessHelper.MakeInParam("@article", OleDbType.VarChar, 2000, g.Article),
                AccessHelper.MakeInParam("@articlelink", OleDbType.VarChar, 2000, g.ArticleLink)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_guidec order by id desc");
            object results = AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(results, null) || object.Equals(System.DBNull.Value, results))
                return 0;
            else
                return int.Parse(results.ToString());
        }
        public int QQMsnAdd(QQMsn q)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_qqmsn (header,bottom,account,namer,notes,isqq) values (@header,@bottom,@account,@namer,@notes,@isqq)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@header", OleDbType.VarChar, 200, q.Header),
                AccessHelper.MakeInParam("@bottom", OleDbType.VarChar, 200, q.Bottom),
                AccessHelper.MakeInParam("@account", OleDbType.VarChar, 2000, q.Account),
                AccessHelper.MakeInParam("@namer", OleDbType.VarChar, 2000, q.Namer),
                AccessHelper.MakeInParam("@notes", OleDbType.VarChar, 2000, q.Notes),
                AccessHelper.MakeInParam("@isqq", OleDbType.Boolean, 1, q.IsQQ)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_qqmsn order by id desc");
            object results = AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(results, null) || object.Equals(System.DBNull.Value, results))
                return 0;
            else
                return int.Parse(results.ToString());
        }
        public int ImagesAdd(Images img)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_images (width,height,imagename,imageurl,imagelink) values (@width,@height,@imagename,@imageurl,@imagelink)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@width", OleDbType.Integer, 4, img.Width),
                AccessHelper.MakeInParam("@height", OleDbType.Integer, 4, img.Height),
                AccessHelper.MakeInParam("@imagename", OleDbType.VarChar, 2000, img.ImageName),
                AccessHelper.MakeInParam("@imageurl", OleDbType.VarChar, 2000, img.ImageUrl),
                AccessHelper.MakeInParam("@imagelink", OleDbType.VarChar, 2000, img.ImageLink)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_images order by id desc");
            object results = AccessHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(results, null) || object.Equals(System.DBNull.Value, results))
                return 0;
            else
                return int.Parse(results.ToString());
        }
        public void WebSiteAdd(Site s)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_site (userid,sitename,siteurl,sitenote,ranglist,addisplay,adid,timer,curscript) values (@userid,@sitename,@siteurl,@sitenote,@ranglist,@addisplay,@adid,getdate(),@curscript)");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, s.UserId),
                AccessHelper.MakeInParam("@sitename", OleDbType.VarChar, 100, s.SiteName),
                AccessHelper.MakeInParam("@siteurl", OleDbType.VarChar, 200, s.SiteUrl),
                AccessHelper.MakeInParam("@sitenote", OleDbType.VarChar, 1000, s.SiteNote),
                AccessHelper.MakeInParam("@ranglist", OleDbType.VarChar, 500, s.RangeList),
                AccessHelper.MakeInParam("@addisplay", OleDbType.Integer, 4, s.AdDisplay),
                AccessHelper.MakeInParam("@adid", OleDbType.Integer, 4, s.AdId),
                AccessHelper.MakeInParam("@curscript", OleDbType.VarChar, 2000, s.CurScript)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public DataSet GetWebSite(int siteId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_site where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, siteId) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetGuidec(int adId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_guidec where id=@adid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@adid", OleDbType.Integer, 4, adId) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetQQMsn(int adId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_qqmsn where id=@adid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@adid", OleDbType.Integer, 4, adId) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetImages(int adId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_images where id=@adid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@adid", OleDbType.Integer, 4, adId) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public int GetWebSiteUserId(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select userid from adv_site where id=@siteid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, siteid) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public void GuidecEdit(Guidec g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_guidec set title=@title,link=@link,article=@article,articlelink=@articlelink where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@title", OleDbType.VarChar, 200, g.Title),
                AccessHelper.MakeInParam("@link", OleDbType.VarChar, 200, g.Link),
                AccessHelper.MakeInParam("@article", OleDbType.VarChar, 2000, g.Article),
                AccessHelper.MakeInParam("@articlelink", OleDbType.VarChar, 2000, g.ArticleLink),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, g.Id)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void QQMsnEdit(QQMsn q)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_qqmsn set header=@header,bottom=@bottom,account=@account,namer=@namer,notes=@notes,isqq=@isqq where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@header", OleDbType.VarChar, 200, q.Header),
                AccessHelper.MakeInParam("@bottom", OleDbType.VarChar, 200, q.Bottom),
                AccessHelper.MakeInParam("@account", OleDbType.VarChar, 2000, q.Account),
                AccessHelper.MakeInParam("@namer", OleDbType.VarChar, 2000, q.Namer),
                AccessHelper.MakeInParam("@notes", OleDbType.VarChar, 2000, q.Notes),
                AccessHelper.MakeInParam("@isqq", OleDbType.Boolean, 1, q.IsQQ),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, q.Id)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void ImageEdit(Images i)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_images set width=@width,height=@height,imagename=@imagename,imageurl=@imageurl,imagelink=@imagelink where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@width", OleDbType.Integer, 4, i.Width),
                AccessHelper.MakeInParam("@height", OleDbType.Integer, 4, i.Height),
                AccessHelper.MakeInParam("@imagename", OleDbType.VarChar, 2000, i.ImageName),
                AccessHelper.MakeInParam("@imageurl", OleDbType.VarChar, 2000, i.ImageUrl),
                AccessHelper.MakeInParam("@imagelink", OleDbType.VarChar, 2000, i.ImageLink),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, i.Id)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void WebSiteEdit(Site s)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_site set sitename=@sitename,siteurl=@siteurl,sitenote=@sitenote,ranglist=@ranglist,addisplay=@addisplay,adid=@adid,curscript=@curscript where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@sitename", OleDbType.VarChar, 100, s.SiteName),
                AccessHelper.MakeInParam("@siteurl", OleDbType.VarChar, 200, s.SiteUrl),
                AccessHelper.MakeInParam("@sitenote", OleDbType.VarChar, 1000, s.SiteNote),
                AccessHelper.MakeInParam("@ranglist", OleDbType.VarChar, 500, s.RangeList),
                AccessHelper.MakeInParam("@addisplay", OleDbType.Integer, 4, s.AdDisplay),
                AccessHelper.MakeInParam("@adid", OleDbType.Integer, 4, s.AdId),
                AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, s.Id),
                AccessHelper.MakeInParam("@curscript", OleDbType.VarChar, 2000, s.CurScript)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void RemoveAdvert(int adtype, int id)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("delete {0} where id=@id", Common.Util.GetAdTypeTable(adtype)));
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, id) };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public int GetWebSiteId(string url)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_site where replace(siteurl,'www.','')=@url");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@url", OleDbType.VarChar, 200, url) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public bool ExistsWebSite(string url)
        {
            return this.GetWebSiteId(url) > 0 ? true : false;
        }
        public string GetScripts(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select curscript from adv_site where id=@siteid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, siteid) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return string.Empty;
            else
                return obj.ToString();
        }
        public void Activity(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_site set stats = 1 - stats where id=@id");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@id", OleDbType.Integer, 4, siteid) };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);

        }
        public bool GetSiteStats(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select stats from adv_site where id=@siteid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, siteid) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return false;
            else
                return Common.Util.ChangeStrToBool(obj.ToString());
        }
        public DataSet GetSite(int userid)
        {
            this.builder = new StringBuilder();
            if (userid != 0)
                this.builder.Append("select id,sitename from adv_site where userid=@userid");
            else
                this.builder.Append("select id,sitename from adv_site where userid<>@userid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, userid) };
            return AccessHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public void ClearLogging(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("delete adv_analysis where siteid=@siteid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, siteid) };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        #endregion
        #region 脚本
        public string GetCountry(string ip)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select ip_city from adv_ipdata where @iplong between startip and endip");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@iplong", OleDbType.BigInt, 8, Util.IP2Long(ip)) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return string.Empty;
            else
                return obj.ToString();
        }
        public int GetCityId(string country)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select cityId from adv_city where cityName=@cityName");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@cityName", OleDbType.VarChar, 50, country) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public DataSet GetWebSite(string ranglist)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select id,addisplay,adid from adv_site where (ranglist like '%${0}$%') order by id", ranglist));
            return AccessHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public int GetCitySiteId(int cityId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select siteId from adv_city where cityId=@cityId");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@cityId", OleDbType.Integer, 4, cityId) };
            return int.Parse(AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
        }
        public void UpdateCitySiteId(int cityId, int siteId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_city set siteId=@siteId where cityId=@cityId");
            OleDbParameter[] sParams = new OleDbParameter[]{
                AccessHelper.MakeInParam("@siteId", OleDbType.Integer, 4, siteId),
                AccessHelper.MakeInParam("@cityId", OleDbType.Integer, 4, cityId)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public string GetWebSiteCountryId(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select ranglist from adv_site where id=@siteid");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, siteid) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return "";
            else
                return obj.ToString();
        }
        public Citys GetAllCity()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_city");
            Citys citys = new Citys();
            DataSet set = AccessHelper.RunSqlGetDataSet(this.builder.ToString());
            if (Util.CheckDataSet(set))
            {
                foreach (DataRow reader in set.Tables[0].Rows)
                {
                    City city = new City();
                    city.Id = Util.ChangeStrToInt(reader[0].ToString());
                    city.CityName = reader[1].ToString();
                    city.ProId = Util.ChangeStrToInt(reader[2].ToString());
                    citys.Add(city);
                }
            }
            return citys;
        }
        public bool CheckAllWebSiteCity(int cityid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select ranglist from adv_site");
            DataSet ds = AccessHelper.RunSqlGetDataSet(this.builder.ToString());
            if (Common.Util.CheckDataSet(ds))
            {
                foreach (DataRow reader in ds.Tables[0].Rows)
                {
                    string[] ranglist = reader["ranglist"].ToString().Replace("$", "").Split(new char[] { ',' });
                    for (int i = 0; i < ranglist.Length; i++)
                    {
                        if (ranglist[i].ToString() == cityid.ToString())
                            return true;
                    }
                }
            }
            return false;
        }
        #endregion
        #region 访问日志
        public void AnalysisAdd(Analysis ana)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_analysis (siteid,ip,country,logdate,referrer,pageurl,pagetitle,consult,userid) values (@siteid,@ip,@country,getdate(),@referrer,@pageurl,@pagetitle,@consult,@userid)");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, ana.SiteId),
                AccessHelper.MakeInParam("@ip", OleDbType.VarChar, 15, ana.Ip),
                AccessHelper.MakeInParam("@country", OleDbType.VarChar, 100, ana.Country),
                AccessHelper.MakeInParam("@referrer", OleDbType.VarChar, 500, ana.Referrer),
                AccessHelper.MakeInParam("@pageurl", OleDbType.VarChar, 500, ana.PageUrl),
                AccessHelper.MakeInParam("@pagetitle", OleDbType.VarChar, 200, ana.PageTitle),
                AccessHelper.MakeInParam("@userid", OleDbType.Integer, 4, ana.UserId),
                AccessHelper.MakeInParam("@consult", OleDbType.Integer, 4, ana.Consult)
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void VisitAdd(Visit v)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_visit where siteid=@siteid and dates=@dates");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@dates", OleDbType.VarChar, 8, v.Dates.ToString("yyyyMMdd")),
                AccessHelper.MakeInParam("@pv", OleDbType.BigInt, 8, v.Pv),
                AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, v.SiteId),
                AccessHelper.MakeInParam("@consult", OleDbType.Integer, 4, v.Consult)
            };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
            {
                this.builder = new StringBuilder();
                this.builder.Append("insert into adv_visit (dates,pv,siteid,consult) values (@dates,@pv,@siteid,@consult)");
                AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            }
            else
            {
                this.builder = new StringBuilder();
                this.builder.Append("update adv_visit set pv=pv+1 where siteid=@siteid and dates=@dates");
                AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            }
        }
        public void VisitUpdate(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_visit set consult=consult+1 where siteid=@siteid and dates=@dates");
            OleDbParameter[] sParams = new OleDbParameter[]
            {
                AccessHelper.MakeInParam("@siteid", OleDbType.Integer, 4, siteid),
                AccessHelper.MakeInParam("@dates", OleDbType.VarChar, 8, DateTime.Now.ToString("yyyyMMdd"))
            };
            AccessHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public int GetUserIdFromWebSite(string site)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select userid from adv_site where siteurl=@site");
            OleDbParameter[] sParams = new OleDbParameter[] { AccessHelper.MakeInParam("@site", OleDbType.VarChar, 200, site) };
            object obj = AccessHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        #endregion
    }
}
*/