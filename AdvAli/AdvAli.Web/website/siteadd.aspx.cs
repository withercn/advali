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
    public partial class siteadd : AdminPage
    {
        public string WebSiteName = AdvAli.Config.Global.config.WebSiteName;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 11;
            base.Page_Load(sender, e);
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

        protected void WebSiteAdd_Click(object sender, EventArgs e)
        {
            HtmlWebSite.WebSiteAdd();
        }
    }
}
