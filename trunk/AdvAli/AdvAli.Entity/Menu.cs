using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class Menu
    {
        #region private
        private int _id = 0;
        private string _menuname;
        private string _url;
        private int _parent;
        private int _rights;
        private int _sub;
        #endregion

        #region public
        public int Id { set { this._id = value; } get { return this._id; } }
        public string MenuName { set { this._menuname = value; } get { return this._menuname; } }
        public string Url { set { this._url = value; } get { return this._url; } }
        public int Parent { set { this._parent = value; } get { return this._parent; } }
        public int Rights { set { this._rights = value; } get { return this._rights; } }
        public int Sub { set { this._sub = value; } get { return this._sub; } }
        #endregion
    }

    public class Menus : System.Collections.CollectionBase
    {
        public Menu this[int index]
        {
            get { return (Menu)List[index]; }
        }

        public void Add(Menu menu)
        {
            List.Add(menu);
        }

        public void Remove(Menu menu)
        {
            List.Remove(menu);
        }
    }
}
