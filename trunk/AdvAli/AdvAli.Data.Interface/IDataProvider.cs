using System;
using System.Data;
using AdvAli.Entity;

namespace AdvAli.Data
{
    public interface IDataProvider
    {
        /// <summary>
        /// 获取系统配置
        /// </summary>
        Entity.Config GetConfig();
        /// <summary>
        /// 更新系统配置
        /// </summary>
        void UpdateConfig(Entity.Config config);
        /// <summary>
        /// 添加账户
        /// </summary>
        /// <returns>0:失败 >0:成功</returns>
        int AddUser(User u);
        /// <summary>
        /// 检测用户是否存在
        /// </summary>
        bool CheckUser(string username);
        /// <summary>
        /// 读取默认的邮件配置
        /// </summary>
        DataSet GetDefaultEmailConfig();
        /// <summary>
        /// 用户登陆
        /// </summary>
        int LoginUser(string username, string password);
        /// <summary>
        /// 删除用户
        /// </summary>
        bool DeleteUser(int userid);
        /// <summary>
        /// 登陆后更新登陆时间
        /// </summary>
        void LoginUserUpdateState(int userid);
        /// <summary>
        /// 读取用户
        /// </summary>
        DataSet GetUser(int userid);
        /// <summary>
        /// 修改用户
        /// </summary>
        int EditUser(User u);
        /// <summary>
        /// 根据用户判断权限
        /// </summary>
        DataSet GetAdmins(int userid);
        /// <summary>
        /// 找回密码
        /// </summary>
        string ForgetPassword(string email);
        /// <summary>
        /// 添加菜单项
        /// </summary>
        void AddMenu(AdvAli.Entity.Menu menu);
        /// <summary>
        /// 删除菜单项
        /// </summary>
        bool DeleteMenu(int menuid);
        /// <summary>
        /// 修改菜单项
        /// </summary>
        bool EditMenu(AdvAli.Entity.Menu menu);
        /// <summary>
        /// 读取子菜单
        /// </summary>
        DataSet GetMenus(int parent);
        /// <summary>
        /// 读取所有用户
        /// </summary>
        DataSet GetUser();
        /// <summary>
        /// 读取所有用户(带分页)
        /// </summary>
        DataSet GetUser(int page, int pagesize, out int recordcount);
        /// <summary>
        ///  读取所有用户/查询用户 (带分页)
        /// </summary>
        DataSet GetUser(string username, int timersel, DateTime timer1, DateTime timer2, int page, int pagesize, out int recordcount);
        /// <summary>
        ///  读取/查询指定表(带分页)(管理员)
        /// </summary>
        DataSet GetTable(string tablename, int page, int pagesize, out int recordcount);
        /// <summary>
        ///  读取/查询指定表(带分页)
        /// </summary>
        DataSet GetTable(int userid, string tablename, int page, int pagesize, out int recordcount);
        /// <summary>
        /// 读取/查询指定表(带分面,指定字段)
        /// </summary>
        DataSet GetTable(int userid, string tablename, string fields, int page, int pagesize, out int recordcount);
        /// <summary>
        /// 获取当前页名称
        /// </summary>
        string GetCurrentUrlName(string url);
        /// <summary>
        /// 删除记录
        /// </summary>
        bool DeleteData(int id, string table);
        /// <summary>
        /// 同时删除多条记录
        /// </summary>
        bool DeleteBatch(string idlist, string table);
        /// <summary>
        /// 读取所有权限
        /// </summary>
        DataSet GetAdmins();
        /// <summary>
        /// 获取用户组
        /// </summary>
        DataSet GetGroups();
        /// <summary>
        /// 读取用户组权限
        /// </summary>
        string GetGroupAdmins(int groupid);
        /// <summary>
        /// 获取权限所对应的数据集
        /// </summary>
        DataSet GetGroupAdmins(string admins);
        /// <summary>
        /// 修改用户密码
        /// </summary>
        bool EditUserPassword(int userid, string oldpassword, string newpassword);
        /// <summary>
        /// 修改用户权限
        /// </summary>
        void EditUserRights(int userid, int groupid, string userrights);
        /// <summary>
        /// 增加权限项
        /// </summary>
        void AdminsAdd(int id, string adminname);
        /// <summary>
        /// 获取最大的权限编号
        /// </summary>
        int GetMaxAdminsId();
        /// <summary>
        /// 获取最大的分组编号
        /// </summary>
        int GetMaxGroupsId();
        /// <summary>
        /// 添加用户组
        /// </summary>
        int GroupsAdd(Group g);
        /// <summary>
        /// 读取组
        /// </summary>
        DataSet GetGroups(int id);
        /// <summary>
        /// 修改组
        /// </summary>
        void EditGroups(Group g);
        /// <summary>
        /// 获取广告范围
        /// </summary>
        string GetAdRang(string ranglist);
        /// <summary>
        /// 获取指定省的所有城市名
        /// </summary>
        DataSet GetCity(int proId);
        /// <summary>
        /// 获取所有省
        /// </summary>
        DataSet GetProvince();
        /// <summary>
        /// 获取广告类型
        /// </summary>
        DataSet GetAdType();
        /// <summary>
        /// 添加商务通 返回编号
        /// </summary>
        int GuidecAdd(Guidec g);
        /// <summary>
        /// 添加QQ或MSN 返回编号
        /// </summary>
        int QQMsnAdd(QQMsn q);
        /// <summary>
        /// 添加图片 返回编号
        /// </summary>
        int ImagesAdd(Images img);
        /// <summary>
        /// 添加网站
        /// </summary>
        void WebSiteAdd(Site s);
        /// <summary>
        /// 获取网站信息
        /// </summary>
        DataSet GetWebSite(int siteId);
        /// <summary>
        /// 获取商务通资料
        /// </summary>
        DataSet GetGuidec(int adId);
        /// <summary>
        /// 获取QQ或MSN资料
        /// </summary>
        DataSet GetQQMsn(int adId);
        /// <summary>
        /// 获取图片资料
        /// </summary>
        DataSet GetImages(int adId);
        /// <summary>
        /// 修改商务通
        /// </summary>
        void GuidecEdit(Guidec g);
        /// <summary>
        /// 修改QQ/Msn
        /// </summary>
        void QQMsnEdit(QQMsn q);
        /// <summary>
        /// 修改图片
        /// </summary>
        void ImageEdit(Images i);
        /// <summary>
        /// 修改网站
        /// </summary>
        void WebSiteEdit(Site s);
        /// <summary>
        /// 删除原来的广告
        /// </summary>
        void RemoveAdvert(int adtype, int id);
        /// <summary>
        /// 获取城市编号
        /// </summary>
        int GetCityId(string country);
        /// <summary>
        /// 获取所有指定地域位置的网站
        /// </summary>
        DataSet GetWebSites(string ranglist);
        /// <summary>
        /// 获取指定城市最后显示的网站编号
        /// </summary>
        int GetCitySiteId(int cityId);
        /// <summary>
        /// 获取指定关键字及地域 最后显示的网站编号
        /// </summary>
        int GetKeyCitySiteId(int cityId,string keyword);
        /// <summary>
        /// 更新指定城市的最后显示网站编号
        /// </summary>
        void UpdateCitySiteId(int cityId, int siteId);
        /// <summary>
        /// 更新指定关键字及地域 最后显示的网站编号
        /// </summary>
        void UpdateKeyCitySiteId(string keyword, int cityId, int siteId);
        /// <summary>
        /// 根据网址获取网站编号
        /// </summary>
        int GetWebSiteId(string url);
        /// <summary>
        /// 获取网站所属账户编号
        /// </summary>
        int GetWebSiteUserId(int siteid);
        /// <summary>
        /// 根据网址判断网站是否存在
        /// </summary>
        bool ExistsWebSite(string url);
        /// <summary>
        /// 获取IP所属城市
        /// </summary>
        string GetCountry(string ip);
        /// <summary>
        /// 判断网站是否包含指定的城市
        /// </summary>
        string GetWebSiteCountryId(int siteid);
        /// <summary>
        /// 添加访问日志
        /// </summary>
        void AnalysisAdd(Analysis ana);
        /// <summary>
        /// 添加访问统计
        /// </summary>
        void VisitAdd(Visit v);
        /// <summary>
        /// 更新访问统计
        /// </summary>
        void VisitUpdate(int siteid);
        /// <summary>
        /// 获取所属网站的用户编号
        /// </summary>
        int GetUserIdFromWebSite(string site);
        /// <summary>
        /// 获取网站无法访问时的脚本
        /// </summary>
        string GetScripts(int siteid);
        /// <summary>
        /// 获取所有城市
        /// </summary>
        Citys GetAllCity();
        /// <summary>
        /// 所有网站中是否包含指定的地域
        /// </summary>
        bool CheckAllWebSiteCity(int cityid);
        /// <summary>
        /// 修改网站状态
        /// </summary>
        void Activity(int siteid);
        /// <summary>
        /// 获取网站状态
        /// </summary>
        bool GetSiteStats(int siteid);
        /// <summary>
        /// 获取用户的网站
        /// </summary>
        DataSet GetSite(int userid);
        /// <summary>
        /// 获取日志数据
        /// </summary>
        DataSet GetLogs(int userid, int siteid, string date1, string date2, int page, int pagesize, out int recordcount);
        /// <summary>
        /// 获取数据统计
        /// </summary>
        DataSet GetVisits(int userid, int siteid, string date1, string date2, int page, int pagesize, out int recordcount);
        /// <summary>
        /// 反馈意见
        /// </summary>
        DataSet GetForum(int userid, int isre, bool remove, int page, int pagesize, out int recordcount);
        /// <summary>
        /// 清空指定站点的日志
        /// </summary>
        void ClearLogging(int siteid);
        /// <summary>
        /// 回复反馈意见
        /// </summary>
        void Repost(int postid, string re);
        /// <summary>
        /// 反馈意见
        /// </summary>
        void Posts(string title, string context, int userid);
        /// <summary>
        /// 将反馈意见标记为删除
        /// </summary>
        void DeletePost(string postid);
        /// <summary>
        /// 恢复删除
        /// </summary>
        void RecoverPost(string postid);
        /// <summary>
        /// 搜索引擎
        /// </summary>
        DataSet GetKeySearch();
        /// <summary>
        /// 获取单一关键字信息
        /// </summary>
        /// <returns></returns>
        DataSet GetKey(int id);
        /// <summary>
        /// 获取关键字合集,根据分组编号
        /// </summary>
        DataSet GetKeys(int groupid);
        /// <summary>
        /// 获取关键字合集
        /// </summary>
        DataSet GetKeys(int userid, int siteid, int groupid, int page, int pagesize, out int recordcount);
        /// <summary>
        /// 获取网站关键字
        /// </summary>
        DataSet GetSiteKeys(int siteid);
        /// <summary>
        /// 获取用户关键字
        /// </summary>
        DataSet GetUserKeys(int userid);
        /// <summary>
        /// 获取所有关键字
        /// </summary>
        DataSet GetAllKeys();
        /// <summary>
        /// 获取所有关键字组
        /// </summary>
        DataSet GetKeyGroups();
        /// <summary>
        /// 获取关键字组,根据用户编号和网站编号
        /// </summary>
        DataSet GetKeyGroups(int userid, int siteid);
        /// <summary>
        /// 获取指定的关键字组
        /// </summary>
        DataSet GetKeyGroup(int id);
        /// <summary>
        /// 添加关键字
        /// </summary>
        bool KeyAdd(Key k);
        /// <summary>
        /// 修改关键字
        /// </summary>
        void KeysEdit(Key k);
        /// <summary>
        /// 关键字分组合集
        /// </summary>
        DataSet GetKeysGroup(int userid, int siteid, int page, int pagesize, out int recordcount);
        /// <summary>
        /// 添加关键字分组
        /// </summary>
        bool KeysGroupAdd(KeyGroup kg);
        /// <summary>
        /// 添加搜索引擎
        /// </summary>
        bool KeySearchAdd(KeySearch ks);
        /// <summary>
        /// 根据关键词读取所有关键词信息
        /// </summary>
        DataSet GetAllKeys(string key,string cityid);
        /// <summary>
        /// 判断该关键词和地域有否有网站选择
        /// </summary>
        bool GetKeySite(string key, string cityid);
        /// <summary>
        /// 加盟网站设置第一步
        /// </summary>
        int SaveStep1(int siteid, Site site);
        /// <summary>
        /// 加盟网站设置第二步
        /// </summary>
        void SaveStep2(int siteid, Site site);
        /// <summary>
        /// 加盟网站设置第三步
        /// </summary>
        void SaveStep3(int siteid, Site site);
        /// <summary>
        /// 加盟网站调协第四步（文字商务通）
        /// </summary>
        int SaveStep41(int siteid, Site site, Guidec guidec);
    }
}
