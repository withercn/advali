using System;
using System.Data;
using System.Runtime.InteropServices;
using System.Text;
using System.Web;
using System.Web.UI;
using AdvAli.Entity;
using AdvAli.Common;
using AdvAli.Logic;
using AdvAli.Plugin;
using AdvAli.Config;

namespace AdvAli.Web.Html
{
    public class HtmlUser : Page
    {
        public static clsDES clsdes = new clsDES("#$(*&D*(& $#KF*DL(@!_)(#KJF)$$*()J@");

        #region 添加用户
        public static void AddUser(string username, string password, string inc, string contact, string tel, string mobile, string fax, string qq, string msn, string address)
        {
            clsDES cd = new clsDES(Guid.NewGuid().ToString());
            User u = new User();
            u.Username = username;
            u.Password = Util.Md532(password);
            u.Inc = inc;
            u.Contact = contact;
            u.TelPhone = tel;
            u.Mobile = mobile;
            u.Fax = fax;
            u.QQ = qq;
            u.Msn = msn;
            u.Address = address;
            u.GroupId = 1;
            u.RegDate = DateTime.Now;
            u.LogDate = u.RegDate;
            u.RegIp = Util.GetUserIP();
            u.LogIp = u.RegIp;
            u.Adminstrator = Consult.GetGroupAdmins(1);
            if (!Util.CheckEmail(u.Username))
            {
                MsgBox.Alert(string.Format("邮箱账户 {0} 不是合法的邮箱名称!", u.Username));
                return;
            }
            if (password.Length < 6 || password.Length > 20)
            {
                MsgBox.Alert(string.Format("密码长度不符合规则,长度应该为6-20个字符!", u.Password));
            }
            if (inc.Length <= 0)
            {
                MsgBox.Alert("企业名称不能为空!");
            }
            if (contact.Length <= 0)
            {
                MsgBox.Alert("联系人不能为空!");
            }
            if (tel.Length == 0 && mobile.Length == 0)
            {
                MsgBox.Alert("固定电话和手机必需填写一项!");
            }
            if (address.Length <= 0)
            {
                MsgBox.Alert("联系地址不能为空!");
            }
            int userid = 0;
            if (Logic.Consult.CheckUser(username))
            {
                userid = Consult.AddUser(u);
            }
            else
            {
                MsgBox.Alert(string.Format("用户 {0} 已经注册过,请更换注册账户!", username)); 
            }
            if (userid > 0)
            {
                EmailConfig defaultMail = Consult.GetDefaultEmailConfig();
                if (Mail.SendMail(defaultMail.MailName, u.Username, string.Format("用户 {0} 的注册成功!", u.Username), string.Format("<p>您在<span style='color:blue;font-size:14px;'>{0}</span>的注册成功。<br />账号：{1}<br />密码：{2}</p></body></html>", Global.__WebSiteName, u.Username, password), defaultMail.Email, defaultMail.Pass, defaultMail.SmtpServer))
                {
                    MsgBox.AlertA(string.Format("用户 {0} 注册成功! 密码已发送到您的邮箱．", username), "location.href=\"http://www.andad.net/\";");
                }
                else
                {
                    MsgBox.AlertA(string.Format("用户 {0} 注册成功! 但是注册信息无法发送到指定邮箱．", username), "location.href=\"http://www.andad.net/\";");
                }
            }
            else
            {
                MsgBox.Alert(string.Format("用户 {0} 注册失败!", u.Username));
            }
        }
        #endregion

