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
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;
using System.Text.RegularExpressions;

namespace AdvAli.Web.website
{
    public partial class siteedit : AdminPage
    {
        public int id = 0;
        public string GuidecHtml = "<li class=\"h30 left\">广告文字1：</li>\r\n<li class=\"inputs left\"><input type=\"text\" id=\"article1\" name=\"article1\" class=\"loginInput\" /></li>\r\n<li style=\"clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;\">&nbsp;</li>\r\n<li class=\"h30 left\">文字链接1：</li><li class=\"inputs left\"><input type=\"text\" id=\"articlelink1\" name=\"articlelink1\" class=\"loginInput\" /></li><li style=\"clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;\">&nbsp;</li>";
        public string QQMsnHtml = "<li class=\"left\">QQ号码1：</li><li class=\"inputf left\"><input id=\"qqnum1\" name=\"qqnum1\" type=\"text\" class=\"loginInput\" /></li><li class=\"left\">QQ名称1：</li><li class=\"inputf left\"><input id=\"qqs1\" name=\"qqs1\" type=\"text\" class=\"loginInput\" /></li><li style=\"clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;\">&nbsp;</li><li class=\"left\">QQ说明1：</li><li class=\"inputs left\"><input id=\"qqtitle1\" name=\"qqtitle1\" type=\"text\" class=\"loginInput\" /></li><li style=\"clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;\">&nbsp;</li>";
        public string ImagesHtml = "<li class=\"h30\">图片名称：</li><li class=\"inputs\"><input type=\"text\" value=\"{0}\" id=\"picname\" name=\"picname\" class=\"loginInput\" /></li><li class=\"h30\">图片地址：</li><li class=\"h30\"><input type=\"file\" id=\"picurl\" name=\"picurl\" class=\"loginInput\" /></li><li class=\"h30\">图片链接：</li><li class=\"inputs\"><input type=\"text\" id=\"piclnk\" name=\"piclnk\" class=\"loginInput\" /></li>";
        public string WebSiteName = AdvAli.Config.Global.config.WebSiteName;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 12;
            base.Page_Load(sender, e);
            id = Common.Util.GetPageParamsAndToInt("id");
            if (id == -100)
                Response.Redirect(AdvAli.Config.Global.__WebSiteUrl + "/website/index.aspx", true);
            if (!Page.IsPostBack)
                this.PageBind();
        }

        protected override void BindData()
        {
            HtmlSelect province = new HtmlSelect();
            province.Attributes.Add("onchange", "showSelect(this.value)");
            selectSub.Controls.Add(province);
            using (DataSet ds = Logic.Consult.GetProvince())
            {
                if (Common.Util.CheckDataSet(ds))
                {
                    Common.Util.BindCtrlHTMLDDL(ds, "proName", "proId", province);

                    foreach (DataRow reader in ds.Tables[0].Rows)
                    {
                        HtmlGenericControl div = new HtmlGenericControl("div");
                        div.ID = "c0" + reader["proId"].ToString();
                        using (DataSet city = Logic.Consult.GetCity(Common.Util.ConvertToInt(reader["proId"].ToString())))
                        {
                            if (Common.Util.CheckDataSet(city))
                            {
                                foreach (DataRow dr in city.Tables[0].Rows)
                                {
                                    HtmlInputCheckBox check = new HtmlInputCheckBox();
                                    check.Value = dr["cityId"].ToString();
                                    check.Attributes.Add("onclick", "addPreItem()");
                                    check.ID = "chk" + dr["cityId"].ToString();
                                    check.Attributes.Add("title", dr["cityName"].ToString());
                                    div.Controls.Add(check);
                                    HtmlGenericControl label = new HtmlGenericControl("label");
                                    label.Attributes.Add("for", "chk" + dr["cityId"].ToString());
                                    label.InnerText = dr["cityName"].ToString();
                                    div.Controls.Add(label);
                                }
                            }
                        }
                        selectSub.Controls.Add(div);
                    }
                }
            }

            if (!Page.IsPostBack)
            {
                Common.Util.BindCtrlHTMLDDL(Logic.Consult.GetAdType(), "adtype", "id", adTypeSelect);
                adTypeSelect.Items.Insert(0, new ListItem("请选择", "0"));
            }
            adTypeSelect.SelectedIndex = 0;
            base.BindData();
        }

        protected void PageBind()
        {
            Entity.Site site = Logic.Consult.GetWebSite(id);
            txtwebname.Value = site.SiteName;
            txtUrl.Value = site.SiteUrl;
            sitenote.Value = site.SiteNote;
            txtRange.Value = site.RangeList.Replace("$", "");
            this.CreateCheckItem(txtRange.Value, HtmlWebSite.GetAdRang(txtRange.Value));
            adTypeSelect.Value = site.AdDisplay.ToString();
            ClientScript.RegisterStartupScript(this.GetType(), "Initing", string.Format("attack(\"{0}\");", site.AdDisplay), true);
            int adid = site.AdId;
            curscript.Value = site.CurScript;
            object obj = HtmlWebSite.GetAdvert(site.AdDisplay, site.AdId);
            switch (site.AdDisplay)
            {
                case 1:
                    this.BindGuidecInfo((Guidec)obj);
                    break;
                case 2:
                    this.BindQQMsnInfo((QQMsn)obj);
                    break;
                case 3:
                    this.BindQQMsnInfo((QQMsn)obj);
                    break;
                case 4:
                    this.BindImagesInfo((Images)obj);
                    break;
            }
        }

