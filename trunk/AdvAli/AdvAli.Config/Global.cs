using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using AdvAli.Entity;
using AdvAli.Data;

namespace AdvAli.Config
{
    public class Global : HttpApplication
    {

        public static IDataProvider provider = ((IDataProvider)Controller.CreateProvider());
        public static Entity.Config config = provider.GetConfig();


        #region public
        public static string allrights = config.AllRights;
        public static string __WebSiteName = config.WebSiteName;
        public static string __WebSiteUrl = config.WebSiteUrl;
        public static string __Domain = config.WebSiteDomain;
        public static string __UploadDirectory = config.UploadDirectory;
        public static string __Title = config.WebSiteTitle;
        public static bool __AllowRegister = config.AllowRegister;
        public static bool __AllowLogin = config.AllowLogin;
        public static long __MaxUpload = config.MaxUpload;
        public static string __AllowUpload = config.AllowUpload;
        public static string __CopyRright = config.CopyRight;
        public static string __Meta_Key = config.Meta_Key;
        public static string __Meta_Desc = config.Meta_Desc;
        public static Citys __Citys = provider.GetAllCity();

        public static string AllRights
        {
            get { return allrights; }
        }
        #endregion

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
