using System;
using System.Collections.Generic;
using System.Text;

namespace AdvAli.Entity
{
    /// <summary>
    /// 图片
    /// </summary>
    public class Images
    {
        #region private
        private int _id = 0;
        private int _width = 0;
        private int _height = 0;
        private string _imagename = "";
        private string _imageurl = "";
        private string _imagelink = "";
        #endregion
        #region public
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set { this._id = value; } get { return this._id; } }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { set { this._width = value; } get { return this._width; } }
        /// <summary>
        /// 高度
        /// </summary>
        public int Height { set { this._height = value; } get { return this._height; } }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string ImageName { set { this._imagename = value; } get { return this._imagename; } }
        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageUrl { set { this._imageurl = value; } get { return this._imageurl; } }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string ImageLink { set { this._imagelink = value; } get { return this._imagelink; } }
        #endregion
    }
}
