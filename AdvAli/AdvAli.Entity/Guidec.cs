using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    /// <summary>
    /// 商务通
    /// </summary>
    public class Guidec
    {
        #region private
        private int _id = 0;
        private string _title = "";
        private string _link = "";
        private string _context = "";
        private int _wordlnk = 0;
        private string _adtext1 = "";
        private string _adlink1 = "";
        private string _adtext2 = "";
        private string _adlink2 = "";
        private string _adText3 = "";
        private string _prompt = "";
        private string _tel1 = "";
        private string _tel2 = "";
        #endregion

        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 商务通标题
        /// </summary>
        public string Title { set { this._title = value; } get { return this._title; } }
        /// <summary>
        /// 商务通链接
        /// </summary>
        public string Link { set { this._link = value; } get { return this._link; } }
        /// <summary>
        /// 商务通邀请语
        /// </summary>
        public string Context { set { this._context = value; } get { return this._context; } }
        /// <summary>
        /// 商务通邀请窗口是否设置文字链接广告：是 否 
        /// </summary>
        public int WordLnk { set { this._wordlnk = value; } get { return this._wordlnk; } }
        /// <summary>
        /// 广告语一
        /// </summary>
        public string AdText1 { set { this._adtext1 = value; } get { return this._adtext1; } }
        /// <summary>
        /// 广告链接一
        /// </summary>
        public string AdLink1 { set { this._adlink1 = value; } get { return this._adlink1; } }
        /// <summary>
        /// 广告语二
        /// </summary>
        public string AdText2 { set { this._adtext2 = value; } get { return this._adtext2; } }
        /// <summary>
        /// 广告链接二
        /// </summary>
        public string AdLink2 { set { this._adlink2 = value; } get { return this._adlink2; } }
        /// <summary>
        /// 温馨提示
        /// </summary>
        public string Prompt { set { this._prompt = value; } get { return this._prompt; } }
        /// <summary>
        /// 网络咨询热线
        /// </summary>
        public string Tel1 { set { this._tel1 = value; } get { return this._tel1; } }
        /// <summary>
        /// 24小时热线
        /// </summary>
        public string Tel2 { set { this._tel2 = value; } get { return this._tel2; } }
        #endregion
    }
}
