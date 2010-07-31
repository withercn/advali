using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    /// <summary>
    /// 用户分组
    /// </summary>
    public class Group
    {
        #region private
        private int _id;
        private string _groupname;
        private string _caption;
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 分组名称
        /// </summary>
        public string GroupName { set { this._groupname = value; } get { return this._groupname; } }
        /// <summary>
        /// 组权限
        /// </summary>
        public string Caption { set { this._caption = value; } get { return this._caption; } }
        #endregion
    }

    public class Groups : System.Collections.CollectionBase
    {
        public Group this[int index]
        {
            get { return (Group)List[index]; }
        }

        public void Add(Group g)
        {
            List.Add(g);
        }

        public void Remove(Group g)
        {
            List.Remove(g);
        }
    }
}