        #region 用户登陆
        public static void LoginUser()
        {
            string username = HttpContext.Current.Request["txtUsername"];
            string password = HttpContext.Current.Request["txtPassword"];
            string code = HttpContext.Current.Request["txtCode"];
            ((Page)HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((Page)HttpContext.Current.Handler).GetType(), "forgetscript", "start=0;objid='inputid';", true);
            if (!Util.CheckEmail(username))
            {
                MsgBox.Alert("用户名格式不正确!正确格式:test@test.com");
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MsgBox.Alert("密码不能为空!");
                return;
            }
            if (string.IsNullOrEmpty(code))
            {
                MsgBox.Alert("验证码不能为空!");
                return; 
            }
            LoginUser(username, password, code);
        }
        public static void LoginUser(string username, string password)
        {
            LoginUser(username, password, HttpContext.Current.Session["code"]);
        }
        public static void LoginUser(string username, string password, object code)
        {
            ((Page)HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((Page)HttpContext.Current.Handler).GetType(), "forgetscript", "start=0;objid='inputid';", true);
            if (object.Equals(code, HttpContext.Current.Session["code"]))
            {
                int userid = Consult.LoginUser(username,password);
                User user = Consult.GetUser(userid);
                if (user.GroupId < 8 && !Global.config.AllowLogin)
                {
                    MsgBox.Alert("系统目前不允许用户登陆");
                    return;
                }
                if (userid > 0)
                {
                    AdvAliCookie.WriteUserCookie(clsdes.Encrypt(userid.ToString()), Global.__Domain, DateTime.Now.AddDays(7));
                    MsgBox.AlertA(string.Format("用户 {0} 登陆成功!", username), "location.href=\"" + Global.__WebSiteUrl + "index.aspx\";");
                }
                else
                {
                    MsgBox.Alert(string.Format("用户 {0} 密码错误!", username));
                }
            }
            else
            {
                MsgBox.Alert("验证码错误!");
            }
        }
        public static void LoginUserUpdateState(int userid)
        {
            Consult.LoginUserUpdateState(userid);
        }
        #endregion

        #region 退出登陆
        public static void LogoutUser()
        {
            AdvAliCookie.RemoveCookie();
            MsgBox.ScriptAlert("Logout", "<p>用户退出登陆成功!</p>", AdvAli.Config.Global.config.WebSiteUrl + "/login.aspx", "top");

        }
        #endregion

        #region 删除用户
        public static void DeleteUser(int userid)
        {
            ((Page)HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((Page)HttpContext.Current.Handler).GetType(), "forgetscript", "start=0;objid='inputid';", true);
            if (Consult.DeleteUser(userid))
            {
                MsgBox.Alert("DeleteUser", "<p>删除用户成功!</p>");
            }
            else
            {
                MsgBox.Alert("DeleteUser", "<p>删除用户失败!</p>");
            }
        }
        #endregion

