using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class QQMsn
    {
        #region private
        private int _id = 0;
        private string _header = "";
        private string _bottom = "";
        private string _account = "";
        private string _namer = "";
        private string _notes = "";
        private bool _isqq = false;
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// QQ/Msn头部信息
        /// </summary>
        public string Header { set { this._header = value; } get { return this._header; } }
        /// <summary>
        /// QQ/Msn底部信息
        /// </summary>
        public string Bottom { set { this._bottom = value; } get { return this._bottom; } }
        /// <summary>
        /// QQ/Msn账号
        /// </summary>
        public string Account { set { this._account = value; } get { return this._account; } }
        /// <summary>
        /// QQ/Msn名称
        /// </summary>
        public string Namer { set { this._namer = value; } get { return this._namer; } }
        /// <summary>
        /// QQ/Msn说明
        /// </summary>
        public string Notes { set { this._notes = value; } get { return this._notes; } }
        /// <summary>
        /// 是否QQ
        /// </summary>
        public bool IsQQ { set { this._isqq = value; } get { return this._isqq; } }
        #endregion
    }
}
