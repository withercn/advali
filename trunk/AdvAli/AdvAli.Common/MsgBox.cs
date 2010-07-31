using System;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.UI;

namespace AdvAli.Common
{
    public class MsgBox
    {
        public static void Alert(string message)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered("script"))
            {
                handler.ClientScript.RegisterStartupScript(handler.GetType(), "script", string.Format("alert('{0}');history.go(-1);", message), true);
            }
        }

        public static void AlertB(string message)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered("script"))
            {
                handler.ClientScript.RegisterStartupScript(handler.GetType(), "script", string.Format("alert('{0}');", message), true);
            }
        }

        public static void AlertA(string message, string script)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered("script"))
            {
                handler.ClientScript.RegisterStartupScript(handler.GetType(), "script", string.Format("alert('{0}');{1}", message, script), true);
            }
        }

        public static void Alert(string key, string message, string url, string target)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox();msg.alert(\"{0}\",\"{1}\",{2})", message.Replace("\"", "\\\""), url, target);
                handler.ClientScript.RegisterStartupScript(handler.GetType(), key, mess, true);
            }
        }

        public static void Alert(string key, string message,string url)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox();msg.alert(\"{0}\",\"{1}\")", message.Replace("\"", "\\\""), url);
                handler.ClientScript.RegisterStartupScript(handler.GetType(), key, mess, true);
            }
        }

        public static void Alert(string key, string message)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox();msg.alert(\"{0}\");", message.Replace("\"", "\\\""));
                handler.ClientScript.RegisterStartupScript(handler.GetType(), key, mess, true);
            }
        }

        public static void JumpAlert(string key, string message)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox('','','location.href=location.href;');msg.alert(\"{0}\");", message.Replace("\"", "\\\""));
                handler.ClientScript.RegisterStartupScript(handler.GetType(), key, mess, true);
            }
        }

        public static void AlertScript(string key, string message, string script)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox('','',\"" + script.Replace("\"","\\\"") + ";\");msg.alert(\"{0}\");", message.Replace("\"", "\\\""));
                handler.ClientScript.RegisterStartupScript(handler.GetType(), key, mess, true);
            }
        }

        public static void RegisterScript(string key, string message, string script)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox('注册新用户','注册',\"" + script.Replace("\"", "\\\"") + ";\");msg.alert(\"{0}\");", message.Replace("\"", "\\\""));
                handler.ClientScript.RegisterStartupScript(handler.GetType(), key, mess, true);
            }
        }

        public static void ForgetScript(string key, string message, string script)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox('密码找回','发送密码',\"" + script.Replace("\"", "\\\"") + ";\");msg.alert(\"{0}\");", message.Replace("\"", "\\\""));
                handler.ClientScript.RegisterStartupScript(handler.GetType(), key, mess, true);
            }
        }

        public static void ScriptAlert(string key, string message, string url)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox();msg.alert(\"{0}\",\"{1}\")", message.Replace("\"", "\\\""), url);
                handler.Response.Clear();
                handler.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
                handler.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
                handler.Response.Write("<head>\r\n");
                handler.Response.Write("<script type=\"text/javascript\">var paths=\"" + AdvAli.Config.Global.config.WebSiteUrl + "\";</script>");
                handler.Response.Write("<script type=\"text/javascript\" src=\"" + AdvAli.Config.Global.config.WebSiteUrl + "/script/msgbox.js\"></script>\r\n");
                handler.Response.Write("</head><body>\r\n");
                handler.Response.Write("<script type=\"text/javascript\">" + mess + "</script>");
                handler.Response.Write("</body></html>");
                handler.Response.End();
            }
        }

        public static void ScriptAlert(string key, string message, string url,string target)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            if (!handler.ClientScript.IsStartupScriptRegistered(key))
            {
                string mess = string.Format("var msg = new msgbox();msg.alert(\"{0}\",\"{1}\",\"{2}\")", message.Replace("\"", "\\\""), url, target);
                handler.Response.Clear();
                handler.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
                handler.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
                handler.Response.Write("<head>\r\n");
                handler.Response.Write("<script type=\"text/javascript\">var paths=\"" + AdvAli.Config.Global.config.WebSiteUrl + "\";</script>");
                handler.Response.Write("<script type=\"text/javascript\" src=\"" + AdvAli.Config.Global.config.WebSiteUrl + "/script/msgbox.js\"></script>\r\n");
                handler.Response.Write("</head><body>\r\n");
                handler.Response.Write("<script type=\"text/javascript\">" + mess + "</script>");
                handler.Response.Write("</body></html>");
                handler.Response.End();
            }
        }
    }
}
