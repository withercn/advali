using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    /// <summary>
    /// 访问量统计
    /// </summary>
    public class Visit
    {
        #region private
        private int _id = 0;
        private DateTime _dates = DateTime.Now;
        private int _pv = 0;
        private int _siteid = 0;
        private int _consult = 0;
        #endregion
        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 日期
        /// </summary>
        public DateTime Dates { set { this._dates = value; } get { return this._dates; } }
        /// <summary>
        /// Pages Views
        /// </summary>
        public int Pv { set { this._pv = value; } get { return this._pv; } }
        /// <summary>
        /// 网站编号
        /// </summary>
        public int SiteId { set { this._siteid = value; } get { return this._siteid; } }
        /// <summary>
        /// 咨询次数
        /// </summary>
        public int Consult { set { this._consult = value; } get { return this._consult; } }
        #endregion
    }
}
