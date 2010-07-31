using System;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Web.Mail;

namespace AdvAli.Plugin
{
    public class Mail
    {
        /// <summary>
        /// 发送电子邮件
        /// </summary>
        /// <param name="from">发件人的名称</param>
        /// <param name="to">收件人</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="account">发送账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="smtpServ">发送服务器</param>
        /// <returns></returns>
        public static bool SendMail(string from, string to, string title, string content, string account, string pwd, string smtpServ)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new MailAddress(account, from);
                message.To.Add(new MailAddress(to));
                message.Subject = title;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = content;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.Priority = System.Net.Mail.MailPriority.High;
                SmtpClient client = new SmtpClient(smtpServ);
                client.Credentials = new NetworkCredential(account, pwd);
                //client.Credentials = new NetworkCredential(account, pwd, account.Substring(account.IndexOf("@") + 1));
                client.Send(message);
                return true;
            } 
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 群发邮件
        /// </summary>
        /// <param name="form">发件人的名称</param>
        /// <param name="maillist">收件人列表,以","分开</param>
        /// <param name="title">标题</param>
        /// <param name="content">内容</param>
        /// <param name="account">发送账号</param>
        /// <param name="pwd">密码</param>
        /// <param name="smtpServ">发送服务器</param>
        /// <returns></returns>
        public static bool SendMailToList(string from, string maillist, string title, string content, string account, string pwd, string smtpServ)
        {
            try
            {
                System.Net.Mail.MailMessage message = new System.Net.Mail.MailMessage();
                message.From = new MailAddress(account, from);
                string[] tos = maillist.Split(new char[] { ',' });
                for (int i = 0; i < tos.Length; i++)
                {
                    message.To.Add(new MailAddress(tos[i]));
                }
                message.Subject = title;
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = content;
                message.IsBodyHtml = true;
                message.BodyEncoding = Encoding.UTF8;
                message.Priority = System.Net.Mail.MailPriority.High;
                SmtpClient client = new SmtpClient(smtpServ);
                client.Credentials = new NetworkCredential(account.Substring(0, account.IndexOf("@") - 1), pwd);
                //client.Credentials = new NetworkCredential(account, pwd, account.Substring(account.IndexOf("@") + 1));
                client.Send(message);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
