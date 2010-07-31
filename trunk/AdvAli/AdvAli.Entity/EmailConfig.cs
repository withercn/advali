using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    public class EmailConfig
    {
        #region private
        private int _id;
        private string _email;
        private string _mailname;
        private string _pass;
        private string _smtpserver;
        private bool _isopen;
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 邮件账号
        /// </summary>
        public string Email { set { this._email = value; } get { return this._email; } }
        /// <summary>
        /// 邮件名称
        /// </summary>
        public string MailName { set { this._mailname = value; } get { return this._mailname; } }
        /// <summary>
        /// 密码
        /// </summary>
        public string Pass { set { this._pass = value; } get { return this._pass; } }
        /// <summary>
        /// 发件服务器
        /// </summary>
        public string SmtpServer { set { this._smtpserver = value; } get { return this._smtpserver; } }
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsOpen { set { this._isopen = value; } get { return this._isopen; } }
        #endregion
    }
}
