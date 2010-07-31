using System;
using System.Runtime.InteropServices;
using System.Web;

namespace AdvAli.Common
{
    /// <summary>
    /// Cookie相关操作
    /// </summary>
    public class AdvAliCookie
    {
        public static void WriteUserCookie(string memberId, string domain,DateTime expires)
        {
            HttpCookie cookie = new HttpCookie("memberId");
            cookie.Expires = expires;
            cookie.HttpOnly = false;
            cookie.Value = memberId;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetCookieMemberId()
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["memberId"];
            if (HttpCookie.Equals(cookie, null))
                return null;
            else
                return cookie.Value; 
        }

        public static void RemoveCookie()
        {
            HttpCookie cookie = new HttpCookie("memberId");
            cookie.Expires = DateTime.Now.AddDays(-1);
            HttpContext.Current.Response.AppendCookie(cookie);
            HttpContext.Current.Session.RemoveAll();
            HttpContext.Current.Session.Abandon();
        }

        public static void WriteCookieValue(string cookieName, string cookieValue)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.HttpOnly = true;
            cookie.Value = cookieValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetCookieValue(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (HttpCookie.Equals(cookie, null))
                return null;
            else
                return cookie.Value;
        }
    }
}
