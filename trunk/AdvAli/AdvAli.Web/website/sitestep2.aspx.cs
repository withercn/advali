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

namespace AdvAli.Web.website
{
    public partial class sitestep2 : AdminPage
    {
        public string WebSiteName = AdvAli.Config.Global.config.WebSiteName;
        public int id = 0;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 11;
            base.Page_Load(sender, e);
            id = Common.Util.GetPageParamsAndToInt("id");
            if (!Page.IsPostBack && id != -100)
                this.BData();
        }

        private void BData()
        {
            Entity.Site site = Logic.Consult.GetWebSite(id);
            txtRange.Value = site.RangeList.Replace("$", "");
            string[] txt = txtRange.Value.Split(new char[] { ',' });
            ArrayList al = new ArrayList();
            txtRange.Value = "";
            foreach (string t in txt)
            {
                if (!al.Contains(t) && !string.IsNullOrEmpty(t))
                {
                    al.Add(t);
                    txtRange.Value += t + ",";
                }
            }
            if (txtRange.Value.Length > 0)
                txtRange.Value = txtRange.Value.Substring(0, txtRange.Value.Length - 1);
            this.CreateCheckItem(txtRange.Value, HtmlWebSite.GetAdRang(txtRange.Value));
        }

        protected void SaveStep2_Click(object sender, EventArgs e)
        {
            HtmlWebSite.SaveStep2(id);
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

        protected void Step1_Click(object sender, EventArgs e)
        {
            id = Common.Util.GetPageParamsAndToInt("id");
            if (id != -100)
                Response.Redirect(string.Format("sitestep1.aspx?id={0}", id.ToString()));
        }
    }
}