        #region 修改用户
        public static void EditUser(User u)
        {
            if (!Util.CheckEmail(u.Username))
            {
                MsgBox.Alert(string.Format("邮箱账户 {0} 不是合法的邮箱名称!", u.Username));
                return;
            }
            if (u.Password.Length < 6 || u.Password.Length > 20 && u.Password.Length != 32)
            {
                MsgBox.Alert(string.Format("密码长度不符合规则,长度应该为6-20个字符!", u.Password));
                return;
            }
            if (u.Inc.Length <= 0)
            {
                MsgBox.Alert("企业名称不能为空!");
                return;
            }
            if (u.Contact.Length <= 0)
            {
                MsgBox.Alert("联系人不能为空!");
                return;
            }
            if (u.TelPhone.Length == 0 && u.Mobile.Length == 0)
            {
                MsgBox.Alert("固定电话和手机必需填写一项!");
                return;
            }
            if (u.Address.Length <= 0)
            {
                MsgBox.Alert("联系地址不能为空!");
                return;
            }
            int result = Consult.EditUser(u);
            if (result > 0)
                MsgBox.ScriptAlert("UpdateUser", string.Format("用户 {0} 修改成功.", u.Username), "../user/index.aspx");
            else
                MsgBox.Alert("UpdateUser", string.Format("用户 {0} 修改失败.", u.Username));
        }
        public static void EditUser(int userid)
        {
            string username = HttpContext.Current.Request["txtUsername"];
            string password = HttpContext.Current.Request["txtPassword"];
            string entname = HttpContext.Current.Request["txtEntname"];
            string entnote = HttpContext.Current.Request["txtEntnote"];
            string address = HttpContext.Current.Request["txtAddress"];
            string tel = HttpContext.Current.Request["txtTel"];
            EditUser(userid, username, password, entname, entnote, address, tel);
        }
        public static void EditUser(int userid, string username, string password)
        {
            string entname = HttpContext.Current.Request["txtEntname"];
            string entnote = HttpContext.Current.Request["txtEntnote"];
            string address = HttpContext.Current.Request["txtAddress"];
            string tel = HttpContext.Current.Request["txtTel"];
            EditUser(userid, username, password, entname, entnote, address, tel);
        }
        public static void EditUser(int userid, string username, string password, string entname, string entnote, string address, string tel)
        {
            User u = Consult.GetUser(userid);
            if (!string.IsNullOrEmpty(password))
                u.Password = Util.Md532(password);
            u.Address = address;
            if (!string.IsNullOrEmpty(password))
            {
                if (password.Length > 0)
                {
                    if (password.Length < 6 || password.Length > 20)
                    {
                        MsgBox.Alert("RegisterUser", string.Format("<p>密码长度不符合规则,长度应该为 6-20的字符!</p>", u.Username));
                        return;
                    }
                }
            }
            if (string.IsNullOrEmpty(address))
            {
                MsgBox.Alert("RegisterUser", string.Format("<p>联系地址不能为空!</p>"));
                return;
            }
            if (string.IsNullOrEmpty(tel))
            {
                MsgBox.Alert("RegisterUser", string.Format("<p>联系电话不能为空!</p>"));
                return;
            }
            int result = Consult.EditUser(u);
            ((Page)HttpContext.Current.Handler).ClientScript.RegisterStartupScript(((Page)HttpContext.Current.Handler).GetType(), "forgetscript", "start=0;objid='inputid';", true);
            if (result > 0)
                MsgBox.ScriptAlert("UpdateUser", string.Format("用户 {0} 修改成功.", username), "../user/index.aspx");
            else
                MsgBox.Alert("UpdateUser", string.Format("用户 {0} 修改失败.", username));
        }
        public static void EditPassword(int userid, string oldpassword, string newpassword)
        {
            if (oldpassword.Length < 6 || oldpassword.Length > 20 || newpassword.Length < 6 || newpassword.Length > 20)
            {
                MsgBox.Alert("RegisterUser", string.Format("<p>密码长度不符合规则,长度应该为 6-20的字符!</p>"));
                return;
            }
            if (Consult.EditUserPassword(userid, Common.Util.Md532(oldpassword), Common.Util.Md532(newpassword)))
            {
                MsgBox.ScriptAlert("Password", string.Format("密码修改成功!"), "../user/password.aspx");
            }
            else
            {
                MsgBox.ScriptAlert("Password", string.Format("密码修改失败!"), "../user/password.aspx");
            }
        }
        public static void EditUserRights(int userid, int groupid, string userrights)
        {
            if (userid > 0)
            {
                Consult.EditUserRights(userid, groupid, userrights);
                MsgBox.ScriptAlert("UpdateUser", "权限设置成功!", "../user/index.aspx");
            }
            else
            {
                MsgBox.ScriptAlert("Password", "请选择一个用户!", "../user/index.aspx");
            }
        }
        #endregion

        #region 找回密码
        public static void ForgetPassword(string email)
        {
            string pass = Consult.ForgetPassword(email);
            if (string.IsNullOrEmpty(pass))
            {
                MsgBox.Alert(string.Format("电子邮件 {0} 不存在!", email));
            }
            else
            {
                EmailConfig defaultMail = Consult.GetDefaultEmailConfig();
                if (Mail.SendMail(defaultMail.MailName, email, string.Format("您在{0}的密码已修改!", Global.__WebSiteName), string.Format("<p>您成功使用<span style='color:blue;font-size:14px;'>{0}</span>的密码找回功能。<br />新的密码：{1} (请尽快登陆修改密码)</p></body></html>", Global.__WebSiteName, pass), defaultMail.Email, defaultMail.Pass, defaultMail.SmtpServer))
                {
                    MsgBox.Alert(string.Format("您的新密码已成功发送到指定邮箱。\\n请尽快登陆,修改您的密码!"));
                }
                else
                {
                    MsgBox.Alert(string.Format("您的新密码在发送中出现错误，请检查服务商提供的邮件账号是否可用。\\n如果正常，请稍后重新使用密码找回功能。"));
                }
            }
        }
        #endregion

        #region 登陆相关
        public static bool IsOperatorLogged()
        {
            if (!string.IsNullOrEmpty(AdvAliCookie.GetCookieMemberId()))
                return true;
            else
                return false;
        }
        public static int GetLoggedMemberId() 
        {
            string memberid = AdvAliCookie.GetCookieMemberId();
            if (string.IsNullOrEmpty(memberid))
                return 0;
            string userid = clsdes.Decrypt(memberid);
            if (string.IsNullOrEmpty(userid))
                return 0;
            else
                return int.Parse(userid);
        }
        #endregion
    }
}
