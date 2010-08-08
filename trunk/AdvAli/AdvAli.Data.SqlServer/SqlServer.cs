using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;
using AdvAli.Entity;
using AdvAli.Common;

namespace AdvAli.Data
{
    public class SqlServer : IDataProvider
    {
        private StringBuilder builder = new StringBuilder();
        private SqlHelper helper = new SqlHelper();

        public Entity.Config GetConfig()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_config");
            Entity.Config config = new Config();
            using (DataSet ds = SqlHelper.RunSqlGetDataSet(this.builder.ToString()))
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
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@websitename", SqlDbType.VarChar, 200, config.WebSiteName),
                SqlHelper.MakeInParam("@websitetitle", SqlDbType.VarChar, 200, config.WebSiteTitle),
                SqlHelper.MakeInParam("@websiteurl", SqlDbType.VarChar, 200, config.WebSiteUrl),
                SqlHelper.MakeInParam("@websitedomain", SqlDbType.VarChar, 200, config.WebSiteDomain),
                SqlHelper.MakeInParam("@websitenote", SqlDbType.VarChar, 8000, config.WebSiteNote),
                SqlHelper.MakeInParam("@allrights", SqlDbType.VarChar, 2000, config.AllRights),
                SqlHelper.MakeInParam("@uploaddirectory", SqlDbType.VarChar, 500, config.UploadDirectory),
                SqlHelper.MakeInParam("@allowregister", SqlDbType.Bit, 1, config.AllowRegister),
                SqlHelper.MakeInParam("@allowlogin", SqlDbType.Bit, 1, config.AllowLogin),
                SqlHelper.MakeInParam("@maxupload", SqlDbType.BigInt, 8, config.MaxUpload),
                SqlHelper.MakeInParam("@allowupload", SqlDbType.VarChar, 200, config.AllowUpload),
                SqlHelper.MakeInParam("@copyright", SqlDbType.VarChar, 500, config.CopyRight),
                SqlHelper.MakeInParam("@meta_key", SqlDbType.VarChar, 200, config.Meta_Key),
                SqlHelper.MakeInParam("@meta_desc", SqlDbType.VarChar, 2000, config.Meta_Desc)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        #region 用户
        public int AddUser(User u)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_user (username,password,inc,contact,tel,mobile,fax,qq,msn,address,regdate,logdate,regip,logip,groupid,admins) values (@username,@password,@inc,@contact,@tel,@mobile,@fax,@qq,@msn,@address,@regdate,@logdate,@regip,@logip,@groupid,@admins)");
            SqlParameter[] sParams = new SqlParameter[]{
                 SqlHelper.MakeInParam("@username", SqlDbType.VarChar,200,u.Username),
                 SqlHelper.MakeInParam("@password", SqlDbType.Char,32,u.Password),
                 SqlHelper.MakeInParam("@inc",SqlDbType.VarChar, 200, u.Inc),
                 SqlHelper.MakeInParam("@contact", SqlDbType.VarChar, 50, u.Contact),
                 SqlHelper.MakeInParam("@tel", SqlDbType.VarChar, 50, u.TelPhone),
                 SqlHelper.MakeInParam("@mobile", SqlDbType.VarChar, 11, u.Mobile),
                 SqlHelper.MakeInParam("@fax", SqlDbType.VarChar, 50, u.Fax),
                 SqlHelper.MakeInParam("@qq", SqlDbType.VarChar, 50, u.QQ),
                 SqlHelper.MakeInParam("@msn", SqlDbType.VarChar, 200, u.Msn),
                 SqlHelper.MakeInParam("@address", SqlDbType.VarChar, 500, u.Address),
                 SqlHelper.MakeInParam("@regdate",SqlDbType.DateTime,8,u.RegDate),
                 SqlHelper.MakeInParam("@logdate",SqlDbType.DateTime,8,u.LogDate),
                 SqlHelper.MakeInParam("@regip",SqlDbType.VarChar,15,u.RegIp),
                 SqlHelper.MakeInParam("@logip",SqlDbType.VarChar,15,u.LogIp),
                 SqlHelper.MakeInParam("@groupid",SqlDbType.Int,4,u.GroupId),
                 SqlHelper.MakeInParam("@admins", SqlDbType.VarChar, 200, u.Adminstrator)
             };
            return SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public bool CheckUser(string username)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_user where username=@username");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@username",SqlDbType.VarChar,50,username)
            };
            object objValue = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(objValue, null) || object.Equals(System.DBNull.Value, objValue))
                return true;
            else
                return false;
        }
        public DataSet GetDefaultEmailConfig()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_emailconfig where isopen=1");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public int LoginUser(string username, string password)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_user where username=@username and password=@password and groupid>0");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@username", SqlDbType.VarChar, 50, username),
                SqlHelper.MakeInParam("@password", SqlDbType.Char, 32, Util.Md532(password))
            };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
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
            this.builder.Append("update adv_user set logdate=getdate(),logip=@logip where id=@userid");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid),
                SqlHelper.MakeInParam("@logip", SqlDbType.VarChar ,15 ,Util.ClientIp())
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public bool DeleteUser(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("delete adv_user where id=@userid");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid)
            };
            if (SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams) > 0)
                return true;
            else
                return false;
        }
        public DataSet GetUser(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_user where id=@userid");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public int EditUser(User u)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set password=@password,inc=@inc,contact=@contact,tel=@tel,mobile=@mobile,fax=@fax,qq=@qq,msn=@msn,address=@address,groupid=@groupid where id=@id");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, u.Id),
                SqlHelper.MakeInParam("@password", SqlDbType.Char, 32, u.Password),
                SqlHelper.MakeInParam("@inc", SqlDbType.VarChar, 200, u.Inc),
                SqlHelper.MakeInParam("@contact", SqlDbType.VarChar, 50, u.Contact),
                SqlHelper.MakeInParam("@tel", SqlDbType.VarChar, 50, u.TelPhone),
                SqlHelper.MakeInParam("@mobile", SqlDbType.VarChar, 11, u.Mobile),
                SqlHelper.MakeInParam("@fax", SqlDbType.VarChar, 50, u.Fax),
                SqlHelper.MakeInParam("@qq", SqlDbType.VarChar, 50, u.QQ),
                SqlHelper.MakeInParam("@msn", SqlDbType.VarChar, 200, u.Msn),
                SqlHelper.MakeInParam("@address", SqlDbType.VarChar, 500, u.Address),
                SqlHelper.MakeInParam("@groupid", SqlDbType.Int, 8, u.GroupId)
            };
            return SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public DataSet GetAdmins()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_admins where len(adminname)>0");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetGroups()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_group");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetAdmins(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select admins from adv_user where id=@userid");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return null;
            else
            {
                this.builder = new StringBuilder();
                this.builder.Append(string.Format("select * from adv_admins where id in ({0})", obj.ToString()));
                return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
            }
        }
        public DataSet GetGroupAdmins(string admins)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id,adminname from adv_admins where id in (" + admins + ")");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public string ForgetPassword(string email)
        {
            this.builder = new StringBuilder();
            string pass = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8);
            builder.Append("update adv_user set password=@password where username=@email");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@password", SqlDbType.Char, 32, Util.Md532(pass)),
                SqlHelper.MakeInParam("@email", SqlDbType.VarChar, 50, email)
            };
            int results = SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return pass;
            else
                return null;
        }
        public void AddMenu(AdvAli.Entity.Menu menu)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_menu (menu,url,parent) values (@menu,@url,@parent)");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@menu", SqlDbType.NVarChar, 50, menu.MenuName),
                SqlHelper.MakeInParam("@url", SqlDbType.VarChar, 200, menu.Url),
                SqlHelper.MakeInParam("@parent", SqlDbType.Int, 4, menu.Parent)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(),sParams);
        }
        public bool DeleteMenu(int menuid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("delete adv_menu where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, menuid) };
            int results = SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return true;
            else
                return false;
        }
        public bool EditMenu(AdvAli.Entity.Menu menu)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_menu set menu=@menu,url=@url,parent=@parent where id=@id");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@menu", SqlDbType.NVarChar, 50, menu.MenuName),
                SqlHelper.MakeInParam("@url", SqlDbType.VarChar, 200, menu.Url),
                SqlHelper.MakeInParam("@parent", SqlDbType.Int ,4, menu.Parent),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, menu.Id)
            };
            int results = SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return true;
            else
                return false;
        }
        public DataSet GetMenus(int parent)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_menu where parent=@parent and sub<>3");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@parent", SqlDbType.Int, 4, parent)
            };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetUser()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_user order by id desc");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetUser(int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from adv_user");
            int i = int.Parse(SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString()).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from adv_user where id not in (select top " + min + " id from adv_user order by id desc) order by id desc");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
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
            int i = int.Parse(SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString()).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " a.*,b.groupname from adv_user a,adv_group b where a.id not in (select top " + min + " id from adv_user where 1=1 " + sb.ToString() + " order by id desc) " + sb.ToString() + "  and a.groupid=b.id order by a.id desc");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetTable(string tablename, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from " + tablename);
            int i = int.Parse(SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString()).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from " + tablename + " where id not in (select top " + min + " id from " + tablename + " order by id desc) order by id desc");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetTable(int userid, string tablename, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from " + tablename + " where userid=@userid");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid) };
            int i = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from " + tablename + " where userid=@userid and id not in (select top " + min + " id from " + tablename + " where userid=@userid order by id desc) order by id desc");
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetTable(int userid, string tablename, string fields, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from " + tablename);
            if (userid != 0)
                this.builder.Append(" where userid=@userid");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid) };
            int i = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " " + fields + " from " + tablename + " where 1=1");
            if(userid != 0)
                this.builder.Append(" and userid=@userid");
            this.builder.Append(" and id not in (select top " + min + " id from " + tablename + " where 1=1");
            if(userid != 0)
                this.builder.Append(" and userid=@userid");
            this.builder.Append(" order by id desc) order by id desc");
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetLogs(int userid, int siteid, string date1, string date2, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from adv_analysis where 1=1 and siteid<>getsiteid");
            if (userid > 0)
                this.builder.Append(" and getsiteid in (select id from adv_site where userid=@userid)");
            if (siteid > 0)
                this.builder.Append(" and getsiteid=@siteid");
            if (date1 != string.Empty && date2 != string.Empty)
                this.builder.Append(string.Format(" and (logdate between '{0} 00:00' and '{1} 23:59')", date1, date2));
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid), SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid) };
            int i = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from adv_analysis where 1=1 and siteid<>getsiteid");
            if (userid > 0)
                this.builder.Append(" and getsiteid in (select id from adv_site where userid=@userid)");
            if (siteid > 0)
                this.builder.Append(" and getsiteid=@siteid");
            if (date1 != string.Empty && date2 != string.Empty)
                this.builder.Append(string.Format(" and (logdate between '{0} 00:00' and '{1} 23:59')", date1, date2));
            this.builder.Append(" and id not in (select top " + min + " id from adv_analysis where 1=1 and siteid<>getsiteid");
            if (userid > 0)
                this.builder.Append(" and getsiteid in (select id from adv_site where userid=@userid)");
            if (siteid > 0)
                this.builder.Append(" and getsiteid=@siteid");
            if (date1 != string.Empty && date2 != string.Empty)
                this.builder.Append(string.Format(" and (logdate between '{0} 00:00' and '{1} 23:59')", date1, date2));
            this.builder.Append(" order by id desc) order by id desc");
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetVisits(int userid, int siteid, string date1, string date2, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from adv_visit where 1=1");
            if (userid > 0)
                this.builder.Append(" and siteid in (select id from adv_site where userid=@userid)");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            if (date1 != string.Empty && date2 != string.Empty)
                this.builder.Append(string.Format(" and (dates between '{0}' and '{1}')", date1, date2));
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 8, userid),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 8, siteid)
            };
            int i = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " a.id,b.sitename,a.dates,a.pv,a.consult from adv_visit a,adv_site b where a.siteid=b.id");
            if (userid > 0)
                this.builder.Append(" and siteid in (select id from adv_site where userid=@userid)");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            if (date1 != string.Empty && date2 != string.Empty)
                this.builder.Append(string.Format(" and (dates between '{0}' and '{1}')", date1, date2));
            this.builder.Append(" and a.id not in (select top " + min + " id from adv_visit where 1=1");
            if (userid > 0)
                this.builder.Append(" and siteid in (select id from adv_site where userid=@userid)");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            if (date1 != string.Empty && date2 != string.Empty)
                this.builder.Append(string.Format(" and (dates between '{0}' and '{1}')", date1, date2));
            this.builder.Append(" order by id desc) order by a.id desc");
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetForum(int userid, int isre, bool remove, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from adv_forum where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (remove)
                this.builder.Append(" and remove=1");
            else
            {
                this.builder.Append(" and remove=0");
                this.builder.Append(" and isre=@isre");
            }
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid),
                SqlHelper.MakeInParam("@isre", SqlDbType.Int, 4, isre)
            };
            int i = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " * from adv_forum where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (remove)
                this.builder.Append(" and remove=1");
            else
            {
                this.builder.Append(" and remove=0");
                this.builder.Append(" and isre=@isre");
            }
            this.builder.Append(" and id not in (select top " + min + " id from adv_forum where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (remove)
                this.builder.Append(" and remove=1");
            else
            {
                this.builder.Append(" and remove=0");
                this.builder.Append(" and isre=@isre");
            }
            this.builder.Append(" order by id desc) order by id desc");
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public void Repost(int postid, string re)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_forum set re=@re,isre=1 where id=@postid");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@re", SqlDbType.VarChar, 8000, re),
                SqlHelper.MakeInParam("postid", SqlDbType.Int, 4, postid)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void Posts(string title, string context, int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_forum (userid,title,context,postdate,postip,isre,remove) values (@userid,@title,@context,getdate(),@ip,0,0)");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid),
                SqlHelper.MakeInParam("@title", SqlDbType.VarChar, 200, title),
                SqlHelper.MakeInParam("@context", SqlDbType.VarChar, 8000, context),
                SqlHelper.MakeInParam("@ip", SqlDbType.VarChar, 15, Util.ClientIp())
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void DeletePost(string postid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("update adv_forum set remove=1 where id in ({0})", postid));
            SqlHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
        }
        public void RecoverPost(string postid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("update adv_forum set remove=0 where id in ({0})", postid));
            SqlHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
        }
        public string GetCurrentUrlName(string url)
        {
            string urls = url;
            if (url.IndexOf("?") != -1)
                urls = url.Substring(0, url.IndexOf("?")).Replace("?", "");
            this.builder = new StringBuilder();
            this.builder.Append("select menu from adv_menu where url=@url");
            SqlParameter[] sParasm = new SqlParameter[] { SqlHelper.MakeInParam("@url", SqlDbType.VarChar, 200, urls.ToLower()) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParasm);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return "";
            else
                return obj.ToString();
        }
        public bool DeleteData(int id, string table)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("delete {0} where id=@id", Util.RemoveHTMLTag(table)));
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, id) };
            int results = SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results == 1)
                return true;
            else
                return false;
        }
        public bool DeleteBatch(string idlist, string table)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("delete {0} where id in ({1})", Util.RemoveHTMLTag(table), Util.RemoveHTMLTag(idlist)));
            int results = SqlHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
            if (results > 0)
                return true;
            else
                return false;
        }
        public string GetGroupAdmins(int groupid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select caption from adv_group where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, groupid) };
            return SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString();
        }
        public bool EditUserPassword(int userid, string oldpassword, string newpassword)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set password=@newpassword where id=@id and password=@oldpassword");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@newpassword", SqlDbType.Char, 32, newpassword),
                SqlHelper.MakeInParam("@oldpassword", SqlDbType.Char, 32, oldpassword),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, userid)
            };
            int results = SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (results > 0)
                return true;
            else
                return false;
        }
        public void EditUserRights(int userid, int groupid, string userrights)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set groupid=@groupid,admins=@admins where id=@id");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@groupid", SqlDbType.Int, 4, groupid),
                SqlHelper.MakeInParam("@admins", SqlDbType.VarChar, 1000, userrights),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, userid)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void AdminsAdd(int id, string adminname)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_admins (id,adminname) values (@id,@adminname)");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, id),
                SqlHelper.MakeInParam("@adminname", SqlDbType.NVarChar, 50, adminname)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public int GetMaxAdminsId()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_admins order by id desc");
            object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return -100;
            else
                return int.Parse(obj.ToString());
        }
        public int GetMaxGroupsId()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_group where id<999 order by id desc");
            object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return -100;
            else
                return int.Parse(obj.ToString());
        }
        public int GroupsAdd(Group g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_group where id=@id or groupname=@groupname");
            SqlParameter[] fParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, g.Id),
                SqlHelper.MakeInParam("@groupname", SqlDbType.VarChar, 50, g.GroupName)
            };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), fParams);
            if (!object.Equals(obj, null) && !object.Equals(obj, System.DBNull.Value))
                return -1;
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_group (id,groupname,caption) values (@id,@groupname,@caption)");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, g.Id),
                SqlHelper.MakeInParam("@groupname", SqlDbType.VarChar, 50, g.GroupName),
                SqlHelper.MakeInParam("@caption", SqlDbType.VarChar, 1000, g.Caption)
            };
            return SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);                
        }
        public DataSet GetGroups(int id)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_group where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, id) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public void EditGroups(Group g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_group set groupname=@groupname,caption=@caption where id=@id");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@groupname", SqlDbType.VarChar, 40, g.GroupName),
                SqlHelper.MakeInParam("@caption", SqlDbType.VarChar, 1000, g.Caption),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, g.Id)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("update adv_user set admins=@caption where groupid=@id");
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("UPDATE adv_menu SET sub = 1 WHERE (id IN (SELECT parent FROM adv_menu WHERE id IN (" + g.Caption + ") AND sub = 0 and parent not in (" + g.Caption + ")))");
            SqlHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
            this.builder = new StringBuilder();
            this.builder.Append("UPDATE adv_menu SET sub = 0 WHERE (id not (SELECT parent FROM adv_menu WHERE id IN (" + g.Caption + ") AND sub = 1))");
            SqlHelper.RunSqlReturnAffectedRowNum(this.builder.ToString());
        }
        #endregion
        #region 网站
        public string GetAdRang(string ranglist)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select cityid,cityname from adv_city where cityid in ({0})", ranglist));
            string[] list = ranglist.Split(new char[] { ',' });
            string rangelist = "";
            using (DataSet ds = SqlHelper.RunSqlGetDataSet(this.builder.ToString()))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        foreach (DataRow reader in ds.Tables[0].Rows)
                        {
                            if (list[i] == reader["cityid"].ToString())
                                rangelist += reader["cityname"].ToString() + ",";
                        }
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
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@proId", SqlDbType.Int, 4, proId) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetProvince()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_province");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetAdType()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_adtype order by id");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public int GuidecAdd(Guidec g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_guidec (title,link,article,articlelink,guideccontent) values (@title,@link,@article,@articlelink,@guideccontent)");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@title", SqlDbType.VarChar, 200, g.Title),
                SqlHelper.MakeInParam("@link", SqlDbType.VarChar, 200, g.Link),
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_guidec order by id desc");
            object results = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(results, null) || object.Equals(System.DBNull.Value, results))
                return 0;
            else
                return int.Parse(results.ToString());
        }
        public int QQMsnAdd(QQMsn q)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_qqmsn (header,bottom,account,namer,notes,isqq) values (@header,@bottom,@account,@namer,@notes,@isqq)");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@header", SqlDbType.VarChar, 200, q.Header),
                SqlHelper.MakeInParam("@bottom", SqlDbType.VarChar, 200, q.Bottom),
                SqlHelper.MakeInParam("@account", SqlDbType.VarChar, 2000, q.Account),
                SqlHelper.MakeInParam("@namer", SqlDbType.VarChar, 2000, q.Namer),
                SqlHelper.MakeInParam("@notes", SqlDbType.VarChar, 2000, q.Notes),
                SqlHelper.MakeInParam("@isqq", SqlDbType.Bit, 1, q.IsQQ)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_qqmsn order by id desc");
            object results = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(results, null) || object.Equals(System.DBNull.Value, results))
                return 0;
            else
                return int.Parse(results.ToString());
        }
        public int ImagesAdd(Images img)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_images (width,height,imagename,imageurl,imagelink) values (@width,@height,@imagename,@imageurl,@imagelink)");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@width", SqlDbType.Int, 4, img.Width),
                SqlHelper.MakeInParam("@height", SqlDbType.Int, 4, img.Height),
                SqlHelper.MakeInParam("@imagename", SqlDbType.VarChar, 2000, img.ImageName),
                SqlHelper.MakeInParam("@imageurl", SqlDbType.VarChar, 2000, img.ImageUrl),
                SqlHelper.MakeInParam("@imagelink", SqlDbType.VarChar, 2000, img.ImageLink)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 id from adv_images order by id desc");
            object results = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(results, null) || object.Equals(System.DBNull.Value, results))
                return 0;
            else
                return int.Parse(results.ToString());
        }
        public void WebSiteAdd(Site s)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_site (userid,sitename,siteurl,sitenote,ranglist,addisplay,adid,timer,curscript,sitedomain) values (@userid,@sitename,@siteurl,@sitenote,@ranglist,@addisplay,@adid,getdate(),@curscript,@sitedomain)");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, s.UserId),
                SqlHelper.MakeInParam("@sitename", SqlDbType.VarChar, 100, s.SiteName),
                SqlHelper.MakeInParam("@siteurl", SqlDbType.VarChar, 200, s.SiteUrl),
                SqlHelper.MakeInParam("@sitenote", SqlDbType.VarChar, 1000, s.SiteNote),
                SqlHelper.MakeInParam("@ranglist", SqlDbType.VarChar, 500, s.RangeList),
                SqlHelper.MakeInParam("@addisplay", SqlDbType.Int, 4, s.AdDisplay),
                SqlHelper.MakeInParam("@adid", SqlDbType.Int, 4, s.AdId),
                SqlHelper.MakeInParam("@curscript", SqlDbType.VarChar, 2000, s.CurScript),
                SqlHelper.MakeInParam("@sitedomain", SqlDbType.VarChar, 200, s.SiteDomain)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public DataSet GetWebSite(int siteId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_site where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, siteId) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetGuidec(int adId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_guidec where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, adId) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetQQMsn(int adId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_qqmsn where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, adId) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetImages(int adId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select top 1 * from adv_images where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, adId) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public int GetWebSiteUserId(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select userid from adv_site where id=@siteid");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public void GuidecEdit(Guidec g)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_guidec set title=@title,link=@link,article=@article,articlelink=@articlelink,guideccontent=@guideccontent where id=@id");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@title", SqlDbType.VarChar, 200, g.Title),
                SqlHelper.MakeInParam("@link", SqlDbType.VarChar, 200, g.Link),
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void QQMsnEdit(QQMsn q)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_qqmsn set header=@header,bottom=@bottom,account=@account,namer=@namer,notes=@notes,isqq=@isqq where id=@id");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@header", SqlDbType.VarChar, 200, q.Header),
                SqlHelper.MakeInParam("@bottom", SqlDbType.VarChar, 200, q.Bottom),
                SqlHelper.MakeInParam("@account", SqlDbType.VarChar, 2000, q.Account),
                SqlHelper.MakeInParam("@namer", SqlDbType.VarChar, 2000, q.Namer),
                SqlHelper.MakeInParam("@notes", SqlDbType.VarChar, 2000, q.Notes),
                SqlHelper.MakeInParam("@isqq", SqlDbType.Bit, 1, q.IsQQ),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, q.Id)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void ImageEdit(Images i)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_images set width=@width,height=@height,imagename=@imagename,imageurl=@imageurl,imagelink=@imagelink where id=@id");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@width", SqlDbType.Int, 4, i.Width),
                SqlHelper.MakeInParam("@height", SqlDbType.Int, 4, i.Height),
                SqlHelper.MakeInParam("@imagename", SqlDbType.VarChar, 2000, i.ImageName),
                SqlHelper.MakeInParam("@imageurl", SqlDbType.VarChar, 2000, i.ImageUrl),
                SqlHelper.MakeInParam("@imagelink", SqlDbType.VarChar, 2000, i.ImageLink),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, i.Id)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void WebSiteEdit(Site s)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_site set sitename=@sitename,siteurl=@siteurl,sitenote=@sitenote,ranglist=@ranglist,addisplay=@addisplay,adid=@adid,curscript=@curscript,sitedomain=@sitedomain where id=@id");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@sitename", SqlDbType.VarChar, 100, s.SiteName),
                SqlHelper.MakeInParam("@siteurl", SqlDbType.VarChar, 200, s.SiteUrl),
                SqlHelper.MakeInParam("@sitenote", SqlDbType.VarChar, 1000, s.SiteNote),
                SqlHelper.MakeInParam("@ranglist", SqlDbType.VarChar, 500, s.RangeList),
                SqlHelper.MakeInParam("@addisplay", SqlDbType.Int, 4, s.AdDisplay),
                SqlHelper.MakeInParam("@adid", SqlDbType.Int, 4, s.AdId),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, s.Id),
                SqlHelper.MakeInParam("@curscript", SqlDbType.VarChar, 2000, s.CurScript),
                SqlHelper.MakeInParam("@sitedomain", SqlDbType.VarChar, 200, s.SiteDomain)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void RemoveAdvert(int adtype, int id)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("delete {0} where id=@id", Common.Util.GetAdTypeTable(adtype)));
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, id) };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public int GetWebSiteId(string url)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_site where sitedomain=@url");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@url", SqlDbType.VarChar, 200, url) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(),sParams);
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
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return string.Empty;
            else
                return obj.ToString();
        }
        public void Activity(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_site set stats = 1 - stats where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, siteid) };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public bool GetSiteStats(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select stats from adv_site where id=@siteid");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
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
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public void ClearLogging(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("delete adv_analysis where siteid=@siteid");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid) };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public int SaveStep1(int siteid, Site site)
        {
            this.builder = new StringBuilder();
            if (siteid > 0)
                this.builder.Append("update adv_site set sitename=@sitename,siteurl=@siteurl,sitenote=@sitenote,curscript=@curscript,sitedomain=@sitedomain where id=@siteid");
            else
                this.builder.Append("insert into adv_site (userid,sitename,siteurl,sitenote,curscript,sitedomain) values (@userid,@sitename,@siteurl,@sitenote,@curscript,@sitedomain)");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, site.UserId),
                SqlHelper.MakeInParam("@sitename", SqlDbType.VarChar, 100, site.SiteName),
                SqlHelper.MakeInParam("@siteurl", SqlDbType.VarChar, 200, site.SiteUrl),
                SqlHelper.MakeInParam("@sitenote", SqlDbType.VarChar, 1000, site.SiteNote),
                SqlHelper.MakeInParam("@curscript", SqlDbType.VarChar, 4000, site.CurScript),
                SqlHelper.MakeInParam("@sitedomain", SqlDbType.VarChar, 200, site.SiteDomain),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            if (siteid > 0) return siteid;
            object obj = SqlHelper.RunSqlGetFirstCellValue("select top 1 id from adv_site order by id desc");
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public void SaveStep2(int siteid, Site site)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_site set ranglist=@ranglist where id=@siteid");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@ranglist", SqlDbType.VarChar, 500, site.RangeList),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void SaveStep3(int siteid, Site site)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_site set addisplay=@addisplay,templates=@templates,adid=@adid where id=@siteid");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@addisplay", SqlDbType.Int, 4, site.AdDisplay),
                SqlHelper.MakeInParam("@templates", SqlDbType.Int, 4, site.Templates),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid),
                SqlHelper.MakeInParam("@adid", SqlDbType.Int, 4, site.AdId)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public int SaveStep41(int siteid, Site site, Guidec guidec)
        {
            if (site.AdId > 0)
            {
                this.builder = new StringBuilder();
                this.builder.Append("update adv_guidec set title=@title,link=@link,context=@context,wordlnk=@wordlnk,adtext1=@adtext1,adlink1=@adlink1,adtext2=@adtext2,adlink2=@adlink2,prompt=@prompt,tel1=@tel1,tel2=@tel2 where id=@id");
                SqlParameter[] sParams = new SqlParameter[]
                {
                    SqlHelper.MakeInParam("@title", SqlDbType.VarChar, 200, guidec.Title),
                    SqlHelper.MakeInParam("@link", SqlDbType.VarChar, 200, guidec.Link),
                    SqlHelper.MakeInParam("@context", SqlDbType.VarChar, 2000, guidec.Context),
                    SqlHelper.MakeInParam("@wordlnk", SqlDbType.Int, 4, guidec.WordLnk),
                    SqlHelper.MakeInParam("adtext1", SqlDbType.VarChar, 200, guidec.AdText1),
                    SqlHelper.MakeInParam("@adlink1", SqlDbType.VarChar, 200, guidec.AdLink1),
                    SqlHelper.MakeInParam("@adtext2", SqlDbType.VarChar, 200, guidec.AdText2),
                    SqlHelper.MakeInParam("@adlink2", SqlDbType.VarChar, 200, guidec.AdLink2),
                    SqlHelper.MakeInParam("@prompt", SqlDbType.VarChar, 200, guidec.Prompt),
                    SqlHelper.MakeInParam("@tel1", SqlDbType.VarChar, 200, guidec.Tel1),
                    SqlHelper.MakeInParam("@tel2", SqlDbType.VarChar, 200, guidec.Tel2),
                    SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, guidec.Id)
                };
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
                return guidec.Id;
            }
            else
            {
                this.builder = new StringBuilder();
                this.builder.Append("insert adv_guidec (title,link,context,wordlnk,adtext1,adlink1,adtext2,adlink2,prompt,tel1,tel2) values (@title,@link,@context,@wordlnk,@adtext1,@adlink1,@adtext2,@adlink2,@prompt,@tel1,@tel2)");
                SqlParameter[] sParams = new SqlParameter[]
                {
                    SqlHelper.MakeInParam("@title", SqlDbType.VarChar, 200, guidec.Title),
                    SqlHelper.MakeInParam("@link", SqlDbType.VarChar, 200, guidec.Link),
                    SqlHelper.MakeInParam("@context", SqlDbType.VarChar, 2000, guidec.Context),
                    SqlHelper.MakeInParam("@wordlnk", SqlDbType.Int, 4, guidec.WordLnk),
                    SqlHelper.MakeInParam("adtext1", SqlDbType.VarChar, 200, guidec.AdText1),
                    SqlHelper.MakeInParam("@adlink1", SqlDbType.VarChar, 200, guidec.AdLink1),
                    SqlHelper.MakeInParam("@adtext2", SqlDbType.VarChar, 200, guidec.AdText2),
                    SqlHelper.MakeInParam("@adlink2", SqlDbType.VarChar, 200, guidec.AdLink2),
                    SqlHelper.MakeInParam("@prompt", SqlDbType.VarChar, 200, guidec.Prompt),
                    SqlHelper.MakeInParam("@tel1", SqlDbType.VarChar, 200, guidec.Tel1),
                    SqlHelper.MakeInParam("@tel2", SqlDbType.VarChar, 200, guidec.Tel2)
                };
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
                this.builder = new StringBuilder();
                this.builder.Append("select top 1 id from adv_guidec order by id desc");
                object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
                if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                    return 0;
                else
                {
                    int id = int.Parse(obj.ToString());
                    this.builder = new StringBuilder();
                    this.builder.Append("update adv_site set adid=@adid where id=@id");
                    SqlParameter[] fParams = new SqlParameter[]
                    {
                        SqlHelper.MakeInParam("@adid", SqlDbType.Int, 4, id),
                        SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, siteid)
                    };
                    SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), fParams);
                    return id;
                }
            }
        }
        public int SaveStep42(int siteid, Site site, QQMsn qqmsn)
        {
            this.builder = new StringBuilder();
            if (site.AdId > 0)
            {
                this.builder.Append("update adv_qqmsn set header=@header,bottom=@bottom,account=@account,namer=@namer,notes=@notes,isqq=@isqq where id=@id");
                SqlParameter[] sParams = new SqlParameter[]
                {
                    SqlHelper.MakeInParam("@header", SqlDbType.VarChar, 200, qqmsn.Header),
                    SqlHelper.MakeInParam("@bottom", SqlDbType.VarChar, 200, qqmsn.Bottom),
                    SqlHelper.MakeInParam("@account", SqlDbType.VarChar, 2000, qqmsn.Account),
                    SqlHelper.MakeInParam("@namer", SqlDbType.VarChar, 2000, qqmsn.Namer),
                    SqlHelper.MakeInParam("@notes", SqlDbType.VarChar, 2000, qqmsn.Notes),
                    SqlHelper.MakeInParam("@isqq", SqlDbType.Bit, 1, qqmsn.IsQQ),
                    SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, qqmsn.Id)
                };
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
                return qqmsn.Id;
            }
            else
            {
                this.builder.Append("insert into adv_qqmsn (header,bottom,account,namer,notes,isqq) values (@header,@bottom,@account,@namer,@notes,@isqq)");
                SqlParameter[] fParams = new SqlParameter[]
                {
                    SqlHelper.MakeInParam("@header", SqlDbType.VarChar, 200, qqmsn.Header),
                    SqlHelper.MakeInParam("@bottom", SqlDbType.VarChar, 200, qqmsn.Bottom),
                    SqlHelper.MakeInParam("@account", SqlDbType.VarChar, 2000, qqmsn.Account),
                    SqlHelper.MakeInParam("@namer", SqlDbType.VarChar, 2000, qqmsn.Namer),
                    SqlHelper.MakeInParam("@notes", SqlDbType.VarChar, 2000, qqmsn.Notes),
                    SqlHelper.MakeInParam("@isqq", SqlDbType.Bit, 1, qqmsn.IsQQ)
                };
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), fParams);
                this.builder = new StringBuilder();
                this.builder.Append("select top 1 id from adv_qqmsn order by id desc");
                object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
                if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                    return 0;
                else
                {
                    int id = int.Parse(obj.ToString());
                    this.builder = new StringBuilder();
                    this.builder.Append("update adv_site set adid=@adid where id=@id");
                    SqlParameter[] nParams = new SqlParameter[]
                    {
                        SqlHelper.MakeInParam("@adid", SqlDbType.Int, 4, id),
                        SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, siteid)
                    };
                    SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), nParams);
                    return id;
                }
            }
        }
        public int SaveStep44(int siteid, Site site, Images images)
        {
            this.builder = new StringBuilder();
            if (site.AdId > 0)
            {
                this.builder.Append("update adv_images set imagename=@imagename,imageurl=@imageurl,imagelink=@imagelink,width=@width,height=@height where id=@id");
                SqlParameter[] sParams = new SqlParameter[]
                {
                    SqlHelper.MakeInParam("@imagename", SqlDbType.VarChar, 2000, images.ImageName),
                    SqlHelper.MakeInParam("@imageurl", SqlDbType.VarChar, 2000, images.ImageUrl),
                    SqlHelper.MakeInParam("@imagelink", SqlDbType.VarChar, 2000, images.ImageLink),
                    SqlHelper.MakeInParam("@width", SqlDbType.Int, 4, images.Width),
                    SqlHelper.MakeInParam("@height", SqlDbType.Int, 4, images.Height),
                    SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, images.Id)
                };
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
                return images.Id;
            }
            else
            {
                this.builder.Append("insert into adv_images (imagename,imageurl,imagelink,width,height) values (@imagename,@imageurl,@imagelink,@width,@height)");
                SqlParameter[] fParams = new SqlParameter[]
                {
                    SqlHelper.MakeInParam("@imagename", SqlDbType.VarChar, 2000, images.ImageName),
                    SqlHelper.MakeInParam("@imageurl", SqlDbType.VarChar, 2000, images.ImageUrl),
                    SqlHelper.MakeInParam("@imagelink", SqlDbType.VarChar, 2000, images.ImageLink),
                    SqlHelper.MakeInParam("@width", SqlDbType.Int, 4, images.Width),
                    SqlHelper.MakeInParam("@height", SqlDbType.Int, 4, images.Height)
                };
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), fParams);
                this.builder = new StringBuilder();
                this.builder.Append("select top 1 id from adv_images order by id desc");
                object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
                if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                    return 0;
                else
                {
                    int id = int.Parse(obj.ToString());
                    this.builder = new StringBuilder();
                    this.builder.Append("update adv_site set adid=@adid where id=@id");
                    SqlParameter[] nParams = new SqlParameter[]
                    {
                        SqlHelper.MakeInParam("@adid", SqlDbType.Int, 4, id),
                        SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, siteid)
                    };
                    SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), nParams);
                    return id;
                }
            }
        }
        #endregion
        #region 脚本
        public string GetCountry(string ip)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select ip_city from adv_ipdata where @iplong between startip and endip");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@iplong", SqlDbType.BigInt, 8, Util.IP2Long(ip)) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return string.Empty;
            else
                return obj.ToString();
        }
        public int GetCityId(string country)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select top 1 cityId from adv_city where cityName like '%{0}%'", country));
            object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public DataSet GetWebSites(string ranglist)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select id,addisplay,adid from adv_site where (ranglist like '%${0}$%') and stats=1 order by id", ranglist));
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public int GetCitySiteId(int cityId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select siteId from adv_city where cityId=@cityId");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@cityId", SqlDbType.Int, 4, cityId) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, System.DBNull.Value) || object.Equals(obj, null))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public int GetKeyCitySiteId(int cityId, string keyword)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select siteid from adv_key_order where cityid=@cityid and keyword=@keyword");
            SqlParameter[] sParams = new SqlParameter[] 
            { 
                SqlHelper.MakeInParam("@cityId", SqlDbType.Int, 4, cityId),
                SqlHelper.MakeInParam("@keyword", SqlDbType.VarChar, 200, keyword)
            };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public void UpdateCitySiteId(int cityId, int siteId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_city set siteId=@siteId where cityId=@cityId");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@siteId", SqlDbType.Int, 4, siteId),
                SqlHelper.MakeInParam("@cityId", SqlDbType.Int, 4, cityId)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public void UpdateKeyCitySiteId(string keyword, int cityId, int siteId)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_key_order set siteid=@siteid where cityid=@cityid and keyword=@keyword");
            SqlParameter[] sParams1 = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteId),
                SqlHelper.MakeInParam("@cityid", SqlDbType.Int, 4, cityId),
                SqlHelper.MakeInParam("@keyword", SqlDbType.VarChar, 200, keyword)
            };
            SqlParameter[] sParams2 = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteId),
                SqlHelper.MakeInParam("@cityid", SqlDbType.Int, 4, cityId),
                SqlHelper.MakeInParam("@keyword", SqlDbType.VarChar, 200, keyword)
            };
            int result = SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams1);
            if (result > 0)
                return;
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_key_order (keyword,siteid,cityid) values (@keyword,@siteid,@cityid)");
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams2);
        }
        public string GetWebSiteCountryId(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select ranglist from adv_site where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, siteid) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
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
            using (DataSet set = SqlHelper.RunSqlGetDataSet(this.builder.ToString()))
            {
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
            }
            return citys;
        }
        public bool CheckAllWebSiteCity(int cityid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select ranglist from adv_site");
            using (DataSet ds = SqlHelper.RunSqlGetDataSet(this.builder.ToString()))
            {
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
            }
            return false;
        }
        #endregion
        #region 访问日志
        public void AnalysisAdd(Analysis ana)
        {
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_analysis (siteid,ip,country,logdate,referrer,pageurl,pagetitle,userid,getsiteid,keyword) values (@siteid,@ip,@country,getdate(),@referrer,@pageurl,@pagetitle,@userid,@getsiteid,@keyword)");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, ana.SiteId),
                SqlHelper.MakeInParam("@ip", SqlDbType.VarChar, 15, ana.Ip),
                SqlHelper.MakeInParam("@country", SqlDbType.VarChar, 100, ana.Country),
                SqlHelper.MakeInParam("@referrer", SqlDbType.VarChar, 4000, ana.Referrer),
                SqlHelper.MakeInParam("@pageurl", SqlDbType.VarChar, 4000, ana.PageUrl),
                SqlHelper.MakeInParam("@pagetitle", SqlDbType.VarChar, 200, ana.PageTitle),
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, ana.UserId),
                SqlHelper.MakeInParam("@getsiteid", SqlDbType.Int,4, ana.GetSiteId),
                SqlHelper.MakeInParam("@keyword", SqlDbType.VarChar, 50, ana.Keyword)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            this.VisitUpdate(ana.GetSiteId);
        }
        public void VisitAdd(Visit v)
        {
            StringBuilder builder1 = new StringBuilder();
            builder1 = new StringBuilder("select id from adv_visit where siteid=@siteid and dates=@dates");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@dates", SqlDbType.VarChar, 8, v.Dates.ToString("yyyyMMdd")),
                SqlHelper.MakeInParam("@pv", SqlDbType.BigInt, 8, v.Pv),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, v.SiteId),
                SqlHelper.MakeInParam("@consult", SqlDbType.Int, 4, v.Consult)
            };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(builder1.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
            {
                StringBuilder builder2 = new StringBuilder("insert into adv_visit (dates,pv,siteid,consult) values (@dates,@pv,@siteid,@consult)");
                SqlHelper.RunParamedSqlReturnAffectedRowNum(builder2.ToString(), sParams);
            }
            else
            {
                StringBuilder builder3 = new StringBuilder("update adv_visit set pv=pv+1 where siteid=@siteid and dates=@dates");
                SqlHelper.RunParamedSqlReturnAffectedRowNum(builder3.ToString(), sParams);
            }
        }
        public void VisitUpdate(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select id from adv_visit where siteid=@siteid and dates=@dates");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid),
                SqlHelper.MakeInParam("@dates", SqlDbType.VarChar, 8, DateTime.Now.ToString("yyyyMMdd"))
            };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            this.builder = new StringBuilder();
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
            {
                this.builder.Append("insert into adv_visit (dates,pv,siteid,consult) values (@dates,1,@siteid,1)");
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            }
            else
            {
                this.builder.Append("update adv_visit set consult=consult+1 where siteid=@siteid and dates=@dates");
                SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            }
        }
        public int GetUserIdFromWebSite(string site)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select userid from adv_site where siteurl=@site");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@site", SqlDbType.VarChar, 200, site) };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        #endregion
        #region 关键字相关
        public DataSet GetKeySearch()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_key_search order by id desc");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetKey(int id)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, id) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetKeys(int groupid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys where groupid=@groupid order by id desc");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@groupid", SqlDbType.Int, 4, groupid) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetAllKeys(string key,string cityid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select a.id as kid,b.id as siteid,b.* from adv_keys a,adv_site b where keywords=@key and a.siteid=b.id and  (ranglist like '%${0}$%') and stats=1", cityid));
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@key", SqlDbType.VarChar, 200, key) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetSiteKeys(int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys where siteid=@siteid order by id desc");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetUserKeys(int userid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys where userid=@userid order by id desc");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetAllKeys()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys order by id desc");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetKeyGroups()
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys_group order by id desc");
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetKeyGroups(int userid, int siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys_group where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            SqlParameter[] sParams = new SqlParameter[]{
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid)
            };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetKeyGroup(int id)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select * from adv_keys_group where id=@id");
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, id) };
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public DataSet GetKeys(int userid, int siteid, int groupid, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from adv_keys where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            if (groupid > 0)
                this.builder.Append(" and groupid=@groupid");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, siteid),
                SqlHelper.MakeInParam("@groupid", SqlDbType.Int, 4, groupid)
            };
            int i = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + "  a.id,a.keywords,a.userid,a.flag,b.groupname,c.sitename,a.price from adv_keys a,adv_keys_group b,adv_site c where 1=1");
            if (userid > 0)
                this.builder.Append(" and a.userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and a.siteid=@siteid");
            if (groupid > 0)
                this.builder.Append(" and a.groupid=@groupid");
            this.builder.Append(" and a.id not in (select top " + min + " id from adv_keys where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            if (groupid > 0)
                this.builder.Append(" and groupid=@groupid");
            this.builder.Append(" order by id desc) and a.siteid=c.id and a.groupid=b.id order by a.id desc");
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public bool KeyAdd(Key k)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from adv_keys where keywords=@keywords and siteid=@siteid and groupid=@groupid and flag=@flag");
            SqlParameter[] fParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@keywords", SqlDbType.VarChar, 200, k.Keywords),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, k.SiteId),
                SqlHelper.MakeInParam("@groupid", SqlDbType.Int, 4, k.GroupId),
                SqlHelper.MakeInParam("@flag", SqlDbType.Bit, 1, k.Flag)
            };
            int count = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), fParams).ToString());
            if (count > 0)
                return false;
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_keys (keywords,userid,groupid,siteid,price,flag) values (@keywords,@userid,@groupid,@siteid,@price,@flag)");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@keywords", SqlDbType.VarChar, 200, k.Keywords),
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, k.UserId),
                SqlHelper.MakeInParam("@groupid", SqlDbType.Int, 4, k.GroupId),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, k.SiteId),
                SqlHelper.MakeInParam("@price", SqlDbType.Money, 8, k.Price),
                SqlHelper.MakeInParam("@flag", SqlDbType.Bit, 1, k.Flag)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            return true;
        }
        public void KeysEdit(Key k)
        {
            this.builder = new StringBuilder();
            this.builder.Append("update adv_keys set keywords=@keywords,groupid=@groupid,siteid=@siteid,price=@price,flag=@flag where id=@id");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@keywords", SqlDbType.VarChar, 200, k.Keywords),
                SqlHelper.MakeInParam("@groupid", SqlDbType.Int, 4, k.GroupId),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, k.SiteId),
                SqlHelper.MakeInParam("@price", SqlDbType.Money, 4, k.Price),
                SqlHelper.MakeInParam("@id", SqlDbType.Int, 4, k.Id),
                SqlHelper.MakeInParam("@flag", SqlDbType.Bit, 1, k.Flag)
            };
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
        }
        public DataSet GetKeysGroup(int userid, int siteid, int page, int pagesize, out int recordcount)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from adv_keys_group where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, userid),
                SqlHelper.MakeInParam("siteid", SqlDbType.Int, 4, siteid)
            };
            int i = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            int min = (page - 1) * pagesize;
            recordcount = i;
            this.builder = new StringBuilder();
            this.builder.Append("select top " + pagesize.ToString() + " a.id,a.groupname,b.sitename from adv_keys_group a,adv_site b where 1=1");
            if (userid > 0)
                this.builder.Append(" and a.userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and a.siteid=@siteid");
            this.builder.Append(" and a.id not in (select top " + min + " id from adv_keys_group where 1=1");
            if (userid > 0)
                this.builder.Append(" and userid=@userid");
            if (siteid > 0)
                this.builder.Append(" and siteid=@siteid");
            this.builder.Append(" order by id desc) and a.siteid=b.id order by a.id desc");
            return SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams);
        }
        public bool KeysGroupAdd(KeyGroup kg)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(*) from adv_keys_group where groupname=@groupname and siteid=@siteid");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@groupname", SqlDbType.VarChar, 1000, kg.GroupName),
                SqlHelper.MakeInParam("@siteid", SqlDbType.Int, 4, kg.SiteId),
                SqlHelper.MakeInParam("@userid", SqlDbType.Int, 4, kg.UserId)
            };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            int count = int.Parse(obj.ToString());
            if (count > 0)
                return false;
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_keys_group (groupname,siteid,userid) values (@groupname,@siteid,@userid)");
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            return true;
        }
        public bool KeySearchAdd(KeySearch ks)
        {
            this.builder = new StringBuilder();
            this.builder.Append("select count(id) from adv_key_search where surl=@surl");
            SqlParameter[] sParams = new SqlParameter[]
            {
                SqlHelper.MakeInParam("@sname", SqlDbType.VarChar, 200, ks.SName),
                SqlHelper.MakeInParam("@surl", SqlDbType.VarChar, 200, ks.SUrl),
                SqlHelper.MakeInParam("@ie", SqlDbType.VarChar, 50, ks.Ie),
                SqlHelper.MakeInParam("@skey", SqlDbType.VarChar, 200, ks.SKey),
                SqlHelper.MakeInParam("@ei", SqlDbType.VarChar, 50, ks.Ei)
            };
            object obj = SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams);
            int count = int.Parse(obj.ToString());
            if (count > 0)
                return false;
            this.builder = new StringBuilder();
            this.builder.Append("insert into adv_key_search (sname,surl,ie,skey,ei) values (@sname,@surl,@ie,@skey,@ei)");
            SqlHelper.RunParamedSqlReturnAffectedRowNum(this.builder.ToString(), sParams);
            return true;
        }
        public bool GetKeySite(string key, string cityid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select count(*) from adv_keys a,adv_site b where keywords=@key and a.siteid=b.id and  (ranglist like '%${0}$%') and stats=1", cityid));
            SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@key", SqlDbType.VarChar, 200, key) };
            int count = int.Parse(SqlHelper.RunParamedSqlGetFirstCellValue(this.builder.ToString(), sParams).ToString());
            if (count > 0)
                return true;
            else
                return false;
        }
        #endregion
        #region 比例分配
        public int GetAllProportion(string siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select count(*) from adv_analysis where datediff(dd,logdate,getdate())=1 and siteid in ({0})", siteid));
            object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public int GetAllTodayCount(string siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select count(*) from adv_analysis where datediff(dd,logdate,getdate())=0 and getsiteid in ({0})", siteid));
            object obj = SqlHelper.RunSqlGetFirstCellValue(this.builder.ToString());
            if (object.Equals(obj, null) || object.Equals(obj, System.DBNull.Value))
                return 0;
            else
                return int.Parse(obj.ToString());
        }
        public DataSet GetProportion(string siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select siteid,count(id) as results from adv_analysis where datediff(dd,logdate,getdate())=1 and siteid in ({0}) group by siteid", siteid));
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetTodayProportion(string siteid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select siteid,count(id) as results from adv_analysis where datediff(dd,logdate,getdate())=0 and getsiteid in ({0}) group by siteid", siteid));
            return SqlHelper.RunSqlGetDataSet(this.builder.ToString());
        }
        public DataSet GetKeyProportion(string keywords, string cityid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select id from adv_site where ranglist like '%${0}$%' and stats=1", cityid));
            using (DataSet ds = SqlHelper.RunSqlGetDataSet(this.builder.ToString()))
            {
                if (Util.CheckDataSet(ds))
                {
                    string siteid = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i < ds.Tables[0].Rows.Count - 1)
                            siteid += ds.Tables[0].Rows[i]["id"].ToString() + ",";
                        else
                            siteid += ds.Tables[0].Rows[i]["id"].ToString();
                    }
                    this.builder = new StringBuilder();
                    this.builder.Append(string.Format("select siteid from adv_keys where siteid in ({0}) and keywords=@keywords", siteid));
                    SqlParameter[] sParams = new SqlParameter[] { SqlHelper.MakeInParam("@keywords", SqlDbType.VarChar, 200, keywords) };
                    using (DataSet set = SqlHelper.RunParamedSqlGetDataSet(this.builder.ToString(), sParams))
                    {
                        if (Util.CheckDataSet(set))
                            return set;
                        else
                            return ds;
                    }
                }
                return null;
            }
        }
        public string GetProportions(string cityid)
        {
            this.builder = new StringBuilder();
            this.builder.Append(string.Format("select id from adv_site where ranglist like '%${0}$%' and stats=1", cityid));
            using (DataSet ds = SqlHelper.RunSqlGetDataSet(this.builder.ToString()))
            {
                if (Util.CheckDataSet(ds))
                {
                    string siteid = "";
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        if (i < ds.Tables[0].Rows.Count - 1)
                            siteid += ds.Tables[0].Rows[i]["id"].ToString() + ",";
                        else
                            siteid += ds.Tables[0].Rows[i]["id"].ToString();
                    }
                    return siteid;
                }
                return string.Empty;
            }
        }
        public string GetKeyProportions(string keywords, string cityid)
        {
            using (DataSet ds = GetKeyProportion(keywords, cityid))
            {
                string siteid = string.Empty;
                if (Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        siteid += reader[0].ToString() + ",";
                    }
                    if (siteid.Length > 0) siteid = siteid.Substring(0, siteid.Length - 1);
                }
                return siteid;
            }
        }
        public string GetKeyProportions(DataSet ds)
        {
            string siteid = string.Empty;
            if (Util.CheckDataSet(ds))
            {
                foreach (DataRow reader in ds.Tables[0].Rows)
                {
                    siteid += reader[0].ToString() + ",";
                }
                if (siteid.Length > 0) siteid = siteid.Substring(0, siteid.Length - 1);
            }
            return siteid;
        }
        #endregion
    }
}
