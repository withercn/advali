using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdvAli.Web
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int adType = 0;
            int adId = 0;
            Logic.Consult.GetAdKeyWebSiteId("深圳医疗", 214, out  adType, out adId);
        }
    }
}
