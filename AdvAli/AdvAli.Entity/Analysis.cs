using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    /// <summary>
    /// 访问日志
    /// </summary>
    public class Analysis
    {
        #region private
        private int _id = 0;
        private int _siteid = 0;
        private string _ip = "0.0.0.0";
        private string _country = "";
        private string _referrer = "";
        private string _pageurl = "";
        private string _pagetitle = "";
        private int _userid = 0;
        private int _consult = 0;
        private int _getsiteid = 0;
        private string _keyword = "";
        private DateTime _logdate;
        #endregion
        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 网站编号
        /// </summary>
        public int SiteId { set { this._siteid = value; } get { return this._siteid; } }
        /// <summary>
        /// IP地址
        /// </summary>
        public string Ip { set { this._ip = value; } get { return this._ip; } }
        /// <summary>
        /// 所属城市
        /// </summary>
        public string Country { set { this._country = value; } get { return this._country; } }
        /// <summary>
        /// 来源地址
        /// </summary>
        public string Referrer { set { this._referrer = value; } get { return this._referrer; } }
        /// <summary>
        /// 受访页地址
        /// </summary>
        public string PageUrl { set { this._pageurl = value; } get { return this._pageurl; } }
        /// <summary>
        /// 受访页标题
        /// </summary>
        public string PageTitle { set { this._pagetitle = value; } get { return this._pagetitle; } }
        /// <summary>
        /// 所属用户编号
        /// </summary>
        public int UserId { set { this._userid = value; } get { return this._userid; } }
        /// <summary>
        /// 咨询量
        /// </summary>
        public int Consult { set { this._consult = value; } get { return this._consult; } }
        /// <summary>
        /// 商务通网站编号
        /// </summary>
        public int GetSiteId { set { this._getsiteid = value; } get { return this._getsiteid; } }
        /// <summary>
        /// 搜索引擎关键字
        /// </summary>
        public string Keyword { set { this._keyword = value; } get { return this._keyword; } }
        /// <summary>
        /// 日志时间
        /// </summary>
        public DateTime LogDate { set { this._logdate = value; } get { return this._logdate; } }
        #endregion
    }
}
