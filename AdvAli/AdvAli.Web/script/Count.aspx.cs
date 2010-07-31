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

namespace AdvAli.Web.script
{
    public partial class Count : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int siteid = Common.Util.GetPageParamsAndToInt("siteid");
            HtmlCount.AnalysisAdd();
            Response.Clear();
            Response.End();
        }
    }
}
