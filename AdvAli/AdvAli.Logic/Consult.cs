using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.UI.WebControls;
using AdvAli.Data;
using AdvAli.Entity;
using AdvAli.Common;

namespace AdvAli.Logic
{
    /// <summary>
    /// 判断网站所在地域
    /// </summary>
    public enum CitySelect
    {
        /// <summary>
        /// 受访网站
        /// </summary>
        LocalDomainCity = 1,
        /// <summary>
        /// 搜索引擎包含地域的网站
        /// </summary>
        SearchEngineCity = 2,
        /// <summary>
        /// 客户来访地域的网站
        /// </summary>
        IPCity = 3,
        /// <summary>
        /// 搜索引擎，关键字判段
        /// </summary>
        SearchEngineKeyword =4
    }

    public class Consult
    {
        private static IDataProvider provider = ((IDataProvider)AdvAli.Data.Controller.CreateProvider());
        private static DataRow dr;

        public static int AddUser(User u)
        {
            return provider.AddUser(u);
        }
        public static bool CheckUser(string username)
        {
            return provider.CheckUser(username);
        }
        public static EmailConfig GetDefaultEmailConfig()
        {
            EmailConfig email = new EmailConfig();
            using (DataSet config = provider.GetDefaultEmailConfig())
            {
                if (Util.CheckDataSet(config))
                {
                    dr = config.Tables[0].Rows[0];
                    email.Id = Util.ConvertToInt(dr["id"].ToString());
                    email.Email = dr["email"].ToString();
                    email.MailName = dr["mailname"].ToString();
                    email.Pass = dr["pass"].ToString();
                    email.SmtpServer = dr["smtpserver"].ToString();
                    email.IsOpen = true;
                }
            }
            return email;
        }
        public static int LoginUser(string username, string password)
        {
            return provider.LoginUser(username, password);
        }
        public static bool DeleteUser(int userid)
        {
            return provider.DeleteUser(userid);
        }
        public static void LoginUserUpdateState(int userid)
        {
            provider.LoginUserUpdateState(userid);
        }
        public static User GetUser(int userid)
        {
            User u = new User();
            using (DataSet set = provider.GetUser(userid))
            {
                if (Util.CheckDataSet(set))
                {
                    DataRow reader = set.Tables[0].Rows[0];
                    u.Id = Util.ChangeStrToInt(reader["id"].ToString());
                    u.Username = reader["username"].ToString();
                    u.Password = reader["password"].ToString();
                    u.Inc = reader["inc"].ToString();
                    u.Contact = reader["contact"].ToString();
                    u.TelPhone = reader["tel"].ToString();
                    u.Mobile = reader["mobile"].ToString();
                    u.Fax = reader["fax"].ToString();
                    u.QQ = reader["qq"].ToString();
                    u.Msn = reader["msn"].ToString();
                    u.Address = reader["address"].ToString();
                    u.RegDate = Util.ConvertToDateTime(reader["regdate"].ToString());
                    u.RegIp = reader["regip"].ToString();
                    u.LogDate = Util.ConvertToDateTime(reader["logdate"].ToString());
                    u.LogIp = reader["logip"].ToString();
                    u.GroupId = Util.ChangeStrToInt(reader["groupid"].ToString());
                    u.Admins = Consult.GetAdmins(userid);
                }
            }
            return u;
        }
        public static int EditUser(User u)
        {
            return provider.EditUser(u);
        }
        public static DataSet GetAdmins()
        {
            return provider.GetAdmins();
        }
        public static DataSet GetGroups()
        {
            return provider.GetGroups();
        }
        public static string GetGroupAdmins(int groupid)
        {
            return provider.GetGroupAdmins(groupid);
        }
        public static Admins GetAdmins(int userid)
        {
            Admins admins = new Admins();
            using (DataSet adminset = provider.GetAdmins(userid))
            {
                if (Util.CheckDataSet(adminset))
                {
                    foreach (DataRow reader in adminset.Tables[0].Rows)
                    {
                        Admin adm = new Admin();
                        adm.AdminId = Util.ConvertToInt(reader["id"].ToString());
                        adm.AdminName = reader["adminname"].ToString();
                        admins.Add(adm);
                    }
                }
            }
            return admins;
        }
        public static Admins GetAdmins(string admin)
        {
            Admins admins = new Admins();
            using (DataSet set = provider.GetGroupAdmins(admin))
            {
                if (Util.CheckDataSet(set))
                {
                    foreach (DataRow reader in set.Tables[0].Rows)
                    {
                        Admin adm = new Admin();
                        adm.AdminId = Util.ConvertToInt(reader["id"].ToString());
                        adm.AdminName = reader["adminname"].ToString();
                        admins.Add(adm);
                    }
                }
            }
            return admins;
        }
        public static string ForgetPassword(string email)
        {
            return provider.ForgetPassword(email);
        }
        public static void AddMenu(AdvAli.Entity.Menu menu)
        {
            provider.AddMenu(menu);
        }
        public static bool DeleteMenu(int menuid)
        {
            return provider.DeleteMenu(menuid);
        }
        public static bool EditMenu(AdvAli.Entity.Menu menu)
        {
            return provider.EditMenu(menu);
        }
        public static Menus GetMenus(int parent)
        {
            Menus menus = new Menus();
            using (DataSet set = provider.GetMenus(parent))
            {
                if (Util.CheckDataSet(set))
                {
                    foreach (DataRow reader in set.Tables[0].Rows)
                    {
                        AdvAli.Entity.Menu menu = new AdvAli.Entity.Menu();
                        menu.Id = Util.ConvertToInt(reader["id"].ToString());
                        menu.MenuName = reader["menu"].ToString();
                        menu.Url = reader["url"].ToString();
                        menu.Parent = Util.ConvertToInt(reader["parent"].ToString());
                        menu.Rights = Util.ConvertToInt(reader["rights"].ToString());
                        menu.Sub = Util.ConvertToInt(reader["sub"].ToString());
                        menus.Add(menu);
                    }
                }
            }
            return menus;
        }
        public static DataSet GetUser()
        {
            return provider.GetUser();
        }
        public static DataSet GetUser(int page, int pagesize, out int recordcount)
        {
            return provider.GetUser(page, pagesize, out recordcount);
        }
        public static DataSet GetUser(string username, int timersel, DateTime timer1, DateTime timer2, int page, int pagesize, out int recordcount)
        {
            return provider.GetUser(username, timersel, timer1, timer2, page, pagesize, out recordcount);
        }
        public static DataSet GetTable(string tablename, int page, int pagesize, out int recordount)
        {
            return provider.GetTable(tablename, page, pagesize, out recordount);
        }
        public static DataSet GetTable(int userid, string tablename, int page, int pagesize, out int recordcount)
        {
            return provider.GetTable(userid, tablename, page, pagesize, out recordcount);
        }
        public static DataSet GetTable(int userid, string tablename, string fields, int page, int pagesize, out int recordcount)
        {
            return provider.GetTable(userid, tablename, fields, page, pagesize, out recordcount);
        }
        public static DataSet GetLogs(int userid, int siteid, string date1,string date2, int page, int pagesize, out int recordcount)
        {
            return provider.GetLogs(userid, siteid, date1, date2, page, pagesize, out recordcount);
        }
        public static DataSet GetVisits(int userid, int siteid, string date1, string date2, int page, int pagesize, out int recordcount)
        {
            return provider.GetVisits(userid, siteid, date1, date2, page, pagesize, out recordcount);
        }
        public static DataSet GetForum(int userid, int isre, bool remove, int page, int pagesize, out int recordcount)
        {
            return provider.GetForum(userid, isre, remove, page, pagesize, out recordcount);
        }
        public static DataSet GetKeys(int userid, int siteid, int groupid, int page, int pagesize, out int recordcount)
        {
            return provider.GetKeys(userid, siteid, groupid, page, pagesize, out recordcount);
        }
        public static DataSet GetKeysGroup(int userid, int siteid, int page, int pagesize, out int recordcount)
        {
            return provider.GetKeysGroup(userid, siteid, page, pagesize, out recordcount);
        }
        public static string GetCurrentUrlName(string url)
        {
            return provider.GetCurrentUrlName(url);
        }
        public static bool DeleteData(int id,string table)
        {
            return provider.DeleteData(id, table);
        }
        public static bool DeleteBatch(string idlist,string table)
        {
            return provider.DeleteBatch(idlist, table);
        }
        public static bool EditUserPassword(int userid, string oldpassword, string newpassword)
        {
            return provider.EditUserPassword(userid, oldpassword, newpassword);
        }
        public static void EditUserRights(int userid, int groupid, string userrights)
        {
            provider.EditUserRights(userid, groupid, userrights);
        }
        public static void AdminsAdd(int id, string adminname)
        {
            provider.AdminsAdd(id, adminname);
        }
        public static int GetMaxAdminsId()
        {
            return provider.GetMaxAdminsId();
        }
        public static int GetMaxGroupsId()
        {
            return provider.GetMaxGroupsId();
        }
        public static int GroupsAdd(Group g)
        {
            return provider.GroupsAdd(g);
        }
        public static Group GetGroups(int id)
        {
            Group g = new Group();
            using (DataSet ds = provider.GetGroups(id))
            {
                if (Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    g.Id = Util.ConvertToInt(reader["id"].ToString());
                    g.GroupName = reader["groupname"].ToString();
                    g.Caption = reader["caption"].ToString();
                }
            }
            return g;
        }
        public static void EditGroups(Group g)
        {
            provider.EditGroups(g);
        }
        public static DataSet GetWebSite()
        {
            return null;
        }
        public static string GetAdRang(string ranglist)
        {
            return provider.GetAdRang(ranglist);
        }
        public static DataSet GetCity(int proId)
        {
            return provider.GetCity(proId);
        }
        public static DataSet GetProvince()
        {
            return provider.GetProvince();
        }
        public static DataSet GetAdType()
        {
            return provider.GetAdType();
        }
        public static int GuidecAdd(Guidec g)
        {
            return  provider.GuidecAdd(g);
        }
        public static int QQMsnAdd(QQMsn q)
        {
            return  provider.QQMsnAdd(q);
        }
        public static int ImagesAdd(Images img)
        {
            return  provider.ImagesAdd(img);
        }
        public static void WebSiteAdd(Site s)
        {
            provider.WebSiteAdd(s);
        }
        public static Site GetWebSite(int siteId)
        {
            Site site = new Site();
            using (DataSet ds = provider.GetWebSite(siteId))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    site.Id = Util.ChangeStrToInt(reader["id"].ToString());
                    site.UserId = Util.ChangeStrToInt(reader["userid"].ToString());
                    site.SiteName = reader["sitename"].ToString();
                    site.SiteUrl = reader["siteurl"].ToString();
                    site.SiteNote = reader["sitenote"].ToString();
                    site.RangeList = reader["ranglist"].ToString();
                    site.AdDisplay = Util.ChangeStrToInt(reader["addisplay"].ToString());
                    site.AdId = Util.ChangeStrToInt(reader["adid"].ToString());
                    site.Timer = Util.ConvertToDateTime(reader["timer"].ToString());
                    site.CurScript = reader["curscript"].ToString();
                    site.SiteDomain = reader["sitedomain"].ToString();
                    site.Templates = Util.ConvertToInt(reader["templates"].ToString());
                }
                else
                {
                    return null;
                }
            }
            return site;
        }
        public static Guidec GetGuidec(int adId)
        {
            Guidec guidec = new Guidec();
            using (DataSet ds = provider.GetGuidec(adId))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    guidec.Id = Util.ChangeStrToInt(reader["id"].ToString());
                    guidec.Title = reader["title"].ToString();
                    guidec.Link = reader["link"].ToString();
                    guidec.Context = reader["context"].ToString();
                    guidec.WordLnk = Util.ConvertToInt(reader["wordlnk"].ToString());
                    guidec.AdText1 = reader["adtext1"].ToString();
                    guidec.AdLink1 = reader["adlink1"].ToString();
                    guidec.AdText2 = reader["adtext2"].ToString();
                    guidec.AdLink2 = reader["adlink2"].ToString();
                }
            }
            return guidec;
        }
        public static QQMsn GetQQMsn(int adId)
        {
            QQMsn qqmsn = new QQMsn();
            using (DataSet ds = provider.GetQQMsn(adId))
            {
                if (Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    qqmsn.Id = Util.ChangeStrToInt(reader["id"].ToString());
                    qqmsn.Header = reader["header"].ToString();
                    qqmsn.Bottom = reader["bottom"].ToString();
                    qqmsn.Account = reader["account"].ToString();
                    qqmsn.Namer = reader["namer"].ToString();
                    qqmsn.Notes = reader["notes"].ToString();
                    qqmsn.IsQQ = Util.ChangeStrToBool(reader["isqq"].ToString());
                }
            }
            return qqmsn;
        }
        public static Images GetImages(int adId)
        {
            Images image = new Images();
            using (DataSet ds = provider.GetImages(adId))
            {
                if (Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    image.Id = Util.ChangeStrToInt(reader["id"].ToString());
                    image.Width = Util.ChangeStrToInt(reader["width"].ToString());
                    image.Height = Util.ChangeStrToInt(reader["height"].ToString());
                    image.ImageName = reader["imagename"].ToString();
                    image.ImageUrl = reader["imageurl"].ToString();
                    image.ImageLink = reader["imagelink"].ToString();
                }
            }
            return image;
        }
        public static void GuidecEdit(Guidec g)
        {
            provider.GuidecEdit(g);
        }
        public static void QQMsnEdit(QQMsn q)
        {
            provider.QQMsnEdit(q);
        }
        public static void ImageEdit(Images i)
        {
            provider.ImageEdit(i);
        }
        public static void WebSiteEdit(Site s)
        {
            provider.WebSiteEdit(s);
        }
        public static void RemoveAdvert(int adtype, int id)
        {
            provider.RemoveAdvert(adtype, id);
        }
        public static int GetCityId(string country)
        {
            if (!string.IsNullOrEmpty(country))
            {
                return provider.GetCityId(country);
            }
            else
            {
                return 0;
            }
        }
        public static int GetAdWebSiteId(int cityId,out int adType,out int adId)
        {
            int siteId = 0;
            adType = 0;
            adId = 0;
            bool isFinded = false;
            int lastSiteId = provider.GetCitySiteId(cityId);
            using (DataSet ds = provider.GetWebSites(cityId.ToString()))
            {
                if (Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        siteId = Util.ChangeStrToInt(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["id"].ToString());
                        if (lastSiteId == siteId)
                        {
                            siteId = Util.ConvertToInt(reader["id"].ToString());
                            adType = Util.ConvertToInt(reader["addisplay"].ToString());
                            adId = Util.ConvertToInt(reader["adid"].ToString());
                            break;
                        }
                        siteId = Util.ConvertToInt(reader["id"].ToString());
                        if (lastSiteId == 0) isFinded = true;
                        adType = Util.ConvertToInt(reader["addisplay"].ToString());
                        adId = Util.ConvertToInt(reader["adid"].ToString());
                        if (isFinded)
                        {
                            break;
                        }
                        if (siteId == lastSiteId) isFinded = true;
                    }
                }
            }
            provider.UpdateCitySiteId(cityId, siteId);
            return siteId;
        }
        public static int GetAdKeyWebSiteId(string keyword, int cityId, out int adType, out int adId)
        {
            int siteId = 0;
            adType = 0;
            adId = 0;
            bool isFinded = false;
            int lastSiteId = provider.GetKeyCitySiteId(cityId, keyword);
            using (DataSet ds = provider.GetAllKeys(keyword, cityId.ToString()))
            {
                if (Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        siteId = Util.ChangeStrToInt(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["id"].ToString());
                        if (lastSiteId == siteId)
                        {
                            siteId = Util.ConvertToInt(reader["siteid"].ToString());
                            adType = Util.ConvertToInt(reader["addisplay"].ToString());
                            adId = Util.ConvertToInt(reader["adid"].ToString());
                            break;
                        }
                        siteId = Util.ConvertToInt(reader["siteid"].ToString());
                        if (lastSiteId == 0) isFinded = true;
                        adType = Util.ConvertToInt(reader["addisplay"].ToString());
                        adId = Util.ConvertToInt(reader["adid"].ToString());
                        if (isFinded)
                        {
                            break;
                        }
                        if (siteId == lastSiteId) isFinded = true;
                    }
                }
            }
            provider.UpdateKeyCitySiteId(keyword, cityId, siteId);
            return siteId;
        }
        public static int GetWebSiteId(string url)
        {
            return provider.GetWebSiteId(url);
        }
        public static bool ExistsWebSite(string url)
        {
            return provider.ExistsWebSite(url);
        }
        public static string GetCountry(string ip)
        {
            return provider.GetCountry(ip);
        }
        public static string GetWebSiteCountryId(int siteid)
        {
            return provider.GetWebSiteCountryId(siteid).Replace("$", "");
        }
        public static bool CheckAllWebSiteCity(int cityid)
        {
            return provider.CheckAllWebSiteCity(cityid);
        }
        public static void AnalysisAdd(Analysis ana)
        {
            provider.AnalysisAdd(ana);
        }
        public static void VisitAdd(Visit v)
        {
            provider.VisitAdd(v);
        }
        public static void VisitUpdate(int siteid)
        {
            provider.VisitUpdate(siteid);
        }
        public static int GetUserIdFromWebSite(string site)
        {
            return provider.GetUserIdFromWebSite(site);
        }
        public static void UpdateConfig(AdvAli.Entity.Config config)
        {
            provider.UpdateConfig(config);
        }
        public static string GetScripts(int siteid)
        {
            return provider.GetScripts(siteid);
        }
        public static int GetWebSiteUserId(int siteid)
        {
            return provider.GetWebSiteUserId(siteid);
        }
        public static string GetSite(string url)
        {
            string domain = Util.GetDomain(url);
            string[] domains = domain.Split(new char[] { '.' });
            if (domains.Length > 0)
                return domains[domains.Length - 2];
            else
                return "";
        }
        public static City GetCityFormSearchEngine()
        {
            string key = Util.GetKeywords();

            if (!string.IsNullOrEmpty(key))
            {
                foreach (City city in AdvAli.Config.Global.__Citys)
                {
                    if (key.IndexOf(city.CityName) != -1)
                    {
                        return city;
                    }
                }
            }
            return null;
        }
        public static City GetCityFormsSearchEngines(out bool hasSearch)
        {
            string key = Util.GetKeywords();
            if (key.Length > 0)
                hasSearch = true;
            else
                hasSearch = false;
            if (!string.IsNullOrEmpty(key))
            {
                foreach (City city in AdvAli.Config.Global.__Citys)
                {
                    if (key.IndexOf(city.CityName) != -1)
                    {
                        return city;
                    }
                }
            }
            return null;
        }
        public static void Activity(int siteid)
        {
            provider.Activity(siteid);
        }
        public static bool GetSiteStats(int siteid)
        {
            return provider.GetSiteStats(siteid);
        }
        public static void ClearLogging(int siteid)
        {
                provider.ClearLogging(siteid);
        }
        public static DataSet GetSite(int userid, int groupid)
        {
            if (groupid >= 8)
                return provider.GetSite(0);
            else
                return provider.GetSite(userid);
        }
        public static DataSet GetGroups(int userid, int siteid, int groupid)
        {
            if (groupid >= 8)
                return provider.GetKeyGroups(0, siteid);
            else
                return provider.GetKeyGroups(userid, siteid);
        }
        public static string GetKeywords()
        {
            return Util.GetKeywords();
        }
        public static string GetKeywords(string url)
        {
            return Util.GetKeywords(url);
        }
        public static void Repost(int postid, string re)
        {
            provider.Repost(postid, re);
        }
        public static void Posts(string title, string context, int userid)
        {
            provider.Posts(title, context, userid);
        }
        public static void DeletePost(string postid)
        {
            provider.DeletePost(postid);
        }
        public static void RecoverPost(string postid)
        {
            provider.RecoverPost(postid);
        }
        public static DataSet GetKeySearch()
        {
            return provider.GetKeySearch();
        }
        public static DataSet GetKey(int id)
        {
            return provider.GetKey(id);
        }
        public static DataSet GetKeys(int groupid)
        {
            return provider.GetKeys(groupid);
        }
        public static DataSet GetAllKeys(string key, string cityid)
        {
            return provider.GetAllKeys(key, cityid);
        }
        public static DataSet GetSiteKeys(int siteid)
        {
            return provider.GetSiteKeys(siteid);
        }
        public static DataSet GetUserKeys(int userid)
        {
            return provider.GetUserKeys(userid);
        }
        public static DataSet GetAllKeys()
        {
            return provider.GetAllKeys();
        }
        public static DataSet GetKeyGroups()
        {
            return provider.GetKeyGroups();
        }
        public static DataSet GetKeyGroups(int userid, int siteid)
        {
            return provider.GetKeyGroups(userid, siteid);
        }
        public static DataSet GetKeyGroup(int id)
        {
            return provider.GetKeyGroup(id);
        }
        public static bool KeyAdd(Key k)
        {
            return provider.KeyAdd(k);
        }
        public static void KeysEdit(Key k)
        {
            provider.KeysEdit(k);
        }
        public static bool KeysGroupAdd(KeyGroup kg)
        {
            return provider.KeysGroupAdd(kg);
        }
        public static bool KeySearchAdd(KeySearch ks)
        {
            return provider.KeySearchAdd(ks);
        }
        public static bool GetKeySite(string key, string cityid)
        {
            return provider.GetKeySite(key, cityid);
        }
        public static int SaveStep1(int siteid, Site site)
        {
            return provider.SaveStep1(siteid, site);
        }
        public static void SaveStep2(int siteid, Site site)
        {
            provider.SaveStep2(siteid, site);
        }
        public static void SaveStep3(int siteid, Site site)
        {
            provider.SaveStep3(siteid, site);
        }
        public static int SaveStep41(int siteid, Site site, Guidec guidec)
        {
            return provider.SaveStep41(siteid, site, guidec);
        }
    }
}
