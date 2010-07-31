using System;
using System.Web;
using System.Data;
using System.Collections.Generic;
using System.Text;
using AdvAli.Logic;
using AdvAli.Entity;
using AdvAli.Common;
using AdvAli.Config;

namespace AdvAli.Keys
{
    public class KeyManage
    {
        /// <summary>
        /// 获取所有的搜索引擎
        /// </summary>
        public static KeySearchs GetKeySearch()
        {
            KeySearchs kss = new KeySearchs();
            using (DataSet ds = Logic.Consult.GetKeySearch())
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        KeySearch ks = new KeySearch();
                        ks.Id = Util.ConvertToInt(reader["id"].ToString());
                        ks.SName = reader["sname"].ToString();
                        ks.SUrl = reader["surl"].ToString();
                        ks.Ie = reader["ie"].ToString();
                        ks.SKey = reader["skey"].ToString();
                        kss.Add(ks);
                    }
                    return kss;
                }
            }
            return null;
        }
        public static Key GetKey(int id)
        {
            Key key = new Key();
            using (DataSet ds = Logic.Consult.GetKey(id))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    key.Id = Util.ConvertToInt(reader["id"].ToString());
                    key.Keywords = reader["keywords"].ToString();
                    key.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                    key.UserId = Util.ConvertToInt(reader["userid"].ToString());
                    key.Price = Util.ConvertToDecimal(reader["price"].ToString());
                    key.Flag = Util.ChangeStrToBool(reader["flag"].ToString());
                    return key;
                }
            }
            return null;
        }
        public static AdvAli.Entity.Keys GetKeys(int groupid)
        {
            AdvAli.Entity.Keys keys = new AdvAli.Entity.Keys();
            using (DataSet ds = Logic.Consult.GetKeys(groupid))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        Key key = new Key();
                        key.Id = Util.ConvertToInt(reader["id"].ToString());
                        key.Keywords = reader["keywords"].ToString();
                        key.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                        key.UserId = Util.ConvertToInt(reader["userid"].ToString());
                        key.Flag = Util.ChangeStrToBool(reader["flag"].ToString());
                        keys.Add(key);
                    }
                    return keys;
                }
            }
            return null;
        }
        public static DataSet GetAllKeys(string keyword, string cityid)
        {
            return Logic.Consult.GetAllKeys(keyword, cityid);
        }
        public static AdvAli.Entity.Keys GetSiteKeys(int siteid)
        {
            AdvAli.Entity.Keys keys = new AdvAli.Entity.Keys();
            using (DataSet ds = Logic.Consult.GetSiteKeys(siteid))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        Key key = new Key();
                        key.Id = Util.ConvertToInt(reader["id"].ToString());
                        key.Keywords = reader["keywords"].ToString();
                        key.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                        key.UserId = Util.ConvertToInt(reader["userid"].ToString());
                        key.Flag = Util.ChangeStrToBool(reader["flag"].ToString());
                        keys.Add(key);
                    }
                    return keys;
                }
            }
            return null;
        }
        public static AdvAli.Entity.Keys GetUserKeys(int userid)
        {
            AdvAli.Entity.Keys keys = new AdvAli.Entity.Keys();
            using (DataSet ds = Logic.Consult.GetUserKeys(userid))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        Key key = new Key();
                        key.Id = Util.ConvertToInt(reader["id"].ToString());
                        key.Keywords = reader["keywords"].ToString();
                        key.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                        key.UserId = Util.ConvertToInt(reader["userid"].ToString());
                        key.Flag = Util.ChangeStrToBool(reader["flag"].ToString());
                        keys.Add(key);
                    }
                    return keys;
                }
            }
            return null;
        }
        public static AdvAli.Entity.Keys GetAllKeys()
        {
            AdvAli.Entity.Keys keys = new AdvAli.Entity.Keys();
            using (DataSet ds = Logic.Consult.GetAllKeys())
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        Key key = new Key();
                        key.Id = Util.ConvertToInt(reader["id"].ToString());
                        key.Keywords = reader["keywords"].ToString();
                        key.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                        key.UserId = Util.ConvertToInt(reader["userid"].ToString());
                        key.Flag = Util.ChangeStrToBool(reader["flag"].ToString());
                        keys.Add(key);
                    }
                    return keys;
                }
            }
            return null;
        }
        public static KeyGroups GetKeyGroups()
        {
            KeyGroups kgs = new KeyGroups();
            using (DataSet ds = Logic.Consult.GetKeyGroups())
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        KeyGroup kg = new KeyGroup();
                        kg.Id = Util.ConvertToInt(reader["id"].ToString());
                        kg.GroupName = reader["groupname"].ToString();
                        kg.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                        kg.UserId = Util.ConvertToInt(reader["userid"].ToString());
                        kgs.Add(kg);
                    }
                    return kgs;
                }
            }
            return null;
        }
        public static KeyGroups GetKeyGroups(int userid, int siteid)
        {
            KeyGroups kgs = new KeyGroups();
            using (DataSet ds = Logic.Consult.GetKeyGroups(userid, siteid))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        KeyGroup kg = new KeyGroup();
                        kg.Id = Util.ConvertToInt(reader["id"].ToString());
                        kg.GroupName = reader["groupname"].ToString();
                        kg.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                        kg.UserId = Util.ConvertToInt(reader["userid"].ToString());
                        kgs.Add(kg);
                    }
                    return kgs;
                }
            }
            return null;
        }
        public static KeyGroup GetKeyGroup(int id)
        {
            KeyGroup kg = new KeyGroup();
            using (DataSet ds = Logic.Consult.GetKeyGroup(id))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    DataRow reader = ds.Tables[0].Rows[0];
                    kg.Id = Util.ConvertToInt(reader["id"].ToString());
                    kg.GroupName = reader["groupname"].ToString();
                    kg.SiteId = Util.ConvertToInt(reader["siteid"].ToString());
                    kg.UserId = Util.ConvertToInt(reader["userid"].ToString());
                    return kg;
                }
            }
            return null;
        }
        public static bool GetKeySite(string key, string cityid)
        {
            return Logic.Consult.GetKeySite(key, cityid);
        }

        public static string GetKeywords()
        {
            if (string.IsNullOrEmpty(Common.Util.GetPageParams("referrer")))
                return string.Empty;
            else
                return GetKeywords(Common.Util.GetPageParams("referrer"));
        }
        public static string GetKeywords(string urls)
        {
            Uri uri;
            KeySearchs kss = GetKeySearch();
            string ie = "";
            string key = string.Empty;
            try { uri = new Uri(urls); }
            catch { return string.Empty; }
            string host = uri.Host.ToLower();
            foreach (KeySearch ks in kss)
            {
                if (host.IndexOf(ks.SUrl) != -1)
                {
                    if (!string.IsNullOrEmpty(ks.Ei))
                        ie = Util.GetRequestUrl(ks.Ei, urls);
                    if (ie == "")
                        ie = ks.Ie;
                    string[] spk = ks.SKey.Split(new char[] { '|' });
                    for (int i = 0; i < spk.Length; i++)
                    {
                        key = Util.GetRequestUrl(spk[i], urls);
                        if (key.Trim().Length > 0) break;
                    }
                }
            }
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(ie))
            {
                if (ie.ToLower().IndexOf("gb") != -1)
                    ie = "gb2312";
                if (ie.ToLower().IndexOf("utf") != -1)
                    ie = "utf-8";
                key = HttpUtility.UrlDecode(key, System.Text.Encoding.GetEncoding(ie));
            }
            return key;
        }

        public static City GetCityFormSearchEngine()
        {
            string key = GetKeywords();
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
        public static City GetCityFormsSearchEngines(out int hasSearch,out string keys)
        {
            string key = GetKeywords();
            if (!string.IsNullOrEmpty(key))
            {
                foreach (City city in AdvAli.Config.Global.__Citys)
                {
                    if (key.IndexOf(city.CityName) != -1)
                    {
                        hasSearch = 2;
                        keys = key;
                        return city;
                    }
                }
                keys = key;
                hasSearch = 1;
                return null;
            }
            keys = string.Empty;
            hasSearch = 0;
            return null;
        }

        public static bool KeysAdd(Key k)
        {
            return Logic.Consult.KeyAdd(k);
        }
        public static void KeysEdit(Key k)
        {
            Logic.Consult.KeysEdit(k);
        }
        public static bool KeysGroupAdd(KeyGroup kg)
        {
            return Logic.Consult.KeysGroupAdd(kg);
        }
        public static bool KeySearchAdd(KeySearch ks)
        {
            return Logic.Consult.KeySearchAdd(ks);
        }
    }
}
