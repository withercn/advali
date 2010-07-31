using System;

namespace AdvAli.Entity
{
    public class Site
    {
        #region private
        private int _id = 0;
        private int _userid = 0;
        private string _sitename = "";
        private string _siteurl = "";
        private string _sitenote = "";
        private string _rangelist = "";
        private int _addisplay = 0;
        private int _adid = 0;
        private DateTime _timer = DateTime.Now;
        private string _curscript = "";
        private string _sitedomain = "";
        private bool _stats = false;
        private int _templates = 0;
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserId { set { this._userid = value; } get { return this._userid; } }
        /// <summary>
        /// 网站名称
        /// </summary>
        public string SiteName { set { this._sitename = value; } get { return this._sitename; } }
        /// <summary>
        /// 网站域名 无需 http://
        /// </summary>
        public string SiteUrl { set { this._siteurl = value; } get { return this._siteurl; } }
        /// <summary>
        /// 网站说明
        /// </summary>
        public string SiteNote { set { this._sitenote = value; } get { return this._sitenote; } }
        /// <summary>
        /// 地域范围
        /// </summary>
        public string RangeList { set { this._rangelist = value; } get { return this._rangelist; } }
        /// <summary>
        /// 咨询显示方式
        /// </summary>
        public int AdDisplay { set { this._addisplay = value; } get { return this._addisplay; } }
        /// <summary>
        /// 广告编号
        /// </summary>
        public int AdId { set { this._adid = value; } get { return this._adid; } }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime Timer { set { this._timer = value; } get { return this._timer; } }
        /// <summary>
        /// 自定义脚本
        /// </summary>
        public string CurScript { set { this._curscript = value; } get { return this._curscript; } }
        /// <summary>
        /// 根域名
        /// </summary>
        public string SiteDomain { set { this._sitedomain = value; } get { return this._sitedomain; } }
        /// <summary>
        /// 网站启用状态
        /// </summary>
        public bool Stats { set { this._stats = value; } get { return this._stats; } }
        /// <summary>
        /// 商务通模板选择
        /// </summary>
        public int Templates 
        {
            set 
            {
                if (value > 0)
                    this._templates = value;
                else
                    this._templates = 0;
            } 
            get { return this._templates; } 
        }
        #endregion
    }
}
