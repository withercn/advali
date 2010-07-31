using System;


namespace AdvAli.Entity
{
    public class Pager
    {
        private string _FristPage = string.Empty;
        private string _LastPage = string.Empty;
        private string _ListPage = string.Empty;
        private string _NextPage = string.Empty;
        private int _PageCount;
        private int _PageIndex;
        private int _PageSize;
        private string _PrevPage = string.Empty;
        private int _RecordCount;

        public string FristPage
        {
            get
            {
                return this._FristPage;
            }
            set
            {
                this._FristPage = value.ToString();
            }
        }

        public string LastPage
        {
            get
            {
                return this._LastPage;
            }
            set
            {
                this._LastPage = value.ToString();
            }
        }

        public string ListPage
        {
            get
            {
                return this._ListPage;
            }
            set
            {
                this._ListPage = value.ToString();
            }
        }

        public string NextPage
        {
            get
            {
                return this._NextPage;
            }
            set
            {
                this._NextPage = value.ToString();
            }
        }

        public int PageCount
        {
            get
            {
                return this._PageCount;
            }
            set
            {
                this._PageCount = value;
            }
        }

        public int PageIndex
        {
            get
            {
                return this._PageIndex;
            }
            set
            {
                this._PageIndex = value;
            }
        }

        public int PageSize
        {
            get
            {
                return this._PageSize;
            }
            set
            {
                this._PageSize = value;
            }
        }

        public string PrevPage
        {
            get
            {
                return this._PrevPage;
            }
            set
            {
                this._PrevPage = value.ToString();
            }
        }

        public int RecordCount
        {
            get
            {
                return this._RecordCount;
            }
            set
            {
                this._RecordCount = value;
            }
        }
    }
}
