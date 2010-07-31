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
    public partial class rightsedit : AdminPage
    {
        private int userid = 0;
        private User users;

        protected override void Page_Load(object sender, EventArgs e)
        {
            userid = Common.Util.GetPageParamsAndToInt("id");
            users = Logic.Consult.GetUser(userid);
            if (!Page.IsPostBack)
                this.txtUsername.Value = users.Username;
            base.IsNeedCheckRights=true;
            base.BrowserRightsIntValue = 9;
            base.Page_Load(sender, e);
        }

        protected override void BindData()
        {
            Common.Util.BindCtrlDDL(Logic.Consult.GetGroups(), "groupname", "id", group, users.GroupId.ToString());
            var count = group.Items.Count;
            if (users.GroupId != 9)
            {
                for (int i = 0; i < count; i++)
                {
                    if (int.Parse(group.Items[i].Value) >= base.user.GroupId)
                    {
                        group.Items.Remove(group.Items[i]);
                        if (i < count - 1)
                        {
                            i--;
                            count--;
                        }
                    }
                }
            }
            if (!Page.IsPostBack)
                this.BindGroupsOfAdmins();
            base.BindData();
        }

        protected void RightsEdit_Click(object sender, EventArgs e)
        {
            string thisrights = "";
            if (int.Parse(group.SelectedValue) != 999)
            {
                thisrights = Logic.Consult.GetGroupAdmins(int.Parse(group.SelectedValue));
            }
            else
            {
                thisrights = HttpContext.Current.Request["hid"];
                if (thisrights.Length > 0)
                    thisrights = thisrights.Substring(0, thisrights.Length - 1);
            }
            HtmlUser.EditUserRights(userid, int.Parse(group.SelectedValue), thisrights);
            this.BindGroupsOfAdmins();
        }

        protected void Groups_Change(object sender, EventArgs e)
        {
            this.BindGroupsOfAdmins();
        }

        protected void BindGroupsOfAdmins()
        {
            string currentAdmins = "";
            if (int.Parse(this.group.SelectedValue) != 999)
                currentAdmins = Logic.Consult.GetGroupAdmins(int.Parse(this.group.SelectedValue)).Trim();
            else
            {
                Admins admin = Logic.Consult.GetAdmins(userid);
                foreach (Admin adm in admin)
                {
                    currentAdmins += adm.AdminId.ToString() + ",";
                }
                if (currentAdmins.Length > 0) currentAdmins = currentAdmins.Substring(0, currentAdmins.Length - 1);
            }
            string[] currentGroupAdmins = currentAdmins.Split(new char[] { ',' });
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
                        if (int.Parse(this.group.SelectedValue) != 999)
                            checkbox.Attributes.Add("disabled", "disabled");
                        else
                        {
                            checkbox.Attributes.Add("onclick", "SetCustomizeAdmins(this);");
                            checkbox.Attributes.Add("value", dr["id"].ToString());
                        }
                        for (int i = 0; i < currentGroupAdmins.Length; i++)
                        {
                            if (dr["id"].ToString() == currentGroupAdmins[i])
                                checkbox.Checked = true;
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
