using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class Admin
    {
        #region private
        private int _adminid;
        private string _adminaname;
        #endregion

        #region public
        public int AdminId { set { this._adminid = value; } get { return this._adminid; } }
        public string AdminName { set { this._adminaname = value; } get { return this._adminaname; } }
        #endregion
    }

    public class Admins : System.Collections.CollectionBase
    {
        public Admin this[int index]
        {
            get { return (Admin)List[index]; }
        }

        public void Add(Admin a)
        {
            List.Add(a);
        }

        public void Remove(Admin a)
        {
            List.Remove(a);
        }
    }
}
