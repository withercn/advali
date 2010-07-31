using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class Key
    {
        #region private
        private int _id = 0;
        private string _keywords = "";
        private int _userid = 0;
        private int _groupid = 0;
        private int _siteid = 0;
        private decimal _price = 0;
        private bool _flag = false;
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords { set { this._keywords = value; } get { return this._keywords; } }
        /// <summary>
        /// 所属用户
        /// </summary>
        public int UserId { set { this._userid = value; } get { return this._userid; } }
        /// <summary>
        /// 关键字组编号
        /// </summary>
        public int GroupId { set { this._groupid = value; } get { return this._groupid; } }
        /// <summary>
        /// 所属网站
        /// </summary>
        public int SiteId { set { this._siteid = value; } get { return this._siteid; } }
        /// <summary>
        /// 价格
        /// </summary>
        public decimal Price { set { this._price = value; } get { return this._price; } }
        /// <summary>
        /// 是否需要关键字
        /// </summary>
        public bool Flag { set { this._flag = value; } get { return this._flag; } }
        #endregion
    }

    public class Keys : System.Collections.CollectionBase
    {
        public Key this[int index]
        {
            get { return (Key)List[index]; }
        }

        public void Add(Key k)
        {
            List.Add(k);
        }

        public void Remove(Key k)
        {
            List.Remove(k);
        }
    }
}
