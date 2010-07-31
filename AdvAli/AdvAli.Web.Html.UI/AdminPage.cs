using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdvAli.Web.Html.UI
{
    public class AdminPage : Page
    {
        protected bool isNeedCheckRights = true;
        protected int memberId = 0;
        protected int browserRightsIntValue = 0;
        protected int recordcount = 0;
        protected string addurl = "";
        protected string editurl = "";
        protected string rightsurl = "";
        protected string deltable = "";
        protected string defaulttable = "";

        public bool IsNeedCheckRights
        {
            get { return this.isNeedCheckRights; }
            set { this.isNeedCheckRights = value; }
        }
        public int MemberId
        {
            get { return this.memberId; }
            set { this.memberId = value; }
        }
        public int BrowserRightsIntValue
        {
            get { return this.browserRightsIntValue; }
            set { this.browserRightsIntValue = value; }
        }
        public int RecordCount
        {
            set { this.recordcount = value; }
            get { return this.recordcount; }
        }
        public string Fields = "";
        public string FieldName = "";
        public string FieldWidth = "";
        public string Navigations = "<a href=\"" + Config.Global.config.WebSiteUrl + "index.aspx\" target=\"_top\">" + Config.Global.__WebSiteName + "</a>&nbsp;>&nbsp;<a href=\"../" + Common.Util.GetCurrentUrl() + "\">" + Logic.Consult.GetCurrentUrlName("../" + Common.Util.GetCurrentUrl()) + "</a>";
        public string AddUrl
        {
            set { this.addurl = value; }
            get { return this.addurl; }
        }
        public string EditUrl
        {
            set { this.editurl = value; }
            get { return this.editurl; }
        }
        public string RightsUrl
        {
            set { this.rightsurl = value; }
            get { return this.rightsurl; }
        }
        public string DelTable
        {
            set { this.deltable = value; }
            get { return this.deltable; }
        }
        public string DefaultTable
        {
            set { this.defaulttable = value; }
            get { return this.defaulttable; }
        }
        public AdvAli.Entity.User user = new AdvAli.Entity.User();

        protected override void OnInit(EventArgs e)
        {
            this.MemberId = this.GetLoggedMemberId();
            if (this.MemberId > 0)
            {
                this.user = Logic.Consult.GetUser(this.MemberId);
                if (object.Equals(user, null))
                {
                    AdvAli.Common.MsgBox.ScriptAlert("Msg", "<p>对不起,您没有权限访问该模块!</p>", AdvAli.Config.Global.config.WebSiteUrl + "/login.aspx", "top");
                }
            }
            else
            {
                AdvAli.Common.MsgBox.ScriptAlert("Msg", "<p>对不起,您还没有登陆,请登陆后重新访问!</p>", AdvAli.Config.Global.config.WebSiteUrl + "/login.aspx", "top");
            }
            base.OnInit(e);
        }
        protected virtual void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                if (this.IsOperatorLogged())
                {
                    if (this.isNeedCheckRights)
                    {
                        if (this.user.GroupId > 0)
                        {
                            if (this.JudgeRights(this.BrowserRightsIntValue, user.Admins))
                            {
                                this.BindData();
                            }
                            else
                            {
                                AdvAli.Common.MsgBox.ScriptAlert("Msg", "<p>对不起,您没有权限访问该模块!</p>", AdvAli.Config.Global.config.WebSiteUrl + "/login.aspx", "top");
                            }
                        }
                        else
                        {
                            AdvAli.Common.MsgBox.ScriptAlert("Msg", "<p>对不起,您的账户已被禁用,请与网站管理员联系!</p>", AdvAli.Config.Global.config.WebSiteUrl + "/login.aspx", "top");
                        }
                    }
                    else
                    {
                        this.BindData();
                    }
                }
                else
                {
                    AdvAli.Common.MsgBox.ScriptAlert("Msg", "<p>对不起,您没有权限访问该模块!</p>", AdvAli.Config.Global.config.WebSiteUrl + "/login.aspx", "top");
                }
            }
            else
            {
                this.BindData();
            }
        }
        protected bool IsOperatorLogged()
        {
            return Html.HtmlUser.IsOperatorLogged();
        }
        protected int GetLoggedMemberId()
        {
            return Html.HtmlUser.GetLoggedMemberId();
        }
        protected int GetLoggedUserGroupId()
        {
            AdvAli.Entity.User user = Logic.Consult.GetUser(this.GetLoggedMemberId());
            return user.GroupId;
        }
        protected bool JudgeRights(int RightsId,AdvAli.Entity.Admins admins)
        {
            return (AdvAli.Common.Util.JudgeRights(RightsId, admins) && AdvAli.Common.Util.JudgeRights(RightsId, AdvAli.Config.Global.AllRights));
        }
        protected virtual void BindData()
        { }
        protected void TableBindData(HtmlTable data)
        {
            string[] fields = Fields.Split(new char[] { ',' });
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;
            string username = Common.Util.GetPageParams("txtusername");
            int timesel = 0;
            int.TryParse(Common.Util.GetPageParams("timesel"), out timesel);
            string time1 = Common.Util.GetPageParams("time1");
            string time2 = Common.Util.GetPageParams("time2");
            
            DateTime timer1 = DateTime.Now;
            DateTime timer2 = DateTime.Now;
            if (!string.IsNullOrEmpty(time1))
            {
                timer1 = DateTime.Parse(time1);
            }
            if (!string.IsNullOrEmpty(time2))
            {
                timer2 = DateTime.Parse(time2);
            }
            using (DataSet ds = AdvAli.Logic.Consult.GetUser(username, timesel, timer1, timer2, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (AdvAli.Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }
                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        for (int i = 0; i < fields.Length; i++)
                        {
                            HtmlTableCell td = new HtmlTableCell();
                            if (!string.IsNullOrEmpty(reader[fields[i]].ToString()))
                                td.InnerHtml = reader[fields[i]].ToString();
                            else
                                td.InnerHtml = "&nbsp;";
                            tr.Cells.Add(td);
                        }
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void DefaultDataSetBind(HtmlTable data)
        {
            string[] fields = Fields.Split(new char[] { ',' });
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;

            using (DataSet ds = AdvAli.Logic.Consult.GetTable(this.DefaultTable, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (AdvAli.Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }
                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        for (int i = 0; i < fields.Length; i++)
                        {
                            HtmlTableCell td = new HtmlTableCell();
                            if (!string.IsNullOrEmpty(reader[fields[i]].ToString()))
                                td.InnerHtml = reader[fields[i]].ToString();
                            else
                                td.InnerHtml = "&nbsp;";
                            tr.Cells.Add(td);
                        }
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void BaseDataBind(HtmlTable data)
        {
            string[] fields = Fields.Split(new char[] { ',' });
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;

            using (DataSet ds = Logic.Consult.GetTable((this.GetLoggedUserGroupId() >= 8 ? 0 : HtmlUser.GetLoggedMemberId()), this.DefaultTable, this.Fields, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (AdvAli.Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }
                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        for (int i = 0; i < fields.Length; i++)
                        {
                            HtmlTableCell td = new HtmlTableCell();
                            if (string.IsNullOrEmpty(reader[i].ToString().Trim()) || string.Equals(reader[i].ToString().Trim(), "<a href=\"\" target=\"_blank\"></a>"))
                            {
                                td.InnerHtml = "无";
                            }
                            else
                            {
                                td.InnerHtml = reader[i].ToString();
                                td.Attributes.Add("title", reader[i].ToString());
                            }
                            tr.Cells.Add(td);
                        }
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void GetWebSite(HtmlTable data)
        {
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;
            using (DataSet ds = this.GetLoggedUserGroupId() >= 8 ? Logic.Consult.GetTable(this.DefaultTable, pageIndex, HtmlPager.PageSize, out recordcount) : Logic.Consult.GetTable(this.GetLoggedMemberId(), this.DefaultTable, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (AdvAli.Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }
                    htc = new HtmlTableCell();
                    htc.InnerHtml = "获取代码";
                    tr.Cells.Add(htc);
                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        HtmlTableCell td = new HtmlTableCell();
                        td.InnerHtml = reader["id"].ToString();
                        tr.Cells.Add(td);
                        td = new HtmlTableCell();
                        td.InnerHtml = string.Format("<a href=\"http://{0}\" target=\"_blank\">{1}</a>", reader["siteurl"].ToString().ToLower().Replace("http://", ""), reader["sitename"].ToString());
                        tr.Cells.Add(td);
                        int adType = Common.Util.ConvertToInt(reader["addisplay"].ToString());
                        td = new HtmlTableCell();
                        td.InnerHtml = Common.Util.GetAdType(adType);
                        tr.Cells.Add(td);
                        td = new HtmlTableCell();
                        td.InnerHtml = HtmlWebSite.GetAdRang(reader["ranglist"].ToString().Replace("$", ""));
                        tr.Cells.Add(td);
                        td = new HtmlTableCell();
                        if (this.GetLoggedUserGroupId() >= 8)
                            td.InnerHtml = string.Format("<a href=\"../website/activity.aspx?siteid={0}\">{1}</a>", reader["id"].ToString(), (Common.Util.ChangeStrToBool(reader["stats"].ToString()) ? "已开启" : "已关闭"));
                        else
                            td.InnerHtml = Common.Util.ChangeStrToBool(reader["stats"].ToString()) ? "已开启" : "已关闭";
                        tr.Cells.Add(td);
                        td = new HtmlTableCell();
                        td.InnerHtml = string.Format("<a href=\"../website/GetScript.aspx?siteid={0}\">获取代码</a>", reader["id"].ToString());
                        tr.Cells.Add(td);
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Response.Redirect(AddUrl);
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            string idlist = GetIdList();
            if (string.IsNullOrEmpty(idlist))
            {
                Common.MsgBox.JumpAlert("Msg", "<p>请选择一条需要编辑的数据!</p>");
                return;
            }          
            if (idlist.IndexOf(",") != -1)
            {
                Common.MsgBox.JumpAlert("Msg", "<p>同一时间只能选择一项数据进行编辑!</p>");
                return;
            }
            int id = Common.Util.ChangeStrToInt(idlist);
            if (Request.Url.ToString().ToLower().IndexOf("user/index.aspx") != -1)
            {
                AdvAli.Entity.User targetUser = Logic.Consult.GetUser(id);
                if (id == GetLoggedMemberId())
                {
                    Common.MsgBox.JumpAlert("Msg", "<p>对不起,你的用户权限不够,无法完成该操作!</p>");
                    return;
                }
                if (user.GroupId <= targetUser.GroupId && user.Username != targetUser.Username)
                {
                    Common.MsgBox.JumpAlert("Msg", "<p>对不起,你的用户权限不够,无法完成该操作!</p>");
                    return;
                }
            }
            if (id != 0 || Request.Url.ToString().ToLower().IndexOf("user/groups.aspx") != -1)
            {
                HttpContext.Current.Response.Redirect(string.Format("{0}?id={1}", EditUrl, id), true);
            }
            else
            {
                Common.MsgBox.JumpAlert("Msg", "<p>选择错误,请重新选择!</p>");
                return;
            }
        }
        protected void Rights_Click(object sender,EventArgs e)
        {
            string idlist = GetIdList();
            int id = Common.Util.ChangeStrToInt(idlist);
            
            if (string.IsNullOrEmpty(idlist))
            {
                Common.MsgBox.JumpAlert("Msg", "<p>请选择一个用户设置权限!</p>");
                return;
            }
            if (idlist.IndexOf(",") != -1)
            {
                Common.MsgBox.JumpAlert("Msg", "<p>同一时间只能对一个用户进行权限设置!</p>");
                return;
            }

            if (Request.Url.ToString().ToLower().IndexOf("user/index.aspx") != -1)
            {
                AdvAli.Entity.User targetUser = Logic.Consult.GetUser(id);
                if (id == GetLoggedMemberId())
                {
                    Common.MsgBox.JumpAlert("Msg", "<p>对不起,你的用户权限不够,无法完成该操作!</p>");
                    return;
                }
                if (user.GroupId <= targetUser.GroupId && user.Username != targetUser.Username)
                {
                    Common.MsgBox.JumpAlert("Msg", "<p>对不起,你的用户权限不够,无法完成该操作!</p>");
                    return;
                }
            }
            if (id != 0)
            {
                HttpContext.Current.Response.Redirect(string.Format("{0}?id={1}", RightsUrl, id), true);
            }
            else
            {
                Common.MsgBox.JumpAlert("Msg", "<p>选择错误,请重新选择!</p>");
                return;
            }
        }
        protected virtual void Del_Click(object sender, EventArgs e)
        {
            string idlist = GetIdList();
            int id = Common.Util.ChangeStrToInt(idlist);
            if (Request.Url.ToString().ToLower().IndexOf("user/index.aspx") != -1)
            {
                AdvAli.Entity.User targetUser = Logic.Consult.GetUser(id);
                if (id == GetLoggedMemberId())
                {
                    Common.MsgBox.JumpAlert("Msg", "<p>对不起,你的用户权限不够,无法完成该操作!</p>");
                    return;
                }
                if (user.GroupId <= targetUser.GroupId && user.Username != targetUser.Username)
                {
                    Common.MsgBox.JumpAlert("Msg", "<p>对不起,你的用户权限不够,无法完成该操作!</p>");
                    return;
                }
            }
            if (string.IsNullOrEmpty(idlist))
            {
                Common.MsgBox.JumpAlert("Msg", "<p>请选择需要删除的数据!</p>");
                return;
            }
            Logic.Consult.DeleteBatch(idlist, deltable);
            Common.MsgBox.JumpAlert("Msg", "<p>删除数据成功!</p>");
        }
        protected string GetIdList()
        {
            string idlist = Common.Util.GetPageParams("idlist");
            if (idlist.Trim().Length > 0)
                return idlist.Trim().Substring(0, idlist.Trim().Length - 1);
            else
                return null;
        }
        protected void GetLogs(HtmlTable data)
        {
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;
            int userid = this.GetLoggedMemberId();
            int siteid = 0;
            string date1 = "", date2 = "";
            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid = Common.Util.GetPageParamsAndToInt("siteid");
            if (Common.Util.GetPageParams("date1") != string.Empty)
            {
                try { DateTime.Parse(Common.Util.GetPageParams("date1")); }
                catch { Common.MsgBox.AlertScript("alert", "日期格式不正确", "history.go(-1);"); return; }
                date1 = Common.Util.GetPageParams("date1");
            }
            if (Common.Util.GetPageParams("date2") != string.Empty)
            {
                try { DateTime.Parse(Common.Util.GetPageParams("date2")); }
                catch { Common.MsgBox.AlertScript("alert", "日期格式不正确", "history.go(-1);"); return; }
                date2 = Common.Util.GetPageParams("date2");
            }
            if (this.GetLoggedUserGroupId() >= 8)
            {
                userid = 0;                
            }
            using (DataSet ds = Logic.Consult.GetLogs(userid, siteid, date1, date2, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (AdvAli.Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }
                    
                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = reader["id"].ToString();
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        DateTime logdate = Common.Util.ConvertToDateTime(reader["logdate"].ToString());
                        htc.InnerHtml = logdate.ToString("yyyy年MM月dd日hh点");
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = reader["country"].ToString();
                        htc.Attributes.Add("title", reader["ip"].ToString());
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.Attributes.Add("title", reader["pagetitle"].ToString());
                        if (!string.IsNullOrEmpty(reader["pageurl"].ToString()))
                            htc.InnerHtml = string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", reader["pageurl"].ToString(), reader["pagetitle"].ToString());
                        else
                            htc.InnerHtml = "&nbsp;";
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        string keywords = Common.Util.GetKeywords(reader["referrer"].ToString());
                        if (string.IsNullOrEmpty(reader["referrer"].ToString()))
                            htc.InnerHtml = "&nbsp;";
                        else if (keywords != string.Empty)
                            htc.InnerHtml = string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", reader["referrer"].ToString(), keywords);
                        else
                            htc.InnerHtml = string.Format("<a href=\"{0}\" target=\"_blank\">{0}</a>", reader["referrer"].ToString());
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        AdvAli.Entity.Site site = Logic.Consult.GetWebSite(Common.Util.ChangeStrToInt(reader["siteid"].ToString()));
                        htc.InnerHtml = string.Format("<a href=\"http://{0}\" target=\"_blank\">{1}</a>", site.SiteUrl, site.SiteName);
                        tr.Cells.Add(htc);
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void GetVisits(HtmlTable data)
        {
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;
            int userid = this.GetLoggedMemberId();
            int siteid = 0;
            string date1 = "", date2 = "";
            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid = Common.Util.GetPageParamsAndToInt("siteid");
            if (Common.Util.GetPageParams("date1") != string.Empty)
            {
                try { DateTime.Parse(Common.Util.GetPageParams("date1")); }
                catch { Common.MsgBox.AlertScript("alert", "日期格式不正确", "history.go(-1);"); return; }
                date1 = DateTime.Parse(Common.Util.GetPageParams("date1")).ToString("yyyyMMdd");
            }
            if (Common.Util.GetPageParams("date2") != string.Empty)
            {
                try { DateTime.Parse(Common.Util.GetPageParams("date2")); }
                catch { Common.MsgBox.AlertScript("alert", "日期格式不正确", "history.go(-1);"); return; }
                date2 = DateTime.Parse(Common.Util.GetPageParams("date2")).ToString("yyyyMMdd");
            }
            if (this.GetLoggedUserGroupId() >= 8)
            {
                userid = 0;
            }
            using (DataSet ds = Logic.Consult.GetVisits(userid, siteid, date1, date2, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }

                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = reader["id"].ToString();
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = reader["sitename"].ToString();
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = reader["dates"].ToString();
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = reader["pv"].ToString();
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = reader["consult"].ToString();
                        tr.Cells.Add(htc);
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void GetForum(HtmlTable data)
        {
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int userid = this.GetLoggedMemberId();
            if (this.GetLoggedUserGroupId() >= 8)
                userid = 0;
            int isre = 0;
            if (Common.Util.GetPageParamsAndToInt("isre") != -100)
                isre = Common.Util.GetPageParamsAndToInt("isre");
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;
            bool remove = false;
            if (Common.Util.GetPageParamsAndToInt("remove") != -100)
                remove = Common.Util.ChangeStrToBool(Common.Util.GetPageParams("remove"));

            using (DataSet ds = Logic.Consult.GetForum(userid, isre, remove, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }

                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        htc.InnerHtml = string.Format("<a href=\"javascript:showContext('c{1}')\">{0}</a>", reader["title"].ToString(), (startid + runv).ToString());
                        tr.Cells.Add(htc);
                        htc = new HtmlTableCell();
                        AdvAli.Entity.User getUser = Logic.Consult.GetUser(Common.Util.ChangeStrToInt(reader["userid"].ToString()));
                        htc.InnerHtml = getUser.Inc;
                        htc.Attributes.Add("title", reader["postip"].ToString() + "\n" + Common.QQWry.GetIpLocation(Server.MapPath("~/data/qqwry.dat"), reader["postip"].ToString()).Country);
                        tr.Cells.Add(htc);
                        data.Rows.Add(tr);
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        tr.Style.Add("display", "none");
                        tr.Attributes.Add("id", ("c" + (startid + runv)).ToString());
                        htc.Attributes.Add("class", "context");
                        htc.ColSpan = 3;
                        if (this.GetLoggedUserGroupId() >= 8)
                        {
                            htc.InnerHtml = string.Format("<div class=\"post\">&nbsp;&nbsp;&nbsp;&nbsp;{0}&nbsp;&nbsp;<a href=\"javascript:repost({4})\" class=\"respan\">[回复]</a><br /><span class=\"timer\">({1})</span></div><div class=\"re\"><span class=\"mng\">管理员回复：</span><br />&nbsp;&nbsp;&nbsp;&nbsp;{2}<br /><span class=\"timer\">({3})</span></div>", reader["context"].ToString(), Common.Util.ConvertToDateTime(reader["postdate"].ToString()).ToString("yyyy年MM月dd日 hh:mm:ss"), reader["re"].ToString(), Common.Util.ConvertToDateTime(reader["redate"].ToString()).ToString("yyyy年MM月dd日 hh:mm:ss"), reader["id"].ToString());
                        }
                        else if (Common.Util.ChangeStrToBool(reader["isre"].ToString()))
                        {
                            htc.InnerHtml = string.Format("<div class=\"post\">&nbsp;&nbsp;&nbsp;&nbsp;{0}<br /><span class=\"timer\">({1})</span></div><div class=\"re\"><span class=\"mng\">管理员回复：</span><br />&nbsp;&nbsp;&nbsp;&nbsp;{2}<br /><span class=\"timer\">({3})</span></div>", reader["context"].ToString(), Common.Util.ConvertToDateTime(reader["postdate"].ToString()).ToString("yyyy年MM月dd日 hh:mm:ss"), reader["re"].ToString(), Common.Util.ConvertToDateTime(reader["redate"].ToString()).ToString("yyyy年MM月dd日 hh:mm:ss"));
                        }
                        else
                        {
                            htc.InnerHtml = string.Format("<div class=\"post\">&nbsp;&nbsp;&nbsp;&nbsp;{0}<br /><span class=\"timer\">({1})</span></div>", reader["context"].ToString(), Common.Util.ConvertToDateTime(reader["postdate"].ToString()).ToString("yyyy年MM月dd日 hh:mm:ss"));
                        }

                        tr.Cells.Add(htc);
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void GetKeys(HtmlTable data)
        {
            string[] fields = Fields.Split(new char[] { ',' });
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;
            int userid = this.GetLoggedMemberId();
            if (this.GetLoggedUserGroupId() >= 8)
                userid = 0;
            int siteid = 0, groupid = 0;
            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid = Common.Util.GetPageParamsAndToInt("siteid");
            if (Common.Util.GetPageParamsAndToInt("group") != -100)
                groupid = Common.Util.GetPageParamsAndToInt("group");
            using (DataSet ds = Logic.Consult.GetKeys(userid, siteid, groupid, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }
                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        for (int i = 0; i < fields.Length; i++)
                        {
                            HtmlTableCell td = new HtmlTableCell();
                            if (fields[i].ToLower() != "flag")
                            {
                                if (!string.IsNullOrEmpty(reader[fields[i]].ToString()))
                                    td.InnerHtml = reader[fields[i]].ToString();
                                else
                                    td.InnerHtml = "&nbsp;";
                                tr.Cells.Add(td);
                            }
                            else
                            {
                                bool flag = AdvAli.Common.Util.ChangeStrToBool(reader["flag"].ToString());
                                if (flag)
                                    td.InnerHtml = "允许";
                                else
                                    td.InnerHtml = "拒绝";
                                tr.Cells.Add(td);
                            }
                        }
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
        protected void GetKeysGroup(HtmlTable data)
        {
            string[] fields = Fields.Split(new char[] { ',' });
            string[] fieldsname = FieldName.Split(new char[] { ',' });
            string[] fieldswidth = FieldWidth.Split(new char[] { ',' });
            int pageIndex = (Common.Util.GetPageParamsAndToInt("Page") > 0) ? Common.Util.GetPageParamsAndToInt("Page") : 1;
            int userid = this.GetLoggedMemberId();
            if (this.GetLoggedUserGroupId() >= 8)
                userid = 0;
            int siteid = 0;
            if (Common.Util.GetPageParamsAndToInt("siteid") != -100)
                siteid = Common.Util.GetPageParamsAndToInt("siteid");
            using (DataSet ds = Logic.Consult.GetKeysGroup(userid, siteid, pageIndex, HtmlPager.PageSize, out recordcount))
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    HtmlTableRow tr = new HtmlTableRow();
                    tr.Attributes.Add("class", "title");
                    HtmlTableCell htc = new HtmlTableCell();
                    htc.InnerHtml = "<span><input onclick=checkall() type=checkbox id=selall></span>";
                    htc.Width = "30";
                    tr.Cells.Add(htc);
                    for (int i = 0; i < fieldsname.Length; i++)
                    {
                        HtmlTableCell td = new HtmlTableCell();
                        td.Width = fieldswidth[i];
                        td.InnerHtml = fieldsname[i];
                        tr.Cells.Add(td);
                    }
                    data.Rows.Add(tr);
                    Random ro = new Random(DateTime.Now.Millisecond);
                    int startid = ro.Next(1, 100);
                    HtmlInputHidden hih = new HtmlInputHidden();
                    hih.ID = "startid";
                    hih.Value = startid.ToString();
                    Page.Form.Controls.Add(hih);
                    HtmlInputHidden hid = new HtmlInputHidden();
                    hid.ID = "idlist";
                    hid.Value = "";
                    Page.Form.Controls.Add(hid);
                    int runv = 0;
                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        tr = new HtmlTableRow();
                        htc = new HtmlTableCell();
                        htc.InnerHtml = "<input value=\"" + reader["id"].ToString() + "\" type=checkbox onclick=\"SetHid('" + reader["id"].ToString() + "');\" id=sel" + (startid + runv).ToString() + " />";
                        tr.Cells.Add(htc);
                        for (int i = 0; i < fields.Length; i++)
                        {
                            HtmlTableCell td = new HtmlTableCell();
                            if (!string.IsNullOrEmpty(reader[fields[i]].ToString()))
                                td.InnerHtml = reader[fields[i]].ToString();
                            else
                                td.InnerHtml = "&nbsp;";
                            tr.Cells.Add(td);
                        }
                        data.Rows.Add(tr);
                        runv++;
                    }
                }
            }
        }
    }
}
