using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Net;

namespace AdvAli.Common
{
    public class Util
    {
        public static string Md532(string enstr)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(enstr, "MD5").ToLower();
        }

        public static string Md516(string enstr)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(enstr, "MD5").ToLower().Substring(8, 16);
        }

        public static clsTripleDES triDes = new clsTripleDES("{[(<'*((*#$&@!Uptime*~CMSWrite~*emitpU!@&$#*))*'>)]}");

        /// <summary>
        /// 绑定CheckBoxList
        /// </summary>
        public static void BindCtrlCBL(DataSet ds, string textField, string valueField, CheckBoxList cblControlName)
        {
            if (cblControlName.Items.Count <= 1)
            {
                cblControlName.DataSource = ds;
                cblControlName.DataTextField = textField;
                cblControlName.DataValueField = valueField;
                cblControlName.DataBind();
            }
        }
        /// <summary>
        /// 绑定DropDownList
        /// </summary>
        public static void BindCtrlDDL(DataSet ds, string textField, string valueField, DropDownList ddlControlName)
        {
            if (ddlControlName.Items.Count <= 1)
            {
                ddlControlName.DataSource = ds;
                ddlControlName.DataTextField = textField;
                ddlControlName.DataValueField = valueField;
                ddlControlName.DataBind();
            }
        }

        public static void BindCtrlDDL(DataSet ds, string textField, string valueField, DropDownList ddlControlName, string ddlDefaultValue)
        {
            if (ddlControlName.Items.Count <= 1)
            {
                ddlControlName.DataSource = ds;
                ddlControlName.DataTextField = textField;
                ddlControlName.DataValueField = valueField;
                ddlControlName.DataBind();
                ddlControlName.Items.FindByValue(ddlDefaultValue).Selected = true;
            }
        }
        /// <summary>
        /// 绑定HtmlSelect
        /// </summary>
        public static void BindCtrlHTMLDDL(DataSet ds, string textField, string valueField, HtmlSelect ddlControlName)
        {
            if (ddlControlName.Items.Count <= 1)
            {
                ddlControlName.DataSource = ds;
                ddlControlName.DataTextField = textField;
                ddlControlName.DataValueField = valueField;
                ddlControlName.DataBind();
            }
        }
        /// <summary>
        /// 绑定HtmlSelect带默认值
        /// </summary>
        public static void BindCtrlHTMLDDL(DataSet ds, string textField, string valueField, HtmlSelect ddlControlName, string ddlDefaultValue)
        {
            if (ddlControlName.Items.Count <= 1)
            {
                ddlControlName.DataSource = ds;
                ddlControlName.DataTextField = textField;
                ddlControlName.DataValueField = valueField;
                ddlControlName.DataBind();
                ddlControlName.Items.FindByValue(ddlDefaultValue).Selected = true;
            }
        }
        /// <summary>
        /// 绑定ListBox
        /// </summary>
        public static void BindCtrlLB(DataSet ds, string textField, string valueField, ListBox ddlControlName)
        {
            if (ddlControlName.Items.Count <= 1)
            {
                ddlControlName.DataSource = ds;
                ddlControlName.DataTextField = textField;
                ddlControlName.DataValueField = valueField;
                ddlControlName.DataBind();
            }
        }
        /// <summary>
        /// 绑定RadioButtonList
        /// </summary>
        public static void BindRBL(DataSet ds, string textField, string valueField, RadioButtonList rbl)
        {
            if (rbl.Items.Count <= 1)
            {
                rbl.DataSource = ds;
                rbl.DataTextField = textField;
                rbl.DataValueField = valueField;
                rbl.DataBind();
            }
        }
        /// <summary>
        /// 字符串转布尔值
        /// </summary>
        public static bool ChangeStrToBool(string strOrBit)
        {
            return ((string.Compare(strOrBit.ToLower().Trim(), "1") == 0) || (string.Compare(strOrBit.ToLower().Trim(), "true") == 0));
        }
        /// <summary>
        /// 字符串转10进制数
        /// </summary>
        public static decimal ChangeStrToDecimal(string strDecimal)
        {
            decimal num = 0M;
            if (IsNumber(strDecimal))
            {
                try
                {
                    num = decimal.Parse(decimal.Parse(strDecimal).ToString("0.00"));
                }
                catch (Exception)
                {
                }
                return num;
            }
            return 0M;
        }
        /// <summary>
        /// 字符串转整数
        /// </summary>
        public static int ChangeStrToInt(string strInt)
        {
            if (string.IsNullOrEmpty(strInt))
                return 0;
            if (IsNumber(strInt))
            {
                return int.Parse(strInt);
            }
            return 0;
        }
        /// <summary>
        /// 字符串转短整数
        /// </summary>
        public static short ChangeStrToShort(string strSmallInt)
        {
            if (IsNumber(strSmallInt))
            {
                return short.Parse(strSmallInt);
            }
            return 0;
        }
        /// <summary>
        /// 检查数据集中否有效
        /// </summary>
        public static bool CheckDataSet(DataSet ds)
        {
            return ((ds != null) && ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0)));
        }
        /// <summary>
        /// 检查Email格式
        /// </summary>
        public static bool CheckEmail(string emailToCheck)
        {
            string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
            return Regex.IsMatch(emailToCheck, pattern);
        }
        /// <summary>
        /// 文件是否存在
        /// </summary>
        public static bool CheckFileExists(string virtualPathAndName)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath(virtualPathAndName)))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 目录是否存在
        /// </summary>
        public static bool CheckFolderExists(string virtualPathAndName)
        {
            if (!Directory.Exists(HttpContext.Current.Server.MapPath(virtualPathAndName)))
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// 客户端IP
        /// </summary>
        public static string ClientIp()
        {
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
            }
            if (HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] != null)
                return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            else
                return "0.0.0.0";
        }
        /// <summary>
        /// 字符串转日期
        /// </summary>
        public static DateTime ConvertToDateTime(string s)
        {
            if (s == "")
            {
                return DateTime.MinValue;
            }
            return DateTime.Parse(s);
        }
        /// <summary>
        /// 字符串转十进制
        /// </summary>
        public static decimal ConvertToDecimal(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return -79228162514264337593543950335M;
            }
            return decimal.Parse(s);
        }
        /// <summary>
        /// 字符串转整数
        /// </summary>
        public static int ConvertToInt(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return -2147483648;
            }
            return int.Parse(s);
        }
        /// <summary>
        /// 复制目录
        /// </summary>
        public static bool CopyDirectory(string sPath, string dPath)
        {
            try
            {
                string[] directories = Directory.GetDirectories(sPath);
                if (!Directory.Exists(dPath))
                {
                    Directory.CreateDirectory(dPath);
                }
                DirectoryInfo path = new DirectoryInfo(sPath);
                DirectoryInfo[] infoArray = path.GetDirectories();
                CopyFile(path, dPath.Replace(@"\\", @"\"));
                if (infoArray.Length > 0)
                {
                    foreach (DirectoryInfo info2 in infoArray)
                    {
                        string fullName = info2.FullName;
                        string str2 = fullName.Replace(sPath, dPath);
                        if (!Directory.Exists(str2))
                        {
                            Directory.CreateDirectory(str2);
                        }
                        CopyFile(info2, str2);
                        CopyDirectory(fullName, str2);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 复制文件
        /// </summary>
        private static void CopyFile(DirectoryInfo path, string desPath)
        {
            string fullName = path.FullName;
            FileInfo[] files = path.GetFiles();
            if (files.Length > 0)
            {
                foreach (FileInfo info in files)
                {
                    string destFileName = info.FullName.Replace(fullName, desPath).Replace(@"\\", @"\");
                    info.CopyTo(destFileName, true);
                }
            }
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        public static void CreateFolder(string virtualPathAndName)
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath(virtualPathAndName)))
            {
                try
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath(virtualPathAndName));
                }
                catch (IOException exception)
                {
                    throw new IOException("目录创建失败：" + exception.Message.ToString());
                }
            }
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        public static bool DeleteFile(string physicalPath)
        {
            if (File.Exists(physicalPath))
            {
                try
                {
                    File.Delete(physicalPath);
                    return true;
                }
                catch (IOException)
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 删除目录
        /// </summary>
        public static void DeleteFolder(string virtualPathAndName)
        {
            string[] files = Directory.GetFiles(HttpContext.Current.Server.MapPath(virtualPathAndName));
            foreach (string str in files)
            {
                if (Directory.Exists(str))
                {
                    Directory.Delete(str, true);
                }
                if (File.Exists(str))
                {
                    File.Delete(str);
                }
            }
            Directory.Delete(HttpContext.Current.Server.MapPath(virtualPathAndName), true);
        }
        /// <summary>
        /// 删除虚拟目录及物理文件跳转
        /// </summary>
        public static void DeleteInstallRedirectUrl(string virtualPathAndName, string physialPath, string url)
        {
            DeleteFolder(virtualPathAndName);
            if (DeleteFile(physialPath))
            {
                HttpContext.Current.Response.Redirect(url);
            }
        }
        /// <summary>
        /// 加密 SHA1,MD5
        /// </summary>
        public static string EncryptPassword(string PasswordString, string PasswordFormat)
        {
            switch (PasswordFormat)
            {
                case "SHA1":
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "SHA1");

                case "MD5":
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(PasswordString, "MD5");
            }
            return string.Empty;
        }
        /// <summary>
        /// 执行脚本
        /// </summary>
        public static void ExecuteServerScript(string keyName, string jsScript)
        {
            Page handler = (Page)HttpContext.Current.Handler;
            ClientScriptManager clientScript = handler.ClientScript;
            Type type = handler.GetType();
            if (!clientScript.IsStartupScriptRegistered(keyName))
            {
                clientScript.RegisterStartupScript(type, keyName, "<script type='text/javascript' defer='defer'>" + jsScript + "</script>");
            }
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        public static bool FileUpDB(FileUpload fu, string FilePath)
        {
            bool flag;
            try
            {
                HttpPostedFile postedFile = fu.PostedFile;
                postedFile.SaveAs(HttpContext.Current.Server.MapPath("" + FilePath + "") + "//" + Path.GetFileName(postedFile.FileName));
                flag = true;
            }
            catch
            {
                flag = false;
            }
            return flag;
        }
        public static string FileUpDb(string fu)
        {
            string path = "";
            HttpFileCollection hfc = HttpContext.Current.Request.Files;
            HttpPostedFile postedFile = hfc[fu];
            if (postedFile != null)
            {
                if (!string.IsNullOrEmpty(postedFile.FileName))
                {
                    string year = DateTime.Now.Year.ToString();
                    string month = DateTime.Now.Month.ToString("00");
                    string extFileName = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf("."));
                    string[] extName = AdvAli.Config.Global.config.AllowUpload.Split(new char[] { '|' });
                    int fileLength = int.Parse((postedFile.ContentLength / 1024).ToString());
                    string filename = DateTime.Now.Millisecond.ToString("0000000000") + extFileName;
                    if (!Common.Util.CheckFolderExists(Config.Global.__UploadDirectory + year))
                    {
                        Common.Util.CreateFolder(Config.Global.__UploadDirectory + year);
                    }
                    if (!Common.Util.CheckFolderExists(Config.Global.__UploadDirectory + year + "/" + month))
                    {
                        Common.Util.CreateFolder(Config.Global.__UploadDirectory + year + "/" + month);
                    }
                    postedFile.SaveAs(HttpContext.Current.Server.MapPath(Config.Global.__UploadDirectory + year + "/" + month + "/" + filename));
                    path = Config.Global.__UploadDirectory + year + "/" + month + "/" + filename;
                    path = "http://" + Config.Global.config.WebSiteDomain + path;
                }
            }
            return path;
        }
        public static string GetPath()
        {
            string str1 = Config.Global.config.WebSiteDomain;
            string str2 = Config.Global.config.WebSiteUrl;
            string str3 = string.Empty;
            if (str2.ToLower().IndexOf("http://") != -1)
            {
                str2 = str2.ToLower().Replace("http://", "");
                str2 = str2.ToLower().Replace(str1.ToLower(), "");
                str2 = str2.Replace("/", "");
                str3 = str2;
            }
            return str3;
        }
        /// <summary>
        /// 读取参数
        /// </summary>
        public static string GetPageParams(string param)
        {
            string str = string.Empty;
            if (HttpContext.Current.Request[param] != null)
            {
                str = HttpContext.Current.Request[param].ToString();
            }
            return str;
        }
        /// <summary>
        /// 读取参数转为整数
        /// 出错 -100
        /// </summary>
        public static int GetPageParamsAndToInt(string param)
        {
            try
            {
                if (HttpContext.Current.Request[param] != null)
                {
                    return int.Parse(HttpContext.Current.Request[param].ToString());
                }
                return -100;
            }
            catch (Exception)
            {
                return -100;
            }
        }
        /// <summary>
        /// 读取参数转为整数
        /// 出错 -100
        /// </summary>
        public static int GetRequestAndAlterToInt(string strParam)
        {
            int num = -100;
            if (HttpContext.Current.Request[strParam] == null)
            {
                return num;
            }
            try
            {
                return int.Parse(HttpContext.Current.Request[strParam].ToString());
            }
            catch (Exception)
            {
                return -100;
            }
        }
        /// <summary>
        /// 获取客户IP
        /// </summary>
        public static string GetUserIP()
        {
            string userHostAddress;
            HttpRequest request = HttpContext.Current.Request;
            if (request.ServerVariables["HTTP_X_FORWARDED_FOR"] == "")
            {
                userHostAddress = request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                userHostAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            }
            if ((userHostAddress == null) || (userHostAddress == ""))
            {
                userHostAddress = request.UserHostAddress;
            }
            return userHostAddress;
        }
        /// <summary>
        /// 判断浮点数
        /// </summary>
        public static bool IsFloat(string strData)
        {
            bool flag = true;
            try
            {
                float num = float.Parse(strData);
            }
            catch (FormatException)
            {
                flag = false;
            }
            return flag;
        }
        /// <summary>
        /// 判断数值
        /// </summary>
        public static bool IsNumber(string str)
        {
            Regex regex = new Regex("^[+-]?[0123456789]*[.]?[0123456789]*$");
            return regex.IsMatch(str);
        }
        /// <summary>
        /// 获取来源链接
        /// </summary>
        public static string ReferrerUrl()
        {
            string str = string.Empty;
            if (HttpContext.Current.Request.UrlReferrer != null)
            {
                str = HttpContext.Current.Request.UrlReferrer.ToString().Trim();
            }
            return str;
        }
        /// <summary>
        /// 删除Html对像
        /// </summary>
        public static string RemoveHTMLTag(string Htmlstring)
        {
            Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "\x00a1", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "\x00a2", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "\x00a3", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "\x00a9", RegexOptions.IgnoreCase);
            Htmlstring = Regex.Replace(Htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);
            Htmlstring.Replace("<", "");
            Htmlstring.Replace(">", "");
            Htmlstring.Replace("\r\n", "");
            Htmlstring = HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
            return Htmlstring;
        }
        /// <summary>
        /// 设置页面不缓存
        /// </summary>
        public static void SetPageNoCache()
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AddHeader("Pragma", "No-Cache");
        }
        /// <summary>
        /// 替换字符串
        /// </summary>
        public static string StringReplace(string input, string replacement, string pattern)
        {
            return Regex.Replace(input, @"\$" + pattern + @"\$", replacement, RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// 选择类型
        /// </summary>
        public static string SwitchOperationType(string OpContent)
        {
            switch (OpContent.ToLower())
            {
                case "add":
                    return "添加";

                case "delete":
                    return "删除";

                case "update":
                    return "更新";

                case "verify":
                    return "审核";
            }
            return "未知";
        }
        /// <summary>
        /// 测试Access连接
        /// </summary>
        public static bool TestAccess(string constr)
        {
            try
            {
                OleDbConnection connection = new OleDbConnection(constr);
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 测试SqlServer连接
        /// </summary>
        public static bool TestMSSql(string constr)
        {
            try
            {
                SqlConnection connection = new SqlConnection(constr);
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 测试MySql连接
        /// </summary>
        public static bool TestMYSQL(string constr)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(constr);
                connection.Open();
                connection.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// 客户端弹出信息
        /// </summary>
        /// <param name="msg">信息</param>
        /// <param name="navigateUrl">跳转连接</param>
        /// <param name="target">连接目标</param>
        public static void UIAlert(string msg, string navigateUrl, string target)
        {
            msg = Regex.Replace(msg, @"\r\n|\n", @"\n");
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.Write("<script language=\"javascript\">");
            HttpContext.Current.Response.Write(string.Format("alert('{0}');", msg));
            if (target != null)
            {
                HttpContext.Current.Response.Write(string.Format("{0}.location='{1}';", target, navigateUrl));
            }
            else
            {
                HttpContext.Current.Response.Write(string.Format("location='{0}';", navigateUrl));
            }
            HttpContext.Current.Response.Write("</script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 判断权限
        /// </summary>
        /// <param name="RightsID"></param>
        /// <param name="rightsList"></param>
        /// <returns></returns>
        public static bool JudgeRights(int RightsID, string rightsList)
        {
            bool flag = false;
            try
            {
                string input = rightsList;
                string[] strArray = Regex.Split(input, "[|]+");
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (RightsID == int.Parse(strArray[i].ToString().Trim()))
                    {
                        flag = true;
                        break;
                    }
                }
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 判断权限
        /// </summary>
        /// <param name="RightsID"></param>
        /// <param name="admins"></param>
        /// <returns></returns>
        public static bool JudgeRights(int RightsID, AdvAli.Entity.Admins admins)
        {
            bool flag = false;
            try
            {
                foreach (AdvAli.Entity.Admin admin in admins)
                {
                    if (RightsID == admin.AdminId)
                    {
                        flag = true;
                        break;
                    }
                }
                return flag;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetCurrentUrl()
        {
            string allurl = HttpContext.Current.Request.Url.ToString().ToLower().Replace(AdvAli.Config.Global.config.WebSiteUrl.ToLower(), "");
            return allurl;
        }

        public static string GetAdType(int i)
        {
            switch (i)
            {
                case 1:
                    return "文字商务通";
                case 2:
                    return "QQ";
                case 3:
                    return "Msn";
                case 4:
                    return "图片商务通";
                default:
                    return "文字商务通";
            }
        }

        public static string GetAdTypeFields(int i)
        {
            switch (i)
            {
                case 1:
                    return "guidec";
                case 2:
                    return "qq";
                case 3:
                    return "msn";
                case 4:
                    return "adimage";
                default:
                    return "guidec";
            }
        }

        public static string GetAdTypeTable(int i)
        {
            switch (i)
            {
                case 1:
                    return "adv_guidec";
                case 2:
                    return "adv_qqmsn";
                case 3:
                    return "adv_qqmsn";
                case 4:
                    return "adv_images";
                default:
                    return "";
            }
        }

        public static int GetQQState(long qq)
        {
            WebClient client = new WebClient();
            byte[] data;
            try { data = client.DownloadData("http://wpa.qq.com/pa?p=1:" + qq.ToString() + ":1"); }
            catch { data = new byte[0]; }
            switch (data.Length)
            {
                case 2329:
                    return 1;
                case 2262:
                    return 0;
                case 0:
                    return -1;
                default:
                    return -1;
            }
        }

        public static int GetMsnState(string msn)
        {
            WebClient client = new WebClient();
            byte[] data;
            try { data = client.DownloadData(string.Format("http://messenger.services.live.com/users/{0}/presenceimage/", msn)); }
            catch { data = new byte[0]; }
            switch (data.Length)
            {
                case 534:
                    return 1;
                case 333:
                    return 0;
                case 0:
                    return -1;
                default:
                    return -1;
            }
        }

        public static long IP2Long(string ip)
        {
            string[] ipSplit = ip.Split(new char[] { '.' });
            string ipString = "";
            if (ipSplit.Length == 4)
            {
                foreach (string ips in ipSplit)
                {
                    string temp = Convert.ToInt16(ips).ToString("x");
                    if (temp.Length == 1)
                    {
                        ipString += "0" + temp;
                    }
                    else
                    {
                        ipString += temp;
                    }
                }
            }
            return long.Parse(ipString, System.Globalization.NumberStyles.HexNumber);
        }

        /*public static string GetDomain(string url)
        {
            try
            {
                Uri uri = new Uri(url);
                string[] hosts = uri.Host.Split(new char[] { '.' });
                string host = "";
                if (hosts.Length >= 3)
                {
                    host = hosts[hosts.Length - 2] + "." + hosts[hosts.Length - 1];
                }
                return host;
            }
            catch { return string.Empty; }
        }*/

        /// <summary>
        /// 获取服务器根域名  
        /// </summary>
        /// <returns></returns>
        public static string GetDomain(string url)
        {
            Uri uri;
            try { uri = new Uri(url); }
            catch { return string.Empty; }
            string str = uri.Host.ToLower();// HttpContext.Current.Request.Url.Host.ToString().ToLower();//此处获取值转换为小写
            if (str.IndexOf('.') > 0)
            {
                string[] strArr = str.Split('.');
                string lastStr = strArr.GetValue(strArr.Length - 1).ToString();
                if (IsNumeric(lastStr)) //如果最后一位是数字，那么说明是IP地址
                {
                    return str.Replace(".", ""); //替换.为纯数字输出 
                }
                else //否则为域名
                {
                    string[] domainRules = ".com.cn|.net.cn|.org.cn|.gov.cn|.com.hk|.com|.net|.cn|.org|.cc|.me|.tel|.mobi|.asia|.biz|.info|.name|.tv|.hk|.公司|.中国|.网络".Split('|');
                    string findStr = string.Empty;
                    string replaceStr = string.Empty;
                    string returnStr = string.Empty;
                    for (int i = 0; i < domainRules.Length; i++)
                    {
                        if (str.EndsWith(domainRules[i].ToLower())) //如果最后有找到匹配项
                        {
                            findStr = domainRules[i].ToString(); 
                            replaceStr = str.Replace(findStr, ""); //将匹配项替换为空，便于再次判断
                            if (replaceStr.IndexOf('.') > 0) //存在二级域名或者三级，比如：www.163
                            {
                                string[] replaceArr = replaceStr.Split('.'); // www px915
                                returnStr = replaceArr.GetValue(replaceArr.Length - 1).ToString() + findStr;
                                return returnStr;
                            }
                            else 
                            {
                                returnStr = replaceStr + findStr; //连接起来输出为：px915.com
                                return returnStr;
                            };
                        }
                        else
                        { returnStr = str; }
                    }
                    return returnStr;
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public static bool IsNumeric(string str)
        {
            try { int i = Convert.ToInt32(str); return true; }
            catch { return false; }
        }

        public static string ScriptChange(string script)
        {
            Regex reg = new Regex(@"<script[^>]*?src\s*=\s*(""(?<src>[^""]+?)""|'(?<src>[^']+?)'|(?<src>[^\s>]+))[^>]*?>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            string results = reg.Replace(script, "document.write('<scr' + 'ipt type=\"text/javascript\" src=${1}></scr' + 'ipt>');");
            return results;
        }

        public static string RemoveScript(string script)
        {
            string regresults = ScriptChange(script);
            Regex reg = new Regex(@"<script.*?>\r\n", RegexOptions.IgnoreCase);
            //Regex reg = new Regex(@"<script[\s\S]+</script *>", RegexOptions.IgnoreCase);
            regresults = reg.Replace(regresults, "");
            reg = new Regex(@"</script>", RegexOptions.IgnoreCase);
            regresults = reg.Replace(regresults, "");
            reg = new Regex(@"\r\n\/\/.*?\r\n", RegexOptions.IgnoreCase);
            regresults = reg.Replace(regresults, "\r\n");
            //regresults = regresults.Replace("\\", "").Replace("\\\\", "");
            regresults = regresults.Replace("\r\n\r\n", "\r\n");
            return regresults;
        }

        /// <summary>
        /// 获取Url中传递过来的参数
        /// </summary>
        /// <param name="requestName"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetRequestUrl(string requestName, string url)
        {
            string str = url.ToLower();
            if (str.IndexOf("?" + requestName) != -1 || str.IndexOf("&" + requestName) != -1)
            {
                if (str.IndexOf("?" + requestName) != -1)
                {
                    str = str.Substring(str.IndexOf("?" + requestName) + requestName.Length + 1);
                    if (str.IndexOf("&") != -1)
                    {
                        str = str.Substring(0, str.IndexOf("&"));
                    }
                }
                else
                {
                    str = str.Substring(str.IndexOf("&" + requestName) + requestName.Length + 1);
                    if (str.IndexOf("&") != -1)
                    {
                        str = str.Substring(0, str.IndexOf("&"));
                    }
                }
            }
            else
            {
                str = "";
            }
            return str;
        }
        /// <summary>
        /// 判断字符串数组是否有该字符串.
        /// </summary>
        public static bool HasString(string strArray, string str, char[] specator)
        {
            string[] sArray = strArray.Split(specator);
            for (int i = 0; i < sArray.Length; i++)
            {
                if (sArray[i] == str)
                    return true;
            }
            return false;
        }
        public static string GetKeywords()
        {
            if (string.IsNullOrEmpty(Common.Util.GetPageParams("referrer")))
                return string.Empty;
            else
                return GetKeywords(Common.Util.GetPageParams("referrer"));
        }
        /// <summary>
        /// 获取url中的搜索关键字
        /// </summary>
        public static string GetKeywords(string urls)
        {
            Uri uri;
            string ie = "gb2312";
            string key = string.Empty;
            try { uri = new Uri(urls); }
            catch { return string.Empty; }
            string host = uri.Host.ToLower();
            if (host.IndexOf("baidu") != -1)
            {
                ie = Util.GetRequestUrl("ie=", urls);
                if (ie == "")
                    ie = "gb2312";
                if (Util.GetRequestUrl("wd=", urls) != "")
                {
                    key = Util.GetRequestUrl("wd=", urls);
                }
                else if (Util.GetRequestUrl("word=", urls) != "")
                {
                    key = Util.GetRequestUrl("word=", urls);
                }
            }
            else if (host.IndexOf("google") != -1)
            {
                ie = Util.GetRequestUrl("ie=", urls);
                if (ie == "")
                {
                    ie = "utf-8";
                }
                if (Util.GetRequestUrl("q=", urls) != "")
                {
                    key = Util.GetRequestUrl("q=", urls);
                }
            }
            else if (host.IndexOf("yahoo") != -1)
            {
                ie = Util.GetRequestUrl("ei=", urls);
                if (ie == "")
                {
                    ie = "utf-8";
                }
                if (Util.GetRequestUrl("p=", urls) != "")
                {
                    key = Util.GetRequestUrl("p=", urls);
                }
            }
            else if (host.IndexOf("sogou") != -1)
            {
                ie = "gb2312";
                if (Util.GetRequestUrl("query=", urls) != "")
                {
                    key = Util.GetRequestUrl("query=", urls);
                }
            }
            else if (host.IndexOf("soso") != -1)
            {
                ie = "utf-8";
                if (Util.GetRequestUrl("w=", urls) != "")
                {
                    key = Util.GetRequestUrl("w=", urls);
                }
            }
            if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(ie))
            {
                if (ie.ToLower().IndexOf("gb") != -1)
                    ie = "gb2312";
                if (ie.ToLower().IndexOf("utf") != -1)
                    ie = "utf-8";
                key = HttpUtility.UrlDecode(key, System.Text.Encoding.GetEncoding(ie));
            }
            return key;
        }
    }
}
