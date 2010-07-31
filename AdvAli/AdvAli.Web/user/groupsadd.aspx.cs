using System;
using AdvAli.Web.Html.UI;
using AdvAli.Web.Html;
using AdvAli.Entity;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AdvAli.Web.user
{
    public partial class groupsadd : AdminPage
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 10;
            base.Page_Load(sender, e);
            id.Value = HtmlGroups.GetMaxGroupId().ToString();
        }

        protected void GroupsAdd_Click(object sender, EventArgs e)
        {
            HtmlGroups.GroupsAdd();
        }

        protected override void BindData()
        {
            this.BindAdmins();
            base.BindData();
        }

        private void BindAdmins()
        {
            HtmlInputHidden hih = new HtmlInputHidden();
            hih.ID = "hid";
            hih.Value = "";
            Page.Form.Controls.Add(hih);
            using (DataSet reader = Logic.Consult.GetAdmins())
            {
                if (Common.Util.CheckDataSet(reader))
                {
                    foreach (DataRow dr in reader.Tables[0].Rows)
                    {
                        HtmlGenericControl li = new HtmlGenericControl("li");
                        HtmlInputCheckBox checkbox = new HtmlInputCheckBox();
                        checkbox.ID = string.Format("admin{0}", dr["id"].ToString());
                        checkbox.Attributes.Add("onclick", "SetCustomizeAdmins(this);");
                        checkbox.Attributes.Add("value", dr["id"].ToString());
                        li.Controls.Add(checkbox);
                        HtmlGenericControl label = new HtmlGenericControl("label");
                        label.Attributes.Add("for", string.Format("admin{0}", dr["id"].ToString()));
                        label.InnerText = dr["adminname"].ToString();
                        li.Controls.Add(label);
                        RightsList.Controls.Add(li);
                    }
                }
            }
        }
    }
}
