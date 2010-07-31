using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class KeyGroup
    {
        #region private
        private int _id = 0;
        private string _groupname = "";
        private int _siteid = 0;
        private int _userid = 0;
        #endregion
        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 关键字组名称
        /// </summary>
        public string GroupName { set { this._groupname = value; } get { return this._groupname; } }
        /// <summary>
        /// 所属网站
        /// </summary>
        public int SiteId { set { this._siteid = value; } get { return this._siteid; } }
        /// <summary>
        /// 所属用户
        /// </summary>
        public int UserId { set { this._userid = value; } get { return this._userid; } }
        #endregion
    }

    public class KeyGroups : System.Collections.CollectionBase
    {
        public KeyGroup this[int index]
        {
            get { return (KeyGroup)List[index]; }
        }

        public void Add(KeyGroup kg)
        {
            List.Add(kg);
        }

        public void Remove(KeyGroup kg)
        {
            List.Remove(kg);
        }
    }
}