        private void BindGuidecInfo(Guidec guidec)
        {
            guidechead.Value = guidec.Title;
            guideclink.Value = guidec.Link;
        }

        private void BindQQMsnInfo(QQMsn qqmsn)
        {
            qqhead.Value = qqmsn.Header;
            qqbottom.Value = qqmsn.Bottom;
            string[] qqnum = qqmsn.Account.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
            string[] qqs = qqmsn.Namer.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
            string[] qqtitle = qqmsn.Notes.Split(new string[] { "|||" }, StringSplitOptions.RemoveEmptyEntries);
            if (qqnum.Length == 0 || qqs.Length == 0 || qqtitle.Length == 0)
                return;
            QQMsnHtml = "";
            string qm = qqmsn.IsQQ ? "QQ" : "Msn";
            t1.InnerHtml = qm + "头部信息";
            t2.InnerHtml = qm + "底部信息";
            for (int i = 0; i < qqnum.Length; i++)
            {
                string n = (i + 1).ToString();
                QQMsnHtml += "<li class=\"left\">" + qm + "号码" + n + "：</li>\r\n";
                QQMsnHtml += "<li class=\"inputf left\"><input id=\"qqnum" + n + "\" name=\"qqnum" + n + "\" value=\"" + qqnum[i] + "\" type=\"text\" class=\"loginInput\" /></li>\r\n";
                QQMsnHtml += "<li class=\"left\">" + qm + "名称" + n + "：</li>\r\n";
                QQMsnHtml += "<li class=\"inputf left\"><input id=\"qqs" + n + "\" name=\"qqs" + n + "\" value=\"" + qqs[i] + "\" type=\"text\" class=\"loginInput\" /></li>\r\n";
                QQMsnHtml += "<li style=\"clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;\">&nbsp;</li>";
                QQMsnHtml += "<li class=\"left\">" + qm + "说明1：</li>\r\n";
                QQMsnHtml += "<li class=\"inputs left\"><input id=\"qqtitle" + n + "\" name=\"qqtitle" + n + "\" value=\"" + qqtitle[i] + "\" type=\"text\" class=\"loginInput\" /></li>\r\n";
                QQMsnHtml += "<li style=\"clear:both;font-size:0px;overflow:hidden;height:0px;line-height:0px;\">&nbsp;</li>\r\n";
            }
            qqn.Value = qqnum.Length.ToString();
            isqq.Value = qqmsn.IsQQ ? "1" : "0";
        }

        private void BindImagesInfo(Images image)
        {
            picwidth.Value = image.Width.ToString();
            picheight.Value = image.Height.ToString();
            ImagesHtml = "";
            ImagesHtml += "<li class=\"h30\">图片名称：</li>\r\n";
            ImagesHtml += "<li class=\"inputs\"><input type=\"text\" id=\"picname\" name=\"picname\" value=\"" + image.ImageName + "\" class=\"loginInput\" /></li>\r\n";
            ImagesHtml += "<li class=\"h30\">图片地址：<a id=\"pichref\" href=\"" + image.ImageUrl + "\" target=\"_blank\">" + image.ImageUrl + "</a><input type=\"hidden\" name=\"pice\" value=\"" + image.ImageUrl + "\" /></li>\r\n";
            ImagesHtml += "<li class=\"h30\"><input type=\"file\" id=\"picurl\" name=\"picurl\"  class=\"loginInput\" /></li>\r\n";
            ImagesHtml += "<li class=\"h30\">图片链接：</li>\r\n";
            ImagesHtml += "<li class=\"inputs\"><input type=\"text\" id=\"piclnk\" name=\"piclnk\" value=\"" + image.ImageLink + "\" class=\"loginInput\" /></li>\r\n";
        }

        protected void WebSiteEdit_Click(object sender, EventArgs e)
        {
            HtmlWebSite.WebSiteEdit(id);
        }

        private void CreateCheckItem(string rangeId, string rangeList)
        {
            string[] id = rangeId.Split(new char[] { ',' });
            string[] list = rangeList.Split(new char[] { ',' });
            if (id.Length != list.Length) return;
            string prevItem = "";
            for (int i = 0; i < id.Length; i++)
            {
                HtmlInputCheckBox cb = new HtmlInputCheckBox();
                cb.Attributes.Add("title", list[i]);
                cb.Attributes.Add("onclick", "copyItem(\"makeSureItem\",\"previewItem\");same(this);");
                cb.Value = id[i];
                cb.Checked = true;
                makeSureItem.Controls.Add(cb);
                HtmlGenericControl gc = new HtmlGenericControl();
                gc.InnerText = list[i];
                makeSureItem.Controls.Add(gc);
                prevItem += "<input type='checkbox' checked='true' title='" + list[i] + "' value='" + id[i] + "' onclick='copyItem(\"previewItem\",\"previewItem\");same(this);'>" + list[i];
                foreach (Control ctl in selectSub.Controls)
                {
                    if (ctl.HasControls())
                    {
                        if (ctl.ID.Substring(0, 1).ToLower() == "c")
                        {
                            foreach (Control ctrls in ctl.Controls)
                            {
                                if (ctrls is HtmlInputCheckBox)
                                {
                                    HtmlInputCheckBox hic = (HtmlInputCheckBox)ctrls;
                                    if (hic.Attributes["title"].ToString() == list[i])
                                        hic.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            previewItem.InnerHtml = prevItem;
        }
    }
}
