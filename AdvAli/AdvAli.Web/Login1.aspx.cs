using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using AdvAli.Common;
using AdvAli.Config;

namespace AdvAli.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlMeta hm = new HtmlMeta();
            hm.Name = "Keywords";
            hm.Content = Config.Global.__Meta_Key;
            Header.Controls.Add(hm);
            hm = new HtmlMeta();
            hm.Name = "Description";
            hm.Content = Config.Global.__Meta_Desc;
            Header.Controls.Add(hm);
            Title = Config.Global.__Title;
            if (Page.IsPostBack || Util.GetPageParams("post")=="submits")
            {
                switch (int.Parse(Util.GetPageParams("submits")))
                {
                    case 0: // 登陆
                        Html.HtmlUser.LoginUser();
                        break;
                    case 1: // 注册
                        if (!Global.config.AllowRegister)
                        {
                            MsgBox.JumpAlert("Login", "<p>系统目前不允许注册新用户!</p>");
                            return;
                        }
                        ClientScript.RegisterStartupScript(this.GetType(), "registerscript", "start=0;objid='username';", true);
                        MsgBox.RegisterScript("Register", string.Format("<p onselectstart=\"return true;\"><ul><li class=\"h30\">电子邮件 / Email Account：</li><li class=\"inputs\"><input type='text' class='registerInput' id='username' name='username' /></li><li class=\"h30\">企业名称：</li><li class=\"inputs\"><input class='registerInput' type='text' name='entname' /></li><li class=\"h30\">联系地址：</li><li class=\"inputs\"><input class='registerInput' type='text' name='address' /></li><li class=\"h30\">联系电话：</li><li class=\"inputs\"><input class='registerInput' type='text' name='tel' /></li><li class=\"h30\">企业简介：</li><li class='registerContentLi'><textarea class='registerContent' name='entnote'></textarea></li></ul></p>"), "SetHideValue('submits',3)");
                        break;
                    case 2: // 忘记密码
                        ClientScript.RegisterStartupScript(this.GetType(), "forgetscript", "start=0;objid='email';", true);
                        MsgBox.ForgetScript("Register", string.Format("<p onselectstart=\"return true;\"><ul><li class=\"h30\">电子邮件 / Email Account：</li><li class=\"inputs\"><input type='text' class='registerInput' id='email' name='email' /></li></ul></p>"), "SetHideValue('submits',4)");
                        break;
                    case 3: // 注册
                        //Html.HtmlUser.AddUser(HttpContext.Current.Request["username"], HttpContext.Current.Request["entname"], HttpContext.Current.Request["entnote"], HttpContext.Current.Request["address"], HttpContext.Current.Request["tel"]);
                        break;
                    case 4: // 忘记密码
                        Html.HtmlUser.ForgetPassword(HttpContext.Current.Request["email"]);
                        break;
                }
            }
        }
    }
}
