using System;

namespace AdvAli.Entity
{
    /// <summary>
    /// 账户
    /// </summary>
    public class User
    {
        #region private
        private int _id = 0;
        private string _username;
        private string _password;
        private string _inc;
        private string _contact;
        private string _tel;
        private string _mobile;
        private string _fax;
        private string _qq;
        private string _msn;
        private string _address;
        private DateTime _regdate;
        private DateTime _logdate = DateTime.Now;
        private string _regip;
        private string _logip;
        private int _groupid;
        private Admins _admins = new Admins();
        private string _adminstrator;
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { get { return this._id; } set { this._id = value; } }
        /// <summary>
        /// 账户
        /// </summary>
        public string Username { get { return this._username; } set { this._username = value; } }
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get { return this._password; } set { this._password = value; } }
        /// <summary>
        /// 企业名称
        /// </summary>
        public string Inc { get { return this._inc; } set { this._inc = value; } }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Contact { get { return this._contact; } set { this._contact = value; } }
        /// <summary>
        /// 因定电话
        /// </summary>
        public string TelPhone { get { return this._tel; } set { this._tel = value; } }
        /// <summary>
        /// 移动电话
        /// </summary>
        public string Mobile { get { return this._mobile; } set { this._mobile = value; } }
        /// <summary>
        /// 传真
        /// </summary>
        public string Fax { get { return this._fax; } set { this._fax = value; } }
        /// <summary>
        /// 腾讯QQ
        /// </summary>
        public string QQ { get { return this._qq; } set { this._qq = value; } }
        /// <summary>
        /// 微软Msn
        /// </summary>
        public string Msn { get { return this._msn; } set { this._msn = value; } }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address { get { return this._address; } set { this._address = value; } }
        /// <summary>
        /// 注册时间
        /// </summary>
        public DateTime RegDate { get { return this._regdate; } set { this._regdate = value; } }
        /// <summary>
        /// 最后登陆时间
        /// </summary>
        public DateTime LogDate { get { return this._logdate; } set { this._logdate = value; } }
        /// <summary>
        /// 注册IP
        /// </summary>
        public string RegIp { get { return this._regip; } set { this._regip = value; } }
        /// <summary>
        /// 最后登陆IP
        /// </summary>
        public string LogIp { get { return this._logip; } set { this._logip = value; } }
        /// <summary>
        /// 用户组
        /// </summary>
        public int GroupId { get { return this._groupid; } set { this._groupid = value; } }
        /// <summary>
        /// 管理权限
        /// </summary>
        public Admins Admins { get { return this._admins; } set { this._admins = value; } }
        /// <summary>
        /// 管理权限
        /// </summary>
        public string Adminstrator { get { return this._adminstrator; } set { this._adminstrator = value; } }
        #endregion
    }
}
