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
    public partial class groupsedit : AdminPage
    {
        private int gid = 0;

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.isNeedCheckRights = true;
            base.BrowserRightsIntValue = 10;
            base.Page_Load(sender, e);
        }

        protected void GroupsEdit_Click(object sender, EventArgs e)
        {
            HtmlGroups.GroupsEdit();
        }

        protected override void BindData()
        {
            this.BindAdmins();
            base.BindData();
        }

        private void BindAdmins()
        {
            gid = Common.Util.GetPageParamsAndToInt("id");
            Group g = Logic.Consult.GetGroups(gid);
            id.Value = g.Id.ToString();
            groupname.Value = g.GroupName;
            string[] admins = g.Caption.Split(new char[] { ',' });
            HtmlInputHidden hih = new HtmlInputHidden();
            hih.ID = "hid";
            hih.Value = g.Caption + ",";
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
                        for (int i = 0; i < admins.Length; i++)
                        {
                            if (admins[i] == dr["id"].ToString())
                            {
                                checkbox.Checked = true;
                                break;
                            }
                        }
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
