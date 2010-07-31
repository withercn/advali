using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class KeySearch
    {
        #region private
        private int _id = 0;
        private string _sname = "";
        private string _surl = "";
        private string _ie = "";
        private string _skey = "";
        private string _ei = "";
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 搜索引擎名称
        /// </summary>
        public string SName { set { this._sname = value; } get { return this._sname; } }
        /// <summary>
        /// 搜索引擎域名关键词
        /// </summary>
        public string SUrl { set { this._surl = value; } get { return this._surl; } }
        /// <summary>
        /// 搜索引擎默认编码
        /// </summary>
        public string Ie { set { this._ie = value; } get { return this._ie; } }
        /// <summary>
        /// 搜索引擎查询参数
        /// </summary>
        public string SKey { set { this._skey = value; } get { return this._skey; } }
        /// <summary>
        /// 搜索引擎编码关键词
        /// </summary>
        public string Ei { set { this._ei = value; } get { return this._ei; } }
        #endregion
    }

    public class KeySearchs : System.Collections.CollectionBase
    {
        public KeySearch this[int index]
        {
            get { return (KeySearch)List[index]; }
        }

        public void Add(KeySearch ks)
        {
            List.Add(ks);
        }

        public void Remove(KeySearch ks)
        {
            List.Remove(ks);
        }
    }
}
