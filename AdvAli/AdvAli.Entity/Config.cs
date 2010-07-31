using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class Config
    {
        #region private
        private string _websitename;
        private string _websitetitle;
        private string _websiteurl;
        private string _websitedomain;
        private string _websitenote;
        private string _allrights;
        private string _uploaddirectory;
        private long _maxupload;
        private string _allowupload;
        private string _meta_key;
        private string _meta_desc;
        private string _copyright;
        private bool _allowregister;
        private bool _allowlogin;
        #endregion

        #region public
        public string WebSiteName { set { this._websitename = value; } get { return this._websitename; } }
        public string WebSiteTitle { set { this._websitetitle = value; } get { return this._websitetitle; } }
        public string WebSiteUrl { set { this._websiteurl = value; } get { return this._websiteurl; } }
        public string WebSiteDomain { set { this._websitedomain = value; } get { return this._websitedomain; } }
        public string WebSiteNote { set { this._websitenote = value; } get { return this._websitenote; } }
        public string AllRights { set { this._allrights = value; } get { return this._allrights; } }
        public string UploadDirectory { set { this._uploaddirectory = value; } get { return this._uploaddirectory; } }
        public long MaxUpload { set { this._maxupload = value; } get { return this._maxupload; } }
        public string AllowUpload { set { this._allowupload = value; } get { return this._allowupload; } }
        public string Meta_Key { set { this._meta_key = value; } get { return this._meta_key; } }
        public string Meta_Desc { set { this._meta_desc = value; } get { return this._meta_desc; } }
        public string CopyRight { set { this._copyright = value; } get { return this._copyright; } }
        public bool AllowRegister { set { this._allowregister = value; } get { return this._allowregister; } }
        public bool AllowLogin { set { this._allowlogin = value; } get { return this._allowlogin; } }
        #endregion
    }
}
